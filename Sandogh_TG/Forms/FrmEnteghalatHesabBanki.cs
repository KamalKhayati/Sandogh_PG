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
    public partial class FrmEnteghalatHesabBanki : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmEnteghalatHesabBanki(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        #region MyRegion
        public EnumCED En;

        public void FillDataGridEnteghalatHesabBanki()
        {
            //using (var db = new MyContext())
            //{
            //    try
            //    {
            //        var q1 = db.EnteghalatHesabBankis.OrderBy(s => s.Seryal).ToList();
            //        if (q1.Count > 0)
            //            enteghalatHesabBankisBindingSource.DataSource = q1;
            //        else
            //            enteghalatHesabBankisBindingSource.DataSource = null;
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
            //            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

        }

        public void FillcmbHesabBanki1()
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

        public void FillcmbHesabBanki2()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (En == EnumCED.Create)
                    {
                        int _HesabBanki1Id = Convert.ToInt32(cmbHesabBanki1.EditValue);
                        var q1 = db.HesabBankis.Where(f => f.IsActive == true && f.Id != _HesabBanki1Id).ToList();
                        if (q1.Count > 0)
                            hesabBankisBindingSource1.DataSource = q1;
                        else
                            hesabBankisBindingSource1.DataSource = null;

                    }
                    else
                    {
                        var q1 = db.HesabBankis.Select(f => f).ToList();
                        if (q1.Count > 0)
                            hesabBankisBindingSource1.DataSource = q1;
                        else
                            hesabBankisBindingSource1.DataSource = null;


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
            //        var q = db.EnteghalatHesabBankis.Select(s => s);
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
            //                    XtraMessageBox.Show("اعمال محدودیت ثبت حداکثر 9999999 سریال انتقالی" + "\n" +
            //                        "توجه : نمیتوان بیشتر از این تعداد سریال، انتقالی ثبت نمود ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void FrmEnteghalatHesabBanki_Load(object sender, EventArgs e)
        {
            FillDataGridEnteghalatHesabBanki();
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
            else if (string.IsNullOrEmpty(cmbHesabBanki1.Text))
            {
                XtraMessageBox.Show("انتقالی از چه حسابی انجام شود؟", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabBanki1.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(cmbHesabBanki2.Text))
            {
                XtraMessageBox.Show("انتقالی به چه حسابی انجام شود؟", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabBanki2.Focus();
                return false;
            }
            else if (txtMablagh.Text == "0")
            {
                XtraMessageBox.Show("لطفاً مبلغ را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMablagh.Focus();
                return false;
            }
            return true;
        }

        private void FrmEnteghalatHesabBanki_KeyDown(object sender, KeyEventArgs e)
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
            FillDataGridEnteghalatHesabBanki();
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
            cmbHesabBanki1.EditValue = 0;
            txtMablagh.Text = string.Empty;
            cmbHesabBanki2.EditValue = 0;
            txtSharh.Text = string.Empty;
        }

        public void ActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                txtTarikh.ReadOnly = false;
                cmbHesabBanki1.ReadOnly = false;
                txtMablagh.ReadOnly = false;
                cmbHesabBanki2.ReadOnly = false;
                txtSharh.ReadOnly = false;
            }
            FillcmbHesabBanki1();
        }

        public void InActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                txtTarikh.ReadOnly = true;
                cmbHesabBanki1.ReadOnly = true;
                txtMablagh.ReadOnly = true;
                cmbHesabBanki2.ReadOnly = true;
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
            txtTarikh.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (gridView1.SelectedRowsCount > 0)
            //{
            //    if (XtraMessageBox.Show("آیا انتقالی فوق حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //    {
            //        EditRowIndex = gridView1.FocusedRowHandle;
            //        using (var db = new MyContext())
            //        {
            //            try
            //            {
            //                int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
            //                var q = db.EnteghalatHesabBankis.FirstOrDefault(p => p.Id == RowId);
            //                if (q != null)
            //                {
            //                    db.EnteghalatHesabBankis.Remove(q);
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
                cmbHesabBanki1.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabBanki1Id"));
                txtMablagh.Text = gridView1.GetFocusedRowCellValue("Mablagh").ToString();
                cmbHesabBanki2.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabBanki2Id"));
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
            //                EnteghalatHesabBanki obj = new EnteghalatHesabBanki();
            //                obj.Seryal = Convert.ToInt32(txtSeryal.Text);
            //                if (!string.IsNullOrEmpty(txtTarikh.Text))
            //                    obj.Tarikh = Convert.ToDateTime(txtTarikh.Text);
            //                obj.Mablagh = Convert.ToDecimal(txtMablagh.Text);
            //                obj.HesabBanki1Id = Convert.ToInt32(cmbHesabBanki1.EditValue);
            //                obj.HesabBanki1Name = cmbHesabBanki1.Text;
            //                obj.HesabBanki2Id = Convert.ToInt32(cmbHesabBanki2.EditValue);
            //                obj.HesabBanki2Name = cmbHesabBanki2.Text;
            //                obj.Sharh = txtSharh.Text;
            //                obj.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);

            //                db.EnteghalatHesabBankis.Add(obj);
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
            //                var q = db.EnteghalatHesabBankis.FirstOrDefault(p => p.Id == RowId);
            //                if (q != null)
            //                {
            //                    if (!string.IsNullOrEmpty(txtTarikh.Text))
            //                        q.Tarikh = Convert.ToDateTime(txtTarikh.Text);
            //                    q.Mablagh = Convert.ToDecimal(txtMablagh.Text);
            //                    q.HesabBanki1Id = Convert.ToInt32(cmbHesabBanki1.EditValue);
            //                    q.HesabBanki1Name = cmbHesabBanki1.Text;
            //                    q.HesabBanki2Id = Convert.ToInt32(cmbHesabBanki2.EditValue);
            //                    q.HesabBanki2Name = cmbHesabBanki2.Text;
            //                    q.Sharh = txtSharh.Text;

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

        private void cmbHesabBanki1_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbHesabBanki1.ShowPopup();
            }
        }

        private void cmbHesabBanki2_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbHesabBanki2.ShowPopup();
            }
        }

        private void txtMablagh_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMablagh.Text) && txtMablagh.Text != "0")
            {
                txtSharh.Text = "بابت انتقال وجه";
            }
        }

        private void cmbHesabBanki1_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbHesabBanki2();
        }
        #endregion
    }
}