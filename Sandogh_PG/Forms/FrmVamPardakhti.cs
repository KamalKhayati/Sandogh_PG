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
using System.Collections;
using Sandogh_PG.Forms;

namespace Sandogh_PG
{
    public partial class FrmVamPardakhti : DevExpress.XtraEditors.XtraForm
    {
        public FrmListVamhayePardakhti Fm;
        public FrmVamPardakhti(FrmListVamhayePardakhti fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        public EnumCED En;
        public int EditRowIndex = 0;
        public int _IDSandogh = 0;
        public bool IsEditRizAghsat = true;
        //public bool ListTasviyeNashode = true;
        public void FillcmbDaryaftkonande()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (Fm.ListTasviyeNashode)
                    {
                        var q1 = db.AllHesabTafzilis.Where(s => s.GroupTafziliId == 3).OrderBy(s => s.Code).AsParallel();
                        if (q1.Count() > 0)
                            allHesabTafzilisBindingSource.DataSource = En == EnumCED.Create ? q1.Where(s => s.IsActive == true).OrderBy(s => s.Code).AsParallel() : q1;
                        else
                            allHesabTafzilisBindingSource.DataSource = null;
                    }
                    else
                    {
                        var q1 = db.AllHesabTafzilis.Where(s => s.GroupTafziliId == 3).OrderBy(s => s.Code).AsParallel();
                        if (q1.Count() > 0)
                            allHesabTafzilisBindingSource.DataSource = q1;
                        else
                            allHesabTafzilisBindingSource.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillcmbHesabMoin()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q1 = db.CodeMoins.OrderBy(s => s.Code).AsParallel();
                    if (q1.Count() > 0)
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
        public void FillcmbHesabTafzili()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
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
                                    if (Fm.ListTasviyeNashode)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2).OrderBy(s => s.Code).AsParallel();
                                        if (q1.Count() > 0)
                                            allHesabTafzilisBindingSource1.DataSource = En == EnumCED.Create ? q1.Where(f => f.IsActive == true).OrderBy(s => s.Code).AsParallel() : q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2).OrderBy(s => s.Code).AsParallel();
                                        if (q2.Count() > 0)
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
                                    if (Fm.ListTasviyeNashode)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 3).OrderBy(s => s.Code).AsParallel();
                                        if (q1.Count() > 0)
                                            allHesabTafzilisBindingSource1.DataSource = En == EnumCED.Create ? q1.Where(f => f.IsActive == true).OrderBy(s => s.Code).AsParallel() : q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 3).OrderBy(s => s.Code).AsParallel();
                                        if (q2.Count() > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q2;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    break;
                                }
                            case 2002:
                                {
                                    goto case 2001;
                                }
                            case 2003:
                                {
                                    goto case 2001;
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
                                    if (Fm.ListTasviyeNashode)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 6).OrderBy(s => s.Code).AsParallel();
                                        if (q1.Count() > 0)
                                            allHesabTafzilisBindingSource1.DataSource = En == EnumCED.Create ? q1.Where(f => f.IsActive == true).OrderBy(s => s.Code).AsParallel() : q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 6).OrderBy(s => s.Code).AsParallel();
                                        if (q2.Count() > 0)
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
                                    if (Fm.ListTasviyeNashode)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 4).OrderBy(s => s.Code).AsParallel();
                                        if (q1.Count() > 0)
                                            allHesabTafzilisBindingSource1.DataSource = En == EnumCED.Create ? q1.Where(f => f.IsActive == true).OrderBy(s => s.Code).AsParallel() : q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 4).OrderBy(s => s.Code).AsParallel();
                                        if (q2.Count() > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q2;
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
                                    if (Fm.ListTasviyeNashode)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 5).OrderBy(s => s.Code).AsParallel();
                                        if (q1.Count() > 0)
                                            allHesabTafzilisBindingSource1.DataSource = En == EnumCED.Create ? q1.Where(f => f.IsActive == true).OrderBy(s => s.Code).AsParallel() : q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 5).OrderBy(s => s.Code).AsParallel();
                                        if (q2.Count() > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q2;
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
        public void FillchkcmbEntekhabZamenin()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _DaryaftKonandeId = Convert.ToInt32(cmbDaryaftkonande.EditValue);
                    if (Fm.ListTasviyeNashode)
                    {
                        var q1 = db.AllHesabTafzilis.Where(s => s.GroupTafziliId == 3 && s.Id != _DaryaftKonandeId).OrderBy(s => s.Code).AsParallel();
                        if (q1.Count() > 0)
                            allHesabTafzilisBindingSource2.DataSource = En == EnumCED.Create ? q1.Where(s => s.IsActive == true).OrderBy(s => s.Code).AsParallel() : q1;
                        else
                            allHesabTafzilisBindingSource2.DataSource = null;
                    }
                    else
                    {
                        var q1 = db.AllHesabTafzilis.Where(s => s.GroupTafziliId == 3 && s.Id != _DaryaftKonandeId).OrderBy(s => s.Code).AsParallel();
                        if (q1.Count() > 0)
                            allHesabTafzilisBindingSource2.DataSource = q1;
                        else
                            allHesabTafzilisBindingSource2.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillDataGridCheckTazmin()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (Convert.ToInt32(cmbDaryaftkonande.EditValue) > 0)
                    {
                        int AazaId = Convert.ToInt32(cmbDaryaftkonande.EditValue);
                        int _SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                        var f0 = db.R_VamPardakhti_B_CheckTazmins.Where(s => s.SalMaliId == _SalMaliId && s.CheckTazmin1.VamGerandeId == AazaId && s.VamPardakhtin1.IsTasviye == false).AsParallel();
                        var f1 = f0.ToList();
                        var q0 = db.CheckTazmins.Where(s => s.IsInSandogh == true && s.SalMaliId == _SalMaliId && s.VamGerandeId == AazaId).OrderBy(s => s.SeryalDaryaft).AsParallel();
                        var q1 = q0.ToList();
                        if (q1.Count > 0)
                        {
                            if (En == EnumCED.Create)
                            {
                                if (f1.Count > 0)
                                {
                                    foreach (var item in f1)
                                    {
                                        q1.Remove(q1.FirstOrDefault(s => s.Id == item.CheckTazminId));
                                    }
                                }
                                checkTazminsBindingSource.DataSource = q1;
                            }
                            else
                            {
                                int _VamId = Convert.ToInt32(txtId.Text);
                                var f2 = f1.Where(s => s.VamPardakhtiId != _VamId).ToList();
                                if (f2.Count > 0)
                                {
                                    foreach (var item in f2)
                                    {
                                        q1.Remove(q1.FirstOrDefault(s => s.Id == item.CheckTazminId));
                                    }
                                }

                                checkTazminsBindingSource.DataSource = q1;
                            }
                        }
                        else
                            checkTazminsBindingSource.DataSource = null;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void NewCode()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.VamPardakhtis.Select(s => s).AsParallel();
                    if (q.Any())
                    {
                        var MaximumCode = q.Max(p => p.Code);
                        if (MaximumCode.ToString() != "9999999")
                        {
                            txtCode.Text = (MaximumCode + 1).ToString();
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                                XtraMessageBox.Show("اعمال محدودیت 9999999 کد وام  ..." + "\n" +
                                    "توجه : نمیتوان بیشتر از این تعداد، وام پرداختی ثبت نمود ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        txtCode.Text = "1";
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        List<CheckTazmin> BefourEditgridView = null;
        string _deviceID = string.Empty;
        string _dataBaseName = string.Empty;

        private void FrmVamPardakhti_Load(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 1;
            xtraTabControl2.SelectedTabPageIndex = 1;
            xtraTabControl1.SelectedTabPageIndex = 0;
            xtraTabControl2.SelectedTabPageIndex = 0;
            FillcmbDaryaftkonande();
            FillcmbHesabMoin();
            HelpClass1.DateTimeMask(txtTarikhDarkhast);
            HelpClass1.DateTimeMask(txtTarikhPardakht);
            HelpClass1.DateTimeMask(txtSarresidAvalinGhest);
            _IDSandogh = Convert.ToInt32(Fm.Fm.IDSandogh.Caption);
            _deviceID = HelpClass1.GetMadarBoardSerial();

            using (var db = new MyContext())
            {
                try
                {
                    _dataBaseName = db.Database.Connection.Database;

                    if (En == EnumCED.Create)
                    {
                        NewCode();
                        cmbNahveyePardakht.SelectedIndex = 0;
                        //cmbNoeVam.SelectedIndex = 0;
                        //_cmbNoeVamIndex = cmbNoeVam.SelectedIndex;
                        txtTarikhPardakht.Text = txtTarikhDarkhast.Text = DateTime.Now.ToString().Substring(0, 10);
                        cmbFaseleAghsat.SelectedIndex = 0;
                        chkIsTasviye.Visible = false;
                        var q2 = db.HesabBankis.FirstOrDefault(s => s.IsActive == true && s.IsDefault == true);
                        if (q2 != null)
                        {
                            var q3 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2 && f.Id2 == q2.Id);
                            if (q3 != null)
                            {
                                cmbHesabMoin.EditValue = 1;
                                cmbHesabTafzili.EditValue = q3.Id;
                            }
                        }
                        //var q1 = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _IDSandogh);
                        //if (q1 != null)
                        //{
                        //    var q11 = q1.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == _cmbNoeVamIndex);
                        //    txtDarsadeKarmozd.Text = q11.DarsadeKarmozd.ToString();
                        //    txtMablaghDirkard.Text = q11.MablaghDirkard.ToString();
                        //    checkEdit1.Checked = q1.radioGroup1 == 0 ? true : false;
                        //    checkEdit2.Checked = q1.radioGroup1 == 1 ? true : false;
                        //}

                        //cmbNoeVam.Focus();
                    }
                    else if (En == EnumCED.Edit)
                    {
                        cmbNoeVam.SelectedIndex = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("IndexNoeVam"));
                        _cmbNoeVamIndex = cmbNoeVam.SelectedIndex;
                        txtDarsadeKarmozd.Text = Fm.gridView1.GetFocusedRowCellDisplayText("DarsadeKarmozd");
                        txtMablaghDirkard.Text = Fm.gridView1.GetFocusedRowCellDisplayText("MablaghDirkard");
                        checkEdit1.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("checkEdit1"));
                        checkEdit2.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("checkEdit2"));
                        cmbNahveyePardakht.SelectedIndex = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("IndexNahveyePardakht"));

                        int _VamPardakhtiId = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("Id"));
                        var m1 = Convert.ToDecimal(Fm.gridView2.Columns["MablaghDaryafti"].SummaryItem.SummaryValue);
                        var m2 = Convert.ToDecimal(Fm.gridView1.GetFocusedRowCellValue("MablaghAsli"));
                        var m3 = Convert.ToDecimal(Fm.gridView1.GetFocusedRowCellValue("MablaghKarmozd"));
                        var q11 = db.VamPardakhtis.FirstOrDefault(s => s.Id == _VamPardakhtiId);
                        var m5 = q11.checkEdit1 ? m2 : m2 + m3;
                        if (m1 == m5)
                        {
                            chkIsTasviye.Enabled = true;
                        }


                        //cmbDaryaftkonande.ReadOnly = true;
                        EditRowIndex = Fm.gridView1.FocusedRowHandle;
                        txtId.Text = Fm.gridView1.GetFocusedRowCellDisplayText("Id");
                        cmbDaryaftkonande.EditValue = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("AazaId"));
                        if (!string.IsNullOrEmpty(Fm.gridView1.GetFocusedRowCellDisplayText("TarikhDarkhast")))
                        {
                            txtTarikhDarkhast.Text = Fm.gridView1.GetFocusedRowCellDisplayText("TarikhDarkhast").Substring(0, 10);

                        }
                        txtShomareDarkhast.Text = Fm.gridView1.GetFocusedRowCellDisplayText("ShomareDarkhast");
                        txtCode.Text = Fm.gridView1.GetFocusedRowCellDisplayText("Code");
                        if (!string.IsNullOrEmpty(Fm.gridView1.GetFocusedRowCellDisplayText("TarikhPardakht")))
                        {
                            txtTarikhPardakht.Text = Fm.gridView1.GetFocusedRowCellDisplayText("TarikhPardakht").Substring(0, 10);

                        }
                        txtMablaghAsli.Text = Fm.gridView1.GetFocusedRowCellDisplayText("MablaghAsli");
                        txtMablaghKarmozd.Text = Fm.gridView1.GetFocusedRowCellDisplayText("MablaghKarmozd");
                        cmbFaseleAghsat.SelectedIndex = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("IndexFaseleAghsat"));
                        txtTedadAghsat.Text = Fm.gridView1.GetFocusedRowCellDisplayText("TedadAghsat");
                        txtMablaghAghsat.Text = Fm.gridView1.GetFocusedRowCellDisplayText("MablaghAghsat");
                        if (!string.IsNullOrEmpty(Fm.gridView1.GetFocusedRowCellDisplayText("SarresidAvalinGhest")))
                        {
                            txtSarresidAvalinGhest.Text = Fm.gridView1.GetFocusedRowCellDisplayText("SarresidAvalinGhest").Substring(0, 10);

                        }
                        cmbHesabMoin.EditValue = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("HesabMoinId"));
                        cmbHesabTafzili.EditValue = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("HesabTafziliId"));
                        //lstZamenin1.Items.Add(Fm.gridView1.GetFocusedRowCellDisplayText("ZameninName"));
                        if (!string.IsNullOrEmpty(Fm.gridView1.GetFocusedRowCellDisplayText("ZameninId")))
                        {
                            chkcmbEntekhabZamenin.SetEditValue(Fm.gridView1.GetFocusedRowCellDisplayText("ZameninId"));

                        }
                        txtTozihat.Text = Fm.gridView1.GetFocusedRowCellDisplayText("Tozihat") != null ? Fm.gridView1.GetFocusedRowCellDisplayText("Tozihat") : null;
                        chkIsTasviye.Visible = true;
                        chkIsTasviye.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("IsTasviye"));

                        if (Convert.ToInt32(cmbDaryaftkonande.EditValue) > 0)
                        {
                            int AazaId = Convert.ToInt32(cmbDaryaftkonande.EditValue);
                            int _VamId = Convert.ToInt32(txtId.Text);
                            int _SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                            var f0 = db.R_VamPardakhti_B_CheckTazmins.Where(s => s.SalMaliId == _SalMaliId && s.CheckTazmin1.VamGerandeId == AazaId && s.VamPardakhtin1.IsTasviye == false && s.VamPardakhtiId == _VamId).AsParallel();
                            var f1 = f0.ToList();
                            var q0 = db.CheckTazmins.Where(s => s.IsInSandogh == true && s.SalMaliId == _SalMaliId && s.VamGerandeId == AazaId).OrderBy(s => s.SeryalDaryaft).AsParallel();
                            var q1 = q0.ToList();
                            List<CheckTazmin> list2 = new List<CheckTazmin>();
                            if (q1.Count > 0)
                            {
                                if (f1.Count > 0)
                                {
                                    foreach (var item in f1)
                                    {
                                        list2.Add(q1.FirstOrDefault(s => s.Id == item.CheckTazminId));
                                    }

                                    checkTazminsBindingSource.DataSource = list2.ToList();
                                }
                                else
                                {
                                    checkTazminsBindingSource.DataSource = null;
                                }
                            }
                            else
                                checkTazminsBindingSource.DataSource = null;
                        }

                        BefourEditgridView = new List<CheckTazmin>();
                        //BefourEditgridView = gridView1.DataSource;
                        BefourEditgridView = ((IEnumerable)gridView1.DataSource).Cast<CheckTazmin>().ToList();

                    }

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

        private void FrmVamPardakhti_KeyDown(object sender, KeyEventArgs e)
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

        public bool Validation()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var k = db.AllowedDevises.FirstOrDefault(s => s.DeviceID == _deviceID && s.DataBaseName == _dataBaseName);
                    if (k != null)
                    {
                        //if (k.VersionType == "Orginal")
                        //{
                        //    return true;
                        //}
                        //else
                        //{
                        if (k.VersionType == "Demo")
                        {
                            //if (k.IsActive == true)
                            //{
                            //    return true;
                            //}
                            //else 
                            if (k.IsActive == false)
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

                        //}
                    }
                    else
                    {
                        return false;
                    }



                    if (string.IsNullOrEmpty(cmbDaryaftkonande.Text))
                    {
                        XtraMessageBox.Show("لطفا نام دریافت کننده وام را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (string.IsNullOrEmpty(cmbNahveyePardakht.Text))
                    {
                        XtraMessageBox.Show("لطفاً نحوه پرداخت وام را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (string.IsNullOrEmpty(cmbNoeVam.Text))
                    {
                        XtraMessageBox.Show("لطفاً نوع وام را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtShomareDarkhast.Text) || txtShomareDarkhast.Text == "0")
                    {
                        XtraMessageBox.Show("لطفاً شماره درخواست را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtCode.Text))
                    {
                        XtraMessageBox.Show("فیلد کد وام نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtTarikhPardakht.Text))
                    {
                        XtraMessageBox.Show("لطفا تاریخ پرداخت را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtMablaghAsli.Text) || Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) == 0)
                    {
                        XtraMessageBox.Show("لطفا مبلغ اصلی وام را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (string.IsNullOrEmpty(cmbFaseleAghsat.Text))
                    {
                        XtraMessageBox.Show("لطفا فاصله اقساط وام را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtTedadAghsat.Text) || Convert.ToInt32(txtTedadAghsat.Text.Replace(",", "")) == 0)
                    {
                        XtraMessageBox.Show("لطفا تعداد اقساط وام را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtMablaghAghsat.Text) || Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", "")) == 0)
                    {
                        XtraMessageBox.Show("مبلغ اقساط تعیین نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtSarresidAvalinGhest.Text))
                    {
                        XtraMessageBox.Show("لطفا سررسید اولین قسط وام را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (string.IsNullOrEmpty(cmbHesabTafzili.Text))
                    {
                        XtraMessageBox.Show("لطفا نام بانک یا صندوق را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        int _IDSandogh = Convert.ToInt32(Fm.Fm.IDSandogh.Caption);
                        var q = db.Tanzimats.FirstOrDefault(f => f.SandoghId == _IDSandogh);
                        if (q.checkEdit1)
                        {
                            if (chkcmbEntekhabZamenin.Text == string.Empty && checkTazminsBindingSource.Count == 0)
                            {
                                XtraMessageBox.Show("لطفاً سند ضمانت یا ضامنین وام را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                            else
                            {
                                if (q.checkEdit5)
                                {
                                    decimal SumEtebarZamenin = 0;
                                    decimal SumMablaghVam = 0;
                                    decimal MablaghAsli = !string.IsNullOrEmpty(txtMablaghAsli.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) : 0;
                                    decimal MablaghKarmozd = !string.IsNullOrEmpty(txtMablaghKarmozd.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", "")) : 0;
                                    SumMablaghVam = q.radioGroup1 == 0 ? MablaghAsli : MablaghAsli + MablaghKarmozd;

                                    if (chkcmbEntekhabZamenin.Text != string.Empty)
                                    {
                                        var CheckedList1 = chkcmbEntekhabZamenin.Properties.GetItems().GetCheckedValues();
                                        var q4 = db.AazaSandoghs.Where(s => s.IsActive == true).ToList();

                                        foreach (var item in CheckedList1)
                                        {
                                            decimal MandeSaghfeEtebarZamen = 0;

                                            if (En == EnumCED.Create)
                                                MandeSaghfeEtebarZamen = q4.FirstOrDefault(s => s.AllTafId == (int)item).SaghfeEtebar - q4.FirstOrDefault(s => s.AllTafId == (int)item).EtebarBlookeShode;
                                            else
                                            {
                                                int VamId = Convert.ToInt32(txtId.Text);
                                                MandeSaghfeEtebarZamen = q4.FirstOrDefault(s => s.AllTafId == (int)item).SaghfeEtebar - q4.FirstOrDefault(s => s.AllTafId == (int)item).EtebarBlookeShode;
                                                var w = db.R_VamPardakhti_B_Zamenins.FirstOrDefault(s => s.VamPardakhtiId == VamId && s.AllTafId == (int)item);
                                                if (w != null)
                                                {
                                                    MandeSaghfeEtebarZamen += w.EtebarBlookeShode;
                                                }

                                            }
                                            SumEtebarZamenin += MandeSaghfeEtebarZamen;
                                        }
                                    }

                                    if (gridView1.RowCount > 0)
                                    {
                                        decimal SumAsnadTazmini = Convert.ToDecimal(gridView1.Columns["Mablagh"].SummaryText.Replace(",", ""));
                                        SumEtebarZamenin += SumAsnadTazmini;
                                    }

                                    if (SumEtebarZamenin < SumMablaghVam)
                                    {
                                        XtraMessageBox.Show("جمع سقف اعتبار ضامن یا ضامنین و اسناد تضمینی جهت ضمانت وام جاری کافی نیست لطفاً اصلاح بفرمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return false;
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }
                                else if (q.checkEdit11)
                                {
                                    int CheckedList = chkcmbEntekhabZamenin.Properties.GetItems().GetCheckedValues().Count;
                                    decimal MablaghVam = Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", ""));
                                    int NoeVamIndex = cmbNoeVam.SelectedIndex;
                                    var tz = db.TedadZamenins.Where(s => s.AnvaeVam1.TanzimatId == q.Id && s.AnvaeVam1.NoeVamIndex == NoeVamIndex).OrderBy(s => s.Mablagh).ToList();
                                    if (tz.Count > 0)
                                    {
                                        int tedadZamen = 0;
                                        foreach (var item in tz)
                                        {
                                            if (MablaghVam <= item.Mablagh)
                                            {
                                                tedadZamen = item.TedadZamen;
                                                break;
                                            }
                                        }

                                        if (tedadZamen == 0)
                                        {
                                            XtraMessageBox.Show("مبلغ وام بیشتر از حد نصاب تعداد ضامنین است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return false;
                                        }
                                        else if (CheckedList < tedadZamen)
                                        {
                                            XtraMessageBox.Show("تعداد ضامنین باید حداقل " + tedadZamen.ToString() + " نفر باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return false;

                                        }
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("در قسمت تنظیمات نرم افزار تعداد ضامنین وام مشخص نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return false;

                                    }
                                    return true;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            return true;
                        }
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
            if (Validation())
            {
                int yyyy1 = Convert.ToInt32(txtTarikhPardakht.Text.Substring(0, 4));
                int MM1 = Convert.ToInt32(txtTarikhPardakht.Text.Substring(5, 2));
                int dd1 = Convert.ToInt32(txtTarikhPardakht.Text.Substring(8, 2));
                Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                int yyyy2 = Convert.ToInt32(txtSarresidAvalinGhest.Text.Substring(0, 4));
                int MM2 = Convert.ToInt32(txtSarresidAvalinGhest.Text.Substring(5, 2));
                int dd2 = Convert.ToInt32(txtSarresidAvalinGhest.Text.Substring(8, 2));
                Mydate d2 = new Mydate(yyyy2, MM2, dd2);
                if (d2 < d1 || d2 == d1)
                {
                    XtraMessageBox.Show("تاریخ سررسید اولین قسط بایستی بیشتر از تاریخ پرداخت وام باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSarresidAvalinGhest.Focus();
                    return;
                }

                int _Code = Convert.ToInt32(txtCode.Text);
                int _Tedad = Convert.ToInt32(txtTedadAghsat.Text);
                //int yyyy1 = Convert.ToInt32(txtTarikhPardakht.Text.Substring(0, 4));
                //int MM1 = Convert.ToInt32(txtTarikhPardakht.Text.Substring(5, 2));
                //int dd1 = Convert.ToInt32(txtTarikhPardakht.Text.Substring(8, 2));
                //Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                decimal _MablaghVam = 0;
                if (checkEdit1.Checked)
                {
                    _MablaghVam = Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", ""));
                }
                else if (checkEdit2.Checked)
                {
                    _MablaghVam = Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) + Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", ""));
                }
                decimal _Tafazol = _MablaghVam - (Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", "")) * (_Tedad - 1));
                if (_Tafazol <= 0 || Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", "")) > _MablaghVam)
                {
                    XtraMessageBox.Show("جمع مبالغ اقساط بیشتر از مبلغ وام است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var db = new MyContext())
                {
                    try
                    {
                        int _SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                        //_IDSandogh = Convert.ToInt32(Fm.Fm.IDSandogh.Caption);
                        //var b1 = db.AllHesabTafzilis.Where(s => s.SandoghId == _IDSandogh && s.GroupTafziliId == 3).ToList();
                        if (En == EnumCED.Create)
                        {
                            var q1 = db.AsnadeHesabdariRows.Any() ? db.AsnadeHesabdariRows.Max(f => f.ShomareSanad) : 0;
                            VamPardakhti obj = new VamPardakhti();
                            obj.AazaId = Convert.ToInt32(cmbDaryaftkonande.EditValue);
                            obj.NameAaza = cmbDaryaftkonande.Text;
                            obj.IndexNahveyePardakht = cmbNahveyePardakht.SelectedIndex;
                            obj.NahveyePardakht = cmbNahveyePardakht.Text;
                            obj.IndexNoeVam = cmbNoeVam.SelectedIndex;
                            obj.NoeVam = cmbNoeVam.Text;
                            obj.DarsadeKarmozd = !string.IsNullOrEmpty(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) ? Convert.ToSingle(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) : 0;
                            obj.MablaghDirkard = !string.IsNullOrEmpty(txtMablaghDirkard.Text.Replace(",", "")) ? Convert.ToInt32(txtMablaghDirkard.Text.Replace(",", "")) : 0;
                            obj.checkEdit1 = checkEdit1.Checked ? true : false;
                            obj.checkEdit2 = checkEdit2.Checked ? true : false;
                            if (!string.IsNullOrEmpty(txtTarikhDarkhast.Text))
                                obj.TarikhDarkhast = Convert.ToDateTime(txtTarikhDarkhast.Text.Substring(0, 10));
                            obj.ShomareDarkhast = Convert.ToInt32(txtShomareDarkhast.Text);
                            obj.Code = Convert.ToInt32(txtCode.Text);
                            if (!string.IsNullOrEmpty(txtTarikhPardakht.Text))
                                obj.TarikhPardakht = Convert.ToDateTime(txtTarikhPardakht.Text.Substring(0, 10));
                            obj.MablaghAsli = !string.IsNullOrEmpty(txtMablaghAsli.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) : 0;
                            obj.MablaghKarmozd = !string.IsNullOrEmpty(txtMablaghKarmozd.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", "")) : 0;
                            obj.IndexFaseleAghsat = cmbFaseleAghsat.SelectedIndex;
                            obj.FaseleAghsat = cmbFaseleAghsat.Text;
                            obj.TedadAghsat = Convert.ToInt32(txtTedadAghsat.Text);
                            obj.MablaghAghsat = !string.IsNullOrEmpty(txtMablaghAghsat.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", "")) : 0;
                            if (!string.IsNullOrEmpty(txtSarresidAvalinGhest.Text))
                                obj.SarresidAvalinGhest = Convert.ToDateTime(txtSarresidAvalinGhest.Text.Substring(0, 10));
                            obj.HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                            obj.HesabMoinName = cmbHesabMoin.Text;
                            obj.HesabTafziliId = Convert.ToInt32(cmbHesabTafzili.EditValue);
                            obj.HesabTafziliName = cmbHesabTafzili.Text;
                            //List<int> ListZameninId = new List<int>();
                            if (!string.IsNullOrEmpty(chkcmbEntekhabZamenin.Text))
                            {
                                obj.ZameninName = chkcmbEntekhabZamenin.Text;

                                string CheckedItems = ",";
                                //string CheckedCodes = string.Empty;
                                var CheckedList = chkcmbEntekhabZamenin.Properties.GetItems().GetCheckedValues();
                                if (CheckedList != null)
                                {
                                    foreach (var item in CheckedList)
                                    {
                                        CheckedItems += item.ToString() + ",";
                                    }
                                }
                                obj.ZameninId = CheckedItems;
                                //obj.ZameninCode = b1.FirstOrDefault(s=>s.Id==;
                            }
                            else
                            {
                                obj.ZameninName = null;
                                obj.ZameninId = null;
                            }
                            obj.HaveCheckTazmin = checkTazminsBindingSource.DataSource != null ? true : false;
                            obj.IsTasviye = chkIsTasviye.Checked ? true : false;
                            obj.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                            obj.ShomareSanad = q1 + 1;
                            obj.Tozihat = txtTozihat.Text;

                            List<R_VamPardakhti_B_CheckTazmin> list2 = new List<R_VamPardakhti_B_CheckTazmin>();
                            if (gridView1.RowCount > 0)
                            {
                                for (int i = 0; i < gridView1.RowCount; i++)
                                {
                                    list2.Add(new R_VamPardakhti_B_CheckTazmin() { CheckTazminId = Convert.ToInt32(gridView1.GetRowCellValue(i, "Id")), MablageCheck = Convert.ToDecimal(gridView1.GetRowCellValue(i, "Mablagh")), SalMaliId = _SalMaliId });
                                }
                                obj.R_VamPardakhti_B_CheckTazmins = list2;
                            }

                            decimal SumAsnadTazmini = gridView1.RowCount > 0 ? Convert.ToDecimal(gridView1.Columns["Mablagh"].SummaryText.Replace(",", "")) : 0;
                            List<R_VamPardakhti_B_Zamenin> List1 = new List<R_VamPardakhti_B_Zamenin>();
                            var p2 = db.Tanzimats.FirstOrDefault(f => f.SandoghId == _IDSandogh);
                            if (p2 != null)
                            {
                                if (chkcmbEntekhabZamenin.Text != string.Empty)
                                {
                                    var CheckedList1 = chkcmbEntekhabZamenin.Properties.GetItems().GetCheckedValues();
                                    decimal MablaghAsli = !string.IsNullOrEmpty(txtMablaghAsli.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) : 0;
                                    decimal MablaghKarmozd = !string.IsNullOrEmpty(txtMablaghKarmozd.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", "")) : 0;
                                    decimal SumMablaghVam = MablaghAsli + MablaghKarmozd;
                                    var q4 = db.AazaSandoghs.ToList();

                                    decimal EtebarZamenGhabli = SumAsnadTazmini;
                                    decimal MandeEtebar = 0;
                                    foreach (var item in CheckedList1)
                                    {
                                        if (EtebarZamenGhabli < SumMablaghVam)
                                        {
                                            MandeEtebar = q4.FirstOrDefault(s => s.AllTafId == (int)item).SaghfeEtebar - q4.FirstOrDefault(s => s.AllTafId == (int)item).EtebarBlookeShode;
                                            var q5 = q4.FirstOrDefault(s => s.AllTafId == (int)item);
                                            if (q5 != null)
                                            {
                                                if (MandeEtebar == SumMablaghVam - EtebarZamenGhabli)
                                                {
                                                    q5.EtebarBlookeShode = q5.EtebarBlookeShode + (SumMablaghVam - EtebarZamenGhabli);
                                                    List1.Add(new R_VamPardakhti_B_Zamenin() { AllTafId = (int)item, EtebarBlookeShode = MandeEtebar, SalMaliId = _SalMaliId });

                                                }
                                                else if (MandeEtebar > SumMablaghVam - EtebarZamenGhabli)
                                                {
                                                    q5.EtebarBlookeShode = q5.EtebarBlookeShode + (SumMablaghVam - EtebarZamenGhabli);
                                                    List1.Add(new R_VamPardakhti_B_Zamenin() { AllTafId = (int)item, EtebarBlookeShode = SumMablaghVam - EtebarZamenGhabli, SalMaliId = _SalMaliId });

                                                }
                                                else if (MandeEtebar < SumMablaghVam - EtebarZamenGhabli)
                                                {
                                                    q5.EtebarBlookeShode = q5.EtebarBlookeShode + MandeEtebar;
                                                    List1.Add(new R_VamPardakhti_B_Zamenin() { AllTafId = (int)item, EtebarBlookeShode = MandeEtebar, SalMaliId = _SalMaliId });

                                                }

                                            }
                                            EtebarZamenGhabli += MandeEtebar;

                                        }
                                        else
                                        {
                                            List1.Add(new R_VamPardakhti_B_Zamenin() { AllTafId = (int)item, EtebarBlookeShode = 0, SalMaliId = _SalMaliId });
                                        }
                                    }
                                }
                                obj.R_VamPardakhti_B_Zamenins = List1;
                            }


                            db.VamPardakhtis.Add(obj);
                            db.SaveChanges();
                            //////////////////////////////////////////////////////////////////////////////////////
                            int _HesabAazaId2 = Convert.ToInt32(cmbDaryaftkonande.EditValue);
                            var _q2 = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabAazaId2);

                            var _q1 = db.CodeMoins.FirstOrDefault(f => f.Code == _CodeMoin);
                            AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
                            obj2.ShomareSanad = q1 + 1;
                            obj2.Tarikh = Convert.ToDateTime(txtTarikhPardakht.Text.Substring(0, 10));
                            obj2.HesabMoinId = _q1.Id;
                            obj2.HesabMoinCode = _q1.Code;
                            obj2.HesabMoinName = _q1.Name;
                            obj2.HesabTafId = _HesabAazaId2;
                            obj2.HesabTafCode = _q2.Code;
                            obj2.HesabTafName = cmbDaryaftkonande.Text;
                            obj2.Bed = _MablaghVam;
                            obj2.Sharh = "بابت پرداخت وام شماره " + txtCode.Text + " به " + cmbDaryaftkonande.Text;
                            obj2.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                            db.AsnadeHesabdariRows.Add(obj2);
                            db.SaveChanges();

                            int _HesabMoinId1 = Convert.ToInt32(cmbHesabMoin.EditValue);
                            var _q3 = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId1);
                            int _HesabTafId1 = Convert.ToInt32(cmbHesabTafzili.EditValue);
                            var _q4 = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabTafId1);
                            AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
                            obj1.ShomareSanad = q1 + 1;
                            obj1.Tarikh = Convert.ToDateTime(txtTarikhPardakht.Text.Substring(0, 10));
                            obj1.HesabMoinId = _HesabMoinId1;
                            obj1.HesabMoinCode = _q3.Code;
                            obj1.HesabMoinName = cmbHesabMoin.Text;
                            obj1.HesabTafId = _HesabTafId1;
                            obj1.HesabTafCode = _q4.Code;
                            obj1.HesabTafName = cmbHesabTafzili.Text;
                            obj1.Bes = _MablaghVam - Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", ""));
                            obj1.Sharh = _q3.Code == 1001 ? "بابت پرداخت وام شماره " + txtCode.Text + " به " + cmbDaryaftkonande.Text :
                                "بابت اختصاص وام شماره " + txtCode.Text + " به " + cmbDaryaftkonande.Text;
                            obj1.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                            db.AsnadeHesabdariRows.Add(obj1);
                            //if (_q3.Code == 6001)
                            //    XtraMessageBox.Show("مبلغ وام به حساب وام پرداختنی منظور شد تا بعداً به وام گیرنده پرداخت شود", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            db.SaveChanges();


                            if (Convert.ToInt32(txtMablaghKarmozd.Text.Replace(",", "")) != 0)
                            {
                                var _q5 = db.CodeMoins.FirstOrDefault(f => f.Code == 8001);
                                var _q6 = db.AllHesabTafzilis.FirstOrDefault(f => f.Code == 1000001);
                                AsnadeHesabdariRow obj3 = new AsnadeHesabdariRow();
                                obj3.ShomareSanad = q1 + 1;
                                obj3.Tarikh = Convert.ToDateTime(txtTarikhPardakht.Text.Substring(0, 10));
                                obj3.HesabMoinId = _q5.Id;
                                obj3.HesabMoinCode = 8001;
                                obj3.HesabMoinName = _q5.Name;
                                obj3.HesabTafId = _q6.Id;
                                obj3.HesabTafCode = 1000001;
                                obj3.HesabTafName = _q6.Name;
                                obj3.Bes = Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", ""));
                                obj3.Sharh = "بابت کارمزد وام شماره " + txtCode.Text + " " + cmbDaryaftkonande.Text;
                                obj3.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                db.AsnadeHesabdariRows.Add(obj3);
                            }
                            db.SaveChanges();

                            Fm.btnDisplyActiveList1_Click(null, null);

                            /////////////////////////////////////////////////////////////////////////////////////////////////////////
                            if (XtraMessageBox.Show("آیا قسط بندی وام انجام شود؟", "پیغام ثبت ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                var q2 = db.VamPardakhtis.FirstOrDefault(s => s.Code == _Code);
                                Fm._VamPardakhtiId = q2.Id;
                                List<RizeAghsatVam> list3 = new List<RizeAghsatVam>();
                                if (cmbFaseleAghsat.SelectedIndex == 0)
                                {
                                    for (int i = 1; i <= _Tedad; i++)
                                    {
                                        RizeAghsatVam ct = new RizeAghsatVam();
                                        ct.ShomareGhest = i;
                                        ct.AazaId = _HesabAazaId2;
                                        ct.NameAaza = cmbDaryaftkonande.Text;
                                        ct.VamPardakhtiId = q2.Id;
                                        ct.VamPardakhtiCode = _Code;
                                        if (i != 1)
                                            d2.IncrementMonth();
                                        ct.TarikhSarresid = Convert.ToDateTime(d2.ToString());
                                        ct.MablaghAghsat = i != _Tedad ? Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", "")) : _Tafazol;
                                        ct.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                        list3.Add(ct);
                                        //db.RizeAghsatVams.Add(ct);
                                    }

                                    list3.FirstOrDefault(s => s.ShomareGhest == 1).MablaghAghsat = list3.FirstOrDefault(s => s.ShomareGhest == _Tedad).MablaghAghsat;
                                    list3.FirstOrDefault(s => s.ShomareGhest == _Tedad).MablaghAghsat = Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", ""));
                                }
                                else if (cmbFaseleAghsat.SelectedIndex == 1)
                                {
                                    for (int i = 1; i <= _Tedad; i++)
                                    {
                                        RizeAghsatVam ct = new RizeAghsatVam();
                                        ct.ShomareGhest = i;
                                        ct.AazaId = _HesabAazaId2;
                                        ct.NameAaza = cmbDaryaftkonande.Text;
                                        ct.VamPardakhtiId = q2.Id;
                                        ct.VamPardakhtiCode = _Code;
                                        if (i != 1)
                                            d2.IncrementYear();
                                        ct.TarikhSarresid = Convert.ToDateTime(d2.ToString());
                                        ct.MablaghAghsat = i != _Tedad ? Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", "")) : _Tafazol;
                                        ct.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                        list3.Add(ct);
                                        //db.RizeAghsatVams.Add(ct);
                                    }

                                    list3.FirstOrDefault(s => s.ShomareGhest == 1).MablaghAghsat = list3.FirstOrDefault(s => s.ShomareGhest == _Tedad).MablaghAghsat;
                                    list3.FirstOrDefault(s => s.ShomareGhest == _Tedad).MablaghAghsat = Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", ""));

                                }

                                db.RizeAghsatVams.AddRange(list3);
                                db.SaveChanges();
                            }
                            /////////////////////////////////////////////////////////////////////////////////////////////////////////
                            En = EnumCED.Save;
                            //if (Fm.ListTasviyeNashode)
                            //else
                            //    Fm.btnDisplyNotActiveList1_Click(null, null);
                            Fm.FillDataGridRizeAghsatVam();
                            Fm.gridView1.MoveLast();
                            XtraMessageBox.Show("اطلاعات با موفقیت ثبت شد", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.VamPardakhtis.FirstOrDefault(s => s.Id == RowId);
                            if (q != null)
                            {
                                if (Fm.ListTasviyeNashode == true && chkIsTasviye.Checked == false)
                                {
                                    q.AazaId = Convert.ToInt32(cmbDaryaftkonande.EditValue);
                                    q.NameAaza = cmbDaryaftkonande.Text;
                                    q.IndexNahveyePardakht = cmbNahveyePardakht.SelectedIndex;
                                    q.NahveyePardakht = cmbNahveyePardakht.Text;
                                    q.IndexNoeVam = cmbNoeVam.SelectedIndex;
                                    q.NoeVam = cmbNoeVam.Text;
                                    q.DarsadeKarmozd = !string.IsNullOrEmpty(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) ? Convert.ToSingle(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) : 0;
                                    q.MablaghDirkard = !string.IsNullOrEmpty(txtMablaghDirkard.Text.Replace(",", "")) ? Convert.ToInt32(txtMablaghDirkard.Text.Replace(",", "")) : 0;
                                    q.checkEdit1 = checkEdit1.Checked ? true : false;
                                    q.checkEdit2 = checkEdit2.Checked ? true : false;
                                    if (!string.IsNullOrEmpty(txtTarikhDarkhast.Text))
                                        q.TarikhDarkhast = Convert.ToDateTime(txtTarikhDarkhast.Text.Substring(0, 10));
                                    q.ShomareDarkhast = Convert.ToInt32(txtShomareDarkhast.Text);
                                    q.Code = Convert.ToInt32(txtCode.Text);
                                    if (!string.IsNullOrEmpty(txtTarikhPardakht.Text))
                                        q.TarikhPardakht = Convert.ToDateTime(txtTarikhPardakht.Text.Substring(0, 10));
                                    q.MablaghAsli = !string.IsNullOrEmpty(txtMablaghAsli.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) : 0;
                                    q.MablaghKarmozd = !string.IsNullOrEmpty(txtMablaghKarmozd.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", "")) : 0;
                                    q.IndexFaseleAghsat = cmbFaseleAghsat.SelectedIndex;
                                    q.FaseleAghsat = cmbFaseleAghsat.Text;
                                    q.TedadAghsat = Convert.ToInt32(txtTedadAghsat.Text);
                                    q.MablaghAghsat = !string.IsNullOrEmpty(txtMablaghAghsat.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", "")) : 0;
                                    if (!string.IsNullOrEmpty(txtSarresidAvalinGhest.Text))
                                        q.SarresidAvalinGhest = Convert.ToDateTime(txtSarresidAvalinGhest.Text.Substring(0, 10));
                                    q.HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                                    q.HesabMoinName = cmbHesabMoin.Text;
                                    q.HesabTafziliId = Convert.ToInt32(cmbHesabTafzili.EditValue);
                                    q.HesabTafziliName = cmbHesabTafzili.Text;
                                    if (!string.IsNullOrEmpty(chkcmbEntekhabZamenin.Text))
                                    {
                                        q.ZameninName = chkcmbEntekhabZamenin.Text;

                                        string CheckedItems = ",";
                                        var CheckedList = chkcmbEntekhabZamenin.Properties.GetItems().GetCheckedValues();
                                        if (CheckedList != null)
                                        {
                                            foreach (var item in CheckedList)
                                            {
                                                CheckedItems += item.ToString() + ",";
                                            }
                                        }
                                        q.ZameninId = CheckedItems;
                                    }
                                    else
                                    {
                                        q.ZameninName = null;
                                        q.ZameninId = null;
                                    }
                                    q.HaveCheckTazmin = checkTazminsBindingSource.DataSource != null ? true : false;
                                    q.IsTasviye = chkIsTasviye.Checked ? true : false;
                                    q.Tozihat = txtTozihat.Text;

                                    /////////////////////////////////////////////////////////////////////////////////////////////////////////

                                    List<CheckTazmin> _gridView1 = new List<CheckTazmin>();
                                    //BefourEditgridView = gridView1.DataSource;
                                    _gridView1 = ((IEnumerable)gridView1.DataSource).Cast<CheckTazmin>().ToList();

                                    //var _gridView1 = gridView1.DataSource;
                                    if (_gridView1 != BefourEditgridView)
                                    {
                                        var w = db.R_VamPardakhti_B_CheckTazmins.Where(s => s.VamPardakhtiId == RowId).ToList();
                                        if (w.Count > 0)
                                        {
                                            db.R_VamPardakhti_B_CheckTazmins.RemoveRange(w);
                                        }

                                        List<R_VamPardakhti_B_CheckTazmin> list2 = new List<R_VamPardakhti_B_CheckTazmin>();
                                        if (gridView1.RowCount > 0)
                                        {
                                            for (int i = 0; i < gridView1.RowCount; i++)
                                            {
                                                list2.Add(new R_VamPardakhti_B_CheckTazmin() { CheckTazminId = Convert.ToInt32(gridView1.GetRowCellValue(i, "Id")), MablageCheck = Convert.ToDecimal(gridView1.GetRowCellValue(i, "Mablagh")), SalMaliId = _SalMaliId });
                                            }
                                            q.R_VamPardakhti_B_CheckTazmins = list2;
                                        }
                                    }

                                    ///////////////////////////////////////////////////////////////////////////////////////////
                                    //if (CheckedList_0 != CheckedList_1)
                                    {
                                        var q4 = db.AazaSandoghs.ToList();

                                        var w = db.R_VamPardakhti_B_Zamenins.Where(s => s.VamPardakhtiId == RowId).ToList();
                                        if (w.Count > 0)
                                        {
                                            foreach (var item in w)
                                                q4.FirstOrDefault(s => s.AllTafId == item.AllTafId).EtebarBlookeShode = q4.FirstOrDefault(s => s.AllTafId == item.AllTafId).EtebarBlookeShode - item.EtebarBlookeShode;

                                            db.R_VamPardakhti_B_Zamenins.RemoveRange(w);
                                        }


                                        decimal SumAsnadTazmini = gridView1.RowCount > 0 ? Convert.ToDecimal(gridView1.Columns["Mablagh"].SummaryText.Replace(",", "")) : 0;
                                        List<R_VamPardakhti_B_Zamenin> List1 = new List<R_VamPardakhti_B_Zamenin>();
                                        var p2 = db.Tanzimats.FirstOrDefault(f => f.SandoghId == _IDSandogh);
                                        if (p2 != null)
                                        {
                                            if (chkcmbEntekhabZamenin.Text != string.Empty)
                                            {
                                                var CheckedList1 = chkcmbEntekhabZamenin.Properties.GetItems().GetCheckedValues();
                                                decimal MablaghAsli = !string.IsNullOrEmpty(txtMablaghAsli.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) : 0;
                                                decimal MablaghKarmozd = !string.IsNullOrEmpty(txtMablaghKarmozd.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", "")) : 0;
                                                decimal SumMablaghVam = MablaghAsli + MablaghKarmozd;

                                                decimal EtebarZamenGhabli = SumAsnadTazmini;
                                                decimal MandeEtebar = 0;
                                                foreach (var item in CheckedList1)
                                                {
                                                    if (EtebarZamenGhabli < SumMablaghVam)
                                                    {
                                                        MandeEtebar = q4.FirstOrDefault(s => s.AllTafId == (int)item).SaghfeEtebar - q4.FirstOrDefault(s => s.AllTafId == (int)item).EtebarBlookeShode;
                                                        var q5 = q4.FirstOrDefault(s => s.AllTafId == (int)item);
                                                        if (q5 != null)
                                                        {
                                                            if (MandeEtebar == SumMablaghVam - EtebarZamenGhabli)
                                                            {
                                                                q5.EtebarBlookeShode = q5.EtebarBlookeShode + (SumMablaghVam - EtebarZamenGhabli);
                                                                List1.Add(new R_VamPardakhti_B_Zamenin() { AllTafId = (int)item, EtebarBlookeShode = MandeEtebar, SalMaliId = _SalMaliId });

                                                            }
                                                            else if (MandeEtebar > SumMablaghVam - EtebarZamenGhabli)
                                                            {
                                                                q5.EtebarBlookeShode = q5.EtebarBlookeShode + (SumMablaghVam - EtebarZamenGhabli);
                                                                List1.Add(new R_VamPardakhti_B_Zamenin() { AllTafId = (int)item, EtebarBlookeShode = SumMablaghVam - EtebarZamenGhabli, SalMaliId = _SalMaliId });

                                                            }
                                                            else if (MandeEtebar < SumMablaghVam - EtebarZamenGhabli)
                                                            {
                                                                q5.EtebarBlookeShode = q5.EtebarBlookeShode + MandeEtebar;
                                                                List1.Add(new R_VamPardakhti_B_Zamenin() { AllTafId = (int)item, EtebarBlookeShode = MandeEtebar, SalMaliId = _SalMaliId });

                                                            }

                                                        }
                                                        EtebarZamenGhabli += MandeEtebar;

                                                    }
                                                    else
                                                    {
                                                        List1.Add(new R_VamPardakhti_B_Zamenin() { AllTafId = (int)item, EtebarBlookeShode = 0, SalMaliId = _SalMaliId });
                                                    }
                                                    #region MyRegion
                                                    //List<VamPardakhti> q6 = new List<VamPardakhti>();
                                                    //if (En == EnumCED.Create)
                                                    //{
                                                    //    //q6 = db.VamPardakhtis.Where(s => s.IsTasviye == false && s.ZameninName.Contains(NameZamen)).ToList();
                                                    //    q6 = db.VamPardakhtis.Where(s => s.IsTasviye == false && s.ZameninId.Contains("," + (int)item + ",")).ToList();
                                                    //}
                                                    //else if (En == EnumCED.Edit)
                                                    //{
                                                    //    int _VamId = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("Id"));
                                                    //    //q6 = db.VamPardakhtis.Where(s => s.IsTasviye == false && s.Id != _VamId && s.ZameninName.Contains(ZamenId)).ToList();
                                                    //    q6 = db.VamPardakhtis.Where(s => s.IsTasviye == false && s.Id < _VamId && s.ZameninId.Contains("," + (int)item + ",")).ToList();
                                                    //}

                                                    #endregion
                                                }
                                            }
                                            q.R_VamPardakhti_B_Zamenins = List1;
                                        }
                                    }

                                    ////////////////////////////////////////////////////////////////////////////////////////////
                                    if (IsEditRizAghsat)
                                    {
                                        var q2 = db.AsnadeHesabdariRows.Where(f => f.ShomareSanad == q.ShomareSanad);
                                        if (q2.Count() > 0)
                                            db.AsnadeHesabdariRows.RemoveRange(q2);

                                        //////////////////////////////////////////////////////////////////////////////////////
                                        int _HesabAazaId2 = Convert.ToInt32(cmbDaryaftkonande.EditValue);
                                        var _q2 = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabAazaId2);
                                        var _q1 = db.CodeMoins.FirstOrDefault(f => f.Code == _CodeMoin);
                                        AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
                                        obj2.ShomareSanad = q.ShomareSanad;
                                        obj2.Tarikh = Convert.ToDateTime(txtTarikhPardakht.Text.Substring(0, 10));
                                        obj2.HesabMoinId = _q1.Id;
                                        obj2.HesabMoinCode = _q1.Code;
                                        obj2.HesabMoinName = _q1.Name;
                                        obj2.HesabTafId = _HesabAazaId2;
                                        obj2.HesabTafCode = _q2.Code;
                                        obj2.HesabTafName = cmbDaryaftkonande.Text;
                                        obj2.Bed = _MablaghVam;
                                        obj2.Sharh = "بابت پرداخت وام شماره " + txtCode.Text + " به " + cmbDaryaftkonande.Text;
                                        obj2.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                        db.AsnadeHesabdariRows.Add(obj2);

                                        int _HesabMoinId1 = Convert.ToInt32(cmbHesabMoin.EditValue);
                                        var _q3 = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId1);
                                        int _HesabTafId1 = Convert.ToInt32(cmbHesabTafzili.EditValue);
                                        var _q4 = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabTafId1);
                                        AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
                                        obj1.ShomareSanad = q.ShomareSanad;
                                        obj1.Tarikh = Convert.ToDateTime(txtTarikhPardakht.Text.Substring(0, 10));
                                        obj1.HesabMoinId = _HesabMoinId1;
                                        obj1.HesabMoinCode = _q3.Code;
                                        obj1.HesabMoinName = cmbHesabMoin.Text;
                                        obj1.HesabTafId = _HesabTafId1;
                                        obj1.HesabTafCode = _q4.Code;
                                        obj1.HesabTafName = cmbHesabTafzili.Text;
                                        obj1.Bes = _MablaghVam - Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", ""));
                                        obj1.Sharh = _q3.Code == 1001 ? "بابت پرداخت وام شماره " + txtCode.Text + " به " + cmbDaryaftkonande.Text :
                                            "بابت اختصاص وام شماره " + txtCode.Text + " به " + cmbDaryaftkonande.Text;
                                        obj1.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                        db.AsnadeHesabdariRows.Add(obj1);
                                        //if (_q3.Code == 6001)
                                        //    XtraMessageBox.Show("مبلغ وام به حساب وام پرداختنی منظور شد تا بعداً به وام گیرنده پرداخت شود", "پیغام ثبت ", MessageBoxButtons.OK);

                                        if (Convert.ToInt32(txtMablaghKarmozd.Text.Replace(",", "")) != 0)
                                        {
                                            var _q5 = db.CodeMoins.FirstOrDefault(f => f.Code == 8001);
                                            var _q6 = db.AllHesabTafzilis.FirstOrDefault(f => f.Code == 1000001);
                                            AsnadeHesabdariRow obj3 = new AsnadeHesabdariRow();
                                            obj3.ShomareSanad = q.ShomareSanad;
                                            obj3.Tarikh = Convert.ToDateTime(txtTarikhPardakht.Text.Substring(0, 10));
                                            obj3.HesabMoinId = _q5.Id;
                                            obj3.HesabMoinCode = 8001;
                                            obj3.HesabMoinName = _q5.Name;
                                            obj3.HesabTafId = _q6.Id;
                                            obj3.HesabTafCode = 1000001;
                                            obj3.HesabTafName = _q6.Name;
                                            obj3.Bes = Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", ""));
                                            obj3.Sharh = "بابت کارمزد وام شماره " + txtCode.Text + " " + cmbDaryaftkonande.Text;
                                            obj3.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                            db.AsnadeHesabdariRows.Add(obj3);
                                        }

                                    }
                                    db.SaveChanges();


                                    /////////////////////////////////////////////////////////////////////////////////////////////////////////
                                    if (IsEditRizAghsat == true)
                                    {
                                        if (XtraMessageBox.Show("آیا قسط بندی وام مجدداً انجام شود؟", "پیغام ثبت ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                        {

                                            var q3 = db.RizeAghsatVams.Where(s => s.VamPardakhtiId == RowId);
                                            if (q3.Count() > 0)
                                            {
                                                db.RizeAghsatVams.RemoveRange(q3);
                                            }
                                            /////////////////////////////////////////////////////////////////
                                            int _HesabAazaId2 = Convert.ToInt32(cmbDaryaftkonande.EditValue);
                                            var q4 = db.VamPardakhtis.FirstOrDefault(s => s.Code == _Code);
                                            Fm._VamPardakhtiId = q4.Id;
                                            List<RizeAghsatVam> list3 = new List<RizeAghsatVam>();
                                            if (cmbFaseleAghsat.SelectedIndex == 0)
                                            {
                                                for (int i = 1; i <= _Tedad; i++)
                                                {
                                                    RizeAghsatVam ct = new RizeAghsatVam();
                                                    ct.ShomareGhest = i;
                                                    ct.AazaId = _HesabAazaId2;
                                                    ct.NameAaza = cmbDaryaftkonande.Text;
                                                    ct.VamPardakhtiId = q4.Id;
                                                    ct.VamPardakhtiCode = _Code;
                                                    if (i != 1)
                                                        d2.IncrementMonth();
                                                    ct.TarikhSarresid = Convert.ToDateTime(d2.ToString());
                                                    ct.MablaghAghsat = i != _Tedad ? Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", "")) : _Tafazol;
                                                    ct.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                                    list3.Add(ct);
                                                    //db.RizeAghsatVams.Add(ct);
                                                }
                                                list3.FirstOrDefault(s => s.ShomareGhest == 1).MablaghAghsat = list3.FirstOrDefault(s => s.ShomareGhest == _Tedad).MablaghAghsat;
                                                list3.FirstOrDefault(s => s.ShomareGhest == _Tedad).MablaghAghsat = Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", ""));

                                            }
                                            else if (cmbFaseleAghsat.SelectedIndex == 1)
                                            {
                                                for (int i = 1; i <= _Tedad; i++)
                                                {
                                                    RizeAghsatVam ct = new RizeAghsatVam();
                                                    ct.ShomareGhest = i;
                                                    ct.AazaId = _HesabAazaId2;
                                                    ct.NameAaza = cmbDaryaftkonande.Text;
                                                    ct.VamPardakhtiId = q4.Id;
                                                    ct.VamPardakhtiCode = _Code;
                                                    if (i != 1)
                                                        d2.IncrementYear();
                                                    ct.TarikhSarresid = Convert.ToDateTime(d2.ToString());
                                                    ct.MablaghAghsat = i != _Tedad ? Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", "")) : _Tafazol;
                                                    ct.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                                    list3.Add(ct);
                                                    //db.RizeAghsatVams.Add(ct);
                                                }

                                                list3.FirstOrDefault(s => s.ShomareGhest == 1).MablaghAghsat = list3.FirstOrDefault(s => s.ShomareGhest == _Tedad).MablaghAghsat;
                                                list3.FirstOrDefault(s => s.ShomareGhest == _Tedad).MablaghAghsat = Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", ""));
                                            }

                                            db.RizeAghsatVams.AddRange(list3);
                                        }
                                    }

                                }
                                else if (Fm.ListTasviyeNashode == true && chkIsTasviye.Checked == true)
                                {
                                    q.IsTasviye = chkIsTasviye.Checked;
                                }
                                else if (Fm.ListTasviyeNashode == false)
                                {
                                    q.IsTasviye = chkIsTasviye.Checked;
                                }
                                
                                db.SaveChanges();
                                /////////////////////////////////////////////////////////////////////////////////////////////////////////

                                En = EnumCED.Save;
                                Fm._VamPardakhtiId = RowId;
                                if (Fm.ListTasviyeNashode)
                                    Fm.btnDisplyActiveList1_Click(null, null);
                                else
                                    Fm.btnDisplyNotActiveList1_Click(null, null);

                                Fm.FillDataGridRizeAghsatVam();
                                if (Fm.gridView1.RowCount > 0)
                                    Fm.gridView1.FocusedRowHandle = EditRowIndex;
                                XtraMessageBox.Show("اطلاعات با موفقیت ویرایش شد", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FrmVamPardakhti_FormClosing(object sender, FormClosingEventArgs e)
        {
            En = EnumCED.Cancel;
        }

        public string MohasebeKarmozd()
        {
            string Result = "";
            if (!string.IsNullOrEmpty(txtMablaghAsli.Text) && Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) != 0)
            {
                if (!string.IsNullOrEmpty(txtDarsadeKarmozd.Text) && Convert.ToDecimal(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) != 0)
                {
                    decimal d = Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) * (Convert.ToDecimal(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) / 100);
                    Result = Math.Truncate(d).ToString();
                }
                else
                    Result = "0";
            }
            else
                Result = "0";

            return Result;
        }
        public string MohasebeMablaghAgsat()
        {
            string Result = "";
            using (var db = new MyContext())
            {
                try
                {
                    if (checkEdit1.Checked)
                    {
                        if (!string.IsNullOrEmpty(txtMablaghAsli.Text) && Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) != 0)
                        {
                            if (!string.IsNullOrEmpty(txtTedadAghsat.Text) && Convert.ToInt32(txtTedadAghsat.Text) != 0)
                            {
                                decimal d = Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) / Convert.ToInt32(txtTedadAghsat.Text);
                                Result = Math.Truncate(d).ToString();
                            }
                            else
                                Result = "0";
                        }
                        else
                            Result = "0";
                    }
                    else if (checkEdit2.Checked)
                    {
                        if (!string.IsNullOrEmpty(txtMablaghAsli.Text) && Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) != 0)
                        {
                            if (!string.IsNullOrEmpty(txtTedadAghsat.Text) && Convert.ToInt32(txtTedadAghsat.Text) != 0)
                            {
                                decimal Sum = Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) + Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", ""));
                                decimal d = Sum / Convert.ToInt32(txtTedadAghsat.Text);
                                Result = Math.Truncate(d).ToString();
                            }
                            else
                                Result = "0";
                        }
                        else
                            Result = "0";
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Result;
        }
        private void txtMablaghAsli_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDarsadeKarmozd.Text) && txtDarsadeKarmozd.Text != "0")
                txtMablaghKarmozd.Text = MohasebeKarmozd();
            if (!string.IsNullOrEmpty(txtTedadAghsat.Text) && txtTedadAghsat.Text != "0")
                txtMablaghAghsat.Text = MohasebeMablaghAgsat();
        }

        private void txtDarsadeKarmozd_EditValueChanged(object sender, EventArgs e)
        {
            txtMablaghKarmozd.Text = MohasebeKarmozd();

        }

        private void txtTedadAghsat_EditValueChanged(object sender, EventArgs e)
        {
            txtMablaghAghsat.Text = MohasebeMablaghAgsat();
        }

        private void txtMablaghKarmozd_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTedadAghsat.Text) && txtTedadAghsat.Text != "0")
                txtMablaghAghsat.Text = MohasebeMablaghAgsat();

        }

        private void cmbFaseleAghsat_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTarikhPardakht.Text))
            {
                int yyyy1 = Convert.ToInt32(txtTarikhPardakht.Text.Substring(0, 4));
                int MM1 = Convert.ToInt32(txtTarikhPardakht.Text.Substring(5, 2));
                int dd1 = Convert.ToInt32(txtTarikhPardakht.Text.Substring(8, 2));
                Mydate d1 = null;
                if (cmbFaseleAghsat.SelectedIndex == 0)
                {
                    d1 = new Mydate(yyyy1, MM1, dd1);
                    d1.IncrementMonth();
                }
                else if (cmbFaseleAghsat.SelectedIndex == 1)
                {
                    d1 = new Mydate(yyyy1, MM1, dd1);
                    d1.IncrementYear();
                }
                txtSarresidAvalinGhest.Text = d1.ToString();
            }
        }

        string CheckedList_0 = string.Empty;
        string CheckedList_1 = string.Empty;
        public void chkcmbAazaSandoogh_EditValueChanged(object sender, EventArgs e)
        {
            //lstZamenin.Items.Clear();
            //lstZamenin.Items.Add(chkcmbEntekhabZamenin.Text);
            using (var db = new MyContext())
            {
                try
                {
                    int _IDSandogh = Convert.ToInt32(Fm.Fm.IDSandogh.Caption);
                    var CheckedListValue = chkcmbEntekhabZamenin.Properties.GetItems().GetCheckedValues();
                    CheckedList_1 = chkcmbEntekhabZamenin.Text;
                    var q2 = db.Tanzimats.FirstOrDefault(f => f.SandoghId == _IDSandogh);
                    if (q2 != null)
                    {

                        if (q2.checkEdit1 && q2.checkEdit5)
                        {
                            if (CheckedList_1 != string.Empty)
                            {
                                decimal MablaghAsli = !string.IsNullOrEmpty(txtMablaghAsli.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) : 0;
                                decimal MablaghKarmozd = !string.IsNullOrEmpty(txtMablaghKarmozd.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", "")) : 0;
                                decimal SumMablaghVam = MablaghAsli + MablaghKarmozd;
                                var q4 = db.AazaSandoghs.Where(s => s.GroupTafziliId == 3).ToList();
                                List<string> ListZamenin1 = new List<string>();
                                List<string> ListZamenin2 = new List<string>();
                                decimal MandeSaghfeEtebarZamen = 0;
                                lstZamenin1.Items.Clear();
                                lstZamenin2.Items.Clear();

                                if (En == EnumCED.Create)
                                {
                                    foreach (var item in CheckedListValue)
                                    {
                                        MandeSaghfeEtebarZamen = q4.FirstOrDefault(s => s.AllTafId == (int)item).SaghfeEtebar - q4.FirstOrDefault(s => s.AllTafId == (int)item).EtebarBlookeShode;

                                        #region MyRegion
                                        //List<VamPardakhti> q6 = new List<VamPardakhti>();
                                        //if (En == EnumCED.Create)
                                        //{
                                        //    //q6 = db.VamPardakhtis.Where(s => s.IsTasviye == false && s.ZameninName.Contains(NameZamen)).ToList();
                                        //    q6 = db.VamPardakhtis.Where(s => s.IsTasviye == false && s.ZameninId.Contains("," + (int)item + ",")).ToList();
                                        //}
                                        //else if (En == EnumCED.Edit)
                                        //{
                                        //    int _VamId = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("Id"));
                                        //    //q6 = db.VamPardakhtis.Where(s => s.IsTasviye == false && s.Id != _VamId && s.ZameninName.Contains(ZamenId)).ToList();
                                        //    q6 = db.VamPardakhtis.Where(s => s.IsTasviye == false && s.Id < _VamId && s.ZameninId.Contains("," + (int)item + ",")).ToList();
                                        //}

                                        #endregion
                                        if (MandeSaghfeEtebarZamen > 0)
                                            ListZamenin1.Add(q4.FirstOrDefault(s => s.AllTafId == (int)item).NameVFamil + " : " + "مانده اعتبار جهت ضمانت = " + MandeSaghfeEtebarZamen.ToString("n0") + "  ");
                                        else
                                            ListZamenin1.Add(q4.FirstOrDefault(s => s.AllTafId == (int)item).NameVFamil + " : " + "مانده اعتبار جهت ضمانت = " + "0" + "  ");
                                    }


                                    //////////////////////////////////////////////
                                    decimal SumAsnadTazmini = gridView1.RowCount > 0 ? Convert.ToDecimal(gridView1.Columns["Mablagh"].SummaryText.Replace(",", "")) : 0;
                                    //List<R_VamPardakhti_B_Zamenin> List1 = new List<R_VamPardakhti_B_Zamenin>();
                                    decimal EtebarZamenGhabli = SumAsnadTazmini;
                                    decimal MandeEtebar = 0;
                                    //lstZamenin2.Items.Clear();
                                    foreach (var item in CheckedListValue)
                                    {
                                        if (EtebarZamenGhabli < SumMablaghVam)
                                        {
                                            MandeEtebar = q4.FirstOrDefault(s => s.AllTafId == (int)item).SaghfeEtebar - q4.FirstOrDefault(s => s.AllTafId == (int)item).EtebarBlookeShode;
                                            var q5 = q4.FirstOrDefault(s => s.AllTafId == (int)item);
                                            if (q5 != null)
                                            {
                                                if (MandeEtebar == SumMablaghVam - EtebarZamenGhabli)
                                                {
                                                    //q5.EtebarBlookeShode = q5.EtebarBlookeShode + (SumMablaghVam - EtebarZamenGhabli);
                                                    //List1.Add(new R_VamPardakhti_B_Zamenin() { AllTafId = (int)item, EtebarBlookeShode = MandeEtebar, SalMaliId = _SalMaliId });
                                                    if (MandeSaghfeEtebarZamen > 0)
                                                        ListZamenin2.Add(q4.FirstOrDefault(s => s.AllTafId == (int)item).NameVFamil + " : " + "اعتباری که بلوکه خواهد شد = " + MandeEtebar.ToString("n0") + "  ");
                                                    else
                                                        ListZamenin2.Add(q4.FirstOrDefault(s => s.AllTafId == (int)item).NameVFamil + " : " + "اعتباری که بلوکه خواهد شد = " + "0" + "  ");

                                                }
                                                else if (MandeEtebar > SumMablaghVam - EtebarZamenGhabli)
                                                {
                                                    //q5.EtebarBlookeShode = q5.EtebarBlookeShode + (SumMablaghVam - EtebarZamenGhabli);
                                                    //List1.Add(new R_VamPardakhti_B_Zamenin() { AllTafId = (int)item, EtebarBlookeShode = SumMablaghVam - EtebarZamenGhabli, SalMaliId = _SalMaliId });
                                                    if (MandeSaghfeEtebarZamen > 0)
                                                        ListZamenin2.Add(q4.FirstOrDefault(s => s.AllTafId == (int)item).NameVFamil + " : " + "اعتباری که بلوکه خواهد شد = " + (SumMablaghVam - EtebarZamenGhabli).ToString("n0") + "  ");
                                                    else
                                                        ListZamenin2.Add(q4.FirstOrDefault(s => s.AllTafId == (int)item).NameVFamil + " : " + "اعتباری که بلوکه خواهد شد = " + "0" + "  ");

                                                }
                                                else if (MandeEtebar < SumMablaghVam - EtebarZamenGhabli)
                                                {
                                                    //q5.EtebarBlookeShode = q5.EtebarBlookeShode + MandeEtebar;
                                                    //List1.Add(new R_VamPardakhti_B_Zamenin() { AllTafId = (int)item, EtebarBlookeShode = MandeEtebar, SalMaliId = _SalMaliId });
                                                    if (MandeSaghfeEtebarZamen > 0)
                                                        ListZamenin2.Add(q4.FirstOrDefault(s => s.AllTafId == (int)item).NameVFamil + " : " + "اعتباری که بلوکه خواهد شد = " + MandeEtebar.ToString("n0") + "  ");
                                                    else
                                                        ListZamenin2.Add(q4.FirstOrDefault(s => s.AllTafId == (int)item).NameVFamil + " : " + "اعتباری که بلوکه خواهد شد = " + "0" + "  ");

                                                }

                                            }
                                            EtebarZamenGhabli += MandeEtebar;
                                        }
                                        else
                                        {
                                            ListZamenin2.Add(q4.FirstOrDefault(s => s.AllTafId == (int)item).NameVFamil + " : " + "اعتباری که بلوکه خواهد شد = " + "0" + "  ");

                                            //lstZamenin2.Items.Clear();

                                        }
                                    }

                                    /////////////////////////////////////////////////////////
                                }
                                else
                                {
                                    int _VamId = Convert.ToInt32(txtId.Text);
                                    var q = db.R_VamPardakhti_B_Zamenins.Where(s => s.VamPardakhtiId == _VamId).ToList();
                                    if (CheckedList_0 == CheckedList_1)
                                    {
                                        if (q.Count > 0)
                                        {
                                            foreach (var item1 in q)
                                            {
                                                ListZamenin2.Add(q4.FirstOrDefault(s => s.AllTafId == item1.AllTafId).NameVFamil + " : " + "اعتبار بلوکه شده جهت ضمانت = " + item1.EtebarBlookeShode.ToString("n0") + "  ");
                                            }
                                        }
                                        else
                                        {
                                            ListZamenin1.Clear();
                                            ListZamenin2.Clear();
                                        }

                                    }
                                    else
                                    {
                                        foreach (var item in CheckedListValue)
                                        {
                                            if (q != null)
                                            {
                                                MandeSaghfeEtebarZamen = q4.FirstOrDefault(s => s.AllTafId == (int)item).SaghfeEtebar - q4.FirstOrDefault(s => s.AllTafId == (int)item).EtebarBlookeShode;

                                                if (q.Any(s => s.VamPardakhtiId == _VamId && s.AllTafId == (int)item))
                                                {
                                                    ListZamenin1.Add(q4.FirstOrDefault(s => s.AllTafId == (int)item).NameVFamil + " : " + "مانده اعتبار جهت ضمانت = " + MandeSaghfeEtebarZamen.ToString("n0") + "  ");
                                                    ListZamenin2.Add(q4.FirstOrDefault(s => s.AllTafId == (int)item).NameVFamil + " : " + "اعتبار بلوکه شده جهت ضمانت = " + q.FirstOrDefault(s => s.VamPardakhtiId == _VamId && s.AllTafId == (int)item).EtebarBlookeShode.ToString("n0") + "  ");
                                                }
                                                else
                                                {
                                                    if (MandeSaghfeEtebarZamen > 0)
                                                        ListZamenin1.Add(q4.FirstOrDefault(s => s.AllTafId == (int)item).NameVFamil + " : " + "مانده اعتبار جهت ضمانت = " + MandeSaghfeEtebarZamen.ToString("n0") + "  ");
                                                    else
                                                        ListZamenin1.Add(q4.FirstOrDefault(s => s.AllTafId == (int)item).NameVFamil + " : " + "مانده اعتبار جهت ضمانت = " + "0" + "  ");

                                                }
                                            }
                                            else
                                            {
                                                lstZamenin1.Items.Clear();
                                                lstZamenin2.Items.Clear();
                                            }
                                        }

                                    }
                                }

                                //lstZamenin.Items.Clear();
                                foreach (var item in ListZamenin1)
                                {
                                    lstZamenin1.Items.Add(item);
                                }
                                foreach (var item in ListZamenin2)
                                {
                                    lstZamenin2.Items.Add(item);
                                }
                            }
                            else
                            {
                                lstZamenin1.Items.Clear();
                                lstZamenin2.Items.Clear();
                            }

                        }
                    }
                    else
                    {
                        lstZamenin1.Items.Clear();
                        lstZamenin2.Items.Clear();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void cmbDaryaftkonande_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkEdit1.Checked)
            //{
            //    checkEdit2.Checked = false;
            //    //checkEdit1.Visible = true;
            //}

            if (checkEdit1.Checked)
            {
                checkEdit1.Visible = true;
                checkEdit2.Visible = false;

                //checkEdit1.Checked = true;
                checkEdit2.Checked = false;
            }
            else
            {
                checkEdit2.Visible = true;
                checkEdit1.Visible = false;

                //checkEdit2.Checked = true;
                checkEdit1.Checked = false;
            }


            if (!string.IsNullOrEmpty(txtTedadAghsat.Text) && txtTedadAghsat.Text != "0")
                txtMablaghAghsat.Text = MohasebeMablaghAgsat();
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                checkEdit1.Visible = true;
                checkEdit2.Visible = false;

                //checkEdit1.Checked = true;
                checkEdit2.Checked = false;
            }
            else
            {
                checkEdit2.Visible = true;
                checkEdit1.Visible = false;

                //checkEdit2.Checked = true;
                checkEdit1.Checked = false;
            }

            if (!string.IsNullOrEmpty(txtTedadAghsat.Text) && txtTedadAghsat.Text != "0")
                txtMablaghAghsat.Text = MohasebeMablaghAgsat();

        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            btnCreate.Visible = btnDelete.Visible = btnNemayeshCheckhaiAtfNashode.Visible = xtraTabControl1.SelectedTabPageIndex == 1 ? true : false;
            btnTarifAaza.Visible = xtraTabControl1.SelectedTabPageIndex == 0 ? true : false;
        }

        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            FrmDaryaftCheckTazmin fm = new FrmDaryaftCheckTazmin(this);
            fm.ShowDialog();
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);

        }

        private void cmbDaryaftkonande_Enter(object sender, EventArgs e)
        {
            //if (En == EnumCED.Create)
            cmbDaryaftkonande.ShowPopup();
        }

        private void cmbHesabMoin_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbHesabTafzili();
        }

        private void cmbNahveyePardakht_Enter(object sender, EventArgs e)
        {
            cmbNahveyePardakht.ShowPopup();
        }

        private void cmbNoeVam_Enter(object sender, EventArgs e)
        {
            //if (En == EnumCED.Create)
            //    cmbNoeVam.ShowPopup();
        }

        private void cmbFaseleAghsat_Enter(object sender, EventArgs e)
        {
            cmbFaseleAghsat.ShowPopup();
        }

        private void cmbHesabMoin_Enter(object sender, EventArgs e)
        {
            cmbHesabMoin.ShowPopup();
        }

        private void cmbHesabTafzili_Enter(object sender, EventArgs e)
        {
            cmbHesabTafzili.ShowPopup();
        }

        private void chkcmbEntekhabZamenin_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
                chkcmbEntekhabZamenin.ShowPopup();
        }

        private void txtMablaghAsli_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelpClass1.AddZerooToTextBox(sender, e);

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.VamPardakhtis;
                    if (q.Count()>0)
                    {
                        var q1 = q.Max(s => s.ShomareDarkhast);
                        if (q != null)
                        {
                            if (q.Count() != q1)
                            {
                                int i = 0;
                                foreach (var item in q)
                                {
                                    i++;
                                    item.ShomareDarkhast = i;
                                }
                                db.SaveChanges();
                            }
                            else
                            {
                                txtShomareDarkhast.Text = (q1 + 1).ToString();

                            }
                        }
                        else
                        {
                            txtShomareDarkhast.Text = "1";
                        }
                        txtTarikhPardakht.Focus();

                    }
                    else
                    {
                        txtShomareDarkhast.Text = "1";
                        txtTarikhPardakht.Focus();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        int _AazaId = 0;
        private void cmbDaryaftkonande_Leave(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        var q = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _IDSandogh);
                        if (q != null)
                        {
                            if (q.checkEdit2 && q.AnvaeVams.FirstOrDefault().AdamEtayeVamJadid)
                            {
                                if (!string.IsNullOrEmpty(cmbDaryaftkonande.Text))
                                {
                                    _AazaId = Convert.ToInt32(cmbDaryaftkonande.EditValue);

                                    var q1 = db.VamPardakhtis.FirstOrDefault(s => s.IsTasviye == false && s.AazaId == _AazaId && s.IndexNoeVam == _cmbNoeVamIndex);
                                    if (q1 != null)
                                    {
                                        XtraMessageBox.Show("عضو انتخابی وام تسویه نشده قبلی دارد لذا اعطای وام جدید به ایشان مقدور نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        cmbDaryaftkonande.EditValue = 0;
                                        cmbDaryaftkonande_Enter(null, null);
                                        cmbDaryaftkonande.Focus();
                                        return;
                                    }


                                }
                                //if (Fm.gridView1.RowCount > 0)
                                //{
                                //    List<int> ListAazaId = new List<int>();
                                //    for (int i = 0; i < Fm.gridView1.RowCount; i++)
                                //    {
                                //        ListAazaId.Add(Convert.ToInt32(Fm.gridView1.GetRowCellValue(i, "AazaId")));
                                //        if (ListAazaId[i] == _AazaId)
                                //        {
                                //            XtraMessageBox.Show("عضو انتخابی وام تسویه نشده قبلی دارد لذا اعطای وام مجدد به ایشان مقدور نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //            cmbDaryaftkonande.EditValue = 0;
                                //            return;
                                //        }
                                //    }
                                //}

                            }

                            if (q.checkEdit14)
                            {
                                _AazaId = Convert.ToInt32(cmbDaryaftkonande.EditValue);
                                var w = db.AazaSandoghs.FirstOrDefault(s => s.AllTafId == _AazaId);
                                if (w != null)
                                {
                                    int yyyy1 = Convert.ToInt32(w.TarikhOzviat.ToString().Substring(0, 4));
                                    int MM1 = Convert.ToInt32(w.TarikhOzviat.ToString().Substring(5, 2));
                                    int dd1 = Convert.ToInt32(w.TarikhOzviat.ToString().Substring(8, 2));
                                    Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                                    d1.AddMont(q.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == _cmbNoeVamIndex).MinModatEntezar);

                                    int yyyy2 = Convert.ToInt32(DateTime.Now.ToString().Substring(0, 4));
                                    int MM2 = Convert.ToInt32(DateTime.Now.ToString().Substring(5, 2));
                                    int dd2 = Convert.ToInt32(DateTime.Now.ToString().Substring(8, 2));
                                    Mydate d2 = new Mydate(yyyy2, MM2, dd2);

                                    if (d1 > d2)
                                    {
                                        XtraMessageBox.Show("حداقل مدت انتظار جهت اعطای وام به عضو جدید " + q.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == _cmbNoeVamIndex).MinModatEntezar + " ماه می باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        cmbDaryaftkonande.EditValue = 0;
                                        cmbDaryaftkonande_Enter(null, null);
                                        cmbDaryaftkonande.Focus();
                                        return;

                                    }

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

        }

        private void cmbDaryaftkonande_EditValueChanged_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbDaryaftkonande.EditValue) > 0)
            {
                FillchkcmbEntekhabZamenin();
                cmbNoeVam.ReadOnly = true;
                

            }
        }


        private void FrmVamPardakhti_Shown(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbNoeVam.Focus();
                //CheckedList_0 = chkcmbEntekhabZamenin.Text;
                //cmbDaryaftkonande.ReadOnly = true;
                //using (var db = new MyContext())
                //{
                //    try
                //    {


                //        int _IDSandogh = Convert.ToInt32(Fm.Fm.IDSandogh.Caption);
                //        var vv = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _IDSandogh).AnvaeVams.FirstOrDefault(s => s.DefaultNoeVam == true);
                //        if (vv != null)
                //            cmbNoeVam.SelectedIndex = vv.NoeVamIndex;
                //        else
                //            cmbNoeVam.ShowPopup();

                //        //var CheckedListValue = chkcmbEntekhabZamenin.Properties.GetItems().GetCheckedValues();
                //        //CheckedList_1 = chkcmbEntekhabZamenin.Text;
                //        //var q2 = db.Tanzimats.FirstOrDefault(f => f.IDSandogh == _IDSandogh).checkEdit5;
                //        //if (q2)
                //        //{
                //        //    //cmbDaryaftkonande.ReadOnly = txtMablaghAsli.ReadOnly = txtMablaghKarmozd.ReadOnly = true;
                //        //    var q4 = db.AazaSandoghs.Where(s => s.GroupTafziliId == 3).ToList();
                //        //    int _VamId = Convert.ToInt32(txtId.Text);
                //        //    var q = db.R_VamPardakhti_B_Zamenins.Where(s => s.VamPardakhtiId == _VamId).AsParallel();
                //        //    if (q.Count() > 0)
                //        //    {
                //        //        lstZamenin1.Items.Clear();
                //        //        foreach (var item1 in q)
                //        //        {
                //        //            if (Fm.ListTasviyeNashode)
                //        //                lstZamenin1.Items.Add(q4.FirstOrDefault(s => s.AllTafId == item1.AllTafId).NameVFamil + " : " + "اعتبار بلوکه شده جهت ضمانت = " + item1.EtebarBlookeShode.ToString("n0") + "  ");
                //        //            else
                //        //                lstZamenin1.Items.Add(q4.FirstOrDefault(s => s.AllTafId == item1.AllTafId).NameVFamil + " : " + "اعتبار آزاد شده جهت ضمانت = " + item1.EtebarBlookeShode.ToString("n0") + "  ");
                //        //        }
                //        //    }
                //        //    else
                //        //    {
                //        //        lstZamenin1.Items.Clear();
                //        //    }
                //        //}
                //        //else
                //        //{
                //        //    lstZamenin1.Items.Clear();
                //        //}
                //    }
                //    catch (Exception ex)
                //    {
                //        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                //            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}

            }
            //else
            //{
            //    cmbDaryaftkonande.Focus();
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }

        private void btnNemayeshCheckhaiAtfNashode_Click(object sender, EventArgs e)
        {
            FillDataGridCheckTazmin();
            //using (var db = new MyContext())
            //{
            //    try
            //    {
            //        if (Convert.ToInt32(cmbDaryaftkonande.EditValue) > 0)
            //        {
            //            int AazaId = Convert.ToInt32(cmbDaryaftkonande.EditValue);
            //            var q1 = db.CheckTazmins.Where(s => s.IsInSandogh == true && s.VamGerandeId == AazaId).OrderBy(s => s.SeryalDaryaft).ToList();
            //            if (q1.Count > 0)
            //            {
            //                if (En == EnumCED.Create)
            //                {
            //                    checkTazminsBindingSource.DataSource = q1.Where(s => s.VaziatAtf == false).ToList();
            //                }
            //                else
            //                {
            //                    int _VamId = Convert.ToInt32(txtId.Text);
            //                    checkTazminsBindingSource.DataSource = q1.Where(s => s.AtfVamId == _VamId || s.AtfVamId == 0).ToList();
            //                }
            //            }
            //            else
            //                checkTazminsBindingSource.DataSource = null;

            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
            //            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void txtTozihat_Leave(object sender, EventArgs e)
        {
            xtraTabControl2.SelectedTabPageIndex = 1;
            xtraTabControl1.SelectedTabPageIndex = 0;
            chkcmbEntekhabZamenin.Focus();
        }

        private void btnTarifAaza_Click(object sender, EventArgs e)
        {
            FrmTarifAaza_1 fm = new FrmTarifAaza_1(this);
            fm.IsActiveList = true;
            fm.ShowDialog(this);
        }

        int _CodeMoin = 0;
        int _cmbNoeVamIndex = 0;
        double _DarsadKarmozd = 0;
        decimal _MablaghDirkard = 0;
        int _MaxAghsatMahane = 0;
        int _MaxAghsatSalane = 0;
        decimal _MaxPardakht = 0;
        private void cmbNoeVam_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    _cmbNoeVamIndex = cmbNoeVam.SelectedIndex;
                    var q0 = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _IDSandogh);
                    var q1 = q0.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == _cmbNoeVamIndex);
                    _DarsadKarmozd = q1.DarsadeKarmozd;
                    _MablaghDirkard = q1.MablaghDirkard;
                    _MaxAghsatMahane = q1.MaxAghsatMahane;
                    _MaxAghsatSalane = q1.MaxAghsatSalane;
                    _MaxPardakht = q1.MaxPardakht;
                    txtDarsadeKarmozd.Text = _DarsadKarmozd.ToString();
                    txtMablaghDirkard.Text = _MablaghDirkard.ToString();
                    if (q0.radioGroup1 == 0)
                    {
                        checkEdit1.Visible = true;
                        checkEdit2.Visible = false;

                        checkEdit1.Checked = true;
                        checkEdit2.Checked = false;
                    }
                    else
                    {
                        checkEdit2.Visible = true;
                        checkEdit1.Visible = false;

                        checkEdit2.Checked = true;
                        checkEdit1.Checked = false;
                    }
                    //if (q0.radioGroup1 == 0) checkEdit1.Checked = true; else checkEdit2.Checked = true;

                    //checkEdit2.Checked = q0.radioGroup1 == 0 ? true : false;

                    var q = db.CodeMoins.ToList();
                    switch (_cmbNoeVamIndex)
                    {
                        case 0:
                            {
                                _CodeMoin = 2001;
                                textEdit1.Text = q.FirstOrDefault(s => s.Code == _CodeMoin).Name;
                                break;
                            }
                        case 1:
                            {
                                _CodeMoin = 2002;
                                textEdit1.Text = q.FirstOrDefault(s => s.Code == _CodeMoin).Name;
                                break;
                            }
                        case 2:
                            {
                                _CodeMoin = 2003;
                                textEdit1.Text = q.FirstOrDefault(s => s.Code == _CodeMoin).Name;
                                break;
                            }
                        case 3:
                            {
                                _CodeMoin = 2004;
                                textEdit1.Text = q.FirstOrDefault(s => s.Code == _CodeMoin).Name;
                                break;
                            }
                        default:
                            {
                                _CodeMoin = 0;
                                textEdit1.Text = "";
                                break;
                            }


                    }

                    if (En == EnumCED.Create)
                    cmbDaryaftkonande.Focus();


                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void txtTarikhDarkhast_Enter(object sender, EventArgs e)
        {

        }

        private void txtMablaghAsli_Leave(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtMablaghAsli.Text))
            //{
            //    if (txtMablaghAsli.Text != "0")
            //    {
            //        decimal _mbAsli = Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", ""));
            //        if (!string.IsNullOrEmpty(txtDarsadeKarmozd.Text) && txtDarsadeKarmozd.Text != "0")
            //        {
            //            decimal _drKarmozd= Convert.ToDecimal(txtDarsadeKarmozd.Text.Replace(",", ""));
            //            txtMablaghKarmozd.Text = (_mbAsli * _drKarmozd/100).ToString();
            //        }
            //        else
            //        {
            //            txtMablaghKarmozd.Text = String.Empty;
            //        }
            //        //double D = Convert.ToDouble()

            //    }
            //    else
            //    {
            //        txtMablaghKarmozd.Text = String.Empty;
            //        //txtDarsadeKarmozd.Text = String.Empty;
            //    }
            //}
            //else
            //{
            //    txtMablaghKarmozd.Text = String.Empty;
            //    //txtDarsadeKarmozd.Text = String.Empty;
            //}
        }

        private void txtTarikhDarkhast_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtShomareDarkhast.Text))
            {
                btnNext_Click(null, null);
                txtShomareDarkhast.Focus();
            }
        }

        private void txtTedadAghsat_Leave(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _IDSandogh);
                    if (q != null)
                    {
                        if (q.checkEdit13)
                        {
                            if (cmbFaseleAghsat.SelectedIndex == 0)
                            {
                                if (Convert.ToInt32(txtTedadAghsat.Text) > q.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == _cmbNoeVamIndex).MaxAghsatMahane)
                                {
                                    XtraMessageBox.Show("تعداد اقساط نباید بیشتر از " + q.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == _cmbNoeVamIndex).MaxAghsatMahane + " ماه باشد",
                                                  "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtTedadAghsat.Focus();
                                }

                            }
                            else
                            {
                                if (Convert.ToInt32(txtTedadAghsat.Text) > q.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == _cmbNoeVamIndex).MaxAghsatSalane)
                                {
                                    XtraMessageBox.Show("تعداد اقساط نباید بیشتر از " + q.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == _cmbNoeVamIndex).MaxAghsatSalane + " سال باشد",
                                                   "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtTedadAghsat.Focus();
                                }

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

        private void txtMablaghAsli_Leave_1(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _IDSandogh);
                    if (q != null)
                    {
                        if (q.checkEdit12)
                        {
                            decimal _m = q.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == _cmbNoeVamIndex).MaxPardakht;
                            if (Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) > _m)
                            {
                                XtraMessageBox.Show("سقف مبلغ وام " + _m.ToString("n0") + " است",
                                              "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtMablaghAsli.Focus();
                            }

                        }
                        double _d = q.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == _cmbNoeVamIndex).MablaghVamChandBrabarSarmaye;
                        if (_d != 0)
                        {
                            _AazaId = Convert.ToInt32(cmbDaryaftkonande.EditValue);
                            decimal sumbed = 0;
                            decimal sumbes = 0;

                            if (q.radioGroup4 == 0)
                            {
                                var q5 = db.AsnadeHesabdariRows.Where(s => s.HesabMoinCode == 7001 && s.HesabTafId == _AazaId).ToList();
                                //var q5 = q4.Where(s => s.HesabTafId == q[i].AllTafId).ToList();
                                sumbed = q5.Sum(s => s.Bed) ?? 0;
                                sumbes = q5.Sum(s => s.Bes) ?? 0;

                            }
                            else if (q.radioGroup4 == 1)
                            {
                                var q5 = db.AazaSandoghs.FirstOrDefault(s => s.AllTafId == _AazaId);
                                //var q5 = q4.Where(s => s.HesabTafId == q[i].AllTafId).ToList();
                                if (q5 != null)
                                    sumbes = q5.BesAvali ?? 0;
                                sumbed = 0;

                            }
                            decimal _ZaribSarmaye = Convert.ToDecimal(_d);
                            decimal _ChandBrabarSarmaye = (sumbes - sumbed) >= 0 ? _ZaribSarmaye * (sumbes - sumbed) : 0;


                            if (Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) > _ChandBrabarSarmaye)
                            {
                                XtraMessageBox.Show("مبلغ وام از " + _d.ToString() + " برابر سرمایه وام گیرنده بیشتر است",
                                              "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtMablaghAsli.Focus();
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

        private void cmbNoeVam_Enter_1(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            cmbNoeVam.ShowPopup();

        }
    }
}