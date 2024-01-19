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
using DevExpress.XtraReports.UI;

namespace Sandogh_PG
{
    public partial class FrmDaryaftPardakhtBinHesabha : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmDaryaftPardakhtBinHesabha(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        public EnumCED En;
        //public bool IsCheckInSandogh = true;

        public void FillDataGridDaryaftPardakhtBinHesabha()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var p2 = db.CodeMoins.AsParallel();
                    var q2 = p2.ToList();
                    var p1 = db.DaryaftPardakhtBinHesabhas.OrderBy(s => s.Seryal).AsParallel();
                    var q1 = p1.ToList();
                    if (q1.Count > 0)
                    {
                        foreach (var item in q1)
                        {
                            item.HesabMoineName1 = q2.FirstOrDefault(s => s.SandoghId == _SandoghId && s.Id == item.HesabMoinId1).Name;
                            item.HesabMoineName2 = q2.FirstOrDefault(s => s.SandoghId == _SandoghId && s.Id == item.HesabMoinId2).Name;
                        }

                        gridControl1.DataSource = q1;
                        gridView1.MoveLast();
                    }
                    else
                        gridControl1.DataSource = null;
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
                        codeMoinsBindingSource.DataSource = q1.ToList();
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

        public void FillcmbHesabTafzili1()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _HesabMoinId = Convert.ToInt32(cmbHesabMoin1.EditValue);
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
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2).OrderBy(s => s.Code).AsParallel();
                                        if (q1.Count() > 0)
                                            allHesabTafzilisBindingSource.DataSource = En == EnumCED.Create ? q1.Where(f => f.IsActive == true).OrderBy(s => s.Code).ToList() : q1.ToList();
                                        else
                                            allHesabTafzilisBindingSource.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2).OrderBy(s => s.Code).AsParallel();
                                        if (q2.Count() > 0)
                                            allHesabTafzilisBindingSource.DataSource = q2.ToList();
                                        else
                                            allHesabTafzilisBindingSource.DataSource = null;
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
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 3).OrderBy(s => s.Code).AsParallel();
                                        if (q1.Count() > 0)
                                            allHesabTafzilisBindingSource.DataSource = En == EnumCED.Create ? q1.Where(f => f.IsActive == true).OrderBy(s => s.Code).ToList() : q1.ToList();
                                        else
                                            allHesabTafzilisBindingSource.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 3).OrderBy(s => s.Code).AsParallel();
                                        if (q2.Count() > 0)
                                            allHesabTafzilisBindingSource.DataSource = q2.ToList();
                                        else
                                            allHesabTafzilisBindingSource.DataSource = null;
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
                                    if (En == EnumCED.Create)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 6).OrderBy(s => s.Code).AsParallel();
                                        if (q1.Count() > 0)
                                            allHesabTafzilisBindingSource.DataSource = En == EnumCED.Create ? q1.Where(f => f.IsActive == true).OrderBy(s => s.Code).ToList() : q1.ToList();
                                        else
                                            allHesabTafzilisBindingSource.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 6).OrderBy(s => s.Code).AsParallel();
                                        if (q2.Count() > 0)
                                            allHesabTafzilisBindingSource.DataSource = q2.ToList();
                                        else
                                            allHesabTafzilisBindingSource.DataSource = null;
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
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 4).OrderBy(s => s.Code).AsParallel();
                                        if (q1.Count() > 0)
                                            allHesabTafzilisBindingSource.DataSource = En == EnumCED.Create ? q1.Where(f => f.IsActive == true).OrderBy(s => s.Code).ToList() : q1.ToList();
                                        else
                                            allHesabTafzilisBindingSource.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 4).OrderBy(s => s.Code).AsParallel();
                                        if (q1.Count() > 0)
                                            allHesabTafzilisBindingSource.DataSource = q1.ToList();
                                        else
                                            allHesabTafzilisBindingSource.DataSource = null;
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
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 5).OrderBy(s => s.Code).AsParallel();
                                        if (q1.Count() > 0)
                                            allHesabTafzilisBindingSource.DataSource = En == EnumCED.Create ? q1.Where(f => f.IsActive == true).OrderBy(s => s.Code).ToList() : q1.ToList();
                                        else
                                            allHesabTafzilisBindingSource.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 5).OrderBy(s => s.Code).AsParallel();
                                        if (q1.Count() > 0)
                                            allHesabTafzilisBindingSource.DataSource = q1.ToList();
                                        else
                                            allHesabTafzilisBindingSource.DataSource = null;
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
        public void FillcmbHesabTafzili2()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _HesabMoinId = Convert.ToInt32(cmbHesabMoin2.EditValue);
                    var q = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId);
                    if (q != null)
                    {
                        switch (q.Code)
                        {
                            case 1001:
                                {
                                    //allHesabTafzilisBindingSource1.DisplayMember = "NameHesab";
                                    //allHesabTafzilisBindingSource1.ValueMember = "Id";
                                    //allHesabTafzilisBindingSource1.Columns[1].FieldName = "NameHesab";
                                    if (En == EnumCED.Create)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2).OrderBy(s => s.Code).ToList();
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
                                    //allHesabTafzilisBindingSource1.DisplayMember = "NameVFamil";
                                    //allHesabTafzilisBindingSource1.ValueMember = "Id";
                                    //allHesabTafzilisBindingSource1.Columns[1].FieldName = "NameVFamil";
                                    if (En == EnumCED.Create)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 3).OrderBy(s => s.Code).ToList();
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
                                    if (En == EnumCED.Create)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 6).OrderBy(s => s.Code).ToList();
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
                                    //allHesabTafzilisBindingSource1.DisplayMember = "HesabName";
                                    //allHesabTafzilisBindingSource1.ValueMember = "Id";
                                    //allHesabTafzilisBindingSource1.Columns[1].FieldName = "HesabName";
                                    if (En == EnumCED.Create)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 4).OrderBy(s => s.Code).ToList();
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
                                    //allHesabTafzilisBindingSource1.DisplayMember = "HesabName";
                                    //allHesabTafzilisBindingSource1.ValueMember = "Id";
                                    //allHesabTafzilisBindingSource1.Columns[1].FieldName = "HesabName";
                                    if (En == EnumCED.Create)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 5).OrderBy(s => s.Code).ToList();
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

        private void NewSeryal()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.DaryaftPardakhtBinHesabhas.Select(s => s);
                    if (q.Any())
                    {
                        var MaximumCod = q.Max(p => p.Seryal);
                        if (MaximumCod.ToString() != "9999999")
                        {
                            txtSeryal.Text = (MaximumCod + 1).ToString();
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                                XtraMessageBox.Show("اعمال محدودیت ثبت حداکثر 9999999 سریال" + "\n" +
                                    "توجه : نمیتوان بیشتر از این تعداد سریال، ثبت نمود ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        //private void DefaultBankVSandogh()
        //{
        //    using (var db = new MyContext())
        //    {
        //        try
        //        {
        //            if (En == EnumCED.Create)
        //            {
        //                var q2 = db.HesabBankis.FirstOrDefault(s => s.IsActive == true && s.IsDefault == true);
        //                if (q2 != null)
        //                    cmbNameHesab.EditValue = q2.Id;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
        //                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}
        int _SandoghId = 0;
        string _deviceID = string.Empty;
        string _dataBaseName = string.Empty;

        private void FrmDaryaftPardakhtBinHesabha_Load(object sender, EventArgs e)
        {
            _SandoghId = Convert.ToInt32(Fm.IDSandogh.Caption);
            HelpClass1.DateTimeMask(txtTarikh);
            FillDataGridDaryaftPardakhtBinHesabha();
            _deviceID = HelpClass1.GetMadarBoardSerial();
            _dataBaseName = new MyContext().Database.Connection.Database;
            FillcmbHesabMoin();
            //gridView1.MoveLast();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private bool ControlMablaghSarmayeAvalye()
        //{
        //    using (var db = new MyContext())
        //    {
        //        try
        //        {
        //            if (true)
        //            {

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
        //                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //        return true;
        //    }

        //}
        private bool Validation()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _HesabMoinId1 = Convert.ToInt32(cmbHesabMoin1.EditValue);
                    int _HesabMoinId2 = Convert.ToInt32(cmbHesabMoin2.EditValue);
                    _CodeMoin1 = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId1).Code;
                    _CodeMoin2 = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId2).Code;

                    var k = db.AllowedDevises.FirstOrDefault(s => s.DeviceID == _deviceID && s.DataBaseName == _dataBaseName);
                    if (k != null)
                    {
                        if (k.VersionType == "Display")
                        {
                            XtraMessageBox.Show("در نسخه نمایشی نمیتوان سند صادر و یا ویرایش نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;

                        }
                        else
                        {
                            if (k.VersionType == "Demo")
                            {
                                if (k.IsActive == false)
                                {
                                    XtraMessageBox.Show("در نسخه آزمایشی نمیتوان بیشتر از 100 مورد سند صادر و یا ویرایش نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }
                            }

                            var t = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SandoghId);
                            if (_CodeMoin2 == 7001 && chkTaghirSarmayeAvalye.Checked)
                            {
                                int _AazaId = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                                var a = db.AazaSandoghs.FirstOrDefault(s => s.AllTafId == _AazaId);
                                if (t.checkEdit10)
                                {
                                    var v = db.VamPardakhtis;
                                    if (a != null)
                                    {
                                        if (v.FirstOrDefault(s => s.AazaId == _AazaId) == null)
                                        {
                                            ///// تاریخ عضویت کنترل میشود
                                            int yyyy1 = Convert.ToInt32(a.TarikhOzviat.ToString().Substring(0, 4));
                                            int MM1 = Convert.ToInt32(a.TarikhOzviat.ToString().Substring(5, 2));
                                            int dd1 = Convert.ToInt32(a.TarikhOzviat.ToString().Substring(8, 2));
                                            Mydate d11 = new Mydate(yyyy1, MM1, dd1);
                                            Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                                            d1.AddMont(t.XMah);

                                            int yyyy2 = Convert.ToInt32(DateTime.Now.ToString().Substring(0, 4));
                                            int MM2 = Convert.ToInt32(DateTime.Now.ToString().Substring(5, 2));
                                            int dd2 = Convert.ToInt32(DateTime.Now.ToString().Substring(8, 2));
                                            Mydate d2 = new Mydate(yyyy2, MM2, dd2);

                                            if (d1 < d2)
                                            {
                                                XtraMessageBox.Show("افزایش سرمایه اولیه حداکثر تا " + t.XMah + " ماه از تاریخ عضویت در صندوق مجاز می باشد" +
                                                    "\n تاریخ عضویت در صندوق : " + d11.ToString() + "\n پایان مهلت افزایش سرمایه اولیه :" + d1.ToString(), "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return false;

                                            }

                                        }
                                        else if (v.FirstOrDefault(s => s.AazaId == _AazaId && s.IsTasviye == false) != null)
                                        {
                                            ///// تاریخ دریافت وام کنترل میشود 
                                            int yyyy1 = Convert.ToInt32(v.FirstOrDefault(s => s.AazaId == _AazaId && s.IsTasviye == false && (s.IndexNoeVam == 0 || s.IndexNoeVam == 0)).TarikhPardakht.ToString().Substring(0, 4));
                                            int MM1 = Convert.ToInt32(v.FirstOrDefault(s => s.AazaId == _AazaId && s.IsTasviye == false && (s.IndexNoeVam == 0 || s.IndexNoeVam == 0)).TarikhPardakht.ToString().Substring(5, 2));
                                            int dd1 = Convert.ToInt32(v.FirstOrDefault(s => s.AazaId == _AazaId && s.IsTasviye == false && (s.IndexNoeVam == 0 || s.IndexNoeVam == 0)).TarikhPardakht.ToString().Substring(8, 2));
                                            Mydate d11 = new Mydate(yyyy1, MM1, dd1);
                                            Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                                            d1.AddMont(t.XMah);

                                            int yyyy2 = Convert.ToInt32(DateTime.Now.ToString().Substring(0, 4));
                                            int MM2 = Convert.ToInt32(DateTime.Now.ToString().Substring(5, 2));
                                            int dd2 = Convert.ToInt32(DateTime.Now.ToString().Substring(8, 2));
                                            Mydate d2 = new Mydate(yyyy2, MM2, dd2);

                                            if (d1 < d2)
                                            {
                                                XtraMessageBox.Show("افزایش سرمایه اولیه حداکثر تا " + t.XMah + " ماه از تاریخ پرداخت وام مجاز می باشد" +
                                                    "\n تاریخ پرداخت وام : " + d11.ToString() + "\n پایان مهلت افزایش سرمایه اولیه :" + d1.ToString(), "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return false;

                                            }

                                        }
                                    }
                                }

                                if (t.checkEdit16)
                                {
                                    _Mablagh = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                                    decimal _MinMablagh = t.radioGroup2 == 0 ? t.MinMablaghSarmayeAvalye : Convert.ToDecimal(t.MinTedadSahm) * t.MablaghHarSahm;
                                    decimal _MaxMablagh = t.radioGroup2 == 0 ? t.MaxMablaghSarmayeAvalye : Convert.ToDecimal(t.MaxTedadSahm) * t.MablaghHarSahm;

                                    if (a.BesAvali == 0)
                                    {

                                        if (_Mablagh < _MinMablagh)
                                        {
                                            XtraMessageBox.Show("ثبت سرمایه اولیه برای بار اول نباید از حداقل مبلغ " + _MinMablagh.ToString("n0") + " کمتر باشد"
                                                              , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return false;
                                        }
                                        else if (_Mablagh > _MaxMablagh)
                                        {
                                            XtraMessageBox.Show("ثبت سرمایه اولیه نباید از حداکثر مبلغ " + _MaxMablagh.ToString("n0") + " بیشتر باشد"
                                                  , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return false;

                                        }
                                    }
                                    else
                                    {

                                        if (a.BesAvali + _Mablagh > _MaxMablagh)
                                        {
                                            XtraMessageBox.Show("عملیات ذخیره انجام نشد زیرا با ثبت این سند مجموعه سرمایه اولیه از حداکثر تعیین شده تجاوز خواهد کرد " +
                                                "\n حداکثر سرمایه اولیه : " + _MaxMablagh.ToString("n0")
                                                , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return false;

                                        }
                                    }
                                }
                            }


                            return true;
                        }


                        //if (k.VersionType == "Orginal")
                        //{
                        //    return true;
                        //}
                        //else
                        //{

                        //    if (k.VersionType == "Demo")
                        //    {
                        //        if (k.IsActive == true)
                        //        {
                        //            return true;
                        //        }
                        //        else if (k.IsActive == false)
                        //        {
                        //            XtraMessageBox.Show("در نسخه آزمایشی نمیتوان بیشتر از 100 مورد سند صادر و یا ویرایش نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //            return false;
                        //        }

                        //    }
                        //    else if (k.VersionType == "Display")
                        //    {
                        //        XtraMessageBox.Show("در نسخه نمایشی نمیتوان سند صادر و یا ویرایش نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        return false;
                        //    }

                        //}
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
            }


            if (string.IsNullOrEmpty(txtSeryal.Text))
            {
                XtraMessageBox.Show("فیلد سریال نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeryal.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtTarikh.Text))
            {
                XtraMessageBox.Show("لطفاً تاریخ را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTarikh.Focus();
                return false;
            }
            else if (txtMablagh.Text == "0")
            {
                XtraMessageBox.Show("لطفاً مبلغ را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMablagh.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(cmbHesabMoin1.Text))
            {
                XtraMessageBox.Show("لطفاً حساب معین بدهکار را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabMoin1.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(cmbHesabMoin2.Text))
            {
                XtraMessageBox.Show("لطفاً حساب معین بستانکار را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabMoin2.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(cmbHesabTafzili1.Text))
            {
                XtraMessageBox.Show("لطفاً حساب تفضیل بدهکار را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabTafzili1.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(cmbHesabTafzili2.Text))
            {
                XtraMessageBox.Show("لطفاً حساب تفضیل بستانکار را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabTafzili2.Focus();
                return false;
            }
            return true;
        }

        private void FrmDaryaftPardakhtBinHesabha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnCreate_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F3 && btnDelete.Enabled == true)
            {
                btnDelete_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F4 && btnEdit.Enabled == true)
            {
                btnEdit_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F5 && btnSave.Enabled == true)
            {
                btnSave_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F6 && btnCancel.Enabled == true)
            {
                btnCancel_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnDisplayList_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnSaveNext_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F10)
            {
                btnAdvancedSearch_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F11)
            {
                btnPrintPreview_Click(sender, null);
            }
            //else if (e.KeyCode == Keys.F12 && btnPrint.Enabled == true)
            //{
            //    btnPrint_Click(sender, null);
            //}
            else if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, null);
            }
            HelpClass1.ControlAltShift_KeyDown(sender, e, btnDesignReport);

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            gridView1.MoveLast();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            gridView1.MoveNext();

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            gridView1.MovePrev();

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            gridView1.MoveFirst();
        }

        private void btnPrintPreview1_Click(object sender, EventArgs e)
        {
            HelpClass1.PrintPreview(gridControl1, gridView1);
        }

        public void btnDisplayList_Click(object sender, EventArgs e)
        {
            FillDataGridDaryaftPardakhtBinHesabha();
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEdit_Click(null, null);
            }

        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            ///HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);
        }

        private void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            gridView1.OptionsFind.AlwaysVisible = gridView1.OptionsFind.AlwaysVisible ? false : true;
        }

        public void InActiveButtons()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                foreach (SimpleButton item in panelControl2.Controls)
                {
                    item.Enabled = false;
                }
                btnSave.Enabled = true;
                btnSaveNext.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;
            }
        }

        public void ActiveButtons()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                foreach (SimpleButton item in panelControl2.Controls)
                {
                    item.Enabled = true;
                }
                btnSave.Enabled = false;
                btnSaveNext.Enabled = false;
                btnCancel.Enabled = false;
            }
        }

        public void ClearControls()
        {
            txtSeryal.Text = string.Empty;
            cmbNoeSanad.SelectedIndex = -1;
            txtTarikh.Text = string.Empty;
            txtMablagh.Text = string.Empty;
            cmbHesabMoin1.EditValue = 0;
            cmbHesabMoin2.EditValue = 0;
            cmbHesabTafzili1.EditValue = 0;
            cmbHesabTafzili2.EditValue = 0;
            txtSharh.Text = string.Empty;
            chkTaghirSarmayeAvalye.Checked = false;
        }

        public void ActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                txtTarikh.ReadOnly = false;
                cmbNoeSanad.ReadOnly = false;
                txtMablagh.ReadOnly = false;
                cmbHesabMoin1.ReadOnly = false;
                cmbHesabMoin2.ReadOnly = false;
                cmbHesabTafzili1.ReadOnly = false;
                cmbHesabTafzili2.ReadOnly = false;
                txtSharh.ReadOnly = false;
                chkTaghirSarmayeAvalye.ReadOnly = false;
                FillcmbHesabMoin();
            }
        }

        public void InActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                txtTarikh.ReadOnly = true;
                cmbNoeSanad.ReadOnly = true;
                txtMablagh.ReadOnly = true;
                cmbHesabMoin1.ReadOnly = true;
                cmbHesabMoin2.ReadOnly = true;
                cmbHesabTafzili1.ReadOnly = true;
                cmbHesabTafzili2.ReadOnly = true;
                txtSharh.ReadOnly = true;
                chkTaghirSarmayeAvalye.ReadOnly = true;
            }
        }

        public int EditRowIndex = 0;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            En = EnumCED.Create;
            InActiveButtons();
            ClearControls();
            NewSeryal();
            ActiveControls();
            txtTarikh.Text = DateTime.Now.ToString().Substring(0, 10);
            gridControl1.Enabled = false;
            //DefaultBankVSandogh();
            cmbNoeSanad.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (XtraMessageBox.Show("آیا عملیات فوق حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    EditRowIndex = gridView1.FocusedRowHandle;
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                            var q = db.DaryaftPardakhtBinHesabhas.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                db.DaryaftPardakhtBinHesabhas.Remove(q);
                                ///////////////////////////////////////////////////////////////////
                                var q1 = db.AsnadeHesabdariRows.Where(f => f.ShomareSanad == q.ShomareSanad);
                                if (q1.Count() > 0)
                                    db.AsnadeHesabdariRows.RemoveRange(q1);
                                ///////////////////////////////////////////////////////////////////////////////
                                int _HesabMoinId1 = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabMoinId1"));
                                int _HesabMoinId2 = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabMoinId2"));
                                //int _Moin1Id = Convert.ToInt32(cmbHesabMoin1.EditValue);
                                // int _Moin1Id = Convert.ToInt32(cmbHesabMoin2.EditValue);
                                _Mablagh = Convert.ToDecimal(txtMablagh.Text);
                                var m = db.CodeMoins;
                                _CodeMoin1 = m.FirstOrDefault(f => f.Id == _HesabMoinId1).Code;
                                _CodeMoin2 = m.FirstOrDefault(f => f.Id == _HesabMoinId2).Code;

                                _Mablagh = Convert.ToDecimal(gridView1.GetFocusedRowCellValue("Mablagh").ToString());
                                bool _chkTaghirSarmayeAvalye = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("TaghirSarmayeAvalye"));
                                if (_chkTaghirSarmayeAvalye)
                                {
                                    if (_CodeMoin1 == 7001)
                                    {
                                        int _AazaId = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                                        var As = db.AazaSandoghs.FirstOrDefault(s => s.AllTafId == _AazaId);
                                        As.BesAvali += _Mablagh;
                                    }
                                    if (_CodeMoin2 == 7001)
                                    {
                                        int _AazaId = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                                        var As = db.AazaSandoghs.FirstOrDefault(s => s.AllTafId == _AazaId);
                                        //As.BesAvali -= _Mablagh;
                                        if (As.BesAvali >= _Mablagh)
                                            As.BesAvali -= _Mablagh;
                                        else
                                        {
                                            XtraMessageBox.Show("مبلغ مانده سرمایه اولیه در تعریف اشخاص کمتر از مبلغ این سند می باشد لذا نمیتوان سند جاری را حذف نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;

                                        }

                                    }
                                }
                                ///////////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();

                                btnDisplayList_Click(null, null);
                                // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex - 1;
                            }
                            else
                            {
                                XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }


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
                        //catch (DbUpdateException)
                        //{
                        //    XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این حساب مقدور نیست \n" +
                        //        " جهت حذف حساب مورد نظر در ابتدا بایستی زیر شاخه های این حساب یعنی پس انداز ماهیانه اعضاء،\n وامهای دریافتی اعضا،ریز اقساط وام، انتقالی بین حسابها، سند های درآمد و هزینه ، و سایر دریافتها و\n پرداختها مربوط به این حساب در صورت وجود حذف گردد" +
                        //        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        //bool _BeforEditchkTaghirSarmayeAvalye = false;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && btnEdit.Visible == true)
            {

                gridControl1.Enabled = false;
                EditRowIndex = gridView1.FocusedRowHandle;
                En = EnumCED.Edit;
                InActiveButtons();
                ActiveControls();

                txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                txtSeryal.Text = gridView1.GetFocusedRowCellValue("Seryal").ToString();
                if (gridView1.GetFocusedRowCellValue("Tarikh") != null)
                    txtTarikh.Text = gridView1.GetFocusedRowCellValue("Tarikh").ToString().Substring(0, 10); ;
                txtMablagh.Text = gridView1.GetFocusedRowCellValue("Mablagh").ToString();
                cmbHesabMoin1.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabMoinId1"));
                cmbHesabTafzili1.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabTafziliId1"));
                cmbHesabMoin2.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabMoinId2"));
                cmbHesabTafzili2.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabTafziliId2"));
                txtSharh.Text = gridView1.GetFocusedRowCellValue("Sharh").ToString();
                cmbNoeSanad.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("NoeSanadIndex"));
                chkTaghirSarmayeAvalye.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("TaghirSarmayeAvalye"));
                //_BeforEditchkTaghirSarmayeAvalye = chkTaghirSarmayeAvalye.Checked;
                cmbNoeSanad.Focus();
            }
        }

        decimal SumBed = 0;
        decimal SumBes = 0;
        decimal MandeHesab = 0;
        int _cmbNoeSanad = 0;
        //string _cmbHesabMoin1 = string.Empty;
        int AllTafId = 0;
        string _NameAaza = string.Empty;
        int _HesabMoinId1 = 0;
        int _HesabMoinId2 = 0;
        int _HesabTafziliId1 = 0;
        int _HesabTafziliId2 = 0;
        Decimal _Mablagh = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                _cmbNoeSanad = cmbNoeSanad.SelectedIndex;

                AllTafId = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                _NameAaza = cmbHesabTafzili1.Text;
                _HesabMoinId1 = Convert.ToInt32(cmbHesabMoin1.EditValue);
                _HesabMoinId2 = Convert.ToInt32(cmbHesabMoin2.EditValue);
                _HesabTafziliId1 = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                _HesabTafziliId2 = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                //Convert.ToInt32(cmbHesabMoin1.EditValue);

                if (En == EnumCED.Create)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            var q2 = db.AsnadeHesabdariRows.Any() ? db.AsnadeHesabdariRows.Max(f => f.ShomareSanad) : 0;
                            DaryaftPardakhtBinHesabha obj = new DaryaftPardakhtBinHesabha();
                            obj.Seryal = Convert.ToInt32(txtSeryal.Text);
                            if (!string.IsNullOrEmpty(txtTarikh.Text))
                                obj.Tarikh = Convert.ToDateTime(txtTarikh.Text);
                            if (txtMablagh.Text != "0")
                            {
                                obj.Mablagh = Convert.ToDecimal(txtMablagh.Text);
                                obj.HesabMoinId1 = Convert.ToInt32(cmbHesabMoin1.EditValue);
                                obj.HesabMoineName1 = cmbHesabMoin1.Text;
                                obj.HesabMoinId2 = Convert.ToInt32(cmbHesabMoin2.EditValue);
                                obj.HesabMoineName2 = cmbHesabMoin2.Text;
                                obj.HesabTafziliId1 = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                                obj.HesabTafziliName1 = cmbHesabTafzili1.Text;
                                obj.HesabTafziliId2 = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                                obj.HesabTafziliName2 = cmbHesabTafzili2.Text;
                            }
                            obj.TaghirSarmayeAvalye = chkTaghirSarmayeAvalye.Checked;
                            obj.Sharh = txtSharh.Text;
                            obj.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                            obj.ShomareSanad = q2 + 1;
                            obj.NoeSanadIndex = cmbNoeSanad.SelectedIndex;
                            obj.NoeSanadName = cmbNoeSanad.Text;
                            db.DaryaftPardakhtBinHesabhas.Add(obj);
                            //////////////////////////////////////////////////////////////////////////////////////////
                            //_HesabMoinId1 = Convert.ToInt32(cmbHesabMoin1.EditValue);
                            //int _HesabTafziliId1 = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                            AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
                            obj1.ShomareSanad = q2 + 1;
                            obj1.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
                            obj1.HesabMoinId = Convert.ToInt32(cmbHesabMoin1.EditValue);
                            obj1.HesabMoinCode = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId1).Code;
                            obj1.HesabMoinName = cmbHesabMoin1.Text; ;
                            obj1.HesabTafId = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                            obj1.HesabTafCode = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabTafziliId1).Code;
                            obj1.HesabTafName = cmbHesabTafzili1.Text;
                            obj1.Bed = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                            obj1.Sharh = txtSharh.Text;
                            obj1.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                            db.AsnadeHesabdariRows.Add(obj1);

                            //int _HesabMoinId2 = Convert.ToInt32(cmbHesabMoin2.EditValue);
                            //int _HesabTafziliId2 = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                            AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
                            obj2.ShomareSanad = q2 + 1;
                            obj2.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
                            obj2.HesabMoinId = Convert.ToInt32(cmbHesabMoin2.EditValue);
                            obj2.HesabMoinCode = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId2).Code;
                            obj2.HesabMoinName = cmbHesabMoin2.Text; ;
                            obj2.HesabTafId = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                            obj2.HesabTafCode = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabTafziliId2).Code;
                            obj2.HesabTafName = cmbHesabTafzili2.Text;
                            obj2.Bes = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                            obj2.Sharh = txtSharh.Text;
                            obj2.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                            db.AsnadeHesabdariRows.Add(obj2);
                            ///////////////////////////////////////////////////////////////////////////////

                            _Mablagh = Convert.ToDecimal(txtMablagh.Text);
                            var m = db.CodeMoins;
                            _CodeMoin1 = m.FirstOrDefault(f => f.Id == _HesabMoinId1).Code;
                            _CodeMoin2 = m.FirstOrDefault(f => f.Id == _HesabMoinId2).Code;
                            if (chkTaghirSarmayeAvalye.Checked)
                            {
                                if (_CodeMoin1 == 7001)
                                {
                                    //int _AazaId = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                                    var As = db.AazaSandoghs.FirstOrDefault(s => s.AllTafId == _HesabTafziliId1);
                                    //As.BesAvali -= _Mablagh;
                                    if (As.BesAvali >= _Mablagh)
                                        As.BesAvali -= _Mablagh;
                                    else
                                    {
                                        XtraMessageBox.Show("مبلغ مانده سرمایه اولیه در تعریف اشخاص کمتر از مبلغ فعلی می باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;

                                    }

                                }
                                if (_CodeMoin2 == 7001)
                                {
                                    //int _AazaId = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                                    var As = db.AazaSandoghs.FirstOrDefault(s => s.AllTafId == _HesabTafziliId2);
                                    As.BesAvali += _Mablagh;

                                }
                            }
                            ///////////////////////////////////////////////////////////////////////////////////
                            db.SaveChanges();
                            btnDisplayList_Click(null, null);

                            //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                            gridControl1.Enabled = true;
                            gridView1.MoveLast();

                            ActiveButtons();
                            ClearControls();
                            InActiveControls();
                            En = EnumCED.Save;

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
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.ToString(), "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (En == EnumCED.Edit)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            var m = db.CodeMoins;
                            int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                            int _AazaId1_Befour = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabTafziliId1").ToString());
                            int _AazaId2_Befour = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabTafziliId2").ToString());
                            int _HesabMoinId1_Befour = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabMoinId1").ToString());
                            int _HesabMoinId2_Befour = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabMoinId2").ToString());
                            int _ShomareSanad_Befour = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ShomareSanad").ToString());
                            int _Seryal_Befour = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Seryal").ToString());
                            bool _chkTaghirSarmayeAvalye_Befour = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("TaghirSarmayeAvalye"));
                            decimal _Mablagh_Befour = Convert.ToDecimal(gridView1.GetFocusedRowCellValue("Mablagh").ToString());
                            bool _chkTaghirSarmayeAvalyeAfter = chkTaghirSarmayeAvalye.Checked;

                            if (_chkTaghirSarmayeAvalye_Befour == true)
                            {
                                var q11 = db.DaryaftPardakhtBinHesabhas.FirstOrDefault(p => p.Id == RowId);
                                if (q11 != null)
                                    db.DaryaftPardakhtBinHesabhas.Remove(q11);

                                var q12 = db.AsnadeHesabdariRows.Where(f => f.ShomareSanad == _ShomareSanad_Befour);
                                if (q12.Count() > 0)
                                    db.AsnadeHesabdariRows.RemoveRange(q12);


                                _CodeMoin1 = m.FirstOrDefault(f => f.Id == _HesabMoinId1_Befour).Code;
                                _CodeMoin2 = m.FirstOrDefault(f => f.Id == _HesabMoinId2_Befour).Code;

                                if (_CodeMoin1 == 7001)
                                {
                                    //int _AazaId = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                                    var As = db.AazaSandoghs.FirstOrDefault(s => s.AllTafId == _AazaId1_Befour);
                                    As.BesAvali += _Mablagh_Befour;
                                }
                                if (_CodeMoin2 == 7001)
                                {
                                    //int _AazaId = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                                    var As = db.AazaSandoghs.FirstOrDefault(s => s.AllTafId == _AazaId2_Befour);
                                    if (As.BesAvali >= _Mablagh_Befour)
                                        As.BesAvali -= _Mablagh_Befour;
                                    else
                                    {
                                        XtraMessageBox.Show("مبلغ مانده سرمایه اولیه در تعریف اشخاص کمتر از مبلغ قبل از ویرایش می باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;

                                    }

                                }

                                _Mablagh = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                                if (_chkTaghirSarmayeAvalyeAfter == true)
                                {
                                    //_Mablagh = Convert.ToDecimal(txtMablagh.Text);
                                    _CodeMoin1 = m.FirstOrDefault(f => f.Id == _HesabMoinId1).Code;
                                    _CodeMoin2 = m.FirstOrDefault(f => f.Id == _HesabMoinId2).Code;
                                    if (_CodeMoin1 == 7001)
                                    {
                                        var As = db.AazaSandoghs.FirstOrDefault(s => s.AllTafId == _HesabTafziliId1);
                                        if (As.BesAvali >= _Mablagh)
                                            As.BesAvali -= _Mablagh;
                                        else
                                        {
                                            XtraMessageBox.Show("مبلغ مانده سرمایه اولیه در تعریف اشخاص کمتر از مبلغ فعلی می باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;

                                        }
                                    }
                                    if (_CodeMoin2 == 7001)
                                    {
                                        var As = db.AazaSandoghs.FirstOrDefault(s => s.AllTafId == _HesabTafziliId2);
                                        As.BesAvali += _Mablagh;

                                    }

                                }

                                //////////////////////////////////////صدور سند جدید به شماره سند قبلی/////////////////////////////////////////////
                                //int q2 = db.AsnadeHesabdariRows.Any() ? db.AsnadeHesabdariRows.Max(f => f.ShomareSanad) : 0;
                                
                                DaryaftPardakhtBinHesabha obj = new DaryaftPardakhtBinHesabha();
                                obj.Seryal = _Seryal_Befour;
                                if (!string.IsNullOrEmpty(txtTarikh.Text))
                                    obj.Tarikh = Convert.ToDateTime(txtTarikh.Text);
                                if (txtMablagh.Text != "0")
                                {
                                    obj.Mablagh = Convert.ToDecimal(txtMablagh.Text);
                                    obj.HesabMoinId1 = Convert.ToInt32(cmbHesabMoin1.EditValue);
                                    obj.HesabMoineName1 = cmbHesabMoin1.Text;
                                    obj.HesabMoinId2 = Convert.ToInt32(cmbHesabMoin2.EditValue);
                                    obj.HesabMoineName2 = cmbHesabMoin2.Text;
                                    obj.HesabTafziliId1 = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                                    obj.HesabTafziliName1 = cmbHesabTafzili1.Text;
                                    obj.HesabTafziliId2 = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                                    obj.HesabTafziliName2 = cmbHesabTafzili2.Text;
                                }
                                obj.TaghirSarmayeAvalye = chkTaghirSarmayeAvalye.Checked;
                                obj.Sharh = txtSharh.Text;
                                obj.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                                obj.ShomareSanad = _ShomareSanad_Befour;
                                obj.NoeSanadIndex = cmbNoeSanad.SelectedIndex;
                                obj.NoeSanadName = cmbNoeSanad.Text;
                                db.DaryaftPardakhtBinHesabhas.Add(obj);
                                //////////////////////////////////////////////////////////////////////////////////////////

                                AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
                                obj1.ShomareSanad = _ShomareSanad_Befour;
                                obj1.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
                                obj1.HesabMoinId = Convert.ToInt32(cmbHesabMoin1.EditValue);
                                obj1.HesabMoinCode = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId1).Code;
                                obj1.HesabMoinName = cmbHesabMoin1.Text; ;
                                obj1.HesabTafId = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                                obj1.HesabTafCode = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabTafziliId1).Code;
                                obj1.HesabTafName = cmbHesabTafzili1.Text;
                                obj1.Bed = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                                obj1.Sharh = txtSharh.Text;
                                obj1.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                                db.AsnadeHesabdariRows.Add(obj1);

                                //int _HesabMoinId2 = Convert.ToInt32(cmbHesabMoin2.EditValue);
                                //int _HesabTafziliId2 = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                                AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
                                obj2.ShomareSanad = _ShomareSanad_Befour;
                                obj2.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
                                obj2.HesabMoinId = Convert.ToInt32(cmbHesabMoin2.EditValue);
                                obj2.HesabMoinCode = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId2).Code;
                                obj2.HesabMoinName = cmbHesabMoin2.Text; ;
                                obj2.HesabTafId = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                                obj2.HesabTafCode = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabTafziliId2).Code;
                                obj2.HesabTafName = cmbHesabTafzili2.Text;
                                obj2.Bes = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                                obj2.Sharh = txtSharh.Text;
                                obj2.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                                db.AsnadeHesabdariRows.Add(obj2);
                                ///////////////////////////////////////////////////////////////////////////////
                                //////////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();
                                btnDisplayList_Click(null, null);

                                //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex;
                                gridControl1.Enabled = true;
                                ActiveButtons();
                                ClearControls();
                                InActiveControls();
                                En = EnumCED.Save;


                            }
                            else if (_chkTaghirSarmayeAvalye_Befour == false)
                            {

                                _Mablagh = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                                if (_chkTaghirSarmayeAvalyeAfter == true)
                                {
                                    //_Mablagh = Convert.ToDecimal(txtMablagh.Text);
                                    _CodeMoin1 = m.FirstOrDefault(f => f.Id == _HesabMoinId1).Code;
                                    _CodeMoin2 = m.FirstOrDefault(f => f.Id == _HesabMoinId2).Code;
                                    if (_CodeMoin1 == 7001)
                                    {
                                        var As = db.AazaSandoghs.FirstOrDefault(s => s.AllTafId == _HesabTafziliId1);
                                        if (As.BesAvali >= _Mablagh)
                                            As.BesAvali -= _Mablagh;
                                        else
                                        {
                                            XtraMessageBox.Show("مبلغ مانده سرمایه اولیه در تعریف اشخاص کمتر از مبلغ فعلی می باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;

                                        }
                                    }
                                    if (_CodeMoin2 == 7001)
                                    {
                                        var As = db.AazaSandoghs.FirstOrDefault(s => s.AllTafId == _HesabTafziliId2);
                                        As.BesAvali += _Mablagh;

                                    }

                                }

                                ///////////////////////////////////////////ویرایش سند فعلی///////////////////////////////////////
                                //int RowId = Convert.ToInt32(txtId.Text);
                                var q = db.DaryaftPardakhtBinHesabhas.FirstOrDefault(p => p.Id == RowId);
                                if (q != null)
                                {
                                    if (!string.IsNullOrEmpty(txtTarikh.Text))
                                        q.Tarikh = Convert.ToDateTime(txtTarikh.Text);
                                    if (txtMablagh.Text != "0")
                                    {
                                        q.Mablagh = Convert.ToDecimal(txtMablagh.Text);
                                        q.HesabMoinId1 = Convert.ToInt32(cmbHesabMoin1.EditValue);
                                        q.HesabMoineName1 = cmbHesabMoin1.Text;
                                        q.HesabMoinId2 = Convert.ToInt32(cmbHesabMoin2.EditValue);
                                        q.HesabMoineName2 = cmbHesabMoin2.Text;
                                        q.HesabTafziliId1 = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                                        q.HesabTafziliName1 = cmbHesabTafzili1.Text;
                                        q.HesabTafziliId2 = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                                        q.HesabTafziliName2 = cmbHesabTafzili2.Text;
                                    }
                                    q.TaghirSarmayeAvalye = chkTaghirSarmayeAvalye.Checked;
                                    q.Sharh = txtSharh.Text;
                                    q.NoeSanadIndex = cmbNoeSanad.SelectedIndex;
                                    q.NoeSanadName = cmbNoeSanad.Text;
                                    /////////////////////////////////////////////////////////////////////////////////////
                                    var q2 = db.AsnadeHesabdariRows.Where(f => f.ShomareSanad == q.ShomareSanad);
                                    if (q2.Count() > 0)
                                        db.AsnadeHesabdariRows.RemoveRange(q2);


                                    //_HesabMoinId1 = Convert.ToInt32(cmbHesabMoin1.EditValue);
                                    //int _HesabTafziliId1 = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                                    AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
                                    obj1.ShomareSanad = q.ShomareSanad;
                                    obj1.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
                                    obj1.HesabMoinId = Convert.ToInt32(cmbHesabMoin1.EditValue);
                                    obj1.HesabMoinCode = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId1).Code;
                                    obj1.HesabMoinName = cmbHesabMoin1.Text; ;
                                    obj1.HesabTafId = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                                    obj1.HesabTafCode = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabTafziliId1).Code;
                                    obj1.HesabTafName = cmbHesabTafzili1.Text;
                                    obj1.Bed = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                                    obj1.Sharh = txtSharh.Text;
                                    obj1.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                                    db.AsnadeHesabdariRows.Add(obj1);

                                    //int _HesabMoinId2 = Convert.ToInt32(cmbHesabMoin2.EditValue);
                                    //int _HesabTafziliId2 = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                                    AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
                                    obj2.ShomareSanad = q.ShomareSanad;
                                    obj2.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
                                    obj2.HesabMoinId = Convert.ToInt32(cmbHesabMoin2.EditValue);
                                    obj2.HesabMoinCode = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId2).Code;
                                    obj2.HesabMoinName = cmbHesabMoin2.Text; ;
                                    obj2.HesabTafId = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                                    obj2.HesabTafCode = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabTafziliId2).Code;
                                    obj2.HesabTafName = cmbHesabTafzili2.Text;
                                    obj2.Bes = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                                    obj2.Sharh = txtSharh.Text;
                                    obj2.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                                    db.AsnadeHesabdariRows.Add(obj2);
                                    ///////////////////////////////////////////////////////////////////////////////
                                    //if (_BeforEditchkTaghirSarmayeAvalye == false && chkTaghirSarmayeAvalye.Checked == true)
                                    //{
                                    //    //int _Moin1Id = Convert.ToInt32(cmbHesabMoin1.EditValue);
                                    //    // int _Moin1Id = Convert.ToInt32(cmbHesabMoin2.EditValue);
                                    //    _Mablagh = Convert.ToDecimal(txtMablagh.Text);
                                    //    var m = db.CodeMoins;
                                    //    _CodeMoin1 = m.FirstOrDefault(f => f.Id == _HesabMoinId1).Code;
                                    //    _CodeMoin2 = m.FirstOrDefault(f => f.Id == _HesabMoinId2).Code;
                                    //    if (chkTaghirSarmayeAvalye.Checked)
                                    //    {
                                    //        if (_CodeMoin1 == 7001)
                                    //        {
                                    //            int _AazaId = Convert.ToInt32(cmbHesabTafzili1.EditValue);
                                    //            var As = db.AazaSandoghs.FirstOrDefault(s => s.AllTafId == _AazaId);
                                    //            As.BesAvali -= _Mablagh;
                                    //        }
                                    //        if (_CodeMoin2 == 7001)
                                    //        {
                                    //            int _AazaId = Convert.ToInt32(cmbHesabTafzili2.EditValue);
                                    //            var As = db.AazaSandoghs.FirstOrDefault(s => s.AllTafId == _AazaId);
                                    //            As.BesAvali += _Mablagh;

                                    //        }
                                    //    }

                                    //}                                ///////////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();
                                    btnDisplayList_Click(null, null);

                                    //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridView1.RowCount > 0)
                                        gridView1.FocusedRowHandle = EditRowIndex;
                                    gridControl1.Enabled = true;
                                    ActiveButtons();
                                    ClearControls();
                                    InActiveControls();
                                    En = EnumCED.Save;
                                }
                                else
                                {
                                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                using (var db = new MyContext())
                {
                    try
                    {

                        int _HesabMoinCode = db.CodeMoins.FirstOrDefault(s => s.SandoghId == _SandoghId && s.Id == _HesabMoinId1).Code;
                        if ((_cmbNoeSanad == 1 || _cmbNoeSanad == 2) && _HesabMoinCode == 7001 && AllTafId > 0)
                        {

                            var p3 = db.AsnadeHesabdariRows.Where(f => f.HesabTafId == AllTafId && f.HesabMoinCode == 7001).AsParallel();
                            var q3 = p3.ToList();
                            if (q3.Count > 0)
                            {
                                foreach (var item in q3)
                                {
                                    if (item.Bed != null)
                                        SumBed += (decimal)item.Bed;
                                    else
                                        SumBes += (decimal)item.Bes;
                                }
                                MandeHesab = SumBed - SumBes;
                                if (MandeHesab == 0)
                                {
                                    if (XtraMessageBox.Show("با ثبت این سند مانده حساب سرمایه " + _NameAaza + " صفر میشود آیا شخص مورد نظر غیر فعال شود ؟", "پیغام ثبت ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                    {
                                        var q1 = db.VamPardakhtis.FirstOrDefault(s => s.IsTasviye == false && s.AazaId == AllTafId);
                                        var q5 = db.VamPardakhtis.Where(s => s.IsTasviye == false && s.ZameninName.Contains(_NameAaza));
                                        var q4 = db.CheckTazmins.FirstOrDefault(f => f.IsInSandogh == true && f.VamGerandeId == AllTafId);
                                        var p6 = db.AsnadeHesabdariRows.Where(f => f.HesabTafId == AllTafId && f.HesabMoinCode == 3001).AsParallel();
                                        var q6 = p6.ToList();
                                        var p7 = db.AsnadeHesabdariRows.Where(f => f.HesabTafId == AllTafId && f.HesabMoinCode == 4001).AsParallel();
                                        var q7 = p7.ToList();
                                        var p8 = db.AsnadeHesabdariRows.Where(f => f.HesabTafId == AllTafId && f.HesabMoinCode == 6003).AsParallel();
                                        var q8 = p8.ToList();

                                        if (q1 != null)
                                        {
                                            XtraMessageBox.Show("عضو مورد نظر وام تسویه نشده دارد لذا نمیتوان آنرا غیر فعال نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                        else if (q5.Count() > 0)
                                        {
                                            foreach (var item in q5)
                                            {
                                                XtraMessageBox.Show("عضو مورد نظر ضامن وام " + item.NameAaza + " است لذا نمیتوان آنرا غیر فعال نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                            return;
                                        }
                                        else if (q4 != null)
                                        {
                                            XtraMessageBox.Show("عضو مورد نظر نزد صندوق سند تضمینی دارد لذا نمیتوان آنرا غیر فعال نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                        else if (q6.Count > 0)
                                        {
                                            foreach (var item in q6)
                                            {
                                                if (item.Bed != null)
                                                    SumBed += (decimal)item.Bed;
                                                else
                                                    SumBes += (decimal)item.Bes;
                                            }
                                            MandeHesab = SumBed - SumBes;
                                            if (MandeHesab != 0)
                                            {
                                                XtraMessageBox.Show("حساب مساعده عضو مورد نظر مانده دارد لذا نمیتوان آنرا غیر فعال نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }
                                        }
                                        else if (q7.Count > 0)
                                        {
                                            foreach (var item in q7)
                                            {
                                                if (item.Bed != null)
                                                    SumBed += (decimal)item.Bed;
                                                else
                                                    SumBes += (decimal)item.Bes;
                                            }
                                            MandeHesab = SumBed - SumBes;
                                            if (MandeHesab != 0)
                                            {
                                                XtraMessageBox.Show("حساب بدهکاران عضو مورد نظر مانده دارد لذا نمیتوان آنرا غیر فعال نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }
                                        }
                                        else if (q8.Count > 0)
                                        {
                                            foreach (var item in q8)
                                            {
                                                if (item.Bed != null)
                                                    SumBed += (decimal)item.Bed;
                                                else
                                                    SumBes += (decimal)item.Bes;
                                            }
                                            MandeHesab = SumBed - SumBes;
                                            if (MandeHesab != 0)
                                            {
                                                XtraMessageBox.Show("حساب بستانکاران عضو مورد نظر مانده دارد لذا نمیتوان آنرا غیر فعال نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }
                                        }

                                        var qq1 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 3 && f.Id == AllTafId);
                                        qq1.IsActive = false;
                                        int _Id2 = qq1.Id2;

                                        var qq2 = db.AazaSandoghs.FirstOrDefault(f => f.GroupTafziliId == 3 && f.Id == _Id2);
                                        qq2.IsActive = false;
                                        db.SaveChanges();


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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gridControl1.Enabled = true;
            ActiveButtons();
            ClearControls();
            InActiveControls();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
            if (En == EnumCED.Save)
                btnCreate_Click(null, null);
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (btnDelete.Enabled == false)
            {
                btnDelete.Enabled = btnEdit.Enabled = gridView1.RowCount > 0 ? true : false;
            }
            if (gridView1.SelectedRowsCount > 0 && btnEdit.Visible == true)
            {
                //gridControl1.Enabled = false;
                //EditRowIndex = gridView1.FocusedRowHandle;
                //En = EnumCED.Edit;
                //InActiveButtons();
                //ActiveControls();
                cmbHesabMoin1.EditValue = cmbHesabMoin2.EditValue = 0;
                txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                txtSeryal.Text = gridView1.GetFocusedRowCellValue("Seryal").ToString();
                if (gridView1.GetFocusedRowCellValue("Tarikh") != null)
                    txtTarikh.Text = gridView1.GetFocusedRowCellValue("Tarikh").ToString().Substring(0, 10); ;
                txtMablagh.Text = gridView1.GetFocusedRowCellValue("Mablagh").ToString();
                cmbHesabMoin1.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabMoinId1"));
                cmbHesabTafzili1.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabTafziliId1"));
                cmbHesabMoin2.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabMoinId2"));
                cmbHesabTafzili2.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabTafziliId2"));
                txtSharh.Text = gridView1.GetFocusedRowCellValue("Sharh").ToString();
                cmbNoeSanad.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("NoeSanadIndex"));
                chkTaghirSarmayeAvalye.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("TaghirSarmayeAvalye"));

                //cmbNoeSanad.Focus();
            }

        }

        private void cmbHesabMoin1_Enter(object sender, EventArgs e)
        {
            cmbHesabMoin1.ShowPopup();
        }
        private void cmbHesabMoin2_Enter(object sender, EventArgs e)
        {
            cmbHesabMoin2.ShowPopup();
        }
        private void cmbHesabTafzili1_Enter(object sender, EventArgs e)
        {
            cmbHesabTafzili1.ShowPopup();
        }
        private void cmbHesabTafzili2_Enter(object sender, EventArgs e)
        {
            cmbHesabTafzili2.ShowPopup();
        }

        private void cmbHesabMoin1_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbHesabTafzili1();
            using (var db = new MyContext())
            {
                try
                {
                    int _Id1 = Convert.ToInt32(cmbHesabMoin1.EditValue);
                    int _Id2 = Convert.ToInt32(cmbHesabMoin2.EditValue);
                    var q = db.CodeMoins.FirstOrDefault(s => s.Id == _Id1);
                    if (q != null)
                    {
                        if (q.Code == 7001)
                        {
                            _CodeMoin1 = q.Code;
                            chkTaghirSarmayeAvalye.Visible = true;
                            if (_Id1 != _Id2)
                            {
                                chkTaghirSarmayeAvalye.Text = "کاهش سرمایه اولیه";
                            }
                            else
                            {
                                chkTaghirSarmayeAvalye.Text = "افزایش/کاهش سرمایه اولیه";
                            }
                        }
                        else if (_CodeMoin2 != 7001)
                        {
                            chkTaghirSarmayeAvalye.Visible = false;
                            chkTaghirSarmayeAvalye.Checked = false;
                        }

                    }
                    else
                    {
                        chkTaghirSarmayeAvalye.Visible = false;
                        chkTaghirSarmayeAvalye.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        int _CodeMoin2 = 0;
        int _CodeMoin1 = 0;
        private void cmbHesabMoin2_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbHesabTafzili2();
            using (var db = new MyContext())
            {
                try
                {
                    int _Id1 = Convert.ToInt32(cmbHesabMoin1.EditValue);
                    int _Id2 = Convert.ToInt32(cmbHesabMoin2.EditValue);
                    var q = db.CodeMoins.FirstOrDefault(s => s.Id == _Id2);

                    if (q != null)
                    {
                        if (q.Code == 7001)
                        {
                            _CodeMoin2 = q.Code;
                            chkTaghirSarmayeAvalye.Visible = true;
                            if (_Id2 != _Id1)
                            {
                                chkTaghirSarmayeAvalye.Text = "افزایش سرمایه اولیه";
                            }
                            else
                            {
                                chkTaghirSarmayeAvalye.Text = "افزایش/کاهش سرمایه اولیه";
                            }
                        }
                        else if (_CodeMoin1 != 7001)
                        {
                            chkTaghirSarmayeAvalye.Visible = false;
                            chkTaghirSarmayeAvalye.Checked = false;
                        }

                    }
                    else
                    {
                        chkTaghirSarmayeAvalye.Visible = false;
                        chkTaghirSarmayeAvalye.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void cmbNoeSanad_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
                cmbNoeSanad.ShowPopup();
        }

        private void txtMablagh_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelpClass1.AddZerooToTextBox(sender, e);

        }

        string FilePath1 = Application.StartupPath + @"\Report\Ghozareshat\";
        string FileName1 = "rptDP_BinHesabha.repx";
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(FilePath1 + FileName1))
            {
                if (gridView1.RowCount > 0)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            //string _TarikhDaryaft = gridView1.GetFocusedRowCellDisplayText("TarikhDaryaft").ToString().Substring(0, 10);
                            int _RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                            int _NoeSanadIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("NoeSanadIndex"));
                            var q = db.DaryaftPardakhtBinHesabhas.FirstOrDefault(f => f.Id == _RowId);
                            if (q != null)
                            {
                                XtraReport XtraReport1 = new XtraReport();
                                XtraReport1.LoadLayoutFromXml(FilePath1 + FileName1);
                                XtraReport1.Parameters["TarikhVSaat"].Value = DateTime.Now;
                                XtraReport1.Parameters["SandoghName"].Value = Fm.ribbonControl1.ApplicationDocumentCaption;
                                XtraReport1.Parameters["Logo_Co"].Value = Fm.pictureEdit1.Image;

                                string SharhSanad = string.Empty;
                                if (_NoeSanadIndex == 0 || _NoeSanadIndex == 1)
                                {
                                    String[] Text1 = new string[3];
                                    Text1[0] = "بدینوسیله طی سند شماره " + q.ShomareSanad.ToString() + " در مورخه " + q.Tarikh.ToString().Substring(0, 10);
                                    Text1[1] = " مبلغ " + q.Mablagh.ToString("N0") + " ";
                                    Text1[2] = q.NoeSanadIndex == 0 ? " از خانم / آقای " + q.HesabTafziliName2 + " دریافت گردید." : " به خانم / آقای " + q.HesabTafziliName1 + " پرداخت گردید.";
                                    SharhSanad = Text1[0] + Text1[1] + Text1[2];
                                }
                                else if (_NoeSanadIndex == 2)
                                {
                                    String[] Text1 = new string[3];
                                    Text1[0] = "بدینوسیله طی سند شماره " + q.ShomareSanad.ToString() + " در مورخه " + q.Tarikh.ToString().Substring(0, 10);
                                    Text1[1] = " مبلغ " + q.Mablagh.ToString("N0") + " ";
                                    Text1[2] = " از حساب " + q.HesabTafziliName2 + " به حساب" + q.HesabTafziliName1 + " انتقال پیدا کرد.";
                                    SharhSanad = Text1[0] + Text1[1] + Text1[2];
                                }
                                else if (_NoeSanadIndex == 3)
                                {
                                    String[] Text1 = new string[3];
                                    Text1[0] = "بدینوسیله طی سند شماره " + q.ShomareSanad.ToString() + " در مورخه " + q.Tarikh.ToString().Substring(0, 10);
                                    Text1[1] = " مبلغ " + q.Mablagh.ToString("N0") + " ";
                                    Text1[2] = "  بابت ثبت " + q.HesabTafziliName2 + " سند حسابداری صادر گردید.";
                                    SharhSanad = Text1[0] + Text1[1] + Text1[2];
                                }
                                else if (_NoeSanadIndex == 4)
                                {
                                    String[] Text1 = new string[3];
                                    Text1[0] = "بدینوسیله طی سند شماره " + q.ShomareSanad.ToString() + " در مورخه " + q.Tarikh.ToString().Substring(0, 10);
                                    Text1[1] = " مبلغ " + q.Mablagh.ToString("N0") + " ";
                                    Text1[2] = " بابت ثبت " + q.HesabTafziliName1 + " سند حسابداری صادر گردید.";
                                    SharhSanad = Text1[0] + Text1[1] + Text1[2];
                                }
                                else if (_NoeSanadIndex == 5)
                                {
                                    String[] Text1 = new string[3];
                                    Text1[0] = "بدینوسیله طی سند شماره " + q.ShomareSanad.ToString() + " در مورخه " + q.Tarikh.ToString().Substring(0, 10);
                                    Text1[1] = " مبلغ " + q.Mablagh.ToString("N0") + " ";
                                    Text1[2] = " بابت ثبت " + q.HesabTafziliName1 + " سند حسابداری صادر گردید.";
                                    SharhSanad = Text1[0] + Text1[1] + Text1[2];
                                }
                                XtraReport1.Parameters["SharhSanad"].Value = SharhSanad;

                                List<DaryaftPardakhtBinHesabha> List1 = new List<DaryaftPardakhtBinHesabha>();
                                List1.Add(q);
                                XtraReport1.DataSource = List1;
                                FrmPrinPreview FPP = new FrmPrinPreview();
                                FPP.documentViewer1.DocumentSource = XtraReport1;
                                FPP.ShowDialog();
                            }
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //XtraReport1.DataSource = HelpClass1.ConvettDatagridviewToDataSet(gridView1);

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

                }
            }
            else
            {
                HelpClass1.NewReportDesigner(FilePath1, FileName1);
            }
        }

        private void btnDesignReport_Click(object sender, EventArgs e)
        {
            HelpClass1.LoadReportDesigner(FilePath1, FileName1);
        }

        private void cmbHesabTafzili2_Leave(object sender, EventArgs e)
        {
            string _taf1 = cmbHesabTafzili1.Text;
            string _taf2 = cmbHesabTafzili2.Text;
            switch (cmbNoeSanad.Text)
            {
                case "دریافت":
                    {
                        txtSharh.Text = "دریافت  " + _taf1 + " از " + _taf2;
                        break;
                    }
                case "پرداخت":
                    {
                        txtSharh.Text = "پرداخت  " + _taf2 + " به " + _taf1;
                        break;
                    }
                case "انتقالی":
                    {
                        txtSharh.Text = "انتقال حساب از  " + _taf2 + " به " + _taf1;
                        break;
                    }
                case "درآمد":
                    {
                        txtSharh.Text = "بابت ثبت  " + _taf2;
                        break;
                    }
                case "هزینه":
                    {
                        txtSharh.Text = "بابت ثبت  " + _taf1;
                        break;
                    }
                case "اموال":
                    {
                        txtSharh.Text = "بابت ثبت  " + _taf1;
                        break;
                    }
            }
        }

        private void FrmDaryaftPardakhtBinHesabha_Shown(object sender, EventArgs e)
        {
            gridView1.MoveLast();
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


        //string _PardakhtKonandeName = string.Empty;
        //string _GroupHesab = string.Empty;
        //string Text1 = "دریافت";
        //string Text2 = " از ";
        //private void cmbPardakhtKonande_EditValueChanged(object sender, EventArgs e)
        //{
        //    txtMablagh_EditValueChanged(null, null);
        //}

        //private void txtMablagh_EditValueChanged(object sender, EventArgs e)
        //{
        //    _PardakhtKonandeName = cmbPardakhtKonande.Text;
        //    if (!string.IsNullOrEmpty(txtMablagh.Text) && txtMablagh.Text != "0")
        //    {
        //        using (var db = new MyContext())
        //        {
        //            try
        //            {
        //                if (Convert.ToInt32(cmbNameHesab.EditValue) != 0)
        //                {
        //                    int _HesabId = Convert.ToInt32(cmbNameHesab.EditValue);
        //                    var q = db.HesabBankis.FirstOrDefault(f => f.Id == _HesabId);
        //                    if (q != null)
        //                    {
        //                        _GroupHesab = " " + q.GroupHesab;
        //                        txtSharh.Text = Text1 + _GroupHesab + Text2 + _PardakhtKonandeName;
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
        //                    "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }

        //    }
        //    else
        //    {
        //        _GroupHesab = "";
        //        txtSharh.Text = Text1 + _GroupHesab + Text2 + _PardakhtKonandeName;
        //    }
        //}

        //private void cmbNameHesab_EditValueChanged(object sender, EventArgs e)
        //{
        //    txtMablagh_EditValueChanged(null, null);
        //}

    }

}