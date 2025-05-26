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
        public static bool SavePrintData(string mo_id,string goods_id,int qty,decimal weg,decimal weg_gross,string mo_group,int package_num,string carton_size,string suit_flag,List<string> list)
        {
            DataTable dtFind = new DataTable();
            bool flag = true;
            string sql_u = "";
            string sql_f = string.Format(
            @"Select '1' From packing_mo_label with(nolock) Where mo_id='{0}' And goods_id='{1}' And qty={2} And package_num={3}", mo_id, goods_id,qty, package_num);
            if (suit_flag == "0")
            {
                dtFind = clsPublicOfPad.ExecuteSqlReturnDataTable(sql_f);
                if (dtFind.Rows.Count == 0)
                {
                    sql_u = string.Format(
                    @" Insert Into packing_mo_label(mo_id,goods_id,qty,weg,weg_gross,upd_flag,mo_group,package_num,update_by,update_date,carton_size,suit_flag) 
                    values ('{0}','{1}',{2},{3},{4},'{5}','{6}',{7},'{8}',getdate(),'{9}','{10}')",
                    mo_id, goods_id, qty, weg, weg_gross, "0", mo_group, package_num, DBUtility._user_id, carton_size, suit_flag);                    
                }
                else
                {
                    sql_u = string.Format(
                    @" UPDATE packing_mo_label SET weg={4},weg_gross={5},carton_size='{6}',suit_flag='{7}' 
                    Where mo_id='{0}' And goods_id='{1}' And qty={2} And package_num={3}",
                    mo_id, goods_id, qty, package_num, weg, weg_gross, carton_size, suit_flag);
                }
                if (clsPublicOfPad.ExecuteSqlUpdate(sql_u) > 0)
                    flag = true;
                else
                    flag = false;
            }
            else
            {
                //底三件走貨
                if(suit_flag == "1" && list.Count>0)
                {
                    sql_u = "";
                    foreach (var item in list)
                    {
                        sql_f = string.Format(
                        @"Select '1' From packing_mo_label with(nolock) Where mo_id='{0}' And goods_id='{1}' And qty={2} And package_num={3}", mo_id, item, qty, package_num);
                        dtFind = clsPublicOfPad.ExecuteSqlReturnDataTable(sql_f);
                        if (dtFind.Rows.Count == 0)
                        {
                            sql_u += string.Format(
                            @" Insert Into packing_mo_label(mo_id,goods_id,qty,weg,weg_gross,upd_flag,mo_group,package_num,update_by,update_date,carton_size,suit_flag) 
                            values ('{0}','{1}',{2},{3},{4},'{5}','{6}',{7},'{8}',getdate(),'{9}','{10}')",
                            mo_id, item, qty, weg, weg_gross, "0", mo_group, package_num, DBUtility._user_id, carton_size, suit_flag);
                        }
                        else
                        {
                            sql_u += string.Format(
                            @" UPDATE packing_mo_label SET weg={4},weg_gross={5},carton_size='{6}',suit_flag='{7}' 
                            Where mo_id='{0}' And goods_id='{1}' And qty={2} And package_num={3}",
                            mo_id, item, qty, package_num, weg, weg_gross, carton_size, suit_flag);
                        }
                    }
                    if (clsPublicOfPad.ExecuteSqlUpdate(sql_u) > 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            
            return flag;
        }
    }
}
