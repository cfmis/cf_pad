using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace cf_pad.CLS
{
    public static class clsInventory
    {
        private static string remote_db = DBUtility.remote_db;
        private static string within_code = DBUtility.within_code;
        public static DataTable GetGoodsStock(string dep,string mo_id,string goods_id)
        {
            string strSql = " Select a.mo_id,a.goods_id" +
                ",Convert(Int,Sum(qty)) AS st_qty,Convert(Decimal(18,2),Sum(sec_qty)) AS st_weg " +
                " From " + remote_db + "st_details_lot a" +
                " Where a.within_code='" + within_code + "' And a.location_id='" + dep + "' And a.mo_id='" + mo_id
                + "' And a.goods_id='" + goods_id + "' And a.carton_code<>'ZZZ'" +
                " Group By a.mo_id,a.goods_id ";
            DataTable dtSt = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            return dtSt;
        }
        public static string Save()
        {
            string result = "";
            return result;
        }

        public static DataTable GetWipDataWithMo(string mo_id, string prd_dept,string goods_id)
        {
            DataTable dtmo_data = new DataTable();
            string strSql = @" SELECT a.mo_id,a.ver,b.sequence_id,b.wp_id,b.goods_id,c.name as goods_name
                    ,Convert(Int,b.prod_qty) AS prod_qty,b.next_wp_id,Rtrim(b.wp_id)+'-'+Rtrim(b.goods_id) As goods_dep
                    from jo_bill_mostly a 
                    INNER join jo_bill_goods_details b on a.within_code=b.within_code and a.id=b.id 
                    INNER JOIN it_goods c on b.within_code=c.within_code and b.goods_id=c.id 
                    WHERE a.within_code='0000'  And a.mo_id = '" + mo_id + "'";
            //if (prd_dept != "")
            //    strSql += " And b.wp_id in " + prd_dept + " ";
            if (goods_id != "")
                strSql += " And b.goods_id='" + goods_id + "'";
            dtmo_data = clsPublicOfGeo.ExecuteSqlReturnDataTable(strSql);
            return dtmo_data;
        }

        public static DataTable GetWipDataWithMoMat(string mo_id, string prd_dept, string goods_id)
        {
            DataTable dtmo_data = new DataTable();
            string strSql = @" SELECT a.mo_id,a.ver,c.sequence_id,b.wp_id,c.materiel_id AS goods_id,d.name as goods_name
                , Convert(Int, b.prod_qty) AS prod_qty, b.next_wp_id, Rtrim(b.wp_id) + '-' + Rtrim(c.materiel_id) As goods_dep
                FROM jo_bill_mostly a
                Inner Join jo_bill_goods_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver
                Inner Join jo_bill_materiel_details c ON b.within_code=c.within_code AND b.id=c.id AND b.ver=c.ver AND b.sequence_id=c.upper_sequence
                INNER JOIN it_goods d on c.within_code=d.within_code and c.materiel_id=d.id
                WHERE a.within_code='" + "0000" + "' AND a.mo_id ='" + mo_id + "'";
            if (prd_dept != "")
                strSql += " And b.wp_id = " + prd_dept + " ";
            if (goods_id != "")
                strSql += " And c.materiel_id='" + goods_id + "'";
            dtmo_data = clsPublicOfGeo.ExecuteSqlReturnDataTable(strSql);
            return dtmo_data;
        }
    }
}
