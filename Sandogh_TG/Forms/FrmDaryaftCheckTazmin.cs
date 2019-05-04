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
    public partial class FrmDaryaftCheckTazmin : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmDaryaftCheckTazmin(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        FrmVamPardakhti Am;
        public FrmDaryaftCheckTazmin(FrmVamPardakhti am)
        {
            InitializeComponent();
            Am = am;
        }
        public EnumCED En;
        public bool IsCheckInSandogh = true;

        private void cmbNoeSanad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNoeSanad.SelectedIndex == 0 || cmbNoeSanad.SelectedIndex == -1)
            {
                labelControl4.Text = "شماره چک";
                labelControl14.Text = "تاریخ چک";
                labelControl19.Text = "مبلغ چک";
                labelControl8.Text = "صاحب چک";
                txtShomareHesab.ReadOnly = false;
            }
            else
            {
                labelControl4.Text = "شماره سفته";
                labelControl14.Text = "تاریخ سفته";
                labelControl19.Text = "مبلغ سفته";
                labelControl8.Text = "ضامن سفته";
                txtShomareHesab.ReadOnly = true;
            }
        }

        public void FillDataGridCheckTazmin()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (IsCheckInSandogh == true)
                    {
                        var q1 = db.CheckTazmins.Where(s => s.IsInSandogh == true).OrderBy(s => s.SeryalDaryaft).ToList();
                        if (q1.Count > 0)
                            checkTazminsBindingSource.DataSource = q1;
                        else
                            checkTazminsBindingSource.DataSource = null;
                    }
                    else
                    {
                        var q = db.CheckTazmins.Where(s => s.IsInSandogh == false).OrderBy(s => s.SeryalDaryaft);
                        if (q.Count() > 0)
                            checkTazminsBindingSource.DataSource = q.ToList();
                        else
                            checkTazminsBindingSource.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbVamGerande()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (En == EnumCED.Create)
                    {
                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 3 && IsActive == true).ToList();
                        if (q1.Count > 0)
                            allHesabTafzilisBindingSource.DataSource = q1;
                        else
                            allHesabTafzilisBindingSource.DataSource = null;
                    }
                    else
                    {
                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 3).ToList();
                        if (q1.Count > 0)
                            allHesabTafzilisBindingSource.DataSource = q1;
                        else
                            allHesabTafzilisBindingSource.DataSource = null;
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
                    var q = db.CheckTazmins.Select(s => s);
                    if (q.Any())
                    {
                        var MaximumCod = q.Max(p => p.SeryalDaryaft);
                        if (MaximumCod.ToString() != "9999999")
                        {
                            txtSeryalDaryaft.Text = (MaximumCod + 1).ToString();
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                                XtraMessageBox.Show("اعمال محدودیت ثبت حداکثر 9999999 سریال دریافت" + "\n" +
                                    "توجه : نمیتوان بیشتر از این تعداد ثبت نمود ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        txtSeryalDaryaft.Text = "1";
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmDaryaftCheckTazmin_Load(object sender, EventArgs e)
        {
            FillDataGridCheckTazmin();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool TextEditValidation()
        {
            if (string.IsNullOrEmpty(txtSeryalDaryaft.Text))
            {
                XtraMessageBox.Show("فیلد سریال دریافت نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeryalDaryaft.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtTarikhDaryaft.Text))
            {
                XtraMessageBox.Show("فیلد تاریخ نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTarikhDaryaft.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(cmbVamGerande.Text))
            {
                XtraMessageBox.Show("لطفا نام وام گیرنده را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVamGerande.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(cmbNoeSanad.Text))
            {
                XtraMessageBox.Show("لطفا نوع سند را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbNoeSanad.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtShCheck.Text))
            {
                XtraMessageBox.Show("لطفا شماره چک/سفته را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtShCheck.Focus();
                return false;
            }
            return true;
        }

        private void FrmDaryaftCheckTazmin_KeyDown(object sender, KeyEventArgs e)
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
                btnDisplayCheckInSandogh_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnDisplayCheckOdatShode_Click(sender, null);
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

        public void btnDisplayCheckInSandogh_Click(object sender, EventArgs e)
        {
            IsCheckInSandogh = true;
            FillDataGridCheckTazmin();
            btnCreate.Visible = btnDelete.Visible = btnEdit.Visible = btnSave.Visible = btnSaveNext.Visible = btnCancel.Visible = true;
        }

        public void btnDisplayCheckOdatShode_Click(object sender, EventArgs e)
        {
            IsCheckInSandogh = false;
            FillDataGridCheckTazmin();
            btnCreate.Visible = btnDelete.Visible = btnEdit.Visible = btnSave.Visible = btnSaveNext.Visible = btnCancel.Visible = false;
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
            txtSeryalDaryaft.Text = string.Empty;
            txtTarikhDaryaft.Text = string.Empty;
            cmbVamGerande.EditValue = 0;
            cmbNoeSanad.SelectedIndex = -1;
            txtShCheck.Text = string.Empty;
            txtTarikhCheck.Text = string.Empty;
            txtMamlaghCheck.Text = string.Empty;
            txtShomareHesab.Text = string.Empty;
            txtNameBankVShobe.Text = string.Empty;
            txtSahebCheck.Text = string.Empty;
            txtSharhSanad.Text = string.Empty;
        }

        public void ActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                cmbVamGerande.ReadOnly = false;
                txtTarikhDaryaft.ReadOnly = false;
                cmbNoeSanad.ReadOnly = false;
                txtShCheck.ReadOnly = false;
                txtTarikhCheck.ReadOnly = false;
                txtMamlaghCheck.ReadOnly = false;
                txtShomareHesab.ReadOnly = false;
                txtNameBankVShobe.ReadOnly = false;
                txtSahebCheck.ReadOnly = false;
                txtSharhSanad.ReadOnly = false;
            }
            FillcmbVamGerande();

        }

        public void InActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                cmbVamGerande.ReadOnly = true;
                txtTarikhDaryaft.ReadOnly = true;
                cmbNoeSanad.ReadOnly = true;
                txtShCheck.ReadOnly = true;
                txtTarikhCheck.ReadOnly = true;
                txtMamlaghCheck.ReadOnly = true;
                txtShomareHesab.ReadOnly = true;
                txtNameBankVShobe.ReadOnly = true;
                txtSahebCheck.ReadOnly = true;
                txtSharhSanad.ReadOnly = true;
            }
        }

        public int EditRowIndex = 0;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            En = EnumCED.Create;
            InActiveButtons();
            ClearControls();
            cmbVamGerande.EditValue = 0;
            cmbNoeSanad.SelectedIndex = 0;
            NewSeryal();
            ActiveControls();
            txtTarikhDaryaft.Text = DateTime.Now.ToString().Substring(0, 10);
            gridControl1.Enabled = false;
            txtTarikhDaryaft.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (XtraMessageBox.Show("آیا دریافت فوق حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    EditRowIndex = gridView1.FocusedRowHandle;
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                            var q = db.CheckTazmins.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                db.CheckTazmins.Remove(q);
                                /////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();

                                btnDisplayCheckInSandogh_Click(null, null);
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
                txtSeryalDaryaft.Text = gridView1.GetFocusedRowCellValue("SeryalDaryaft").ToString();
                txtTarikhDaryaft.Text = gridView1.GetFocusedRowCellValue("TarikhDaryaft").ToString().Substring(0, 10); ;
                cmbVamGerande.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("VamGerandeId"));
                cmbNoeSanad.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("NoeSanadId"));
                txtShCheck.Text = gridView1.GetFocusedRowCellValue("ShCheck").ToString();
                if (gridView1.GetFocusedRowCellValue("TarikhCheck") != null)
                    txtTarikhCheck.Text = gridView1.GetFocusedRowCellValue("TarikhCheck").ToString().Substring(0, 10);
                txtMamlaghCheck.Text = gridView1.GetFocusedRowCellValue("Mablagh").ToString();
                txtShomareHesab.Text = gridView1.GetFocusedRowCellValue("ShomareHesab").ToString();
                txtNameBankVShobe.Text = gridView1.GetFocusedRowCellValue("NameBank").ToString();
                txtSahebCheck.Text = gridView1.GetFocusedRowCellValue("SahebCheck").ToString();
                txtSharhSanad.Text = gridView1.GetFocusedRowCellValue("SharhDaryaftCheck").ToString();

                txtTarikhDaryaft.Focus();
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
                            CheckTazmin obj = new CheckTazmin();
                            obj.SeryalDaryaft = Convert.ToInt32(txtSeryalDaryaft.Text);
                            if (!string.IsNullOrEmpty(txtTarikhDaryaft.Text))
                                obj.TarikhDaryaft = Convert.ToDateTime(txtTarikhDaryaft.Text);
                            obj.VamGerandeId = Convert.ToInt32(cmbVamGerande.EditValue);
                            obj.VamGerandeName = cmbVamGerande.Text;
                            obj.NoeSanadId = cmbNoeSanad.SelectedIndex;
                            obj.NoeSanad = cmbNoeSanad.Text;
                            obj.ShCheck = txtShCheck.Text;
                            if (!string.IsNullOrEmpty(txtTarikhCheck.Text))
                                obj.TarikhCheck = Convert.ToDateTime(txtTarikhCheck.Text);
                            obj.Mablagh = !string.IsNullOrEmpty(txtMamlaghCheck.Text) ? Convert.ToDecimal(txtMamlaghCheck.Text) : 0;
                            obj.ShomareHesab = txtShomareHesab.Text;
                            obj.NameBank = txtNameBankVShobe.Text;
                            obj.SahebCheck = txtSahebCheck.Text;
                            obj.SharhDaryaftCheck = txtSharhSanad.Text;
                            obj.VaziyatCheck = "نزد صندوق";
                            obj.IsInSandogh = true;
                            if (Application.OpenForms["FrmVamPardakhti"] == null)
                                obj.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                            else
                                obj.SalMaliId = Convert.ToInt32(Am.Fm.Fm.IDSalMali.Caption);

                            db.CheckTazmins.Add(obj);
                            db.SaveChanges();
                            btnDisplayCheckInSandogh_Click(null, null);

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
                            var q = db.CheckTazmins.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                if (!string.IsNullOrEmpty(txtTarikhDaryaft.Text))
                                    q.TarikhDaryaft = Convert.ToDateTime(txtTarikhDaryaft.Text);
                                q.VamGerandeId = Convert.ToInt32(cmbVamGerande.EditValue);
                                q.VamGerandeName = cmbVamGerande.Text;
                                q.NoeSanadId = cmbNoeSanad.SelectedIndex;
                                q.NoeSanad = cmbNoeSanad.Text;
                                q.ShCheck = txtShCheck.Text;
                                if (!string.IsNullOrEmpty(txtTarikhCheck.Text))
                                    q.TarikhCheck = Convert.ToDateTime(txtTarikhCheck.Text);
                                q.Mablagh = !string.IsNullOrEmpty(txtMamlaghCheck.Text) ? Convert.ToDecimal(txtMamlaghCheck.Text) : 0;
                                q.ShomareHesab = txtShomareHesab.Text;
                                q.NameBank = txtNameBankVShobe.Text;
                                q.SahebCheck = txtSahebCheck.Text;
                                q.SharhDaryaftCheck = txtSharhSanad.Text;

                                db.SaveChanges();
                                btnDisplayCheckInSandogh_Click(null, null);

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
            //gridView1_RowCellClick(null, null);
            btnDelete.Enabled = btnEdit.Enabled = gridView1.RowCount > 0 ? true : false;
        }

        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
            if (En == EnumCED.Save)
                btnCreate_Click(null, null);
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
        }

        private void FrmDaryaftCheckTazmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["FrmVamPardakhti"] != null)
            {
                Am.FillDataGridCheckTazmin();
            }
        }

        private void cmbVamGerande_Enter(object sender, EventArgs e)
        {
            cmbVamGerande.ShowPopup();
        }

        private void cmbNoeSanad_Enter(object sender, EventArgs e)
        {
            cmbNoeSanad.ShowPopup();

        }

        private void txtShCheck_EditValueChanged(object sender, EventArgs e)
        {
            txtSharhSanad.Text = "بابت دریافت " + cmbNoeSanad.Text + " تضمین به شماره " + txtShCheck.Text;

        }
    }
}