using cf_pad.Reports;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf_pad.Forms
{
    public partial class frmPrintArtwork : Form
    {
        DataTable dtReport = new DataTable();
        public frmPrintArtwork()
        {
            InitializeComponent();
        }

        private void GetArtWork()
        {
            string strArtwork = txtArtwork.Text.Trim();
            string strSql = string.Format("select dbo.fn_get_picture_name_of_artwork('0000','{0}','OUT') AS pictrue_name", strArtwork);
            dtReport = DBUtility.ExecuteSqlReturnDataTable(strSql);
            string strPicture_name = "";
            if(dtReport.Rows.Count>0)
            {
                if(!string.IsNullOrEmpty(dtReport.Rows[0]["pictrue_name"].ToString()))
                {
                    strPicture_name = dtReport.Rows[0]["pictrue_name"].ToString();
                }
                else
                {
                    strPicture_name = "";
                }
            }
            if (strPicture_name!="")
            {
                picArtwork.Image = Image.FromFile(strPicture_name);
            }
            else
            {
                picArtwork.Image = null;
            }
            
        }

        private void txtArtwork_Leave(object sender, EventArgs e)
        {
            if (txtArtwork.Text.Trim() != "")
            {
                GetArtWork();
            }
        }

        private void frmPrintArtwork_Load(object sender, EventArgs e)
        {
            txtArtwork.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print("P");
        }

        private void btnPrivew_Click(object sender, EventArgs e)
        {
            Print("V");
        }

        private void Print(string print_type)
        {
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("沒有需要列印的相關數據，請重新輸入條件!");
                txtArtwork.Focus();
                return;
            }

            using (xrArtwork mMyReport = new xrArtwork(txtArtwork.Text) { DataSource = dtReport })
            {
                mMyReport.CreateDocument();
                mMyReport.PrintingSystem.ShowMarginsWarning = false;                
                if (print_type == "P")
                    mMyReport.Print();
                else
                    mMyReport.ShowPreviewDialog();
            }            
        }

        private void txtArtwork_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    string strArtwork = txtArtwork.Text.Trim();
                    if (string.IsNullOrEmpty(strArtwork))
                    {
                        dtReport.Clear();
                        return;
                    }
                    GetArtWork();
                    break;
            }
        }

       
    }
}
