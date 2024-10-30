namespace cf_pad.Forms
{
    partial class frmPrdTransfer
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.rdbChecked = new System.Windows.Forms.RadioButton();
            this.rdbNotChecked = new System.Windows.Forms.RadioButton();
            this.btnQueryByTrans_id = new System.Windows.Forms.Button();
            this.txtRecId = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbReturn = new System.Windows.Forms.RadioButton();
            this.rdbDeliver = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.mktReceived_date = new System.Windows.Forms.MaskedTextBox();
            this.lblcon_date = new System.Windows.Forms.Label();
            this.txtTransfer_id = new System.Windows.Forms.TextBox();
            this.lbltrans_id_q = new System.Windows.Forms.Label();
            this.lblin_dept = new System.Windows.Forms.Label();
            this.dgvTransfer = new System.Windows.Forms.DataGridView();
            this.lbltrans_id = new System.Windows.Forms.Label();
            this.txtIn_dept = new System.Windows.Forms.TextBox();
            this.txtOut_dept = new System.Windows.Forms.TextBox();
            this.txtMo_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ColSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colmo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colgoods_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colgoods_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActual_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActual_weg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActual_pack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colweight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpackage_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colbatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltrans_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunit_code_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunit_code_weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colremark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colseq_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransfer)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtMo_id);
            this.splitContainer1.Panel1.Controls.Add(this.txtOut_dept);
            this.splitContainer1.Panel1.Controls.Add(this.txtIn_dept);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.btnQueryByTrans_id);
            this.splitContainer1.Panel1.Controls.Add(this.txtRecId);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            this.splitContainer1.Panel1.Controls.Add(this.btnExit);
            this.splitContainer1.Panel1.Controls.Add(this.btnQuery);
            this.splitContainer1.Panel1.Controls.Add(this.mktReceived_date);
            this.splitContainer1.Panel1.Controls.Add(this.lblcon_date);
            this.splitContainer1.Panel1.Controls.Add(this.txtTransfer_id);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lbltrans_id_q);
            this.splitContainer1.Panel1.Controls.Add(this.lblin_dept);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvTransfer);
            this.splitContainer1.Panel2.Controls.Add(this.lbltrans_id);
            this.splitContainer1.Size = new System.Drawing.Size(972, 728);
            this.splitContainer1.SplitterDistance = 207;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbAll);
            this.groupBox1.Controls.Add(this.rdbChecked);
            this.groupBox1.Controls.Add(this.rdbNotChecked);
            this.groupBox1.Location = new System.Drawing.Point(494, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 58);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdbAll.Location = new System.Drawing.Point(207, 24);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(74, 30);
            this.rdbAll.TabIndex = 2;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "全部";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // rdbChecked
            // 
            this.rdbChecked.AutoSize = true;
            this.rdbChecked.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdbChecked.Location = new System.Drawing.Point(107, 24);
            this.rdbChecked.Name = "rdbChecked";
            this.rdbChecked.Size = new System.Drawing.Size(96, 30);
            this.rdbChecked.TabIndex = 1;
            this.rdbChecked.TabStop = true;
            this.rdbChecked.Text = "已收貨";
            this.rdbChecked.UseVisualStyleBackColor = true;
            // 
            // rdbNotChecked
            // 
            this.rdbNotChecked.AutoSize = true;
            this.rdbNotChecked.Checked = true;
            this.rdbNotChecked.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdbNotChecked.Location = new System.Drawing.Point(7, 24);
            this.rdbNotChecked.Name = "rdbNotChecked";
            this.rdbNotChecked.Size = new System.Drawing.Size(96, 30);
            this.rdbNotChecked.TabIndex = 0;
            this.rdbNotChecked.TabStop = true;
            this.rdbNotChecked.Text = "未收貨";
            this.rdbNotChecked.UseVisualStyleBackColor = true;
            // 
            // btnQueryByTrans_id
            // 
            this.btnQueryByTrans_id.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnQueryByTrans_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQueryByTrans_id.Location = new System.Drawing.Point(372, 0);
            this.btnQueryByTrans_id.Name = "btnQueryByTrans_id";
            this.btnQueryByTrans_id.Size = new System.Drawing.Size(200, 64);
            this.btnQueryByTrans_id.TabIndex = 17;
            this.btnQueryByTrans_id.Text = "按單號查詢";
            this.btnQueryByTrans_id.UseVisualStyleBackColor = false;
            this.btnQueryByTrans_id.Click += new System.EventHandler(this.btnQueryByTrans_id_Click);
            // 
            // txtRecId
            // 
            this.txtRecId.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtRecId.Location = new System.Drawing.Point(122, 190);
            this.txtRecId.Name = "txtRecId";
            this.txtRecId.Size = new System.Drawing.Size(240, 47);
            this.txtRecId.TabIndex = 16;
            this.txtRecId.TextChanged += new System.EventHandler(this.txtRecId_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbReturn);
            this.groupBox2.Controls.Add(this.rdbDeliver);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(302, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 58);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "單據類別";
            // 
            // rdbReturn
            // 
            this.rdbReturn.AutoSize = true;
            this.rdbReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdbReturn.Location = new System.Drawing.Point(100, 20);
            this.rdbReturn.Name = "rdbReturn";
            this.rdbReturn.Size = new System.Drawing.Size(74, 30);
            this.rdbReturn.TabIndex = 1;
            this.rdbReturn.Text = "退貨";
            this.rdbReturn.UseVisualStyleBackColor = true;
            this.rdbReturn.Click += new System.EventHandler(this.rdbReturn_Click);
            // 
            // rdbDeliver
            // 
            this.rdbDeliver.AutoSize = true;
            this.rdbDeliver.Checked = true;
            this.rdbDeliver.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdbDeliver.Location = new System.Drawing.Point(9, 20);
            this.rdbDeliver.Name = "rdbDeliver";
            this.rdbDeliver.Size = new System.Drawing.Size(74, 30);
            this.rdbDeliver.TabIndex = 0;
            this.rdbDeliver.TabStop = true;
            this.rdbDeliver.Text = "發貨";
            this.rdbDeliver.UseVisualStyleBackColor = true;
            this.rdbDeliver.Click += new System.EventHandler(this.rdbDeliver_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 26);
            this.label1.TabIndex = 13;
            this.label1.Text = "發貨部門:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(574, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(179, 64);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "確認收貨";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Location = new System.Drawing.Point(7, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(179, 64);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.Lime;
            this.btnQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.ForeColor = System.Drawing.Color.Black;
            this.btnQuery.Location = new System.Drawing.Point(189, 0);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(179, 64);
            this.btnQuery.TabIndex = 3;
            this.btnQuery.Text = "查詢";
            this.btnQuery.UseVisualStyleBackColor = false;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // mktReceived_date
            // 
            this.mktReceived_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.mktReceived_date.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mktReceived_date.Location = new System.Drawing.Point(407, 133);
            this.mktReceived_date.Mask = "9999/99/99";
            this.mktReceived_date.Name = "mktReceived_date";
            this.mktReceived_date.PromptChar = ' ';
            this.mktReceived_date.Size = new System.Drawing.Size(271, 47);
            this.mktReceived_date.TabIndex = 1;
            this.mktReceived_date.ValidatingType = typeof(System.DateTime);
            // 
            // lblcon_date
            // 
            this.lblcon_date.AutoSize = true;
            this.lblcon_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblcon_date.Location = new System.Drawing.Point(297, 143);
            this.lblcon_date.Name = "lblcon_date";
            this.lblcon_date.Size = new System.Drawing.Size(106, 26);
            this.lblcon_date.TabIndex = 0;
            this.lblcon_date.Text = "收貨日期:";
            // 
            // txtTransfer_id
            // 
            this.txtTransfer_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtTransfer_id.Location = new System.Drawing.Point(368, 190);
            this.txtTransfer_id.Name = "txtTransfer_id";
            this.txtTransfer_id.Size = new System.Drawing.Size(333, 47);
            this.txtTransfer_id.TabIndex = 2;
            // 
            // lbltrans_id_q
            // 
            this.lbltrans_id_q.AutoSize = true;
            this.lbltrans_id_q.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbltrans_id_q.Location = new System.Drawing.Point(12, 203);
            this.lbltrans_id_q.Name = "lbltrans_id_q";
            this.lbltrans_id_q.Size = new System.Drawing.Size(106, 26);
            this.lbltrans_id_q.TabIndex = 0;
            this.lbltrans_id_q.Text = "移交單號:";
            // 
            // lblin_dept
            // 
            this.lblin_dept.AutoSize = true;
            this.lblin_dept.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblin_dept.Location = new System.Drawing.Point(12, 94);
            this.lblin_dept.Name = "lblin_dept";
            this.lblin_dept.Size = new System.Drawing.Size(106, 26);
            this.lblin_dept.TabIndex = 0;
            this.lblin_dept.Text = "收貨部門:";
            // 
            // dgvTransfer
            // 
            this.dgvTransfer.AllowUserToAddRows = false;
            this.dgvTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransfer.ColumnHeadersHeight = 60;
            this.dgvTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTransfer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSelect,
            this.colmo_id,
            this.colgoods_id,
            this.colgoods_desc,
            this.colActual_qty,
            this.colActual_weg,
            this.colActual_pack,
            this.colQty,
            this.colweight,
            this.colpackage_num,
            this.colbatch,
            this.coltrans_id,
            this.colunit_code_qty,
            this.colunit_code_weight,
            this.colremark,
            this.colseq_no});
            this.dgvTransfer.Location = new System.Drawing.Point(1, 3);
            this.dgvTransfer.Name = "dgvTransfer";
            this.dgvTransfer.RowHeadersWidth = 25;
            this.dgvTransfer.RowTemplate.Height = 80;
            this.dgvTransfer.Size = new System.Drawing.Size(970, 514);
            this.dgvTransfer.TabIndex = 13;
            this.dgvTransfer.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTransfer_RowPostPaint);
            // 
            // lbltrans_id
            // 
            this.lbltrans_id.AutoSize = true;
            this.lbltrans_id.Location = new System.Drawing.Point(111, 242);
            this.lbltrans_id.Name = "lbltrans_id";
            this.lbltrans_id.Size = new System.Drawing.Size(39, 12);
            this.lbltrans_id.TabIndex = 13;
            this.lbltrans_id.Text = "label10";
            this.lbltrans_id.Visible = false;
            // 
            // txtIn_dept
            // 
            this.txtIn_dept.Font = new System.Drawing.Font("新細明體", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtIn_dept.Location = new System.Drawing.Point(122, 79);
            this.txtIn_dept.Name = "txtIn_dept";
            this.txtIn_dept.Size = new System.Drawing.Size(161, 49);
            this.txtIn_dept.TabIndex = 19;
            this.txtIn_dept.TextChanged += new System.EventHandler(this.txtIn_dept_TextChanged);
            // 
            // txtOut_dept
            // 
            this.txtOut_dept.Font = new System.Drawing.Font("新細明體", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtOut_dept.Location = new System.Drawing.Point(122, 135);
            this.txtOut_dept.Name = "txtOut_dept";
            this.txtOut_dept.Size = new System.Drawing.Size(161, 49);
            this.txtOut_dept.TabIndex = 20;
            this.txtOut_dept.TextChanged += new System.EventHandler(this.txtOut_dept_TextChanged);
            // 
            // txtMo_id
            // 
            this.txtMo_id.Font = new System.Drawing.Font("新細明體", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMo_id.Location = new System.Drawing.Point(122, 243);
            this.txtMo_id.Name = "txtMo_id";
            this.txtMo_id.Size = new System.Drawing.Size(240, 49);
            this.txtMo_id.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "制單編號:";
            // 
            // ColSelect
            // 
            this.ColSelect.HeaderText = "選取";
            this.ColSelect.Name = "ColSelect";
            this.ColSelect.Width = 40;
            // 
            // colmo_id
            // 
            this.colmo_id.DataPropertyName = "mo_id";
            this.colmo_id.HeaderText = "制單編號";
            this.colmo_id.Name = "colmo_id";
            this.colmo_id.ReadOnly = true;
            this.colmo_id.Width = 120;
            // 
            // colgoods_id
            // 
            this.colgoods_id.DataPropertyName = "goods_id";
            this.colgoods_id.HeaderText = "物料編號";
            this.colgoods_id.Name = "colgoods_id";
            this.colgoods_id.ReadOnly = true;
            this.colgoods_id.Width = 220;
            // 
            // colgoods_desc
            // 
            this.colgoods_desc.DataPropertyName = "goods_desc";
            this.colgoods_desc.HeaderText = "物料描述";
            this.colgoods_desc.Name = "colgoods_desc";
            this.colgoods_desc.ReadOnly = true;
            this.colgoods_desc.Width = 200;
            // 
            // colActual_qty
            // 
            this.colActual_qty.DataPropertyName = "actual_qty";
            this.colActual_qty.HeaderText = "實際數量";
            this.colActual_qty.Name = "colActual_qty";
            // 
            // colActual_weg
            // 
            this.colActual_weg.DataPropertyName = "actual_weg";
            this.colActual_weg.HeaderText = "實際重量";
            this.colActual_weg.Name = "colActual_weg";
            // 
            // colActual_pack
            // 
            this.colActual_pack.DataPropertyName = "actual_pack";
            this.colActual_pack.HeaderText = "實際包數";
            this.colActual_pack.Name = "colActual_pack";
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "con_qty";
            this.colQty.HeaderText = "單據數量";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            this.colQty.Width = 80;
            // 
            // colweight
            // 
            this.colweight.DataPropertyName = "sec_qty";
            this.colweight.HeaderText = "單據重量";
            this.colweight.Name = "colweight";
            this.colweight.ReadOnly = true;
            this.colweight.Width = 80;
            // 
            // colpackage_num
            // 
            this.colpackage_num.DataPropertyName = "package_num";
            this.colpackage_num.HeaderText = "單據包數";
            this.colpackage_num.Name = "colpackage_num";
            this.colpackage_num.ReadOnly = true;
            this.colpackage_num.Width = 80;
            // 
            // colbatch
            // 
            this.colbatch.DataPropertyName = "lot_no";
            this.colbatch.HeaderText = "批號";
            this.colbatch.Name = "colbatch";
            this.colbatch.ReadOnly = true;
            this.colbatch.Width = 120;
            // 
            // coltrans_id
            // 
            this.coltrans_id.DataPropertyName = "id";
            this.coltrans_id.HeaderText = "移交單號";
            this.coltrans_id.Name = "coltrans_id";
            this.coltrans_id.ReadOnly = true;
            this.coltrans_id.Width = 180;
            // 
            // colunit_code_qty
            // 
            this.colunit_code_qty.DataPropertyName = "unit_code";
            this.colunit_code_qty.HeaderText = "數量單位";
            this.colunit_code_qty.Name = "colunit_code_qty";
            this.colunit_code_qty.ReadOnly = true;
            this.colunit_code_qty.Width = 60;
            // 
            // colunit_code_weight
            // 
            this.colunit_code_weight.DataPropertyName = "sec_unit";
            this.colunit_code_weight.HeaderText = "重量單位";
            this.colunit_code_weight.Name = "colunit_code_weight";
            this.colunit_code_weight.ReadOnly = true;
            this.colunit_code_weight.Width = 60;
            // 
            // colremark
            // 
            this.colremark.DataPropertyName = "remark";
            this.colremark.HeaderText = "備註";
            this.colremark.Name = "colremark";
            this.colremark.ReadOnly = true;
            this.colremark.Width = 200;
            // 
            // colseq_no
            // 
            this.colseq_no.DataPropertyName = "sequence_id";
            this.colseq_no.HeaderText = "序號";
            this.colseq_no.Name = "colseq_no";
            this.colseq_no.ReadOnly = true;
            // 
            // frmPrdTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(972, 728);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmPrdTransfer";
            this.Text = "frmPrdTransfer";
            this.Load += new System.EventHandler(this.frmPrdTransfer_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransfer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvTransfer;
        private System.Windows.Forms.Label lblin_dept;
        private System.Windows.Forms.Label lblcon_date;
        private System.Windows.Forms.TextBox txtTransfer_id;
        private System.Windows.Forms.Label lbltrans_id_q;
        private System.Windows.Forms.MaskedTextBox mktReceived_date;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbltrans_id;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbReturn;
        private System.Windows.Forms.RadioButton rdbDeliver;
        private System.Windows.Forms.TextBox txtRecId;
        private System.Windows.Forms.Button btnQueryByTrans_id;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.RadioButton rdbChecked;
        private System.Windows.Forms.RadioButton rdbNotChecked;
        private System.Windows.Forms.TextBox txtOut_dept;
        private System.Windows.Forms.TextBox txtIn_dept;
        private System.Windows.Forms.TextBox txtMo_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colgoods_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colgoods_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActual_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActual_weg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActual_pack;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colweight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpackage_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn colbatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltrans_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunit_code_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunit_code_weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colremark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colseq_no;
    }
}