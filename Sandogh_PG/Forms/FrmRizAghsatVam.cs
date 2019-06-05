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
    public partial class FrmRizAghsatVam : DevExpress.XtraEditors.XtraForm
    {
        FrmListVamhayePardakhti Fm;
        public FrmRizAghsatVam(FrmListVamhayePardakhti fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        public EnumCED En;
        public int EditRowIndex = 0;
        public int DaryaftKonandeId = 0;
        public int VamId = 0;
        public int VamCode = 0;
        //bool btnSaveClose_Clicked = true;


        public void FillcmbDaryaftkonande()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q1 = db.AllHesabTafzilis.Where(s =>s.GroupTafziliId==3 && s.IsActive == true).OrderBy(s => s.Code).ToList();
                    if (q1.Count > 0)
                        allHesabTafzilisBindingSource.DataSource = q1;
                    else
                        allHesabTafzilisBindingSource.DataSource = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void NewGhest()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int VamId = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("Id"));

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmRizAghsatVam_Load(object sender, EventArgs e)
        {
            FillcmbDaryaftkonande();
            DaryaftKonandeId = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("AazaId"));
            VamId = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("Id"));
            VamCode = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("Code"));
            cmbDaryaftKonande.EditValue = DaryaftKonandeId;
            txtCode.Text = VamCode.ToString();
            if (En == EnumCED.Create)
            {
                btnSaveNext.Visible = true;
                //txtShomareGhest.Text = (_ShomareGhest + 1).ToString();
                //txtSarresidGhest.Text = string.Empty;
                //txtMablaghGest.Text = string.Empty;
                if (!string.IsNullOrEmpty(txtSarresidGhest.Text))
                {
                }
                using (var db = new MyContext())
                {
                    try
                    {
                        var q1 = db.RizeAghsatVams.Where(s => s.VamPardakhtiId == VamId).ToList();
                        var q2 = db.VamPardakhtis.FirstOrDefault(s => s.Id == VamId);
                        if (q1.Count > 0)
                        {
                            int _Max = q1.Max(s => s.ShomareGhest);
                            if (_Max != q2.TedadAghsat)
                            {
                                txtShomareGhest.Text = (_Max + 1).ToString();
                                int yyyy2 = Convert.ToInt32(q1.Max(s => s.TarikhSarresid).ToString().Substring(0, 4));
                                int MM2 = Convert.ToInt32(q1.Max(s => s.TarikhSarresid).ToString().Substring(5, 2));
                                int dd2 = Convert.ToInt32(q1.Max(s => s.TarikhSarresid).ToString().Substring(8, 2));
                                Mydate d2 = new Mydate(yyyy2, MM2, dd2);
                                d2.IncrementMonth();
                                txtSarresidGhest.Text = d2.ToString();
                                txtMablaghGest.Text = q1.Max(s => s.MablaghAghsat).ToString();
                            }
                            else
                            {
                                XtraMessageBox.Show(" تعداد اقساط وام " + q2.TedadAghsat.ToString() + " قسط است لذا بیشتر از این تعداد نمیتوان اقساط جدید تعریف نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                                return;
                            }

                        }
                        else
                        {
                            txtShomareGhest.Text = "1";
                        }
                        txtSarresidGhest.Focus();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else if (En == EnumCED.Edit)
            {
                btnSaveNext.Visible = false;
                txtShomareGhest.Text = Fm.gridView2.GetFocusedRowCellDisplayText("ShomareGhest");
                txtMablaghGest.Text = Fm.gridView2.GetFocusedRowCellDisplayText("MablaghAghsat");
                if (!string.IsNullOrEmpty(Fm.gridView2.GetFocusedRowCellDisplayText("TarikhSarresid")))
                {
                    txtSarresidGhest.Text = Fm.gridView2.GetFocusedRowCellDisplayText("TarikhSarresid").Substring(0, 10);

                }

            }

        }

        private void FrmRizAghsatVam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnSaveClose_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F9 && btnSaveNext.Visible == true)
            {
                btnSaveNext_Click(sender, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, null);
            }

        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbDaryaftKonande.Text))
            {
                XtraMessageBox.Show("فیلد گیرنده وام نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(txtCode.Text))
            {
                XtraMessageBox.Show("کد وام نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(txtShomareGhest.Text))
            {
                XtraMessageBox.Show("فیلد قسط نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(txtMablaghGest.Text))
            {
                XtraMessageBox.Show("لطفاً مبلغ را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(txtSarresidGhest.Text))
            {
                XtraMessageBox.Show("لطفاً سررسید قسط را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _HesabAazaId2 = Convert.ToInt32(cmbDaryaftKonande.EditValue);
                        int VamId = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("Id"));
                        if (En == EnumCED.Create)
                        {
                            RizeAghsatVam ct = new RizeAghsatVam();
                            ct.ShomareGhest = Convert.ToInt32(txtShomareGhest.Text);
                            ct.AazaId = _HesabAazaId2;
                            ct.NameAaza = cmbDaryaftKonande.Text;
                            ct.VamPardakhtiId = VamId;
                            ct.VamPardakhtiCode = VamCode;
                            if (!string.IsNullOrEmpty(txtSarresidGhest.Text))
                                ct.TarikhSarresid = Convert.ToDateTime(txtSarresidGhest.Text.Substring(0, 10));
                            if (!string.IsNullOrEmpty(txtMablaghGest.Text))
                                ct.MablaghAghsat = Convert.ToDecimal(txtMablaghGest.Text.Replace(",", ""));
                            ct.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                            db.RizeAghsatVams.Add(ct);

                            db.SaveChanges();
                            //XtraMessageBox.Show("اطلاعات با موفقیت ثبت شد", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            En = EnumCED.Save;
                            Fm.btnDisplyActiveList2_Click(null, null);
                            Fm.gridView2.MoveLast();
                            this.Close();
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(Fm.gridView2.GetFocusedRowCellValue("Id"));

                            var q = db.RizeAghsatVams.FirstOrDefault(s => s.Id == RowId);
                            if (q != null)
                            {
                                //q.AazaId = _HesabAazaId2;
                                //q.NameAaza = cmbDaryaftKonande.Text;
                                //q.VamPardakhtiId = VamId;
                                //q.VamPardakhtiCode = VamCode;
                                if (!string.IsNullOrEmpty(txtSarresidGhest.Text))
                                    q.TarikhSarresid = Convert.ToDateTime(txtSarresidGhest.Text.Substring(0, 10));
                                if (!string.IsNullOrEmpty(txtMablaghGest.Text))
                                    q.MablaghAghsat = Convert.ToDecimal(txtMablaghGest.Text.Replace(",", ""));
                                db.SaveChanges();
                                //XtraMessageBox.Show("اطلاعات با موفقیت ویرایش شد", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                En = EnumCED.Save;
                                Fm.btnDisplyActiveList2_Click(null, null);
                                if (Fm.gridView2.RowCount > 0)
                                    Fm.gridView2.FocusedRowHandle = EditRowIndex;
                                this.Close();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            En = EnumCED.Cancel;
            this.Close();
        }

        private void FrmRizAghsatVam_FormClosing(object sender, FormClosingEventArgs e)
        {
            En = EnumCED.Cancel;
        }

        public new void ActiveForm(XtraForm form)
        {
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog(this);
            }
            else
            {
                Application.OpenForms[form.Name].Activate();
            }

        }

        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            //btnSaveClose_Clicked = false;
            //btnSaveClose_Click(null, null);
            //btnSaveClose_Clicked = true;
            //En = EnumCED.Create;
            btnSaveClose_Click(null, null);
            if (En == EnumCED.Cancel)
            {
                ActiveForm(this);
                this.Visible = false;
                Fm.btnCreate2_Click(null, null);

            }
        }

        private void txtMablaghGest_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelpClass1.AddZerooToTextBox(sender, e);

        }
    }
}