using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RUI.PC;
using cf_pad.CLS;
using cf_pad.MDL;

namespace cf_pad.Forms
{
    public partial class frmTakeMoSample : Form
    {
        private string remote_db = DBUtility.remote_db;
        private string _userid = DBUtility._user_id;
        private string within_code = DBUtility.within_code;
        private DataTable dtStoreList = new DataTable();
        private DataTable dtFlRec = new DataTable();
        private string doc_type = "ADN";
        private bool edit_mode = false;//編輯狀態
        private string barcode = "";
        public frmTakeMoSample()
        {
            InitializeComponent();
        }


        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    barcode = txtBarCode.Text.Trim();
                    if (barcode.Length != 12)
                    {
                        MessageBox.Show("條碼規則或長度不正確!");
                        return;
                    }
                    txtBarCode.Text = "";
                    cleanItemBox();
                    loadFlRec();
                    break;
            }
        }

        private void InitComBoxs()
        {
            //綁定發貨倉庫
            DataTable dtLoc = clsTakeMoSample.loadLoc();
            cmbStore.DataSource = dtLoc;
            cmbStore.DisplayMember = "int9loc";
            cmbStore.ValueMember = "int9loc";



            mktCon_date.Text = System.DateTime.Now.ToString("yyyy/MM/dd");// "2015/01/01";

            
        }

        private void frmStoreIssue_Load(object sender, EventArgs e)
        {


            Font a = new Font("GB2312", 14);//GB2312为字体名称，1为字体大小dataGridView1.Font = a;
            dgvDetails.Font = a;
            dgvDetails.AutoGenerateColumns = false;
            dgvShowDetails.Font = a;
            dgvShowDetails.AutoGenerateColumns = false;
            dgvMoDetails.Font = a;
            dgvMoDetails.AutoGenerateColumns = false;
            dgvShowStore.Font = a;
            dgvShowStore.AutoGenerateColumns = false;
            dgvFlRec.Font = a;
            dgvFlRec.AutoGenerateColumns = false;
            dgvWaitFl.Font = a;
            dgvWaitFl.AutoGenerateColumns = false;

            txtId.Text = "ADI0001000005";
            InitComBoxs();//初始化控件
            
            txtBarCode.Focus();
        }
        //從內部提倉單中提取發貨資料
        private void loadFlRec()
        {
            string loc = "";
            string lot = "";
            string mo_id = "";
            string st_lot = "";
            string fl_mo = "";
            string fl_lot = "";
            int st_qty, fl_qty;
            double st_weg, fl_weg;
            string id=doc_type+barcode.Substring(0,10);
            string seq = "00" + barcode.Substring(10, 2) + "h";
            
            dtFlRec = clsTakeMoSample.GetFlRecFromJo(id,seq);//提取待發料記錄

            if (dtFlRec.Rows.Count > 0)
            {
                edit_mode = true;//找到記錄，變為編輯狀態
                loc = dtFlRec.Rows[0]["location"].ToString();
                txtOmo_id.Text = dtFlRec.Rows[0]["obligate_mo_id"].ToString();
                txtLot_no.Text = dtFlRec.Rows[0]["lot_no"].ToString();
                txtGoods_id.Text = dtFlRec.Rows[0]["goods_id"].ToString();
                txtGoods_name.Text = dtFlRec.Rows[0]["goods_name"].ToString();
                txtMo_id.Text = dtFlRec.Rows[0]["mo_id"].ToString();
                txtJo_id.Text = dtFlRec.Rows[0]["id"].ToString();
                txtOrder_no.Text = dtFlRec.Rows[0]["order_no"].ToString();
                txtSo_sequence_id.Text = dtFlRec.Rows[0]["so_sequence_id"].ToString();
                txtOrder_qty.Text = dtFlRec.Rows[0]["order_qty"].ToString();
                cmbStore.SelectedValue = loc;
                fl_qty = 0;
                for (int i = 0; i < dtFlRec.Rows.Count; i++)
                {
                    fl_qty = fl_qty + Convert.ToInt32(dtFlRec.Rows[i]["fl_qty"]);
                }
                txtQty.Text = fl_qty.ToString();

                ////提倉單，取消不用通過轉換率獲取發料重量
                //double rate = clsTakeMoSample.GetRate(txtGoods_id.Text);
                //if (rate > 0)
                //{
                //    txtWeg.Text = Math.Round(fl_qty / rate, 2).ToString();
                //    txtKgRate.Text = rate.ToString();
                //}
                //else
                //    txtWeg.Text = "";
                //if (txtWeg.Text == "" || txtWeg.Text == "0")
                //    txtWeg.Text = "0.01";


                //提取庫存記錄
                DataTable dtSt = new DataTable();
                dtSt = clsTakeMoSample.checkMoStore(loc, mo_id, txtGoods_id.Text, lot);
                
                ////要在已發料且未批準的記錄中查找，是否有已發貨的批號，若有，則要先扣除這些記錄的庫存
                string state = "0";
                DataTable dtId = clsTakeMoSample.findDocRec_Sub(txtId.Text, loc, txtGoods_id.Text, state);

                for (int i = 0; i < dtSt.Rows.Count; i++)
                {
                    mo_id = dtSt.Rows[i]["mo_id"].ToString();
                    st_lot = dtSt.Rows[i]["lot_no"].ToString();
                    st_qty = Convert.ToInt32(dtSt.Rows[i]["qty"]);
                    st_weg = Math.Round(Convert.ToSingle(dtSt.Rows[i]["sec_qty"]), 2);
                    for (int j = 0; j < dtId.Rows.Count; j++)
                    {
                        fl_mo = dtId.Rows[j]["obligate_mo_id"].ToString();
                        fl_lot = dtId.Rows[j]["ir_lot_no"].ToString();
                        if (mo_id == fl_mo && st_lot == fl_lot)
                        {
                            fl_qty = Convert.ToInt32(dtId.Rows[j]["i_amount"]);
                            fl_weg = Math.Round(Convert.ToSingle(dtId.Rows[j]["i_weight"]), 2);
                            st_qty = st_qty - fl_qty;
                            st_weg = st_weg - fl_weg;
                        }
                    }
                    dtSt.Rows[i]["qty"] = st_qty;
                    dtSt.Rows[i]["sec_qty"] = st_weg;
                }

                dtStoreList.Clear();
                dtStoreList = dtSt.Clone(); // 克隆dt 的结构，包括所有 dt 架构和约束,并无数据； 
                DataRow[] rows ;
                if (cmbStore.SelectedValue.ToString() == "809" || cmbStore.SelectedValue.ToString() == "805" || cmbStore.SelectedValue.ToString() == "815")
                    rows = dtSt.Select("qty<>0 and sec_qty<>0");
                else
                    rows = dtSt.Select("qty<>0 or sec_qty<>0"); // 从dt 中查询符合条件的记录； 
                foreach (DataRow row in rows)  // 将查询的结果添加到dt中； 
                {
                    dtStoreList.Rows.Add(row.ItemArray);
                }

                dgvDetails.DataSource = dtStoreList;
                dgvDetails.Refresh();


                countFlWeg();//通過倉存數來轉換，得出發料重量



                genQtyWeg();//產生發貨記錄

                if (txtMo_id.Text.Trim() == "")
                    txtMo_id.Text = txtOmo_id.Text;
            }
            else
                dgvFlRec.DataSource = null;
            dgvWaitFl.DataSource = dtFlRec;
            dgvWaitFl.Refresh();
        }
        //產生發貨記錄

        private void genQtyWeg()
        {

            if (txtQty.Text.Trim() != "" && txtQty.Text.Trim() != "0" && !Verify.StringValidating(txtQty.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
            {
                Operation_info("數 量 格 式 有 錯 誤!", Color.Red);
                return;
            }
            if (txtWeg.Text.Trim() != "" && txtWeg.Text.Trim() != "0" && !Verify.StringValidating(txtWeg.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
            {
                Operation_info("重 量 格 式 有 錯 誤!", Color.Red);
                return;
            }


            //string loc = "";
            //string lot = "";
            //string mo_id = "";
            //int lot_qty = 0;
            //double tot_fl_weg = 0;

            int fl_qty = 0;
            double fl_weg = 0;
            string fl_lot = "";
            string st_lot = "";
            string fl_mo = "";
            string st_mo = "";
            int st_qty = 0;
            double st_weg = 0;
            int bal_qty = 0;
            double bal_weg = 0;
            
            double lot_weg = 0;
            
            

            DataTable dtFlList = new DataTable();
            DataTable dtStoreRec = new DataTable();
            dtStoreRec = dtStoreList.Clone(); //Copy倉存記錄
            foreach (DataRow row in dtStoreList.Rows)
            {
                dtStoreRec.ImportRow(row);
            }
            dtFlList = dtFlRec.Clone(); //Copy發料記錄
            foreach (DataRow row in dtFlRec.Rows)
            {
                dtFlList.ImportRow(row);
            }
            dtFlList.Columns.Add("chkRec", typeof(bool));
            dtFlList.Columns.Add("fl_weg", typeof(double));
            dtFlList.Columns.Add("st_qty", typeof(int));
            dtFlList.Columns.Add("st_weg", typeof(double));

            //將輸入的數量指派到發料記錄中,如果數量比記錄數少，就要將原來記錄的發料數清0
            bal_qty = (txtQty.Text != "" ? Convert.ToInt32(txtQty.Text) : 0);
            for (int i = 0; i < dtFlList.Rows.Count; i++)
            {
                fl_qty = Convert.ToInt32(dtFlList.Rows[i]["fl_qty"]);
                if (bal_qty > fl_qty)
                {
                    bal_qty = bal_qty - fl_qty;
                }
                else
                {
                    if (bal_qty > 0)
                    {
                        fl_qty = bal_qty;
                        bal_qty = 0;
                        dtFlList.Rows[i]["fl_qty"] = fl_qty;
                    }
                    else
                        if (bal_qty == 0)
                            dtFlList.Rows[i]["fl_qty"] = 0;
                }
                dtFlList.Rows[i]["fl_weg"] = 0;
            }

            //如果數量還沒有指派完，則將剩餘的數量加到第一筆記錄中
            if (bal_qty > 0)
            {
                fl_qty = Convert.ToInt32(dtFlList.Rows[0]["fl_qty"]);
                dtFlList.Rows[0]["fl_qty"] = fl_qty + bal_qty;
            }



            
            //先將庫存對應批號套入發料記錄中，同時扣除對應的批號的數量，以免被其它批號所用
            //若庫存批號不存在了，則發料的庫存改為0
            for (int i = 0; i < dtFlList.Rows.Count; i++)
            {
                fl_mo = dtFlList.Rows[i]["obligate_mo_id"].ToString();
                fl_lot = dtFlList.Rows[i]["lot_no"].ToString();
                for (int j = 0; j < dtStoreRec.Rows.Count; j++)
                {
                    st_mo = dtStoreRec.Rows[j]["mo_id"].ToString();
                    st_lot=dtStoreRec.Rows[j]["lot_no"].ToString();
                    if (fl_mo==st_mo && fl_lot == st_lot)
                    {
                        fl_qty = Convert.ToInt32(dtFlList.Rows[i]["fl_qty"]);
                        st_qty = Convert.ToInt32(dtStoreRec.Rows[j]["qty"]);
                        st_weg = Math.Round(Convert.ToSingle(Convert.ToSingle(dtStoreRec.Rows[j]["sec_qty"])), 2);
                        dtFlList.Rows[i]["st_qty"] = st_qty;
                        dtFlList.Rows[i]["st_weg"] = st_weg;

                        if (st_qty > fl_qty)//預先減去已配給的庫存，以免被其它批號再扣
                            dtStoreRec.Rows[j]["qty"] = st_qty - fl_qty;
                        else
                            dtStoreRec.Rows[j]["qty"] = 0;
                        break;
                    }
                    else
                    {
                        dtFlList.Rows[i]["st_qty"] = 0;
                        dtFlList.Rows[i]["st_weg"] = 0;
                    }
                }
            }

            //將發料數同倉數對比，若倉數每MO及LOT若不夠扣，發料就要產生一筆新的記錄
            
            int rows_count = dtFlList.Rows.Count;
            for (int i = 0; i < rows_count; i++)
            {
                fl_mo = dtFlList.Rows[i]["obligate_mo_id"].ToString();
                fl_lot = dtFlList.Rows[i]["lot_no"].ToString();
                fl_qty = Convert.ToInt32(dtFlList.Rows[i]["fl_qty"]);//Convert.ToInt32(txtQty.Text);
                st_qty = (dtFlList.Rows[i]["st_qty"].ToString() != "" ? Convert.ToInt32(dtFlList.Rows[i]["st_qty"]) : 0);
                if (fl_qty > st_qty)
                    dtFlList.Rows[i]["fl_qty"] = st_qty;
                
                bal_qty = fl_qty - st_qty;
                if (bal_qty > 0)//如果發料大於倉存，即倉不夠數，要繼續在其它批次中查找
                {
                    
                    for (int j = 0; j < dtStoreRec.Rows.Count; j++)
                    {
                        st_qty = Convert.ToInt32(dtStoreRec.Rows[j]["qty"]);
                        if (st_qty > 0)
                        {
                            st_mo = dtStoreRec.Rows[j]["mo_id"].ToString();
                            st_lot = dtStoreRec.Rows[j]["lot_no"].ToString();
                            if (fl_mo != st_mo || fl_lot != st_lot)
                            {
                                //st_qty = Convert.ToInt32(dtStoreRec.Rows[j]["qty"]);
                                //if (st_qty > 0)
                                //{
                                if (bal_qty > st_qty)
                                {
                                    fl_qty = st_qty;
                                    st_qty = 0;
                                    bal_qty = bal_qty - fl_qty;
                                }
                                else
                                {
                                    fl_qty = bal_qty;
                                    st_qty = st_qty - bal_qty;
                                    bal_qty = 0;
                                }
                                dtStoreRec.Rows[j]["qty"] = st_qty;
                                DataRow dr = dtFlList.NewRow();
                                dr["obligate_mo_id"] = dtStoreRec.Rows[j]["mo_id"];
                                dr["lot_no"] = dtStoreRec.Rows[j]["lot_no"];
                                dr["fl_qty"] = fl_qty;
                                dr["fl_weg"] = 0;
                                dr["jo_sub_sequence_id"] = dtFlList.Rows[i]["jo_sub_sequence_id"].ToString();
                                dr["mrp_id"] = dtFlList.Rows[i]["mrp_id"].ToString();
                                dtFlList.Rows.Add(dr);
                                if (bal_qty == 0)
                                    break;
                                //}
                            }
                        }
                    }
                }
            }

            //指派重量


            dtStoreRec.Clear();
            foreach (DataRow row in dtStoreList.Rows)
            {
                dtStoreRec.ImportRow(row);
            }
            rows_count = dtFlList.Rows.Count;
            bal_weg = (txtWeg.Text != "" ? Math.Round(Convert.ToSingle(txtWeg.Text), 2) : 0);
            for (int i = 0; i < rows_count; i++)
            {
                fl_mo = dtFlList.Rows[i]["obligate_mo_id"].ToString();
                fl_lot = dtFlList.Rows[i]["lot_no"].ToString();
                fl_qty = Convert.ToInt32(dtFlList.Rows[i]["fl_qty"]);
                
                if (fl_qty > 0)//如果有發料，才計算重量
                {
                    for (int j = 0; j < dtStoreRec.Rows.Count; j++)
                    {
                        st_mo = dtStoreRec.Rows[j]["mo_id"].ToString();
                        st_lot = dtStoreRec.Rows[j]["lot_no"].ToString();
                        if (fl_mo==st_mo && fl_lot == st_lot)
                        {
                            st_qty = Convert.ToInt32(dtStoreRec.Rows[j]["qty"]);
                            st_weg = Math.Round(Convert.ToSingle(dtStoreRec.Rows[j]["sec_qty"]), 2);
                            if (bal_weg > st_weg)
                            {
                                if (fl_qty == st_qty)
                                    fl_weg = st_weg;
                                else
                                    fl_weg = Math.Round(fl_qty * (st_weg / st_qty), 2);
                                st_weg = st_weg - fl_weg;

                                bal_weg = Math.Round(bal_weg - fl_weg, 2);
                            }
                            else
                            {
                                fl_weg = bal_weg;
                                st_weg = Math.Round(st_weg - bal_weg, 2);
                                bal_weg = 0;
                            }
                            dtFlList.Rows[i]["fl_weg"] = fl_weg;
                            dtStoreRec.Rows[j]["sec_qty"] = st_weg;
                            break;
                        }
                    }
                }
                if (bal_weg == 0)
                    break;
            }

            if (bal_weg > 0)
            {
                bool result = false;
                for (int j = 0; j < dtStoreRec.Rows.Count; j++)
                {
                    st_mo = dtStoreRec.Rows[j]["mo_id"].ToString();
                    st_lot = dtStoreRec.Rows[j]["lot_no"].ToString();
                    st_weg = Math.Round(Convert.ToSingle(dtStoreRec.Rows[j]["sec_qty"]), 2);
                    if (bal_weg > st_weg)
                    {
                        fl_weg = st_weg;
                        st_weg = 0;
                        bal_weg = Math.Round(bal_weg - fl_weg, 2);
                    }
                    else
                    {
                        fl_weg = bal_weg;
                        st_weg = Math.Round(st_weg - bal_weg, 2);
                        bal_weg = 0;
                    }
                    dtStoreRec.Rows[j]["sec_qty"] = st_weg;
                    for (int i = 0; i < rows_count; i++)
                    {
                        fl_mo = dtFlList.Rows[i]["obligate_mo_id"].ToString();
                        fl_lot = dtFlList.Rows[i]["lot_no"].ToString();
                        if (fl_mo==st_mo && st_lot == fl_lot)
                        {
                            lot_weg = Math.Round(Convert.ToSingle(dtFlList.Rows[i]["fl_weg"]), 2);
                            dtFlList.Rows[i]["fl_weg"] = lot_weg + fl_weg;
                            result = true;
                            break;
                        }
                        else
                            result = false;
                    }
                    if (result == false)
                    {

                        DataRow dr = dtFlList.NewRow();
                        dr["obligate_mo_id"] = dtStoreRec.Rows[j]["mo_id"].ToString();
                        dr["lot_no"] = dtStoreRec.Rows[j]["lot_no"].ToString();
                        dr["fl_qty"] = 0;
                        dr["fl_weg"] = fl_weg;
                        dr["jo_sub_sequence_id"] = dtFlList.Rows[0]["jo_sub_sequence_id"].ToString();
                        dr["mrp_id"] = dtFlList.Rows[0]["mrp_id"].ToString();
                        dtFlList.Rows.Add(dr);
                    }
                    if (bal_weg == 0)
                        break;
                }
            }


            DataTable newdt = new DataTable();
            newdt = dtFlList.Clone(); // 克隆dt 的结构，包括所有 dt 架构和约束,并无数据； 
            DataRow[] rows = dtFlList.Select("fl_qty<>0 or fl_weg<>0"); // 从dt 中查询符合条件的记录； 
            foreach (DataRow row in rows)  // 将查询的结果添加到dt中； 
            {
                newdt.Rows.Add(row.ItemArray);
            }



            newdt.DefaultView.Sort = "jo_sub_sequence_id";


            dgvFlRec.DataSource = newdt;
            dgvFlRec.Refresh();
            if (dgvFlRec.Rows.Count > 0)
            {
                txtLot_no.Text = dgvFlRec.Rows[0].Cells["colFlot_no"].Value.ToString();
                txtOmo_id.Text = dgvFlRec.Rows[0].Cells["colFomo_id"].Value.ToString();
            }

            //shareQty();
            //shareWeg();
        }

        private void shareQty()
        {
            if (txtQty.Text.Trim()!="" && !Verify.StringValidating(txtQty.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
            {
                Operation_info("數 量 格 式 有 錯 誤!", Color.Red);
                return;
            }
            if (txtWeg.Text.Trim() != "" && !Verify.StringValidating(txtWeg.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
            {
                Operation_info("重 量 格 式 有 錯 誤!", Color.Red);
                return;
            }
            double bal_qty;
            double st_qty;

            bal_qty = (txtQty.Text != "" ? Math.Round(Convert.ToSingle(txtQty.Text), 0) : 0);
            for (int i = 0; i < dgvFlRec.Rows.Count; i++)
            {
                st_qty = (dgvFlRec.Rows[i].Cells["colFqty"].Value.ToString() != "" ? Math.Round(Convert.ToSingle(dgvFlRec.Rows[i].Cells["colFqty"].Value), 0) : 0);

                if (bal_qty >= st_qty)
                {
                    dgvFlRec.Rows[i].Cells["colFfl_qty"].Value = st_qty;
                    dgvFlRec.Rows[i].Cells["colFchk"].Value = true;
                    dgvFlRec.Rows[i].Cells["colFmrp_id"].Value = dgvDetails.Rows[0].Cells["colMrp_id"].Value;
                    bal_qty = bal_qty - st_qty;
                }
                else
                {
                    if (bal_qty > 0)
                    {
                        dgvFlRec.Rows[i].Cells["colFfl_qty"].Value = bal_qty;
                        dgvFlRec.Rows[i].Cells["colFchk"].Value = true;
                        dgvFlRec.Rows[i].Cells["colFmrp_id"].Value = dgvDetails.Rows[0].Cells["colMrp_id"].Value;
                        bal_qty = 0;
                    }
                    else
                    {
                        dgvFlRec.Rows[i].Cells["colFfl_qty"].Value = 0;
                        dgvFlRec.Rows[i].Cells["colFchk"].Value = false;
                        dgvFlRec.Rows[i].Cells["colFmrp_id"].Value = "";
                    }
                }

                //if (bal_qty <= 0)
                //    break;
            }
            if (dgvFlRec.Rows.Count > 0)
            {
                txtOmo_id.Text = dgvFlRec.Rows[0].Cells["colFomo_id"].Value.ToString();
                txtLot_no.Text = dgvFlRec.Rows[0].Cells["colFlot_no"].Value.ToString();
            }
        }
        private void shareWeg()
        {
            if (txtQty.Text.Trim() != "" && !Verify.StringValidating(txtQty.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
            {
                Operation_info("數 量 格 式 有 錯 誤!", Color.Red);
                return;
            }
            if (txtWeg.Text.Trim() != "" && !Verify.StringValidating(txtWeg.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
            {
                Operation_info("重 量 格 式 有 錯 誤!", Color.Red);
                return;
            }
            double bal_weg;
            double st_qty, st_weg;
            double fl_qty, fl_weg;
            bal_weg = (txtWeg.Text != "" ? (txtWeg.Text != "" ? Math.Round(Convert.ToSingle(txtWeg.Text), 2) : 0) : 0);
            for (int i = 0; i < dgvFlRec.Rows.Count; i++)
            {
                st_qty = (dgvFlRec.Rows[i].Cells["colFqty"].Value.ToString() != "" ? Math.Round(Convert.ToSingle(dgvFlRec.Rows[i].Cells["colFqty"].Value), 0) : 0);
                st_weg = (dgvFlRec.Rows[i].Cells["colFweg"].Value.ToString() != "" ? Math.Round(Convert.ToSingle(dgvFlRec.Rows[i].Cells["colFweg"].Value), 2) : 0);
                fl_qty = (dgvFlRec.Rows[i].Cells["colFfl_qty"].Value.ToString() != "" ? Math.Round(Convert.ToSingle(dgvFlRec.Rows[i].Cells["colFfl_qty"].Value), 0) : 0);
                fl_weg = (dgvFlRec.Rows[i].Cells["colFfl_weg"].Value.ToString() != "" ? Math.Round(Convert.ToSingle(dgvFlRec.Rows[i].Cells["colFfl_weg"].Value), 2) : 0);
                if (bal_weg >= st_weg)
                {
                    if (fl_qty == st_qty)
                        fl_weg = st_weg;
                    else
                        if (fl_qty > 0)//如果存在發料數，則重量按比例換算
                        {
                            if (st_qty != 0)
                                fl_weg = Math.Round(fl_qty * (st_weg / st_qty), 2);
                            else
                                fl_weg = 0;
                        }
                        else
                            fl_weg = st_weg;//若不存在發料數，直接將發料重量等於庫存重量

                    dgvFlRec.Rows[i].Cells["colFfl_weg"].Value = fl_weg;
                    dgvFlRec.Rows[i].Cells["colFchk"].Value = true;
                    dgvFlRec.Rows[i].Cells["colFmrp_id"].Value = dgvDetails.Rows[0].Cells["colMrp_id"].Value;
                    bal_weg = Math.Round(bal_weg - fl_weg, 2);

                }
                else
                {
                    if (bal_weg > 0)
                    {
                        //if (fl_qty > 0)
                        //{
                        //    if (fl_qty == st_qty)
                        //        fl_weg = st_weg;
                        //    else
                        //        fl_weg = Math.Round(fl_qty * (st_weg / st_qty), 2);
                        //}
                        //else
                        //    fl_weg = bal_weg;
                        fl_weg = bal_weg;//不用再通過數量、重量換算，直接將剩下的重量當作發料重量
                        bal_weg = 0;
                        dgvFlRec.Rows[i].Cells["colFfl_weg"].Value = fl_weg;
                        dgvFlRec.Rows[i].Cells["colFchk"].Value = true;
                        dgvFlRec.Rows[i].Cells["colFmrp_id"].Value = dgvDetails.Rows[0].Cells["colMrp_id"].Value;
                    }
                    else
                    {
                        dgvFlRec.Rows[i].Cells["colFfl_weg"].Value = 0;//清空原來的重量
                        if (fl_qty == 0)
                        {
                            dgvFlRec.Rows[i].Cells["colFmrp_id"].Value = "";
                            dgvFlRec.Rows[i].Cells["colFchk"].Value = false;
                        }
                    }
                }
                //if (bal_weg <= 0)
                //    break;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            addNewDoc();
            cleanItemBox();
        }
        private void addNewDoc()
        {
            if (!checkNewDoc())
                return;
            takemosample objModel = new takemosample();
            objModel.con_date = mktCon_date.Text;//"2000/01/01";
            objModel.it_customer = "CF_FAI";
            objModel.crusr = _userid;
            txtId.Text = clsTakeMoSample.AddNewDoc(objModel);
            if (txtId.Text != "")
            {
                Operation_info("建 立 新 單 成 功!", Color.Blue);
            }
            else
            {
                Operation_info("建 立 新 單 失 敗!", Color.Red);
            }
        }
        private bool checkNewDoc()
        {
            bool result = true;
            if (!clsValidRule.CheckDateFormat(mktCon_date.Text.Trim()))
            {
                MessageBox.Show("發貨日期不正確!");
                return false;
            }

            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtBarCode.Focus();
            if (edit_mode == false)
            {
                Operation_info("沒 有 需 要 儲 存 的 記 錄!", Color.Red);
                return;
            }
            addStoreDetails();
        }
        private void addStoreDetails()
        {
            if (!checkNewDoc())
                return;
            if (!checkStoreDetails())
                return;
            string result = "";
            List<takemosample> listDetail = new List<takemosample>();
            

            for (int i = 0; i < dgvFlRec.Rows.Count; i++)
            {
                //if ((bool)dgvFlRec.Rows[i].Cells["colFchk"].Value == true)
                //{
                    takemosample objModel = new takemosample();
                    objModel.id = txtId.Text;
                    objModel.mo_id = txtMo_id.Text;
                    objModel.goods_id = txtGoods_id.Text;
                    objModel.goods_name = txtGoods_name.Text;
                    objModel.obligate_mo_id = txtOmo_id.Text;
                    objModel.qty = Convert.ToInt32(txtQty.Text);
                    objModel.weg = Convert.ToSingle(txtWeg.Text);
                    objModel.lot_no = txtLot_no.Text;
                    objModel.loc = cmbStore.SelectedValue.ToString();
                    objModel.contract_cid = "";
                    objModel.customer_goods = "";
                    objModel.order_no = txtOrder_no.Text;
                    objModel.so_sequence_id = txtSo_sequence_id.Text;
                    objModel.order_qty = (txtOrder_qty.Text.Trim() != "" ? Convert.ToInt32(txtOrder_qty.Text) : 0);
                    objModel.ref_sequence_id = dgvFlRec.Rows[i].Cells["colFJo_sub_sequence_id"].Value.ToString();
                    objModel.line_mo_id = dgvFlRec.Rows[i].Cells["colFomo_id"].Value.ToString();
                    objModel.line_lot_no = dgvFlRec.Rows[i].Cells["colFlot_no"].Value.ToString();
                    objModel.line_qty = Convert.ToInt32(dgvFlRec.Rows[i].Cells["colFfl_qty"].Value);
                    objModel.line_weg = Math.Round(Convert.ToSingle(dgvFlRec.Rows[i].Cells["colFfl_weg"].Value), 2);
                    objModel.mrp_id = dgvFlRec.Rows[i].Cells["colFmrp_id"].Value.ToString();
                    objModel.crusr = _userid;

                    listDetail.Add(objModel);
                //}
            }
            result = clsTakeMoSample.AddStoreRec(listDetail);
            txtSeq.Text = result;

            if (result!="")
            {
                edit_mode = false;//儲存成功後，改為非編輯模式
                Operation_info("數 據 保 存 成 功!", Color.Blue);
                setFlRecColor();
            }
            else
            {
                Operation_info("數 據 保 存 失 敗!", Color.Red);
            }

            refreshDocSubRec();//刷新明細表記錄
            txtBarCode.Focus();
        }

        private void setFlRecColor()
        {
            for (int i = 0; i < dgvFlRec.Rows.Count; i++)
            {
                dgvFlRec.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(0x00, 0x33, 0xFF);
            }
        }
        //刷新明細表記錄
        private void refreshDocSubRec()
        {
            DataTable dtFlRec = clsTakeMoSample.loadDocSubRec(txtId.Text, txtSeq.Text);
            dgvFlRec.DataSource = dtFlRec;
            dgvFlRec.Refresh();
            setFlRecColor();//設置記錄顏色
        }
        private bool checkStoreDetails()
        {
            bool result = true;
            if (txtId.Text == "")
            {
                MessageBox.Show("單據編號不能為空!");
                return false;
            }
            DataTable dtId = clsTakeMoSample.checkDocStatus(txtId.Text);
            if (dtId.Rows.Count == 0)
            {
                MessageBox.Show("單據編號不存在!");
                return false;
            }
            else
            {
                if (dtId.Rows[0]["state"].ToString() != "0")
                {
                    MessageBox.Show("單據編號已批準，不能再進行輸入!");
                    return false;
                }
            }
            if (cmbStore.SelectedValue == null || cmbStore.SelectedValue.ToString()== "")
            {
                MessageBox.Show("發貨倉庫不能為空,請重新輸入!");
                return false;
            }
            if (txtSeq.Text != "")
            {
                MessageBox.Show("這筆記錄已發貨,不能儲存!");
                return false;
            }
            if (txtMo_id.Text == "")
            {
                MessageBox.Show("制單編號不能為空,請重新輸入!");
                return false;
            }
            if (txtGoods_id.Text == "")
            {
                MessageBox.Show("物料編號不能為空,請重新輸入!");
                return false;
            }
            if (txtLot_no.Text == "")
            {
                MessageBox.Show("批號不能為空,請重新輸入!");
                return false;
            }
            if (txtOmo_id.Text == "")
            {
                MessageBox.Show("庫存制單不能為空,請重新輸入!");
                return false;
            }
            //if (txtTdep.Text == "")
            //{
            //    MessageBox.Show("收貨部門不能為空,請重新輸入!");
            //    txtTdep.Focus();
            //    return false;
            //}
            if (txtQty.Text == "" || txtWeg.Text == "")
            {
                MessageBox.Show("數量或重量不能為空,請重新輸入!");
                return false;
            }
            if (!Verify.StringValidating(txtQty.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
            {
                MessageBox.Show("數量格式有誤,請重新輸入!");
                return false;
            }
            if (!Verify.StringValidating(txtWeg.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
            {
                MessageBox.Show("重量格式有誤,請重新輸入!");
                return false;
            }
            if (Convert.ToInt32(txtQty.Text) == 0 || Convert.ToSingle(txtWeg.Text)==0)
            {
                MessageBox.Show("數量或重量不能為0,請重新輸入!");
                return false;
            }
            DataTable dtIdLoc = new DataTable();
            //檢查是否將不同部門的制單輸入在相同的單據上
            //dtIdLoc = clsTakeMoSample.checkDocDiffLoc(txtId.Text, "", "");
            //if (dtIdLoc.Rows.Count > 0)
            //{
            //    if (dtIdLoc.Rows[0]["inventory_issuance"].ToString() != cmbStore.SelectedValue.ToString()
            //        || dtIdLoc.Rows[0]["inventory_receipt"].ToString() != txtTdep.Text.Trim())
            //    {
            //        //MessageBox.Show("不能將發往不同部門的制單輸入在同一單據上!");
            //        //return false;

            //        if (changeDoc() == false)//如果沒有可用的單號，則返回重新建立新單
            //            return false;
            //    }
            //}
            //檢查是否在同一單據上，輸入重複的制單
            
            string adn_id = dgvFlRec.Rows[0].Cells["colFmrp_id"].Value.ToString();
            string seq = dgvFlRec.Rows[0].Cells["colFJo_sub_sequence_id"].Value.ToString();
            dtIdLoc = clsTakeMoSample.checkDocDiffLoc(txtId.Text,adn_id, seq);
            if (dtIdLoc.Rows.Count > 0)
            {
                //if (DialogResult.OK != MessageBox.Show("已重複輸入制單，序號：" + dtIdLoc.Rows[0]["sequence_id"].ToString() + "!", "系統信息", MessageBoxButtons.OKCancel))
                //{
                //    return false;
                //}


                if (MessageBox.Show("已重複輸入制單，序號：" + dtIdLoc.Rows[0]["sequence_id"].ToString() + "!", "確定繼續保存嗎？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }

                
            }
            double fl_qty, fl_weg;
            double tot_qty, tot_weg;
            double line_qty, line_weg;
            double st_qty, st_weg;
            string lot_no = "";
            string mo_id = "";
            tot_qty = 0;
            tot_weg = 0;
            fl_qty = Math.Round(Convert.ToSingle(txtQty.Text), 2);
            fl_weg = Math.Round(Convert.ToSingle(txtWeg.Text), 2);
            for (int i = 0; i < dgvFlRec.Rows.Count; i++)
            {
                //if ((bool)dgvFlRec.Rows[i].Cells["colFchk"].Value == true)
                //{
                    line_qty = Convert.ToSingle(dgvFlRec.Rows[i].Cells["colFfl_qty"].Value);
                    line_weg = Convert.ToSingle(dgvFlRec.Rows[i].Cells["colFfl_weg"].Value);
                    mo_id = dgvFlRec.Rows[i].Cells["colFomo_id"].Value.ToString();
                    lot_no = dgvFlRec.Rows[i].Cells["colFlot_no"].Value.ToString();
                    tot_qty = tot_qty + line_qty;
                    tot_weg = tot_weg + line_weg;
                    
                    DataTable dtMoStore = clsTakeMoSample.checkMoStore(cmbStore.SelectedValue.ToString(), mo_id, txtGoods_id.Text, lot_no);
                    if (dtMoStore.Rows.Count == 0)
                    {
                        MessageBox.Show("批號：" + lot_no + "倉存記錄不存在!");
                        return false;
                    }
                    else
                    {
                        st_qty = Convert.ToInt32(dtMoStore.Rows[0]["qty"]);
                        st_weg = Convert.ToSingle(dtMoStore.Rows[0]["sec_qty"]);
                        if (st_qty < 0 || st_weg < 0)
                        {
                            MessageBox.Show("批號倉存數據已為負數：" + lot_no + "，不能儲存!");
                            return false;
                        }
                        else
                        {
                            if (line_qty > st_qty || line_weg > st_weg)
                            {
                                MessageBox.Show("批號發貨數已大於倉存數：" + lot_no + "，不能儲存!");
                                return false;
                            }
                        }
                    }
                //}
            }
            tot_qty = Math.Round(tot_qty, 2);
            tot_weg = Math.Round(tot_weg, 2);
            if (tot_qty != fl_qty || tot_weg != fl_weg)
            {
                MessageBox.Show("發貨數同扣倉存數不符，數量差額：" + (tot_qty - fl_qty).ToString() + " 重量差額：" + (tot_weg - fl_weg).ToString() + " 不能儲存!");
                return false;
            }
            return result;
        }
        private void cleanItemBox()
        {
            txtMo_id.Text = "";
            txtGoods_id.Text = "";
            txtGoods_name.Text = "";
            txtQty.Text = "";
            txtWeg.Text = "";
            txtTdep.Text = "";
            txtOmo_id.Text = "";
            txtLot_no.Text = "";
            txtJo_seq.Text = "";
            txtJo_sub_seq.Text = "";
            txtJo_id.Text = "";
            txtOrder_no.Text = "";
            txtSo_sequence_id.Text = "";
            txtOrder_qty.Text = "";
            txtSeq.Text = "";
            txtState.Text = "";
            txtCreate_by.Text = "";
            txtCheck_date.Text = "";
            txtKgRate.Text = "";
            dgvDetails.DataSource = null;
            dgvMoDetails.DataSource = null;
            dgvFlRec.DataSource = null;
        }

        //按單據編號查詢發貨記錄
        private void findDocRec()
        {
            if (txtId.Text == "")
            {
                Operation_info("單據編號不能為空!", Color.Blue);
                txtId.Focus();
                return;
            }
            string loc = "";
            string mo_id = "";
            string goods_id = "";
            DataTable dtId = clsTakeMoSample.findDocRec(txtId.Text, loc, mo_id, goods_id);
            dgvShowDetails.DataSource = dtId;
            dgvShowDetails.Refresh();
            if (dtId.Rows.Count > 0)
            {
                if (dtId.Rows[0]["state"].ToString() != "0")
                    txtState.Text = "已批準";
                else
                    txtState.Text = "未批準";
                mktCon_date.Text = dtId.Rows[0]["inventory_date"].ToString();
                txtCreate_by.Text = dtId.Rows[0]["create_by"].ToString();
                txtCheck_date.Text = dtId.Rows[0]["check_date"].ToString();
                
                //fillTextBox(0);//填充各種控件的值
            }
        }
        //按制單編號查詢發貨記錄
        private void findMoRec()
        {
            if (cmbStore.SelectedValue.ToString() == "" && txtMo_id.Text == "" && txtGoods_id.Text == "")
                return;
            string id="";
            string loc = cmbStore.SelectedValue.ToString();
            string mo_id = txtMo_id.Text;
            string goods_id = txtGoods_id.Text;
            DataTable dtId = clsTakeMoSample.findDocRec(id, loc, mo_id, goods_id);
            dgvMoDetails.DataSource = dtId;
            dgvMoDetails.Refresh();
            if (dtId.Rows.Count > 0)
                fillTextBoxFromMo(0);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            findDocRec();
            //cleanItemBox();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (tbcMain.SelectedIndex == 0)//切換單據
            {
                changeDoc();
                return;
            }
            if(tbcMain.SelectedIndex!=1)
            {
                MessageBox.Show("請選擇在明細表中進行刪除!");
                txtBarCode.Focus();
                return;
            }
            if (dgvShowDetails.Rows.Count == 0)
            {
                MessageBox.Show("沒有要刪除的記錄!");
                txtBarCode.Focus();
                return;
            }
            if (txtId.Text == "" || txtSeq.Text=="")
            {
                return;
            }
            DataTable dtId = clsTakeMoSample.checkDocStatus(txtId.Text);
            if (dtId.Rows.Count == 0)
            {
                MessageBox.Show("單據編號不存在!");
                txtId.Focus();
                return;
            }
            else
            {
                if (dtId.Rows[0]["state"].ToString() != "0")
                {
                    MessageBox.Show("單據編號已批準，不能刪除!");
                    txtState.Text = "已批準";
                    return;
                }
            }
            int result = 0;
            result = clsTakeMoSample.DelStoreRec(txtId.Text, dgvShowDetails.CurrentRow.Cells["colDseq"].Value.ToString());

            if (result != 0)
            {
                Operation_info("數 據 刪 除 成 功!", Color.Blue);
                cleanItemBox();
                findDocRec();
            }
            else
            {
                Operation_info("數 據 刪 除 失 敗!", Color.Red);
            }

            
        }
        //從單據編號表中填充各控件的值
        private void fillTextBox(int row)
        {
            txtSeq.Text = dgvShowDetails.Rows[row].Cells["colDseq"].Value.ToString();
            txtMo_id.Text = dgvShowDetails.Rows[row].Cells["colDmo_id"].Value.ToString();
            txtGoods_id.Text = dgvShowDetails.Rows[row].Cells["colDgoods_id"].Value.ToString();
            txtGoods_name.Text = dgvShowDetails.Rows[row].Cells["colDgoods_name"].Value.ToString();
            txtQty.Text = dgvShowDetails.Rows[row].Cells["colDqty"].Value.ToString();
            txtWeg.Text = dgvShowDetails.Rows[row].Cells["colDweg"].Value.ToString();
            txtLot_no.Text = dgvShowDetails.Rows[row].Cells["colDlot_no"].Value.ToString();
            txtOmo_id.Text = dgvShowDetails.Rows[row].Cells["colDomo_id"].Value.ToString();
            txtTdep.Text = dgvShowDetails.Rows[row].Cells["colDtdep"].Value.ToString();
            
            dgvDetails.DataSource = null;
            refreshDocSubRec();//刷新明細表記錄
        }
        //切換單據編號，當在輸入不同部門時，快速切換單據編號
        private bool changeDoc()
        {
            if (cmbStore.SelectedValue.ToString() == "" || mktCon_date.Text == "" || txtTdep.Text == "")
            {
                Operation_info("部門不能為空!", Color.Red);
                return false;
            }
            string loc = cmbStore.SelectedValue.ToString();
            string dat = mktCon_date.Text;
            string tdep = txtTdep.Text;
            string crusr = _userid;
            string state = "0";
            DataTable dtId = clsTakeMoSample.findDocDetails(loc, dat, state, tdep, crusr);
            if (dtId.Rows.Count > 0)
            {
                txtId.Text = dtId.Rows[0]["id"].ToString();
            }
            else
            {
                Operation_info("沒有可用單號，請新建立!", Color.Red);
                return false;
            }
            return true;
        }


        private void Operation_info(string msg, Color fore_clr)
        {
            lblShowResult.Text = msg;
            lblShowResult.ForeColor = fore_clr;
            lblShowResult.Visible = true;
            Delay(1200); // 延時1.2秒
            lblShowResult.Visible = false;
        }

        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }



        //從制單編號表中填充各控件的值
        private void fillTextBoxFromMo(int row)
        {
            txtId.Text = dgvMoDetails.Rows[row].Cells["colMid"].Value.ToString();
            mktCon_date.Text = dgvMoDetails.Rows[row].Cells["colMcon_date"].Value.ToString();
            txtSeq.Text = dgvMoDetails.Rows[row].Cells["colMseq"].Value.ToString();
            txtMo_id.Text = dgvMoDetails.Rows[row].Cells["colMmo_id"].Value.ToString();
            txtGoods_id.Text = dgvMoDetails.Rows[row].Cells["colMgoods_id"].Value.ToString();
            txtGoods_name.Text = dgvMoDetails.Rows[row].Cells["colMgoods_name"].Value.ToString();
            txtQty.Text = dgvMoDetails.Rows[row].Cells["colMqty"].Value.ToString();
            txtWeg.Text = dgvMoDetails.Rows[row].Cells["colMweg"].Value.ToString();
            txtLot_no.Text = dgvMoDetails.Rows[row].Cells["colMlot_no"].Value.ToString();
            txtOmo_id.Text = dgvMoDetails.Rows[row].Cells["colMomo_id"].Value.ToString();
            txtTdep.Text = dgvMoDetails.Rows[row].Cells["colMtdep"].Value.ToString();
            if (dgvMoDetails.Rows[row].Cells["colMstate"].Value.ToString() != "0")
                txtState.Text = "已批準";
            else
                txtState.Text = "未批準";
            dgvDetails.DataSource = null;
        }

        private void tbcMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush bru = new SolidBrush(Color.FromArgb(72, 181, 250));
            SolidBrush bruFont = new SolidBrush(Color.FromArgb(217, 54, 26));// 标签字体颜色
            Font font = new System.Drawing.Font("微软雅黑", 12F);//设置标签字体样式
            StringFormat StrFormat = new StringFormat();

            for (int i = 0; i < tbcMain.TabPages.Count; i++)
            {
                //获取标签头的工作区域
                Rectangle recChild = tbcMain.GetTabRect(i);
                //绘制标签头背景颜色
                e.Graphics.FillRectangle(bru, recChild);
                //绘制标签头的文字
                e.Graphics.DrawString(tbcMain.TabPages[i].Text, font, bruFont, recChild, StrFormat);
            }

        }

        private void tbcMain_Click(object sender, EventArgs e)
        {
            int ss=tbcMain.SelectedIndex;
            if (ss == 0)
                btnDel.Text = "切換單號(&Q)";
            else
            {
                btnDel.Text = "刪除(&D)";
                if (ss == 3)
                {
                    findStore();
                }
            }
            txtBarCode.Focus();
        }

        private void btnNoConfDoc_Click(object sender, EventArgs e)
        {
            string state = "0";
            findNoConfRec(state);
        }
        private void cmdIisConfDoc_Click(object sender, EventArgs e)
        {
            string state = "1";
            findNoConfRec(state);
        }
            //按制單編號查詢發貨記錄
        private void findNoConfRec(string state)
        {
            if (cmbStore.SelectedValue.ToString() == "" || mktCon_date.Text == "")
            {
                MessageBox.Show("請輸入貨倉代號!");
                cmbStore.Focus();
                return;
            }
            string loc = cmbStore.SelectedValue.ToString();
            string dat = mktCon_date.Text;
            string tdep = "";
            string crusr = "";
            DataTable dtId = clsTakeMoSample.findDocDetails(loc, dat, state,tdep,crusr);
            dgvMoDetails.DataSource = dtId;
            dgvMoDetails.Refresh();
            if (dtId.Rows.Count > 0)
                fillTextBoxFromMo(0);
        }

        private void findStore()
        {
            if (cmbStore.SelectedValue.ToString() == "" || txtOmo_id.Text == "" || txtGoods_id.Text == "")
                return;
            string loc = cmbStore.SelectedValue.ToString();
            string goods_id = txtGoods_id.Text;
            string mo_id = txtOmo_id.Text;
            int total_qty = 0;
            double total_weg = 0;
            DataTable dtStore = clsTakeMoSample.findStore(loc, mo_id, goods_id);
            for (int i = 0; i < dtStore.Rows.Count; i++)
            {
                total_qty = Convert.ToInt32(dtStore.Rows[i]["qty"]);
                total_weg = Convert.ToSingle(dtStore.Rows[i]["sec_qty"]);
            }
            dgvShowStore.DataSource = dtStore;
            dgvShowStore.Refresh();
            txtTotalQty.Text = total_qty.ToString();
            txtTotalWeg.Text = total_weg.ToString();
        }


        private void txtWeg_MouseDown(object sender, MouseEventArgs e)
        {
            if (edit_mode == true)
                clsUtility.Call_imput();
        }



        private void txtWeg_Leave(object sender, EventArgs e)
        {
            
            if (edit_mode == true)//在編輯模式下才更新
            {
                genQtyWeg();
                //shareQty();
                //shareWeg();
            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            if (edit_mode == true)//在編輯模式下才更新
            {
                countFlWeg();//通過倉存數轉換，得出發料重量
                genQtyWeg();
                //shareQty();
                //shareWeg();
            }
        }

        private void dgvShowDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fillTextBox(e.RowIndex);//填充各種控件的值
        }

        private void dgvMoDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fillTextBoxFromMo(e.RowIndex);//填充各種控件的值
            findDocRec();
        }

        private void btnTrWeg_Click(object sender, EventArgs e)
        {
            if (txtQty.Text != "" && txtKgRate.Text != "")
            {
                txtWeg.Text = Math.Round(Convert.ToSingle(txtQty.Text) / Convert.ToSingle(txtKgRate.Text), 1).ToString();
                if (txtWeg.Text == "0")
                    txtWeg.Text = "0.01";
                genQtyWeg();
            }
        }

        private void btnTrQty_Click(object sender, EventArgs e)
        {
            if (txtWeg.Text != "" && txtKgRate.Text != "")
            {
                txtQty.Text = Math.Round(Convert.ToSingle(txtWeg.Text) * Convert.ToSingle(txtKgRate.Text), 0).ToString();
                genQtyWeg();
            }
        }

        private void txtId_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtId.Text == "")
            {
                if (mktCon_date.Text.Replace(" ", "") != "//")
                {
                    txtId.Text = "ADI" + mktCon_date.Text.Substring(2, 2) + mktCon_date.Text.Substring(5, 2);
                    txtId.SelectionStart = 7;
                }
                else
                {
                    txtId.Text = "ADI";
                    txtId.SelectionStart = 3;
                }
            }
        }
        //通過倉存數轉換得出發料重量
        private void countFlWeg()
        {
            txtWeg.Text = "0";
            if (txtQty.Text != "")
            {
                for (int i = 0; i < dgvDetails.Rows.Count; i++)
                {
                    if (txtOmo_id.Text == dgvDetails.Rows[i].Cells["colMo_id"].Value.ToString()
                        && txtLot_no.Text == dgvDetails.Rows[i].Cells["colLot_no"].Value.ToString()
                        && dgvDetails.Rows[i].Cells["colQty"].Value.ToString() != ""
                        && dgvDetails.Rows[i].Cells["colSec_qty"].Value.ToString() != "")
                    {
                        txtWeg.Text = Math.Round(Convert.ToSingle(txtQty.Text) * (Convert.ToSingle(dgvDetails.Rows[i].Cells["colSec_qty"].Value.ToString())
                            / Convert.ToSingle(dgvDetails.Rows[i].Cells["colQty"].Value.ToString())), 2).ToString();
                        break;
                    }
                }
            }
            if (txtWeg.Text == "" || txtWeg.Text == "0")
                txtWeg.Text = "0.01";
        }

        private void txtWeg_MouseLeave(object sender, EventArgs e)
        {
            //txtWeg_Leave(sender, e);
        }
    }
}
