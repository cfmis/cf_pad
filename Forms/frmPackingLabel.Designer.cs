﻿namespace cf_pad.Forms
{
    partial class frmPackingLabel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkSuit = new System.Windows.Forms.CheckBox();
            this.cmbCartonSize = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkBoth = new System.Windows.Forms.CheckBox();
            this.chkIsFinish = new System.Windows.Forms.CheckBox();
            this.cmbCrossUnit = new System.Windows.Forms.ComboBox();
            this.cmbNetUnit = new System.Windows.Forms.ComboBox();
            this.cmbQty = new System.Windows.Forms.ComboBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtCross_weiht = new System.Windows.Forms.TextBox();
            this.txtNet_weiht = new System.Windows.Forms.TextBox();
            this.txtPrints = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAutoPrint = new System.Windows.Forms.CheckBox();
            this.lblItem_total = new System.Windows.Forms.Label();
            this.btnPrintView = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbItems = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblRoss_weiht = new System.Windows.Forms.Label();
            this.lblNet_weiht = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMo_group = new System.Windows.Forms.Label();
            this.lblDivision = new System.Windows.Forms.Label();
            this.lblBrand_name = new System.Windows.Forms.Label();
            this.lblBrand_id = new System.Windows.Forms.Label();
            this.lblIt_customer = new System.Windows.Forms.Label();
            this.lblCustomer_color_id = new System.Windows.Forms.Label();
            this.lblCustomer_color = new System.Windows.Forms.Label();
            this.rchGoods_desc = new System.Windows.Forms.RichTextBox();
            this.lblMo_id_barcode = new System.Windows.Forms.Label();
            this.lblMo_id = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblPO_style = new System.Windows.Forms.Label();
            this.lblGoods_id = new System.Windows.Forms.Label();
            this.lblOc_no = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlSuit = new System.Windows.Forms.Panel();
            this.dgvBom = new System.Windows.Forms.DataGridView();
            this.chkSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.goods_id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primary_key1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_desc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlSuit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBom)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.chkSuit);
            this.panel1.Controls.Add(this.cmbCartonSize);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.chkBoth);
            this.panel1.Controls.Add(this.chkIsFinish);
            this.panel1.Controls.Add(this.cmbCrossUnit);
            this.panel1.Controls.Add(this.cmbNetUnit);
            this.panel1.Controls.Add(this.cmbQty);
            this.panel1.Controls.Add(this.txtQty);
            this.panel1.Controls.Add(this.lblQty);
            this.panel1.Controls.Add(this.txtCross_weiht);
            this.panel1.Controls.Add(this.txtNet_weiht);
            this.panel1.Controls.Add(this.txtPrints);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkAutoPrint);
            this.panel1.Controls.Add(this.lblItem_total);
            this.panel1.Controls.Add(this.btnPrintView);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.cmbItems);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lblRoss_weiht);
            this.panel1.Controls.Add(this.lblNet_weiht);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 264);
            this.panel1.TabIndex = 2;
            // 
            // chkSuit
            // 
            this.chkSuit.AutoSize = true;
            this.chkSuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSuit.Location = new System.Drawing.Point(657, 159);
            this.chkSuit.Name = "chkSuit";
            this.chkSuit.Size = new System.Drawing.Size(152, 33);
            this.chkSuit.TabIndex = 53;
            this.chkSuit.Text = "底三件走貨";
            this.chkSuit.UseVisualStyleBackColor = true;
            this.chkSuit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chkSuit_MouseUp);
            // 
            // cmbCartonSize
            // 
            this.cmbCartonSize.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbCartonSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCartonSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbCartonSize.FormattingEnabled = true;
            this.cmbCartonSize.Location = new System.Drawing.Point(518, 95);
            this.cmbCartonSize.MaxDropDownItems = 12;
            this.cmbCartonSize.MaxLength = 50;
            this.cmbCartonSize.Name = "cmbCartonSize";
            this.cmbCartonSize.Size = new System.Drawing.Size(295, 47);
            this.cmbCartonSize.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(404, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 29);
            this.label8.TabIndex = 50;
            this.label8.Text = "紙箱尺寸";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkBoth
            // 
            this.chkBoth.AutoSize = true;
            this.chkBoth.Checked = true;
            this.chkBoth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoth.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkBoth.Location = new System.Drawing.Point(428, 55);
            this.chkBoth.Name = "chkBoth";
            this.chkBoth.Size = new System.Drawing.Size(344, 33);
            this.chkBoth.TabIndex = 49;
            this.chkBoth.Text = "默認則面、正面標簽一起列印";
            this.chkBoth.UseVisualStyleBackColor = true;
            // 
            // chkIsFinish
            // 
            this.chkIsFinish.AutoSize = true;
            this.chkIsFinish.Checked = true;
            this.chkIsFinish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkIsFinish.Location = new System.Drawing.Point(523, 159);
            this.chkIsFinish.Name = "chkIsFinish";
            this.chkIsFinish.Size = new System.Drawing.Size(80, 33);
            this.chkIsFinish.TabIndex = 48;
            this.chkIsFinish.Text = "套件";
            this.chkIsFinish.UseVisualStyleBackColor = true;
            this.chkIsFinish.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chkIsFinish_MouseUp);
            // 
            // cmbCrossUnit
            // 
            this.cmbCrossUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            this.cmbCrossUnit.FormattingEnabled = true;
            this.cmbCrossUnit.Location = new System.Drawing.Point(742, 208);
            this.cmbCrossUnit.Name = "cmbCrossUnit";
            this.cmbCrossUnit.Size = new System.Drawing.Size(71, 47);
            this.cmbCrossUnit.TabIndex = 6;
            this.cmbCrossUnit.Text = "KG";
            // 
            // cmbNetUnit
            // 
            this.cmbNetUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            this.cmbNetUnit.FormattingEnabled = true;
            this.cmbNetUnit.Location = new System.Drawing.Point(481, 208);
            this.cmbNetUnit.Name = "cmbNetUnit";
            this.cmbNetUnit.Size = new System.Drawing.Size(73, 47);
            this.cmbNetUnit.TabIndex = 4;
            this.cmbNetUnit.Text = "KG";
            // 
            // cmbQty
            // 
            this.cmbQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            this.cmbQty.FormattingEnabled = true;
            this.cmbQty.Location = new System.Drawing.Point(213, 208);
            this.cmbQty.Name = "cmbQty";
            this.cmbQty.Size = new System.Drawing.Size(91, 47);
            this.cmbQty.TabIndex = 2;
            this.cmbQty.Text = "SET";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(72, 208);
            this.txtQty.MaxLength = 10;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(139, 47);
            this.txtQty.TabIndex = 1;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNet_weiht_KeyPress);
            this.txtQty.Leave += new System.EventHandler(this.txtQty_Leave);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblQty.ForeColor = System.Drawing.Color.Black;
            this.lblQty.Location = new System.Drawing.Point(11, 219);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(56, 26);
            this.lblQty.TabIndex = 47;
            this.lblQty.Text = "數量";
            // 
            // txtCross_weiht
            // 
            this.txtCross_weiht.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCross_weiht.Location = new System.Drawing.Point(618, 208);
            this.txtCross_weiht.MaxLength = 10;
            this.txtCross_weiht.Name = "txtCross_weiht";
            this.txtCross_weiht.Size = new System.Drawing.Size(123, 47);
            this.txtCross_weiht.TabIndex = 3;
            this.txtCross_weiht.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCross_weiht.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCross_weiht_KeyPress);
            // 
            // txtNet_weiht
            // 
            this.txtNet_weiht.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNet_weiht.Location = new System.Drawing.Point(370, 208);
            this.txtNet_weiht.MaxLength = 10;
            this.txtNet_weiht.Name = "txtNet_weiht";
            this.txtNet_weiht.Size = new System.Drawing.Size(110, 47);
            this.txtNet_weiht.TabIndex = 2;
            this.txtNet_weiht.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNet_weiht.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNet_weiht_KeyPress);
            // 
            // txtPrints
            // 
            this.txtPrints.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPrints.Location = new System.Drawing.Point(520, 4);
            this.txtPrints.MaxLength = 3;
            this.txtPrints.Name = "txtPrints";
            this.txtPrints.Size = new System.Drawing.Size(77, 47);
            this.txtPrints.TabIndex = 8;
            this.txtPrints.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrints.Click += new System.EventHandler(this.txtPrints_Click);
            this.txtPrints.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrints_KeyPress);
            this.txtPrints.Leave += new System.EventHandler(this.txtPrints_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(404, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 29);
            this.label1.TabIndex = 42;
            this.label1.Text = "列印份數";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAutoPrint
            // 
            this.chkAutoPrint.AutoSize = true;
            this.chkAutoPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkAutoPrint.Location = new System.Drawing.Point(621, 12);
            this.chkAutoPrint.Name = "chkAutoPrint";
            this.chkAutoPrint.Size = new System.Drawing.Size(176, 33);
            this.chkAutoPrint.TabIndex = 4;
            this.chkAutoPrint.Text = "掃描自動列印";
            this.chkAutoPrint.UseVisualStyleBackColor = true;
            this.chkAutoPrint.Click += new System.EventHandler(this.chkAutoPrint_Click);
            // 
            // lblItem_total
            // 
            this.lblItem_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblItem_total.ForeColor = System.Drawing.Color.Blue;
            this.lblItem_total.Location = new System.Drawing.Point(684, 155);
            this.lblItem_total.Name = "lblItem_total";
            this.lblItem_total.Size = new System.Drawing.Size(32, 35);
            this.lblItem_total.TabIndex = 27;
            this.lblItem_total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrintView
            // 
            this.btnPrintView.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPrintView.Location = new System.Drawing.Point(270, 3);
            this.btnPrintView.Name = "btnPrintView";
            this.btnPrintView.Size = new System.Drawing.Size(122, 80);
            this.btnPrintView.TabIndex = 5;
            this.btnPrintView.Text = "預 覽(&V)";
            this.btnPrintView.UseVisualStyleBackColor = false;
            this.btnPrintView.Click += new System.EventHandler(this.btnPrintView_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPrint.Location = new System.Drawing.Point(138, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(122, 80);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "列 印(&P)";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(5, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(122, 80);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbItems
            // 
            this.cmbItems.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbItems.FormattingEnabled = true;
            this.cmbItems.Location = new System.Drawing.Point(72, 149);
            this.cmbItems.MaxLength = 18;
            this.cmbItems.Name = "cmbItems";
            this.cmbItems.Size = new System.Drawing.Size(444, 47);
            this.cmbItems.TabIndex = 0;
            this.cmbItems.SelectedIndexChanged += new System.EventHandler(this.cmbItems_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtBarCode);
            this.panel3.Controls.Add(this.lblBarcode);
            this.panel3.Location = new System.Drawing.Point(3, 89);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(396, 56);
            this.panel3.TabIndex = 4;
            // 
            // txtBarCode
            // 
            this.txtBarCode.BackColor = System.Drawing.Color.Plum;
            this.txtBarCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBarCode.Location = new System.Drawing.Point(69, 3);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(320, 47);
            this.txtBarCode.TabIndex = 0;
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.ForeColor = System.Drawing.Color.DarkViolet;
            this.lblBarcode.Location = new System.Drawing.Point(4, 14);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(61, 29);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "條碼";
            // 
            // lblRoss_weiht
            // 
            this.lblRoss_weiht.AutoSize = true;
            this.lblRoss_weiht.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblRoss_weiht.ForeColor = System.Drawing.Color.Black;
            this.lblRoss_weiht.Location = new System.Drawing.Point(565, 219);
            this.lblRoss_weiht.Name = "lblRoss_weiht";
            this.lblRoss_weiht.Size = new System.Drawing.Size(56, 26);
            this.lblRoss_weiht.TabIndex = 45;
            this.lblRoss_weiht.Text = "毛重";
            this.lblRoss_weiht.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNet_weiht
            // 
            this.lblNet_weiht.AutoSize = true;
            this.lblNet_weiht.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblNet_weiht.ForeColor = System.Drawing.Color.Black;
            this.lblNet_weiht.Location = new System.Drawing.Point(315, 219);
            this.lblNet_weiht.Name = "lblNet_weiht";
            this.lblNet_weiht.Size = new System.Drawing.Size(56, 26);
            this.lblNet_weiht.TabIndex = 1;
            this.lblNet_weiht.Text = "凈重";
            this.lblNet_weiht.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pnlSuit);
            this.panel2.Controls.Add(this.lblMo_group);
            this.panel2.Controls.Add(this.lblDivision);
            this.panel2.Controls.Add(this.lblBrand_name);
            this.panel2.Controls.Add(this.lblBrand_id);
            this.panel2.Controls.Add(this.lblIt_customer);
            this.panel2.Controls.Add(this.lblCustomer_color_id);
            this.panel2.Controls.Add(this.lblCustomer_color);
            this.panel2.Controls.Add(this.rchGoods_desc);
            this.panel2.Controls.Add(this.lblMo_id_barcode);
            this.panel2.Controls.Add(this.lblMo_id);
            this.panel2.Controls.Add(this.lblCustomer);
            this.panel2.Controls.Add(this.lblPO_style);
            this.panel2.Controls.Add(this.lblGoods_id);
            this.panel2.Controls.Add(this.lblOc_no);
            this.panel2.Controls.Add(this.lblCode);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(2, 266);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(818, 469);
            this.panel2.TabIndex = 3;
            // 
            // lblMo_group
            // 
            this.lblMo_group.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMo_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMo_group.Location = new System.Drawing.Point(135, 13);
            this.lblMo_group.Name = "lblMo_group";
            this.lblMo_group.Size = new System.Drawing.Size(88, 31);
            this.lblMo_group.TabIndex = 63;
            this.lblMo_group.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMo_group.Visible = false;
            // 
            // lblDivision
            // 
            this.lblDivision.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivision.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDivision.Location = new System.Drawing.Point(135, 52);
            this.lblDivision.Name = "lblDivision";
            this.lblDivision.Size = new System.Drawing.Size(88, 31);
            this.lblDivision.TabIndex = 62;
            this.lblDivision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDivision.Visible = false;
            // 
            // lblBrand_name
            // 
            this.lblBrand_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBrand_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBrand_name.Location = new System.Drawing.Point(9, 47);
            this.lblBrand_name.Name = "lblBrand_name";
            this.lblBrand_name.Size = new System.Drawing.Size(120, 40);
            this.lblBrand_name.TabIndex = 61;
            this.lblBrand_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBrand_name.Visible = false;
            // 
            // lblBrand_id
            // 
            this.lblBrand_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBrand_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBrand_id.Location = new System.Drawing.Point(10, 4);
            this.lblBrand_id.Name = "lblBrand_id";
            this.lblBrand_id.Size = new System.Drawing.Size(120, 40);
            this.lblBrand_id.TabIndex = 60;
            this.lblBrand_id.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBrand_id.Visible = false;
            // 
            // lblIt_customer
            // 
            this.lblIt_customer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIt_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblIt_customer.Location = new System.Drawing.Point(59, 88);
            this.lblIt_customer.Name = "lblIt_customer";
            this.lblIt_customer.Size = new System.Drawing.Size(172, 42);
            this.lblIt_customer.TabIndex = 59;
            this.lblIt_customer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblIt_customer.Visible = false;
            // 
            // lblCustomer_color_id
            // 
            this.lblCustomer_color_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomer_color_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCustomer_color_id.Location = new System.Drawing.Point(256, 321);
            this.lblCustomer_color_id.Name = "lblCustomer_color_id";
            this.lblCustomer_color_id.Size = new System.Drawing.Size(555, 40);
            this.lblCustomer_color_id.TabIndex = 58;
            this.lblCustomer_color_id.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCustomer_color
            // 
            this.lblCustomer_color.AutoSize = true;
            this.lblCustomer_color.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.lblCustomer_color.Location = new System.Drawing.Point(14, 321);
            this.lblCustomer_color.Name = "lblCustomer_color";
            this.lblCustomer_color.Size = new System.Drawing.Size(250, 39);
            this.lblCustomer_color.TabIndex = 57;
            this.lblCustomer_color.Text = "CUST. COLOR";
            this.lblCustomer_color.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rchGoods_desc
            // 
            this.rchGoods_desc.BackColor = System.Drawing.Color.Gainsboro;
            this.rchGoods_desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rchGoods_desc.Location = new System.Drawing.Point(256, 411);
            this.rchGoods_desc.Name = "rchGoods_desc";
            this.rchGoods_desc.Size = new System.Drawing.Size(555, 183);
            this.rchGoods_desc.TabIndex = 0;
            this.rchGoods_desc.Text = "";
            // 
            // lblMo_id_barcode
            // 
            this.lblMo_id_barcode.Font = new System.Drawing.Font("Code 128", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMo_id_barcode.Location = new System.Drawing.Point(229, 6);
            this.lblMo_id_barcode.Name = "lblMo_id_barcode";
            this.lblMo_id_barcode.Size = new System.Drawing.Size(577, 77);
            this.lblMo_id_barcode.TabIndex = 54;
            this.lblMo_id_barcode.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblMo_id
            // 
            this.lblMo_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMo_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMo_id.Location = new System.Drawing.Point(256, 92);
            this.lblMo_id.Name = "lblMo_id";
            this.lblMo_id.Size = new System.Drawing.Size(555, 42);
            this.lblMo_id.TabIndex = 53;
            this.lblMo_id.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCustomer
            // 
            this.lblCustomer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCustomer.Location = new System.Drawing.Point(256, 139);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(555, 42);
            this.lblCustomer.TabIndex = 47;
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPO_style
            // 
            this.lblPO_style.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPO_style.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPO_style.Location = new System.Drawing.Point(256, 186);
            this.lblPO_style.Name = "lblPO_style";
            this.lblPO_style.Size = new System.Drawing.Size(555, 42);
            this.lblPO_style.TabIndex = 48;
            this.lblPO_style.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGoods_id
            // 
            this.lblGoods_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGoods_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblGoods_id.Location = new System.Drawing.Point(256, 365);
            this.lblGoods_id.Name = "lblGoods_id";
            this.lblGoods_id.Size = new System.Drawing.Size(555, 40);
            this.lblGoods_id.TabIndex = 51;
            this.lblGoods_id.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOc_no
            // 
            this.lblOc_no.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOc_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblOc_no.Location = new System.Drawing.Point(256, 232);
            this.lblOc_no.Name = "lblOc_no";
            this.lblOc_no.Size = new System.Drawing.Size(555, 40);
            this.lblOc_no.TabIndex = 49;
            this.lblOc_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCode
            // 
            this.lblCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCode.Location = new System.Drawing.Point(256, 276);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(555, 40);
            this.lblCode.TabIndex = 50;
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label2.Location = new System.Drawing.Point(51, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 39);
            this.label2.TabIndex = 41;
            this.label2.Text = "CUSTOMER";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label7.Location = new System.Drawing.Point(16, 406);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(248, 39);
            this.label7.TabIndex = 46;
            this.label7.Text = "GOODS DESC";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label3.Location = new System.Drawing.Point(3, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 39);
            this.label3.TabIndex = 42;
            this.label3.Text = "PO NO / STYLE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label6.Location = new System.Drawing.Point(93, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 39);
            this.label6.TabIndex = 45;
            this.label6.Text = "CF CODE";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label4.Location = new System.Drawing.Point(136, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 39);
            this.label4.TabIndex = 43;
            this.label4.Text = "OC NO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label5.Location = new System.Drawing.Point(36, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(228, 39);
            this.label5.TabIndex = 44;
            this.label5.Text = "CUST. CODE";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlSuit
            // 
            this.pnlSuit.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSuit.Controls.Add(this.dgvBom);
            this.pnlSuit.Location = new System.Drawing.Point(256, 2);
            this.pnlSuit.Name = "pnlSuit";
            this.pnlSuit.Size = new System.Drawing.Size(558, 210);
            this.pnlSuit.TabIndex = 64;
            this.pnlSuit.Visible = false;
            // 
            // dgvBom
            // 
            this.dgvBom.AllowUserToAddRows = false;
            this.dgvBom.AllowUserToDeleteRows = false;
            this.dgvBom.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkSelect,
            this.goods_id1,
            this.primary_key1,
            this.goods_desc1});
            this.dgvBom.Location = new System.Drawing.Point(4, 3);
            this.dgvBom.Name = "dgvBom";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBom.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBom.RowHeadersWidth = 30;
            this.dgvBom.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("PMingLiU", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dgvBom.RowTemplate.Height = 35;
            this.dgvBom.Size = new System.Drawing.Size(549, 204);
            this.dgvBom.TabIndex = 3;
            // 
            // chkSelect
            // 
            this.chkSelect.DataPropertyName = "flag_select";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.NullValue = false;
            this.chkSelect.DefaultCellStyle = dataGridViewCellStyle3;
            this.chkSelect.HeaderText = "   ";
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Width = 50;
            // 
            // goods_id1
            // 
            this.goods_id1.DataPropertyName = "goods_id";
            this.goods_id1.HeaderText = "貨品編號";
            this.goods_id1.Name = "goods_id1";
            this.goods_id1.ReadOnly = true;
            this.goods_id1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.goods_id1.Width = 250;
            // 
            // primary_key1
            // 
            this.primary_key1.DataPropertyName = "primary_key";
            this.primary_key1.HeaderText = "";
            this.primary_key1.Name = "primary_key1";
            this.primary_key1.ReadOnly = true;
            this.primary_key1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.primary_key1.Width = 30;
            // 
            // goods_desc1
            // 
            this.goods_desc1.DataPropertyName = "goods_desc";
            this.goods_desc1.HeaderText = "貨品描述";
            this.goods_desc1.Name = "goods_desc1";
            this.goods_desc1.ReadOnly = true;
            this.goods_desc1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.goods_desc1.Width = 230;
            // 
            // frmPackingLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 742);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmPackingLabel";
            this.Text = "frmPackingLabel";
            this.Load += new System.EventHandler(this.frmPackingLabel_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlSuit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrintView;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbItems;
        private System.Windows.Forms.Label lblItem_total;
        private System.Windows.Forms.Label lblMo_id_barcode;
        private System.Windows.Forms.Label lblMo_id;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblPO_style;
        private System.Windows.Forms.Label lblGoods_id;
        private System.Windows.Forms.Label lblOc_no;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rchGoods_desc;
        private System.Windows.Forms.CheckBox chkAutoPrint;
        private System.Windows.Forms.TextBox txtPrints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCross_weiht;
        private System.Windows.Forms.Label lblRoss_weiht;
        private System.Windows.Forms.TextBox txtNet_weiht;
        private System.Windows.Forms.Label lblNet_weiht;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.ComboBox cmbCrossUnit;
        private System.Windows.Forms.ComboBox cmbNetUnit;
        private System.Windows.Forms.ComboBox cmbQty;
        private System.Windows.Forms.Label lblCustomer_color_id;
        private System.Windows.Forms.Label lblCustomer_color;
        private System.Windows.Forms.Label lblIt_customer;
        private System.Windows.Forms.Label lblBrand_name;
        private System.Windows.Forms.Label lblBrand_id;
        private System.Windows.Forms.CheckBox chkIsFinish;
        private System.Windows.Forms.CheckBox chkBoth;
        private System.Windows.Forms.Label lblDivision;
        private System.Windows.Forms.Label lblMo_group;
        private System.Windows.Forms.ComboBox cmbCartonSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkSuit;
        private System.Windows.Forms.Panel pnlSuit;
        private System.Windows.Forms.DataGridView dgvBom;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn primary_key1;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_desc1;
    }
}