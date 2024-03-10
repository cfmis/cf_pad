using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//using cf01.ModuleClass;
using cf_pad.CLS;
using cf_pad.MDL;

namespace cf_pad.Forms
{
    public partial class frmProductQtyConfirm : Form
    {
        private string usrid = DBUtility._user_id;
        private string remote_db = DBUtility.remote_db;
        private string input_type = "0";//0--人手輸入，1--條碼輸入
        public frmProductQtyConfirm()
        {
            InitializeComponent();
        }

        private void frmProductQtyConfirm_Load(object sender, EventArgs e)
        {
            //clsControlInfoHelper forminit = new clsControlInfoHelper(this.Name, this.Controls);
            //forminit.GenerateContorl();


            //dgvDetails.RowHeadersVisible = true;  //因類clsControlInfoHelper DataGridView中已屏蔽行標頭,此處重新恢覆回來
            //dgvDetails.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect; //因類clsControlInfoHelper的問題，此處重新恢覆整行選中的屬性
            dgvDetails.AutoGenerateColumns = false;
            if (usrid.Length > 3)
            {
                if (usrid.Substring(0, 3).ToUpper() == "BUT")
                    textDep1.Text = "102";
                else
                {
                    if (usrid.Substring(0, 3).ToUpper() == "ALY")//合金部的,只對選貨記錄的
                        textDep1.Text = "302";
                }
            }
            this.mktDate1.Text = clsUtility.changeDateFormat(DateTime.Now);
            this.mktDate2.Text = clsUtility.changeDateFormat(DateTime.Now);
            dteSentDate.Text = clsUtility.changeDateFormat(DateTime.Now.AddDays(-1));
            dtpStart.Value = Convert.ToDateTime("2014/01/01 " + "00:00");
            dtpEnd.Value = Convert.ToDateTime("2014/01/01 " + "23:59");
            Font a = new Font("GB2312", 14);//GB2312为字体名称，1为字体大小dataGridView1.Font = a;
            dgvDetails.Font = a;
            txtBarCode.Focus();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void find_data(string prd_item)
        {
            string conf_flag, qc_flag;
            string conf_date1, conf_date2;
            string prd_date1, prd_date2;
            conf_flag = "";
            qc_flag = "";
            conf_date1 = "";
            conf_date2 = "";
            prd_date1 = "";
            prd_date2 = "";
            if (textDep1.Text == "")
            {
                MessageBox.Show("部門不能為空!");
                this.textDep1.Focus();
                return;
            }
            if (clsValidRule.CheckDateIsEmpty(this.mktDate1.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.mktDate1.Text) == false)
                {
                    MessageBox.Show("日期不正確!");
                    this.mktDate1.Focus();
                    return;
                }
                else
                    prd_date1 = this.mktDate1.Text;
            }
            if (clsValidRule.CheckDateIsEmpty(this.mktDate2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.mktDate2.Text) == false)
                {
                    MessageBox.Show("日期不正確!");
                    this.mktDate2.Focus();
                    return;
                }
                else
                    prd_date2 = this.mktDate2.Text;
            }
            if (clsValidRule.CheckDateIsEmpty(this.mktConfTime1.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.mktConfTime1.Text) == false)
                {
                    MessageBox.Show("磅貨日期不正確!");
                    this.mktConfTime1.Focus();
                    return;
                }
                else
                    conf_date1 = mktConfTime1.Text + " " + dtpStart.Text.ToString();
            }
            if (clsValidRule.CheckDateIsEmpty(this.mktConfTime2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.mktConfTime2.Text) == false)
                {
                    MessageBox.Show("磅貨日期不正確!");
                    this.mktConfTime2.Focus();
                    return;
                }
                else
                    conf_date2 = mktConfTime2.Text + " " + dtpEnd.Text.ToString();
            }

            if (rdbNoConf.Checked == true)//未確認收貨
                conf_flag = "N";
            if (rdbYesConf.Checked == true)//已確認收貨
                conf_flag = "Y";
            if (chkQc.Checked == false)//是否已QC
                qc_flag = "Y";
            //先從生產記錄中查找記錄
            DataTable dtPrdRec = clsProductionSchedule.GetProductQtyConfirm(textDep1.Text.Trim(), prd_date1, prd_date2, textMo1.Text.Trim(), prd_item, conf_date1, conf_date2, qc_flag, conf_flag);
            
            dgvDetails.DataSource = dtPrdRec;
            FillControls();
        }
        //在生產計劃中提取記錄，作為生產記錄
        private DataTable GetMoFromPlan(string id,int ver,string seq)
        {
            string strSql = "";
            strSql = "SELECT a.id, a.mo_id AS prd_mo,b.goods_id AS prd_item, d.name AS item_desc,c.materiel_id AS mat_item, e.name AS mat_item_desc " +
                ",convert(int,b.prod_qty) AS prd_qty, b.wp_id AS prd_dep,b.next_wp_id AS to_dep " +
                " FROM " +
                remote_db + "jo_bill_mostly a " +
                "INNER JOIN " + remote_db + "jo_bill_goods_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver " +
                "INNER JOIN " + remote_db + "jo_bill_materiel_details c ON b.within_code=c.within_code AND b.id=c.id AND b.ver=c.ver AND b.sequence_id = c.upper_sequence " +
                " LEFT OUTER JOIN " + remote_db + "it_goods d ON b.within_code=d.within_code AND b.goods_id=d.id " +
                " LEFT OUTER JOIN " + remote_db + "it_goods e ON c.within_code=e.within_code AND c.materiel_id=e.id " +
                " WHERE a.within_code='" + "0000" + "'" + " AND a.id= '" + id + "' AND a.ver='" + ver + "' AND b.sequence_id = '" + seq + "'";

            DataTable dtMo = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            dtMo.Columns.Add("prd_id", typeof(string));
            dtMo.Columns.Add("mat_item_lot", typeof(string));
            dtMo.Columns.Add("prd_weg", typeof(string));
            dtMo.Columns.Add("qc_flag", typeof(string));
            dtMo.Columns.Add("conf_flag", typeof(string));
            dtMo.Columns.Add("conf_time", typeof(string));
            dtMo.Columns.Add("pack_num", typeof(string));
            dtMo.Columns.Add("actual_qty", typeof(string));
            dtMo.Columns.Add("actual_weg", typeof(string));
            dtMo.Columns.Add("actual_pack_num", typeof(string));
            dtMo.Columns.Add("sample_no", typeof(string));
            dtMo.Columns.Add("sample_weg", typeof(string));
            return dtMo;
        }
        private bool valid_data()
        {
            //if (txtReq.Text == "")
            //{
            //    MessageBox.Show("記錄號無效,不能儲存!");
            //    return false;
            //}

            string returnMsg = "";
            returnMsg = clsValidRule.validInputInt(txtQty.Text);
            if (returnMsg != "")
            {
                MessageBox.Show(returnMsg);
                txtQty.Focus();
                return false;
            }
            returnMsg = clsValidRule.validInputInt(txtActualPack.Text);
            if (returnMsg != "")
            {
                MessageBox.Show(returnMsg);
                txtActualPack.Focus();
                return false;
            };
            returnMsg = clsValidRule.validInputNumeric((txtWeg.Text));
            if (returnMsg != "")
            {
                MessageBox.Show(returnMsg);
                txtWeg.Focus();
                return false;
            }

            if (txtConf_flag.Text.Trim() == "Y")// && chk_insert_status() == true)
            {
                MessageBox.Show("這筆記錄已收貨!");
                return false;
            }
            return true;
        }

        private void save_process(string upd_type)
        {
            int Result = 0;
            product_records objModel = new product_records();
            objModel.actual_pack_num = (txtActualPack.Text !="" ? Convert.ToInt32(txtActualPack.Text):1);
            objModel.mat_item = txtMatItem.Text.ToString();
            objModel.mat_item_lot = txtMatLot.Text.ToString();
            objModel.mat_item_desc = txtMatDesc.Text.ToString();
            objModel.sample_no = (txtSample_no.Text != "" ? Convert.ToInt32(txtSample_no.Text) : 0);
            objModel.sample_weg = Math.Round((txtSample_weg.Text != "" ? Convert.ToDecimal(txtSample_weg.Text) : 0), 4);
            objModel.to_dep = txtToDep.Text.Trim();
            objModel.conf_time = System.DateTime.Now;
            if (upd_type == "Y")
            {
                objModel.actual_qty = Convert.ToSingle(txtQty.Text);
                objModel.actual_weg = Convert.ToSingle(txtWeg.Text);
                objModel.conf_flag = "Y";
            }
            else
            {
                objModel.actual_qty = 0;
                objModel.actual_weg = 0;
                objModel.conf_flag = "";
            }
            if (txtReq.Text.Trim() != "")//如果是從生產單中收貨
            {
                objModel.prd_id = Convert.ToInt32(txtReq.Text);
                Result=clsProductionSchedule.UpdatePrdActualQty(objModel);
                
            }
            else//如果是從生產計劃單中收貨，則要產生記錄號，並將記錄插入生產單中，生產類型為A03
            {
                objModel.prd_id = clsPublicOfPad.GenNo("frmProductionSchedule");//自動產生序列號
                if (objModel.prd_id == 0)
                {
                    MessageBox.Show("儲存記錄失敗!");
                }
                else
                {
                    objModel.prd_dep = txtFdep.Text.Trim();
                    objModel.prd_mo = txtPrdMo.Text.Trim();
                    objModel.prd_date = clsUtility.changeDateFormat(System.DateTime.Now);
                    objModel.prd_item = txtPrdItem.Text.Trim();
                    objModel.prd_pdate = clsUtility.changeDateFormat(System.DateTime.Now);
                    objModel.crusr = DBUtility._user_id;
                    objModel.crtim = System.DateTime.Now;
                    if (objModel.prd_dep == "105" || objModel.prd_dep == "302")
                        objModel.prd_work_type = "A03";
                    else
                        objModel.prd_work_type = "A02";
                    Result=clsProductionSchedule.InsertPrdActualQty(objModel);
                }
            }
            //如果是從JX收貨的磅貨，則要將收貨記錄插入到product_transfer_jx_details中，以更新之前發貨到JX的狀態
            if (rdgFromJx.Checked == true)
            {
                if (Result > 0 && upd_type == "Y")
                {

                    int Transfer_flag = 1;
                    //DataTable dt = clsProductionSchedule.CheckGoodsTransferJx(txtFdep.Text.Trim(), txtPrdItem.Text.Trim(), txtPrdMo.Text.Trim(), Transfer_flag);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    if (MessageBox.Show("已存在一筆從JX收貨的記錄,是否重複儲存?", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                    //    {
                    //        Result = 0;
                    //    }

                    //}
                    product_transfer_jx_details objModelJx = new product_transfer_jx_details();
                    objModelJx.Prd_dep = txtFdep.Text.Trim();
                    objModelJx.Transfer_date = clsUtility.changeDateFormat(System.DateTime.Now);
                    objModelJx.sentDate = dteSentDate.Text;
                    objModelJx.Prd_item = txtPrdItem.Text.Trim();
                    objModelJx.Prd_mo = txtPrdMo.Text.Trim();
                    objModelJx.Transfer_flag = Transfer_flag;
                    objModelJx.Transfer_qty = Convert.ToDecimal(objModel.actual_qty);
                    objModelJx.Transfer_weg = Convert.ToDecimal(objModel.actual_weg);
                    objModelJx.packNum = objModel.actual_pack_num;
                    objModelJx.To_dep = objModel.to_dep;
                    objModelJx.Crusr = DBUtility._user_id;
                    objModelJx.Crtim = clsUtility.changeDateTimeFormat(System.DateTime.Now);
                    Result = clsGoodsTransferJx.UpdateGoodsTransferJx(objModelJx);
                }
            }
            if (Result > 0)
            {
                MessageBox.Show("儲存成功！", "系統信息");
                find_data("");//不用物料編號
            }
            else
            {
                MessageBox.Show("儲存失敗！", "系統信息");
            }
        
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillControls();
        }
        private void FillControls()
        {
            if (dgvDetails.RowCount == 0)
                return;
            txtReq.Text = dgvDetails.CurrentRow.Cells["colPrd_id"].Value.ToString();
            txtPrdMo.Text = dgvDetails.CurrentRow.Cells["colPrd_mo"].Value.ToString();
            txtPrdItem.Text = dgvDetails.CurrentRow.Cells["colPrd_item"].Value.ToString();
            txtItemDesc.Text = dgvDetails.CurrentRow.Cells["colItem_desc"].Value.ToString();
            txtMatItem.Text = dgvDetails.CurrentRow.Cells["colMat_item"].Value.ToString();
            txtMatDesc.Text = dgvDetails.CurrentRow.Cells["colMat_item_desc"].Value.ToString();
            txtMatLot.Text = dgvDetails.CurrentRow.Cells["colMat_item_lot"].Value.ToString();
            txtToDep.Text = dgvDetails.CurrentRow.Cells["colTo_dep"].Value.ToString();
            txtFdep.Text = dgvDetails.CurrentRow.Cells["colPrd_dep"].Value.ToString();
            txtQc_flag.Text = dgvDetails.CurrentRow.Cells["colQc_flag"].Value.ToString();
            txtConf_flag.Text = dgvDetails.CurrentRow.Cells["colConf_flag"].Value.ToString();
            txtConf_time.Text = dgvDetails.CurrentRow.Cells["colConf_time"].Value.ToString();
            txtSample_no.Text = (dgvDetails.CurrentRow.Cells["colSample_no"].Value.ToString() != "0" ? dgvDetails.CurrentRow.Cells["colSample_no"].Value.ToString() : "");
            txtSample_weg.Text = (dgvDetails.CurrentRow.Cells["colSample_weg"].Value.ToString() != "0" ? dgvDetails.CurrentRow.Cells["colSample_weg"].Value.ToString() : "");
            if (txtConf_flag.Text.Trim() != "Y")
            {
                txtQty.Text = dgvDetails.CurrentRow.Cells["colPrd_qty"].Value.ToString();
                txtWeg.Text = dgvDetails.CurrentRow.Cells["colPrd_weg"].Value.ToString();
                txtActualPack.Text = dgvDetails.CurrentRow.Cells["colPack_num"].Value.ToString();
            }
            else
            {
                txtQty.Text = dgvDetails.CurrentRow.Cells["colActual_qty"].Value.ToString();
                txtWeg.Text = dgvDetails.CurrentRow.Cells["colActual_weg"].Value.ToString();
                txtActualPack.Text = dgvDetails.CurrentRow.Cells["colActual_pack_num"].Value.ToString();
            }
            if (txtActualPack.Text.Trim() == "0" || txtActualPack.Text.Trim() == "")
                txtActualPack.Text = "1";
            ReFindPlanRec();//重新查找生產計劃中的記錄
        }
        //因為在輸入生產報表時，可能沒有下部門，所以重新在在生產流程中找出下部門，若已存在下部門，就不找了
        private void ReFindPlanRec()
        {
            if (txtToDep.Text.Trim() == "")
            {
                //獲取制單編號資料 COLLATE Chinese_PRC_CI_AS
                string sql = " Select convert(int,b.prod_qty) AS prod_qty,b.next_wp_id From " +
                    remote_db + "jo_bill_mostly a" +
                    " Inner Join  " + remote_db + "jo_bill_goods_details  b On a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver " +
                    " Where a.within_code = '" + "0000" + "' and a.mo_id='" + txtPrdMo.Text.Trim() + "' and b.wp_id='" + txtFdep.Text.Trim() +
                    "' and b.goods_id='" + txtPrdItem.Text.Trim() + "'";
                DataTable dtPrd = clsPublicOfPad.ExecuteSqlReturnDataTable(sql);
                if (dtPrd.Rows.Count > 0)
                {
                    txtToDep.Text = dtPrd.Rows[0]["next_wp_id"].ToString();
                    if (txtConf_flag.Text.Trim() != "Y" && txtFdep.Text.Trim() == "302")//如果是合金部的，完成數量默認取計劃數量
                    {
                        txtQty.Text = dtPrd.Rows[0]["prod_qty"].ToString();
                    }
                    btnSave.Enabled = true;
                }
                else
                {
                    MessageBox.Show("這筆記錄的生產計劃已改變,不能進行操作!");
                    btnSave.Enabled = false;
                }
            }
        }
        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (valid_data() == false)
                return;
            save_process("Y");
        }

        private void mktDate1_TextChanged(object sender, EventArgs e)
        {
            mktDate2.Text = mktDate1.Text;
        }

        private void mktConfTime1_TextChanged(object sender, EventArgs e)
        {
            mktConfTime2.Text = mktConfTime1.Text;
            rdbYesConf.Checked = true;
            dtpStart.Value = Convert.ToDateTime("2014/01/01 " + "00:00");
            dtpEnd.Value = Convert.ToDateTime("2014/01/01 " + "23:59");
        }

        private void textMo1_TextChanged(object sender, EventArgs e)
        {
            mktConfTime1.Text = "";
            mktConfTime2.Text = "";
            mktDate1.Text = "";
            mktDate2.Text = "";
            chkQc.Checked = true;
            rdbAll.Checked = true;
            dtpStart.Value = Convert.ToDateTime("2014/01/01 " + "00:00");
            dtpEnd.Value = Convert.ToDateTime("2014/01/01 " + "23:59");
            if (textMo1.Text == "")
            {
                this.mktDate1.Text = DateTime.Now.ToString("yyyy/MM/dd");
                this.mktDate2.Text = DateTime.Now.ToString("yyyy/MM/dd");
                chkQc.Checked = false;
            }
            if (input_type =="0" && textMo1.Text.Length >= 8)//如果是人手輸入的，才查找
                find_data("");
        }


        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (chk_insert_status()==false)//如果已過數到系統，則不能再修改
                save_process("N");
        }
        private bool chk_insert_status()
        {
            bool sresult = false;
            DataTable dtPrd;
            try
            {
                //獲取制單編號資料 COLLATE Chinese_PRC_CI_AS
                string sql = "";
                sql += " Select a.prd_id " +
                    " From product_records a " +
                    " Where a.prd_id = " + "'" + Convert.ToInt32(txtReq.Text) + "' and a.imput_flag='" + "Y" + "'";
                dtPrd = clsPublicOfPad.ExecuteSqlReturnDataTable(sql);
                if (dtPrd.Rows.Count > 0)
                {
                    sresult = true;
                    MessageBox.Show("這筆記錄已傳入系統,不能進行操作!");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            return sresult;
            //GBW004725
        }

        private void mktConfTime1_MouseDown(object sender, MouseEventArgs e)
        {
            if (mktDate1.Text.Trim() == "/  /")
                mktConfTime1.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void mktDate1_MouseDown(object sender, MouseEventArgs e)
        {
            if (mktConfTime1.Text.Trim() == "/  /")
                mktDate1.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void txtMatItem_Leave(object sender, EventArgs e)
        {
            GetMat_Desc();
        }
        private void GetMat_Desc()
        {

            txtMatDesc.Text = "";
            string strSql = "";
            DataTable dtMatDesc = new DataTable();
            strSql = " SELECT name FROM " + remote_db + "it_goods " +
                           " WHERE within_code='" + "0000" + "' AND id ='" + txtMatItem.Text.Trim() + "' ";
            try
            {
                dtMatDesc = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
                if (dtMatDesc.Rows.Count > 0)
                    txtMatDesc.Text = dtMatDesc.Rows[0]["name"].ToString().Trim();
                else
                    MessageBox.Show("物料編號不存在!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //掃描制單編號，物料編號
                    string goods_id;
                    input_type = "1";//設置為條碼輸入狀態
                    DataTable dtBarCode = clsPublicOfPad.BarCodeToItem(txtBarCode.Text);
                    txtBarCode.Text = "";
                    if (dtBarCode.Rows.Count > 0)
                    {
                        string barcode_type = dtBarCode.Rows[0]["barcode_type"].ToString();
                            if (barcode_type == "2")//從生產計劃中提取的條形碼
                            {
                                textMo1.Text = dtBarCode.Rows[0]["mo_id"].ToString();
                                textDep1.Text = dtBarCode.Rows[0]["wp_id"].ToString();
                                goods_id = dtBarCode.Rows[0]["goods_id"].ToString();
                                find_data(goods_id);
                                if (dgvDetails.Rows.Count == 0)//若在生產記錄中沒有記錄，則從生產計劃中提取
                                {
                                    string id = dtBarCode.Rows[0]["id"].ToString();
                                    int ver = Convert.ToInt32(dtBarCode.Rows[0]["ver"]);
                                    string seq = dtBarCode.Rows[0]["sequence_id"].ToString();
                                    DataTable dtPrdRec = GetMoFromPlan(id, ver, seq);
                                    dgvDetails.DataSource = dtPrdRec;
                                    FillControls();
                                }
                            }
                    }
                    else
                        return;
                    break;
            }
        }

        private void textMo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            input_type = "0";//設置為手動輸入狀態
        }


        private void btnCountQty_Click(object sender, EventArgs e)
        {
            ConvertQtyWeg(0);//計數量
        }
        private void ConvertQtyWeg(int count_type)
        {
            double base_qty = 0;
            if (txtSample_no.Text != "" && txtSample_weg.Text != "" && Convert.ToSingle(txtSample_weg.Text) != 0)
                base_qty = Math.Round(Convert.ToInt32(txtSample_no.Text) / (Convert.ToSingle(txtSample_weg.Text) / 1000), 0);
            if (count_type == 0)//計數量
            {
                txtQty.Text = "";
                if (txtWeg.Text != "")
                {
                    txtQty.Text = Math.Round(Convert.ToSingle(txtWeg.Text) * base_qty, 0).ToString();
                }
            }
            else//計重量
            {
                txtWeg.Text = "";
                if (txtQty.Text != "" && base_qty != 0)
                {
                    txtWeg.Text = Math.Round(Convert.ToSingle(txtQty.Text) / base_qty, 2).ToString();
                }
            }
        }

        private void btnCountWeg_Click(object sender, EventArgs e)
        {
            ConvertQtyWeg(1);//計重量
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (btnConvert.Text == "數量轉換")
            {
                btnConvert.Text = "編輯";
                tabControl1.SelectedIndex = 1;
                txtSample_no.Focus();
            }
            else
            {
                btnConvert.Text = "數量轉換";
                tabControl1.SelectedIndex = 0;
                txtBarCode.Focus();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (btnFind.Text == "查詢(&F)")
            {
                btnFind.Text = "編輯";
                tabControl1.SelectedIndex = 2;
                txtSample_no.Focus();
            }
            else
            {
                btnFind.Text = "查詢(&F)";
                tabControl1.SelectedIndex = 0;
                txtBarCode.Focus();
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            find_data("");
            btnFind.Text = "查詢(&F)";
            tabControl1.SelectedIndex = 0;
            txtBarCode.Focus();
        }

        private void rdgFromJx_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
         }

        private void rdgFromDep_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
        }

        private void btnMutRec_Click(object sender, EventArgs e)
        {
            if (txtConf_flag.Text.Trim() == "")
            {
                MessageBox.Show("這筆記錄未收貨!");
                return;
            }
            txtConf_flag.Text = "";
            txtConf_time.Text = "";
            txtReq.Text = "";
            txtQty.Text = "";
            txtWeg.Text = "";
        }

    }
}
