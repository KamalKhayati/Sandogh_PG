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

namespace Sandogh_PG.Forms
{
    public partial class FrmTarifSalMali : DevExpress.XtraEditors.XtraForm
    {
        public FrmTarifSalMali()
        {
            InitializeComponent();
        }
        public EnumCED En;
        public int EditRowIndex = 0;
        public void FillDataGridSalMali()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q1 = db.SalMalis.OrderBy(s => s.NameSandogh).ToList();
                    if (q1.Count > 0)
                        salMalisBindingSource.DataSource = q1;
                    else
                        salMalisBindingSource.DataSource = null;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillcmbNameSandoogh()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q1 = db.TarifSandoghs.OrderBy(s => s.Id).ToList();
                    if (q1.Count > 0)
                        tarifSandoghsBindingSource.DataSource = q1;
                    else
                        tarifSandoghsBindingSource.DataSource = null;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void FrmTarifSalMali_Load(object sender, EventArgs e)
        {
            FillDataGridSalMali();
            FillcmbNameSandoogh();
        }

        private void FrmTarifSalMali_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.F9)
            {
                btnSaveNext_Click(sender, null);
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

        public void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbNameSandoogh.Text))
            {
                XtraMessageBox.Show("فیلد نام پرداخت کننده نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(txtStartDate.Text))
            {
                XtraMessageBox.Show("لطفاً شروع دوره مالی را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(txtEndDate.Text))
            {
                XtraMessageBox.Show("لطفاً پایان دوره مالی را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(txtSalMali.Text))
            {
                XtraMessageBox.Show("لطفاً سالی مالی را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            SalMali obj = new SalMali();
                            obj.Id = db.SalMalis.Any() ? db.SalMalis.Max(f => f.Id) + 1 : 1;
                            obj.TarifSandoghId = Convert.ToInt32(cmbNameSandoogh.EditValue);
                            obj.NameSandogh = cmbNameSandoogh.Text;
                            obj.SaleMali = Convert.ToInt32(txtSalMali.Text);
                            obj.StartDate = Convert.ToDateTime(txtStartDate.Text.Substring(0, 10));
                            obj.EndDate = Convert.ToDateTime(txtEndDate.Text.Substring(0, 10));
                            obj.IsDefault = chkIsDefault.Checked;
                            db.SalMalis.Add(obj);
                            db.SaveChanges();
                            //XtraMessageBox.Show("اطلاعات با موفقیت ثبت شد", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnDisplyActiveList_Click(null, null);
                            gridView1.MoveLast();
                            gridControl1.Enabled = true;
                            ActiveButtons();
                            ClearControls();
                            InActiveControls();
                            En = EnumCED.Save;
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.SalMalis.FirstOrDefault(s => s.Id == RowId);
                            if (q != null)
                            {
                                q.TarifSandoghId = Convert.ToInt32(cmbNameSandoogh.EditValue);
                                q.NameSandogh = cmbNameSandoogh.Text;
                                q.SaleMali = Convert.ToInt32(txtSalMali.Text);
                                q.StartDate = Convert.ToDateTime(txtStartDate.Text.Substring(0, 10));
                                q.EndDate = Convert.ToDateTime(txtEndDate.Text.Substring(0, 10));
                                q.IsDefault = chkIsDefault.Checked;
                                db.SaveChanges();
                                //XtraMessageBox.Show("اطلاعات با موفقیت ویرایش شد", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnDisplyActiveList_Click(null, null);
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex;
                                gridControl1.Enabled = true;
                                ActiveButtons();
                                ClearControls();
                                InActiveControls();
                                En = EnumCED.Save;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //En = EnumCED.Cancel;
            this.Close();
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
            FillDataGridSalMali();
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

        public void ActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                //cmbNameSandoogh.ReadOnly = false;
                txtSalMali.ReadOnly = false;
                txtStartDate.ReadOnly = false;
                txtEndDate.ReadOnly = false;
                chkIsDefault.ReadOnly = false;
            }
        }

        public void InActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                //cmbNameSandoogh.ReadOnly = true;
                txtSalMali.ReadOnly = true;
                txtStartDate.ReadOnly = true;
                txtEndDate.ReadOnly = true;
                chkIsDefault.ReadOnly = true;
            }
        }

        public void ClearControls()
        {
            cmbNameSandoogh.EditValue = 0;
            txtSalMali.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            txtEndDate.Text = string.Empty;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            En = EnumCED.Create;
            gridControl1.Enabled = false;
            InActiveButtons();
            ClearControls();
            ActiveControls();
            cmbNameSandoogh.EditValue = 1;
            txtSalMali.Text = "1398";
            txtStartDate.Text = "1398/01/01";
            txtEndDate.Text = DateTime.Now.ToString().Substring(0, 10);
            txtSalMali.Focus();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (XtraMessageBox.Show("آیا سال مالی مورد نظر حذف شود؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (XtraMessageBox.Show("در صورت حذف تمامی اطلاعات سال مالی مورد نظر حذف خواهد شد آیا برای حذف مطمئن هستید؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        EditRowIndex = gridView1.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                                var q = db.SalMalis.FirstOrDefault(p => p.Id == RowId);
                                if (q != null)
                                {
                                    db.SalMalis.Remove(q);
                                    /////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();

                                    btnDisplyActiveList_Click(null, null);
                                    XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridView1.RowCount > 0)
                                        gridView1.FocusedRowHandle = EditRowIndex - 1;
                                }
                                else
                                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (DbUpdateException)
                            {
                                XtraMessageBox.Show("به دلیل اینکه از سال مالی فوق جهت صدور سند استفاده شده است لذا قابل حذف نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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
                txtId.Text = gridView1.GetFocusedRowCellDisplayText("Id");
                cmbNameSandoogh.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("TarifSandoghId"));
                txtSalMali.Text = gridView1.GetFocusedRowCellDisplayText("SaleMali");
                txtStartDate.Text = gridView1.GetFocusedRowCellDisplayText("StartDate").Substring(0, 10);
                txtEndDate.Text = gridView1.GetFocusedRowCellDisplayText("EndDate").Substring(0, 10);
                chkIsDefault.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsDefault"));
                txtSalMali.ReadOnly = true;
                txtStartDate.Focus();
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

        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
            if (En == EnumCED.Save)
                btnCreate_Click(null, null);
        }

        private void cmbNameSandoogh_Enter(object sender, EventArgs e)
        {
            if(En==EnumCED.Create)
            cmbNameSandoogh.ShowPopup();
        }
    }
}
