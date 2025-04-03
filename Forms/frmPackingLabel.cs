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
using DevExpress.XtraReports.UI;

namespace cf_pad.Forms
{
    public partial class frmPackingLabel : Form
    {
        string mo_id = "", goods_id = "", mo_group = "",carton_size="",suit_flag="0";
        int qty =  0 ;
        decimal weg = 0, weg_gross = 0;
        DataTable dtLabel = new DataTable();
        DataTable dtReport = new DataTable();
        DataTable dtFind = new DataTable();
        DataTable dtBom = new DataTable();
        List<string> lstItem = new List<string>();

        public frmPackingLabel()
        {
            InitializeComponent();

            dtReport.Columns.Add("it_customer", typeof(string));
            dtReport.Columns.Add("mo_id", typeof(string));
            dtReport.Columns.Add("mo_id_barcode", typeof(string));
            dtReport.Columns.Add("name_cust", typeof(string));
            dtReport.Columns.Add("po_style", typeof(string));
            dtReport.Columns.Add("id", typeof(string));
            dtReport.Columns.Add("trim_code", typeof(string));
            dtReport.Columns.Add("customer_color_id", typeof(string));
            dtReport.Columns.Add("goods_id", typeof(string));
            dtReport.Columns.Add("goods_desc", typeof(string));
            dtReport.Columns.Add("qty", typeof(string));
            dtReport.Columns.Add("qty_unit", typeof(string));
            dtReport.Columns.Add("net_weiht", typeof(string));
            dtReport.Columns.Add("net_unit", typeof(string));
            dtReport.Columns.Add("cross_weiht", typeof(string));
            dtReport.Columns.Add("cross_unit", typeof(string));

            dtReport.Columns.Add("brand_id", typeof(string));
            dtReport.Columns.Add("brand_name", typeof(string));
            dtReport.Columns.Add("flag_both", typeof(string));
            dtReport.Columns.Add("brand_name_custom", typeof(string));
            dtReport.Columns.Add("division", typeof(string));

            dtBom.Columns.Add("flag_select", typeof(bool));
            dtBom.Columns.Add("goods_id", typeof(string));
            dtBom.Columns.Add("primary_key", typeof(string));
            dtBom.Columns.Add("goods_desc", typeof(string));
        }

        private void frmPackingLabel_Load(object sender, EventArgs e)
        {
            txtBarCode.Focus();
            //重量
            DataTable dtUnit = clsPublicOfGeo.ExecuteSqlReturnDataTable("SELECT id FROM cd_units WHERE kind='03'");
            SetComboxItem(dtUnit, cmbNetUnit);
            SetComboxItem(dtUnit, cmbCrossUnit);
            dtUnit = clsPublicOfGeo.ExecuteSqlReturnDataTable("SELECT id FROM cd_units WHERE kind='05'");
            SetComboxItem(dtUnit, cmbQty);
            cmbQty.Text = "SET";
            cmbNetUnit.Text = "KG";
            cmbCrossUnit.Text = "KG";
            DataTable dtCartonSize = clsPublicOfGeo.ExecuteSqlReturnDataTable("SELECT name as id FROM cd_carton_size WHERE state <>'2' Order By id");
            for (int i = 0; i < dtCartonSize.Rows.Count; i++)
            {
                cmbCartonSize.Items.Add(dtCartonSize.Rows[i]["id"].ToString());
            }
            cmbCartonSize.Text = "";
            dgvBom.DataSource = dtBom;
        }

        private void SetComboxItem(DataTable dt,ComboBox cmb)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmb.Items.Add(dt.Rows[i]["id"].ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            string strBarCode = txtBarCode.Text;
            if (strBarCode.Length > 10)
            {
                strBarCode = strBarCode.Substring(0, 9);
            }
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SqlParameter[] paras = new SqlParameter[] {
                        new SqlParameter("@mo_id", strBarCode),
                        new SqlParameter("@lang", "CN")
                        //txtBarCode.Text)                       
                    };
                    dtLabel = clsPublicOfPad.ExecuteProcedure("usp_packing_label_new", paras);
                    txtBarCode.Text = "";
                    txtPrints.Text = "1";//重新掃條碼將列印份數重置為1
                    chkSuit.Checked = false;
                    pnlSuit.Visible = false;                   
                    dtBom.Clear();
                    if (dtLabel.Rows.Count > 0)
                    {
                        cmbItems.Text = dtLabel.Rows[0]["goods_id"].ToString();
                        Fill_Combox(dtLabel);
                                                                  
                        if (chkAutoPrint.Checked)
                        {
                            Print("P");
                        }
                        txtBarCode.Focus();
                    }
                    else
                    {
                        lblMo_id_barcode.Text = "";
                        lblIt_customer.Text = "";
                        lblMo_id.Text = "";
                        lblCustomer.Text = "";
                        lblPO_style.Text = "";
                        lblOc_no.Text = "";
                        lblCode.Text = "";
                        lblCustomer_color_id.Text = "";
                        lblGoods_id.Text = "";
                        rchGoods_desc.Text = "";
                        lblItem_total.Text = "";

                        txtQty.Text = "";
                        cmbQty.Text = "";
                        txtNet_weiht.Text = "";
                        cmbNetUnit.Text = "";
                        txtCross_weiht.Text = "";
                        cmbCrossUnit.Text = "";
                        cmbCartonSize.Text = "";

                        lblBrand_id.Text = "";
                        lblBrand_name.Text = "";
                        lblDivision.Text = "";
                        lblMo_group.Text = "";
                        return;
                    }                    
                    break;
            }
        }

        private void Fill_Combox(DataTable dt)
        {
            cmbItems.Items.Clear();
            cmbCartonSize.Text="";
            if (dt.Rows.Count > 0)
            {
                if (chkIsFinish.Checked)
                {
                    cmbItems.Items.Add(dt.Rows[0]["goods_id_f0"].ToString());
                    cmbItems.Text = dt.Rows[0]["goods_id_f0"].ToString();
                    lblItem_total.Text = "1";
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cmbItems.Items.Add(dt.Rows[i]["goods_id"].ToString());
                    }
                    cmbItems.Text = dt.Rows[0]["goods_id"].ToString();
                    lblItem_total.Text = dt.Rows.Count.ToString();
                }
                Select_Item(cmbItems.Text);
            }                       
        }
        private void Select_Item(string pGoods_id)
        {
            DataRow[] dr ;
            if (chkIsFinish.Checked)
            {
                dr = dtLabel.Select(string.Format("goods_id_f0='{0}'", pGoods_id));
                lblGoods_id.Text = dr[0]["goods_id_f0"].ToString();
            }
            else
            {
                dr = dtLabel.Select(string.Format("goods_id='{0}'", pGoods_id));
                lblGoods_id.Text = dr[0]["goods_id"].ToString();
            }
            lblIt_customer.Text = dr[0]["it_customer"].ToString();
            lblMo_id.Text = dr[0]["mo_id"].ToString();
            lblMo_id_barcode.Text = dr[0]["mo_id_barcode"].ToString();
            lblCustomer.Text = dr[0]["name_cust"].ToString();
            lblPO_style.Text = dr[0]["po_style"].ToString();
            lblOc_no.Text = dr[0]["id"].ToString();
            lblCode.Text = dr[0]["trim_code"].ToString();
            lblCustomer_color_id.Text = dr[0]["customer_color_id"].ToString();
            //lblGoods_id.Text = dr[0]["goods_id"].ToString();
            rchGoods_desc.Text = dr[0]["goods_desc"].ToString();

            lblBrand_id.Text = dr[0]["brand_id"].ToString();
            lblBrand_name.Text = dr[0]["brand_name_custom"].ToString();
            lblDivision.Text = dr[0]["division"].ToString();
            lblMo_group.Text = dr[0]["mo_group"].ToString();

            //取凈重
            Get_Net_Weiht(lblMo_id.Text, cmbItems.Text);
            cmbQty.Text = "SET";// "PCS";
            cmbNetUnit.Text = "KG";
            cmbCrossUnit.Text = "KG";
        }

        private void cmbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            Select_Item(cmbItems.Text);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print("P");
            txtBarCode.Focus();
        }

        private void btnPrintView_Click(object sender, EventArgs e)
        {           
            Print("V");
            txtBarCode.Focus();
        }

        private void Print(string print_type)
        {
            if (dtLabel.Rows.Count > 0)
            {
                //保存打印标签数据到临时表
                mo_id = lblMo_id.Text.Trim();
                goods_id = cmbItems.Text.Trim();
                qty = string.IsNullOrEmpty(txtQty.Text) ? 0 : int.Parse(txtQty.Text);
                weg = string.IsNullOrEmpty(txtNet_weiht.Text) ? 0 : decimal.Parse(txtNet_weiht.Text);
                weg_gross = string.IsNullOrEmpty(txtCross_weiht.Text) ? 0 : decimal.Parse(txtCross_weiht.Text);
                mo_group = lblMo_group.Text;
                carton_size = cmbCartonSize.Text.Trim();
                suit_flag = (!chkSuit.Checked) ? "0" : "1";

                dtReport.Clear();
                if(txtPrints.Text=="")
                {
                    txtPrints.Text="1";
                }
                int print_total= int.Parse(txtPrints.Text);
                if (print_total == 0)
                {
                    print_total = 1;
                }
                lstItem.Clear();
                if(chkSuit.Checked)
                {
                    for(int i = 0; i < dgvBom.Rows.Count; i++)
                    {
                        if (dgvBom.Rows[i].Cells["chkSelect"].Value.ToString() == "True")
                        {
                            lstItem.Add(dgvBom.Rows[i].Cells["goods_id1"].Value.ToString());
                        }
                    }
                }

                if (!clsPacking.SavePrintData(mo_id, goods_id, qty, weg, weg_gross, mo_group, print_total, carton_size, suit_flag, lstItem))
                {
                    MessageBox.Show("保存列印數據失败!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                for (int i = 0; i < print_total; i++)
                {                   
                    DataRow newRow = dtReport.NewRow();
                    newRow["it_customer"] = lblIt_customer.Text;
                    newRow["mo_id"] = lblMo_id.Text;
                    newRow["mo_id_barcode"] = lblMo_id_barcode.Text;
                    newRow["name_cust"] = lblCustomer.Text;
                    newRow["po_style"] = lblPO_style.Text;
                    newRow["id"] = lblOc_no.Text;
                    newRow["trim_code"] = lblCode.Text;
                    newRow["customer_color_id"] = lblCustomer_color_id.Text;
                    newRow["goods_id"] = lblGoods_id.Text;
                    newRow["goods_desc"] = rchGoods_desc.Text;
                    newRow["qty"] = txtQty.Text == "" ? "--" : txtQty.Text;
                    newRow["qty_unit"] = cmbQty.Text;
                    newRow["net_weiht"] = txtNet_weiht.Text == "" ? "--" : txtNet_weiht.Text;
                    newRow["net_unit"] = cmbNetUnit.Text;
                    newRow["cross_weiht"] = txtCross_weiht.Text == "" ? "--" : txtCross_weiht.Text;
                    newRow["cross_unit"] = cmbCrossUnit.Text;
                    newRow["brand_id"] = lblBrand_id.Text;
                    newRow["brand_name_custom"] = lblBrand_name.Text;
                    newRow["flag_both"] = chkBoth.Checked?"Y":"N";//紙箱正面,側面標簽列是否一起列印標識
                    newRow["division"] = lblDivision.Text;
                    dtReport.Rows.Add(newRow);
                }

                xrPackingLabel oRepot = new xrPackingLabel() { DataSource = dtReport };
                oRepot.CreateDocument();
                oRepot.PrintingSystem.ShowMarginsWarning = false;

                if (print_type == "P")
                {                
                    oRepot.Print();
                }
                else
                {                   
                    oRepot.ShowPreviewDialog();
                }
            }
            else
            {
                MessageBox.Show("沒有要列印的數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
     

        private void chkAutoPrint_Click(object sender, EventArgs e)
        {
            txtBarCode.Focus();
        }

        private void txtPrints_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)13)
            {
                txtBarCode.Focus();
            }
        }

        private void txtPrints_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPrints.Text))
            {
                int print_total = int.Parse(txtPrints.Text);
                if (print_total == 0)
                {
                    txtPrints.Text = "1";
                }
            }
            else
            {
                txtPrints.Text = "1";
            }
        }

        private void txtPrints_Click(object sender, EventArgs e)
        {
            txtPrints.SelectAll();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            Set_Number_Format(txtQty, e);
        }

        private void txtNet_weiht_KeyPress(object sender, KeyPressEventArgs e)
        {
            Set_Number_Format(txtNet_weiht, e);
        }

        private void txtCross_weiht_KeyPress(object sender, KeyPressEventArgs e)
        {
            Set_Number_Format(txtCross_weiht, e);
        }

        private void chkSuit_MouseUp(object sender, MouseEventArgs e)
        {
            dtBom.Clear();
            if (chkSuit.Checked)
            {
                pnlSuit.Visible = true;               
                DataRow dr;
                for (int i=0;i<dtLabel.Rows.Count;i++)
                {
                    dr = dtBom.NewRow();
                    dr["flag_select"] = false;
                    dr["goods_id"] = dtLabel.Rows[i]["goods_id"].ToString();
                    dr["primary_key"] = dtLabel.Rows[i]["primary_key"].ToString();
                    dr["goods_desc"] = dtLabel.Rows[i]["goods_desc"].ToString();                   
                    dtBom.Rows.Add(dr);
                }
            }
            else
            {
                pnlSuit.Visible = false;
            }                              
        }

        private void Set_Number_Format(TextBox obj,KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;

            //小数点的处理。
            if ((int)e.KeyChar == 46)      //小数点
            {
                if (obj.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(obj.Text, out oldf);
                    b2 = float.TryParse(obj.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void Get_Net_Weiht(string mo_id, string goods_id)
        {            
            DataTable dt = new DataTable();            
            SqlParameter[] paras = new SqlParameter[] 
            {
                new SqlParameter("@mo_id", mo_id),
                new SqlParameter("@goods_id",goods_id)
            };
            //上部門移交或倉庫轉倉到包裝（601）的数量和重量
            dt = clsPublicOfPad.ExecuteProcedure("usp_packing_get_weight", paras);
            if (dt.Rows.Count > 0)
            {
                txtQty.Text = dt.Rows[0]["qty"].ToString();
                txtNet_weiht.Text = dt.Rows[0]["net_weiht"].ToString();
            }
            else
            {
                txtQty.Text = "";
                txtNet_weiht.Text = "";
            }   
            txtCross_weiht.Text = "";
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            if (txtQty.Text != "")
            {
                Set_qty_Convert_to_weiht(lblMo_id.Text, cmbItems.Text, int.Parse(txtQty.Text));
            }
        }

        private void Set_qty_Convert_to_weiht(string mo_id, string goods_id, int qty_input)
        {
            if (string.IsNullOrEmpty(mo_id) || string.IsNullOrEmpty(goods_id))
            {
                return;
            }
            DataTable dt = new DataTable();
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@mo_id", mo_id),
                new SqlParameter("@goods_id",goods_id)
            };
            dt = clsPublicOfPad.ExecuteProcedure("usp_packing_get_weight", paras);
            
            if (dt.Rows.Count > 0)
            {
                string strWeg = dt.Rows[0]["net_weiht"].ToString();
                if(string.IsNullOrEmpty(strWeg))
                {
                    strWeg = "0.00";
                }
                float weiht = float.Parse(strWeg);
                string strQty = dt.Rows[0]["qty"].ToString();
                if (string.IsNullOrEmpty(strQty))
                {
                    strQty = "0";
                }
                int qty = int.Parse(strQty);
                if (qty == 0)
                {
                    qty = 1;
                }
                txtNet_weiht.Text = Math.Round((qty_input * weiht) / qty, 2).ToString();
            }
            else
                txtNet_weiht.Text = "";
        }   

        private void chkIsFinish_MouseUp(object sender, MouseEventArgs e)
        {
            Fill_Combox(dtLabel);                        
        }

        
    }
}
