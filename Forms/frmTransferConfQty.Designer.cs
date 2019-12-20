namespace cf_pad.Forms
{
    partial class frmTransferConfQty
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnIsConf = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnConfigMo = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.rdbById = new System.Windows.Forms.RadioButton();
            this.rdbByMo = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtGoods_id = new System.Windows.Forms.TextBox();
            this.txtAdjWeg = new System.Windows.Forms.TextBox();
            this.txtSumWeg = new System.Windows.Forms.TextBox();
            this.txtSumQty = new System.Windows.Forms.TextBox();
            this.lblId_state = new System.Windows.Forms.Label();
            this.btnGetQty = new System.Windows.Forms.Button();
            this.txtActual_pack = new System.Windows.Forms.TextBox();
            this.lblActual_pack = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdbNoConfQty = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtIn_dept = new System.Windows.Forms.TextBox();
            this.txtOut_dept = new System.Windows.Forms.TextBox();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.lblIn_dep = new System.Windows.Forms.Label();
            this.lblOut_dep = new System.Windows.Forms.Label();
            this.txtImput_flag = new System.Windows.Forms.TextBox();
            this.txtImput_time = new System.Windows.Forms.TextBox();
            this.lblGoods_name = new System.Windows.Forms.Label();
            this.lblCrusr = new System.Windows.Forms.Label();
            this.txtCon_date = new System.Windows.Forms.MaskedTextBox();
            this.lblCon_date = new System.Windows.Forms.Label();
            this.txtTransfer_id = new System.Windows.Forms.TextBox();
            this.txtId_state = new System.Windows.Forms.TextBox();
            this.txtSeq_id = new System.Windows.Forms.TextBox();
            this.lblTransfer_id = new System.Windows.Forms.Label();
            this.lblSeq_id = new System.Windows.Forms.Label();
            this.txtCrtim = new System.Windows.Forms.TextBox();
            this.txtCrusr = new System.Windows.Forms.TextBox();
            this.txtLot_no = new System.Windows.Forms.TextBox();
            this.lblLot_no = new System.Windows.Forms.Label();
            this.txtMo_id = new System.Windows.Forms.TextBox();
            this.lblMo_id = new System.Windows.Forms.Label();
            this.txtCountWeg = new System.Windows.Forms.TextBox();
            this.txtCountQty = new System.Windows.Forms.TextBox();
            this.txtSample_weg = new System.Windows.Forms.TextBox();
            this.lblCountQty = new System.Windows.Forms.Label();
            this.lblSumWeg = new System.Windows.Forms.Label();
            this.lblSumQty = new System.Windows.Forms.Label();
            this.lblSample_weg = new System.Windows.Forms.Label();
            this.txtSample_no = new System.Windows.Forms.TextBox();
            this.lblCountWeg = new System.Windows.Forms.Label();
            this.lblSample_num = new System.Windows.Forms.Label();
            this.txtActual_weg = new System.Windows.Forms.TextBox();
            this.lblActual_weg = new System.Windows.Forms.Label();
            this.txtActual_qty = new System.Windows.Forms.TextBox();
            this.lblActual_qty = new System.Windows.Forms.Label();
            this.txtGoods_name = new System.Windows.Forms.TextBox();
            this.txtAdjQty = new System.Windows.Forms.TextBox();
            this.lblAdjWeg = new System.Windows.Forms.Label();
            this.lblAbjQty = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gvDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.checkbox = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.Merge_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Mo_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Goods_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Actual_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Actual_weg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Sequence_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Conf_flag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Con_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Sec_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Goods_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Con_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Rec_state = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lot_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.In_dept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Out_dept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Check_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Rec_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Crusr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Crtim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Imput_flag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Imput_time = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Package_num = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Check_state = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Stock_type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Actual_pack_num = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Sample_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Sample_weg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Complete_state = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.btnIsConf);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnConfigMo);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 76);
            this.panel1.TabIndex = 1;
            // 
            // btnIsConf
            // 
            this.btnIsConf.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnIsConf.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnIsConf.Location = new System.Drawing.Point(649, 3);
            this.btnIsConf.Name = "btnIsConf";
            this.btnIsConf.Size = new System.Drawing.Size(160, 70);
            this.btnIsConf.TabIndex = 7;
            this.btnIsConf.Text = "已圍數";
            this.btnIsConf.UseVisualStyleBackColor = false;
            this.btnIsConf.Click += new System.EventHandler(this.btnIsConf_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnFind.Location = new System.Drawing.Point(165, 3);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(160, 70);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "      查詢        (未圍數)";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.Yellow;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDel.Location = new System.Drawing.Point(488, 3);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(160, 70);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "取消圍數";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnConfigMo
            // 
            this.btnConfigMo.BackColor = System.Drawing.Color.SpringGreen;
            this.btnConfigMo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnConfigMo.Location = new System.Drawing.Point(327, 3);
            this.btnConfigMo.Name = "btnConfigMo";
            this.btnConfigMo.Size = new System.Drawing.Size(160, 70);
            this.btnConfigMo.TabIndex = 4;
            this.btnConfigMo.Text = "確認(&C)";
            this.btnConfigMo.UseVisualStyleBackColor = false;
            this.btnConfigMo.Click += new System.EventHandler(this.btnConfigMo_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Location = new System.Drawing.Point(5, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(160, 70);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // rdbById
            // 
            this.rdbById.AutoSize = true;
            this.rdbById.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdbById.Location = new System.Drawing.Point(112, 8);
            this.rdbById.Name = "rdbById";
            this.rdbById.Size = new System.Drawing.Size(118, 30);
            this.rdbById.TabIndex = 1;
            this.rdbById.TabStop = true;
            this.rdbById.Text = "按移交單";
            this.rdbById.UseVisualStyleBackColor = true;
            this.rdbById.Click += new System.EventHandler(this.rdbById_Click);
            // 
            // rdbByMo
            // 
            this.rdbByMo.AutoSize = true;
            this.rdbByMo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdbByMo.Location = new System.Drawing.Point(11, 8);
            this.rdbByMo.Name = "rdbByMo";
            this.rdbByMo.Size = new System.Drawing.Size(96, 30);
            this.rdbByMo.TabIndex = 0;
            this.rdbByMo.Text = "按制單";
            this.rdbByMo.UseVisualStyleBackColor = true;
            this.rdbByMo.Click += new System.EventHandler(this.rdbByMo_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 76);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtGoods_id);
            this.splitContainer1.Panel1.Controls.Add(this.txtAdjWeg);
            this.splitContainer1.Panel1.Controls.Add(this.txtSumWeg);
            this.splitContainer1.Panel1.Controls.Add(this.txtSumQty);
            this.splitContainer1.Panel1.Controls.Add(this.lblId_state);
            this.splitContainer1.Panel1.Controls.Add(this.btnGetQty);
            this.splitContainer1.Panel1.Controls.Add(this.txtActual_pack);
            this.splitContainer1.Panel1.Controls.Add(this.lblActual_pack);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.txtImput_flag);
            this.splitContainer1.Panel1.Controls.Add(this.txtImput_time);
            this.splitContainer1.Panel1.Controls.Add(this.lblGoods_name);
            this.splitContainer1.Panel1.Controls.Add(this.lblCrusr);
            this.splitContainer1.Panel1.Controls.Add(this.txtCon_date);
            this.splitContainer1.Panel1.Controls.Add(this.lblCon_date);
            this.splitContainer1.Panel1.Controls.Add(this.txtTransfer_id);
            this.splitContainer1.Panel1.Controls.Add(this.txtId_state);
            this.splitContainer1.Panel1.Controls.Add(this.txtSeq_id);
            this.splitContainer1.Panel1.Controls.Add(this.lblTransfer_id);
            this.splitContainer1.Panel1.Controls.Add(this.lblSeq_id);
            this.splitContainer1.Panel1.Controls.Add(this.txtCrtim);
            this.splitContainer1.Panel1.Controls.Add(this.txtCrusr);
            this.splitContainer1.Panel1.Controls.Add(this.txtLot_no);
            this.splitContainer1.Panel1.Controls.Add(this.lblLot_no);
            this.splitContainer1.Panel1.Controls.Add(this.txtMo_id);
            this.splitContainer1.Panel1.Controls.Add(this.lblMo_id);
            this.splitContainer1.Panel1.Controls.Add(this.txtCountWeg);
            this.splitContainer1.Panel1.Controls.Add(this.txtCountQty);
            this.splitContainer1.Panel1.Controls.Add(this.txtSample_weg);
            this.splitContainer1.Panel1.Controls.Add(this.lblCountQty);
            this.splitContainer1.Panel1.Controls.Add(this.lblSumWeg);
            this.splitContainer1.Panel1.Controls.Add(this.lblSumQty);
            this.splitContainer1.Panel1.Controls.Add(this.lblSample_weg);
            this.splitContainer1.Panel1.Controls.Add(this.txtSample_no);
            this.splitContainer1.Panel1.Controls.Add(this.lblCountWeg);
            this.splitContainer1.Panel1.Controls.Add(this.lblSample_num);
            this.splitContainer1.Panel1.Controls.Add(this.txtActual_weg);
            this.splitContainer1.Panel1.Controls.Add(this.lblActual_weg);
            this.splitContainer1.Panel1.Controls.Add(this.txtActual_qty);
            this.splitContainer1.Panel1.Controls.Add(this.lblActual_qty);
            this.splitContainer1.Panel1.Controls.Add(this.txtGoods_name);
            this.splitContainer1.Panel1.Controls.Add(this.txtAdjQty);
            this.splitContainer1.Panel1.Controls.Add(this.lblAdjWeg);
            this.splitContainer1.Panel1.Controls.Add(this.lblAbjQty);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1184, 650);
            this.splitContainer1.SplitterDistance = 287;
            this.splitContainer1.TabIndex = 1;
            // 
            // txtGoods_id
            // 
            this.txtGoods_id.Location = new System.Drawing.Point(319, 182);
            this.txtGoods_id.Name = "txtGoods_id";
            this.txtGoods_id.Size = new System.Drawing.Size(314, 38);
            this.txtGoods_id.TabIndex = 26;
            // 
            // txtAdjWeg
            // 
            this.txtAdjWeg.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtAdjWeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtAdjWeg.Location = new System.Drawing.Point(423, 395);
            this.txtAdjWeg.Name = "txtAdjWeg";
            this.txtAdjWeg.ReadOnly = true;
            this.txtAdjWeg.Size = new System.Drawing.Size(146, 47);
            this.txtAdjWeg.TabIndex = 25;
            // 
            // txtSumWeg
            // 
            this.txtSumWeg.BackColor = System.Drawing.Color.Orange;
            this.txtSumWeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSumWeg.Location = new System.Drawing.Point(142, 233);
            this.txtSumWeg.Name = "txtSumWeg";
            this.txtSumWeg.ReadOnly = true;
            this.txtSumWeg.Size = new System.Drawing.Size(146, 47);
            this.txtSumWeg.TabIndex = 24;
            this.txtSumWeg.TextChanged += new System.EventHandler(this.txtSumWeg_TextChanged);
            // 
            // txtSumQty
            // 
            this.txtSumQty.BackColor = System.Drawing.Color.Orange;
            this.txtSumQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSumQty.Location = new System.Drawing.Point(142, 342);
            this.txtSumQty.Name = "txtSumQty";
            this.txtSumQty.ReadOnly = true;
            this.txtSumQty.Size = new System.Drawing.Size(148, 47);
            this.txtSumQty.TabIndex = 24;
            // 
            // lblId_state
            // 
            this.lblId_state.AutoSize = true;
            this.lblId_state.BackColor = System.Drawing.SystemColors.Control;
            this.lblId_state.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblId_state.ForeColor = System.Drawing.Color.Black;
            this.lblId_state.Location = new System.Drawing.Point(585, 242);
            this.lblId_state.Name = "lblId_state";
            this.lblId_state.Size = new System.Drawing.Size(194, 26);
            this.lblId_state.TabIndex = 23;
            this.lblId_state.Text = "移交單已完成收貨:";
            // 
            // btnGetQty
            // 
            this.btnGetQty.BackColor = System.Drawing.Color.Cyan;
            this.btnGetQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnGetQty.Location = new System.Drawing.Point(594, 445);
            this.btnGetQty.Name = "btnGetQty";
            this.btnGetQty.Size = new System.Drawing.Size(140, 50);
            this.btnGetQty.TabIndex = 22;
            this.btnGetQty.Text = "取校正數量";
            this.btnGetQty.UseVisualStyleBackColor = false;
            this.btnGetQty.Click += new System.EventHandler(this.btnGetQty_Click);
            // 
            // txtActual_pack
            // 
            this.txtActual_pack.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtActual_pack.Location = new System.Drawing.Point(954, 187);
            this.txtActual_pack.Name = "txtActual_pack";
            this.txtActual_pack.Size = new System.Drawing.Size(59, 47);
            this.txtActual_pack.TabIndex = 1;
            this.txtActual_pack.Visible = false;
            this.txtActual_pack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtActual_pack_MouseDown);
            // 
            // lblActual_pack
            // 
            this.lblActual_pack.AutoSize = true;
            this.lblActual_pack.Location = new System.Drawing.Point(797, 196);
            this.lblActual_pack.Name = "lblActual_pack";
            this.lblActual_pack.Size = new System.Drawing.Size(130, 31);
            this.lblActual_pack.TabIndex = 0;
            this.lblActual_pack.Text = "實際包數:";
            this.lblActual_pack.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.rdbNoConfQty);
            this.panel3.Controls.Add(this.rdbById);
            this.panel3.Controls.Add(this.rdbByMo);
            this.panel3.Location = new System.Drawing.Point(402, 125);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(388, 49);
            this.panel3.TabIndex = 21;
            // 
            // rdbNoConfQty
            // 
            this.rdbNoConfQty.AutoSize = true;
            this.rdbNoConfQty.Checked = true;
            this.rdbNoConfQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdbNoConfQty.Location = new System.Drawing.Point(234, 8);
            this.rdbNoConfQty.Name = "rdbNoConfQty";
            this.rdbNoConfQty.Size = new System.Drawing.Size(96, 30);
            this.rdbNoConfQty.TabIndex = 2;
            this.rdbNoConfQty.TabStop = true;
            this.rdbNoConfQty.Text = "未圍數";
            this.rdbNoConfQty.UseVisualStyleBackColor = true;
            this.rdbNoConfQty.Click += new System.EventHandler(this.rdbNoConfQty_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.txtIn_dept);
            this.panel2.Controls.Add(this.txtOut_dept);
            this.panel2.Controls.Add(this.txtBarCode);
            this.panel2.Controls.Add(this.lblIn_dep);
            this.panel2.Controls.Add(this.lblOut_dep);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1178, 60);
            this.panel2.TabIndex = 0;
            // 
            // txtIn_dept
            // 
            this.txtIn_dept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIn_dept.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtIn_dept.Location = new System.Drawing.Point(389, 5);
            this.txtIn_dept.Name = "txtIn_dept";
            this.txtIn_dept.Size = new System.Drawing.Size(204, 47);
            this.txtIn_dept.TabIndex = 1;
            this.txtIn_dept.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtIn_dept_MouseDown);
            // 
            // txtOut_dept
            // 
            this.txtOut_dept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOut_dept.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtOut_dept.Location = new System.Drawing.Point(654, 5);
            this.txtOut_dept.Name = "txtOut_dept";
            this.txtOut_dept.Size = new System.Drawing.Size(133, 47);
            this.txtOut_dept.TabIndex = 1;
            this.txtOut_dept.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtOut_dept_MouseDown);
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(14, 10);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(320, 38);
            this.txtBarCode.TabIndex = 0;
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
            // 
            // lblIn_dep
            // 
            this.lblIn_dep.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblIn_dep.Location = new System.Drawing.Point(337, 6);
            this.lblIn_dep.Name = "lblIn_dep";
            this.lblIn_dep.Size = new System.Drawing.Size(58, 52);
            this.lblIn_dep.TabIndex = 0;
            this.lblIn_dep.Text = "收貨部門";
            // 
            // lblOut_dep
            // 
            this.lblOut_dep.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblOut_dep.Location = new System.Drawing.Point(599, 6);
            this.lblOut_dep.Name = "lblOut_dep";
            this.lblOut_dep.Size = new System.Drawing.Size(58, 52);
            this.lblOut_dep.TabIndex = 0;
            this.lblOut_dep.Text = "發貨部門";
            // 
            // txtImput_flag
            // 
            this.txtImput_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtImput_flag.Location = new System.Drawing.Point(589, 511);
            this.txtImput_flag.Name = "txtImput_flag";
            this.txtImput_flag.ReadOnly = true;
            this.txtImput_flag.Size = new System.Drawing.Size(53, 47);
            this.txtImput_flag.TabIndex = 1;
            this.txtImput_flag.Visible = false;
            // 
            // txtImput_time
            // 
            this.txtImput_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtImput_time.Location = new System.Drawing.Point(648, 511);
            this.txtImput_time.Name = "txtImput_time";
            this.txtImput_time.ReadOnly = true;
            this.txtImput_time.Size = new System.Drawing.Size(267, 47);
            this.txtImput_time.TabIndex = 1;
            this.txtImput_time.Visible = false;
            // 
            // lblGoods_name
            // 
            this.lblGoods_name.AutoSize = true;
            this.lblGoods_name.Location = new System.Drawing.Point(12, 189);
            this.lblGoods_name.Name = "lblGoods_name";
            this.lblGoods_name.Size = new System.Drawing.Size(130, 31);
            this.lblGoods_name.TabIndex = 3;
            this.lblGoods_name.Text = "物料描述:";
            // 
            // lblCrusr
            // 
            this.lblCrusr.AutoSize = true;
            this.lblCrusr.Location = new System.Drawing.Point(9, 520);
            this.lblCrusr.Name = "lblCrusr";
            this.lblCrusr.Size = new System.Drawing.Size(103, 31);
            this.lblCrusr.TabIndex = 3;
            this.lblCrusr.Text = "收貨人:";
            this.lblCrusr.Visible = false;
            // 
            // txtCon_date
            // 
            this.txtCon_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCon_date.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtCon_date.Location = new System.Drawing.Point(142, 70);
            this.txtCon_date.Mask = "9999/99/99";
            this.txtCon_date.Name = "txtCon_date";
            this.txtCon_date.PromptChar = ' ';
            this.txtCon_date.Size = new System.Drawing.Size(248, 47);
            this.txtCon_date.TabIndex = 2;
            this.txtCon_date.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtCon_date_MouseDown);
            // 
            // lblCon_date
            // 
            this.lblCon_date.AutoSize = true;
            this.lblCon_date.Location = new System.Drawing.Point(9, 81);
            this.lblCon_date.Name = "lblCon_date";
            this.lblCon_date.Size = new System.Drawing.Size(130, 31);
            this.lblCon_date.TabIndex = 0;
            this.lblCon_date.Text = "移交日期:";
            // 
            // txtTransfer_id
            // 
            this.txtTransfer_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTransfer_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtTransfer_id.Location = new System.Drawing.Point(525, 70);
            this.txtTransfer_id.Name = "txtTransfer_id";
            this.txtTransfer_id.Size = new System.Drawing.Size(265, 47);
            this.txtTransfer_id.TabIndex = 1;
            this.txtTransfer_id.TextChanged += new System.EventHandler(this.txtTransfer_id_TextChanged);
            this.txtTransfer_id.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtTransfer_id_MouseDown);
            // 
            // txtId_state
            // 
            this.txtId_state.BackColor = System.Drawing.Color.Chartreuse;
            this.txtId_state.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtId_state.Location = new System.Drawing.Point(594, 288);
            this.txtId_state.Name = "txtId_state";
            this.txtId_state.ReadOnly = true;
            this.txtId_state.Size = new System.Drawing.Size(125, 47);
            this.txtId_state.TabIndex = 1;
            // 
            // txtSeq_id
            // 
            this.txtSeq_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSeq_id.Location = new System.Drawing.Point(594, 395);
            this.txtSeq_id.Name = "txtSeq_id";
            this.txtSeq_id.ReadOnly = true;
            this.txtSeq_id.Size = new System.Drawing.Size(125, 47);
            this.txtSeq_id.TabIndex = 1;
            // 
            // lblTransfer_id
            // 
            this.lblTransfer_id.AutoSize = true;
            this.lblTransfer_id.Location = new System.Drawing.Point(392, 81);
            this.lblTransfer_id.Name = "lblTransfer_id";
            this.lblTransfer_id.Size = new System.Drawing.Size(130, 31);
            this.lblTransfer_id.TabIndex = 0;
            this.lblTransfer_id.Text = "移交單號:";
            // 
            // lblSeq_id
            // 
            this.lblSeq_id.AutoSize = true;
            this.lblSeq_id.Location = new System.Drawing.Point(585, 351);
            this.lblSeq_id.Name = "lblSeq_id";
            this.lblSeq_id.Size = new System.Drawing.Size(211, 31);
            this.lblSeq_id.TabIndex = 0;
            this.lblSeq_id.Text = "當前更正的記錄:";
            // 
            // txtCrtim
            // 
            this.txtCrtim.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCrtim.Location = new System.Drawing.Point(294, 511);
            this.txtCrtim.Name = "txtCrtim";
            this.txtCrtim.ReadOnly = true;
            this.txtCrtim.Size = new System.Drawing.Size(289, 47);
            this.txtCrtim.TabIndex = 1;
            this.txtCrtim.Visible = false;
            // 
            // txtCrusr
            // 
            this.txtCrusr.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCrusr.Location = new System.Drawing.Point(142, 511);
            this.txtCrusr.Name = "txtCrusr";
            this.txtCrusr.ReadOnly = true;
            this.txtCrusr.Size = new System.Drawing.Size(146, 47);
            this.txtCrusr.TabIndex = 1;
            this.txtCrusr.Visible = false;
            // 
            // txtLot_no
            // 
            this.txtLot_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLot_no.Location = new System.Drawing.Point(896, 126);
            this.txtLot_no.Name = "txtLot_no";
            this.txtLot_no.ReadOnly = true;
            this.txtLot_no.Size = new System.Drawing.Size(117, 47);
            this.txtLot_no.TabIndex = 1;
            this.txtLot_no.Visible = false;
            // 
            // lblLot_no
            // 
            this.lblLot_no.AutoSize = true;
            this.lblLot_no.Location = new System.Drawing.Point(797, 137);
            this.lblLot_no.Name = "lblLot_no";
            this.lblLot_no.Size = new System.Drawing.Size(76, 31);
            this.lblLot_no.TabIndex = 0;
            this.lblLot_no.Text = "批號:";
            this.lblLot_no.Visible = false;
            // 
            // txtMo_id
            // 
            this.txtMo_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMo_id.Location = new System.Drawing.Point(142, 125);
            this.txtMo_id.Name = "txtMo_id";
            this.txtMo_id.Size = new System.Drawing.Size(248, 47);
            this.txtMo_id.TabIndex = 1;
            this.txtMo_id.TextChanged += new System.EventHandler(this.txtMo_id_TextChanged);
            this.txtMo_id.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtMo_id_MouseDown);
            // 
            // lblMo_id
            // 
            this.lblMo_id.AutoSize = true;
            this.lblMo_id.Location = new System.Drawing.Point(9, 136);
            this.lblMo_id.Name = "lblMo_id";
            this.lblMo_id.Size = new System.Drawing.Size(130, 31);
            this.lblMo_id.TabIndex = 0;
            this.lblMo_id.Text = "制單編號:";
            // 
            // txtCountWeg
            // 
            this.txtCountWeg.BackColor = System.Drawing.Color.Yellow;
            this.txtCountWeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCountWeg.Location = new System.Drawing.Point(423, 233);
            this.txtCountWeg.Name = "txtCountWeg";
            this.txtCountWeg.Size = new System.Drawing.Size(146, 47);
            this.txtCountWeg.TabIndex = 1;
            this.txtCountWeg.TextChanged += new System.EventHandler(this.txtCountWeg_TextChanged);
            this.txtCountWeg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtCountQty_MouseDown);
            // 
            // txtCountQty
            // 
            this.txtCountQty.BackColor = System.Drawing.Color.Yellow;
            this.txtCountQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCountQty.Location = new System.Drawing.Point(423, 342);
            this.txtCountQty.Name = "txtCountQty";
            this.txtCountQty.Size = new System.Drawing.Size(146, 47);
            this.txtCountQty.TabIndex = 1;
            this.txtCountQty.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtCountQty_MouseDown);
            // 
            // txtSample_weg
            // 
            this.txtSample_weg.BackColor = System.Drawing.Color.Yellow;
            this.txtSample_weg.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSample_weg.Location = new System.Drawing.Point(423, 288);
            this.txtSample_weg.Name = "txtSample_weg";
            this.txtSample_weg.Size = new System.Drawing.Size(146, 47);
            this.txtSample_weg.TabIndex = 1;
            this.txtSample_weg.TextChanged += new System.EventHandler(this.txtSample_weg_TextChanged);
            this.txtSample_weg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtSample_weg_MouseDown);
            // 
            // lblCountQty
            // 
            this.lblCountQty.AutoSize = true;
            this.lblCountQty.ForeColor = System.Drawing.Color.Black;
            this.lblCountQty.Location = new System.Drawing.Point(290, 349);
            this.lblCountQty.Name = "lblCountQty";
            this.lblCountQty.Size = new System.Drawing.Size(130, 31);
            this.lblCountQty.TabIndex = 0;
            this.lblCountQty.Text = "計算數量:";
            // 
            // lblSumWeg
            // 
            this.lblSumWeg.AutoSize = true;
            this.lblSumWeg.Location = new System.Drawing.Point(9, 242);
            this.lblSumWeg.Name = "lblSumWeg";
            this.lblSumWeg.Size = new System.Drawing.Size(130, 31);
            this.lblSumWeg.TabIndex = 0;
            this.lblSumWeg.Text = "合計重量:";
            // 
            // lblSumQty
            // 
            this.lblSumQty.AutoSize = true;
            this.lblSumQty.Location = new System.Drawing.Point(7, 349);
            this.lblSumQty.Name = "lblSumQty";
            this.lblSumQty.Size = new System.Drawing.Size(130, 31);
            this.lblSumQty.TabIndex = 0;
            this.lblSumQty.Text = "合計數量:";
            // 
            // lblSample_weg
            // 
            this.lblSample_weg.AutoSize = true;
            this.lblSample_weg.Location = new System.Drawing.Point(290, 297);
            this.lblSample_weg.Name = "lblSample_weg";
            this.lblSample_weg.Size = new System.Drawing.Size(130, 31);
            this.lblSample_weg.TabIndex = 0;
            this.lblSample_weg.Text = "圍數重量:";
            // 
            // txtSample_no
            // 
            this.txtSample_no.BackColor = System.Drawing.Color.Yellow;
            this.txtSample_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSample_no.Location = new System.Drawing.Point(142, 288);
            this.txtSample_no.Name = "txtSample_no";
            this.txtSample_no.Size = new System.Drawing.Size(146, 47);
            this.txtSample_no.TabIndex = 1;
            this.txtSample_no.TextChanged += new System.EventHandler(this.txtSample_num_TextChanged);
            this.txtSample_no.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtSample_no_MouseDown);
            // 
            // lblCountWeg
            // 
            this.lblCountWeg.AutoSize = true;
            this.lblCountWeg.Location = new System.Drawing.Point(290, 242);
            this.lblCountWeg.Name = "lblCountWeg";
            this.lblCountWeg.Size = new System.Drawing.Size(130, 31);
            this.lblCountWeg.TabIndex = 0;
            this.lblCountWeg.Text = "實磅重量:";
            // 
            // lblSample_num
            // 
            this.lblSample_num.AutoSize = true;
            this.lblSample_num.Location = new System.Drawing.Point(9, 297);
            this.lblSample_num.Name = "lblSample_num";
            this.lblSample_num.Size = new System.Drawing.Size(130, 31);
            this.lblSample_num.TabIndex = 0;
            this.lblSample_num.Text = "圍數數量:";
            // 
            // txtActual_weg
            // 
            this.txtActual_weg.BackColor = System.Drawing.Color.Cyan;
            this.txtActual_weg.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtActual_weg.Location = new System.Drawing.Point(423, 448);
            this.txtActual_weg.Name = "txtActual_weg";
            this.txtActual_weg.Size = new System.Drawing.Size(146, 47);
            this.txtActual_weg.TabIndex = 1;
            this.txtActual_weg.TextChanged += new System.EventHandler(this.txtActual_weg_TextChanged);
            this.txtActual_weg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtActual_weg_MouseDown);
            // 
            // lblActual_weg
            // 
            this.lblActual_weg.AutoSize = true;
            this.lblActual_weg.Location = new System.Drawing.Point(294, 457);
            this.lblActual_weg.Name = "lblActual_weg";
            this.lblActual_weg.Size = new System.Drawing.Size(130, 31);
            this.lblActual_weg.TabIndex = 0;
            this.lblActual_weg.Text = "實收重量:";
            // 
            // txtActual_qty
            // 
            this.txtActual_qty.BackColor = System.Drawing.Color.Cyan;
            this.txtActual_qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtActual_qty.Location = new System.Drawing.Point(142, 448);
            this.txtActual_qty.Name = "txtActual_qty";
            this.txtActual_qty.Size = new System.Drawing.Size(146, 47);
            this.txtActual_qty.TabIndex = 1;
            this.txtActual_qty.TextChanged += new System.EventHandler(this.txtActual_qty_TextChanged);
            this.txtActual_qty.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtActual_qty_MouseDown);
            // 
            // lblActual_qty
            // 
            this.lblActual_qty.AutoSize = true;
            this.lblActual_qty.Location = new System.Drawing.Point(9, 457);
            this.lblActual_qty.Name = "lblActual_qty";
            this.lblActual_qty.Size = new System.Drawing.Size(130, 31);
            this.lblActual_qty.TabIndex = 0;
            this.lblActual_qty.Text = "實收數量:";
            // 
            // txtGoods_name
            // 
            this.txtGoods_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtGoods_name.Location = new System.Drawing.Point(142, 180);
            this.txtGoods_name.Name = "txtGoods_name";
            this.txtGoods_name.ReadOnly = true;
            this.txtGoods_name.Size = new System.Drawing.Size(654, 47);
            this.txtGoods_name.TabIndex = 1;
            // 
            // txtAdjQty
            // 
            this.txtAdjQty.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtAdjQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtAdjQty.Location = new System.Drawing.Point(142, 395);
            this.txtAdjQty.Name = "txtAdjQty";
            this.txtAdjQty.ReadOnly = true;
            this.txtAdjQty.Size = new System.Drawing.Size(146, 47);
            this.txtAdjQty.TabIndex = 25;
            // 
            // lblAdjWeg
            // 
            this.lblAdjWeg.AutoSize = true;
            this.lblAdjWeg.Location = new System.Drawing.Point(294, 404);
            this.lblAdjWeg.Name = "lblAdjWeg";
            this.lblAdjWeg.Size = new System.Drawing.Size(130, 31);
            this.lblAdjWeg.TabIndex = 0;
            this.lblAdjWeg.Text = "校正重量:";
            // 
            // lblAbjQty
            // 
            this.lblAbjQty.AutoSize = true;
            this.lblAbjQty.Location = new System.Drawing.Point(9, 404);
            this.lblAbjQty.Name = "lblAbjQty";
            this.lblAbjQty.Size = new System.Drawing.Size(130, 31);
            this.lblAbjQty.TabIndex = 0;
            this.lblAbjQty.Text = "校正數量:";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl1.MainView = this.gvDetails;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcCheck});
            this.gridControl1.Size = new System.Drawing.Size(1184, 359);
            this.gridControl1.TabIndex = 25;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetails});
            // 
            // gvDetails
            // 
            this.gvDetails.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvDetails.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.White;
            this.gvDetails.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 16F);
            this.gvDetails.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gvDetails.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvDetails.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDetails.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gvDetails.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvDetails.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gvDetails.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gvDetails.Appearance.Row.Options.UseFont = true;
            this.gvDetails.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 16F);
            this.gvDetails.Appearance.ViewCaption.Options.UseFont = true;
            this.gvDetails.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.gvDetails.Appearance.ViewCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gvDetails.AppearancePrint.Row.Options.UseTextOptions = true;
            this.gvDetails.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gvDetails.AppearancePrint.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gvDetails.ColumnPanelRowHeight = 50;
            this.gvDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.checkbox,
            this.Merge_id,
            this.Mo_id,
            this.Goods_name,
            this.Actual_qty,
            this.Actual_weg,
            this.Sequence_id,
            this.Conf_flag,
            this.Con_qty,
            this.Sec_qty,
            this.Goods_id,
            this.ID,
            this.Con_date,
            this.Rec_state,
            this.Lot_no,
            this.In_dept,
            this.Out_dept,
            this.Check_date,
            this.Rec_id,
            this.Crusr,
            this.Crtim,
            this.Imput_flag,
            this.Imput_time,
            this.Package_num,
            this.Check_state,
            this.Stock_type,
            this.Actual_pack_num,
            this.Sample_no,
            this.Sample_weg,
            this.Complete_state});
            this.gvDetails.FooterPanelHeight = 50;
            this.gvDetails.GridControl = this.gridControl1;
            this.gvDetails.Name = "gvDetails";
            this.gvDetails.OptionsSelection.MultiSelect = true;
            this.gvDetails.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvDetails.OptionsView.ColumnAutoWidth = false;
            this.gvDetails.OptionsView.ShowGroupPanel = false;
            this.gvDetails.PaintStyleName = "Skin";
            this.gvDetails.RowHeight = 80;
            this.gvDetails.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvDetails_RowStyle);
            this.gvDetails.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gvDetails_SelectionChanged);
            this.gvDetails.MouseLeave += new System.EventHandler(this.gvDetails_MouseLeave);
            // 
            // checkbox
            // 
            this.checkbox.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 16F);
            this.checkbox.AppearanceCell.Options.UseFont = true;
            this.checkbox.Caption = "選取";
            this.checkbox.ColumnEdit = this.gcCheck;
            this.checkbox.FieldName = "check";
            this.checkbox.MaxWidth = 120;
            this.checkbox.Name = "checkbox";
            this.checkbox.Visible = true;
            this.checkbox.VisibleIndex = 0;
            this.checkbox.Width = 80;
            // 
            // gcCheck
            // 
            this.gcCheck.AutoHeight = false;
            this.gcCheck.Name = "gcCheck";
            this.gcCheck.Click += new System.EventHandler(this.gcCheck_Click);
            // 
            // Merge_id
            // 
            this.Merge_id.Caption = "併單索引";
            this.Merge_id.FieldName = "merge_id";
            this.Merge_id.Name = "Merge_id";
            this.Merge_id.OptionsColumn.AllowEdit = false;
            this.Merge_id.OptionsColumn.ReadOnly = true;
            this.Merge_id.Visible = true;
            this.Merge_id.VisibleIndex = 1;
            // 
            // Mo_id
            // 
            this.Mo_id.Caption = "制單編號";
            this.Mo_id.FieldName = "mo_id";
            this.Mo_id.MaxWidth = 100;
            this.Mo_id.Name = "Mo_id";
            this.Mo_id.OptionsColumn.AllowEdit = false;
            this.Mo_id.OptionsColumn.ReadOnly = true;
            this.Mo_id.Visible = true;
            this.Mo_id.VisibleIndex = 2;
            this.Mo_id.Width = 90;
            // 
            // Goods_name
            // 
            this.Goods_name.AppearanceCell.Options.UseTextOptions = true;
            this.Goods_name.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.Goods_name.Caption = "物料描述";
            this.Goods_name.FieldName = "goods_name";
            this.Goods_name.Name = "Goods_name";
            this.Goods_name.OptionsColumn.AllowEdit = false;
            this.Goods_name.OptionsColumn.ReadOnly = true;
            this.Goods_name.Visible = true;
            this.Goods_name.VisibleIndex = 3;
            this.Goods_name.Width = 250;
            // 
            // Actual_qty
            // 
            this.Actual_qty.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 18F);
            this.Actual_qty.AppearanceCell.Options.UseFont = true;
            this.Actual_qty.AppearanceCell.Options.UseTextOptions = true;
            this.Actual_qty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Actual_qty.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.Actual_qty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 16F);
            this.Actual_qty.AppearanceHeader.Options.UseFont = true;
            this.Actual_qty.AppearanceHeader.Options.UseTextOptions = true;
            this.Actual_qty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Actual_qty.Caption = "實收數量";
            this.Actual_qty.FieldName = "actual_qty";
            this.Actual_qty.Name = "Actual_qty";
            this.Actual_qty.OptionsColumn.ReadOnly = true;
            this.Actual_qty.Visible = true;
            this.Actual_qty.VisibleIndex = 4;
            this.Actual_qty.Width = 80;
            // 
            // Actual_weg
            // 
            this.Actual_weg.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 18F);
            this.Actual_weg.AppearanceCell.Options.UseFont = true;
            this.Actual_weg.AppearanceCell.Options.UseTextOptions = true;
            this.Actual_weg.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Actual_weg.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 16F);
            this.Actual_weg.AppearanceHeader.Options.UseFont = true;
            this.Actual_weg.AppearanceHeader.Options.UseTextOptions = true;
            this.Actual_weg.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Actual_weg.Caption = "實收重量";
            this.Actual_weg.FieldName = "actual_weg";
            this.Actual_weg.Name = "Actual_weg";
            this.Actual_weg.OptionsColumn.ReadOnly = true;
            this.Actual_weg.Visible = true;
            this.Actual_weg.VisibleIndex = 5;
            this.Actual_weg.Width = 80;
            // 
            // Sequence_id
            // 
            this.Sequence_id.Caption = "序號";
            this.Sequence_id.FieldName = "sequence_id";
            this.Sequence_id.Name = "Sequence_id";
            this.Sequence_id.OptionsColumn.AllowEdit = false;
            this.Sequence_id.OptionsColumn.ReadOnly = true;
            this.Sequence_id.Visible = true;
            this.Sequence_id.VisibleIndex = 6;
            this.Sequence_id.Width = 60;
            // 
            // Conf_flag
            // 
            this.Conf_flag.Caption = "圍數狀態";
            this.Conf_flag.FieldName = "conf_flag";
            this.Conf_flag.MaxWidth = 60;
            this.Conf_flag.Name = "Conf_flag";
            this.Conf_flag.OptionsColumn.AllowEdit = false;
            this.Conf_flag.OptionsColumn.ReadOnly = true;
            this.Conf_flag.Visible = true;
            this.Conf_flag.VisibleIndex = 7;
            this.Conf_flag.Width = 60;
            // 
            // Con_qty
            // 
            this.Con_qty.Caption = "單據數量";
            this.Con_qty.FieldName = "con_qty";
            this.Con_qty.Name = "Con_qty";
            this.Con_qty.OptionsColumn.ReadOnly = true;
            this.Con_qty.Visible = true;
            this.Con_qty.VisibleIndex = 8;
            this.Con_qty.Width = 80;
            // 
            // Sec_qty
            // 
            this.Sec_qty.Caption = "單據重量";
            this.Sec_qty.FieldName = "sec_qty";
            this.Sec_qty.Name = "Sec_qty";
            this.Sec_qty.OptionsColumn.ReadOnly = true;
            this.Sec_qty.Visible = true;
            this.Sec_qty.VisibleIndex = 9;
            this.Sec_qty.Width = 80;
            // 
            // Goods_id
            // 
            this.Goods_id.Caption = "物料編號";
            this.Goods_id.FieldName = "goods_id";
            this.Goods_id.Name = "Goods_id";
            this.Goods_id.OptionsColumn.AllowEdit = false;
            this.Goods_id.OptionsColumn.ReadOnly = true;
            this.Goods_id.Visible = true;
            this.Goods_id.VisibleIndex = 10;
            this.Goods_id.Width = 250;
            // 
            // ID
            // 
            this.ID.Caption = "單據編號";
            this.ID.FieldName = "id";
            this.ID.Name = "ID";
            this.ID.OptionsColumn.ReadOnly = true;
            this.ID.Visible = true;
            this.ID.VisibleIndex = 11;
            this.ID.Width = 160;
            // 
            // Con_date
            // 
            this.Con_date.Caption = "移交單日期";
            this.Con_date.FieldName = "con_date";
            this.Con_date.Name = "Con_date";
            this.Con_date.OptionsColumn.AllowEdit = false;
            this.Con_date.OptionsColumn.ReadOnly = true;
            this.Con_date.Visible = true;
            this.Con_date.VisibleIndex = 12;
            this.Con_date.Width = 130;
            // 
            // Rec_state
            // 
            this.Rec_state.Caption = "收貨狀態";
            this.Rec_state.FieldName = "RecState";
            this.Rec_state.Name = "Rec_state";
            this.Rec_state.OptionsColumn.AllowEdit = false;
            this.Rec_state.OptionsColumn.ReadOnly = true;
            this.Rec_state.Visible = true;
            this.Rec_state.VisibleIndex = 13;
            this.Rec_state.Width = 80;
            // 
            // Lot_no
            // 
            this.Lot_no.Caption = "批號";
            this.Lot_no.FieldName = "lot_no";
            this.Lot_no.Name = "Lot_no";
            this.Lot_no.OptionsColumn.AllowEdit = false;
            this.Lot_no.OptionsColumn.ReadOnly = true;
            this.Lot_no.Visible = true;
            this.Lot_no.VisibleIndex = 14;
            this.Lot_no.Width = 80;
            // 
            // In_dept
            // 
            this.In_dept.Caption = "收貨部門";
            this.In_dept.FieldName = "in_dept";
            this.In_dept.Name = "In_dept";
            this.In_dept.OptionsColumn.AllowEdit = false;
            this.In_dept.OptionsColumn.ReadOnly = true;
            this.In_dept.Visible = true;
            this.In_dept.VisibleIndex = 15;
            this.In_dept.Width = 80;
            // 
            // Out_dept
            // 
            this.Out_dept.Caption = "發貨部門";
            this.Out_dept.FieldName = "out_dept";
            this.Out_dept.Name = "Out_dept";
            this.Out_dept.OptionsColumn.AllowEdit = false;
            this.Out_dept.OptionsColumn.ReadOnly = true;
            this.Out_dept.Visible = true;
            this.Out_dept.VisibleIndex = 16;
            this.Out_dept.Width = 80;
            // 
            // Check_date
            // 
            this.Check_date.Caption = "批准日期";
            this.Check_date.FieldName = "check_date";
            this.Check_date.Name = "Check_date";
            this.Check_date.OptionsColumn.AllowEdit = false;
            this.Check_date.OptionsColumn.ReadOnly = true;
            this.Check_date.Visible = true;
            this.Check_date.VisibleIndex = 17;
            this.Check_date.Width = 130;
            // 
            // Rec_id
            // 
            this.Rec_id.Caption = "收貨單據";
            this.Rec_id.FieldName = "rec_id";
            this.Rec_id.Name = "Rec_id";
            this.Rec_id.OptionsColumn.AllowEdit = false;
            this.Rec_id.OptionsColumn.ReadOnly = true;
            this.Rec_id.Visible = true;
            this.Rec_id.VisibleIndex = 18;
            this.Rec_id.Width = 160;
            // 
            // Crusr
            // 
            this.Crusr.Caption = "收貨人";
            this.Crusr.FieldName = "crusr";
            this.Crusr.Name = "Crusr";
            this.Crusr.OptionsColumn.AllowEdit = false;
            this.Crusr.OptionsColumn.ReadOnly = true;
            this.Crusr.Visible = true;
            this.Crusr.VisibleIndex = 19;
            this.Crusr.Width = 100;
            // 
            // Crtim
            // 
            this.Crtim.Caption = "收貨日期";
            this.Crtim.FieldName = "crtim";
            this.Crtim.Name = "Crtim";
            this.Crtim.OptionsColumn.AllowEdit = false;
            this.Crtim.OptionsColumn.ReadOnly = true;
            this.Crtim.Visible = true;
            this.Crtim.VisibleIndex = 20;
            this.Crtim.Width = 130;
            // 
            // Imput_flag
            // 
            this.Imput_flag.Caption = "簽收標識";
            this.Imput_flag.FieldName = "imput_flag";
            this.Imput_flag.Name = "Imput_flag";
            this.Imput_flag.OptionsColumn.AllowEdit = false;
            this.Imput_flag.OptionsColumn.ReadOnly = true;
            this.Imput_flag.Visible = true;
            this.Imput_flag.VisibleIndex = 21;
            this.Imput_flag.Width = 100;
            // 
            // Imput_time
            // 
            this.Imput_time.Caption = "簽收時間";
            this.Imput_time.FieldName = "imput_time";
            this.Imput_time.Name = "Imput_time";
            this.Imput_time.OptionsColumn.AllowEdit = false;
            this.Imput_time.OptionsColumn.ReadOnly = true;
            this.Imput_time.Visible = true;
            this.Imput_time.VisibleIndex = 22;
            this.Imput_time.Width = 130;
            // 
            // Package_num
            // 
            this.Package_num.Caption = "包數";
            this.Package_num.FieldName = "package_num";
            this.Package_num.Name = "Package_num";
            this.Package_num.OptionsColumn.AllowEdit = false;
            this.Package_num.OptionsColumn.ReadOnly = true;
            this.Package_num.Visible = true;
            this.Package_num.VisibleIndex = 23;
            this.Package_num.Width = 80;
            // 
            // Check_state
            // 
            this.Check_state.Caption = "批准狀態";
            this.Check_state.FieldName = "state";
            this.Check_state.Name = "Check_state";
            this.Check_state.OptionsColumn.AllowEdit = false;
            this.Check_state.OptionsColumn.ReadOnly = true;
            this.Check_state.Visible = true;
            this.Check_state.VisibleIndex = 24;
            this.Check_state.Width = 80;
            // 
            // Stock_type
            // 
            this.Stock_type.Caption = "庫存類型";
            this.Stock_type.FieldName = "stock_type";
            this.Stock_type.Name = "Stock_type";
            this.Stock_type.OptionsColumn.AllowEdit = false;
            this.Stock_type.OptionsColumn.ReadOnly = true;
            this.Stock_type.Visible = true;
            this.Stock_type.VisibleIndex = 25;
            this.Stock_type.Width = 74;
            // 
            // Actual_pack_num
            // 
            this.Actual_pack_num.Caption = "實際包數";
            this.Actual_pack_num.FieldName = "actual_pack";
            this.Actual_pack_num.Name = "Actual_pack_num";
            this.Actual_pack_num.OptionsColumn.AllowEdit = false;
            this.Actual_pack_num.OptionsColumn.ReadOnly = true;
            this.Actual_pack_num.Visible = true;
            this.Actual_pack_num.VisibleIndex = 26;
            this.Actual_pack_num.Width = 72;
            // 
            // Sample_no
            // 
            this.Sample_no.Caption = "圍數數量";
            this.Sample_no.FieldName = "sample_no";
            this.Sample_no.Name = "Sample_no";
            this.Sample_no.OptionsColumn.AllowEdit = false;
            this.Sample_no.OptionsColumn.ReadOnly = true;
            this.Sample_no.Visible = true;
            this.Sample_no.VisibleIndex = 27;
            this.Sample_no.Width = 77;
            // 
            // Sample_weg
            // 
            this.Sample_weg.Caption = "圍數重量";
            this.Sample_weg.FieldName = "sample_weg";
            this.Sample_weg.Name = "Sample_weg";
            this.Sample_weg.OptionsColumn.AllowEdit = false;
            this.Sample_weg.OptionsColumn.ReadOnly = true;
            this.Sample_weg.Visible = true;
            this.Sample_weg.VisibleIndex = 28;
            this.Sample_weg.Width = 100;
            // 
            // Complete_state
            // 
            this.Complete_state.Caption = "完成標識";
            this.Complete_state.FieldName = "id_state";
            this.Complete_state.Name = "Complete_state";
            this.Complete_state.OptionsColumn.AllowEdit = false;
            this.Complete_state.OptionsColumn.ReadOnly = true;
            this.Complete_state.Visible = true;
            this.Complete_state.VisibleIndex = 29;
            this.Complete_state.Width = 70;
            // 
            // frmTransferConfQty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 726);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "frmTransferConfQty";
            this.Text = "frmTransferRecords";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTransferRecords_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblIn_dep;
        private System.Windows.Forms.TextBox txtIn_dept;
        private System.Windows.Forms.TextBox txtOut_dept;
        private System.Windows.Forms.Label lblOut_dep;
        private System.Windows.Forms.TextBox txtMo_id;
        private System.Windows.Forms.Label lblMo_id;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lblCon_date;
        private System.Windows.Forms.TextBox txtActual_qty;
        private System.Windows.Forms.Label lblActual_qty;
        private System.Windows.Forms.TextBox txtActual_weg;
        private System.Windows.Forms.Label lblActual_weg;
        private System.Windows.Forms.TextBox txtSeq_id;
        private System.Windows.Forms.Label lblSeq_id;
        private System.Windows.Forms.RadioButton rdbById;
        private System.Windows.Forms.RadioButton rdbByMo;
        private System.Windows.Forms.TextBox txtTransfer_id;
        private System.Windows.Forms.Label lblTransfer_id;
        private System.Windows.Forms.MaskedTextBox txtCon_date;
        private System.Windows.Forms.TextBox txtLot_no;
        private System.Windows.Forms.Label lblLot_no;
        private System.Windows.Forms.Label lblCrusr;
        private System.Windows.Forms.TextBox txtCrtim;
        private System.Windows.Forms.TextBox txtCrusr;
        private System.Windows.Forms.TextBox txtImput_time;
        private System.Windows.Forms.TextBox txtImput_flag;
        private System.Windows.Forms.Button btnConfigMo;
        private System.Windows.Forms.TextBox txtActual_pack;
        private System.Windows.Forms.Label lblActual_pack;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblGoods_name;
        private System.Windows.Forms.TextBox txtGoods_name;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.TextBox txtCountQty;
        private System.Windows.Forms.TextBox txtSample_weg;
        private System.Windows.Forms.Label lblCountQty;
        private System.Windows.Forms.Label lblSample_weg;
        private System.Windows.Forms.TextBox txtSample_no;
        private System.Windows.Forms.Label lblSample_num;
        private System.Windows.Forms.Button btnGetQty;
        private System.Windows.Forms.Label lblId_state;
        private System.Windows.Forms.RadioButton rdbNoConfQty;
        private System.Windows.Forms.TextBox txtId_state;
        private System.Windows.Forms.TextBox txtSumQty;
        private System.Windows.Forms.TextBox txtSumWeg;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Columns.GridColumn Mo_id;
        private DevExpress.XtraGrid.Columns.GridColumn checkbox;
        private DevExpress.XtraGrid.Columns.GridColumn Conf_flag;
        private DevExpress.XtraGrid.Columns.GridColumn Goods_name;
        private DevExpress.XtraGrid.Columns.GridColumn Con_qty;
        private DevExpress.XtraGrid.Columns.GridColumn Sec_qty;
        private DevExpress.XtraGrid.Columns.GridColumn Goods_id;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn Con_date;
        private DevExpress.XtraGrid.Columns.GridColumn Sequence_id;
        private DevExpress.XtraGrid.Columns.GridColumn Rec_state;
        private DevExpress.XtraGrid.Columns.GridColumn Lot_no;
        private DevExpress.XtraGrid.Columns.GridColumn Actual_qty;
        private DevExpress.XtraGrid.Columns.GridColumn Actual_weg;
        private DevExpress.XtraGrid.Columns.GridColumn In_dept;
        private DevExpress.XtraGrid.Columns.GridColumn Out_dept;
        private DevExpress.XtraGrid.Columns.GridColumn Check_date;
        private DevExpress.XtraGrid.Columns.GridColumn Rec_id;
        private DevExpress.XtraGrid.Columns.GridColumn Crusr;
        private DevExpress.XtraGrid.Columns.GridColumn Crtim;
        private DevExpress.XtraGrid.Columns.GridColumn Imput_flag;
        private DevExpress.XtraGrid.Columns.GridColumn Imput_time;
        private DevExpress.XtraGrid.Columns.GridColumn Package_num;
        private DevExpress.XtraGrid.Columns.GridColumn Check_state;
        private DevExpress.XtraGrid.Columns.GridColumn Stock_type;
        private DevExpress.XtraGrid.Columns.GridColumn Actual_pack_num;
        private DevExpress.XtraGrid.Columns.GridColumn Sample_no;
        private DevExpress.XtraGrid.Columns.GridColumn Sample_weg;
        private DevExpress.XtraGrid.Columns.GridColumn Complete_state;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit gcCheck;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetails;
        private System.Windows.Forms.TextBox txtAdjWeg;
        private System.Windows.Forms.TextBox txtAdjQty;
        private System.Windows.Forms.Label lblSumQty;
        private System.Windows.Forms.Label lblAdjWeg;
        private System.Windows.Forms.Label lblAbjQty;
        private System.Windows.Forms.Label lblSumWeg;
        private System.Windows.Forms.TextBox txtCountWeg;
        private System.Windows.Forms.Label lblCountWeg;
        private DevExpress.XtraGrid.Columns.GridColumn Merge_id;
        private System.Windows.Forms.TextBox txtGoods_id;
        private System.Windows.Forms.Button btnIsConf;
    }
}