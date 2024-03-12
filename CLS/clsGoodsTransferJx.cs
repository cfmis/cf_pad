using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using cf_pad.MDL;

namespace cf_pad.CLS
{
    public class clsGoodsTransferJx
    {
        private static String strConn = DBUtility.dgcf_pad_connectionString;
        private static string remote_db = DBUtility.remote_db;

        public static DataTable FindTransferData(string dep,string prd_date,string mo_id,bool transfer_type,int transfer_flag)
        {
            string strSql = "Select a.*,b.name AS Prd_item_cdesc,Convert(Varchar(20),Crtim,120) AS crtim_str" +
                " From product_transfer_jx_details a" +
                " Left Join dgcf_db.dbo.geo_it_goods b ON a.Prd_item COLLATE chinese_taiwan_stroke_CI_AS=b.id" +
                " Where a.Prd_dep='" + dep + "'";
            if (prd_date.Trim() != "")
                strSql += " AND a.Transfer_date='" + prd_date + "'";
            if (mo_id != "")
                strSql += " AND a.Prd_mo Like " + "'%" + mo_id + "%'";
            //int Transfer_flag = 2;
            //if (transfer_type == true)
            //    Transfer_flag = 0;
            //else if (transfer_type == true)
            //    Transfer_flag = 1;
            //if (Transfer_flag != 2)
            //    strSql += " AND a.Transfer_flag='" + Transfer_flag + "'";
            strSql += " Order By a.crtim DESC";
            DataTable dtTran = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            return dtTran;
        }


        public static DataTable FindData(string Prd_dep, string Prd_date, string Prd_item, string Prd_mo)
        {
            string strSql = "Select a.*,b.name AS Prd_item_cdesc,Convert(Varchar(20),Crtim,120) AS crtim_str" +
                " From product_transfer_jx_details a" +
                " Left Join dgcf_db.dbo.geo_it_goods b ON a.Prd_item COLLATE chinese_taiwan_stroke_CI_AS=b.id" +
                " Where a.Prd_dep>=''";
            if (Prd_dep != "")
                strSql += " And a.Prd_dep='" + Prd_dep + "'";
            if (Prd_date != "")
                strSql += " And a.Transfer_date='" + Prd_date + "'";
            if (Prd_item != "")
                strSql += " And a.Prd_item='" + Prd_item + "'";
            if (Prd_mo != "")
                strSql += " And a.Prd_mo='" + Prd_mo + "'";
            strSql += " Order By a.crtim DESC";
            DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            return dt;
        }

        public static DataTable FindOldData(string Prd_dep, string Prd_item, string Prd_mo)
        {
            string strSql = "Select a.Transfer_qty,a.Transfer_weg " +
                " From product_transfer_jx_details a" +
                " Where a.Prd_dep='" + Prd_dep + "' AND a.Prd_item='" + Prd_item + "' AND a.Prd_mo='" + Prd_mo + "'";
            strSql += " Order By a.crtim DESC";
            DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            return dt;
        }

        //public static DataTable CheckStore(string Prd_dep, string Prd_item, string Prd_mo)
        //{
        //    string strSql = "Select * From product_transfer_jx_summary Where Prd_dep='" + Prd_dep + "' AND Prd_item='" + Prd_item + "' AND Prd_mo='" + Prd_mo + "'";
        //    DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
        //    return dt;
        //}

        public static DataTable GetPrintData(string Prd_dep, string Prd_date, string Transfer_flag)
        {
            string strSql = "Select a.prd_dep,d.dep_cdesc AS prd_dep_cdesc,a.prd_mo,a.prd_item,b.name AS prd_item_cdesc" +
                    ",a.transfer_qty,a.transfer_weg,a.wip_id" +
                    ",a.transfer_date,c.flag_desc,a.to_dep,e.dep_cdesc AS to_dep_cdesc " +
                    " FROM product_transfer_jx_details a" +
                    " LEFT JOIN dgcf_db.dbo.geo_it_goods b ON a.prd_item=b.id COLLATE chinese_taiwan_stroke_CI_AS" +
                    " LEFT JOIN dgcf_db.dbo.bs_flag_desc c ON a.transfer_flag=c.flag_id COLLATE chinese_taiwan_stroke_CI_AS" +
                    " LEFT JOIN dgcf_db.dbo.bs_dep d ON a.wip_id=d.dep_id COLLATE chinese_taiwan_stroke_CI_AS" +
                    " LEFT JOIN dgcf_db.dbo.bs_dep e ON a.to_dep=e.dep_id COLLATE chinese_taiwan_stroke_CI_AS" +
                    " WHERE c.doc_type='goods_transfer_jx'";
            if (Prd_dep != "")
                strSql += " AND a.prd_dep='" + Prd_dep + "'";
            if (Prd_date != "")
                strSql += " AND a.Transfer_date='" + Prd_date + "'";
            if (Transfer_flag.Trim() == "0" || Transfer_flag.Trim() == "1")
                strSql += " AND a.Transfer_flag='" + Transfer_flag + "'";
            strSql += " ORDER BY a.prd_dep,a.Transfer_flag,a.transfer_date,a.prd_item,a.prd_mo";
            DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            return dt;
        }

        public static int UpdateGoodsTransferJx(product_transfer_jx_details objModel)
        {
            int Result = 0;
            string strSql = "";
            string Prd_dep = objModel.Prd_dep;
            string Prd_mo = objModel.Prd_mo;
            string Prd_item = objModel.Prd_item;
            string Transfer_date = objModel.Transfer_date;
            int Transfer_flag = objModel.Transfer_flag;
            decimal Transfer_qty = objModel.Transfer_qty;
            decimal Transfer_weg = objModel.Transfer_weg;
            string Crusr = objModel.Crusr;
            string Crtim = objModel.Crtim;

            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            strSql += string.Format(@"Insert Into product_transfer_jx_details (Transfer_date,Prd_dep,prd_item,prd_mo,Transfer_flag,transfer_qty,transfer_weg
                ,wip_id,to_dep,pack_num,sent_date,crusr,crtim) Values " +
                "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')"
                , Transfer_date, Prd_dep, Prd_item, Prd_mo, objModel.Transfer_flag, objModel.Transfer_qty, objModel.Transfer_weg
                , objModel.wipId, objModel.To_dep, objModel.packNum, objModel.sentDate, objModel.Crusr, objModel.Crtim);

            strSql += string.Format(@" COMMIT TRANSACTION ");

            Result = clsPublicOfPad.ExecuteSqlUpdate(strSql);
            return Result;

        }

        //private static DataTable checkStore(string Prd_dep, string Prd_item, string Prd_mo)
        //{
        //    string strSql = "Select * From product_transfer_jx_summary Where Prd_dep='" + Prd_dep + "' AND Prd_item='" + Prd_item + "' AND Prd_mo='" + Prd_mo + "'";
        //    DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
        //    return dt;
        //}
        public static DataTable CheckGoodsTransferJx(string Prd_dep, string Prd_item, string Prd_mo, int Transfer_flag)
        {
            string strSql = "Select * From product_transfer_jx_details Where Prd_dep='" + Prd_dep + "' AND Prd_item='" + Prd_item + "' AND Prd_mo='" + Prd_mo
                + "' AND Transfer_flag='" + Transfer_flag + "'";
            DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            return dt;
        }


        public static int Del(int Prd_id)
        {
            int result = 0;
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            strSql += string.Format(@"Delete From product_transfer_jx_details Where Prd_id='{0}'"
                , Prd_id);
            strSql += string.Format(@" COMMIT TRANSACTION ");

            result = clsPublicOfPad.ExecuteSqlUpdate(strSql);
            return result;
        }

    }
}
