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

namespace Sandogh_PG.Forms
{
    public partial class FrmNobatVam : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmNobatVam(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
            //        // This line of code is generated by Data Source Configuration Wizard
            //        // Instantiate a new DBContext
            //        Sandogh_PG.MyContext dbContext = new Sandogh_PG.MyContext();
            //        // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            //        dbContext.AazaSandoghs.LoadAsync().ContinueWith(loadTask =>
            //        {
            //// Bind data to control when loading complete
            //aazaSandoghsBindingSource.DataSource = dbContext.AazaSandoghs.Local.ToBindingList();
            //        }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
            //        Sandogh_PG.MyContext dbContext = new Sandogh_PG.MyContext();
            //        // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            //        dbContext.AazaSandoghs.LoadAsync().ContinueWith(loadTask =>
            //        {
            //// Bind data to control when loading complete
            //aazaSandoghsBindingSource1.DataSource = dbContext.AazaSandoghs.Local.ToBindingList();
            //        }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
            //        Sandogh_PG.MyContext dbContext = new Sandogh_PG.MyContext();
            //        // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            //        dbContext.AazaSandoghs.LoadAsync().ContinueWith(loadTask =>
            //        {
            //// Bind data to control when loading complete
            //aazaSandoghsBindingSource2.DataSource = dbContext.AazaSandoghs.Local.ToBindingList();
            //        }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }

        public int _IDSandogh = 0;
        private void btnDisplyList_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q1 = db.AazaSandoghs.Where(s => s.IsActive == true).AsParallel();
                    var q2 = db.VamPardakhtis;
                    List<AazaSandogh> List = new List<AazaSandogh>();

                    if (xtraTabControl1.SelectedTabPageIndex == 0)
                    {
                        var q3 = q2.Where(s => s.IsTasviye == false).AsParallel();
                        foreach (var item in q1)
                        {
                            if (q3.FirstOrDefault(s => s.AazaId == item.AllTafId) == null)
                            {
                                //q1.Remove(item);
                                List.Add(item);
                            }
                        }
                        aazaSandoghsBindingSource0.DataSource = List.OrderBy(s => s.TarikhOzviat);
                    }
                    else if (xtraTabControl1.SelectedTabPageIndex == 1)
                    {
                        var q3 = q2.Where(s => s.IsTasviye == false).AsParallel();
                        foreach (var item in q1)
                        {
                            if (q3.FirstOrDefault(s => s.AazaId == item.AllTafId) == null)
                            {
                                //q1.Remove(item);
                                List.Add(item);
                            }
                        }
                        aazaSandoghsBindingSource1.DataSource = List.OrderBy(s => s.NobatbandiVam);
                    }

                    else
                    {
                        //foreach (var item in q1)
                        //{
                        //    if (q2.FirstOrDefault(s => s.AazaId == item.AllTafId) == null)
                        //    {
                        //        int yyyy1 = Convert.ToInt32(item.TarikhTasviyeVam.ToString().Substring(0, 4));
                        //        int MM1 = Convert.ToInt32(item.TarikhTasviyeVam.ToString().Substring(5, 2));
                        //        int dd1 = Convert.ToInt32(item.TarikhTasviyeVam.ToString().Substring(8, 2));
                        //        Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                        //        int _index = cmbNoeVam.SelectedIndex;
                        //        int ModatEntezar = db.Tanzimats.FirstOrDefault(s=>s.SandoghId== _IDSandogh).AnvaeVams.FirstOrDefault(s=>s.NoeVamIndex== _index).MinModatEntezar;
                        //        item.TarikhTasviyeVam = Convert.ToDateTime(d1.AddMont(ModatEntezar));
                        //        List.Add(item);
                        //    }
                        //    else if (q2.FirstOrDefault(s => s.AazaId == item.AllTafId && s.IsTasviye == false) != null)
                        //    {
                        //        continue;
                        //    }
                        //    else if (q2.FirstOrDefault(s => s.AazaId == item.AllTafId && s.IsTasviye == true) != null)
                        //    {
                        //        var q5 = db.RizeAghsatVams.Where(s => s.AazaId == item.AllTafId).Max(s => s.TarikhDaryaft);
                        //        item.TarikhTasviyeVam = Convert.ToDateTime(q5);
                        //        List.Add(item);
                        //    }
                        //}

                        var q3 = q2.Where(s => s.IsTasviye == false).AsParallel();
                        foreach (var item in q1)
                        {
                            if (q3.FirstOrDefault(s => s.AazaId == item.AllTafId) == null)
                            {
                                //q1.Remove(item);
                                List.Add(item);
                            }
                        }

                        aazaSandoghsBindingSource2.DataSource = List.OrderBy(s => s.TarikhTasviyeVam);

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnDesignReport_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            HelpClass1.CustomDrawRowIndicator(sender, e, gridView1);
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            HelpClass1.CustomDrawRowIndicator(sender, e, gridView2);
        }

        private void FrmNobatVam_Load(object sender, EventArgs e)
        {
            _IDSandogh = Convert.ToInt32(Fm.IDSandogh.Caption);

            using (var db = new MyContext())
            {
                try
                {
                    var q = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _IDSandogh);
                    //cmbNoeVam.SelectedIndex = q;

                    if (q.checkEdit6)
                    {
                        if (q.NoeRezervIndex == 0)
                        {
                            xtraTabControl1.SelectedTabPageIndex = 0;
                            xtraTabControl1.TabPages[1].PageVisible = false;
                            xtraTabControl1.TabPages[2].PageVisible = false;
                            xtraTabControl1.TabPages[0].Text = "نوبت بندی بر اساس تاریخ عضویت اعضاء در صندوق";
                        }
                        else if (q.NoeRezervIndex == 1)
                        {
                            xtraTabControl1.SelectedTabPageIndex = 1;
                            xtraTabControl1.TabPages[0].PageVisible = false;
                            xtraTabControl1.TabPages[2].PageVisible = false;
                            xtraTabControl1.TabPages[1].Text = "نوبت بندی بر اساس شماره قرعه کشی اعضاء در صندوق";

                        }
                        else if (q.NoeRezervIndex == 2)
                        {
                            xtraTabControl1.SelectedTabPageIndex = 2;
                            xtraTabControl1.TabPages[0].PageVisible = false;
                            xtraTabControl1.TabPages[1].PageVisible = false;
                            xtraTabControl1.TabPages[2].Text = "نوبت بندی بر اساس تاریخ عضویت اعضاء جدید با حداقل مدت انتظار یا تاریخ تسویه وام قبلی اعضاء";

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

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            HelpClass1.CustomDrawRowIndicator(sender, e, gridView3);

        }

        private void gridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(gridView2, gridView2.RowCount);
            }

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(gridView1, gridView1.RowCount);
            }

        }

        private void gridView3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(gridView3, gridView3.RowCount);
            }

        }
    }
}