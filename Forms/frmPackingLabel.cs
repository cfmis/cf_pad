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

        DataTable dtLabel = new DataTable();
        DataTable dtReport = new DataTable();
        public frmPackingLabel()
        {
            InitializeComponent();

            dtReport.Columns.Add("mo_id", typeof(String));
            dtReport.Columns.Add("mo_id_barcode", typeof(String));
            dtReport.Columns.Add("name_cust", typeof(String));
            dtReport.Columns.Add("po_style", typeof(String));
            dtReport.Columns.Add("id", typeof(String));
            dtReport.Columns.Add("trim_code", typeof(String));
            dtReport.Columns.Add("customer_color_id", typeof(String));
            dtReport.Columns.Add("goods_id", typeof(String));
            dtReport.Columns.Add("goods_desc", typeof(String));
            dtReport.Columns.Add("qty", typeof(String));
            dtReport.Columns.Add("qty_unit", typeof(String));
            dtReport.Columns.Add("net_weiht", typeof(String));
            dtReport.Columns.Add("net_unit", typeof(String));
            dtReport.Columns.Add("cross_weiht", typeof(String));
            dtReport.Columns.Add("cross_unit", typeof(String));
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
            cmbQty.Text = "PCS";
            cmbNetUnit.Text = "KG";
            cmbCrossUnit.Text = "KG";
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
                        new SqlParameter("@mo_id", strBarCode)  //txtBarCode.Text)
                    };
                    dtLabel = clsPublicOfPad.ExecuteProcedure("usp_packing_label", paras);
                    txtBarCode.Text = "";
                    txtPrints.Text = "1";//重新掃條碼將列印份數重置為1
                    if (dtLabel.Rows.Count > 0)
                    {
                        cmbItems.Text = dtLabel.Rows[0]["goods_id"].ToString();
                        Fill_Combox(dtLabel);
                        lblItem_total.Text = dtLabel.Rows.Count.ToString();
                                           
                        if (chkAutoPrint.Checked)
                        {
                            Print("P");
                        }
                        txtBarCode.Focus();
                    }
                    else
                    {
                        lblMo_id_barcode.Text = "";
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
                        return;
                    }                    
                    break;
            }
        }

        private void Fill_Combox(DataTable dt)
        {
            cmbItems.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbItems.Items.Add(dt.Rows[i]["goods_id"].ToString());
                }
                cmbItems.Text = dt.Rows[0]["goods_id"].ToString();
            }
            Select_Item(cmbItems.Text);              
        }

        private void Select_Item(string pGoods_id)
        {
            DataRow[] dr = dtLabel.Select(string.Format("goods_id='{0}'", pGoods_id));

            lblMo_id.Text = dr[0]["mo_id"].ToString();
            lblMo_id_barcode.Text = dr[0]["mo_id_barcode"].ToString();
            lblCustomer.Text = dr[0]["name_cust"].ToString();
            lblPO_style.Text = dr[0]["po_style"].ToString();
            lblOc_no.Text = dr[0]["id"].ToString();
            lblCode.Text = dr[0]["trim_code"].ToString();
            lblCustomer_color_id.Text = dr[0]["customer_color_id"].ToString();
            lblGoods_id.Text = dr[0]["goods_id"].ToString();
            rchGoods_desc.Text = dr[0]["goods_desc"].ToString();

            //取凈重
            Get_Net_Weiht(lblMo_id.Text, cmbItems.Text);
            cmbQty.Text = "PCS";
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
                for (int i = 0; i < print_total; i++)
                {
                    DataRow newRow = dtReport.NewRow();
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
            dt = clsPublicOfPad.ExecuteProcedure("usp_packing_get_weight", paras);
            if (dt.Rows.Count > 0)
            {
                txtNet_weiht.Text = dt.Rows[0]["net_weiht"].ToString();
            }
            else
                txtNet_weiht.Text = "";

            txtQty.Text = "";            
            txtCross_weiht.Text = "";
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            if (txtQty.Text != "")
            {
                Set_qty_Convert_to_weiht(lblMo_id.Text, cmbItems.Text, Int32.Parse(txtQty.Text));
            }
        }

        private void Set_qty_Convert_to_weiht(string mo_id, string goods_id, int qty_input)
        {
            if (string.IsNullOrEmpty(mo_id) || string.IsNullOrEmpty(goods_id))
                return;

            DataTable dt = new DataTable();
            SqlParameter[] paras = new SqlParameter[] 
            {
                new SqlParameter("@mo_id", mo_id),
                new SqlParameter("@goods_id",goods_id)
            };
            dt = clsPublicOfPad.ExecuteProcedure("usp_packing_get_weight", paras);
            
            if (dt.Rows.Count > 0)
            {
                float weiht = float.Parse(dt.Rows[0]["net_weiht"].ToString());
                int qty = Int32.Parse(dt.Rows[0]["qty"].ToString());
                txtNet_weiht.Text = Math.Round((qty_input * weiht) / qty, 2).ToString();
            }
            else
                txtNet_weiht.Text = "";
        }

     
     
    

       
    }
}
