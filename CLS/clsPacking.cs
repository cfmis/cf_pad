using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace cf_pad.CLS
{
    public class clsPacking
    {
        //private static string strConn = DBUtility.dgcf_pad_connectionString;
        public static bool SavePrintData(string mo_id,string goods_id,int qty,decimal weg,decimal weg_gross,string mo_group,int pages)
        {
            bool flag = true;
            string sql_f = string.Format(@"Select '1' From packing_mo_label Where mo_id='{0}' And goods_id='{1}' And pages={2}", mo_id, goods_id,pages);
            DataTable dtFind = clsPublicOfPad.ExecuteSqlReturnDataTable(sql_f);
            if (dtFind.Rows.Count == 0)
            {
                string sql_i = string.Format(
                @"Insert Into packing_mo_label(mo_id,goods_id,qty,weg,weg_gross,upd_flag,mo_group,pages,update_by,update_date) 
                values ('{0}','{1}',{2},{3},{4},'{5}','{6}',{7},'{8}',getdate())", mo_id, goods_id, qty, weg, weg_gross, "0", mo_group, pages, DBUtility._user_id);
                if (clsPublicOfPad.ExecuteSqlUpdate(sql_i) > 0)
                    flag = true;
                else
                    flag = false;
            }
            return flag;
        }
    }
}
