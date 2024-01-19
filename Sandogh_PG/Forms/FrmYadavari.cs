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

namespace Sandogh_PG
{
    public partial class FrmYadavari : DevExpress.XtraEditors.XtraForm
    {
        public FrmYadavari()
        {
            InitializeComponent();
        }

        private void FrmYadavari_Load(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    DateTime _DateTimeNow = DateTime.Now;
                    var p = db.RizeAghsatVams.Where(f => f.ShomareSanad == 0 && f.TarikhSarresid < _DateTimeNow && f.VamPardakhti1.IsTasviye == false).AsParallel();
                    var q = p.ToList();
                    if (q != null)
                        rizeAghsatVamsBindingSource.DataSource = q.OrderBy(f => f.TarikhSarresid);
                    else
                        rizeAghsatVamsBindingSource.DataSource = null;
                    //////////////////////////////////////////////////////////////
                    int yyyy1 = Convert.ToInt32(DateTime.Now.ToString().Substring(0, 4));
                    int MM1 = Convert.ToInt32(DateTime.Now.ToString().Substring(5, 2));
                    int dd1 = Convert.ToInt32(DateTime.Now.ToString().Substring(8, 2));
                    Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                    d1.DecrementMonth();
                    DateTime _DateTimeNow_1 = Convert.ToDateTime(d1.ToString());
                    List<HaghOzviat> List = new List<HaghOzviat>();
                    var p2 = db.AllHesabTafzilis.Where(s => s.GroupTafziliId == 3 && s.IsActive == true).AsParallel();
                    var q2 = p2.ToList();
                    if (q2.Count > 0)
                    {
                        foreach (var item in q2)
                        {
                            var p1 = db.HaghOzviats.Where(f => f.AazaId == item.Id).AsParallel();
                            var q1 = p1.ToList();
                            //var q1 = db.HaghOzviats.Where(f => f.Tarikh < _DateTimeNow_1);
                            if (q1.Count > 0)
                            {
                                var q3 = q1.Max(f => f.Tarikh);
                                if (q3 != null)
                                {
                                    var q5 = q1.Where(s => s.Tarikh == q3).Max(s => s.ShomareSanad);
                                    if (q5 != 0)
                                    {
                                        var q6 = q1.FirstOrDefault(s => s.ShomareSanad == q5);
                                        if (q6 != null)
                                        {
                                            int indexMont = Convert.ToInt32(d1.ToString().Substring(5, 2)) - 1;
                                            int Year = Convert.ToInt32(d1.ToString().Substring(0, 4));
                                            var q4 = q1.FirstOrDefault(s => s.Sal == Year && s.IndexMonth == indexMont);
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
                        }
                    }

                    if (List != null)
                        haghOzviatsBindingSource.DataSource = List.OrderBy(f => f.Tarikh);
                    else
                        haghOzviatsBindingSource.DataSource = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> FrmYadavari_Load()" + "\n" + ex.Message,
                        "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);
        }

        private void gridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);

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
                HelpClass1.ExportDataGridViewToExcel(this,gridView1, gridView1.RowCount);
            }

        }

        private void gridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(this,gridView2, gridView2.RowCount);
            }

        }
    }
}