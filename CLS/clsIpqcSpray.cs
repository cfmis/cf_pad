using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using cf_pad.MDL;
using System.Windows.Forms;

namespace cf_pad.CLS
{
    public class clsIpqcSpray
    {
        //private static string strConn = DBUtility.dgcf_pad_connectionString;
        private static string remote_db = DBUtility.remote_db;

        public static DataTable GetTbInit ()
        {
            string strSql =
            @"SELECT dept_id,qc_size as name_dept,date_check,sequence_id,mo_id,lot_no,goods_id,
            qc_logo,qc_size,qc_size_actual,do_color,qty_lot,qty_sample,qty_ac_std,qty_re_std,
            qty_ng,Convert(bit,result_check) as result_check,result_desc_ng,package_num,weight,
            Convert(bit,is_complete) as is_complete,remark as goods_name
            FROM qc_report_spray
            WHERE 1=0";
            DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            return dt;
        }

        public static string GetMaxSeq(string dept_id,string date_check)
        {
            string result = "";
            string strSql = string.Format(@"Select Max(sequence_id) as sequence_id FROM qc_report_spray Where dept_id='{0}' And date_check='{1}'", dept_id, date_check);
            DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            result = dt.Rows[0]["sequence_id"].ToString();
            if (!string.IsNullOrEmpty(result))
            {
                result = (int.Parse(dt.Rows[0]["sequence_id"].ToString()) + 1).ToString().PadLeft(2, '0');
            }
            else
            {
                result = "001";
            }
            return result;
        }
        /// <summary>
        /// 返回例2024/03/26格式日期字符
        /// </summary>
        /// <returns></returns>
        public static string GetDBDate()
        {
            string result = "";
            DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable("Select convert(varchar(10),getdate(),111) as date");
            result = dt.Rows[0]["date"].ToString();//2024/03/26
            return result;
        }

        public static bool Save(qc_report_spray mdl,string status_edit)
        {
            bool save_flag = false;
            string sql_i =
            @"Insert Into dbo.qc_report_spray (dept_id,date_check,sequence_id,mo_id,lot_no,goods_id,qc_logo,qc_size,qc_size_actual,do_color,qty_lot,
            qty_sample,qty_ac_std,qty_re_std,qty_ng,result_check,result_desc_ng,package_num,weight,is_complete,remark,create_by,create_date) Values
            (@dept_id,@date_check,@sequence_id,@mo_id,@lot_no,@goods_id,@qc_logo,@qc_size,@qc_size_actual,@do_color,@qty_lot,
            @qty_sample,@qty_ac_std,@qty_re_std,@qty_ng,@result_check,@result_desc_ng,@package_num,@weight,@is_complete,@remark,@user_id,getdate())";
            string sql_u =
            @"UPDATE dbo.qc_report_spray 
			SET mo_id=@mo_id,lot_no=@lot_no,goods_id=@goods_id,qc_logo=@qc_logo,qc_size=@qc_size,qc_size_actual=@qc_size_actual,do_color=@do_color,qty_lot=@qty_lot,
            qty_sample=@qty_sample,qty_ac_std=@qty_ac_std,qty_re_std=@qty_re_std,qty_ng=@qty_ng,result_check=@result_check,result_desc_ng=@result_desc_ng,
            package_num=@package_num,weight=@weight,is_complete=@is_complete,remark=@remark,update_by=@user_id,update_date=getdate()
			WHERE dept_id=@dept_id And date_check=@date_check And sequence_id=@sequence_id";
            if(status_edit == "NEW")
            {
                string sql_f = string.Format(@"SELECT '1' AS id FROM qc_report_spray WHERE dept_id='{0}' And date_check='{1}' And sequence_id='{2}'", mdl.dept_id, mdl.date_check, mdl.sequence_id);
                DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(sql_f);
                //多用戶同時操作,可能序號已存在,則重新取最大序號
                if (dt.Rows.Count > 0)
                {
                    mdl.sequence_id = GetMaxSeq(mdl.dept_id,mdl.date_check);
                }
            }            
            try
            {                
                SqlConnection myCon = new SqlConnection(DBUtility.dgcf_pad_connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    myCommand.Parameters.Clear();
                    myCommand.Parameters.AddWithValue("@dept_id", mdl.dept_id);
                    myCommand.Parameters.AddWithValue("@date_check", mdl.date_check);
                    myCommand.Parameters.AddWithValue("@sequence_id", mdl.sequence_id);
                    myCommand.Parameters.AddWithValue("@mo_id", mdl.mo_id);
                    myCommand.Parameters.AddWithValue("@lot_no", mdl.lot_no);
                    myCommand.Parameters.AddWithValue("@goods_id", mdl.goods_id);
                    myCommand.Parameters.AddWithValue("@qc_logo", mdl.qc_logo);
                    myCommand.Parameters.AddWithValue("@qc_size", mdl.qc_size); 
                    myCommand.Parameters.AddWithValue("@qc_size_actual", mdl.qc_size_actual);
                    myCommand.Parameters.AddWithValue("@do_color", mdl.do_color);
                    myCommand.Parameters.AddWithValue("@qty_lot", mdl.qty_lot);
                    myCommand.Parameters.AddWithValue("@qty_sample", mdl.qty_sample);
                    myCommand.Parameters.AddWithValue("@qty_ac_std", mdl.qty_ac_std);
                    myCommand.Parameters.AddWithValue("@qty_re_std", mdl.qty_re_std);
                    myCommand.Parameters.AddWithValue("@qty_ng", mdl.qty_ng);
                    bool result_check = false;
                    if (mdl.result_check.ToString() == "True")
                        result_check = true;
                    else
                        result_check = false;                   
                    myCommand.Parameters.AddWithValue("@result_check", result_check);
                    myCommand.Parameters.AddWithValue("@result_desc_ng", mdl.result_desc_ng);
                    myCommand.Parameters.AddWithValue("@package_num", mdl.package_num);
                    myCommand.Parameters.AddWithValue("@weight", mdl.weight);
                    bool is_complete;
                    if (mdl.is_complete.ToString() == "True")
                        is_complete = true;
                    else
                        is_complete = false;
                    myCommand.Parameters.AddWithValue("@is_complete", is_complete);
                    myCommand.Parameters.AddWithValue("@remark", mdl.remark);
                    myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                    
                    if (status_edit == "NEW") 
                    {
                        //新增
                        myCommand.CommandText = sql_i;
                    }
                    else
                    {
                        //保存編輯                            
                        myCommand.CommandText = sql_u;
                    }
                    myCommand.ExecuteNonQuery();
                    myTrans.Commit(); //數據提交
                    save_flag = true;
                }
            }
            catch (Exception ex)
            {
                save_flag = false;                
                MessageBox.Show(ex.Message);
            }
            return save_flag;
        }

        public static DataTable FindQcReportSpray(find_qc_report_spray mdl)
        {
            string str = string.Format(
            @"SELECT a.dept_id,a.mo_id,a.lot_no,b.name as goods_name,a.qc_logo,a.qc_size,a.do_color,a.qty_lot,a.qty_sample,a.qty_ac_std,a.qty_re_std,
            a.qc_size_actual,a.qty_ng,a.result_check,a.result_desc_ng,a.package_num,a.weight,a.is_complete,a.goods_id,
            CONVERT(VARCHAR(10),a.date_check,111) AS date_check,a.sequence_id,c.name as name_dept,
            (SELECT TOP 1 Isnull(bb.picture_name,'') FROM {0}cd_pattern_details bb
            WHERE b.within_code=bb.within_code and b.blueprint_id=bb.id and Isnull(bb.picture_name,'')<>''
            ) AS picture_name
            FROM dbo.qc_report_spray a INNER JOIN {0}it_goods b on b.within_code='0000' And a.goods_id=b.id
            INNER JOIN {0}cd_department c ON c.within_code='0000' And c.id=a.dept_id            
            WHERE 1>0", remote_db);

            StringBuilder sb = new StringBuilder();
            sb.Append(str);
            if (!string.IsNullOrEmpty(mdl.mo_id1))
                sb.Append(string.Format(" AND a.mo_id>='{0}'", mdl.mo_id1));
            if (!string.IsNullOrEmpty(mdl.mo_id2))
                sb.Append(string.Format(" AND a.mo_id<='{0}'", mdl.mo_id2));
            if (!string.IsNullOrEmpty(mdl.date_check1))
                sb.Append(string.Format(" AND a.date_check>='{0}'", mdl.date_check1));
            if (!string.IsNullOrEmpty(mdl.date_check2))
                sb.Append(string.Format(" AND a.date_check<='{0}'", mdl.date_check2));
            if (!string.IsNullOrEmpty(mdl.dept_id1))
                sb.Append(string.Format(" AND a.dept_id>='{0}'", mdl.dept_id1));
            if (!string.IsNullOrEmpty(mdl.dept_id2))
                sb.Append(string.Format(" AND a.dept_id<='{0}'", mdl.dept_id2));
            DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(sb.ToString());
            return dt;
        }

        public static int Del(string dept_id, string date_check, string sequence_id)
        {
            string strSql_d = string.Format("Delete From qc_report_spray WHERE dept_id='{0}' And date_check='{1}' And sequence_id='{2}'", dept_id, date_check, sequence_id);
            int result= clsPublicOfPad.ExecuteSqlUpdate(strSql_d);
            return result;
        }

    }
}
