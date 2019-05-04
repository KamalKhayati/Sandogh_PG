﻿using System;
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
    public partial class FrmDaryafti : DevExpress.XtraEditors.XtraForm
    {
        public FrmMain Fm;
        public FrmDaryafti(FrmMain fm)
        {
            InitializeComponent();
            Fm=fm;
        }
        public bool IsActiveList1 = true;
        public bool IsActiveList2 = true;
        int _VamId = 0;
        int _AazaId = 0;
        public void FillDataGridAazaSandogh()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    haghOzviatsBindingSource.DataSource = null;
                    haghOzviatsBindingSource.DataSource = null;
                    vamPardakhtisBindingSource.DataSource = null;
                    rizeAghsatVamsBindingSource.DataSource = null;
                    if (IsActiveList1 == true)
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
        public void FillDataGridHaghOzviat()
        {
            using (var db = new MyContext())
            {
                try
                {
                    haghOzviatsBindingSource.DataSource = null;
                    _AazaId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                    var qq = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 3 && f.Id2 == _AazaId);

                    if (qq!=null)
                    {
                        var q1 = db.HaghOzviats.Where(s => s.AazaId == qq.Id).OrderBy(s => s.Tarikh).ThenBy(s=>s.Seryal).ToList();
                        if (q1.Count > 0)
                            haghOzviatsBindingSource.DataSource = q1;
                        else
                            haghOzviatsBindingSource.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillDataGridVamhayePardakhti()
        {
            using (var db = new MyContext())
            {
                try
                {
                    vamPardakhtisBindingSource.DataSource = null;
                    rizeAghsatVamsBindingSource.DataSource = null;
                    _AazaId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                    var qq = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 3 && f.Id2 == _AazaId);
                    if (qq!=null)
                    {
                        if (IsActiveList2 == true)
                        {
                            var q1 = db.VamPardakhtis.Where(s => s.IsTasviye == false && s.AazaId == qq.Id).OrderBy(s => s.Code).ToList();
                            if (q1.Count > 0)
                                vamPardakhtisBindingSource.DataSource = q1;
                            else
                                vamPardakhtisBindingSource.DataSource = null;
                        }
                        else
                        {
                            var q = db.VamPardakhtis.Where(s => s.IsTasviye == true && s.AazaId == qq.Id).OrderBy(s => s.Code);
                            if (q.Count() > 0)
                                vamPardakhtisBindingSource.DataSource = q.ToList();
                            else
                                vamPardakhtisBindingSource.DataSource = null;
                        }

                    }                }
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
                    rizeAghsatVamsBindingSource.DataSource = null;
                    _VamId = Convert.ToInt32(gridView3.GetFocusedRowCellValue("Id"));
                    var q1 = db.RizeAghsatVams.Where(s => s.VamPardakhtiId == _VamId).OrderBy(s => s.TarikhSarresid).ToList();
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

        public void btnCreate2_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                FrmDaryaftHaghOzviat fm = new FrmDaryaftHaghOzviat(this);
                fm.En = EnumCED.Create;
                fm.ShowDialog();
            }
        }

        private void btnEdit2_Click(object sender, EventArgs e)
        {
            if (gridView2.SelectedRowsCount > 0)
            {
                FrmDaryaftHaghOzviat fm = new FrmDaryaftHaghOzviat(this);
                fm.En = EnumCED.Edit;
                fm.ShowDialog();

            }
        }

        public void btnDisplyList2_Click(object sender, EventArgs e)
        {
            FillDataGridHaghOzviat();
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);
        }

        private void gridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);
        }

        private void FrmDaryafti_Load(object sender, EventArgs e)
        {
            FillDataGridAazaSandogh();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (IsActiveList1 == true && IsActiveList2 == true)
            {
                //FillDataGridVamhayePardakhti();
                gridView1_RowCellClick(null, null);
                groupBox1.Text = "اشخاص (فعال)";
                groupBox1.ForeColor = Color.Blue;
                groupBox4.Text = "وامهای (تسویه نشده)";
                groupBox4.ForeColor = Color.Blue;
            }
            else if (IsActiveList1 == true && IsActiveList2 == false)
            {
                IsActiveList2 = true;
                //FillDataGridVamhayePardakhti();
                gridView1_RowCellClick(null, null);
                groupBox1.Text = "اشخاص (فعال)";
                groupBox1.ForeColor = Color.Blue;
                groupBox4.Text = "وامهای (تسویه نشده)";
                groupBox4.ForeColor = Color.Blue;
            }
            else if (IsActiveList1 == false && IsActiveList2 == false)
            {
                //FillDataGridVamhayePardakhti();
                gridView1_RowCellClick(null, null);
                groupBox1.Text = "اعضاء (غیرفعال)";
                groupBox1.ForeColor = Color.Red;
                groupBox4.Text = "وامهای (تسویه شده)";
                groupBox4.ForeColor = Color.Red;
            }
            else if (IsActiveList1 == false && IsActiveList2 == true)
            {
                IsActiveList2 = false;
                //FillDataGridVamhayePardakhti();
                gridView1_RowCellClick(null, null);
                groupBox1.Text = "اعضاء (غیرفعال)";
                groupBox1.ForeColor = Color.Red;
                groupBox4.Text = "وامهای (تسویه شده)";
                groupBox4.ForeColor = Color.Red;
            }
        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //total = new List<long>();
            ////FillDataGridRizeAghsatVam();
            gridView3_RowCellClick(null, null);
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

        private void btnDisplayActiveList1_Click(object sender, EventArgs e)
        {
            IsActiveList1 = true;
            FillDataGridAazaSandogh();
            //gridView1_RowCellClick(null, null);
            //gridView3_RowCellClick(null, null);
            gridView1_FocusedRowChanged(null, null);
            gridView3_FocusedRowChanged(null, null);
            groupBox1.Text = "اشخاص (فعال)";
            groupBox1.ForeColor = Color.Blue;
            groupBox4.Text = "وامهای (تسویه نشده)";
            groupBox4.ForeColor = Color.Blue;

        }

        private void btnDisplayNotActiveList1_Click(object sender, EventArgs e)
        {
            IsActiveList1 = false;
            FillDataGridAazaSandogh();
            //gridView1_RowCellClick(null, null);
            //gridView3_RowCellClick(null, null);
            gridView1_FocusedRowChanged(null, null);
            gridView3_FocusedRowChanged(null, null);
            groupBox1.Text = "اعضاء (غیرفعال)";
            groupBox1.ForeColor = Color.Red;
            groupBox4.Text = "وامهای (تسویه شده)";
            groupBox4.ForeColor = Color.Red;

        }

        private void btnPrintPreview1_Click(object sender, EventArgs e)
        {
            HelpClass1.PrintPreview(gridControl1, gridView1);
        }

        private void btnPrintPreview2_Click(object sender, EventArgs e)
        {
            HelpClass1.PrintPreview(gridControl2, gridView2);

        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            FillDataGridHaghOzviat();
            //btnDisplyList2_Click(null, null);
            FillDataGridVamhayePardakhti();
            gridView3_RowCellClick(null, null);
            if (IsActiveList1 == true)
            {
                if (gridView1.RowCount > 0)
                {
                    btnCreate2.Visible = true;
                    btnDelete2.Visible = true;
                    btnEdit2.Visible = true;
                }
            }
            else
            {
                btnCreate2.Visible = false;
                btnDelete2.Visible = false;
                btnEdit2.Visible = false;
                btnCreate4.Visible = false;
                btnDelete4.Visible = false;
                btnEdit4.Visible = false;
            }

        }
        int EditRowIndex = 0;
        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gridView2.SelectedRowsCount > 0)
            {
                if (XtraMessageBox.Show("آیا ردیف مورد نظر حذف شود؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    EditRowIndex = gridView1.FocusedRowHandle;
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(gridView2.GetFocusedRowCellValue("Id").ToString());
                            var q = db.HaghOzviats.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                db.HaghOzviats.Remove(q);
                                var q1 = db.AsnadeHesabdariRows.Where(f => f.ShomareSanad == q.ShomareSanad);
                                if (q1.Count() > 0)
                                    db.AsnadeHesabdariRows.RemoveRange(q1);

                                /////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();

                                btnDisplyList2_Click(null, null);
                                //XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView2.RowCount > 0)
                                    gridView2.FocusedRowHandle = EditRowIndex - 1;
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

        private void btnCreate3_Click(object sender, EventArgs e)
        {
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            btnEdit2_Click(null, null);
        }

        private void gridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEdit2_Click(null, null);
            }

        }

        List<long> total = new List<long>();
        public int IndexAkharinDaruaft = -1;
        private void gridView4_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);

            int rowIndex = e.ListSourceRowIndex;
            long MablaghAghsat = Convert.ToInt64(gridView4.GetListSourceRowCellValue(rowIndex, "MablaghAghsat"));
            long MablaghDaryafti = Convert.ToInt64(gridView4.GetListSourceRowCellValue(rowIndex, "MablaghDaryafti"));
            if (e.Column.FieldName != "Mande") return;
            if (e.IsGetData)
            {
                if (rowIndex == 0)
                {
                    total.Add(MablaghAghsat - MablaghDaryafti);
                    e.Value = total[rowIndex];
                    if (Convert.ToInt32(e.Value) == 0)
                    {
                        IndexAkharinDaruaft = rowIndex;
                    }
                }
                else
                {
                    total.Add(total[rowIndex - 1] + MablaghAghsat - MablaghDaryafti);
                    e.Value = total[rowIndex];
                    if (Convert.ToInt32(e.Value) == 0)
                    {
                        IndexAkharinDaruaft = rowIndex;
                    }
                }
            }
        }

        private void gridView3_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);

        }

        public void btnCreate4_Click(object sender, EventArgs e)
        {
            if (gridView4.RowCount > 0)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _CodeVam = Convert.ToInt32(gridView3.GetFocusedRowCellDisplayText("Code"));
                        var q1 = db.RizeAghsatVams.FirstOrDefault(s => s.VamPardakhtiCode == _CodeVam && s.SeryalDaryaft == 0);
                        if (q1 != null)
                        {
                            FrmDaryafteAghsateVam fm = new FrmDaryafteAghsateVam(this);
                            fm.En = EnumCED.Create;
                            fm.ShowDialog();
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

        private void btnDelete4_Click(object sender, EventArgs e)
        {
            if (gridView4.SelectedRowsCount > 0)
            {
                if (Convert.ToInt32(gridView4.GetFocusedRowCellValue("SeryalDaryaft")) != 0)
                {
                    if (XtraMessageBox.Show("آیا دریافت قسط مورد نظر حذف شود؟", "پیغام حذف دریافت اقساط وام", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        EditRowIndex = gridView4.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int RowId = Convert.ToInt32(gridView4.GetFocusedRowCellValue("Id").ToString());
                                var q = db.RizeAghsatVams.FirstOrDefault(p => p.Id == RowId);
                                if (q != null)
                                {
                                    q.SeryalDaryaft = 0;
                                    q.TarikhDaryaft = null;
                                    q.MablaghDaryafti = 0;
                                    q.NameHesabId = 0;
                                    q.NameHesab = string.Empty;
                                    q.Sharh = string.Empty;
                                    q.ShomareSanad = 0;
                                    ///////////////////////////////////////////////////////////////////
                                    var q1 = db.AsnadeHesabdariRows.Where(f => f.ShomareSanad == q.ShomareSanad);
                                    if (q1.Count() > 0)
                                        db.AsnadeHesabdariRows.RemoveRange(q1);
                                    //////////////////////////////////////////////////////////////////
                                    db.SaveChanges();
                                    btnDisplyActiveList4_Click(null, null);
                                    //XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridView4.RowCount > 0)
                                        gridView4.FocusedRowHandle = EditRowIndex - 1;

                                    var q2 = db.VamPardakhtis.FirstOrDefault(s => s.Id == q.VamPardakhtiId);
                                    if (q2.IsTasviye == false)
                                    {
                                        if (Convert.ToInt32(gridView4.Columns["Mande"].SummaryItem.SummaryValue) == 0)
                                        {
                                            if (XtraMessageBox.Show("آیا وام فوق به لیست وامهای تسویه شده انتقال یابد؟", "پیغام ثبت ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                            {
                                                if (q2 != null)
                                                {
                                                    q2.IsTasviye = true;
                                                    db.SaveChanges();
                                                    btnDisplyActiveList3_Click(null, null);
                                                }
                                            }

                                        }
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(gridView4.Columns["Mande"].SummaryItem.SummaryValue) != 0)
                                        {
                                            if (XtraMessageBox.Show("با حذف دریافت این قسط ، وام مذکور از حالت تسویه خارج شد آیا وام فوق به لیست وامهای تسویه نشده انتقال یابد؟", "پیغام ثبت ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                            {
                                                if (q2 != null)
                                                {
                                                    q2.IsTasviye = false;
                                                    db.SaveChanges();
                                                    btnDisplyActiveList3_Click(null, null);
                                                }
                                            }
                                        }
                                    }

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

        }

        private void btnEdit4_Click(object sender, EventArgs e)
        {
            if (gridView4.SelectedRowsCount > 0)
            {
                if (Convert.ToInt32(gridView4.GetFocusedRowCellValue("SeryalDaryaft")) != 0)
                {
                    FrmDaryafteAghsateVam fm = new FrmDaryafteAghsateVam(this);
                    fm.En = EnumCED.Edit;
                    fm.EditRowIndex = gridView4.FocusedRowHandle;
                    fm.ShowDialog();
                }
            }

        }

        private void btnLast3_Click(object sender, EventArgs e)
        {
            gridView3.MoveLast();

        }

        private void btnNext3_Click(object sender, EventArgs e)
        {
            gridView3.MoveNext();

        }

        private void btnPreview3_Click(object sender, EventArgs e)
        {
            gridView3.MovePrev();

        }

        private void btnFirst3_Click(object sender, EventArgs e)
        {
            gridView3.MoveFirst();

        }

        private void btnLast4_Click(object sender, EventArgs e)
        {
            gridView4.MoveLast();

        }

        private void btnNext4_Click(object sender, EventArgs e)
        {
            gridView4.MoveNext();

        }

        private void btnPreview4_Click(object sender, EventArgs e)
        {
            gridView4.MovePrev();

        }

        private void btnFirst4_Click(object sender, EventArgs e)
        {
            gridView4.MoveFirst();

        }

        private void btnPrintPreview3_Click(object sender, EventArgs e)
        {
            HelpClass1.PrintPreview(gridControl3, gridView3);

        }

        private void btnPrintPreview4_Click(object sender, EventArgs e)
        {
            HelpClass1.PrintPreview(gridControl4, gridView4);

        }

        public void btnDisplyActiveList3_Click(object sender, EventArgs e)
        {
            IsActiveList2 = true;
            FillDataGridVamhayePardakhti();
            //gridView3_RowCellClick(null, null);
            gridView3_FocusedRowChanged(null, null);
            groupBox4.Text = "وامهای (تسویه نشده)";
            groupBox4.ForeColor = Color.Blue;
        }

        private void btnDisplyNotActiveList3_Click(object sender, EventArgs e)
        {
            IsActiveList2 = false;
            FillDataGridVamhayePardakhti();
            //gridView3_RowCellClick(null, null);
            gridView3_FocusedRowChanged(null, null);
            groupBox4.Text = "وامهای (تسویه شده)";
            groupBox4.ForeColor = Color.Red;

        }

        public void btnDisplyActiveList4_Click(object sender, EventArgs e)
        {
            total = new List<long>();
            FillDataGridRizeAghsatVam();
        }

        private void gridView3_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            total = new List<long>();
            FillDataGridRizeAghsatVam();
            //btnDisplyActiveList4_Click(null, null);
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        private void gridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (IsActiveList2 == true)
            {
                if (gridView3.RowCount > 0)
                {
                    btnCreate4.Visible = true;
                    btnDelete4.Visible = true;
                    btnEdit4.Visible = true;
                }
            }
            else
            {
                btnCreate4.Visible = false;
                btnDelete4.Visible = false;
                btnEdit4.Visible = false;
            }

        }

        private void gridView4_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            HelpClass1.gridView_CustomSummaryCalculate(sender, e, gridView4, "MablaghAghsat", "MablaghDaryafti", "Mande");
        }
    }
}
