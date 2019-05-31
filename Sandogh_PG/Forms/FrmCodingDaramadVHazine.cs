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
using System.Data.Entity.Infrastructure;

namespace Sandogh_PG
{
    public partial class FrmCodingDaramadVHazine : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmCodingDaramadVHazine(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        public EnumCED En;
        public bool IsActiveList = true;
        private void cmbGroupHesab_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewCode();
        }

        public void FillDataGridCodingDaramadVHazine()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (IsActiveList)
                    {
                        var q1 = db.CodingDaramadVHazines.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0)
                            codingDaramadVHazinesBindingSource.DataSource = q1;
                        else
                            codingDaramadVHazinesBindingSource.DataSource = null;
                    }
                    else
                    {
                        var q1 = db.CodingDaramadVHazines.Where(s => s.IsActive == false).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0)
                            codingDaramadVHazinesBindingSource.DataSource = q1;
                        else
                            codingDaramadVHazinesBindingSource.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void NewCode()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.CodingDaramadVHazines.Where(s => s.GroupIndex == 0).ToList();
                    var q1 = db.CodingDaramadVHazines.Where(s => s.GroupIndex == 1).ToList();
                    if (cmbGroupHesab.SelectedIndex == 0)
                    {
                        if (q.Count > 0)
                        {
                            var MaximumCod = q.Max(s => s.Code);
                            if (MaximumCod.ToString() != "1999999")
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
                            txtCode.Text = "1000001";
                        }
                    }
                    else if (cmbGroupHesab.SelectedIndex == 1)
                    {
                        if (q1.Count > 0)
                        {
                            var MaximumCod = q1.Max(s => s.Code);
                            if (MaximumCod.ToString() != "2999999")
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
                            txtCode.Text = "2000001";
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmCodingDaramadVHazine_Load(object sender, EventArgs e)
        {
            FillDataGridCodingDaramadVHazine();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool TextEditValidation()
        {
            if (string.IsNullOrEmpty(cmbGroupHesab.Text))
            {
                XtraMessageBox.Show("لطفا گروه حساب را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGroupHesab.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtNameHesab.Text))
            {
                XtraMessageBox.Show("لطفا نام حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameHesab.Focus();
                return false;
            }
            return true;
        }

        private void FrmCodingDaramadVHazine_KeyDown(object sender, KeyEventArgs e)
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
                btnDisplayActiveList_Click(sender, null);
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

        public void btnDisplayActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = true;
            FillDataGridCodingDaramadVHazine();
        }
        public void btnDisplayNotActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = false;
            FillDataGridCodingDaramadVHazine();
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
        }

        public void ActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                cmbGroupHesab.ReadOnly = false;
                txtNameHesab.ReadOnly = false;
                chkIsActive.ReadOnly = false;
            }
        }

        public void InActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                cmbGroupHesab.ReadOnly = true;
                txtNameHesab.ReadOnly = true;
                chkIsActive.ReadOnly = true;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            En = EnumCED.Create;
            InActiveButtons();
            ClearControls();
            ActiveControls();
            gridControl1.Enabled = false;
            cmbGroupHesab.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (XtraMessageBox.Show("آیا حساب مورد نظر حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    EditRowIndex = gridView1.FocusedRowHandle;
                    if (gridView1.GetFocusedRowCellDisplayText("Code") == "1000001" || gridView1.GetFocusedRowCellDisplayText("Code") == "1000002"
                        || gridView1.GetFocusedRowCellDisplayText("Code") == "2000001")
                    {
                        XtraMessageBox.Show("این کد سیستمی است لذا قابل حذف نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                            var qq = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 4 || f.GroupTafziliId == 5 && f.Id2 == RowId);
                            if (qq != null)
                            {
                                db.AllHesabTafzilis.Remove(qq);
                                var q = db.CodingDaramadVHazines.FirstOrDefault(p => p.Id == RowId);
                                if (q != null)
                                    db.CodingDaramadVHazines.Remove(q);
                                /////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();

                                btnDisplayActiveList_Click(null, null);
                               // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (gridView1.GetFocusedRowCellDisplayText("Code") == "1000001" || gridView1.GetFocusedRowCellDisplayText("Code") == "1000002"
                    || gridView1.GetFocusedRowCellDisplayText("Code") == "2000001")
                {
                    XtraMessageBox.Show("این کد سیستمی است لذا قابل ویرایش نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                gridControl1.Enabled = false;
                EditRowIndex = gridView1.FocusedRowHandle;
                En = EnumCED.Edit;
                InActiveButtons();

                cmbGroupHesab.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("GroupIndex"));
                txtId.Text = gridView1.GetFocusedRowCellDisplayText("Id");
                txtCode.Text = gridView1.GetFocusedRowCellDisplayText("Code");
                txtNameHesab.Text = gridView1.GetFocusedRowCellDisplayText("HesabName");
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                ActiveControls();
                cmbGroupHesab.ReadOnly = true;
                txtNameHesab.Focus();
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
                            CodingDaramadVHazine obj = new CodingDaramadVHazine();
                            obj.Code = Convert.ToInt32(txtCode.Text);
                            obj.GroupIndex = cmbGroupHesab.SelectedIndex;
                            obj.GroupName = cmbGroupHesab.Text;
                            obj.HesabName = txtNameHesab.Text;
                            obj.SandoghId = Convert.ToInt32(Fm.IDSandogh.Caption);
                            obj.IsActive = chkIsActive.Checked;
                            obj.GroupTafziliId = cmbGroupHesab.SelectedIndex == 0 ? 4 : 5;
                            //obj.SalMaliId= Convert.ToInt32(Fm.IDSalMali.Caption);
                            db.CodingDaramadVHazines.Add(obj);
                            db.SaveChanges();
                            //////////////////////////////////////////
                            int _Code = Convert.ToInt32(txtCode.Text);
                            AllHesabTafzili obj1 = new AllHesabTafzili();
                            obj1.Id2 = db.CodingDaramadVHazines.FirstOrDefault(f => f.Code == _Code).Id;
                            obj1.Code = _Code;
                            obj1.Name = txtNameHesab.Text;
                            obj1.GroupTafziliId = cmbGroupHesab.SelectedIndex == 0 ? 4 : 5;
                            obj1.IsActive = chkIsActive.Checked;
                            obj1.SandoghId = Convert.ToInt32(Fm.IDSandogh.Caption);
                            db.AllHesabTafzilis.Add(obj1);
                            db.SaveChanges();
                            /////////////////////////////////////////////////////////////////////////////////////
                            if (IsActiveList)
                                btnDisplayActiveList_Click(null, null);
                            else
                                btnDisplayNotActiveList_Click(null, null);

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
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            var q = db.CodingDaramadVHazines.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                q.Code = Convert.ToInt32(txtCode.Text);
                                q.GroupIndex = cmbGroupHesab.SelectedIndex;
                                q.GroupName = cmbGroupHesab.Text;
                                q.HesabName = txtNameHesab.Text;
                                q.IsActive = chkIsActive.Checked;
                                q.GroupTafziliId = cmbGroupHesab.SelectedIndex == 0 ? 4 : 5;
                                //////////////////////////////////////////
                                int _Code = Convert.ToInt32(txtCode.Text);
                                var qq1 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 4 || f.GroupTafziliId == 5 && f.Id2 == RowId);
                                if (qq1 != null)
                                {
                                    qq1.Code = _Code;
                                    qq1.Name = txtNameHesab.Text;
                                    qq1.GroupTafziliId = cmbGroupHesab.SelectedIndex == 0 ? 4 : 5;
                                    qq1.IsActive = chkIsActive.Checked;
                                }
                                /////////////////////////////////////////////////////////////////////////////////////

                                db.SaveChanges();
                                if (IsActiveList)
                                    btnDisplayActiveList_Click(null, null);
                                else
                                    btnDisplayNotActiveList_Click(null, null);
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

        private void cmbGroupHesab_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbGroupHesab.ShowPopup();
            }
        }
    }
}