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
            string strCust_id= GetCurrentColumnValue("it_customer").ToString();
            if(strCust_id != "DO-S0467")
            {
                xrLabel17.Visible = false;
            }
            else
            {
                //2021/04/29號要求,DO-S0467客戶要求顯示“country of origin :China ”內容
                xrLabel17.Visible = true;
            }
            string strFlagboth = GetCurrentColumnValue("flag_both").ToString();
            SubBand1.Visible = strFlagboth == "Y" ? true : false;

            //牌子分類2024/06/03
            string division = GetCurrentColumnValue("division").ToString();
            string brand_name_custom = GetCurrentColumnValue("brand_name_custom").ToString();
            lblDivision.Visible = (!string.IsNullOrEmpty(division)) ? true : false;
            lblBrand_name.Visible = (!string.IsNullOrEmpty(brand_name_custom)) ? true : false;
        }

        private void xrPictureBox2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            clsUtility clsUtility = new clsUtility();
            //string fileName = GetCurrentColumnValue("mo_id").ToString().Trim() + ".jpg";
            //xrPictureBox2.Image = clsUtility.QRCodeImage(fileName);
            xrPictureBox2.Image = clsUtility.GenQRCode("http://www.chingfung.com");
        }
    }
}
