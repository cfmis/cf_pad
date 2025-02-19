using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using cf_pad.MDL;
using cf_pad.CLS;

namespace cf_pad.Forms
{
    public partial class frmPackingMoRecords : Form
    {
        string remote_db = DBUtility.remote_db;
        private int BarCodeMinLength = 4;//這個為測試用，如果是正常的制單條碼，長度為10
        public frmPackingMoRecords()
        {
            InitializeComponent();
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBarCode.Text.Trim().Length > BarCodeMinLength)
                    doBarCode();
                txtBarCode.Focus();
            }
        }
        private void doBarCode()
        {
            string mo_id = "";
            mo_id = txtBarCode.Text.Trim();
            txtMo.Text = mo_id;
            txtBarCode.Text = "";
            string strSql = "";
            DataTable dtPk = chkPackingMo();
            if (dtPk.Rows.Count == 0)
            {
                strSql = " Select Convert(Int,a.order_qty*b.rate) As qty_pcs " +
                    " From " + remote_db + "so_order_details a " +
                    " Inner Join " + remote_db + "it_coding b On a.within_code=b.within_code And a.goods_unit=b.unit_code " +
                    " Where a.within_code='" + "0000" + "' And a.mo_id='" + mo_id + "' And b.id='" + "*" + "'";
                DataTable dtOc = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
                if (dtOc.Rows.Count > 0)
                {
                    txtQty.Text = dtOc.Rows[0]["qty_pcs"].ToString();
                    txtWeg.Text = "";
                }
                else
                    cleanText();
            }
            else
            {
                txtQty.Text = dtPk.Rows[0]["qty"].ToString();
                txtWeg.Text = dtPk.Rows[0]["weg"].ToString();
                MessageBox.Show("已存在一筆記錄!");
            }
            
        }
        private DataTable chkPackingMo()
        {
            string mo_id = txtMo.Text;
            string strSql = " Select qty,weg " +
                " From packing_mo_records " +
                " Where mo_id='" + mo_id + "' And upd_flag='0' ";
            DataTable dtPk = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            return dtPk;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cleanText();
        }
        private void cleanText()
        {
            txtBarCode.Text = "";
            txtMo.Text = "";
            txtQty.Text = "";
            txtWeg.Text = "";
            txtBarCode.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            string strSql = "";
            string upd_flag = "0";
            int Qty = 0;
            decimal Weg = 0;  
            Qty = txtQty.Text != "" ? Convert.ToInt32(txtQty.Text.Trim()) :  0;
            Weg = txtWeg.Text != "" ? Convert.ToDecimal(txtWeg.Text.Trim()) : 0;
            string update_user = DBUtility._user_id;
            DataTable dtPk = chkPackingMo();
            if (dtPk.Rows.Count == 0)
                strSql = @"insert into packing_mo_records (mo_id,qty,weg, upd_flag,update_user,update_time )
                                 Values(@mo_id,@qty,@weg, @upd_flag, @update_user,GETDATE())";
            else
                strSql = @"Update packing_mo_records Set qty=@qty,weg=@weg, upd_flag=@upd_flag,update_user=@update_user,update_time=GETDATE()" +
                    " Where mo_id=@mo_id And upd_flag=@upd_flag ";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@mo_id",txtMo.Text.Trim()),
                new SqlParameter("@qty",Qty),
                new SqlParameter("@weg",Weg),
                new SqlParameter("@upd_flag",upd_flag),
                new SqlParameter("@update_user",update_user),
            };
            int result = clsPublicOfPad.ExecuteNonQueryReturnInt(strSql, paras);

            if (result == 1)
                MessageBox.Show("儲存包裝箱制單記錄成功!");
            else
                MessageBox.Show("儲存包裝箱制單記錄失敗!");
            txtBarCode.Focus();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            string pdfPath = "c:/Install/2025-02-11T173415.pdf";
            string text = ExtractTextFromPdf(pdfPath);
            Console.WriteLine(text);
        }

        private static string ExtractTextFromPdf(string pdfPath)
        {
            if (!File.Exists(pdfPath))
            {
                Console.WriteLine($"File not found: {pdfPath}");
                return string.Empty;
            }
            using (PdfReader reader = new PdfReader(pdfPath))
            {
                StringWriter output = new StringWriter();
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    output.WriteLine(PdfTextExtractor.GetTextFromPage(reader, i));
                }
                return output.ToString();
            }
        }
    }
}
