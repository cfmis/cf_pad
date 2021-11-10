using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using cf_pad.CLS;
using RUI.PC;
using cf_pad.MDL;
using cf_pad.Reports;
using DevExpress.XtraReports.UI;

namespace cf_pad.Forms
{
    public partial class frmTransferRecords : Form
    {
        DataTable dtReport = new DataTable();
        public string _userid = DBUtility._user_id.ToUpper();
        public static DataTable dtTransferDetails = new DataTable();
        public static DataTable dtTemp = new DataTable();
        public static DataTable dtBarCode = new DataTable();
        public static string query_status = "Y";
        public static string remote_db = DBUtility.remote_db;
        public string strbarcode;

        public frmTransferRecords()
        {
            InitializeComponent();
        }

        private void frmTransferRecords_Load(object sender, EventArgs e)
        {
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
                            if (_userid.Substring(0, 3) == "STB")
                                txtIn_dept.Text = "806";
                            else
                            {
                                if (_userid.Substring(0, 3) == "STA")
                                    txtIn_dept.Text = "805";
                                else
                                {
                                    if (_userid.Substring(0, 3) == "STC")
                                        txtIn_dept.Text = "809";
                                    else
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (txtIn_dept.Text == "105" || txtIn_dept.Text == "510")
                chkIsRec.Checked = true;
            setTextVisible();
            
            CreatPrintTb();//建立打印的表
        }
        //建立打印的表
        private void CreatPrintTb()
        {
            dtReport.Columns.Add("id", typeof(string));
            dtReport.Columns.Add("con_date", typeof(string));
            dtReport.Columns.Add("out_dept", typeof(string));
            dtReport.Columns.Add("out_dept_name", typeof(string));
            dtReport.Columns.Add("in_dept", typeof(string));
            dtReport.Columns.Add("in_dept_name", typeof(string));
            dtReport.Columns.Add("mo_id", typeof(string));
            dtReport.Columns.Add("goods_id", typeof(string));
            dtReport.Columns.Add("goods_name", typeof(string));
            dtReport.Columns.Add("con_qty", typeof(decimal));
            dtReport.Columns.Add("sec_qty", typeof(decimal));
            dtReport.Columns.Add("barcode_id", typeof(string));
            dtReport.Columns.Add("sequence_id", typeof(string));
            dtReport.Columns.Add("picture_name", typeof(string));
            dtReport.Columns.Add("do_color", typeof(string));
            dtReport.Columns.Add("package_num", typeof(string));
            dtReport.Columns.Add("lot_no", typeof(string));
            dtReport.Columns.Add("seq_id_flag", typeof(string));
            dtReport.Columns.Add("rec_flag", typeof(string));
            dtReport.Columns.Add("vendor_id", typeof(string));
            dtReport.Columns.Add("name_vendor", typeof(string));
            dtReport.Columns.Add("name_clr", typeof(string));
            dtReport.Columns.Add("production_remark", typeof(string));
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void find_data(int s_type)
        {
            int select_type;
            select_type = 1;
            string tdep, fdep;
            string mo_id, doc, seq, item, date1, date2, merge_id;
            tdep = "";
            fdep = "";
            mo_id = "";
            doc = "";
            seq = "";
            item = "";
            date1 = "";
            date2 = "";
            merge_id = "";
            if (s_type == 3 || s_type == 5 || s_type == 6)//按制單編號查詢/移交單日期/
            {
                if (txtIn_dept.Text.Trim() == "")
                {
                    MessageBox.Show("收貨部門不能為空!");
                    return;
                }
            }
            if (s_type == 3)//按制單編號查詢
            {
                if (txtFindMo.Text.Trim() == "")
                {
                    MessageBox.Show("制單編號不能為空!");
                    return;
                }
            }
            if (s_type == 4)
            {
                if (txtFindId.Text.Trim() == "")
                {
                    MessageBox.Show("單據編號不能為空!");
                    return;
                }
            }
            if (s_type == 5)
            {
                if (txtFindDate.Text.Replace(" ", "") == "//")
                {
                    MessageBox.Show("移交單日期不能為空!");
                    return;
                }
            }

            if (s_type == 6)//如果是查詢已收貨
            {
                if (txtCon_date.Text.Replace(" ", "") == "//" && txtMo_id.Text.Trim() == "" && txtTransfer_id.Text.Trim() == "")
                {
                    MessageBox.Show("至少要輸入一個查詢條件：日期、制單、單據編號!");
                    return;
                }
            }
            switch (s_type)
            {
                case 1://條形碼按單據編號查詢
                    {
                        select_type = 1;
                        if (chkIsRec.Checked==true)
                            select_type = 5;
                        doc = dtBarCode.Rows[0]["doc_id"].ToString();
                        seq = dtBarCode.Rows[0]["doc_seq"].ToString();
                        break;
                    }
                case 2://條形碼按制單編號
                    {
                        select_type = 1;
                        if (chkIsRec.Checked == true)
                            select_type = 5;
                        tdep = txtIn_dept.Text;
                        fdep = txtOut_dept.Text;
                        mo_id = txtMo_id.Text;
                        item = txtGoods_id.Text;
                        break;
                    }
                case 3://按制單編號
                    {
                        select_type = 5;
                        tdep = txtIn_dept.Text;
                        mo_id = txtFindMo.Text;
                        break;
                    }
                case 4://按移交單編號
                    {
                        select_type = 5;
                        doc = txtFindId.Text;
                        break;
                    }
                case 5://按移交單日期
                    {
                        select_type = 5;
                        date1 = txtFindDate.Text;
                        date2 = Convert.ToDateTime(date1).AddDays(1).ToString("yyyy/MM/dd");
                        break;
                    }
                case 6://查詢已收貨
                    {
                        select_type = 2;
                        if (txtCon_date.Text.Replace(" ", "") != "//")
                        {
                            date1 = txtCon_date.Text;
                            date2 = Convert.ToDateTime(date1).AddDays(1).ToString("yyyy/MM/dd");
                        }
                        if (txtMo_id.Text.Trim() != "")
                            mo_id = txtMo_id.Text.Trim();
                        else
                        {
                            if (txtTransfer_id.Text.Trim() != "")
                                doc = txtTransfer_id.Text.Trim();
                        }
                        break;
                    }
                case 10://貨倉發貨：條形碼按單據編號查詢
                    {
                        select_type = 1;
                        if (chkIsRec.Checked == true)
                            select_type = 5;
                        doc = dtBarCode.Rows[0]["doc_id"].ToString();
                        seq = dtBarCode.Rows[0]["doc_seq"].ToString();
                        break;
                    }
                case 11://儲存後，從已收貨的記錄中查找
                    {
                        select_type = 2;
                        doc = txtTransfer_id.Text.Trim();
                        seq = txtSeq_id.Text.Trim();
                        break;
                    }
                case 12://儲存後，通過合併ID從已收貨的記錄中查找
                    {
                        select_type = 2;
                        merge_id = txtMerge_id.Text.Trim();
                        break;
                    }
                default:break;
            }
            dtTransferDetails = clsPrdTransfer.GetTransferDetails(select_type, tdep, fdep, mo_id, doc, seq, item, date1, date2, merge_id);
            dgvDetails.DataSource = dtTransferDetails;
            //如果是已簽收的，則用紅色表示
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                if (dgvDetails.Rows[i].Cells["colRecState"].Value.ToString().Trim() != "" || dgvDetails.Rows[i].Cells["colSign_by"].Value.ToString().Trim() != "")
                    dgvDetails.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                else
                    dgvDetails.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
            CleanTextBox();
            fill_data();
            ShowData501();//顯示外發的數據
            
        }
        //顯示外發的數據
        private void ShowData501()
        {
            //如果是外發部門的，則顯示供應商
            if (string.Compare(txtIn_dept.Text.Trim(), "500") >= 0 && string.Compare(txtIn_dept.Text.Trim(), "600") < 0)
            {
                DataTable vtb = clsProductionSchedule.GetVendorFromWp(txtTransfer_id.Text, txtOut_dept.Text.Trim(), txtIn_dept.Text.Trim(), txtMo_id.Text.Trim(), txtGoods_id.Text.Trim());
                if (vtb.Rows.Count > 0)
                {
                    txtVendor.Text = vtb.Rows[0]["logogram"].ToString().Trim() + "(" + vtb.Rows[0]["vendor_id"].ToString().Trim() + ")";
                    txtColorName.Text = vtb.Rows[0]["color_name"].ToString().Trim() + "  " + vtb.Rows[0]["do_color"].ToString();
                }
                else
                {
                    vtb = clsProductionSchedule.GetVendDataFromWip(txtMo_id.Text.Trim(),txtIn_dept.Text.Trim(),  txtGoods_id.Text.Trim());
                    if (vtb.Rows.Count > 0)
                    {
                        txtColorName.Text = vtb.Rows[0]["color_name"].ToString().Trim() + "  " + vtb.Rows[0]["do_color"].ToString();
                    }
                }
                lblDef_qty.ForeColor = Color.Black;
                txtDef_qty.ForeColor = Color.Black;
                txtGoods_name.ForeColor = Color.Black;
                txtColorName.ForeColor = Color.Black;
                DataTable wtb = clsProductionSchedule.GetRecQtyFromWip(txtMo_id.Text.Trim(), txtIn_dept.Text.Trim(), txtGoods_id.Text.Trim());
                if (wtb.Rows.Count > 0)
                {
                    txtPre_prd_qty.Text = wtb.Rows[0]["pre_prd_qty"].ToString().Trim();
                    txtRecQty.Text = wtb.Rows[0]["pre_ok_qty"].ToString().Trim();
                    txtRecWeg.Text = wtb.Rows[0]["pre_ok_weg"].ToString().Trim();
                    int def_qty = (txtPre_prd_qty.Text != "" ? Convert.ToInt32(txtPre_prd_qty.Text) : 0) - (txtRecQty.Text != "" ? Convert.ToInt32(txtRecQty.Text) : 0);
                    txtDef_qty.Text = def_qty.ToString();
                    if (def_qty <= 0)
                    {
                        lblDef_qty.ForeColor = Color.Blue;
                        txtDef_qty.ForeColor = Color.Blue;
                        txtGoods_name.ForeColor = Color.Blue;
                        txtColorName.ForeColor = Color.Blue;
                    }
                    else
                    {
                        lblDef_qty.ForeColor = Color.Black;
                        txtDef_qty.ForeColor = Color.Black;
                        txtGoods_name.ForeColor = Color.Black;
                        txtColorName.ForeColor = Color.Black;
                    }
                }
                else
                {
                    txtPre_prd_qty.Text = "";
                    txtRecQty.Text = "";
                    txtDef_qty.Text = "";
                    txtRecWeg.Text = "";
                }
                DataTable stb = clsProductionSchedule.GetStQtyFromWip(txtMo_id.Text.Trim(), txtIn_dept.Text.Trim(), txtGoods_id.Text.Trim());
                if (stb.Rows.Count > 0)
                {
                    txtStQty.Text = stb.Rows[0]["st_qty"].ToString().Trim();
                    txtStWeg.Text = stb.Rows[0]["st_weg"].ToString().Trim();
                }
            }
        }
        
        private void txtMo_id_TextChanged(object sender, EventArgs e)
        {
            if (txtMo_id.Text.Length >= 9 && query_status == "Y")
                find_data(3);//1--在原始移交單中查詢
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            query_status = "N";
            fill_data();
            ShowData501();//顯示外發部門的數據
        }

        private void fill_data()
        {
            query_status = "N";
            if (dgvDetails.RowCount <= 0)
                return;
            txtIn_dept.Text = this.dgvDetails[5, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            txtOut_dept.Text = this.dgvDetails[6, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            txtCon_date.Text = this.dgvDetails[3, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            txtTransfer_id.Text = this.dgvDetails[2, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            txtSeq_id.Text = this.dgvDetails[7, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            txtMo_id.Text = this.dgvDetails[8, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            txtGoods_name.Text = this.dgvDetails[10, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            txtActual_qty.Text = this.dgvDetails[15, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            txtActual_weg.Text = this.dgvDetails[16, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            if (txtActual_qty.Text.Trim() == "")
                txtActual_qty.Text = this.dgvDetails[12, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            if (txtActual_weg.Text.Trim() == "")
                txtActual_weg.Text = this.dgvDetails[13, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            txtPerQty.Text = txtActual_qty.Text;
            txtPerWeg.Text = txtActual_weg.Text;
            txtLot_no.Text = this.dgvDetails[11, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            txtCrusr.Text = this.dgvDetails[17, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            txtCrtim.Text = this.dgvDetails[18, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            txtImput_flag.Text = this.dgvDetails[19, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            txtImput_time.Text = this.dgvDetails[20, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            //如果是已收貨的，則顯示已收貨的包數
            if (dgvDetails.CurrentRow.Cells["colRecState"].Value.ToString().Trim() != "" || dgvDetails.CurrentRow.Cells["colSign_by"].Value.ToString().Trim() != "")
                txtActual_pack.Text = dgvDetails.CurrentRow.Cells["colActual_pack"].Value.ToString();
            else//未收貨的，則顯示上部門的包數，若包數為0，則默認為1包。
            {
                txtActual_pack.Text = dgvDetails.CurrentRow.Cells["colPackage_num"].Value.ToString();
                if ((txtActual_pack.Text.Trim() != "" ? Convert.ToInt32(txtActual_pack.Text) : 0) == 0)
                    txtActual_pack.Text = "1";
            }
            txtId_state.Text = this.dgvDetails[27, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();//= "Y"移交單已完成收貨
            txtMerge_id.Text = dgvDetails.CurrentRow.Cells["colMerge_id"].Value.ToString();
            txtGoods_id.Text = dgvDetails.CurrentRow.Cells["colGoods_id"].Value.ToString();
            txtVendor.Text = "";
            txtDif_qty.Text = dgvDetails.CurrentRow.Cells["colDif_qty"].Value.ToString();
            txtDif_weg.Text = dgvDetails.CurrentRow.Cells["colDif_weg"].Value.ToString();
            chkAdj.Checked = false;
            chkRet.Checked = false;
            if(dgvDetails.CurrentRow.Cells["colDif_flag"].Value.ToString()=="A")
                chkAdj.Checked = true;
            if (dgvDetails.CurrentRow.Cells["colDif_flag"].Value.ToString() == "R")
                chkRet.Checked = true;

            ShowItemPic(txtGoods_id.Text);//顯示產品圖片

        }
        private void CleanTextBox()
        {
            txtIn_dept.Text = "";
            txtOut_dept.Text = "";
            txtCon_date.Text = "";
            txtTransfer_id.Text = "";
            txtSeq_id.Text = "";
            txtMo_id.Text = "";
            txtGoods_name.Text = "";
            txtActual_qty.Text = "";
            txtActual_weg.Text = "";
            txtPerQty.Text = "";
            txtPerWeg.Text = "";
            txtLot_no.Text = "";
            txtCrusr.Text = "";
            txtCrtim.Text = "";
            txtImput_flag.Text = "";
            txtImput_time.Text = "";
            txtActual_pack.Text = "";
            txtId_state.Text = "";//= "Y"移交單已完成收貨
            txtMerge_id.Text = "";
            txtGoods_id.Text = "";
            txtVendor.Text = "";
            txtDif_qty.Text = "";
            txtDif_weg.Text = "";
            txtColorName.Text = "";
        }
        private void btnConfigMo_Click(object sender, EventArgs e)
        {
            if (!clsPublicOfPad.getUserDep(_userid, txtIn_dept.Text))
            {
                MessageBox.Show("此用戶"+_userid+"沒有該部門的收貨權限!");
                return;
            }
            int Result = 0;
            if (chkMerge.Checked == true)
            {
                Result = MergeRecive();
            }
            else
            {
                Result = GeneralRecive();
            }

            if (Result > 0)
            {
                // MessageBox.Show("收貨成功！");
                //if (chkIsPprint.Checked == true)//收貨後列印
                //    btnPrint_Click(sender, e);
            }
            else
            {
                MessageBox.Show("保存出錯(Error)！");
            }
            txtBarCode.Focus();
        }

        /// <summary>
        /// 合併單收貨
        /// </summary>
        /// <returns></returns>
        private int MergeRecive()
        {
            int Result = 0;
            int merge_id = clsPublicOfPad.GenNo("frmTransferRecords");  //併單索引
            txtMerge_id.Text = merge_id.ToString();
            int st_tr = 1;//移交單還是貨倉發貨標識
            ////更新併單總數量、重量
            for (int i = 0; i < listDetail.Count; i++)
            {
                listDetail[i].total_qty = Convert.ToSingle(txtTotalQty.Text);
                listDetail[i].total_weg = Convert.ToSingle(txtTotalWeg.Text);
            }
            //更新明細表記錄
            Result = clsPrdTransfer.SaveTransferDetails(listDetail, merge_id);
            //更新主表記錄
            if (Result > 0)
            {
                for (int i = 0; i < listDetail.Count; i++)
                {
                    if (listDetail[i].id.Substring(0, 3) == "DAA" || listDetail[i].id.Substring(0, 3) == "DAB")//如果是貨倉發貨
                        st_tr = 2;
                    Result = clsPrdTransfer.SaveTransferMostly(st_tr, listDetail[i].id, txtIn_dept.Text.Trim(), txtOut_dept.Text.Trim(), _userid);
                    if (Result == 0)
                        break;
                }
            }


            if (Result > 0)
            {
                find_data(12);//儲存後，從已收貨的記錄中查找
                dtTemp.Rows.Clear();
                listDetail.Clear();
                chkMerge.Checked = false;
                chkMerge.Visible = false;
                txtTotalQty.Text = "";
                txtTotalWeg.Text = "";
            }

            return Result;
        }

        /// <summary>
        /// 普通收貨
        /// </summary>
        private int GeneralRecive()
        {
            int result = 0;
            if (valid_data())
            {
                jo_materiel_con_details objDetails = new jo_materiel_con_details();
                objDetails.mo_id = txtMo_id.Text.Trim();
                objDetails.goods_id = dgvDetails.CurrentRow.Cells["colGoods_id"].Value.ToString();
                objDetails.id = txtTransfer_id.Text.Trim();
                objDetails.lot_no = dgvDetails.CurrentRow.Cells["colLot_no"].Value.ToString();
                objDetails.package_num = clsUtility.FormatNullableFloat(dgvDetails.CurrentRow.Cells["colPackage_num"].Value);
                objDetails.con_qty = clsUtility.FormatNullableFloat(dgvDetails.CurrentRow.Cells["colCon_qty"].Value);
                objDetails.sec_qty = clsUtility.FormatNullableFloat(dgvDetails.CurrentRow.Cells["colSec_qty"].Value);
                objDetails.actual_qty = Convert.ToSingle(txtActual_qty.Text);
                objDetails.actual_weg = Math.Round(Convert.ToSingle(txtActual_weg.Text), 2);
                objDetails.actual_pack = Convert.ToInt32(txtActual_pack.Text);
                objDetails.dif_qty = (txtDif_qty.Text.Trim()!=""?Convert.ToSingle(txtDif_qty.Text):0);
                objDetails.dif_weg = (txtDif_weg.Text.Trim()!=""?Math.Round(Convert.ToSingle(txtDif_weg.Text), 2):0);
                objDetails.dif_flag = "";
                if(chkAdj.Checked == true)
                    objDetails.dif_flag = "A";
                if (chkRet.Checked == true)
                {
                    objDetails.dif_flag = "R";
                    objDetails.dif_qty = Math.Abs(objDetails.dif_qty);
                    objDetails.dif_weg = Math.Abs(objDetails.dif_weg);
                }
                objDetails.sequence_id = dgvDetails.CurrentRow.Cells["colSeq"].Value.ToString();
                objDetails.sample_no = 0;
                objDetails.sample_weg = 0;
                objDetails.conf_flag = "";
                objDetails.crusr = DBUtility._user_id;
                objDetails.crtim = DateTime.Now;

                result = clsPrdTransfer.SaveTransferDetails(objDetails);//儲存明細表記錄
                if (result > 0)
                {
                    //填充主表實體類
                    int st_tr=1;
                    if (objDetails.id.Substring(0, 3) == "DAA" || objDetails.id.Substring(0, 3) == "DAB")//如果是貨倉發貨
                        st_tr = 2;
                    int MostlyResult = clsPrdTransfer.SaveTransferMostly(st_tr, objDetails.id, txtIn_dept.Text.Trim(), txtOut_dept.Text.Trim(), _userid);

                    find_data(11);//從已收貨的記錄中查找

                }
            }
            return result;
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

        private void txtMo_id_MouseDown(object sender, MouseEventArgs e)
        {
            query_status = "Y";
            clsUtility.Call_imput();
        }

        private void txtTransfer_id_TextChanged(object sender, EventArgs e)
        {
            if (txtMo_id.Text.Length >= 12 && query_status == "Y")
                find_data(4);//1--在原始移交單中查詢
        }


        private void btnDel_Click(object sender, EventArgs e)
        {
            if (!clsPublicOfPad.getUserDep(_userid, txtIn_dept.Text))
            {
                MessageBox.Show("此用戶" + _userid + "沒有該部門的收貨權限!");
                return;
            }
            int result = 0;
            result = clsPrdTransfer.DelTransferDetails(1, txtTransfer_id.Text.Trim(), txtSeq_id.Text.Trim());
            if (result > 0)
            {
                find_data(4);//1--在原始移交單中查詢
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
            find_data(6);//查找已收貨的記錄
            txtBarCode.Focus();
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //掃描制單編號，物料編號
                    query_status = "N";//禁止用制單或移交單查詢
                    dtBarCode = clsPublicOfPad.BarCodeToItem(txtBarCode.Text);
                    txtBarCode.Text = "";
                    if (dtBarCode.Rows.Count > 0)
                    {
                        string barcode_type = dtBarCode.Rows[0]["barcode_type"].ToString();
                        if (barcode_type == "11")//移交單的條碼/17為無生產流程的退單的條碼(RW)17
                        {
                            find_data(1);
                        }
                        else
                        {
                            if (barcode_type == "12")//倉庫發貨的條碼
                                find_data(10);
                            else
                            {
                                if (barcode_type == "2")//從生產計劃中提取的條形碼
                                {
                                    txtIn_dept.Text = dtBarCode.Rows[0]["next_wp_id"].ToString();
                                    txtMo_id.Text = dtBarCode.Rows[0]["mo_id"].ToString();
                                    txtOut_dept.Text = dtBarCode.Rows[0]["wp_id"].ToString();
                                    txtGoods_id.Text = dtBarCode.Rows[0]["goods_id"].ToString();
                                    find_data(2);
                                }
                            }
                        }
                        setTextVisible();
                    }
                    else
                        return;
                    break;

            }
        }
        
        private void btnConfQty_Click(object sender, EventArgs e)
        {
            frmTransferConfQty frmConfQty = new frmTransferConfQty();
            frmConfQty.ShowDialog();
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

        private void txtActual_qty_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtActual_weg_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private List<jo_materiel_con_details> listDetail = new List<jo_materiel_con_details>();

        /// <summary>
        ///進行合併收貨 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMergeDocument_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                bool IsMerge = true;
                if (listDetail.Count > 0)
                {
                    for (int i = 0; i < listDetail.Count; i++)
                    {
                        if (listDetail[i].id == txtTransfer_id.Text && listDetail[i].sequence_id == txtSeq_id.Text)
                        {
                            MessageBox.Show("單據已存在合併收貨列表中，不能重複合併。");
                            IsMerge = false;
                            break;
                        }
                    }
                }

                if (dgvDetails.CurrentRow.Cells["colRecState"].Value.ToString() == "Y")
                {
                    MessageBox.Show("單據已收貨，不能重複收貨操作。");
                    IsMerge = false;
                }

                if (IsMerge)
                {
                    GenerateMergeList();
                    FillDataGrid();

                    //設置合併收貨狀態
                    chkMerge.Checked = true;
                    chkMerge.Visible = true;
                }
            }
            txtBarCode.Focus();
        }

        /// <summary>
        ///生成合併單據集合 
        /// </summary>
        private void GenerateMergeList()
        {
            //併單數量、重量累加
            if (string.IsNullOrEmpty(txtTotalQty.Text) && string.IsNullOrEmpty(txtTotalWeg.Text))
            {
                txtTotalQty.Text = txtActual_qty.Text;
                txtTotalWeg.Text = txtActual_weg.Text;
            }
            else
            {
                txtTotalQty.Text = (Convert.ToSingle(txtTotalQty.Text) + Convert.ToSingle(txtActual_qty.Text)).ToString();
                txtTotalWeg.Text = Math.Round(Convert.ToSingle(txtTotalWeg.Text) + Convert.ToSingle(txtActual_weg.Text), 2).ToString();
            }

            jo_materiel_con_details objDetails = new jo_materiel_con_details();
            objDetails.mo_id = txtMo_id.Text.Trim();
            objDetails.goods_id = dgvDetails.CurrentRow.Cells["colGoods_id"].Value.ToString();
            objDetails.id = txtTransfer_id.Text.Trim();
            objDetails.lot_no = dgvDetails.CurrentRow.Cells["colLot_no"].Value.ToString();
            objDetails.package_num = clsUtility.FormatNullableFloat(dgvDetails.CurrentRow.Cells["colPackage_num"].Value);
            objDetails.con_qty = clsUtility.FormatNullableFloat(dgvDetails.CurrentRow.Cells["colCon_qty"].Value);
            objDetails.sec_qty = clsUtility.FormatNullableFloat(dgvDetails.CurrentRow.Cells["colSec_qty"].Value);
            objDetails.actual_qty = Convert.ToSingle(txtActual_qty.Text);
            objDetails.actual_weg = Math.Round(Convert.ToSingle(txtActual_weg.Text), 2);
            objDetails.actual_pack = Convert.ToInt32(txtActual_pack.Text);
            objDetails.sequence_id = dgvDetails.CurrentRow.Cells["colSeq"].Value.ToString();
            objDetails.barcode_lot = dgvDetails.CurrentRow.Cells["colBarcode_lot"].Value.ToString();
            objDetails.sample_no = 0;
            objDetails.sample_weg = 0;
            objDetails.conf_flag = "";
            objDetails.total_qty = Convert.ToSingle(txtTotalQty.Text);
            objDetails.total_weg = Convert.ToSingle(txtTotalWeg.Text);
            objDetails.crusr = DBUtility._user_id;
            objDetails.crtim = DateTime.Now;
            listDetail.Add(objDetails);


        }

        /// <summary>
        /// 把合併的單據添加到臨時表
        /// </summary>
        private void FillDataGrid()
        {
            if (dgvMerge.Rows.Count > 0)
            {
                dtTemp.ImportRow(dtTransferDetails.Rows[dgvDetails.CurrentRow.Index]);
            }
            else
            {
                dtTemp = dtTransferDetails.Copy();
                dtTemp.Clear();
                dtTemp.ImportRow(dtTransferDetails.Rows[dgvDetails.CurrentRow.Index]);
            }

            if (listDetail.Count == dtTemp.Rows.Count)
            {
                for (int i = 0; i < listDetail.Count; i++)
                {
                    if (listDetail[i].id == dtTemp.Rows[i]["id"].ToString())
                    {
                        dtTemp.Rows[i]["actual_qty"] = listDetail[i].actual_qty;
                        dtTemp.Rows[i]["actual_weg"] = listDetail[i].actual_weg;
                        dtTemp.Rows[i]["actual_pack"] = listDetail[i].actual_pack;
                    }
                }

                dgvMerge.DataSource = dtTemp;
            }

            this.tabControl1.SelectedTab = tabPage2;
        }

        /// <summary>
        ///移除合併的單據 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvMerge.Rows.Count > 0)
            {
                txtTotalQty.Text = (Convert.ToSingle(txtTotalQty.Text) - Convert.ToSingle(dgvMerge.CurrentRow.Cells["Actual_qty"].Value)).ToString();
                txtTotalWeg.Text = Math.Round(Convert.ToSingle(txtTotalWeg.Text) - Convert.ToSingle(dgvMerge.CurrentRow.Cells["Actual_weg"].Value), 2).ToString();

                for (int i = 0; i < listDetail.Count; i++)
                {
                    if (listDetail[i].id == dgvMerge.CurrentRow.Cells["Id"].Value.ToString() && listDetail[i].sequence_id == dgvMerge.CurrentRow.Cells["Sequence_id"].Value.ToString())
                    {
                        listDetail.RemoveAt(i);
                        break;
                    }
                }
                dtTemp.Rows.RemoveAt(dgvMerge.CurrentRow.Index);
                dgvMerge.DataSource = dtTemp;
            }

            if (dtTemp.Rows.Count == 0)
            {
                chkMerge.Checked = false;
                chkMerge.Visible = false;
            }
            txtBarCode.Focus();
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

        private void tabControl1_Click(object sender, EventArgs e)
        {
            txtBarCode.Focus();
        }

        private void btnConfFind_Click(object sender, EventArgs e)
        {
            if (txtFindMo.Visible == true)
            {
                query_status = "Y";//期
                find_data(3);
            }
            if (txtFindId.Visible == true)
            {
                query_status = "Y";
                find_data(4);
            }
            if (txtFindDate.Visible == true)
            {
                query_status = "Y";
                find_data(5);
            }
            palShowCont.Visible = false;
            setFindTextBoxVisible();
            txtBarCode.Focus();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            palShowCont.Visible = false;
            setFindTextBoxVisible();
            txtBarCode.Focus();
        }
        private void setFindTextBoxVisible()
        {
            txtFindMo.Visible = false;
            lblFindMo.Visible = false;
            lblShowId.Visible = false;
            txtFindId.Visible = false;
            txtFindDate.Visible = false;
            lblFindDate.Visible = false;
        }
        private void btnShowMo_Click(object sender, EventArgs e)
        {
            txtFindMo.Text = txtMo_id.Text;
            txtFindMo.Visible = true;
            lblFindMo.Visible = true;
            palShowCont.Visible = true;
            txtFindMo.Focus();
        }

        private void btnShowId_Click(object sender, EventArgs e)
        {
            txtFindId.Text = txtTransfer_id.Text;
            lblShowId.Visible = true;
            txtFindId.Visible = true;
            palShowCont.Visible = true;
            txtFindId.Focus();
        }

        private void btnShowDate_Click(object sender, EventArgs e)
        {
            txtFindDate.Text = txtCon_date.Text;
            txtFindDate.Visible = true;
            lblFindDate.Visible = true;
            palShowCont.Visible = true;
            txtFindDate.Focus();
        }

        private void txtFindDate_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtFindId_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtFindMo_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            string strSql = "p_sync_turn_over";//u_test/z_load_st_details
            int result;
            result = clsPublicOfGeo.ExecuteNonQuery(strSql, null, true);
            if (result >= 0)
                MessageBox.Show("同步成功!");
            else
                MessageBox.Show("同步失败!");
        }

        private void chkIsRec_Click(object sender, EventArgs e)
        {
            txtBarCode.Focus();
        }

        private void txtActual_qty_TextChanged(object sender, EventArgs e)
        {
            if (txtActual_qty.Text.Trim() != "" && dgvDetails.CurrentRow.Cells["colCon_qty"].Value != null && dgvDetails.CurrentRow.Cells["colCon_qty"].Value.ToString().Trim()!="")
                txtDif_qty.Text = (Convert.ToInt32(txtActual_qty.Text) - Convert.ToInt32(dgvDetails.CurrentRow.Cells["colCon_qty"].Value)).ToString();
        }

        private void txtActual_weg_TextChanged(object sender, EventArgs e)
        {
            if (txtActual_weg.Text.Trim() != "" && dgvDetails.CurrentRow.Cells["colSec_qty"].Value != null && dgvDetails.CurrentRow.Cells["colSec_qty"].Value.ToString().Trim() != "")
                txtDif_weg.Text = Math.Round((Convert.ToSingle(txtActual_weg.Text) - Convert.ToSingle(dgvDetails.CurrentRow.Cells["colSec_qty"].Value)),2).ToString();
        }

        private void chkAdj_Click(object sender, EventArgs e)
        {
            chkRet.Checked = false;
        }

        private void chkRet_Click(object sender, EventArgs e)
        {
            chkAdj.Checked = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dtReportTo = new DataTable();
            dtReportTo = dtReport.Clone();
            if (chkMerge.Checked == false)//如果是逐條收貨
            {
                if (dgvDetails.Rows.Count == 0)
                {
                    MessageBox.Show("沒有需要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataRow newRow = dtReportTo.NewRow();
                newRow["id"] = dgvDetails.CurrentRow.Cells["colId"].Value.ToString();
                newRow["con_date"] = dgvDetails.CurrentRow.Cells["colCon_date"].Value.ToString();
                newRow["out_dept"] = dgvDetails.CurrentRow.Cells["colOut_dept"].Value.ToString();
                newRow["out_dept_name"] = dgvDetails.CurrentRow.Cells["colOut_dept"].Value.ToString();
                newRow["in_dept"] = dgvDetails.CurrentRow.Cells["colIn_dept"].Value.ToString();
                newRow["in_dept_name"] = dgvDetails.CurrentRow.Cells["colIn_dept"].Value.ToString();
                newRow["mo_id"] = dgvDetails.CurrentRow.Cells["colMo_id"].Value.ToString();
                newRow["goods_id"] = dgvDetails.CurrentRow.Cells["colGoods_id"].Value.ToString();
                newRow["goods_name"] = dgvDetails.CurrentRow.Cells["colGoods_name"].Value.ToString();
                if (string.Compare(txtIn_dept.Text.Trim(), "8") > 0)
                {
                    newRow["con_qty"] = (txtPerQty.Text !="" ? Convert.ToDecimal(txtPerQty.Text):0);
                    newRow["sec_qty"] = (txtPerWeg.Text != "" ? Convert.ToDecimal(txtPerWeg.Text) : 0);
                }
                else
                {
                    newRow["con_qty"] = Convert.ToDecimal(dgvDetails.CurrentRow.Cells["colCon_qty"].Value);
                    newRow["sec_qty"] = Convert.ToDecimal(dgvDetails.CurrentRow.Cells["colSec_qty"].Value);
                }
                newRow["barcode_id"] = dgvDetails.CurrentRow.Cells["colBarcode_lot"].Value.ToString();
                newRow["sequence_id"] = dgvDetails.CurrentRow.Cells["colSeq"].Value.ToString();
                newRow["picture_name"] = "";
                newRow["do_color"] = txtColorName.Text.ToString().Trim();
                newRow["package_num"] = dgvDetails.CurrentRow.Cells["colPackage_num"].Value.ToString();
                newRow["lot_no"] = dgvDetails.CurrentRow.Cells["colLot_no"].Value.ToString();
                newRow["seq_id_flag"] = "";
                newRow["rec_flag"] = "";

                newRow["vendor_id"] = "";
                newRow["name_vendor"] = "";
                newRow["name_clr"] = txtColorName.Text.ToString().Trim();
                newRow["production_remark"] = "";

                dtReportTo.Rows.Add(newRow);
            }
            else//如果是合併收貨
            {
                if (dgvMerge.Rows.Count == 0)
                {
                    MessageBox.Show("沒有需要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                for (int i = 0; i < dgvMerge.Rows.Count; i++)
                {
                    DataRow newRow = dtReportTo.NewRow();
                    newRow["id"] = dgvMerge.Rows[i].Cells["Id"].Value.ToString();
                    newRow["con_date"] = dgvMerge.Rows[i].Cells["Con_date"].Value.ToString();
                    newRow["out_dept"] = dgvMerge.Rows[i].Cells["Out_dept"].Value.ToString();
                    newRow["out_dept_name"] = dgvMerge.Rows[i].Cells["Out_dept"].Value.ToString();
                    newRow["in_dept"] = dgvMerge.Rows[i].Cells["In_dept"].Value.ToString();
                    newRow["in_dept_name"] = dgvMerge.Rows[i].Cells["In_dept"].Value.ToString();
                    newRow["mo_id"] = dgvMerge.Rows[i].Cells["Mo_id"].Value.ToString();
                    newRow["goods_id"] = dgvMerge.Rows[i].Cells["Goods_id"].Value.ToString();
                    newRow["goods_name"] = dgvMerge.Rows[i].Cells["Goods_name"].Value.ToString();
                    if (string.Compare(txtIn_dept.Text.Trim(), "8") > 0)
                    {
                        newRow["con_qty"] = (txtPerQty.Text != "" ? Convert.ToDecimal(txtPerQty.Text) : 0);
                        newRow["sec_qty"] = (txtPerWeg.Text != "" ? Convert.ToDecimal(txtPerWeg.Text) : 0);
                    }
                    else
                    {
                        newRow["con_qty"] = Convert.ToDecimal(dgvMerge.Rows[i].Cells["Con_qty"].Value);
                        newRow["sec_qty"] = Convert.ToDecimal(dgvMerge.Rows[i].Cells["Sec_qty"].Value);
                    }
                    newRow["barcode_id"] = dgvMerge.Rows[i].Cells["Barcode_lot"].Value.ToString();
                    newRow["sequence_id"] = dgvMerge.Rows[i].Cells["Sequence_id"].Value.ToString();
                    newRow["picture_name"] = "";
                    newRow["do_color"] = txtColorName.Text.ToString().Trim();
                    newRow["package_num"] = dgvMerge.Rows[i].Cells["Package_num"].Value.ToString();
                    newRow["lot_no"] = dgvMerge.Rows[i].Cells["Lot_no"].Value.ToString();
                    newRow["seq_id_flag"] = "";
                    newRow["rec_flag"] = "";

                    newRow["vendor_id"] = "";
                    newRow["name_vendor"] = "";
                    newRow["name_clr"] = txtColorName.Text.ToString().Trim();
                    newRow["production_remark"] = "";

                    dtReportTo.Rows.Add(newRow);
                }
            }
            //-----

            //加載報表                
            xrDelivery oRepot = new xrDelivery() { DataSource = dtReportTo };
            oRepot.CreateDocument();
            oRepot.PrintingSystem.ShowMarginsWarning = false;
            //oRepot.ShowPreview();
            oRepot.Print();
        }

        private void txtIn_dept_Leave(object sender, EventArgs e)
        {
            setTextVisible();
        }
        private void setTextVisible()
        {
            if (string.Compare(txtIn_dept.Text.Trim(), "8") > 0)
            {
                chkIsPprint.Checked = true;
                txtVendor.Visible = false;
                lblColorName.Visible = false;
                txtColorName.Visible = false;
                txtMo_id.Width = 457;
                lblPerQty.Visible = true;
                txtPerQty.Visible = true;
                lblPerWeg.Visible = true;
                txtPerWeg.Visible = true;
                btnCountQty.Visible = true;
            }
            else
            {
                chkIsPprint.Checked = false;
                txtVendor.Visible = true;
                lblColorName.Visible = true;
                txtColorName.Visible = true;
                txtMo_id.Width = 329;
                lblPerQty.Visible = false;
                txtPerQty.Visible = false;
                lblPerWeg.Visible = false;
                txtPerWeg.Visible = false;
                btnCountQty.Visible = false;
            }
            if (string.Compare(txtIn_dept.Text.Trim(), "501") >= 0 && string.Compare(txtIn_dept.Text.Trim(), "509") <= 0)
            {
                groupBox1.Visible = false;
                pal501.Visible = true;
            }
            else
            {
                groupBox1.Visible = true;
                pal501.Visible = false;
            }
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (btnShow.Text == "顯示")
            {
                btnShow.Text = "隱藏";
                btnShowMo.Visible = true;
                btnShowId.Visible = true;
                btnShowDate.Visible = true;
                btnSync.Visible = true;
                txtBarCode.Visible = false;
                //lblIn_dep.Visible = false;
                txtIn_dept.Visible = false;
                txtOut_dept.Visible = false;
                lblTrFlag.Visible = false;
            }
            else
            {
                btnShow.Text = "顯示";
                btnShowMo.Visible = false;
                btnShowId.Visible = false;
                btnShowDate.Visible = false;
                btnSync.Visible = false;

                txtBarCode.Visible = true;
                //lblIn_dep.Visible = true;
                txtIn_dept.Visible = true;
                txtOut_dept.Visible = true;
                lblTrFlag.Visible = true;
                txtBarCode.Focus();
            }
        }

        private void txtPerWeg_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    txtPerWeg.Text = txtPerWeg.Text.Replace(" ", "");
                    countQty();
                    break;
            }
        }

        private void txtPerWeg_Leave(object sender, EventArgs e)
        {
            countQty();
        }

        private void txtPerWeg_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtPerQty_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtPerWeg_KeyPress(object sender, KeyPressEventArgs e)
        {
            char Key_Char = e.KeyChar;//判斷按鍵的 Keychar
            if (((int)(Key_Char)).ToString() == "10")
            {
                txtPerWeg.Text = txtPerWeg.Text.Replace(" ", "");
                countQty();
            }
        }

        private void btnCountQty_Click(object sender, EventArgs e)
        {
            countQty();
        }
        private void countQty()
        {
            txtPerWeg.Text = txtPerWeg.Text.Replace(" ", "");
            if (!clsValidRule.IsNumeric(txtPerWeg.Text))
                return;
            if (txtActual_weg.Text.Trim() != "" && txtActual_qty.Text.Trim() != "" && txtPerWeg.Text.Trim() != "")
                txtPerQty.Text = Convert.ToInt32((Convert.ToDecimal(txtActual_qty.Text) / Convert.ToDecimal(txtActual_weg.Text)) * Convert.ToDecimal(txtPerWeg.Text)).ToString();
        }
        private void ShowItemPic(string item)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                string strImagePath = DBUtility.imagePath + CLS.clsShowProductionPlan.GetImagePath(item);
                if (File.Exists(strImagePath))
                {
                    picItem.Image = Image.FromFile(strImagePath);
                }
                else
                {
                    picItem.Image = null;
                }
            }
            else
                picItem.Image = null;
        }
    }
}
