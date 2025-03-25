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
    public partial class frmPacking : Form
    {
        string mo_id = "", goods_id = "", mo_group ="",carton_size="";
        int qty = 0;
        decimal weg = 0, weg_gross = 0;
        DataTable dtLabel = new DataTable();
        //DataTable dtGet_Str_Date = new DataTable();
        DataTable dtReport = new DataTable();


        public frmPacking()
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
            //dtReport.Columns.Add("net_weiht", typeof(String));
            //dtReport.Columns.Add("net_unit", typeof(String));
            //dtReport.Columns.Add("cross_weiht", typeof(String));
            //dtReport.Columns.Add("cross_unit", typeof(String));
            dtReport.Columns.Add("brand_id", typeof(string));
            dtReport.Columns.Add("brand_name", typeof(string));
            dtReport.Columns.Add("brand_name_custom", typeof(string));
            dtReport.Columns.Add("division", typeof(string));
        }

        private void frmPacking_Load(object sender, EventArgs e)
        {
            txtBarCode.Focus();
            //取當前服務器日期字串
            //dtGet_Str_Date = clsPublicOfPad.ExecuteSqlReturnDataTable("SELECT convert(varchar(10),GETDATE(),112) as str_date");
            //重量
            DataTable dtUnit = clsPublicOfGeo.ExecuteSqlReturnDataTable("SELECT id FROM cd_units WHERE kind='03'");       
            dtUnit = clsPublicOfGeo.ExecuteSqlReturnDataTable("SELECT id FROM cd_units WHERE kind='05'");
            SetComboxItem(dtUnit, cmbQty);
            cmbQty.Text = "PCS";    
       
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
                        new SqlParameter("@lang", "EN")
                        //txtBarCode.Text)
                    };
                    dtLabel = clsPublicOfPad.ExecuteProcedure("usp_packing_label_new", paras);
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
                        lblgoods_id_f0.Text = "";
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
                        txtOrder_qty.Text = "";                        
                        txtSend_qty.Text = "";

                        lblBrand_id.Text = "";
                        lblBrand_name.Text = "";
                        lblDivision.Text = "";
                        txtQty1.Text = "";
                        txtNet_weiht.Text = "";
                        lblMo_group.Text = "";
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
            lblIt_customer.Text = dr[0]["it_customer"].ToString();
            lblMo_id.Text = dr[0]["mo_id"].ToString();
            lblMo_id_barcode.Text = dr[0]["mo_id_barcode"].ToString();
            lblCustomer.Text = dr[0]["name_cust"].ToString();
            lblPO_style.Text = dr[0]["po_style"].ToString();
            lblOc_no.Text = dr[0]["id"].ToString();
            lblCode.Text = dr[0]["trim_code"].ToString();
            lblCustomer_color_id.Text = dr[0]["customer_color_id"].ToString();
            lblGoods_id.Text = dr[0]["goods_id"].ToString();
            rchGoods_desc.Text = dr[0]["goods_desc"].ToString();
            lblgoods_id_f0.Text = dr[0]["goods_id_f0"].ToString();
            lblMo_group.Text = dr[0]["mo_group"].ToString();

            //取訂單數量
            Get_Order_Qty();
            //查找已交到包装的数量和重量2025/03/11 allen
            Get_Net_Weiht(lblMo_id.Text, lblgoods_id_f0.Text);

            cmbQty.Text = "PCS";
            //cmbNetUnit.Text = "KG";
            //cmbCrossUnit.Text = "KG";

            lblBrand_id.Text = dr[0]["brand_id"].ToString();
            lblBrand_name.Text = dr[0]["brand_name_custom"].ToString();
            lblDivision.Text = dr[0]["division"].ToString();
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
                goods_id = lblgoods_id_f0.Text.Trim();
                qty = string.IsNullOrEmpty(txtQty1.Text) ? 0 : int.Parse(txtQty1.Text);
                weg = string.IsNullOrEmpty(txtNet_weiht.Text) ? 0 : decimal.Parse(txtNet_weiht.Text);
                weg_gross = 0;
                mo_group = lblMo_group.Text;               

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

                if (!clsPacking.SavePrintData(mo_id, goods_id, qty, weg, weg_gross, mo_group, print_total,carton_size))
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
                    newRow["brand_id"] =lblBrand_id.Text;
                    newRow["brand_name_custom"] = lblBrand_name.Text;
                    newRow["division"] = lblDivision.Text;
                    dtReport.Rows.Add(newRow);
                }

                xrPacking oRepot = new xrPacking() { DataSource = dtReport };
                oRepot.CreateDocument();
                oRepot.PrintingSystem.ShowMarginsWarning = false;

                if (print_type == "P")
                {
                    oRepot.Print();
                    /* cancel 2025/03/12 allen
                    string sql_f = string.Format(@"Select '1' FROM packing_print_list WHERE mo_id='{0}' and print_date='{1}' and print_qty='{2}'", 
                        lblMo_id.Text, dtGet_Str_Date.Rows[0]["str_date"], txtQty.Text);
                    DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(sql_f);
                    if (dt.Rows.Count > 0)
                    {
                        if (MessageBox.Show("此頁數當前走貨數量已有過列印記錄，是否繼續列印?", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            oRepot.Print();
                        }
                    }
                    else
                    {
                        //oRepot.Print();
                        Save_print_info();
                    }
                    */
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
                    b2 = float.TryParse(obj.Text + e.KeyChar, out f);
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

        //private void Save_print_info()
        //{
        //    string sql_i = @"Insert into packing_print_list(mo_id,print_date,print_qty,crusr) Values(@mo_id,@print_date,@print_qty,@crusr)";            
        //    SqlConnection myCon  = new SqlConnection(DBUtility.dgcf_pad_connectionString);
        //    myCon.Open();            
        //    try
        //    {
        //        using (SqlCommand myCommand = new SqlCommand() { Connection = myCon })
        //        {
        //            myCommand.Parameters.Clear();
        //            myCommand.CommandText = sql_i;
        //            myCommand.Parameters.AddWithValue("@mo_id", lblMo_id.Text);
        //            myCommand.Parameters.AddWithValue("@print_date", dtGet_Str_Date.Rows[0]["str_date"].ToString());
        //            myCommand.Parameters.AddWithValue("@print_qty", txtQty.Text);
        //            myCommand.Parameters.AddWithValue("@crusr", DBUtility._user_id);
        //            myCommand.ExecuteNonQuery();                                
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        myCon.Close();
        //        myCon.Dispose();
        //    }
        //    txtBarCode.Focus();
        //}

        private void Get_Order_Qty()
        {
            string strSql = string.Format(
            @"Select Convert(int,B.order_qty*SS.rate) AS order_qty From so_order_manage A with(nolock)
            INNER JOIN so_order_details B with(nolock) ON A.within_code =B.within_code AND A.id=B.id AND A.ver=B.ver 
            Left outer join (select unit_code,rate from it_coding with(nolock) where within_code='0000' and id='*') SS 
	            ON B.goods_unit=SS.unit_code
            WHERE A.within_code='0000' AND A.state not IN ('2','V') AND B.mo_id = '{0}'", lblMo_id.Text);
            DataTable dt1 = clsPublicOfGeo.ExecuteSqlReturnDataTable(strSql);
            int order_qty,send_qty,qty;
            if (dt1.Rows.Count > 0)
            {
                txtOrder_qty.Text = dt1.Rows[0]["order_qty"].ToString();
                order_qty = int.Parse(dt1.Rows[0]["order_qty"].ToString());
            }
            else
            {
                txtOrder_qty.Text ="0";
                order_qty = 0;
            }

            //已走货数量
            //strSql =string.Format(@"Select Sum(convert(int,print_qty)) as print_qty FROM packing_print_list with(nolock) WHERE mo_id='{0}'",lblMo_id.Text);
            strSql = string.Format(@"Select Sum(qty) as print_qty FROM packing_mo_label with(nolock) WHERE mo_id='{0}'", lblMo_id.Text);
            DataTable dt2 = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            if (dt2.Rows.Count > 0)
            {
                txtSend_qty.Text = dt2.Rows[0]["print_qty"].ToString();
                if (txtSend_qty.Text != "")
                    send_qty = int.Parse(dt2.Rows[0]["print_qty"].ToString());
                else
                {
                    txtSend_qty.Text = "0";
                    send_qty = 0;
                }
            }
            else
            {
                txtSend_qty.Text = "0";
                send_qty = 0;
            }
            qty = order_qty - send_qty;
            if (qty < 0)
                txtQty.Text = "0";
            else
                txtQty.Text = qty.ToString();
        }   


        private void btnPint_List_Click(object sender, EventArgs e)
        {
            if (lblMo_id.Text != "")
            {
                using (frmPackingList ofrm = new frmPackingList(lblMo_id.Text))
                {
                    ofrm.ShowDialog();                  
                }
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
                txtQty1.Text = dt.Rows[0]["qty"].ToString();
                txtNet_weiht.Text = dt.Rows[0]["net_weiht"].ToString();
            }
            else
            {
                txtQty1.Text = "";
                txtNet_weiht.Text = "";
            }            
        }

    }
}
