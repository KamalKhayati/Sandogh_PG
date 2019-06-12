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
                    var q = db.TarifSandoghs.FirstOrDefault(s => s.IsDefault == true);
                    if (q != null)
                    {
                        IDSandogh.Caption = q.Id.ToString();
                        ribbonControl1.ApplicationDocumentCaption = q.NameSandogh;
                        string MadarBoardCode = string.Empty;
                        ManagementObjectSearcher sercher2 = new ManagementObjectSearcher("select * from Win32_BaseBoard");
                        foreach (ManagementObject wmi_Board in sercher2.Get())
                        {
                            if (wmi_Board["SerialNumber"] != null)
                                MadarBoardCode = wmi_Board["SerialNumber"].ToString().Trim();
                        }
                        if (q.MadarBoardCode != MadarBoardCode.Substring(0, 10))
                        {
                            q.MadarBoardCode = MadarBoardCode.Substring(0, 10);
                            db.SaveChanges();
                        }
                        int _SId = Convert.ToInt32(IDSandogh.Caption);
                        var q2 = db.TarifSandoghs.FirstOrDefault(s => s.Id == _SId);
                        if (q2.PicBackground != null)
                        {
                            MemoryStream ms = new MemoryStream(q2.PicBackground);
                            pictureEdit3.Image = Image.FromStream(ms);
                            img = pictureEdit3.Image;
                        }
                        //else
                        //    pictureEdit3.Image = null;
                    }

                    var q1 = db.SalMalis.FirstOrDefault(s => s.IsDefault == true);
                    if (q1 != null)
                    {
                        IDSalMali.Caption = q1.Id.ToString();
                    }


                    EtmamGaranti.Caption = db.TarifSandoghs.FirstOrDefault().TarikhEtmamGaranti != null ? "اتمام گارانتی : " + db.TarifSandoghs.FirstOrDefault().TarikhEtmamGaranti.ToString().Substring(0, 10) : "0000/00/00";
                    int yyyy1 = Convert.ToInt32(DateTime.Now.ToString().Substring(0, 4));
                    int MM1 = Convert.ToInt32(DateTime.Now.ToString().Substring(5, 2));
                    int dd1 = Convert.ToInt32(DateTime.Now.ToString().Substring(8, 2));
                    Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                    int yyyy2 = Convert.ToInt32(db.TarifSandoghs.FirstOrDefault().TarikhEtmamGaranti.ToString().Substring(0, 4));
                    int MM2 = Convert.ToInt32(db.TarifSandoghs.FirstOrDefault().TarikhEtmamGaranti.ToString().Substring(5, 2));
                    int dd2 = Convert.ToInt32(db.TarifSandoghs.FirstOrDefault().TarikhEtmamGaranti.ToString().Substring(8, 2));
                    Mydate d2 = new Mydate(yyyy2, MM2, dd2);
                    if (d2 < d1)
                    {
                        EtmamGaranti.ItemAppearance.Normal.ForeColor = Color.Red;
                        btnTamdidGaranti.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }


                    if (Application.OpenForms["FrmTarifSandogh"] == null)
                    {
                        var q3 = db.Tanzimats.Any(f => f.checkEdit3 == true);
                        if (q3)
                        {
                            FrmYadavari fm = new FrmYadavari();
                            fm.ShowDialog();
                            //Application.OpenForms["FrmYadavari"].Activate();
                        }

                    }
                    ///////////////////////////////////////بعد از یکبار اجرا حذف شود ///////////////////////////////////////////
                    var q4 = db.AazaSandoghs.Where(f => f.AllTafId == 0).ToList();
                    if (q4.Count > 0)
                    {
                        foreach (var item in q4)
                        {
                            item.AllTafId = db.AllHesabTafzilis.FirstOrDefault(f => f.Code == item.Code).Id;
                        }
                        db.SaveChanges();
                    }

                    var q5 = db.HesabBankis.Where(f => f.AllTafId == 0).ToList();
                    if (q5.Count > 0)
                    {
                        foreach (var item in q5)
                        {
                            item.AllTafId = db.AllHesabTafzilis.FirstOrDefault(f => f.Code == item.Code).Id;
                        }
                        db.SaveChanges();
                    }
                    ///////////////////////////////////////بعد از یکبار اجرا حذف شود ///////////////////////////////////////////
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
        Image img;

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
                        img = Image.FromFile(XtraopenFileDialog1.FileName);
                        this.pictureEdit3.Image = img;
                        //this.pictureEdit3.Tag = openFileDialog1.FileName;
                        int _SId = Convert.ToInt32(IDSandogh.Caption);
                        var q = db.TarifSandoghs.FirstOrDefault(f => f.Id == _SId);
                        if (q != null)
                        {
                            MemoryStream ms = new MemoryStream();
                            img.Save(ms, pictureEdit3.Image.RawFormat);
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
                                var q3 = db.AsnadeHesabdariRows.Where(f => f.HesabTafId == q1.Id).ToList();
                                if (q3.Count > 0)
                                {
                                    decimal Mande = Convert.ToDecimal(q3.Sum(f => f.Bed) - q3.Sum(f => f.Bes));
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
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("آیا همه اطلاعات ثبت شده حذف گردد ؟", "پیغام حذف کلیه اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (XtraMessageBox.Show("آیا برای انجام اینکار مطمئن هستید ؟", "پیغام حذف کلیه اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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

        private void FrmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void btnMandeAshkhas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmMandeAshkhas frm = new FrmMandeAshkhas();
            frm._SandoghName = ribbonControl1.ApplicationDocumentCaption;
            frm.ShowDialog();

        }

        private void btnTamdidGaranti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmAppRegister frm = new FrmAppRegister(this);
            frm.Text = "تمدید گارانتی";
            frm.btnExit.Text = "بستن";
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
                object path = Application.StartupPath + @"\Report\DarkhastVam\DarkhastVam.doc";
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

        private void btnDarkhastVam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
            if (Application.OpenForms["FrmBackupRestore"] == null && IsDataDelete==false)
                HelpClass1.FrmMain_FormClosing(sender, e);
        }
    }
}
