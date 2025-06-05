namespace cf_pad.Forms
{
    partial class frmInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventory));
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
            this.btnPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExpToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblWeg = new System.Windows.Forms.Label();
            this.txtWeg = new System.Windows.Forms.TextBox();
            this.txtMo = new System.Windows.Forms.TextBox();
            this.lblMo = new System.Windows.Forms.Label();
            this.lblGoodsId = new System.Windows.Forms.Label();
            this.lblGoodsName = new System.Windows.Forms.Label();
            this.txtGoodsName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.txtMonth = new System.Windows.Forms.MaskedTextBox();
            this.cmbDep = new System.Windows.Forms.ComboBox();
            this.lblDept = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cmbGoodsId = new System.Windows.Forms.ComboBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblSeq = new System.Windows.Forms.Label();
            this.txtSeq = new System.Windows.Forms.TextBox();
            this.dgvInv = new System.Windows.Forms.DataGridView();
            this.colMoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoodsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoodsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStWeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrdGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocShe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tc1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLocShe = new System.Windows.Forms.Label();
            this.lblPackNum = new System.Windows.Forms.Label();
            this.txtPackNum = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvInvFind = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdFind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrdGroupFind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackNumFind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoodsType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocSheFind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtIdFind = new System.Windows.Forms.TextBox();
            this.txtMoFind = new System.Windows.Forms.TextBox();
            this.lblMoFind = new System.Windows.Forms.Label();
            this.lblIdFind = new System.Windows.Forms.Label();
            this.cmbShe = new System.Windows.Forms.ComboBox();
            this.cmbSheFind = new System.Windows.Forms.ComboBox();
            this.lblSheFind = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInv)).BeginInit();
            this.tc1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvFind)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBarCode
            // 
            this.txtBarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtBarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarCode.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBarCode.Location = new System.Drawing.Point(111, 40);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(422, 27);
            this.txtBarCode.TabIndex = 1;
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblBarcode.ForeColor = System.Drawing.Color.Red;
            this.lblBarcode.Location = new System.Drawing.Point(17, 44);
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
            this.btnPreview,
            this.toolStripSeparator6,
            this.btnPrint,
            this.toolStripSeparator7,
            this.btnExpToExcel,
            this.toolStripSeparator8});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(947, 38);
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
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
            // 
            // btnPreview
            // 
            this.btnPreview.AutoSize = false;
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(65, 35);
            this.btnPreview.Text = "預覽(&V)";
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSize = false;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(65, 35);
            this.btnPrint.Text = "列印(&P)";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 38);
            // 
            // btnExpToExcel
            // 
            this.btnExpToExcel.AutoSize = false;
            this.btnExpToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExpToExcel.Image")));
            this.btnExpToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExpToExcel.Name = "btnExpToExcel";
            this.btnExpToExcel.Size = new System.Drawing.Size(65, 35);
            this.btnExpToExcel.Text = "匯出(&E)";
            this.btnExpToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExpToExcel.Click += new System.EventHandler(this.btnExpToExcel_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 38);
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtQty.Location = new System.Drawing.Point(95, 143);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(156, 27);
            this.txtQty.TabIndex = 7;
            this.txtQty.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtQty_MouseDown);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblQty.ForeColor = System.Drawing.Color.Black;
            this.lblQty.Location = new System.Drawing.Point(49, 149);
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
            this.lblWeg.Location = new System.Drawing.Point(310, 149);
            this.lblWeg.Name = "lblWeg";
            this.lblWeg.Size = new System.Drawing.Size(44, 16);
            this.lblWeg.TabIndex = 8;
            this.lblWeg.Text = "重量:";
            // 
            // txtWeg
            // 
            this.txtWeg.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtWeg.Location = new System.Drawing.Point(361, 143);
            this.txtWeg.Name = "txtWeg";
            this.txtWeg.Size = new System.Drawing.Size(156, 27);
            this.txtWeg.TabIndex = 7;
            this.txtWeg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtWeg_MouseDown);
            // 
            // txtMo
            // 
            this.txtMo.BackColor = System.Drawing.Color.GhostWhite;
            this.txtMo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMo.Location = new System.Drawing.Point(95, 43);
            this.txtMo.MaxLength = 9;
            this.txtMo.Name = "txtMo";
            this.txtMo.Size = new System.Drawing.Size(231, 27);
            this.txtMo.TabIndex = 9;
            this.txtMo.Leave += new System.EventHandler(this.txtMo_Leave);
            // 
            // lblMo
            // 
            this.lblMo.AutoSize = true;
            this.lblMo.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblMo.ForeColor = System.Drawing.Color.Black;
            this.lblMo.Location = new System.Drawing.Point(17, 47);
            this.lblMo.Name = "lblMo";
            this.lblMo.Size = new System.Drawing.Size(76, 16);
            this.lblMo.TabIndex = 10;
            this.lblMo.Text = "制單編號:";
            // 
            // lblGoodsId
            // 
            this.lblGoodsId.AutoSize = true;
            this.lblGoodsId.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblGoodsId.ForeColor = System.Drawing.Color.Black;
            this.lblGoodsId.Location = new System.Drawing.Point(17, 80);
            this.lblGoodsId.Name = "lblGoodsId";
            this.lblGoodsId.Size = new System.Drawing.Size(76, 16);
            this.lblGoodsId.TabIndex = 10;
            this.lblGoodsId.Text = "物料編號:";
            // 
            // lblGoodsName
            // 
            this.lblGoodsName.AutoSize = true;
            this.lblGoodsName.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblGoodsName.ForeColor = System.Drawing.Color.Black;
            this.lblGoodsName.Location = new System.Drawing.Point(17, 113);
            this.lblGoodsName.Name = "lblGoodsName";
            this.lblGoodsName.Size = new System.Drawing.Size(76, 16);
            this.lblGoodsName.TabIndex = 10;
            this.lblGoodsName.Text = "物料描述:";
            // 
            // txtGoodsName
            // 
            this.txtGoodsName.BackColor = System.Drawing.Color.GhostWhite;
            this.txtGoodsName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGoodsName.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtGoodsName.Location = new System.Drawing.Point(95, 109);
            this.txtGoodsName.MaxLength = 9;
            this.txtGoodsName.Name = "txtGoodsName";
            this.txtGoodsName.Size = new System.Drawing.Size(422, 27);
            this.txtGoodsName.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbGroup);
            this.panel1.Controls.Add(this.lblGroup);
            this.panel1.Controls.Add(this.txtMonth);
            this.panel1.Controls.Add(this.cmbDep);
            this.panel1.Controls.Add(this.lblDept);
            this.panel1.Controls.Add(this.txtBarCode);
            this.panel1.Controls.Add(this.lblBarcode);
            this.panel1.Controls.Add(this.lblMonth);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 78);
            this.panel1.TabIndex = 11;
            // 
            // cmbGroup
            // 
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.DropDownWidth = 150;
            this.cmbGroup.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(437, 5);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(96, 27);
            this.cmbGroup.TabIndex = 14;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup.Location = new System.Drawing.Point(392, 12);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(44, 16);
            this.lblGroup.TabIndex = 15;
            this.lblGroup.Text = "組別:";
            // 
            // txtMonth
            // 
            this.txtMonth.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMonth.Location = new System.Drawing.Point(319, 7);
            this.txtMonth.Mask = "9999/99";
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(71, 27);
            this.txtMonth.TabIndex = 13;
            // 
            // cmbDep
            // 
            this.cmbDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDep.DropDownWidth = 150;
            this.cmbDep.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbDep.Location = new System.Drawing.Point(111, 7);
            this.cmbDep.Name = "cmbDep";
            this.cmbDep.Size = new System.Drawing.Size(122, 27);
            this.cmbDep.TabIndex = 12;
            this.cmbDep.Leave += new System.EventHandler(this.cmbDep_Leave);
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblDept.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDept.Location = new System.Drawing.Point(65, 14);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(44, 16);
            this.lblDept.TabIndex = 11;
            this.lblDept.Text = "部門:";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblMonth.ForeColor = System.Drawing.Color.Black;
            this.lblMonth.Location = new System.Drawing.Point(237, 14);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(76, 16);
            this.lblMonth.TabIndex = 10;
            this.lblMonth.Text = "盤點月份:";
            // 
            // cmbGoodsId
            // 
            this.cmbGoodsId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGoodsId.DropDownWidth = 150;
            this.cmbGoodsId.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbGoodsId.Location = new System.Drawing.Point(95, 76);
            this.cmbGoodsId.Name = "cmbGoodsId";
            this.cmbGoodsId.Size = new System.Drawing.Size(422, 27);
            this.cmbGoodsId.TabIndex = 12;
            this.cmbGoodsId.Leave += new System.EventHandler(this.cmbGoodsId_Leave);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblId.ForeColor = System.Drawing.Color.Black;
            this.lblId.Location = new System.Drawing.Point(17, 17);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(76, 16);
            this.lblId.TabIndex = 10;
            this.lblId.Text = "盤點單號:";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.GhostWhite;
            this.txtId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtId.Location = new System.Drawing.Point(95, 13);
            this.txtId.MaxLength = 20;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(422, 27);
            this.txtId.TabIndex = 9;
            // 
            // lblSeq
            // 
            this.lblSeq.AutoSize = true;
            this.lblSeq.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblSeq.ForeColor = System.Drawing.Color.Black;
            this.lblSeq.Location = new System.Drawing.Point(360, 47);
            this.lblSeq.Name = "lblSeq";
            this.lblSeq.Size = new System.Drawing.Size(44, 16);
            this.lblSeq.TabIndex = 10;
            this.lblSeq.Text = "序號:";
            // 
            // txtSeq
            // 
            this.txtSeq.BackColor = System.Drawing.Color.GhostWhite;
            this.txtSeq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSeq.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSeq.Location = new System.Drawing.Point(411, 43);
            this.txtSeq.MaxLength = 20;
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.ReadOnly = true;
            this.txtSeq.Size = new System.Drawing.Size(106, 27);
            this.txtSeq.TabIndex = 9;
            this.txtSeq.Leave += new System.EventHandler(this.txtMo_Leave);
            // 
            // dgvInv
            // 
            this.dgvInv.AllowUserToAddRows = false;
            this.dgvInv.ColumnHeadersHeight = 30;
            this.dgvInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMoId,
            this.colGoodsId,
            this.colGoodsName,
            this.colStQty,
            this.colStWeg,
            this.colId,
            this.colStMonth,
            this.colSeq,
            this.colLocId,
            this.colPrdGroup,
            this.colPackNum,
            this.colLocShe,
            this.colUpdateUser,
            this.colUpdateTime});
            this.dgvInv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInv.Location = new System.Drawing.Point(3, 224);
            this.dgvInv.Name = "dgvInv";
            this.dgvInv.ReadOnly = true;
            this.dgvInv.RowHeadersWidth = 35;
            this.dgvInv.RowTemplate.Height = 30;
            this.dgvInv.Size = new System.Drawing.Size(933, 152);
            this.dgvInv.TabIndex = 12;
            this.dgvInv.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvInv_RowPostPaint);
            this.dgvInv.SelectionChanged += new System.EventHandler(this.dgvInv_SelectionChanged);
            // 
            // colMoId
            // 
            this.colMoId.DataPropertyName = "mo_id";
            this.colMoId.HeaderText = "制單編號";
            this.colMoId.Name = "colMoId";
            this.colMoId.ReadOnly = true;
            // 
            // colGoodsId
            // 
            this.colGoodsId.DataPropertyName = "goods_id";
            this.colGoodsId.HeaderText = "物料編號";
            this.colGoodsId.Name = "colGoodsId";
            this.colGoodsId.ReadOnly = true;
            this.colGoodsId.Width = 160;
            // 
            // colGoodsName
            // 
            this.colGoodsName.DataPropertyName = "goods_name";
            this.colGoodsName.HeaderText = "物料描述";
            this.colGoodsName.Name = "colGoodsName";
            this.colGoodsName.ReadOnly = true;
            this.colGoodsName.Width = 200;
            // 
            // colStQty
            // 
            this.colStQty.DataPropertyName = "st_qty";
            this.colStQty.HeaderText = "盤點數量";
            this.colStQty.Name = "colStQty";
            this.colStQty.ReadOnly = true;
            // 
            // colStWeg
            // 
            this.colStWeg.DataPropertyName = "st_weg";
            this.colStWeg.HeaderText = "盤點重量";
            this.colStWeg.Name = "colStWeg";
            this.colStWeg.ReadOnly = true;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "id";
            this.colId.HeaderText = "盤點單號";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 120;
            // 
            // colStMonth
            // 
            this.colStMonth.DataPropertyName = "st_month";
            this.colStMonth.HeaderText = "盤點月份";
            this.colStMonth.Name = "colStMonth";
            this.colStMonth.ReadOnly = true;
            this.colStMonth.Width = 80;
            // 
            // colSeq
            // 
            this.colSeq.DataPropertyName = "seq";
            this.colSeq.HeaderText = "序號";
            this.colSeq.Name = "colSeq";
            this.colSeq.ReadOnly = true;
            this.colSeq.Width = 80;
            // 
            // colLocId
            // 
            this.colLocId.DataPropertyName = "loc_id";
            this.colLocId.HeaderText = "盤點部門";
            this.colLocId.Name = "colLocId";
            this.colLocId.ReadOnly = true;
            this.colLocId.Width = 80;
            // 
            // colPrdGroup
            // 
            this.colPrdGroup.DataPropertyName = "prd_group";
            this.colPrdGroup.HeaderText = "組別";
            this.colPrdGroup.Name = "colPrdGroup";
            this.colPrdGroup.ReadOnly = true;
            this.colPrdGroup.Width = 60;
            // 
            // colPackNum
            // 
            this.colPackNum.DataPropertyName = "pack_num";
            this.colPackNum.HeaderText = "包數";
            this.colPackNum.Name = "colPackNum";
            this.colPackNum.ReadOnly = true;
            this.colPackNum.Width = 60;
            // 
            // colLocShe
            // 
            this.colLocShe.DataPropertyName = "loc_she";
            this.colLocShe.HeaderText = "貨架";
            this.colLocShe.Name = "colLocShe";
            this.colLocShe.ReadOnly = true;
            this.colLocShe.Width = 60;
            // 
            // colUpdateUser
            // 
            this.colUpdateUser.DataPropertyName = "update_user";
            this.colUpdateUser.HeaderText = "建立人";
            this.colUpdateUser.Name = "colUpdateUser";
            this.colUpdateUser.ReadOnly = true;
            // 
            // colUpdateTime
            // 
            this.colUpdateTime.DataPropertyName = "update_time";
            this.colUpdateTime.HeaderText = "建立時間";
            this.colUpdateTime.Name = "colUpdateTime";
            this.colUpdateTime.ReadOnly = true;
            this.colUpdateTime.Width = 120;
            // 
            // tc1
            // 
            this.tc1.Controls.Add(this.tabPage1);
            this.tc1.Controls.Add(this.tabPage2);
            this.tc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc1.ItemSize = new System.Drawing.Size(60, 32);
            this.tc1.Location = new System.Drawing.Point(0, 116);
            this.tc1.Name = "tc1";
            this.tc1.SelectedIndex = 0;
            this.tc1.Size = new System.Drawing.Size(947, 419);
            this.tc1.TabIndex = 14;
            this.tc1.Click += new System.EventHandler(this.tc1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvInv);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 36);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(939, 379);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "記錄編輯";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbShe);
            this.panel2.Controls.Add(this.txtId);
            this.panel2.Controls.Add(this.txtQty);
            this.panel2.Controls.Add(this.cmbGoodsId);
            this.panel2.Controls.Add(this.lblGoodsId);
            this.panel2.Controls.Add(this.lblMo);
            this.panel2.Controls.Add(this.lblQty);
            this.panel2.Controls.Add(this.lblLocShe);
            this.panel2.Controls.Add(this.lblPackNum);
            this.panel2.Controls.Add(this.lblWeg);
            this.panel2.Controls.Add(this.txtPackNum);
            this.panel2.Controls.Add(this.txtWeg);
            this.panel2.Controls.Add(this.lblGoodsName);
            this.panel2.Controls.Add(this.lblId);
            this.panel2.Controls.Add(this.txtSeq);
            this.panel2.Controls.Add(this.lblSeq);
            this.panel2.Controls.Add(this.txtMo);
            this.panel2.Controls.Add(this.txtGoodsName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(933, 221);
            this.panel2.TabIndex = 13;
            // 
            // lblLocShe
            // 
            this.lblLocShe.AutoSize = true;
            this.lblLocShe.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblLocShe.ForeColor = System.Drawing.Color.Black;
            this.lblLocShe.Location = new System.Drawing.Point(310, 181);
            this.lblLocShe.Name = "lblLocShe";
            this.lblLocShe.Size = new System.Drawing.Size(44, 16);
            this.lblLocShe.TabIndex = 8;
            this.lblLocShe.Text = "貨架:";
            // 
            // lblPackNum
            // 
            this.lblPackNum.AutoSize = true;
            this.lblPackNum.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblPackNum.ForeColor = System.Drawing.Color.Black;
            this.lblPackNum.Location = new System.Drawing.Point(44, 181);
            this.lblPackNum.Name = "lblPackNum";
            this.lblPackNum.Size = new System.Drawing.Size(44, 16);
            this.lblPackNum.TabIndex = 8;
            this.lblPackNum.Text = "包數:";
            // 
            // txtPackNum
            // 
            this.txtPackNum.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPackNum.Location = new System.Drawing.Point(95, 176);
            this.txtPackNum.Name = "txtPackNum";
            this.txtPackNum.Size = new System.Drawing.Size(156, 27);
            this.txtPackNum.TabIndex = 7;
            this.txtPackNum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtWeg_MouseDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvInvFind);
            this.tabPage2.Controls.Add(this.reportViewer1);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 36);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(939, 379);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "記錄查詢";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvInvFind
            // 
            this.dgvInvFind.AllowUserToAddRows = false;
            this.dgvInvFind.ColumnHeadersHeight = 30;
            this.dgvInvFind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInvFind.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.colIdFind,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.colPrdGroupFind,
            this.colPackNumFind,
            this.colGoodsType,
            this.colLocSheFind,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            this.dgvInvFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvFind.Location = new System.Drawing.Point(3, 45);
            this.dgvInvFind.Name = "dgvInvFind";
            this.dgvInvFind.ReadOnly = true;
            this.dgvInvFind.RowHeadersWidth = 35;
            this.dgvInvFind.RowTemplate.Height = 30;
            this.dgvInvFind.Size = new System.Drawing.Size(933, 331);
            this.dgvInvFind.TabIndex = 18;
            this.dgvInvFind.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvInvFind_RowPostPaint);
            this.dgvInvFind.SelectionChanged += new System.EventHandler(this.dgvInvFind_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "mo_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "制單編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "goods_id";
            this.dataGridViewTextBoxColumn2.HeaderText = "物料編號";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 160;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "goods_name";
            this.dataGridViewTextBoxColumn3.HeaderText = "物料描述";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "st_qty";
            this.dataGridViewTextBoxColumn4.HeaderText = "盤點數量";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "st_weg";
            this.dataGridViewTextBoxColumn5.HeaderText = "盤點重量";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // colIdFind
            // 
            this.colIdFind.DataPropertyName = "id";
            this.colIdFind.HeaderText = "盤點單號";
            this.colIdFind.Name = "colIdFind";
            this.colIdFind.ReadOnly = true;
            this.colIdFind.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "st_month";
            this.dataGridViewTextBoxColumn7.HeaderText = "盤點月份";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "seq";
            this.dataGridViewTextBoxColumn8.HeaderText = "序號";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "loc_id";
            this.dataGridViewTextBoxColumn9.HeaderText = "盤點部門";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // colPrdGroupFind
            // 
            this.colPrdGroupFind.DataPropertyName = "prd_group";
            this.colPrdGroupFind.HeaderText = "組別";
            this.colPrdGroupFind.Name = "colPrdGroupFind";
            this.colPrdGroupFind.ReadOnly = true;
            this.colPrdGroupFind.Width = 60;
            // 
            // colPackNumFind
            // 
            this.colPackNumFind.DataPropertyName = "pack_num";
            this.colPackNumFind.HeaderText = "包數";
            this.colPackNumFind.Name = "colPackNumFind";
            this.colPackNumFind.ReadOnly = true;
            this.colPackNumFind.Width = 60;
            // 
            // colGoodsType
            // 
            this.colGoodsType.DataPropertyName = "goods_type";
            this.colGoodsType.HeaderText = "顏色分類";
            this.colGoodsType.Name = "colGoodsType";
            this.colGoodsType.ReadOnly = true;
            this.colGoodsType.Width = 60;
            // 
            // colLocSheFind
            // 
            this.colLocSheFind.DataPropertyName = "loc_she";
            this.colLocSheFind.HeaderText = "貨架";
            this.colLocSheFind.Name = "colLocSheFind";
            this.colLocSheFind.ReadOnly = true;
            this.colLocSheFind.Width = 60;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "update_user";
            this.dataGridViewTextBoxColumn10.HeaderText = "建立人";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "update_time";
            this.dataGridViewTextBoxColumn11.HeaderText = "建立時間";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 120;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(3, 45);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(933, 331);
            this.reportViewer1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmbSheFind);
            this.panel3.Controls.Add(this.lblSheFind);
            this.panel3.Controls.Add(this.txtIdFind);
            this.panel3.Controls.Add(this.txtMoFind);
            this.panel3.Controls.Add(this.lblMoFind);
            this.panel3.Controls.Add(this.lblIdFind);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(933, 42);
            this.panel3.TabIndex = 17;
            // 
            // txtIdFind
            // 
            this.txtIdFind.BackColor = System.Drawing.Color.GhostWhite;
            this.txtIdFind.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdFind.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtIdFind.Location = new System.Drawing.Point(357, 9);
            this.txtIdFind.MaxLength = 20;
            this.txtIdFind.Name = "txtIdFind";
            this.txtIdFind.Size = new System.Drawing.Size(231, 27);
            this.txtIdFind.TabIndex = 13;
            // 
            // txtMoFind
            // 
            this.txtMoFind.BackColor = System.Drawing.Color.GhostWhite;
            this.txtMoFind.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMoFind.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMoFind.Location = new System.Drawing.Point(104, 9);
            this.txtMoFind.MaxLength = 9;
            this.txtMoFind.Name = "txtMoFind";
            this.txtMoFind.Size = new System.Drawing.Size(169, 27);
            this.txtMoFind.TabIndex = 14;
            // 
            // lblMoFind
            // 
            this.lblMoFind.AutoSize = true;
            this.lblMoFind.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblMoFind.ForeColor = System.Drawing.Color.Black;
            this.lblMoFind.Location = new System.Drawing.Point(26, 13);
            this.lblMoFind.Name = "lblMoFind";
            this.lblMoFind.Size = new System.Drawing.Size(76, 16);
            this.lblMoFind.TabIndex = 15;
            this.lblMoFind.Text = "制單編號:";
            // 
            // lblIdFind
            // 
            this.lblIdFind.AutoSize = true;
            this.lblIdFind.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblIdFind.ForeColor = System.Drawing.Color.Black;
            this.lblIdFind.Location = new System.Drawing.Point(279, 12);
            this.lblIdFind.Name = "lblIdFind";
            this.lblIdFind.Size = new System.Drawing.Size(76, 16);
            this.lblIdFind.TabIndex = 16;
            this.lblIdFind.Text = "盤點單號:";
            // 
            // cmbShe
            // 
            this.cmbShe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShe.DropDownWidth = 150;
            this.cmbShe.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbShe.FormattingEnabled = true;
            this.cmbShe.Location = new System.Drawing.Point(361, 176);
            this.cmbShe.Name = "cmbShe";
            this.cmbShe.Size = new System.Drawing.Size(156, 27);
            this.cmbShe.TabIndex = 14;
            this.cmbShe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbShe_MouseDown);
            // 
            // cmbSheFind
            // 
            this.cmbSheFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSheFind.DropDownWidth = 150;
            this.cmbSheFind.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbSheFind.FormattingEnabled = true;
            this.cmbSheFind.Location = new System.Drawing.Point(649, 9);
            this.cmbSheFind.Name = "cmbSheFind";
            this.cmbSheFind.Size = new System.Drawing.Size(156, 27);
            this.cmbSheFind.TabIndex = 18;
            // 
            // lblSheFind
            // 
            this.lblSheFind.AutoSize = true;
            this.lblSheFind.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblSheFind.ForeColor = System.Drawing.Color.Black;
            this.lblSheFind.Location = new System.Drawing.Point(598, 13);
            this.lblSheFind.Name = "lblSheFind";
            this.lblSheFind.Size = new System.Drawing.Size(44, 16);
            this.lblSheFind.TabIndex = 17;
            this.lblSheFind.Text = "貨架:";
            // 
            // frmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 535);
            this.Controls.Add(this.tc1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPackingMoRecords";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInventory_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInv)).EndInit();
            this.tc1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvFind)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label lblGoodsId;
        private System.Windows.Forms.Label lblGoodsName;
        private System.Windows.Forms.TextBox txtGoodsName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbDep;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.MaskedTextBox txtMonth;
        private System.Windows.Forms.ComboBox cmbGoodsId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtSeq;
        private System.Windows.Forms.Label lblSeq;
        private System.Windows.Forms.DataGridView dgvInv;
        private System.Windows.Forms.TabControl tc1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtIdFind;
        private System.Windows.Forms.Label lblMoFind;
        private System.Windows.Forms.Label lblIdFind;
        private System.Windows.Forms.TextBox txtMoFind;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvInvFind;
        private System.Windows.Forms.Panel panel3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ToolStripButton btnPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblPackNum;
        private System.Windows.Forms.TextBox txtPackNum;
        private System.Windows.Forms.ToolStripButton btnExpToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.Label lblLocShe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoodsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStWeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrdGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocShe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdateUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrdGroupFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackNumFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoodsType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocSheFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.ComboBox cmbShe;
        private System.Windows.Forms.ComboBox cmbSheFind;
        private System.Windows.Forms.Label lblSheFind;
    }
}