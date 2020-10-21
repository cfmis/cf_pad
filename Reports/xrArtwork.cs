using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf_pad.Reports
{
    public partial class xrArtwork : DevExpress.XtraReports.UI.XtraReport
    {
        string str_artwork_id = "";
        public xrArtwork(string artwork_id)
        {
            InitializeComponent();
            str_artwork_id = artwork_id;
        }

        void BindImage()
        {
            string art_path = GetCurrentColumnValue("pictrue_name").ToString();
            if (File.Exists(art_path))
            {
                xrPictureBox1.ImageUrl = art_path;
            }          
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            BindImage();
           
        }

        private void xrArtwork_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel1.Text = str_artwork_id;
        }
    }
}
