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
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;

namespace Sandogh_PG
{
    public partial class FrmDaryafti : DevExpress.XtraEditors.XtraForm
    {
        public FrmMain Fm;
        public FrmDaryafti(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;

        }
        public FrmDaryafti()
        {
            InitializeComponent();
        }
        public bool IsActiveList1 = true;
        public bool IsActiveList2 = true;
        int _VamId = 0;
        int _AazaId = 0;
        int _AllTafId = 0;
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
                        //var q1 = dataContext.AazaSandoghs.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList();
                        var q1 = dataContext.AazaSandoghs.Where(s => s.IsActive == true).OrderBy(s => s.Code).AsParallel();
                        //var q1 = dataContext.AazaSandoghs.AsParallel();
                        aazaSandoghsBindingSource.DataSource = q1.Count() > 0 ? q1 : null;
                    }
                    else
                    {
                        var q = dataContext.AazaSandoghs.Where(s => s.IsActive == false).OrderBy(s => s.Code).AsParallel();
                        aazaSandoghsBindingSource.DataSource = q.Count() > 0 ? q : null;
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
                    _AllTafId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("AllTafId"));

                    //var qq = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 3 && f.Id2 == _AazaId);
                    //if (qq != null)
                    {
                        var q1 = db.HaghOzviats.Where(s => s.AazaId == _AllTafId).OrderBy(s => s.Tarikh).ThenBy(s => s.Seryal).AsParallel();
                        foreach (var item in q1)
                        {
                            int yyyy2s = Convert.ToInt32(item.Sarresid.ToString().Substring(0, 4));
                            int MM2s = Convert.ToInt32(item.Sarresid.ToString().Substring(5, 2));
                            int dd2s = Convert.ToInt32(item.Sarresid.ToString().Substring(8, 2));
                            Mydate d2s = new Mydate(yyyy2s, MM2s, dd2s);

                            int yyyy2d = Convert.ToInt32(item.Tarikh.ToString().Substring(0, 4));
                            int MM2d = Convert.ToInt32(item.Tarikh.ToString().Substring(5, 2));
                            int dd2d = Convert.ToInt32(item.Tarikh.ToString().Substring(8, 2));
                            Mydate d2d = new Mydate(yyyy2d, MM2d, dd2d);

                            if (d2s< d2d)
                            {
                                item.TakhirVaTajil = (d2s - d2d) * -1;
                            }
                            else if (d2s > d2d)
                            {
                                item.TakhirVaTajil = d2d - d2s;
                            }
                            else
                            {
                                item.TakhirVaTajil = 0;
                            }

                        }

                        haghOzviatsBindingSource.DataSource = q1.Count() > 0 ? q1 : null;
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
                    _AllTafId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("AllTafId"));

                    //var qq = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 3 && f.Id2 == _AazaId);
                    //if (qq != null)
                    {
                        if (IsActiveList2 == true)
                        {
                            var q1 = db.VamPardakhtis.Where(s => s.IsTasviye == false && s.AazaId == _AllTafId).OrderBy(s => s.Code).AsParallel();
                                vamPardakhtisBindingSource.DataSource = q1.Count() > 0 ? q1 : null;
                        }
                        else
                        {
                            var q = db.VamPardakhtis.Where(s => s.IsTasviye == true && s.AazaId == _AllTafId).OrderBy(s => s.Code).AsParallel();
                            vamPardakhtisBindingSource.DataSource = q.Count() > 0 ? q : null;
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
        public void FillDataGridRizeAghsatVam()
        {
            using (var db = new MyContext())
            {
                try
                {
                    rizeAghsatVamsBindingSource.Clear();
                    rizeAghsatVamsBindingSource.DataSource = null;
                    _VamId = Convert.ToInt32(gridView3.GetFocusedRowCellValue("Id"));
                    var q1 = db.RizeAghsatVams.Where(s => s.VamPardakhtiId == _VamId).OrderBy(s => s.Id).OrderBy(s => s.TarikhSarresid).AsParallel();
                    //var q2 = q1.ToList();
                    foreach (var item in q1)
                    {
                        int yyyy2s = Convert.ToInt32(item.TarikhSarresid.ToString().Substring(0, 4));
                        int MM2s = Convert.ToInt32(item.TarikhSarresid.ToString().Substring(5, 2));
                        int dd2s = Convert.ToInt32(item.TarikhSarresid.ToString().Substring(8, 2));
                        Mydate d2s = new Mydate(yyyy2s, MM2s, dd2s);

                        int yyyy2d = item.TarikhDaryaft!=null? Convert.ToInt32(item.TarikhDaryaft.ToString().Substring(0, 4)) : Convert.ToInt32(DateTime.Now.ToString().Substring(0, 4));
                        int MM2d = item.TarikhDaryaft != null ? Convert.ToInt32(item.TarikhDaryaft.ToString().Substring(5, 2)) : Convert.ToInt32(DateTime.Now.ToString().Substring(5, 2));
                        int dd2d = item.TarikhDaryaft != null ? Convert.ToInt32(item.TarikhDaryaft.ToString().Substring(8, 2)) : Convert.ToInt32(DateTime.Now.ToString().Substring(8, 2));
                        Mydate d2d = new Mydate(yyyy2d, MM2d, dd2d);

                        if (d2s < d2d)
                        {
                            item.TakhirVaTajil = (d2s - d2d) * -1;
                        }
                        else if (d2s > d2d)
                        {
                            if (d2d.ToString()!= DateTime.Now.ToString().Substring(0, 10))
                            {
                                item.TakhirVaTajil = d2d - d2s;
                            }
                            else
                            {
                                item.TakhirVaTajil = 0;
                            }
                        }
                        else
                        {
                            item.TakhirVaTajil = 0;
                        }

                    }

                    rizeAghsatVamsBindingSource.DataSource = q1.Count() > 0 ? q1 : null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public int _cmbMoin = 0;
        public int _cmbNameHesab = 0;

        public void btnCreate2_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                FrmDaryaftHaghOzviat fm = new FrmDaryaftHaghOzviat(this);
                fm.En = EnumCED.Create;
                gridView2.MoveLast();
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

        string _deviceID = string.Empty;
        string _dataBaseName = string.Empty;

        private void FrmDaryafti_Load(object sender, EventArgs e)
        {
            FillDataGridAazaSandogh();
            _deviceID = HelpClass1.GetMadarBoardSerial();
            _dataBaseName = new MyContext().Database.Connection.Database;

        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //total = new List<long>();
            ////FillDataGridRizeAghsatVam();
            //gridView3_RowCellClick(sender, null);
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
            gridView1_RowCellClick(null, null);
            gridView3_RowCellClick(null, null);
            //gridView1_FocusedRowChanged(null, null);
            //gridView3_FocusedRowChanged(null, null);
            groupBox1.Text = "اشخاص (فعال)";
            groupBox1.ForeColor = Color.Blue;
            groupBox4.Text = "وامهای (تسویه نشده)";
            groupBox4.ForeColor = Color.Blue;

        }

        private void btnDisplayNotActiveList1_Click(object sender, EventArgs e)
        {
            IsActiveList1 = false;
            FillDataGridAazaSandogh();
            gridView1_RowCellClick(null, null);
            gridView3_RowCellClick(null, null);
            //gridView1_FocusedRowChanged(null, null);
            //gridView3_FocusedRowChanged(null, null);
            groupBox1.Text = "اعضاء (غیرفعال)";
            groupBox1.ForeColor = Color.Red;
            groupBox4.Text = "وامهای (تسویه شده)";
            groupBox4.ForeColor = Color.Red;

        }

        private void btnPrintPreview1_Click(object sender, EventArgs e)
        {
            HelpClass1.PrintPreview(gridControl1, gridView1);
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (IsActiveList1 == true && IsActiveList2 == true)
            {
                //FillDataGridVamhayePardakhti();
                //gridView1_RowCellClick(null, null);
                groupBox1.Text = "اشخاص (فعال)";
                groupBox1.ForeColor = Color.Blue;
                groupBox4.Text = "وامهای (تسویه نشده)";
                groupBox4.ForeColor = Color.Blue;
            }
            else if (IsActiveList1 == true && IsActiveList2 == false)
            {
                IsActiveList2 = true;
                //FillDataGridVamhayePardakhti();
                //gridView1_RowCellClick(null, null);
                groupBox1.Text = "اشخاص (فعال)";
                groupBox1.ForeColor = Color.Blue;
                groupBox4.Text = "وامهای (تسویه نشده)";
                groupBox4.ForeColor = Color.Blue;
            }
            else if (IsActiveList1 == false && IsActiveList2 == false)
            {
                //FillDataGridVamhayePardakhti();
                //gridView1_RowCellClick(null, null);
                groupBox1.Text = "اعضاء (غیرفعال)";
                groupBox1.ForeColor = Color.Red;
                groupBox4.Text = "وامهای (تسویه شده)";
                groupBox4.ForeColor = Color.Red;
            }
            else if (IsActiveList1 == false && IsActiveList2 == true)
            {
                IsActiveList2 = false;
                //FillDataGridVamhayePardakhti();
                //gridView1_RowCellClick(null, null);
                groupBox1.Text = "اعضاء (غیرفعال)";
                groupBox1.ForeColor = Color.Red;
                groupBox4.Text = "وامهای (تسویه شده)";
                groupBox4.ForeColor = Color.Red;
            }

            FillDataGridHaghOzviat();

            if (gridView2.RowCount > 0)
            {
                IndexAkharinDaruaftHaghOzviat = gridView2.RowCount - 1;
                gridView2.FocusedRowHandle = IndexAkharinDaruaftHaghOzviat;
            }

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

            FillDataGridVamhayePardakhti();
            if (gridView3.RowCount > 0)
            {
                gridView3_RowCellClick(null, null);
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    if (Convert.ToInt32(gridView4.GetRowCellValue(i, "ShomareSanad")) == 0)
                    {
                        gridView4.FocusedRowHandle = i;
                        return;
                    }
                }
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


                            var k = db.AllowedDevises.FirstOrDefault(s => s.DeviceID == _deviceID && s.DataBaseName == _dataBaseName);
                            if (k.VersionType == "Demo")
                            {
                                var d = db.AsnadeHesabdariRows.AsParallel();
                                if (d.Count() < 200)
                                {
                                    k.IsActive = true;
                                    db.SaveChanges();
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
            int rowIndex = e.ListSourceRowIndex;
            //if (rowIndex == 0)

            //HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);

            //int rowIndex = e.ListSourceRowIndex;
            long MablaghAghsat = Convert.ToInt64(gridView4.GetListSourceRowCellValue(rowIndex, "MablaghAghsat"));
            long MablaghDaryafti = Convert.ToInt64(gridView4.GetListSourceRowCellValue(rowIndex, "MablaghDaryafti"));
            if (e.Column.FieldName != "Mande") return;
            if (e.IsGetData)
            {
                if (rowIndex == 0)
                {
                    total.Add(MablaghAghsat - MablaghDaryafti);
                    e.Value = total[rowIndex];
                    if (Convert.ToInt64(e.Value) == 0)
                    {
                        IndexAkharinDaruaft = rowIndex;
                    }
                }
                else
                {
                    total.Add(total[rowIndex - 1] + MablaghAghsat - MablaghDaryafti);
                    e.Value = total[rowIndex];
                    if (Convert.ToInt64(e.Value) == 0)
                    {
                        IndexAkharinDaruaft = rowIndex;
                    }
                }
            }
        }

        public int IndexAkharinDaruaftGhest = 0;
        public int IndexAkharinDaruaftHaghOzviat = 0;

        public void btnCreate4_Click(object sender, EventArgs e)
        {
            if (gridView4.RowCount > 0)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (Convert.ToDecimal(gridView4.Columns["Mande"].SummaryItem.SummaryValue) == 0)
                        {
                            if (XtraMessageBox.Show("مبلغ وام تسویه شده است آیا به لیست وامهای تسویه شده انتقال یابد؟", "پیغام ثبت ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                int _VamPardakhtiId = Convert.ToInt32(gridView3.GetFocusedRowCellValue("Id"));
                                var q = db.VamPardakhtis.FirstOrDefault(s => s.Id == _VamPardakhtiId);
                                if (q != null)
                                {
                                    q.IsTasviye = true;
                                    db.SaveChanges();
                                    btnDisplyActiveList3_Click(null, null);
                                }
                            }
                            else
                                return;
                        }
                        else
                        {
                            int _CodeVam = Convert.ToInt32(gridView3.GetFocusedRowCellDisplayText("Code"));
                            var q2 = db.RizeAghsatVams.FirstOrDefault(s => s.VamPardakhtiCode == _CodeVam && s.SeryalDaryaft == 0);

                            var q1 = db.RizeAghsatVams.FirstOrDefault(s => s.VamPardakhtiCode == _CodeVam && s.SeryalDaryaft == 0);
                            if (q1 != null)
                            {
                                FrmDaryafteAghsateVam fm = new FrmDaryafteAghsateVam(this);
                                fm.En = EnumCED.Create;
                                if (q2 != null)
                                    IndexAkharinDaruaftGhest = q2.ShomareGhest - 1;
                                fm.ShowDialog();
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

        private void btnDelete4_Click(object sender, EventArgs e)
        {
            if (gridView4.SelectedRowsCount > 0)
            {
                if (Convert.ToInt32(gridView4.GetFocusedRowCellValue("SeryalDaryaft")) != 0)
                {
                    if (XtraMessageBox.Show("آیا دریافت قسط مورد نظر حذف شود؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                                    ///////////////////////////////////////////////////////////////////
                                    var q1 = db.AsnadeHesabdariRows.Where(f => f.ShomareSanad == q.ShomareSanad);
                                    if (q1.Count() > 0)
                                        db.AsnadeHesabdariRows.RemoveRange(q1);
                                    //////////////////////////////////////////////////////////////////
                                    q.SeryalDaryaft = 0;
                                    q.TarikhDaryaft = null;
                                    q.MablaghDaryafti = 0;
                                    q.NameHesabId = 0;
                                    q.NameHesab = string.Empty;
                                    q.Sharh = string.Empty;
                                    q.ShomareSanad = 0;
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


                                var k = db.AllowedDevises.FirstOrDefault(s => s.DeviceID == _deviceID && s.DataBaseName == _dataBaseName);
                                if (k.VersionType == "Demo")
                                {
                                    var d = db.AsnadeHesabdariRows.AsParallel();
                                    if (d.Count() < 200)
                                    {
                                        k.IsActive = true;
                                        db.SaveChanges();
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
            if (gridView3.IsFocusedView)
            {
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    if (Convert.ToInt32(gridView4.GetRowCellValue(i, "ShomareSanad")) == 0)
                    {
                        gridView4.FocusedRowHandle = i;
                        return;
                    }
                }

            }
            //btnDisplyActiveList4_Click(null, null);
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

        string FilePath1 = Application.StartupPath + @"\Report\Ghozareshat\";
        string FileName2 = "rptRizDaryafti.repx";
        string FileName4 = "rptRizVamha.repx";

        private void btnPrintPreview4_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(FilePath1 + FileName4))
            {
                if (gridView4.RowCount > 0)
                {
                    XtraReport XtraReport1 = new XtraReport();
                    XtraReport1.LoadLayoutFromXml(FilePath1 + FileName4);

                    XtraReport1.DataSource = HelpClass1.ConvettDatagridviewToDataSet(gridView4);

                    XtraReport1.Parameters["TarikhVSaat"].Value = DateTime.Now;
                    XtraReport1.Parameters["SandoghName"].Value = Fm.ribbonControl1.ApplicationDocumentCaption;
                    XtraReport1.Parameters["Logo_Co"].Value = Fm.pictureEdit1.Image;

                    XtraReport1.Parameters["NameAaza"].Value = gridView3.GetFocusedRowCellDisplayText("NameAaza");
                    XtraReport1.Parameters["ShomareSanad"].Value = gridView3.GetFocusedRowCellDisplayText("ShomareSanad");
                    XtraReport1.Parameters["NahveyePardakht"].Value = gridView3.GetFocusedRowCellDisplayText("NahveyePardakht");
                    XtraReport1.Parameters["NoeVam"].Value = gridView3.GetFocusedRowCellDisplayText("NoeVam");
                    XtraReport1.Parameters["DarsadeKarmozd"].Value = gridView3.GetFocusedRowCellDisplayText("DarsadeKarmozd");
                    XtraReport1.Parameters["MablaghDirkard"].Value = gridView3.GetFocusedRowCellDisplayText("MablaghDirkard");
                    XtraReport1.Parameters["TarikhDarkhast"].Value = gridView3.GetFocusedRowCellDisplayText("TarikhDarkhast");
                    XtraReport1.Parameters["ShomareDarkhast"].Value = gridView3.GetFocusedRowCellDisplayText("ShomareDarkhast");
                    XtraReport1.Parameters["Code"].Value = gridView3.GetFocusedRowCellDisplayText("Code");
                    XtraReport1.Parameters["TarikhPardakht"].Value = gridView3.GetFocusedRowCellDisplayText("TarikhPardakht");
                    XtraReport1.Parameters["MablaghAsli"].Value = gridView3.GetFocusedRowCellDisplayText("MablaghAsli");
                    XtraReport1.Parameters["MablaghKarmozd"].Value = gridView3.GetFocusedRowCellDisplayText("MablaghKarmozd");
                    XtraReport1.Parameters["FaseleAghsat"].Value = gridView3.GetFocusedRowCellDisplayText("FaseleAghsat");
                    XtraReport1.Parameters["TedadAghsat"].Value = gridView3.GetFocusedRowCellDisplayText("TedadAghsat");
                    XtraReport1.Parameters["MablaghAghsat"].Value = gridView3.GetFocusedRowCellDisplayText("MablaghAghsat");
                    XtraReport1.Parameters["SarresidAvalinGhest"].Value = gridView3.GetFocusedRowCellDisplayText("SarresidAvalinGhest");
                    XtraReport1.Parameters["ZameninName"].Value = gridView3.GetFocusedRowCellDisplayText("ZameninName");
                    XtraReport1.Parameters["HaveCheckTazmin"].Value = gridView3.GetFocusedRowCellDisplayText("HaveCheckTazmin");


                    //XtraReport1.DataSource = gridView2.DataSource;
                    //XtraReport1.Parameters["Az_Tarikh"].Value = ChkTarikh.Checked ? txtAzTarikh.Text : gridView2.GetRowCellDisplayText(0, "Tarikh").Substring(0, 10);
                    //XtraReport1.Parameters["Ta_Tarikh"].Value = ChkTarikh.Checked ? txtTaTarikh.Text : DateTime.Now.ToString().Substring(0, 10);
                    //XtraReport1.Parameters["HesabMoin"].Value = _HesabMoin;

                    //List<decimal> ListMande1 = new List<decimal>();
                    //for (int i = 0; i < gridView1.RowCount; i++)
                    //{
                    //    ListMande1.Add(Convert.ToDecimal(gridView2.GetRowCellValue(i, "Mande1")));
                    //}
                    //XtraReport1.Parameters["Mande1"].Value = ListMande1;
                    FrmPrinPreview FPP = new FrmPrinPreview();
                    FPP.documentViewer1.DocumentSource = XtraReport1;
                    FPP.ShowDialog();

                }
            }
            else
            {
                HelpClass1.NewReportDesigner(FilePath1, FileName4);
            }
        }

        private void btnDesignReport4_Click(object sender, EventArgs e)
        {
            HelpClass1.LoadReportDesigner(FilePath1, FileName4);
        }

        private void btnPrintPreview3_Click(object sender, EventArgs e)
        {
            //HelpClass1.PrintPreview(gridControl3, gridView3);
            btnPrintPreview4_Click(null, null);
        }

        private void btnDesignReport3_Click(object sender, EventArgs e)
        {
            btnDesignReport4_Click(null, null);
        }

        private void btnPrintPreview2_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(FilePath1 + FileName2))
            {
                if (gridView2.RowCount > 0)
                {
                    XtraReport XtraReport1 = new XtraReport();
                    XtraReport1.LoadLayoutFromXml(FilePath1 + FileName2);

                    XtraReport1.DataSource = gridView2.DataSource;

                    XtraReport1.Parameters["TarikhVSaat"].Value = DateTime.Now;
                    XtraReport1.Parameters["SandoghName"].Value = Fm.ribbonControl1.ApplicationDocumentCaption;
                    XtraReport1.Parameters["Logo_Co"].Value = Fm.pictureEdit1.Image;

                    //XtraReport1.Parameters["NameAaza"].Value = gridView3.GetFocusedRowCellDisplayText("NameAaza");
                    //XtraReport1.Parameters["ShomareSanad"].Value = gridView3.GetFocusedRowCellDisplayText("ShomareSanad");
                    //XtraReport1.Parameters["NahveyePardakht"].Value = gridView3.GetFocusedRowCellDisplayText("NahveyePardakht");
                    //XtraReport1.Parameters["NoeVam"].Value = gridView3.GetFocusedRowCellDisplayText("NoeVam");
                    //XtraReport1.Parameters["DarsadeKarmozd"].Value = gridView3.GetFocusedRowCellDisplayText("DarsadeKarmozd");
                    //XtraReport1.Parameters["MablaghDirkard"].Value = gridView3.GetFocusedRowCellDisplayText("MablaghDirkard");
                    //XtraReport1.Parameters["TarikhDarkhast"].Value = gridView3.GetFocusedRowCellDisplayText("TarikhDarkhast");
                    //XtraReport1.Parameters["ShomareDarkhast"].Value = gridView3.GetFocusedRowCellDisplayText("ShomareDarkhast");
                    //XtraReport1.Parameters["Code"].Value = gridView3.GetFocusedRowCellDisplayText("Code");
                    //XtraReport1.Parameters["TarikhPardakht"].Value = gridView3.GetFocusedRowCellDisplayText("TarikhPardakht");
                    //XtraReport1.Parameters["MablaghAsli"].Value = gridView3.GetFocusedRowCellDisplayText("MablaghAsli");
                    //XtraReport1.Parameters["MablaghKarmozd"].Value = gridView3.GetFocusedRowCellDisplayText("MablaghKarmozd");
                    //XtraReport1.Parameters["FaseleAghsat"].Value = gridView3.GetFocusedRowCellDisplayText("FaseleAghsat");
                    //XtraReport1.Parameters["TedadAghsat"].Value = gridView3.GetFocusedRowCellDisplayText("TedadAghsat");
                    //XtraReport1.Parameters["MablaghAghsat"].Value = gridView3.GetFocusedRowCellDisplayText("MablaghAghsat");
                    //XtraReport1.Parameters["SarresidAvalinGhest"].Value = gridView3.GetFocusedRowCellDisplayText("SarresidAvalinGhest");
                    //XtraReport1.Parameters["ZameninName"].Value = gridView3.GetFocusedRowCellDisplayText("ZameninName");
                    //XtraReport1.Parameters["HaveCheckTazmin"].Value = gridView3.GetFocusedRowCellDisplayText("HaveCheckTazmin");


                    //XtraReport1.DataSource = gridView2.DataSource;
                    //XtraReport1.Parameters["Az_Tarikh"].Value = ChkTarikh.Checked ? txtAzTarikh.Text : gridView2.GetRowCellDisplayText(0, "Tarikh").Substring(0, 10);
                    //XtraReport1.Parameters["Ta_Tarikh"].Value = ChkTarikh.Checked ? txtTaTarikh.Text : DateTime.Now.ToString().Substring(0, 10);
                    //XtraReport1.Parameters["HesabMoin"].Value = _HesabMoin;

                    //List<decimal> ListMande1 = new List<decimal>();
                    //for (int i = 0; i < gridView1.RowCount; i++)
                    //{
                    //    ListMande1.Add(Convert.ToDecimal(gridView2.GetRowCellValue(i, "Mande1")));
                    //}
                    //XtraReport1.Parameters["Mande1"].Value = ListMande1;

                    FrmPrinPreview FPP = new FrmPrinPreview();
                    FPP.documentViewer1.DocumentSource = XtraReport1;
                    FPP.ShowDialog();

                }
            }
            else
            {
                HelpClass1.NewReportDesigner(FilePath1, FileName2);
            }
        }

        private void btnDesignReport2_Click(object sender, EventArgs e)
        {
            HelpClass1.LoadReportDesigner(FilePath1, FileName2);
        }


        private void FrmDaryafti_KeyDown(object sender, KeyEventArgs e)
        {
            HelpClass1.ControlAltShift_KeyDown(sender, e, btnDesignReport3);
            HelpClass1.ControlAltShift_KeyDown(sender, e, btnDesignReport4);
            HelpClass1.ControlAltShift_KeyDown(sender, e, btnDesignReport2);

            //if (e.KeyCode == Keys.F7)
            //{
            //    btnCreate5.Visible = btnDelete5.Visible = btnEdit5.Visible = (btnCreate5.Visible = btnDelete5.Visible = btnEdit5.Visible == false) ? true : false;
            //    labelControl2.Visible = labelControl2.Visible == true ? false : true;
            //}
        }

        private void gridView4_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            HelpClass1.gridView4_RowCellStyle(sender, e);

            GridView view = sender as GridView;
            if (view.RowCount > 0)
            {
                // bool IsActive = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "IsActive"));
                //int TakhirVaTajil = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "TedadeFarzand"));

                if (e.Column.FieldName == "TakhirVaTajil")
                {
                    if (Convert.ToInt32(e.CellValue) < 0)
                    {
                        Color foreColor = Color.Red;
                        e.Appearance.ForeColor = foreColor;
                        //e.Appearance.BackColor = Color.LightYellow;
                    }
                    else
                    {
                        //return;
                        Color foreColor = Color.Black;
                        e.Appearance.ForeColor = foreColor;
                    }

                }
                else
                {
                    //return;
                    Color foreColor = Color.Black;
                    e.Appearance.ForeColor = foreColor;
                }

            }

        }

        private void btnPrint1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            HelpClass1.CustomDrawRowIndicator(sender, e, view);

        }

        private void gridView2_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            HelpClass1.CustomDrawRowIndicator(sender, e, view);

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            gridView1_RowCellClick(null, null);

            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(this,gridView1, gridView1.RowCount);
            }

        }

        private void gridView1_KeyUp(object sender, KeyEventArgs e)
        {
            gridView1_RowCellClick(null, null);
        }

        private void gridView3_KeyDown(object sender, KeyEventArgs e)
        {
            gridView3_RowCellClick(null, null);
        }

        private void gridView3_KeyUp(object sender, KeyEventArgs e)
        {
            gridView3_RowCellClick(null, null);

            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(this,gridView3, gridView3.RowCount);
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void gridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(this,gridView2, gridView2.RowCount);
            }

        }

        private void gridView4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(this,gridView4, gridView4.RowCount);
            }

        }

        private void gridView2_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.RowCount > 0)
            {
                // bool IsActive = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "IsActive"));
                //int TakhirVaTajil = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "TedadeFarzand"));

                if (e.Column.FieldName == "TakhirVaTajil")
                {
                    if (Convert.ToInt32(e.CellValue) < 0)
                    {
                        Color foreColor = Color.Red;
                        e.Appearance.ForeColor = foreColor;
                        //e.Appearance.BackColor = Color.LightYellow;
                    }
                    else
                    {
                        Color foreColor = Color.Black;
                        e.Appearance.ForeColor = foreColor;
                    }

                }
                else
                {
                    Color foreColor = Color.Black;
                    e.Appearance.ForeColor = foreColor;
                }

            }

        }
    }
}
