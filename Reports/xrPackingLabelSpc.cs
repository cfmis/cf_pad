using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using cf_pad.CLS;

namespace cf_pad.Reports
{
    public partial class xrPackingLabelSpc : DevExpress.XtraReports.UI.XtraReport
    {
        public xrPackingLabelSpc()
        {
            InitializeComponent();            
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        //private void xrPictureBox2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        //{
        //    clsUtility clsUtility = new clsUtility();
        //    //string fileName = GetCurrentColumnValue("mo_id").ToString().Trim() + ".jpg";
        //    //xrPictureBox2.Image = clsUtility.QRCodeImage(fileName);            
        //    //xrPictureBox2.Image = clsUtility.GenBarCode(xrLabel2.Text.Trim());
        //}

      
    }
}
