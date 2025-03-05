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
    public partial class frmPackingMo : Form
    {

        DataTable dtReport = new DataTable();
        DataTable dtReport2 = new DataTable();
        public bool blPermission = false;      
        string dbRemote = DBUtility.remote_db;
        public frmPackingMo()
        {
            InitializeComponent();           
        }

        private void frmPackingMo_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtReport.Dispose();
        }

        private void frmPackingMo_Load(object sender, EventArgs e)
        {
            txtBarCode.Focus();
            mskDat1.Text = DateTime.Now.ToString("yyyy/MM/dd");
            mskDat2.Text = DateTime.Now.ToString("yyyy/MM/dd");
            //生成表結構
            string strSql = @"SELECT mo_id,qty,weg,box_no,package_num,upd_flag,update_user,update_time,prd_id FROM dbo.packing_mo_records WHERE 1=0";
            dtReport = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            dgvDetails.DataSource = dtReport;

            //以下用戶組別的用戶才可以保存、刪除
            strSql = string.Format(@"SELECT user_id FROM {0}sys_user WHERE user_id='{1}' and group_id='601'", dbRemote, DBUtility._user_id);
            DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            if (dt.Rows.Count > 0 || DBUtility._user_id == "ADMIN")
                blPermission = true;
            else
                blPermission = false;            
            blPermission = true; 
           
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {           
            switch (e.KeyCode)
            {               
                case Keys.Enter:
                    string strMo = txtBarCode.Text;
                    ClearInput();
                    if (strMo.Length > 9)
                    {
                        strMo = strMo.Substring(0, 9);
                    }
                    if (string.IsNullOrEmpty(strMo))
                    {                       
                        return;
                    }
                    CheckMo(strMo);
                    break;
            }
        }

        private void ClearInput()
        {
            txtPrd_id.Text = "0";
            txtMo_id.Text = "";
            txtQty.Text = "0";
            txtWeg.Text = "0.00";
            txtBarCode.Text = "";
            cmbPackage_num.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {  
            if (dtReport.Rows.Count > 0)
            {
                if (!blPermission)
                {
                    MessageBox.Show(string.Format("當前用戶【{0}】沒有此操作權限!", DBUtility._user_id), "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtMo_id.Text == "")
                {
                    MessageBox.Show("頁數不可為空!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMo_id.Focus();
                    return;
                }
                if (txtQty.Text == "")
                {
                    MessageBox.Show("數量不可為空!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQty.Focus();
                    return;
                }
                if (txtWeg.Text == "")
                {
                    MessageBox.Show("重量不可為空!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtWeg.Focus();
                    return;
                }
                if (txtQty.Text != "")
                {
                    if (Convert.ToInt32(txtQty.Text) <= 0)
                    {
                        MessageBox.Show("輸入的數量格式不正確，請返回檢查!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQty.Focus();
                        return;
                    }
                }
                if (txtWeg.Text != "")
                {                    
                    if (Convert.ToDecimal(txtWeg.Text) <= 0)
                    {
                        MessageBox.Show("輸入的重量格式不正確，請返回檢查!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtWeg.Focus();                      
                        return;
                    }    
                }
                string user_id = DBUtility._user_id;
                string sql_i =
                @"Insert into dbo.packing_mo_records(mo_id,qty,weg,box_no,package_num,upd_flag,update_user,update_time)
                Values(@mo_id,@qty,@weg,@box_no,@package_num,@upd_flag,@update_user,getdate())";
                string sql_u =
                @"UPDATE dbo.packing_mo_records 
				SET mo_id=@mo_id,qty=@qty,weg=@weg,box_no=@box_no,package_num=@package_num,update_user=@update_user,update_time=getdate()
				WHERE prd_id=@prd_id";               
                
                int prd_id;
                int package_num = 0;
                bool save_flag = false;
                try
                {
                    SqlConnection myCon = new SqlConnection(DBUtility.dgcf_pad_connectionString);
                    myCon.Open();
                    SqlTransaction myTrans = myCon.BeginTransaction();
                    using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                    {
                        prd_id = (txtPrd_id.Text == "") ? 0 : Convert.ToInt32(txtPrd_id.Text);
                        myCommand.Parameters.Clear();
                        if (prd_id == 0) //新增
                        {
                            myCommand.CommandText = sql_i;
                            myCommand.Parameters.AddWithValue("@upd_flag", "0");
                        }
                        else
                        {
                            //保存編輯                                
                            myCommand.CommandText = sql_u;
                            myCommand.Parameters.AddWithValue("@prd_id", prd_id);
                        }
                        myCommand.Parameters.AddWithValue("@mo_id", txtMo_id.Text.Trim());
                        myCommand.Parameters.AddWithValue("@qty", txtQty.Text);
                        myCommand.Parameters.AddWithValue("@weg", txtWeg.Text);
                        myCommand.Parameters.AddWithValue("@box_no", cmbBoxno.Text.Trim());
                        if (string.IsNullOrEmpty(cmbPackage_num.Text.Trim()))
                            package_num = 0;
                        else
                            package_num = int.Parse(cmbPackage_num.Text.Trim());
                        myCommand.Parameters.AddWithValue("@package_num", package_num);
                        
                        myCommand.Parameters.AddWithValue("@update_user", DBUtility._user_id);
                        
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

                if (save_flag)
                {
                    //重新刷新已保存的數據
                    string strMo = dtReport.Rows[0]["mo_id"].ToString();
                    string strSql = "SELECT * FROM packing_mo_records Where upd_flag='0' ORDER BY update_time Desc";
                    dtReport = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
                    dgvDetails.DataSource = dtReport;
                    Operation_info("數 據 保 存 成 功!", Color.Blue);
                }
                else
                {                   
                    Operation_info("數 據 保 存 失 敗!", Color.Red);                    
                }
                txtBarCode.Focus();
            }
        }

        private void CheckMo(string mo_id)
        {
            string str = string.Format(
            @"SELECT B.mo_id,dbo.fn_z_Get_pcs_qty(B.transfer_amount,B.unit) AS order_qty,B.sec_qty
            FROM st_transfer_mostly A WITH(NOLOCK),st_transfer_detail B WITH(NOLOCK)
            WHERE A.id=B.id and A.within_code=B.within_code AND B.within_code='{0}' AND B.mo_id='{1}' And ISNULL(A.bill_type_no,'')<>'' AND A.state NOT IN('0','2')",  "0000",mo_id);
            DataTable dt = clsPublicOfGeo.ExecuteSqlReturnDataTable(str);
            if(dt.Rows.Count > 0)
            {
                str = dt.Rows[0]["mo_id"].ToString();
                txtMo_id.Text = dt.Rows[0]["mo_id"].ToString();
                txtQty.Text = dt.Rows[0]["order_qty"].ToString();
                txtWeg.Text = dt.Rows[0]["sec_qty"].ToString(); ;
                DataRow drw = dtReport.NewRow();
                drw["mo_id"] = txtMo_id.Text;
                drw["qty"] = Int32.Parse(txtQty.Text);
                drw["weg"] = decimal.Parse(txtWeg.Text);
                dtReport.Rows.Add(drw);
                txtBarCode.Text = "";                
            }
            else
            {
                str = "";
                txtMo_id.Text = "";
                txtQty.Text = "0";
                txtWeg.Text = "0.00";
                txtPrd_id.Text = "0";
                Operation_info("頁數資料不正確!", Color.Red);
                txtBarCode.Text = "";
                cmbBoxno.Text = "";             
            }
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

                int prd_id = Convert.ToInt32(dtReport.Rows[dgvDetails.CurrentRow.Index]["prd_id"].ToString());
                string sql_d = string.Format("Delete From packing_mo_records WHERE prd_id={0}", prd_id);

                if (prd_id > 0)
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
                            cmd.CommandText = sql_d;
                            cmd.ExecuteNonQuery();
                            this.Tag = "DEL";
                            dgvDetails.Rows.RemoveAt(dgvDetails.CurrentRow.Index);//移除表格中的當前行          
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
                    dgvDetails.Rows.RemoveAt(dgvDetails.CurrentRow.Index);//移除表格中的當前行                    
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
            @"SELECT * FROM dbo.packing_mo_records WHERE prd_id>0 ");
            if (!string.IsNullOrEmpty(txtMO1.Text))
                sb.Append(string.Format(" AND mo_id>='{0}'",txtMO1.Text));
            if (!string.IsNullOrEmpty(txtMO2.Text))
                sb.Append(string.Format(" AND mo_id<='{0}'", txtMO2.Text));
            if (!string.IsNullOrEmpty(dat1))
                sb.Append(string.Format(" AND update_time>='{0}'", dat1));
            if (!string.IsNullOrEmpty(dat2))
            {
                dat2 = DateTime.Now.AddDays(1).Date.ToString("yyyy/MM/dd");
                sb.Append(string.Format(" AND update_time<='{0}'", dat2));
            }
                
            sb.Append(string.Format(" AND upd_flag='{0}'", "0"));
            dtReport2 = clsPublicOfPad.ExecuteSqlReturnDataTable(sb.ToString());
            dgvDetails2.DataSource = dtReport2;            
            if (dtReport2.Rows.Count == 0)
            {
                MessageBox.Show("沒有符合條件的數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                using (xrPackingMo rpt = new xrPackingMo() { DataSource = dtReport2 })
                {
                    rpt.CreateDocument();
                    rpt.PrintingSystem.ShowMarginsWarning = false;
                    rpt.ShowPreviewDialog();
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
     
        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {   
            if (dtReport.Rows.Count==0)
            {
                return;
            }
            if (dgvDetails.RowCount > 0)
            {          
                if (this.Tag == "DEL")
                {
                    this.Tag = "";
                    return;
                }
                if(dgvDetails.CurrentCell.RowIndex<0)
                {
                    return;
                }
                txtMo_id.Text = dtReport.Rows[dgvDetails.CurrentCell.RowIndex]["mo_id"].ToString();
                txtQty.Text = dtReport.Rows[dgvDetails.CurrentCell.RowIndex]["qty"].ToString();
                txtWeg.Text = dtReport.Rows[dgvDetails.CurrentCell.RowIndex]["weg"].ToString();
                cmbBoxno.Text = dtReport.Rows[dgvDetails.CurrentCell.RowIndex]["box_no"].ToString();
                cmbPackage_num.Text = dtReport.Rows[dgvDetails.CurrentCell.RowIndex]["package_num"].ToString();
                txtPrd_id.Text = dtReport.Rows[dgvDetails.CurrentCell.RowIndex]["prd_id"].ToString();
                         
            }
        }

        private bool isExists(string str)
        {
            return System.Text.RegularExpressions.Regex.Matches(str, "[a-zA-Z]").Count > 0;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (btnSet.Text == "數據瀏覽")
            {
                btnSet.Text = "數據編輯";
                tbc.SelectedIndex = 1;
            }
            else
            {
                if(dtReport2.Rows.Count==0)
                {
                    ClearInput();
                    dtReport.Clear();
                }
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
                    dgvDetails.DataSource = dtReport;
                }

            }
            txtBarCode.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
        
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.Input_Int(txtQty, e);
        }

        private void txtWeg_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.Input_Decimal(txtWeg, e);
        }

        private void txtQty_Click(object sender, EventArgs e)
        {
            txtQty.SelectAll();
        }

        private void txtWeg_Click(object sender, EventArgs e)
        {
            txtWeg.SelectAll();
        }
    }
}
