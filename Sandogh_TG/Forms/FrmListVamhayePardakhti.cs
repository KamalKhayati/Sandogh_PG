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
using DevExpress.XtraGrid.Views.Grid;

namespace Sandogh_TG
{
    public partial class FrmListVamhayePardakhti : DevExpress.XtraEditors.XtraForm
    {
        public FrmMain Fm;
        public FrmListVamhayePardakhti(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        public bool ListTasviyeNashode = true;
        public int _VamPardakhtiId = 0;
        public void FillDataGridVamhayePardakhti()
        {
            using (var db = new MyContext())
            {
                try
                {
                    rizeAghsatVamsBindingSource.DataSource = null;
                    if (ListTasviyeNashode == true)
                    {
                        var q1 = db.VamPardakhtis.Where(s => s.IsTasviye == false).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0)
                            vamPardakhtisBindingSource.DataSource = q1;
                        else
                            vamPardakhtisBindingSource.DataSource = null;
                    }
                    else
                    {
                        var q = db.VamPardakhtis.Where(s => s.IsTasviye == true).OrderBy(s => s.Code);
                        if (q.Count() > 0)
                            vamPardakhtisBindingSource.DataSource = q.ToList();
                        else
                            vamPardakhtisBindingSource.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillDataGridRizeAghsatVam()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _VamPardakhtiId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                    var q1 = db.RizeAghsatVams.Where(s => s.VamPardakhtiId == _VamPardakhtiId).OrderBy(s => s.TarikhSarresid).ToList();
                    if (q1.Count > 0)
                        rizeAghsatVamsBindingSource.DataSource = q1;
                    else
                        rizeAghsatVamsBindingSource.DataSource = null;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnCreate1_Click(object sender, EventArgs e)
        {
            FrmVamPardakhti fm = new FrmVamPardakhti(this);
            fm.En = EnumCED.Create;
            fm.ShowDialog();
        }

        private void btnEdit1_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                EditRowIndex = gridView1.FocusedRowHandle;
                using (var db = new MyContext())
                {
                    try
                    {
                        if (ListTasviyeNashode)
                        {
                            int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                            var q = db.RizeAghsatVams.FirstOrDefault(p => p.VamPardakhtiId == RowId && p.MablaghDaryafti > 0);
                            if (q != null)
                            {
                                XtraMessageBox.Show("به دلیل اقساط دریافتی ، بعضی از اطلاعات قابل ویرایش نیست \nجهت ویرایش کلیه اطلاعات ، بایستی در ابتدا اقساط دریافت شده از طریق منوی (دریافت پس انداز ماهیانه و اقساط وام) حذف شود \nضمناً در صورت نداشتن اقساط دریافتی ، جهت حذف و یا ویرایش اطلاعات مربوط به تاریخ سررسید اقساط و مبلغ اقساط میتوانید\n از طریق منوی سمت چپ اقدام نمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                FrmVamPardakhti fm = new FrmVamPardakhti(this);
                                fm.En = EnumCED.Edit;
                                fm.IsEditRizAghsat = false;
                                fm.panelControl1.Enabled = false;
                                fm.panelControl3.Enabled = false;
                                fm.panelControl5.Enabled = false;
                                fm.panelControl6.Enabled = false;
                                fm.panelControl7.Enabled = false;
                                fm.ShowDialog();
                            }
                            else
                            {
                                FrmVamPardakhti fm = new FrmVamPardakhti(this);
                                fm.En = EnumCED.Edit;
                                fm.IsEditRizAghsat = true;
                                fm.ShowDialog();
                            }

                        }
                        else
                        {
                            FrmVamPardakhti fm = new FrmVamPardakhti(this);
                            fm.En = EnumCED.Edit;
                            //fm.IsEditRizAghsat = true;
                            fm.panelControl1.Enabled = fm.panelControl3.Enabled = fm.panelControl4.Enabled = fm.panelControl5.Enabled = fm.panelControl6.Enabled = fm.panelControl7.Enabled = false;
                            fm.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FrmListVamhayePardakhti_Load(object sender, EventArgs e)
        {
            FillDataGridVamhayePardakhti();
        }

        public void btnDisplyActiveList1_Click(object sender, EventArgs e)
        {
            ListTasviyeNashode = true;
            FillDataGridVamhayePardakhti();
            gridView1_FocusedRowChanged(null, null);
            groupBox4.Text = "لیست وامهای پرداختی (تسویه نشده)";
            groupBox4.ForeColor = Color.Blue;
        }

        public void btnDisplyNotActiveList1_Click(object sender, EventArgs e)
        {
            ListTasviyeNashode = false;
            FillDataGridVamhayePardakhti();
            gridView1_FocusedRowChanged(null, null);
            groupBox4.Text = "لیست وامهای پرداختی (تسویه شده)";
            groupBox4.ForeColor = Color.Red;
        }

        private void btnPrintPreview1_Click(object sender, EventArgs e)
        {
            HelpClass1.PrintPreview(gridControl1, gridView1);
        }

        private void btnLast1_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveLast(gridView1);
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveNext(gridView1);

        }

        private void btnPreview1_Click(object sender, EventArgs e)
        {
            HelpClass1.MovePrev(gridView1);

        }

        private void btnFirst1_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveFirst(gridView1);

        }
        int EditRowIndex = 0;
        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (XtraMessageBox.Show("آیا وام مورد نظر حذف شود؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    EditRowIndex = gridView1.FocusedRowHandle;
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                            var qq1 = db.RizeAghsatVams.FirstOrDefault(p => p.VamPardakhtiId == RowId && p.MablaghDaryafti > 0);
                            if (qq1 != null)
                            {
                                XtraMessageBox.Show("به دلیل اقساط دریافتی ، وام فوق قابل حذف نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                var q = db.VamPardakhtis.FirstOrDefault(p => p.Id == RowId);
                                if (q != null)
                                {
                                    db.VamPardakhtis.Remove(q);
                                    var q1 = db.AsnadeHesabdariRows.Where(f => f.ShomareSanad == q.ShomareSanad);
                                    if (q1.Count() > 0)
                                        db.AsnadeHesabdariRows.RemoveRange(q1);
                                    /////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();

                                    if (ListTasviyeNashode)
                                        btnDisplyActiveList1_Click(null, null);
                                    else
                                        btnDisplyNotActiveList1_Click(null, null);
                                    //XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridView1.RowCount > 0)
                                        gridView1.FocusedRowHandle = EditRowIndex - 1;
                                }
                                else
                                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }





                        }
                        //catch (DbUpdateException)
                        //{
                        //    XtraMessageBox.Show("حذف این وام مقدور نیست \n" +
                        //        "جهت حذف وام مورد نظر ، در ابتدا بایستی ریز اقساط وام حذف گردد"
                        //        , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridView1_RowCellClick(null, null);
            //total = new List<long>();
            //FillDataGridRizeAghsatVam();
            chkSelectAll.Checked = false;
            if (ListTasviyeNashode == true)
            {
                if (gridView1.RowCount > 0)
                {
                    btnCreate2.Visible = true;
                    btnDelete2.Visible = true;
                    btnEdit2.Visible = true;
                    chkSelectAll.Visible = true;
                }
            }
            else
            {
                btnCreate2.Visible = false;
                btnDelete2.Visible = false;
                btnEdit2.Visible = false;
                chkSelectAll.Visible = false;
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            _VamPardakhtiId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
            total = new List<long>();
            FillDataGridRizeAghsatVam();

        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);

        }
        List<long> total = new List<long>();
        private void gridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);

            int rowIndex = e.ListSourceRowIndex;
            long MablaghAghsat = Convert.ToInt64(gridView2.GetListSourceRowCellValue(rowIndex, "MablaghAghsat"));
            long MablaghDaryafti = Convert.ToInt64(gridView2.GetListSourceRowCellValue(rowIndex, "MablaghDaryafti"));
            if (e.Column.FieldName != "Mande") return;
            if (e.IsGetData)
            {
                if (rowIndex == 0)
                {
                    total.Add(MablaghAghsat - MablaghDaryafti);
                    e.Value = total[rowIndex];

                }
                else
                {
                    total.Add(total[rowIndex - 1] + MablaghAghsat - MablaghDaryafti);
                    e.Value = total[rowIndex];
                }

            }

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit1_Click(null, null);
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEdit1_Click(null, null);
            }

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            btnEdit2_Click(null, null);
        }

        private void btnEdit2_Click(object sender, EventArgs e)
        {
            if (gridView2.SelectedRowsCount > 0)
            {
                int ColumnMablaghDaryafti = Convert.ToInt32(gridView2.GetFocusedRowCellValue("MablaghDaryafti"));
                if (ColumnMablaghDaryafti > 0)
                {
                    XtraMessageBox.Show("مبلغ قسط مورد نظر قبلاً دریافت شده است لذا قابل ویرایش نیست \nجهت ویرایش بایستی در ابتدا مبلغ قسط دریافت شده از طریق منوی (دریافت پس انداز ماهیانه و اقساط وام) حذف شود ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    return;
                }
                else
                {
                    FrmRizAghsatVam fm = new FrmRizAghsatVam(this);
                    fm.En = EnumCED.Edit;
                    fm.EditRowIndex = gridView2.FocusedRowHandle;
                    //fm.IDSandogh.Text = IDSandogh.Text;
                    fm.ShowDialog();
                }
            }
        }

        private void gridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEdit2_Click(null, null);
            }
        }

        private void btnLast2_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveLast(gridView2);

        }

        private void btnNext2_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveNext(gridView2);

        }

        private void btnPreview2_Click(object sender, EventArgs e)
        {
            HelpClass1.MovePrev(gridView2);

        }

        private void btnFirst2_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveFirst(gridView2);

        }

        public void btnDisplyActiveList2_Click(object sender, EventArgs e)
        {
            FillDataGridRizeAghsatVam();
        }

        private void btnPrintPreview2_Click(object sender, EventArgs e)
        {
            HelpClass1.PrintPreview(gridControl2, gridView2);

        }

        public void btnCreate2_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                FrmRizAghsatVam fm = new FrmRizAghsatVam(this);
                fm.En = EnumCED.Create;
                //fm.IDSandogh.Text = IDSandogh.Text;
                fm.ShowDialog();
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gridView2.SelectedRowsCount > 0)
            {
                int ColumnSum = 0;
                if (chkSelectAll.Checked)
                {
                    if (XtraMessageBox.Show("آیا همه اقساط وام جاری شوند؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ColumnSum = Convert.ToInt32(gridView2.Columns["MablaghDaryafti"].SummaryItem.SummaryValue);
                        if (ColumnSum != 0)
                        {
                            XtraMessageBox.Show("تعدادی از اقساط قبلاً دریافت شده اند لذا قابل حذف نیستند \nجهت حذف اقساط بایستی در ابتدا مبلغ اقساط دریافت شده از طریق منوی (دریافت پس انداز ماهیانه و اقساط وام) حذف شوند ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                            return;
                        }
                        else
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int VamId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.RizeAghsatVams.Where(p => p.VamPardakhtiId == VamId).ToList();
                                    if (q.Count() > 0)
                                    {
                                        db.RizeAghsatVams.RemoveRange(q);
                                        db.SaveChanges();
                                        btnDisplyActiveList2_Click(null, null);
                                        //XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (XtraMessageBox.Show("آیا قسط مورد نظر حذف شود؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (Convert.ToInt32(gridView2.GetFocusedRowCellValue("MablaghDaryafti")) > 0)
                        {
                            XtraMessageBox.Show("قسط مورد نظر قبلاً دریافت شده است لذا قابل حذف نیست \nجهت حذف بایستی در ابتدا مبلغ قسط دریافت شده از طریق منوی (دریافت پس انداز ماهیانه و اقساط وام) حذف شود ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                            return;
                        }
                        else
                        {
                            EditRowIndex = gridView2.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridView2.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.RizeAghsatVams.FirstOrDefault(p => p.Id == RowId);
                                    if (q != null)
                                    {
                                        db.RizeAghsatVams.Remove(q);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();

                                        btnDisplyActiveList2_Click(null, null);
                                        //XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView2.RowCount > 0)
                                            gridView2.FocusedRowHandle = EditRowIndex - 1;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //catch (DbUpdateException)
                                //{
                                //    XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این وام مقدور نیست \n" +
                                //        "جهت حذف وام مورد نظر در ابتدا بایستی ریز اقساط وام مذکور حذف گردد"
                                //        , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //}
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                gridView2.OptionsSelection.MultiSelect = true;
                gridView2.SelectAll();
            }
            else
            {
                gridView2.OptionsSelection.MultiSelect = false;
                //gridView2.UnSelectCells(0, ColLine, gridView2.TopRowIndex, colMablaghAghsat);
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (ListTasviyeNashode == false)
            //{
            //    btnCreate2.Visible = false;
            //    btnDelete2.Visible = false;
            //    btnEdit2.Visible = false;
            //    chkSelectAll.Visible = false;
            //}
        }

        private void gridView2_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            HelpClass1.gridView_CustomSummaryCalculate(sender, e, gridView2, "MablaghAghsat", "MablaghDaryafti", "Mande");

        }
    }
}