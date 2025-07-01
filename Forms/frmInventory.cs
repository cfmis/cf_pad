using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using cf_pad.MDL;
using cf_pad.CLS;
using System.IO;

namespace cf_pad.Forms
{
    public partial class frmInventory : Form
    {
        DataTable dtMoItem = new DataTable();
        DataTable dtInvView = new DataTable();
        string remote_db = DBUtility.remote_db;
        string user_id = DBUtility._user_id;
        private int BarCodeMinLength = 13;//這個為測試用，如果是正常的制單條碼，長度為10
        public frmInventory()
        {
            InitializeComponent();
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBarCode.Text.Trim().Length >= BarCodeMinLength)
                    doBarCode();
                txtBarCode.Focus();
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
                    bool input_flag = true;
                    string mo_id= dtBarCode.Rows[0]["mo_id"].ToString();
                    string goods_id = dtBarCode.Rows[0]["goods_id"].ToString().Trim();
                    DataTable dtInv = LoadData(1, cmbDep.SelectedValue.ToString(), txtMonth.Text.Trim(), "", mo_id, goods_id, "");
                    if (dtInv.Rows.Count > 0)
                    {
                        if (MessageBox.Show("已存在盤點記錄,確定繼續新增嗎?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            input_flag = false;
                        }
                    }
                    if (input_flag)
                    {
                        CleanTextPart();
                        txtMo.Text = mo_id;
                        dtMoItem = clsInventory.GetWipDataWithMo(mo_id, "", goods_id);
                        if (dtMoItem.Rows.Count == 0)
                            dtMoItem = clsInventory.GetWipDataWithMoMat(mo_id, cmbDep.SelectedValue.ToString().Trim(), goods_id);
                        SetCmbGoodsSource(1);
                        cmbGoodsId.SelectedValue = goods_id;
                        //if (dtMoItem.Rows.Count > 0)
                        //{
                        //    cmbGoodsId.SelectedValue = goods_id;
                        //    DataRow[] drs = dtMoItem.Select("goods_id= '" + goods_id + "'");
                        //    txtGoodsName.Text = drs[0]["goods_name"].ToString();//獲取物料描述
                        //}


                        GetGoodsStock();
                    }
                    else
                    {
                        txtId.Text = dtInv.Rows[0]["id"].ToString();
                        FindData();
                    }
                }
                
                
            }

        }

        private void GetGoodsStock()
        {
            string goods_id = cmbGoodsId.SelectedValue != null ? cmbGoodsId.SelectedValue.ToString() : "";
            if (dtMoItem.Rows.Count > 0)
            {
                DataRow[] drs = dtMoItem.Select("goods_id= '" + goods_id + "'");
                txtGoodsName.Text = drs[0]["goods_name"].ToString();//獲取物料描述
            }
            
            DataTable dtSt = clsInventory.GetGoodsStock(cmbDep.SelectedValue.ToString(), txtMo.Text.Trim(), goods_id);
            if (dtSt.Rows.Count > 0)
            {
                DataRow dr = dtSt.Rows[0];
                //txtGoodsName.Text = dr["goods_cname"].ToString();//獲取物料描述
                txtQty.Text = dr["st_qty"].ToString();
                txtWeg.Text = dr["st_weg"].ToString();
            }
            else
            {
                //txtGoodsName.Text = "";
                txtQty.Text = "0";
                txtWeg.Text = "0";
            }
        }
        
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CleanText();
            txtBarCode.Focus();
        }
        private void CleanText()
        {
            txtBarCode.Text = "";
            txtId.Text = "";
            CleanTextPart();
        }
        private void CleanTextPart()
        {
            txtMo.Text = "";
            txtGoodsName.Text = "";
            txtQty.Text = "";
            txtWeg.Text = "";
            txtSeq.Text = "";
            txtPackNum.Text = "";
            SetCmbGoodsSource(0);
            txtBarCode.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidData())
                return;
            Save();
        }
        private bool ValidData()
        {
            bool result = true;
            if (cmbDep.SelectedValue == null || cmbDep.SelectedValue.ToString() == "")
            {
                result = false;
                MessageBox.Show("部門不能為空!");
                cmbDep.Focus();
            }
            else if (txtMonth.Text.Trim()=="/")
            {
                result = false;
                MessageBox.Show("盤點月份不能為空!");
                txtMonth.Focus();
            }else if (!clsValidRule.IsNumeric(txtWeg.Text))
            {
                MessageBox.Show("重量格式有誤,請重新輸入!");
                txtWeg.Focus();
                txtWeg.SelectAll();
                return false;
            }
            else if (!clsValidRule.IsNumeric(txtQty.Text))
            {
                MessageBox.Show("數量格式有誤,請重新輸入!");
                txtQty.Focus();
                txtQty.SelectAll();
                return false;
            }
            return result;
        }
        private void Save()
        {
            string strSql = "";
            string id = txtId.Text.Trim();
            string loc_id = cmbDep.SelectedValue.ToString();
            string seq = txtSeq.Text.Trim();
            string st_month = txtMonth.Text.Trim();
            string mo_id = txtMo.Text.Trim();
            string prd_group= cmbGroup.SelectedValue != null ? cmbGroup.SelectedValue.ToString() : "";
            string goods_id = cmbGoodsId.SelectedValue != null ? cmbGoodsId.SelectedValue.ToString() : "";
            string pack_num = txtPackNum.Text.Trim();
            string loc_she = cmbShe.SelectedValue != null ? cmbShe.SelectedValue.ToString().Trim() : "";
            decimal st_qty,st_weg = 0;
            st_qty = txtQty.Text != "" ? Convert.ToInt32(txtQty.Text.Trim()) :  0;
            st_weg = txtWeg.Text != "" ? Convert.ToDecimal(txtWeg.Text.Trim()) : 0;
            if (!CheckInventoryID(id))//id=="" || 
            {
                id = GetInventoryID(loc_id, st_month);
                txtId.Text = id;
            }
            if (!CheckInventorySeq(id, seq))//seq=="" || 
            {
                seq = GetInventorySeq(id);
                strSql = @"insert into product_inventory (id,seq,st_month,loc_id,mo_id,goods_id,st_qty,st_weg,prd_group,pack_num,loc_she,update_user,update_time )
                         Values(@id,@seq,@st_month,@loc_id,@mo_id,@goods_id,@st_qty,@st_weg,@prd_group,@pack_num,@loc_she, @update_user,GETDATE())";
            }
            else
                strSql = @"Update product_inventory Set st_month=@st_month,loc_id=@loc_id,mo_id=@mo_id,goods_id=@goods_id"
                    + ",st_qty=@st_qty,st_weg=@st_weg,prd_group=@prd_group,pack_num=@pack_num,loc_she=@loc_she"
                    + ",update_user=@update_user,update_time=GETDATE()" +
                    " Where id=@id And seq=@seq ";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@id",id),
                new SqlParameter("@seq",seq),
                new SqlParameter("@st_month",st_month),
                new SqlParameter("@loc_id",loc_id),
                new SqlParameter("@mo_id",mo_id),
                new SqlParameter("@goods_id",goods_id),
                new SqlParameter("@st_qty",st_qty),
                new SqlParameter("@st_weg",st_weg),
                new SqlParameter("@prd_group",prd_group),
                new SqlParameter("@pack_num",pack_num),
                new SqlParameter("@loc_she",loc_she),
                new SqlParameter("@update_user",user_id)
            };
            int result = clsPublicOfPad.ExecuteNonQueryReturnInt(strSql, paras);

            if (result == 1)
            {
                MessageBox.Show("儲存盤點記錄成功!");
                FindData();
            }
            else
                MessageBox.Show("儲存盤點記錄失敗!");
            txtBarCode.Focus();
        }
        private bool CheckInventoryID(string id)
        {
            bool result = false;
            string strSql = " Select id " +
                " From product_inventory " +
                " Where id='" + id + "'";
            DataTable dtInv = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            if (dtInv.Rows.Count > 0)
                result = true;
            return result;
        }
        private string GetInventoryID(string dep,string st_month)
        {
            string id = "";
            string id_month = st_month.Substring(0, 4) + st_month.Substring(5, 2);
            string id1 = dep + id_month + "001";
            string id2 = dep + id_month + "999";
            string strSql = " Select Max(id) As id From product_inventory Where id>='" + id1 + "' And id<='" + id2 + "'";
            DataTable dtInv = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);//105202505551
            if (dtInv.Rows[0]["id"].ToString() != "")
                id = dep + id_month + (Convert.ToInt32(dtInv.Rows[0]["id"].ToString().Substring(9, 3)) + 1).ToString().PadLeft(3, '0');
            else
                id = id1;
            return id;
        }
        private bool CheckInventorySeq(string ID,string Seq)
        {
            bool result = false;
            string strSql = " Select Seq From product_inventory Where id='" + ID + "' And Seq='" + Seq + "'";
            DataTable dtInv = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            if (dtInv.Rows.Count > 0)
                result = true;
            return result;
        }
        private string GetInventorySeq(string ID)
        {
            string Seq = "";
            string strSql = " Select Max(Seq) As Seq From product_inventory Where id='" + ID + "'";
            DataTable dtInv = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            if (dtInv.Rows[0]["Seq"].ToString() != "")
                Seq = (Convert.ToInt32(dtInv.Rows[0]["Seq"].ToString()) + 1).ToString().PadLeft(3, '0');
            else
                Seq = "001";
            return Seq;
        }
        private void frmInventory_Load(object sender, EventArgs e)
        {
            dgvInv.AutoGenerateColumns = false;
            dgvInvFind.AutoGenerateColumns = false;
            DataTable dtPrd_dept = clsGetBaseData.GetPrdDep();
            //初始化生產部門
            cmbDep.DataSource = dtPrd_dept;
            cmbDep.DisplayMember = "int9loc";
            cmbDep.ValueMember = "int9loc";
            if (user_id.Substring(0, 3) == "BLK")
                cmbDep.SelectedValue = "105";
            txtMonth.Text = System.DateTime.Now.ToString("yyyy/MM/dd").Substring(0, 7);
            SetComBoxSource();
            reportViewer1.RefreshReport();
        }
        private void SetComBoxSource()
        {
            
            string dep = cmbDep.SelectedValue != null ? cmbDep.SelectedValue.ToString().Trim() : "";
            //部門組別
            DataTable dtGroup = clsGetBaseData.GetDepGroup(dep, "1");
            cmbGroup.DataSource = dtGroup;
            cmbGroup.DisplayMember = "work_group";
            cmbGroup.ValueMember = "work_group";
            //部門貨架
            DataTable dtShe = clsGetBaseData.GetDepGroup(dep, "3");
            cmbShe.DataSource = dtShe;
            cmbShe.DisplayMember = "work_group";
            cmbShe.ValueMember = "work_group";
            //部門貨架--查找
            DataTable dtSheFind = clsGetBaseData.GetDepGroup(dep, "3");
            cmbSheFind.DataSource = dtSheFind;
            cmbSheFind.DisplayMember = "work_group";
            cmbSheFind.ValueMember = "work_group";

            if (dep == "105")
            {
                if (user_id == "BLK01")
                    cmbGroup.SelectedValue = "BC01";
                else if (user_id == "BLK02")
                    cmbGroup.SelectedValue = "BC02";
                else if (user_id == "BLK03")
                    cmbGroup.SelectedValue = "BC03";
                else if (user_id == "BLK04")
                    cmbGroup.SelectedValue = "BC04";
                else if (user_id == "BLK05")
                    cmbGroup.SelectedValue = "BC05";
                else if (user_id == "BLK06")
                    cmbGroup.SelectedValue = "BC06";
            }
            txtBarCode.Focus();

        }

        private void GetMoDataSource()//從生產表或排期表或流程中獲取記錄
        {
            
        }
        private void txtMo_Leave(object sender, EventArgs e)
        {
            GetMoItem();
        }

        private void GetMoItem()
        {
            cmbGoodsId.Text = "";
            txtGoodsName.Text = "";
            //cmb.Items.Clear();

            //處理一些本部門幫其它部門生產的單
            string prd_dep = cmbDep.SelectedValue != null ? cmbDep.SelectedValue.ToString().Trim() : "";//txtWipDep.Text.Trim();//
            if (prd_dep == "")
                prd_dep = "999";
            string dep_group = "(" + prd_dep + ")";

            if (prd_dep == "128")//如果是洗油的，本部門沒有流程，可能是幫其它部門做的
                dep_group = "(128,102,108,124,122)";
            else if (prd_dep == "104")//如果是洗油的，本部門沒有流程，可能是幫其它部門做的
                dep_group = "(104,124,122)";
            dtMoItem = clsInventory.GetWipDataWithMo(txtMo.Text.Trim(), dep_group, "");
            SetCmbGoodsSource(1);
        }
        private void SetCmbGoodsSource(int clean_flag)
        {
            if (clean_flag == 0)
                dtMoItem = clsInventory.GetWipDataWithMo("ZZZZZZZZZ", "(999)", "");
            cmbGoodsId.DataSource = dtMoItem;
            cmbGoodsId.DisplayMember = "goods_dep";
            cmbGoodsId.ValueMember = "goods_id";

        }

        private void cmbGoodsId_Leave(object sender, EventArgs e)
        {
            GetGoodsStock();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            tc1.SelectedIndex = 1;
            FindData();
            txtBarCode.Focus();
        }
        private void FindData()
        {
            if (!ValidData())
                return;
            string loc_id = cmbDep.SelectedValue != null ? cmbDep.SelectedValue.ToString() : "";
            string st_month = txtMonth.Text;
            DataTable dtInv = new DataTable();
            if (tc1.SelectedIndex==0)
            {
                string id = txtId.Text.Trim();
                dtInv = LoadData(1, loc_id, st_month, id, "", "", "");
                dgvInv.DataSource = dtInv;
            }
            else
            {
                string id = txtIdFind.Text.Trim();
                string mo_id = txtMoFind.Text.Trim();
                string loc_she = cmbSheFind.SelectedValue != null ? cmbSheFind.SelectedValue.ToString() : "";
                dtInvView = LoadData(2, loc_id, st_month, id, mo_id, "", loc_she);
                dgvInvFind.DataSource = dtInvView;
                dgvInvFind.Visible = true;
                reportViewer1.Visible = false;
            }
        }
        private DataTable LoadData(int rpt_type,string loc_id,string st_month,string id,string mo_id,string goods_id,string loc_she)
        {
            string strSql = "";
            string prd_group = cmbGroup.SelectedValue != null ? cmbGroup.SelectedValue.ToString().Trim() : "";
            strSql = " Select a.id,a.seq,a.st_month,a.loc_id,a.mo_id,a.goods_id,b.name AS goods_name,a.st_qty,a.st_weg" +
                    ",a.prd_group,a.pack_num,a.loc_she,a.update_user,Convert(Varchar(20),a.update_time,120) AS update_time" +
                    ",Substring(a.goods_id,15,4) AS goods_type" +
                    " From product_inventory a" +
                    " Left Join dgcf_db.dbo.geo_it_goods b On a.goods_id=b.id COLLATE chinese_taiwan_stroke_CI_AS " +
                    " Where a.id>=''";
            if (loc_id != "")
                strSql += " And a.loc_id='" + loc_id + "'";
            if (st_month != "")
                strSql += " And a.st_month='" + st_month + "'";
            if (id.Trim() != "")
                strSql += " And a.id='" + id + "'";
            if (mo_id.Trim() != "")
                strSql += " And a.mo_id='" + mo_id + "'";
            if (goods_id.Trim() != "")
                strSql += " And a.goods_id='" + goods_id + "'";
            if (prd_group.Trim() != "")
                strSql += " And a.prd_group='" + prd_group + "'";
            if (loc_she.Trim() != "")
                strSql += " And a.loc_she='" + loc_she + "'";
            if (rpt_type == 1)
            {
                
                strSql += " Order By a.update_time Desc ";
            }
            else
            {
                strSql += " Order By loc_id,prd_group,loc_she,id,seq,update_time Desc";
                //strSql += " Order By a.update_time Desc ";
                //strSql += " Order By prd_group,prd_group,goods_type ";
            }
            DataTable dtInv = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            return dtInv;
        }

        private void dgvInv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvInv.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvInv.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvInv.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dgvInv_SelectionChanged(object sender, EventArgs e)
        {
            fill_textbox();//填充各種控件
        }

        //填充各種控件
        private void fill_textbox()
        {
            //DataRowView rowView = (DataRowView)dgvInv.CurrentRow.DataBoundItem;
            //DataRow currentDataRow = rowView.Row;
            //cmbDep.SelectedValue = currentDataRow["loc_id"].ToString();
            //txtMonth.Text = currentDataRow["st_month"].ToString();
            //txtId.Text = currentDataRow["id"].ToString();
            //txtSeq.Text = currentDataRow["seq"].ToString();
            //txtMo.Text = currentDataRow["mo_id"].ToString();
            //txtQty.Text = currentDataRow["st_qty"].ToString();
            //txtWeg.Text = currentDataRow["st_weg"].ToString();
            //GetMoItem();
            //cmbGoodsId.SelectedValue = currentDataRow["goods_id"].ToString();
            //txtGoodsName.Text = currentDataRow["goods_name"].ToString();

            DataGridViewRow currentRow = dgvInv.CurrentRow;
            
            if (currentRow != null)
            {
                cmbDep.SelectedValue = currentRow.Cells["colLocId"].Value.ToString();
                txtMonth.Text = currentRow.Cells["colStMonth"].Value.ToString();
                txtId.Text = currentRow.Cells["colId"].Value.ToString();
                txtSeq.Text = currentRow.Cells["colSeq"].Value.ToString();
                txtMo.Text = currentRow.Cells["colMoId"].Value.ToString();
                txtQty.Text = currentRow.Cells["colStQty"].Value.ToString();
                txtWeg.Text = currentRow.Cells["colStWeg"].Value.ToString();
                cmbGroup.SelectedValue = currentRow.Cells["colPrdGroup"].Value.ToString();
                txtPackNum.Text = currentRow.Cells["colPackNum"].Value.ToString();
                cmbShe.SelectedValue = currentRow.Cells["colLocShe"].Value.ToString().Trim();
                GetMoItem();
                cmbGoodsId.SelectedValue = currentRow.Cells["colGoodsId"].Value.ToString();
                txtGoodsName.Text = currentRow.Cells["colGoodsName"].Value.ToString();
            }



            txtBarCode.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定要刪除嗎?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //int prd_id = record_id;
                int re = Delete();
                if (re > 0)
                {
                    //MessageBox.Show("刪除成功!");
                    FindData();

                }
                else
                {
                    MessageBox.Show("刪除失敗!");
                }
            }
            txtBarCode.Focus();
        }
        private int Delete()
        {
            int result = 0;
            string id = txtId.Text.Trim();
            string seq = txtSeq.Text.Trim();
            string strSql = " Delete From product_inventory Where id='" + id + "' And seq='" + seq + "'";
            result= clsPublicOfPad.ExecuteSqlUpdate(strSql);
            return result;
        }

        private void dgvInvFind_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dgvInvFind.CurrentRow;

            if (currentRow != null)
            {
                txtId.Text = currentRow.Cells["colIdFind"].Value.ToString();
            }
        }

        private void tc1_Click(object sender, EventArgs e)
        {
            FindData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dtInvView.Rows.Count == 0)
            {
                dgvInvFind.Visible = true;
                reportViewer1.Visible = false;
                MessageBox.Show("沒有找到符合條件的記錄!");
                return;
            }
            reportViewer1.PrintDialog();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            tc1.SelectedIndex = 1;
            FindData();
            txtBarCode.Focus();
            if (dtInvView.Rows.Count == 0)
            {
                dgvInvFind.Visible = true;
                reportViewer1.Visible = false;
                MessageBox.Show("沒有找到符合條件的記錄!");
                return;
            }
            dgvInvFind.Visible = false;
            reportViewer1.Visible = true;
            string strReportPath = "";
            strReportPath = Application.StartupPath;
            //MessageBox.Show(strReportPath);
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            string fileName = strReportPath + @"\Reports\" + "rptInventory.rdlc";
            //MessageBox.Show(fileName);
            this.reportViewer1.LocalReport.ReportPath = fileName;
            this.reportViewer1.LocalReport.DataSources.Clear();
            //向報表傳遞多個參數
            List<ReportParameter> para1 = new List<ReportParameter>();            //这里是添加两个字段
            para1.Add(new ReportParameter("userId", user_id));
            reportViewer1.LocalReport.SetParameters(para1);
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ds_inventory", dtInvView));
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            //reportViewer1.PrintDialog();
            this.reportViewer1.RefreshReport();
        }

        private void dgvInvFind_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvInvFind.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvInvFind.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvInvFind.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void txtQty_MouseDown(object sender, MouseEventArgs e)
        {
            txtQty.SelectAll();
        }

        private void txtWeg_MouseDown(object sender, MouseEventArgs e)
        {
            txtWeg.SelectAll();
        }

        private void btnExpToExcel_Click(object sender, EventArgs e)
        {
            ExpToExcel();
        }

        /// 簡易匯出Excel
        /// </summary>
        private void ExpToExcel()
        {
            if (dtInvView.Rows.Count == 0)
            {
                MessageBox.Show("沒有找到符合條件的記錄!");
                return;
            }
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel files(*.xls)|*.xls";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";
            //DateTime now = DateTime.Now;
            //saveFile.FileName = now.ToShortDateString();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = saveFile.OpenFile();

                //frmProgress wForm = new frmProgress();
                //new Thread((ThreadStart)delegate
                //{
                //    wForm.TopMost = true;
                //    wForm.ShowDialog();
                //}).Start();

                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));



                string str = " ";
                //写标题
                str += "序號";
                str += "\t" + "制單編號";
                str += "\t" + "物料編號";
                str += "\t" + "物料描述";
                str += "\t" + "數量";
                str += "\t" + "重量";
                str += "\t" + "盤點單號";
                str += "\t" + "組別";
                str += "\t" + "包數";
                str += "\t" + "顏色分類";
                str += "\t" + "貨架";
                sw.WriteLine(str);
                //写内容

                int excelNo = 1;
                for (int rowNo = 0; rowNo < dtInvView.Rows.Count; rowNo++)
                {
                    DataRow drMo = dtInvView.Rows[rowNo];
                    string tempstr = " ";
                    tempstr = "=\"" + excelNo.ToString() + "\"";//序號
                    tempstr += "\t" + drMo["mo_id"].ToString();
                    tempstr += "\t" + drMo["goods_id"].ToString();
                    tempstr += "\t" + drMo["goods_name"].ToString();
                    tempstr += "\t" + drMo["st_qty"].ToString();
                    tempstr += "\t" + drMo["st_weg"].ToString();
                    tempstr += "\t" + "=\"" + drMo["id"].ToString() + "\"";
                    tempstr += "\t" + drMo["prd_group"].ToString();
                    tempstr += "\t" + "=\"" + drMo["pack_num"].ToString() + "\"";
                    tempstr += "\t" + "=\"" + drMo["goods_type"].ToString() + "\"";
                    tempstr += "\t" + "=\"" + drMo["loc_she"].ToString() + "\"";
                    sw.WriteLine(tempstr);

                    excelNo++;
                    //}
                }

                sw.Close();
                myStream.Close();
                //wForm.Invoke((EventHandler)delegate { wForm.Close(); });
                MessageBox.Show("已匯出記錄！");
            }
        }

        private void cmbDep_Leave(object sender, EventArgs e)
        {
            SetComBoxSource();
        }

        private void cmbShe_MouseDown(object sender, MouseEventArgs e)
        {
            txtWeg.SelectAll();
        }
    }
}
