using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using cf_pad.CLS;

namespace cf_pad.Reports
{
    public partial class xrPackingLabel : DevExpress.XtraReports.UI.XtraReport
    {
        public xrPackingLabel()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrPictureBox2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            clsUtility clsUtility = new clsUtility();
            string fileName = GetCurrentColumnValue("mo_id") + ".jpg";
            xrPictureBox2.Image = clsUtility.GenByZXingNet(fileName);
        }
    }
}
