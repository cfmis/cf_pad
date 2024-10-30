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
using DevExpress.XtraEditors.Repository;

namespace cf_pad.Forms
{
    public partial class frmTransferConfQty : Form
    {
        public string _userid = DBUtility._user_id.ToUpper();
        public static DataTable dtTransferMostly = new DataTable();
        public static DataTable dtTransferDetails = new DataTable();
        public static string query_status = "Y";
        public static string count_status = "N";//值改變時是否重新計算
        public frmTransferConfQty()
        {
            InitializeComponent();
        }

        private void frmTransferRecords_Load(object sender, EventArgs e)
        {
            this.gvDetails.BestFitColumns();

            txtIn_dept.Text = "105";
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
            txtCon_date.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QueryMostly(int select_type, string In_dept, string Out_dept, string mo_id, string doc, string seq, string item)
        {
            if (txtIn_dept.Text.Trim() == "")
            {
                MessageBox.Show("收貨部門不能為空!");
                return;
            }
            if (rdbByMo.Checked == true && txtMo_id.Text.Trim() == "")
            {
                MessageBox.Show("制單編號不能為空!");
                return;
            }
            if (rdbById.Checked == true && txtTransfer_id.Text.Trim() == "")
            {
                MessageBox.Show("移交單號不能為空!");
                return;
            }

            string strCon_date_from = "";
            string strCon_date_to = "";
            if (txtCon_date.Text.Replace(" ", "") != "//")
            {
                strCon_date_from = txtCon_date.Text;
                strCon_date_to = Convert.ToDateTime(strCon_date_from).AddDays(1).ToString("yyyy/MM/dd");
            }
            dtTransferDetails = clsPrdTransfer.GetTransferDetails(select_type, In_dept, Out_dept, mo_id, doc, seq, item, strCon_date_from, strCon_date_to, "");
            dtTransferDetails.Columns.Add("check", System.Type.GetType("System.Boolean"));
            gridControl1.DataSource = dtTransferDetails;
            clearTextBox();//清空文本框內容
            count_status = "Y";
            //BindColumnCheckBox();//綁定復選框
            // fill_data();
        }

        private void txtMo_id_TextChanged(object sender, EventArgs e)
        {
            if (txtMo_id.Text.Length >= 9 && query_status == "Y")
                queryByMo(3);//1--在原始移交單中查詢
        }

        private void btnConfigMo_Click(object sender, EventArgs e)
        {
            if (valid_data() == false)
            {
                txtBarCode.Focus();
                return;
            }
            int result = 0;
            jo_materiel_con_details objDetails = new jo_materiel_con_details();
            objDetails.crusr = DBUtility._user_id;
            objDetails.crtim = DateTime.Now;
            objDetails.conf_flag = "Y";
            for (int RowIndex = 0; RowIndex < gvDetails.RowCount; RowIndex++)
            {
                if (gvDetails.GetDataRow(RowIndex)["check"].ToString() == "True")
                {
                    objDetails.mo_id = gvDetails.GetDataRow(RowIndex)["mo_id"].ToString().Trim();
                    objDetails.goods_id = gvDetails.GetDataRow(RowIndex)["goods_id"].ToString().Trim();
                    objDetails.id = gvDetails.GetDataRow(RowIndex)["id"].ToString().Trim();
                    objDetails.lot_no = gvDetails.GetDataRow(RowIndex)["lot_no"].ToString().Trim();
                    objDetails.package_num = clsUtility.FormatNullableFloat(gvDetails.GetDataRow(RowIndex)["Package_num"]);
                    objDetails.con_qty = clsUtility.FormatNullableFloat(gvDetails.GetDataRow(RowIndex)["con_qty"]);
                    objDetails.sec_qty = clsUtility.FormatNullableFloat(gvDetails.GetDataRow(RowIndex)["sec_qty"]);
                    objDetails.actual_qty = Convert.ToSingle(gvDetails.GetDataRow(RowIndex)["actual_qty"]);
                    objDetails.actual_weg = Math.Round(Convert.ToSingle(gvDetails.GetDataRow(RowIndex)["actual_weg"]), 2);
                    objDetails.actual_pack = Convert.ToInt32(gvDetails.GetDataRow(RowIndex)["actual_pack"]);
                    objDetails.sequence_id = gvDetails.GetDataRow(RowIndex)["sequence_id"].ToString().Trim();
                    objDetails.sample_no = (txtSample_no.Text.Trim() != "" ? Convert.ToSingle(txtSample_no.Text) : 0);
                    objDetails.sample_weg = (txtSample_weg.Text.Trim() != "" ? Math.Round(Convert.ToSingle(txtSample_weg.Text), 2) : 0);
                    if (txtTransfer_id.Text.Trim() == objDetails.id && txtSeq_id.Text.Trim() == objDetails.sequence_id)//同是否選中的記錄對比
                    {
                        objDetails.actual_qty = Convert.ToSingle(txtActual_qty.Text);
                        objDetails.actual_weg = Math.Round(Convert.ToSingle(txtActual_weg.Text), 2);
                    }
                    result = clsPrdTransfer.SaveTransferDetails(objDetails);//插入明細表
                    if (result > 0)
                    {
                        //MessageBox.Show("儲存明細表成功!");
                        //填充主表實體類   
                        result = clsPrdTransfer.SaveTransferMostly(2, objDetails.id, txtIn_dept.Text.Trim(), txtOut_dept.Text.Trim(), _userid);
                        //if (result > 0)
                        //{
                        //    MessageBox.Show("此移交單已簽收完成!");
                        //}
                    }
                }
            }
            if (result > 0)
                MessageBox.Show("已確認成功!");
            //if (rdbByMo.Checked == true || rdbNoConfQty.Checked == true)
            //    queryByMo(2);//2--在已收貨的移交單中查詢
            //if (rdbById.Checked == true)
            //    queryById(1);//1--在原始移交單中查詢
            txtBarCode.Focus();
        }
        private bool valid_data()
        {
            if (txtActual_qty.Text == "")
            {
                MessageBox.Show("實際數量不能為空!");
                return false;
            }
            if (txtActual_weg.Text == "")
            {
                MessageBox.Show("實際重量不能為空!");
                return false;
            }
            if (txtActual_pack.Text == "")
            {
                MessageBox.Show("實際包數不能為空!");
                return false;
            }
            return true;
        }

        private void rdbByMo_Click(object sender, EventArgs e)
        {
            queryByMo(3);//1--在原始移交單中查詢
        }

        private void rdbById_Click(object sender, EventArgs e)
        {
            queryById(3);//1--在原始移交單中查詢
        }

        private void txtMo_id_MouseDown(object sender, MouseEventArgs e)
        {
            query_status = "Y";
            clsUtility.Call_imput();
        }

        private void txtTransfer_id_TextChanged(object sender, EventArgs e)
        {
            if (txtMo_id.Text.Length >= 12 && query_status == "Y")
                queryById(3);//1--在原始移交單中查詢
        }
        private void queryById(int select_type)
        {
            QueryMostly(select_type, txtIn_dept.Text.Trim(), "", "", txtTransfer_id.Text.Trim(), "", "");

        }
        private void queryByMo(int select_type)
        {
            QueryMostly(select_type, txtIn_dept.Text.Trim(), "", txtMo_id.Text.Trim(), "", "", "");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int result = 0;
            result = clsPrdTransfer.DelTransferDetails(2, txtTransfer_id.Text.Trim(), txtSeq_id.Text.Trim());
            if (result > 0)
            {
                if (rdbByMo.Checked == true)
                    queryByMo(3);//2--在已收貨的移交單中查詢
                if (rdbById.Checked == true)
                    queryById(3);//1--在原始移交單中查詢
            }
            txtBarCode.Focus();
        }

        private void txtTransfer_id_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtTransfer_id.Text.Trim() == "" && txtOut_dept.Text.Trim() != "" && txtIn_dept.Text.Trim() != "")
            {
                txtTransfer_id.Text = "T" + txtOut_dept.Text.Trim() + txtIn_dept.Text.Trim();
                txtTransfer_id.SelectionStart = txtTransfer_id.Text.Length;
            }
            clsUtility.Call_imput();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtCon_date.Text.Replace(" ", "") == "//")
            {
                MessageBox.Show("日期不能為空!");
                return;
            }
            QueryMostly(3, txtIn_dept.Text.Trim(), "", "", "", "", "");
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //掃描制單編號，物料編號
                    string goods_id;
                    string out_dep;
                    DataTable dtBarCode = clsPublicOfPad.BarCodeToItem(txtBarCode.Text);
                    txtBarCode.Text = "";
                    if (dtBarCode.Rows.Count > 0)
                    {
                        string barcode_type = dtBarCode.Rows[0]["barcode_type"].ToString();
                        if (barcode_type == "2")//從生產計劃中提取的條形碼
                        {
                            txtIn_dept.Text = dtBarCode.Rows[0]["next_wp_id"].ToString();
                            txtMo_id.Text = dtBarCode.Rows[0]["mo_id"].ToString();
                            out_dep = dtBarCode.Rows[0]["wp_id"].ToString();
                            goods_id = dtBarCode.Rows[0]["goods_id"].ToString();
                            QueryMostly(3, txtIn_dept.Text, out_dep, txtMo_id.Text, "", "", goods_id);
                        }
                    }
                    else
                        return;

                    break;
            }
        }

        private void txtSample_num_TextChanged(object sender, EventArgs e)
        {
            convert_kg_pcs();
            if (count_status == "Y")
                aftAdjustQty();//校正後數量aftAdjustQty();//校正後數量
        }
        private void convert_kg_pcs()
        {
            txtCountQty.Text = "";
            if (txtSample_no.Text != "" && txtSample_weg.Text != "" && Convert.ToSingle(txtSample_weg.Text) != 0 && txtCountWeg.Text != "")
                txtCountQty.Text = Math.Round((Convert.ToInt32(txtSample_no.Text) / (Convert.ToSingle(txtSample_weg.Text))
                    * (Convert.ToSingle(txtCountWeg.Text) * 1000)), 0).ToString();
            //aftAdjustQty();//校正後數量
        }

        private void txtSample_weg_TextChanged(object sender, EventArgs e)
        {
            convert_kg_pcs();
            if (count_status == "Y")
                aftAdjustQty();//校正後數量aftAdjustQty();//校正後數量
        }

        private void btnGetQty_Click(object sender, EventArgs e)
        {
            //BindColumnCheckBox();

            //BindColumnCheckBox();//綁定復選框
            //txtActual_qty.Text = txtCountQty.Text;
            txtActual_qty.Text = txtAdjQty.Text;
            txtActual_weg.Text = txtAdjWeg.Text;
        }

        private void txtActual_weg_TextChanged(object sender, EventArgs e)
        {
            convert_kg_pcs();
        }

        private void rdbNoConfQty_Click(object sender, EventArgs e)
        {
            QueryMostly(3, txtIn_dept.Text.Trim(), "", "", "", "", "");
        }

        private void txtIn_dept_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtCon_date_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtOut_dept_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtSample_no_MouseDown(object sender, MouseEventArgs e)
        {
            //count_status = "Y";
            clsUtility.Call_imput();
        }

        private void txtSample_weg_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtCountQty_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtActual_qty_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtActual_weg_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtActual_pack_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void BindColumnCheckBox()
        {
            //CheckBox cbx_Build;
            //Rectangle rect0 = dgvDetails.GetCellDisplayRectangle(0, -1, true);
            //cbx_Build = new CheckBox();
            //cbx_Build.BackColor = Color.Transparent;
            //cbx_Build.Padding = new Padding(0);
            //cbx_Build.Margin = new Padding(0);
            //cbx_Build.Size = new System.Drawing.Size(55, 125);
            //cbx_Build.Parent = dgvDetails;
            //cbx_Build.Location  = new Point(rect0.X + 10, rect0.Y + 3);
            //cbx_Build.AutoSize = false;
            //cbx_Build.TabIndex = 0;
            ////cbx_Build.CheckedChanged += new EventHandler(cbx_Build_CheckedChanged);
            //for (int i = 0; i < dgvDetails.Rows.Count; i++)
            //{
            //    Rectangle rect = dgvDetails.GetCellDisplayRectangle(0, i, true);
            //    cbx_Build = new CheckBox();
            //    cbx_Build.BackColor = Color.Transparent;
            //    cbx_Build.Padding = new Padding(0);
            //    cbx_Build.Margin = new Padding(0);
            //    cbx_Build.Size = new System.Drawing.Size(108, 120);
            //    cbx_Build.Parent = dgvDetails;
            //    cbx_Build.Location = new Point(rect.X + 10, rect.Y + 5);
            //    cbx_Build.AutoSize = false;
            //    cbx_Build.TabIndex = i + 1;
            //    //cbx_Build.CheckedChanged += new EventHandler(cbx_Build_CheckedChanged);
            //}
        }

        private void gvDetails_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            query_status = "N";
            count_status = "N";
            int RowIndex = gvDetails.FocusedRowHandle;
            //if (gvDetails.GetDataRow(RowIndex)["check"].ToString() == "True")
            //{
            txtOut_dept.Text = gvDetails.GetRowCellValue(RowIndex, "out_dept").ToString();
            txtCon_date.Text = gvDetails.GetRowCellValue(RowIndex, "con_date").ToString();
            txtTransfer_id.Text = gvDetails.GetRowCellValue(RowIndex, "id").ToString();
            txtSeq_id.Text = gvDetails.GetRowCellValue(RowIndex, "sequence_id").ToString();
            txtMo_id.Text = gvDetails.GetRowCellValue(RowIndex, "mo_id").ToString();
            txtGoods_name.Text = gvDetails.GetRowCellValue(RowIndex, "goods_name").ToString();
            txtActual_qty.Text = gvDetails.GetRowCellValue(RowIndex, "actual_qty").ToString();
            txtActual_weg.Text = gvDetails.GetRowCellValue(RowIndex, "actual_weg").ToString();
            txtLot_no.Text = gvDetails.GetRowCellValue(RowIndex, "lot_no").ToString();
            txtCrusr.Text = gvDetails.GetRowCellValue(RowIndex, "crusr").ToString();
            txtCrtim.Text = gvDetails.GetRowCellValue(RowIndex, "crtim").ToString();
            txtImput_flag.Text = gvDetails.GetRowCellValue(RowIndex, "imput_flag").ToString();
            txtImput_time.Text = gvDetails.GetRowCellValue(RowIndex, "imput_time").ToString();
            txtActual_pack.Text = gvDetails.GetRowCellValue(RowIndex, "actual_pack").ToString();
            //txtSample_no.Text = gvDetails.GetRowCellValue(RowIndex, "sample_no").ToString();
            //txtSample_weg.Text = gvDetails.GetRowCellValue(RowIndex, "sample_weg").ToString();
            if (txtSample_no.Text.Trim() == "0")
                txtSample_no.Text = "";
            if (txtSample_weg.Text.Trim() == "0")
                txtSample_weg.Text = "";
            txtId_state.Text = gvDetails.GetRowCellValue(RowIndex, "id_state").ToString(); //= "Y"移交單已完成收貨
            txtAdjQty.Text = txtActual_qty.Text;
            txtAdjWeg.Text = txtActual_weg.Text;
            aftAdjustQty();//校正後數量
            //}
        }

        /// <summary>
        /// checkbox click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gcCheck_Click(object sender, EventArgs e)
        {
            int RowIndex = gvDetails.FocusedRowHandle;

            if (RowIndex >= 0)
            {
                //首先获取到多选列的值
                string merge_id = gvDetails.GetRowCellValue(RowIndex, "merge_id").ToString();
                string val = gvDetails.GetDataRow(RowIndex)["check"].ToString();
                if (val == "True")
                {
                    if (merge_id != "")
                    {
                        for (int i = 0; i < gvDetails.RowCount; i++)
                        {
                            if (merge_id == gvDetails.GetRowCellValue(i, "merge_id").ToString())
                            {
                                gvDetails.GetDataRow(i)["check"] = false;  //如果是已选中就设置未选中的值為 false
                            }
                        }

                        txtSumQty.Text = "";
                        txtSumWeg.Text = "";
                    }
                    else
                    {
                        gvDetails.GetDataRow(RowIndex)["check"] = false;

                        if (txtSumQty.Text.Trim() != "")
                        {
                            txtSumQty.Text = (Convert.ToDecimal(txtSumQty.Text) - Convert.ToDecimal(gvDetails.GetRowCellValue(RowIndex, "actual_qty"))).ToString();
                        }

                        if (txtSumWeg.Text.Trim() != "")
                        {
                            txtSumWeg.Text = (Convert.ToDecimal(txtSumWeg.Text) - Convert.ToDecimal(gvDetails.GetRowCellValue(RowIndex, "actual_weg"))).ToString();
                        }
                    }
                }
                else
                {
                    if (merge_id != "")
                    {
                        decimal SumQty = 0;
                        decimal SumWeg = 0;

                        for (int i = 0; i < gvDetails.RowCount; i++)
                        {
                            if (merge_id == gvDetails.GetRowCellValue(i, "merge_id").ToString())
                            {
                                gvDetails.GetDataRow(i)["check"] = true;   //如果是未选中就设置选中的值為 true

                                SumQty += Convert.ToDecimal(gvDetails.GetRowCellValue(i, "actual_qty"));
                                SumWeg += Convert.ToDecimal(gvDetails.GetRowCellValue(i, "actual_weg"));
                            }
                            else
                            {
                                gvDetails.GetDataRow(i)["check"] = false;
                            }
                        }

                        txtSumQty.Text = SumQty.ToString();
                        txtSumWeg.Text = SumWeg.ToString();
                    }
                    else
                    {
                        //如果选中非併單數據就设置已选中併單的數據值為 false
                        for (int i = 0; i < gvDetails.RowCount; i++)
                        {
                            if (gvDetails.GetRowCellValue(i, "merge_id").ToString() != "")
                            {
                                gvDetails.GetDataRow(i)["check"] = false;
                            }
                        }

                        gvDetails.GetDataRow(RowIndex)["check"] = true;
                        if (txtSumQty.Text.Trim() != "")
                        {
                            txtSumQty.Text = (Convert.ToDecimal(txtSumQty.Text) + Convert.ToDecimal(gvDetails.GetRowCellValue(RowIndex, "actual_qty"))).ToString();
                        }
                        else
                        {
                            txtSumQty.Text = gvDetails.GetRowCellValue(RowIndex, "actual_qty").ToString();
                        }

                        if (txtSumWeg.Text.Trim() != "")
                        {
                            txtSumWeg.Text = (Convert.ToDecimal(txtSumWeg.Text) + Convert.ToDecimal(gvDetails.GetRowCellValue(RowIndex, "actual_weg"))).ToString();
                        }
                        else
                        {
                            txtSumWeg.Text = gvDetails.GetRowCellValue(RowIndex, "actual_weg").ToString();
                        }
                    }
                }

                if (merge_id != "")
                {
                    DataRow[] dr = dtTransferDetails.Select("merge_id= '" + merge_id + "'");
                    txtCountWeg.Text = dr[0]["total_weg"].ToString();
                }
                else
                {
                    txtCountWeg.Text = txtSumWeg.Text;
                }

                convert_kg_pcs();
                aftAdjustQty();//校正後數量
            }
        }

        private void txtActual_qty_TextChanged(object sender, EventArgs e)
        {
            //aftAdjustQty();//校正後數量
        }
        private void aftAdjustQty()
        {
            if (gvDetails.RowCount > 0)
            {
                if (gvDetails.GetDataRow(gvDetails.FocusedRowHandle)["check"].ToString() == "True")
                {
                    if (txtActual_qty.Text != "" && txtSumQty.Text != "" && txtCountQty.Text != "")
                        txtAdjQty.Text = (Convert.ToInt32(txtActual_qty.Text) - (Convert.ToInt32(txtSumQty.Text) - Convert.ToInt32(txtCountQty.Text))).ToString();
                    if (txtActual_weg.Text != "" && txtSumWeg.Text != "" && txtCountWeg.Text != "")
                        txtAdjWeg.Text = (Convert.ToSingle(txtActual_weg.Text) + (Convert.ToSingle(txtCountWeg.Text) - Convert.ToSingle(txtSumWeg.Text))).ToString();
                }
            }
        }

        private void clearTextBox()
        {
            txtSample_no.Text = "";
            txtSample_weg.Text = "";
            txtCountQty.Text = "";
            txtCountWeg.Text = "";
            txtSumQty.Text = "";
            txtSumWeg.Text = "";
            txtSumWeg.Text = "";
        }

        private void gvDetails_MouseLeave(object sender, EventArgs e)
        {
            count_status = "Y";
        }

        private void txtSumWeg_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCountWeg_TextChanged(object sender, EventArgs e)
        {
            convert_kg_pcs();
            if (count_status == "Y")
                aftAdjustQty();//校正後數量aftAdjustQty();//校正後數量
        }

        private void btnIsConf_Click(object sender, EventArgs e)
        {
            if (txtCon_date.Text.Replace(" ", "") == "//")
            {
                MessageBox.Show("日期不能為空!");
                return;
            }
            QueryMostly(4, txtIn_dept.Text.Trim(), "", "", "", "", "");
        }

        private void gvDetails_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {

        }

    }
}
