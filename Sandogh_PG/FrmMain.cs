using DevExpress.XtraEditors;
using nucs.JsonSettings;
using nucs.JsonSettings.Fluent;
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

namespace Sandogh_PG
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //SettingsBag Settings { get; } = JsonSettings.Construct<SettingsBag>(AppVariable.fileName + @"\config.json").EnableAutosave().WithEncryption("asdjklasjdkajsd654654").LoadNow();
        SettingsBag Settings { get; } = JsonSettings.Construct<SettingsBag>(AppVariable.fileName + @"\config.json").EnableAutosave().WithEncryption("km113012").LoadNow();
        public FrmMain()
        {
            InitializeComponent();

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

        private void btnTanzimat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTanzimat fm = new FrmTanzimat(this);
            ActiveForm(fm);

        }

        private void btnTarifSalMali_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTarifSalMali fm = new FrmTarifSalMali();
            ActiveForm(fm);
        }

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
                    HelpClass1.SwitchToPersianLanguage();
                    HelpClass1.SetRegionAndLanguage();
                    Settings[AppVariable.IsChangeDbName] = "False";
                    string _DeviceID = HelpClass1.GetMadarBoardSerial();
                    string _dataBaseName = db.Database.Connection.Database;
                     
                    var q5 = db.AllowedDevises.FirstOrDefault(s => s.DeviceID == _DeviceID && s.DataBaseName== _dataBaseName);
                    var q = db.TarifSandoghs.FirstOrDefault(s => s.IsDefault == true);
                    if (q != null && q5 != null)
                    {
                        IDSandogh.Caption = q.Id.ToString();
                        ribbonControl1.ApplicationDocumentCaption = q.NameSandogh;
                        int _SId = Convert.ToInt32(IDSandogh.Caption);
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
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            FrmListKarbaran fm = new FrmListKarbaran();
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
            // int i = Convert.ToInt32(IndexNameDataBase.Caption);
            Settings[AppVariable.SkinName[0]] = DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveSkinName;
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
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
                                    MojodiSandogh.Caption = "موجودی صندوق/بانک : " + Mande.ToString("###,###,###,###,###") + " ریال";
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
        int _IdHesab = 0;
        private void MojodiSandogh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSoratHesabTafzili frm = new FrmSoratHesabTafzili(this);
            frm.cmbHesabTafzili.EditValue = _IdHesab;
            ActiveForm(frm);
        }

        bool IsDataDelete = false;
        public bool IsOkDelete = false;
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                            try
                            {
                                db.Database.Initialize(true);
                                // XtraMessageBox.Show("کلیه اطلاعات ثبت شده با موفقیت حذف گردید و نرم افزار مجدداً راه اندازی خواهد شد", "پیغام", MessageBoxButtons.OK);
                                XtraMessageBox.Show("کلیه اطلاعات ثبت شده با موفقیت حذف گردید لطفا برنامه را مجدداً اجرا کنید", "پیغام", MessageBoxButtons.OK);
                                IsDataDelete = true;
                                //Application.Restart();
                                Application.Exit();
                            }
                            catch (Exception ex)
                            {
                                //Application.Exit();
                                XtraMessageBox.Show(ex.Message);
                            }
                        }
                    }
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
                object path = FilePath + @"\DarkhastVam_Temp.doc";
                object readOnly = false;
                object isVisible = true;
                Word.Document doc = new Word.Document();
                doc = ap.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref isVisible, ref miss, ref miss, ref miss, ref miss);
                doc.Activate();
                //Word.Application ap = new Word.Application();
                //Word.Document document = ap.Documents.Open(FilePath + @"\Gharardade_Temp.doc",);

            }
            catch //(Exception)
            {
                //doc.Application.Quit(ref missing, ref missing, ref missing);
                //throw;
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
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        public static void KillProcess(string name)
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


        private void FindAndReplace(Word.Application wordApp, object findText, object replaceText)
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

        string FilePath = string.Empty;
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
                    File.Copy(FilePath + @"\DarkhastVam_Org.doc", FilePath + @"\DarkhastVam_Temp.doc", true);
                    //File.Copy(@"D:\Kamal Projects\Sandogh\Sandogh TG N1\Sandogh_PG\Sandogh_PG\bin\Debug\Report\Gharardade.docx", "c:\\temp.docx", true);
                    //File.Copy("D:\\Gharardade.docx", "D:\\temp.doc", true);
                    //  create missing object
                    object missing = Missing.Value;
                    //  create Word application object
                    Word.Application wordApp = new Word.Application();
                    //  create Word document object
                    Word.Document aDoc = null;
                    //  create & define filename object with temp.doc
                    object filename = FilePath + @"\DarkhastVam_Temp.doc";
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
                catch //(Exception ex)
                {
                    // XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                    //   "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnDarkhastVam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetInfoForWord();
            SetInFoToWord();
            OpenFilWord();
        }

        private void btnMabaleghGhabelDaryaft_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmMabaleghGhabelDaryaft frm = new FrmMabaleghGhabelDaryaft();
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

        public bool IsAllowed = false;
        public void btnSupportSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NameDataBase_ItemClick(null, null);
        }
    }
}
