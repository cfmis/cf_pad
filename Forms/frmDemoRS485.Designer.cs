﻿namespace cf_pad.Forms
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
            this.SuspendLayout();
            // 
            // seriaSettingPlay
            // 
            this.seriaSettingPlay.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.seriaSettingPlay_DataReceived);
            // 
            // frmDemoRS485
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 566);
            this.Name = "frmDemoRS485";
            this.Text = "frmDemoRS485";
            this.Load += new System.EventHandler(this.frmDemoRS485_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort seriaSettingPlay;
    }
}