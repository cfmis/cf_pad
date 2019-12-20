using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf_pad.CLS;

namespace cf_pad.Forms
{
    public partial class frmPackingList : Form
    {
        private string strMo_id;
        private DataTable dt;
        public frmPackingList(string pMo_id)
        {
            InitializeComponent();
            strMo_id = pMo_id;
        }

        private void frmPackingList_Load(object sender, EventArgs e)
        {
            string sql = string.Format(@"Select * From packing_print_list Where mo_id='{0}'", strMo_id);
            dt = clsPublicOfPad.ExecuteSqlReturnDataTable(sql);
            dataGridView1.DataSource = dt;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                int cur_row = dataGridView1.CurrentCell.RowIndex;
                if (MessageBox.Show("是否要刪除當前記錄?", "提示信息", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strDate = dt.Rows[cur_row]["print_date"].ToString();
                    string strQty = dt.Rows[cur_row]["print_qty"].ToString();
                    string sql_d = string.Format(@"Delete From packing_print_list Where mo_id='{0}' and print_date='{1}' and print_qty='{2}'", strMo_id, strDate, strQty);
                    try
                    {
                        clsPublicOfPad.ExecuteSqlUpdate(sql_d);
                        dt.Rows.RemoveAt(cur_row);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
