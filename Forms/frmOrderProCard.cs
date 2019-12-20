using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using cf_pad.Reports;
using cf_pad.MDL;
using cf_pad.CLS;
using RUI.PC;
using DevExpress.XtraReports.UI;

namespace cf_pad.Forms
{
    public partial class frmOrderProCard : Form
    {
        private List<Mo_for_jx> lsModel = new List<Mo_for_jx>();
        private DataTable dtGoodsInfo = new DataTable();

        private clsUtility.enumOperationType operationType;
        private string goods_id;
        private int Reserve_Qty;

        public frmOrderProCard()
        {
            InitializeComponent();
        }

        private void frmOrderProCard_Load(object sender, EventArgs e)
        {
            txtPrintCopies.Text = "1";   //默認列印份數為1
            txtDept1.Focus();
            txtgoods_name.Enabled = false;
            txtPro_qty.Enabled = false;
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            operationType = clsUtility.enumOperationType.Print;
            if (ValidateText())
            {
                print_workcard();
            }
        }

        private void BTNPRINTPREVIEW_Click(object sender, EventArgs e)
        {
            operationType = clsUtility.enumOperationType.PreView;
            if (ValidateText())
            {
                print_workcard();
            }
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            txtDept1.Text = "";
            txtMoId.Text = "";
            txtgoods_name.Text = "";
            txtPer_qty.Text = "";
            txtPro_qty.Text = "";
        }

        /// <summary>
        /// 驗證輸入的數量是否為真確格式
        /// </summary>
        /// <returns></returns>
        private bool ValidateText()
        {
            if (txtDept1.Text.Trim() == "")
            {
                MessageBox.Show("請輸入部門。");
                txtDept1.Focus();
                return false;
            }

            if (txtMoId.Text.Trim() == "")
            {
                MessageBox.Show("請輸入制單編號。");
                txtMoId.Focus();
                return false;
            }

            if (!Information.IsNumeric(txtPer_qty.Text.Trim()))
            {
                MessageBox.Show("每次生產數量只能輸入數字格式，請重新輸入。");
                txtPer_qty.Focus();
                txtPer_qty.SelectAll();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 選擇物料編號后，填充數據。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowByItem()
        {
            for (int i = 0; i < lsModel.Count; i++)
            {
                if (lueGoodsId.EditValue.ToString() == lsModel[i].sequence_id)
                {
                    Reserve_Qty = lsModel[i].Reserve_qty;
                    goods_id = lsModel[i].goods_id;
                    txtgoods_name.Text = lsModel[i].goods_name;
                    txtPer_qty.Text = lsModel[i].prod_qty.ToString();
                    txtPro_qty.Text = lsModel[i].prod_qty.ToString();
                    txtNextDep.Text = lsModel[i].next_wp_id.ToString();
                    txtNextDepName.Text = lsModel[i].next_wp_name.ToString();
                    txtCompDate.Text = lsModel[i].t_complete_date.ToString();
                    txtBaseQty.Text = lsModel[i].base_qty.ToString();
                    txtGoodsUnit.Text = lsModel[i].unit_code.ToString();
                    txtColor.Text = lsModel[i].color.ToString();
                    txtBaseRate.Text = lsModel[i].base_rate.ToString();
                    txtBasicUnit.Text = lsModel[i].basic_unit.ToString();
                    txtPreDepQty.Text = lsModel[i].predept_rechange_qty.ToString();
                    txtSequenceId.Text = lsModel[i].sequence_id.ToString();
                    txtBlueprintId.Text = lsModel[i].blueprint_id.ToString();
                    txtUnitCode.Text = lsModel[i].unit_code.ToString();
                    txtget_color_sample_name.Text = lsModel[i].get_color_sample_name;
                    txtVender_id.Text = lsModel[i].Vendor_id;
                    txtC_sec_qty_ok.Text = lsModel[i].c_sec_qty_ok.ToString();

                    getArtDetails();//獲取圖樣代號資料

                    /****************獲取訂單數量*******************/
                    DataTable dtQty = new DataTable();
                    if (txtDept1.Text == "107" && txtNextDep.Text == "601" || txtDept1.Text == "510" && txtNextDep.Text == "601")
                    {
                        dtQty = clsMo_for_jx.GetOrderQtyBasedOnBom(txtMoId.Text.Trim(), goods_id);//滿足以上條件，訂單數量是基於Bom 用量
                    }
                    else
                    {
                        dtQty = clsMo_for_jx.GetOrderQty(txtMoId.Text.Trim());//獲取訂單數量
                    }

                    if (dtQty.Rows.Count > 0)
                    {
                        txtOrderUnit.Text = dtQty.Rows[0]["goods_unit"].ToString();
                        txtOrderQty.Text = Convert.ToInt32(dtQty.Rows[0]["order_qty"]).ToString();
                        txtOrderPcsQty.Text = Convert.ToInt32(dtQty.Rows[0]["order_qty_pcs"]).ToString();
                    }
                    break;
                }
            }
        }

        private void getArtDetails()
        {
            DataTable dtArt = clsMo_for_jx.GetGoods_ArtWork(goods_id);
            if (dtArt.Rows.Count > 0)
            {
                txtColorName.Text = dtArt.Rows[0]["color_name"].ToString();
                txtColorDo.Text = dtArt.Rows[0]["do_color"].ToString();
                txtPicPath.Text = dtArt.Rows[0]["picture_name"].ToString();
                txtArtId.Text = dtArt.Rows[0]["art_id"].ToString();
                picArtWork.Image = null;
                if (txtPicPath.Text.Trim() != "")
                    picArtWork.Image = Image.FromFile(DBUtility.imagePath + txtPicPath.Text.Trim());
            }
        }

        /// <summary>
        /// 根據部門、制單編號查詢單據信息
        /// </summary>
        private void GetGoodsDetails()
        {
            dtGoodsInfo = clsMo_for_jx.GetGoods_DetailsById(txtDept1.Text.Trim(), txtMoId.Text.Trim(), "");
            if (dtGoodsInfo.Rows.Count > 0)
            {

                lsModel.Clear();
                for (int i = 0; i < dtGoodsInfo.Rows.Count; i++)
                {
                    Mo_for_jx objModel = new Mo_for_jx();
                    objModel.wp_id = dtGoodsInfo.Rows[i]["wp_id"].ToString();
                    objModel.mo_id = dtGoodsInfo.Rows[i]["mo_id"].ToString();
                    objModel.goods_id = dtGoodsInfo.Rows[i]["goods_id"].ToString();
                    objModel.goods_name = dtGoodsInfo.Rows[i]["name"].ToString();
                    objModel.prod_qty = Convert.ToInt32(dtGoodsInfo.Rows[i]["prod_qty"]);
                    objModel.goods_unit = dtGoodsInfo.Rows[i]["goods_unit"].ToString();
                    objModel.bill_date = dtGoodsInfo.Rows[i]["bill_date"].ToString();
                    objModel.check_date = dtGoodsInfo.Rows[i]["check_date"].ToString();
                    objModel.order_qty = string.IsNullOrEmpty(txtOrderQty.Text) ? 0 : Convert.ToInt32(txtOrderQty.Text);
                    objModel.next_wp_id = dtGoodsInfo.Rows[i]["next_wp_id"].ToString();
                    objModel.next_wp_name = dtGoodsInfo.Rows[i]["next_wp_name"].ToString();
                    objModel.t_complete_date = dtGoodsInfo.Rows[i]["t_complete_date"].ToString();
                    objModel.brand_id = dtGoodsInfo.Rows[i]["brand_id"].ToString();
                    objModel.get_color_sample = dtGoodsInfo.Rows[i]["get_color_sample"].ToString();
                    objModel.order_unit = txtOrderUnit.Text.ToString();
                    objModel.production_remark = dtGoodsInfo.Rows[i]["production_remark"].ToString();
                    objModel.nickle_free = dtGoodsInfo.Rows[i]["nickle_free"].ToString();
                    objModel.plumbum_free = dtGoodsInfo.Rows[i]["plumbum_free"].ToString();
                    objModel.remark = dtGoodsInfo.Rows[i]["remark"].ToString();
                    objModel.base_qty = dtGoodsInfo.Rows[i]["base_qty"].ToString();
                    objModel.unit_code = dtGoodsInfo.Rows[i]["unit_code"].ToString();
                    objModel.base_rate = dtGoodsInfo.Rows[i]["base_rate"].ToString();
                    objModel.basic_unit = dtGoodsInfo.Rows[i]["basic_unit"].ToString();
                    objModel.within_code = dtGoodsInfo.Rows[i]["within_code"].ToString();
                    objModel.ver = dtGoodsInfo.Rows[i]["ver"].ToString();
                    objModel.id = dtGoodsInfo.Rows[i]["id"].ToString();
                    objModel.sequence_id = dtGoodsInfo.Rows[i]["sequence_id"].ToString();
                    objModel.blueprint_id = dtGoodsInfo.Rows[i]["blueprint_id"].ToString();
                    objModel.color = dtGoodsInfo.Rows[i]["color"].ToString();
                    objModel.predept_rechange_qty = dtGoodsInfo.Rows[i]["predept_rechange_qty"].ToString();
                    objModel.Reserve_qty = clsUtility.FormatNullableInt32(dtGoodsInfo.Rows[i]["OBLIGATE_QTY"]);
                    objModel.get_color_sample_name = dtGoodsInfo.Rows[i]["get_color_sample_name"].ToString();
                    objModel.Vendor_id = dtGoodsInfo.Rows[i]["vendor_id"].ToString();
                    objModel.c_sec_qty_ok = clsUtility.FormatNullableInt32(dtGoodsInfo.Rows[i]["c_sec_qty_ok"]);
                    lsModel.Add(objModel);
                }
                BindcmboxGoodsId();
                txtPrdRemark.Text = dtGoodsInfo.Rows[0]["production_remark"].ToString();
                txtBrandId.Text = dtGoodsInfo.Rows[0]["brand_id"].ToString();
                txtRemark.Text = dtGoodsInfo.Rows[0]["remark"].ToString();
                txtCust.Text = dtGoodsInfo.Rows[0]["customer_id"].ToString();
                txtVer.Text = dtGoodsInfo.Rows[0]["ver"].ToString();
                txtReqSample.Text = dtGoodsInfo.Rows[0]["get_color_sample"].ToString();
                txtId.Text = dtGoodsInfo.Rows[0]["id"].ToString();
                txtReqTest.Text = "";
                if (dtGoodsInfo.Rows[0]["nickle_free"].ToString() == "1")
                    txtReqTest.Text = "無叻;";
                if (dtGoodsInfo.Rows[0]["plumbum_free"].ToString() == "1")
                    txtReqTest.Text = txtReqTest.Text.Trim() + "無鉛;";

                //ShowByItem();

            }
            else
            {
                // lsModel.Clear();

                lueGoodsId.Properties.DataSource = null;
                lueGoodsId.Refresh();
            }
        }

        /// <summary>
        /// 綁定物料編號
        /// </summary>
        void BindcmboxGoodsId()
        {
            if (lsModel.Count > 0)
            {
                DataTable dtcmboxSource = new DataTable();

                dtcmboxSource.Columns.Add(new DataColumn("next_wp_id", typeof(string)));
                dtcmboxSource.Columns.Add(new DataColumn("goods_id", typeof(string)));
                dtcmboxSource.Columns.Add(new DataColumn("goods_name", typeof(string)));
                dtcmboxSource.Columns.Add(new DataColumn("sequence_id", typeof(string)));
                DataRow dr = null;
                for (int i = 0; i < lsModel.Count; i++)
                {
                    dr = dtcmboxSource.NewRow();
                    dr["next_wp_id"] = lsModel[i].next_wp_id;
                    dr["goods_id"] = lsModel[i].goods_id;
                    dr["goods_name"] = lsModel[i].goods_name;
                    dr["sequence_id"] = lsModel[i].sequence_id;
                    dtcmboxSource.Rows.Add(dr);
                }
                if (dtcmboxSource.Rows.Count > 0)
                {
                    lueGoodsId.Text = "";
                    lueGoodsId.EditValue = "";
                    lueGoodsId.Properties.DataSource = dtcmboxSource;
                    lueGoodsId.Properties.ValueMember = "sequence_id";
                    lueGoodsId.Properties.DisplayMember = "goods_id";
                }
            }

        }

        /// <summary>
        /// 獲取打印工序卡數據
        /// </summary>
        private void print_workcard()
        {
            if (!ValidateWeight())
                return;

            String dep, mo;
            dep = txtDept1.Text.Trim();
            mo = txtMoId.Text.Trim();
            if (dep != "" && mo != "" && goods_id != "")
            {

                DataTable dtRemark = dtGoodsInfo.Copy();

                if (dtGoodsInfo.Rows.Count > 0)
                {
                    int PrintCopies = Convert.ToInt32(txtPrintCopies.Text.Trim());  //列印份數

                    int Per_qty = Convert.ToInt32(txtPer_qty.Text.Trim());  //每次生產數量
                    if (Per_qty == 0)
                        Per_qty = 1;
                    int Total_qty = Convert.ToInt32(txtPro_qty.Text.Trim());    //生產總量
                    int NumPage = 0;     //報表頁數

                    DataTable dtNewWork = new DataTable();
                    dtNewWork = dtRemark;
                    dtNewWork.Rows.Clear();
                    dtNewWork.Columns.Remove("t_complete_date");
                    dtNewWork.Columns.Remove("base_rate");
                    dtNewWork.Columns.Remove("base_qty");
                    dtNewWork.Columns.Remove("prod_qty");
                    dtNewWork.Columns.Remove("name");
                    dtNewWork.Columns.Add("per_qty", typeof(string));
                    dtNewWork.Columns.Add("page_num", typeof(int));
                    dtNewWork.Columns.Add("total_page", typeof(int));
                    dtNewWork.Columns.Add("t_complete_date", typeof(string));
                    dtNewWork.Columns.Add("base_rate", typeof(int));
                    dtNewWork.Columns.Add("base_qty", typeof(int));
                    dtNewWork.Columns.Add("prod_qty", typeof(string));
                    dtNewWork.Columns.Add("order_qty", typeof(string));
                    dtNewWork.Columns.Add("order_qty_pcs", typeof(string));
                    dtNewWork.Columns.Add("do_color1", typeof(string));
                    dtNewWork.Columns.Add("art_id", typeof(string));
                    dtNewWork.Columns.Add("picture_name", typeof(string));
                    dtNewWork.Columns.Add("do_color", typeof(string));
                    dtNewWork.Columns.Add("color_name", typeof(string));
                    dtNewWork.Columns.Add("next_dep_name", typeof(string));
                    dtNewWork.Columns.Add("goods_name", typeof(string));
                    dtNewWork.Columns.Add("net_weight", typeof(string));
                    dtNewWork.Columns.Add("BarCode", typeof(string));
                    DataRow dr = null;

                    if (Total_qty > 0)
                    {
                        if (Total_qty % Per_qty > 0)
                        {
                            NumPage = (Total_qty / Per_qty) + 1;
                        }
                        else
                        {
                            NumPage = (Total_qty / Per_qty);
                        }
                    }
                    else
                    {
                        if (Reserve_Qty > 0)  //如果生產數量為0，且預留數量大於0，任需要打印工序卡
                        {
                            NumPage = 1;
                        }
                    }

                    for (int j = 1; j <= PrintCopies; j++)
                    {
                        for (int i = 1; i <= NumPage; i++)
                        {
                            dr = dtNewWork.NewRow();


                            dr["total_page"] = NumPage;
                            dr["wp_id"] = dep;
                            dr["mo_id"] = mo;
                            dr["goods_id"] = goods_id;
                            dr["goods_name"] = txtgoods_name.Text.Trim();
                            dr["prod_qty"] = clsUtility.NumberConvert(txtPro_qty.Text);
                            dr["goods_unit"] = txtGoodsUnit.Text.Trim();
                            dr["within_code"] = "0000";
                            dr["id"] = txtId.Text.Trim();
                            dr["ver"] = clsUtility.FormatNullableInt32(txtVer.Text);
                            dr["sequence_id"] = txtSequenceId.Text.Trim();
                            dr["blueprint_id"] = txtBlueprintId.Text.Trim();
                            dr["production_remark"] = txtPrdRemark.Text.Trim();
                            dr["remark"] = txtRemark.Text.Trim();
                            dr["next_wp_id"] = txtNextDep.Text.Trim();
                            if (txtPreDepQty.Text != "")
                                dr["predept_rechange_qty"] = clsUtility.FormatNullableDecimal(txtPreDepQty.Text);
                            if (txtOrderQty.Text != "")
                                dr["order_qty"] = clsUtility.NumberConvert(txtOrderQty.Text);
                            dr["order_unit"] = txtOrderUnit.Text.Trim();
                            dr["color"] = txtColor.Text.Trim();
                            if (txtBaseQty.Text != "")
                                dr["base_qty"] = clsUtility.FormatNullableInt32(txtBaseQty.Text);
                            dr["unit_code"] = txtUnitCode.Text.Trim();
                            if (txtBaseRate.Text != "")
                                dr["base_rate"] = clsUtility.FormatNullableInt32(txtBaseRate.Text);
                            dr["basic_unit"] = txtBasicUnit.Text.Trim();
                            dr["art_id"] = txtArtId.Text.Trim();
                            dr["picture_name"] = txtPicPath.Text.Trim();
                            dr["color_name"] = txtColorName.Text.Trim();
                            dr["do_color"] = txtColorDo.Text.Trim();
                            if (txtOrderPcsQty.Text != "")
                                dr["order_qty_pcs"] = clsUtility.NumberConvert(txtOrderPcsQty.Text);
                            dr["next_dep_name"] = txtNextDepName.Text.Trim();
                            dr["customer_id"] = txtCust.Text.Trim();
                            dr["brand_id"] = txtBrandId.Text.Trim();
                            dr["get_color_sample"] = txtReqSample.Text.Trim();
                            dr["do_color1"] = txtReqSample.Text.Trim();
                            dr["get_color_sample_name"] = txtget_color_sample_name.Text.Trim();
                            dr["vendor_id"] = txtVender_id.Text.Trim();
                            dr["c_sec_qty_ok"] = clsUtility.FormatNullableInt32(txtC_sec_qty_ok.Text);
                            dr["net_weight"] = txtNet_weight.Text.Trim();
                            dr["page_num"] = i;

                            if (txtCompDate.Text.Trim() != "" && txtCompDate.Text.Trim() != null)
                            {
                                dr["t_complete_date"] = Convert.ToDateTime(txtCompDate.Text).ToString("yyyy/MM/dd");
                            }

                            if (i == NumPage && Per_qty != 0)
                            {
                                if (Total_qty % Per_qty > 0)
                                {
                                    dr["per_qty"] = clsUtility.NumberConvert(Total_qty % Per_qty);
                                }
                                else
                                {
                                    dr["per_qty"] = clsUtility.NumberConvert(Per_qty);
                                }
                            }
                            else
                            {
                                dr["per_qty"] = clsUtility.NumberConvert(Per_qty);
                            }

                            dr["BarCode"] = clsMo_for_jx.ReturnBarCode(txtMoId.Text.Trim() + "0" + txtVer.Text.Trim() + txtSequenceId.Text.Substring(2, 2));

                            dtNewWork.Rows.Add(dr);
                        }
                    }

                    if (dtNewWork.Rows.Count > 0)
                    {
                        xtaWork_No_BarCode xr = new xtaWork_No_BarCode();
                        xr.DataSource = dtNewWork;
                        if (operationType == clsUtility.enumOperationType.PreView)    //判斷是預覽 Or 打印
                        {
                            xr.ShowPreviewDialog();
                        }
                        else
                        {
                            xr.Print();
                        }
                    }
                    else
                    {
                        MessageBox.Show("該數據無需打印工序卡。");
                    }

                }
            }
        }

        private bool ValidateWeight()
        {
            if (txtNet_weight.Text.Trim() != "")
            {
                if (!Verify.StringValidating(txtNet_weight.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
                {
                    MessageBox.Show("輸入的淨重格式不正確，請重新輸入。");
                    txtNet_weight.Focus();
                    txtNet_weight.SelectAll();
                    return false;
                }
            }
            return true;
        }



        /// <summary>
        /// 清空
        /// </summary>
        private void ClearForm()
        {
            foreach (Control ct in this.Controls)
            {
                switch (ct.GetType().Name)
                {
                    case "TextBox":
                        {
                            TextBox txt = (TextBox)ct;
                            if (txt.Name != "txtDept1" && txt.Name != "txtMoId" && txt.Name != "txtPrintCopies")
                            {
                                if (txt.Name.Trim().Length > 2 && txt.Name.Substring(0, 3) == "txt")
                                {
                                    txt.Text = "";
                                }
                            }
                            break;
                        }
                    case "PictureBox":
                        {
                            PictureBox pic = (PictureBox)ct;
                            pic.Image = null;
                            break;
                        }
                    case "ComboBox":
                        {
                            ComboBox comb = (ComboBox)ct;
                            comb.Text = null;
                            break;
                        }
                }
            }
        }

        private void txtMoId_Leave(object sender, EventArgs e)
        {
            ClearForm();
            GetGoodsDetails();
        }

        private void txtDept1_Leave(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void lueGoodsId_TextChanged(object sender, EventArgs e)
        {
            ShowByItem();
        }

        private void txtMoId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lueGoodsId.Focus();
                lueGoodsId.Text = "";
            }
        }

        private void txtDept1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMoId.Focus();
            }
        }








    }
}
