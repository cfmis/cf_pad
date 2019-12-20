using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using cf_pad.CLS;
using System.IO;
using cf_pad.MDL;

namespace cf_pad.Forms
{
    public partial class frmIqcOpNg : Form
    {

        private bool blPermission;
        private string within_code = DBUtility.within_code;
        private string user_id = DBUtility._user_id;
        private string remote_tb = DBUtility.remote_db;

        public frmIqcOpNg()
        {
            InitializeComponent();
                 
        }

        private void frmIqcOpNg_Load(object sender, EventArgs e)
        {
            dgvDetails2.AutoGenerateColumns = false;
            txtBarCode.Focus();           
            
            //FQC組別下的用戶才可以保存、刪除
            string sql=string.Format(@"SELECT user_id FROM DGERP2.cferp.dbo.sys_user WHERE user_id='{0}' and group_id LIKE '%QC%'", DBUtility._user_id);
            DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(sql);
            if (dt.Rows.Count > 0 || user_id == "ADMIN")
                blPermission = true;
            else
                blPermission = false;
            dt.Dispose();
            initWorker();//初始化綁定combobox的工號

            sql = @"Select distinct unqualified_iqc_seq as cdesc,unqualified_category as id From DGERP2.cferp.dbo.op_iqc_mostly WHERE unqualified_category>'Q'";
            DataTable dt1 = clsPublicOfPad.ExecuteSqlReturnDataTable(sql);
            DataRow dr= dt1.NewRow();
            dt1.Rows.Add(dr);
            dt1.DefaultView.Sort = "id ASC";
            cmbUnqualified_iqc_seq.DataSource = dt1;
            cmbUnqualified_iqc_seq.DisplayMember = "cdesc";
            cmbUnqualified_iqc_seq.ValueMember = "cdesc";

            sql = @"SELECT '' as id,'' as cdesc Union SELECT gtyp_code as id,gtyp_cdesc as cdesc FROM bs_type_group WHERE gtyp_code in ('Q1','Q2')";
            cmbUnqualified_category.DataSource = DBUtility.ExecuteSqlReturnDataTable(sql);
            cmbUnqualified_category.DisplayMember = "cdesc";
            cmbUnqualified_category.ValueMember = "id";

        }
        
        
        /// <summary>
        /// 初始化綁定combobox的工號
        /// </summary>
        private void initWorker()
        {
            cmbWorker.DataSource = clsProductQCRecords.InitWorker("P13-00", "P13-00","159");
            cmbWorker.DisplayMember = "hrm1name";
            cmbWorker.ValueMember = "hrm1wid";
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }           

        private void btnSave_Click(object sender, EventArgs e)
        {           
            string sql_f = string.Format(
                @"SELECT iqc_result FROM op_outpro_in_detail with(nolock) Where within_code ='0000' and id='{0}' and sequence_id ='{1}'",txtBill_id.Text,txtSequence_id.Text);
            DataTable dt = clsPublicOfGeo.ExecuteSqlReturnDataTable(sql_f);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("此頁數尚未進行收貨入庫QC檢驗，將無法進行此異常處理的操作!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt.Dispose();
                return;
            }
            dt.Dispose();

            if (!blPermission)
            {
                MessageBox.Show(string.Format("當前用戶【{0}】沒有此操作權限!", user_id), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //if (!chkNg.Checked)
            //{
            //    MessageBox.Show("請首先勾選檢驗結果選項(請選擇：NG) !", "提示信息");
            //    return;
            //}  
         
            //if (cmbWorker.SelectedValue==null || cmbWorker.SelectedValue.ToString() == "")
            //{
            //    MessageBox.Show("工號不能為空!", "提示信息");
            //    cmbWorker.Focus();
            //    return;
            //}    
            product_ipqc objModel = new product_ipqc();
            objModel.doc_id = txtID.Text;
            objModel.state = cmbNot_ok_rmk.Text;/*處理方法*/
            if (string.IsNullOrEmpty(cmbWorker.Text))
                objModel.qc_by = "";
            else
                objModel.qc_by = cmbWorker.SelectedValue.ToString();/*工號*/
            objModel.unqualified_iqc_seq = cmbUnqualified_iqc_seq.Text;
            if (string.IsNullOrEmpty(cmbUnqualified_category.Text))
                objModel.unqualified_category = "";
            else
                objModel.unqualified_category = cmbUnqualified_category.SelectedValue.ToString();
            objModel.qc_remark = txtQc_remark.Text;/*備註*/ 
            objModel.mo_no = txtMo_id.Text;
            objModel.crusr = user_id;
            objModel.iqc_state = "2";/*設置QC狀態*/
            objModel.sequence_id = txtSequence_id.Text;
            objModel.mat_item = txtBill_id.Text;/*外發入庫單據編號*/
                        

            if (chkNg.Checked)
                objModel.iqc_result = "0";
            if (chkOk.Checked)
                objModel.iqc_result = "1";
            
            //objModel.qc_date 為處理結果
            switch(objModel.state)
            {
                case "翻電":
                    objModel.qc_date ="001";
                    break ;
                 case "移交":
                    objModel.qc_date ="002";
                    break ;
                 case "分選":
                    objModel.qc_date ="003";
                    break ;
                 case "報廢":
                    objModel.qc_date ="004";
                    break ;
                default :
                    objModel.qc_date="";
                    break ;
            }           

            if (string.IsNullOrEmpty(objModel.qc_by))
            {
                objModel.qc_by = user_id;
            }           
            int result = clsCheckOutQty.UpdateIpqc_NG(objModel);
            if (result > 0)
            {
                Operation_info("儲存QC記錄成功!");
                txtBarCode.Text = objModel.mo_no;
                LoadData();
                txtBarCode.Text = "";
                for (int i = 0; i < dgvDetails2.Rows.Count; i++)
                {
                    if (dgvDetails2.Rows[i].Cells["id"].Value.ToString() == objModel.doc_id)
                    {
                        dgvDetails2.Rows[i].Selected=true;
                        dgvDetails2.CurrentCell = dgvDetails2.Rows[i].Cells["mo_id"];
                        break;
                    }
                }
            }
            else
                MessageBox.Show("儲存QC記錄失敗!");
            txtIqc_state.Focus();            
        }


        private void Operation_info(string msg)//(string msg, Color fore_clr)
        {
            lblSaveinfo.Visible = true;
            lblSaveinfo.Text = msg;
            Delay(1200); // 延時1.2秒
            lblSaveinfo.Text = "";
            lblSaveinfo.Visible = false ;
        }
        
        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }
     
      
        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (txtBarCode.Text != "")
                    {
                        string strmo=txtBarCode.Text ;
                        if (strmo.Length > 9)
                            txtBarCode.Text = strmo.Substring(0, 9);
                        LoadData();
                    }
                    else
                        return;
                    txtBarCode.Text = "";
                    txtBarCode.Focus();
                    break;  
            }            
        }

        private void LoadData()
        {
            string strsql=string.Format(
            @"Select A.id,Convert(varchar(10),A.qc_date,120) as qc_date,A.vendor_id,A.vendor,A.mo_id,
            A.goods_id,Convert(int,A.issues_qty) as issues_qty,A.qc_result,A.remark,
            CASE ISNULL(B.disposal_method,'') 
             WHEN '001' THEN '翻電' 
             WHEN '002' THEN '移交' 
             WHEN '003' THEN '分揀' 
             WHEN '004' THEN '報廢'
            ELSE '' END AS disposal_method,
            A.check_person,Isnull(A.unqualified_iqc_seq,'') as unqualified_iqc_seq ,
            Isnull(A.unqualified_category,'') as unqualified_category,C.name as goods_name,
            dbo.Fn_get_picture_name('0000',A.goods_id,'out') as picture_name,
            Case When A.qc_state='2' Then '檢查完成' Else '' End as iqc_state,A.bill_id,A.sequence_id 
            FROM op_iqc_mostly A with(nolock),op_iqc_details B with(nolock) ,it_goods C with(nolock)
            WHERE A.within_code=B.within_code And A.id=B.id and A.within_code=C.within_code AND A.goods_id=C.id AND A.within_code='0000' AND A.mo_id='{0}' 
            AND A.state<>'2' AND B.waster_modality='001' ORDER BY A.qc_date Desc", txtBarCode.Text);
           
            DataTable dtReport = clsPublicOfGeo.ExecuteSqlReturnDataTable(strsql);

            dgvDetails2.DataSource = dtReport;
            if (dtReport.Rows.Count > 0)
                ShowQcRec(0);
            else
            {
                MessageBox.Show("此頁數還沒進行外發IQC檢驗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Text = "";
                txtMo_id.Text = "";
                txtGoods_id.Text = "";
                txtGoods_Name.Text = "";
                txtQcdate.Text = "";
                cmbUnqualified_iqc_seq.Text = "";
                cmbUnqualified_category.Text = "";
                cmbWorker.Text = "";
                cmbNot_ok_rmk.Text = "";
                txtQc_remark.Text = "";
                txtIqc_state.Text = "";
                txtBill_id.Text = "";
                txtSequence_id.Text = "";
                Set_Artwork(null);
                chkOk.Checked = false;
                chkNg.Checked = false;
            }
        }

        private void ShowQcRec(int row_index)
        {
            txtID.Text = dgvDetails2.Rows[row_index].Cells["id"].Value.ToString();
            txtMo_id.Text = dgvDetails2.Rows[row_index].Cells["mo_id"].Value.ToString();
            txtGoods_id.Text = dgvDetails2.Rows[row_index].Cells["goods_id"].Value.ToString();
            txtGoods_Name.Text = dgvDetails2.Rows[row_index].Cells["goods_name"].Value.ToString();
            txtQcdate.Text = dgvDetails2.Rows[row_index].Cells["qc_date"].Value.ToString(); //DateTime.Now.ToString("yyyy/MM/dd");
            cmbUnqualified_iqc_seq.SelectedValue = dgvDetails2.Rows[row_index].Cells["unqualified_iqc_seq"].Value.ToString();
            cmbUnqualified_category.SelectedValue = dgvDetails2.Rows[row_index].Cells["unqualified_category"].Value.ToString();
            //cmbWorker.Text = dgvDetails2.Rows[row_index].Cells["check_person"].Value.ToString();
            cmbWorker.SelectedValue = dgvDetails2.Rows[row_index].Cells["check_person"].Value.ToString();
            cmbNot_ok_rmk.Text = dgvDetails2.Rows[row_index].Cells["disposal_method"].Value.ToString();
            txtQc_remark.Text = dgvDetails2.Rows[row_index].Cells["remark"].Value.ToString();
            txtIqc_state.Text = dgvDetails2.Rows[row_index].Cells["iqc_state"].Value.ToString();
            txtBill_id.Text = dgvDetails2.Rows[row_index].Cells["bill_id"].Value.ToString();
            txtSequence_id.Text = dgvDetails2.Rows[row_index].Cells["sequence_id"].Value.ToString();
            Set_Artwork(dgvDetails2.Rows[row_index].Cells["picture_name"].Value.ToString());
            

            chkOk.Checked = false;
            chkNg.Checked = false;
            string iqc_result = dgvDetails2.Rows[row_index].Cells["qc_result"].Value.ToString();
            if (iqc_result == "1")
                chkOk.Checked = true;
            else
            {
                if (iqc_result == "0")
                    chkNg.Checked = true;
            }            
        }

        private void chkNg_Click(object sender, EventArgs e)
        {
            string iqc_result;
            if (chkNg.Checked)
            {
                chkOk.Checked = false;
                iqc_result = "0";
            }
            else
            {
                chkOk.Checked = true;
                iqc_result = "1";
            }
            if (dgvDetails2.Rows.Count > 0)
            {
                dgvDetails2.Rows[dgvDetails2.CurrentCell.RowIndex].Cells["qc_result"].Value = iqc_result;
            }
        }


        private void Set_Artwork(string artwork)
        {
            if (!string.IsNullOrEmpty(artwork))
            {
                if (File.Exists(artwork))
                    pic_artwork.Image = Image.FromFile(artwork);
                else
                    pic_artwork.Image = null;
            }
            else
                pic_artwork.Image = null;
        }

        private void txtRemark_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput(); 
        }
     
        private void dgvDetails2_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails2.RowCount > 0)
            {                
                ShowQcRec(dgvDetails2.CurrentCell.RowIndex);
            }
        }        

        private void txtBarCode_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput(); 
        }

        private void cmbUnqualified_iqc_seq_Leave(object sender, EventArgs e)
        {
            if (dgvDetails2.Rows.Count > 0)
            {
                dgvDetails2.Rows[dgvDetails2.CurrentCell.RowIndex].Cells["unqualified_iqc_seq"].Value = cmbUnqualified_iqc_seq.Text;
            }
        }

        private void cmbUnqualified_category_Leave(object sender, EventArgs e)
        {
            if (dgvDetails2.Rows.Count > 0)
            {
                if (cmbUnqualified_category.Text != "")
                   dgvDetails2.Rows[dgvDetails2.CurrentCell.RowIndex].Cells["unqualified_category"].Value = cmbUnqualified_category.SelectedValue.ToString();
            }
        }
        

        private void cmbWorker_Leave(object sender, EventArgs e)
        {
            if (dgvDetails2.Rows.Count > 0)
            {
                if(cmbWorker.Text !="")
                   dgvDetails2.Rows[dgvDetails2.CurrentCell.RowIndex].Cells["check_person"].Value = cmbWorker.SelectedValue.ToString();
            }
        }

        private void txtQc_remark_Leave(object sender, EventArgs e)
        {
            if (dgvDetails2.Rows.Count > 0)
            {
                dgvDetails2.Rows[dgvDetails2.CurrentCell.RowIndex].Cells["remark"].Value = txtQc_remark.Text;
            }            
        }

        private void cmbNot_ok_rmk_Leave(object sender, EventArgs e)
        {
            if (dgvDetails2.Rows.Count > 0)
            {               
                 dgvDetails2.Rows[dgvDetails2.CurrentCell.RowIndex].Cells["disposal_method"].Value = cmbNot_ok_rmk.Text;
            }
        }

     


    }
}
