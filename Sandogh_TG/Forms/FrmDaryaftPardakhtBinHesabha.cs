using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;

namespace Sandogh_TG
{
    public partial class FrmDaryaftPardakhtBinHesabha : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmDaryaftPardakhtBinHesabha(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        public EnumCED En;
        //public bool IsCheckInSandogh = true;

        public void FillDataGridDaryaftPardakhtBinHesabha()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q1 = db.DaryaftPardakhtBinHesabhas.OrderBy(s => s.Seryal).ToList();
                    if (q1.Count > 0)
                        daryaftPardakhtBinHesabhasBindingSource.DataSource = q1;
                    else
                        daryaftPardakhtBinHesabhasBindingSource.DataSource = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbHesabMoin()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q1 = db.CodeMoins.Select(s => s).ToList();
                    if (q1.Count > 0)
                        codeMoinsBindingSource.DataSource = q1;
                    else
                        codeMoinsBindingSource.DataSource = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbHesabTafzili1()
        {
            using (var db = new MyContext())
            {
                try
                {
                    switch (Convert.ToInt32(cmbHesabMoin1.EditValue))
                    {
                        case 1001:
                            {
                                cmbHesabTafzili1.Properties.DisplayMember = "NameHesab";
                                cmbHesabTafzili1.Properties.ValueMember = "Code";
                                cmbHesabTafzili1.Properties.Columns[1].FieldName = "NameHesab";
                                if (En == EnumCED.Create)
                                {
                                    var q1 = db.HesabBankis.Where(f => f.IsActive == true).OrderBy(s => s.Code).ToList();
                                    if (q1.Count > 0)
                                        cmbHesabTafzili1.Properties.DataSource = q1;
                                    else
                                        cmbHesabTafzili1.Properties.DataSource = null;
                                }
                                else if (En == EnumCED.Edit)
                                {
                                    var q2 = db.HesabBankis.OrderBy(s => s.Code).ToList();
                                    if (q2.Count > 0)
                                        cmbHesabTafzili1.Properties.DataSource = q2;
                                    else
                                        cmbHesabTafzili1.Properties.DataSource = null;
                                }
                                break;
                            }
                        case 2001:
                            {
                                cmbHesabTafzili1.Properties.DisplayMember = "NameVFamil";
                                cmbHesabTafzili1.Properties.ValueMember = "Code";
                                cmbHesabTafzili1.Properties.Columns[1].FieldName = "NameVFamil";
                                if (En == EnumCED.Create)
                                {
                                    var q1 = db.AazaSandoghs.Where(f => f.IsActive == true).OrderBy(s => s.Code).ToList();
                                    if (q1.Count > 0)
                                        cmbHesabTafzili1.Properties.DataSource = q1;
                                    else
                                        cmbHesabTafzili1.Properties.DataSource = null;
                                }
                                else if (En == EnumCED.Edit)
                                {
                                    var q2 = db.AazaSandoghs.OrderBy(s => s.Code).ToList();
                                    if (q2.Count > 0)
                                        cmbHesabTafzili1.Properties.DataSource = q2;
                                    else
                                        cmbHesabTafzili1.Properties.DataSource = null;
                                }
                                break;
                            }
                        case 3001:
                            {
                                goto case 2001;
                            }
                        case 4001:
                            {
                                goto case 2001;
                            }
                        case 6001:
                            {
                                goto case 2001;
                            }
                        case 6002:
                            {
                                goto case 2001;
                            }
                        case 6003:
                            {
                                goto case 2001;
                            }
                        case 7001:
                            {
                                goto case 2001;
                            }
                        case 8001:
                            {
                                cmbHesabTafzili1.Properties.DisplayMember = "HesabName";
                                cmbHesabTafzili1.Properties.ValueMember = "Code";
                                cmbHesabTafzili1.Properties.Columns[1].FieldName = "HesabName";
                                var q1 = db.CodingDaramadVHazines.Where(s => s.GroupIndex == 0).OrderBy(s => s.Code).ToList();
                                if (q1.Count > 0)
                                    cmbHesabTafzili1.Properties.DataSource = q1;
                                else
                                    cmbHesabTafzili1.Properties.DataSource = null;
                                break;
                            }
                        case 9001:
                            {
                                cmbHesabTafzili1.Properties.DisplayMember = "HesabName";
                                cmbHesabTafzili1.Properties.ValueMember = "Code";
                                cmbHesabTafzili1.Properties.Columns[1].FieldName = "HesabName";
                                var q1 = db.CodingDaramadVHazines.Where(s => s.GroupIndex == 1).OrderBy(s => s.Code).ToList();
                                if (q1.Count > 0)
                                    cmbHesabTafzili1.Properties.DataSource = q1;
                                else
                                    cmbHesabTafzili1.Properties.DataSource = null;
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillcmbHesabTafzili2()
        {
            using (var db = new MyContext())
            {
                try
                {
                    switch (Convert.ToInt32(cmbHesabMoin2.EditValue))
                    {
                        case 1001:
                            {
                                cmbHesabTafzili2.Properties.DisplayMember = "NameHesab";
                                cmbHesabTafzili2.Properties.ValueMember = "Code";
                                cmbHesabTafzili2.Properties.Columns[1].FieldName = "NameHesab";
                                if (En == EnumCED.Create)
                                {
                                    var q1 = db.HesabBankis.Where(f => f.IsActive == true).OrderBy(s => s.Code).ToList();
                                    if (q1.Count > 0)
                                        cmbHesabTafzili2.Properties.DataSource = q1;
                                    else
                                        cmbHesabTafzili2.Properties.DataSource = null;
                                }
                                else if (En == EnumCED.Edit)
                                {
                                    var q2 = db.HesabBankis.OrderBy(s => s.Code).ToList();
                                    if (q2.Count > 0)
                                        cmbHesabTafzili2.Properties.DataSource = q2;
                                    else
                                        cmbHesabTafzili2.Properties.DataSource = null;
                                }
                                break;
                            }
                        case 2001:
                            {
                                cmbHesabTafzili2.Properties.DisplayMember = "NameVFamil";
                                cmbHesabTafzili2.Properties.ValueMember = "Code";
                                cmbHesabTafzili2.Properties.Columns[1].FieldName = "NameVFamil";
                                if (En == EnumCED.Create)
                                {
                                    var q1 = db.AazaSandoghs.Where(f => f.IsActive == true).OrderBy(s => s.Code).ToList();
                                    if (q1.Count > 0)
                                        cmbHesabTafzili2.Properties.DataSource = q1;
                                    else
                                        cmbHesabTafzili2.Properties.DataSource = null;
                                }
                                else if (En == EnumCED.Edit)
                                {
                                    var q2 = db.AazaSandoghs.OrderBy(s => s.Code).ToList();
                                    if (q2.Count > 0)
                                        cmbHesabTafzili2.Properties.DataSource = q2;
                                    else
                                        cmbHesabTafzili2.Properties.DataSource = null;
                                }
                                break;
                            }
                        case 3001:
                            {
                                goto case 2001;
                            }
                        case 4001:
                            {
                                goto case 2001;
                            }
                        case 6001:
                            {
                                goto case 2001;
                            }
                        case 6002:
                            {
                                goto case 2001;
                            }
                        case 6003:
                            {
                                goto case 2001;
                            }
                        case 7001:
                            {
                                goto case 2001;
                            }
                        case 8001:
                            {
                                cmbHesabTafzili2.Properties.DisplayMember = "HesabName";
                                cmbHesabTafzili2.Properties.ValueMember = "Code";
                                cmbHesabTafzili2.Properties.Columns[1].FieldName = "HesabName";
                                var q1 = db.CodingDaramadVHazines.Where(s => s.GroupIndex == 0).OrderBy(s => s.Code).ToList();
                                if (q1.Count > 0)
                                    cmbHesabTafzili2.Properties.DataSource = q1;
                                else
                                    cmbHesabTafzili2.Properties.DataSource = null;
                                break;
                            }
                        case 9001:
                            {
                                cmbHesabTafzili2.Properties.DisplayMember = "HesabName";
                                cmbHesabTafzili2.Properties.ValueMember = "Code";
                                cmbHesabTafzili2.Properties.Columns[1].FieldName = "HesabName";
                                var q1 = db.CodingDaramadVHazines.Where(s => s.GroupIndex == 1).OrderBy(s => s.Code).ToList();
                                if (q1.Count > 0)
                                    cmbHesabTafzili2.Properties.DataSource = q1;
                                else
                                    cmbHesabTafzili2.Properties.DataSource = null;
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void NewSeryal()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.DaryaftPardakhtBinHesabhas.Select(s => s);
                    if (q.Any())
                    {
                        var MaximumCod = q.Max(p => p.Seryal);
                        if (MaximumCod.ToString() != "9999999")
                        {
                            txtSeryal.Text = (MaximumCod + 1).ToString();
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                                XtraMessageBox.Show("اعمال محدودیت ثبت حداکثر 9999999 سریال" + "\n" +
                                    "توجه : نمیتوان بیشتر از این تعداد سریال، ثبت نمود ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        txtSeryal.Text = "1";
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //private void DefaultBankVSandogh()
        //{
        //    using (var db = new MyContext())
        //    {
        //        try
        //        {
        //            if (En == EnumCED.Create)
        //            {
        //                var q2 = db.HesabBankis.FirstOrDefault(s => s.IsActive == true && s.IsDefault == true);
        //                if (q2 != null)
        //                    cmbNameHesab.EditValue = q2.Id;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
        //                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        private void FrmDaryaftNaghdiVBanki_Load(object sender, EventArgs e)
        {
            FillDataGridDaryaftPardakhtBinHesabha();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool TextEditValidation()
        {
            if (string.IsNullOrEmpty(txtSeryal.Text))
            {
                XtraMessageBox.Show("فیلد سریال نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeryal.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtTarikh.Text))
            {
                XtraMessageBox.Show("لطفاً تاریخ را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTarikh.Focus();
                return false;
            }
            else if (txtMablagh.Text == "0")
            {
                XtraMessageBox.Show("لطفاً مبلغ را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMablagh.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(cmbHesabMoin1.Text))
            {
                XtraMessageBox.Show("لطفاً حساب معین بدهکار را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabMoin1.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(cmbHesabMoin2.Text))
            {
                XtraMessageBox.Show("لطفاً حساب معین بستانکار را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabMoin2.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(cmbHesabTafzili1.Text))
            {
                XtraMessageBox.Show("لطفاً حساب تفضیل بدهکار را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabTafzili1.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(cmbHesabTafzili2.Text))
            {
                XtraMessageBox.Show("لطفاً حساب تفضیل بستانکار را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabTafzili2.Focus();
                return false;
            }
            return true;
        }

        private void FrmDaryaftNaghdiVBanki_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnCreate_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F3 && btnDelete.Enabled == true)
            {
                btnDelete_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F4 && btnEdit.Enabled == true)
            {
                btnEdit_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F5 && btnSave.Enabled == true)
            {
                btnSave_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F6 && btnCancel.Enabled == true)
            {
                btnCancel_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnDisplayList_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnSaveNext_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F10)
            {
                btnAdvancedSearch_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F11)
            {
                btnPrintPreview_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F12 && btnPrint.Enabled == true)
            {
                btnPrint_Click(sender, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, null);
            }

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            gridView1.MoveLast();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            gridView1.MoveNext();

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            gridView1.MovePrev();

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            gridView1.MoveFirst();
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            HelpClass1.PrintPreview(gridControl1, gridView1);
        }

        public void btnDisplayList_Click(object sender, EventArgs e)
        {
            FillDataGridDaryaftPardakhtBinHesabha();
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEdit_Click(null, null);
            }

        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);
        }

        private void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            gridView1.OptionsFind.AlwaysVisible = gridView1.OptionsFind.AlwaysVisible ? false : true;
        }

        public void InActiveButtons()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                foreach (SimpleButton item in panelControl2.Controls)
                {
                    item.Enabled = false;
                }
                btnSave.Enabled = true;
                btnSaveNext.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;
            }
        }

        public void ActiveButtons()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                foreach (SimpleButton item in panelControl2.Controls)
                {
                    item.Enabled = true;
                }
                btnSave.Enabled = false;
                btnSaveNext.Enabled = false;
                btnCancel.Enabled = false;
            }
        }

        public void ClearControls()
        {
            txtSeryal.Text = string.Empty;
            txtTarikh.Text = string.Empty;
            txtMablagh.Text = string.Empty;
            cmbHesabMoin1.EditValue = 0;
            cmbHesabMoin2.EditValue = 0;
            cmbHesabTafzili1.EditValue = 0;
            cmbHesabTafzili2.EditValue = 0;
            txtSharh.Text = string.Empty;
        }

        public void ActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                txtTarikh.ReadOnly = false;
                txtMablagh.ReadOnly = false;
                cmbHesabMoin1.ReadOnly = false;
                cmbHesabMoin2.ReadOnly = false;
                cmbHesabTafzili1.ReadOnly = false;
                cmbHesabTafzili2.ReadOnly = false;
                txtSharh.ReadOnly = false;
            }
            FillcmbHesabMoin();
        }

        public void InActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                txtTarikh.ReadOnly = true;
                txtMablagh.ReadOnly = true;
                cmbHesabMoin1.ReadOnly = true;
                cmbHesabMoin2.ReadOnly = true;
                cmbHesabTafzili1.ReadOnly = true;
                cmbHesabTafzili2.ReadOnly = true;
                txtSharh.ReadOnly = true;
            }
        }

        public int EditRowIndex = 0;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            En = EnumCED.Create;
            InActiveButtons();
            ClearControls();
            NewSeryal();
            ActiveControls();
            txtTarikh.Text = DateTime.Now.ToString().Substring(0, 10);
            gridControl1.Enabled = false;
            //DefaultBankVSandogh();
            txtTarikh.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (XtraMessageBox.Show("آیا عملیات فوق حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    EditRowIndex = gridView1.FocusedRowHandle;
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                            var q = db.DaryaftPardakhtBinHesabhas.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                db.DaryaftPardakhtBinHesabhas.Remove(q);
                                ///////////////////////////////////////////////////////////////////
                                var q1 = db.AsnadeHesabdariRows.Where(f => f.ShomareSanad == q.ShomareSanad);
                                if (q1.Count() > 0)
                                    db.AsnadeHesabdariRows.RemoveRange(q1);
                                /////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();

                                btnDisplayList_Click(null, null);
                                XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex - 1;
                            }
                            else
                                XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //catch (DbUpdateException)
                        //{
                        //    XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این حساب مقدور نیست \n" +
                        //        " جهت حذف حساب مورد نظر در ابتدا بایستی زیر شاخه های این حساب یعنی پس انداز ماهیانه اعضاء،\n وامهای دریافتی اعضا،ریز اقساط وام، انتقالی بین حسابها، سند های درآمد و هزینه ، و سایر دریافتها و\n پرداختها مربوط به این حساب در صورت وجود حذف گردد" +
                        //        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && btnEdit.Visible == true)
            {
                gridControl1.Enabled = false;
                EditRowIndex = gridView1.FocusedRowHandle;
                En = EnumCED.Edit;
                InActiveButtons();
                ActiveControls();

                txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                txtSeryal.Text = gridView1.GetFocusedRowCellValue("Seryal").ToString();
                if (gridView1.GetFocusedRowCellValue("Tarikh") != null)
                    txtTarikh.Text = gridView1.GetFocusedRowCellValue("Tarikh").ToString().Substring(0, 10); ;
                txtMablagh.Text = gridView1.GetFocusedRowCellValue("Mablagh").ToString();
                cmbHesabMoin1.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabMoinCode1"));
                cmbHesabTafzili1.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabTafziliCode1"));
                cmbHesabMoin2.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabMoinCode2"));
                cmbHesabTafzili2.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabTafziliCode2"));
                txtSharh.Text = gridView1.GetFocusedRowCellValue("Sharh").ToString();

                txtTarikh.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (TextEditValidation())
            {
                if (En == EnumCED.Create)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            var q2 = db.AsnadeHesabdariRows.Any() ? db.AsnadeHesabdariRows.Max(f => f.ShomareSanad) : 0;
                            DaryaftPardakhtBinHesabha obj = new DaryaftPardakhtBinHesabha();
                            obj.Seryal = Convert.ToInt32(txtSeryal.Text);
                            if (!string.IsNullOrEmpty(txtTarikh.Text))
                                obj.Tarikh = Convert.ToDateTime(txtTarikh.Text);
                            if (txtMablagh.Text != "0")
                            {
                                obj.Mablagh = Convert.ToDecimal(txtMablagh.Text);
                                obj.HesabMoinCode1 = Convert.ToInt32(cmbHesabMoin1.EditValue);
                                obj.HesabMoineName1 = cmbHesabMoin1.Text;
                                obj.HesabMoinCode2 = Convert.ToInt32(cmbHesabMoin2.EditValue);
                                obj.HesabMoineName2 = cmbHesabMoin2.Text;
                                obj.HesabTafziliCode1 = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                                obj.HesabTafziliName1 = cmbHesabTafzili1.Text;
                                obj.HesabTafziliCode2 = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                                obj.HesabTafziliName2 = cmbHesabTafzili2.Text;
                            }
                            obj.Sharh = txtSharh.Text;
                            obj.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                            obj.ShomareSanad = q2 + 1;
                            db.DaryaftPardakhtBinHesabhas.Add(obj);
                            //////////////////////////////////////////////////////////////////////////////////////////
                            int _HesabTafziliCode1 = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                            AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
                            obj1.ShomareSanad = q2 + 1;
                            obj1.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
                            obj1.MoinCode = Convert.ToInt32(cmbHesabMoin1.EditValue);
                            obj1.MoinName = cmbHesabMoin1.Text; ;
                            obj1.HesabTafCode = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                            obj1.HesabTafName = cmbHesabTafzili1.Text;
                            obj1.Bed = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                            obj1.Sharh = txtSharh.Text;
                            obj1.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                            db.AsnadeHesabdariRows.Add(obj1);

                            int _HesabTafziliCode2 = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                            AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
                            obj2.ShomareSanad = q2 + 1;
                            obj2.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
                            obj2.MoinCode = Convert.ToInt32(cmbHesabMoin2.EditValue);
                            obj2.MoinName = cmbHesabMoin2.Text;
                            //obj2.HesabTafId = _HesabTafziliCode2;
                            obj2.HesabTafCode = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                            obj2.HesabTafName = cmbHesabTafzili2.Text;
                            obj2.Bes = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                            obj2.Sharh = txtSharh.Text;
                            obj2.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                            db.AsnadeHesabdariRows.Add(obj2);
                            ///////////////////////////////////////////////////////////////////////////////
                            db.SaveChanges();
                            btnDisplayList_Click(null, null);

                            //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                            gridControl1.Enabled = true;
                            gridView1.MoveLast();
                            ActiveButtons();
                            ClearControls();
                            InActiveControls();
                            En = EnumCED.Save;
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.ToString(), "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (En == EnumCED.Edit)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.DaryaftPardakhtBinHesabhas.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                if (!string.IsNullOrEmpty(txtTarikh.Text))
                                    q.Tarikh = Convert.ToDateTime(txtTarikh.Text);
                                if (txtMablagh.Text != "0")
                                {
                                    q.Mablagh = Convert.ToDecimal(txtMablagh.Text);
                                    q.HesabMoinCode1 = Convert.ToInt32(cmbHesabMoin1.EditValue);
                                    q.HesabMoineName1 = cmbHesabMoin1.Text;
                                    q.HesabMoinCode2 = Convert.ToInt32(cmbHesabMoin2.EditValue);
                                    q.HesabMoineName2 = cmbHesabMoin2.Text;
                                    q.HesabTafziliCode1 = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                                    q.HesabTafziliName1 = cmbHesabTafzili1.Text;
                                    q.HesabTafziliCode2 = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                                    q.HesabTafziliName2 = cmbHesabTafzili2.Text;
                                }
                                q.Sharh = txtSharh.Text;
                                /////////////////////////////////////////////////////////////////////////////////////
                                var q2 = db.AsnadeHesabdariRows.Where(f => f.ShomareSanad == q.ShomareSanad);
                                if (q2.Count() > 0)
                                    db.AsnadeHesabdariRows.RemoveRange(q2);


                                int _HesabTafziliCode1 = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                                AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
                                obj1.ShomareSanad = q.ShomareSanad;
                                obj1.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
                                obj1.MoinCode = Convert.ToInt32(cmbHesabMoin1.EditValue);
                                obj1.MoinName = cmbHesabMoin1.Text; ;
                                obj1.HesabTafCode = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                                obj1.HesabTafName = cmbHesabTafzili1.Text;
                                obj1.Bed = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                                obj1.Sharh = txtSharh.Text;
                                obj1.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                                db.AsnadeHesabdariRows.Add(obj1);

                                int _HesabTafziliCode2 = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                                AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
                                obj2.ShomareSanad = q.ShomareSanad;
                                obj2.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
                                obj2.MoinCode = Convert.ToInt32(cmbHesabMoin2.EditValue);
                                obj2.MoinName = cmbHesabMoin2.Text;
                                //obj2.HesabTafId = _HesabTafziliCode2;
                                obj2.HesabTafCode = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                                obj2.HesabTafName = cmbHesabTafzili2.Text;
                                obj2.Bes = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                                obj2.Sharh = txtSharh.Text;
                                obj2.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                                db.AsnadeHesabdariRows.Add(obj2);
                                /////////////////////////////////////////////////////////////
                                db.SaveChanges();
                                btnDisplayList_Click(null, null);

                                //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex;
                                gridControl1.Enabled = true;
                                ActiveButtons();
                                ClearControls();
                                InActiveControls();
                                En = EnumCED.Save;
                            }
                            else
                                XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gridControl1.Enabled = true;
            ActiveButtons();
            ClearControls();
            InActiveControls();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridView1_RowCellClick(null, null);
        }

        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
            if (En == EnumCED.Save)
                btnCreate_Click(null, null);
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            btnDelete.Enabled = btnEdit.Enabled = gridView1.RowCount > 0 ? true : false;
        }

        private void cmbHesabMoin1_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbHesabMoin1.ShowPopup();
            }
        }
        private void cmbHesabMoin2_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbHesabMoin2.ShowPopup();
            }
        }
        private void cmbHesabTafzili1_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbHesabTafzili1.ShowPopup();
            }
        }
        private void cmbHesabTafzili2_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbHesabTafzili2.ShowPopup();
            }
        }

        private void cmbHesabMoin1_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbHesabTafzili1();
        }

        private void cmbHesabMoin2_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbHesabTafzili2();
        }

        //string _PardakhtKonandeName = string.Empty;
        //string _GroupHesab = string.Empty;
        //string Text1 = "دریافت";
        //string Text2 = " از ";
        //private void cmbPardakhtKonande_EditValueChanged(object sender, EventArgs e)
        //{
        //    txtMablagh_EditValueChanged(null, null);
        //}

        //private void txtMablagh_EditValueChanged(object sender, EventArgs e)
        //{
        //    _PardakhtKonandeName = cmbPardakhtKonande.Text;
        //    if (!string.IsNullOrEmpty(txtMablagh.Text) && txtMablagh.Text != "0")
        //    {
        //        using (var db = new MyContext())
        //        {
        //            try
        //            {
        //                if (Convert.ToInt32(cmbNameHesab.EditValue) != 0)
        //                {
        //                    int _HesabId = Convert.ToInt32(cmbNameHesab.EditValue);
        //                    var q = db.HesabBankis.FirstOrDefault(f => f.Id == _HesabId);
        //                    if (q != null)
        //                    {
        //                        _GroupHesab = " " + q.GroupHesab;
        //                        txtSharh.Text = Text1 + _GroupHesab + Text2 + _PardakhtKonandeName;
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
        //                    "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }

        //    }
        //    else
        //    {
        //        _GroupHesab = "";
        //        txtSharh.Text = Text1 + _GroupHesab + Text2 + _PardakhtKonandeName;
        //    }
        //}

        //private void cmbNameHesab_EditValueChanged(object sender, EventArgs e)
        //{
        //    txtMablagh_EditValueChanged(null, null);
        //}

    }
}