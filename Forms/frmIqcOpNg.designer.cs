namespace cf_pad.Forms
{
    partial class frmIqcOpNg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIqcOpNg));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtQcdate = new System.Windows.Forms.MaskedTextBox();
            this.cmbWorker = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtQc_remark = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkOk = new System.Windows.Forms.CheckBox();
            this.chkNg = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtMo_id = new System.Windows.Forms.TextBox();
            this.cmbNot_ok_rmk = new System.Windows.Forms.ComboBox();
            this.txtIqc_state = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblQcResult = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblSaveinfo = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.dgvDetails2 = new System.Windows.Forms.DataGridView();
            this.qc_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issues_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unqualified_iqc_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unqualified_category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qc_result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disposal_method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_person = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picture_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iqc_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bill_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sequence_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtGoods_id = new System.Windows.Forms.TextBox();
            this.txtGoods_Name = new System.Windows.Forms.TextBox();
            this.pic_artwork = new System.Windows.Forms.PictureBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtBill_id = new System.Windows.Forms.TextBox();
            this.txtSequence_id = new System.Windows.Forms.TextBox();
            this.cmbUnqualified_category = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbUnqualified_iqc_seq = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_artwork)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQcdate
            // 
            this.txtQcdate.Font = new System.Drawing.Font("PMingLiU", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtQcdate.Location = new System.Drawing.Point(63, 101);
            this.txtQcdate.Mask = "9999/99/99";
            this.txtQcdate.Name = "txtQcdate";
            this.txtQcdate.PromptChar = ' ';
            this.txtQcdate.ReadOnly = true;
            this.txtQcdate.Size = new System.Drawing.Size(256, 49);
            this.txtQcdate.TabIndex = 82;
            // 
            // cmbWorker
            // 
            this.cmbWorker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorker.Font = new System.Drawing.Font("PMingLiU", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbWorker.FormattingEnabled = true;
            this.cmbWorker.Location = new System.Drawing.Point(63, 328);
            this.cmbWorker.Name = "cmbWorker";
            this.cmbWorker.Size = new System.Drawing.Size(208, 48);
            this.cmbWorker.TabIndex = 81;
            this.cmbWorker.Leave += new System.EventHandler(this.cmbWorker_Leave);
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("PMingLiU", 14.25F);
            this.label26.ForeColor = System.Drawing.Color.DarkViolet;
            this.label26.Location = new System.Drawing.Point(9, 332);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(52, 36);
            this.label26.TabIndex = 78;
            this.label26.Text = "工 號";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQc_remark
            // 
            this.txtQc_remark.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtQc_remark.Location = new System.Drawing.Point(63, 379);
            this.txtQc_remark.Multiline = true;
            this.txtQc_remark.Name = "txtQc_remark";
            this.txtQc_remark.Size = new System.Drawing.Size(706, 81);
            this.txtQc_remark.TabIndex = 74;
            this.txtQc_remark.Leave += new System.EventHandler(this.txtQc_remark_Leave);
            this.txtQc_remark.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtRemark_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkOk);
            this.panel1.Controls.Add(this.chkNg);
            this.panel1.Location = new System.Drawing.Point(64, 276);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 48);
            this.panel1.TabIndex = 67;
            // 
            // chkOk
            // 
            this.chkOk.AutoSize = true;
            this.chkOk.Enabled = false;
            this.chkOk.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOk.ForeColor = System.Drawing.Color.Blue;
            this.chkOk.Location = new System.Drawing.Point(4, 2);
            this.chkOk.Name = "chkOk";
            this.chkOk.Size = new System.Drawing.Size(78, 43);
            this.chkOk.TabIndex = 5;
            this.chkOk.Text = "OK";
            this.chkOk.UseVisualStyleBackColor = true;
            // 
            // chkNg
            // 
            this.chkNg.AutoSize = true;
            this.chkNg.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNg.ForeColor = System.Drawing.Color.Red;
            this.chkNg.Location = new System.Drawing.Point(123, 2);
            this.chkNg.Name = "chkNg";
            this.chkNg.Size = new System.Drawing.Size(78, 43);
            this.chkNg.TabIndex = 4;
            this.chkNg.Text = "NG";
            this.chkNg.UseVisualStyleBackColor = true;
            this.chkNg.Click += new System.EventHandler(this.chkNg_Click);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("PMingLiU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(13, 388);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(49, 27);
            this.label22.TabIndex = 66;
            this.label22.Text = "備註";
            // 
            // txtMo_id
            // 
            this.txtMo_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id.Font = new System.Drawing.Font("PMingLiU", 26F);
            this.txtMo_id.Location = new System.Drawing.Point(423, 101);
            this.txtMo_id.MaxLength = 9;
            this.txtMo_id.Multiline = true;
            this.txtMo_id.Name = "txtMo_id";
            this.txtMo_id.ReadOnly = true;
            this.txtMo_id.Size = new System.Drawing.Size(199, 49);
            this.txtMo_id.TabIndex = 5;
            // 
            // cmbNot_ok_rmk
            // 
            this.cmbNot_ok_rmk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNot_ok_rmk.Font = new System.Drawing.Font("PMingLiU", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbNot_ok_rmk.FormattingEnabled = true;
            this.cmbNot_ok_rmk.Items.AddRange(new object[] {
            "",
            "翻電",
            "移交",
            "分揀",
            "報廢"});
            this.cmbNot_ok_rmk.Location = new System.Drawing.Point(594, 327);
            this.cmbNot_ok_rmk.Name = "cmbNot_ok_rmk";
            this.cmbNot_ok_rmk.Size = new System.Drawing.Size(177, 48);
            this.cmbNot_ok_rmk.TabIndex = 65;
            this.cmbNot_ok_rmk.Leave += new System.EventHandler(this.cmbNot_ok_rmk_Leave);
            // 
            // txtIqc_state
            // 
            this.txtIqc_state.BackColor = System.Drawing.SystemColors.Window;
            this.txtIqc_state.Font = new System.Drawing.Font("PMingLiU", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtIqc_state.ForeColor = System.Drawing.Color.Red;
            this.txtIqc_state.Location = new System.Drawing.Point(461, 153);
            this.txtIqc_state.Multiline = true;
            this.txtIqc_state.Name = "txtIqc_state";
            this.txtIqc_state.ReadOnly = true;
            this.txtIqc_state.Size = new System.Drawing.Size(161, 50);
            this.txtIqc_state.TabIndex = 60;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("PMingLiU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 43);
            this.label9.TabIndex = 23;
            this.label9.Text = "檢驗日期";
            // 
            // lblQcResult
            // 
            this.lblQcResult.Font = new System.Drawing.Font("PMingLiU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQcResult.Location = new System.Drawing.Point(11, 274);
            this.lblQcResult.Name = "lblQcResult";
            this.lblQcResult.Size = new System.Drawing.Size(49, 52);
            this.lblQcResult.TabIndex = 54;
            this.lblQcResult.Text = "檢驗結果";
            this.lblQcResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("PMingLiU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(373, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 43);
            this.label10.TabIndex = 45;
            this.label10.Text = "制單編號";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("PMingLiU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(13, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 52);
            this.label11.TabIndex = 46;
            this.label11.Text = "物料編號";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.label17.Location = new System.Drawing.Point(433, 156);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(26, 46);
            this.label17.TabIndex = 61;
            this.label17.Text = "狀態";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("PMingLiU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(547, 329);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 45);
            this.label18.TabIndex = 63;
            this.label18.Text = "處理方式";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSaveinfo
            // 
            this.lblSaveinfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblSaveinfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSaveinfo.Font = new System.Drawing.Font("PMingLiU", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSaveinfo.ForeColor = System.Drawing.Color.Blue;
            this.lblSaveinfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSaveinfo.Location = new System.Drawing.Point(63, 399);
            this.lblSaveinfo.Name = "lblSaveinfo";
            this.lblSaveinfo.Size = new System.Drawing.Size(703, 59);
            this.lblSaveinfo.TabIndex = 16;
            this.lblSaveinfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSaveinfo.Visible = false;
            // 
            // txtBarCode
            // 
            this.txtBarCode.BackColor = System.Drawing.Color.Thistle;
            this.txtBarCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBarCode.Font = new System.Drawing.Font("PMingLiU", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBarCode.Location = new System.Drawing.Point(104, 20);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(299, 49);
            this.txtBarCode.TabIndex = 0;
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
            this.txtBarCode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtBarCode_MouseDown);
            // 
            // lblBarcode
            // 
            this.lblBarcode.Font = new System.Drawing.Font("PMingLiU", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBarcode.ForeColor = System.Drawing.Color.Blue;
            this.lblBarcode.Location = new System.Drawing.Point(9, 37);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(95, 22);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "制單頁數";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(157, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 89);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(6, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(149, 89);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(776, 100);
            this.panel3.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblBarcode);
            this.groupBox2.Controls.Add(this.txtBarCode);
            this.groupBox2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(319, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 88);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查找條件";
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("PMingLiU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(289, 278);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(47, 44);
            this.label27.TabIndex = 92;
            this.label27.Text = "不良原因";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDetails2
            // 
            this.dgvDetails2.AllowUserToAddRows = false;
            this.dgvDetails2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("PMingLiU", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dgvDetails2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetails2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetails2.ColumnHeadersHeight = 40;
            this.dgvDetails2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qc_date,
            this.mo_id,
            this.goods_id,
            this.goods_name,
            this.issues_qty,
            this.unqualified_iqc_seq,
            this.unqualified_category,
            this.qc_result,
            this.remark,
            this.disposal_method,
            this.vendor_id,
            this.vendor,
            this.check_person,
            this.picture_name,
            this.iqc_state,
            this.id,
            this.bill_id,
            this.sequence_id});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("PMingLiU", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetails2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetails2.Location = new System.Drawing.Point(5, 463);
            this.dgvDetails2.Name = "dgvDetails2";
            this.dgvDetails2.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails2.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetails2.RowHeadersWidth = 25;
            this.dgvDetails2.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("PMingLiU", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dgvDetails2.RowTemplate.Height = 70;
            this.dgvDetails2.Size = new System.Drawing.Size(764, 346);
            this.dgvDetails2.TabIndex = 93;
            this.dgvDetails2.SelectionChanged += new System.EventHandler(this.dgvDetails2_SelectionChanged);
            // 
            // qc_date
            // 
            this.qc_date.DataPropertyName = "qc_date";
            this.qc_date.HeaderText = "檢驗日期";
            this.qc_date.Name = "qc_date";
            this.qc_date.ReadOnly = true;
            this.qc_date.Width = 110;
            // 
            // mo_id
            // 
            this.mo_id.DataPropertyName = "mo_id";
            this.mo_id.HeaderText = "制單編號";
            this.mo_id.Name = "mo_id";
            this.mo_id.ReadOnly = true;
            this.mo_id.Width = 120;
            // 
            // goods_id
            // 
            this.goods_id.DataPropertyName = "goods_id";
            this.goods_id.HeaderText = "物料編號";
            this.goods_id.Name = "goods_id";
            this.goods_id.ReadOnly = true;
            this.goods_id.Width = 230;
            // 
            // goods_name
            // 
            this.goods_name.DataPropertyName = "goods_name";
            this.goods_name.HeaderText = "物料描述";
            this.goods_name.Name = "goods_name";
            this.goods_name.ReadOnly = true;
            this.goods_name.Width = 200;
            // 
            // issues_qty
            // 
            this.issues_qty.DataPropertyName = "issues_qty";
            this.issues_qty.HeaderText = "收貨數量";
            this.issues_qty.Name = "issues_qty";
            this.issues_qty.ReadOnly = true;
            this.issues_qty.Width = 80;
            // 
            // unqualified_iqc_seq
            // 
            this.unqualified_iqc_seq.DataPropertyName = "unqualified_iqc_seq";
            this.unqualified_iqc_seq.HeaderText = "不良原因";
            this.unqualified_iqc_seq.Name = "unqualified_iqc_seq";
            this.unqualified_iqc_seq.ReadOnly = true;
            this.unqualified_iqc_seq.Width = 50;
            // 
            // unqualified_category
            // 
            this.unqualified_category.DataPropertyName = "unqualified_category";
            this.unqualified_category.HeaderText = "原因分類";
            this.unqualified_category.Name = "unqualified_category";
            this.unqualified_category.ReadOnly = true;
            this.unqualified_category.Width = 50;
            // 
            // qc_result
            // 
            this.qc_result.DataPropertyName = "qc_result";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.qc_result.DefaultCellStyle = dataGridViewCellStyle2;
            this.qc_result.HeaderText = "檢驗結果";
            this.qc_result.Name = "qc_result";
            this.qc_result.ReadOnly = true;
            this.qc_result.Width = 80;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "備註";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            this.remark.Width = 200;
            // 
            // disposal_method
            // 
            this.disposal_method.DataPropertyName = "disposal_method";
            this.disposal_method.HeaderText = "處理方式";
            this.disposal_method.Name = "disposal_method";
            this.disposal_method.ReadOnly = true;
            this.disposal_method.Width = 160;
            // 
            // vendor_id
            // 
            this.vendor_id.DataPropertyName = "vendor_id";
            this.vendor_id.HeaderText = " 供應商編號";
            this.vendor_id.Name = "vendor_id";
            this.vendor_id.ReadOnly = true;
            // 
            // vendor
            // 
            this.vendor.DataPropertyName = "vendor";
            this.vendor.HeaderText = "供應商名稱";
            this.vendor.Name = "vendor";
            this.vendor.ReadOnly = true;
            // 
            // check_person
            // 
            this.check_person.DataPropertyName = "check_person";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("PMingLiU", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.check_person.DefaultCellStyle = dataGridViewCellStyle3;
            this.check_person.HeaderText = "工號";
            this.check_person.Name = "check_person";
            this.check_person.ReadOnly = true;
            this.check_person.Width = 70;
            // 
            // picture_name
            // 
            this.picture_name.DataPropertyName = "picture_name";
            this.picture_name.HeaderText = "圖樣";
            this.picture_name.Name = "picture_name";
            this.picture_name.ReadOnly = true;
            this.picture_name.Visible = false;
            // 
            // iqc_state
            // 
            this.iqc_state.DataPropertyName = "iqc_state";
            this.iqc_state.HeaderText = "QC狀態";
            this.iqc_state.Name = "iqc_state";
            this.iqc_state.ReadOnly = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // bill_id
            // 
            this.bill_id.DataPropertyName = "bill_id";
            this.bill_id.HeaderText = "bill_id";
            this.bill_id.Name = "bill_id";
            this.bill_id.ReadOnly = true;
            this.bill_id.Visible = false;
            // 
            // sequence_id
            // 
            this.sequence_id.DataPropertyName = "sequence_id";
            this.sequence_id.HeaderText = "sequence_id";
            this.sequence_id.Name = "sequence_id";
            this.sequence_id.ReadOnly = true;
            this.sequence_id.Visible = false;
            // 
            // txtGoods_id
            // 
            this.txtGoods_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGoods_id.Font = new System.Drawing.Font("PMingLiU", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtGoods_id.Location = new System.Drawing.Point(63, 153);
            this.txtGoods_id.MaxLength = 18;
            this.txtGoods_id.Name = "txtGoods_id";
            this.txtGoods_id.ReadOnly = true;
            this.txtGoods_id.Size = new System.Drawing.Size(362, 46);
            this.txtGoods_id.TabIndex = 94;
            // 
            // txtGoods_Name
            // 
            this.txtGoods_Name.Font = new System.Drawing.Font("PMingLiU", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtGoods_Name.Location = new System.Drawing.Point(63, 204);
            this.txtGoods_Name.Multiline = true;
            this.txtGoods_Name.Name = "txtGoods_Name";
            this.txtGoods_Name.ReadOnly = true;
            this.txtGoods_Name.Size = new System.Drawing.Size(559, 68);
            this.txtGoods_Name.TabIndex = 95;
            // 
            // pic_artwork
            // 
            this.pic_artwork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_artwork.Location = new System.Drawing.Point(627, 110);
            this.pic_artwork.Name = "pic_artwork";
            this.pic_artwork.Size = new System.Drawing.Size(149, 155);
            this.pic_artwork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_artwork.TabIndex = 96;
            this.pic_artwork.TabStop = false;
            // 
            // txtID
            // 
            this.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtID.Location = new System.Drawing.Point(94, 816);
            this.txtID.MaxLength = 18;
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(106, 23);
            this.txtID.TabIndex = 97;
            this.txtID.Visible = false;
            // 
            // txtBill_id
            // 
            this.txtBill_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBill_id.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBill_id.Location = new System.Drawing.Point(277, 816);
            this.txtBill_id.MaxLength = 18;
            this.txtBill_id.Name = "txtBill_id";
            this.txtBill_id.ReadOnly = true;
            this.txtBill_id.Size = new System.Drawing.Size(121, 23);
            this.txtBill_id.TabIndex = 98;
            this.txtBill_id.Visible = false;
            // 
            // txtSequence_id
            // 
            this.txtSequence_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSequence_id.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSequence_id.Location = new System.Drawing.Point(423, 816);
            this.txtSequence_id.MaxLength = 18;
            this.txtSequence_id.Name = "txtSequence_id";
            this.txtSequence_id.ReadOnly = true;
            this.txtSequence_id.Size = new System.Drawing.Size(121, 23);
            this.txtSequence_id.TabIndex = 99;
            this.txtSequence_id.Visible = false;
            // 
            // cmbUnqualified_category
            // 
            this.cmbUnqualified_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnqualified_category.Font = new System.Drawing.Font("PMingLiU", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbUnqualified_category.FormattingEnabled = true;
            this.cmbUnqualified_category.Items.AddRange(new object[] {
            "",
            "翻電",
            "移交",
            "分選",
            "報廢"});
            this.cmbUnqualified_category.Location = new System.Drawing.Point(342, 327);
            this.cmbUnqualified_category.Name = "cmbUnqualified_category";
            this.cmbUnqualified_category.Size = new System.Drawing.Size(193, 48);
            this.cmbUnqualified_category.TabIndex = 100;
            this.cmbUnqualified_category.Leave += new System.EventHandler(this.cmbUnqualified_category_Leave);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.label1.Location = new System.Drawing.Point(271, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 46);
            this.label1.TabIndex = 101;
            this.label1.Text = "不良原因分類";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbUnqualified_iqc_seq
            // 
            this.cmbUnqualified_iqc_seq.Font = new System.Drawing.Font("PMingLiU", 30F);
            this.cmbUnqualified_iqc_seq.FormattingEnabled = true;
            this.cmbUnqualified_iqc_seq.Location = new System.Drawing.Point(342, 275);
            this.cmbUnqualified_iqc_seq.MaxLength = 50;
            this.cmbUnqualified_iqc_seq.Name = "cmbUnqualified_iqc_seq";
            this.cmbUnqualified_iqc_seq.Size = new System.Drawing.Size(428, 48);
            this.cmbUnqualified_iqc_seq.TabIndex = 102;
            this.cmbUnqualified_iqc_seq.Leave += new System.EventHandler(this.cmbUnqualified_iqc_seq_Leave);
            // 
            // frmIqcOpNg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 842);
            this.Controls.Add(this.cmbUnqualified_category);
            this.Controls.Add(this.cmbUnqualified_iqc_seq);
            this.Controls.Add(this.txtSequence_id);
            this.Controls.Add(this.txtBill_id);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.pic_artwork);
            this.Controls.Add(this.txtGoods_Name);
            this.Controls.Add(this.txtQcdate);
            this.Controls.Add(this.txtGoods_id);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtMo_id);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblSaveinfo);
            this.Controls.Add(this.txtIqc_state);
            this.Controls.Add(this.dgvDetails2);
            this.Controls.Add(this.txtQc_remark);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbWorker);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.cmbNot_ok_rmk);
            this.Controls.Add(this.lblQcResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label18);
            this.Name = "frmIqcOpNg";
            this.Text = "frmIqcOpNg";
            this.Load += new System.EventHandler(this.frmIqcOpNg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_artwork)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Label lblSaveinfo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMo_id;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblQcResult;
        private System.Windows.Forms.CheckBox chkNg;
        private System.Windows.Forms.TextBox txtIqc_state;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbNot_ok_rmk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtQc_remark;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cmbWorker;
        private System.Windows.Forms.MaskedTextBox txtQcdate;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtGoods_id;
        private System.Windows.Forms.DataGridView dgvDetails2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtGoods_Name;
        private System.Windows.Forms.CheckBox chkOk;
        private System.Windows.Forms.PictureBox pic_artwork;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtBill_id;
        private System.Windows.Forms.TextBox txtSequence_id;
        private System.Windows.Forms.ComboBox cmbUnqualified_category;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbUnqualified_iqc_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn qc_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn issues_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn unqualified_iqc_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn unqualified_category;
        private System.Windows.Forms.DataGridViewTextBoxColumn qc_result;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn disposal_method;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn check_person;
        private System.Windows.Forms.DataGridViewTextBoxColumn picture_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn iqc_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn bill_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn sequence_id;

    }
}