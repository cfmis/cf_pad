namespace cf_pad.Forms
{
    partial class frmModulePlace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModulePlace));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.picShowArtWork = new System.Windows.Forms.PictureBox();
            this.txtArt = new System.Windows.Forms.TextBox();
            this.labArt = new System.Windows.Forms.Label();
            this.txtModulePlace = new System.Windows.Forms.TextBox();
            this.labModulePlace = new System.Windows.Forms.Label();
            this.txtModuleId = new System.Windows.Forms.TextBox();
            this.labModuleId = new System.Windows.Forms.Label();
            this.txtDep = new System.Windows.Forms.TextBox();
            this.labDep = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.art_full_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.art_file = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.art_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShowArtWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.btnFind,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(803, 58);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = false;
            this.btnExit.Font = new System.Drawing.Font("新細明體", 12F);
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(85, 55);
            this.btnExit.Text = "退出(&X)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 58);
            // 
            // btnFind
            // 
            this.btnFind.AutoSize = false;
            this.btnFind.Font = new System.Drawing.Font("新細明體", 12F);
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(85, 55);
            this.btnFind.Text = "查詢(&F)";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 58);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 58);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtRemark);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.picShowArtWork);
            this.splitContainer1.Panel1.Controls.Add(this.txtArt);
            this.splitContainer1.Panel1.Controls.Add(this.labArt);
            this.splitContainer1.Panel1.Controls.Add(this.txtModulePlace);
            this.splitContainer1.Panel1.Controls.Add(this.labModulePlace);
            this.splitContainer1.Panel1.Controls.Add(this.txtModuleId);
            this.splitContainer1.Panel1.Controls.Add(this.labModuleId);
            this.splitContainer1.Panel1.Controls.Add(this.txtDep);
            this.splitContainer1.Panel1.Controls.Add(this.labDep);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer1.Size = new System.Drawing.Size(803, 654);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 1;
            // 
            // picShowArtWork
            // 
            this.picShowArtWork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picShowArtWork.Location = new System.Drawing.Point(512, 12);
            this.picShowArtWork.Name = "picShowArtWork";
            this.picShowArtWork.Size = new System.Drawing.Size(271, 269);
            this.picShowArtWork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picShowArtWork.TabIndex = 5;
            this.picShowArtWork.TabStop = false;
            // 
            // txtArt
            // 
            this.txtArt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtArt.Font = new System.Drawing.Font("新細明體", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtArt.Location = new System.Drawing.Point(160, 109);
            this.txtArt.MaxLength = 7;
            this.txtArt.Name = "txtArt";
            this.txtArt.Size = new System.Drawing.Size(179, 43);
            this.txtArt.TabIndex = 2;
            this.txtArt.TextChanged += new System.EventHandler(this.btnFind_Click);
            // 
            // labArt
            // 
            this.labArt.AutoSize = true;
            this.labArt.Font = new System.Drawing.Font("新細明體", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labArt.Location = new System.Drawing.Point(14, 118);
            this.labArt.Name = "labArt";
            this.labArt.Size = new System.Drawing.Size(141, 30);
            this.labArt.TabIndex = 0;
            this.labArt.Text = "圖樣代號:";
            // 
            // txtModulePlace
            // 
            this.txtModulePlace.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModulePlace.Font = new System.Drawing.Font("新細明體", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtModulePlace.Location = new System.Drawing.Point(160, 160);
            this.txtModulePlace.MaxLength = 20;
            this.txtModulePlace.Name = "txtModulePlace";
            this.txtModulePlace.Size = new System.Drawing.Size(179, 43);
            this.txtModulePlace.TabIndex = 3;
            this.txtModulePlace.TextChanged += new System.EventHandler(this.btnFind_Click);
            // 
            // labModulePlace
            // 
            this.labModulePlace.AutoSize = true;
            this.labModulePlace.Font = new System.Drawing.Font("新細明體", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labModulePlace.Location = new System.Drawing.Point(14, 168);
            this.labModulePlace.Name = "labModulePlace";
            this.labModulePlace.Size = new System.Drawing.Size(141, 30);
            this.labModulePlace.TabIndex = 0;
            this.labModulePlace.Text = "模具位置:";
            // 
            // txtModuleId
            // 
            this.txtModuleId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModuleId.Font = new System.Drawing.Font("新細明體", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtModuleId.Location = new System.Drawing.Point(160, 60);
            this.txtModuleId.MaxLength = 20;
            this.txtModuleId.Name = "txtModuleId";
            this.txtModuleId.Size = new System.Drawing.Size(179, 43);
            this.txtModuleId.TabIndex = 1;
            this.txtModuleId.TextChanged += new System.EventHandler(this.btnFind_Click);
            // 
            // labModuleId
            // 
            this.labModuleId.AutoSize = true;
            this.labModuleId.Font = new System.Drawing.Font("新細明體", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labModuleId.Location = new System.Drawing.Point(14, 69);
            this.labModuleId.Name = "labModuleId";
            this.labModuleId.Size = new System.Drawing.Size(141, 30);
            this.labModuleId.TabIndex = 0;
            this.labModuleId.Text = "模具編號:";
            // 
            // txtDep
            // 
            this.txtDep.Font = new System.Drawing.Font("新細明體", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDep.Location = new System.Drawing.Point(160, 9);
            this.txtDep.MaxLength = 3;
            this.txtDep.Name = "txtDep";
            this.txtDep.Size = new System.Drawing.Size(83, 43);
            this.txtDep.TabIndex = 0;
            // 
            // labDep
            // 
            this.labDep.AutoSize = true;
            this.labDep.Font = new System.Drawing.Font("新細明體", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labDep.Location = new System.Drawing.Point(74, 19);
            this.labDep.Name = "labDep";
            this.labDep.Size = new System.Drawing.Size(81, 30);
            this.labDep.TabIndex = 0;
            this.labDep.Text = "部門:";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.ColumnHeadersHeight = 60;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.remark,
            this.art_full_path,
            this.art_file,
            this.art_seq});
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.EnableHeadersVisualStyles = false;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersWidth = 20;
            this.dgvDetails.RowTemplate.Height = 120;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(799, 352);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "dep";
            this.dataGridViewTextBoxColumn1.HeaderText = "部門";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "module_id";
            this.dataGridViewTextBoxColumn2.HeaderText = "模具編號";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "module_name";
            this.dataGridViewTextBoxColumn3.HeaderText = "模具描述";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "module_place";
            this.dataGridViewTextBoxColumn4.HeaderText = "模具位置";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "item_size";
            this.dataGridViewTextBoxColumn5.HeaderText = "尺寸";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "prd_type";
            this.dataGridViewTextBoxColumn6.HeaderText = "產品類型";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "art_id";
            this.dataGridViewTextBoxColumn7.HeaderText = "圖樣代號";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "module_type";
            this.dataGridViewTextBoxColumn8.HeaderText = "模具類型";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("新細明體", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtRemark.Location = new System.Drawing.Point(160, 211);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(337, 43);
            this.txtRemark.TabIndex = 7;
            this.txtRemark.TextChanged += new System.EventHandler(this.btnFind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(74, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "備註:";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "dep";
            this.Column1.HeaderText = "部門";
            this.Column1.Name = "Column1";
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "module_id";
            this.Column2.HeaderText = "模具編號";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "module_name";
            this.Column3.HeaderText = "模具描述";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "module_place";
            this.Column4.HeaderText = "模具位置";
            this.Column4.Name = "Column4";
            this.Column4.Width = 170;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "item_size";
            this.Column5.HeaderText = "尺寸";
            this.Column5.Name = "Column5";
            this.Column5.Width = 60;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "prd_type";
            this.Column6.HeaderText = "產品類型";
            this.Column6.Name = "Column6";
            this.Column6.Width = 70;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "art_id";
            this.Column7.HeaderText = "圖樣代號";
            this.Column7.Name = "Column7";
            this.Column7.Width = 120;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "module_type";
            this.Column8.HeaderText = "模具類型";
            this.Column8.Name = "Column8";
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "備註";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            this.remark.Width = 160;
            // 
            // art_full_path
            // 
            this.art_full_path.DataPropertyName = "art_full_path";
            this.art_full_path.HeaderText = "art_full_path";
            this.art_full_path.Name = "art_full_path";
            this.art_full_path.ReadOnly = true;
            this.art_full_path.Visible = false;
            // 
            // art_file
            // 
            this.art_file.DataPropertyName = "art_file";
            this.art_file.HeaderText = "art_file";
            this.art_file.Name = "art_file";
            this.art_file.Visible = false;
            // 
            // art_seq
            // 
            this.art_seq.DataPropertyName = "art_seq";
            this.art_seq.HeaderText = "art_seq";
            this.art_seq.Name = "art_seq";
            this.art_seq.Visible = false;
            // 
            // frmModulePlace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 712);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmModulePlace";
            this.Text = "frmModulePlace";
            this.Load += new System.EventHandler(this.frmModulePlace_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picShowArtWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtDep;
        private System.Windows.Forms.Label labDep;
        private System.Windows.Forms.TextBox txtModuleId;
        private System.Windows.Forms.Label labModuleId;
        private System.Windows.Forms.TextBox txtArt;
        private System.Windows.Forms.Label labArt;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.TextBox txtModulePlace;
        private System.Windows.Forms.Label labModulePlace;
        private System.Windows.Forms.PictureBox picShowArtWork;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn art_full_path;
        private System.Windows.Forms.DataGridViewTextBoxColumn art_file;
        private System.Windows.Forms.DataGridViewTextBoxColumn art_seq;
    }
}