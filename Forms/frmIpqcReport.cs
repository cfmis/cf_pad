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
    public partial class frmIpqcReport : Form
    {

        DataTable dtReport = new DataTable();
        DataTable dtReport2 = new DataTable();
        public bool blPermission =false;
        public frmIpqcReport()
        {
            InitializeComponent();                 
        }

        private void frmIpqcReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtReport.Dispose();
        }

        private void frmIpqcReport_Load(object sender, EventArgs e)
        {
            txtBarCode.Focus();
            mskDat1.Text = DateTime.Now.ToString("yyyy/MM/dd");
            mskDat2.Text = DateTime.Now.ToString("yyyy/MM/dd");
            //生成表結構
            string strSql =
                   @"SELECT Convert(bit,0) AS flag_select,CONVERT(VARCHAR(20),qc_date,111) AS qc_date,mo_id,goods_id,goods_name,order_qty,
                    sample_qty,ac,re,qty_ng,qc_size,qc_color,qc_logo,qc_result,remark,artwork,id,qc_by,
                    ROW_NUMBER() OVER (ORDER BY id) AS seq_no,'' AS check_color_desc,proofread_status AS check_color,mo_id AS mo_id2,'' AS proofread_status
                    FROM dbo.qc_report_finish WHERE 1=0";
            dtReport = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            dgvDetails.DataSource = dtReport;

            //FQC組別下的用戶才可以保存、刪除
            strSql = string.Format(@"SELECT user_id FROM DGERP2.cferp.dbo.sys_user WHERE user_id='{0}' and group_id='FQC'", DBUtility._user_id);
            DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            if (dt.Rows.Count > 0 || DBUtility._user_id == "ADMIN")
                blPermission = true;
            else
                blPermission = false;
            dt.Dispose();

            initWorker();//初始化綁定combobox的工號
        }


        //初始化綁定combobox的工號
        private void initWorker()
        {
            cmbWorker.DataSource = clsProductQCRecords.InitWorker("P21-01", "P21-01","");
            cmbWorker.DisplayMember = "hrm1name";
            cmbWorker.ValueMember = "hrm1wid";
        }


        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    string strMo = txtBarCode.Text;
                    if (strMo.Length > 9)
                    {
                        strMo = strMo.Substring(0, 9);
                    }

                    if (string.IsNullOrEmpty(strMo))
                    {
                        dtReport.Clear();
                        return;
                    }
                    string strSql = GetFindSqlStr(strMo);

                    dtReport = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
                    txtBarCode.Text = "";
                    if (dtReport.Rows.Count > 0)
                    {
                        DialogResult r = MessageBox.Show(
                            string.Format("該頁數【{0}】當前日期已保存過相關測試數據!\r\n                  請選擇:\r\n【是】  繼續新增該頁數測試資料;\r\n\r\n【否】  調出當日已保存的該頁數測試資料供修改.", strMo), 
                            "系統提示", 
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button2
                            );
                        if (r == DialogResult.No)
                        {
                            dgvDetails.DataSource = dtReport;
                            return;
                        }
                    }
                    SqlParameter[] paras = new SqlParameter[] {
                        new SqlParameter("@mo_id", strMo)
                    };
                    dtReport.Clear();      
                    dtReport = clsPublicOfGeo.ExecuteProcedureReturnTable("z_ipqc_get_ac_re", paras);
                    dgvDetails.DataSource = dtReport;
                    txtBarCode.Text = "";
                    chkResult.Checked = false;
                    chkCheckColor.Checked = false;
                    if (dtReport.Rows.Count > 0)
                    {                        
                        txtBarCode.Focus();
                    }
                    else
                    {
                        dtReport.Clear();
                        lblGoods_id.Text = "";
                        richGoods_name.Text = "";
                        cmbWorker.SelectedValue = "";
                        return;
                    }
                    break;
            }
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
                if (cmbWorker.SelectedValue == null || cmbWorker.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("請輸入檢驗人!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbWorker.Focus();
                    return;
                }      
                if(pnlCheckColor.Visible == true)
                {
                    if (!chkCheckColor.Checked)
                    {
                        if (MessageBox.Show("注意:當前頁數未完成確認對色,是否繼續保當前資料?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button2) == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
                 
                const string sql_i =
                    @"Insert into dbo.qc_report_finish(qc_date,mo_id,goods_id,goods_name,order_qty,sample_qty,ac,re,qty_ng,qc_size,qc_color,qc_logo,qc_result,remark,artwork,create_by,create_date,qc_by,proofread_status)
                  Values(convert(date,getdate(),120),@mo_id,@goods_id,@goods_name,@order_qty,@sample_qty,@ac,@re,@qty_ng,@qc_size,@qc_color,@qc_logo,@qc_result,@remark,@artwork,@create_by,getdate(),@qc_by,@proofread_status)";
                const string sql_u =
                    @"UPDATE dbo.qc_report_finish 
				SET mo_id=@mo_id,goods_id=@goods_id,goods_name=@goods_name,order_qty=@order_qty,sample_qty=@sample_qty,ac=@ac,re=@re,qty_ng=@qty_ng,qc_size=@qc_size,qc_color=@qc_color,qc_logo=@qc_logo,
                    qc_result=@qc_result,remark=@remark,artwork=@artwork,update_by=@update_by,update_date=getdate(),qc_by=@qc_by,proofread_status=@proofread_status
				WHERE id=@id";

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
                                dtReport.Rows[i]["qc_by"] = cmbWorker.SelectedValue.ToString();
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
                                myCommand.Parameters.AddWithValue("@qc_by", cmbWorker.SelectedValue.ToString());
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

                int id = Convert.ToInt32(dtReport.Rows[dgvDetails.CurrentRow.Index]["id"].ToString());
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
                dat1 = "";

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
                dat2 = "";

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
            if (dtReport2.Rows.Count == 0)
            {
                MessageBox.Show("沒有符合條件的數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvDetails2.DataSource = dtReport2;

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
                using (xrQcFinishReport mMyReport = new xrQcFinishReport() { DataSource = dtReport })
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
            if(dgvDetails.Rows.Count>0)
            {
                if (chkSelectAll.Checked)
                {
                    Select_All(true);
                }
                else
                {
                    Select_All(false);
                }
            }
        }

        private void chkResult_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                if (chkResult.Checked)
                {
                    UpdateQcResult(true);
                }
                else
                {
                    UpdateQcResult(false);
                }
            }
        }

        private void Select_All(bool blnSelectAll)
        {
            if (dgvDetails.Rows.Count > 0)
            {                
                for (int i = 0; i < dtReport.Rows.Count; i++)
                {
                    dtReport.Rows[i]["flag_select"] = blnSelectAll;
                }
            }
        }

        private void UpdateQcResult(bool blnQcResult)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                for (int i = 0; i < dtReport.Rows.Count; i++)
                {
                    dtReport.Rows[i]["qc_result"] = blnQcResult;
                }
            }
        }
        private void UpdateCheckColor( bool blnCheckColor)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                for (int i = 0; i < dtReport.Rows.Count; i++)
                {
                    dtReport.Rows[i]["check_color"] = blnCheckColor;
                }
            }
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
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
                lblGoods_id.Text = dtReport.Rows[dgvDetails.CurrentCell.RowIndex]["goods_id"].ToString();
                richGoods_name.Text = dtReport.Rows[dgvDetails.CurrentCell.RowIndex]["goods_name"].ToString();
                cmbWorker.SelectedValue = ""; 
                if (dtReport.Rows[dgvDetails.CurrentCell.RowIndex]["qc_by"].ToString() != "")
                {
                    cmbWorker.SelectedValue = dtReport.Rows[dgvDetails.CurrentCell.RowIndex]["qc_by"].ToString();
                }
                //對色
                if (dtReport.Rows[dgvDetails.CurrentCell.RowIndex]["mo_id2"].ToString() != "" &&
                   "0,1".Contains(dtReport.Rows[dgvDetails.CurrentCell.RowIndex]["proofread_status"].ToString()))
                {
                    //符合對色條件
                    pnlCheckColor.Visible = true;
                    if (dtReport.Rows[dgvDetails.CurrentCell.RowIndex]["check_color"].ToString() == "True")                    
                        chkCheckColor.Checked = true;
                    else                    
                        chkCheckColor.Checked = false;
                }else
                {
                    pnlCheckColor.Visible = false;
                    chkCheckColor.Checked = false;
                }
               
                string strArtwork = dtReport.Rows[dgvDetails.CurrentCell.RowIndex]["artwork"].ToString();
                if (!string.IsNullOrEmpty(strArtwork))
                {
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
                btnSet.Text = "數據編輯";
                tbc.SelectedIndex = 1;
            }
            else
            {
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
                    dgvDetails.DataSource = dtReport;
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
            if (dgvDetails.Rows.Count > 0)
            {
                if (chkCheckColor.Checked)
                {
                    UpdateCheckColor(true);
                }
                else
                {
                    UpdateCheckColor(false);
                }
            }
        }
    }
}
