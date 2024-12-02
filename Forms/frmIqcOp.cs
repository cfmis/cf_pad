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
using cf_pad.MDL;
using DevExpress.XtraReports.UI;

namespace cf_pad.Forms
{
    public partial class frmIqcOp : Form
    {

        private bool blPermission =false;
        private string within_code = DBUtility.within_code;
        private string user_id = DBUtility._user_id;
        private string remote_tb = DBUtility.remote_db;

        public frmIqcOp()
        {
            InitializeComponent();
                 
        }

        private void frmIqcOp_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void frmIqcOp_Load(object sender, EventArgs e)
        {
            dgvDetails2.AutoGenerateColumns = false;
            txtBarCode.Focus();
            mskDat1.Text = DateTime.Now.ToString("yyyy/MM/dd");
            mskDat2.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtDept.EditValue = "501";
            txtQcdate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            cmbQcSource.Text = "外發收貨";          
            DataTable dtDept=clsPublicOfGeo.ExecuteSqlReturnDataTable(@"SELECT id,name FROM dbo.cd_department WHERE within_code='0000' AND state='0'");
            txtDept.Properties.DataSource = dtDept;
            txtDept.Properties.ValueMember = "id";
            txtDept.Properties.DisplayMember = "id";

            
           //FQC組別下的用戶才可以保存、刪除
           string sql=string.Format(@"SELECT user_id FROM DGERP2.cferp.dbo.sys_user WHERE user_id='{0}' and group_id LIKE '%QC%'", DBUtility._user_id);
           DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(sql);
           if (dt.Rows.Count > 0 || user_id == "ADMIN")
               blPermission = true;
           else
               blPermission = false;
           dt.Dispose();

           initWorker();//初始化綁定combobox的工號
           //自适应宽度
           //txtGoods_id.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            //填充列
          // txtGoods_id.Properties.PopulateColumns();

           //txtGoods_id.Properties.Columns[0].Width = 110;
           //txtGoods_id.Properties.Columns[1].Width = 50;
           //txtGoods_id.Properties.Columns[2].Width = 50;
           //txtGoods_id.Properties.Columns[3].Width = 40;
           //控制选择项的总宽度
           //txtGoods_id.Properties.PopupWidth = 250;


        }
        //初始化綁定combobox的工號
        private void initWorker()
        {

            cmbWorker.DataSource = clsProductQCRecords.InitWorker("P13-00", "P13-00","159");
            cmbWorker.DisplayMember = "hrm1name";
            cmbWorker.ValueMember = "hrm1wid";
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Enter:
                    DataTable dtBarCode = clsPublicOfPad.BarCodeToItem(txtBarCode.Text);
                    txtBarCode.Text = "";
                    if (dtBarCode.Rows.Count > 0)
                    {
                        string barcode_type = dtBarCode.Rows[0]["barcode_type"].ToString();
                        if (barcode_type == "2")//從生產計劃中提取的條形碼
                        {
                            txtMo_id.Text = dtBarCode.Rows[0]["mo_id"].ToString();
                            txtFindItem1.Text = dtBarCode.Rows[0]["goods_id"].ToString();
                            txtDept.EditValue = dtBarCode.Rows[0]["wp_id"].ToString();
                            if (tbc.SelectedIndex == 1)//如果是在第二個頁面
                                LoadData("page2");
                            else
                                GetRecPlate(1, txtFindItem1.Text);
                            
                        }
                    }
                    else
                        return;
                    txtBarCode.Focus();
                    break;
            }
        }

        private void txtGoods_id_EditValueChanged(object sender, EventArgs e)
        {
            
            
        }        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!blPermission)
            {
                MessageBox.Show(string.Format("當前用戶【{0}】沒有此操作權限!", user_id), "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //if (txtQcdate.Text.Trim() == "/  /" || txtQcdate.Text == "")
            //{
            //    MessageBox.Show(string.Format("QC日期不正確!", user_id), "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtQcdate.Focus();
            //    return;
            //}
            if (!clsValidRule.CheckDateFormat(txtQcdate.Text.Trim()))
            {
                MessageBox.Show(string.Format("QC日期不正確!", user_id), "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQcdate.Focus();
                return;
            }
            if (!chkOk.Checked && !chkNg.Checked)
            {
                MessageBox.Show(string.Format("請選擇檢驗結果OK或NG!", user_id), "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chkOk.Focus();
                return;
            }

            if (cmbWorker.SelectedValue==null || cmbWorker.SelectedValue.ToString() == "")
            {
                MessageBox.Show("工號不能為空!");
                cmbWorker.Focus();
                return;
            }

            int result = 0;
            product_ipqc objModel = new product_ipqc();
            objModel.doc_id = txtId.Text;//單據編號
            objModel.doc_seq = txtSeq.Text;//單據序號
            objModel.seq_no = "001";
            objModel.seq_id = "001";
            objModel.dep_no = txtDept.Text;
            objModel.mo_source = cmbQcSource.Text;//收貨來源
            objModel.qc_date = Convert.ToDateTime(txtQcdate.Text).ToString("yyyy/MM/dd");
            objModel.prd_date = objModel.qc_date;
            objModel.mo_no = txtMo_id.Text;
            objModel.mat_item = txtGoods_id.EditValue.ToString();
            objModel.lot_qty = Int32.Parse(txtQty.Text);
            objModel.qc_remark = txtQc_remark.Text;
            objModel.crusr = user_id;
            objModel.vendor = txtVendor.Text;
            objModel.vendor_id = txtVendor_id.Text;
            objModel.check_qty = Int32.Parse(txtCheck_qty.Text);
            objModel.update_count = "1";
            objModel.transfers_state = "0";
            objModel.adobt_level = "LEVEL II";
            objModel.state = "1";
            objModel.iqc_result = "0";
            objModel.iqc_state = "2";
            objModel.check_times = 1;
            objModel.waster_modality = "001";
            objModel.sequence_id = "0001h";
            objModel.adopt_standard = "Ⅱ";
            objModel.aql_standard = "J";
            objModel.aql_sample = "1.0";
            objModel.accept_qty = Int32.Parse(txtAc.Text);
            objModel.reject_qty = Int32.Parse(txtRe.Text);
            if (chkOk.Checked)
            {
                objModel.iqc_result = "1";
            }
            if (chkNg.Checked)
            {
                objModel.iqc_result = "0";
            }
            objModel.qc_by = cmbWorker.SelectedValue.ToString();//工號

            result = clsCheckOutQty.UpdateIpqc(objModel);
            if (result > 0)
            {
                GetRecPlate(2, "");
                Operation_info("儲存QC記錄成功!");
            }
            else
                MessageBox.Show("儲存QC記錄失敗!");
            txtBarCode.Focus();
            
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!blPermission)
            {
                MessageBox.Show(string.Format("當前用戶【{0}】沒有此操作權限!", user_id), "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int result = 0;
            product_ipqc objModel = new product_ipqc();
            objModel.doc_id = txtId.Text;//單據編號
            objModel.doc_seq = txtSeq.Text;//單據序號
            objModel.state = "2";
            objModel.iqc_result = null;
            objModel.iqc_state = null;
            objModel.qc_doc_id = txtQc_doc_id.Text;
            result = clsCheckOutQty.CancelIpqc(objModel);
            if (result > 0)
            {
                GetRecPlate(2, "");
                Operation_info("注銷QC記錄成功!");
            }
            else
                MessageBox.Show("注銷QC記錄失敗!");
            txtBarCode.Focus();
        }

        private void Operation_info(string msg)//(string msg, Color fore_clr)
        {
            //lblSaveinfo.Text = msg;
            //lblSaveinfo.ForeColor = fore_clr;
            //lblSaveinfo.Visible = true;
            lblSaveinfo.Text = msg;
            Delay(1200); // 延時1.2秒
            lblSaveinfo.Text = "";
            //lblSaveinfo.Visible = false;
        }
        
        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
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
            if ((txtFindMo1.TextLength - txtFindMo1.SelectionLength) == txtFindMo1.MaxLength - 1)
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
            if ((txtFindMo2.TextLength - txtFindMo2.SelectionLength) == txtFindMo2.MaxLength - 1)
            {
                SendKeys.Send("{TAB}");
            }     
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            LoadData("find");
        }
        private void LoadData(string search_type)
        {
            string dat1 = "";
            string dat2 = "";
            int is_qc = 0;//未檢
            string mo1 = "", mo2 = "";
            string item1 = "", item2 = "";
            if (search_type == "page2")//若是條碼掃描，則只顯示已檢的記錄
            {
                mo1 = txtMo_id.Text;
                mo2 = mo1;
                item1 = txtFindItem1.Text;
                item2 = item1;
                is_qc = 1;
            }
            else
            {
                dat1 = mskDat1.Text;
                dat2 = mskDat2.Text;
                mo1 = txtFindMo1.Text;
                mo2 = txtFindMo2.Text;
                item1 = "";
                item2 = "";
                if (dat1.Trim() != "/  /")
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

                if (dat2.Trim() != "/  /")
                {
                    if (!clsValidRule.CheckDateFormat(dat2))
                    {
                        MessageBox.Show("日期格有誤，請返回檢查!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mskDat2.Focus();
                        return;
                    }
                    dat2 = Convert.ToDateTime(dat2).AddDays(1).ToString("yyyy/MM/dd");
                }
                else
                    dat2 = "";

                if (dat1 == "" && dat2 == "" && txtFindMo1.Text == "" && txtFindMo2.Text == "")
                {
                    MessageBox.Show("查詢條件不可為空，請輸入查詢條件!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskDat1.Focus();
                    return;
                }


                if (rdbNoCheck.Checked == true)
                    is_qc = 0;
                if (rdbIsCheck.Checked == true)
                    is_qc = 1;
            }
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@is_qc", is_qc),
                new SqlParameter("@dep", txtDept.EditValue),
                new SqlParameter("@dat1", dat1),
                new SqlParameter("@dat2", dat2),
                new SqlParameter("@mo1", mo1),
                new SqlParameter("@mo2", mo2),
                new SqlParameter("@item1", item1),
                new SqlParameter("@item2", item2)
                };
            DataTable dtReport = clsPublicOfPad.ExecuteProcedure("usp_iqc", paras);


            dgvDetails2.DataSource = dtReport;
            if (dtReport.Rows.Count > 0)
                ShowQcRec(0);
            else
                MessageBox.Show("沒有符合條件的數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void mskDat1_Leave(object sender, EventArgs e)
        {
            mskDat2.Text = mskDat1.Text;
        }

        private void txtMO1_Leave(object sender, EventArgs e)
        {
            txtFindMo2.Text = txtFindMo1.Text;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dtPrint = new DataTable();
            dtPrint.Columns.Add("qc_date", typeof(string));
            dtPrint.Columns.Add("goods_name", typeof(string));
            dtPrint.Columns.Add("mat_item", typeof(string));
            dtPrint.Columns.Add("mo_no", typeof(string));
            dtPrint.Columns.Add("mat_color", typeof(string));
            dtPrint.Columns.Add("lot_qty", typeof(string));
            dtPrint.Columns.Add("dep_no", typeof(string));
            dtPrint.Columns.Add("check_qty", typeof(string));
            dtPrint.Columns.Add("ac", typeof(string));
            dtPrint.Columns.Add("re", typeof(string));
            dtPrint.Columns.Add("qc_remark", typeof(string));
            dtPrint.Columns.Add("vendor", typeof(string));
            DataRow dr = null;
            dr = dtPrint.NewRow();
            dr["qc_date"] = txtQcdate.Text;
            dr["goods_name"] = txtGoods_name.Text;
            dr["mat_item"] = txtGoods_id.EditValue;
            dr["mo_no"] = txtMo_id.Text;
            dr["mat_color"] = txtColor.Text + " / " + txtDo_color.Text;
            dr["lot_qty"] = txtQty.Text;
            dr["dep_no"] = txtDept.EditValue;
            dr["check_qty"] = txtCheck_qty.Text;
            dr["ac"] = txtAc.Text;
            dr["re"] = txtRe.Text;
            dr["qc_remark"] = txtQc_remark.Text;
            dr["vendor"] = txtVendor_id.Text;// + "--" + txtVendor.Text;
            dtPrint.Rows.Add(dr);
            using (xrIqcOp mMyReport = new xrIqcOp() { DataSource = dtPrint })
            {
                mMyReport.CreateDocument();
                mMyReport.PrintingSystem.ShowMarginsWarning = false;
                mMyReport.ShowPreviewDialog();
                //mMyReport.Print();//.ShowPreviewDialog();
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


        private void set_artwork(string artwork)
        {    
            if (!string.IsNullOrEmpty(artwork))
            {
                if (File.Exists(artwork))
                    pic_artwork.Image = Image.FromFile(artwork);
                else
                    pic_artwork.Image = null;
            }
            else
                pic_artwork.Image = null;
        }

        private void txtDept_Click(object sender, EventArgs e)
        {
            txtDept.SelectAll();
        }

        private void chkOk_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOk.Checked)
            {
                chkNg.Checked = false;
            }
        }

        private void chkNg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNg.Checked)
            {
                chkOk.Checked = false;
            }
        }

        private void txtMo_id_Leave(object sender, EventArgs e)
        {
            if (txtMo_id.Text != "" && txtDept.EditValue != "")
            {
                GetRecPlate(1,"");
            }
        }


        //獲取制單編號資料，并綁定物料編號
        private void GetRecPlate(int find_type,string item)
        {
            //cmbGoods_id.Items.Clear();
            string dep = txtDept.EditValue.ToString();
            //if (dep == "104")//如果是104幫102加工的，則將部門改成102來提取記錄
            //    dep = "102";
            //DataTable dtMo_item = clsProductionSchedule.GetMo_dataById(txtMo_id.Text.Trim(), dep, item);
            //if (dtMo_item.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dtMo_item.Rows.Count; i++)
            //    {
            //        cmbGoods_id.Items.Add(dtMo_item.Rows[i]["goods_id"].ToString());
            //    }
            //}

            string dat1 = "", dat2 = "";
            if (txtQcdate.Text.Trim() != "/  /" && txtQcdate.Text.Trim()!="")
            {
                dat1 = Convert.ToDateTime(txtQcdate.Text).AddDays(-3).ToString("yyyy/MM/dd"); 
                dat2 = Convert.ToDateTime(dat1).AddDays(1).ToString("yyyy/MM/dd");
            }
            string strSql = "";
            strSql = "SELECT a.id,a.dept_id,b.sequence_id,b.mo_id,b.goods_id,b.lot_no,convert(int,b.t_ir_qty) as qty" +
                ",CASE ISNULL(b.iqc_state,'') WHEN '2' THEN '檢查完成' ELSE '' END AS iqc_state" +
                ",c.name AS goods_name,d.name AS color_name,d.do_color,dbo.Fn_get_picture_name('0000',b.goods_id,'out') as picture_name" +
                ",a.vendor_id,a.vendor,b.iqc_result,e.id AS qc_doc_id,e.qc_date,e.remark" +
                ",CASE ISNULL(e.state,'') WHEN '2' THEN '已注銷' ELSE '' END AS qc_doc_state,e.check_person as qc_by" +
                " FROM op_outpro_in_mostly a with(nolock) " +
                " INNER JOIN op_outpro_in_detail b with(nolock) ON a.within_code=b.within_code AND a.id=b.id" +
                " INNER JOIN it_goods c with(nolock) ON b.within_code=c.within_code AND b.goods_id=c.id" +
                " INNER JOIN cd_color d with(nolock) ON c.within_code=d.within_code AND c.color=d.id";

            if (find_type==2)
                strSql += " LEFT JOIN ";
            else
            {
                if (chkIsCheck.Checked)
                    strSql += " INNER JOIN ";
                else
                    strSql += " LEFT JOIN ";
            }
            strSql += "op_iqc_mostly e ON b.within_code=e.within_code AND b.id=e.bill_id AND b.sequence_id=e.sequence_id";
            strSql +=" WHERE a.within_code='" + within_code + "' AND a.dept_id='" + dep + "' AND a.state='1' AND b.mo_id='" + txtMo_id.Text + "'";
            if (find_type == 1)
            {
                if (chkIsCheck.Checked)
                    strSql += " AND b.iqc_state ='2'";//IS NOT NULL ";
                else
                    strSql += " AND (b.iqc_state IS NULL OR b.iqc_state ='') ";
                //strSql += " AND a.ir_date>='" + dat1 + "' AND a.ir_date < '" + dat2 + "'";
                if (item != "")
                    strSql += " AND b.goods_id='" + item + "'";
                strSql += "ORDER BY b.iqc_state ";
            }
            else
            {
                strSql += " AND b.id='" + txtId.Text + "' AND b.sequence_id='" + txtSeq.Text + "'";
                if(txtQc_doc_id.Text.Trim()!="")
                    strSql += " AND e.id='" + txtQc_doc_id.Text +  "'";
                strSql += "ORDER BY e.create_date Desc ";
            }
            

            
            DataTable dtIpqc = clsPublicOfGeo.ExecuteSqlReturnDataTable(strSql);
            //dgvDetails.DataSource = dtReport;

            txtGoods_id.Properties.DataSource = dtIpqc;
            txtGoods_id.Properties.ValueMember = "goods_id";
            txtGoods_id.Properties.DisplayMember = "goods_id";

            if (dtIpqc.Rows.Count > 0)
                lblItems.Text = dtIpqc.Rows.Count.ToString();
            else
                lblItems.Text = "";

            
            if (dtIpqc.Rows.Count > 0)
            {
                //txtDept.EditValue = dtReport.Rows[0]["dept_id"].ToString();
                if(dtIpqc.Rows[0]["qc_date"].ToString()!="")
                    txtQcdate.Text = Convert.ToDateTime(dtIpqc.Rows[0]["qc_date"]).ToString("yyyy/MM/dd");
                if (chkIsCheck.Checked == false)//如果是為未QC的記錄，自動設置當前日期
                    txtQcdate.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
                txtMo_id.Text = dtIpqc.Rows[0]["mo_id"].ToString();
                txtGoods_id.EditValue = dtIpqc.Rows[0]["goods_id"].ToString();
                txtIqc_state.Text = dtIpqc.Rows[0]["iqc_state"].ToString();
                txtQty.Text = dtIpqc.Rows[0]["qty"].ToString();
                txtLot_no.Text = dtIpqc.Rows[0]["lot_no"].ToString();
                txtId.Text = dtIpqc.Rows[0]["id"].ToString();
                txtSeq.Text = dtIpqc.Rows[0]["sequence_id"].ToString();
                txtVendor_id.Text = dtIpqc.Rows[0]["vendor_id"].ToString();
                txtVendor.Text = dtIpqc.Rows[0]["vendor"].ToString();
                txtQc_remark.Text = dtIpqc.Rows[0]["remark"].ToString();
                txtQc_doc_id.Text = dtIpqc.Rows[0]["qc_doc_id"].ToString();
                txtQc_doc_state.Text = dtIpqc.Rows[0]["qc_doc_state"].ToString();
                txtGoods_name.Text = dtIpqc.Rows[0]["goods_name"].ToString();
                txtColor.Text = dtIpqc.Rows[0]["color_name"].ToString();
                txtDo_color.Text = dtIpqc.Rows[0]["do_color"].ToString();
                txtRecCount.Text = dtIpqc.Rows.Count.ToString();

                if (dtIpqc.Rows[0]["qc_by"].ToString() != null)//.Substring(0,10);
                    cmbWorker.SelectedValue = dtIpqc.Rows[0]["qc_by"].ToString();

                set_artwork(dtIpqc.Rows[0]["picture_name"].ToString());
                chkOk.Checked = false;
                chkNg.Checked = false;
                string iqc_result=dtIpqc.Rows[0]["iqc_result"].ToString();
                if (iqc_result == "1")
                    chkOk.Checked = true;
                else
                    if (iqc_result == "0")
                        chkNg.Checked =true;
            }
            else
            {
                txtQcdate.Text="";
                txtMo_id.Text = "";
                txtGoods_id.Text = "";
                txtGoods_name.Text = "";
                txtQty.Text = "";
                txtColor.Text = "";
                txtDo_color.Text = "";
                txtLot_no.Text = "";
                txtIqc_state.Text = "";
                txtSeq.Text = "";
                txtNot_ok_rmk.Text = "";
                txtCheck_qty.Text = "";
                txtAc.Text = "";
                txtRe.Text = "";
                txtId.Text = "";
                txtRecCount.Text = "";
                txtVendor_id.Text = "";
                txtVendor.Text = "";
                txtQc_remark.Text = "";
                txtQc_doc_id.Text = "";
                txtQc_doc_state.Text = "";
                cmbWorker.SelectedValue = "";
                chkOk.Checked = false;
                chkNg.Checked = false;
                pic_artwork.Image = null;
                return;
            }
            if (dtIpqc.Rows.Count > 1)
                MessageBox.Show("有多批次記錄待檢驗:" + dtIpqc.Rows.Count.ToString(), "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadCheckStdQty();
        }
        private void LoadQcRec()
        {
            txtQcdate.Text = "";
            txtNot_ok_rmk.SelectedItem = "";
            string strSql = "";
            strSql = "Select qc_date,qc_ok,qc_no_ok,do_result From product_qc_records Where doc_id='" + txtId.Text + "' AND doc_seq='" + txtSeq.Text + "'";
            DataTable tbIpqc = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            if (tbIpqc.Rows.Count > 0)
            {
                txtQcdate.Text = tbIpqc.Rows[0]["qc_date"].ToString();
                txtNot_ok_rmk.SelectedItem = tbIpqc.Rows[0]["do_result"].ToString();
                if (tbIpqc.Rows[0]["qc_ok"].ToString() == "Y")
                    chkOk.Checked = true;
                if (tbIpqc.Rows[0]["qc_no_ok"].ToString() == "N")
                    chkNg.Checked = true;
            }
            if (txtQcdate.Text == "")
                txtQcdate.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            
        }
        private void LoadCheckStdQty()
        {
            string strSql = "";
            string chk_qty=txtQty.Text;
            txtAc.Text = "";
            txtRe.Text = "";
            txtCheck_qty.Text = "";
            strSql = "SELECT aa.start_qty,aa.end_qty, bb.check_qty,bb.accept_qty as ac,bb.reject_qty re" +
                " FROM "+remote_tb+"it_iqclev_detail aa"+
                " INNER JOIN "+remote_tb+"cd_aql bb ON aa.within_code=bb.within_code AND aa.iqc_lev=bb.id" +
                " WHERE  aa.stand_id='Ⅱ' AND bb.sample='1.0' " +
                " AND "+chk_qty+" BETWEEN aa.start_qty AND aa.end_qty";
            DataTable tbStdQty = clsPublicOfGeo.ExecuteSqlReturnDataTable(strSql);
            if (tbStdQty.Rows.Count > 0)
            {
                txtAc.Text = tbStdQty.Rows[0]["ac"].ToString();
                txtRe.Text = tbStdQty.Rows[0]["re"].ToString();
                txtCheck_qty.Text = tbStdQty.Rows[0]["check_qty"].ToString();
            }
        }
        private void btnSet_Click(object sender, EventArgs e)
        {
            if (btnSet.Text == "數據瀏覽")
            {
                btnSet.Text = "數據編輯";
                tbc.SelectedIndex = 1;
                palIsCheck.Visible = false;
            }
            else
            {
                //ShowQcRec(dgvDetails2.CurrentRow.Index);
                btnSet.Text = "數據瀏覽";
                tbc.SelectedIndex = 0;
                palIsCheck.Visible = true;
            }
            txtBarCode.Focus();
        }

        private void dgvDetails2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowQcRec(e.RowIndex);
            }
        }
        private void ShowQcRec(int row)
        {
            txtMo_id.Text = dgvDetails2.Rows[row].Cells["mo_no"].Value.ToString();
            txtId.Text = dgvDetails2.Rows[row].Cells["colDoc_id"].Value.ToString();
            txtSeq.Text = dgvDetails2.Rows[row].Cells["colDoc_seq"].Value.ToString();
            txtQc_doc_id.Text = dgvDetails2.Rows[row].Cells["colQc_doc_id"].Value.ToString();
            //txtQcdate.Text = dgvDetails2.Rows[row].Cells["qc_date"].Value.ToString();
            GetRecPlate(2,"");
        }

        private void rdbNoCheck_Click(object sender, EventArgs e)
        {
            btnFind_Click(sender, e);
        }

        private void rdbIsCheck_Click(object sender, EventArgs e)
        {
            btnFind_Click(sender, e);
        }

        private void txtMo_id_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput(); 
        }

        private void mskDat1_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput(); 
        }

        private void mskDat2_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput(); 
        }

        private void txtFindMo1_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput(); 
        }

        private void txtFindMo2_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput(); 
        }

        private void chkIsCheck_Click(object sender, EventArgs e)
        {
            txtBarCode.Focus();
        }

        private void txtRemark_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput(); 
        }

        private void txtGoods_id_Leave(object sender, EventArgs e)
        {
            if (txtGoods_id.ItemIndex>0)
            {
                txtQty.Text = txtGoods_id.GetColumnValue("qty").ToString();
                txtLot_no.Text = txtGoods_id.GetColumnValue("lot_no").ToString();
                txtIqc_state.Text = txtGoods_id.GetColumnValue("iqc_state").ToString();
                txtSeq.Text = txtGoods_id.GetColumnValue("sequence_id").ToString();
                txtQc_doc_id.Text = txtGoods_id.GetColumnValue("qc_doc_id").ToString();
                LoadCheckStdQty();
            }
        }

        

        private bool isExists(string str)
        {
            return System.Text.RegularExpressions.Regex.Matches(str, "[a-zA-Z]").Count > 0;
        }


    }
}
