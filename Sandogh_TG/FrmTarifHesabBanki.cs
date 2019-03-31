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
using Sandogh_TG.Models;

namespace Sandogh_TG
{
    public partial class FrmTarifHesabBanki : DevExpress.XtraEditors.XtraForm
    {
        public FrmTarifHesabBanki()
        {
            InitializeComponent();
        }

        private void cmbGroupHesab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGroupHesab.SelectedIndex==0)
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
                        var q = dataContext.HesabBankis.Where(p => p.IsActive == false).OrderBy(s => s.Code);
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

        private void btnNewCode(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.HesabBankis.Select(s => s);
                    if (q.Any())
                    {
                        var MaximumCod = q.Max(p => p.Code);
                        if (MaximumCod.ToString() != "999")
                        {
                            txtCode.Text = (MaximumCod + 1).ToString();
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                                XtraMessageBox.Show("اعمال محدودیت تعریف 999 حساب  ..." + "\n" +
                                    "توجه : نمیتوان بیشتر از 999 حساب تعریف کرد مگر اینکه در صورت امکان از کدهای خالی مابین 1 تا 999 استفاده نمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        txtCode.Text = "001";
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
            else if (Convert.ToInt32(txtCode.Text) == 0 || Convert.ToInt32(txtCode.Text) > 999)
            {
                XtraMessageBox.Show("کد وارده بایستی عددی بزرگتر از صفر و کمتر از 1000 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                btnSharhHesab_Click(sender, null);
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

        private void btnSharhHesab_Click(object sender, EventArgs e)
        {
            gridView1.Columns["SharhHesab"].Visible = gridView1.Columns["SharhHesab"].Visible == false ? true : false;
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
            txtMojodiAvali.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            txtTell.Text = string.Empty;
            txtSharhHesab.Text = string.Empty;
        }

        public void ActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                cmbGroupHesab.ReadOnly = false;
                txtNameBank.ReadOnly = false;
                txtStartDate.ReadOnly = false;
                chkIsActive.ReadOnly = false;
                txtSharhHesab.ReadOnly = false;
                txtMojodiAvali.ReadOnly = false;
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
                txtMojodiAvali.ReadOnly = true;
                txtStartDate.ReadOnly = true;
                txtTell.ReadOnly = true;
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
            btnNewCode(null, null);
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
                            var q = db.HesabBankis.FirstOrDefault(p => p.Id == RowId);
                            //var q8 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                            if (q != null /*&& q8 != null*/)
                            {
                                db.HesabBankis.Remove(q);
                                //db.EpAccessLevelCodingHesabdaris.Remove(q8);
                                /////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();

                                if (IsActiveBeforeEdit)
                                    btnDisplyActiveList_Click(null, null);
                                else
                                    btnDisplyNotActiveList_Click(null, null);
                                XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex - 1;
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
                cmbGroupHesab.Text = gridView1.GetFocusedRowCellValue("GroupHesab").ToString();
                txtNameBank.Text = gridView1.GetFocusedRowCellValue("NameBank").ToString();
                txtNameShobe.Text = gridView1.GetFocusedRowCellValue("NameShobe").ToString();
                txtCodeShobe.Text = gridView1.GetFocusedRowCellValue("CodeShobe").ToString();
                txtNoeHesab.Text = gridView1.GetFocusedRowCellValue("NoeHesab").ToString();
                txtShomareHesab.Text = gridView1.GetFocusedRowCellValue("ShomareHesab").ToString();
                txtShomareKart.Text = gridView1.GetFocusedRowCellValue("ShomareKart").ToString();
                txtShomareShaba.Text = gridView1.GetFocusedRowCellValue("ShomareShaba").ToString();
                txtShomareMoshtari.Text = gridView1.GetFocusedRowCellValue("ShomareMoshtari").ToString();
                txtMojodiAvali.Text = gridView1.GetFocusedRowCellValue("Mojodi").ToString();
                txtStartDate.EditValue = gridView1.GetFocusedRowCellValue("StartDate").ToString().Substring(0, 10);
                txtTell.Text = gridView1.GetFocusedRowCellValue("Tell").ToString();
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();

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
                            obj.Mojodi = !string.IsNullOrEmpty(txtMojodiAvali.Text) ? Convert.ToDecimal(txtMojodiAvali.Text) : 0;
                            if (!string.IsNullOrEmpty(txtStartDate.Text))
                                obj.StartDate = Convert.ToDateTime(txtStartDate.Text);
                            obj.Tell = txtTell.Text;
                            obj.IsActive = chkIsActive.Checked;
                            obj.SharhHesab = txtSharhHesab.Text;

                            db.HesabBankis.Add(obj);
                            db.SaveChanges();
                            /////////////////////////////////////////////////////////////////////////////////////
                            //int _Code = Convert.ToInt32(txtCodeGroupTafziliSandogh.Text + txtCode.Text);
                            //var q = db.EpHesabTafziliHesabBankis.FirstOrDefault(s => s.Code == _Code);
                            //////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                            //EpAccessLevelCodingHesabdari n1 = new EpAccessLevelCodingHesabdari();
                            //n1.KeyId = _Code;
                            //n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                            //n1.LevelName = txtName.Text;
                            //n1.HesabGroupId = q.GroupId;
                            //n1.HesabColId = q.Id;
                            //n1.IsActive = chkIsActive.Checked;
                            //db.EpAccessLevelCodingHesabdaris.Add(n1);
                            ///////////////////////////////////////////////////////////////////////////////////////
                            //db.SaveChanges();
                            if (chkIsActive.Checked)
                                btnDisplyActiveList_Click(null, null);
                            else
                                btnDisplyNotActiveList_Click(null, null);

                            XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                            gridView1.MoveLast();
                            ActiveButtons();
                            ClearControls();
                            InActiveControls();
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
                                q.Mojodi = !string.IsNullOrEmpty(txtMojodiAvali.Text) ? Convert.ToDecimal(txtMojodiAvali.Text) : 0;
                                if (!string.IsNullOrEmpty(txtStartDate.Text))
                                    q.StartDate = Convert.ToDateTime(txtStartDate.Text);
                                q.Tell = txtTell.Text;
                                q.IsActive = chkIsActive.Checked;
                                q.SharhHesab = txtSharhHesab.Text;

                                db.SaveChanges();
                                if (IsActiveBeforeEdit)
                                    btnDisplyActiveList_Click(null, null);
                                else
                                    btnDisplyNotActiveList_Click(null, null);

                                XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex;
                                gridControl1.Enabled = true;
                                ActiveButtons();
                                ClearControls();
                                InActiveControls();
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
        string _ShomareHesab = string.Empty;
        private void txtNameBank_EditValueChanged(object sender, EventArgs e)
        {
            _NameBank = txtNameBank.Text;
            txtNameHesab.Text = _NameBank + " " + _NameShobe + " " + _ShomareHesab;
        }

        private void txtNameShobe_EditValueChanged(object sender, EventArgs e)
        {
            _NameShobe = txtNameShobe.Text;
            txtNameHesab.Text = _NameBank + " " + _NameShobe + " " + _ShomareHesab;
        }

        private void txtShomareHesab_EditValueChanged(object sender, EventArgs e)
        {
            _ShomareHesab = txtShomareHesab.Text;
            txtNameHesab.Text = _NameBank + " " + _NameShobe + " " + _ShomareHesab;
        }

    }
}