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
using System.IO;
using DevExpress.XtraReports.UI;

namespace cf_pad.Forms
{
    public partial class frmIpqcWeiht : Form
    {

        DataTable dtReport = new DataTable();
        DataTable dtFind = new DataTable();
        public bool blPermission =false;
        public frmIpqcWeiht()
        {
            InitializeComponent();
                 
        }

        private void frmIpqcWeiht_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtReport.Dispose();
        }

        private void frmIpqcWeiht_Load(object sender, EventArgs e)
        {
            txtBarCode.Focus();
            mskDat1.Text = DateTime.Now.ToString("yyyy/MM/dd");
            mskDat2.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
           
            //FQC組別下的用戶才可以保存、刪除
           string sql=string.Format(@"SELECT user_id FROM DGERP2.cferp.dbo.sys_user WHERE user_id='{0}' and group_id='FQC'", DBUtility._user_id);
           DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(sql);
           if (dt.Rows.Count > 0 || DBUtility._user_id=="ADMIN" )
               blPermission = true;
           else
               blPermission = false;
           dt.Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    string strmo = txtBarCode.Text;
                    if (strmo.Length > 9)
                    {
                        strmo = strmo.Substring(0, 9);
                    }
                    if (string.IsNullOrEmpty(strmo))
                    {
                        dtReport.Clear();
                        return;
                    }
                    txtMo_id.Text = strmo;
                    txtID.Text = "";
                    btnDel.Enabled = false;
                    Set_Dropbox_Items(strmo);

                    txtBarCode.Text = "";                   
                    if (dtReport.Rows.Count > 0)
                    {                        
                        txtBarCode.Focus();
                        txtGoods_id.Text = dtReport.Rows[0]["goods_id"].ToString();
                        txtGoods_name.Text = dtReport.Rows[0]["goods_name"].ToString();
                        txtQty_order.Text = dtReport.Rows[0]["order_qty"].ToString();
                        txtQty_check.Text = "";
                        txtQty_packing.Text = "";
                        txtQty_differ.Text = "";
                        txtWeiht_check.Text = "";
                        txtLable_no.Text = "";
                        txtRemark.Text = "";
                    }
                    else
                    {
                        dtReport.Clear();
                        txtMo_id.Text = "";
                        txtID.Text = "";
                        txtGoods_id.Text = "";
                        txtGoods_name.Text = "";
                        txtQty_order.Text = "";
                        txtQty_check.Text = "";
                        txtQty_packing.Text = "";                       
                        txtQty_differ.Text = "";
                        txtWeiht_check.Text = "";                      
                        txtLable_no.Text = "";
                        txtRemark.Text = "";
                        return;
                    }                   

                    break;
            }
        }

        private void Set_Dropbox_Items(string strmo)
        {
            string sql = string.Format(
                   @"SELECT B.goods_id,C.name AS goods_name,B.primary_key,CONVERT(int,A.order_qty*S.rate) as order_qty,
                       dbo.Fn_get_picture_name('0000',B.goods_id,'out') as artwork
                    FROM so_order_details A with(nolock),so_order_bom B with(nolock),it_goods C with(nolock),
                    (SELECT within_code,unit_code,rate FROM it_coding with(nolock) WHERE within_code ='0000' and id ='*' and basic_unit = 'PCS') S
                    WHERE A.within_code = B.within_code AND A.id = B.id AND A.ver = B.ver AND A.sequence_id = B.upper_sequence AND 
                     A.within_code = S.within_code AND A.goods_unit = S.unit_code AND
                     B.within_code = C.within_code AND B.goods_id = C.id AND A.mo_id='{0}' Order By B.primary_key desc", strmo);
            dtReport = clsPublicOfGeo.ExecuteSqlReturnDataTable(sql);           
            dataGridView1.DataSource = dtReport;
            if (dtReport.Rows.Count > 0)
            {
                txtGoods_id.Text = dtReport.Rows[0]["goods_id"].ToString();                
                txtGoods_name.Text = dtReport.Rows[0]["goods_name"].ToString();
                txtQty_order.Text = dtReport.Rows[0]["order_qty"].ToString();
                string strArtwork = dtReport.Rows[0]["artwork"].ToString();
                if (!string.IsNullOrEmpty(strArtwork))
                {
                    if (File.Exists(strArtwork))
                        pic_artwork.Image = Image.FromFile(strArtwork);
                    else
                        pic_artwork.Image = null;
                }
                else
                    pic_artwork.Image = null;
                dataGridView1.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {  
            if (!blPermission)
            {
                MessageBox.Show(string.Format("當前用戶【{0}】沒有此操作權限!", DBUtility._user_id), "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dateTimePicker1.Text == "" || txtGoods_id.Text == "")
            {
                MessageBox.Show("日期或貨品編號不可為空!", "系統提示");
                return;
            }
            const string sql_i =
            @"Insert into dbo.qc_packing_weiht(qc_date,mo_id,goods_id,qty_order,qty_packing,qty_check,qty_differ,weiht_check,remark,lable_no,create_by,create_date)
                Values(@qc_date,@mo_id,@goods_id,@qty_order,@qty_packing,@qty_check,@qty_differ,@weiht_check,@remark,@lable_no,@user_id,getdate())";
            const string sql_u =
            @"UPDATE dbo.qc_packing_weiht 
			SET qc_date=@qc_date,mo_id=@mo_id,goods_id=@goods_id,qty_order=@qty_order,qty_packing=@qty_packing,qty_check=@qty_check,qty_differ=@qty_differ,
                weiht_check=@weiht_check,remark=@remark,lable_no=@lable_no,update_by=@user_id,update_date=getdate()
			WHERE id=@id";

            bool save_flag = false;
            try
            {
                SqlConnection myCon = new SqlConnection(DBUtility.dgcf_pad_connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    myCommand.Parameters.Clear();
                    myCommand.Parameters.AddWithValue("@qc_date",dateTimePicker1.Value.ToString("yyyy-MM-dd") );
                    myCommand.Parameters.AddWithValue("@mo_id", txtMo_id.Text);
                    myCommand.Parameters.AddWithValue("@goods_id", txtGoods_id.Text);
                    myCommand.Parameters.AddWithValue("@qty_order", string.IsNullOrEmpty(txtQty_order.Text) ? 0 : Int32.Parse(txtQty_order.Text));                    ;
                    myCommand.Parameters.AddWithValue("@qty_packing",string.IsNullOrEmpty(txtQty_packing.Text) ? 0 : Int32.Parse(txtQty_packing.Text));
                    myCommand.Parameters.AddWithValue("@qty_check", string.IsNullOrEmpty(txtQty_check.Text) ? 0 : Int32.Parse(txtQty_check.Text));
                    myCommand.Parameters.AddWithValue("@weiht_check", string.IsNullOrEmpty(txtWeiht_check.Text) ? 0 : float.Parse(txtWeiht_check.Text));
                    myCommand.Parameters.AddWithValue("@qty_differ", string.IsNullOrEmpty(txtQty_differ.Text) ? 0 : Int32.Parse(txtQty_differ.Text));
                    myCommand.Parameters.AddWithValue("@remark", txtRemark.Text);
                    myCommand.Parameters.AddWithValue("@lable_no", txtLable_no.Text);
                    myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                    if (txtID.Text =="") //新增
                    {
                        myCommand.CommandText = sql_i;                           
                    }
                    else
                    {
                        //保存編輯                                    
                        myCommand.CommandText = sql_u;
                        myCommand.Parameters.AddWithValue("@id", Int32.Parse(txtID.Text));                                                        
                    }
                    myCommand.ExecuteNonQuery();                            
                    myTrans.Commit(); //數據提交
                    save_flag = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (save_flag)
            {                    
                Operation_info("數 據 保 存 成 功!", Color.Blue);
            }
            else
            {                   
                Operation_info("數 據 保 存 失 敗!", Color.Red);                    
            }
            txtBarCode.Focus();            
        }
               
        private void Operation_info(string msg, Color fore_clr)
        {
            lblSaveinfo.Text = msg;
            lblSaveinfo.ForeColor = fore_clr;
            lblSaveinfo.Visible = true;
            Delay(1200); // 延時1.2秒
            lblSaveinfo.Visible = false;
        }
        
        //public static void Delay(int milliSecond)
        private void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {            
            if (!blPermission)
            {
                MessageBox.Show(string.Format("當前用戶【{0}】沒有此操作權限!", DBUtility._user_id), "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtID.Text))
            {                    
                return;
            }
            int id = Convert.ToInt32(txtID.Text);
            string strSql_d = string.Format("Delete From qc_packing_weiht WHERE id={0}", id);

            if (id > 0)
            {
                if (MessageBox.Show("確定要刪除當前記錄?", "系統提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }                    
                try
                {
                    using (SqlConnection conn = new SqlConnection(DBUtility.dgcf_pad_connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = strSql_d;
                        cmd.ExecuteNonQuery();             
                        Operation_info("當前行刪除成功!", Color.Blue);
                    }
                    dtReport.Clear();
                    txtMo_id.Text = "";
                    txtID.Text = "";
                    txtGoods_id.Text = "";
                    txtGoods_name.Text = "";
                    txtQty_order.Text = "";
                    txtQty_packing.Text = "";
                    txtQty_check.Text = "";
                    txtQty_differ.Text = "";
                    txtWeiht_check.Text = "";
                    txtRemark.Text = "";
                    txtLable_no.Text = "";
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void mskDat1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //按回車跳到下一控件                
            if (e.KeyChar == 13) //等同于(e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                //等同于frm.SelectNextControl(frm.ActiveControl, true, true, true, true);
            }              
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //按回車跳到下一控件                
            if (e.KeyChar == 13) //等同于(e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                //等同于frm.SelectNextControl(frm.ActiveControl, true, true, true, true);
            }            
        }

        private void txtMO1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //按回車跳到下一控件                
            if (e.KeyChar == 13) //等同于(e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                //等同于frm.SelectNextControl(frm.ActiveControl, true, true, true, true);
            }
            if ((txtMO1.TextLength - txtMO1.SelectionLength) == txtMO1.MaxLength - 1)
            {
                SendKeys.Send("{TAB}");
            }     
        }

        private void txtMO2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //按回車跳到下一控件                
            if (e.KeyChar == 13) //等同于(e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                //等同于frm.SelectNextControl(frm.ActiveControl, true, true, true, true);
            }
            if ((txtMO2.TextLength - txtMO2.SelectionLength) == txtMO2.MaxLength - 1)
            {
                SendKeys.Send("{TAB}");
            }     
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string dat1 = mskDat1.Text;
            string dat2 = mskDat2.Text;
           
            if (dat1 != "    /  /")
            {
                if (!clsValidRule.CheckDateFormat(dat1))
                {                
                    MessageBox.Show("日期格有誤，請返回檢查!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskDat1.Focus();
                    return;
                }
            }
            else
                dat1 = "";

            if (dat2 != "    /  /")
            {
                if (!clsValidRule.CheckDateFormat(dat2))
                {
                    MessageBox.Show("日期格有誤，請返回檢查!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskDat2.Focus();
                    return;
                }
            }
            else
                dat2 = "";

            if (dat1 == "" && dat2 == "" && txtMO1.Text == "" && txtMO2.Text == "")
            {
                MessageBox.Show("查詢條件不可為空，請輸入查詢條件!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskDat1.Focus();
                return;
            }
            StringBuilder sb = new StringBuilder(
            string.Format(@"Select A.id,convert(char(10),A.qc_date,120) as qc_date,A.mo_id,A.goods_id,A.qty_order,A.qty_packing,A.qty_check,A.qty_differ,A.weiht_check,
                    A.remark,A.lable_no,B.name as goods_name,ROW_NUMBER() OVER(ORDER BY A.id ) as seq_no
                    From dbo.qc_packing_weiht A with(nolock) 
	                INNER JOIN {0}it_goods B with(nolock) ON B.within_code='0000' and A.goods_id =B.id 
                    WHERE A.id>0 ",DBUtility.remote_db));
            if(!string.IsNullOrEmpty(txtMO1.Text))
                sb.Append(string.Format(" AND A.mo_id>='{0}'",txtMO1.Text));
            if (!string.IsNullOrEmpty(txtMO2.Text))
                sb.Append(string.Format(" AND A.mo_id<='{0}'", txtMO2.Text));
            if (!string.IsNullOrEmpty(dat1))
                sb.Append(string.Format(" AND A.qc_date>='{0}'", dat1));
            if (!string.IsNullOrEmpty(dat2))
                sb.Append(string.Format(" AND A.qc_date<='{0}'", dat2));
            dtFind = clsPublicOfPad.ExecuteSqlReturnDataTable(sb.ToString());
            if (dtFind.Rows.Count == 0)
            {                
                MessageBox.Show("沒有符合條件的數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvDetails.DataSource = dtFind;

            //統計MO張數
            sb.Clear();
            sb.Append(@"SELECT Distinct mo_id FROM dbo.qc_packing_weiht WHERE id>0 ");
            if (!string.IsNullOrEmpty(txtMO1.Text))
                sb.Append(string.Format(" AND mo_id>='{0}'", txtMO1.Text));
            if (!string.IsNullOrEmpty(txtMO2.Text))
                sb.Append(string.Format(" AND mo_id<='{0}'", txtMO2.Text));
            if (!string.IsNullOrEmpty(dat1))
                sb.Append(string.Format(" AND qc_date>='{0}'", dat1));
            if (!string.IsNullOrEmpty(dat2))
                sb.Append(string.Format(" AND qc_date<='{0}'", dat2));            
            using (DataTable dtMO = clsPublicOfPad.ExecuteSqlReturnDataTable(sb.ToString()))
            {
                lblMo_total.Text = dtMO.Rows.Count.ToString();
            }            
            

        }

        private void mskDat1_Leave(object sender, EventArgs e)
        {
            mskDat2.Text = mskDat1.Text;
        }

        private void txtMO1_Leave(object sender, EventArgs e)
        {
            txtMO2.Text = txtMO1.Text;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                using (xrQcPacking mMyReport = new xrQcPacking() { DataSource = dtFind })
                {
                    mMyReport.CreateDocument();
                    mMyReport.PrintingSystem.ShowMarginsWarning = false;
                    mMyReport.ShowPreviewDialog();
                }
            }
        }

        private void tbc_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tbc.SelectedIndex)
            {
                case 0:                    
                    txtBarCode.Focus();
                    break;
            }
        }


        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dtFind.Rows.Count > 0)
            {
                btnDel.Enabled = true;
                int i = dgvDetails.CurrentCell.RowIndex;
                Set_Dropbox_Items(dtFind.Rows[i]["mo_id"].ToString());   
             
                txtID.Text = dtFind.Rows[i]["id"].ToString();
                txtMo_id.Text = dtFind.Rows[i]["mo_id"].ToString();
                txtGoods_id.Text = dtFind.Rows[i]["goods_id"].ToString();
                txtGoods_name.Text = dtFind.Rows[i]["goods_name"].ToString();
                txtQty_order.Text = dtFind.Rows[i]["qty_order"].ToString();
                txtQty_packing.Text = dtFind.Rows[i]["qty_packing"].ToString();
                txtQty_check.Text = dtFind.Rows[i]["qty_check"].ToString();
                txtQty_differ.Text = dtFind.Rows[i]["qty_differ"].ToString();
                txtWeiht_check.Text = dtFind.Rows[i]["weiht_check"].ToString();
                txtRemark.Text = dtFind.Rows[i]["remark"].ToString();
                txtLable_no.Text = dtFind.Rows[i]["lable_no"].ToString();
                //string strArtwork = dtReport.Rows[0]["artwork"].ToString(); //txtGoods_id.GetColumnValue("artwork").ToString(); 
                //if (!string.IsNullOrEmpty(strArtwork))
                //{
                //    if (File.Exists(strArtwork))
                //        pic_artwork.Image = Image.FromFile(strArtwork);
                //    else
                //        pic_artwork.Image = null;
                //}
                //else
                //    pic_artwork.Image = null;
            }
        }

        private void txtWeiht_check_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.Input_Decimal(txtWeiht_check, e);
        }

        private void txtQty_packing_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.Input_Int(txtQty_packing, e);
        }

        private void txtQty_differ_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.Input_Int(txtQty_differ, e);
        }

        private void txtQty_check_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.Input_Int(txtQty_check, e);
        }

        private void txtGoods_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //按的是回車鍵
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtQty_packing_MouseDown(object sender, MouseEventArgs e)
        {
            if (chkKeyBorad.Checked)
                clsUtility.Call_imput();
        }

        private void txtQty_check_MouseDown(object sender, MouseEventArgs e)
        {
            if (chkKeyBorad.Checked)
                clsUtility.Call_imput();
        }

        private void txtQty_differ_MouseDown(object sender, MouseEventArgs e)
        {
            if (chkKeyBorad.Checked)
                clsUtility.Call_imput();
        }

        private void txtWeiht_check_MouseDown(object sender, MouseEventArgs e)
        {
            if (chkKeyBorad.Checked)
               clsUtility.Call_imput();
        }

        private void txtRemark_MouseDown(object sender, MouseEventArgs e)
        {
            if(chkKeyBorad.Checked)
               clsUtility.Call_imput();
        }

        private void mskDat1_MouseDown(object sender, MouseEventArgs e)
        {
            if (chkKeyBorad.Checked)
                clsUtility.Call_imput();
        }

        private void mskDat2_MouseDown(object sender, MouseEventArgs e)
        {
            if (chkKeyBorad.Checked)
                clsUtility.Call_imput();
        }

        private void txtMO1_MouseDown(object sender, MouseEventArgs e)
        {
            if (chkKeyBorad.Checked)
                clsUtility.Call_imput();
        }

        private void txtMO2_MouseDown(object sender, MouseEventArgs e)
        {
            if (chkKeyBorad.Checked)
                clsUtility.Call_imput();
        }

        private void txtQty_packing_Leave(object sender, EventArgs e)
        {
            Set_Qty_Differ();
        }

        private void txtQty_check_Leave(object sender, EventArgs e)
        {
            Set_Qty_Differ();
        }

        private void Set_Qty_Differ()
        {
            Int32 qty_packing,qty_check;
            if (string.IsNullOrEmpty(txtQty_packing.Text))
                qty_packing = 0;
            else
                qty_packing = Int32.Parse(txtQty_packing.Text);
            if (string.IsNullOrEmpty(txtQty_check.Text))
                qty_check = 0;
            else
                qty_check = Int32.Parse(txtQty_check.Text);
            if (qty_packing > 0 || qty_check > 0)
            {
                txtQty_differ.Text = (qty_check - qty_packing).ToString();
            }
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Focus();
            SendKeys.SendWait("%{DOWN}");
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount>0)
            {
                txtGoods_id.Text = dtReport.Rows[dataGridView1.CurrentRow.Index]["goods_id"].ToString();
                txtGoods_name.Text = dtReport.Rows[dataGridView1.CurrentRow.Index]["goods_name"].ToString();
                txtQty_order.Text = dtReport.Rows[dataGridView1.CurrentRow.Index]["order_qty"].ToString();
                string strArtwork = dtReport.Rows[dataGridView1.CurrentRow.Index]["artwork"].ToString();
                if (!string.IsNullOrEmpty(strArtwork))
                {
                    if (File.Exists(strArtwork))
                        pic_artwork.Image = Image.FromFile(strArtwork);
                    else
                        pic_artwork.Image = null;
                }
                else
                    pic_artwork.Image = null;
                dataGridView1.Visible = false;
            }
        }

        private void txtGoods_id1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

    

     
     
     

     
     
    

       
    }
}
