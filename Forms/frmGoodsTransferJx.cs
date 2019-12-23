using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CFPublic;
using cf_pad.CLS;
using cf_pad.MDL;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Drawing.Imaging;


namespace cf_pad.Forms
{
    public partial class frmGoodsTransferJx : Form
    {
        private string userId = DBUtility._user_id;
        //BardCodeHooK BarCode = new BardCodeHooK();
        private int BarCodeMinLength = 4;//這個為測試用，如果是正常的制單條碼，長度為10
        //private string search_start_time = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        public frmGoodsTransferJx()
        {
            InitializeComponent();
            //BarCode.BarCodeEvent += new BardCodeHooK.BardCodeDeletegate(BarCode_BarCodeEvent);
        }

        //private delegate void ShowInfoDelegate(BardCodeHooK.BarCodes barCode);

        //private void ShowInfo(BardCodeHooK.BarCodes barCode)
        //{
        //    if (this.InvokeRequired)
        //    {
        //        this.BeginInvoke(new ShowInfoDelegate(ShowInfo), new object[] { barCode });
        //    }
        //    else
        //    {
        //        //textBox1.Text = barCode.KeyName;
        //        //textBox2.Text = barCode.VirtKey.ToString();
        //        //textBox3.Text = barCode.ScanCode.ToString();
        //        //textBox4.Text = barCode.Ascll.ToString();
        //        //textBox5.Text = barCode.Chr.ToString();
        //        string strBarCode1 = "";
        //        strBarCode1 = barCode.IsValid ? barCode.BarCode : "";//是否为扫描枪输入，如果为true则是 否则为键盘输入
        //        strBarCode1 = strBarCode1.Replace("\r\n", "").Replace("'", "").Replace("\0", "").Replace("\r", "");

        //        //textBox7.Text += barCode.KeyName;
        //        if (strBarCode1.Length > BarCodeMinLength)
        //        {
        //            txtBarCode.Text = strBarCode1.Trim().ToUpper();

        //            //MessageBox.Show(strBarCode);
        //            if (strBarCode1.Length == 5)//如果掃描的是工號// && barcode.Substring(0, 5) == "00000"
        //            {
        //                txtBarCode.Text = "";
        //             }
        //            else
        //            {
        //                doBarCode();
        //                txtBarCode.Focus();
        //                //MessageBox.Show(barCode.IsValid.ToString());
        //            }
        //        }
        //    }
        //}

        //void BarCode_BarCodeEvent(BardCodeHooK.BarCodes barCode)
        //{

        //    ShowInfo(barCode);
        //}

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBarCode.Text.Trim().Length > BarCodeMinLength)
                    doBarCode();
            }
        }

        private void doBarCode()
        {
            string barcode = "";
            //if (txtBarCode.Text.Trim().Length > 13)
            //    barcode = txtBarCode.Text.Substring(0, 13);
            //else
            //    barcode = txtBarCode.Text.Trim();
            barcode = txtBarCode.Text.Trim();
            DataTable dtBarCode = clsPublicOfPad.BarCodeToItem(barcode);
            txtBarCode.Text = "";
            if (dtBarCode.Rows.Count > 0)
            {
                string barcode_type = dtBarCode.Rows[0]["barcode_type"].ToString();
                if (barcode_type == "2")//從生產計劃中提取的條形碼
                {
                    cleanTextBox();
                    txtMo_id.Text = dtBarCode.Rows[0]["mo_id"].ToString();
                    txtGoods_id.Text = dtBarCode.Rows[0]["goods_id"].ToString();
                    txtWipId.Text = dtBarCode.Rows[0]["wp_id"].ToString();
                    //cmbPrdDepFind.SelectedValue = cmbPrdDep.SelectedValue.ToString().Trim();
                    getMoDataSource();//從生產表或排期表或流程中獲取記錄
                    getMoProduct();//從生產記錄中提取生產數量及重量
                    showItemPic(txtGoods_id.Text);//顯示圖片
                    findData((cmbPrdDep.SelectedValue != null ? cmbPrdDep.SelectedValue.ToString().Trim() : ""), txtGoods_id.Text, txtMo_id.Text);
                    if (dgvDetails.Rows.Count == 0)
                    {
                        txtPackNum.Text = "1";
                        dteTransferDate.Text = clsUtility.changeDateFormat(DateTime.Now);
                    }
                    else
                        fillData(0);
                }
            }
            //MessageBox.Show(barcode);

            //txtMatItem.Focus();
            //}
            //else
            //    return;


            //break;
        }

        private void findData(string Prd_dep, string Prd_item, string Prd_mo)
        {
            string strSql = "Select a.*,b.name AS Prd_item_cdesc,Convert(Varchar(20),Crtim,120) AS crtim_str" +
                " From product_transfer_jx_details a" +
                " Left Join dgcf_db.dbo.geo_it_goods b ON a.Prd_item COLLATE chinese_taiwan_stroke_CI_AS=b.id" +
                " Where a.Prd_dep='" + Prd_dep + "' AND a.Prd_item='" + Prd_item + "' AND a.Prd_mo='" + Prd_mo + "'";
            strSql += " Order By a.crtim DESC";
            DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            dgvDetails.DataSource = dt;
        }
        private void cleanTextBox()
        {
            txtPrd_id.Text = "";
            txtMo_id.Text = "";
            //cmbPrdDep.SelectedValue = "";
            txtWipId.Text = "";
            txtTo_dep.Text = "";
            txtGoods_id.Text = "";
            txtGoods_name.Text = "";
            txtQty.Text = "";
            txtWeg.Text = "";
            dteTransferDate.Text = "";
            txtPackNum.Text = "";
            lblShowMsg.Text = "信息提示";
            picItem.Image = null;
            //rdgSent.Checked = false;
            //rdgReceive.Checked = false;
        }
        private void getMoDataSource()
        {
            //從流程中提取物料描述、原料描述
            DataTable dtItem = clsProductionSchedule.GetMo_dataById(txtMo_id.Text.Trim(), txtWipId.Text.Trim(), txtGoods_id.Text);
            DataRow drItem = dtItem.Rows[0];
            txtMo_id.Text = drItem["mo_id"].ToString();
            txtQty.Text = drItem["prod_qty"].ToString();
            txtGoods_id.Text = drItem["goods_id"].ToString();
            txtGoods_name.Text = drItem["goods_name"].ToString();
            txtTo_dep.Text = drItem["next_wp_id"].ToString();
        }

        private void getMoProduct()
        {
            string strSql = "";
           // if (rdgSent.Checked == true)//如果是發貨的，默認從生產記錄中帶出數量和重量
           // {
           //     strSql = "Select prd_work_type,prd_qty AS Transfer_qty,prd_weg AS Transfer_weg,prd_start_time,prd_end_time " +
           //         " From product_records" +
           //         " Where Prd_dep='" + cmbPrdDep.SelectedValue.ToString().Trim() + "' AND Prd_mo='" + txtMo_id.Text + "' AND Prd_item='" + txtGoods_id.Text + "' AND prd_work_type='A02' "
           //         + " Order By Prd_date DESC";
           // }
           // else//如果是收貨的，帶出最後一次發貨的數量和重量
           // {
           //     strSql = "Select a.Transfer_qty,a.Transfer_weg " +
           //     " From product_transfer_jx_details a" +
           //     " Where a.Prd_dep='" + cmbPrdDep.SelectedValue.ToString().Trim() + "' AND a.Prd_item='" + txtGoods_id.Text + "' AND a.Prd_mo='" + txtMo_id.Text + "'";
           //     strSql += " Order By a.crtim DESC";
           //}
            if (rdgReceive.Checked == true)//如果是收貨的，帶出最後一次發貨的數量和重量
            {
                strSql = "Select a.Transfer_qty,a.Transfer_weg " +
                " From product_transfer_jx_details a" +
                " Where a.Prd_dep='" + cmbPrdDep.SelectedValue.ToString().Trim() + "' AND a.Prd_item='" + txtGoods_id.Text + "' AND a.Prd_mo='" + txtMo_id.Text + "'";
                strSql += " Order By a.crtim DESC";
                DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
                if (dt.Rows.Count > 0)
                {
                    txtQty.Text = dt.Rows[0]["Transfer_qty"].ToString();
                    txtWeg.Text = dt.Rows[0]["Transfer_weg"].ToString();
                }
            }
        }

        private void showItemPic(string item)
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

        private void frmGoodsTransferJx_Load(object sender, EventArgs e)
        {
            //BarCode.Start();
            Font a = new Font("GB2312", 12);//GB2312为字体名称，1为字体大小dataGridView1.Font = a;
            dgvDetails.Font = a;
            dgvDetails.AutoGenerateColumns = false;
            dteSentDate.Text = clsUtility.changeDateFormat(DateTime.Now.AddDays(-1));
            InitComBoxs();
            txtBarCode.Focus();
            this.reportViewer1.RefreshReport();
        }
        private void InitComBoxs()
        {
            //初始化生產部門
            DataTable dtPrdDep = clsProductionSchedule.GetAllPrd_dept();
            cmbPrdDep.DataSource = dtPrdDep;
            cmbPrdDep.DisplayMember = "int9loc";
            cmbPrdDep.ValueMember = "int9loc";
            cmbPrdDepFind.DataSource = dtPrdDep;
            cmbPrdDepFind.DisplayMember = "int9loc";
            cmbPrdDepFind.ValueMember = "int9loc";
            string userid_part = userId.Substring(0, 3);
            if (userid_part == "BUT")
            {
                cmbPrdDep.SelectedValue = "102";
            }
            else
            {
                if (userid_part == "ALY")
                    cmbPrdDep.SelectedValue = "302";
                else
                {
                    if (userid_part == "BLK")
                        cmbPrdDep.SelectedValue = "105";
                    else
                    {
                        if (userid_part == "BLP")
                            cmbPrdDep.SelectedValue = "107";
                    }
                }
            }
            if (userId == "BUK01")
                cmbPrdDep.SelectedValue = "202";
            else
            {
                if (userId == "BUK02")
                    cmbPrdDep.SelectedValue = "203";
            }


        }
        private void btnConf_Click(object sender, EventArgs e)
        {
            save();
        }
        private void save()
        {
            if (!checkRecord())
            {
                return;
            }
            int Result = 0;
            product_transfer_jx_details objModel = new product_transfer_jx_details();
            objModel.Prd_dep = cmbPrdDep.SelectedValue.ToString().Trim();
            objModel.Transfer_date = dteTransferDate.Text;
            objModel.sentDate = dteSentDate.Text;
            objModel.Prd_item = txtGoods_id.Text;
            objModel.Prd_mo = txtMo_id.Text;
            objModel.Transfer_flag = 0;
            if (rdgReceive.Checked == true)
                objModel.Transfer_flag = 1;
            objModel.Transfer_qty = txtQty.Text.Trim() != "" ? Convert.ToDecimal(txtQty.Text.Trim()) : 0;
            objModel.Transfer_weg = txtWeg.Text.Trim() != "" ? Convert.ToDecimal(txtWeg.Text.Trim()) : 0;
            objModel.packNum = txtPackNum.Text.Trim() != "" ? int.Parse(txtPackNum.Text.Trim()) : 0;
            objModel.wipId = txtWipId.Text;
            objModel.To_dep = txtTo_dep.Text;
            objModel.Crusr = userId;
            objModel.Crtim = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            Result = clsProductionSchedule.UpdateGoodsTransferJx(objModel);
            if (Result > 0)
                lblShowMsg.Text = "儲存成功!";
            else
                MessageBox.Show("儲存記錄失敗!");
            findData(objModel.Prd_dep, objModel.Prd_item, objModel.Prd_mo);
            txtBarCode.Focus();
        }

        private bool checkRecord()
        {
            bool result = true;
            string returnMsg = "";
            if (rdgSent.Checked == false && rdgReceive.Checked == false)
            {
                MessageBox.Show("請選擇收貨或發貨類型!");
                return false;
            }
            if (cmbPrdDep.SelectedValue == null || cmbPrdDep.SelectedValue.ToString().Trim() == "")
            {
                MessageBox.Show("部門不能為空!");
                cmbPrdDep.Focus();
                return false;
            }
            returnMsg = clsValidRule.validInputInt(txtQty.Text);
            if ( returnMsg!= "")
            {
                MessageBox.Show(returnMsg);
                txtQty.Focus();
                return false;
            }
            returnMsg = clsValidRule.validInputInt(txtPackNum.Text);
            if (returnMsg != "")
            {
                MessageBox.Show(returnMsg);
                txtPackNum.Focus();
                return false;
            };
            returnMsg = clsValidRule.validInputNumeric((txtWeg.Text));
            if (returnMsg != "")
            {
                MessageBox.Show(returnMsg);
                txtWeg.Focus();
                return false;
            }
            
            int Transfer_flag = 0;
            if (rdgReceive.Checked == true)
                Transfer_flag = 1;
            if (txtPrd_id.Text.Trim() != "")
            {
                DataTable dt = clsProductionSchedule.CheckGoodsTransferJx(cmbPrdDep.SelectedValue.ToString().Trim(), txtGoods_id.Text, txtMo_id.Text, Transfer_flag);
                if (dt.Rows.Count > 0)
                {
                    //if (MessageBox.Show("已存在一筆記錄,是否重複儲存?", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                    MessageBox.Show("已存在一筆記錄,若要重複收、發貨，請先點繫多批次!");
                    result = false;
                }
            }
            return result;
        }
        private DataTable checkStore(string Prd_dep, string Prd_item, string Prd_mo)
        {
            string strSql = "Select * From product_transfer_jx_summary Where Prd_dep='" + Prd_dep + "' AND Prd_item='" + Prd_item + "' AND Prd_mo='" + Prd_mo + "'";
            DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            return dt;
        }
        private void fillData(int row)
        {
            if (row < 0)
                return;
            DataGridViewRow dr = dgvDetails.Rows[row];
            txtPrd_id.Text = dr.Cells["colPrd_id"].Value.ToString();
            dteTransferDate.Text = dr.Cells["colTransfer_date"].Value.ToString();
            cmbPrdDep.SelectedValue = dr.Cells["colPrd_dep"].Value.ToString();
            txtMo_id.Text = dr.Cells["colPrd_mo"].Value.ToString();
            txtGoods_id.Text = dr.Cells["colPrd_item"].Value.ToString();
            txtGoods_name.Text = dr.Cells["colPrd_item_cdesc"].Value.ToString();
            txtQty.Text = dr.Cells["colTransfer_qty"].Value.ToString();
            txtWeg.Text = dr.Cells["colTransfer_weg"].Value.ToString();
            txtWipId.Text = dr.Cells["colWipId"].Value.ToString();
            txtTo_dep.Text = dr.Cells["colTo_dep"].Value.ToString();
            txtPackNum.Text = dr.Cells["colPack_num"].Value.ToString();
            rdgSent.Checked = false;
            rdgReceive.Checked = false;
            if (Convert.ToInt32(dr.Cells["colTransfer_flag"].Value.ToString()) == 1)
                rdgReceive.Checked = true;
            else
                rdgSent.Checked = true;
            showItemPic(txtGoods_id.Text);//顯示圖片
            txtBarCode.Focus();
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
                return;
            fillData(e.RowIndex);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete();
        }
        private void delete()
        {
            if (txtPrd_id.Text.Trim() == "")
            {
                MessageBox.Show("沒有刪除的記錄!");
                return;
            }
            if (MessageBox.Show("是否確定刪除該筆記錄?", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                return;
            int Prd_id = Convert.ToInt32(txtPrd_id.Text);
            string strSql = "";
            string Prd_dep, Prd_mo, Prd_item, Transfer_date;
            decimal Transfer_qty = 0, Transfer_weg = 0;
            decimal In_qty = 0, In_weg = 0;
            decimal Out_qty = 0, Out_weg = 0;
            string In_date = "", Out_date = "";
            int Transfer_flag = 0;
            int result = 0;
            if (rdgReceive.Checked == true)
                Transfer_flag = 1;
            string Crusr = DBUtility._user_id;
            string Crtim = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            Transfer_date = dteTransferDate.Text;
            Prd_dep = cmbPrdDep.SelectedValue.ToString().Trim();
            Prd_item = txtGoods_id.Text;
            Prd_mo = txtMo_id.Text;
            Transfer_qty = txtQty.Text.Trim() != "" ? Convert.ToDecimal(txtQty.Text.Trim()) : 0;
            Transfer_weg = txtWeg.Text.Trim() != "" ? Convert.ToDecimal(txtWeg.Text.Trim()) : 0;
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            strSql += string.Format(@"Delete From product_transfer_jx_details Where Prd_id='{0}'"
                , Prd_id);

            DataTable dtStore = checkStore(Prd_dep, Prd_item, Prd_mo);
            if (dtStore.Rows.Count == 0)
            {
            }
            else
            {
                DataRow dr = dtStore.Rows[0];
                Out_date = dr["Out_date"].ToString();
                In_date = dr["In_date"].ToString();
                In_weg = dr["In_weg"].ToString() != "" ? Convert.ToDecimal(dr["In_weg"].ToString()) : 0;
                In_qty = dr["In_qty"].ToString() != "" ? Convert.ToDecimal(dr["In_qty"].ToString()) : 0;
                Out_weg = dr["Out_weg"].ToString() != "" ? Convert.ToDecimal(dr["Out_weg"].ToString()) : 0;
                Out_qty = dr["Out_qty"].ToString() != "" ? Convert.ToDecimal(dr["Out_qty"].ToString()) : 0;
                if (Transfer_flag == 0)
                {
                    Out_date = "1900/01/01";
                    Out_qty = Out_qty - Transfer_qty;
                    Out_weg = Out_weg - Transfer_weg;
                }
                else
                {
                    In_date = "1900/01/01";
                    In_qty = In_qty - Transfer_qty;
                    In_weg = In_weg - Transfer_weg;
                }
                strSql += string.Format(@"Update product_transfer_jx_summary Set In_qty='{0}',In_weg='{1}',Out_qty='{2}',Out_weg='{3}',In_date='{4}',Out_date='{5}',Crusr='{6}',Crtim='{7}'" +
                " Where Prd_dep='{8}' And Prd_item='{9}' And Prd_mo='{10}'"
                , In_qty, In_weg, Out_qty, Out_weg, In_date, Out_date, Crusr, Crtim, Prd_dep, Prd_item, Prd_mo);
            }

            strSql += string.Format(@" COMMIT TRANSACTION ");

            result = clsPublicOfPad.ExecuteSqlUpdate(strSql);
            cleanTextBox();
            rdgSent.Checked = false;
            rdgReceive.Checked = false;
            findData(Prd_dep, Prd_item, Prd_mo);
            txtBarCode.Focus();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (btnDetails.Text == "瀏覽(&B)")
            {
                tabControl1.SelectedIndex = 1;
                btnDetails.Text = "編輯(&B)";
                dteTransferDateFind.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
                dteTransferDateFind.Focus();
            }
            else
            {
                btnDetails.Text = "瀏覽(&B)";
                tabControl1.SelectedIndex = 0;
                txtBarCode.Focus();
            }
            
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (cmbPrdDepFind.SelectedValue.ToString().Trim() == "")
            {
                MessageBox.Show("請輸入查詢部門!");
                cmbPrdDepFind.Focus();
                return;
            }
            string strSql = "Select a.*,b.name AS Prd_item_cdesc,Convert(Varchar(20),Crtim,120) AS crtim_str" +
                " From product_transfer_jx_details a" +
                " Left Join dgcf_db.dbo.geo_it_goods b ON a.Prd_item COLLATE chinese_taiwan_stroke_CI_AS=b.id" +
                " Where a.Prd_dep='" + cmbPrdDepFind.SelectedValue.ToString().Trim() + "'";
            if (dteTransferDateFind.Text.Trim() != "/  /")
                strSql += " AND a.Transfer_date='" + dteTransferDateFind.Text.Trim() + "'";
            if (txtMo_id_f.Text.Trim() != "")
                strSql += " AND a.Prd_mo Like '" + "%" + txtMo_id_f.Text.Trim() + "%" + "'";
            int Transfer_flag = 2;
            if (rdgSent_f.Checked == true)
                Transfer_flag = 0;
            else if (rdgReceive_f.Checked == true)
                Transfer_flag = 1;
            if (Transfer_flag != 2)
                strSql += " AND a.Transfer_flag='" + Transfer_flag + "'";
            strSql += " Order By a.crtim DESC";
            DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("沒有找到符合條件的記錄!");
                return;
            }
            dgvDetails.DataSource = dt;
            btnDetails.Text = "瀏覽(&B)";
            tabControl1.SelectedIndex = 0;
            txtBarCode.Focus();
        }

        private void rdgSent_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            lblDat.Text = "發貨日期";
            txtBarCode.Focus();
        }

        private void rdgReceive_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            lblDat.Text = "收貨日期";
            txtBarCode.Focus();
        }

        private void txtWeg_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput(); 
        }

        private void txtQty_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput(); 
        }

        private void btnMutRec_Click(object sender, EventArgs e)
        {
            if (rdgReceive.Checked == true)
                panel6.Visible = true;
            if (rdgSent.Checked == true)
                panel6.Visible = false;
            txtPrd_id.Text = "";
            txtQty.Text = "";
            txtWeg.Text = "";
            txtPackNum.Text = "1";
            dteTransferDate.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
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
        

        private DataTable getPrintData()
        {
            string prdDep = cmbPrdDepFind.SelectedValue.ToString();
            string dateFrom = dteTransferDateFind.Text;
            string transferFlag = "";
            if (rdgSent_f.Checked == true)
                transferFlag = "0";
            if (rdgReceive_f.Checked == true)
                transferFlag = "1";
            string strSql = "Select a.prd_dep,d.dep_cdesc AS prd_dep_cdesc,a.prd_mo,a.prd_item,b.name AS prd_item_cdesc" +
                    ",a.transfer_qty,a.transfer_weg,a.wip_id" +
                    ",a.transfer_date,c.flag_desc,a.to_dep,e.dep_cdesc AS to_dep_cdesc " +
                    " FROM product_transfer_jx_details a" +
                    " LEFT JOIN dgcf_db.dbo.geo_it_goods b ON a.prd_item=b.id COLLATE chinese_taiwan_stroke_CI_AS" +
                    " LEFT JOIN dgcf_db.dbo.bs_flag_desc c ON a.transfer_flag=c.flag_id COLLATE chinese_taiwan_stroke_CI_AS" +
                    " LEFT JOIN dgcf_db.dbo.bs_dep d ON a.wip_id=d.dep_id COLLATE chinese_taiwan_stroke_CI_AS" +
                    " LEFT JOIN dgcf_db.dbo.bs_dep e ON a.to_dep=e.dep_id COLLATE chinese_taiwan_stroke_CI_AS" +
                    " WHERE c.doc_type='goods_transfer_jx'";
            if (prdDep != "")
                strSql += " AND a.prd_dep='" + prdDep + "'";
            if (dateFrom != "")
                strSql += " AND a.Transfer_date='" + dateFrom + "'";
            if (transferFlag.Trim() == "0" || transferFlag.Trim() == "1")
                strSql += " AND a.Transfer_flag='" + transferFlag + "'";
            strSql += " ORDER BY a.prd_dep,a.Transfer_flag,a.transfer_date,a.prd_item,a.prd_mo";
            DataTable dtPrint = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            
            return dtPrint;
        }

        private void btnGenReport_Click(object sender, EventArgs e)
        {
            DataTable dtPrint = getPrintData();
            if (dtPrint.Rows.Count == 0)
            {
                MessageBox.Show("沒有找到符合條件的記錄!");
                return;
            }

            //Run(dtPrint);
            //return;
            string strReportPath = "";
            //if (Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\") > 0)
            //{
            //    strReportPath = Application.StartupPath;
            //    strReportPath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0,
            //        Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            //}
            //else
            //    strReportPath = Application.StartupPath;
            strReportPath = Application.StartupPath;
            //MessageBox.Show(strReportPath);
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            string fileName = strReportPath + @"\Reports\" + "rptGoodsTransferJx.rdlc";
            //MessageBox.Show(fileName);
            this.reportViewer1.LocalReport.ReportPath = fileName;
            this.reportViewer1.LocalReport.DataSources.Clear();
            //向報表傳遞多個參數
            List<ReportParameter> para1 = new List<ReportParameter>();            //这里是添加两个字段
            para1.Add(new ReportParameter("userId", userId));
            reportViewer1.LocalReport.SetParameters(para1);
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DSDgcf_pad", dtPrint));
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            //reportViewer1.PrintDialog();
            this.reportViewer1.RefreshReport();
            //return;
            //this.reportViewer1.Reset();
            ////this.ReportViewer1.LocalReport.Dispose();
            //reportViewer1.LocalReport.DataSources.Clear();
            ////this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\rptGoodsTransferJx.rdlc";//"rptGoodsTransferJx.rdlc";
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = @"\rptGoodsTransferJx.rdlc";
            //ReportDataSource rds = new ReportDataSource("DSDgcf_pad", dtPrint);
            ////this.ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DSDgcf_pad", dtPrint));
            ////ReportViewer1.LocalReport.DataSources.Add(
            ////new Microsoft.Reporting.WebForms.ReportDataSource("DSDgcf_pad", dtPrint));

            ////向報表傳遞多個參數
            //List<ReportParameter> para = new List<ReportParameter>();            //这里是添加两个字段
            //para.Add(new ReportParameter("userId", userId));
            ////para.Add(new ReportParameter("userName", "aaa"));
            ////reportViewer1.LocalReport.SetParameters(para);
            //reportViewer1.LocalReport.DataSources.Add(rds);
            ////this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            ////this.reportViewer1.ZoomPercent = 100;
            ////reportViewer1.LocalReport.Refresh();
            //reportViewer1.RefreshReport();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            reportViewer1.PrintDialog();
        }


    }
}
