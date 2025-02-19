using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using cf_pad.CLS;//反射

namespace cf_pad
{
    public partial class frmMainPad: Form
    {
        public static frmMainPad pMainWin;
        public string user_id;
        public string user_name;
        public static bool isRunMain;
        DataTable dtMenu;
        public frmMainPad()
        {
            InitializeComponent();
            pMainWin = this;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {             

        }
        

        private void RunNewForm(string path_formname)
        {
            int location = path_formname.LastIndexOf(".") + 1;
            string formname = path_formname.Substring(location, (path_formname.Length - (location)));
            if (checkChildFrmExist(formname) == false)
            {
                Assembly asb = Assembly.GetExecutingAssembly();//得到当前的程序集
                Form f = (Form)asb.CreateInstance("cf_pad." + path_formname);//利用反射，根据数据库中的字段值创建窗体对象 
                //f.MdiParent = this;
                f.WindowState = FormWindowState.Maximized;
                //f.Show();
                f.ShowDialog();
            }
        }
        private static bool checkChildFrmExist(string childFrmName)
        {
            bool isExist_flag = false;
            foreach (Form childFrm in frmMainPad.pMainWin.MdiChildren)
            {
                if (childFrm.Name == childFrmName)
                {
                    if (childFrm.WindowState == FormWindowState.Minimized)
                    {
                        childFrm.WindowState = FormWindowState.Maximized;
                    }
                    childFrm.Activate();
                    isExist_flag = true;
                    break;
                }
            }
            return isExist_flag;
        }

        private void BTNExit_Click(object sender, EventArgs e)
        {
            Dispose();
            Application.Exit();
            //this.Close();
        }

        private void BTN1_Click(object sender, EventArgs e)
        {
            if (DBUtility._user_id.Substring(0, 3) == "ALY" || DBUtility._user_id.Substring(0, 3) == "BUT" || DBUtility._user_id == "BUK02")
            {
                //MessageBox.Show("請改用新版本的進度表!");
                //return;
                RunNewForm("Forms.frmPrdSchedule");//生產進度表(新)
            }
            else
                RunNewForm("Forms.frmProductionSchedule");//生產進度表
           
        }

        private void BTN2_Click(object sender, EventArgs e)
        {
            RunNewForm("Forms.frmProductionSelect");//查看生產計劃            
        }

        private void BTN3_Click(object sender, EventArgs e)
        {
            RunNewForm("Forms.frmProductQc");//產品QC
        }

        private void BTN4_Click(object sender, EventArgs e)
        {
            RunNewForm("Forms.frmProductQtyConfirm");//磅貨登記
            //RunNewForm("Forms.frmKeyboard");//磅貨登記
        }

        private void BTN5_Click(object sender, EventArgs e)
        {
            //RunNewForm("Forms.frmPrdTransfer");//移交單收貨
            RunNewForm("Forms.frmTransferRecords");//移交單收貨
        }

        private void BTN6_Click(object sender, EventArgs e)
        {           
            //RunNewForm("Forms.frmShowPlan");//查看生產計劃

            RunNewForm("Forms.frmPrdSchedule");//生產進度表(新)
        }

        private void BTN7_Click(object sender, EventArgs e)
        {
            //RunNewForm("Forms.frmModulePlace");//模具存放位置
            RunNewForm("Forms.frmGoodsTransferJx");//收、發貨到JX
        }        

        private void BTN8_Click(object sender, EventArgs e)
        {
            RunNewForm("Forms.frmCheckOutQty");//外發點貨
        }

        private void BTN9_Click(object sender, EventArgs e)
        {
            RunNewForm("Forms.frmPackingLabel");//列印裝箱標識卡
        }

        private void BTN10_Click(object sender, EventArgs e)
        {
            ////RunNewForm("Forms.frmIpqcReport");//成品檢驗記錄           
            Forms.frmIpqcReport frm = new Forms.frmIpqcReport("0");
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        private void BTN11_Click(object sender, EventArgs e)
        {
            //RunNewForm("Forms.frmIqcOp");//外發IQC檢驗
            RunNewForm("Forms.frmIqcOpNg");//外發IQC檢驗異常處理
        }

        private void BTN12_Click(object sender, EventArgs e)
        {
            RunNewForm("Forms.frmIpqcWeiht");//重量記錄表
        }

        private void BTN13_Click(object sender, EventArgs e)
        {
            RunNewForm("Forms.frmPacking");//列辦單標識卡
        }

        private void btnStoreIssue_Click(object sender, EventArgs e)
        {
            RunNewForm("Forms.frmStoreIssue");//倉庫發貨
        }

        private void btnTakeMoSample_Click(object sender, EventArgs e)
        {
            RunNewForm("Forms.frmTakeMoSample");//提倉單
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            RunNewForm("Forms.frmTransfer");//電鍍磅貨
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunNewForm("Forms.frmQcOut");//外發IQC檢驗(新)
        }

        private void btnPrintArtwork_Click(object sender, EventArgs e)
        {
            RunNewForm("Forms.frmPrintArtwork");//圖樣列印
        }

        private void BTN14_Click(object sender, EventArgs e)
        {            
            Forms.frmIpqcReport frm = new Forms.frmIpqcReport("1");
            //frm.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();            
        }

        private void BTN15_Click(object sender, EventArgs e)
        {
            RunNewForm("Forms.frmPackingMo");
        }
    }
}
