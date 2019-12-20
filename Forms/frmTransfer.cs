using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using cf_pad.CLS;
using System.Data.SqlClient;


namespace cf_pad.Forms
{
    public partial class frmTransfer : Form
    {
        DataTable dtDept;
        DataTable dtStock;
        DataTable dtData;
        DataTable dtLotNo;
        DataTable dtFind;
        DataTable dtQC_Data;
        DataTable dtQC;

        DataSet dsSt;        
        public frmTransfer()
        {
            InitializeComponent();
            dtFind = new DataTable();
            dtLotNo = new DataTable();
            dtDept = clsBs_Dep.GetAll_WH();
        }

        private void frmTransfer_Load(object sender, EventArgs e)
        {
            DataTable dtDept = clsBs_Dep.Get_Plate_Dept();
            txtCrusr1.Text = DBUtility._user_id;
            txtCrusr2.Text = txtCrusr1.Text;
            if (dtDept.Rows.Count > 0)
            {
                //發貨部門
                for (int i = 0; i < dtDept.Rows.Count; i++)
                {
                    cboOut_dept.Items.Add(dtDept.Rows[i]["id"].ToString());
                    cboIn_dept.Items.Add(dtDept.Rows[i]["id"].ToString());

                    txtDept1.Items.Add(dtDept.Rows[i]["id"].ToString());
                    txtDept2.Items.Add(dtDept.Rows[i]["id"].ToString());
                }
                cboOut_dept.Text = "501";
                cboIn_dept.Text = "";

                txtDept1.Text = "501";
                txtDept2.Text = "501";
            }

            //初始表明細
            string strsql = string.Format(
            @"Select A.mo_id,A.goods_id,B.name as goods_name,Convert(int,A.con_qty) as con_qty,Convert(decimal(20,2),A.sec_qty) as sec_qty,
            Convert(int,A.con_qty) as old_qty,Convert(decimal(20,2),A.sec_qty) as old_sec_qty,
            Convert(int,A.package_num) as package_num,A.lot_no,A.id,A.sequence_id,isnull(A.qc_result,'0') as qc_result,A.jo_id,A.jo_sequence_id           
            FROM {0}jo_materiel_con_details A ,{0}it_goods B
            where 1=0", DBUtility.remote_db);
            dtData = clsPublicOfPad.ExecuteSqlReturnDataTable(strsql);
            //dtData = clsPublicOfGeo.ExecuteSqlReturnDataTable(strsql);
            dgvDetails.DataSource = dtData;

            //初始QC測試
            dtQC_Data = new DataTable();
            dtQC_Data.Columns.Add("mo_id", typeof(string));
            dtQC_Data.Columns.Add("goods_id", typeof(string));
            dtQC_Data.Columns.Add("goods_name", typeof(string));
            dtQC_Data.Columns.Add("prod_qty", typeof(int));
            dtQC_Data.Columns.Add("sec_qty", typeof(float));
            dtQC_Data.Columns.Add("package_num", typeof(int));
            dtQC_Data.Columns.Add("lot_no", typeof(string));
            dtQC_Data.Columns.Add("jo_id", typeof(string));
            dtQC_Data.Columns.Add("jo_sequence_id", typeof(string));
            dgvDetails_qc.DataSource = dtQC_Data;
            this.ActiveControl = txtBarCode;
            txtBarCode.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ss = dtpDate.Text;
        }     

        private void btnDataList_Click(object sender, EventArgs e)
        {
            //btnSet.Text = "數據編輯";
            tbcDetails.SelectedIndex = 1;
            dtpDate.Text = DateTime.Now.Date.ToString("yyyy/MM/dd");
            dtp1.Text = DateTime.Now.Date.ToString("yyyy/MM/dd");
            dtp1.Text = DateTime.Now.Date.ToString("yyyy/MM/dd");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void Add()
        {
            tbcDetails.SelectedIndex = 0;
            if (dgvDetails.RowCount > 0 && txtSate.Text == "")
            {
                if (MessageBox.Show("當前未保存的資料將會丟失,是否繼續?\r\n\r\n[是] 清除未保存的數據\r\n\r\n[否] 返回繼續當前操作", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    Clear();
                }
            }
            else
                Clear();
        }

        private void Clear()
        {
            dtData.Clear();
            dtLotNo.Clear();
            dtQC_Data.Clear();
            
            txtBarCode.Text = "";
            cboOut_dept.Enabled = true;
            cboIn_dept.Enabled = true;
            txtOut_dept_name.Text = "";
            txtIn_dept_name.Text = "";
            txtId.Text = "";
            cboOut_dept.Text = "";
            txtOut_dept_name.Text = "";
            cboIn_dept.Text = "";
            txtIn_dept_name.Text = "";
            txtCurrentRow.Text = "";
            txtSate.Text = "";
            txtCheck_by.Text = "";
            txtCheck_date.Text = "";          
            txtMo_id.Text = "";
            txtGoods_id.Text = "";
            txtGoods_name.Text = "";
            txtLot.Text = "";
            txtQty.Text = "";
            txtSec_qty.Text = "";
            txtPackage_num.Text = "";
            txtIdqc.Text = "";
            btnSave.Enabled = true;

            txtBarCode.Focus();
        }

        

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSate.Text == "已批準")
            {
                txtBarCode.Text = "";
                return;
            }
            if (dgvDetails.RowCount > 100)
            {
                MessageBox.Show("注意：明細不可超出100條件記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBarCode.Text = "";
                return;
            }

            string seq_id="";
            switch (e.KeyCode)
            {               
                case Keys.Enter:
                    string strBarCode = txtBarCode.Text;
                    string mo_id;
                    if (strBarCode.Length == 13)
                    {
                        mo_id = strBarCode.Substring(0, 9);
                        seq_id = String.Format("00{0}h", strBarCode.Substring(11, 2));
                        SqlParameter[] paras = new SqlParameter[]{
                            new SqlParameter("@mo_id", mo_id),
                            new SqlParameter("@sequence_id", seq_id)
                        };
                        dsSt = clsPublicOfPad.ExecuteProcedureReturnDataSet("usp_plate_transfer", paras, null);
                    }
                    else
                    {
                        if (strBarCode.Length == 12) //返回準確的批號
                        {
                            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@id_barcode", strBarCode) };
                            dsSt = clsPublicOfPad.ExecuteProcedureReturnDataSet("usp_plate_transfer_lotno", paras, null);
                        }
                        else
                        {
                            MessageBox.Show("無效的條碼!", "提示信息", MessageBoxButtons.OK);
                            txtBarCode.Text = "";
                            return;
                        }
                    }                    
                    
                    dtStock = dsSt.Tables[0];
                    dtLotNo = dsSt.Tables[1];
                    dtQC = dsSt.Tables[2];
                    dgvLotno.DataSource = dtLotNo;//批號下拉框

                    txtBarCode.Text = "";
                    if (dtStock.Rows.Count > 0)
                    {
                        if (strBarCode.Length == 12)
                        {
                            seq_id = dtStock.Rows[0]["jo_sequence_id"].ToString();
                        }
                        txtBarCode.Focus();
                        //從第二條記錄開始檢查是否與首筆記錄的負責部門、下部門是否一致，避免交錯部門
                        if (dgvDetails.RowCount > 0 && (dtStock.Rows[0]["wp_id"].ToString() != cboOut_dept.Text || dtStock.Rows[0]["next_wp_id"].ToString() != cboIn_dept.Text))
                        {
                            MessageBox.Show("當前頁數貨品的負責部門與前一頁數的負責部門不相符!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dgvDetails.Rows[dgvDetails.Rows.Count - 1].Selected = true; //選中整行  
                            return;
                        }
                        
                        /*2019-11-21 暫時取消外發QC狀態是否OK的檢查
                        if (dtStock.Rows[0]["iqc_result"].ToString() == "1")
                        {                            
                            picqc_result1.Visible = true; //打勾的圖片
                            picqc_result2.Visible = false;//空白的圖片
                        }
                        else
                        {                            
                            picqc_result1.Visible = false;
                            picqc_result2.Visible = true;
                            txtLot.Text = "";
                            txtQty.Text = "";
                            txtSec_qty.Text = "";
                            MessageBox.Show("當前頁數之貨品外發電鍍IQC檢查通不過!不可以進行后續的操作!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        */

                        if (dgvDetails.RowCount == 0) //第一筆記錄時設置負責部門和接收部門
                        {
                            cboOut_dept.Text = dtStock.Rows[0]["wp_id"].ToString();
                            cboIn_dept.Text = dtStock.Rows[0]["next_wp_id"].ToString();
                            txtId.Text = Get_Max_No(cboOut_dept.Text, cboIn_dept.Text);
                        }                        
                        txtMo_id.Text = dtStock.Rows[0]["mo_id"].ToString();
                        txtGoods_id.Text = dtStock.Rows[0]["goods_id"].ToString();
                        txtGoods_name.Text = dtStock.Rows[0]["goods_name"].ToString();
                        txtLot.Text = dtStock.Rows[0]["lot_no"].ToString();
                        txtQty.Text = dtStock.Rows[0]["qty"].ToString();
                        txtSec_qty.Text = dtStock.Rows[0]["sec_qty"].ToString();
                        txtPackage_num.Text = "1";                        

                        //=================
                        //生成702QC測試移交單數據
                        if (dtQC.Rows.Count > 0)
                        {
                            if (int.Parse(dtQC.Rows[0]["prod_qty"].ToString()) > 0)
                            {
                                //Operation_info("此頁數有要交QC測試的數據!", Color.Blue); // 提示信息取消于2019-11-21
                                DataRow dr_qc = dtData.NewRow();
                                dr_qc = dtQC_Data.NewRow();
                                dr_qc["mo_id"] = txtMo_id.Text;
                                dr_qc["goods_id"] = txtGoods_id.Text;
                                dr_qc["goods_name"] = txtGoods_name.Text;
                                dr_qc["lot_no"] = txtLot.Text;
                                dr_qc["prod_qty"] = dtQC.Rows[0]["prod_qty"].ToString();
                                dr_qc["sec_qty"] = "0.01";
                                dr_qc["package_num"] = "0";
                                dr_qc["jo_id"] = dtQC.Rows[0]["jo_id"].ToString();
                                dr_qc["jo_sequence_id"] = dtQC.Rows[0]["jo_sequence_id"].ToString();

                                dtQC_Data.Rows.Add(dr_qc);
                                if (dgvDetails_qc.RowCount == 1) //第一筆記錄時設置負責部門和接收部門
                                {
                                    cboOut_dept.Text = dtStock.Rows[0]["wp_id"].ToString();
                                    txtIdqc.Text = Get_Max_No(cboOut_dept.Text, "702");
                                }
                                //扣減移交單中的數量,重量                                
                                txtQty.Text = (float.Parse(dtStock.Rows[0]["qty"].ToString()) - float.Parse(dtQC.Rows[0]["prod_qty"].ToString())).ToString();
                                //txtQty.Text = int.Parse(txtQty.Text).ToString();
                                txtSec_qty.Text = Math.Round(float.Parse(dtStock.Rows[0]["sec_qty"].ToString()) - 0.01, 2).ToString();
                            }
                        }
                        //=================
                        
                        //生成移交單明細數據
                        DataRow dr = dtData.NewRow();
                        dr["mo_id"] = txtMo_id.Text;
                        dr["goods_id"] = txtGoods_id.Text;
                        dr["goods_name"] = txtGoods_name.Text;
                        dr["lot_no"] = txtLot.Text;
                        dr["con_qty"] = txtQty.Text;
                        dr["sec_qty"] = txtSec_qty.Text;
                        dr["package_num"] = txtPackage_num.Text;
                        dr["qc_result"] = dtStock.Rows[0]["iqc_result"].ToString();
                        dr["old_qty"] = dtStock.Rows[0]["old_qty"].ToString();
                        dr["old_sec_qty"] = dtStock.Rows[0]["old_sec_qty"].ToString();
                        dr["jo_id"] = dtStock.Rows[0]["jo_id"].ToString();
                        dr["jo_sequence_id"] = seq_id;

                        dtData.Rows.Add(dr);
                        int new_row = dtData.Rows.Count - 1;
                        txtCurrentRow.Text = new_row.ToString(); ;
                        dgvDetails.CurrentCell = dgvDetails.Rows[new_row].Cells[1]; //设置当前单元格
                        dgvDetails.Rows[new_row].Selected = true; //選中整行
                        dgvDetails.Refresh();            
                    }
                    else
                    {
                        if (dgvDetails.RowCount > 0)
                        {
                            return;//避免已輸入前幾個頁，再掃描當前頁數時沒倉數量時清空之前的部門的情況
                        }
                        cboOut_dept.Text = "";
                        cboIn_dept.Text = "";
                        txtMo_id.Text = "";
                        txtGoods_id.Text = "";
                        txtGoods_name.Text = "";
                        txtLot.Text = "";
                        txtQty.Text = "";
                        txtSec_qty.Text = "";
                        txtPackage_num.Text = "";
                        txtCurrentRow.Text = "";                       
                        picqc_result2.Visible = true;
                    }                   
                   break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btLotNo_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                ////當前行不是最后一條記錄時，重新設置下拉列表的數據來源
                //if (dgvDetails.CurrentRow.Index != dgvDetails.RowCount - 1)
                //{
                //    SqlParameter[] paras = new SqlParameter[]{
                //            new SqlParameter("@wp_id", cboOut_dept.Text),
                //            new SqlParameter("@next_wp_id", cboIn_dept.Text),
                //            new SqlParameter("@mo_id", txtMo_id.Text),
                //            new SqlParameter("@goods_id",txtGoods_id.Text)
                //    };               
                //    dtLotNo = clsPublicOfPad.ExecuteProcedure("usp_plate_transfer_find_lotno", paras);
                //    if(dtLotNo.Rows.Count>0)
                //        dgvLotno.Visible = true;
                //    else
                //        dgvLotno.Visible = false;
                //}
                //else

                //最后一條添加的記錄時才顯示批號下拉列表
                if (dgvDetails.CurrentRow.Index == dgvDetails.RowCount - 1)
                    pnlLot.Visible = true;
                else
                    pnlLot.Visible = false;
            }
        }
     

        private void txtLot_Click(object sender, EventArgs e)
        {
            if(dgvLotno.Visible)
               pnlLot.Visible = false;
        }

        private void dgvLotno_DoubleClick(object sender, EventArgs e)
        {
            pnlLot.Visible = false;
            txtBarCode.Focus();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            tbcDetails.SelectedIndex = 0;
            if (dgvDetails.RowCount == 0)
            {
                return;
            }
            if (txtSate.Text=="已批準")
            {
                MessageBox.Show("當前單據已批準，不可以再進行刪除的操作！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (!Check_Department_Valid(cboOut_dept.Text)) //檢查當前用戶是否有此部門的權限
            {
                return;
            }

            int curRow = int.Parse(txtCurrentRow.Text);
            if (txtSate.Text == "未批準")
            {
                string sql_f = string.Format(@"select state from {0}jo_materiel_con_mostly with(nolock) where within_code='0000' and id='{1}'", DBUtility.remote_db, txtId.Text);
                DataTable dt = new DataTable();
                dt = clsPublicOfPad.ExecuteSqlReturnDataTable(sql_f);
                if (dt.Rows[0]["state"].ToString() == "1")
                {
                    MessageBox.Show("當前單據已批準，不可以再進行刪除的操作！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    DialogResult result = MessageBox.Show("是否要刪除當前資料?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        //檢查明細表是否存在一條以下的記錄,如是等于一件，直接刪除主表
                        sql_f = string.Format(@"Select '0' as rs From {0}jo_materiel_con_details with(nolock) Where within_code='0000' and id='{1}'", DBUtility.remote_db, txtId.Text);
                        string sql_del_mostly = string.Format(@"DELETE FROM {0}jo_materiel_con_mostly Where within_code='0000' and id='{1}'", DBUtility.remote_db, txtId.Text);
                        string sql_del_details = string.Format(@"DELETE FROM {0}jo_materiel_con_details Where within_code='0000' and id='{1}'", DBUtility.remote_db, txtId.Text);
                        dt = clsPublicOfPad.ExecuteSqlReturnDataTable(sql_f);
                        int del_result;
                        if (dt.Rows.Count > 1)                 
                            del_result = clsPublicOfPad.ExecuteSqlUpdate(sql_del_details);//刪除明細
                        else                        
                            del_result = clsPublicOfPad.ExecuteSqlUpdate(sql_del_mostly);//刪除主表      
                        dtData.Rows.RemoveAt(curRow);
                        dtData.AcceptChanges();
                        Operation_info("當前記錄刪除成功!", Color.Blue);                        
                    }                    
                }
            }
            if (txtSate.Text == "")
            {
                dtData.Rows.RemoveAt(curRow);
                dtData.AcceptChanges();
                Operation_info("當前記錄刪除成功!", Color.Blue);
                txtBarCode.Focus();
                //DataGridViewRow row = dgvDetails.Rows[curRow];
                //dgvDetails.Rows.Remove(row);
            }  
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                txtMo_id.Text = dtData.Rows[dgvDetails.CurrentRow.Index]["mo_id"].ToString();
                txtGoods_id.Text = dtData.Rows[dgvDetails.CurrentRow.Index]["goods_id"].ToString();
                txtGoods_name.Text = dtData.Rows[dgvDetails.CurrentRow.Index]["goods_name"].ToString();
                txtLot.Text = dtData.Rows[dgvDetails.CurrentRow.Index]["lot_no"].ToString();
                txtQty.Text = dtData.Rows[dgvDetails.CurrentRow.Index]["con_qty"].ToString();
                txtSec_qty.Text = dtData.Rows[dgvDetails.CurrentRow.Index]["sec_qty"].ToString();
                txtPackage_num.Text = dtData.Rows[dgvDetails.CurrentRow.Index]["package_num"].ToString();
                
                /*代碼取消于2019-11-21
                if (dtData.Rows[dgvDetails.CurrentRow.Index]["qc_result"].ToString() == "1")
                {                    
                    picqc_result1.Visible = true;
                    picqc_result2.Visible = false;
                }
                else
                {                    
                    picqc_result1.Visible = false;
                    picqc_result2.Visible = true;
                }
                */

                txtCurrentRow.Text = dgvDetails.CurrentRow.Index.ToString();

            }
        }

        private static void Set_Number_Format(TextBox obj, KeyPressEventArgs e)
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

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {            
            clsUtility.Input_Int(txtQty, e);
        }

        private void txtSec_qty_KeyPress(object sender, KeyPressEventArgs e)
        {            
            clsUtility.Input_Decimal(txtSec_qty, e);           
        }

        private void txtPackage_num_KeyPress(object sender, KeyPressEventArgs e)
        {
            Set_Number_Format(txtPackage_num, e);
        }

        private void txtSec_qty_Leave(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                if (txtSec_qty.Text != "")
                {
                    int cur_row = int.Parse(txtCurrentRow.Text);                 
                    float old_sec_qty, rate_qty, new_sec_qty;
                    float old_qty = Int32.Parse(dtData.Rows[cur_row]["old_qty"].ToString());
                    old_sec_qty = float.Parse(dtData.Rows[cur_row]["old_sec_qty"].ToString());
                    rate_qty = old_qty / old_sec_qty;
                    new_sec_qty = float.Parse(txtSec_qty.Text);                    
                    txtQty.Text = Math.Round(rate_qty * new_sec_qty).ToString();

                    dtData.Rows[cur_row]["con_qty"] = txtQty.Text;
                    dtData.Rows[cur_row]["sec_qty"] = txtSec_qty.Text;
                    txtBarCode.Focus();
                }
            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                if (txtSec_qty.Text != "" && txtQty.Text != "")
                {
                    int cur_row = int.Parse(txtCurrentRow.Text);
                    dtData.Rows[cur_row]["con_qty"] = txtQty.Text;
                    dtData.Rows[cur_row]["sec_qty"] = txtSec_qty.Text;
                }
            }
        }

        private void txtQty_Click(object sender, EventArgs e)
        {
            if (dgvLotno.Visible)
                dgvLotno.Visible = false;
        }

        private void cboOut_dept_Leave(object sender, EventArgs e)
        {
            check_dept_name(cboOut_dept,txtOut_dept_name);
            if (cboOut_dept.Text != "" && cboIn_dept.Text != "" && txtSate.Text == "")
            {
                txtId.Text = Get_Max_No(cboOut_dept.Text, cboIn_dept.Text);
            }
        }

        private void cboIn_dept_Leave(object sender, EventArgs e)
        {
            check_dept_name(cboIn_dept,txtIn_dept_name);
            if (cboOut_dept.Text != "" && cboIn_dept.Text != "" && txtSate.Text == "")
            {
                txtId.Text = Get_Max_No(cboOut_dept.Text, cboIn_dept.Text);
            }
        }

        private void check_dept_name(ComboBox obj_id,TextBox obj_name)
        {
            if (obj_id.Text != "")
            {                
                dtDept.Select();
                DataRow[] dr_arry = dtDept.Select(string.Format("id='{0}'", obj_id.Text));
                if (dr_arry.Length > 0)
                    obj_name.Text = dr_arry[0]["name"].ToString();
                else
                {
                    obj_name.Text = "";
                    MessageBox.Show("無效的部門代碼[0]!","提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    obj_id.Focus();
                }
            }
        }        

        private void txtPackage_num_Leave(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                if (txtPackage_num.Text != "" )
                {
                    int cur_row = int.Parse(txtCurrentRow.Text);
                    dtData.Rows[cur_row]["Package_num"] = txtPackage_num.Text;                    
                }
            }
        }     

        private static string Get_Max_No(string from_dept, string to_dept)
        {
            string strMaxNo="";
            int iMaxNo;            
            string strsql = string.Format(
            @"Select SUBSTRING(bill_code,8,5) AS bill_code 
            From {0}sys_bill_max_jo07 with (nolock) WHERE within_code='0000' AND bill_text1='T' AND bill_text2='{1}' AND bill_text3='{2}'", DBUtility.remote_db, from_dept, to_dept);
            DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(strsql);
            if (dt.Rows.Count > 0)
            {
                strMaxNo = dt.Rows[0]["bill_code"].ToString();
                if (string.IsNullOrEmpty(strMaxNo))
                    iMaxNo = 1;
                else
                    iMaxNo = int.Parse(strMaxNo) + 1;
            }
            else
                iMaxNo = 1;
            strMaxNo = iMaxNo.ToString("00000");
            strMaxNo = String.Format("DT{0}{1}{2}", from_dept, to_dept, strMaxNo);
            return strMaxNo;
        }
     
        private void btnSave_Click(object sender, EventArgs e)
        {
            tbcDetails.SelectedIndex = 0;
            if (dgvDetails.RowCount == 0)
            {
                return;
            }
            if (!Check_Department_Valid(cboOut_dept.Text)) //檢查當前用戶是否有此部門的權限
            {                
                return;
            }
            if (Save_Valid())
            {
                string strID = "";
                if (txtSate.Text == "")
                {
                    strID = Get_Max_No(cboOut_dept.Text, cboIn_dept.Text);
                    txtId.Text = strID;
                }
                else
                    strID = txtId.Text;
                //移交單主表
                const string sql_h_i = @"INSERT INTO jo_materiel_con_mostly
                (within_code,id,con_date,out_dept,in_dept,transfers_state,state,bill_type_no,con_type,stock_type,bill_origin,create_by,create_date,update_by,update_date,update_count,servername,handler) Values
                (@within_code,@id,@con_date,@out_dept,@in_dept,@ransfers_state,@state,@bill_type_no,@con_type,@stock_type,@bill_origin,@user_id,getdate(),@user_id,getdate(),1,@servername,@user_id)";

                const string sql_h_u =
                @"Update jo_materiel_con_mostly SET con_date=@con_date,update_by=@user_id,getdate(),update_count = Convert(nvarchar(5),Convert(int,update_count)+1) 
                Where within_code=@within_code and id=@id";
                //移交單明細表
                const string sql_d_i =
                @"INSERT INTO jo_materiel_con_details
                (within_code,id,sequence_id,jo_id,jo_sequence_id,mo_id,goods_id,con_qty,unit_code,sec_qty,sec_unit,package_num,location,carton_code,lot_no,qc_result) Values
                (@within_code,@id,@sequence_id,@jo_id,@jo_sequence_id,@mo_id,@goods_id,@con_qty,'PCS',@sec_qty,'KG',@package_num,@location,@carton_code,@lot_no,@qc_result)";

                const string sql_d_u =
                @"UPDATE jo_materiel_con_details SET jo_id=@jo_id,jo_sequence_id=@jo_sequence_id,mo_id=@mo_id,goods_id=@goods_id,con_qty=@con_qty,sec_qty=@sec_qty,package_num=@package_num,
                location=@location,carton_code=@carton_code,lot_no=@lot_no,qc_result=@qc_result 
                WHERE within_code=@within_code AND id=@id AND sequence_id=@sequence_id";
                //更新最大單據編號
                const string sql_bill_code_i = 
                @"Insert Into sys_bill_max_jo07(within_code,bill_id,bill_code,bill_text1,bill_text2,bill_text3)
                    Values(@within_code,'JO07',@bill_code,'T',@out_dept,@in_dept)";
                const string sql_bill_code_u =
                @"UPDATE sys_bill_max_jo07 SET bill_code=@bill_code WHERE within_code=@within_code AND bill_text1='T' AND bill_text2=@out_dept AND bill_text3=@in_dept";

                //string rowStatus;
                bool save_flag = false;
                string out_dept, in_dept;
                out_dept = cboOut_dept.Text.Trim();
                in_dept = cboIn_dept.Text.Trim();
                //SqlConnection myCon = new SqlConnection(DBUtility.dgcf_pad_connectionString);
                SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                try
                {
                    int package_num;
                    string sequence_id = ""; 
                    using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                    {
                        if (txtSate.Text == "") //新增數據，直接插入
                        {
                            //更新最大單據編號
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@within_code", "0000");
                            myCommand.Parameters.AddWithValue("@bill_code", strID.Substring(1,12));
                            myCommand.Parameters.AddWithValue("@out_dept", cboOut_dept.Text);
                            myCommand.Parameters.AddWithValue("@in_dept", cboIn_dept.Text);                            
                            if (strID.Substring(strID.Length - 5) != "00001")
                                myCommand.CommandText = sql_bill_code_u;
                            else
                                myCommand.CommandText = sql_bill_code_i;//第一張單據
                            myCommand.ExecuteNonQuery();

                            //主表
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@within_code", "0000");
                            myCommand.Parameters.AddWithValue("@id", strID);
                            myCommand.Parameters.AddWithValue("@con_date", dtpDate.Text);
                            myCommand.Parameters.AddWithValue("@out_dept", out_dept);
                            myCommand.Parameters.AddWithValue("@in_dept", in_dept);
                            myCommand.Parameters.AddWithValue("@ransfers_state", "0");
                            myCommand.Parameters.AddWithValue("@state", "0");
                            myCommand.Parameters.AddWithValue("@bill_type_no", "T");
                            myCommand.Parameters.AddWithValue("@con_type", "0");
                            myCommand.Parameters.AddWithValue("@stock_type", "0");
                            myCommand.Parameters.AddWithValue("@bill_origin", "2");
                            myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                            myCommand.Parameters.AddWithValue("@servername", "hkserver.cferp.dbo");
                            if (txtSate.Text == "")
                                myCommand.CommandText = sql_h_i;
                            else
                                myCommand.CommandText = sql_h_u;
                            myCommand.ExecuteNonQuery();

                            //明細表                                               
                            for (int i = 0; i < dtData.Rows.Count; i++)
                            {
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@within_code", "0000");
                                myCommand.Parameters.AddWithValue("@id", strID);
                                sequence_id = (i + 1).ToString("0000") + "h";
                                myCommand.Parameters.AddWithValue("@sequence_id", sequence_id);
                                myCommand.Parameters.AddWithValue("@jo_id", dtData.Rows[i]["jo_id"].ToString());
                                myCommand.Parameters.AddWithValue("@jo_sequence_id", dtData.Rows[i]["jo_sequence_id"].ToString());
                                myCommand.Parameters.AddWithValue("@mo_id", dtData.Rows[i]["mo_id"].ToString());
                                myCommand.Parameters.AddWithValue("@goods_id", dtData.Rows[i]["goods_id"].ToString());
                                myCommand.Parameters.AddWithValue("@con_qty", int.Parse(dtData.Rows[i]["con_qty"].ToString()));
                                //myCommand.Parameters.AddWithValue("@sec_qty", float.Parse(dtData.Rows[i]["sec_qty"].ToString()));
                                myCommand.Parameters.AddWithValue("@sec_qty", Math.Round(float.Parse(dtData.Rows[i]["sec_qty"].ToString()),2));                                
                                if (!string.IsNullOrEmpty(dtData.Rows[i]["package_num"].ToString()))
                                    package_num = int.Parse(dtData.Rows[i]["package_num"].ToString());
                                else
                                    package_num = 0;
                                myCommand.Parameters.AddWithValue("@package_num", package_num);
                                myCommand.Parameters.AddWithValue("@location", out_dept);
                                myCommand.Parameters.AddWithValue("@carton_code", out_dept);
                                myCommand.Parameters.AddWithValue("@lot_no", dtData.Rows[i]["lot_no"].ToString());
                                myCommand.Parameters.AddWithValue("@qc_result", dtData.Rows[i]["qc_result"].ToString());
                                myCommand.CommandText = sql_d_i;
                                myCommand.ExecuteNonQuery();
                            }

                            //生成義702QC的移交單
                            if (dgvDetails_qc.RowCount > 0)
                            {
                                //更新最大單據編號
                                string strIDQC = Get_Max_No(cboOut_dept.Text, "702");
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@within_code", "0000");
                                myCommand.Parameters.AddWithValue("@bill_code", strIDQC.Substring(1, 12));//不可以將前綴將寫入
                                myCommand.Parameters.AddWithValue("@out_dept", cboOut_dept.Text);
                                myCommand.Parameters.AddWithValue("@in_dept", "702");                                
                                if (strIDQC.Substring(strIDQC.Length - 5) != "00001")
                                    myCommand.CommandText = sql_bill_code_u;
                                else
                                    myCommand.CommandText = sql_bill_code_i;//第一張單據
                                myCommand.ExecuteNonQuery();
                                
                                //主表
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@within_code", "0000");
                                myCommand.Parameters.AddWithValue("@id", strIDQC);
                                myCommand.Parameters.AddWithValue("@con_date", dtpDate.Text);
                                myCommand.Parameters.AddWithValue("@out_dept", out_dept);
                                myCommand.Parameters.AddWithValue("@in_dept", "702");
                                myCommand.Parameters.AddWithValue("@ransfers_state", "0");
                                myCommand.Parameters.AddWithValue("@state", "0");
                                myCommand.Parameters.AddWithValue("@bill_type_no", "T");
                                myCommand.Parameters.AddWithValue("@con_type", "0");
                                myCommand.Parameters.AddWithValue("@stock_type", "0");
                                myCommand.Parameters.AddWithValue("@bill_origin", "2");
                                myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                                myCommand.Parameters.AddWithValue("@servername", "hkserver.cferp.dbo");
                                if (txtSate.Text == "")
                                    myCommand.CommandText = sql_h_i;
                                else
                                    myCommand.CommandText = sql_h_u;
                                myCommand.ExecuteNonQuery();

                                //明細表                                                     
                                for (int i = 0; i < dtQC_Data.Rows.Count; i++)
                                {
                                    myCommand.Parameters.Clear();
                                    myCommand.Parameters.AddWithValue("@within_code", "0000");
                                    myCommand.Parameters.AddWithValue("@id", strIDQC);
                                    sequence_id = (i + 1).ToString("0000") + "h";
                                    myCommand.Parameters.AddWithValue("@sequence_id", sequence_id);
                                    myCommand.Parameters.AddWithValue("@jo_id", dtQC_Data.Rows[i]["jo_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@jo_sequence_id", dtQC_Data.Rows[i]["jo_sequence_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@mo_id", dtQC_Data.Rows[i]["mo_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@goods_id", dtQC_Data.Rows[i]["goods_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@con_qty", int.Parse(dtQC_Data.Rows[i]["prod_qty"].ToString()));
                                    //myCommand.Parameters.AddWithValue("@sec_qty", float.Parse(dtQC_Data.Rows[i]["sec_qty"].ToString()));
                                    myCommand.Parameters.AddWithValue("@sec_qty", Math.Round(float.Parse(dtQC_Data.Rows[i]["sec_qty"].ToString()), 2));  
                                    if (!string.IsNullOrEmpty(dtQC_Data.Rows[i]["package_num"].ToString()))
                                        package_num = int.Parse(dtQC_Data.Rows[i]["package_num"].ToString());
                                    else
                                        package_num = 0;
                                    myCommand.Parameters.AddWithValue("@package_num", package_num);
                                    myCommand.Parameters.AddWithValue("@location", out_dept);
                                    myCommand.Parameters.AddWithValue("@carton_code", out_dept);
                                    myCommand.Parameters.AddWithValue("@lot_no", dtQC_Data.Rows[i]["lot_no"].ToString());
                                    myCommand.Parameters.AddWithValue("@qc_result", "");
                                    myCommand.CommandText = sql_d_i;
                                    myCommand.ExecuteNonQuery();
                                }
                            }
                        }                            
                        else //=====================================================查找出來修改
                        {
                            //未批準的舊數據
                            //狀態為【未批準】即已保存的數據重新查出來修改或編輯
                            //更新主表
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@within_code", "0000");
                            myCommand.Parameters.AddWithValue("@id", strID);
                            myCommand.Parameters.AddWithValue("@con_date", dtpDate.Text);
                            myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                            myCommand.CommandText = sql_h_u;
                            myCommand.ExecuteNonQuery();
                            //更新明細表
                            string rowStatus;
                            for (int i = 0; i < dtData.Rows.Count; i++)
                            {
                                rowStatus = dtData.Rows[i].RowState.ToString();
                                if (rowStatus == "Modified" || rowStatus == "Added")
                                {
                                    if (rowStatus == "Modified")
                                    {
                                        sequence_id = dtData.Rows[i]["sequence_id"].ToString();
                                        myCommand.CommandText = sql_d_u;
                                    }
                                    else
                                    {
                                        sequence_id = GetMax_Sequence_id(strID);
                                        myCommand.CommandText = sql_d_i;
                                    }
                                }
                                else
                                    continue;//未修改到的記錄直接返回
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@within_code", "0000");
                                myCommand.Parameters.AddWithValue("@id", strID);
                                myCommand.Parameters.AddWithValue("@sequence_id", sequence_id);
                                myCommand.Parameters.AddWithValue("@jo_id", dtData.Rows[i]["jo_id"].ToString());
                                myCommand.Parameters.AddWithValue("@jo_sequence_id", dtData.Rows[i]["jo_sequence_id"].ToString());
                                myCommand.Parameters.AddWithValue("@mo_id", dtData.Rows[i]["mo_id"].ToString());
                                myCommand.Parameters.AddWithValue("@goods_id", dtData.Rows[i]["goods_id"].ToString());
                                myCommand.Parameters.AddWithValue("@con_qty", int.Parse(dtData.Rows[i]["con_qty"].ToString()));
                                //myCommand.Parameters.AddWithValue("@sec_qty", float.Parse(dtData.Rows[i]["sec_qty"].ToString()));
                                myCommand.Parameters.AddWithValue("@sec_qty", Math.Round(float.Parse(dtData.Rows[i]["sec_qty"].ToString()), 2));  
                                if (!string.IsNullOrEmpty(dtData.Rows[i]["package_num"].ToString()))
                                    package_num = int.Parse(dtData.Rows[i]["package_num"].ToString());
                                else
                                    package_num = 0;
                                myCommand.Parameters.AddWithValue("@package_num", package_num);
                                myCommand.Parameters.AddWithValue("@location", out_dept);
                                myCommand.Parameters.AddWithValue("@carton_code", out_dept);
                                myCommand.Parameters.AddWithValue("@lot_no", dtData.Rows[i]["lot_no"].ToString());
                                myCommand.Parameters.AddWithValue("@qc_result", dtData.Rows[i]["qc_result"].ToString());                                
                                myCommand.ExecuteNonQuery();
                            }

                            //生成義702QC的移交單
                            if (dgvDetails_qc.RowCount > 0)
                            {
                                //更新最大單據編號
                                string strIDQC = Get_Max_No(cboOut_dept.Text, "702");
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@within_code", "0000");
                                myCommand.Parameters.AddWithValue("@bill_code", strIDQC.Substring(1,12));//不可以將前綴將寫入
                                myCommand.Parameters.AddWithValue("@out_dept", cboOut_dept.Text);
                                myCommand.Parameters.AddWithValue("@in_dept", "702");
                                if (strIDQC.Substring(strIDQC.Length - 5) != "00001")
                                    myCommand.CommandText = sql_bill_code_u;
                                else
                                    myCommand.CommandText = sql_bill_code_i;//第一張單據
                                myCommand.ExecuteNonQuery();

                                //主表
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@within_code", "0000");
                                myCommand.Parameters.AddWithValue("@id", strIDQC);
                                myCommand.Parameters.AddWithValue("@con_date", dtpDate.Text);
                                myCommand.Parameters.AddWithValue("@out_dept", out_dept);
                                myCommand.Parameters.AddWithValue("@in_dept", "702");
                                myCommand.Parameters.AddWithValue("@ransfers_state", "0");
                                myCommand.Parameters.AddWithValue("@state", "0");
                                myCommand.Parameters.AddWithValue("@bill_type_no", "T");
                                myCommand.Parameters.AddWithValue("@con_type", "0");
                                myCommand.Parameters.AddWithValue("@stock_type", "0");
                                myCommand.Parameters.AddWithValue("@bill_origin", "2");
                                myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                                myCommand.Parameters.AddWithValue("@servername", "hkserver.cferp.dbo");
                                //if (txtSate.Text == "")
                                    myCommand.CommandText = sql_h_i;
                                //else
                                //    myCommand.CommandText = sql_h_u;//??
                                myCommand.ExecuteNonQuery();

                                //明細表                                                     
                                for (int i = 0; i < dtQC_Data.Rows.Count; i++)
                                {
                                    myCommand.Parameters.Clear();
                                    myCommand.Parameters.AddWithValue("@within_code", "0000");
                                    myCommand.Parameters.AddWithValue("@id", strIDQC);
                                    sequence_id = (i + 1).ToString("0000") + "h";
                                    myCommand.Parameters.AddWithValue("@sequence_id", sequence_id);
                                    myCommand.Parameters.AddWithValue("@jo_id", dtQC_Data.Rows[i]["jo_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@jo_sequence_id", dtQC_Data.Rows[i]["jo_sequence_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@mo_id", dtQC_Data.Rows[i]["mo_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@goods_id", dtQC_Data.Rows[i]["goods_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@con_qty", int.Parse(dtQC_Data.Rows[i]["prod_qty"].ToString()));
                                    //myCommand.Parameters.AddWithValue("@sec_qty", float.Parse(dtQC_Data.Rows[i]["sec_qty"].ToString()));
                                    myCommand.Parameters.AddWithValue("@sec_qty", Math.Round(float.Parse(dtQC_Data.Rows[i]["sec_qty"].ToString()), 2));  
                                    if (!string.IsNullOrEmpty(dtQC_Data.Rows[i]["package_num"].ToString()))
                                        package_num = int.Parse(dtQC_Data.Rows[i]["package_num"].ToString());
                                    else
                                        package_num = 0;
                                    myCommand.Parameters.AddWithValue("@package_num", package_num);
                                    myCommand.Parameters.AddWithValue("@location", out_dept);
                                    myCommand.Parameters.AddWithValue("@carton_code", out_dept);
                                    myCommand.Parameters.AddWithValue("@lot_no", dtQC_Data.Rows[i]["lot_no"].ToString());
                                    myCommand.Parameters.AddWithValue("@qc_result", "");
                                    myCommand.CommandText = sql_d_i;
                                    myCommand.ExecuteNonQuery();
                                }
                            }
                        }
                        myTrans.Commit(); //數據提交
                        save_flag = true;
                    }
                }
                catch (Exception ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show(ex.Message);
                }
                finally 
                {
                    myCon.Close();
                    myCon.Dispose();
                    myTrans.Dispose();
                }

                if (save_flag)
                {
                    Operation_info("數 據 保 存 成 功!", Color.Blue);
                    //txtSate.Text = "未批準";
                    //txtIdqc.Text = "";
                    dtQC_Data.Clear();
                    Clear();
                    cboOut_dept.Enabled = false;
                    cboIn_dept.Enabled = false;
                    btnSave.Enabled = false;
                }
                else
                {
                    Operation_info("數 據 保 存 失 敗!", Color.Red);
                }
                txtBarCode.Focus(); 
            }
        }

        private bool Save_Valid()
        {
            bool flag = true;
            if (txtSate.Text == "已批準")
            {                
                flag = false;
                MessageBox.Show("此單已批準,不可保存", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (cboOut_dept.Text == "" && cboIn_dept.Text == "")
            {
                flag = false;
                MessageBox.Show("負責部門或收貨部門不可為空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (dgvDetails.RowCount == 0)
            {
                flag = false;
                MessageBox.Show("明細資料不可為空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return flag;
        }

        private bool Check_Department_Valid(string pDept)
        {
            bool flag;
            string strSql = string.Format(@"Select '1' From cd_storehouse_popedom with(nolock) Where within_code='0000' and user_id='{0}' and location_type='S' AND location_id='{1}'", DBUtility._user_id, pDept);
            DataTable dt = new DataTable();
            dt = clsPublicOfGeo.ExecuteSqlReturnDataTable(strSql);
            if (dt.Rows.Count > 0 || DBUtility._user_id == "ADMIN")
                flag = true;
            else
            {
                flag = false;
                MessageBox.Show(string.Format("對不起,你沒有【{0}】部門的操作權限!",pDept), "提示信息", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            return flag;
        }

        private void Operation_info(string msg, Color fore_clr)
        {
            lblSaveinfo.Text = msg;
            lblSaveinfo.ForeColor = fore_clr;
            lblSaveinfo.Visible = true;
            Delay(1200); // 延時1.2秒
            lblSaveinfo.Visible = false;
        }

        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }

        private string GetMax_Sequence_id(string pID)
        {
            string seq_id;
            string sql = string.Format(@"Select max(Sequence_id) as Sequence_id From {0}jo_materiel_con_details with(nolock) Where within_code='0000' and id='{1}'",
                DBUtility._user_id, pID);
            DataTable dt=clsPublicOfPad.ExecuteSqlReturnDataTable(sql);
            seq_id=dt.Rows[0]["Sequence_id"].ToString();
            seq_id = (int.Parse(seq_id.Substring(0, seq_id.Length - 1)) + 1).ToString("0000") + "h";
            return seq_id;
        }

        private void mskDat1_Leave(object sender, EventArgs e)
        {
            dtp2.Text = dtp1.Text;
        }

        private void txtMO1_Leave(object sender, EventArgs e)
        {
            txtMO2.Text = txtMO1.Text;
        }

        private void txtDept1_Leave(object sender, EventArgs e)
        {
            txtDept2.Text = txtDept1.Text;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Find_Data();
        }

        private void Find_Data()
        {
            if (txtDept1.Text == "" && txtDept2.Text == "" && txtMO1.Text == "" && txtMO2.Text == "")
            {
                MessageBox.Show("查找條件不可為空!","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }           
            string strSql =
                @"Select A.id,A.con_date,A.out_dept,A.in_dept,A.check_by,A.check_date,A.state,
                B.sequence_id,B.mo_id,B.goods_id,Convert(int,B.con_qty) AS con_qty,Convert(decimal(12,2),B.sec_qty) AS sec_qty,B.lot_no,B.package_num,B.qc_result,
                Convert(int,B.con_qty) as old_qty,Convert(decimal(12,2),B.sec_qty) as old_sec_qty,C.name as goods_name,B.jo_id,B.jo_sequence_id
                From jo_materiel_con_mostly A with(nolock) 
                INNER JOIN jo_materiel_con_details B with(nolock) ON A.within_code=B.within_code AND A.id=B.id
                LEFT OUTER JOIN it_goods C with(nolock) ON B.within_code=C.within_code and B.goods_id=C.id 
                WHERE A.within_code='0000' AND A.state='0'";
            if (txtDept1.Text != "")
                strSql += String.Format(" AND A.out_dept>='{0}'", txtDept1.Text);
            if (txtDept2.Text != "")
                strSql += String.Format(" AND A.out_dept<='{0}'", txtDept2.Text);
            if (dtp1.Text != "")
                strSql += String.Format(" AND A.con_date>='{0}'", dtp1.Text);
            if (dtp2.Text != "")
                strSql += String.Format(" AND A.con_date<='{0}'", dtp2.Text);
            if (txtCrusr1.Text != "")
                strSql += String.Format(" AND A.create_by>='{0}'",txtCrusr1.Text);
            if (txtCrusr2.Text != "")
                strSql += String.Format(" AND A.create_by<='{0}'",txtCrusr2.Text);

            if (txtMO1.Text != "")
                strSql += String.Format(" AND B.mo_id>='{0}'",txtMO1.Text);
            if (txtMO2.Text != "")
                strSql += String.Format(" AND B.mo_id<='{0}'",txtMO2.Text);

            strSql += " ORDER BY A.id,B.sequence_id";

            dtFind = clsPublicOfGeo.ExecuteSqlReturnDataTable(strSql);
            dgvDetails2.DataSource = dtFind;

            if (dtFind.Rows.Count == 0)
            {
                MessageBox.Show("無滿足條件的數據!","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            if (!btnSave.Enabled)
                btnSave.Enabled = true;
        }

        private void dgvDetails2_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails2.RowCount > 0)
            {  
                int i = dgvDetails2.CurrentRow.Index;
                string strid = dgvDetails2.Rows[i].Cells["id1"].Value.ToString();
                //如果Page1中的值與Page2中當前記錄為同一張單則直接返回                
                if (dtData.Rows.Count > 0)
                {
                    if (dtData.Rows[0]["id"].ToString() == strid) 
                    {
                        return;
                    }
                }
                //Page1中的值為空或與Page2中當前記錄為不是同一張單則才進行后面的操作
                dtData.Clear();
                dtQC_Data.Clear();
                txtId.Text = strid;
                cboOut_dept.Text = dgvDetails2.Rows[i].Cells["out_dept"].Value.ToString();
                cboIn_dept.Text = dgvDetails2.Rows[i].Cells["in_dept"].Value.ToString();
                dtpDate.Text = dgvDetails2.Rows[i].Cells["con_date"].Value.ToString();
                txtCheck_by.Text = dgvDetails2.Rows[i].Cells["check_by"].Value.ToString();
                txtCheck_date.Text = dgvDetails2.Rows[i].Cells["check_date"].Value.ToString();
                if (dgvDetails2.Rows[i].Cells["state"].Value.ToString() == "0")
                {
                    txtSate.Text = "未批準";
                    //cboOut_dept.Enabled = false;
                    //cboIn_dept.Enabled = false;
                }
                if (dgvDetails2.Rows[i].Cells["state"].Value.ToString() == "1")
                {
                    txtSate.Text = "已批準";
                    //cboOut_dept.Enabled = false;
                    //cboIn_dept.Enabled = false;
                }
                cboOut_dept.Enabled = false;
                cboIn_dept.Enabled = false;

                DataRow[] rds= dtFind.Select(string.Format("id='{0}'",strid));
                DataRow new_row = null;
                foreach (DataRow dr in rds)
                {
                    new_row = dtData.NewRow();
                    new_row["mo_id"] = dr["mo_id"].ToString();
                    new_row["goods_id"] = dr["goods_id"].ToString();
                    new_row["goods_name"] = dr["goods_name"].ToString();
                    new_row["lot_no"] = dr["lot_no"].ToString();
                    new_row["con_qty"] = dr["con_qty"];
                    new_row["sec_qty"] = dr["sec_qty"];
                    new_row["package_num"] = dr["package_num"];
                    new_row["id"] = dr["id"].ToString();
                    new_row["sequence_id"] = dr["sequence_id"].ToString();
                    new_row["qc_result"] = dr["qc_result"].ToString();
                    new_row["old_qty"] = dr["old_qty"];
                    new_row["old_sec_qty"] = dr["old_sec_qty"];
                    new_row["jo_id"] = dr["jo_id"].ToString();
                    new_row["jo_sequence_id"] = dr["jo_sequence_id"].ToString();
                    dtData.Rows.Add(new_row);
                }              
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            tbcDetails.SelectedIndex = 0;
            txtBarCode.Focus();
        }

        private void mskDat1_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void mskDat2_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtMO1_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtMO2_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private static void cboOut_dept_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private static void cboIn_dept_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtQty_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtSec_qty_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtPackage_num_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtCrusr1_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }
        private void txtCrusr2_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void btnItemDel_Click(object sender, EventArgs e)
        {
            if (dgvDetails_qc.RowCount > 0)
            {
                DialogResult result = MessageBox.Show("是否要刪除當前資料?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {                    
                    dtQC_Data.Rows.RemoveAt(dgvDetails_qc.CurrentRow.Index);
                    dtQC_Data.AcceptChanges();                    
                }                    
            }
        }

        private void dgvDetails_qc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                clsUtility.Call_imput();                
            }
        }

        private void txtCrusr1_Leave(object sender, EventArgs e)
        {
            txtCrusr2.Text = txtCrusr1.Text;
        }

        private void dgvLotno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLotno.RowCount > 0)
            {
                txtLot.Text = dtLotNo.Rows[dgvLotno.CurrentRow.Index]["lot_no"].ToString();
                txtQty.Text = dtLotNo.Rows[dgvLotno.CurrentRow.Index]["qty"].ToString();
                txtSec_qty.Text = dtLotNo.Rows[dgvLotno.CurrentRow.Index]["sec_qty"].ToString();

                int cur_row = int.Parse(txtCurrentRow.Text);               
                dtData.Rows[cur_row]["con_qty"] = txtQty.Text;
                dtData.Rows[cur_row]["sec_qty"] = txtSec_qty.Text;
                dtData.Rows[cur_row]["lot_no"] = txtLot.Text;//ADD BY 2017-04-27
                dtData.Rows[cur_row]["old_qty"] = dtLotNo.Rows[dgvLotno.CurrentRow.Index]["old_qty"].ToString();
                dtData.Rows[cur_row]["old_sec_qty"] = dtLotNo.Rows[dgvLotno.CurrentRow.Index]["old_sec_qty"].ToString(); 
                txtBarCode.Focus();
            }            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlLot.Visible = false;
            txtBarCode.Focus();
        }

        private void txtBarCode_Enter(object sender, EventArgs e)
        {
            if (chkKeyBoard.Checked)
            {
                clsUtility.Call_imput();
            }
        }

      
    }
}
