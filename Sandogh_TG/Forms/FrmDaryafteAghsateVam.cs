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

namespace Sandogh_TG
{
    public partial class FrmDaryafteAghsateVam : DevExpress.XtraEditors.XtraForm
    {
        FrmDaryafti Fm;
        public FrmDaryafteAghsateVam(FrmDaryafti fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        public EnumCED En;
        public int EditRowIndex = 0;
        string _Text1 = "دریافت از ";
        string _NameAaza = string.Empty;
        string _Babat = " بابت قسط ";
        string _ShomareGhest = string.Empty;
        string _Text2 = " وام شماره ";
        string _ShomareVam = string.Empty;
        public void FillcmbPardakhtKonande()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    var q1 = dataContext.AazaSandoghs.OrderBy(s => s.Code).ToList();
                    if (q1.Count > 0)
                        aazaSandoghsBindingSource.DataSource = q1;
                    else
                        aazaSandoghsBindingSource.DataSource = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillcmbNameHesab()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    var q1 = dataContext.HesabBankis.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList();
                    if (q1.Count > 0)
                        hesabBankisBindingSource.DataSource = q1;
                    else
                        hesabBankisBindingSource.DataSource = null;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void NewSeryal()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.RizeAghsatVams.Max(s => s.SeryalDaryaft);
                    if (q > 0)
                    {
                        if (q != 9999999)
                        {
                            txtSeryal.Text = (q + 1).ToString();
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                                XtraMessageBox.Show("اعمال محدودیت 9999999 سریال دریافت  ..." + "\n" +
                                    "توجه : نمیتوان بیشتر از این تعداد، دریافتی اقساط داشت ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        txtSeryal.Text = "0000001";
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmDaryafteAghsateVam_Load(object sender, EventArgs e)
        {
            FillcmbPardakhtKonande();
            FillcmbNameHesab();
            cmbPardakhtKonande.EditValue = Convert.ToInt32(Fm.gridView3.GetFocusedRowCellValue("AazaId"));
            txtCodeVam.Text = Fm.gridView3.GetFocusedRowCellDisplayText("Code");

            if (En == EnumCED.Create)
            {
                NewSeryal();
                txtTarikhDaryaft.Text = DateTime.Now.ToString().Substring(0, 10);
                //txtMablaghDaryaft.Text = Fm.gridView4.GetFocusedRowCellDisplayText("MablaghAghsat");

                using (var db = new MyContext())
                {
                    try
                    {
                        var q2 = db.HesabBankis.FirstOrDefault(s => s.IsDefault == true);
                        if (q2 != null)
                            cmbNameHesab.EditValue = q2.Id;

                        int _CodeVam = Convert.ToInt32(Fm.gridView3.GetFocusedRowCellDisplayText("Code"));
                        var q1 = db.RizeAghsatVams.FirstOrDefault(s => s.VamPardakhtiCode == _CodeVam && s.SeryalDaryaft == 0);
                        if (q1 != null)
                        {
                            txtId.Text = q1.Id.ToString();
                            txtShomareGhest.Text = q1.ShomareGhest.ToString();
                            txtSarresidGhest.Text = q1.TarikhSarresid.ToString().Substring(0, 10);
                            txtMablaghGhest.Text = q1.MablaghAghsat.ToString();
                            txtMablaghDaryaft.Text = q1.MablaghAghsat.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


                _NameAaza = cmbPardakhtKonande.Text;
                _ShomareGhest = txtShomareGhest.Text;
                _ShomareVam = txtCodeVam.Text;
                txtSharh.Text = _Text1 + _NameAaza + _Babat + _ShomareGhest + _Text2 + _ShomareVam;
            }
            else if (En == EnumCED.Edit)
            {
                txtSeryal.Text = Fm.gridView4.GetFocusedRowCellDisplayText("SeryalDaryaft");
                txtId.Text = Fm.gridView4.GetFocusedRowCellDisplayText("Id");
                txtShomareGhest.Text = Fm.gridView4.GetFocusedRowCellDisplayText("ShomareGhest");
                txtSarresidGhest.Text = Fm.gridView4.GetFocusedRowCellDisplayText("TarikhSarresid").Substring(0, 10);
                txtMablaghGhest.Text = Fm.gridView4.GetFocusedRowCellDisplayText("MablaghAghsat");
                txtTarikhDaryaft.Text = Fm.gridView4.GetFocusedRowCellDisplayText("TarikhDaryaft").Substring(0, 10);
                txtMablaghDaryaft.Text = Fm.gridView4.GetFocusedRowCellDisplayText("MablaghDaryafti");
                cmbNameHesab.EditValue = Convert.ToInt32(Fm.gridView4.GetFocusedRowCellValue("NameHesabId"));
                txtSharh.Text = Fm.gridView4.GetFocusedRowCellDisplayText("Sharh");
                btnSaveNext.Visible = false;

            }


        }

        private void FrmDaryafteAghsateVam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnSaveClose_Click(sender, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, null);
            }

        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbPardakhtKonande.Text))
            {
                XtraMessageBox.Show("فیلد نام پرداخت کننده نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtCodeVam.Text))
            {
                XtraMessageBox.Show("فیلد کد وام نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtSeryal.Text))
            {
                XtraMessageBox.Show("فیلد سریال نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(txtTarikhDaryaft.Text))
            {
                XtraMessageBox.Show("لطفاً تاریخ دریافت را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(txtMablaghDaryaft.Text))
            {
                XtraMessageBox.Show("لطفاً مبلغ دریافت را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(cmbNameHesab.Text))
            {
                XtraMessageBox.Show("لطفاً حساب بانک یا صندوق را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int RowId = Convert.ToInt32(txtId.Text);
                        var q = db.RizeAghsatVams.FirstOrDefault(s => s.Id == RowId);
                        if (En == EnumCED.Create)
                        {
                            if (q != null)
                            {
                                q.SeryalDaryaft = Convert.ToInt32(txtSeryal.Text);
                                if (!string.IsNullOrEmpty(txtTarikhDaryaft.Text))
                                {
                                    q.TarikhDaryaft = Convert.ToDateTime(txtTarikhDaryaft.Text.Substring(0, 10));
                                }
                                q.MablaghDaryafti = !string.IsNullOrEmpty(txtMablaghDaryaft.Text) ? Convert.ToDecimal(txtMablaghDaryaft.Text) : 0;
                                q.NameHesabId = Convert.ToInt32(cmbNameHesab.EditValue);
                                q.NameHesab = cmbNameHesab.Text;
                                q.Sharh = txtSharh.Text;
                                db.SaveChanges();
                                //XtraMessageBox.Show("اطلاعات با موفقیت ثبت شد", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                En = EnumCED.Save;
                                Fm.btnDisplyActiveList4_Click(null, null);
                                Fm.gridView4.FocusedRowHandle = Fm.IndexAkharinDaruaft;
                                this.Close();
                                if (Convert.ToInt32(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) == 0)
                                {
                                    if (XtraMessageBox.Show("با دریافت این قسط وام مذکور تسویه شد آیا وام فوق به لیست وامهای تسویه شده انتقال یابد؟", "پیغام ثبت ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                    {
                                        var q1 = db.VamPardakhtis.FirstOrDefault(s => s.Id == q.VamPardakhtiId);
                                        if (q1 != null)
                                        {
                                            q1.IsTasviye = true;
                                            db.SaveChanges();
                                            Fm.btnDisplyActiveList3_Click(null, null);
                                        }
                                    }
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            if (q != null)
                            {
                                //q.SeryalDaryaft = Convert.ToInt32(txtSeryal.Text);
                                if (!string.IsNullOrEmpty(txtTarikhDaryaft.Text))
                                {
                                    q.TarikhDaryaft = Convert.ToDateTime(txtTarikhDaryaft.Text.Substring(0, 10));
                                }
                                q.MablaghDaryafti = !string.IsNullOrEmpty(txtMablaghDaryaft.Text) ? Convert.ToDecimal(txtMablaghDaryaft.Text) : 0;
                                q.NameHesabId = Convert.ToInt32(cmbNameHesab.EditValue);
                                q.NameHesab = cmbNameHesab.Text;
                                q.Sharh = txtSharh.Text;
                                db.SaveChanges();
                                //XtraMessageBox.Show("اطلاعات با موفقیت ویرایش شد", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                En = EnumCED.Save;
                                Fm.btnDisplyActiveList4_Click(null, null);
                                if (Fm.gridView4.RowCount > 0)
                                    Fm.gridView4.FocusedRowHandle = EditRowIndex;
                                this.Close();
                                var q1 = db.VamPardakhtis.FirstOrDefault(s => s.Id == q.VamPardakhtiId);
                                if (q1.IsTasviye == false)
                                {
                                    if (Convert.ToInt32(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) == 0)
                                    {
                                        if (XtraMessageBox.Show("وام تسویه شد آیا به لیست وامهای تسویه شده انتقال یابد؟", "پیغام ثبت ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                        {
                                            if (q1 != null)
                                            {
                                                q1.IsTasviye = true;
                                                db.SaveChanges();
                                                Fm.btnDisplyActiveList3_Click(null, null);
                                            }
                                        }

                                    }
                                }
                                else
                                {
                                    if (Convert.ToInt32(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) != 0)
                                    {
                                        if (XtraMessageBox.Show("با ویرایش دریافت این قسط ، وام مذکور از حالت تسویه خارج شد آیا وام فوق به لیست وامهای تسویه نشده انتقال یابد؟", "پیغام ثبت ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                        {
                                            if (q1 != null)
                                            {
                                                q1.IsTasviye = false;
                                                db.SaveChanges();
                                                Fm.btnDisplyActiveList3_Click(null, null);
                                            }
                                        }
                                    }
                                }
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

        private void FrmDaryafteAghsateVam_FormClosing(object sender, FormClosingEventArgs e)
        {
            En = EnumCED.Cancel;
        }

        public new void ActiveForm(XtraForm form)
        {
            if (Application.OpenForms[form.Name] == null)
            {
                form.Show(this);
            }
            else
            {
                Application.OpenForms[form.Name].Activate();
            }

        }

        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            btnSaveClose_Click(null, null);
            ActiveForm(this);
            this.Visible = false;
            Fm.btnCreate4_Click(null, null);
        }
    }
}