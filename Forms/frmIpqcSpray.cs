using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf_pad.CLS;
using System.Data.SqlClient;
using cf_pad.Reports;
using System.IO;
using DevExpress.XtraReports.UI;

namespace cf_pad.Forms
{
    public partial class frmIpqcSpray : Form
    {

        DataTable dtReport = new DataTable();
        DataTable dtReport2 = new DataTable();
        DataTable dtBarCode = new DataTable();
        public bool blPermission =false;
        string remote_db = DBUtility.remote_db;


        public frmIpqcSpray()
        {
            InitializeComponent();                 
        }

        private void frmIpqcSpray_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtReport.Dispose();
        }

        private void frmIpqcSpray_Load(object sender, EventArgs e)
        {
            txtBarCode.Focus();
            mskDate_check.Text = DateTime.Now.Date.ToString("yyyy/MM/dd");
            mskDat1.Text = DateTime.Now.ToString("yyyy/MM/dd");
            mskDat2.Text = DateTime.Now.ToString("yyyy/MM/dd");
            //生成表結構
            string strSql =
            @"SELECT dept_id,qc_size as name_dept,date_check,sequence_id,mo_id,lot_no,goods_id,
            qc_logo,qc_size,qc_size_actual,do_color,qty_lot,qty_sample,qty_ac_std,qty_re_std,
            qty_ng,Convert(bit,result_check) as result_check,result_desc_ng,package_num,weight,
            Convert(bit,is_complete) as is_complete,remark as goods_name
            FROM qc_report_spray
            WHERE 1=0";
            dtReport = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            dgvDetails2.DataSource = dtReport;


            ////FQC組別下的用戶才可以保存、刪除
            //strSql = string.Format(@"SELECT user_id FROM {0}sys_user WHERE user_id='{1}' and group_id='FQC'", remote_db, DBUtility._user_id);
            //DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            //if (dt.Rows.Count > 0 || DBUtility._user_id == "ADMIN")
            //    blPermission = true;
            //else
            //    blPermission = false;
            //dt.Dispose();
            blPermission = true;
            //initWorker();//初始化綁定combobox的工號
        }

        ////初始化綁定combobox的工號
        //private void initWorker()
        //{
        //    cmbWorker.DataSource = clsProductQCRecords.InitWorker("P21-01", "P21-01","");
        //    cmbWorker.DisplayMember = "hrm1name";
        //    cmbWorker.ValueMember = "hrm1wid";
        //}

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    string strBarCode = txtBarCode.Text; //GKE0068420002
                    string strMo = string.Empty;
                    string strVer = string.Empty;
                    string strSeq = string.Empty;
                    if (string.IsNullOrEmpty(strBarCode))
                    {                       
                        this.ClearBarCodeInfo();
                        return;
                    }
                    if (strBarCode.Length >= 13)
                    {
                        strMo = strBarCode.Substring(0, 9);//頁數
                        strVer = strBarCode.Substring(9, 2); //頁數版本號
                        strSeq = "00" + strBarCode.Substring(11, 2) + "h";//生產流程序號
                    }
                    else
                    {
                        this.ClearBarCodeInfo();
                        this.Operation_info("些條在碼長度有問題,請返回檢查!", Color.Red);
                        return;
                    }                    
                    
                    //string strSql = string.Format(
                    //@"SELECT a.mo_id,b.wp_id,e.name as name_wp,b.next_wp_id,f.name as name_next,b.goods_id,b.prod_qty as qty_lot,c.blueprint_id as artwork,
                    //d.name as size_id,c.do_color,CONVERT(bit,1) as result_check,CONVERT(bit,1) as is_complete
                    //FROM {0}jo_bill_mostly a with(nolock) 
                    //INNER JOIN {0}jo_bill_goods_details b with(nolock) ON a.within_code = b.within_code AND a.id = b.id AND a.ver = b.ver 
                    //INNER JOIN {0}it_goods c ON b.within_code=c.within_code AND b.goods_id=c.id
                    //LEFT JOIN {0}cd_size d ON c.within_code=d.within_code AND c.size_id=d.id
                    //LEFT JOIN {0}cd_productline e ON b.within_code=e.within_code and b.wp_id=e.id
                    //LEFT JOIN {0}cd_productline f ON b.within_code=f.within_code and b.next_wp_id=f.id
                    //WHERE a.within_code='0000' AND a.mo_id='{1}' AND b.sequence_id='{2}' AND b.next_wp_id<>'702'", remote_db, strMo, strSeq);
                    //dtReport = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
                    //txtBarCode.Text = "";
                    //if (dtReport.Rows.Count == 0)
                    //{
                    //    //DialogResult r = MessageBox.Show(
                    //    //    string.Format("該頁數【{0}】當前日期已保存過相關測試數據!\r\n                  請選擇:\r\n【是】  繼續新增該頁數測試資料;\r\n\r\n【否】  調出當日已保存的該頁數測試資料供修改.", strMo), 
                    //    //    "系統提示", 
                    //    //    MessageBoxButtons.YesNo,
                    //    //    MessageBoxIcon.Information,
                    //    //    MessageBoxDefaultButton.Button2
                    //    //    );
                    //    //if (r == DialogResult.No)
                    //    //{
                    //    //    dgvDetails.DataSource = dtReport;
                    //    //    return;
                    //    //}
                    //}
                    SqlParameter[] paras = new SqlParameter[] {
                        new SqlParameter("@remote_db", remote_db),
                        new SqlParameter("@mo_id", strMo),
                        new SqlParameter("@sequence_id",strSeq)
                    };
                    dtBarCode = clsPublicOfPad.ExecuteProcedure("p_jx_spray_ipqc", paras);                   
                    txtBarCode.Text = "";                                       
                    if (dtBarCode.Rows.Count > 0)
                    { 
                        txtBarCode.Focus();
                        txtDept_id.Text = dtBarCode.Rows[0]["dept_id"].ToString();
                        txtDept_name.Text = dtBarCode.Rows[0]["dept_name"].ToString();
                        txtMo_id.Text = dtBarCode.Rows[0]["mo_id"].ToString();
                        txtLot_no.Text = dtBarCode.Rows[0]["lot_no"].ToString();                        
                        //mskDate_check.Text = DateTime.Now.Date.ToString("yyyy/MM/dd");
                        txtDo_color.Text= dtBarCode.Rows[0]["do_color"].ToString();
                        txtQc_size.Text = dtBarCode.Rows[0]["size_desc"].ToString();
                        txtQc_size_actual.Text = dtBarCode.Rows[0]["size_desc"].ToString();                        
                        txtGoods_id.Text = dtBarCode.Rows[0]["goods_id"].ToString();
                        txtGoods_name.Text = dtBarCode.Rows[0]["goods_name"].ToString();                       
                        txtQty_lot.Text = dtBarCode.Rows[0]["qty_lot"].ToString();
                        txtQc_logo.Text = dtBarCode.Rows[0]["qc_logo"].ToString();
                        txtQty_sample.Text = dtBarCode.Rows[0]["qty_sample"].ToString();
                        txtQty_ac_std.Text= dtBarCode.Rows[0]["qty_ac_std"].ToString();
                        txtQty_re_std.Text = dtBarCode.Rows[0]["qty_re_std"].ToString();
                        chkOk.Checked = true;  //檢驗結果OK
                        chkNg.Checked = false;
                        chkIs_complete1.Checked = true; //已齊
                        chkIs_complete2.Checked = false; //未齊

                        txtResult_desc_ng.Text = "";
                        txtQty_ng.Text = "0";
                        txtPackage_num.Text = "0";
                        txtWeight.Text = "0.00";
                    }
                    else
                    {
                        this.ClearBarCodeInfo();
                        dtBarCode.Clear();
                        //cmbWorker.SelectedValue = "";
                        return;
                    }
                    break;
            }
        }

        private void ClearBarCodeInfo() {
            txtBarCode.Text = "";
            txtBarCode.Focus();
            txtDept_id.Text = "";
            txtDept_name.Text = "";
            txtMo_id.Text = "";
            txtLot_no.Text = "";
            //mskDate_check.Clear();
            txtDo_color.Text = "";
            txtQc_size.Text = "";
            txtQc_size_actual.Text = "";
            txtGoods_id.Text = "";
            txtGoods_name.Text = "";
            txtQty_lot.Text = "0";
            txtQc_logo.Text = "";
            txtQty_ac_std.Text = "0";
            txtQty_re_std.Text = "0";
            chkOk.Checked = true;  //檢驗結果OK
            chkNg.Checked = false;
            chkIs_complete1.Checked = true; //已齊
            chkIs_complete2.Checked = false; //未齊

            txtResult_desc_ng.Text = "";
            txtQty_sample.Text = "0";
            txtQty_ng.Text = "0";
            txtPackage_num.Text = "0";
            txtWeight.Text = "0.00";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {  
            //if (dtReport.Rows.Count > 0)
            //{
            if (!blPermission)
            {
                this.Operation_info(string.Format("當前用戶【{0}】沒有此操作權限!", DBUtility._user_id), Color.Red);                
                return;
            }
            if (string.IsNullOrEmpty(txtDept_id.Text.Trim()))
            {
                this.Operation_info("部門不可為空!  保存失敗!", Color.Red);
                txtDept_id.Focus();
                return;
            }
            if (mskDate_check.Text== "____/__/__")
            {
                this.Operation_info("日期不可為空! 保存失敗!", Color.Red);                
                mskDate_check.Focus();
                return;
            }
            //檢查日期有效性
            if (!clsUtility.CheckDate(mskDate_check.Text))
            {
                this.Operation_info("輸入的日期不正確! 保存失敗!", Color.Red);
                mskDate_check.Focus();
                return;
            }

                //if (cmbWorker.SelectedValue == null || cmbWorker.SelectedValue.ToString() == "")
                //{
                //    MessageBox.Show("請輸入檢驗人!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    cmbWorker.Focus();
                //    return;
                //}      
                //if(pnlCheckColor.Visible == true)
                //{
                //    if (!chkCheckColor.Checked)
                //    {
                //        if (MessageBox.Show("注意:當前頁數未完成確認對色,是否繼續保當前資料?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                //            MessageBoxDefaultButton.Button2) == DialogResult.No)
                //        {
                //            return;
                //        }
                //    }
                //}

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
				WHERE dept_id=@dept_id,date_check=@date_check,sequence_id=@sequence_id";

            return;
                bool isFlag = false;
                for (int i=0;i<dtReport.Rows.Count;i++)
                {
                    if (dtReport.Rows[i]["flag_select"].ToString() == "True")
                    {
                        isFlag = true;
                    }
                }
                if (!isFlag)
                {
                    MessageBox.Show("請首先選擇要保存的記錄!", "系統提示",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                                
                string rowStatus, flag_select;
                int id;
                bool qc_result,proofread_status,save_flag = false;
                try
                {
                    SqlConnection myCon = new SqlConnection(DBUtility.dgcf_pad_connectionString);
                    myCon.Open();
                    SqlTransaction myTrans = myCon.BeginTransaction();
                    using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                    {
                        for (int i = 0; i < dtReport.Rows.Count; i++)
                        {
                            rowStatus = dtReport.Rows[i].RowState.ToString();
                            id = Convert.ToInt32(dtReport.Rows[i]["id"].ToString());
                            flag_select = dtReport.Rows[i]["flag_select"].ToString();
                            if (flag_select == "True")
                            {
                                //dtReport.Rows[i]["qc_by"] = cmbWorker.SelectedValue.ToString();
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@mo_id", dtReport.Rows[i]["mo_id"].ToString());
                                myCommand.Parameters.AddWithValue("@goods_id", dtReport.Rows[i]["goods_id"].ToString());
                                myCommand.Parameters.AddWithValue("@goods_name", dtReport.Rows[i]["goods_name"].ToString());
                                myCommand.Parameters.AddWithValue("@order_qty", dtReport.Rows[i]["order_qty"]);
                                myCommand.Parameters.AddWithValue("@sample_qty", dtReport.Rows[i]["sample_qty"]);
                                myCommand.Parameters.AddWithValue("@ac", dtReport.Rows[i]["ac"]);
                                myCommand.Parameters.AddWithValue("@re", dtReport.Rows[i]["re"]);
                                myCommand.Parameters.AddWithValue("@qty_ng", dtReport.Rows[i]["qty_ng"]);
                                myCommand.Parameters.AddWithValue("@qc_size", dtReport.Rows[i]["qc_size"].ToString());
                                myCommand.Parameters.AddWithValue("@qc_color", dtReport.Rows[i]["qc_color"].ToString());
                                myCommand.Parameters.AddWithValue("@qc_logo", dtReport.Rows[i]["qc_logo"].ToString());
                                if (dtReport.Rows[i]["qc_result"].ToString() == "True")
                                    qc_result = true;
                                else
                                    qc_result = false;
                                if (dtReport.Rows[i]["mo_id2"].ToString() != "" && "0,1".Contains(dtReport.Rows[i]["proofread_status"].ToString()))
                                {
                                    if (dtReport.Rows[i]["check_color"].ToString() == "True")
                                        proofread_status = true;
                                    else
                                        proofread_status = false;
                                }else
                                {
                                    proofread_status = false;
                                }
                                myCommand.Parameters.AddWithValue("@qc_result", qc_result);
                                myCommand.Parameters.AddWithValue("@remark", dtReport.Rows[i]["remark"].ToString());
                                myCommand.Parameters.AddWithValue("@artwork", dtReport.Rows[i]["artwork"].ToString());
                                //myCommand.Parameters.AddWithValue("@qc_by", cmbWorker.SelectedValue.ToString());
                                myCommand.Parameters.AddWithValue("@proofread_status", proofread_status);

                                if (id == 0) //新增
                                {
                                    myCommand.CommandText = sql_i;
                                    myCommand.Parameters.AddWithValue("@create_by", DBUtility._user_id);
                                }
                                else
                                {
                                    if (rowStatus == "Modified") //保存編輯
                                    {
                                        myCommand.CommandText = sql_u;
                                        myCommand.Parameters.AddWithValue("@id", dtReport.Rows[i]["id"]);
                                        myCommand.Parameters.AddWithValue("@update_by", DBUtility._user_id);
                                    }
                                }
                                myCommand.ExecuteNonQuery();
                            }
                        }
                        myTrans.Commit(); //數據提交
                        save_flag = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (save_flag)
                {
                    //重新刷新已保存的數據
                    string strMo = dtReport.Rows[0]["mo_id"].ToString();
                    string strSql = GetFindSqlStr(strMo);
                    dtReport = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
                    //dgvDetails.DataSource = dtReport;
                    Operation_info("數 據 保 存 成 功!", Color.Blue);
                }
                else
                {                   
                    Operation_info("數 據 保 存 失 敗!", Color.Red);                    
                }
                txtBarCode.Focus();
            //}
        }

        private string GetFindSqlStr(string mo_id)
        {
            string str = string.Format(
                    @"SELECT convert(bit,0) AS flag_select,CONVERT(VARCHAR(20),A.qc_date,111) AS qc_date,A.mo_id,A.goods_id,A.goods_name,A.order_qty,
                    A.sample_qty,A.ac,A.re,A.qty_ng,A.qc_size,A.qc_color,A.qc_logo,A.qc_result,A.remark,A.artwork,A.id,A.qc_by,
                    ROW_NUMBER() OVER (ORDER BY A.id) AS seq_no,Case WHEN ISNULL(B.mo_id,'')<>'' THEN '需要對色' ELSE '' END AS check_color_desc,
                    A.proofread_status AS check_color,ISNULL(B.mo_id,'') AS mo_id2,ISNULL(B.proofread_status,'') AS proofread_status
                    FROM dbo.qc_report_finish A left join dgsql2.dgcf_db.dbo.mo_need_proofread_color B on A.mo_id = B.mo_id Collate Chinese_PRC_CI_AS
                    WHERE A.mo_id='{0}' and A.qc_date=CONVERT(date,GETDATE(),120)", mo_id); ;
            return str;
        }
       
        private void Operation_info(string msg, Color fore_clr)
        {
            lblSaveinfo.Text = msg;
            lblSaveinfo.ForeColor = fore_clr;
            lblSaveinfo.Visible = true;
            Delay(1200); // 延時1.2秒
            lblSaveinfo.Visible = false;
        }
        
        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dtReport.Rows.Count > 0)
            {
                if (!blPermission)
                {
                    MessageBox.Show(string.Format("當前用戶【{0}】沒有此操作權限!", DBUtility._user_id), "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int id = Convert.ToInt32(dtReport.Rows[dgvDetails2.CurrentRow.Index]["id"].ToString());
                string strSql_d = string.Format("Delete From qc_report_finish WHERE id={0}",id);

                if (id > 0)
                {
                    if (MessageBox.Show("確定要刪除當前記錄?", "系統提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information,
                     MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }
                    
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(DBUtility.dgcf_pad_connectionString))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = strSql_d;
                            cmd.ExecuteNonQuery();
                            this.Tag = "DEL";
                            dgvDetails2.Rows.RemoveAt(dgvDetails2.CurrentRow.Index);//移除表格中的當前行          
                            Operation_info("當前行刪除成功!", Color.Blue);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {                    
                    this.Tag = "DEL";
                    dgvDetails2.Rows.RemoveAt(dgvDetails2.CurrentRow.Index);//移除表格中的當前行                    
                }
                dtReport.AcceptChanges();
            }
        }

        private void mskDat1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //按回車跳到下一控件                
            if (e.KeyChar == 13) //等同于(e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                //等同于frm.SelectNextControl(frm.ActiveControl, true, true, true, true);
            }              
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //按回車跳到下一控件                
            if (e.KeyChar == 13) //等同于(e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                //等同于frm.SelectNextControl(frm.ActiveControl, true, true, true, true);
            }            
        }

        private void txtMO1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //按回車跳到下一控件                
            if (e.KeyChar == 13) //等同于(e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                //等同于frm.SelectNextControl(frm.ActiveControl, true, true, true, true);
            }
            if ((txtMO1.TextLength - txtMO1.SelectionLength) == txtMO1.MaxLength - 1)
            {
                SendKeys.Send("{TAB}");
            }     
        }

        private void txtMO2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //按回車跳到下一控件                
            if (e.KeyChar == 13) //等同于(e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                //等同于frm.SelectNextControl(frm.ActiveControl, true, true, true, true);
            }
            if ((txtMO2.TextLength - txtMO2.SelectionLength) == txtMO2.MaxLength - 1)
            {
                SendKeys.Send("{TAB}");
            }     
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string dat1 = mskDat1.Text;
            string dat2 = mskDat2.Text;

            if (dat1 != "    /  /")
            {
                if (!clsValidRule.CheckDateFormat(dat1))
                {
                    MessageBox.Show("日期格有誤，請返回檢查!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskDat1.Focus();
                    return;
                }
            }
            else
            {
                dat1 = "";
            }
            if (dat2 != "    /  /")
            {
                if (!clsValidRule.CheckDateFormat(dat2))
                {
                    MessageBox.Show("日期格有誤，請返回檢查!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskDat2.Focus();
                    return;
                }
            }
            else
            {
                dat2 = "";
            }
            if (dat1 == "" && dat2 == "" && txtMO1.Text == "" && txtMO2.Text == "")
            {
                MessageBox.Show("查詢條件不可為空，請輸入查詢條件!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskDat1.Focus();
                return;
            }
            StringBuilder sb = new StringBuilder(
                    @"SELECT convert(bit,0) AS flag_select,CONVERT(VARCHAR(20),A.qc_date,111) AS qc_date,A.mo_id,A.goods_id,
                    A.goods_name,A.order_qty,A.sample_qty,A.ac,re,A.qty_ng,A.qc_size,A.qc_color,A.qc_logo,A.qc_result,A.remark,
                    A.artwork,A.id,A.qc_by,ROW_NUMBER() OVER (ORDER BY A.id) AS seq_no,
                    Case WHEN ISNULL(B.mo_id,'')<>'' THEN '需要對色' ELSE '' END AS check_color_desc, A.proofread_status AS check_color,
                    ISNULL(B.mo_id,'') AS mo_id2,ISNULL(B.proofread_status,'') AS proofread_status
                    FROM dbo.qc_report_finish A LEFT JOIN dgsql2.dgcf_db.dbo.mo_need_proofread_color B on A.mo_id = B.mo_id Collate Chinese_PRC_CI_AS
                    WHERE id>0 ");
            if (!string.IsNullOrEmpty(txtMO1.Text))
                sb.Append(string.Format(" AND A.mo_id>='{0}'",txtMO1.Text));
            if (!string.IsNullOrEmpty(txtMO2.Text))
                sb.Append(string.Format(" AND A.mo_id<='{0}'", txtMO2.Text));
            if (!string.IsNullOrEmpty(dat1))
                sb.Append(string.Format(" AND A.qc_date>='{0}'", dat1));
            if (!string.IsNullOrEmpty(dat2))
                sb.Append(string.Format(" AND A.qc_date<='{0}'", dat2));
            dtReport2 = clsPublicOfPad.ExecuteSqlReturnDataTable(sb.ToString());
            dgvDetails2.DataSource = dtReport2;
            if (dtReport2.Rows.Count == 0)
            {
                MessageBox.Show("沒有符合條件的數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            

            //統計MO張數
            sb.Clear();
            sb.Append(@"SELECT Distinct mo_id FROM dbo.qc_report_finish WHERE id>0 ");
            if (!string.IsNullOrEmpty(txtMO1.Text))
                sb.Append(string.Format(" AND mo_id>='{0}'", txtMO1.Text));
            if (!string.IsNullOrEmpty(txtMO2.Text))
                sb.Append(string.Format(" AND mo_id<='{0}'", txtMO2.Text));
            if (!string.IsNullOrEmpty(dat1))
                sb.Append(string.Format(" AND qc_date>='{0}'", dat1));
            if (!string.IsNullOrEmpty(dat2))
                sb.Append(string.Format(" AND qc_date<='{0}'", dat2));            
            using (DataTable dtMO = clsPublicOfPad.ExecuteSqlReturnDataTable(sb.ToString()))
            {
                lblMo_total.Text = dtMO.Rows.Count.ToString();
            }            

        }

        private void mskDat1_Leave(object sender, EventArgs e)
        {
            mskDat2.Text = mskDat1.Text;
        }

        private void txtMO1_Leave(object sender, EventArgs e)
        {
            txtMO2.Text = txtMO1.Text;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvDetails2.RowCount > 0)
            {
                using (xrQcFinishReport mMyReport = new xrQcFinishReport() { DataSource = dtReport2 })
                {
                    mMyReport.CreateDocument();
                    mMyReport.PrintingSystem.ShowMarginsWarning = false;
                    mMyReport.ShowPreviewDialog();
                }
            }
        }

        private void tbc_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tbc.SelectedIndex)
            {
                case 0:                    
                    txtBarCode.Focus();
                    break;
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if(dgvDetails2.Rows.Count>0)
            {
                //if (chkSelectAll.Checked)
                //{
                //    Select_All(true);
                //}
                //else
                //{
                //    Select_All(false);
                //}
            }
        }

        private void chkResult_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvDetails2.Rows.Count > 0)
            {
                //if (chkResult.Checked)
                //{
                //    UpdateQcResult(true);
                //}
                //else
                //{
                //    UpdateQcResult(false);
                //}
            }
        }

        private void Select_All(bool blnSelectAll)
        {
            if (dgvDetails2.Rows.Count > 0)
            {                
                for (int i = 0; i < dtReport.Rows.Count; i++)
                {
                    dtReport.Rows[i]["flag_select"] = blnSelectAll;
                }
            }
        }

        private void UpdateQcResult(bool blnQcResult)
        {
            if (dgvDetails2.Rows.Count > 0)
            {
                for (int i = 0; i < dtReport.Rows.Count; i++)
                {
                    dtReport.Rows[i]["qc_result"] = blnQcResult;
                }
            }
        }
        private void UpdateCheckColor( bool blnCheckColor)
        {
            if (dgvDetails2.Rows.Count > 0)
            {
                for (int i = 0; i < dtReport.Rows.Count; i++)
                {
                    dtReport.Rows[i]["check_color"] = blnCheckColor;
                }
            }
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgvDetails2.RowCount > 0)
            //{               
            //    if (this.Tag == "DEL")
            //    {
            //        this.Tag = "";
            //        return;
            //    }
            //    if(dgvDetails2.CurrentCell.RowIndex<0)
            //    {
            //        return;
            //    }
            //    lblGoods_id.Text = dtReport.Rows[dgvDetails2.CurrentCell.RowIndex]["goods_id"].ToString();
            //    txtGoods_name.Text = dtReport.Rows[dgvDetails.CurrentCell.RowIndex]["goods_name"].ToString();
            //    cmbWorker.SelectedValue = ""; 
            //    if (dtReport.Rows[dgvDetails2.CurrentCell.RowIndex]["qc_by"].ToString() != "")
            //    {
            //        cmbWorker.SelectedValue = dtReport.Rows[dgvDetails2.CurrentCell.RowIndex]["qc_by"].ToString();
            //    }
            //    //對色
            //    if (dtReport.Rows[dgvDetails2.CurrentCell.RowIndex]["mo_id2"].ToString() != "" &&
            //       "0,1".Contains(dtReport.Rows[dgvDetails2.CurrentCell.RowIndex]["proofread_status"].ToString()))
            //    {
            //        //符合對色條件
            //        pnlCheckColor.Visible = true;
            //        if (dtReport.Rows[dgvDetails2.CurrentCell.RowIndex]["check_color"].ToString() == "True")                    
            //            chkCheckColor.Checked = true;
            //        else                    
            //            chkCheckColor.Checked = false;
            //    }else
            //    {
            //        pnlCheckColor.Visible = false;
            //        chkCheckColor.Checked = false;
            //    }
               
            //    string strArtwork = dtReport.Rows[dgvDetails2.CurrentCell.RowIndex]["artwork"].ToString();
            //    if (!string.IsNullOrEmpty(strArtwork))
            //    {
            //        if (File.Exists(strArtwork))
            //            pic_artwork.Image = Image.FromFile(strArtwork);
            //        else
            //            pic_artwork.Image = null;
            //    }
            //    else
            //        pic_artwork.Image = null;                
            //}
        }

        private bool isExists(string str)
        {
            return System.Text.RegularExpressions.Regex.Matches(str, "[a-zA-Z]").Count > 0;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (btnSet.Text == "數據瀏覽")
            {
                //顯示第二頁
                btnSet.Text = "數據編輯";
                tbc.SelectedIndex = 1;
            }
            else
            {
                //顯示第一頁
                //ShowQcRec(dgvDetails2.CurrentRow.Index);
                btnSet.Text = "數據瀏覽";
                tbc.SelectedIndex = 0;
                if (dgvDetails2.CurrentCell == null)
                {
                    //表格無數據是避出錯,需加此判斷
                    return;
                }
                int curIndex = dgvDetails2.CurrentCell.RowIndex;
                if (curIndex >= 0)
                {                   
                    string strMoId = dtReport2.Rows[curIndex]["mo_id"].ToString();                    
                    DataRow[] drws = dtReport2.Select("mo_id="+"'"+ strMoId+"'");
                    //dtReport = dtReport2.Clone();    
                    dtReport.Clear();
                    foreach (DataRow dr in drws)
                    {                       
                        dtReport.ImportRow(dr);
                    }
                    dgvDetails2.DataSource = dtReport;
                }

            }
            txtBarCode.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void chkCheckColor_MouseUp(object sender, MouseEventArgs e)
        {
            if (dgvDetails2.Rows.Count > 0)
            {
                //if (chkCheckColor.Checked)
                //{
                //    UpdateCheckColor(true);
                //}
                //else
                //{
                //    UpdateCheckColor(false);
                //}
            }
        }


        public static DialogResult CustomMessageBox(string message, string caption,
                                                    MessageBoxButtons buttons = MessageBoxButtons.OK, 
                                                    MessageBoxIcon icon = MessageBoxIcon.Information, 
                                                    int fontSize = 12)
        {
            Form messageForm = new Form();
            messageForm.Text = caption;
            messageForm.Width = 300;
            messageForm.Height = 100;
            messageForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            messageForm.StartPosition = FormStartPosition.CenterParent;
            messageForm.DialogResult = DialogResult.None;
            messageForm.AcceptButton = null;
            messageForm.CancelButton = null;
            messageForm.Controls.Add(new Label() { Text = message, Font = new Font("Arial", fontSize, FontStyle.Regular, GraphicsUnit.Pixel, ((byte)(0))), Location = new Point(10, 10) });
            messageForm.ShowDialog();
            return messageForm.DialogResult; // Return the result only after form is closed.
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //CustomMessageBox("DFDFDFDF精豐鈕扣", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information, 20);
            txtWeight.Text = string.IsNullOrEmpty(txtWeight.Text)?"0.00":clsUtility.FormatNullableDecimal(txtWeight).ToString();
            if(clsUtility.CheckDate(mskDate_check.Text)==false)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.Input_Decimal(txtWeight,e);
        }

        private void txtQty_lot_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.Input_Int(txtQty_lot, e);            
        }

        private void txtQty_sample_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.Input_Int(txtQty_sample, e);
        }

        private void txtQty_ac_std_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.Input_Int(txtQty_ac_std, e);
        }

        private void txtQty_re_std_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.Input_Int(txtQty_re_std, e);
        }

        private void txtQty_ng_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.Input_Int(txtQty_ng, e);
        }

        private void txtPackage_num_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.Input_Int(txtPackage_num, e);
        }
    }
}
