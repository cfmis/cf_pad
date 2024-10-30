using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf_pad.CLS;
using RUI.PC;
using cf_pad.MDL;
using cf_pad.Reports;
using System.IO;

namespace cf_pad.Forms
{
    public partial class frmCheckOutQty : Form
    {
        private string _userid = DBUtility._user_id.ToUpper();
        private static DataTable dtTransferDetails = new DataTable();
        private static DataTable dtWfDetails = new DataTable();
        private string strbarcode;
        private int select_type;//用來控制各種查詢的類別
        private string remote_tb = DBUtility.remote_db;
        public frmCheckOutQty()
        {
            InitializeComponent();
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
                    DataTable dtBarCode = clsPublicOfPad.BarCodeToItem(txtBarCode.Text);
                    txtBarCode.Text = "";
                    if (dtBarCode.Rows.Count > 0)
                    {
                        string barcode_type = dtBarCode.Rows[0]["barcode_type"].ToString();
                        if (barcode_type == "11" || barcode_type=="12")//從移交單貨貨倉發貨單中提取的條形碼
                        {
                            txtWid.Text = dtBarCode.Rows[0]["doc_id"].ToString();
                            txtWseq.Text = dtBarCode.Rows[0]["doc_seq"].ToString();
                            select_type = 1;
                        }
                        else
                        {
                            if (barcode_type == "2")//從生產計劃中提取的條形碼
                            {
                                txtIn_dept.Text = dtBarCode.Rows[0]["next_wp_id"].ToString();
                                txtMo_id.Text = dtBarCode.Rows[0]["mo_id"].ToString();
                                txtOut_dept.Text = dtBarCode.Rows[0]["wp_id"].ToString();
                                txtMat_item.Text = dtBarCode.Rows[0]["goods_id"].ToString();
                                select_type = 2;
                            }
                        }
                    }
                    else
                        return;
                    
                    ShowMoRemark();//顯示制單的備註
                    SelectData();


                    if (dgvDetails.Rows.Count == 1 && dgvWipDetails.Rows.Count == 1)
                    {
                        //UpdateCheckOutQty(1);//當兩個表都是一條記錄時，自動確認點貨
                        //以下為判斷備註中是否有合併電鍍，已取消(2016/05/27)
                        if (CheckMergePlateMo(txtMo_id.Text) == false)//如果制單備註中沒有合併的制單，就自動確認
                            UpdateCheckOutQty(1);//當兩個表都是一條記錄時，自動確認點貨
                        //else
                        //{
                        //    MessageBox.Show("制單備註中有合併的制單，不能自動確認!");
                        //    return;
                        //}
                    }
                    if (dgvDetails.Rows.Count == 0 && dgvWipDetails.Rows.Count > 0)
                    {
                        UpdateCheckOutQty(3);//當沒有外發記錄，而有移交記錄時，自動確認為未開單
                    }
                    break;
            }
            
        }
        //檢查備註中是否有多個制單
        private bool CheckMultMo()
        {
            string str1=txtPlate_remark.Text.Trim();
            string str2="";
            bool result=false;
            int len=str1.Length;

            for (int i = 0; i < len; i++)
            {
                str2 = str1.Substring(i, 1);
                if (str2 == "G" || str2 == "T" || str2 == "S" || str2 == "W" || str2 == "R" || str2 == "N")
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private bool CheckMergePlateMo(string mo_id)
        {
            bool result = false;
            string strSql = "Select id FROM "+remote_tb+"op_unite_details Where within_code='0000'" + " AND mo_id='" + mo_id + "'";
            DataTable dtMerge = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            if (dtMerge.Rows.Count > 0)
            {
                string doc_id = dtMerge.Rows[0]["id"].ToString();
                strSql = "Select mo_id FROM " + remote_tb + "op_unite_details Where within_code='0000'" + " AND id='" + doc_id + "'";
                DataTable dtIsMerge = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
                if (dtIsMerge.Rows.Count > 0)
                {
                    string merge_mo = "";
                    for (int i = 0; i < dtIsMerge.Rows.Count; i++)
                    {
                        merge_mo += dtIsMerge.Rows[i]["mo_id"].ToString() + "/";
                    }
                    result = true;
                    MessageBox.Show("存在合併發貨的制單："+merge_mo);
                }
            }
            return result;
        }

        private void SelectData()
        {
            //if (txtVend_id.Text.Trim() == "")
            //{
            //    MessageBox.Show("請先輸入供應商!");
            //    txtVend_id.Focus();
            //    return;
            //}
            string tdep = "";
            string fdep = "";
            string mo_id = "";
            string wp_item = "";
            string wp_doc = "";
            string wp_seq = "";
            string wp_dat1 = "";
            string wp_dat2 = "";
            string wf_item = "";
            string wf_doc = "";
            string wf_seq = "";
            string wf_dat1 = "";
            string wf_dat2 = "";
            string vend_id = "";
            int is_count = 0;
            if (mtkPDat.Text.Trim() != "/  /")
            {
                wp_dat1 = mtkPDat.Text.Trim();
                wp_dat2 = Convert.ToDateTime(wp_dat1).AddDays(1).ToString("yyyy/MM/dd");
            }
            if (mtkDat.Text.Trim() != "/  /")
            {
                //wp_dat1 = mtkDat.Text.Trim();
                //wp_dat2 = Convert.ToDateTime(wp_dat1).AddDays(1).ToString("yyyy/MM/dd");
                wf_dat1 = mtkDat.Text.Trim();
                wf_dat2 = Convert.ToDateTime(wf_dat1).AddDays(1).ToString("yyyy/MM/dd");
            }
            switch (select_type)
            {
                case 1://條碼按移交單編號查找
                    {
                        wp_doc = txtWid.Text;
                        wp_seq = txtWseq.Text;
                        break;
                    }
                case 2://條碼按制單編號
                    {
                        tdep = txtIn_dept.Text;
                        fdep = txtOut_dept.Text;
                        mo_id = txtMo_id.Text;
                        wp_item = txtMat_item.Text;
                        wf_item = wp_item;
                        break;
                    }
                case 3://按確認後的狀態更新
                    {
                        wf_doc = txtPid.Text;
                        wf_seq = txtPseq.Text;
                        tdep = txtIn_dept.Text;
                        fdep = txtOut_dept.Text;
                        mo_id = txtMo_id.Text;
                        wp_item = txtMat_item.Text;
                        wf_item = wp_item;
                        break;
                    }
                case 4://暫停
                    {
                        wf_doc = txtPid.Text;
                        wf_seq = txtPseq.Text;
                        tdep = txtIn_dept.Text;
                        fdep = txtOut_dept.Text;
                        mo_id = txtMo_id.Text;
                        wp_item = txtMat_item.Text;
                        wf_item = wp_item;
                        break;
                    }
                case 5://未開外發單
                    {
                        wf_doc = "ZZZ";
                        wf_seq = "ZZZ";
                        if (wp_dat1 == "")//若移交日期未空，則只查找當日所開的移交單
                        {
                            wp_dat1 = System.DateTime.Now.ToString("yyyy/MM/dd");
                            wp_dat2 = System.DateTime.Now.AddDays(1).ToString("yyyy/MM/dd");
                        }
                        tdep = txtIn_dept.Text;
                        fdep = txtOut_dept.Text;
                        mo_id = txtMo_id.Text;
                        wp_item = txtMat_item.Text;
                        wf_item = wp_item;
                        break;
                    }
                case 6://未點貨的外發單，//判斷查找外發單是否未點貨，當為1時，只顯示未點貨的記錄
                    {
                        is_count = 1;
                        if (wf_dat1=="")
                        {
                            wf_dat1 = System.DateTime.Now.ToString("yyyy/MM/dd");
                            wf_dat2 = System.DateTime.Now.AddDays(1).ToString("yyyy/MM/dd");
                            mtkDat.Text = wf_dat1;
                        }
                        wf_doc = "";
                        wf_seq = "";
                        tdep = "ZZZ";
                        fdep = "ZZZ";
                        mo_id = "";
                        wp_item = "ZZZ";
                        wf_item = "";

                        break;
                    }
                case 7://取消設定
                    {
                        wp_doc = txtPid.Text;
                        wp_seq = txtPseq.Text;
                        wf_doc = txtWid.Text;
                        wf_seq = txtWseq.Text;
                        if (wp_doc == "")
                        {
                            wp_doc = "ZZZ";
                            wp_seq = "ZZZ";
                        }
                        if (wf_doc == "")
                        {
                            wf_doc = "ZZZ";
                            wf_seq = "ZZZ";
                        }
                        break;
                    }
                case 8://按外發加工單號查詢
                    {
                        is_count = 0;
                        if (wf_dat1 == "")
                        {
                            wf_dat1 = System.DateTime.Now.ToString("yyyy/MM/dd");
                            wf_dat2 = System.DateTime.Now.AddDays(1).ToString("yyyy/MM/dd");
                            mtkDat.Text = wf_dat1;
                        }
                        wf_doc = txtPid.Text.Trim();
                        wf_seq = "";
                        tdep = "ZZZ";
                        fdep = "ZZZ";
                        mo_id = "";
                        wp_item = "ZZZ";
                        wf_item = "";

                        break;
                    }
                default: break;
            }
            

            if (select_type != 5)
            {
                //提取移交單資料
                dtTransferDetails = clsCheckOutQty.GetWipDetails(tdep, fdep, mo_id, wp_item, wp_doc, wp_seq, wp_dat1, wp_dat2);
                dgvWipDetails.DataSource = dtTransferDetails;
                if (select_type == 1 && dgvWipDetails.Rows.Count > 0)//條碼按移交單編號查找
                {
                    //如果條碼是按照移交來查的，則就需要從移交單中找出物料編號，再由物料編號找出外發記錄
                    mo_id = dtTransferDetails.Rows[0]["mo_id"].ToString();
                    wf_item = dtTransferDetails.Rows[0]["goods_id"].ToString();
                }
            }
            else//提取未開外發單的移交單資料
            {
                string strSql = @" SELECT a.mo_id,a.goods_id,a.id,convert(varchar(10),b.con_date,111) AS con_date,a.sequence_id,a.check_flag" +
                " FROM jo_mat_check_out1 a " +
                " INNER JOIN " + remote_tb + "jo_materiel_con_mostly b ON a.within_code=b.within_code And a.id=b.id" +
                " WHERE a.within_code='0000' AND a.check_flag='N'";
                strSql += " AND b.con_date>='" + wp_dat1 + "'" + " AND b.con_date <'" + wp_dat2 + "'";
                //if (txtVend_id.Text != "")
                //    strSql += " AND a.vendor_id='" + txtVend_id.Text + "'";
                dgvWipDetails.DataSource = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            }
            //提取外發單資料
            dtWfDetails = clsCheckOutQty.GetWfDetails(is_count, vend_id, mo_id, wf_item, wf_doc, wf_seq, wf_dat1, wf_dat2);
            dgvDetails.DataSource = dtWfDetails;
            if (dgvDetails.Rows.Count == 0)
                MessageBox.Show("不存在外發加工單!");
            else
                ShowItemPic(dgvDetails.Rows[dgvDetails.CurrentRow.Index].Cells["colPGoods_id"].Value.ToString());//顯示產品圖片
            CleanTextBox();//清空文本框內容
            SetGridColor();//設置表格顏色
            FillTextBox();//填入數據到文本框
            ShowVendor();//顯示供應商
            ShowMoRemark();//顯示制單的備註
            if (txtFl_by.Text.Trim() == "501")
                MessageBox.Show("屬於最低消費單!");

        }
        
        private void SetGridColor()
        {
            double pweg = 0, cweg = 0, wweg = 0;
            string check_flag = "";
            //移交單記錄
            for (int i = 0; i < dgvWipDetails.Rows.Count; i++)
            {
                check_flag = dgvWipDetails.Rows[i].Cells["colWCheck_flag"].Value.ToString().Trim();
                if (check_flag == "Y")//已點貨
                {
                    dgvWipDetails.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(0x00, 0x33, 0xFF);
                    cweg = cweg + Convert.ToDouble(dgvWipDetails.Rows[i].Cells["colWSec_qty"].Value);
                }
                else
                {
                    if (check_flag == "N" || dtWfDetails.Rows.Count == 0)//未開單
                    {
                        dgvWipDetails.Rows[i].Cells["colWRecState"].Value = "未開單";
                        dgvWipDetails.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(0xFF, 0x00, 0x33);
                    }
                    else
                        dgvWipDetails.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                wweg = wweg + Convert.ToDouble(dgvWipDetails.Rows[i].Cells["colWSec_qty"].Value);

            }
            //標識外發加工單
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                check_flag = dgvDetails.Rows[i].Cells["colPCheck_flag"].Value.ToString().Trim();
                if (check_flag == "A")//全部確認
                    dgvDetails.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(0x00, 0x33, 0xFF);
                else
                {
                    if (check_flag == "B")//分批確認
                        dgvDetails.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(0x00, 0xFF, 0x66);
                    else
                    {
                        if (check_flag == "C")//暫停
                            dgvDetails.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        else
                            dgvDetails.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                }
                pweg = pweg + Convert.ToDouble(dgvDetails.Rows[i].Cells["colPSec_qty"].Value);
            }
            txtWfWeg.Text = pweg.ToString();
            txtWipWeg.Text = wweg.ToString();
            txtCountWeg.Text = cweg.ToString();
        }
        private void frmCheckOutQty_Load(object sender, EventArgs e)
        {
            Font a = new Font("GB2312", 14);//GB2312为字体名称，1为字体大小dataGridView1.Font = a;
            dgvWipDetails.Font = a;
            dgvWipDetails.Font = a;
            dgvWipDetails.AutoGenerateColumns = false;

            dgvDetails.Font = a;
            dgvDetails.Font = a;
            dgvDetails.AutoGenerateColumns = false;

            dgvCheckMo.Font = a;
            dgvCheckMo.Font = a;
            dgvCheckMo.AutoGenerateColumns = false;


            mtkDat.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            //mtkPDat.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            txtBarCode.Focus();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            UpdateCheckOutQty(1);//確認點貨
        }

        private void UpdateCheckOutQty(int upd_flag)
        {
            if (upd_flag == 1 || upd_flag ==2)
            {
                if (dgvDetails.Rows.Count == 0)
                {
                    MessageBox.Show("外發記錄為空!");
                    return;
                }
                if (dgvDetails.Rows[dgvDetails.CurrentRow.Index].Cells["colVend_id"].Value.ToString() != txtVend_id.Text.Trim().ToUpper())
                {
                    MessageBox.Show("外發供應商和當前供應商不一致!");
                    txtVend_id.Focus();
                    return;
                }
            }
            if (upd_flag != 4)//如果只是更新外發暫停的，則不用檢查移交單
            {
                if (dgvWipDetails.Rows.Count == 0)
                {
                    MessageBox.Show("移交記錄為空!");
                    return;
                }
            }
            int RowsCount = 0;
            int CurrentRow = 0;
            if (upd_flag == 1)//全部確認
            {
                CurrentRow = 0;
                RowsCount = dgvWipDetails.Rows.Count;
            }
            else//分批或未開單時只更新選中的記錄
            {
                if (upd_flag == 2 || upd_flag == 3)//部分確認或未開外發單，對選中的當前記錄進行更新
                {
                    CurrentRow = dgvWipDetails.CurrentRow.Index;
                    RowsCount = CurrentRow + 1;
                }
                else
                    if (upd_flag == 4)//這個是只更新外發單暫停的記錄
                    {
                        CurrentRow = 1;
                        RowsCount = CurrentRow + 1;
                    }
            }

            List<checkoutqty> listDetail = new List<checkoutqty>();
            for (int i = CurrentRow; i < RowsCount; i++)
            {
                checkoutqty objDetails = new checkoutqty();
                if (upd_flag == 1 || upd_flag == 2 || upd_flag == 3)//更新移交單：1-全部確認、2-分批確認、3-移交單未開外發單
                {
                    objDetails.id = dgvWipDetails.Rows[i].Cells["colWid"].Value.ToString();
                    objDetails.sequence_id = dgvWipDetails.Rows[i].Cells["colWSequence_id"].Value.ToString();
                    objDetails.mo_id = dgvWipDetails.Rows[i].Cells["colWMo_id"].Value.ToString();
                    objDetails.goods_id = dgvWipDetails.Rows[i].Cells["colWGoods_id"].Value.ToString();
                }
                if (upd_flag == 1 || upd_flag == 2 || upd_flag == 4)//更新外發單：1-全部確認、2-分批確認、4-暫停外發單
                {
                    objDetails.wf_id = dgvDetails.Rows[dgvDetails.CurrentRow.Index].Cells["colPid"].Value.ToString();
                    objDetails.wf_seq = dgvDetails.Rows[dgvDetails.CurrentRow.Index].Cells["colPSequence_id"].Value.ToString();
                    objDetails.vend_id = dgvDetails.Rows[dgvDetails.CurrentRow.Index].Cells["colVend_id"].Value.ToString();
                }
                else//如果只是更新未開外發單的
                {
                    objDetails.wf_id = "";
                    objDetails.wf_seq = "";
                    objDetails.vend_id = "";
                }
                if (upd_flag == 1)//全部確認
                {
                    objDetails.check_flag_wf = "A";//全部確認
                    objDetails.check_flag_wip = "Y";//已點貨
                }
                else
                {
                    if (upd_flag == 2)//分批確認
                    {
                        objDetails.check_flag_wf = "B";//分批確認
                        if(CheckBatchIsOne() ==1)
                            objDetails.check_flag_wf = "A";//如果分批的只剩一筆記錄，則自動設置為全部完成確認
                        objDetails.check_flag_wip = "Y";//已點貨
                    }
                    else
                    {
                        if (upd_flag == 3)//移交單未開外發單
                        {
                            objDetails.check_flag_wf = "";//未使用到
                            objDetails.check_flag_wip = "N";//移交單未開外發單
                        }
                        else
                        {
                            if (upd_flag == 4)//暫停外發單
                            {
                                objDetails.check_flag_wf = "C";//暫停外發
                                objDetails.check_flag_wip = "";//移交單未開外發單
                            }
                        }
                    }
                }
                objDetails.crusr = _userid;
                listDetail.Add(objDetails);
            }
            if (listDetail.Count > 0)
            {
                if (clsCheckOutQty.UpdateCheckOutQty(upd_flag,listDetail) < 0)
                    MessageBox.Show("儲存記錄失敗!");

            }
            SelectData();
            txtBarCode.Focus();
        }
        //檢查分批確認是否只剩一筆記錄
        private int CheckBatchIsOne()
        {
            int onlyone = 0;
            for (int i = 0; i < dgvWipDetails.Rows.Count; i++)
            {
                if (dgvWipDetails.Rows[i].Cells["colWCheck_flag"].Value.ToString() != "Y")
                    onlyone = onlyone + 1;
            }
            return onlyone;
        }
        private void btnBatch_Click(object sender, EventArgs e)
        {
            UpdateCheckOutQty(2);//分批確認
        }

        private void btnNoRec_Click(object sender, EventArgs e)
        {
            UpdateCheckOutQty(3);//未開外發單
        }
        //查找未開外發單記錄
        private void btnNoDoc_Click(object sender, EventArgs e)
        {
            select_type = 5;
            SelectData();
        }
        //查詢未點貨的記錄
        private void btnShowNoRec_Click(object sender, EventArgs e)
        {
            select_type = 6;
            SelectData();
        }
        //由移交單中顯示申請的供應商
        private void ShowVendor()
        {
            
            txtRVend_id.Text = "";
            if (dgvWipDetails.Rows.Count > 0 && select_type !=5)//如果是未開單的就不用顯示供應商
            {
                string strSql = "";
                string tdep = dgvWipDetails.Rows[dgvWipDetails.CurrentRow.Index].Cells["colWIn_dept"].Value.ToString();
                string mo_id = dgvWipDetails.Rows[dgvWipDetails.CurrentRow.Index].Cells["colWMo_id"].Value.ToString();
                string item = dgvWipDetails.Rows[dgvWipDetails.CurrentRow.Index].Cells["colWGoods_id"].Value.ToString();
                strSql = "Select a.vendor_id" + " FROM " + remote_tb + "op_outpro_mostly a" +
                        " Inner Join " + remote_tb + "op_outpro_goods_details b ON a.within_code=b.within_code AND a.id=b.id" +
                        " Inner Join " + remote_tb + "op_outpro_materiel_details c ON b.within_code=c.within_code AND b.id=c.id AND b.sequence_id=c.upper_sequence" +
                        " WHERE a.within_code='" + "0000" + "'" + " AND a.department_id ='" + tdep + "' " + " AND b.mo_id ='" + mo_id + "' " + " AND c.materiel_id ='" + item + "' ";
                DataTable dtVend = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
                if (dtVend.Rows.Count > 0)
                    txtRVend_id.Text = dtVend.Rows[0]["vendor_id"].ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            select_type = 7;
            checkoutqty objDetails = new checkoutqty();
            if (dgvWipDetails.Rows.Count > 0)
            {
                objDetails.id = dgvWipDetails.Rows[dgvWipDetails.CurrentRow.Index].Cells["colWid"].Value.ToString();
                objDetails.sequence_id = dgvWipDetails.Rows[dgvWipDetails.CurrentRow.Index].Cells["colWSequence_id"].Value.ToString();
            }
            else
            {
                objDetails.id = "";
                objDetails.sequence_id = "";
            }
            if (dgvDetails.Rows.Count > 0)
            {
                objDetails.wf_id = dgvDetails.Rows[dgvDetails.CurrentRow.Index].Cells["colPid"].Value.ToString();
                objDetails.wf_seq = dgvDetails.Rows[dgvDetails.CurrentRow.Index].Cells["colPSequence_id"].Value.ToString();
            }
            else//如果只是更新未開外發單的
            {
                objDetails.wf_id = "";
                objDetails.wf_seq = "";
            }
            txtPid.Text = objDetails.id;
            txtPseq.Text = objDetails.sequence_id;
            txtWid.Text = objDetails.wf_id;
            txtWseq.Text = objDetails.wf_seq;
            if (clsCheckOutQty.DeleteCheckOutQty(objDetails) < 0)
                MessageBox.Show("儲存記錄失敗!");

            SelectData();
            txtBarCode.Focus();
        }
        private void CleanTextBox()
        {
            txtWfWeg.Text = "";
            txtCountWeg.Text = "";
            txtWipWeg.Text = "";
            txtRVend_id.Text = "";

            txtMo_id.Text = "";
            txtOut_dept.Text = "";
            txtIn_dept.Text = "";
            txtGoods_id.Text = "";
            txtPlate_remark.Text = "";
            txtPGoods_name.Text = "";
            txtPid.Text = "";
            txtPseq.Text = "";
            txtMat_item.Text = "";
            txtWid.Text = "";
            txtWseq.Text = "";
            txtFl_by.Text = "";
        }
        //顯示制單的備註
        private void ShowMoRemark()
        {
            txtPlate_remark.Text = "";
            string strSql = "";
            string mo_id = txtMo_id.Text;
            strSql = "SELECT CONVERT(VARCHAR(200),plate_remark) AS plate_remark" +
                " FROM " + remote_tb + "so_order_details " +
                " Where within_code='0000' AND mo_id='" + mo_id + "'";
            DataTable dtOc = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            if (dtOc.Rows.Count > 0)
                txtPlate_remark.Text = dtOc.Rows[0]["plate_remark"].ToString();
        }
        private void FillTextBox()
        {
            int i = 0;
            if (dgvDetails.Rows.Count > 0)//外發單記錄
            {
                i = dgvDetails.CurrentRow.Index;
                txtMo_id.Text = dgvDetails.Rows[i].Cells["colPMo_id"].Value.ToString();
                txtGoods_id.Text = dgvDetails.Rows[i].Cells["colPGoods_id"].Value.ToString();
                txtPGoods_name.Text = dgvDetails.Rows[i].Cells["colPGoods_name"].Value.ToString();
                txtPid.Text = dgvDetails.Rows[i].Cells["colPid"].Value.ToString();
                txtPseq.Text = dgvDetails.Rows[i].Cells["colPSequence_id"].Value.ToString();
                txtFl_by.Text = dgvDetails.Rows[i].Cells["colPFl_by"].Value.ToString();
            }
            if (dgvWipDetails.Rows.Count > 0)//移交單記錄
            {
                i = dgvWipDetails.CurrentRow.Index;
                txtMo_id.Text = dgvWipDetails.Rows[i].Cells["colWMo_id"].Value.ToString();
                txtWid.Text = dgvWipDetails.Rows[i].Cells["colWId"].Value.ToString();
                txtWseq.Text = dgvWipDetails.Rows[i].Cells["colWSequence_id"].Value.ToString();
                txtMat_item.Text = dgvWipDetails.Rows[i].Cells["colWGoods_id"].Value.ToString();
                if (select_type != 5)//未開單的記錄，是不會提取部門資料的
                {
                    txtIn_dept.Text = dgvWipDetails.Rows[i].Cells["colWIn_dept"].Value.ToString();
                    txtOut_dept.Text = dgvWipDetails.Rows[i].Cells["colWOut_dept"].Value.ToString();
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            select_type = 4;
            UpdateCheckOutQty(4);//暫停
        }

        private void btnShowGrp_Click(object sender, EventArgs e)
        {
            if (btnShowGrp.Text == "更多")
            {
                btnShowGrp.Text = "隱藏";
                palGrpMore.Visible = true;
            }
            else
            {
                btnShowGrp.Text = "更多";
                palGrpMore.Visible = false;
            }
            txtBarCode.Focus();
        }

        private void btnClVend_Click(object sender, EventArgs e)
        {
            txtVend_id.Text = "";
            CleanTextBox();
            if (mtkDat.Text.Trim() == "/  /")
                mtkDat.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            txtVend_id.Focus();
        }

        private void btnGetMo_Click(object sender, EventArgs e)
        {
            if (btnGetMo.Text == "相關制單")
            {
                string str1 = txtPlate_remark.Text.Trim();
                int len = str1.Length;
                string str2 = "", str3 = "";
                bool new_tb = true;
                string check_flag = "";
                DataTable dtWfDoc = new DataTable();
                

                for (int i = 0; i < len; i++)
                {
                    str2 = str1.Substring(i, 1);
                    if (str2 == "G" || str2 == "T" || str2 == "S" || str2 == "W" || str2 == "R" || str2 == "N")
                    {
                        {
                            str3 = str1.Substring(i, 9);
                            DataTable dtMo = SelectWfMo(str3);
                            if (dtMo.Rows.Count > 0 && new_tb == true)//第一次時，要建立一個表，以便將記錄添加到這個表
                            {
                                dtWfDoc = dtMo.Clone();
                                new_tb = false;
                            }
                            for (int j = 0; j < dtMo.Rows.Count; j++)
                            {
                                DataRow newRow = dtWfDoc.NewRow();
                                newRow["id"] = dtMo.Rows[j]["id"].ToString();
                                newRow["con_date"] = dtMo.Rows[j]["con_date"].ToString();
                                newRow["sequence_id"] = dtMo.Rows[j]["sequence_id"].ToString();
                                newRow["mo_id"] = dtMo.Rows[j]["mo_id"].ToString();
                                newRow["sec_qty"] = dtMo.Rows[j]["sec_qty"].ToString();
                                newRow["goods_id"] = dtMo.Rows[j]["goods_id"].ToString();
                                newRow["goods_name"] = dtMo.Rows[j]["goods_name"].ToString();
                                newRow["check_flag"] = dtMo.Rows[j]["check_flag"].ToString();
                                newRow["vendor_id"] = dtMo.Rows[j]["vendor_id"].ToString();
                                newRow["prod_qty"] = dtMo.Rows[j]["prod_qty"].ToString();
                                newRow["do_color"] = dtMo.Rows[j]["do_color"].ToString();
                                newRow["RecState"] = SelectMoState(str3);//獲取制單收貨狀態//dtMo.Rows[j]["RecState"].ToString();
                                newRow["check_flag"] = dtMo.Rows[j]["check_flag"].ToString();
                                dtWfDoc.Rows.Add(newRow);
                            }

                            i = i + 9;
                        }
                    }
                }
                dgvCheckMo.DataSource = dtWfDoc;
                //設定顏色
                //for (int i = 0; i < dgvCheckMo.Rows.Count; i++)
                //{
                //    check_flag = dgvCheckMo.Rows[i].Cells["colSRecState"].Value.ToString().Trim();
                //    if (check_flag == "已齊")
                //    {
                //        dgvCheckMo.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                //    }
                //    else
                //    {
                //        if (check_flag == "部分")
                //        {
                //            dgvCheckMo.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                //        }
                //        else
                //            dgvCheckMo.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(0xFF, 0x00, 0x33);
                //    }

                //}


                palCheckMo.Visible = true;
                btnGetMo.Text = "隱藏";
            }
            else
            {
                {
                    btnGetMo.Text = "相關制單";
                    palCheckMo.Visible = false;
                }
            }
        }
        private DataTable SelectWfMo(string mo_id)
        {
            //提取外發單資料
            int is_count = 0;//
            string vend_id = txtVend_id.Text;
            string wf_item = "";
            string wf_doc = "";
            string wf_seq = "";
            string wf_dat1 = "";
            string wf_dat2 = "";
            
            DataTable dtMo = clsCheckOutQty.GetWfDetails(is_count, vend_id, mo_id, wf_item, wf_doc, wf_seq, wf_dat1, wf_dat2);
            
            //dgvDetails.DataSource = dtWfDetails;
            return dtMo;
        }
        //制單本部門收貨狀態
        private string SelectMoState(string mo_id)
        {
            string fdep = txtOut_dept.Text.Trim();
            string tdep = txtIn_dept.Text.Trim();
            string item = txtMat_item.Text.Trim();
            string result = "";
            float order_qty;
            float cp_qty;
            string strSql = " SELECT a.mo_id,b.goods_id,b.wp_id,b.next_wp_id,b.order_qty,b.c_qty_ok " +
                " FROM " + remote_tb + "jo_bill_mostly a " +
                " Inner Join " + remote_tb + "jo_bill_goods_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver" +
                " WHERE a.within_code='" + "0000" + "' AND a.mo_id ='" + mo_id + "' ";
            //if (fdep != "")
            //    strSql += " AND b.wp_id='" + fdep + "'";
            if (tdep == "")
                tdep = "501";
            strSql +=" AND b.next_wp_id='" + tdep + "'";
            strSql += " AND b.prod_qty > 0 AND b.order_qty > 0 ";
            //if (item == "")
            //    item = dgvDetails.Rows[dgvDetails.CurrentRow.Index].Cells["colPMat_item"].Value.ToString();
            //strSql +=" AND b.goods_id='" + item + "'";
            DataTable dtMo = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            if (dtMo.Rows.Count > 0)
            {
                string str_order_qty = dtMo.Rows[0]["order_qty"].ToString();
                string str_c_qty = dtMo.Rows[0]["c_qty_ok"].ToString();
                if (str_order_qty != "")
                    order_qty = Convert.ToSingle(str_order_qty);
                else
                    order_qty = 0;
                if (str_c_qty != "")
                    cp_qty = Convert.ToSingle(str_c_qty);
                else
                    cp_qty = 0;
                if (cp_qty >= order_qty)
                    result = "已齊";
                else
                    if (cp_qty < order_qty && cp_qty > 0)
                        result = "部分";
                    else
                        result = "未到貨";
            }
            return result;
        }
        private void mtkDat_MouseDown(object sender, MouseEventArgs e)
        {
            if (mtkDat.Text.Trim() == "/  /")
                mtkDat.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            clsUtility.Call_imput(); 
        }

        private void txtVend_id_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtVend_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBarCode.Focus();
        }

        private void btnShowDoc_Click(object sender, EventArgs e)
        {
            if (txtPid.Text.Trim() == "")
            {
                MessageBox.Show("外發單號為空!");
                txtPid.Focus();
                return;
            }
            select_type = 8;
            SelectData();
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

        private void dgvWipDetails_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FillTextBox();
            ShowMoRemark();
            ShowItemPic(dgvWipDetails.Rows[dgvWipDetails.CurrentRow.Index].Cells["colWGoods_id"].Value.ToString());//顯示產品圖片
            ShowVendor();//顯示申請的供應商
        }

        private void dgvCheckMo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowItemPic(dgvCheckMo.Rows[dgvCheckMo.CurrentRow.Index].Cells["colSGoods_id"].Value.ToString());//顯示產品圖片
        }

        private void dgvDetails_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FillTextBox();
            ShowMoRemark();
            ShowItemPic(dgvDetails.Rows[dgvDetails.CurrentRow.Index].Cells["colPGoods_id"].Value.ToString());//顯示產品圖片
        }

        private void btnFindByMo_Click(object sender, EventArgs e)
        {
            if (txtMo_id.Text == "")
            {
                MessageBox.Show("制單編號不能為空!");
                txtMo_id.Focus();
                return;
            }
            if (txtIn_dept.Text == "")
            {
                MessageBox.Show("部門不能為空!");
                txtIn_dept.Focus();
                return;
            }
            select_type = 2;
            SelectData();
        }

        private void mtkPDat_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtIn_dept_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }

        private void txtMo_id_MouseDown(object sender, MouseEventArgs e)
        {
            clsUtility.Call_imput();
        }
    }
}
