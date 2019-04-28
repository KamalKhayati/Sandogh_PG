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
    public partial class FrmPardakhtNaghdiVBanki : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmPardakhtNaghdiVBanki(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        #region MyRegion
        public EnumCED En;
        //public bool IsCheckInSandogh = true;

        public void FillDataGridPardakhtNaghdiVBanki()
        {
            //using (var db = new MyContext())
            //{
            //    try
            //    {
            //        var q1 = db.PardakhtNaghdiVBankis.OrderBy(s => s.Seryal).ToList();
            //        if (q1.Count > 0)
            //            pardakhtNaghdiVBankisBindingSource.DataSource = q1;
            //        else
            //            pardakhtNaghdiVBankisBindingSource.DataSource = null;
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
            //            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

        }

        public void FillcmbDaryaftKonande()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q1 = db.AazaSandoghs.Select(s => s).ToList();
                    if (q1.Count > 0)
                        aazaSandoghsBindingSource.DataSource = q1;
                    else
                        aazaSandoghsBindingSource.DataSource = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbNameHesab()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (En == EnumCED.Create)
                    {
                        var q1 = db.HesabBankis.Where(f => f.IsActive == true).ToList();
                        if (q1.Count > 0)
                            hesabBankisBindingSource.DataSource = q1;
                        else
                            hesabBankisBindingSource.DataSource = null;

                    }
                    else
                    {
                        var q1 = db.HesabBankis.Select(f => f).ToList();
                        if (q1.Count > 0)
                            hesabBankisBindingSource.DataSource = q1;
                        else
                            hesabBankisBindingSource.DataSource = null;

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
            //using (var db = new MyContext())
            //{
            //    try
            //    {
            //        var q = db.PardakhtNaghdiVBankis.Select(s => s);
            //        if (q.Any())
            //        {
            //            var MaximumCod = q.Max(p => p.Seryal);
            //            if (MaximumCod.ToString() != "9999999")
            //            {
            //                txtSeryal.Text = (MaximumCod + 1).ToString();
            //            }
            //            else
            //            {
            //                if (En == EnumCED.Create)
            //                    XtraMessageBox.Show("اعمال محدودیت ثبت حداکثر 9999999 سریال پرداخت" + "\n" +
            //                        "توجه : نمیتوان بیشتر از این تعداد پرداختی ثبت نمود ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            }

            //        }
            //        else
            //        {
            //            txtSeryal.Text = "1";
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void DefaultBankVSandogh()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (En == EnumCED.Create)
                    {
                        var q2 = db.HesabBankis.FirstOrDefault(s => s.IsActive == true && s.IsDefault == true);
                        if (q2 != null)
                            cmbNameHesab.EditValue = q2.Id;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmPardakhtNaghdiVBanki_Load(object sender, EventArgs e)
        {
            FillDataGridPardakhtNaghdiVBanki();
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
            else if (string.IsNullOrEmpty(cmbDaryaftKonande.Text))
            {
                XtraMessageBox.Show("لطفاً نام دریافت کننده را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDaryaftKonande.Focus();
                return false;
            }
            else if (txtMablagh.Text == "0")
            {
                XtraMessageBox.Show("لطفاً مبلغ را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMablagh.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(cmbNameHesab.Text))
            {
                XtraMessageBox.Show("لطفا نام بانک / صندوق را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbNameHesab.Focus();
                return false;
            }
            return true;
        }

        private void FrmPardakhtNaghdiVBanki_KeyDown(object sender, KeyEventArgs e)
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
            FillDataGridPardakhtNaghdiVBanki();
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
            cmbDaryaftKonande.EditValue = 0;
            txtMablagh.Text = string.Empty;
            cmbNameHesab.EditValue = 0;
            txtSharh.Text = string.Empty;
        }

        public void ActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                txtTarikh.ReadOnly = false;
                cmbDaryaftKonande.ReadOnly = false;
                txtMablagh.ReadOnly = false;
                cmbNameHesab.ReadOnly = false;
                txtSharh.ReadOnly = false;
            }
            FillcmbDaryaftKonande();
            FillcmbNameHesab();
        }

        public void InActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                txtTarikh.ReadOnly = true;
                cmbDaryaftKonande.ReadOnly = true;
                txtMablagh.ReadOnly = true;
                cmbNameHesab.ReadOnly = true;
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
            DefaultBankVSandogh();
            txtTarikh.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (gridView1.SelectedRowsCount > 0)
            //{
            //    if (XtraMessageBox.Show("آیا پرداخت فوق حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //    {
            //        EditRowIndex = gridView1.FocusedRowHandle;
            //        using (var db = new MyContext())
            //        {
            //            try
            //            {
            //                int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
            //                var q = db.PardakhtNaghdiVBankis.FirstOrDefault(p => p.Id == RowId);
            //                if (q != null)
            //                {
            //                    db.PardakhtNaghdiVBankis.Remove(q);
            //                    ///////////////////////////////////////////////////////////////////
            //                    var q1 = db.AsnadeHesabdariRows.Where(f => f.ShomareSanad == q.ShomareSanad);
            //                    if (q1.Count() > 0)
            //                        db.AsnadeHesabdariRows.RemoveRange(q1);
            //                    /////////////////////////////////////////////////////////////////////////////
            //                    db.SaveChanges();

            //                    btnDisplayList_Click(null, null);
            //                    XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            //                    if (gridView1.RowCount > 0)
            //                        gridView1.FocusedRowHandle = EditRowIndex - 1;
            //                }
            //                else
            //                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //            //catch (DbUpdateException)
            //            //{
            //            //    XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این حساب مقدور نیست \n" +
            //            //        " جهت حذف حساب مورد نظر در ابتدا بایستی زیر شاخه های این حساب یعنی پس انداز ماهیانه اعضاء،\n وامهای دریافتی اعضا،ریز اقساط وام، انتقالی بین حسابها، سند های درآمد و هزینه ، و سایر دریافتها و\n پرداختها مربوط به این حساب در صورت وجود حذف گردد" +
            //            //        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            //}
            //            catch (Exception ex)
            //            {
            //                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //    }
            //}
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
                cmbDaryaftKonande.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("DaryaftkonandeId"));
                txtMablagh.Text = gridView1.GetFocusedRowCellValue("Mablagh").ToString();
                cmbNameHesab.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabId"));
                txtSharh.Text = gridView1.GetFocusedRowCellValue("Sharh").ToString();

                txtTarikh.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (TextEditValidation())
            //{
            //    if (En == EnumCED.Create)
            //    {
            //        using (var db = new MyContext())
            //        {
            //            try
            //            {
            //                var q2 = db.AsnadeHesabdariRows.Any() ? db.AsnadeHesabdariRows.Max(f => f.ShomareSanad) : 0;
            //                PardakhtNaghdiVBanki obj = new PardakhtNaghdiVBanki();
            //                obj.Seryal = Convert.ToInt32(txtSeryal.Text);
            //                if (!string.IsNullOrEmpty(txtTarikh.Text))
            //                    obj.Tarikh = Convert.ToDateTime(txtTarikh.Text);
            //                obj.DaryaftkonandeId = Convert.ToInt32(cmbDaryaftKonande.EditValue);
            //                obj.DaryaftkonandeName = cmbDaryaftKonande.Text;
            //                if (txtMablagh.Text != "0")
            //                {
            //                    obj.Mablagh = Convert.ToDecimal(txtMablagh.Text);
            //                    obj.HesabId = Convert.ToInt32(cmbNameHesab.EditValue);
            //                    obj.HesabName = cmbNameHesab.Text;
            //                }
            //                obj.Sharh = txtSharh.Text;
            //                obj.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
            //                obj.ShomareSanad = q2 + 1;
            //                db.PardakhtNaghdiVBankis.Add(obj);
            //                //////////////////////////////////////////////////////////////////////////////////////////
            //                int _HesabId2 = Convert.ToInt32(cmbDaryaftKonande.EditValue);
            //                AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
            //                obj2.ShomareSanad = q2 + 1;
            //                obj2.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
            //                obj2.MoinCode = 2001;
            //                obj2.MoinName = db.CodeMoins.FirstOrDefault(f => f.Code == 2001).Name;
            //                obj2.HesabTafId = _HesabId2;
            //                obj2.HesabTafCode = db.AazaSandoghs.FirstOrDefault(f => f.Id == _HesabId2).Code;
            //                obj2.HesabTafName = cmbDaryaftKonande.Text;
            //                obj2.Bed = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
            //                obj2.Sharh = txtSharh.Text;
            //                obj2.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
            //                db.AsnadeHesabdariRows.Add(obj2);

            //                int _HesabId1 = Convert.ToInt32(cmbNameHesab.EditValue);
            //                AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
            //                obj1.ShomareSanad = q2 + 1;
            //                obj1.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
            //                obj1.MoinCode = 1001;
            //                obj1.MoinName = db.CodeMoins.FirstOrDefault(f => f.Code == 1001).Name;
            //                obj1.HesabTafId = _HesabId1;
            //                obj1.HesabTafCode = db.HesabBankis.FirstOrDefault(f => f.Id == _HesabId1).Code;
            //                obj1.HesabTafName = cmbNameHesab.Text;
            //                obj1.Bes = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
            //                obj1.Sharh = txtSharh.Text;
            //                obj1.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
            //                db.AsnadeHesabdariRows.Add(obj1);

            //                ///////////////////////////////////////////////////////////////////////////////

            //                db.SaveChanges();
            //                btnDisplayList_Click(null, null);

            //                //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            //                gridControl1.Enabled = true;
            //                gridView1.MoveLast();
            //                ActiveButtons();
            //                ClearControls();
            //                InActiveControls();
            //                En = EnumCED.Save;
            //            }
            //            catch (Exception ex)
            //            {
            //                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.ToString(), "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //    }
            //    else if (En == EnumCED.Edit)
            //    {
            //        using (var db = new MyContext())
            //        {
            //            try
            //            {
            //                int RowId = Convert.ToInt32(txtId.Text);
            //                var q = db.PardakhtNaghdiVBankis.FirstOrDefault(p => p.Id == RowId);
            //                if (q != null)
            //                {
            //                    if (!string.IsNullOrEmpty(txtTarikh.Text))
            //                        q.Tarikh = Convert.ToDateTime(txtTarikh.Text);
            //                    q.DaryaftkonandeId = Convert.ToInt32(cmbDaryaftKonande.EditValue);
            //                    q.DaryaftkonandeName = cmbDaryaftKonande.Text;
            //                    if (txtMablagh.Text != "0")
            //                    {
            //                        q.Mablagh = Convert.ToDecimal(txtMablagh.Text);
            //                        q.HesabId = Convert.ToInt32(cmbNameHesab.EditValue);
            //                        q.HesabName = cmbNameHesab.Text;
            //                    }
            //                    q.Sharh = txtSharh.Text;
            //                    /////////////////////////////////////////////////////////////////////////////////////
            //                    var q2 = db.AsnadeHesabdariRows.Where(f => f.ShomareSanad == q.ShomareSanad);
            //                    if (q2.Count() > 0)
            //                        db.AsnadeHesabdariRows.RemoveRange(q2);

            //                    int _HesabId2 = Convert.ToInt32(cmbDaryaftKonande.EditValue);
            //                    AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
            //                    obj2.ShomareSanad = q.ShomareSanad;
            //                    obj2.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
            //                    obj2.MoinCode = 2001;
            //                    obj2.MoinName = db.CodeMoins.FirstOrDefault(f => f.Code == 2001).Name;
            //                    obj2.HesabTafId = _HesabId2;
            //                    obj2.HesabTafCode = db.AazaSandoghs.FirstOrDefault(f => f.Id == _HesabId2).Code;
            //                    obj2.HesabTafName = cmbDaryaftKonande.Text;
            //                    obj2.Bes = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
            //                    obj2.Sharh = txtSharh.Text;
            //                    obj2.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
            //                    db.AsnadeHesabdariRows.Add(obj2);

            //                    int _HesabId1 = Convert.ToInt32(cmbNameHesab.EditValue);
            //                    AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
            //                    obj1.ShomareSanad = q.ShomareSanad;
            //                    obj1.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
            //                    obj1.MoinCode = 1001;
            //                    obj1.MoinName = db.CodeMoins.FirstOrDefault(f => f.Code == 1001).Name;
            //                    obj1.HesabTafId = _HesabId1;
            //                    obj1.HesabTafCode = db.HesabBankis.FirstOrDefault(f => f.Id == _HesabId1).Code;
            //                    obj1.HesabTafName = cmbNameHesab.Text;
            //                    obj1.Bed = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
            //                    obj1.Sharh = txtSharh.Text;
            //                    obj1.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
            //                    db.AsnadeHesabdariRows.Add(obj1);

            //                    /////////////////////////////////////////////////////////////

            //                    db.SaveChanges();
            //                    btnDisplayList_Click(null, null);

            //                    //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            //                    if (gridView1.RowCount > 0)
            //                        gridView1.FocusedRowHandle = EditRowIndex;
            //                    gridControl1.Enabled = true;
            //                    ActiveButtons();
            //                    ClearControls();
            //                    InActiveControls();
            //                    En = EnumCED.Save;
            //                }
            //                else
            //                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //            catch (Exception ex)
            //            {
            //                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //    }
            //}
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

        private void cmbDaryaftKonande_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbDaryaftKonande.ShowPopup();
            }

        }

        string _DaryaftKonandeName = string.Empty;
        string _GroupHesab = string.Empty;
        string Text1 = "پرداخت";
        string Text2 = " به ";
        private void cmbDaryaftKonande_EditValueChanged(object sender, EventArgs e)
        {
            txtMablagh_EditValueChanged(null, null);
        }

        private void txtMablagh_EditValueChanged(object sender, EventArgs e)
        {
            _DaryaftKonandeName = cmbDaryaftKonande.Text;
            if (!string.IsNullOrEmpty(txtMablagh.Text) && txtMablagh.Text != "0")
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (Convert.ToInt32(cmbNameHesab.EditValue) != 0)
                        {
                            int _HesabId = Convert.ToInt32(cmbNameHesab.EditValue);
                            var q = db.HesabBankis.FirstOrDefault(f => f.Id == _HesabId);
                            if (q != null)
                            {
                                _GroupHesab = " " + q.GroupHesab;
                                txtSharh.Text = Text1 + _GroupHesab + Text2 + _DaryaftKonandeName;
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
            else
            {
                _GroupHesab = "";
                txtSharh.Text = Text1 + _GroupHesab + Text2 + _DaryaftKonandeName;
            }
        }

        private void cmbNameHesab_EditValueChanged(object sender, EventArgs e)
        {
            txtMablagh_EditValueChanged(null, null);

        }
        #endregion
    }
}