using DevExpress.XtraEditors;
using nucs.JsonSettings;
using nucs.JsonSettings.Fluent;
using Sandogh_TG;
using Sandogh_TG.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sandogh_TG
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //SettingsBag Settings { get; } = JsonSettings.Construct<SettingsBag>(AppVariable.fileName + @"\config.json").EnableAutosave().WithEncryption("asdjklasjdkajsd654654").LoadNow();
        SettingsBag Settings { get; } = JsonSettings.Construct<SettingsBag>(AppVariable.fileName + @"\config.json").EnableAutosave().LoadNow();
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
                        int _SId = Convert.ToInt32(IDSandogh.Caption);
                        var q2 = db.TarifSandoghs.FirstOrDefault(s => s.Id == _SId);
                        if (q2.PicBackground != null)
                        {
                            MemoryStream ms = new MemoryStream(q2.PicBackground);
                            pictureEdit1.Image = Image.FromStream(ms);
                            img = pictureEdit1.Image;
                        }
                        else
                            pictureEdit1.Image = null;
                    }

                    var q1 = db.SalMalis.FirstOrDefault(s => s.IsDefault == true);
                    if (q1 != null)
                    {
                        IDSalMali.Caption = q1.Id.ToString();
                    }


                    if (Application.OpenForms["FrmTarifSandogh"] == null)
                    {
                        var q3 = db.Tanzimats.Any(f => f.checkEdit3 == true);
                        if (q3)
                        {
                            FrmYadavari fm = new FrmYadavari();
                            fm.ShowDialog();
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
            FrmDaryaftNaghdiVBanki fm = new FrmDaryaftNaghdiVBanki(this);
            ActiveForm(fm);
        }

        private void btnPardakhtNaghdiVBanki_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmPardakhtNaghdiVBanki fm = new FrmPardakhtNaghdiVBanki(this);
            ActiveForm(fm);
        }

        private void btnCodingDaramadVHazine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmCodingDaramadVHazine fm = new FrmCodingDaramadVHazine(this);
            ActiveForm(fm);
        }

        private void btnSabtDaramad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSabtDaramad fm = new FrmSabtDaramad(this);
            ActiveForm(fm);
        }

        private void btnSabtHazine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSabtHazine fm = new FrmSabtHazine(this);
            ActiveForm(fm);

        }

        private void btnEnteghalatHesabBanki_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmEnteghalatHesabBanki fm = new FrmEnteghalatHesabBanki(this);
            ActiveForm(fm);
        }

        private void btnEnteghalatHesabAaza_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmEnteghalatHesabAaza fm = new FrmEnteghalatHesabAaza(this);
            ActiveForm(fm);

        }

        private void btnEnteghalatHesabDaramadVHazine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmEnteghaliBeHesabDaramadVHazine fm = new FrmEnteghaliBeHesabDaramadVHazine(this);
            ActiveForm(fm);

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
            FrmSoratHesabTafzili fm = new FrmSoratHesabTafzili();
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
                        this.pictureEdit1.Image = img;
                        //this.pictureEdit1.Tag = openFileDialog1.FileName;
                        int _SId = Convert.ToInt32(IDSandogh.Caption);
                        var q = db.TarifSandoghs.FirstOrDefault(f => f.Id == _SId);
                        if (q != null)
                        {
                            MemoryStream ms = new MemoryStream();
                            img.Save(ms, pictureEdit1.Image.RawFormat);
                            byte[] myarrey = ms.GetBuffer();
                            q.PicBackground = myarrey;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        if (XtraMessageBox.Show("آیا عکس پس زمینه حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            pictureEdit1.Image = null;
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
            //    //string command = "ALTER DATABASE Sandogh_TG SET OFFLINE WITH ROLLBACK IMMEDIATE " +
            //    //                   " RESTORE DATABASE Sandogh_TG FROM DISK='" + txtSelectFile.Text + "' WITH REPLACE " +
            //    //                    "ALTER DATABASE Sandogh_TG SET ONLINE";
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
            SqlConnection.ClearAllPools();
            Application.Exit();
            Application.ExitThread();
        }
    }
}
