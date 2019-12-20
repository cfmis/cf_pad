namespace cf_pad.Forms
{
    partial class frmPackingList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPackingList));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.print_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.print_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crusr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crtim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mo_id,
            this.print_date,
            this.print_qty,
            this.crusr,
            this.crtim});
            this.dataGridView1.Location = new System.Drawing.Point(4, 81);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(777, 413);
            this.dataGridView1.TabIndex = 0;
            // 
            // mo_id
            // 
            this.mo_id.DataPropertyName = "mo_id";
            this.mo_id.HeaderText = "頁數";
            this.mo_id.Name = "mo_id";
            this.mo_id.ReadOnly = true;
            this.mo_id.Width = 130;
            // 
            // print_date
            // 
            this.print_date.DataPropertyName = "print_date";
            this.print_date.HeaderText = "列印日期";
            this.print_date.Name = "print_date";
            this.print_date.ReadOnly = true;
            this.print_date.Width = 150;
            // 
            // print_qty
            // 
            this.print_qty.DataPropertyName = "print_qty";
            this.print_qty.HeaderText = "標簽數量";
            this.print_qty.Name = "print_qty";
            this.print_qty.ReadOnly = true;
            this.print_qty.Width = 120;
            // 
            // crusr
            // 
            this.crusr.DataPropertyName = "crusr";
            this.crusr.HeaderText = "建檔人";
            this.crusr.Name = "crusr";
            this.crusr.ReadOnly = true;
            this.crusr.Width = 130;
            // 
            // crtim
            // 
            this.crtim.DataPropertyName = "crtim";
            this.crtim.HeaderText = "建檔日期";
            this.crtim.Name = "crtim";
            this.crtim.ReadOnly = true;
            this.crtim.Width = 200;
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(131, 2);
            this.btnDel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(118, 69);
            this.btnDel.TabIndex = 8;
            this.btnDel.Text = "刪除(&D)";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(7, 2);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(113, 69);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmPackingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 500);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPackingList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPackingList";
            this.Load += new System.EventHandler(this.frmPackingList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn print_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn print_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn crusr;
        private System.Windows.Forms.DataGridViewTextBoxColumn crtim;
    }
}