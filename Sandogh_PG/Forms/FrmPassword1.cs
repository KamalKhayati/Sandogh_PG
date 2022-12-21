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

namespace Sandogh_PG.Forms
{
    public partial class FrmPassword1 : DevExpress.XtraEditors.XtraForm
    {
        public FrmPassword1()
        {
            InitializeComponent();
        }

        FrmLogin1 FLogin1;
        public FrmPassword1(FrmLogin1 fLogin1)
        {
            InitializeComponent();
            FLogin1 = fLogin1;
        }
        FrmMain FMain;
        public FrmPassword1(FrmMain fMain)
        {
            InitializeComponent();
            FMain = fMain;
        }
        FrmAppRegister FRegister;
        public FrmPassword1(FrmAppRegister fRegister)
        {
            InitializeComponent();
            FRegister = fRegister;
        }

        string _RandomCode = "";
        public string UserId = string.Empty;
        public string UserName = string.Empty;
        private void FrmPassword1_Load(object sender, EventArgs e)
        {
            _RandomCode = HelpClass1.RandomCode();
            txtCode.Text = _RandomCode;
        }

        private string ReveresString(string RandomCode)
        {
            char[] ch = RandomCode.ToCharArray();
            Array.Reverse(ch);
            return new string(ch);
        }

        private string GenerateSerial(string RandomCode)
        {
            string ReveresRandomCode = ReveresString(RandomCode);
            string Serial = string.Empty;
            string code = ReveresRandomCode.Substring(0, 10);
            for (int i = 0; i < code.Length; i++)
            {
                char ch = char.Parse(code.Substring(i, 1));
                Serial += ((int)ch).ToString();
            }
            string ReveresSerial = ReveresString(Serial);
            return ReveresSerial.Substring(0, 10);
        }

        public string _Password = string.Empty;
        public string _Shenase = string.Empty;
        int yyyy1 = 0;
        int MM1 = 0;
        int dd1 = 0;

        //DateTime _dateTimeBeforEdit;
        //DateTime _GarantiEndDataBeforEdit;
        private void btnSabt_Click(object sender, EventArgs e)
        {
            if (txtSeryal.Text == GenerateSerial(_RandomCode))
            {
                if (FLogin1 != null)
                {
                    if (FLogin1.chkConnectToServer.Visible)
                        {
                            FLogin1.chkConnectToServer.Checked = false;
                            FLogin1.chkConnectToServer.Visible = false;
                            FLogin1.cmbNameDataBaseSandogh.Visible = FLogin1.cmbNameDataBaseSandogh.Enabled = FLogin1.cmbNameDataBaseSandogh.Properties.Items.Count > 1 ? true : false;
                        }
                        else
                        {
                            FLogin1.chkConnectToServer.Visible = true;
                            FLogin1.chkConnectToServer.Visible = true;
                            FLogin1.cmbNameDataBaseSandogh.Visible = true;
                            FLogin1.cmbNameDataBaseSandogh.Enabled = true;
                        }
                        this.Close();
                }
                else if (FMain != null)
                {
                    
                        if (this.Text == "تمدید مدت پشتیبانی")
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    string _DeviceID = HelpClass1.GetMadarBoardSerial();
                                    var q = db.AllowedDevises.FirstOrDefault(s => s.DeviceID == _DeviceID);
                                    if (q != null)
                                    {
                                        //_dateTimeBeforEdit = q.RegisterDate;
                                        //_GarantiEndDataBeforEdit = q.GarantiEndData;
                                        //if (Application.OpenForms["FrmMain"] == null)
                                        //{
                                        //}

                                        //q.AppActived = true;
                                        q.VersionNumber = Application.ProductVersion;
                                        q.LNVersionNumber = HelpClass1.EncryptText(Application.ProductVersion);
                                        //q.VersionNumber = Application.ProductVersion;
                                        q.IsGaranti = true;
                                        q.RegisterDate = Convert.ToDateTime(DateTime.Now.ToString().Substring(0, 10));

                                        if (Convert.ToDateTime(DateTime.Now) >= q.GarantiEndData)
                                        {
                                            yyyy1 = Convert.ToInt32(DateTime.Now.ToString().Substring(0, 4));
                                            MM1 = Convert.ToInt32(DateTime.Now.ToString().Substring(5, 2));
                                            dd1 = Convert.ToInt32(DateTime.Now.ToString().Substring(8, 2));
                                        }
                                        else
                                        {
                                            yyyy1 = Convert.ToInt32(q.GarantiEndData.ToString().Substring(0, 4));
                                            MM1 = Convert.ToInt32(q.GarantiEndData.ToString().Substring(5, 2));
                                            dd1 = Convert.ToInt32(q.GarantiEndData.ToString().Substring(8, 2));

                                        }
                                        Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                                        d1.IncrementYear();
                                        //for (int i = 0; i < 12; i++)
                                        //{
                                        //    d1.IncrementMonth();
                                        //}
                                        q.GarantiEndData = Convert.ToDateTime(d1.ToString());
                                        q.LNGarantiEndData = HelpClass1.EncryptText(d1.ToString());
                                        //}

                                        db.SaveChanges();
                                        this.Close();

                                        //if (Application.OpenForms["FrmMain"] == null)
                                        //{
                                        //    var q1 = db.Karbarans.FirstOrDefault(f => f.Shenase == _Shenase && f.Password == _Password);
                                        //    if (q1 != null)
                                        //    {
                                        //        FrmMain fm = new FrmMain();
                                        //        fm.txtUserId.Caption = q1.Id.ToString();
                                        //        fm.txtUserName.Caption = q1.Name.ToString();
                                        //        fm.txtDateTimeNow.Caption = DateTime.Now.ToString().Substring(0, 10);
                                        //        fm.NameDataBase.Caption = db.Database.Connection.Database;
                                        //        fm.ShNoskheBarname.Caption = q.VersionNumber;
                                        //        //fm.IndexNameDataBase.Caption = cmbNameDataBaseSandogh.SelectedIndex.ToString();
                                        //        fm.Show();
                                        //    }
                                        //}
                                        //else
                                        //{
                                        FMain.EtmamGaranti.Caption = q.GarantiEndData != null ? "اتمام مدت پشتیبانی : " + q.GarantiEndData.ToString().Substring(0, 10) : "1397/01/01";
                                        FMain.NameDataBase.Caption = db.Database.Connection.Database;
                                        FMain.ShNoskheBarname.Caption = q.VersionNumber;
                                        //string _VersionName = HelpClass1.DecryptText(q.VersionType) == "Orginal" ? "اصلی" : HelpClass1.DecryptText(q.VersionType) == "Demo" ? "آزمایشی" : "نمایشی";
                                        //Pm.barStaticItem4.Caption = "نسخه " + _VersionName + " برنامه :";
                                        //Pm.EtmamGaranti.Visibility = q.VersionType == "Orginal" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                                        FMain.EtmamGaranti.ItemAppearance.Normal.ForeColor = labelControl1.ForeColor;
                                        //Fm.btnTamdidGaranti.Enabled = false;

                                    }
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            this.Visible = false;
                            FMain.IsAllowed = true;
                            FMain.btnSupportSetting_ItemClick(null, null);
                        }
                }
                else if (FRegister != null)
                {
                    
                        if (this.Text == "تمدید مدت پشتیبانی")
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    string _DeviceID = HelpClass1.GetMadarBoardSerial();
                                    string _DataBaseName = db.Database.Connection.Database;
                                    var q = db.AllowedDevises.FirstOrDefault(s => s.DeviceID == _DeviceID && s.DataBaseName == _DataBaseName);
                                    if (q != null)
                                    {
                                        //_dateTimeBeforEdit = q.RegisterDate;
                                        //_GarantiEndDataBeforEdit = q.GarantiEndData;
                                        //if (Application.OpenForms["FrmMain"] == null)
                                        //{
                                        //}

                                        //q.AppActived = true;
                                        q.VersionNumber = Application.ProductVersion;
                                        q.LNVersionNumber = HelpClass1.EncryptText(Application.ProductVersion);
                                        //q.VersionNumber = Application.ProductVersion;
                                        q.IsGaranti = true;
                                        q.RegisterDate = Convert.ToDateTime(DateTime.Now.ToString().Substring(0, 10));

                                        yyyy1 = Convert.ToInt32(DateTime.Now.ToString().Substring(0, 4));
                                        MM1 = Convert.ToInt32(DateTime.Now.ToString().Substring(5, 2));
                                        dd1 = Convert.ToInt32(DateTime.Now.ToString().Substring(8, 2));
                                        Mydate d1 = new Mydate(yyyy1, MM1, dd1);

                                        d1.IncrementYear();
                                        //for (int i = 0; i < 12; i++)
                                        //{
                                        //    d1.IncrementMonth();
                                        //}
                                        q.GarantiEndData = Convert.ToDateTime(d1.ToString());
                                        q.LNGarantiEndData = HelpClass1.EncryptText(d1.ToString());
                                        //}

                                        db.SaveChanges();
                                        this.Close();

                                        var q1 = db.Karbarans.FirstOrDefault(f => f.Shenase == _Shenase && f.Password == _Password);
                                        if (q1 != null)
                                        {
                                            FrmMain fm = new FrmMain();
                                            fm.txtUserId.Caption = q1.Id.ToString();
                                            fm.txtUserName.Caption = q1.Name.ToString();
                                            fm.txtDateTimeNow.Caption = DateTime.Now.ToString().Substring(0, 10);
                                            fm.NameDataBase.Caption = db.Database.Connection.Database;
                                            fm.ShNoskheBarname.Caption = q.VersionNumber;
                                            //fm.IndexNameDataBase.Caption = cmbNameDataBaseSandogh.SelectedIndex.ToString();
                                            fm.Show();
                                        }
                                        //else
                                        //{
                                        //Pm.EtmamGaranti.Caption = q.GarantiEndData != null ? "اتمام مدت پشتیبانی : " + q.GarantiEndData.ToString().Substring(0, 10) : "1397/01/01";
                                        //Pm.NameDataBase.Caption = db.Database.Connection.Database;
                                        //Pm.ShNoskheBarname.Caption = q.VersionNumber;
                                        //string _VersionName = HelpClass1.DecryptText(q.VersionType) == "Orginal" ? "اصلی" : HelpClass1.DecryptText(q.VersionType) == "Demo" ? "آزمایشی" : "نمایشی";
                                        //Pm.barStaticItem4.Caption = "نسخه " + _VersionName + " برنامه :";
                                        //Pm.EtmamGaranti.Visibility = q.VersionType == "Orginal" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                                        //Pm.EtmamGaranti.ItemAppearance.Normal.ForeColor = labelControl1.ForeColor;
                                        //Fm.btnTamdidGaranti.Enabled = false;

                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("این سخت افزار با این دیتابیس مجوز دسترسی به اطلاعات برنامه را ندارد", "پیغام مجوز دسترسی", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Application.Exit();
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
            else
            {
                if (string.IsNullOrEmpty(txtSeryal.Text))
                    XtraMessageBox.Show("لطفاً سریال را وارد کنید");
                else
                    XtraMessageBox.Show("سریال وردی اشتباه است");
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}