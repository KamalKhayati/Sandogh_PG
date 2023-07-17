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
using Sandogh_PG;
using System.Data.Entity.Infrastructure;

namespace Sandogh_PG
{
    public partial class FrmTarifHesabBanki : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmTarifHesabBanki(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        private void cmbGroupHesab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGroupHesab.SelectedIndex == 0)
            {
                labelControl5.Text = "نام صندوق";
                ActiveControls();
                txtNameShobe.ReadOnly = true;
                txtCodeShobe.ReadOnly = true;
                txtNoeHesab.ReadOnly = true;
                txtShomareHesab.ReadOnly = true;
                txtShomareKart.ReadOnly = true;
                txtShomareShaba.ReadOnly = true;
                txtShomareMoshtari.ReadOnly = true;
                txtTell.ReadOnly = true;

            }
            else
            {
                labelControl5.Text = "نام بانک";
                ActiveControls();
                txtNameShobe.ReadOnly = false;
                txtCodeShobe.ReadOnly = false;
                txtNoeHesab.ReadOnly = false;
                txtShomareHesab.ReadOnly = false;
                txtShomareKart.ReadOnly = false;
                txtShomareShaba.ReadOnly = false;
                txtShomareMoshtari.ReadOnly = false;
                txtTell.ReadOnly = false;
            }
        }

        public EnumCED En;
        public bool IsActiveList = true;

        public void FillDataGridHesabBanki()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    if (IsActiveList == true)
                    {
                        var q1 = dataContext.HesabBankis.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0)
                            hesabBankisBindingSource.DataSource = q1;
                        else
                            hesabBankisBindingSource.DataSource = null;
                    }
                    else
                    {
                        var q = dataContext.HesabBankis.Where(s => s.IsActive == false).OrderBy(s => s.Code);
                        if (q.Count() > 0)
                            hesabBankisBindingSource.DataSource = q.ToList();
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

        private void NewCode(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.HesabBankis.Select(s => s);
                    if (q.Any())
                    {
                        var MaximumCod = q.Max(p => p.Code);
                        if (MaximumCod.ToString() != "3999999")
                        {
                            txtCode.Text = (MaximumCod + 1).ToString();
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                                XtraMessageBox.Show("اعمال محدودیت تعریف 999999 حساب  ..." + "\n" +
                                    "توجه : نمیتوان بیشتر از این تعداد حساب تعریف کرد ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        txtCode.Text = "3000001";
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        bool IsActiveBeforeEdit = true;
        private void FrmTarifHesabBanki_Load(object sender, EventArgs e)
        {
            FillDataGridHesabBanki();
            HelpClass1.DateTimeMask(txtStartDate);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool TextEditValidation()
        {
            ///////////////// اعتبار سنجی کد ////////////////////////////////////
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToInt32(txtCode.Text) <= 3000000 || Convert.ToInt32(txtCode.Text) >= 4000000)
            {
                XtraMessageBox.Show("کد وارده بایستی عددی بزرگتر از 3000000 و کمتر از 4000000 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtNameBank.Text))
            {
                XtraMessageBox.Show("لطفا نام صندوق / بانک را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameBank.Focus();
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            if (db.HesabBankis.Any())
                            {
                                var q1 = db.HesabBankis.FirstOrDefault(p => p.NameHesab == txtNameHesab.Text);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.HesabBankis.FirstOrDefault(p => p.Id != RowId && p.NameHesab == txtNameHesab.Text);
                            if (q1 != null)
                            {
                                XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //txtName.Text = nameBeforeEdit;
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return true;
        }

        private void FrmTarifHesabBanki_KeyDown(object sender, KeyEventArgs e)
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
                btnDisplyActiveList_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnDisplyNotActiveList_Click(sender, null);
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

        public void btnDisplyActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = true;
            FillDataGridHesabBanki();
        }

        public void btnDisplyNotActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = false;
            FillDataGridHesabBanki();
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
            txtCode.Text = string.Empty;
            txtId.Text = string.Empty;
            txtNameHesab.Text = string.Empty;
            cmbGroupHesab.SelectedIndex = -1;
            txtNameBank.Text = string.Empty;
            txtNameShobe.Text = string.Empty;
            txtCodeShobe.Text = string.Empty;
            txtNoeHesab.Text = string.Empty;
            txtShomareHesab.Text = string.Empty;
            txtShomareKart.Text = string.Empty;
            txtShomareShaba.Text = string.Empty;
            txtShomareMoshtari.Text = string.Empty;
            //txtMojodiAvali.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            txtTell.Text = string.Empty;
            txtSharhHesab.Text = string.Empty;
            chkIsDefault.Checked = false;
        }

        public void ActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                cmbGroupHesab.ReadOnly = false;
                txtNameBank.ReadOnly = false;
                txtStartDate.ReadOnly = false;
                chkIsDefault.ReadOnly = false;
                chkIsActive.ReadOnly = false;
                txtSharhHesab.ReadOnly = false;
                //txtMojodiAvali.ReadOnly = false;
            }
        }

        public void InActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                cmbGroupHesab.ReadOnly = true;
                txtNameBank.ReadOnly = true;
                txtNameShobe.ReadOnly = true;
                txtCodeShobe.ReadOnly = true;
                txtNoeHesab.ReadOnly = true;
                txtShomareHesab.ReadOnly = true;
                txtShomareKart.ReadOnly = true;
                txtShomareShaba.ReadOnly = true;
                txtShomareMoshtari.ReadOnly = true;
                //txtMojodiAvali.ReadOnly = true;
                txtStartDate.ReadOnly = true;
                txtTell.ReadOnly = true;
                chkIsDefault.ReadOnly = true;
                chkIsActive.ReadOnly = true;
                txtSharhHesab.ReadOnly = true;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            En = EnumCED.Create;
            InActiveButtons();
            ClearControls();
            cmbGroupHesab.SelectedIndex = 0;
            ActiveControls();
            NewCode(null, null);
            txtStartDate.Text = DateTime.Now.ToString().Substring(0, 10);
            gridControl1.Enabled = false;
            cmbGroupHesab.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (XtraMessageBox.Show("آیا حساب مورد نظر حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    IsActiveBeforeEdit = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                    EditRowIndex = gridView1.FocusedRowHandle;
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                            var qq = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2 && f.Id2 == RowId);
                            if (qq != null)
                            {
                                db.AllHesabTafzilis.Remove(qq);
                                var q = db.HesabBankis.FirstOrDefault(p => p.Id == RowId);
                                if (q != null)
                                    db.HesabBankis.Remove(q);

                                /////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();

                                if (IsActiveBeforeEdit)
                                    btnDisplyActiveList_Click(null, null);
                                else
                                    btnDisplyNotActiveList_Click(null, null);
                               // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex - 1;
                            }
                            else
                                XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (DbUpdateException)
                        {
                            XtraMessageBox.Show("به دلیل اینکه از حساب فوق جهت صدور سند استفاده شده است لذا قابل حذف نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        public int EditRowIndex = 0;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && btnEdit.Visible == true)
            {
                gridControl1.Enabled = false;
                EditRowIndex = gridView1.FocusedRowHandle;
                En = EnumCED.Edit;
                InActiveButtons();

                txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString();
                txtNameHesab.Text = gridView1.GetFocusedRowCellValue("NameHesab").ToString();
                cmbGroupHesab.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("GroupHesabIndex"));
                cmbGroupHesab.Text = gridView1.GetFocusedRowCellValue("GroupHesab").ToString();
                txtNameBank.Text = gridView1.GetFocusedRowCellValue("NameBank").ToString();
                txtNameShobe.Text = gridView1.GetFocusedRowCellValue("NameShobe").ToString();
                txtCodeShobe.Text = gridView1.GetFocusedRowCellValue("CodeShobe").ToString();
                txtNoeHesab.Text = gridView1.GetFocusedRowCellValue("NoeHesab").ToString();
                txtShomareHesab.Text = gridView1.GetFocusedRowCellValue("ShomareHesab").ToString();
                txtShomareKart.Text = gridView1.GetFocusedRowCellDisplayText("ShomareKart");
                txtShomareShaba.Text = gridView1.GetFocusedRowCellDisplayText("ShomareShaba");
                txtShomareMoshtari.Text = gridView1.GetFocusedRowCellDisplayText("ShomareMoshtari");
                //txtMojodiAvali.Text = gridView1.GetFocusedRowCellValue("Mojodi").ToString();
                txtStartDate.Text = gridView1.GetFocusedRowCellDisplayText("StartDate").Substring(0, 10);
                txtTell.Text = gridView1.GetFocusedRowCellDisplayText("Tell");
                chkIsDefault.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsDefault"));
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                txtSharhHesab.Text = gridView1.GetFocusedRowCellDisplayText("SharhHesab");

                CodeBeforeEdit = txtCode.Text;
                NameBeforeEdit = txtNameHesab.Text;
                IsActiveBeforeEdit = chkIsActive.Checked;
                ActiveControls();
                cmbGroupHesab.Focus();
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
                            HesabBanki obj = new HesabBanki();
                            obj.Code = Convert.ToInt32(txtCode.Text);
                            obj.NameHesab = txtNameHesab.Text;
                            obj.GroupHesabIndex = cmbGroupHesab.SelectedIndex;
                            obj.GroupHesab = cmbGroupHesab.Text;
                            obj.NameBank = txtNameBank.Text;
                            obj.NameShobe = txtNameShobe.Text;
                            if (!string.IsNullOrEmpty(txtCodeShobe.Text))
                                obj.CodeShobe = Convert.ToSingle(txtCodeShobe.Text.Replace("/", "."));
                            obj.NoeHesab = txtNoeHesab.Text;
                            obj.ShomareHesab = txtShomareHesab.Text;
                            obj.ShomareKart = txtShomareKart.Text;
                            obj.ShomareShaba = txtShomareShaba.Text;
                            obj.ShomareMoshtari = txtShomareMoshtari.Text;
                            //obj.Mojodi = !string.IsNullOrEmpty(txtMojodiAvali.Text) ? Convert.ToDecimal(txtMojodiAvali.Text) : 0;
                            if (!string.IsNullOrEmpty(txtStartDate.Text))
                                obj.StartDate = Convert.ToDateTime(txtStartDate.Text);
                            obj.Tell = txtTell.Text;
                            obj.IsDefault = chkIsDefault.Checked;
                            obj.IsActive = chkIsActive.Checked;
                            obj.SharhHesab = txtSharhHesab.Text;
                            obj.TarifSandoghId = Convert.ToInt32(Fm.IDSandogh.Caption);
                            obj.GroupTafziliId = cmbGroupHesab.SelectedIndex == 0 ? 1 : 2;
                            //obj.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                            db.HesabBankis.Add(obj);
                            db.SaveChanges();

                            //////////////////////////////////////////
                            int _Code = Convert.ToInt32(txtCode.Text);
                            AllHesabTafzili obj1 = new AllHesabTafzili();
                            obj1.Id2 = db.HesabBankis.FirstOrDefault(f => f.Code == _Code).Id;
                            obj1.Code = _Code;
                            obj1.Name = txtNameHesab.Text;
                            obj1.GroupTafziliId = cmbGroupHesab.SelectedIndex == 0 ? 1 : 2;
                            obj1.IsActive = chkIsActive.Checked;
                            obj1.SandoghId = Convert.ToInt32(Fm.IDSandogh.Caption);
                            db.AllHesabTafzilis.Add(obj1);
                            db.SaveChanges();
                            ////////////////////////////////////////////////////////////////////////////////////
                            var qr1 = db.AllHesabTafzilis.FirstOrDefault(f => f.Code == _Code);
                            if (qr1 != null)
                            {
                                var qr2 = db.HesabBankis.FirstOrDefault(f => f.Code == _Code);
                                qr2.AllTafId = qr1.Id;
                                db.SaveChanges();
                            }
                            /////////////////////////////////////////////////////////////////////////////////////
                            if (chkIsActive.Checked)
                                btnDisplyActiveList_Click(null, null);
                            else
                                btnDisplyNotActiveList_Click(null, null);

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
                            int _Code = Convert.ToInt32(txtCode.Text);
                            string _Name = txtNameHesab.Text;
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.HesabBankis.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                q.Code = Convert.ToInt32(txtCode.Text);
                                q.NameHesab = txtNameHesab.Text;
                                q.GroupHesabIndex = cmbGroupHesab.SelectedIndex;
                                q.GroupHesab = cmbGroupHesab.Text;
                                q.NameBank = txtNameBank.Text;
                                q.NameShobe = txtNameShobe.Text;
                                if (!string.IsNullOrEmpty(txtCodeShobe.Text))
                                    q.CodeShobe = Convert.ToSingle(txtCodeShobe.Text.Replace("/", "."));
                                q.NoeHesab = txtNoeHesab.Text;
                                q.ShomareHesab = txtShomareHesab.Text;
                                q.ShomareKart = txtShomareKart.Text;
                                q.ShomareShaba = txtShomareShaba.Text;
                                q.ShomareMoshtari = txtShomareMoshtari.Text;
                                //q.Mojodi = !string.IsNullOrEmpty(txtMojodiAvali.Text) ? Convert.ToDecimal(txtMojodiAvali.Text) : 0;
                                if (!string.IsNullOrEmpty(txtStartDate.Text))
                                    q.StartDate = Convert.ToDateTime(txtStartDate.Text);
                                q.Tell = txtTell.Text;
                                q.IsDefault = chkIsDefault.Checked;
                                q.IsActive = chkIsActive.Checked;
                                q.SharhHesab = txtSharhHesab.Text;
                                q.GroupTafziliId = cmbGroupHesab.SelectedIndex == 0 ? 1 : 2;

                                //////////////////////////////////////////
                                //int _Code = Convert.ToInt32(txtCode.Text);
                                var qq1 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2 && f.Id2 == RowId);
                                if (qq1 != null)
                                {
                                    qq1.Code = _Code;
                                    qq1.Name = txtNameHesab.Text;
                                    qq1.GroupTafziliId = cmbGroupHesab.SelectedIndex == 0 ? 1 : 2;
                                    qq1.IsActive = chkIsActive.Checked;
                                }
                                /////////////////////////////////////////////////////////////////////////////////////

                                db.SaveChanges();
                                if (IsActiveBeforeEdit)
                                    btnDisplyActiveList_Click(null, null);
                                else
                                    btnDisplyNotActiveList_Click(null, null);

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
            btnDelete.Enabled = btnEdit.Enabled = gridView1.RowCount > 0 ? true : false;
        }


        string _NameBank = string.Empty;
        string _NameShobe = string.Empty;
        string _NoeHesab = string.Empty;
        string _ShomareHesab = string.Empty;
        private void txtNameBank_EditValueChanged(object sender, EventArgs e)
        {
            _NameBank = txtNameBank.Text;
            txtNameHesab.Text = _NameBank + " " + _NameShobe + " " + _NoeHesab + " " + _ShomareHesab;
        }

        private void txtNameShobe_EditValueChanged(object sender, EventArgs e)
        {
            _NameShobe = txtNameShobe.Text;
            txtNameHesab.Text = _NameBank + " " + _NameShobe + " " + _NoeHesab + " " + _ShomareHesab;
        }

        private void txtShomareHesab_EditValueChanged(object sender, EventArgs e)
        {
            _ShomareHesab = txtShomareHesab.Text;
            txtNameHesab.Text = _NameBank + " " + _NameShobe + " " + _NoeHesab + " " + _ShomareHesab;
        }

        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
            if (En == EnumCED.Save)
                btnCreate_Click(null, null);
        }

        private void btnCreate_Enter(object sender, EventArgs e)
        {
        }

        private void txtNoeHesab_EditValueChanged(object sender, EventArgs e)
        {
            _NoeHesab = txtNoeHesab.Text;
            txtNameHesab.Text = _NameBank + " " + _NameShobe + " " + _NoeHesab + " " + _ShomareHesab;

        }

        private void cmbGroupHesab_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
                cmbGroupHesab.ShowPopup();
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (En == EnumCED.Edit && chkIsActive.Checked == false)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int RowId = Convert.ToInt32(txtId.Text);
                        var AllTafId = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2 && f.Id2 == RowId).Id;
                        var q3 = db.AsnadeHesabdariRows.Where(f => f.HesabTafId == AllTafId).ToList();
                        if (q3.Count > 0)
                        {
                            decimal SumBed = 0;
                            decimal SumBes = 0;
                            decimal MandeHesab = 0;
                            foreach (var item in q3)
                            {
                                if (item.Bed != null)
                                    SumBed += (decimal)item.Bed;
                                else
                                    SumBes += (decimal)item.Bes;
                            }
                            MandeHesab = SumBed - SumBes;
                            if (MandeHesab != 0)
                            {
                                XtraMessageBox.Show("حساب مورد نظر دارای مانده حساب است لذا نمیتوان آنرا غیرفعال نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                chkIsActive.Checked = true;
                                return;

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

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(gridView1, gridView1.RowCount);
            }

        }
    }
}