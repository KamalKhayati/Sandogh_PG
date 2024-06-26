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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace Sandogh_PG
{
    public partial class FrmYadavari : DevExpress.XtraEditors.XtraForm
    {
        public FrmYadavari()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
            Sandogh_PG.MyContext dbContext = new Sandogh_PG.MyContext();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
    //        dbContext.AazaSandoghs.LoadAsync().ContinueWith(loadTask =>
    //        {
    //// Bind data to control when loading complete
    //aazaSandoghsBindingSource.DataSource = dbContext.AazaSandoghs.Local.ToBindingList();
    //        }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void FrmYadavari_Load(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    DateTime _DateTimeNow = DateTime.Now;
                    var p = db.RizeAghsatVams.Where(f => f.ShomareSanad == 0 && f.TarikhSarresid < _DateTimeNow && f.VamPardakhti1.IsTasviye == false).AsParallel();
                    //var q = p.ToList();
                    if (p != null)
                    {
                        rizeAghsatVamsBindingSource.DataSource = p.OrderBy(f => f.TarikhSarresid).ToList();
                        var pp = p.Select(f => f.AazaId).Distinct().ToList();
                        List<RizeAghsatVam> listpp = new List<RizeAghsatVam>();
                        for (int i = 0; i < pp.Count; i++)
                        {
                            RizeAghsatVam obj = new RizeAghsatVam();
                            obj.AazaId = pp[i];
                            obj.NameAaza = p.FirstOrDefault(f => f.AazaId == obj.AazaId).NameAaza;
                            obj.VamPardakhtiCode = p.Where(f => f.AazaId == obj.AazaId).Count();
                            obj.MablaghAghsat = p.Where(f => f.AazaId == obj.AazaId).Sum(f => f.MablaghAghsat);
                            listpp.Add(obj);
                        }
                        gridControl3.DataSource = listpp.OrderByDescending(f => f.VamPardakhtiCode).ToList();
                    }
                    else
                    {
                        rizeAghsatVamsBindingSource.DataSource = null;
                        gridControl3.DataSource = null;
                    }
                    //////////////////////////////////////////////////////////////
                    int yyyy1 = Convert.ToInt32(DateTime.Now.ToString().Substring(0, 4));
                    int MM1 = Convert.ToInt32(DateTime.Now.ToString().Substring(5, 2));
                    int dd1 = Convert.ToInt32(DateTime.Now.ToString().Substring(8, 2));
                    Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                    d1.DecrementMonth();
                    DateTime _DateTimeNow_1 = Convert.ToDateTime(d1.ToString());
                    List<HaghOzviat> List = new List<HaghOzviat>();
                    var p2 = db.AllHesabTafzilis.Where(s => s.GroupTafziliId == 3 && s.IsActive == true).AsParallel();
                    //var q2 = p2.ToList();
                    if (p2.Count() > 0)
                    {
                        foreach (var item in p2)
                        {
                            var p1 = db.HaghOzviats.Where(f => f.AazaId == item.Id).AsParallel();
                            //var q1 = p1.ToList();
                            //var q1 = db.HaghOzviats.Where(f => f.Tarikh < _DateTimeNow_1);
                            if (p1.Count() > 0)
                            {
                                var q3 = p1.Max(f => f.Tarikh);
                                if (q3 != null)
                                {
                                    var q5 = p1.Where(s => s.Tarikh == q3).Max(s => s.ShomareSanad);
                                    if (q5 != 0)
                                    {
                                        var q6 = p1.FirstOrDefault(s => s.ShomareSanad == q5);
                                        if (q6 != null)
                                        {
                                            int indexMont = Convert.ToInt32(d1.ToString().Substring(5, 2)) - 1;
                                            int Year = Convert.ToInt32(d1.ToString().Substring(0, 4));
                                            var q4 = p1.FirstOrDefault(s => s.Sal == Year && s.IndexMonth == indexMont);
                                            if (q4 == null)
                                            {
                                                // if (q3 <= _DateTimeNow_1)
                                                //if (index != q4.IndexMonth)
                                                {
                                                    HaghOzviat obj = new HaghOzviat();
                                                    obj.Id = item.Id;
                                                    obj.NameAaza = item.Name;
                                                    obj.Tarikh = q6.Tarikh;
                                                    obj.Month = q6.Month;
                                                    obj.Sal = q6.Sal;
                                                    obj.Mablagh = q6.Mablagh;
                                                    //obj.Tarikh =Convert.ToDateTime(q3.ToString().Substring(0,10));
                                                    List.Add(obj);
                                                }

                                            }

                                        }
                                    }
                                }
                            }
                            else
                            {
                                HaghOzviat obj = new HaghOzviat();
                                obj.Id = item.Id;
                                obj.NameAaza = item.Name;
                                obj.Tarikh = Convert.ToDateTime("0001/01/01");
                                obj.Month = null;
                                obj.Sal = 0;
                                obj.Mablagh = db.AazaSandoghs.FirstOrDefault(s => s.AllTafId == item.Id).HaghOzviat ?? 0;
                                //obj.Tarikh =Convert.ToDateTime(q3.ToString().Substring(0,10));
                                List.Add(obj);

                            }
                        }
                    }

                    if (List != null)
                    {
                        haghOzviatsBindingSource.DataSource = List.OrderBy(f => f.Tarikh);
                    }
                    else
                    {
                        haghOzviatsBindingSource.DataSource = null;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> FrmYadavari_Load()" + "\n" + ex.Message,
                        "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void FrmYadavari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(this, gridView1, gridView1.RowCount);
            }

        }

        private void gridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(this, gridView2, gridView2.RowCount);
            }

        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            HelpClass1.CustomDrawRowIndicator(sender, e, view);

        }

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            HelpClass1.CustomDrawRowIndicator(sender, e, view);

        }

        private void gridView2_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            HelpClass1.CustomDrawRowIndicator(sender, e, view);

        }

        private void gridView3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(this, gridView3, gridView3.RowCount);
            }

        }

        private void btnPardazish_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

                    if (xtraTabControl1.SelectedTabPageIndex == 3)
                    {
                        /////////////////////////////////////////////تهیه گزارش اعضاء واجد شرایط اخراج از صندوق //////////////////////////////////////////////
                        var tn = db.Tanzimats.FirstOrDefault();
                        if (tn.checkEdit7 && tn.TedadRozAdamVariz != 0)
                        {
                            List<AazaSandogh> List0 = new List<AazaSandogh>();
                            var q1 = db.AazaSandoghs.Where(s => s.IsActive == true).AsParallel();
                            DateTime dtNow = DateTime.Now;
                            int yyyy0 = Convert.ToInt32(dtNow.ToString().Substring(0, 4));
                            int MM0 = Convert.ToInt32(dtNow.ToString().Substring(5, 2));
                            int dd0 = Convert.ToInt32(dtNow.ToString().Substring(8, 2));
                            Mydate d0 = new Mydate(yyyy0, MM0, dd0);

                            foreach (var item in q1)
                            {

                                //int Takhir = 0;
                                //int _Count = 0;
                                /////////////////////////////////////////////محاسبه تأخیر در واریز اقساط ماهیانه وام//////////////////////////////////////////////
                                var ho1 = db.HaghOzviats.Where(s => s.AazaId == item.AllTafId && s.Sarresid <= dtNow);
                                if (ho1.Count() > 0)
                                {
                                    int yyyy2s = Convert.ToInt32(ho1.Max(s => s.Sarresid).ToString().Substring(0, 4));
                                    int MM2s = Convert.ToInt32(ho1.Max(s => s.Sarresid).ToString().Substring(5, 2));
                                    int dd2s = Convert.ToInt32(ho1.Max(s => s.Sarresid).ToString().Substring(8, 2));
                                    Mydate d2s = new Mydate(yyyy2s, MM2s, dd2s);
                                    d2s.IncrementMonth();

                                    if (d2s < d0)
                                    {
                                        if (d2s - d0 >= tn.TedadRozAdamVariz)
                                        {
                                            AazaSandogh obj1 = new AazaSandogh();
                                            obj1.Code = item.Code;
                                            obj1.NameVFamil = item.NameVFamil;
                                            obj1.SharhHesab = "پس انداز ماهیانه";

                                            obj1.TarikhOzviat = Convert.ToDateTime(d2s);
                                            obj1.TedadeFarzand = (d2s - d0) * -1;

                                            List0.Add(obj1);
                                        }
                                    }
                                }
                                else
                                {
                                    int yyyy2s = Convert.ToInt32(item.TarikhOzviat.ToString().Substring(0, 4));
                                    int MM2s = Convert.ToInt32(item.TarikhOzviat.ToString().Substring(5, 2));
                                    int dd2s = Convert.ToInt32(item.TarikhOzviat.ToString().Substring(8, 2));
                                    Mydate d2s = new Mydate(yyyy2s, MM2s, dd2s);

                                    if (d2s < d0)
                                    {
                                        if (d2s - d0 >= tn.TedadRozAdamVariz)
                                        {
                                            AazaSandogh obj1 = new AazaSandogh();
                                            obj1.Code = item.Code;
                                            obj1.NameVFamil = item.NameVFamil;
                                            obj1.SharhHesab = "پس انداز ماهیانه";
                                            obj1.TarikhOzviat = item.TarikhOzviat;
                                            obj1.TedadeFarzand = (d2s - d0) * -1;

                                            List0.Add(obj1);
                                        }
                                    }

                                }
                                /////////////////////////////////////////////محاسبه تأخیر در واریز اقساط ماهیانه وام//////////////////////////////////////////////
                                //var q3 = db.VamPardakhtis.Where(s => s.IsTasviye == false && (s.IndexNoeVam == 0 || s.IndexNoeVam == 1 || s.IndexNoeVam == 2 || s.IndexNoeVam == 3)).AsParallel();
                                var rs = db.RizeAghsatVams.Where(s => s.VamPardakhti1.IsTasviye == false && s.AazaId == item.AllTafId && s.TarikhSarresid <= dtNow && s.ShomareSanad == 0);
                                if (rs.Count() > 0)
                                {
                                    int yyyy2s = Convert.ToInt32(rs.Min(s => s.TarikhSarresid).ToString().Substring(0, 4));
                                    int MM2s = Convert.ToInt32(rs.Min(s => s.TarikhSarresid).ToString().Substring(5, 2));
                                    int dd2s = Convert.ToInt32(rs.Min(s => s.TarikhSarresid).ToString().Substring(8, 2));
                                    Mydate d2s = new Mydate(yyyy2s, MM2s, dd2s);

                                    if (d2s < d0)
                                    {
                                        if (d2s - d0 >= tn.TedadRozAdamVariz)
                                        {
                                            AazaSandogh obj1 = new AazaSandogh();
                                            obj1.Code = item.Code;
                                            obj1.NameVFamil = item.NameVFamil;
                                            obj1.SharhHesab = "اقساط ماهیانه";

                                            obj1.TarikhOzviat = Convert.ToDateTime(d2s);
                                            obj1.TedadeFarzand = (d2s - d0) * -1;

                                            List0.Add(obj1);
                                        }
                                    }
                                }
                            }

                            aazaSandoghsBindingSource.DataSource = List0.OrderBy(s => s.TedadeFarzand);

                        }

                    }

                    SplashScreenManager.CloseForm();

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void gridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            HelpClass1.CustomDrawRowIndicator(sender, e, view);

        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(this, gridView, gridView.RowCount);
            }

        }
    }
}