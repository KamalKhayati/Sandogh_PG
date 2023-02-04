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
                    var q1 = dataContext.AllHesabTafzilis.Where(s => s.GroupTafziliId == 3).OrderBy(s => s.Code).ToList();
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
        //public void FillcmbNameHesab()
        //{
        //    using (var db = new MyContext())
        //    {
        //        try
        //        {
        //            if (En == EnumCED.Create)
        //            {
        //                var q1 = db.AllHesabTafzilis.Where(s => s.GroupTafziliId == 1 || s.GroupTafziliId == 2 || s.GroupTafziliId == 3 && s.IsActive == true).OrderBy(s => s.Code).ToList();
        //                if (q1.Count > 0)
        //                    allHesabTafzilisBindingSource1.DataSource = q1;
        //                else
        //                    allHesabTafzilisBindingSource1.DataSource = null;
        //            }
        //            else
        //            {
        //                var q1 = db.AllHesabTafzilis.Where(s => s.GroupTafziliId == 1 || s.GroupTafziliId == 2).OrderBy(s => s.Code).ToList();
        //                if (q1.Count > 0)
        //                    allHesabTafzilisBindingSource1.DataSource = q1;
        //                else
        //                    allHesabTafzilisBindingSource1.DataSource = null;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
        //                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

        //}
        public void FillcmbHesabMoin()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q1 = db.CodeMoins.Select(s => s).ToList();
                    if (q1.Count > 0)
                        codeMoinsBindingSource.DataSource = q1;
                    else
                        codeMoinsBindingSource.DataSource = null;
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
                        txtSeryal.Text = "1";
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        decimal MablaghDaryaftBeforEdit = 0;
        string _deviceID = string.Empty;
        string _dataBaseName = string.Empty;
        private void FrmDaryafteAghsateVam_Load(object sender, EventArgs e)
        {
            FillcmbPardakhtKonande();
            FillcmbHesabMoin();
            //FillcmbNameHesab();
            cmbPardakhtKonande.EditValue = Convert.ToInt32(Fm.gridView3.GetFocusedRowCellValue("AazaId"));
            txtCodeVam.Text = Fm.gridView3.GetFocusedRowCellDisplayText("Code");
            HelpClass1.DateTimeMask(txtTarikhDaryaft);
            HelpClass1.DateTimeMask(txtSarresidGhest);

            using (var db = new MyContext())
            {
                try
                {
                    _deviceID = HelpClass1.GetMadarBoardSerial();
                    _dataBaseName = db.Database.Connection.Database;

                    if (En == EnumCED.Create)
                    {
                        NewSeryal();
                        txtTarikhDaryaft.Text = DateTime.Now.ToString().Substring(0, 10);
                        //txtMablaghDaryaft.Text = Fm.gridView4.GetFocusedRowCellDisplayText("MablaghAghsat");

                        //var q2 = db.HesabBankis.FirstOrDefault(s => s.IsActive == true && s.IsDefault == true);
                        //if (q2 != null)
                        //{
                        //    var qq1 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2 && f.Id2 == q2.Id);
                        //    if (qq1 != null)
                        //    {
                        //        cmbMoin.EditValue = 1;
                        //        cmbNameHesab.EditValue = qq1.Id;

                        //    }
                        //}

                        int _SandoghId = Convert.ToInt32(Fm.Fm.IDSandogh.Caption);
                        var q2 = db.Tanzimats.FirstOrDefault(s => s.Id == _SandoghId);
                        if (q2 != null)
                        {
                            cmbMoin.EditValue = q2.MoinDefaultId;
                            cmbNameHesab.EditValue = q2.TafsiliDefaultId;
                        }


                        int _CodeVam = Convert.ToInt32(Fm.gridView3.GetFocusedRowCellDisplayText("Code"));
                        int MinShomareGhest = db.RizeAghsatVams.Where(s => s.VamPardakhtiCode == _CodeVam && s.SeryalDaryaft == 0).Min(s => s.ShomareGhest);
                        var q1 = db.RizeAghsatVams.FirstOrDefault(s => s.VamPardakhtiCode == _CodeVam && s.SeryalDaryaft == 0 && s.ShomareGhest == MinShomareGhest);

                        if (q1 != null)
                        {
                            txtId.Text = q1.Id.ToString();
                            txtShomareGhest.Text = q1.ShomareGhest.ToString();
                            txtSarresidGhest.Text = q1.TarikhSarresid.ToString().Substring(0, 10);
                            txtMablaghGhest.Text = q1.MablaghAghsat.ToString();
                            txtMablaghDaryaft.Text = q1.MablaghAghsat.ToString();
                        }


                        _NameAaza = cmbPardakhtKonande.Text;
                        _ShomareGhest = txtShomareGhest.Text;
                        _ShomareVam = txtCodeVam.Text;
                        txtSharh.Text = _Text1 + _NameAaza + _Babat + _ShomareGhest + _Text2 + _ShomareVam;
                    }
                    else if (En == EnumCED.Edit)
                    {
                        int _shSanad = Convert.ToInt32(Fm.gridView4.GetFocusedRowCellDisplayText("ShomareSanad"));
                        txtSeryal.Text = Fm.gridView4.GetFocusedRowCellDisplayText("SeryalDaryaft");
                        txtId.Text = Fm.gridView4.GetFocusedRowCellDisplayText("Id");
                        txtShomareGhest.Text = Fm.gridView4.GetFocusedRowCellDisplayText("ShomareGhest");
                        txtSarresidGhest.Text = Fm.gridView4.GetFocusedRowCellDisplayText("TarikhSarresid").Substring(0, 10);
                        txtMablaghGhest.Text = Fm.gridView4.GetFocusedRowCellDisplayText("MablaghAghsat");
                        txtTarikhDaryaft.Text = Fm.gridView4.GetFocusedRowCellDisplayText("TarikhDaryaft").Substring(0, 10);
                        txtMablaghDaryaft.Text = Fm.gridView4.GetFocusedRowCellDisplayText("MablaghDaryafti");
                        int _MoinId = Convert.ToInt32(db.AsnadeHesabdariRows.FirstOrDefault(f => f.ShomareSanad == _shSanad).HesabMoinId);
                        cmbMoin.EditValue = _MoinId;
                        cmbNameHesab.EditValue = Convert.ToInt32(Fm.gridView4.GetFocusedRowCellValue("NameHesabId"));
                        txtSharh.Text = Fm.gridView4.GetFocusedRowCellDisplayText("Sharh");
                        btnSaveNext.Visible = false;
                        MablaghDaryaftBeforEdit = Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));
                    }
                    txtTarikhDaryaft.Focus();

                    var k = db.AllowedDevises.FirstOrDefault(s => s.DeviceID == _deviceID && s.DataBaseName == _dataBaseName);
                    if (k.VersionType == "Demo")
                    {
                        var d = db.AsnadeHesabdariRows.AsParallel();
                        if (d.Count() >= 200)
                        {
                            k.IsActive = false;
                            db.SaveChanges();
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
        private void FrmDaryafteAghsateVam_KeyDown(object sender, KeyEventArgs e)
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

        public bool IsValidation()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var k = db.AllowedDevises.FirstOrDefault(s => s.DeviceID == _deviceID && s.DataBaseName == _dataBaseName);
                    if (k != null)
                    {
                        if (k.VersionType == "Orginal")
                        {
                            return true;
                        }
                        else
                        {
                            if (k.VersionType == "Demo")
                            {
                                if (k.IsActive == true)
                                {
                                    return true;
                                }
                                else if (k.IsActive == false)
                                {
                                    XtraMessageBox.Show("در نسخه آزمایشی نمیتوان بیشتر از 100 مورد سند صادر و یا ویرایش نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }

                            }
                            else if (k.VersionType == "Display")
                            {
                                XtraMessageBox.Show("در نسخه نمایشی نمیتوان سند صادر و یا ویرایش نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }

                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return true;
            }

        }
        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbPardakhtKonande.Text))
            {
                XtraMessageBox.Show("فیلد نام پرداخت کننده نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(txtCodeVam.Text))
            {
                XtraMessageBox.Show("فیلد کد وام نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(txtSeryal.Text))
            {
                XtraMessageBox.Show("فیلد سریال نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(txtTarikhDaryaft.Text))
            {
                XtraMessageBox.Show("لطفاً تاریخ دریافت را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtMablaghDaryaft.Text == "0")
            {
                XtraMessageBox.Show("لطفاً مبلغ دریافت را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Convert.ToDecimal(txtMablaghDaryaft.Text.Replace(",", "")) < 0)
            {
                XtraMessageBox.Show("مبلغ دریافت صحیح نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(cmbNameHesab.Text))
            {
                XtraMessageBox.Show("لطفاً حساب بانک یا صندوق را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (IsValidation())
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int RowId = Convert.ToInt32(txtId.Text);
                        var q = db.RizeAghsatVams.FirstOrDefault(s => s.Id == RowId);
                        int yyyy2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(0, 4));
                        int MM2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(5, 2));
                        int dd2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(8, 2));
                        Mydate d2 = new Mydate(yyyy2, MM2, dd2);
                        int yyyy3 = Convert.ToInt32(txtTarikhDaryaft.Text.Substring(0, 4));
                        int MM3 = Convert.ToInt32(txtTarikhDaryaft.Text.Substring(5, 2));
                        int dd3 = Convert.ToInt32(txtTarikhDaryaft.Text.Substring(8, 2));
                        Mydate d3 = new Mydate(yyyy3, MM3, dd3);

                        if (En == EnumCED.Create)
                        {
                            var q2 = db.AsnadeHesabdariRows.Any() ? db.AsnadeHesabdariRows.Max(f => f.ShomareSanad) : 0;
                            if (q != null)
                            {
                                q.SeryalDaryaft = Convert.ToInt32(txtSeryal.Text);
                                if (!string.IsNullOrEmpty(txtTarikhDaryaft.Text))
                                {
                                    q.TarikhDaryaft = Convert.ToDateTime(txtTarikhDaryaft.Text.Substring(0, 10));
                                }
                                if (txtMablaghDaryaft.Text != "0")
                                    q.MablaghDaryafti = Convert.ToDecimal(txtMablaghDaryaft.Text);
                                q.NameHesabId = Convert.ToInt32(cmbNameHesab.EditValue);
                                q.NameHesab = cmbNameHesab.Text;
                                q.Sharh = txtSharh.Text;
                                q.ShomareSanad = q2 + 1;
                                //db.SaveChanges();
                                //////////////////////////////////////////////////////////////////////////////////////////
                                int _HesabMoinId1 = Convert.ToInt32(cmbMoin.EditValue);
                                var qq1 = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId1);
                                int _HesabTafId1 = Convert.ToInt32(cmbNameHesab.EditValue);
                                //var qq1 = db.CodeMoins.FirstOrDefault(f => f.Code == 1001);
                                var qq2 = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabTafId1);
                                AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
                                obj1.ShomareSanad = q2 + 1;
                                obj1.Tarikh = Convert.ToDateTime(txtTarikhDaryaft.Text.Substring(0, 10));
                                obj1.HesabMoinId = _HesabMoinId1;
                                obj1.HesabMoinCode = qq1.Code;
                                obj1.HesabMoinName = cmbMoin.Text;
                                obj1.HesabTafId = _HesabTafId1;
                                obj1.HesabTafCode = qq2.Code;
                                obj1.HesabTafName = cmbNameHesab.Text;
                                obj1.Bed = Convert.ToDecimal(txtMablaghDaryaft.Text.Replace(",", ""));
                                obj1.Sharh = txtSharh.Text;
                                obj1.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                db.AsnadeHesabdariRows.Add(obj1);

                                int _HesabTafId2 = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                                var qq3 = db.CodeMoins.FirstOrDefault(f => f.Code == 2001);
                                var qq4 = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabTafId2);
                                AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
                                obj2.ShomareSanad = q2 + 1;
                                obj2.Tarikh = Convert.ToDateTime(txtTarikhDaryaft.Text.Substring(0, 10));
                                obj2.HesabMoinId = qq3.Id;
                                obj2.HesabMoinCode = 2001;
                                obj2.HesabMoinName = qq3.Name;
                                obj2.HesabTafId = _HesabTafId2;
                                obj2.HesabTafCode = qq4.Code;
                                obj2.HesabTafName = cmbPardakhtKonande.Text;
                                obj2.Bes = Convert.ToDecimal(txtMablaghDaryaft.Text.Replace(",", ""));
                                obj2.Sharh = txtSharh.Text;
                                obj2.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                db.AsnadeHesabdariRows.Add(obj2);
                                ///////////////////////////////////////////////////////////////////////////////
                                int _codevam = Convert.ToInt32(txtCodeVam.Text);
                                int _shomareghestBadi = Convert.ToInt32(txtShomareGhest.Text) + 1;
                                var rs1 = Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));
                                decimal Result = Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) - Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", ""));
                                if (txtMablaghDaryaft.Text.Trim().Replace(",", "") != txtMablaghGhest.Text.Trim().Replace(",", ""))
                                {
                                    if (Result < 0)
                                    {
                                        if (txtShomareGhest.Text != db.RizeAghsatVams.Where(s => s.VamPardakhtiCode == _codevam).Max(s => s.ShomareGhest).ToString())
                                        {
                                            if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                XtraMessageBox.Show("مبلغ دریافتی بیشتر از مانده بدهی وام است لطفاً اصلاح فرمایید", "پیغام تصحیح ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                            else if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                // لازم نیست کاری انجام شود
                                            }
                                            else if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                //////////////////////////////////////////////

                                                if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                                {
                                                    var qs1 = XtraMessageBox.Show("با دریافت این قسط مبلغ مانده وام " + rs1.ToString("n0") + "  ریال خواهد بود آیا مبلغ قسط بعدی به مبلغ مانده وام اصلاح گردد؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                    if (qs1 == DialogResult.Yes)
                                                    {
                                                        var w = db.RizeAghsatVams.FirstOrDefault(s => s.VamPardakhtiCode == _codevam && s.ShomareGhest == _shomareghestBadi);
                                                        if (w != null)
                                                        {
                                                            q.MablaghAghsat = Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) + w.MablaghAghsat - rs1;

                                                            w.MablaghAghsat = rs1;
                                                        }
                                                    }
                                                    else if (qs1 == DialogResult.Cancel)
                                                    {
                                                        return;
                                                    }
                                                }
                                                else if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                                {
                                                    //var a = Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));

                                                    var qs1 = XtraMessageBox.Show("با دریافت این قسط مبلغ مانده وام " + rs1.ToString("n0") + "  ریال خواهد بود آیا مبلغ قسط بعدی به مبلغ مانده وام اصلاح گردد؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                    if (qs1 == DialogResult.Yes)
                                                    {
                                                        var w = db.RizeAghsatVams.FirstOrDefault(s => s.VamPardakhtiCode == _codevam && s.ShomareGhest == _shomareghestBadi);
                                                        if (w != null)
                                                        {
                                                            q.MablaghAghsat = Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) + w.MablaghAghsat - rs1;

                                                            w.MablaghAghsat = rs1;
                                                        }
                                                    }
                                                    else if (qs1 == DialogResult.Cancel)
                                                    {
                                                        return;
                                                    }
                                                }
                                                else if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                                {
                                                    var qs1 = XtraMessageBox.Show("آیا مبلغ کسری دریافتی به مبلغ قسط بعدی اضافه گردد؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                    if (qs1 == DialogResult.Yes)
                                                    {
                                                        q.MablaghAghsat = Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));
                                                        var w = db.RizeAghsatVams.FirstOrDefault(s => s.VamPardakhtiCode == _codevam && s.ShomareGhest == _shomareghestBadi);
                                                        if (w != null)
                                                            w.MablaghAghsat = w.MablaghAghsat - Result;
                                                        // XtraMessageBox.Show("مبلغ کسری دریافتی به مبلغ قسط بعدی اضافه گردید", "پیغام  ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                    else if (qs1 == DialogResult.Cancel)
                                                    {
                                                        return;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                XtraMessageBox.Show("مبلغ دریافتی بیشتر از مانده بدهی وام است لطفاً اصلاح فرمایید", "پیغام تصحیح ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                            else if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                // لازم نیست کاری انجام شود
                                            }
                                            else if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                RizeAghsatVam ct = new RizeAghsatVam();
                                                if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                                {
                                                    var qs1 = XtraMessageBox.Show("با توجه به اینکه اولاً دریافتی فوق مربوط به قسط آخر می باشد ثانیاً با دریافت این قسط مبلغ مانده وام  \n " + rs1.ToString("n0") + "  ریال خواهد بود آیا مایلید یک قسط جدید به تاریخ دوره بعد و به مبلغ مانده وام ایجاد شود؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                    if (qs1 == DialogResult.Yes)
                                                    {
                                                        q.MablaghAghsat = Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));
                                                        ct.MablaghAghsat = rs1;
                                                    }
                                                    else if (qs1 == DialogResult.No)
                                                    {
                                                        ct.MablaghAghsat = 0;
                                                    }
                                                    else if (qs1 == DialogResult.Cancel)
                                                    {
                                                        return;
                                                    }
                                                }
                                                else if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                                {
                                                    // q.MablaghAghsat = Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) - (Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")));
                                                    //ct.MablaghAghsat = Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));

                                                    //var a = Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));

                                                    var qs1 = XtraMessageBox.Show("با توجه به اینکه اولاً دریافتی فوق مربوط به قسط آخر می باشد ثانیاً با دریافت این قسط مبلغ مانده وام  \n " + rs1.ToString("n0") + "  ریال خواهد بود آیا مایلید یک قسط جدید به تاریخ دوره بعد و به مبلغ مانده وام ایجاد شود؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                    if (qs1 == DialogResult.Yes)
                                                    {
                                                        q.MablaghAghsat = Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) - rs1;
                                                        ct.MablaghAghsat = rs1;
                                                    }
                                                    else if (qs1 == DialogResult.No)
                                                    {
                                                        ct.MablaghAghsat = 0;
                                                    }
                                                    else if (qs1 == DialogResult.Cancel)
                                                    {
                                                        return;
                                                    }

                                                }
                                                else if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                                {

                                                    var qs1 = XtraMessageBox.Show("با توجه به اینکه اولاً دریافتی فوق مربوط به قسط آخر می باشد ثانیاً با دریافت این قسط مبلغ مانده وام  \n " + rs1.ToString("n0") + "  ریال خواهد بود لذا یک قسط جدید به تاریخ دوره بعد و به مبلغ صفر ریال ایجاد میشود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    //if (qs1 == DialogResult.Yes)
                                                    //{
                                                    //    ct.MablaghAghsat = 0;
                                                    //}
                                                    //else if (qs1 == DialogResult.Cancel)
                                                    //{
                                                    //    return;
                                                    //}
                                                    ct.MablaghAghsat = 0;

                                                }

                                                int _HesabAazaId2 = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                                                int VamId = q.VamPardakhtiId;
                                                int VamCode = q.VamPardakhtiCode;
                                                ct.ShomareGhest = _shomareghestBadi;
                                                ct.AazaId = _HesabAazaId2;
                                                ct.NameAaza = cmbPardakhtKonande.Text;
                                                ct.VamPardakhtiId = VamId;
                                                ct.VamPardakhtiCode = VamCode;
                                                //if (!string.IsNullOrEmpty(txtSarresidGhest.Text))
                                                //int yyyy2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(0, 4));
                                                //int MM2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(5, 2));
                                                //int dd2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(8, 2));
                                                //Mydate d2 = new Mydate(yyyy2, MM2, dd2);
                                                if (q.VamPardakhti1.IndexFaseleAghsat == 0)
                                                    d2.IncrementMonth();
                                                else if (q.VamPardakhti1.IndexFaseleAghsat == 1)
                                                    d2.IncrementYear();
                                                ct.TarikhSarresid = Convert.ToDateTime(d2.ToString());
                                                // if (!string.IsNullOrEmpty(txtMablaghGest.Text))
                                                ct.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                                db.RizeAghsatVams.Add(ct);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (txtShomareGhest.Text != db.RizeAghsatVams.Where(s => s.VamPardakhtiCode == _codevam).Max(s => s.ShomareGhest).ToString())
                                        {
                                            if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                XtraMessageBox.Show("مبلغ دریافتی بیشتر از مانده بدهی وام است لطفاً اصلاح فرمایید", "پیغام تصحیح ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                            else if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                // لازم نیست کاری انجام شود
                                            }
                                            else if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                #region MyRegion
                                                //////////////////////////////////////////////

                                                //if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                                //{
                                                //    var qs1 = XtraMessageBox.Show("با دریافت این قسط مبلغ مانده وام " + rs1 + "  ریال خواهد بود آیا مبلغ قسط بعدی به مبلغ مانده وام اصلاح گردد؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                //    if (qs1 == DialogResult.Yes)
                                                //    {
                                                //        q.MablaghAghsat = Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));
                                                //        var w = db.RizeAghsatVams.FirstOrDefault(s => s.VamPardakhtiCode == _codevam && s.ShomareGhest == _shomareghestBadi);
                                                //        if (w != null)
                                                //            w.MablaghAghsat = rs1;
                                                //    }
                                                //    else if (qs1 == DialogResult.Cancel)
                                                //    {
                                                //        return;
                                                //    }
                                                //}
                                                //if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                                //{
                                                //    //var a = Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));

                                                //    var qs1 = XtraMessageBox.Show("با دریافت این قسط مبلغ مانده وام " + rs1 + "  ریال خواهد بود آیا مبلغ قسط بعدی به مبلغ مانده وام اصلاح گردد؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                //    if (qs1 == DialogResult.Yes)
                                                //    {
                                                //        q.MablaghAghsat = Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) - rs1;
                                                //        var w = db.RizeAghsatVams.FirstOrDefault(s => s.VamPardakhtiCode == _codevam && s.ShomareGhest == _shomareghestBadi);
                                                //        if (w != null)
                                                //            w.MablaghAghsat = rs1;
                                                //    }
                                                //    else if (qs1 == DialogResult.Cancel)
                                                //    {
                                                //        return;
                                                //    }
                                                //}

                                                #endregion
                                                if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                                {
                                                    var qs1 = XtraMessageBox.Show("آیا مبلغ اضافه دریافتی از مبلغ اقساط بعدی کسر گردد؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                    if (qs1 == DialogResult.Yes)
                                                    {
                                                        q.MablaghAghsat = Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));
                                                        int _ShomareGhest = Convert.ToInt32(txtShomareGhest.Text);
                                                        var w = db.RizeAghsatVams.Where(s => s.VamPardakhtiCode == _codevam && s.ShomareGhest > _ShomareGhest).ToList();
                                                        var mb = Result;
                                                        if (w.Count > 0)
                                                            foreach (var item in w)
                                                            {
                                                                if (mb >= item.MablaghAghsat)
                                                                {
                                                                    mb = mb - item.MablaghAghsat;
                                                                    item.MablaghAghsat = 0;
                                                                }
                                                                else
                                                                {
                                                                    item.MablaghAghsat = item.MablaghAghsat - mb;
                                                                    break;
                                                                }
                                                            }
                                                        //w.MablaghAghsat = w.MablaghAghsat - Result;
                                                        // XtraMessageBox.Show("مبلغ کسری دریافتی به مبلغ قسط بعدی اضافه گردید", "پیغام  ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                    else if (qs1 == DialogResult.Cancel)
                                                    {
                                                        return;
                                                    }
                                                }
                                            }
                                            #region MyRegion

                                            //else if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            //{
                                            //    var a = db.RizeAghsatVams.Where(s => s.AazaId == _HesabTafId2 && s.VamPardakhtiCode == _codevam && s.ShomareSanad > 0).ToList();
                                            //    if (a.Count > 0)
                                            //    {
                                            //        var rs = a.Sum(s => s.MablaghAghsat) - a.Sum(s => s.MablaghDaryafti);
                                            //        if (rs == 0)
                                            //            q.MablaghAghsat = Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));
                                            //        else
                                            //            q.MablaghAghsat = Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) - rs;
                                            //    }
                                            //    else
                                            //        q.MablaghAghsat = Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));


                                            //    var r = db.RizeAghsatVams.Where(s => s.VamPardakhtiCode == _codevam && s.ShomareGhest >= _shomareghestBadi).ToList();
                                            //    if (r.Count > 0)
                                            //        db.RizeAghsatVams.RemoveRange(r);
                                            //}
                                            //else if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) && Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) > 0)
                                            //{

                                            //    //q.MablaghAghsat = Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));
                                            //    XtraMessageBox.Show("مبلغ دریافتی فقط در حالتهای ذیل مورد قبول می باشد : \n 1- مبلغ دریافتی با مبلغ قسط برابر باشد \n 2 - مبلغ دریافتی کمتر از مبلغ قسط باشد \n 3- مبلغ دریافتی با مانده قابل دریافت وام برابر باشد \n توجه : چنانچه مبلغ دریافتی بیشتر از مبلغ قسط وام و کمتر از مانده قابل دریافت وام باشد بایستی طی چند قسط ، دریافتی زده شود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            //    return;
                                            //}

                                            #endregion
                                        }
                                        else
                                        {
                                            if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                XtraMessageBox.Show("مبلغ دریافتی بیشتر از مانده بدهی وام است لطفاً اصلاح فرمایید", "پیغام تصحیح ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                            else if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                // لازم نیست کاری انجام شود
                                            }
                                            else if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                RizeAghsatVam ct = new RizeAghsatVam();
                                                #region MyRegion
                                                //if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                                //{
                                                //    var qs1 = XtraMessageBox.Show("با توجه به اینکه اولاً دریافتی فوق مربوط به قسط آخر می باشد ثانیاً با دریافت این قسط مبلغ مانده وام  \n " + rs1 + "  ریال خواهد بود آیا مایلید یک قسط جدید به تاریخ دوره بعد و به مبلغ مانده وام ایجاد شود؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                //    if (qs1 == DialogResult.Yes)
                                                //    {
                                                //        q.MablaghAghsat = Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));
                                                //        ct.MablaghAghsat = rs1;
                                                //    }
                                                //    else if (qs1 == DialogResult.Cancel)
                                                //    {
                                                //        return;
                                                //    }
                                                //}
                                                //if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                                //{
                                                //    // q.MablaghAghsat = Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) - (Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")));
                                                //    //ct.MablaghAghsat = Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));

                                                //    //var a = Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));

                                                //    var qs1 = XtraMessageBox.Show("با توجه به اینکه اولاً دریافتی فوق مربوط به قسط آخر می باشد ثانیاً با دریافت این قسط مبلغ مانده وام  \n " + rs1 + "  ریال خواهد بود آیا مایلید یک قسط جدید به تاریخ دوره بعد و به مبلغ مانده وام ایجاد شود؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                //    if (qs1 == DialogResult.Yes)
                                                //    {
                                                //        q.MablaghAghsat = Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) - rs1;
                                                //        ct.MablaghAghsat = rs1;
                                                //    }
                                                //    else if (qs1 == DialogResult.Cancel)
                                                //    {
                                                //        return;
                                                //    }

                                                //}

                                                #endregion
                                                if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                                {
                                                    // q.MablaghAghsat = Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) - (Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")));
                                                    //ct.MablaghAghsat = 0;

                                                    var qs1 = XtraMessageBox.Show("با توجه به اینکه اولاً دریافتی فوق مربوط به قسط آخر می باشد ثانیاً با دریافت این قسط مبلغ مانده وام  \n " + rs1.ToString("n0") + "  ریال خواهد بود لذا یک قسط جدید به تاریخ دوره بعد و به مبلغ صفر ریال ایجاد میشود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    //if (qs1 == DialogResult.Yes)
                                                    //{
                                                    //q.MablaghAghsat = Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) - rs1;
                                                    ct.MablaghAghsat = 0;
                                                    //}
                                                    //else if (qs1 == DialogResult.Cancel)
                                                    //{
                                                    //    return;
                                                    //}

                                                }

                                                int _HesabAazaId2 = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                                                int VamId = q.VamPardakhtiId;
                                                int VamCode = q.VamPardakhtiCode;
                                                ct.ShomareGhest = _shomareghestBadi;
                                                ct.AazaId = _HesabAazaId2;
                                                ct.NameAaza = cmbPardakhtKonande.Text;
                                                ct.VamPardakhtiId = VamId;
                                                ct.VamPardakhtiCode = VamCode;
                                                //if (!string.IsNullOrEmpty(txtSarresidGhest.Text))
                                                //int yyyy2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(0, 4));
                                                //int MM2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(5, 2));
                                                //int dd2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(8, 2));
                                                //Mydate d2 = new Mydate(yyyy2, MM2, dd2);
                                                if (q.VamPardakhti1.IndexFaseleAghsat == 0)
                                                    d2.IncrementMonth();
                                                else if (q.VamPardakhti1.IndexFaseleAghsat == 1)
                                                    d2.IncrementYear();
                                                ct.TarikhSarresid = Convert.ToDateTime(d2.ToString());
                                                // if (!string.IsNullOrEmpty(txtMablaghGest.Text))
                                                ct.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                                db.RizeAghsatVams.Add(ct);
                                            }
                                        }

                                    }
                                    #region MyRegion
                                    //if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) && Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) == 0)
                                    //{
                                    //    if (txtShomareGhest.Text == db.RizeAghsatVams.Where(s => s.VamPardakhtiCode == _codevam).Max(s => s.ShomareGhest).ToString())
                                    //    {
                                    //        var rs2 = XtraMessageBox.Show("با توجه به اینکه دریافتی فوق مربوط به قسط آخر می باشد و از طرفی مانده وام \nمذکور هنوز تسویه نشده است آیا مایلید یک قسط جدید به تاریخ دوره بعد ایجاد شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    //        if (rs2 == DialogResult.Yes)
                                    //        {
                                    //            //q.MablaghAghsat = rs1;
                                    //            int _HesabAazaId2 = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                                    //            int VamId = q.VamPardakhtiId;
                                    //            int VamCode = q.VamPardakhtiCode;
                                    //            RizeAghsatVam ct = new RizeAghsatVam();
                                    //            ct.ShomareGhest = _shomareghestBadi;
                                    //            ct.AazaId = _HesabAazaId2;
                                    //            ct.NameAaza = cmbPardakhtKonande.Text;
                                    //            ct.VamPardakhtiId = VamId;
                                    //            ct.VamPardakhtiCode = VamCode;
                                    //            //if (!string.IsNullOrEmpty(txtSarresidGhest.Text))
                                    //            //int yyyy2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(0, 4));
                                    //            //int MM2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(5, 2));
                                    //            //int dd2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(8, 2));
                                    //            //Mydate d2 = new Mydate(yyyy2, MM2, dd2);
                                    //            if (q.VamPardakhti1.IndexFaseleAghsat == 0)
                                    //                d2.IncrementMonth();
                                    //            else if (q.VamPardakhti1.IndexFaseleAghsat == 1)
                                    //                d2.IncrementYear();
                                    //            ct.TarikhSarresid = Convert.ToDateTime(d2.ToString());
                                    //            // if (!string.IsNullOrEmpty(txtMablaghGest.Text))
                                    //            ct.MablaghAghsat = 0;
                                    //            ct.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                    //            db.RizeAghsatVams.Add(ct);
                                    //            // XtraMessageBox.Show("توجه : \n در نظر داشته باشید با اینکار جمع ستون مبلغ اقساط با جمع ستون مبلغ دریافتی برابر نخواهد بود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //        }
                                    //    }
                                    //}
                                    //else if (txtMablaghDaryaft.Text.Trim().Replace(",", "") == txtMablaghGhest.Text.Trim().Replace(",", "") && txtShomareGhest.Text == db.RizeAghsatVams.Where(s => s.VamPardakhtiCode == _codevam).Max(s => s.ShomareGhest).ToString() && rs1 > 0)
                                    //{
                                    //    var rs2 = XtraMessageBox.Show("با توجه به اینکه دریافتی فوق مربوط به قسط آخر می باشد و از طرفی مانده وام \nمذکور هنوز تسویه نشده است آیا مایلید یک قسط جدید به تاریخ دوره بعد ایجاد شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    //    if (rs2 == DialogResult.Yes)
                                    //    {
                                    //        //q.MablaghAghsat = rs1;
                                    //        int _HesabAazaId2 = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                                    //        int VamId = q.VamPardakhtiId;
                                    //        int VamCode = q.VamPardakhtiCode;
                                    //        RizeAghsatVam ct = new RizeAghsatVam();
                                    //        ct.ShomareGhest = _shomareghestBadi;
                                    //        ct.AazaId = _HesabAazaId2;
                                    //        ct.NameAaza = cmbPardakhtKonande.Text;
                                    //        ct.VamPardakhtiId = VamId;
                                    //        ct.VamPardakhtiCode = VamCode;
                                    //        //if (!string.IsNullOrEmpty(txtSarresidGhest.Text))
                                    //        //int yyyy2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(0, 4));
                                    //        //int MM2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(5, 2));
                                    //        //int dd2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(8, 2));
                                    //        //Mydate d2 = new Mydate(yyyy2, MM2, dd2);
                                    //        if (q.VamPardakhti1.IndexFaseleAghsat == 0)
                                    //            d2.IncrementMonth();
                                    //        else if (q.VamPardakhti1.IndexFaseleAghsat == 1)
                                    //            d2.IncrementYear();
                                    //        ct.TarikhSarresid = Convert.ToDateTime(d2.ToString());
                                    //        // if (!string.IsNullOrEmpty(txtMablaghGest.Text))
                                    //        ct.MablaghAghsat = 0;
                                    //        ct.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                    //        db.RizeAghsatVams.Add(ct);
                                    //        // XtraMessageBox.Show("توجه : \n در نظر داشته باشید با اینکار جمع ستون مبلغ اقساط با جمع ستون مبلغ دریافتی برابر نخواهد بود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    //    }
                                    //}

                                    #endregion
                                }
                                else
                                {
                                    if (txtShomareGhest.Text != db.RizeAghsatVams.Where(s => s.VamPardakhtiCode == _codevam).Max(s => s.ShomareGhest).ToString())
                                    {
                                        if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                        {
                                            XtraMessageBox.Show("مبلغ دریافتی بیشتر از مانده بدهی وام است لطفاً اصلاح فرمایید", "پیغام تصحیح ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                        else if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                        {
                                            // لازم نیست کاری انجام شود
                                        }
                                        else if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                        {
                                            // لازم نیست کاری انجام شود

                                            //var a = Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));

                                            //    var qs1 = XtraMessageBox.Show("با دریافت این قسط مبلغ مانده وام " + rs1.ToString("n0") + "  ریال خواهد بود آیا مبلغ قسط بعدی به مبلغ مانده وام اصلاح گردد؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                            //    if (qs1 == DialogResult.Yes)
                                            //    {
                                            //        var w = db.RizeAghsatVams.FirstOrDefault(s => s.VamPardakhtiCode == _codevam && s.ShomareGhest == _shomareghestBadi);
                                            //        if (w != null)
                                            //        {
                                            //            q.MablaghAghsat = Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) + w.MablaghAghsat - rs1;

                                            //            w.MablaghAghsat = rs1;
                                            //        }
                                            //    }
                                            //    else if (qs1 == DialogResult.Cancel)
                                            //    {
                                            //        return;
                                            //    }
                                        }
                                    }
                                    else
                                    {
                                        if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                        {
                                            XtraMessageBox.Show("مبلغ دریافتی بیشتر از مانده بدهی وام است لطفاً اصلاح فرمایید", "پیغام تصحیح ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                        else if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                        {
                                            // لازم نیست کاری انجام شود
                                        }
                                        else if (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                        {
                                            var qs1 = XtraMessageBox.Show("با توجه به اینکه اولاً دریافتی فوق مربوط به قسط آخر می باشد ثانیاً با دریافت این قسط مبلغ مانده وام  \n " + rs1.ToString("n0") + "  ریال خواهد بود لذا یک قسط جدید به تاریخ دوره بعد و به مبلغ صفر ریال ایجاد میشود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            RizeAghsatVam ct = new RizeAghsatVam();
                                            ct.MablaghAghsat = 0;
                                            //}

                                            //var rs2 = XtraMessageBox.Show("با توجه به اینکه دریافتی فوق مربوط به قسط آخر می باشد و از طرفی مانده وام \nمذکور هنوز تسویه نشده است آیا مایلید یک قسط جدید به تاریخ دوره بعد ایجاد شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            //if (rs2 == DialogResult.Yes)
                                            //{
                                            //q.MablaghAghsat = rs1;
                                            int _HesabAazaId2 = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                                            int VamId = q.VamPardakhtiId;
                                            int VamCode = q.VamPardakhtiCode;
                                            ct.ShomareGhest = _shomareghestBadi;
                                            ct.AazaId = _HesabAazaId2;
                                            ct.NameAaza = cmbPardakhtKonande.Text;
                                            ct.VamPardakhtiId = VamId;
                                            ct.VamPardakhtiCode = VamCode;
                                            //if (!string.IsNullOrEmpty(txtSarresidGhest.Text))
                                            //int yyyy2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(0, 4));
                                            //int MM2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(5, 2));
                                            //int dd2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(8, 2));
                                            //Mydate d2 = new Mydate(yyyy2, MM2, dd2);
                                            if (q.VamPardakhti1.IndexFaseleAghsat == 0)
                                                d2.IncrementMonth();
                                            else if (q.VamPardakhti1.IndexFaseleAghsat == 1)
                                                d2.IncrementYear();
                                            ct.TarikhSarresid = Convert.ToDateTime(d2.ToString());
                                            // if (!string.IsNullOrEmpty(txtMablaghGest.Text))
                                            //ct.MablaghAghsat = 0;
                                            ct.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                            db.RizeAghsatVams.Add(ct);
                                            // XtraMessageBox.Show("توجه : \n در نظر داشته باشید با اینکار جمع ستون مبلغ اقساط با جمع ستون مبلغ دریافتی برابر نخواهد بود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        }


                                    }
                                }

                                db.SaveChanges();
                                //XtraMessageBox.Show("اطلاعات با موفقیت ثبت شد", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                En = EnumCED.Save;
                                Fm.btnDisplyActiveList4_Click(null, null);
                                Fm.gridView4.FocusedRowHandle = Fm.IndexAkharinDaruaftGhest;
                                this.Close();
                                // if (Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) == 0)
                                var m1 = Convert.ToDecimal(Fm.gridView4.Columns["MablaghDaryafti"].SummaryItem.SummaryValue);
                                var m2 = Convert.ToDecimal(Fm.gridView3.GetFocusedRowCellValue("MablaghAsli"));
                                var m3 = Convert.ToDecimal(Fm.gridView3.GetFocusedRowCellValue("MablaghKarmozd"));
                                if (m1 == m2 + m3)
                                {
                                    if (XtraMessageBox.Show("با دریافت این قسط وام مذکور تسویه شد آیا وام فوق به لیست وامهای تسویه شده انتقال یابد؟", "پیغام ثبت ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                    {
                                        var q1 = db.VamPardakhtis.FirstOrDefault(s => s.Id == q.VamPardakhtiId);
                                        if (q1 != null)
                                        {
                                            q1.IsTasviye = true;

                                            var w = db.R_VamPardakhti_B_Zamenins.Where(s => s.VamPardakhtiId == q.VamPardakhtiId).ToList();
                                            if (w.Count > 0)
                                            {
                                                foreach (var item in w)
                                                {
                                                    var r = db.AazaSandoghs.FirstOrDefault(s => s.AllTafId == item.AllTafId).EtebarBlookeShode;
                                                    r = r - item.EtebarBlookeShode;
                                                }
                                            }

                                            db.SaveChanges();
                                            Fm.btnDisplyActiveList3_Click(null, null);

                                            var n1 = db.CheckTazmins.FirstOrDefault(s => s.VamGerandeId == _HesabTafId2);
                                            if (n1 != null)
                                            {
                                                //int _AllTaf = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                                                var q5 = db.VamPardakhtis.FirstOrDefault(s => s.Id != q.VamPardakhtiId && s.AazaId == _HesabTafId2 && s.IsTasviye == false);
                                                if (q5 == null)
                                                    XtraMessageBox.Show("سند تضمینی بلوکه شده بابت وام فوق آزاد گردید لذا عودت آن به وام گیرنده بلامانع است", "پیغام ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            }
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
                                if (txtMablaghDaryaft.Text != "0")
                                    q.MablaghDaryafti = Convert.ToDecimal(txtMablaghDaryaft.Text);
                                q.NameHesabId = Convert.ToInt32(cmbNameHesab.EditValue);
                                q.NameHesab = cmbNameHesab.Text;
                                q.Sharh = txtSharh.Text;
                                /////////////////////////////////////////////////////////////////////////////////////////
                                var q2 = db.AsnadeHesabdariRows.Where(f => f.ShomareSanad == q.ShomareSanad);
                                if (q2.Count() > 0)
                                    db.AsnadeHesabdariRows.RemoveRange(q2);

                                //////////////////////////////////////////////////////////////////////////////////////////
                                int _HesabMoinId1 = Convert.ToInt32(cmbMoin.EditValue);
                                var qq1 = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId1);
                                int _HesabTafId1 = Convert.ToInt32(cmbNameHesab.EditValue);
                                //var qq1 = db.CodeMoins.FirstOrDefault(f => f.Code == 1001);
                                var qq2 = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabTafId1);
                                AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
                                obj1.ShomareSanad = q.ShomareSanad;
                                obj1.Tarikh = Convert.ToDateTime(txtTarikhDaryaft.Text.Substring(0, 10));
                                obj1.HesabMoinId = _HesabMoinId1;
                                obj1.HesabMoinCode = qq1.Code;
                                obj1.HesabMoinName = cmbMoin.Text;
                                obj1.HesabTafId = _HesabTafId1;
                                obj1.HesabTafCode = qq2.Code;
                                obj1.HesabTafName = cmbNameHesab.Text;
                                obj1.Bed = Convert.ToDecimal(txtMablaghDaryaft.Text.Replace(",", ""));
                                obj1.Sharh = txtSharh.Text;
                                obj1.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                db.AsnadeHesabdariRows.Add(obj1);

                                int _HesabTafId2 = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                                var qq3 = db.CodeMoins.FirstOrDefault(f => f.Code == 2001);
                                var qq4 = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabTafId2);
                                AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
                                obj2.ShomareSanad = q.ShomareSanad;
                                obj2.Tarikh = Convert.ToDateTime(txtTarikhDaryaft.Text.Substring(0, 10));
                                obj2.HesabMoinId = qq3.Id;
                                obj2.HesabMoinCode = 2001;
                                obj2.HesabMoinName = qq3.Name;
                                obj2.HesabTafId = _HesabTafId2;
                                obj2.HesabTafCode = qq4.Code;
                                obj2.HesabTafName = cmbPardakhtKonande.Text;
                                obj2.Bes = Convert.ToDecimal(txtMablaghDaryaft.Text.Replace(",", ""));
                                obj2.Sharh = txtSharh.Text;
                                obj2.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                db.AsnadeHesabdariRows.Add(obj2);

                                int _codevam = Convert.ToInt32(txtCodeVam.Text);
                                int _shomareghestBadi = Convert.ToInt32(txtShomareGhest.Text) + 1;
                                decimal Tafazol = (Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) - MablaghDaryaftBeforEdit);
                                var rs1 = Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Tafazol;
                                decimal Result = Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")) - Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", ""));
                                if (txtMablaghDaryaft.Text.Trim().Replace(",", "") != txtMablaghGhest.Text.Trim().Replace(",", ""))
                                {
                                    if (Result < 0)
                                    {
                                        if (txtShomareGhest.Text != db.RizeAghsatVams.Where(s => s.VamPardakhtiCode == _codevam).Max(s => s.ShomareGhest).ToString())
                                        {
                                            if (Tafazol > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                XtraMessageBox.Show("مبلغ ویرایش شده بیشتر از مانده بدهی وام است لطفاً اصلاح فرمایید", "پیغام تصحیح ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                            else if (Tafazol == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                // لازم نیست کاری انجام شود
                                            }
                                            else if (Tafazol < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                var rs = XtraMessageBox.Show("آیا مبلغ کسری دریافتی به مبلغ قسط بعدی اضافه گردد؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                if (rs == DialogResult.Yes)
                                                {
                                                    q.MablaghAghsat = Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));
                                                    var w = db.RizeAghsatVams.FirstOrDefault(s => s.VamPardakhtiCode == _codevam && s.ShomareGhest == _shomareghestBadi);
                                                    if (w != null)
                                                        w.MablaghAghsat = w.MablaghAghsat - Result;
                                                    // XtraMessageBox.Show("مبلغ کسری دریافتی به مبلغ قسط بعدی اضافه گردید", "پیغام  ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                else if (rs == DialogResult.Cancel)
                                                {
                                                    return;
                                                }
                                            }


                                        }
                                        else
                                        {
                                            if (Tafazol > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                XtraMessageBox.Show("مبلغ ویرایش شده بیشتر از مانده بدهی وام است لطفاً اصلاح فرمایید", "پیغام تصحیح ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                            else if (Tafazol == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                // لازم نیست کاری انجام شود
                                            }
                                            else if (Tafazol < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                RizeAghsatVam ct = new RizeAghsatVam();
                                                if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                                {
                                                    var qs1 = XtraMessageBox.Show("با توجه به اینکه اولاً دریافتی فوق مربوط به قسط آخر می باشد ثانیاً با ویرایش این قسط مبلغ مانده وام  \n " + rs1.ToString("n0") + "  ریال خواهد بود آیا مایلید یک قسط جدید به تاریخ دوره بعد و به مبلغ مانده وام ایجاد شود؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                    if (qs1 == DialogResult.Yes)
                                                    {
                                                        q.MablaghAghsat = q.MablaghAghsat - rs1;
                                                        ct.MablaghAghsat = rs1;
                                                    }
                                                    else if (qs1 == DialogResult.No)
                                                    {
                                                        ct.MablaghAghsat = 0;
                                                    }
                                                    else if (qs1 == DialogResult.Cancel)
                                                    {
                                                        return;
                                                    }
                                                }
                                                else if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                                {
                                                    // q.MablaghAghsat = Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) - (Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")));
                                                    //ct.MablaghAghsat = Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));

                                                    //var a = Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));

                                                    var qs1 = XtraMessageBox.Show("با توجه به اینکه اولاً دریافتی فوق مربوط به قسط آخر می باشد ثانیاً با ویرایش این قسط مبلغ مانده وام  \n " + rs1.ToString("n0") + "  ریال خواهد بود آیا مایلید یک قسط جدید به تاریخ دوره بعد و به مبلغ مانده وام ایجاد شود؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                    if (qs1 == DialogResult.Yes)
                                                    {
                                                        q.MablaghAghsat = q.MablaghAghsat - rs1;
                                                        ct.MablaghAghsat = rs1;
                                                    }
                                                    else if (qs1 == DialogResult.No)
                                                    {
                                                        ct.MablaghAghsat = 0;
                                                    }
                                                    else if (qs1 == DialogResult.Cancel)
                                                    {
                                                        return;
                                                    }

                                                }
                                                else if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                                {
                                                    var qs1 = XtraMessageBox.Show("با توجه به اینکه اولاً دریافتی فوق مربوط به قسط آخر می باشد ثانیاً با ویرایش این قسط مبلغ مانده وام  \n " + rs1.ToString("n0") + "  ریال خواهد بود لذا یک قسط جدید به تاریخ دوره بعد و به مبلغ صفر ریال ایجاد میشود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    ct.MablaghAghsat = 0;

                                                }

                                                //var rs = XtraMessageBox.Show("آیا جهت مبلغ کسری دریافتی قسط جدید به تاریخ دوره بعدایجاد گردد؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                //if (rs == DialogResult.Yes)
                                                //{
                                                q.MablaghAghsat = Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));
                                                int _HesabAazaId2 = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                                                int VamId = q.VamPardakhtiId;
                                                int VamCode = q.VamPardakhtiCode;
                                                //RizeAghsatVam ct = new RizeAghsatVam();
                                                ct.ShomareGhest = _shomareghestBadi;
                                                ct.AazaId = _HesabAazaId2;
                                                ct.NameAaza = cmbPardakhtKonande.Text;
                                                ct.VamPardakhtiId = VamId;
                                                ct.VamPardakhtiCode = VamCode;
                                                //if (!string.IsNullOrEmpty(txtSarresidGhest.Text))
                                                //int yyyy2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(0, 4));
                                                //int MM2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(5, 2));
                                                //int dd2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(8, 2));
                                                //Mydate d2 = new Mydate(yyyy2, MM2, dd2);
                                                if (q.VamPardakhti1.IndexFaseleAghsat == 0)
                                                    d2.IncrementMonth();
                                                else if (q.VamPardakhti1.IndexFaseleAghsat == 1)
                                                    d2.IncrementYear();
                                                ct.TarikhSarresid = Convert.ToDateTime(d2.ToString());
                                                // if (!string.IsNullOrEmpty(txtMablaghGest.Text))
                                                // ct.MablaghAghsat = Result * -1;
                                                ct.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                                db.RizeAghsatVams.Add(ct);
                                                #region MyRegion
                                                //}
                                                //else if (rs == DialogResult.No)
                                                //{
                                                //    if (Convert.ToInt32(txtMablaghDaryaft.Text.Trim().Replace(",", "")) < Convert.ToInt32(txtMablaghGhest.Text.Trim().Replace(",", "")) && txtShomareGhest.Text == db.RizeAghsatVams.Where(s => s.VamPardakhtiCode == _codevam).Max(s => s.ShomareGhest).ToString() && rs1 > 0)
                                                //    {
                                                //        var rs2 = XtraMessageBox.Show("با توجه به اینکه دریافتی فوق مربوط به قسط آخر می باشد و از طرفی مانده وام \nمذکور هنوز تسویه نشده است آیا مایلید یک قسط جدید به تاریخ دوره بعد ایجاد شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                                //        if (rs2 == DialogResult.Yes)
                                                //        {
                                                //            //q.MablaghAghsat = rs1;
                                                //            int _HesabAazaId2 = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                                                //            int VamId = q.VamPardakhtiId;
                                                //            int VamCode = q.VamPardakhtiCode;
                                                //            RizeAghsatVam ct = new RizeAghsatVam();
                                                //            ct.ShomareGhest = _shomareghestBadi;
                                                //            ct.AazaId = _HesabAazaId2;
                                                //            ct.NameAaza = cmbPardakhtKonande.Text;
                                                //            ct.VamPardakhtiId = VamId;
                                                //            ct.VamPardakhtiCode = VamCode;
                                                //            //if (!string.IsNullOrEmpty(txtSarresidGhest.Text))
                                                //            //int yyyy2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(0, 4));
                                                //            //int MM2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(5, 2));
                                                //            //int dd2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(8, 2));
                                                //            //Mydate d2 = new Mydate(yyyy2, MM2, dd2);
                                                //            if (q.VamPardakhti1.IndexFaseleAghsat == 0)
                                                //                d2.IncrementMonth();
                                                //            else if (q.VamPardakhti1.IndexFaseleAghsat == 1)
                                                //                d2.IncrementYear();
                                                //            ct.TarikhSarresid = Convert.ToDateTime(d2.ToString());
                                                //            // if (!string.IsNullOrEmpty(txtMablaghGest.Text))
                                                //            ct.MablaghAghsat = 0;
                                                //            ct.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                                //            db.RizeAghsatVams.Add(ct);
                                                //            // XtraMessageBox.Show("توجه : \n در نظر داشته باشید با اینکار جمع ستون مبلغ اقساط با جمع ستون مبلغ دریافتی برابر نخواهد بود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                //        }
                                                //    }

                                                //}
                                                //else if (rs == DialogResult.Cancel)
                                                //{
                                                //    return;
                                                //} 
                                                #endregion
                                            }

                                        }
                                    }
                                    else
                                    {
                                        if (txtShomareGhest.Text != db.RizeAghsatVams.Where(s => s.VamPardakhtiCode == _codevam).Max(s => s.ShomareGhest).ToString())
                                        {
                                            if (Tafazol > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                XtraMessageBox.Show("مبلغ ویرایش شده بیشتر از مانده بدهی وام است لطفاً اصلاح فرمایید", "پیغام تصحیح ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                            else if (Tafazol == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                // لازم نیست کاری انجام شود
                                            }
                                            else if (Tafazol < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                var qs1 = XtraMessageBox.Show("آیا مبلغ اضافه دریافتی از مبلغ اقساط بعدی کسر گردد؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                if (qs1 == DialogResult.Yes)
                                                {
                                                    q.MablaghAghsat = Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));
                                                    int _ShomareGhest = Convert.ToInt32(txtShomareGhest.Text);
                                                    var w = db.RizeAghsatVams.Where(s => s.VamPardakhtiCode == _codevam && s.ShomareGhest > _ShomareGhest).ToList();
                                                    var mb = Result;
                                                    if (w.Count > 0)
                                                        foreach (var item in w)
                                                        {
                                                            if (mb >= item.MablaghAghsat)
                                                            {
                                                                mb = mb - item.MablaghAghsat;
                                                                item.MablaghAghsat = 0;
                                                            }
                                                            else
                                                            {
                                                                item.MablaghAghsat = item.MablaghAghsat - mb;
                                                                break;
                                                            }
                                                        }
                                                    //w.MablaghAghsat = w.MablaghAghsat - Result;
                                                    // XtraMessageBox.Show("مبلغ کسری دریافتی به مبلغ قسط بعدی اضافه گردید", "پیغام  ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                else if (qs1 == DialogResult.Cancel)
                                                {
                                                    return;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (Tafazol > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                XtraMessageBox.Show("مبلغ ویرایش شده بیشتر از مانده بدهی وام است لطفاً اصلاح فرمایید", "پیغام تصحیح ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                            else if (Tafazol == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                // لازم نیست کاری انجام شود
                                            }
                                            else if (Tafazol < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                RizeAghsatVam ct = new RizeAghsatVam();
                                                if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                                {
                                                    var qs1 = XtraMessageBox.Show("با توجه به اینکه اولاً دریافتی فوق مربوط به قسط آخر می باشد ثانیاً با ویرایش این قسط مبلغ مانده وام  \n " + rs1.ToString("n0") + "  ریال خواهد بود آیا مایلید یک قسط جدید به تاریخ دوره بعد و به مبلغ مانده وام ایجاد شود؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                    if (qs1 == DialogResult.Yes)
                                                    {
                                                        q.MablaghAghsat = q.MablaghAghsat - rs1;
                                                        ct.MablaghAghsat = rs1;
                                                    }
                                                    else if (qs1 == DialogResult.No)
                                                    {
                                                        ct.MablaghAghsat = 0;
                                                    }
                                                    else if (qs1 == DialogResult.Cancel)
                                                    {
                                                        return;
                                                    }
                                                }
                                                else if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                                {
                                                    // q.MablaghAghsat = Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) - (Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")));
                                                    //ct.MablaghAghsat = Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));

                                                    //var a = Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));

                                                    var qs1 = XtraMessageBox.Show("با توجه به اینکه اولاً دریافتی فوق مربوط به قسط آخر می باشد ثانیاً با ویرایش این قسط مبلغ مانده وام  \n " + rs1.ToString("n0") + "  ریال خواهد بود آیا مایلید یک قسط جدید به تاریخ دوره بعد و به مبلغ مانده وام ایجاد شود؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                    if (qs1 == DialogResult.Yes)
                                                    {
                                                        q.MablaghAghsat = q.MablaghAghsat - rs1;
                                                        ct.MablaghAghsat = rs1;
                                                    }
                                                    else if (qs1 == DialogResult.No)
                                                    {
                                                        ct.MablaghAghsat = 0;
                                                    }
                                                    else if (qs1 == DialogResult.Cancel)
                                                    {
                                                        return;
                                                    }

                                                }
                                                else if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                                {

                                                    var qs1 = XtraMessageBox.Show("با توجه به اینکه اولاً دریافتی فوق مربوط به قسط آخر می باشد ثانیاً با ویرایش این قسط مبلغ مانده وام  \n " + rs1.ToString("n0") + "  ریال خواهد بود لذا یک قسط جدید به تاریخ دوره بعد و به مبلغ صفر ریال ایجاد میشود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    //if (qs1 == DialogResult.Yes)
                                                    //{
                                                    //    ct.MablaghAghsat = 0;
                                                    //}
                                                    //else if (qs1 == DialogResult.Cancel)
                                                    //{
                                                    //    return;
                                                    //}
                                                    ct.MablaghAghsat = 0;

                                                }

                                                //q.MablaghAghsat = rs1;
                                                int _HesabAazaId2 = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                                                int VamId = q.VamPardakhtiId;
                                                int VamCode = q.VamPardakhtiCode;
                                                //RizeAghsatVam ct = new RizeAghsatVam();
                                                ct.ShomareGhest = _shomareghestBadi;
                                                ct.AazaId = _HesabAazaId2;
                                                ct.NameAaza = cmbPardakhtKonande.Text;
                                                ct.VamPardakhtiId = VamId;
                                                ct.VamPardakhtiCode = VamCode;
                                                //if (!string.IsNullOrEmpty(txtSarresidGhest.Text))
                                                //int yyyy2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(0, 4));
                                                //int MM2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(5, 2));
                                                //int dd2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(8, 2));
                                                //Mydate d2 = new Mydate(yyyy2, MM2, dd2);
                                                if (q.VamPardakhti1.IndexFaseleAghsat == 0)
                                                    d2.IncrementMonth();
                                                else if (q.VamPardakhti1.IndexFaseleAghsat == 1)
                                                    d2.IncrementYear();
                                                ct.TarikhSarresid = Convert.ToDateTime(d2.ToString());
                                                // if (!string.IsNullOrEmpty(txtMablaghGest.Text))
                                                //ct.MablaghAghsat = 0;
                                                ct.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                                db.RizeAghsatVams.Add(ct);
                                                // XtraMessageBox.Show("توجه : \n در نظر داشته باشید با اینکار جمع ستون مبلغ اقساط با جمع ستون مبلغ دریافتی برابر نخواهد بود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }

                                        }
                                    }
                                }
                                else
                                {
                                    if (txtShomareGhest.Text != db.RizeAghsatVams.Where(s => s.VamPardakhtiCode == _codevam).Max(s => s.ShomareGhest).ToString())
                                    {
                                        if (Tafazol > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                        {
                                            XtraMessageBox.Show("مبلغ ویرایش شده بیشتر از مانده بدهی وام است لطفاً اصلاح فرمایید", "پیغام تصحیح ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                        else if (Tafazol == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                        {
                                            // لازم نیست کاری انجام شود
                                        }
                                        else if (Tafazol < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                        {
                                            // لازم نیست کاری انجام شود
                                        }
                                    }
                                    else
                                    {
                                        if (Tafazol > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                        {
                                            XtraMessageBox.Show("مبلغ ویرایش شده بیشتر از مانده بدهی وام است لطفاً اصلاح فرمایید", "پیغام تصحیح ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                        else if (Tafazol == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                        {
                                            // لازم نیست کاری انجام شود
                                        }
                                        else if (Tafazol < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                        {
                                            RizeAghsatVam ct = new RizeAghsatVam();
                                            if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) == Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                var qs1 = XtraMessageBox.Show("با توجه به اینکه اولاً دریافتی فوق مربوط به قسط آخر می باشد ثانیاً با ویرایش این قسط مبلغ مانده وام  \n " + rs1.ToString("n0") + "  ریال خواهد بود آیا مایلید یک قسط جدید به تاریخ دوره بعد و به مبلغ مانده وام ایجاد شود؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                if (qs1 == DialogResult.Yes)
                                                {
                                                    q.MablaghAghsat = q.MablaghAghsat - rs1;
                                                    ct.MablaghAghsat = rs1;
                                                }
                                                else if (qs1 == DialogResult.No)
                                                {
                                                    ct.MablaghAghsat = 0;
                                                }
                                                else if (qs1 == DialogResult.Cancel)
                                                {
                                                    return;
                                                }
                                            }
                                            else if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) > Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                // q.MablaghAghsat = Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) - (Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", "")));
                                                //ct.MablaghAghsat = Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));

                                                //var a = Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue) - Convert.ToDecimal(txtMablaghDaryaft.Text.Trim().Replace(",", ""));

                                                var qs1 = XtraMessageBox.Show("با توجه به اینکه اولاً دریافتی فوق مربوط به قسط آخر می باشد ثانیاً با ویرایش این قسط مبلغ مانده وام  \n " + rs1.ToString("n0") + "  ریال خواهد بود آیا مایلید یک قسط جدید به تاریخ دوره بعد و به مبلغ مانده وام ایجاد شود؟", "پیغام", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                                if (qs1 == DialogResult.Yes)
                                                {
                                                    q.MablaghAghsat = q.MablaghAghsat - rs1;
                                                    ct.MablaghAghsat = rs1;
                                                }
                                                else if (qs1 == DialogResult.No)
                                                {
                                                    ct.MablaghAghsat = 0;
                                                }
                                                else if (qs1 == DialogResult.Cancel)
                                                {
                                                    return;
                                                }

                                            }
                                            else if (Convert.ToDecimal(txtMablaghGhest.Text.Trim().Replace(",", "")) < Convert.ToDecimal(Fm.gridView4.Columns["Mande"].SummaryItem.SummaryValue))
                                            {
                                                var qs1 = XtraMessageBox.Show("با توجه به اینکه اولاً دریافتی فوق مربوط به قسط آخر می باشد ثانیاً با ویرایش این قسط مبلغ مانده وام  \n " + rs1.ToString("n0") + "  ریال خواهد بود لذا یک قسط جدید به تاریخ دوره بعد و به مبلغ صفر ریال ایجاد میشود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                ct.MablaghAghsat = 0;
                                            }
                                            //}

                                            //var rs2 = XtraMessageBox.Show("با توجه به اینکه دریافتی فوق مربوط به قسط آخر می باشد و از طرفی مانده وام \nمذکور هنوز تسویه نشده است آیا مایلید یک قسط جدید به تاریخ دوره بعد ایجاد شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            //if (rs2 == DialogResult.Yes)
                                            //{
                                            //q.MablaghAghsat = rs1;
                                            int _HesabAazaId2 = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                                            int VamId = q.VamPardakhtiId;
                                            int VamCode = q.VamPardakhtiCode;
                                            ct.ShomareGhest = _shomareghestBadi;
                                            ct.AazaId = _HesabAazaId2;
                                            ct.NameAaza = cmbPardakhtKonande.Text;
                                            ct.VamPardakhtiId = VamId;
                                            ct.VamPardakhtiCode = VamCode;
                                            //if (!string.IsNullOrEmpty(txtSarresidGhest.Text))
                                            //int yyyy2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(0, 4));
                                            //int MM2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(5, 2));
                                            //int dd2 = Convert.ToInt32(txtSarresidGhest.Text.Substring(8, 2));
                                            //Mydate d2 = new Mydate(yyyy2, MM2, dd2);
                                            if (q.VamPardakhti1.IndexFaseleAghsat == 0)
                                                d2.IncrementMonth();
                                            else if (q.VamPardakhti1.IndexFaseleAghsat == 1)
                                                d2.IncrementYear();
                                            ct.TarikhSarresid = Convert.ToDateTime(d2.ToString());
                                            // if (!string.IsNullOrEmpty(txtMablaghGest.Text))
                                            //ct.MablaghAghsat = 0;
                                            ct.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                            db.RizeAghsatVams.Add(ct);
                                            // XtraMessageBox.Show("توجه : \n در نظر داشته باشید با اینکار جمع ستون مبلغ اقساط با جمع ستون مبلغ دریافتی برابر نخواهد بود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        }
                                    }
                                }

                                db.SaveChanges();
                                //XtraMessageBox.Show("اطلاعات با موفقیت ویرایش شد", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                En = EnumCED.Save;
                                Fm.btnDisplyActiveList4_Click(null, null);
                                if (Fm.gridView4.RowCount > 0)
                                    Fm.gridView4.FocusedRowHandle = EditRowIndex;
                                this.Close();

                                var m1 = Convert.ToDecimal(Fm.gridView4.Columns["MablaghDaryafti"].SummaryItem.SummaryValue);
                                var m2 = Convert.ToDecimal(Fm.gridView3.GetFocusedRowCellValue("MablaghAsli"));
                                var m3 = Convert.ToDecimal(Fm.gridView3.GetFocusedRowCellValue("MablaghKarmozd"));

                                var q1 = db.VamPardakhtis.FirstOrDefault(s => s.Id == q.VamPardakhtiId);
                                if (q1.IsTasviye == false)
                                {
                                    if (m1 == m2 + m3)
                                    {
                                        if (XtraMessageBox.Show("مبلغ وام تسویه شد آیا به لیست وامهای تسویه شده انتقال یابد؟", "پیغام ثبت ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                        {
                                            if (q1 != null)
                                            {
                                                q1.IsTasviye = true;
                                                db.SaveChanges();
                                                Fm.btnDisplyActiveList3_Click(null, null);

                                                var n1 = db.CheckTazmins.FirstOrDefault(s => s.VamGerandeId == _HesabTafId2);
                                                if (n1 != null)
                                                {
                                                    //int _AllTaf = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                                                    var q5 = db.VamPardakhtis.FirstOrDefault(s => s.Id != q.VamPardakhtiId && s.AazaId == _HesabTafId2 && s.IsTasviye == false);
                                                    if (q5 == null)
                                                        XtraMessageBox.Show("سند تضمینی بلوکه شده بابت وام فوق آزاد گردید لذا عودت آن به وام گیرنده بلامانع است", "پیغام ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                }

                                            }
                                        }

                                    }
                                }
                                else
                                {
                                    if (m1 != m2 + m3)
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
            using (var db = new MyContext())
            {
                try
                {
                    var k = db.AllowedDevises.FirstOrDefault(s => s.DeviceID == _deviceID && s.DataBaseName == _dataBaseName);
                    if (k.VersionType != "Orginal")
                    {
                        if (k.IsActive == true)
                        {
                            var d = db.AsnadeHesabdariRows.Count();
                            if (d > 200)
                            {
                                k.IsActive = false;
                                db.SaveChanges();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            btnSaveClose_Click(null, null);
            if (En == EnumCED.Cancel)
            {
                ActiveForm(this);
                this.Visible = false;
                Fm.btnCreate4_Click(null, null);

            }
        }

        private void cmbNameHesab_Enter(object sender, EventArgs e)
        {
            cmbNameHesab.ShowPopup();
        }

        private void txtMablaghDaryaft_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelpClass1.AddZerooToTextBox(sender, e);

        }

        public void FillcmbNameHesab()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _HesabMoinId = Convert.ToInt32(cmbMoin.EditValue);
                    var q = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId);
                    if (q != null)
                    {
                        switch (q.Code)
                        {
                            case 1001:
                                {
                                    //allHesabTafzilisBindingSource.DisplayMember = "NameHesab";
                                    //allHesabTafzilisBindingSource.ValueMember = "Id";
                                    //allHesabTafzilisBindingSource.Columns[1].FieldName = "NameHesab";
                                    if (En == EnumCED.Create)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2 ).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = En == EnumCED.Create ? q1.Where(f => f.IsActive == true).OrderBy(s => s.Code).ToList() : q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2).OrderBy(s => s.Code).ToList();
                                        if (q2.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q2;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    break;
                                }
                            case 2001:
                                {
                                    //allHesabTafzilisBindingSource.DisplayMember = "NameVFamil";
                                    //allHesabTafzilisBindingSource.ValueMember = "Id";
                                    //allHesabTafzilisBindingSource.Columns[1].FieldName = "NameVFamil";
                                    if (En == EnumCED.Create)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 3 ).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = En == EnumCED.Create ? q1.Where(f => f.IsActive == true).OrderBy(s => s.Code).ToList() : q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 3).OrderBy(s => s.Code).ToList();
                                        if (q2.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q2;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    break;
                                }
                            case 3001:
                                {
                                    goto case 2001;
                                }
                            case 4001:
                                {
                                    goto case 2001;
                                }
                            case 5001:
                                {
                                    if (En == EnumCED.Create)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 6 ).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = En == EnumCED.Create ? q1.Where(f => f.IsActive == true).OrderBy(s => s.Code).ToList() : q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 6).OrderBy(s => s.Code).ToList();
                                        if (q2.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q2;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    break;
                                }
                            case 6001:
                                {
                                    goto case 2001;
                                }
                            case 6002:
                                {
                                    goto case 2001;
                                }
                            case 6003:
                                {
                                    goto case 2001;
                                }
                            case 7001:
                                {
                                    goto case 2001;
                                }
                            case 8001:
                                {
                                    //allHesabTafzilisBindingSource.DisplayMember = "HesabName";
                                    //allHesabTafzilisBindingSource.ValueMember = "Id";
                                    //allHesabTafzilisBindingSource.Columns[1].FieldName = "HesabName";
                                    if (En == EnumCED.Create)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 4 ).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = En == EnumCED.Create ? q1.Where(f => f.IsActive == true).OrderBy(s => s.Code).ToList() : q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 4).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    break;
                                }
                            case 9001:
                                {
                                    //allHesabTafzilisBindingSource.DisplayMember = "HesabName";
                                    //allHesabTafzilisBindingSource.ValueMember = "Id";
                                    //allHesabTafzilisBindingSource.Columns[1].FieldName = "HesabName";
                                    if (En == EnumCED.Create)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 5 ).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = En == EnumCED.Create ? q1.Where(f => f.IsActive == true).OrderBy(s => s.Code).ToList() : q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 5).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    break;
                                }
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

        private void cmbMoin_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbNameHesab();
        }

        private void cmbMoin_Enter(object sender, EventArgs e)
        {
            cmbMoin.ShowPopup();
        }
    }
}