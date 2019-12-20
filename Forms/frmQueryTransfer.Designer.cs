namespace cf_pad.Forms
{
    partial class frmQueryTransfer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTransferMostly = new System.Windows.Forms.DataGridView();
            this.colTrans_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcon_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colout_dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colin_dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheck_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcheck_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcreate_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcreate_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colhandler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colbill_origin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colstate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colstock_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colupdate_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colupdate_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colupdate_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferMostly)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTransferMostly
            // 
            this.dgvTransferMostly.AllowUserToAddRows = false;
            this.dgvTransferMostly.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransferMostly.ColumnHeadersHeight = 60;
            this.dgvTransferMostly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTransferMostly.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTrans_id,
            this.colcon_date,
            this.colout_dept,
            this.colin_dept,
            this.colCheck_date,
            this.colcheck_by,
            this.colRemark,
            this.colcreate_date,
            this.colcreate_by,
            this.colhandler,
            this.colbill_origin,
            this.colstate,
            this.colstock_type,
            this.colupdate_date,
            this.colupdate_count,
            this.colupdate_by});
            this.dgvTransferMostly.Location = new System.Drawing.Point(0, 0);
            this.dgvTransferMostly.Name = "dgvTransferMostly";
            this.dgvTransferMostly.ReadOnly = true;
            this.dgvTransferMostly.RowTemplate.Height = 120;
            this.dgvTransferMostly.Size = new System.Drawing.Size(982, 712);
            this.dgvTransferMostly.TabIndex = 0;
            this.dgvTransferMostly.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTransferMostly_RowPostPaint);
            this.dgvTransferMostly.DoubleClick += new System.EventHandler(this.dgvTransferMostly_DoubleClick);
            // 
            // colTrans_id
            // 
            this.colTrans_id.DataPropertyName = "id";
            this.colTrans_id.HeaderText = "移交單號";
            this.colTrans_id.Name = "colTrans_id";
            this.colTrans_id.ReadOnly = true;
            this.colTrans_id.Width = 160;
            // 
            // colcon_date
            // 
            this.colcon_date.DataPropertyName = "con_date";
            this.colcon_date.HeaderText = "移交日期";
            this.colcon_date.Name = "colcon_date";
            this.colcon_date.ReadOnly = true;
            this.colcon_date.Width = 160;
            // 
            // colout_dept
            // 
            this.colout_dept.DataPropertyName = "out_dept";
            this.colout_dept.HeaderText = "發貨部門";
            this.colout_dept.Name = "colout_dept";
            this.colout_dept.ReadOnly = true;
            this.colout_dept.Width = 80;
            // 
            // colin_dept
            // 
            this.colin_dept.DataPropertyName = "in_dept";
            this.colin_dept.HeaderText = "收貨部門";
            this.colin_dept.Name = "colin_dept";
            this.colin_dept.ReadOnly = true;
            this.colin_dept.Width = 80;
            // 
            // colCheck_date
            // 
            this.colCheck_date.DataPropertyName = "check_date";
            this.colCheck_date.HeaderText = "批准日期";
            this.colCheck_date.Name = "colCheck_date";
            this.colCheck_date.ReadOnly = true;
            this.colCheck_date.Width = 160;
            // 
            // colcheck_by
            // 
            this.colcheck_by.DataPropertyName = "check_by";
            this.colcheck_by.HeaderText = "批准人";
            this.colcheck_by.Name = "colcheck_by";
            this.colcheck_by.ReadOnly = true;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "remark";
            this.colRemark.HeaderText = "備註";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            this.colRemark.Width = 250;
            // 
            // colcreate_date
            // 
            this.colcreate_date.DataPropertyName = "create_date";
            this.colcreate_date.HeaderText = "建檔日期";
            this.colcreate_date.Name = "colcreate_date";
            this.colcreate_date.ReadOnly = true;
            // 
            // colcreate_by
            // 
            this.colcreate_by.DataPropertyName = "create_by";
            this.colcreate_by.HeaderText = "建檔人";
            this.colcreate_by.Name = "colcreate_by";
            this.colcreate_by.ReadOnly = true;
            // 
            // colhandler
            // 
            this.colhandler.DataPropertyName = "handler";
            this.colhandler.HeaderText = "經手人";
            this.colhandler.Name = "colhandler";
            this.colhandler.ReadOnly = true;
            // 
            // colbill_origin
            // 
            this.colbill_origin.DataPropertyName = "bill_origin";
            this.colbill_origin.HeaderText = "開單來源";
            this.colbill_origin.Name = "colbill_origin";
            this.colbill_origin.ReadOnly = true;
            this.colbill_origin.Width = 80;
            // 
            // colstate
            // 
            this.colstate.DataPropertyName = "state";
            this.colstate.HeaderText = "狀態";
            this.colstate.Name = "colstate";
            this.colstate.ReadOnly = true;
            this.colstate.Width = 80;
            // 
            // colstock_type
            // 
            this.colstock_type.DataPropertyName = "stock_type";
            this.colstock_type.HeaderText = "類型";
            this.colstock_type.Name = "colstock_type";
            this.colstock_type.ReadOnly = true;
            this.colstock_type.Width = 80;
            // 
            // colupdate_date
            // 
            this.colupdate_date.DataPropertyName = "update_date";
            this.colupdate_date.HeaderText = "修改日期";
            this.colupdate_date.Name = "colupdate_date";
            this.colupdate_date.ReadOnly = true;
            // 
            // colupdate_count
            // 
            this.colupdate_count.DataPropertyName = "update_count";
            this.colupdate_count.HeaderText = "修改次數";
            this.colupdate_count.Name = "colupdate_count";
            this.colupdate_count.ReadOnly = true;
            this.colupdate_count.Width = 80;
            // 
            // colupdate_by
            // 
            this.colupdate_by.DataPropertyName = "update_by";
            this.colupdate_by.HeaderText = "修改人";
            this.colupdate_by.Name = "colupdate_by";
            this.colupdate_by.ReadOnly = true;
            // 
            // frmQueryTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 713);
            this.Controls.Add(this.dgvTransferMostly);
            this.Name = "frmQueryTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmQueryTransfer";
            this.Load += new System.EventHandler(this.frmQueryTransfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferMostly)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTransferMostly;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrans_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcon_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colout_dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn colin_dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheck_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcheck_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcreate_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcreate_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn colhandler;
        private System.Windows.Forms.DataGridViewTextBoxColumn colbill_origin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colstate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colstock_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn colupdate_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colupdate_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn colupdate_by;
    }
}