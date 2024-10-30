using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf_pad.CLS;
using RUI.PC;
using cf_pad.MDL;

namespace cf_pad.Forms
{
    public partial class frmPrdTransfer : Form
    {
        public static DataTable dtTransferMostly = new DataTable();
        public static DataTable dtTransferDetails = new DataTable();

        public static jo_materiel_con_mostly objMostly = new jo_materiel_con_mostly();
        public string _userid = DBUtility._user_id.ToUpper();
        public frmPrdTransfer()
        {
            InitializeComponent();
        }

        private void frmPrdTransfer_Load(object sender, EventArgs e)
        {
            mktReceived_date.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dgvTransfer.AutoGenerateColumns = false;

            Font a = new Font("GB2312", 14);//GB2312为字体名称，1为字体大小dataGridView1.Font = a;
            dgvTransfer.Font = a;

            if (_userid.Substring(0, 3) == "BUT")
                txtIn_dept.Text = "102";
            else
            {
                if (_userid.Substring(0, 3) == "ALY")
                    txtIn_dept.Text = "302";
                else
                {
                    if (_userid.Substring(0, 3) == "BLK")
                        txtIn_dept.Text = "105";
                    else
                    {
                        if (_userid.Substring(0, 3) == "BUK")
                            txtIn_dept.Text = "202";
                        else
                        {
                        }
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            txtTransfer_id.Text = "";
            Cursor.Current = Cursors.WaitCursor;  //光標等待
            QueryMostly();
            Cursor.Current = Cursors.Default;

            if (dtTransferMostly.Rows.Count > 0)
            {
                frmQueryTransfer frmQT = new frmQueryTransfer();
                if (frmQT.ShowDialog() == DialogResult.OK)
                {
                    dgvTransfer.DataSource = dtTransferDetails;
                    dgvTransfer.Refresh();

                    txtIn_dept.Text = objMostly.in_dept;
                    txtOut_dept.Text = objMostly.out_dept;
                    txtTransfer_id.Text = objMostly.id;
                    mktReceived_date.Text = objMostly.con_date.ToString("yyyy/MM/dd");
                }
            }
            else
            {
                MessageBox.Show("沒有查到相關數據，請重新輸入條件后查詢。");
                txtTransfer_id.Focus();
                //ClearValue();
            }
        }

        private void btnQueryByTrans_id_Click(object sender, EventArgs e)
        {
            if (txtTransfer_id.Text.Trim() == "")
            {
                MessageBox.Show("請輸入移交單號，再查詢。");
                txtTransfer_id.Focus();
                return;
            }

            Cursor.Current = Cursors.WaitCursor;  //光標等待
            QueryMostly();
            if (dtTransferMostly.Rows.Count > 0)
            {
                dtTransferDetails = clsPrdTransfer.GetTransferDetails(txtTransfer_id.Text.Trim());  //查詢明細表信息
                if (dtTransferDetails.Rows.Count > 0)
                {
                    dgvTransfer.DataSource = dtTransferDetails;
                    dgvTransfer.Refresh();
                }
                Cursor.Current = Cursors.Default;

                //填充主表實體類   
                objMostly.id = dtTransferMostly.Rows[0]["id"].ToString();
                objMostly.in_dept = dtTransferMostly.Rows[0]["in_dept"].ToString();
                objMostly.out_dept = dtTransferMostly.Rows[0]["out_dept"].ToString();
                objMostly.state = dtTransferMostly.Rows[0]["state"].ToString();
                objMostly.stock_type = dtTransferMostly.Rows[0]["stock_type"].ToString();
                objMostly.con_date = clsUtility.FormatNullableDateTime(dtTransferMostly.Rows[0]["con_date"]);
                objMostly.crusr = _userid;
                objMostly.crtim = DateTime.Now;

                txtIn_dept.Text = objMostly.in_dept;
                txtOut_dept.Text = objMostly.out_dept;
                txtTransfer_id.Text = objMostly.id;
                mktReceived_date.Text = objMostly.con_date.ToString("yyyy/MM/dd");
            }
            else
            {
                MessageBox.Show("沒有查到相關數據，請重新輸入條件后查詢。");
                txtTransfer_id.Focus();
                // ClearValue();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvTransfer.RowCount > 0)
            {
                List<jo_materiel_con_details> DetailList = new List<jo_materiel_con_details>();
                for (int i = 0; i < dgvTransfer.Rows.Count; i++)
                {
                    jo_materiel_con_details objDetails = new jo_materiel_con_details();
                    objDetails.mo_id = dgvTransfer.Rows[i].Cells["colmo_id"].Value.ToString();
                    objDetails.goods_id = dgvTransfer.Rows[i].Cells["colgoods_id"].Value.ToString();
                    objDetails.id = dgvTransfer.Rows[i].Cells["coltrans_id"].Value.ToString();
                    objDetails.lot_no = dgvTransfer.Rows[i].Cells["colbatch"].Value.ToString();
                    objDetails.package_num = clsUtility.FormatNullableFloat(dgvTransfer.Rows[i].Cells["colpackage_num"].Value);
                    objDetails.con_qty = clsUtility.FormatNullableFloat(dgvTransfer.Rows[i].Cells["colQty"].Value);
                    objDetails.sec_qty = clsUtility.FormatNullableFloat(dgvTransfer.Rows[i].Cells["colweight"].Value);
                    objDetails.actual_qty = clsUtility.FormatNullableFloat(dgvTransfer.Rows[i].Cells["colActual_qty"].Value);
                    objDetails.actual_weg = clsUtility.FormatNullableFloat(dgvTransfer.Rows[i].Cells["colActual_weg"].Value);
                    objDetails.actual_pack = clsUtility.FormatNullableFloat(dgvTransfer.Rows[i].Cells["colActual_pack"].Value);
                    objDetails.sequence_id = dgvTransfer.Rows[i].Cells["colseq_no"].Value.ToString();
                    objDetails.crusr = DBUtility._user_id;
                    objDetails.crtim = DateTime.Now;
                    DetailList.Add(objDetails);

                }

                if (DetailList.Count > 0)
                {
                    objMostly.lsDetails = DetailList; //將移交單明細集合賦值給主表類的明細

                    int Result = clsPrdTransfer.AddTransferInfo(objMostly);
                    if (Result > 0)
                    {
                        MessageBox.Show("保存成功！");
                    }
                    else
                    {
                        MessageBox.Show("保存失敗！");
                    }
                }
            }
        }



        private void dgvTransfer_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
              e.RowBounds.Location.Y,
              dgvTransfer.RowHeadersWidth - 4,
              e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvTransfer.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvTransfer.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void txtReceived_dep_TextChanged(object sender, EventArgs e)
        {
            bing_doc_id();
        }

        private void cmbOut_dept_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbIn_dept_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void txtRecId_TextChanged(object sender, EventArgs e)
        {
            bing_doc_id();
        }

        private void rdbDeliver_Click(object sender, EventArgs e)
        {
            bing_doc_id();
        }

        private void rdbReturn_Click(object sender, EventArgs e)
        {
            bing_doc_id();
        }

        private void bing_doc_id()
        {
            string doc_type = "T";
            string doc_seq = "";
            if (txtRecId.Text.Trim() != "")
                doc_seq = txtRecId.Text.PadLeft(5, '0');

            if (rdbReturn.Checked == true)
                doc_type = "C";

            txtTransfer_id.Text = doc_type + txtOut_dept.Text.Trim() + txtIn_dept.Text.Trim() + doc_seq;
        }

        /// <summary>
        /// 查詢移交單主表信息
        /// </summary>
        private void QueryMostly()
        {
            int Qtype = 0;
            if (rdbNotChecked.Checked == true)  //未收貨
            {
                Qtype = 0;
            }
            if (rdbChecked.Checked == true)    //收貨
            {
                Qtype = 1;
            }
            if (rdbAll.Checked == true)       //全部
            {
                Qtype = 2;
            }
            string strCon_date_from = "";
            string strCon_date_to = "";
            if (mktReceived_date.Text.Replace(" ", "") != "//")
            {
                strCon_date_from = mktReceived_date.Text;
                strCon_date_to = Convert.ToDateTime(strCon_date_from).AddDays(1).ToString("yyyy/MM/dd");
            }
            string strIn_dpet = txtIn_dept.Text.Trim();
            string strOut_dept = txtOut_dept.Text.Trim();
            string strTrans_id = txtTransfer_id.Text.Trim();
            string strMo_id = txtMo_id.Text.Trim();

            dtTransferMostly = clsPrdTransfer.GetTransferMostly(strTrans_id, strIn_dpet, strOut_dept, strCon_date_from, strCon_date_to, Qtype);
        }

        /// <summary>
        /// 驗證輸入格式是否正確
        /// </summary>
        /// <param name="Actual_qty">實際數量</param>
        /// <param name="Actual_weg">實際重量</param>
        /// <param name="Actual_pack">實際包數</param>
        /// <returns></returns>
        private bool IsValueTypeTrue(string Actual_qty, string Actual_weg, string Actual_pack)
        {
            if (Actual_qty != "0")
            {
                if (!Verify.StringValidating(Actual_qty, Verify.enumValidatingType.PositiveNumber))
                {
                    MessageBox.Show("你輸入的實際數量格式不正確，請重新輸入。");
                    return false;
                }
            }

            if (Actual_weg != "0")
            {
                if (!Verify.StringValidating(Actual_weg, Verify.enumValidatingType.PositiveNumber))
                {
                    MessageBox.Show("你輸入的實際重量格式不正確，請重新輸入。");
                    return false;
                }
            }

            if (Actual_pack != "0")
            {
                if (!Verify.StringValidating(Actual_pack, Verify.enumValidatingType.PositiveNumber))
                {
                    MessageBox.Show("你輸入的實際包數格式不正確，請重新輸入。");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 清除值 
        /// </summary>
        private void ClearValue()
        {
            txtOut_dept.Text = "";
            txtTransfer_id.Text = "";
            mktReceived_date.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dgvTransfer.DataSource = null;
            dgvTransfer.Refresh();
        }

        private void txtIn_dept_TextChanged(object sender, EventArgs e)
        {
            bing_doc_id();
        }

        private void txtOut_dept_TextChanged(object sender, EventArgs e)
        {
            bing_doc_id();
        }


    }
}
