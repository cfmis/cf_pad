namespace cf_pad.Forms
{
    partial class frmProductQtyConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductQtyConfirm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConvert = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.mktConfTime2 = new System.Windows.Forms.MaskedTextBox();
            this.mktConfTime1 = new System.Windows.Forms.MaskedTextBox();
            this.chkQc = new System.Windows.Forms.CheckBox();
            this.mktDate2 = new System.Windows.Forms.MaskedTextBox();
            this.mktDate1 = new System.Windows.Forms.MaskedTextBox();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.rdbYesConf = new System.Windows.Forms.RadioButton();
            this.rdbNoConf = new System.Windows.Forms.RadioButton();
            this.textMo1 = new System.Windows.Forms.TextBox();
            this.textDep1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblConfTime = new System.Windows.Forms.Label();
            this.labMo = new System.Windows.Forms.Label();
            this.labPrdDate = new System.Windows.Forms.Label();
            this.labDep = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.colPrd_mo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrd_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItem_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrd_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrd_weg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActual_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActual_weg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMat_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMat_item_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMat_item_lot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrd_dep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrd_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrd_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQc_flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCrusr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCrtim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActual_pack_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPack_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTo_dep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConf_flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConf_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImput_flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImput_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSample_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSample_weg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrd_work_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCountWeg = new System.Windows.Forms.Button();
            this.btnCountQty = new System.Windows.Forms.Button();
            this.txtSample_weg = new System.Windows.Forms.TextBox();
            this.txtSample_no = new System.Windows.Forms.TextBox();
            this.lblSample_no = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblWegUnit = new System.Windows.Forms.Label();
            this.txtItemDesc = new System.Windows.Forms.TextBox();
            this.txtConf_time = new System.Windows.Forms.TextBox();
            this.txtQc_flag = new System.Windows.Forms.TextBox();
            this.txtConf_flag = new System.Windows.Forms.TextBox();
            this.txtMatLot = new System.Windows.Forms.TextBox();
            this.txtMatDesc = new System.Windows.Forms.TextBox();
            this.txtMatItem = new System.Windows.Forms.TextBox();
            this.txtActualPack = new System.Windows.Forms.TextBox();
            this.txtWeg = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblQc_flag = new System.Windows.Forms.Label();
            this.lblConf_flag = new System.Windows.Forms.Label();
            this.lblMatLot = new System.Windows.Forms.Label();
            this.txtPrdItem = new System.Windows.Forms.TextBox();
            this.lblMatCode = new System.Windows.Forms.Label();
            this.lblActualPack = new System.Windows.Forms.Label();
            this.lblWeg = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtPrdMo = new System.Windows.Forms.TextBox();
            this.lblPrdItem = new System.Windows.Forms.Label();
            this.txtFdep = new System.Windows.Forms.TextBox();
            this.txtToDep = new System.Windows.Forms.TextBox();
            this.txtReq = new System.Windows.Forms.TextBox();
            this.lblReq = new System.Windows.Forms.Label();
            this.lblPrdMo = new System.Windows.Forms.Label();
            this.lblFdep = new System.Windows.Forms.Label();
            this.lblToDep = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdgFromDep = new System.Windows.Forms.RadioButton();
            this.rdgFromJx = new System.Windows.Forms.RadioButton();
            this.lblTransfer_flag = new System.Windows.Forms.Label();
            this.lblItemDesc = new System.Windows.Forms.Label();
            this.lblMatDesc = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblBarCode = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dteSentDate = new System.Windows.Forms.DateTimePicker();
            this.lblShowMsg1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMutRec = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.btnSave,
            this.toolStripSeparator2,
            this.btnMutRec,
            this.toolStripSeparator6,
            this.btnFind,
            this.toolStripSeparator3,
            this.btnUndo,
            this.toolStripSeparator4,
            this.btnConvert,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1049, 63);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.AutoSize = false;
            this.BTNEXIT.Font = new System.Drawing.Font("新細明體", 16F);
            this.BTNEXIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXIT.Image")));
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(140, 60);
            this.BTNEXIT.Text = "退出(&X)";
            this.BTNEXIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNEXIT.Click += new System.EventHandler(this.BTNEXIT_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 63);
            // 
            // btnFind
            // 
            this.btnFind.AutoSize = false;
            this.btnFind.Font = new System.Drawing.Font("新細明體", 16F);
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(140, 60);
            this.btnFind.Text = "查詢(&F)";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.ToolTipText = "查詢(&F)";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 63);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Font = new System.Drawing.Font("新細明體", 16F);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 60);
            this.btnSave.Text = "儲存(&S)";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 63);
            // 
            // btnUndo
            // 
            this.btnUndo.AutoSize = false;
            this.btnUndo.Font = new System.Drawing.Font("新細明體", 16F);
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(140, 60);
            this.btnUndo.Text = "取消(&U)";
            this.btnUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 63);
            // 
            // btnConvert
            // 
            this.btnConvert.AutoSize = false;
            this.btnConvert.Font = new System.Drawing.Font("新細明體", 16F);
            this.btnConvert.Image = ((System.Drawing.Image)(resources.GetObject("btnConvert.Image")));
            this.btnConvert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(140, 60);
            this.btnConvert.Text = "數量轉換";
            this.btnConvert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 63);
            // 
            // txtBarCode
            // 
            this.txtBarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtBarCode.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBarCode.Location = new System.Drawing.Point(94, 3);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(693, 46);
            this.txtBarCode.TabIndex = 0;
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "HH:mm";
            this.dtpEnd.Font = new System.Drawing.Font("新細明體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(342, 327);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size(233, 65);
            this.dtpEnd.TabIndex = 24;
            this.dtpEnd.Value = new System.DateTime(2014, 8, 19, 0, 0, 0, 0);
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "HH:mm";
            this.dtpStart.Font = new System.Drawing.Font("新細明體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(77, 327);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowUpDown = true;
            this.dtpStart.Size = new System.Drawing.Size(233, 65);
            this.dtpStart.TabIndex = 23;
            this.dtpStart.Value = new System.DateTime(2014, 8, 19, 0, 0, 0, 0);
            // 
            // mktConfTime2
            // 
            this.mktConfTime2.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.mktConfTime2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mktConfTime2.Location = new System.Drawing.Point(342, 275);
            this.mktConfTime2.Mask = "0000/00/00";
            this.mktConfTime2.Name = "mktConfTime2";
            this.mktConfTime2.PromptChar = ' ';
            this.mktConfTime2.Size = new System.Drawing.Size(233, 46);
            this.mktConfTime2.TabIndex = 7;
            this.mktConfTime2.Visible = false;
            // 
            // mktConfTime1
            // 
            this.mktConfTime1.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.mktConfTime1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mktConfTime1.Location = new System.Drawing.Point(77, 272);
            this.mktConfTime1.Mask = "0000/00/00";
            this.mktConfTime1.Name = "mktConfTime1";
            this.mktConfTime1.PromptChar = ' ';
            this.mktConfTime1.Size = new System.Drawing.Size(233, 46);
            this.mktConfTime1.TabIndex = 6;
            this.mktConfTime1.TextChanged += new System.EventHandler(this.mktConfTime1_TextChanged);
            this.mktConfTime1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mktConfTime1_MouseDown);
            // 
            // chkQc
            // 
            this.chkQc.AutoSize = true;
            this.chkQc.Checked = true;
            this.chkQc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkQc.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkQc.Location = new System.Drawing.Point(77, 464);
            this.chkQc.Name = "chkQc";
            this.chkQc.Size = new System.Drawing.Size(174, 31);
            this.chkQc.TabIndex = 22;
            this.chkQc.Text = "包含未做QC";
            this.chkQc.UseVisualStyleBackColor = true;
            this.chkQc.Visible = false;
            // 
            // mktDate2
            // 
            this.mktDate2.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.mktDate2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mktDate2.Location = new System.Drawing.Point(342, 213);
            this.mktDate2.Mask = "9999/99/99";
            this.mktDate2.Name = "mktDate2";
            this.mktDate2.PromptChar = ' ';
            this.mktDate2.Size = new System.Drawing.Size(233, 46);
            this.mktDate2.TabIndex = 3;
            this.mktDate2.ValidatingType = typeof(System.DateTime);
            // 
            // mktDate1
            // 
            this.mktDate1.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.mktDate1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mktDate1.Location = new System.Drawing.Point(77, 213);
            this.mktDate1.Mask = "9999/99/99";
            this.mktDate1.Name = "mktDate1";
            this.mktDate1.PromptChar = ' ';
            this.mktDate1.Size = new System.Drawing.Size(233, 46);
            this.mktDate1.TabIndex = 2;
            this.mktDate1.ValidatingType = typeof(System.DateTime);
            this.mktDate1.TextChanged += new System.EventHandler(this.mktDate1_TextChanged);
            this.mktDate1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mktDate1_MouseDown);
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdbAll.Location = new System.Drawing.Point(257, 6);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(138, 31);
            this.rdbAll.TabIndex = 19;
            this.rdbAll.Text = "全部記錄";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // rdbYesConf
            // 
            this.rdbYesConf.AutoSize = true;
            this.rdbYesConf.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdbYesConf.Location = new System.Drawing.Point(140, 6);
            this.rdbYesConf.Name = "rdbYesConf";
            this.rdbYesConf.Size = new System.Drawing.Size(111, 31);
            this.rdbYesConf.TabIndex = 18;
            this.rdbYesConf.Text = "已磅貨";
            this.rdbYesConf.UseVisualStyleBackColor = true;
            // 
            // rdbNoConf
            // 
            this.rdbNoConf.AutoSize = true;
            this.rdbNoConf.Checked = true;
            this.rdbNoConf.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdbNoConf.Location = new System.Drawing.Point(23, 6);
            this.rdbNoConf.Name = "rdbNoConf";
            this.rdbNoConf.Size = new System.Drawing.Size(111, 31);
            this.rdbNoConf.TabIndex = 17;
            this.rdbNoConf.TabStop = true;
            this.rdbNoConf.Text = "未磅貨";
            this.rdbNoConf.UseVisualStyleBackColor = true;
            // 
            // textMo1
            // 
            this.textMo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textMo1.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textMo1.Location = new System.Drawing.Point(77, 159);
            this.textMo1.MaxLength = 10;
            this.textMo1.Name = "textMo1";
            this.textMo1.Size = new System.Drawing.Size(233, 46);
            this.textMo1.TabIndex = 4;
            this.textMo1.TextChanged += new System.EventHandler(this.textMo1_TextChanged);
            this.textMo1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textMo1_KeyPress);
            // 
            // textDep1
            // 
            this.textDep1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textDep1.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textDep1.Location = new System.Drawing.Point(77, 107);
            this.textDep1.MaxLength = 3;
            this.textDep1.Name = "textDep1";
            this.textDep1.Size = new System.Drawing.Size(233, 46);
            this.textDep1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(11, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 49);
            this.label1.TabIndex = 13;
            this.label1.Text = "確認時間:";
            // 
            // lblConfTime
            // 
            this.lblConfTime.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblConfTime.Location = new System.Drawing.Point(11, 268);
            this.lblConfTime.Name = "lblConfTime";
            this.lblConfTime.Size = new System.Drawing.Size(64, 49);
            this.lblConfTime.TabIndex = 13;
            this.lblConfTime.Text = "確認日期:";
            // 
            // labMo
            // 
            this.labMo.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labMo.Location = new System.Drawing.Point(15, 155);
            this.labMo.Name = "labMo";
            this.labMo.Size = new System.Drawing.Size(60, 50);
            this.labMo.TabIndex = 10;
            this.labMo.Text = "制單編號:";
            // 
            // labPrdDate
            // 
            this.labPrdDate.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labPrdDate.Location = new System.Drawing.Point(11, 213);
            this.labPrdDate.Name = "labPrdDate";
            this.labPrdDate.Size = new System.Drawing.Size(64, 56);
            this.labPrdDate.TabIndex = 13;
            this.labPrdDate.Text = "生產日期:";
            // 
            // labDep
            // 
            this.labDep.AutoSize = true;
            this.labDep.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labDep.Location = new System.Drawing.Point(15, 117);
            this.labDep.Name = "labDep";
            this.labDep.Size = new System.Drawing.Size(60, 22);
            this.labDep.TabIndex = 12;
            this.labDep.Text = "部門:";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.ColumnHeadersHeight = 60;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPrd_mo,
            this.colPrd_item,
            this.colItem_desc,
            this.colPrd_qty,
            this.colPrd_weg,
            this.colActual_qty,
            this.colActual_weg,
            this.colMat_item,
            this.colMat_item_desc,
            this.colMat_item_lot,
            this.colPrd_dep,
            this.colPrd_date,
            this.colPrd_id,
            this.colQc_flag,
            this.colCrusr,
            this.colCrtim,
            this.colActual_pack_num,
            this.colPack_num,
            this.colTo_dep,
            this.colConf_flag,
            this.colConf_time,
            this.colImput_flag,
            this.colImput_time,
            this.colId,
            this.colSample_no,
            this.colSample_weg,
            this.colPrd_work_type});
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(3, 489);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersWidth = 40;
            this.dgvDetails.RowTemplate.Height = 120;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(1035, 72);
            this.dgvDetails.TabIndex = 1;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            this.dgvDetails.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDetails_RowPostPaint);
            // 
            // colPrd_mo
            // 
            this.colPrd_mo.DataPropertyName = "prd_mo";
            this.colPrd_mo.HeaderText = "制單編號";
            this.colPrd_mo.Name = "colPrd_mo";
            this.colPrd_mo.ReadOnly = true;
            this.colPrd_mo.Width = 120;
            // 
            // colPrd_item
            // 
            this.colPrd_item.DataPropertyName = "prd_item";
            this.colPrd_item.HeaderText = "物料編號";
            this.colPrd_item.Name = "colPrd_item";
            this.colPrd_item.ReadOnly = true;
            this.colPrd_item.Width = 240;
            // 
            // colItem_desc
            // 
            this.colItem_desc.DataPropertyName = "item_desc";
            this.colItem_desc.HeaderText = "物料描述";
            this.colItem_desc.Name = "colItem_desc";
            this.colItem_desc.ReadOnly = true;
            this.colItem_desc.Width = 340;
            // 
            // colPrd_qty
            // 
            this.colPrd_qty.DataPropertyName = "prd_qty";
            this.colPrd_qty.HeaderText = "生產數量";
            this.colPrd_qty.Name = "colPrd_qty";
            this.colPrd_qty.ReadOnly = true;
            // 
            // colPrd_weg
            // 
            this.colPrd_weg.DataPropertyName = "prd_weg";
            this.colPrd_weg.HeaderText = "生產重量";
            this.colPrd_weg.Name = "colPrd_weg";
            this.colPrd_weg.ReadOnly = true;
            // 
            // colActual_qty
            // 
            this.colActual_qty.DataPropertyName = "actual_qty";
            this.colActual_qty.HeaderText = "實際數量";
            this.colActual_qty.Name = "colActual_qty";
            this.colActual_qty.ReadOnly = true;
            // 
            // colActual_weg
            // 
            this.colActual_weg.DataPropertyName = "actual_weg";
            this.colActual_weg.HeaderText = "實際重量";
            this.colActual_weg.Name = "colActual_weg";
            this.colActual_weg.ReadOnly = true;
            // 
            // colMat_item
            // 
            this.colMat_item.DataPropertyName = "mat_item";
            this.colMat_item.HeaderText = "原料編號";
            this.colMat_item.Name = "colMat_item";
            this.colMat_item.ReadOnly = true;
            // 
            // colMat_item_desc
            // 
            this.colMat_item_desc.DataPropertyName = "mat_item_desc";
            this.colMat_item_desc.HeaderText = "原料描述";
            this.colMat_item_desc.Name = "colMat_item_desc";
            this.colMat_item_desc.ReadOnly = true;
            // 
            // colMat_item_lot
            // 
            this.colMat_item_lot.DataPropertyName = "mat_item_lot";
            this.colMat_item_lot.HeaderText = "原料批號";
            this.colMat_item_lot.Name = "colMat_item_lot";
            this.colMat_item_lot.ReadOnly = true;
            // 
            // colPrd_dep
            // 
            this.colPrd_dep.DataPropertyName = "prd_dep";
            this.colPrd_dep.HeaderText = "部門";
            this.colPrd_dep.Name = "colPrd_dep";
            this.colPrd_dep.ReadOnly = true;
            // 
            // colPrd_date
            // 
            this.colPrd_date.DataPropertyName = "prd_date";
            this.colPrd_date.HeaderText = "生產日期";
            this.colPrd_date.Name = "colPrd_date";
            this.colPrd_date.ReadOnly = true;
            // 
            // colPrd_id
            // 
            this.colPrd_id.DataPropertyName = "prd_id";
            this.colPrd_id.HeaderText = "記錄號";
            this.colPrd_id.Name = "colPrd_id";
            this.colPrd_id.ReadOnly = true;
            // 
            // colQc_flag
            // 
            this.colQc_flag.DataPropertyName = "qc_flag";
            this.colQc_flag.HeaderText = "QC標識";
            this.colQc_flag.Name = "colQc_flag";
            this.colQc_flag.ReadOnly = true;
            // 
            // colCrusr
            // 
            this.colCrusr.DataPropertyName = "crusr";
            this.colCrusr.HeaderText = "錄入人員";
            this.colCrusr.Name = "colCrusr";
            this.colCrusr.ReadOnly = true;
            // 
            // colCrtim
            // 
            this.colCrtim.DataPropertyName = "crtim";
            this.colCrtim.HeaderText = "錄入日期";
            this.colCrtim.Name = "colCrtim";
            this.colCrtim.ReadOnly = true;
            this.colCrtim.Width = 200;
            // 
            // colActual_pack_num
            // 
            this.colActual_pack_num.DataPropertyName = "actual_pack_num";
            this.colActual_pack_num.HeaderText = "實際包數";
            this.colActual_pack_num.Name = "colActual_pack_num";
            this.colActual_pack_num.ReadOnly = true;
            // 
            // colPack_num
            // 
            this.colPack_num.DataPropertyName = "pack_num";
            this.colPack_num.HeaderText = "生產包數";
            this.colPack_num.Name = "colPack_num";
            this.colPack_num.ReadOnly = true;
            // 
            // colTo_dep
            // 
            this.colTo_dep.DataPropertyName = "to_dep";
            this.colTo_dep.HeaderText = "收貨部門";
            this.colTo_dep.Name = "colTo_dep";
            this.colTo_dep.ReadOnly = true;
            // 
            // colConf_flag
            // 
            this.colConf_flag.DataPropertyName = "conf_flag";
            this.colConf_flag.HeaderText = "磅貨標識";
            this.colConf_flag.Name = "colConf_flag";
            this.colConf_flag.ReadOnly = true;
            this.colConf_flag.Width = 60;
            // 
            // colConf_time
            // 
            this.colConf_time.DataPropertyName = "conf_time";
            this.colConf_time.HeaderText = "磅貨日期";
            this.colConf_time.Name = "colConf_time";
            this.colConf_time.ReadOnly = true;
            this.colConf_time.Width = 200;
            // 
            // colImput_flag
            // 
            this.colImput_flag.DataPropertyName = "imput_flag";
            this.colImput_flag.HeaderText = "過數標識";
            this.colImput_flag.Name = "colImput_flag";
            this.colImput_flag.ReadOnly = true;
            this.colImput_flag.Width = 60;
            // 
            // colImput_time
            // 
            this.colImput_time.DataPropertyName = "imput_time";
            this.colImput_time.HeaderText = "過數日期";
            this.colImput_time.Name = "colImput_time";
            this.colImput_time.ReadOnly = true;
            this.colImput_time.Width = 200;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "id";
            this.colId.HeaderText = "計劃生產單號";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colSample_no
            // 
            this.colSample_no.DataPropertyName = "sample_no";
            this.colSample_no.HeaderText = "個數";
            this.colSample_no.Name = "colSample_no";
            this.colSample_no.ReadOnly = true;
            // 
            // colSample_weg
            // 
            this.colSample_weg.DataPropertyName = "sample_weg";
            this.colSample_weg.HeaderText = "個數重量";
            this.colSample_weg.Name = "colSample_weg";
            this.colSample_weg.ReadOnly = true;
            // 
            // colPrd_work_type
            // 
            this.colPrd_work_type.DataPropertyName = "prd_work_type";
            this.colPrd_work_type.HeaderText = "生產類型";
            this.colPrd_work_type.Name = "colPrd_work_type";
            this.colPrd_work_type.ReadOnly = true;
            // 
            // btnCountWeg
            // 
            this.btnCountWeg.BackColor = System.Drawing.Color.DeepPink;
            this.btnCountWeg.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCountWeg.Location = new System.Drawing.Point(375, 144);
            this.btnCountWeg.Name = "btnCountWeg";
            this.btnCountWeg.Size = new System.Drawing.Size(167, 76);
            this.btnCountWeg.TabIndex = 49;
            this.btnCountWeg.Text = "計重量";
            this.btnCountWeg.UseVisualStyleBackColor = false;
            this.btnCountWeg.Click += new System.EventHandler(this.btnCountWeg_Click);
            // 
            // btnCountQty
            // 
            this.btnCountQty.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCountQty.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCountQty.Location = new System.Drawing.Point(375, 46);
            this.btnCountQty.Name = "btnCountQty";
            this.btnCountQty.Size = new System.Drawing.Size(167, 76);
            this.btnCountQty.TabIndex = 48;
            this.btnCountQty.Text = "計數量";
            this.btnCountQty.UseVisualStyleBackColor = false;
            this.btnCountQty.Click += new System.EventHandler(this.btnCountQty_Click);
            // 
            // txtSample_weg
            // 
            this.txtSample_weg.Font = new System.Drawing.Font("新細明體", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSample_weg.Location = new System.Drawing.Point(107, 157);
            this.txtSample_weg.Name = "txtSample_weg";
            this.txtSample_weg.Size = new System.Drawing.Size(185, 71);
            this.txtSample_weg.TabIndex = 43;
            // 
            // txtSample_no
            // 
            this.txtSample_no.Font = new System.Drawing.Font("新細明體", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSample_no.Location = new System.Drawing.Point(107, 43);
            this.txtSample_no.Name = "txtSample_no";
            this.txtSample_no.Size = new System.Drawing.Size(185, 71);
            this.txtSample_no.TabIndex = 42;
            // 
            // lblSample_no
            // 
            this.lblSample_no.AutoSize = true;
            this.lblSample_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSample_no.ForeColor = System.Drawing.Color.Black;
            this.lblSample_no.Location = new System.Drawing.Point(36, 65);
            this.lblSample_no.Name = "lblSample_no";
            this.lblSample_no.Size = new System.Drawing.Size(76, 31);
            this.lblSample_no.TabIndex = 46;
            this.lblSample_no.Text = "個數:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(36, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 31);
            this.label6.TabIndex = 45;
            this.label6.Text = "重量:";
            // 
            // lblWegUnit
            // 
            this.lblWegUnit.AutoSize = true;
            this.lblWegUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblWegUnit.ForeColor = System.Drawing.Color.Black;
            this.lblWegUnit.Location = new System.Drawing.Point(298, 177);
            this.lblWegUnit.Name = "lblWegUnit";
            this.lblWegUnit.Size = new System.Drawing.Size(59, 31);
            this.lblWegUnit.TabIndex = 44;
            this.lblWegUnit.Text = "(克)";
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.BackColor = System.Drawing.SystemColors.Control;
            this.txtItemDesc.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtItemDesc.Location = new System.Drawing.Point(87, 159);
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.ReadOnly = true;
            this.txtItemDesc.Size = new System.Drawing.Size(692, 46);
            this.txtItemDesc.TabIndex = 1;
            // 
            // txtConf_time
            // 
            this.txtConf_time.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtConf_time.ForeColor = System.Drawing.Color.Red;
            this.txtConf_time.Location = new System.Drawing.Point(419, 369);
            this.txtConf_time.Name = "txtConf_time";
            this.txtConf_time.ReadOnly = true;
            this.txtConf_time.Size = new System.Drawing.Size(361, 46);
            this.txtConf_time.TabIndex = 2;
            // 
            // txtQc_flag
            // 
            this.txtQc_flag.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtQc_flag.ForeColor = System.Drawing.Color.Blue;
            this.txtQc_flag.Location = new System.Drawing.Point(602, 266);
            this.txtQc_flag.Name = "txtQc_flag";
            this.txtQc_flag.ReadOnly = true;
            this.txtQc_flag.Size = new System.Drawing.Size(177, 46);
            this.txtQc_flag.TabIndex = 2;
            // 
            // txtConf_flag
            // 
            this.txtConf_flag.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtConf_flag.ForeColor = System.Drawing.Color.Red;
            this.txtConf_flag.Location = new System.Drawing.Point(351, 369);
            this.txtConf_flag.Name = "txtConf_flag";
            this.txtConf_flag.ReadOnly = true;
            this.txtConf_flag.Size = new System.Drawing.Size(62, 46);
            this.txtConf_flag.TabIndex = 2;
            // 
            // txtMatLot
            // 
            this.txtMatLot.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMatLot.Location = new System.Drawing.Point(87, 369);
            this.txtMatLot.Name = "txtMatLot";
            this.txtMatLot.Size = new System.Drawing.Size(206, 46);
            this.txtMatLot.TabIndex = 2;
            // 
            // txtMatDesc
            // 
            this.txtMatDesc.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMatDesc.Location = new System.Drawing.Point(87, 317);
            this.txtMatDesc.Name = "txtMatDesc";
            this.txtMatDesc.Size = new System.Drawing.Size(693, 46);
            this.txtMatDesc.TabIndex = 2;
            // 
            // txtMatItem
            // 
            this.txtMatItem.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMatItem.Location = new System.Drawing.Point(87, 266);
            this.txtMatItem.Name = "txtMatItem";
            this.txtMatItem.Size = new System.Drawing.Size(458, 46);
            this.txtMatItem.TabIndex = 2;
            this.txtMatItem.Leave += new System.EventHandler(this.txtMatItem_Leave);
            // 
            // txtActualPack
            // 
            this.txtActualPack.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtActualPack.Location = new System.Drawing.Point(602, 210);
            this.txtActualPack.Name = "txtActualPack";
            this.txtActualPack.Size = new System.Drawing.Size(177, 46);
            this.txtActualPack.TabIndex = 1;
            // 
            // txtWeg
            // 
            this.txtWeg.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtWeg.Location = new System.Drawing.Point(351, 210);
            this.txtWeg.Name = "txtWeg";
            this.txtWeg.Size = new System.Drawing.Size(193, 46);
            this.txtWeg.TabIndex = 1;
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtQty.Location = new System.Drawing.Point(87, 210);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(206, 46);
            this.txtQty.TabIndex = 0;
            // 
            // lblQc_flag
            // 
            this.lblQc_flag.AutoSize = true;
            this.lblQc_flag.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblQc_flag.ForeColor = System.Drawing.Color.Blue;
            this.lblQc_flag.Location = new System.Drawing.Point(568, 281);
            this.lblQc_flag.Name = "lblQc_flag";
            this.lblQc_flag.Size = new System.Drawing.Size(29, 16);
            this.lblQc_flag.TabIndex = 0;
            this.lblQc_flag.Text = "QC";
            // 
            // lblConf_flag
            // 
            this.lblConf_flag.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblConf_flag.ForeColor = System.Drawing.Color.Red;
            this.lblConf_flag.Location = new System.Drawing.Point(305, 376);
            this.lblConf_flag.Name = "lblConf_flag";
            this.lblConf_flag.Size = new System.Drawing.Size(43, 40);
            this.lblConf_flag.TabIndex = 0;
            this.lblConf_flag.Text = "磅貨標識";
            // 
            // lblMatLot
            // 
            this.lblMatLot.AutoSize = true;
            this.lblMatLot.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMatLot.Location = new System.Drawing.Point(12, 383);
            this.lblMatLot.Name = "lblMatLot";
            this.lblMatLot.Size = new System.Drawing.Size(72, 16);
            this.lblMatLot.TabIndex = 0;
            this.lblMatLot.Text = "原料批號";
            // 
            // txtPrdItem
            // 
            this.txtPrdItem.BackColor = System.Drawing.SystemColors.Control;
            this.txtPrdItem.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPrdItem.Location = new System.Drawing.Point(87, 107);
            this.txtPrdItem.Name = "txtPrdItem";
            this.txtPrdItem.ReadOnly = true;
            this.txtPrdItem.Size = new System.Drawing.Size(458, 46);
            this.txtPrdItem.TabIndex = 1;
            // 
            // lblMatCode
            // 
            this.lblMatCode.AutoSize = true;
            this.lblMatCode.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMatCode.Location = new System.Drawing.Point(12, 281);
            this.lblMatCode.Name = "lblMatCode";
            this.lblMatCode.Size = new System.Drawing.Size(72, 16);
            this.lblMatCode.TabIndex = 0;
            this.lblMatCode.Text = "原料編號";
            // 
            // lblActualPack
            // 
            this.lblActualPack.AutoSize = true;
            this.lblActualPack.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblActualPack.Location = new System.Drawing.Point(557, 226);
            this.lblActualPack.Name = "lblActualPack";
            this.lblActualPack.Size = new System.Drawing.Size(40, 16);
            this.lblActualPack.TabIndex = 0;
            this.lblActualPack.Text = "包數";
            // 
            // lblWeg
            // 
            this.lblWeg.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblWeg.Location = new System.Drawing.Point(305, 218);
            this.lblWeg.Name = "lblWeg";
            this.lblWeg.Size = new System.Drawing.Size(43, 40);
            this.lblWeg.TabIndex = 0;
            this.lblWeg.Text = "實際重量";
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblQty.Location = new System.Drawing.Point(12, 226);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(72, 16);
            this.lblQty.TabIndex = 0;
            this.lblQty.Text = "實際數量";
            // 
            // txtPrdMo
            // 
            this.txtPrdMo.BackColor = System.Drawing.SystemColors.Control;
            this.txtPrdMo.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPrdMo.Location = new System.Drawing.Point(87, 55);
            this.txtPrdMo.Name = "txtPrdMo";
            this.txtPrdMo.ReadOnly = true;
            this.txtPrdMo.Size = new System.Drawing.Size(458, 46);
            this.txtPrdMo.TabIndex = 1;
            // 
            // lblPrdItem
            // 
            this.lblPrdItem.AutoSize = true;
            this.lblPrdItem.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPrdItem.Location = new System.Drawing.Point(12, 123);
            this.lblPrdItem.Name = "lblPrdItem";
            this.lblPrdItem.Size = new System.Drawing.Size(72, 16);
            this.lblPrdItem.TabIndex = 0;
            this.lblPrdItem.Text = "物料編號";
            // 
            // txtFdep
            // 
            this.txtFdep.BackColor = System.Drawing.SystemColors.Control;
            this.txtFdep.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtFdep.Location = new System.Drawing.Point(602, 55);
            this.txtFdep.Name = "txtFdep";
            this.txtFdep.ReadOnly = true;
            this.txtFdep.Size = new System.Drawing.Size(177, 46);
            this.txtFdep.TabIndex = 1;
            // 
            // txtToDep
            // 
            this.txtToDep.BackColor = System.Drawing.SystemColors.Control;
            this.txtToDep.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtToDep.Location = new System.Drawing.Point(602, 109);
            this.txtToDep.Name = "txtToDep";
            this.txtToDep.ReadOnly = true;
            this.txtToDep.Size = new System.Drawing.Size(177, 46);
            this.txtToDep.TabIndex = 1;
            // 
            // txtReq
            // 
            this.txtReq.BackColor = System.Drawing.SystemColors.Control;
            this.txtReq.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtReq.Location = new System.Drawing.Point(836, 159);
            this.txtReq.Name = "txtReq";
            this.txtReq.ReadOnly = true;
            this.txtReq.Size = new System.Drawing.Size(177, 46);
            this.txtReq.TabIndex = 1;
            // 
            // lblReq
            // 
            this.lblReq.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblReq.Location = new System.Drawing.Point(788, 165);
            this.lblReq.Name = "lblReq";
            this.lblReq.Size = new System.Drawing.Size(43, 40);
            this.lblReq.TabIndex = 0;
            this.lblReq.Text = "記錄   號";
            // 
            // lblPrdMo
            // 
            this.lblPrdMo.AutoSize = true;
            this.lblPrdMo.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPrdMo.Location = new System.Drawing.Point(12, 68);
            this.lblPrdMo.Name = "lblPrdMo";
            this.lblPrdMo.Size = new System.Drawing.Size(72, 16);
            this.lblPrdMo.TabIndex = 0;
            this.lblPrdMo.Text = "制單編號";
            // 
            // lblFdep
            // 
            this.lblFdep.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblFdep.Location = new System.Drawing.Point(554, 57);
            this.lblFdep.Name = "lblFdep";
            this.lblFdep.Size = new System.Drawing.Size(43, 40);
            this.lblFdep.TabIndex = 0;
            this.lblFdep.Text = "發貨部門";
            // 
            // lblToDep
            // 
            this.lblToDep.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblToDep.Location = new System.Drawing.Point(554, 111);
            this.lblToDep.Name = "lblToDep";
            this.lblToDep.Size = new System.Drawing.Size(43, 40);
            this.lblToDep.TabIndex = 0;
            this.lblToDep.Text = "收貨部門";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "prd_mo";
            this.dataGridViewTextBoxColumn1.HeaderText = "制單編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 140;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "prd_item";
            this.dataGridViewTextBoxColumn2.HeaderText = "物料編號";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 220;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "item_desc";
            this.dataGridViewTextBoxColumn3.HeaderText = "物料描述";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 440;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "prd_qty";
            this.dataGridViewTextBoxColumn4.HeaderText = "生產數量";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "prd_weg";
            this.dataGridViewTextBoxColumn5.HeaderText = "生產重量";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "actual_qty";
            this.dataGridViewTextBoxColumn6.HeaderText = "實際數量";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "actual_weg";
            this.dataGridViewTextBoxColumn7.HeaderText = "實際重量";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "mat_code";
            this.dataGridViewTextBoxColumn8.HeaderText = "原料編號";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "mat_code_lot";
            this.dataGridViewTextBoxColumn9.HeaderText = "原料批號";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "prd_date";
            this.dataGridViewTextBoxColumn10.HeaderText = "生產日期";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "prd_id";
            this.dataGridViewTextBoxColumn11.HeaderText = "記錄號";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "qc_flag";
            this.dataGridViewTextBoxColumn12.HeaderText = "QC標識";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "crusr";
            this.dataGridViewTextBoxColumn13.HeaderText = "錄入人員";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "crtim";
            this.dataGridViewTextBoxColumn14.HeaderText = "錄入日期";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "crtim";
            this.dataGridViewTextBoxColumn15.HeaderText = "錄入日期";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "actual_pack_num";
            this.dataGridViewTextBoxColumn16.HeaderText = "實際包數";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rdbNoConf);
            this.panel1.Controls.Add(this.rdbAll);
            this.panel1.Controls.Add(this.rdbYesConf);
            this.panel1.Location = new System.Drawing.Point(77, 398);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 47);
            this.panel1.TabIndex = 26;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(66, 50);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1049, 684);
            this.tabControl1.TabIndex = 51;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvDetails);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 116);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1041, 564);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1035, 486);
            this.panel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.rdgFromDep);
            this.panel4.Controls.Add(this.lblShowMsg1);
            this.panel4.Controls.Add(this.rdgFromJx);
            this.panel4.Location = new System.Drawing.Point(87, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(689, 46);
            this.panel4.TabIndex = 46;
            // 
            // rdgFromDep
            // 
            this.rdgFromDep.Checked = true;
            this.rdgFromDep.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdgFromDep.Location = new System.Drawing.Point(21, 4);
            this.rdgFromDep.Name = "rdgFromDep";
            this.rdgFromDep.Size = new System.Drawing.Size(125, 31);
            this.rdgFromDep.TabIndex = 1;
            this.rdgFromDep.TabStop = true;
            this.rdgFromDep.Text = "本部門";
            this.rdgFromDep.UseVisualStyleBackColor = true;
            this.rdgFromDep.Click += new System.EventHandler(this.rdgFromDep_Click);
            // 
            // rdgFromJx
            // 
            this.rdgFromJx.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdgFromJx.Location = new System.Drawing.Point(188, 4);
            this.rdgFromJx.Name = "rdgFromJx";
            this.rdgFromJx.Size = new System.Drawing.Size(154, 31);
            this.rdgFromJx.TabIndex = 2;
            this.rdgFromJx.Text = "從JX收貨";
            this.rdgFromJx.UseVisualStyleBackColor = true;
            this.rdgFromJx.Click += new System.EventHandler(this.rdgFromJx_Click);
            // 
            // lblTransfer_flag
            // 
            this.lblTransfer_flag.AutoSize = true;
            this.lblTransfer_flag.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTransfer_flag.Location = new System.Drawing.Point(44, 21);
            this.lblTransfer_flag.Name = "lblTransfer_flag";
            this.lblTransfer_flag.Size = new System.Drawing.Size(40, 16);
            this.lblTransfer_flag.TabIndex = 45;
            this.lblTransfer_flag.Text = "來源";
            // 
            // lblItemDesc
            // 
            this.lblItemDesc.AutoSize = true;
            this.lblItemDesc.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblItemDesc.Location = new System.Drawing.Point(12, 173);
            this.lblItemDesc.Name = "lblItemDesc";
            this.lblItemDesc.Size = new System.Drawing.Size(72, 16);
            this.lblItemDesc.TabIndex = 0;
            this.lblItemDesc.Text = "物料描述";
            // 
            // lblMatDesc
            // 
            this.lblMatDesc.AutoSize = true;
            this.lblMatDesc.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMatDesc.Location = new System.Drawing.Point(12, 332);
            this.lblMatDesc.Name = "lblMatDesc";
            this.lblMatDesc.Size = new System.Drawing.Size(72, 16);
            this.lblMatDesc.TabIndex = 0;
            this.lblMatDesc.Text = "原料描述";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCountWeg);
            this.tabPage2.Controls.Add(this.btnCountQty);
            this.tabPage2.Controls.Add(this.txtSample_no);
            this.tabPage2.Controls.Add(this.lblWegUnit);
            this.tabPage2.Controls.Add(this.txtSample_weg);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.lblSample_no);
            this.tabPage2.Location = new System.Drawing.Point(4, 116);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1041, 564);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnSearch);
            this.tabPage3.Controls.Add(this.textDep1);
            this.tabPage3.Controls.Add(this.textMo1);
            this.tabPage3.Controls.Add(this.mktDate1);
            this.tabPage3.Controls.Add(this.dtpEnd);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.mktConfTime2);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.mktConfTime1);
            this.tabPage3.Controls.Add(this.lblConfTime);
            this.tabPage3.Controls.Add(this.labPrdDate);
            this.tabPage3.Controls.Add(this.mktDate2);
            this.tabPage3.Controls.Add(this.dtpStart);
            this.tabPage3.Controls.Add(this.labDep);
            this.tabPage3.Controls.Add(this.chkQc);
            this.tabPage3.Controls.Add(this.labMo);
            this.tabPage3.Location = new System.Drawing.Point(4, 116);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1041, 564);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSearch.Location = new System.Drawing.Point(77, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(233, 64);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblBarCode
            // 
            this.lblBarCode.AutoSize = true;
            this.lblBarCode.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBarCode.Location = new System.Drawing.Point(44, 17);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(40, 16);
            this.lblBarCode.TabIndex = 0;
            this.lblBarCode.Text = "條碼";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtBarCode);
            this.panel3.Controls.Add(this.lblBarCode);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 63);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1049, 54);
            this.panel3.TabIndex = 52;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblTransfer_flag);
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.lblMatCode);
            this.panel5.Controls.Add(this.lblMatDesc);
            this.panel5.Controls.Add(this.txtItemDesc);
            this.panel5.Controls.Add(this.lblPrdMo);
            this.panel5.Controls.Add(this.txtMatDesc);
            this.panel5.Controls.Add(this.lblQty);
            this.panel5.Controls.Add(this.txtReq);
            this.panel5.Controls.Add(this.lblPrdItem);
            this.panel5.Controls.Add(this.txtToDep);
            this.panel5.Controls.Add(this.lblItemDesc);
            this.panel5.Controls.Add(this.txtFdep);
            this.panel5.Controls.Add(this.lblMatLot);
            this.panel5.Controls.Add(this.txtActualPack);
            this.panel5.Controls.Add(this.lblToDep);
            this.panel5.Controls.Add(this.txtConf_time);
            this.panel5.Controls.Add(this.lblFdep);
            this.panel5.Controls.Add(this.txtQc_flag);
            this.panel5.Controls.Add(this.lblActualPack);
            this.panel5.Controls.Add(this.txtMatLot);
            this.panel5.Controls.Add(this.lblWeg);
            this.panel5.Controls.Add(this.txtPrdItem);
            this.panel5.Controls.Add(this.lblQc_flag);
            this.panel5.Controls.Add(this.txtPrdMo);
            this.panel5.Controls.Add(this.lblConf_flag);
            this.panel5.Controls.Add(this.txtQty);
            this.panel5.Controls.Add(this.txtConf_flag);
            this.panel5.Controls.Add(this.txtMatItem);
            this.panel5.Controls.Add(this.lblReq);
            this.panel5.Controls.Add(this.txtWeg);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 62);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1035, 424);
            this.panel5.TabIndex = 47;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dteSentDate);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1035, 62);
            this.panel6.TabIndex = 48;
            this.panel6.Visible = false;
            // 
            // dteSentDate
            // 
            this.dteSentDate.CalendarFont = new System.Drawing.Font("新細明體", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dteSentDate.CustomFormat = "yyyy/MM/dd";
            this.dteSentDate.Font = new System.Drawing.Font("新細明體", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dteSentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteSentDate.Location = new System.Drawing.Point(87, 10);
            this.dteSentDate.Name = "dteSentDate";
            this.dteSentDate.Size = new System.Drawing.Size(689, 43);
            this.dteSentDate.TabIndex = 46;
            this.dteSentDate.Value = new System.DateTime(2019, 9, 26, 0, 0, 0, 0);
            // 
            // lblShowMsg1
            // 
            this.lblShowMsg1.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblShowMsg1.ForeColor = System.Drawing.Color.Red;
            this.lblShowMsg1.Location = new System.Drawing.Point(348, 10);
            this.lblShowMsg1.Name = "lblShowMsg1";
            this.lblShowMsg1.Size = new System.Drawing.Size(336, 29);
            this.lblShowMsg1.TabIndex = 47;
            this.lblShowMsg1.Text = "收貨時,必須指定對方發貨的日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 39;
            this.label2.Text = "發貨日期";
            // 
            // btnMutRec
            // 
            this.btnMutRec.AutoSize = false;
            this.btnMutRec.Font = new System.Drawing.Font("新細明體", 16F);
            this.btnMutRec.Image = ((System.Drawing.Image)(resources.GetObject("btnMutRec.Image")));
            this.btnMutRec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMutRec.Name = "btnMutRec";
            this.btnMutRec.Size = new System.Drawing.Size(140, 60);
            this.btnMutRec.Text = "多批次";
            this.btnMutRec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMutRec.Click += new System.EventHandler(this.btnMutRec_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 63);
            // 
            // frmProductQtyConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 684);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmProductQtyConfirm";
            this.Text = "生產產品磅貨確認";
            this.Load += new System.EventHandler(this.frmProductQtyConfirm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.MaskedTextBox mktDate2;
        private System.Windows.Forms.MaskedTextBox mktDate1;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.RadioButton rdbYesConf;
        private System.Windows.Forms.RadioButton rdbNoConf;
        private System.Windows.Forms.TextBox textMo1;
        private System.Windows.Forms.TextBox textDep1;
        private System.Windows.Forms.Label labMo;
        private System.Windows.Forms.Label labPrdDate;
        private System.Windows.Forms.Label labDep;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.CheckBox chkQc;
        private System.Windows.Forms.Label lblConfTime;
        private System.Windows.Forms.MaskedTextBox mktConfTime2;
        private System.Windows.Forms.MaskedTextBox mktConfTime1;
        private System.Windows.Forms.TextBox txtReq;
        private System.Windows.Forms.Label lblReq;
        private System.Windows.Forms.TextBox txtPrdMo;
        private System.Windows.Forms.Label lblPrdMo;
        private System.Windows.Forms.TextBox txtItemDesc;
        private System.Windows.Forms.TextBox txtPrdItem;
        private System.Windows.Forms.Label lblPrdItem;
        private System.Windows.Forms.TextBox txtWeg;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblWeg;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtMatItem;
        private System.Windows.Forms.Label lblMatCode;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TextBox txtMatLot;
        private System.Windows.Forms.Label lblMatLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.TextBox txtActualPack;
        private System.Windows.Forms.Label lblActualPack;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.TextBox txtToDep;
        private System.Windows.Forms.Label lblToDep;
        private System.Windows.Forms.TextBox txtMatDesc;
        private System.Windows.Forms.TextBox txtFdep;
        private System.Windows.Forms.Label lblFdep;
        private System.Windows.Forms.TextBox txtConf_time;
        private System.Windows.Forms.TextBox txtConf_flag;
        private System.Windows.Forms.Label lblConf_flag;
        private System.Windows.Forms.TextBox txtQc_flag;
        private System.Windows.Forms.Label lblQc_flag;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.TextBox txtSample_weg;
        private System.Windows.Forms.TextBox txtSample_no;
        private System.Windows.Forms.Label lblSample_no;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblWegUnit;
        private System.Windows.Forms.Button btnCountWeg;
        private System.Windows.Forms.Button btnCountQty;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripButton btnConvert;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblBarCode;
        private System.Windows.Forms.Label lblItemDesc;
        private System.Windows.Forms.Label lblMatDesc;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdgFromDep;
        private System.Windows.Forms.RadioButton rdgFromJx;
        private System.Windows.Forms.Label lblTransfer_flag;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_mo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_weg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActual_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActual_weg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMat_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMat_item_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMat_item_lot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_dep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQc_flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCrusr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCrtim;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActual_pack_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPack_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTo_dep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConf_flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConf_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImput_flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImput_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSample_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSample_weg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_work_type;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DateTimePicker dteSentDate;
        private System.Windows.Forms.Label lblShowMsg1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton btnMutRec;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}