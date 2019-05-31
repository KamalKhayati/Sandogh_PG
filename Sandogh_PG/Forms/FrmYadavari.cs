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
                    var q = db.RizeAghsatVams.Where(f => f.ShomareSanad == 0 && f.TarikhSarresid < _DateTimeNow).ToList();
                    if (q != null)
                        rizeAghsatVamsBindingSource.DataSource = q.OrderBy(f=>f.TarikhSarresid);
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
                    var q2 = db.AllHesabTafzilis.Where(s => s.GroupTafziliId == 3 && s.IsActive == true).ToList();
                    if (q2.Count > 0)
                    {
                        foreach (var item in q2)
                        {
                            var q1 = db.HaghOzviats.Where(f => f.AazaId == item.Id).ToList();
                            //var q1 = db.HaghOzviats.Where(f => f.Tarikh < _DateTimeNow_1);
                            if (q1.Count > 0)
                            {
                                var q3 = q1.Max(f => f.Tarikh);
                                if (q3 <= _DateTimeNow_1)
                                {
                                    HaghOzviat obj = new HaghOzviat();
                                    obj.Id = item.Id;
                                    obj.NameAaza = item.Name;
                                    obj.Tarikh = q3;
                                    //obj.Tarikh =Convert.ToDateTime(q3.ToString().Substring(0,10));
                                    List.Add(obj);
                                }
                            }

                        }
                    }

                    if (List != null)
                        haghOzviatsBindingSource.DataSource = List.OrderBy(f=>f.Tarikh);
                    else
                        haghOzviatsBindingSource.DataSource = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}