namespace cf_pad.Forms
{
    partial class frmPackingMoRecords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPackingMoRecords));
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblWeg = new System.Windows.Forms.Label();
            this.txtWeg = new System.Windows.Forms.TextBox();
            this.txtMo = new System.Windows.Forms.TextBox();
            this.lblMo = new System.Windows.Forms.Label();
            this.btnPDF = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBarCode
            // 
            this.txtBarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtBarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarCode.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBarCode.Location = new System.Drawing.Point(126, 75);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(452, 27);
            this.txtBarCode.TabIndex = 1;
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblBarcode.ForeColor = System.Drawing.Color.Red;
            this.lblBarcode.Location = new System.Drawing.Point(35, 79);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(92, 16);
            this.lblBarcode.TabIndex = 2;
            this.lblBarcode.Text = "條碼掃描區:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.btnNew,
            this.toolStripSeparator2,
            this.btnSave,
            this.toolStripSeparator3,
            this.btnDelete,
            this.toolStripSeparator4,
            this.btnFind,
            this.toolStripSeparator5,
            this.btnPDF,
            this.toolStripSeparator6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(705, 38);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = false;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(65, 35);
            this.btnExit.Text = "退出(&X)";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btnNew
            // 
            this.btnNew.AutoSize = false;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(65, 35);
            this.btnNew.Text = "新增(&A)";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 35);
            this.btnSave.Text = "儲存(&S)";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 35);
            this.btnDelete.Text = "刪除(&D)";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // btnFind
            // 
            this.btnFind.AutoSize = false;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(65, 35);
            this.btnFind.Text = "查找(&F)";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtQty.Location = new System.Drawing.Point(126, 165);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(178, 27);
            this.txtQty.TabIndex = 7;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblQty.ForeColor = System.Drawing.Color.Black;
            this.lblQty.Location = new System.Drawing.Point(83, 171);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(44, 16);
            this.lblQty.TabIndex = 8;
            this.lblQty.Text = "數量:";
            // 
            // lblWeg
            // 
            this.lblWeg.AutoSize = true;
            this.lblWeg.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblWeg.ForeColor = System.Drawing.Color.Black;
            this.lblWeg.Location = new System.Drawing.Point(83, 215);
            this.lblWeg.Name = "lblWeg";
            this.lblWeg.Size = new System.Drawing.Size(44, 16);
            this.lblWeg.TabIndex = 8;
            this.lblWeg.Text = "重量:";
            // 
            // txtWeg
            // 
            this.txtWeg.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtWeg.Location = new System.Drawing.Point(126, 209);
            this.txtWeg.Name = "txtWeg";
            this.txtWeg.Size = new System.Drawing.Size(178, 27);
            this.txtWeg.TabIndex = 7;
            // 
            // txtMo
            // 
            this.txtMo.BackColor = System.Drawing.Color.GhostWhite;
            this.txtMo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMo.Location = new System.Drawing.Point(126, 122);
            this.txtMo.MaxLength = 9;
            this.txtMo.Name = "txtMo";
            this.txtMo.Size = new System.Drawing.Size(178, 27);
            this.txtMo.TabIndex = 9;
            // 
            // lblMo
            // 
            this.lblMo.AutoSize = true;
            this.lblMo.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblMo.ForeColor = System.Drawing.Color.Black;
            this.lblMo.Location = new System.Drawing.Point(51, 126);
            this.lblMo.Name = "lblMo";
            this.lblMo.Size = new System.Drawing.Size(76, 16);
            this.lblMo.TabIndex = 10;
            this.lblMo.Text = "制單編號:";
            // 
            // btnPDF
            // 
            this.btnPDF.AutoSize = false;
            this.btnPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnPDF.Image")));
            this.btnPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(74, 35);
            this.btnPDF.Text = "讀取PDF";
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
            // 
            // frmPackingMoRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 529);
            this.Controls.Add(this.txtMo);
            this.Controls.Add(this.lblMo);
            this.Controls.Add(this.txtWeg);
            this.Controls.Add(this.lblWeg);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.lblBarcode);
            this.Name = "frmPackingMoRecords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPackingMoRecords";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblWeg;
        private System.Windows.Forms.TextBox txtWeg;
        private System.Windows.Forms.TextBox txtMo;
        private System.Windows.Forms.Label lblMo;
        private System.Windows.Forms.ToolStripButton btnPDF;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}