using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using cf_pad.CLS;
using System.Data.SqlClient;
using cf_pad.Reports;
using System.IO;
using cf_pad.MDL;
using DevExpress.XtraReports.UI;

namespace cf_pad.Forms
{
    public partial class frmQcOut : Form
    {

        private bool blPermission ;
        private readonly string within_code = DBUtility.within_code;
        private readonly string user_id = DBUtility._user_id;
        private readonly string remote_tb = DBUtility.remote_db;
        DataTable dtReport_ng = new DataTable();
        DataTable dtQCList = new DataTable();

        public frmQcOut()
        {
            InitializeComponent();                 
        }

        private void frmIqcOp_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtReport_ng.Dispose();
            dtQCList.Dispose();
        }

        private void frmIqcOp_Load(object sender, EventArgs e)
        {
            dgvDetails2.AutoGenerateColumns = false;
            txtBarCode.Focus();
            mskDat1.Text = DateTime.Now.ToString("yyyy/MM/dd");
            mskDat2.Text = DateTime.Now.ToString("yyyy/MM/dd");

            mskQcDat1.Text = DateTime.Now.ToString("yyyy/MM/dd");
            mskQcDat2.Text = DateTime.Now.ToString("yyyy/MM/dd");
           
            txtDept.EditValue = "501";
            txtQcdate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            cmbQcSource.Text = "外發收貨";          
            DataTable dtDept=clsPublicOfGeo.ExecuteSqlReturnDataTable(@"SELECT id,name FROM dbo.cd_department WHERE within_code='0000' AND state='0'");
            txtDept.Properties.DataSource = dtDept;
            txtDept.Properties.ValueMember = "id";
            txtDept.Properties.DisplayMember = "id";

            //SetGridFont(gvDetails, new Font("Courier New", 10));
            
            //FQC組別下的用戶才可以保存、刪除
            string sql=string.Format(@"SELECT user_id FROM DGERP2.cferp.dbo.sys_user WHERE user_id='{0}' and group_id LIKE '%QC%'", DBUtility._user_id);
            DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(sql);
            if (dt.Rows.Count > 0 || user_id == "ADMIN")
               blPermission = true;
            else
               blPermission = false;
            dt.Dispose();

            rdbGrp.SelectedIndex = 0;

            initWorker();//初始化綁定combobox的工號
            //自适应宽度
            //txtGoods_id.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            //填充列
            //txtGoods_id.Properties.PopulateColumns();

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
            Close();
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
                MessageBox.Show("QC日期不正確!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQcdate.Focus();
                return;
            }
            if (!chkOk.Checked && !chkNg.Checked)
            {
                MessageBox.Show("請選擇檢驗結果OK或NG!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chkOk.Focus();
                return;
            }

            if (cmbWorker.SelectedValue==null || cmbWorker.SelectedValue.ToString() == "")
            {
                MessageBox.Show("工號不能為空!", "提示信息");
                cmbWorker.Focus();
                return;
            }
            bool select_flag = false;
            for (int RowIndex = 0; RowIndex < gvDetails.RowCount; RowIndex++)
            {
                if (gvDetails.GetDataRow(RowIndex)["chkselect"].ToString() == "True")
                {
                    select_flag = true;
                    break;
                }
            }
            if (!select_flag)
            {
                MessageBox.Show("請首先擇要保存的數據!", "提示信息");
                return;
            }

            int result = 0;
            string goods_id = "";
            string ls_qcstate = "";
            for (int RowIndex = 0; RowIndex < gvDetails.RowCount; RowIndex++)
            {
                if (gvDetails.GetDataRow(RowIndex)["chkselect"].ToString() == "True")
                {                    
                    product_ipqc objModel = new product_ipqc();
                    objModel.doc_id = gvDetails.GetDataRow(RowIndex)["id"].ToString();// txtId.Text;//單據編號
                    objModel.doc_seq = gvDetails.GetDataRow(RowIndex)["sequence_id"].ToString();// txtSeq.Text;//單據序號
                    objModel.seq_no = "001";
                    objModel.seq_id = "001";
                    objModel.dep_no = txtDept.Text;
                    objModel.mo_source = cmbQcSource.Text;//收貨來源
                    objModel.qc_date = Convert.ToDateTime(txtQcdate.Text).ToString("yyyy/MM/dd");
                    objModel.prd_date = objModel.qc_date;
                    objModel.mo_no = txtMo_id.Text;
                    objModel.mat_item = gvDetails.GetDataRow(RowIndex)["goods_id"].ToString();// txtGoods_id.EditValue.ToString();
                    goods_id = objModel.mat_item;
                    objModel.lot_qty = Int32.Parse(gvDetails.GetDataRow(RowIndex)["qty"].ToString());// Int32.Parse(txtQty.Text);
                    objModel.qc_remark = txtQc_remark.Text;
                    objModel.crusr = user_id;
                    objModel.vendor = gvDetails.GetDataRow(RowIndex)["vendor"].ToString(); //txtVendor.Text;
                    objModel.vendor_id = gvDetails.GetDataRow(RowIndex)["vendor_id"].ToString();// txtVendor_id.Text;
                    objModel.check_qty = Int32.Parse(txtCheck_qty.Text);
                    objModel.update_count = "1";
                    objModel.transfers_state = "0";
                    objModel.adobt_level = "LEVEL II";
                    objModel.state = "1";
                    
                    ls_qcstate = txtNot_ok_rmk.Text;/*處理方法*/;                   
                    switch (objModel.state)
                    {
                        case "翻電":
                            objModel.not_ok_rmk = "001";                            
                            break;
                        case "移交":
                            objModel.not_ok_rmk = "002";
                            break;
                        case "分選":
                            objModel.not_ok_rmk = "003";
                            break;
                        case "報廢":
                            objModel.not_ok_rmk = "004";
                            break;
                        default:
                            objModel.not_ok_rmk = "";
                            break;
                    } 
                    objModel.iqc_state = "2";
                    objModel.check_times = 1;
                    objModel.waster_modality = "001";
                    objModel.sequence_id = "0001h";
                    objModel.adopt_standard = "Ⅱ";
                    objModel.aql_standard = "J";
                    objModel.aql_sample = "1.0";
                    objModel.accept_qty = Int32.Parse(txtAc.Text);
                    objModel.reject_qty = Int32.Parse(txtRe.Text);
                    if (string.IsNullOrEmpty(gvDetails.GetDataRow(RowIndex)["iqc_result"].ToString()))
                    {
                        MessageBox.Show("請返回設置QC檢查結果(即設置OK或NG)！");
                        result = 0;
                        break ;
                    }
                    //if (chkOk.Checked)
                    if (gvDetails.GetDataRow(RowIndex)["iqc_result"].ToString()=="1")
                    {
                        objModel.iqc_result = "1";
                    }
                    //if (chkNg.Checked)
                    if (gvDetails.GetDataRow(RowIndex)["iqc_result"].ToString() == "0")
                    {
                        objModel.iqc_result = "0";
                    }
                    objModel.qc_by = gvDetails.GetDataRow(RowIndex)["check_person"].ToString();
                    //if (gvDetails.GetDataRow(RowIndex)["iqc_state"].ToString() == "2")
                    //{
                    //    objModel.qc_by = gvDetails.GetDataRow(RowIndex)["check_person"].ToString();
                    //}
                    //else
                    //   objModel.qc_by = cmbWorker.SelectedValue.ToString();//工號

                    result = clsCheckOutQty.UpdateIpqc(objModel);
                    if (result <= 0)
                        break;
                }
            }
            if (result > 0)
            {
                //GetRecPlate(2, "");//2017/09/18日暫取消
                GetRecPlate(2, goods_id);
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
            product_ipqc objModel = new product_ipqc() { 
                /*objModel.doc_id = txtId.Text;
                 * //單據編號*
                 * / /*objModel.doc_seq = txtSeq.Text;
                 * //單據序號*/
                state = "2", 
                iqc_result = null, 
                iqc_state = null, 
                qc_doc_id = txtQc_doc_id.Text 
            };
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
            lblSaveinfo.Visible = true;
            lblSaveinfo.Text = msg;
            Delay(1200); // 延時1.2秒
            lblSaveinfo.Text = "";
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
            if (e.KeyChar == 13) 
            {
                SendKeys.Send("{TAB}");                
            }            
        }

        private void txtMO1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //按回車跳到下一控件                
            if (e.KeyChar == 13) 
            {
                SendKeys.Send("{TAB}");                
            }
            if ((txtFindMo1.TextLength - txtFindMo1.SelectionLength) == txtFindMo1.MaxLength - 1)
            {
                SendKeys.Send("{TAB}");
            }     
        }

        private void txtMO2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //按回車跳到下一控件                
            if (e.KeyChar == 13) 
            {
                SendKeys.Send("{TAB}");                
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
            if (MessageBox.Show("確定要列印不合格報表？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                dtPrint.Columns.Add("inspector", typeof(string));

                DataRow dr = dtPrint.NewRow();
                dr["qc_date"] = txtQcdate.Text;
                dr["goods_name"] = txtGoods_name.Text;
                dr["mat_item"] = txtGoods_id.Text ;
                dr["mo_no"] = txtMo_id.Text;
                dr["mat_color"] = String.Format("{0} / {1}", txtColor.Text, txtDo_color.Text);
                dr["lot_qty"] = txtQty.Text;
                dr["dep_no"] = txtDept.EditValue;
                dr["check_qty"] = txtCheck_qty.Text;
                dr["ac"] = txtAc.Text;
                dr["re"] = txtRe.Text;
                dr["qc_remark"] = txtQc_remark.Text;
                dr["vendor"] = txtVendor_id.Text;// + "--" + txtVendor.Text;
                dr["inspector"] = cmbWorker.Text;
                dtPrint.Rows.Add(dr);
                using (xrIqcOp mMyReport = new xrIqcOp() { DataSource = dtPrint })
                {
                    mMyReport.CreateDocument();
                    mMyReport.PrintingSystem.ShowMarginsWarning = false;
                    mMyReport.Print();
                    //mMyReport.ShowPreviewDialog();
                }                
            }            
        }

        private void tbc_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbc.SelectedIndex)
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
                gvDetails.SetRowCellValue(gvDetails.FocusedRowHandle, "iqc_result", "1");
            }
        }

        private void chkNg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNg.Checked)
            {
                chkOk.Checked = false;
                gvDetails.SetRowCellValue(gvDetails.FocusedRowHandle, "iqc_result", "0");
            }
        }

        private void txtMo_id_Leave(object sender, EventArgs e)
        {
            if (txtMo_id.Text != "" && txtDept.Text != "")
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
            strSql = @"SELECT a.id,Convert(varchar(10),a.ir_date,120) as ir_date,a.dept_id,b.sequence_id,b.mo_id,b.goods_id,b.lot_no
                ,convert(int,b.t_ir_qty) as qty,CASE ISNULL(b.iqc_state,'') WHEN '2' THEN '檢查完成' ELSE '' END AS iqc_state
                ,c.name AS goods_name,d.name AS color_name,d.do_color,dbo.Fn_get_picture_name('0000',b.goods_id,'out') as picture_name 
                ,a.vendor_id,a.vendor,b.iqc_result,e.id AS qc_doc_id,e.qc_date,e.remark
                ,CASE ISNULL(e.final_solution,'') 
                 WHEN '001' THEN '翻電' 
                 WHEN '002' THEN '移交' 
                 WHEN '003' THEN '分揀' 
                 WHEN '004' THEN '報廢' ELSE '' END AS final_solution
                ,CASE ISNULL(e.state,'') WHEN '2' THEN '已注銷' ELSE '' END AS qc_doc_state,e.check_person as qc_by
                ,e.unqualified_iqc_seq,e.unqualified_category,e.check_person
                 FROM op_outpro_in_mostly a with(nolock) 
                 INNER JOIN op_outpro_in_detail b with(nolock) ON a.within_code=b.within_code AND a.id=b.id 
                 INNER JOIN it_goods c with(nolock) ON b.within_code=c.within_code AND b.goods_id=c.id 
                 INNER JOIN cd_color d with(nolock) ON c.within_code=d.within_code AND c.color=d.id ";
            if (find_type==2)
                strSql += " LEFT JOIN ";
            else
            {
                if (chkIsCheck.Checked)
                    strSql += " INNER JOIN ";
                else
                    strSql += " LEFT JOIN ";
            }
            strSql += "op_iqc_mostly e with(nolock) ON b.within_code=e.within_code AND b.id=e.bill_id AND b.sequence_id=e.sequence_id";
            strSql += String.Format(" WHERE a.within_code='{0}' AND a.dept_id='{1}' AND a.state='1' AND b.mo_id='{2}'", within_code, dep, txtMo_id.Text);
            if (find_type == 1)
            {
                if (chkIsCheck.Checked)
                    strSql += " AND b.iqc_state ='2'";//IS NOT NULL ";
                else
                    strSql += " AND (b.iqc_state IS NULL OR b.iqc_state ='') ";
                //strSql += " AND a.ir_date>='" + dat1 + "' AND a.ir_date < '" + dat2 + "'";
                if (item != "")
                    strSql += String.Format(" AND b.goods_id='{0}'", item);
                strSql += "ORDER BY b.iqc_state ";
            }
            else
            {
                //if(txtQc_doc_id.Text.Trim()!="")////2017/09/18日暫取消
                //    strSql += " AND e.id='" + txtQc_doc_id.Text +  "'";
                if (item != "")//2017/09/18日暫替換
                    strSql += String.Format(" AND b.goods_id='{0}'", item);
                strSql += "ORDER BY e.create_date Desc ";
            } 
            
            DataTable dtIpqc = clsPublicOfGeo.ExecuteSqlReturnDataTable(strSql);
            //dgvDetails.DataSource = dtReport;
            dtIpqc.Columns.Add("chkselect", System.Type.GetType("System.Boolean"));

            gc1.DataSource = dtIpqc;
            if (dtIpqc.Rows.Count > 0)
            {
                //==========以下代碼取消于2018-04-09
                //int qty = 0;
                //for (int i = 0; i < dtIpqc.Rows.Count; i++)
                //{
                //    dtIpqc.Rows[i]["chkselect"] = true;
                //    qty = qty + Convert.ToInt32(dtIpqc.Rows[i]["qty"]);
                //}
                //txtTotQty.Text = qty.ToString();
                //==========

                //txtDept.EditValue = dtReport.Rows[0]["dept_id"].ToString();
                if (dtIpqc.Rows[0]["qc_date"].ToString() != "")
                {
                    txtQcdate.Text = Convert.ToDateTime(dtIpqc.Rows[0]["qc_date"]).ToString("yyyy/MM/dd");
                }
                if (chkIsCheck.Checked == false)//如果是為未QC的記錄，自動設置當前日期
                {
                    txtQcdate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                }
                txtMo_id.Text = dtIpqc.Rows[0]["mo_id"].ToString();
                txtId.Text = dtIpqc.Rows[0]["id"].ToString();
                txtSeq.Text = dtIpqc.Rows[0]["sequence_id"].ToString();
                txtIqc_state.Text = dtIpqc.Rows[0]["iqc_state"].ToString();
                //txtVendor_id.Text = dtIpqc.Rows[0]["vendor_id"].ToString();
                txtQc_remark.Text = dtIpqc.Rows[0]["remark"].ToString();
                txtQc_doc_id.Text = dtIpqc.Rows[0]["qc_doc_id"].ToString();
                txtQc_doc_state.Text = dtIpqc.Rows[0]["qc_doc_state"].ToString();
                txtQty.Text = dtIpqc.Rows[0]["qty"].ToString();
                txtIr_date.Text = dtIpqc.Rows[0]["ir_date"].ToString();
                txtNot_ok_rmk.Text = dtIpqc.Rows[0]["final_solution"].ToString();//因更新處理方法時主從表一起更新相同的值，所以直接取主表
                if (dtIpqc.Rows[0]["qc_by"].ToString() != null)//.Substring(0,10);
                {
                    cmbWorker.SelectedValue = dtIpqc.Rows[0]["qc_by"].ToString();
                }
                set_artwork(dtIpqc.Rows[0]["picture_name"].ToString());
                chkOk.Checked = false;
                chkNg.Checked = false;
                string iqc_result=dtIpqc.Rows[0]["iqc_result"].ToString();
                if (iqc_result == "1")
                    chkOk.Checked = true;
                else
                {
                    if (iqc_result == "0")
                    {
                        chkNg.Checked = true;
                    }
                }
            }
            else
            {
                txtQcdate.Text="";
                txtMo_id.Text = "";
                txtIqc_state.Text = "";
                txtNot_ok_rmk.Text = "";
                txtTotQty.Text = "";
                txtCheck_qty.Text = "";
                txtAc.Text = "";
                txtRe.Text = "";
                txtVendor_id.Text = "";
                txtQc_remark.Text = "";
                txtQc_doc_id.Text = "";
                txtQc_doc_state.Text = "";                
                txtQty.Text = "";
                txtIr_date.Text = "";
                cmbWorker.SelectedValue = "";
                chkOk.Checked = false;
                chkNg.Checked = false;
                pic_artwork.Image = null;
                return;
            }

            LoadCheckStdQty();
        }

        //private void LoadQcRec()
        //{
        //    txtQcdate.Text = "";
        //    txtNot_ok_rmk.SelectedItem = "";
        //    string strSql = "";
        //    string id = "", seq = "";
        //    strSql = String.Format("Select qc_date,qc_ok,qc_no_ok,do_result From product_qc_records Where doc_id='{0}' AND doc_seq='{1}'", id, seq);
        //    DataTable tbIpqc = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
        //    if (tbIpqc.Rows.Count > 0)
        //    {
        //        txtQcdate.Text = tbIpqc.Rows[0]["qc_date"].ToString();
        //        txtNot_ok_rmk.SelectedItem = tbIpqc.Rows[0]["do_result"].ToString();
        //        if (tbIpqc.Rows[0]["qc_ok"].ToString() == "Y")
        //            chkOk.Checked = true;
        //        if (tbIpqc.Rows[0]["qc_no_ok"].ToString() == "N")
        //            chkNg.Checked = true;
        //    }
        //    if (txtQcdate.Text == "")
        //        txtQcdate.Text = DateTime.Now.ToString("yyyy/MM/dd");            
        //}

        private void LoadCheckStdQty()
        {
            string strSql = "";
            //string chk_qty = txtTotQty.Text;
            string chk_qty = txtQty.Text; //2018-04-09 改為每次收貨的數量
            txtAc.Text = "";
            txtRe.Text = "";
            txtCheck_qty.Text = "";
            strSql = String.Format(
           @"SELECT aa.start_qty,aa.end_qty, bb.check_qty,bb.accept_qty as ac,bb.reject_qty re 
           FROM {0}it_iqclev_detail aa INNER JOIN {0}cd_aql bb ON aa.within_code=bb.within_code AND aa.iqc_lev=bb.id 
           WHERE aa.stand_id='Ⅱ' AND bb.sample='1.0' AND {1} BETWEEN aa.start_qty AND aa.end_qty", remote_tb, chk_qty);
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
     
        private void ShowQcRec(int row)
        {
            txtMo_id.Text = dgvDetails2.Rows[row].Cells["mo_no"].Value.ToString();
            txtId.Text = dgvDetails2.Rows[row].Cells["colDoc_id"].Value.ToString();
            txtSeq.Text = dgvDetails2.Rows[row].Cells["colDoc_seq"].Value.ToString();
            txtQc_doc_id.Text = dgvDetails2.Rows[row].Cells["colQc_doc_id"].Value.ToString();
            GetRecPlate(2,"");
        }

        private void rdbNoCheck_Click(object sender, EventArgs e)
        {
                rdbIsCheck.Checked = false;
                btnFind_Click(sender, e);
        }

        private void rdbIsCheck_Click(object sender, EventArgs e)
        {
            rdbNoCheck.Checked = false;
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


        //private static bool isExists(string str)
        //{
        //    return System.Text.RegularExpressions.Regex.Matches(str, "[a-zA-Z]").Count > 0;
        //}


        private void sumQty()
        {
            //2018-04-09 取消
            //int qty = Convert.ToInt32(txtTotQty.Text);
            //int RowIndex = gvDetails.FocusedRowHandle;
            ////for (int RowIndex = 0; RowIndex < gvDetails.RowCount; RowIndex++)
            ////{
            //    if (gvDetails.GetDataRow(RowIndex)["chkselect"].ToString() == "True")
            //    {
            //        gvDetails.GetDataRow(RowIndex)["chkselect"] = false;
            //        qty -= Convert.ToInt32(gvDetails.GetDataRow(RowIndex)["qty"]);
            //    }
            //    else
            //    {
            //        gvDetails.GetDataRow(RowIndex)["chkselect"] = true;
            //        qty += Convert.ToInt32(gvDetails.GetDataRow(RowIndex)["qty"]);
            //    }
            ////}
            //txtTotQty.Text = qty.ToString();
            //LoadCheckStdQty();
        }


        private void gcCheck_Click(object sender, EventArgs e)
        {
            //sumQty();
        }     

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            tbc.SelectedIndex = 2;         
        }

        private void mskQcDat1_Leave(object sender, EventArgs e)
        {
            mskQcDat2.Text = mskQcDat1.Text;
        }

        private void btnQC_Click(object sender, EventArgs e)
        {
            Load_Ipqc_NG_Data("1"); //取不合格的數據
        }
        /// <summary>
        /// 取外發IPQC不合格數據
        /// </summary>
        private void Load_Ipqc_NG_Data(string reprot_type)
        {           
            string dat1 = "";
            string dat2 = "";            
            dat1 = mskQcDat1.Text;
            dat2 = mskQcDat2.Text;
            if (dat1.Trim() != "/  /")
            {
                if (!clsValidRule.CheckDateFormat(dat1))
                {
                    MessageBox.Show("日期格有誤，請返回檢查!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskQcDat1.Focus();
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
                    mskQcDat2.Focus();
                    return;
                }
                dat2 = Convert.ToDateTime(dat2).AddDays(1).ToString("yyyy/MM/dd");
            }
            else
                dat2 = "";

            if (dat1 == "" && dat2 == "" && txtMo1.Text =="" && txtMo1.Text =="")
            {
                MessageBox.Show("查詢條件或頁數不可為空！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskQcDat1.Focus();
                return;
            }
            
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@report_type", reprot_type),
                new SqlParameter("@dat1", dat1),
                new SqlParameter("@dat2", dat2),
                new SqlParameter("@mo_id1",txtMo1.Text),
                new SqlParameter("@mo_id2",txtMo2.Text),
                new SqlParameter("@vendor_id1",txtVendor_id1.Text),
                new SqlParameter("@vendor_id2",txtVendor_id2.Text),
                new SqlParameter("@retrun_ok_ng_all",rdbGrp.SelectedIndex.ToString())
            };
            dtReport_ng = clsPublicOfPad.ExecuteProcedure("usp_get_ipqc_data", paras);
            if (dtReport_ng.Rows.Count == 0)
            {
                MessageBox.Show("沒有符合查找條件的數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // return;
            }

            if (reprot_type == "1")
            {
                dgvQCNG.DataSource = dtReport_ng;               
            }
            else
            {
                dtQCList = dtReport_ng.Copy();
                dtReport_ng.Clear();
                using (xrIpqcList mMyReport = new xrIpqcList() { DataSource = dtQCList })
                {
                    mMyReport.CreateDocument();
                    mMyReport.PrintingSystem.ShowMarginsWarning = false;                    
                    mMyReport.ShowPreviewDialog();
                }
            }
        }

        private void mskQcDat1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                SendKeys.Send("{TAB}");
            }  
        }

        private void mskQcDat1_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput(); 
        }

        private void mskQcDat2_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void btnNG_Click(object sender, EventArgs e)
        {
            rdbGrp.SelectedIndex = 0;
            if (dgvQCNG.RowCount == 0)
            {
                MessageBox.Show("沒有符合查找條件的數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (xrIpqc_ng mMyReport = new xrIpqc_ng() { DataSource = dtReport_ng })
            {
                mMyReport.CreateDocument();
                mMyReport.PrintingSystem.ShowMarginsWarning = false;
                //mMyReport.Print();
                mMyReport.ShowPreviewDialog();
            }
        }

        private void txtMo1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }  
        }

        private void txtMo1_Leave_1(object sender, EventArgs e)
        {
            txtMo2.Text = txtMo1.Text;
        }

        private void txtMo1_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtMo2_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void dgvDetails2_SelectionChanged(object sender, EventArgs e)
        {            
            if (dgvDetails2.RowCount>0) //.CurrentCell.RowIndex>= 0
            {
                ShowQcRec(dgvDetails2.CurrentCell.RowIndex);
            }
        }    

        private void txtVendor_id1_Leave(object sender, EventArgs e)
        {
            txtVendor_id2.Text = txtVendor_id1.Text;
        }

        private void txtVendor_id1_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtVendor_id2_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void btnQcList_Click(object sender, EventArgs e)
        {
            Load_Ipqc_NG_Data("2"); //根據條件取合格或不合格或者全部          
        }

        private void gvDetails_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gvDetails.RowCount > 0)
            {
                int i = gvDetails.FocusedRowHandle;
                txtGoods_id.Text = gvDetails.GetRowCellValue(i, "goods_id").ToString();
                txtGoods_name.Text = gvDetails.GetRowCellValue(i, "goods_name").ToString();
                txtVendor_id.Text = gvDetails.GetRowCellValue(i, "vendor_id").ToString();                
                txtColor.Text = gvDetails.GetRowCellValue(i, "color_name").ToString();
                txtDo_color.Text = gvDetails.GetRowCellValue(i, "do_color").ToString();
                txtMo_id.Text = gvDetails.GetRowCellValue(i, "mo_id").ToString();
                txtId.Text = gvDetails.GetRowCellValue(i, "id").ToString();
                txtSeq.Text = gvDetails.GetRowCellValue(i, "sequence_id").ToString();

                txtQc_doc_id.Text = gvDetails.GetRowCellValue(i, "qc_doc_id").ToString();
                txtQc_doc_state.Text = gvDetails.GetRowCellValue(i, "qc_doc_id").ToString();
                txtIqc_state.Text = gvDetails.GetRowCellValue(i, "iqc_state").ToString();                
                txtQty.Text = gvDetails.GetRowCellValue(i, "qty").ToString();

                if (gvDetails.GetRowCellValue(i, "iqc_result").ToString() == "1")
                    chkOk.Checked = true;
                else
                {
                    chkOk.Checked = false;
                }
                if (gvDetails.GetRowCellValue(i, "iqc_result").ToString() == "0")
                    chkNg.Checked = true;
                else
                {
                    chkNg.Checked = false;
                }
                LoadCheckStdQty();
            }
        }
    
        private void cmbWorker_Leave(object sender, EventArgs e)
        {
            string work_id = cmbWorker.SelectedValue.ToString();
            if (gvDetails.RowCount > 0)
            {
                gvDetails.SetRowCellValue(gvDetails.FocusedRowHandle, "check_person", work_id);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvQCNG.RowCount > 0)
            {
                ExpToExcel.DataGridViewToExcel(dgvQCNG);
            }
        }

    }
}
