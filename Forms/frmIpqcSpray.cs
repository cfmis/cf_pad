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
using cf_pad.MDL;

namespace cf_pad.Forms
{
    public partial class frmIpqcSpray : Form
    {

        DataTable dtReport = new DataTable();
        DataTable dtReport2 = new DataTable();
        DataTable dtBarCode = new DataTable();
        public bool blPermission = false;
        string remote_db = DBUtility.remote_db;
        string status_edit = "NEW";
        string strSequence_id = "";
        string strCurrDate = clsIpqcSpray.GetDBDate();


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
            //string strSql =
            //@"SELECT dept_id,qc_size as name_dept,date_check,sequence_id,mo_id,lot_no,goods_id,
            //qc_logo,qc_size,qc_size_actual,do_color,qty_lot,qty_sample,qty_ac_std,qty_re_std,
            //qty_ng,Convert(bit,result_check) as result_check,result_desc_ng,package_num,weight,
            //Convert(bit,is_complete) as is_complete,remark as goods_name
            //FROM qc_report_spray
            //WHERE 1=0";
            //dtReport = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            dtReport = clsIpqcSpray.GetTbInit();            
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
                    //string strVer = string.Empty;
                    string strSeq = string.Empty;
                    this.ClearBarCodeInfo();
                    status_edit = "NEW";//每資當掃描時當作插入新地記錄
                    if (string.IsNullOrEmpty(strBarCode))
                    {                       
                        //this.ClearBarCodeInfo();
                        return;
                    }
                    if (strBarCode.Length >= 13)
                    {
                        strMo = strBarCode.Substring(0, 9);//頁數
                        //strVer = strBarCode.Substring(9, 2); //頁數版本號
                        strSeq = "00" + strBarCode.Substring(11, 2) + "h";//生產流程序號
                    }
                    else
                    {
                        //this.ClearBarCodeInfo();
                        this.Operation_info("此條在碼長度有問題,請返回檢查!", Color.Red);
                        return;
                    } 
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
                        mskDate_check.Text = strCurrDate; //當前服務器時間
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

                        //生成當前部門,日期的最大序號
                        strSequence_id = clsIpqcSpray.GetMaxSeq(txtDept_id.Text, strCurrDate);

                        string strArtwork = dtBarCode.Rows[0]["picture_name"].ToString();  
                        if (!string.IsNullOrEmpty(strArtwork))
                        {
                            strArtwork = DBUtility.imagePath + strArtwork;
                            if (File.Exists(strArtwork))
                                pic_artwork.Image = Image.FromFile(strArtwork);
                            else
                                pic_artwork.Image = null;
                        }
                        else
                            pic_artwork.Image = null;
                    }
                    else
                    {
                        this.ClearBarCodeInfo();
                        dtBarCode.Clear();
                        pic_artwork.Image = null;
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
            strSequence_id = "";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {              
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
            qc_report_spray mdl = new qc_report_spray();
            mdl.dept_id = txtDept_id.Text;
            mdl.date_check = mskDate_check.Text;
            mdl.sequence_id = strSequence_id;
            mdl.mo_id = txtMo_id.Text;
            mdl.lot_no = txtLot_no.Text;
            mdl.goods_id =txtGoods_id.Text;
            mdl.qc_logo = txtQc_logo.Text;
            mdl.qc_size = txtQc_size.Text;
            mdl.qc_size_actual = txtQc_size_actual.Text;
            mdl.do_color = txtDo_color.Text;
            mdl.qty_lot = txtQty_lot.Text;
            mdl.qty_sample = string.IsNullOrEmpty(txtQty_sample.Text)?0:int.Parse(txtQty_sample.Text);
            mdl.qty_ac_std = string.IsNullOrEmpty(txtQty_ac_std.Text) ? 0 : int.Parse(txtQty_ac_std.Text); 
            mdl.qty_re_std = string.IsNullOrEmpty(txtQty_re_std.Text) ? 0 : int.Parse(txtQty_re_std.Text);
            mdl.qty_ng = string.IsNullOrEmpty(txtQty_ng.Text) ? 0 : int.Parse(txtQty_ng.Text);
            bool result_check = chkOk.Checked ? true : false;
            bool is_complete = chkIs_complete1.Checked ? true : false;
            mdl.result_check = result_check;
            mdl.is_complete = is_complete;
            mdl.result_desc_ng = txtResult_desc_ng.Text;
            mdl.package_num = string.IsNullOrEmpty(txtPackage_num.Text) ? 0 : int.Parse(txtPackage_num.Text);
            mdl.weight = string.IsNullOrEmpty(txtWeight.Text) ? 0 : decimal.Parse(txtWeight.Text);
            mdl.remark = "";
            
            bool save_flag = clsIpqcSpray.Save(mdl, status_edit);
            if (save_flag)
            {
                //DataRow dr = dtReport2.NewRow();
                //dr["dept_id"] = mdl.dept_id;
                //dr["date_check"] = mdl.date_check;

                status_edit = "";
                Operation_info("數 據 保 存 成 功!", Color.Blue);
            }
            else
            {
                Operation_info("數 據 保 存 失 敗!", Color.Red);
            }
            txtBarCode.Focus();
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
               
                string dept_id = dtReport.Rows[dgvDetails2.CurrentRow.Index]["dept_id"].ToString();
                string date_check = dtReport.Rows[dgvDetails2.CurrentRow.Index]["date_check"].ToString();
                string sequence_id = dtReport.Rows[dgvDetails2.CurrentRow.Index]["sequence_id"].ToString();
               
                if (dept_id !="")
                {
                    if (MessageBox.Show("確定要刪除當前記錄?", "系統提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information,
                     MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }
                    if(clsIpqcSpray.Del(dept_id, date_check, sequence_id) >= 0)
                    {
                        this.Tag = "DEL";
                        dgvDetails2.Rows.RemoveAt(dgvDetails2.CurrentRow.Index);//移除表格中的當前行          
                        Operation_info("當前行刪除成功!", Color.Blue);
                    }
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
            if (dat1 == "" && dat2 == "" && txtMO1.Text == "" && txtMO2.Text == "" && txtDept1.Text==""&& txtDept2.Text == "")
            {
                MessageBox.Show("查詢條件不可為空，請輸入查詢條件!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskDat1.Focus();
                return;
            }

            find_qc_report_spray mdl = new find_qc_report_spray();
            mdl.mo_id1 = txtMO1.Text;
            mdl.mo_id2 = txtMO2.Text;
            mdl.date_check1 = dat1;
            mdl.date_check2 = dat2;
            mdl.dept_id1 = txtDept1.Text;
            mdl.dept_id2 = txtDept2.Text;
            dtReport2 = clsIpqcSpray.FindQcReportSpray(mdl);
            
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
            //if (dgvDetails2.RowCount > 0)
            //{
            //    using (xrQcFinishReport mMyReport = new xrQcFinishReport() { DataSource = dtReport2 })
            //    {
            //        mMyReport.CreateDocument();
            //        mMyReport.PrintingSystem.ShowMarginsWarning = false;
            //        mMyReport.ShowPreviewDialog();
            //    }
            //}
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

        private void dgvDetails2_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails2.RowCount > 0)
            {
                //if (this.Tag.ToString() == "DEL")
                //{
                //    this.Tag = "";
                //    return;
                //}
                this.Tag = "";
                if (dgvDetails2.CurrentCell.RowIndex < 0)
                {
                    return;
                }
                txtDept_id.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["Dept_id"].ToString();               
                txtDept_name.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["dept_name"].ToString();
                txtMo_id.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["mo_id"].ToString();
                txtLot_no.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["lot_no"].ToString(); 
                mskDate_check.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["ate_check"].ToString(); 
                txtDo_color.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["do_color"].ToString();
                txtQc_size.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["size_desc"].ToString();
                txtQc_size_actual.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["qc_size_actual"].ToString();
                txtGoods_id.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["goods_id"].ToString(); 
                txtGoods_name.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["goods_name"].ToString(); 
                txtQty_lot.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["qty_lot"].ToString();
                txtQc_logo.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["qc_logo"].ToString();
                txtQty_sample.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["qty_sample"].ToString(); 
                txtQty_ac_std.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["qty_ac_std"].ToString();
                txtQty_re_std.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["qty_re_std"].ToString();
                if (dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["result_check"].ToString() == "True")
                {
                    chkOk.Checked = true;  //檢驗結果OK
                    chkNg.Checked = false; //檢驗結果NG
                }
                else
                {
                    chkOk.Checked = false;  //檢驗結果OK
                    chkNg.Checked = true;   //檢驗結果NG
                }
                if (dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["is_complete"].ToString() == "True")
                {
                    chkIs_complete1.Checked = true; //已齊
                    chkIs_complete2.Checked = false;//未齊
                }
                else
                {
                    chkIs_complete1.Checked = false; //已齊
                    chkIs_complete2.Checked = true; //未齊                   
                }
                txtResult_desc_ng.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["result_desc_ng"].ToString();
                txtQty_ng.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["qty_ng"].ToString();
                txtPackage_num.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["package_num"].ToString();
                txtWeight.Text = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["weight"].ToString();
                status_edit = "EDIT";
                string strArtwork = dtReport2.Rows[dgvDetails2.CurrentCell.RowIndex]["picture_name"].ToString();  //??
                if (!string.IsNullOrEmpty(strArtwork))
                {
                    strArtwork = DBUtility.imagePath + strArtwork;
                    if (File.Exists(strArtwork))
                        pic_artwork.Image = Image.FromFile(strArtwork);
                    else
                        pic_artwork.Image = null;
                }
                else
                    pic_artwork.Image = null;
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

        private void chkOk_MouseUp(object sender, MouseEventArgs e)
        {
            if (chkOk.Checked)
            {
                chkNg.Checked = false;
            }
            else
            {
                chkNg.Checked = true;
            }
        }

        private void chkNg_MouseUp(object sender, MouseEventArgs e)
        {
            if (chkNg.Checked)
            {
                chkOk.Checked = false;
            }
            else
            {
                chkOk.Checked = true;
            }
        }

        private void chkIs_complete1_MouseUp(object sender, MouseEventArgs e)
        {
            if (chkIs_complete1.Checked)
            {
                chkIs_complete2.Checked = false;
            }
            else
            {
                chkIs_complete2.Checked = true;
            }
        }

        private void chkIs_complete2_MouseUp(object sender, MouseEventArgs e)
        {
            if (chkIs_complete2.Checked)
            {
                chkIs_complete1.Checked = false;
            }
            else
            {
                chkIs_complete1.Checked = true;
            }
        }
    }
}
