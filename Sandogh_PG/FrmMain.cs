﻿using DevExpress.XtraEditors;
using Nucs.JsonSettings;
using Nucs.JsonSettings.Fluent;
using Sandogh_PG;
using Sandogh_PG.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Net;

namespace Sandogh_PG
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //SettingsBag Settings { get; } = JsonSettings.Construct<SettingsBag>(AppVariable.fileName + @"\config.json").EnableAutosave().WithEncryption("asdjklasjdkajsd654654").LoadNow();
        SettingsBag Settings { get; } = JsonSettings.Construct<SettingsBag>(AppVariable.fileName + @"\config.json").EnableAutosave().LoadNow();
        public FrmMain()
        {
            InitializeComponent();

            try
            {
                #region کدهای مربوط به ذخیره تم های فرم اصلی برنامه 

                DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(skinRibbonGalleryBarItem1, true, true);
                skinRibbonGalleryBarItem1.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(skinRibbonGalleryBarItem1_GalleryItemClick);

                //try
                //{
                //    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(Settings[AppVariable.SkinName].ToString() ?? "The Bezier");

                //}
                //catch (Exception)
                //{

                //}

                #endregion کدهای مربوط به ذخیره تم های فرم اصلی برنامه 

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> FrmMain()" + "\n" + ex.Message,
                    "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnTarifSandogh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTarifSandogh fm = new FrmTarifSandogh(this);
            ActiveForm(fm);
        }

        private void btnTarifHesabBanki_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTarifHesabBanki fm = new FrmTarifHesabBanki(this);
            ActiveForm(fm);

        }

        private void btnTarifAaza_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTarifAaza_1 fm = new FrmTarifAaza_1(this);
            ActiveForm(fm);
            //fm.ShowDialog();

        }

        private void btnDaryaft1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDaryafti fm = new FrmDaryafti(this);
            //fm.lblUserId.Text = txtUserId.Caption;
            //fm.lblUserName.Text = txtUserName.Caption;
            fm.ShowDialog();
        }

        private void btnEetayVam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmListVamhayePardakhti fm = new FrmListVamhayePardakhti(this);
            fm.ShowDialog();
        }

        public bool Dastresi()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _UserId = Convert.ToInt32(txtUserId.Caption);
                    //btnTanzimat.Visibility = btnAllDataDelete.Visibility = _UserId == 2 ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                    //rpgTanzimat.Visible = _UserId == 2 ? true : false;
                    if (_UserId == 2 || _UserId == 3)
                    {
                        return true;
                    }
                    else
                    {
                        XtraMessageBox.Show("فقط مدیر صندوق اجازه دسترسی به این قسمت را دارد",
                                                    "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + ex.Message,
                        "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return true;
            }

        }
        private void btnTanzimat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Dastresi())
            {
                FrmTanzimat fm = new FrmTanzimat(this);
                ActiveForm(fm);

            }
        }

        private void btnTarifSalMali_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTarifSalMali fm = new FrmTarifSalMali();
            ActiveForm(fm);
        }
        int _SId = 0;
        public string _MadarBoardSerial = string.Empty;
        public void FrmMain_Load(object sender, EventArgs e)
        {
            // فراخوانی پوسته برنامه از مسیر دایرکتوری %appdata%
            // try
            //{
            //    int i= Convert.ToInt32(IndexNameDataBase.Caption);
            //    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(Settings[AppVariable.SkinName[i]].ToString() ?? "DevExpress Style");

            //}
            //catch (Exception)
            //{

            //}
            using (var db = new MyContext())
            {
                try
                {
                    int i = Convert.ToInt32(Settings[AppVariable.DefaltIndexCmbNameSandogh]);
                    Settings[AppVariable.VersionNumber[i]] = Application.ProductVersion.ToString();
                    HelpClass1.SwitchToPersianLanguage();
                    HelpClass1.SetRegionAndLanguage();
                    //Settings[AppVariable.IsChangeDbName] = "False";
                    string _DeviceID = HelpClass1.GetMadarBoardSerial();
                    string _dataBaseName = db.Database.Connection.Database;

                    var q5 = db.AllowedDevises.FirstOrDefault(s => s.DeviceID == _DeviceID && s.DataBaseName == _dataBaseName);
                    var q = db.TarifSandoghs.FirstOrDefault(s => s.IsDefault == true);
                    if (q != null && q5 != null)
                    {
                        IDSandogh.Caption = q.Id.ToString();
                        ribbonControl1.ApplicationDocumentCaption = q.NameSandogh;
                        _SId = Convert.ToInt32(IDSandogh.Caption);
                        if (q.PicBackground != null)
                        {
                            MemoryStream ms = new MemoryStream(q.PicBackground);
                            pictureEdit3.Image = Image.FromStream(ms);
                            img1 = pictureEdit3.Image;
                        }
                        if (q.Pictuer != null)
                        {
                            MemoryStream ms = new MemoryStream(q.Pictuer);
                            pictureEdit1.Image = Image.FromStream(ms);
                            //img1 = pictureEdit1.Image;
                        }

                        //else
                        //    pictureEdit3.Image = null;
                    }

                    var q1 = db.SalMalis.FirstOrDefault(s => s.IsDefault == true);
                    if (q1 != null)
                    {
                        IDSalMali.Caption = q1.Id.ToString();
                    }


                    int yyyy1 = Convert.ToInt32(DateTime.Now.ToString().Substring(0, 4));
                    int MM1 = Convert.ToInt32(DateTime.Now.ToString().Substring(5, 2));
                    int dd1 = Convert.ToInt32(DateTime.Now.ToString().Substring(8, 2));
                    Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                    int yyyy2 = Convert.ToInt32(q5.GarantiEndData.ToString().Substring(0, 4));
                    int MM2 = Convert.ToInt32(q5.GarantiEndData.ToString().Substring(5, 2));
                    int dd2 = Convert.ToInt32(q5.GarantiEndData.ToString().Substring(8, 2));
                    Mydate d2 = new Mydate(yyyy2, MM2, dd2);
                    Color r = btnTamdidGaranti.ItemAppearance.Normal.ForeColor;

                    if (q5.VersionType == "Orginal")
                    {
                        EtmamGaranti.Caption = q5.GarantiEndData != null ? "اتمام مدت پشتیبانی : " + q5.GarantiEndData.ToString().Substring(0, 10) : "1397/01/01";
                        if (d2 < d1)
                        {
                            if (q5.IsGaranti == true)
                            {
                                //q.IsGaranti = false;
                                q5.IsGaranti = false;
                                db.SaveChanges();
                            }
                            EtmamGaranti.ItemAppearance.Normal.ForeColor = Color.Red;
                        }
                        else
                        {
                            EtmamGaranti.ItemAppearance.Normal.ForeColor = r;
                        }
                    }
                    else if (q5.VersionType == "Demo")
                    {
                        if (q5.IsActive == true)
                        {
                            var w = db.AsnadeHesabdariRows.Count();
                            if (w >= 200)
                            {
                                //q.AppActived = false;
                                if (q5.IsActive == true)
                                {
                                    q5.IsActive = false;
                                }
                            }

                            //q.AppActived = false;
                            //q5.IsGaranti = false;
                            db.SaveChanges();
                            //EtmamGaranti.ItemAppearance.Normal.ForeColor = Color.Red;

                        }
                        EtmamGaranti.Visibility = btnTamdidGaranti.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    else
                    {
                        EtmamGaranti.Visibility = btnTamdidGaranti.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    string _VersionName = q5.VersionType == "Orginal" ? "اصلی" : q5.VersionType == "Demo" ? "آزمایشی" : "نمایشی";
                    barStaticItem4.Caption = "نسخه " + _VersionName + " برنامه :";
                    //EtmamGaranti.Visibility = q5.VersionType == "Orginal" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;

                    /////////////////////////////////اصلاح دیتابیس///////////////////////////////////
                    //var q11 = db.VamPardakhtis.Where(s => s.chkEditSdoorSanad == false).AsParallel();
                    //if (q11 != null)
                    //{
                    //    foreach (var item in q11)
                    //    {
                    //        //var q21 = db.RizeAghsatVams.Where(s => s.VamPardakhtiId == item.Id && s.VamPardakhti1.IsTasviye == true).AsParallel();

                    //        //if (q21.Count() > 0)
                    //        {
                    //            item.chkEditSdoorSanad = true;
                    //        }

                    //        //else if (q21.FirstOrDefault(s => s.AazaId == item.AllTafId && s.IsTasviye == true) != null)
                    //        //{
                    //        //    var q51 = db.RizeAghsatVams.Where(s => s.AazaId == item.AllTafId && s.VamPardakhti1.IsTasviye == true).Max(s => s.TarikhDaryaft);
                    //        //    item.TarikhTasviyeVam = Convert.ToDateTime(q51);
                    //        //}
                    //        //else if (q21.FirstOrDefault(s => s.AazaId == item.AllTafId && s.IsTasviye == false) != null)
                    //        //{
                    //        //    item.TarikhTasviyeVam = item.TarikhOzviat;
                    //        //}

                    //    }
                    //    db.SaveChanges();

                    //    //}
                    //}
                    /////////////////////////////////اصلاح دیتابیس///////////////////////////////////
                    //var q12 = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SId);
                    //if (q12 != null)
                    //{
                    //    if (q12.Moin2DefaultId == 0 || q12.Moin2DefaultId == 0 )
                    //    {
                    //        var cm = db.CodeMoins.ToList();
                    //        var at = db.AllHesabTafzilis.Where(s=>s.GroupTafzili1.Code==4|| s.GroupTafzili1.Code == 5).ToList();
                    //        q12.Moin2DefaultId = cm.FirstOrDefault(s => s.Code == 8001).Id;
                    //        q12.Moin3DefaultId = cm.FirstOrDefault(s => s.Code == 9001).Id;
                    //        q12.Tafsili2DefaultId = at.FirstOrDefault(s => s.Code == 1000001).Id;
                    //        q12.Tafsili3DefaultId = at.FirstOrDefault(s => s.Code == 2000001).Id;
                    //    }
                    //    db.SaveChanges();

                    //    //}
                    //}

                    /////////////////////////////////اصلاح دیتابیس///////////////////////////////////
                    //var q11 = db.VamPardakhtis.Where(s => s.TarikhTasviyeVam == null && s.IsTasviye == true).AsParallel();
                    //if (q11 != null)
                    //{
                    //    foreach (var item in q11)
                    //    {
                    //        var q21 = db.RizeAghsatVams.Where(s => s.VamPardakhtiId == item.Id && s.VamPardakhti1.IsTasviye == true).AsParallel();

                    //        if (q21.Count() > 0)
                    //        {
                    //            item.TarikhTasviyeVam = q21.Max(s => s.TarikhDaryaft);
                    //        }

                    //        //else if (q21.FirstOrDefault(s => s.AazaId == item.AllTafId && s.IsTasviye == true) != null)
                    //        //{
                    //        //    var q51 = db.RizeAghsatVams.Where(s => s.AazaId == item.AllTafId && s.VamPardakhti1.IsTasviye == true).Max(s => s.TarikhDaryaft);
                    //        //    item.TarikhTasviyeVam = Convert.ToDateTime(q51);
                    //        //}
                    //        //else if (q21.FirstOrDefault(s => s.AazaId == item.AllTafId && s.IsTasviye == false) != null)
                    //        //{
                    //        //    item.TarikhTasviyeVam = item.TarikhOzviat;
                    //        //}

                    //    }
                    //    db.SaveChanges();

                    //    //}
                    //}
                    ////////////////////////////////////////////////////////////////////

                    /////////////////////////////////اصلاح دیتابیس///////////////////////////////////
                    //
                    //var fo = Convert.ToDateTime("1278/10/11");
                    //var q12 = db.AazaSandoghs.Where(s => s.TarikhTasviyeVam == null || s.TarikhTasviyeVam == fo).AsParallel();
                    ////var q12 = db.AazaSandoghs.FirstOrDefault().TarikhTasviyeVam.ToString().Substring(0, 10);
                    ////if (q12== "1278/10/11")
                    ////{

                    ////}
                    //if (q12.Count() > 0)
                    //{
                    //    foreach (var item in q12)
                    //    {
                    //        item.TarikhTasviyeVam = item.TarikhOzviat;
                    //    }
                    //    db.SaveChanges();
                    //}
                    ////////////////////////////////////////////////////////////////////

                    ////// دستور مربوط به فرم یادآوری روزانه
                    var q3 = db.Tanzimats.Any(f => f.checkEdit3 == true);
                    if (q3)
                    {
                        FrmYadavari fm = new FrmYadavari();
                        {
                            DateTime _DateTimeNow = DateTime.Now;
                            var q7 = db.RizeAghsatVams.Where(f => f.ShomareSanad == 0 && f.TarikhSarresid < _DateTimeNow).ToList();
                            if (q7.Count > 0)
                                fm.rizeAghsatVamsBindingSource.DataSource = q7.OrderBy(f => f.TarikhSarresid);
                            else
                                fm.rizeAghsatVamsBindingSource.DataSource = null;
                            //////////////////////////////////////////////////////////////
                            //int yyyy1 = Convert.ToInt32(DateTime.Now.ToString().Substring(0, 4));
                            //int MM1 = Convert.ToInt32(DateTime.Now.ToString().Substring(5, 2));
                            //int dd1 = Convert.ToInt32(DateTime.Now.ToString().Substring(8, 2));
                            //Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                            d1.DecrementMonth();
                            DateTime _DateTimeNow_1 = Convert.ToDateTime(d1.ToString());
                            List<HaghOzviat> List = new List<HaghOzviat>();
                            var q2 = db.AllHesabTafzilis.Where(s => s.GroupTafziliId == 3 && s.IsActive == true).ToList();
                            if (q2.Count > 0)
                            {
                                foreach (var item in q2)
                                {
                                    var q8 = db.HaghOzviats.Where(f => f.AazaId == item.Id).ToList();
                                    //var q1 = db.HaghOzviats.Where(f => f.Tarikh < _DateTimeNow_1);
                                    if (q8.Count > 0)
                                    {
                                        var q9 = q8.Max(f => f.Tarikh);
                                        if (q9 <= _DateTimeNow_1)
                                        {
                                            HaghOzviat obj = new HaghOzviat();
                                            obj.Id = item.Id;
                                            obj.NameAaza = item.Name;
                                            obj.Tarikh = q9;
                                            //obj.Tarikh =Convert.ToDateTime(q3.ToString().Substring(0,10));
                                            List.Add(obj);
                                        }
                                    }

                                }
                            }

                            if (List.Count > 0)
                                fm.haghOzviatsBindingSource.DataSource = List.OrderBy(f => f.Tarikh);
                            else
                                fm.haghOzviatsBindingSource.DataSource = null;
                        }

                        if (fm.rizeAghsatVamsBindingSource.DataSource != null || fm.haghOzviatsBindingSource.DataSource != null)
                            fm.ShowDialog();
                    }
                    #region MyRegion
                    //Application.OpenForms["FrmYadavari"].Activate();
                    //string _NameDataBase = HelpClass1.EncryptText(NameDataBase.Caption);
                    //var p = db.AllowedDataBasess.FirstOrDefault(s => s.DataBaseName == _NameDataBase);

                    //_MadarBoardSerial = HelpClass1.EncryptText(HelpClass1.GetMadarBoardSerial());
                    //// اجرای دستور مقایسه شماره سریال ماردبرد سیستم با دیتابیس
                    //if (p.DeviceID == null)
                    //{

                    //    p.DeviceID = _MadarBoardSerial;
                    //    db.SaveChanges();
                    //}
                    //else
                    //{
                    //    if (_MadarBoardSerial != p.DeviceID)
                    //    {
                    //        if (XtraMessageBox.Show("با توجه به اینکه اطلاعات سیستم دیگری روی این سیستم بازیابی شده است" + "/n" + "لاینسس قفل برنامه قابل اجرا نیست جهت اجرای مجدد برنامه لطفاً با پشتیبانی تماس حاصل فرمایید", "پیغام مجوز اجرای نرم افزار", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    //        {
                    //            this.Enabled = false;
                    //            FrmPassword frm = new FrmPassword(this);
                    //            frm.txtPassword.Focus();
                    //            frm.ShowDialog();
                    //        }
                    //    }
                    //}

                    ////////////////////////////////////////////////////////////////////////////////
                    /// درتاریخ 99/04/19 این کدها غیر فعال شدند

                    //var q4 = db.CodingDaramadVHazines.Where(f => f.AllTafId == 0).ToList();
                    //if (q4.Count > 0)
                    //{
                    //    foreach (var item in q4)
                    //    {
                    //        item.AllTafId = db.AllHesabTafzilis.FirstOrDefault(f => f.Code == item.Code).Id;
                    //    }
                    //    db.SaveChanges();
                    //}

                    //var q5 = db.CodingAmvals.Where(f => f.AllTafId == 0).ToList();
                    //if (q5.Count > 0)
                    //{
                    //    foreach (var item in q5)
                    //    {
                    //        item.AllTafId = db.AllHesabTafzilis.FirstOrDefault(f => f.Code == item.Code).Id;
                    //    }
                    //    db.SaveChanges();
                    //}


                    /////////////////////////////////////////بعد از یکبار اجرا حذف شود ///////////////////////////////////////////
                    //var q6 = db.AazaSandoghs.Where(f => f.AllTafId == 0).ToList();
                    //if (q6.Count > 0)
                    //{
                    //    foreach (var item in q6)
                    //    {
                    //        item.AllTafId = db.AllHesabTafzilis.FirstOrDefault(f => f.Code == item.Code).Id;
                    //    }
                    //    db.SaveChanges();
                    //}

                    //var q7 = db.HesabBankis.Where(f => f.AllTafId == 0).ToList();
                    //if (q7.Count > 0)
                    //{
                    //    foreach (var item in q7)
                    //    {
                    //        item.AllTafId = db.AllHesabTafzilis.FirstOrDefault(f => f.Code == item.Code).Id;
                    //    }
                    //    db.SaveChanges();
                    //}
                    /////////////////////////////////////////بعد از یکبار اجرا حذف شود ///////////////////////////////////////////
                    #endregion                ////////////////////////////////////////////////////////////////////////////////

                    var d = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SId);
                    if (d != null)
                    {
                        btnNobatBandiVam.Visibility = d.checkEdit6 == true && d.NoeRezervIndex != -1 ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> FrmMain_Load()" + "\n" + ex.Message,
                        "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void btnDayaftCheckTazmin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDaryaftCheckTazmin fm = new FrmDaryaftCheckTazmin(this);
            ActiveForm(fm);
        }

        private void btnOdateCheckTazmin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmOdatCheckTazmin fm = new FrmOdatCheckTazmin(this);
            ActiveForm(fm);
        }

        private void btnDaryaftNaghdiVBanki_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void btnPardakhtNaghdiVBanki_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void btnCodingDaramadVHazine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmCodingDaramadVHazine fm = new FrmCodingDaramadVHazine(this);
            ActiveForm(fm);
        }

        private void btnSabtDaramad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void btnSabtHazine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnEnteghalatHesabBanki_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void btnEnteghalatHesabAaza_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnEnteghalatHesabDaramadVHazine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDaftarRozname_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDaftarRozname fm = new FrmDaftarRozname(this);
            ActiveForm(fm);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDaryaftPardakhtBinHesabha fm = new FrmDaryaftPardakhtBinHesabha(this);
            ActiveForm(fm);

        }

        private void btnSoratHesabTafzili_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSoratHesabTafzili fm = new FrmSoratHesabTafzili(this);
            ActiveForm(fm);

        }

        private void btnCalculate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HelpClass1.StartCalculater();
        }

        private void btnBackupRestore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmBackupRestore fm = new FrmBackupRestore(this);
            fm.ShowDialog();
        }
        Image img1;

        private void btnChangeBackground_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraOpenFileDialog XtraopenFileDialog1 = new XtraOpenFileDialog();
            XtraopenFileDialog1.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";

            using (var db = new MyContext())
            {
                try
                {
                    if (XtraopenFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        img1 = Image.FromFile(XtraopenFileDialog1.FileName);
                        this.pictureEdit3.Image = img1;
                        //this.pictureEdit3.Tag = openFileDialog1.FileName;
                        int _SId = Convert.ToInt32(IDSandogh.Caption);
                        var q = db.TarifSandoghs.FirstOrDefault(f => f.Id == _SId);
                        if (q != null)
                        {
                            MemoryStream ms = new MemoryStream();
                            img1.Save(ms, pictureEdit3.Image.RawFormat);
                            byte[] myarrey = ms.GetBuffer();
                            q.PicBackground = myarrey;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        if (XtraMessageBox.Show("آیا عکس پس زمینه حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            pictureEdit3.Image = null;
                            int _SId = Convert.ToInt32(IDSandogh.Caption);
                            var q = db.TarifSandoghs.FirstOrDefault(f => f.Id == _SId);
                            if (q != null)
                            {
                                q.PicBackground = null;
                                db.SaveChanges();
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> btnChangeBackground_ItemClick()" + "\n" + ex.Message,
                        "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnCalling_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmCalling_1 fm = new FrmCalling_1();
            fm.ShowDialog();
        }

        private void btnListKarbaran_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmListKarbaran fm = new FrmListKarbaran(this);
            fm.ShowDialog();
        }

        private void btnYadavari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmYadavari fm = new FrmYadavari();
            fm.ShowDialog();
        }

        private void btnTarazname_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTarazname frm = new FrmTarazname(this);
            ActiveForm(frm);
        }

        private void skinRibbonGalleryBarItem1_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            try
            {
                // int i = Convert.ToInt32(IndexNameDataBase.Caption);
                Settings[AppVariable.SkinName[0]] = DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveSkinName;
                Settings.Save();
                Settings.Dispose();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> skinRibbonGalleryBarItem1_GalleryItemClick()" + "\n" + ex.Message,
                    "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //using (var context = new MyContext())
                //{
                //    string _NameDataBase = NameDataBase.Caption;
                //    //string command = "ALTER DATABASE Sandogh_PG SET OFFLINE WITH ROLLBACK IMMEDIATE " +
                //    //                   " RESTORE DATABASE Sandogh_PG FROM DISK='" + txtSelectFile.Text + "' WITH REPLACE " +
                //    //                    "ALTER DATABASE Sandogh_PG SET ONLINE";
                //    //string command = "ALTER DATABASE " + cmbNameDataBaseSandogh.Text + " SET OFFLINE WITH ROLLBACK IMMEDIATE " +
                //    //                 "ALTER DATABASE " + cmbNameDataBaseSandogh.Text + " SET ONLINE";
                //    //string command = " ALTER DATABASE " + cmbNameDataBaseSandogh.Text + " SET ONLINE";
                //    string command = "DECLARE	@Spid INT DECLARE @ExecSQL VARCHAR(255) DECLARE KillCursor CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY " +
                //                     "FOR SELECT DISTINCT SPID FROM    MASTER..SysProcesses WHERE DBID = DB_ID('" + _NameDataBase + "') OPEN KillCursor " +
                //                     "--Grab the first SPID FETCH   NEXT FROM    KillCursor INTO    @Spid WHILE	@@FETCH_STATUS = 0 BEGIN " +
                //                     "SET     @ExecSQL = 'KILL ' + CAST(@Spid AS VARCHAR(50)) EXEC(@ExecSQL) -- Pull the next SPID FETCH NEXT FROM KillCursor INTO @Spid END " +
                //                     "CLOSE   KillCursor DEALLOCATE  KillCursor " /*+
                //                     "ALTER DATABASE " + _NameDataBase + " SET ONLINE"*/;
                //    context.Database.CommandTimeout = 360;
                //    context.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, command);
                //}

                //SqlConnection.ClearAllPools();
                //Application.Exit();
                //Application.ExitThread();

                if (!string.IsNullOrEmpty(FilePath))
                {
                    foreach (var file in Directory.GetFiles(FilePath, "*.tmp", SearchOption.AllDirectories))
                    {
                        File.Delete(file);
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> FrmMain_FormClosed()" + "\n" + ex.Message,
                    "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSoratSoodVZiyan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSodVZian frm = new FrmSodVZian(this);
            ActiveForm(frm);
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        var q = db.HesabBankis.FirstOrDefault(f => f.IsDefault);
                        if (q != null)
                        {
                            MojodiSandogh.Visibility = MojodiSandogh.Visibility == DevExpress.XtraBars.BarItemVisibility.Never ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                            var q1 = db.AllHesabTafzilis.FirstOrDefault(f => f.Code == q.Code);
                            if (q1 != null)
                            {
                                _IdHesab = q1.Id;
                                //DateTime _Date1 = Convert.ToDateTime("1499/04/21");
                                //DateTime _Date2 = Convert.ToDateTime("1400/04/22");
                                var q3 = db.AsnadeHesabdariRows.Where(f => f.HesabTafId == q1.Id).ToList();
                                if (q3.Count > 0)
                                {
                                    decimal bed = Convert.ToDecimal(q3.Sum(f => f.Bed));
                                    decimal bes = Convert.ToDecimal(q3.Sum(f => f.Bes));
                                    decimal Mande = bed - bes;
                                    MojodiSandogh.Caption = "موجودی صندوق/بانک : " + Mande.ToString("###,###,###,###,###") + " ";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> FrmMain_KeyDown()" + "\n" + ex.Message,
                            "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        int _IdHesab = 0;
        private void MojodiSandogh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSoratHesabTafzili frm = new FrmSoratHesabTafzili(this);
            ActiveForm(frm);
            frm.cmbHesabTafzili.ClosePopup();
            frm.cmbHesabTafzili.EditValue = _IdHesab;
        }

        bool IsDataDelete = false;
        public bool IsOkDelete = false;
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Dastresi())
            {
                try
                {
                    if (XtraMessageBox.Show("آیا همه اطلاعات ثبت شده حذف گردد ؟", "پیغام حذف کلیه اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (XtraMessageBox.Show("آیا برای انجام اینکار مطمئن هستید ؟", "پیغام حذف کلیه اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            FrmShenaseVRamz Fm = new FrmShenaseVRamz(this);
                            Fm.ShowDialog();
                            if (IsOkDelete)
                            {
                                using (var db = new MyContext(SetInitialize.DropCreateDatabaseAlways))
                                {
                                    db.Database.Initialize(true);
                                    // XtraMessageBox.Show("کلیه اطلاعات ثبت شده با موفقیت حذف گردید و نرم افزار مجدداً راه اندازی خواهد شد", "پیغام", MessageBoxButtons.OK);
                                    XtraMessageBox.Show("کلیه اطلاعات ثبت شده با موفقیت حذف گردید لطفا برنامه را مجدداً اجرا کنید", "پیغام", MessageBoxButtons.OK);
                                    IsDataDelete = true;
                                    //Application.Restart();
                                    Application.Exit();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> barButtonItem3_ItemClick()" + "\n" + ex.Message,
                        "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void btnMandeAshkhas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmMandeAshkhas frm = new FrmMandeAshkhas(this);
            frm._SandoghName = ribbonControl1.ApplicationDocumentCaption;
            frm.ShowDialog();

        }

        public void btnTamdidGaranti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmPassword1 frm = new FrmPassword1(this);
            frm.Text = "تمدید مدت پشتیبانی";
            frm.ShowDialog();

        }

        private void EtmamGaranti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btnTamdidGaranti.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
            {
                btnTamdidGaranti_ItemClick(null, null);
            }
        }

        private void OpenFilWord()
        {
            //Document doc = new Document();
            //doc.LoadFromFile(FilePath + @"\Gharardade_Org.doc",FileFormat.Doc);
            try
            {
                Word.Application ap = new Word.Application();
                ap.Visible = true;
                object miss = Missing.Value;
                //object path = Application.StartupPath + @"\Report\DarkhastVam\DarkhastVam.doc";
                object path = FilePath + @"\"+DarkhastVam+"_Temp.doc";
                object readOnly = false;
                object isVisible = true;
                Word.Document doc = new Word.Document();
                doc = ap.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref isVisible, ref miss, ref miss, ref miss, ref miss);
                doc.Activate();
                //Word.Application ap = new Word.Application();
                //Word.Document document = ap.Documents.Open(FilePath + @"\Gharardade_Temp.doc",);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> OpenFilWord()" + "\n" + ex.Message,
                    "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        string NameSandogh = string.Empty;

        public void GetInfoForWord()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int IdSandogh = Convert.ToInt32(IDSandogh.Caption);
                    var q4 = db.TarifSandoghs.FirstOrDefault(f => f.Id == IdSandogh);
                    NameSandogh = q4 != null && !string.IsNullOrEmpty(q4.NameSandogh) ? q4.NameSandogh : "..............................";

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> GetInfoForWord()" + "\n" + ex.Message,
                        "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        public static void KillProcess(string name)
        {
            try
            {
                Process[] pr = Process.GetProcessesByName(name);

                foreach (Process prs in pr)
                {
                    if (prs.ProcessName.ToLower() == name)
                    {
                        prs.Kill();
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> KillProcess()" + "\n" + ex.Message,
                    "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FindAndReplace(Word.Application wordApp, object findText, object replaceText)
        {
            try
            {
                object matchCase = true;
                object matchWholeWord = true;
                object matchWildCards = false;
                object matchSoundsLike = false;
                object matchAllWordForms = false;
                object forward = true;
                object format = false;
                object matchKashida = false;
                object matchDiacritics = false;
                object matchAlefHamza = false;
                object matchControl = false;
                object read_only = false;
                object visible = true;
                object replace = 2;
                object wrap = 1;
                wordApp.Selection.Find.Execute(ref findText, ref matchCase,
                    ref matchWholeWord, ref matchWildCards, ref matchSoundsLike,
                    ref matchAllWordForms, ref forward, ref wrap, ref format,
                    ref replaceText, ref replace, ref matchKashida,
                            ref matchDiacritics,
                    ref matchAlefHamza, ref matchControl);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> FindAndReplace()" + "\n" + ex.Message,
                    "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string FilePath = string.Empty;
        string DarkhastVam = string.Empty;
        public void SetInFoToWord()
        {
            using (var db = new MyContext())
            {
                try
                {
                    FilePath = Application.StartupPath + @"\Report\DarkhastVam";
                    //  Just to kill WINWORD.EXE if it is running
                    KillProcess("winword");
                    //  copy letter format to temp.doc
                    File.Copy(FilePath + @"\"+DarkhastVam+"_Org.doc", FilePath + @"\"+DarkhastVam+"_Temp.doc", true);
                    //File.Copy(@"D:\Kamal Projects\Sandogh\Sandogh TG N1\Sandogh_PG\Sandogh_PG\bin\Debug\Report\Gharardade.docx", "c:\\temp.docx", true);
                    //File.Copy("D:\\Gharardade.docx", "D:\\temp.doc", true);
                    //  create missing object
                    object missing = Missing.Value;
                    //  create Word application object
                    Word.Application wordApp = new Word.Application();
                    //  create Word document object
                    Word.Document aDoc = null;
                    //  create & define filename object with temp.doc
                    object filename = FilePath + @"\"+DarkhastVam+"_Temp.doc";
                    //  if temp.doc available
                    if (File.Exists((string)filename))
                    {
                        object readOnly = false;
                        object isVisible = false;
                        //  make visible Word application
                        wordApp.Visible = false;
                        //  open Word document named temp.doc
                        aDoc = wordApp.Documents.Open(ref filename, ref missing,
                                                      ref readOnly, ref missing, ref missing, ref missing,
                                                      ref missing, ref missing, ref missing, ref missing,
                                                      ref missing, ref isVisible, ref missing, ref missing,
                                                      ref missing, ref missing);
                        aDoc.Activate();
                        //  Call FindAndReplace()function for each change
                        this.FindAndReplace(wordApp, "<NameSandogh>", NameSandogh.Trim());
                        aDoc.Save();
                        KillProcess("winword");

                    }
                    else
                        XtraMessageBox.Show("فایل  موقت Gharardade_Temp یافت نشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> SetInFoToWord()" + "\n" + ex.Message,
                        "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnMabaleghGhabelDaryaft_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmMabaleghGhabelDaryaft frm = new FrmMabaleghGhabelDaryaft(this);
            frm._SandoghName = ribbonControl1.ApplicationDocumentCaption;
            frm.ShowDialog();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms["FrmBackupRestore"] == null && IsDataDelete == false)
                if (Application.OpenForms["FrmLogin1"] == null)
                    if (Application.OpenForms["FrmAppRegister"] == null)
                        HelpClass1.FrmMain_FormClosing(sender, e);
        }

        private void btnListHesabMoin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmCodingDaramadVHazine fm = new FrmCodingDaramadVHazine(this);
            fm.Text = "لیست حسابهای معین";
            fm.Name = "ListHesabMoin";
            fm.labelControl6.Visible = false;
            fm.cmbGroupHesab.Visible = false;
            fm.btnCreate.Visible = false;
            fm.btnDelete.Visible = false;
            fm.btnSaveNext.Visible = false;
            fm.btnDisplyNotActiveList.Visible = false;
            fm.btnAdvancedSearch.Visible = false;
            fm.btnPrintPreview.Visible = false;
            fm.btnPrint.Visible = false;
            fm.labelControl2.Visible = false;
            fm.chkIsActive.Visible = false;
            fm.gridView1.Columns["GroupName"].Visible = false;
            fm.gridView1.Columns["IsActive"].Visible = false;
            fm.gridView1.Columns["HesabName"].Width = 700;
            fm.gridView1.Columns["HesabName"].FieldName = "Name";
            ActiveForm(fm);

        }

        private void NameDataBase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmLogin1 frm = new FrmLogin1();
            frm.ShowDialog();
        }

        public void btnSupportSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NameDataBase_ItemClick(null, null);
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    Settings.Save();
                    Settings.Dispose();

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> FrmMain_Shown()" + "\n" + ex.Message,
                        "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnDaryaft2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("لطفاً قبل از انجام عملیات فوق از اطلاعات فعلی بکاپ گرفته شود \n" + "آیا مایل به اینکار هستید؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (dr == DialogResult.Yes)
            {
                btnBackupRestore_ItemClick(null, null);
            }
            else
            {
                FrmDaryafti2 fm = new FrmDaryafti2(this);
                //fm.lblUserId.Text = txtUserId.Caption;
                //fm.lblUserName.Text = txtUserName.Caption;
                fm.ShowDialog();
            }
        }

        private void BtnRepairDataBase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    ///////////// بررسی اسناد حسابداری با مرجع داده ها ////////////////////
                    List<int> List1 = new List<int>();
                    List<int> List_1 = new List<int>();
                    //var AsnadHesabdari = db.AsnadeHesabdariRows.ToList();
                    //var AazaSandogh = db.AazaSandoghs.ToList();
                    //var VamPardakhti = db.VamPardakhtis.ToList();
                    //var RizeAghsatVam = db.RizeAghsatVams.ToList();
                    //var HaghOzviat = db.HaghOzviats.ToList();
                    //var DaryaftPardakht = db.DaryaftPardakhtBinHesabhas.ToList();
                    List1.AddRange(db.AsnadeHesabdariRows.Select(s => s.ShomareSanad));
                    List_1.AddRange(db.AazaSandoghs.Select(s => s.ShomareSanad));
                    List_1.AddRange(db.VamPardakhtis.Select(s => s.ShomareSanad));
                    List_1.AddRange(db.RizeAghsatVams.Select(s => s.ShomareSanad));
                    List_1.AddRange(db.HaghOzviats.Select(s => s.ShomareSanad));
                    List_1.AddRange(db.DaryaftPardakhtBinHesabhas.Select(s => s.ShomareSanad));

                    List<int> List01 = List1.Distinct().ToList();
                    string SharhList1 = string.Empty;
                    List<int> List001 = new List<int>();

                    for (int i = 0; i < List01.Count; i++)
                    {
                        if (!List_1.Contains(List01[i]))
                        {
                            SharhList1 += "شماره سند " + List01[i] + " مرجع ندارد" + "\n";
                            List001.Add(List01[i]);
                        }
                    }
                    if (List001.Count > 0)
                    {
                        if (XtraMessageBox.Show(SharhList1 + "\n" + "\n" + "آیا سندهای فوق حذف شوند؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            List<AsnadeHesabdariRow> AH = new List<AsnadeHesabdariRow>();
                            foreach (var item in List001)
                            {
                                AH.AddRange(db.AsnadeHesabdariRows.Where(s => s.ShomareSanad == item));

                            }
                            db.AsnadeHesabdariRows.RemoveRange(AH);
                            db.SaveChanges();

                            XtraMessageBox.Show("عملیات انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    ///////////// بررسی افتتاحیه اعضاء با اسناد حسابداری ////////////////////
                    List<int> List2 = new List<int>();
                    List<int> List_2 = new List<int>();
                    List2.AddRange(db.AsnadeHesabdariRows.Select(s => s.ShomareSanad));
                    List_2.AddRange(db.AazaSandoghs.Where(s => s.BesAvali > 0 && s.ShomareSanad > 0).Select(s => s.ShomareSanad));
                    string SharhList2 = string.Empty;

                    for (int i = 0; i < List_2.Count; i++)
                    {
                        if (!List2.Contains(List_2[i]))
                        {
                            int _ShomareSanad = Convert.ToInt32(List_2[i]);
                            var q2 = db.AazaSandoghs.FirstOrDefault(s => s.ShomareSanad == _ShomareSanad);
                            SharhList2 += "افتتاحیه " + q2.NameVFamil + " سند حسابداری ندارد" + "\n";

                        }
                    }

                    if (!string.IsNullOrEmpty(SharhList2))
                    {
                        XtraMessageBox.Show(SharhList2 + "\n" + "\n" + "جهت حل این مشکل با پشتیبانی تماس بگیرید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    ///////////// بررسی حق عضویت ماهیانه با اسناد حسابداری ////////////////////
                    List<int> List3 = new List<int>();
                    List<int> List_3 = new List<int>();
                    List3.AddRange(db.AsnadeHesabdariRows.Select(s => s.ShomareSanad));
                    List_3.AddRange(db.HaghOzviats.Where(s => s.Mablagh > 0).Select(s => s.ShomareSanad));
                    string SharhList3 = string.Empty;

                    for (int i = 0; i < List_3.Count; i++)
                    {
                        if (!List3.Contains(List_3[i]))
                        {
                            int _ShomareSanad = Convert.ToInt32(List_3[i]);
                            var q3 = db.HaghOzviats.FirstOrDefault(s => s.ShomareSanad == _ShomareSanad);
                            SharhList3 += "دریافت پس انداز ماهیانه " + q3.NameAaza + " به شماره سریال " + q3.Seryal + " سند حسابداری ندارد" + "\n";

                        }
                    }

                    if (!string.IsNullOrEmpty(SharhList3))
                    {
                        XtraMessageBox.Show(SharhList3 + "\n" + "\n" + "جهت اصلاح موارد فوق در قسمت دریافت پس انداز ماهیانه ، عضو مورد نظر انتخاب و شماره سریال مربوطه ویرایش و مجدداً ذخیره گردد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    ///////////// بررسی اعطای وام با اسناد حسابداری ////////////////////
                    List<int> List4 = new List<int>();
                    List<int> List_4 = new List<int>();
                    List4.AddRange(db.AsnadeHesabdariRows.Select(s => s.ShomareSanad));
                    List_4.AddRange(db.VamPardakhtis.Where(s => s.MablaghAsli > 0).Select(s => s.ShomareSanad));
                    string SharhList4 = string.Empty;

                    for (int i = 0; i < List_4.Count; i++)
                    {
                        if (!List4.Contains(List_4[i]))
                        {
                            int _ShomareSanad = Convert.ToInt32(List_4[i]);
                            var q4 = db.VamPardakhtis.FirstOrDefault(s => s.ShomareSanad == _ShomareSanad);
                            //SharhList4 +=q4.NoeVam+ " " + q4.NameAaza + " به شماره " + q4.Code + " سند حسابداری ندارد" + "\n";
                            SharhList4 += "وام شماره " + q4.Code + " " + q4.NameAaza + " سند حسابداری ندارد" + "\n";

                        }
                    }

                    if (!string.IsNullOrEmpty(SharhList4))
                    {
                        XtraMessageBox.Show(SharhList4 + "\n" + "\n" + "جهت اصلاح موارد فوق در قسمت اعطای وام ، شماره مربوطه انتخاب ، ویرایش و مجدداً ذخیره گردد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    ///////////// بررسی ریز اقساط وام با اسناد حسابداری ////////////////////
                    List<int> List5 = new List<int>();
                    List<int> List_5 = new List<int>();
                    List5.AddRange(db.AsnadeHesabdariRows.Select(s => s.ShomareSanad));
                    List_5.AddRange(db.RizeAghsatVams.Where(s => s.MablaghDaryafti > 0).Select(s => s.ShomareSanad));
                    string SharhList5 = string.Empty;

                    for (int i = 0; i < List_5.Count; i++)
                    {
                        if (!List5.Contains(List_5[i]))
                        {
                            int _ShomareSanad = Convert.ToInt32(List_5[i]);
                            var q5 = db.RizeAghsatVams.FirstOrDefault(s => s.ShomareSanad == _ShomareSanad);
                            SharhList5 += "قسط " + q5.ShomareGhest + " وام شماره " + q5.VamPardakhtiCode + " " + q5.NameAaza + " سند حسابداری ندارد" + "\n";
                        }
                    }

                    if (!string.IsNullOrEmpty(SharhList5))
                    {
                        XtraMessageBox.Show(SharhList5 + "\n" + "\n" + "جهت اصلاح موارد فوق در قسمت دریافت اقساط ، شماره وام و قسط مربوطه انتخاب ، ویرایش و مجدداً ذخیره گردد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    ///////////// بررسی دریافت/پرداخت بین حسابها با اسناد حسابداری ////////////////////
                    List<int> List6 = new List<int>();
                    List<int> List_6 = new List<int>();
                    List6.AddRange(db.AsnadeHesabdariRows.Select(s => s.ShomareSanad));
                    List_6.AddRange(db.DaryaftPardakhtBinHesabhas.Where(s => s.Mablagh > 0).Select(s => s.ShomareSanad));
                    string SharhList6 = string.Empty;

                    for (int i = 0; i < List_6.Count; i++)
                    {
                        if (!List6.Contains(List_6[i]))
                        {
                            int _ShomareSanad = Convert.ToInt32(List_6[i]);
                            var q6 = db.DaryaftPardakhtBinHesabhas.FirstOrDefault(s => s.ShomareSanad == _ShomareSanad);
                            SharhList6 += "برگ " + q6.NoeSanadName + " به شماره سریال " + q6.Seryal + " سند حسابداری ندارد" + "\n";
                        }
                    }

                    if (!string.IsNullOrEmpty(SharhList6))
                    {
                        XtraMessageBox.Show(SharhList6 + "\n" + "\n" + "جهت اصلاح موارد فوق در قسمت دریافت/پرداخت بین حسابها ، سریال مربوطه انتخاب ، ویرایش و مجدداً ذخیره گردد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    ///////////// بررسی دریافت/پرداخت بین حسابها با سرمایه اولیه در تعریف اشخاص ////////////////////
                    string SharhList7 = string.Empty;
                    //DateTime dt = Convert.ToDateTime("1400/01/01");
                    //var q8 = db.AazaSandoghs.Where(s=>s.ShomareSanad==0).ToList();
                    var q8 = db.AazaSandoghs.ToList();
                    if (q8.Count > 0)
                    {
                        var q7 = db.DaryaftPardakhtBinHesabhas.Where(s => s.TaghirSarmayeAvalye == true).ToList();
                        foreach (var item in q8)
                        {
                            decimal _Sum3 = q7.Where(s => s.HesabTafziliId2 == item.AllTafId).Sum(s => s.Mablagh) - q7.Where(s => s.HesabTafziliId1 == item.AllTafId).Sum(s => s.Mablagh);
                            if (item.BesAvali!= _Sum3)
                            {
                                SharhList7 += "مبلغ سرمایه اولیه " + item.NameVFamil + " صحیح نیست" + "\n";
                            }
                        }

                        if (!string.IsNullOrEmpty(SharhList7))
                        {
                            //XtraMessageBox.Show(SharhList7 + "\n" + "\n" + "موارد مشکل دار", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            XtraMessageBox.Show(SharhList7, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        //if (q7.Count > 0)
                        //{

                        //    foreach (var item in q7)
                        //    {
                        //        if (q8.Any(s => s.AllTafId == item.HesabTafziliId2))
                        //        {
                        //            var q9 = q8.FirstOrDefault(s => s.AllTafId == item.HesabTafziliId2);
                        //            if (q9.BesAvali != item.Mablagh)
                        //            {
                        //                SharhList7 += "مبلغ سرمایه اولیه " + q9.NameVFamil + " صحیح نیست" + "\n";
                        //            }
                        //        }
                        //    }


                        //}
                    }

                    ///////////////////////////// پیغام درستی اطلاعات دیتابیس ////////////////////////////
                    if (string.IsNullOrEmpty(SharhList1) && string.IsNullOrEmpty(SharhList2) && string.IsNullOrEmpty(SharhList3) &&
                        string.IsNullOrEmpty(SharhList4) && string.IsNullOrEmpty(SharhList5) && string.IsNullOrEmpty(SharhList6) &&
                        string.IsNullOrEmpty(SharhList7))
                    {
                        XtraMessageBox.Show("کلیه اسناد دیتابیس صحیح می باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnNobatBandiVam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmNobatVam frm = new FrmNobatVam(this);
            ActiveForm(frm);
        }

        //string FilePath = string.Empty;

        OpenFileDialog ofd = new OpenFileDialog();
        private void btnAsasName_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    FilePath = Application.StartupPath + @"\Report\AsasNameh";
                    if (Directory.Exists(FilePath))
                    {
                        object filename = FilePath + @"\AsasNameh_Org.doc";
                        if (File.Exists((string)filename))
                        {
                            Word.Application ap = new Word.Application();
                            ap.Visible = true;
                            object miss = Missing.Value;
                            //object path = Application.StartupPath + @"\Report\DarkhastVam\DarkhastVam.doc";
                            object path = filename;
                            object readOnly = false;
                            object isVisible = true;
                            Word.Document doc = new Word.Document();
                            doc = ap.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref isVisible, ref miss, ref miss, ref miss, ref miss);
                            doc.Activate();

                        }
                        else
                        {
                            try
                            {
                                ofd.Filter = "WordFile (*.doc)|*.doc|WordFile(*.docx) | *.docx";
                                if (ofd.ShowDialog() == DialogResult.OK)
                                {
                                    string FileName1 = ofd.FileName;
                                    File.Copy(FileName1, FilePath + @"\AsasNameh_Org.doc");

                                    Word.Application ap = new Word.Application();
                                    ap.Visible = true;
                                    object miss = Missing.Value;
                                    //object path = Application.StartupPath + @"\Report\DarkhastVam\DarkhastVam.doc";
                                    object path = FilePath + @"\AsasNameh_Org.doc";
                                    object readOnly = false;
                                    object isVisible = true;
                                    Word.Document doc = new Word.Document();
                                    doc = ap.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref isVisible, ref miss, ref miss, ref miss, ref miss);
                                    doc.Activate();



                                }
                            }
                            catch (PathTooLongException)
                            {

                                MessageBox.Show("مسیر فایل طولانی است");
                            }

                        }
                    }
                    else
                    {
                        //XtraMessageBox.Show("پوشه ای با نام AsasNameh یافت نشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //return;
                        Directory.CreateDirectory(FilePath);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> SetInFoToWord()" + "\n" + ex.Message,
                        "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnDarkhastVamN1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DarkhastVam = "DarkhastVamN1";
            GetInfoForWord();
            SetInFoToWord();
            OpenFilWord();
        }

        private void btnDarkhastVamN2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DarkhastVam = "DarkhastVamN2";
            GetInfoForWord();
            SetInFoToWord();
            OpenFilWord();
        }

        private void IpAdress_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string HostName = Dns.GetHostName();
            string IPAdress = Dns.GetHostByName(HostName).AddressList[0].ToString();
            XtraMessageBox.Show("نام کامپیوتر : " + HostName + "\n"+ "آیپی شبکه : "+ IPAdress , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCodingAmval_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmCodingDaramadVHazine fm = new FrmCodingDaramadVHazine(this);
            fm.Text = "تعریف کدینگ اموال";
            fm.Name = "FrmCodingAmval";
            fm.labelControl6.Visible = false;
            fm.cmbGroupHesab.Visible = false;
            //fm.btnCreate.Visible = true;
            //fm.btnDelete.Visible = true;
            //fm.btnSaveNext.Visible = true;
            //fm.btnDisplyNotActiveList.Visible = true;
            //fm.btnAdvancedSearch.Visible = true;
            //fm.btnPrintPreview.Visible = true;
            //fm.btnPrint.Visible = true;
            //fm.labelControl2.Visible = true;
            //fm.chkIsActive.Visible = true;
            fm.gridView1.Columns["GroupName"].Visible = false;
            //fm.gridView1.Columns["IsActive"].Visible = true;
            //fm.gridView1.Columns["HesabName"].Width = 700;
            //fm.gridView1.Columns["HesabName"].FieldName = "Name";
            ActiveForm(fm);

        }

        public bool IsAllowed = false;
        private void btnSabtLisens_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsAllowed)
            {
                FrmAppRegister frm = new FrmAppRegister(this);
                frm.ShowDialog();
            }
            else
            {
                FrmPassword1 frm = new FrmPassword1(this);
                frm.labelControl4.Visible = false;
                frm.ShowDialog();

            }

        }

        private void btnDatabaseChange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (IsAllowed)
            {
                RepairDataBase1 fmrd = new RepairDataBase1(this);
                fmrd.ShowDialog();
            }
            else
            {
                FrmPassword1 frm = new FrmPassword1(this);
                frm.labelControl4.Visible = false;
                frm.ShowDialog();

            }

        }
    }
}
