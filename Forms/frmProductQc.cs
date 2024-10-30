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
using cf_pad.MDL;

namespace cf_pad.Forms
{
    public partial class frmProductQc : Form
    {
        private String strConn = DBUtility.dgcf_pad_connectionString;
        private DataSet ds_rate, ds_size;
        private int mult_lot=-1;
        private string usrid = DBUtility._user_id.ToUpper();
        public frmProductQc()
        {
            InitializeComponent();

            InitControl();
        }

        void InitControl()
        {
            string strSql;
            this.dtpDate1.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.dtpDate2.Text = DateTime.Now.ToString("yyyy/MM/dd");
            //dtpDate1.Text = "2000/01/01";
            //dtpDate2.Text = "2099/12/31";
            dtpQCDate1.Text = "2000/01/01";
            dtpQCDate2.Text = "2099/12/31";
            if (usrid == "QC01" || usrid == "CFIPQC1")
                textDep1.Text = "102";
            else
            {
                if (usrid == "QC02")
                    textDep1.Text = "302";
            }
            Font a = new Font("GB2312", 14);//GB2312为字体名称，1为字体大小dataGridView1.Font = a;
            dgvDetails.Font = a;
            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.ReadOnly = true;

            strSql = "Select * From qc_item_std Where qc_type ='A02' ";//外觀抽樣數
            ds_rate = exce_sql(strSql, "qc_facade_rate");
            strSql = "Select * From qc_item_std Where qc_type ='A03' ";//尺寸抽樣數
            ds_size = exce_sql(strSql, "qc_size_rate");


            textDep1.Focus();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            if (clsValidRule.CheckDateIsEmpty(this.dtpDate1.Text) == false || clsValidRule.CheckDateIsEmpty(this.dtpDate2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.dtpDate1.Text) == false || clsValidRule.CheckDateFormat(this.dtpDate2.Text) == false)
                {
                    MessageBox.Show("生產日期不正確!");
                    this.dtpDate1.Focus();
                    return;
                }
            }
            if (clsValidRule.CheckDateIsEmpty(this.dtpQCDate1.Text) == false || clsValidRule.CheckDateIsEmpty(this.dtpQCDate2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.dtpQCDate1.Text) == false || clsValidRule.CheckDateFormat(this.dtpQCDate2.Text) == false)
                {
                    MessageBox.Show("QC日期不正確!");
                    this.dtpQCDate1.Focus();
                    return;
                }
            }
            if (textDep1.Text == "")
            {
                MessageBox.Show("請輸入查詢部門!");
                this.textDep1.Focus();
                return;
            }
            FindPoQC();
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            SavePoQC();
        }

        private void rdbYesQc_Click(object sender, EventArgs e)
        {
            FindPoQC();
        }

        private void rdbNoQc_Click(object sender, EventArgs e)
        {
            FindPoQC();
        }

        private void rdbAll_Click(object sender, EventArgs e)
        {
            FindPoQC();
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                if (e.RowIndex == -1)
                    return;

                FillControls(e.RowIndex);
                mult_lot = -1;//恢復為單批次記錄狀態
            }
        }

        private void textMo1_TextChanged(object sender, EventArgs e)
        {
            dtpDate1.Text = "2000/01/01";
            dtpDate2.Text = "2099/12/31";
            dtpQCDate1.Text = "2000/01/01";
            dtpQCDate2.Text = "2099/12/31";
            rdbAll.Checked = true;
            //FindPoQC();
        }

        /// <summary>
        /// 根據條件查詢數據
        /// </summary>
        private void FindPoQC()
        {
            string strWhere = String.Empty;
            string strConditonName = String.Empty;
            string work_type = "A02";
            strWhere = " WHERE a.prd_dep >= " + " '' ";

            if (textDep1.Text.Trim() != "")
                strWhere += " AND a.prd_dep =  " + "'" + textDep1.Text.Trim() + "'";
            strWhere += " AND a.prd_date >=  " + "'" + dtpDate1.Text + "'";
            strWhere += " AND a.prd_date <=  " + "'" + dtpDate2.Text + "'";
            //if (rdbAll.Checked == true || rdbYesQc.Checked == true)
            //{
            //    if (string.Compare(dtpQCDate1.Text, "2014/10/01") > 0)
            //        strWhere += " AND b.qc_date >=  " + "'" + dtpQCDate1.Text + "'";
            //    if (dtpQCDate2.Text != "2099/12/31")
            //        strWhere += " AND b.qc_date <=  " + "'" + dtpQCDate2.Text + "'";
            //}
            if (textMo1.Text != "")
            {
                strWhere += " AND a.prd_mo like  " + "'%" + textMo1.Text.Trim() + "%'";
            }
            if (rdbNoQc.Checked == true)//未QC
                strWhere += " AND a.qc_flag= '" + "" + "'";
            if (rdbYesQc.Checked == true)//未QC
                strWhere += " AND a.qc_flag= '" + "Y" + "'";
            if (textDep1.Text == "102")
                work_type = "A02";
            else
            {
                if (textDep1.Text == "302")//如果是合金部的，則要取已選貨的
                    work_type = "A03";
            }
            strWhere += " AND a.prd_work_type = '" + work_type + "'";
            strWhere += " AND a.prd_end_time <> '" + "" + "'";
            this.BindDataGridView(strWhere);

            if (dgvDetails.RowCount > 0)
            {
                FillControls(0);
            }


        }

        private void BindDataGridView(string strWhere)
        {
            string strSql = null;
            DataSet ds;

            if (rdbAll.Checked == true || rdbYesQc.Checked == true)
            {
                strSql = @" Select a.prd_id,a.prd_dep,a.prd_date,b.qc_date,a.prd_mo,a.prd_item,b.seq_no
                                  ,a.prd_qty AS lot_qty,0 AS facade_sample_qty,0 AS facade_std_ac,0 AS facade_std_re,0 AS size_sample_qty
                                  ,0 AS size_std_ac,0 AS size_std_re,a.crusr,CONVERT(varchar(50),a.crtim,20) AS crtim,b.mat_color
                                  ,b.facade_actual_qty,b.size_actual_qty,b.actual_size,b.mat_logo,b.oth_desc
                                  ,b.no_pass_qty,b.do_result,b.qc_no_ok,b.qc_ok 
                             FROM product_records a 
                             LEFT JOIN product_qc_records b on a.prd_id=b.id " + strWhere;
            }
            else
            {
                strSql = " Select a.prd_id,a.prd_dep,a.prd_date," + "'' " + " AS qc_date,a.prd_mo,a.prd_item"+ ",'' " + " AS seq_no";
                strSql += ",a.prd_qty AS lot_qty,0 AS facade_sample_qty,0 AS facade_std_ac,0 AS facade_std_re,0 AS facade_actual_qty";
                strSql += ",0 AS size_sample_qty,0 AS size_std_ac,0 AS size_std_re,0 AS size_actual_qty,a.crusr,CONVERT(varchar(50),a.crtim,20) AS crtim ";
                strSql += ",'' " + " AS actual_size " + ",'' " + " AS mat_logo " + ",'' " + " AS oth_desc " + ",'' " + " AS no_pass_qty ";
                strSql += ",'' " + " AS do_result " + ",'' " + " AS qc_no_ok " + ",'' " + " AS qc_ok " + ",'' " + " AS mat_color ";
                strSql += "FROM product_records a " + strWhere;
            }

            ds = exce_sql(strSql, "tb_prd");
            this.dgvDetails.DataSource = ds.Tables["tb_prd"];
            int cur_qty, min_rate, max_rate;
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                for (int j = 0; j < ds_rate.Tables["qc_facade_rate"].Rows.Count; j++)
                {

                    cur_qty = Convert.ToInt32(dgvDetails.Rows[i].Cells["lot_qty"].Value);
                    min_rate = Convert.ToInt32(ds_rate.Tables["qc_facade_rate"].Rows[j]["qty_min_rate"]);
                    max_rate = Convert.ToInt32(ds_rate.Tables["qc_facade_rate"].Rows[j]["qty_max_rate"]);
                    if (cur_qty - min_rate >= 0 && cur_qty - max_rate < 0)
                    {
                        dgvDetails.Rows[i].Cells["facade_sample_qty"].Value = ds_rate.Tables["qc_facade_rate"].Rows[j]["sample_qty"].ToString();
                        dgvDetails.Rows[i].Cells["facade_std_ac"].Value = ds_rate.Tables["qc_facade_rate"].Rows[j]["std_ac"].ToString();
                        dgvDetails.Rows[i].Cells["facade_std_re"].Value = ds_rate.Tables["qc_facade_rate"].Rows[j]["std_re"].ToString();
                        dgvDetails.Rows[i].Cells["facade_actual_qty"].Value = ds_rate.Tables["qc_facade_rate"].Rows[j]["sample_qty"].ToString();
                    }
                }

                for (int k = 0; k < ds_size.Tables["qc_size_rate"].Rows.Count; k++)
                {

                    cur_qty = Convert.ToInt32(dgvDetails.Rows[i].Cells["lot_qty"].Value);
                    min_rate = Convert.ToInt32(ds_size.Tables["qc_size_rate"].Rows[k]["qty_min_rate"]);
                    max_rate = Convert.ToInt32(ds_size.Tables["qc_size_rate"].Rows[k]["qty_max_rate"]);
                    if (cur_qty - min_rate >= 0 && cur_qty - max_rate < 0)
                    {
                        dgvDetails.Rows[i].Cells["size_sample_qty"].Value = ds_size.Tables["qc_size_rate"].Rows[k]["sample_qty"].ToString();
                        dgvDetails.Rows[i].Cells["size_actual_qty"].Value = ds_size.Tables["qc_size_rate"].Rows[k]["sample_qty"].ToString();
                        dgvDetails.Rows[i].Cells["size_std_ac"].Value = ds_size.Tables["qc_size_rate"].Rows[k]["std_ac"].ToString();
                        dgvDetails.Rows[i].Cells["size_std_re"].Value = ds_size.Tables["qc_size_rate"].Rows[k]["std_re"].ToString();
                    }
                }
            }
        }

        private DataSet exce_sql(string strSql, string tb)
        {
            SqlConnection m_Conn = null;
            DataSet ds = null;
            try
            {
                m_Conn = new SqlConnection(strConn);
                //m_Cmd = new SqlCommand();
                //m_Cmd.Connection = m_Conn;
            }
            catch (Exception er)
            {
                throw er;
            }
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(strSql, m_Conn);
                ds = new DataSet();
                sda.Fill(ds, tb);
            }
            catch (Exception er)
            {
                throw er;
            }
            m_Conn.Close();
            return ds;
        }

        // 保存QC完成的數據
        private void SavePoQC()
        {
            product_qc_records objModel = new product_qc_records();
            if (ValidateCheckResult())
            {
                objModel.id = Convert.ToInt32(txtPrd_id.Text);
                objModel.dep_no = txtDep.Text.Trim();
                objModel.prd_date = txtPrd_date.Text.Trim();
                objModel.qc_date = dteQc_date.Text.Trim();
                objModel.mo_no = txtPrd_mo.Text.Trim();
                objModel.mat_item = txtPrd_item.Text.Trim();
                objModel.mat_color = txtMat_color.Text.Trim();
                objModel.lot_qty = (txtLot_qty.Text != "" ? Convert.ToInt32(txtLot_qty.Text) : 0);
                objModel.facade_actual_qty = (txtFacade_actual_qty.Text != "" ? Convert.ToInt32(txtFacade_actual_qty.Text) : 0);
                objModel.size_actual_qty = (txtSize_actual_qty.Text != "" ? Convert.ToInt32(txtSize_actual_qty.Text) : 0);
                objModel.actual_size = txtActual_size.Text.Trim();
                objModel.mat_logo = txtMat_logo.Text.Trim();
                objModel.oth_desc = txtOth_desc.Text.Trim();
                objModel.no_pass_qty = (txtNo_pass_qty.Text != "" ? Convert.ToInt32(txtNo_pass_qty.Text) : 0);
                objModel.seq_no = "001";
                objModel.qc_ok = "";
                objModel.qc_no_ok = "";
                if (chkQc_ok.Checked == true)
                {
                    objModel.qc_ok = "Y";
                }
                if (chkQc_no_ok.Checked == true)
                {
                    objModel.qc_no_ok = "N";
                }
                objModel.do_result = txtDo_result.Text.ToString();
                objModel.crusr = usrid;
                objModel.crtim = DateTime.Now;
                objModel.amtim = DateTime.Now;
                objModel.amusr = usrid;
                DataTable dtres = new DataTable();
                string strSql1 = "";
                //如果是多批次的記錄，就要找出最大記錄號後加1
                if (mult_lot == 1)
                {
                    strSql1 = @" SELECT Max(seq_no) AS seq_no_max FROM product_qc_records WHERE id = '" + Convert.ToInt32(txtPrd_id.Text) + "'";
                    dtres = clsProductQCRecords.ExecuteSqlReturnDataTable(strSql1);
                    int seq_no_max = 0;
                    seq_no_max = (dtres.Rows[0]["seq_no_max"].ToString() != "" ? Convert.ToInt32(dtres.Rows[0]["seq_no_max"])+1 : 0);
                    objModel.seq_no = seq_no_max.ToString().PadLeft(3, '0'); 
                }
                strSql1 = @" SELECT id FROM product_qc_records WHERE id = '" + Convert.ToInt32(txtPrd_id.Text) + "' AND seq_no = '" + objModel.seq_no + "'";
                int Result = 0;
                dtres = clsProductQCRecords.ExecuteSqlReturnDataTable(strSql1);
                if (dtres.Rows.Count <= 0)
                {
                    Result = clsProductQCRecords.AddProductQCRecords(objModel);
                }
                else
                {
                    Result = clsProductQCRecords.UpdateProductQCRecords(objModel);
                }
                if (Result > 0)
                {
                    MessageBox.Show("保存成功!");
                    mult_lot = -1;//恢復為單批次記錄狀態
                    FindPoQC();
                }
                else
                {
                    MessageBox.Show("保存失敗!");
                }
            }
        }

        /// <summary>
        /// 驗證文本框格式
        /// </summary>
        /// <returns></returns>
        private bool ValidateCheckResult()
        {

            if (chkQc_ok.Checked == true && chkQc_no_ok.Checked == true)
            {
                MessageBox.Show("檢驗結果不能同時選中 OK 或 NG ，請重新選擇QC結果。");
                return false;
            }
            if (chkQc_ok.Checked == false && chkQc_no_ok.Checked == false)
            {
                MessageBox.Show("檢驗結果無效!");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 填充文本框
        /// </summary>
        /// <param name="i"></param>
        private void FillControls(int i)
        {
            string strPrd_item = (dgvDetails.Rows[i].Cells["prd_item"].Value != null ? dgvDetails.Rows[i].Cells["prd_item"].Value.ToString() : "");
            txtMat_logo.Text = (dgvDetails.Rows[i].Cells["Mat_logo"].Value != null ? dgvDetails.Rows[i].Cells["Mat_logo"].Value.ToString() : "");
            txtActual_size.Text = (dgvDetails.Rows[i].Cells["Actual_size"].Value != null ? dgvDetails.Rows[i].Cells["Actual_size"].Value.ToString() : "");

            txtPrd_id.Text = (dgvDetails.Rows[i].Cells["Prd_id"].Value != null ? dgvDetails.Rows[i].Cells["Prd_id"].Value.ToString() : "");
            txtPrd_date.Text = (dgvDetails.Rows[i].Cells["Prd_date"].Value != null ? dgvDetails.Rows[i].Cells["Prd_date"].Value.ToString() : "");
            txtDep.Text = (dgvDetails.Rows[i].Cells["Prd_dep"].Value != null ? dgvDetails.Rows[i].Cells["Prd_dep"].Value.ToString() : "");
            txtPrd_mo.Text = (dgvDetails.Rows[i].Cells["prd_mo"].Value != null ? dgvDetails.Rows[i].Cells["prd_mo"].Value.ToString() : "");
            txtPrd_item.Text = strPrd_item;
            dteQc_date.Text = (dgvDetails.Rows[i].Cells["Qc_date"].Value != null ? dgvDetails.Rows[i].Cells["Qc_date"].Value.ToString() : "");
            txtOth_desc.Text = (dgvDetails.Rows[i].Cells["Oth_desc"].Value != null ? dgvDetails.Rows[i].Cells["Oth_desc"].Value.ToString() : "");
            txtNo_pass_qty.Text = (dgvDetails.Rows[i].Cells["No_pass_qty"].Value != null ? dgvDetails.Rows[i].Cells["No_pass_qty"].Value.ToString() : "");
            txtMat_color.Text = (dgvDetails.Rows[i].Cells["Mat_color"].Value != null ? dgvDetails.Rows[i].Cells["Mat_color"].Value.ToString() : "");
            txtLot_qty.Text = (dgvDetails.Rows[i].Cells["Lot_qty"].Value != null ? dgvDetails.Rows[i].Cells["Lot_qty"].Value.ToString() : "");
            txtDo_result.Text = (dgvDetails.Rows[i].Cells["Do_result"].Value != null ? dgvDetails.Rows[i].Cells["Do_result"].Value.ToString() : "");
            txtFacade_actual_qty.Text = (dgvDetails.Rows[i].Cells["Facade_actual_qty"].Value != null ? dgvDetails.Rows[i].Cells["Facade_actual_qty"].Value.ToString() : "");
            txtSize_actual_qty.Text = (dgvDetails.Rows[i].Cells["Size_actual_qty"].Value != null ? dgvDetails.Rows[i].Cells["Size_actual_qty"].Value.ToString() : "");
            txtSeq_no.Text = (dgvDetails.Rows[i].Cells["seq_no"].Value != null ? dgvDetails.Rows[i].Cells["seq_no"].Value.ToString() : "");
            if (rdbNoQc.Checked == true || rdbAll.Checked == true)
            {
                if (txtActual_size.Text=="")
                    txtActual_size.Text = clsProductQCRecords.GetSize(strPrd_item.Substring(11, 3));
                if(txtMat_logo.Text =="")
                    txtMat_logo.Text = clsProductQCRecords.GetMat_Logo(strPrd_item.Substring(4, 7));
            }

            chkQc_ok.Checked = false;
            chkQc_no_ok.Checked = false;
            if (dgvDetails.Rows[i].Cells["Qc_ok"].Value != null && dgvDetails.Rows[i].Cells["Qc_ok"].Value.ToString() == "Y")
                chkQc_ok.Checked = true;
            if (dgvDetails.Rows[i].Cells["Qc_no_ok"].Value != null && dgvDetails.Rows[i].Cells["Qc_no_ok"].Value.ToString() == "Y")
                chkQc_no_ok.Checked = true;
            if (dteQc_date.Text == "")
                dteQc_date.Text = DateTime.Now.ToString("yyyy/MM/dd");
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

        private void dtpDate1_ValueChanged(object sender, EventArgs e)
        {
            dtpDate2.Text = dtpDate1.Text;
        }

        private void dtpQCDate1_ValueChanged(object sender, EventArgs e)
        {
            dtpQCDate2.Text = dtpQCDate1.Text;
        }

        private void btnMultlot_Click(object sender, EventArgs e)
        {
            mult_lot = 1;
            chkQc_ok.Checked = false;
            chkQc_no_ok.Checked = false;
            dteQc_date.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void chkQc_ok_Click(object sender, EventArgs e)
        {
            chkQc_no_ok.Checked = false;
        }

        private void chkQc_no_ok_Click(object sender, EventArgs e)
        {
            chkQc_ok.Checked = false;
        }

        private void textDep1_MouseDown(object sender, MouseEventArgs e)
        {
            Call_imput();
        }

        private void textMo1_MouseDown(object sender, MouseEventArgs e)
        {
            Call_imput();
        }

        private void txtDo_result_MouseDown(object sender, MouseEventArgs e)
        {
            Call_imput();
        }

        private void txtOth_desc_MouseDown(object sender, MouseEventArgs e)
        {
            Call_imput();
        }

        private void txtNo_pass_qty_MouseDown(object sender, MouseEventArgs e)
        {
            Call_imput();
        }
        private void Call_imput()
        {
            System.Diagnostics.Process.Start("TabTip.exe"); 
        }
        //private void mktDate1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (mktDate1.Text.Trim() == "/  /")
        //    {
        //        this.mktDate1.Text = DateTime.Now.ToString("yyyy/MM/dd");
        //        this.mktDate2.Text = DateTime.Now.ToString("yyyy/MM/dd");
        //    }
        //}



    }
}
