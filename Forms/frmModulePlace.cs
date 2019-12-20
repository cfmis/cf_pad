using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf_pad.CLS;
using System.IO;

namespace cf_pad.Forms
{
    public partial class frmModulePlace : Form
    {
        DataTable dt = new DataTable();
        public frmModulePlace()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void findMoudlePlace()
        {
            clsCommonUse com = new clsCommonUse();
            dt = com.getDataProcedure("usp_find_module_place",
                new object[] { txtDep.Text, txtModuleId.Text, txtArt.Text, txtModulePlace.Text,txtRemark.Text });
            dgvDetails.DataSource = dt;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            findMoudlePlace();
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {          
            if (dgvDetails.RowCount > 0)
            {
                //art_path = this.dgvDetails[10, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
                //2016-05-02改為以下代碼
                string art_path = dt.Rows[dgvDetails.CurrentCell.RowIndex]["art_full_path"].ToString();
                if (!string.IsNullOrEmpty(art_path))
                {
                    if (File.Exists(art_path))
                        picShowArtWork.Image = Image.FromFile(art_path);
                    else
                        picShowArtWork.Image = null;
                }                
            }
        }

        private void frmModulePlace_Load(object sender, EventArgs e)
        {
            Font a = new Font("GB2312", 18);//GB2312为字体名称，1为字体大小dataGridView1.Font = a;
            dgvDetails.Font = a;
        }
    }
}
