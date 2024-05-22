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
using DevExpress.XtraSplashScreen;

namespace Sandogh_PG.Forms
{
    public partial class RepairDataBase1 : DevExpress.XtraEditors.XtraForm
    {
        public RepairDataBase1()
        {
            InitializeComponent();
        }

        FrmMain Fm;
        public RepairDataBase1(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        private void RepairDataBase1_Load(object sender, EventArgs e)
        {
            //using (var db = new MyContext())
            //{
            //    try
            //    {

            //        if (Application.ProductVersion == "1.0.0.88")
            //        {
            //            var ho = db.HaghOzviats.ToList();
            //            if (ho.Count > 0)
            //            {
            //                if (ho.Sum(s => s.TakhirVaTajil) != 0)
            //                {
            //                    this.Close();
            //                }
            //            }

            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
            //            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

        }


        private void RepairDataBase1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (Fm != null)
                {
                    Fm.IsAllowed = false;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> RepairDataBase1_FormClosed()" + "\n" + ex.Message,
                    "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnOK88_2_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {

                    var ho1 = db.HaghOzviats.OrderBy(s => s.Tarikh).OrderBy(s => s.IndexMonth).ToList();
                    if (ho1.Count > 0)
                    {
                        SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

                        for (int i = 0; i < ho1.Count; i++)
                        {
                            int yyyy3 = ho1[i].Sal;
                            int MM3 = ho1[i].IndexMonth + 1;

                            int _AllTaf = ho1[i].AazaId;
                            var q = db.AazaSandoghs.FirstOrDefault(s => s.AllTafId == _AllTaf);
                            int dd1 = q != null ? Convert.ToInt32(q.TarikhOzviat.ToString().Substring(8, 2)) : 1;

                            int dd3 = dd1;

                            if (dd1 == 31)
                            {
                                if (ho1[i].IndexMonth + 1 == 12)
                                {
                                    //yyyy3 = yyyy3 + 1;
                                    //MM3 = 1;
                                    dd3 = 29;
                                }
                                else if (ho1[i].IndexMonth + 1 == 11 || ho1[i].IndexMonth + 1 == 10 || ho1[i].IndexMonth + 1 == 9 ||
                                    ho1[i].IndexMonth + 1 == 8 || ho1[i].IndexMonth + 1 == 7)
                                {
                                    //yyyy3 = ho1[i].Sal;
                                    //MM3 = MM3 + 1;
                                    dd3 = 30;
                                }
                            }
                            else if (dd1 == 30)
                            {
                                if (ho1[i].IndexMonth + 1 == 12)
                                {
                                    //yyyy3 = yyyy3 + 1;
                                    //MM3 = 1;
                                    dd3 = 29;
                                }
                            }

                            Mydate d3 = new Mydate(yyyy3, MM3, dd3);

                            ho1[i].Sarresid = Convert.ToDateTime(d3);
                        }
                        db.SaveChanges();

                        SplashScreenManager.CloseForm();
                        XtraMessageBox.Show("عملیات با موفقیت انجام شد","پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);

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