namespace cf_pad.Forms
{
    partial class frmPrintArtwork
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtArtwork = new System.Windows.Forms.TextBox();
            this.lblMo_id = new System.Windows.Forms.Label();
            this.picArtwork = new System.Windows.Forms.PictureBox();
            this.btnPrivew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picArtwork)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("PMingLiU", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPrint.ForeColor = System.Drawing.Color.Blue;
            this.btnPrint.Location = new System.Drawing.Point(164, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(122, 84);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "列 印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtArtwork
            // 
            this.txtArtwork.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtArtwork.Font = new System.Drawing.Font("PMingLiU", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtArtwork.Location = new System.Drawing.Point(152, 27);
            this.txtArtwork.MaxLength = 9;
            this.txtArtwork.Name = "txtArtwork";
            this.txtArtwork.Size = new System.Drawing.Size(213, 49);
            this.txtArtwork.TabIndex = 1;
            this.txtArtwork.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArtwork_KeyDown);
            this.txtArtwork.Leave += new System.EventHandler(this.txtArtwork_Leave);
            // 
            // lblMo_id
            // 
            this.lblMo_id.AutoSize = true;
            this.lblMo_id.Font = new System.Drawing.Font("PMingLiU", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMo_id.Location = new System.Drawing.Point(25, 30);
            this.lblMo_id.Name = "lblMo_id";
            this.lblMo_id.Size = new System.Drawing.Size(94, 35);
            this.lblMo_id.TabIndex = 0;
            this.lblMo_id.Text = "圖樣:";
            // 
            // picArtwork
            // 
            this.picArtwork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picArtwork.Location = new System.Drawing.Point(92, 98);
            this.picArtwork.Name = "picArtwork";
            this.picArtwork.Size = new System.Drawing.Size(588, 577);
            this.picArtwork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picArtwork.TabIndex = 1;
            this.picArtwork.TabStop = false;
            // 
            // btnPrivew
            // 
            this.btnPrivew.Font = new System.Drawing.Font("PMingLiU", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPrivew.Location = new System.Drawing.Point(315, 4);
            this.btnPrivew.Name = "btnPrivew";
            this.btnPrivew.Size = new System.Drawing.Size(130, 84);
            this.btnPrivew.TabIndex = 3;
            this.btnPrivew.Text = "預 覽";
            this.btnPrivew.UseVisualStyleBackColor = true;
            this.btnPrivew.Click += new System.EventHandler(this.btnPrivew_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnPrivew);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Location = new System.Drawing.Point(5, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 92);
            this.panel1.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.Font = new System.Drawing.Font("PMingLiU", 26.25F);
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(17, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(122, 84);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "退 出";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtArtwork);
            this.panel2.Controls.Add(this.lblMo_id);
            this.panel2.Controls.Add(this.picArtwork);
            this.panel2.Location = new System.Drawing.Point(15, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(762, 705);
            this.panel2.TabIndex = 3;
            // 
            // frmPrintArtwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 823);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmPrintArtwork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrintArtwork";
            this.Load += new System.EventHandler(this.frmPrintArtwork_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picArtwork)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtArtwork;
        private System.Windows.Forms.Label lblMo_id;
        private System.Windows.Forms.PictureBox picArtwork;
        private System.Windows.Forms.Button btnPrivew;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel2;
    }
}