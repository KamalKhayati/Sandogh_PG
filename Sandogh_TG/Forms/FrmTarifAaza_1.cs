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
using System.IO;
using Sandogh_TG;
using System.Data.Entity.Infrastructure;

namespace Sandogh_TG
{
    public partial class FrmTarifAaza_1 : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmTarifAaza_1(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }


        public EnumCED En;
        public bool IsActiveList = true;

        public void FillDataGridTarifAaza()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    if (IsActiveList == true)
                    {
                        var q1 = dataContext.AazaSandoghs.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0)
                            aazaSandoghsBindingSource.DataSource = q1;
                        else
                            aazaSandoghsBindingSource.DataSource = null;
                    }
                    else
                    {
                        var q = dataContext.AazaSandoghs.Where(s => s.IsActive == false).OrderBy(s => s.Code);
                        if (q.Count() > 0)
                            aazaSandoghsBindingSource.DataSource = q.ToList();
                        else
                            aazaSandoghsBindingSource.DataSource = null;
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
                    var q = db.AazaSandoghs.Select(s => s);
                    if (q.Any())
                    {
                        var MaximumCod = q.Max(p => p.Code);
                        if (MaximumCod.ToString() != "9999999")
                        {
                            txtCode.Text = (MaximumCod + 1).ToString();
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                                XtraMessageBox.Show("اعمال محدودیت تعریف 9999999 حساب  ..." + "\n" +
                                    "توجه : نمیتوان بیشتر از این تعداد حساب تعریف کرد ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        txtCode.Text = "0000001";
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
        private void FrmTarifAaza_1_Load(object sender, EventArgs e)
        {
            FillDataGridTarifAaza();
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
            else if (Convert.ToInt32(txtCode.Text) == 0 || Convert.ToInt32(txtCode.Text) > 99999)
            {
                XtraMessageBox.Show("کد وارده بایستی عددی بزرگتر از صفر و کمتر از 100000 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtNameVFamil.Text))
            {
                XtraMessageBox.Show("لطفا نام , فامیل را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameVFamil.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtTarikhOzviat.Text))
            {
                XtraMessageBox.Show("لطفا تاریخ عضویت را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTarikhOzviat.Focus();
                return false;
            }
            else if (En == EnumCED.Edit && chkIsActive.Checked == false)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int RowId = Convert.ToInt32(txtId.Text);
                        string _NameAaza = txtNameVFamil.Text;
                        var q1 = db.VamPardakhtis.FirstOrDefault(s => s.IsTasviye == false && s.AazaId == RowId);
                        var q2 = db.VamPardakhtis.Where(s => s.IsTasviye == false && s.ZameninName.Contains(_NameAaza));
                        if (q1 != null)
                        {
                            XtraMessageBox.Show("عضو مورد نظر وام تسویه نشده قبلی دارد لذا نمیتوان آنرا غیر فعال نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        else if (q2.Count() > 0)
                        {
                            foreach (var item in q2)
                            {
                                XtraMessageBox.Show("عضو مورد نظر ضامن وام " + item.NameAaza + " است لذا نمیتوان آنرا غیر فعال نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            return false;
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
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            if (db.AazaSandoghs.Any())
                            {
                                var q1 = db.AazaSandoghs.FirstOrDefault(p => p.NameVFamil == txtNameVFamil.Text);
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
                            var q1 = db.AazaSandoghs.FirstOrDefault(p => p.Id != RowId && p.NameVFamil == txtNameVFamil.Text);
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

        private void FrmTarifAaza_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
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
            FillDataGridTarifAaza();
        }

        public void btnDisplyNotActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = false;
            FillDataGridTarifAaza();
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
            txtId.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtCodePersoneli.Text = string.Empty;
            txtTarikhOzviat.Text = string.Empty;
            txtNameVFamil.Text = string.Empty;
            txtNamePedar.Text = string.Empty;
            txtCodeMeli.Text = string.Empty;
            txtShShenasname.Text = string.Empty;
            txtBirthDate.Text = string.Empty;
            cmbJensiat.SelectedIndex = -1;
            cmbTaahol.SelectedIndex = -1;
            txtNameBank.Text = string.Empty;
            txtShomareHesab.Text = string.Empty;
            txtShomareKart.Text = string.Empty;
            txtShomareShaba.Text = string.Empty;
            txtAdress.Text = string.Empty;
            txtMohaleKar.Text = string.Empty;
            txtMobile1.Text = string.Empty;
            txtMobile2.Text = string.Empty;
            txtTell.Text = string.Empty;
            txtShoghl.Text = string.Empty;
            cmbMoaref.EditValue = 0;
            txtHaghOzviat.Text = string.Empty;
            txtBesAvali.Text = string.Empty;
            //txtBedAvali.Text = string.Empty;
            txtHazineEftetah.Text = string.Empty;
            txtSharhHesab.Text = string.Empty;
            pictureEdit1.Image = null;
        }

        public void ActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                txtCodePersoneli.ReadOnly = false;
                txtTarikhOzviat.ReadOnly = false;
                txtNameVFamil.ReadOnly = false;
                txtNamePedar.ReadOnly = false;
                txtCodeMeli.ReadOnly = false;
                txtShShenasname.ReadOnly = false;
                txtBirthDate.ReadOnly = false;
                cmbJensiat.ReadOnly = false;
                cmbTaahol.ReadOnly = false;
                txtNameBank.ReadOnly = false;
                txtShomareHesab.ReadOnly = false;
                txtShomareKart.ReadOnly = false;
                txtShomareShaba.ReadOnly = false;
                txtAdress.ReadOnly = false;
                txtMohaleKar.ReadOnly = false;
                txtMobile1.ReadOnly = false;
                txtMobile2.ReadOnly = false;
                txtTell.ReadOnly = false;
                txtShoghl.ReadOnly = false;
                cmbMoaref.ReadOnly = false;
                txtHaghOzviat.ReadOnly = false;
                txtBesAvali.ReadOnly = false;
                //txtBedAvali.ReadOnly = false;
                txtHazineEftetah.ReadOnly = false;
                txtSharhHesab.ReadOnly = false;
                chkIsActive.ReadOnly = false;
                pictureEdit1.ReadOnly = false;
                btnBrowsPictuer.Enabled = true;
                btnDeletePictuer.Enabled = true;
            }
        }

        public void InActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                txtCodePersoneli.ReadOnly = true;
                txtTarikhOzviat.ReadOnly = true;
                txtNameVFamil.ReadOnly = true;
                txtNamePedar.ReadOnly = true;
                txtCodeMeli.ReadOnly = true;
                txtShShenasname.ReadOnly = true;
                txtBirthDate.ReadOnly = true;
                cmbJensiat.ReadOnly = true;
                cmbTaahol.ReadOnly = true;
                txtNameBank.ReadOnly = true;
                txtShomareHesab.ReadOnly = true;
                txtShomareKart.ReadOnly = true;
                txtShomareShaba.ReadOnly = true;
                txtAdress.ReadOnly = true;
                txtMohaleKar.ReadOnly = true;
                txtMobile1.ReadOnly = true;
                txtMobile2.ReadOnly = true;
                txtTell.ReadOnly = true;
                txtShoghl.ReadOnly = true;
                cmbMoaref.ReadOnly = true;
                txtHaghOzviat.ReadOnly = true;
                txtBesAvali.ReadOnly = true;
                //txtBedAvali.ReadOnly = true;
                txtHazineEftetah.ReadOnly = true;
                txtSharhHesab.ReadOnly = true;
                chkIsActive.ReadOnly = true;
                pictureEdit1.ReadOnly = true;
                btnBrowsPictuer.Enabled = false;
                btnDeletePictuer.Enabled = false;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            En = EnumCED.Create;
            gridControl1.Enabled = false;
            InActiveButtons();
            ClearControls();
            ActiveControls();
            cmbMoaref.EditValue = 0;
            NewCode(null, null);
            txtTarikhOzviat.Text = DateTime.Now.ToString().Substring(0, 10);
            txtCodePersoneli.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (XtraMessageBox.Show("آیا عضو مورد نظر حذف شود؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    IsActiveBeforeEdit = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                    EditRowIndex = gridView1.FocusedRowHandle;
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                            var q = db.AazaSandoghs.FirstOrDefault(p => p.Id == RowId);
                            //var q8 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                            if (q != null /*&& q8 != null*/)
                            {
                                db.AazaSandoghs.Remove(q);
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
                        catch (DbUpdateException)
                        {
                            XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این عضو مقدور نیست \n" +
                                " جهت حذف عضو مورد نظر در ابتدا بایستی زیر شاخه های این عضو یعنی پس انداز ماهیانه دریافتی،\n وامهای دریافتی،ریز اقساط وام، و سایر دریافتها و پرداختها مربوط به این عضو در صورت وجود حذف گردد" +
                                "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtCodePersoneli.Text = gridView1.GetFocusedRowCellValue("CodePersoneli").ToString();
                if (gridView1.GetFocusedRowCellDisplayText("TarikhOzviat").ToString() != string.Empty)
                    txtTarikhOzviat.Text = gridView1.GetFocusedRowCellValue("TarikhOzviat").ToString().Substring(0, 10);
                txtNameVFamil.Text = gridView1.GetFocusedRowCellValue("NameVFamil").ToString();
                txtNamePedar.Text = gridView1.GetFocusedRowCellValue("NamePedar").ToString();
                txtCodeMeli.Text = gridView1.GetFocusedRowCellValue("CodeMelli").ToString();
                txtShShenasname.Text = gridView1.GetFocusedRowCellValue("ShShenasname").ToString();
                if (gridView1.GetFocusedRowCellDisplayText("BirthDate") != string.Empty)
                    txtBirthDate.Text = gridView1.GetFocusedRowCellValue("BirthDate").ToString().Substring(0, 10);
                cmbJensiat.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexJensiat"));
                cmbTaahol.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexTaahol"));
                txtNameBank.Text = gridView1.GetFocusedRowCellValue("NameBank").ToString();
                txtShomareHesab.Text = gridView1.GetFocusedRowCellValue("ShomareHesab").ToString();
                txtShomareKart.Text = gridView1.GetFocusedRowCellValue("ShomareKart").ToString();
                txtShomareShaba.Text = gridView1.GetFocusedRowCellValue("ShomareShaba").ToString();
                txtAdress.Text = gridView1.GetFocusedRowCellValue("AdressManzel").ToString();
                txtMohaleKar.Text = gridView1.GetFocusedRowCellValue("AdressMohalKar").ToString();
                txtMobile1.Text = gridView1.GetFocusedRowCellValue("Mobile1").ToString();
                txtMobile2.Text = gridView1.GetFocusedRowCellValue("Mobile2").ToString();
                txtTell.Text = gridView1.GetFocusedRowCellValue("Tell").ToString();
                txtShoghl.Text = gridView1.GetFocusedRowCellValue("Shoghl").ToString();
                cmbMoaref.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MoarefId"));
                txtBesAvali.Text = gridView1.GetFocusedRowCellValue("BesAvali").ToString();
                //txtBedAvali.Text = gridView1.GetFocusedRowCellValue("BedAvali").ToString();
                txtHaghOzviat.Text = gridView1.GetFocusedRowCellValue("HaghOzviat").ToString();
                txtHazineEftetah.Text = gridView1.GetFocusedRowCellValue("HazineEftetah").ToString();
                txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                using (var db = new MyContext())
                {
                    try
                    {
                        int RowId = Convert.ToInt32(txtId.Text);
                        var q1 = db.AazaSandoghs.FirstOrDefault(s => s.Id == RowId);
                        if (q1.Pictuer != null)
                        {
                            MemoryStream ms = new MemoryStream(q1.Pictuer);
                            pictureEdit1.Image = Image.FromStream(ms);
                            img = pictureEdit1.Image;
                        }
                        else
                            pictureEdit1.Image = null;

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                CodeBeforeEdit = txtCode.Text;
                NameBeforeEdit = txtNameVFamil.Text;
                IsActiveBeforeEdit = chkIsActive.Checked;
                ActiveControls();
                txtCodePersoneli.Focus();
            }
        }

        Image img;
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
                            AazaSandogh obj = new AazaSandogh();
                            obj.Code = Convert.ToInt32(txtCode.Text);
                            obj.CodePersoneli = txtCodePersoneli.Text;
                            if (!string.IsNullOrEmpty(txtTarikhOzviat.Text))
                                obj.TarikhOzviat = Convert.ToDateTime(txtTarikhOzviat.Text);
                            obj.NameVFamil = txtNameVFamil.Text;
                            obj.NamePedar = txtNamePedar.Text;
                            obj.CodeMelli = txtCodeMeli.Text;
                            obj.ShShenasname = txtShShenasname.Text;
                            if (!string.IsNullOrEmpty(txtBirthDate.Text))
                                obj.BirthDate = Convert.ToDateTime(txtBirthDate.Text);
                            if (cmbJensiat.SelectedIndex != -1)
                            {
                                obj.Jensiat = cmbJensiat.Text;
                                obj.IndexJensiat = cmbJensiat.SelectedIndex;

                            }
                            if (cmbTaahol.SelectedIndex != -1)
                            {
                                obj.Taahol = cmbTaahol.Text;
                                obj.IndexTaahol = cmbTaahol.SelectedIndex;

                            }
                            obj.NameBank = txtNameBank.Text;
                            obj.ShomareHesab = txtShomareHesab.Text;
                            obj.ShomareKart = txtShomareKart.Text;
                            obj.ShomareShaba = txtShomareShaba.Text;
                            obj.AdressManzel = txtAdress.Text;
                            obj.AdressMohalKar = txtMohaleKar.Text;
                            obj.Mobile1 = txtMobile1.Text;
                            obj.Mobile2 = txtMobile2.Text;
                            obj.Tell = txtTell.Text;
                            obj.Shoghl = txtShoghl.Text;
                            if (Convert.ToInt32(cmbMoaref.EditValue) != 0)
                            {
                                obj.Moaref = cmbMoaref.Text;
                                obj.MoarefId = Convert.ToInt32(cmbMoaref.EditValue);

                            }
                            obj.HazineEftetah = !string.IsNullOrEmpty(txtHazineEftetah.Text.Replace(",", "")) ? Convert.ToDecimal(txtHazineEftetah.Text.Replace(",", "")) : 0;
                            obj.BesAvali = !string.IsNullOrEmpty(txtBesAvali.Text.Replace(",", "")) ? Convert.ToDecimal(txtBesAvali.Text.Replace(",", "")) : 0;
                            //obj.BedAvali = !string.IsNullOrEmpty(txtBedAvali.Text) ? Convert.ToDecimal(txtBedAvali.Text) : 0;
                            obj.HaghOzviat = !string.IsNullOrEmpty(txtHaghOzviat.Text.Replace(",", "")) ? Convert.ToDecimal(txtHaghOzviat.Text.Replace(",", "")) : 0;
                            obj.IsActive = chkIsActive.Checked;
                            obj.SharhHesab = txtSharhHesab.Text;
                            obj.TarifSandoghId = Convert.ToInt32(Fm.IDSandogh.Caption);
                            obj.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                            if (pictureEdit1.Image != null)
                            {
                                MemoryStream ms = new MemoryStream();
                                img.Save(ms, pictureEdit1.Image.RawFormat);
                                byte[] myarrey = ms.GetBuffer();
                                obj.Pictuer = myarrey;
                            }
                            else
                                obj.Pictuer = null;

                            db.AazaSandoghs.Add(obj);
                            db.SaveChanges();
                            /////////////////////////////////////////////////////////////////////////////////////
                            //int _Code = Convert.ToInt32(txtCodeGroupTafziliSandogh.Text + txtCode.Text);
                            //var q = db.EpHesabTafziliAazaSandoghs.FirstOrDefault(s => s.Code == _Code);
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
                            gridControl1.Enabled = true;
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
                            string _Name = txtNameVFamil.Text;
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.AazaSandoghs.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                q.Code = Convert.ToInt32(txtCode.Text);
                                q.CodePersoneli = txtCodePersoneli.Text;
                                if (!string.IsNullOrEmpty(txtTarikhOzviat.Text))
                                    q.TarikhOzviat = Convert.ToDateTime(txtTarikhOzviat.Text);
                                q.NameVFamil = txtNameVFamil.Text;
                                q.NamePedar = txtNamePedar.Text;
                                q.CodeMelli = txtCodeMeli.Text;
                                q.ShShenasname = txtShShenasname.Text;
                                if (!string.IsNullOrEmpty(txtBirthDate.Text))
                                    q.BirthDate = Convert.ToDateTime(txtBirthDate.Text);
                                if (cmbJensiat.SelectedIndex != -1)
                                {
                                    q.Jensiat = cmbJensiat.Text;
                                    q.IndexJensiat = cmbJensiat.SelectedIndex;

                                }
                                if (cmbTaahol.SelectedIndex != -1)
                                {
                                    q.Taahol = cmbTaahol.Text;
                                    q.IndexTaahol = cmbTaahol.SelectedIndex;

                                }
                                q.NameBank = txtNameBank.Text;
                                q.ShomareHesab = txtShomareHesab.Text;
                                q.ShomareKart = txtShomareKart.Text;
                                q.ShomareShaba = txtShomareShaba.Text;
                                q.AdressManzel = txtAdress.Text;
                                q.AdressMohalKar = txtMohaleKar.Text;
                                q.Mobile1 = txtMobile1.Text;
                                q.Mobile2 = txtMobile2.Text;
                                q.Tell = txtTell.Text;
                                q.Shoghl = txtShoghl.Text;
                                if (Convert.ToInt32(cmbMoaref.EditValue) != 0)
                                {
                                    q.Moaref = cmbMoaref.Text;
                                    q.MoarefId = Convert.ToInt32(cmbMoaref.EditValue);

                                }
                                q.HazineEftetah = !string.IsNullOrEmpty(txtHazineEftetah.Text.Replace(",", "")) ? Convert.ToDecimal(txtHazineEftetah.Text.Replace(",", "")) : 0;
                                q.BesAvali = !string.IsNullOrEmpty(txtBesAvali.Text.Replace(",", "")) ? Convert.ToDecimal(txtBesAvali.Text.Replace(",", "")) : 0;
                                //q.BedAvali = !string.IsNullOrEmpty(txtBedAvali.Text) ? Convert.ToDecimal(txtBedAvali.Text) : 0;
                                q.HaghOzviat = !string.IsNullOrEmpty(txtHaghOzviat.Text.Replace(",", "")) ? Convert.ToDecimal(txtHaghOzviat.Text.Replace(",", "")) : 0;
                                q.SharhHesab = txtSharhHesab.Text;
                                if (pictureEdit1.Image != null)
                                {
                                    MemoryStream ms = new MemoryStream();
                                    img.Save(ms, pictureEdit1.Image.RawFormat);
                                    byte[] myarrey = ms.GetBuffer();
                                    q.Pictuer = myarrey;
                                }
                                else
                                    q.Pictuer = null;



                                q.IsActive = chkIsActive.Checked;
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

        private void btnBrowsPictuer_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img = Image.FromFile(openFileDialog1.FileName);
                this.pictureEdit1.Image = img;
                //this.pictureEdit1.Tag = openFileDialog1.FileName;
            }

        }

        private void btnDeletePictuer_Click(object sender, EventArgs e)
        {
            pictureEdit1.Image = null;
        }
    }
}