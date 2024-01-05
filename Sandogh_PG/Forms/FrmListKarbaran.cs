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
using System.Security.Cryptography;
using DevExpress.XtraGrid.Views.Grid;

namespace Sandogh_PG
{
    public partial class FrmListKarbaran : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmListKarbaran(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        public EnumCED En;
        public int EditRowIndex = 0;
        public void FillDataGridListKarbaran()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _UserId = Convert.ToInt32(Fm.txtUserId.Caption);
                    if (_UserId==2)
                    {
                        var q1 = db.Karbarans.ToList();
                        if (q1.Count > 0)
                            karbaransBindingSource.DataSource = q1;
                        else
                            karbaransBindingSource.DataSource = null;

                    }
                    else
                    {
                        var q1 = db.Karbarans.FirstOrDefault(s=>s.Id== _UserId);
                        if (q1!=null)
                            karbaransBindingSource.DataSource = q1;
                        else
                            karbaransBindingSource.DataSource = null;

                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void FrmListKarbaran_Load(object sender, EventArgs e)
        {
            FillDataGridListKarbaran();
            int _UserId = Convert.ToInt32(Fm.txtUserId.Caption);
            if (_UserId == 2 || _UserId == 3)
            {
                //txtName.Enabled = false;
                btnCreate.Visible = true;
            }
            else
            {
                //txtName.Enabled = true;
                btnCreate.Visible = false;
            }

        }

        private void FrmListKarbaran_KeyDown(object sender, KeyEventArgs e)
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
                btnDisplyList_Click(sender, null);
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
            if (string.IsNullOrEmpty(txtName.Text))
            {
                XtraMessageBox.Show("لطفاً نام و نام خانوادگی کاربر را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(txtShenase.Text))
            {
                XtraMessageBox.Show("لطفاً شناسه کاریری را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                XtraMessageBox.Show("لطفاً پسورد را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            //SHA256CryptoServiceProvider Sha2 = new SHA256CryptoServiceProvider();
                            //Byte[] B1;
                            //Byte[] B2;

                            //B1 = UTF8Encoding.UTF8.GetBytes(txtPassword.Text.Trim());
                            //B2 = Sha2.ComputeHash(B1);
                            //string P1 = BitConverter.ToString(B2);

                            Karbaran obj = new Karbaran();
                            obj.Name = txtName.Text;
                            obj.Shenase = HelpClass1.EncryptText(txtShenase.Text);
                            obj.Password = HelpClass1.EncryptText(txtPassword.Text);
                            db.Karbarans.Add(obj);
                            db.SaveChanges();
                            //XtraMessageBox.Show("اطلاعات با موفقیت ثبت شد", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnDisplyList_Click(null, null);
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
                            var q = db.Karbarans.FirstOrDefault(s => s.Id == RowId);
                            if (q != null)
                            {
                                q.Name = txtName.Text;
                                q.Shenase = HelpClass1.EncryptText(txtShenase.Text);
                                q.Password = HelpClass1.EncryptText(txtPassword.Text);
                                db.SaveChanges();
                                //XtraMessageBox.Show("اطلاعات با موفقیت ویرایش شد", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnDisplyList_Click(null, null);
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex;
                                gridControl1.Enabled = true;
                                ActiveButtons();
                                ClearControls();
                                InActiveControls();
                                En = EnumCED.Save;
                            }
                            btnDelete.Enabled = btnEdit.Enabled = false;

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

        public void btnDisplyList_Click(object sender, EventArgs e)
        {
            FillDataGridListKarbaran();
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
               
                txtName.ReadOnly = false;
                txtShenase.ReadOnly = false;
                txtPassword.ReadOnly = false;
            }
            if(En == EnumCED.Create)
            txtName.Enabled = true;
        }

        public void InActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                //cmbNameSandoogh.ReadOnly = true;
                txtName.Enabled = false;
                txtName.ReadOnly = true;
                txtShenase.ReadOnly = true;
                txtPassword.ReadOnly = true;
            }
            txtName.Enabled = false;

        }

        public void ClearControls()
        {
            txtName.Text = string.Empty;
            txtShenase.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            En = EnumCED.Create;
            gridControl1.Enabled = false;
            InActiveButtons();
            ClearControls();
            ActiveControls();
            txtName.Focus();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (XtraMessageBox.Show("آیا کاربر مورد نظر حذف شود؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    EditRowIndex = gridView1.FocusedRowHandle;
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                            var q = db.Karbarans.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                if (q.Id == 1)
                                {
                                    XtraMessageBox.Show("کاربر فوق سیستمی است لذا قابل حذف نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    return;
                                }
                                db.Karbarans.Remove(q);
                                /////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();

                                btnDisplyList_Click(null, null);
                                //XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex - 1;

                                btnDelete.Enabled = btnEdit.Enabled = false;

                            }
                            else
                                XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //catch (DbUpdateException)
                        //{
                        //    XtraMessageBox.Show("به دلیل اینکه از سال مالی فوق جهت صدور سند استفاده شده است لذا قابل حذف نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtId.Text = gridView1.GetFocusedRowCellDisplayText("Id");
                txtName.Text = gridView1.GetFocusedRowCellDisplayText("Name");
                txtShenase.Text = gridView1.GetFocusedRowCellDisplayText("Shenase");
                txtPassword.Text = gridView1.GetFocusedRowCellDisplayText("Password");
                txtName.Focus();
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
            // btnDelete.Enabled = btnEdit.Enabled = gridView1.RowCount > 0 ? true : false;
            int _UserId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
            //btnTanzimat.Visibility = btnAllDataDelete.Visibility = _UserId == 2 ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            //rpgTanzimat.Visible = _UserId == 2 ? true : false;
            if (_UserId == 1||_UserId == 2 || _UserId == 3)
            {
                txtName.Enabled = false;
                btnDelete.Visible = false;
            }
            else
            {
                txtName.Enabled = true;
                btnDelete.Visible = true;
            }

        }

        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
            if (En == EnumCED.Save)
                btnCreate_Click(null, null);
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {

            if (gridView1.RowCount > 0)
            {
                btnDelete.Enabled = btnEdit.Enabled =  true ;
                using (var db = new MyContext())
                {
                    try
                    {
                        FillDataGridListKarbaran();
                        int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                        int RowIndex = gridView1.FocusedRowHandle;
                        var q = db.Karbarans.FirstOrDefault(f => f.Id == RowId);
                        if (q != null)
                        {
                            gridView1.SetRowCellValue(RowIndex, "Password", HelpClass1.DecryptText(q.Password.ToString()));
                            gridView1.SetRowCellValue(RowIndex, "Shenase", HelpClass1.DecryptText(q.Shenase.ToString()));
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
    }
}