namespace cf_pad.Forms
{
    partial class frmDemoRS485
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
            this.components = new System.ComponentModel.Container();
            this.seriaSettingPlay = new System.IO.Ports.SerialPort(this.components);
            this.txtCrc16 = new System.Windows.Forms.TextBox();
            this.btnCrc = new System.Windows.Forms.Button();
            this.btnRW485 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // seriaSettingPlay
            // 
            this.seriaSettingPlay.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.seriaSettingPlay_DataReceived);
            // 
            // txtCrc16
            // 
            this.txtCrc16.Location = new System.Drawing.Point(391, 277);
            this.txtCrc16.Name = "txtCrc16";
            this.txtCrc16.Size = new System.Drawing.Size(100, 22);
            this.txtCrc16.TabIndex = 8;
            // 
            // btnCrc
            // 
            this.btnCrc.Location = new System.Drawing.Point(250, 268);
            this.btnCrc.Name = "btnCrc";
            this.btnCrc.Size = new System.Drawing.Size(75, 23);
            this.btnCrc.TabIndex = 7;
            this.btnCrc.Text = "button2";
            this.btnCrc.UseVisualStyleBackColor = true;
            this.btnCrc.Click += new System.EventHandler(this.btnCrc_Click);
            // 
            // btnRW485
            // 
            this.btnRW485.Location = new System.Drawing.Point(310, 126);
            this.btnRW485.Name = "btnRW485";
            this.btnRW485.Size = new System.Drawing.Size(75, 23);
            this.btnRW485.TabIndex = 9;
            this.btnRW485.Text = "button1";
            this.btnRW485.UseVisualStyleBackColor = true;
            this.btnRW485.Click += new System.EventHandler(this.btnRW485_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(408, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "CRC(可以用)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(587, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 11;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(571, 78);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 12;
            // 
            // frmDemoRS485
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 566);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRW485);
            this.Controls.Add(this.txtCrc16);
            this.Controls.Add(this.btnCrc);
            this.Name = "frmDemoRS485";
            this.Text = "frmDemoRS485";
            this.Load += new System.EventHandler(this.frmDemoRS485_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort seriaSettingPlay;
        private System.Windows.Forms.TextBox txtCrc16;
        private System.Windows.Forms.Button btnCrc;
        private System.Windows.Forms.Button btnRW485;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}