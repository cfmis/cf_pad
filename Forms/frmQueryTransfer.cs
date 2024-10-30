using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf_pad.CLS;
using cf_pad.MDL;

namespace cf_pad.Forms
{
    public partial class frmQueryTransfer : Form
    {
        public frmQueryTransfer()
        {
            InitializeComponent();
        }

        private void frmQueryTransfer_Load(object sender, EventArgs e)
        {
            dgvTransferMostly.AutoGenerateColumns = false;
            dgvTransferMostly.DataSource = frmPrdTransfer.dtTransferMostly;
            dgvTransferMostly.Refresh();

            Font a = new Font("GB2312", 14);//GB2312为字体名称，1为字体大小dataGridView1.Font = a;
            dgvTransferMostly.Font = a;
        }

        private void dgvTransferMostly_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
              e.RowBounds.Location.Y,
              dgvTransferMostly.RowHeadersWidth - 4,
              e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvTransferMostly.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvTransferMostly.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dgvTransferMostly_DoubleClick(object sender, EventArgs e)
        {
            frmPrdTransfer.dtTransferDetails = clsPrdTransfer.GetTransferDetails(dgvTransferMostly.CurrentRow.Cells["colTrans_id"].Value.ToString());

            jo_materiel_con_mostly objModel = new jo_materiel_con_mostly();
            objModel.id = dgvTransferMostly.CurrentRow.Cells["colTrans_id"].Value.ToString();
            objModel.in_dept = dgvTransferMostly.CurrentRow.Cells["colin_dept"].Value.ToString();
            objModel.out_dept = dgvTransferMostly.CurrentRow.Cells["colout_dept"].Value.ToString();
            objModel.state = dgvTransferMostly.CurrentRow.Cells["colstate"].Value.ToString();
            objModel.stock_type = dgvTransferMostly.CurrentRow.Cells["colstock_type"].Value.ToString();
            objModel.con_date = clsUtility.FormatNullableDateTime(dgvTransferMostly.CurrentRow.Cells["colcon_date"].Value);
            objModel.crusr = DBUtility._user_id;
            objModel.crtim = DateTime.Now;
            frmPrdTransfer.objMostly = objModel;

            DialogResult = DialogResult.OK;
        }


    }
}
