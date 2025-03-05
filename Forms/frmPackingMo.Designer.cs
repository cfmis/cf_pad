namespace cf_pad.Forms
{
    partial class frmPackingMo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPackingMo));
            this.tbc = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbPackage_num = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbBoxno = new System.Windows.Forms.ComboBox();
            this.lblSaveinfo = new System.Windows.Forms.Label();
            this.txtPrd_id = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMo_id = new System.Windows.Forms.TextBox();
            this.txtWeg = new System.Windows.Forms.TextBox();
            this.lblSend_qty = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblOrder = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.mo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.box_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.package_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upd_flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prd_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMO2 = new System.Windows.Forms.TextBox();
            this.txtMO1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mskDat2 = new System.Windows.Forms.MaskedTextBox();
            this.mskDat1 = new System.Windows.Forms.MaskedTextBox();
            this.dgvDetails2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boxno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.package_num1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSet = new System.Windows.Forms.Button();
            this.tbc.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbc
            // 
            this.tbc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbc.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tbc.Controls.Add(this.tabPage1);
            this.tbc.Controls.Add(this.tabPage2);
            this.tbc.Font = new System.Drawing.Font("PMingLiU", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbc.Location = new System.Drawing.Point(3, -13);
            this.tbc.Multiline = true;
            this.tbc.Name = "tbc";
            this.tbc.Padding = new System.Drawing.Point(36, 36);
            this.tbc.SelectedIndex = 0;
            this.tbc.Size = new System.Drawing.Size(1008, 719);
            this.tbc.TabIndex = 4;
            this.tbc.SelectedIndexChanged += new System.EventHandler(this.tbc_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cmbPackage_num);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.cmbBoxno);
            this.tabPage1.Controls.Add(this.lblSaveinfo);
            this.tabPage1.Controls.Add(this.txtPrd_id);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtMo_id);
            this.tabPage1.Controls.Add(this.txtWeg);
            this.tabPage1.Controls.Add(this.lblSend_qty);
            this.tabPage1.Controls.Add(this.txtQty);
            this.tabPage1.Controls.Add(this.lblOrder);
            this.tabPage1.Controls.Add(this.lblBarcode);
            this.tabPage1.Controls.Add(this.txtBarCode);
            this.tabPage1.Controls.Add(this.dgvDetails);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Font = new System.Drawing.Font("PMingLiU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage1.Location = new System.Drawing.Point(4, 106);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1000, 609);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "數據錄入";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(462, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 34);
            this.label9.TabIndex = 64;
            this.label9.Text = "件數";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPackage_num
            // 
            this.cmbPackage_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.cmbPackage_num.FormattingEnabled = true;
            this.cmbPackage_num.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbPackage_num.Location = new System.Drawing.Point(549, 203);
            this.cmbPackage_num.Name = "cmbPackage_num";
            this.cmbPackage_num.Size = new System.Drawing.Size(133, 47);
            this.cmbPackage_num.TabIndex = 63;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(461, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 34);
            this.label8.TabIndex = 62;
            this.label8.Text = "箱號";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbBoxno
            // 
            this.cmbBoxno.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.cmbBoxno.FormattingEnabled = true;
            this.cmbBoxno.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbBoxno.Location = new System.Drawing.Point(549, 137);
            this.cmbBoxno.Name = "cmbBoxno";
            this.cmbBoxno.Size = new System.Drawing.Size(133, 47);
            this.cmbBoxno.TabIndex = 61;
            // 
            // lblSaveinfo
            // 
            this.lblSaveinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSaveinfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblSaveinfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSaveinfo.Font = new System.Drawing.Font("PMingLiU", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSaveinfo.ForeColor = System.Drawing.Color.Blue;
            this.lblSaveinfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSaveinfo.Location = new System.Drawing.Point(175, 252);
            this.lblSaveinfo.Name = "lblSaveinfo";
            this.lblSaveinfo.Size = new System.Drawing.Size(695, 82);
            this.lblSaveinfo.TabIndex = 16;
            this.lblSaveinfo.Text = "數據保存成功！";
            this.lblSaveinfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSaveinfo.Visible = false;
            // 
            // txtPrd_id
            // 
            this.txtPrd_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrd_id.Location = new System.Drawing.Point(554, 65);
            this.txtPrd_id.MaxLength = 10;
            this.txtPrd_id.Name = "txtPrd_id";
            this.txtPrd_id.ReadOnly = true;
            this.txtPrd_id.Size = new System.Drawing.Size(128, 47);
            this.txtPrd_id.TabIndex = 58;
            this.txtPrd_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrd_id.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(34, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 29);
            this.label7.TabIndex = 57;
            this.label7.Text = "制單頁數";
            // 
            // txtMo_id
            // 
            this.txtMo_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMo_id.Location = new System.Drawing.Point(166, 78);
            this.txtMo_id.MaxLength = 10;
            this.txtMo_id.Name = "txtMo_id";
            this.txtMo_id.ReadOnly = true;
            this.txtMo_id.Size = new System.Drawing.Size(228, 47);
            this.txtMo_id.TabIndex = 3;
            // 
            // txtWeg
            // 
            this.txtWeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeg.Location = new System.Drawing.Point(166, 203);
            this.txtWeg.MaxLength = 10;
            this.txtWeg.Name = "txtWeg";
            this.txtWeg.Size = new System.Drawing.Size(228, 47);
            this.txtWeg.TabIndex = 2;
            this.txtWeg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWeg.Click += new System.EventHandler(this.txtWeg_Click);
            this.txtWeg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeg_KeyPress);
            // 
            // lblSend_qty
            // 
            this.lblSend_qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSend_qty.ForeColor = System.Drawing.Color.Black;
            this.lblSend_qty.Location = new System.Drawing.Point(12, 207);
            this.lblSend_qty.Name = "lblSend_qty";
            this.lblSend_qty.Size = new System.Drawing.Size(136, 34);
            this.lblSend_qty.TabIndex = 54;
            this.lblSend_qty.Text = "走貨重量";
            this.lblSend_qty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(166, 137);
            this.txtQty.MaxLength = 10;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(228, 47);
            this.txtQty.TabIndex = 1;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.Click += new System.EventHandler(this.txtQty_Click);
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.ForeColor = System.Drawing.Color.Black;
            this.lblOrder.Location = new System.Drawing.Point(34, 144);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(109, 29);
            this.lblOrder.TabIndex = 52;
            this.lblOrder.Text = "走貨數量";
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("PMingLiU", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBarcode.ForeColor = System.Drawing.Color.DarkViolet;
            this.lblBarcode.Location = new System.Drawing.Point(23, 18);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(120, 27);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "掃描頁數";
            // 
            // txtBarCode
            // 
            this.txtBarCode.BackColor = System.Drawing.Color.Plum;
            this.txtBarCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBarCode.Font = new System.Drawing.Font("PMingLiU", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBarCode.Location = new System.Drawing.Point(166, 9);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(310, 52);
            this.txtBarCode.TabIndex = 0;
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("PMingLiU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dgvDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetails.ColumnHeadersHeight = 65;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mo_id,
            this.qty,
            this.weg,
            this.box_no,
            this.package_num,
            this.update_user,
            this.update_time,
            this.upd_flag,
            this.prd_id});
            this.dgvDetails.Location = new System.Drawing.Point(1, 271);
            this.dgvDetails.Name = "dgvDetails";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("PMingLiU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetails.RowHeadersWidth = 25;
            this.dgvDetails.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("PMingLiU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dgvDetails.RowTemplate.Height = 60;
            this.dgvDetails.Size = new System.Drawing.Size(994, 328);
            this.dgvDetails.TabIndex = 9;
            this.dgvDetails.SelectionChanged += new System.EventHandler(this.dgvDetails_SelectionChanged);
            // 
            // mo_id
            // 
            this.mo_id.DataPropertyName = "mo_id";
            this.mo_id.Frozen = true;
            this.mo_id.HeaderText = "頁數編號";
            this.mo_id.Name = "mo_id";
            this.mo_id.ReadOnly = true;
            this.mo_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.mo_id.Width = 150;
            // 
            // qty
            // 
            this.qty.DataPropertyName = "qty";
            this.qty.HeaderText = "走貨數量";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.qty.Width = 120;
            // 
            // weg
            // 
            this.weg.DataPropertyName = "weg";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.weg.DefaultCellStyle = dataGridViewCellStyle2;
            this.weg.HeaderText = "走貨重量";
            this.weg.Name = "weg";
            this.weg.ReadOnly = true;
            this.weg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.weg.Width = 120;
            // 
            // box_no
            // 
            this.box_no.DataPropertyName = "box_no";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.box_no.DefaultCellStyle = dataGridViewCellStyle3;
            this.box_no.HeaderText = "箱號";
            this.box_no.Name = "box_no";
            this.box_no.ReadOnly = true;
            this.box_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // package_num
            // 
            this.package_num.DataPropertyName = "package_num";
            this.package_num.HeaderText = "件數";
            this.package_num.Name = "package_num";
            this.package_num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // update_user
            // 
            this.update_user.DataPropertyName = "update_user";
            this.update_user.HeaderText = "修改人";
            this.update_user.Name = "update_user";
            this.update_user.ReadOnly = true;
            this.update_user.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // update_time
            // 
            this.update_time.DataPropertyName = "update_time";
            this.update_time.HeaderText = "修改日期";
            this.update_time.Name = "update_time";
            this.update_time.ReadOnly = true;
            this.update_time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.update_time.Width = 200;
            // 
            // upd_flag
            // 
            this.upd_flag.DataPropertyName = "upd_flag";
            this.upd_flag.HeaderText = "狀態";
            this.upd_flag.Name = "upd_flag";
            this.upd_flag.ReadOnly = true;
            this.upd_flag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.upd_flag.Visible = false;
            // 
            // prd_id
            // 
            this.prd_id.DataPropertyName = "prd_id";
            this.prd_id.HeaderText = "prd_id";
            this.prd_id.Name = "prd_id";
            this.prd_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.prd_id.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(398, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 29);
            this.label6.TabIndex = 60;
            this.label6.Text = "KG";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(398, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 29);
            this.label5.TabIndex = 59;
            this.label5.Text = "PCS";
            // 
            // tabPage2
            // 
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.btnPrint);
            this.tabPage2.Controls.Add(this.btnFind);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtMO2);
            this.tabPage2.Controls.Add(this.txtMO1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.mskDat2);
            this.tabPage2.Controls.Add(this.mskDat1);
            this.tabPage2.Controls.Add(this.dgvDetails2);
            this.tabPage2.Font = new System.Drawing.Font("PMingLiU", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage2.Location = new System.Drawing.Point(4, 106);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1000, 609);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "數據查詢";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("PMingLiU", 20F);
            this.label4.Location = new System.Drawing.Point(294, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 27);
            this.label4.TabIndex = 48;
            this.label4.Text = "~";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PMingLiU", 20F);
            this.label3.Location = new System.Drawing.Point(294, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 27);
            this.label3.TabIndex = 47;
            this.label3.Text = "~";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("PMingLiU", 20F);
            this.btnPrint.Location = new System.Drawing.Point(659, 25);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(128, 74);
            this.btnPrint.TabIndex = 46;
            this.btnPrint.Text = "列印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("PMingLiU", 20F);
            this.btnFind.Location = new System.Drawing.Point(526, 25);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(128, 74);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "查詢(&F)";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 20F);
            this.label2.Location = new System.Drawing.Point(13, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 27);
            this.label2.TabIndex = 43;
            this.label2.Text = "頁 數:";
            // 
            // txtMO2
            // 
            this.txtMO2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMO2.Font = new System.Drawing.Font("PMingLiU", 25F);
            this.txtMO2.Location = new System.Drawing.Point(321, 67);
            this.txtMO2.MaxLength = 9;
            this.txtMO2.Name = "txtMO2";
            this.txtMO2.Size = new System.Drawing.Size(192, 47);
            this.txtMO2.TabIndex = 3;
            this.txtMO2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMO2_KeyPress);
            // 
            // txtMO1
            // 
            this.txtMO1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMO1.Font = new System.Drawing.Font("PMingLiU", 25F);
            this.txtMO1.Location = new System.Drawing.Point(99, 67);
            this.txtMO1.MaxLength = 9;
            this.txtMO1.Name = "txtMO1";
            this.txtMO1.Size = new System.Drawing.Size(192, 47);
            this.txtMO1.TabIndex = 2;
            this.txtMO1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMO1_KeyPress);
            this.txtMO1.Leave += new System.EventHandler(this.txtMO1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 20F);
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 27);
            this.label1.TabIndex = 40;
            this.label1.Text = "日 期:";
            // 
            // mskDat2
            // 
            this.mskDat2.Font = new System.Drawing.Font("PMingLiU", 25F);
            this.mskDat2.Location = new System.Drawing.Point(321, 14);
            this.mskDat2.Mask = "0000/00/00";
            this.mskDat2.Name = "mskDat2";
            this.mskDat2.Size = new System.Drawing.Size(192, 47);
            this.mskDat2.TabIndex = 1;
            this.mskDat2.ValidatingType = typeof(System.DateTime);
            this.mskDat2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBox1_KeyPress);
            // 
            // mskDat1
            // 
            this.mskDat1.Font = new System.Drawing.Font("PMingLiU", 25F);
            this.mskDat1.Location = new System.Drawing.Point(99, 14);
            this.mskDat1.Mask = "0000/00/00";
            this.mskDat1.Name = "mskDat1";
            this.mskDat1.Size = new System.Drawing.Size(192, 47);
            this.mskDat1.TabIndex = 0;
            this.mskDat1.ValidatingType = typeof(System.DateTime);
            this.mskDat1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mskDat1_KeyPress);
            this.mskDat1.Leave += new System.EventHandler(this.mskDat1_Leave);
            // 
            // dgvDetails2
            // 
            this.dgvDetails2.AllowUserToAddRows = false;
            this.dgvDetails2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("PMingLiU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dgvDetails2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetails2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetails2.ColumnHeadersHeight = 80;
            this.dgvDetails2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetails2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.boxno,
            this.package_num1,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn14});
            this.dgvDetails2.Location = new System.Drawing.Point(1, 133);
            this.dgvDetails2.Name = "dgvDetails2";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("PMingLiU", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails2.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDetails2.RowHeadersWidth = 25;
            this.dgvDetails2.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("PMingLiU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dgvDetails2.RowTemplate.Height = 120;
            this.dgvDetails2.Size = new System.Drawing.Size(898, 630);
            this.dgvDetails2.TabIndex = 10;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "mo_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "頁數編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "qty";
            this.dataGridViewTextBoxColumn2.HeaderText = "數量";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "weg";
            this.dataGridViewTextBoxColumn3.HeaderText = "重量";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // boxno
            // 
            this.boxno.DataPropertyName = "box_no";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.boxno.DefaultCellStyle = dataGridViewCellStyle6;
            this.boxno.HeaderText = "箱號";
            this.boxno.Name = "boxno";
            this.boxno.ReadOnly = true;
            this.boxno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.boxno.Width = 80;
            // 
            // package_num1
            // 
            this.package_num1.DataPropertyName = "package_num";
            this.package_num1.HeaderText = "件數";
            this.package_num1.Name = "package_num1";
            this.package_num1.ReadOnly = true;
            this.package_num1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.package_num1.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "upd_flag";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn5.HeaderText = "狀態";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "update_user";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn6.HeaderText = "修改人";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "update_time";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn11.HeaderText = "修改日期";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn11.Width = 200;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "prd_id";
            this.dataGridViewTextBoxColumn14.HeaderText = "prd_id";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("PMingLiU", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.Location = new System.Drawing.Point(343, 3);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(164, 80);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "刪除(&D)";
            this.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("PMingLiU", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(173, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(164, 80);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("PMingLiU", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(3, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(164, 80);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSet);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 89);
            this.panel1.TabIndex = 5;
            // 
            // btnSet
            // 
            this.btnSet.Font = new System.Drawing.Font("PMingLiU", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSet.Location = new System.Drawing.Point(513, 3);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(164, 80);
            this.btnSet.TabIndex = 8;
            this.btnSet.Text = "數據瀏覽";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // frmPackingMo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbc);
            this.Name = "frmPackingMo";
            this.Text = "frmPackingMo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPackingMo_FormClosed);
            this.Load += new System.EventHandler(this.frmPackingMo_Load);
            this.tbc.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbc;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblSaveinfo;
        private System.Windows.Forms.DataGridView dgvDetails2;
        private System.Windows.Forms.MaskedTextBox mskDat1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMO2;
        private System.Windows.Forms.TextBox txtMO1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mskDat2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.TextBox txtWeg;
        private System.Windows.Forms.Label lblSend_qty;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMo_id;
        private System.Windows.Forms.TextBox txtPrd_id;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbBoxno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbPackage_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn weg;
        private System.Windows.Forms.DataGridViewTextBoxColumn box_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn package_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn update_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn update_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn upd_flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn prd_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn boxno;
        private System.Windows.Forms.DataGridViewTextBoxColumn package_num1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
    }
}