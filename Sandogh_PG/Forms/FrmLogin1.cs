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
using nucs.JsonSettings;
using nucs.JsonSettings.Fluent;
using System.Configuration;
using System.Xml;

namespace Sandogh_PG.Forms
{
    public partial class FrmLogin1 : DevExpress.XtraEditors.XtraForm
    {
        SettingsBag Settings { get; } = JsonSettings.Construct<SettingsBag>(AppVariable.fileName + @"\config.json").EnableAutosave().WithEncryption("km113012").LoadNow();

        public FrmLogin1()
        {
            InitializeComponent();
        }

        private void FrmLogin1_Load(object sender, EventArgs e)
        {
            //Settings[AppVariable.txtUserName2[0]] = "sa";
            //Settings[AppVariable.txtPassword2[0]] = "113012";
            //Settings[AppVariable.txtUserName2[4]] = "sa";
            //Settings[AppVariable.txtPassword2[4]] = "113012";
            //Settings[AppVariable.txtUserName] = "1";
            //Settings[AppVariable.txtPassword] = "1";


            if (Settings[AppVariable.IsChangeDbName] == null)
            {
                Settings[AppVariable.IsChangeDbName] = "False";
            }
            //string k = Settings[AppVariable.IsChangeDbName].ToString();
            lblSystemDate.Text = DateTime.Now.ToString().Substring(0, 10);
            FillCmbNameDatabase();
            lblVersion.Text = "نسخه: " + Application.ProductVersion;
            using (var db = new MyContext())
            {
                try
                {
                    lblDataBace.Text = "دیتابیس: " + db.Database.Connection.Database.ToString();

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            if (cmbNameDataBaseSandogh.Properties.Items.Count > 1)
            {
                cmbNameDataBaseSandogh.Visible = true;
            }
            //else if (cmbNameDataBaseSandogh.Properties.Items.Count == 0)
            //{
            //    cmbNameDataBaseSandogh.Visible = true;
            //    chkConnectToServer.Visible = true;
            //    this.Height = 495;
            //    XtraMessageBox.Show("لطفاً یک دیتابیس تعریف و یا انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            if (System.IO.Directory.Exists(AppVariable.fileName))
                if (Settings.Data.Count > 0)
                {
                    //        LblNameDatabase.Text = db.Database.Connection.Database;
                    cmbNameDataBaseSandogh.SelectedIndex = Convert.ToInt32(Settings[AppVariable.DefaltIndexCmbNameSandogh]);
                }
                else
                    return;
            else
                return;


            try
            {
                // فراخوانی پوسته برنامه از مسیر دایرکتوری %appdata%
                if (System.IO.Directory.Exists(AppVariable.fileName) && Settings.Data.Count > 0)
                    if (Settings[AppVariable.SkinName[0]] != null)
                        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(Settings[AppVariable.SkinName[0]].ToString() ?? "DevExpress Style");

                ////////////////////////// گرفتن نام کاربری ویندوز ///////////////////////////
                // string UserNameWindows = System.Security.Principal.WindowsIdentity.GetCurrent().Name ;
                //string command2 = "ALTER LOGIN " + UserNameWindows + " DISABLE";
                //db.Database.CommandTimeout = 360;
                //db.Database.ExecuteSqlCommand(command2);
                //db.Database.SqlQuery<string>("ALTER LOGIN" + UserNameWindows + "ENABLE");

            }
            catch (Exception)
            {
            }

            if (Settings[AppVariable.IsChangeDbName].ToString() == "True")
            {
                int _index = Convert.ToInt32(Settings[AppVariable.DefaltIndexCmbNameSandogh]);
                _Shenase1 = Settings[AppVariable.txtUserName[_index]].ToString();
                _Password1 = Settings[AppVariable.txtPassword[_index]].ToString();
                if (Application.OpenForms["FrmMain"] == null)
                    CheckUserNameAndPassword();
            }
        }

        public void FillCmbNameDatabase()
        {
            try
            {
                cmbNameDataBaseSandogh.Properties.Items.Clear();
                if (System.IO.Directory.Exists(AppVariable.fileName) && Settings.Data.Count > 0)
                {
                    int i = 0;
                    // int a = Convert.ToInt32(Settings[AppVariable.cmbNameDataBaseSandogh[i]]);
                    while (Convert.ToInt32(Settings[AppVariable.cmbNameDataBaseSandogh[i]]) == i)
                    {
                        cmbNameDataBaseSandogh.Properties.Items.Add(Settings[AppVariable.txtDatabaseName[i]].ToString());
                        i++;
                    }

                }
            }
            catch
            {
            }

        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void chkConnectToServer_CheckedChanged(object sender, EventArgs e)
        {
            this.Height = chkConnectToServer.Checked ? 523 : 292;
            //cmbServerType.SelectedIndex = 0;
            //cmbServerName.SelectedIndex = 0;
            //cmbAuthentication.SelectedIndex = 0;
        }

        private void cmbNameDataBaseSandogh_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    //string d1 = db.Database.Connection.ConnectionString;
                    FillInfoControls();

                    updateConfigFile(SetAppConfing());
                    ConfigurationManager.RefreshSection("connectionStrings");
                    Settings[AppVariable.DefaltIndexCmbNameSandogh] = cmbNameDataBaseSandogh.SelectedIndex.ToString();
                    //Application.Restart();
                    //Application.Exit();
                    //ConfigurationManager.RefreshSection("AppSettings");
                    //db.Database.Initialize(true);


                    //if (!string.IsNullOrEmpty(db.Database.Connection.Database))
                    //{
                    //    txtShenase.ReadOnly = txtPassword.ReadOnly = false;
                    //    //btnEnter.Enabled = true;
                    //    //string s1 = Application.StartupPath + @"\DB\" + cmbNameDataBaseSandogh.Text + ".mdf";
                    //    //if (System.IO.File.Exists(s1))
                    //    //{
                    //    //    string command1 = " ALTER DATABASE " + LblNameDatabase.Text + " SET ONLINE";
                    //    //    db.Database.CommandTimeout = 360;
                    //    //    db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, command1);
                    //    //}
                    //}

                    txtShenase.ReadOnly = txtPassword.ReadOnly = cmbNameDataBaseSandogh.SelectedIndex == -1 ? true : false;
                    txtShenase.Focus();

                    lblDataBace.Text = "دیتابیس: " + cmbNameDataBaseSandogh.Text;



                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                     "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Application.Exit();
                }
            }
        }

        public void FillInfoControls()
        {
            int _IndexcmbNameDatabase = cmbNameDataBaseSandogh.SelectedIndex;
            try
            {
                if (_IndexcmbNameDatabase != -1)
                {
                    int a = Convert.ToInt32(Settings[AppVariable.cmbNameDataBaseSandogh[_IndexcmbNameDatabase]]);
                    if (a == _IndexcmbNameDatabase)
                    {
                        LblNameDatabase.Text = Settings[AppVariable.txtDatabaseName[_IndexcmbNameDatabase]].ToString();
                        cmbServerType.SelectedIndex = Convert.ToInt32(Settings[AppVariable.cmbServerType[_IndexcmbNameDatabase]].ToString());
                        cmbServerName.Text = Settings[AppVariable.cmbServerName[_IndexcmbNameDatabase]].ToString();
                        cmbAuthentication.SelectedIndex = Convert.ToInt32(Settings[AppVariable.cmbAuthentication[_IndexcmbNameDatabase]].ToString());
                        txtUserName2.Text = Settings[AppVariable.txtUserName2[_IndexcmbNameDatabase]].ToString();
                        txtPassword2.Text = Settings[AppVariable.txtPassword2[_IndexcmbNameDatabase]].ToString();
                        txtDatabaseName.Text = Settings[AppVariable.txtDatabaseName[_IndexcmbNameDatabase]].ToString();
                        txtAttachDbFilePath.Text = Settings[AppVariable.txtAttachDbFilePath[_IndexcmbNameDatabase]].ToString();
                    }

                }
                else
                {
                    LblNameDatabase.Text = string.Empty;
                    cmbServerType.SelectedIndex = -1;
                    cmbServerName.Text = string.Empty;
                    cmbAuthentication.SelectedIndex = -1;
                    txtUserName2.Text = string.Empty;
                    txtPassword2.Text = string.Empty;
                    txtDatabaseName.Text = string.Empty;
                    txtAttachDbFilePath.Text = string.Empty;

                }
            }
            catch (Exception e)
            {
            }
        }

        public string SetAppConfing()
        {
            //D:\Kamal Projects\Sandogh\Sandogh_PG\Sandogh_PG\bin\Debug\DB
            //D:\Kamal Projects\Sandogh\Sandogh_PG\Sandogh_PG\bin\Debug\DB\Sandogh_PG.mdf
            //string DataPath = Application.StartupPath + @"\DB\";
            //       < add name = "con" connectionString = "" providerName = "System.Data.sqlclient" />
            //< !--< add name = "MyContext" connectionString1 = "data source=(LocalDb)\MSSQLLocalDB;initial catalog=Sandogh_PG.MyContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName = "System.Data.SqlClient" /> -->
            //      < !--< add name = "MyContext" connectionString2 = "Data Source=KAMAL-PC\sql2008;AttachDbFilename=|DataDirectory|\Sandogh_PG.mdf; Database=Sandogh_PG;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName = "System.Data.SqlClient" /> -->
            //< add name = "MyContext" connectionString = "Data Source=KAMAL-PC\sql2008;AttachDbFilename=|DataDirectory|\Sandogh_PG.mdf; Database=Sandogh_PG;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName = "System.Data.SqlClient" />

            AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath + @"\DB\");
            try
            {
                //Constructing connection string from the inputs
                StringBuilder Con = new StringBuilder("Data Source=");
                Con.Append(cmbServerName.Text);
                //Con.Append(@"KAMAL-PC\sql2008");
                Con.Append(";AttachDbFilename=");
                Con.Append(txtAttachDbFilePath.Text);
                //Con.Append(DataPath + cmbNameDataBaseSandogh.Text + ".mdf");
                Con.Append(";Database=");
                Con.Append(txtDatabaseName.Text);
                //Con.Append(cmbNameDataBaseSandogh.Text);
                if (cmbAuthentication.SelectedIndex == 0)
                    Con.Append(";Integrated Security=true");
                else if (cmbAuthentication.SelectedIndex == 1)
                {
                    Con.Append(";User Id=");
                    Con.Append(txtUserName2.Text);
                    Con.Append(";Password=");
                    Con.Append(txtPassword2.Text);
                }

                Con.Append(";MultipleActiveResultSets=true");
                Con.Append(";App=EntityFramework");
                string strCon = Con.ToString();
                return strCon;
                // updateConfigFile(strCon);
                ////Create new sql connection
                //SqlConnection Db = new SqlConnection();
                ////to refresh connection string each time else it will use previous connection string
                //ConfigurationManager.RefreshSection("connectionStrings");
                //Db.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                ////To check new connection string is working or not. Please use the existing table otherwise it will give error
                //SqlDataAdapter da = new SqlDataAdapter("select * from GroupTafzilis", Db);
                //DataTable dt = new DataTable();
                //da.Fill(dt);
                //cmbTestValue.DataSource = dt;
                //cmbTestValue.DisplayMember = "Team";
            }
            catch (Exception E)
            {
                MessageBox.Show(ConfigurationManager.ConnectionStrings["MyContext"].ToString() + ".This is invalid connection", "Incorrect server/Database");
                return "";
            }

        }

        public void updateConfigFile(string con)
        {
            //updating config file
            XmlDocument XmlDoc = new XmlDocument();
            //Loading the Config file
            XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            foreach (XmlElement xElement in XmlDoc.DocumentElement)
            {
                if (xElement.Name == "connectionStrings")
                {
                    //setting the coonection string

                    xElement.FirstChild.Attributes[1].Value = con;
                }
            }
            //writing the connection string in config file
            XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }

        private void cmbAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUserName2.Enabled = txtPassword2.Enabled = cmbAuthentication.SelectedIndex == 1 ? true : false;
        }

        //public class AppContext : ApplicationContext
        //{
        //    public AppContext()
        //    {
        //        Application.Idle += new EventHandler(Application_Idle);
        //        //new FrmMain().Show();
        //        new FrmLogin1().ShowDialog();
        //    }

        //    private void Application_Idle(object sender, EventArgs e)
        //    {
        //        if (Application.OpenForms.Count == 0)
        //        {
        //            Application.Exit();
        //        }
        //    }
        //}

        string _Shenase1 = String.Empty;
        string _Password1 = String.Empty;
        private void btnEnter_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {

                int _index = cmbNameDataBaseSandogh.SelectedIndex;
                string dbName = db.Database.Connection.Database;
                if (dbName != cmbNameDataBaseSandogh.Text)
                {
                    this.Visible = false;
                    Settings[AppVariable.IsChangeDbName] = "True";
                    Settings[AppVariable.txtUserName[_index]] = txtShenase.Text;
                    Settings[AppVariable.txtPassword[_index]] = txtPassword.Text;
                    //Application.Exit();
                    Application.Restart();
                    return;
                }
                else
                {
                    if (Application.OpenForms["FrmMain"] != null)
                    {
                        Settings[AppVariable.IsChangeDbName] = "True";
                        Settings[AppVariable.txtUserName[_index]] = txtShenase.Text;
                        Settings[AppVariable.txtPassword[_index]] = txtPassword.Text;
                        Application.Restart();
                        return;
                    }

                    //if (Settings[AppVariable.IsChangeDbName].ToString() == "True")
                    //{
                    //    //int index = Convert.ToInt32(Settings[AppVariable.DefaltIndexCmbNameSandogh]);
                    //    _Shenase1 = Settings[AppVariable.txtUserName[_index]].ToString();
                    //    _Password1 = Settings[AppVariable.txtPassword[_index]].ToString();
                    //}
                    //else
                    //{
                    _Shenase1 = txtShenase.Text;
                    _Password1 = txtPassword.Text;
                    //cmbNameDataBaseSandogh.Enabled = false;
                    LblNameDatabase.Text = db.Database.Connection.Database;
                    lblDataBace.Text = "دیتابیس: " + LblNameDatabase.Text;
                    //}
                }
                CheckUserNameAndPassword();
            }
        }

        public void CheckUserNameAndPassword()
        {
            using (var db = new MyContext())
            {

                try
                {
                    string _Shenase = HelpClass1.EncryptText(_Shenase1);
                    var q = db.Karbarans.FirstOrDefault(f => f.Shenase == _Shenase);
                    if (q != null)
                    {
                        if (Settings[AppVariable.IsChangeDbName].ToString() == "False")
                        {
                            lblName.Visible = true;
                            lblName.Text = q.Name;
                        }
                        //string _Password = HelpClass1.EncryptText(txtPassword.Text);
                        string _Password = HelpClass1.EncryptText(_Password1);
                        //string _Shenase = HelpClass1.EncryptText(txtShenase.Text);
                        var p = db.Karbarans.FirstOrDefault(f => f.Shenase == _Shenase && f.Password == _Password);
                        if (p != null)
                        {
                            this.Close();

                            FrmAppRegister frm = new FrmAppRegister();
                            frm._UserId = p.Id.ToString();
                            frm._UserName = p.Name;
                            frm._Password = _Password;
                            frm._Shenase = _Shenase;
                            //frm.Text = "تمدید پشتیبانی برنامه";
                            frm.Show();

                            #region MyRegion
                            //var qq = db.TarifSandoghs.FirstOrDefault(s => s.IsDefault == true);
                            //if (qq.AppActived == true)
                            //{
                            //    if (HelpClass1.DecryptText(qq.VersionType) == "Demo" || HelpClass1.DecryptText(qq.VersionType) == "Display")
                            //    {
                            //        if (qq.ShomareNoskheBarname != Application.ProductVersion)
                            //        {
                            //            qq.ShomareNoskheBarname = Application.ProductVersion;
                            //            db.SaveChanges();
                            //        }
                            //    }
                            //    else
                            //    {
                            //        if (qq.ShomareNoskheBarname == Application.ProductVersion)
                            //        {
                            //            FrmMain fm = new FrmMain();
                            //            fm.txtUserId.Caption = q.Id.ToString();
                            //            fm.txtUserName.Caption = q.Name.ToString();
                            //            fm.txtDateTimeNow.Caption = DateTime.Now.ToString().Substring(0, 10);
                            //            fm.NameDataBase.Caption = db.Database.Connection.Database;
                            //            fm.ShNoskheBarname.Caption = qq.ShomareNoskheBarname;
                            //            //fm.IndexNameDataBase.Caption = cmbNameDataBaseSandogh.SelectedIndex.ToString();
                            //            fm.Show();
                            //        }
                            //        else
                            //        {
                            //            if (qq.IsGaranti == true)
                            //            {
                            //                qq.ShomareNoskheBarname = Application.ProductVersion;
                            //                db.SaveChanges();

                            //                FrmMain fm = new FrmMain();
                            //                fm.txtUserId.Caption = q.Id.ToString();
                            //                fm.txtUserName.Caption = q.Name.ToString();
                            //                fm.txtDateTimeNow.Caption = DateTime.Now.ToString().Substring(0, 10);
                            //                fm.NameDataBase.Caption = db.Database.Connection.Database;
                            //                fm.ShNoskheBarname.Caption = qq.ShomareNoskheBarname;
                            //                //fm.IndexNameDataBase.Caption = cmbNameDataBaseSandogh.SelectedIndex.ToString();
                            //                fm.Show();
                            //            }
                            //            else
                            //            {
                            //                var rs = XtraMessageBox.Show("با  توجه به اینکه مدت پشتیبانی برنامه به اتمام رسیده است \n لذا مجاز به استفاده از ورژن جدید برنامه نمی باشید\n جهت تمدید پشتیبانی و استفاده از آپدیت جدید برنامه لطفاً با واحد پشتیبانی به شماره \n 09148253244 تماس حاصل فرمایید درغیر اینصورت جهت استفاده از برنامه میتوانید \n ورژن قبلی برنامه را نصب کنید", "پیغام", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            //                if (rs == DialogResult.OK)
                            //                {
                            //                    FrmAppRegister frm = new FrmAppRegister();
                            //                    frm._Password = _Password;
                            //                    frm._Shenase = _Shenase;
                            //                    //frm.Text = "تمدید پشتیبانی برنامه";
                            //                    frm.Show();
                            //                }
                            //                else
                            //                    this.Close();
                            //            }
                            //        }

                            //    }
                            //}
                            //else
                            //{
                            //    FrmAppRegister frm = new FrmAppRegister();
                            //    frm._Password = _Password;
                            //    frm._Shenase = _Shenase;
                            //    frm.Show();
                            //}

                            #endregion
                        }
                        else
                        {
                            XtraMessageBox.Show("رمز عبور اشتباه است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                            if (Settings[AppVariable.IsChangeDbName].ToString() == "True")
                            {
                                Settings[AppVariable.IsChangeDbName] = "False";
                                //cmbNameDataBaseSandogh.Enabled = false;
                                //cmbNameDataBaseSandogh.Enabled = true;
                                //LblNameDatabase.Text = db.Database.Connection.Database;
                                //lblDataBace.Text = "دیتابیس: " + LblNameDatabase.Text;

                            }
                            else
                            {
                                txtPassword.Text = "";
                            }

                            txtPassword.Focus();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("شناسه کاربری اشتباه است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (Settings[AppVariable.IsChangeDbName].ToString() == "True")
                        {
                            Settings[AppVariable.IsChangeDbName] = "False";
                            //cmbNameDataBaseSandogh.Enabled = false;
                            //cmbNameDataBaseSandogh.Enabled = true;
                            //LblNameDatabase.Text = db.Database.Connection.Database;
                            //lblDataBace.Text = "دیتابیس: " + LblNameDatabase.Text;

                        }
                        else
                        {
                            txtShenase.Text = "";
                        }

                        txtShenase.Focus();
                    }
                }
                catch (Exception ex)
                {
                    //db.Database.Initialize(true);
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                    "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDatabaseName_EditValueChanged(object sender, EventArgs e)
        {
            txtAttachDbFilePath.Text = Application.StartupPath + @"\DB\" + txtDatabaseName.Text + ".mdf";
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            txtShenase.Focus();

        }

        private void txtShenase_EditValueChanged(object sender, EventArgs e)
        {
            btnEnter.Enabled = string.IsNullOrEmpty(txtShenase.Text) ? false : string.IsNullOrEmpty(txtPassword.Text) ? false : true;
        }

        private void txtPassword_EditValueChanged(object sender, EventArgs e)
        {
            btnEnter.Enabled = string.IsNullOrEmpty(txtPassword.Text) ? false : string.IsNullOrEmpty(txtShenase.Text) ? false : true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDatabaseName.Text))
            {
                //string d1 = new MyContext().Database.Connection.ConnectionString;
                //if (new MyContext ().Database.SqlQuery("")
                //{
                //    XtraMessageBox.Show("دیتابیسی با این نام قبلاً در پایگاه اطلاعاتی اس کیو ال تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                //    return;
                //}
                if (System.IO.Directory.Exists(AppVariable.fileName))
                    if (Settings.Data.Count > 0)
                    {
                        for (int i = 0; i < cmbNameDataBaseSandogh.Properties.Items.Count; i++)
                        {
                            try
                            {
                                string a = Settings[AppVariable.txtDatabaseName[i]].ToString();
                                if (a == txtDatabaseName.Text)
                                {
                                    XtraMessageBox.Show("دیتابیس با این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    return;
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }

                    }

                int _Index = cmbNameDataBaseSandogh.Properties.Items.Count;
                Settings[AppVariable.txtDatabaseName[_Index]] = txtDatabaseName.Text;
                Settings[AppVariable.cmbNameDataBaseSandogh[_Index]] = _Index;
                Settings[AppVariable.cmbServerType[_Index]] = cmbServerType.SelectedIndex.ToString();
                Settings[AppVariable.cmbServerName[_Index]] = cmbServerName.Text;
                Settings[AppVariable.cmbAuthentication[_Index]] = cmbAuthentication.SelectedIndex.ToString();
                Settings[AppVariable.txtUserName2[_Index]] = txtUserName2.Text;
                Settings[AppVariable.txtPassword2[_Index]] = txtPassword2.Text;
                Settings[AppVariable.txtAttachDbFilePath[_Index]] = txtAttachDbFilePath.Text;
                // SetAppConfing();
                FillCmbNameDatabase();
            }
        }

        private void lblDataBace_Click(object sender, EventArgs e)
        {
            //if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.F12)
            //if (e.Alt && e.Control && e.KeyCode == Keys.Insert)
            //{
            FrmPassword1 frm = new FrmPassword1(this);
            frm.txtSeryal.Focus();
            frm.ShowDialog();
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (Application.OpenForms["FrmMain"] == null || (Application.OpenForms["FrmMain"] != null) && db.Database.Connection.Database != cmbNameDataBaseSandogh.Text)
                    {
                        int ItemCount = cmbNameDataBaseSandogh.Properties.Items.Count;
                        int ItemIndex = cmbNameDataBaseSandogh.SelectedIndex;
                        if (ItemCount > 0 && ItemIndex != -1)
                        {
                            if (ItemIndex + 1 == ItemCount)
                            {
                                Settings[AppVariable.SkinName[ItemIndex]] = null;
                                Settings[AppVariable.cmbNameDataBaseSandogh[ItemIndex]] = null;
                                Settings[AppVariable.cmbServerType[ItemIndex]] = null;
                                Settings[AppVariable.cmbServerName[ItemIndex]] = null;
                                Settings[AppVariable.cmbAuthentication[ItemIndex]] = null;
                                Settings[AppVariable.txtUserName2[ItemIndex]] = null;
                                Settings[AppVariable.txtPassword2[ItemIndex]] = null;
                                Settings[AppVariable.txtAttachDbFilePath[ItemIndex]] = null;
                                Settings[AppVariable.txtDatabaseName[ItemIndex]] = null;
                                Settings[AppVariable.DefaltIndexCmbNameSandogh] = "-1";
                                Settings[AppVariable.IsChangeDbName] = "false";
                                Settings[AppVariable.txtUserName[ItemIndex]] = null;
                                Settings[AppVariable.txtPassword[ItemIndex]] = null;
                                Settings[AppVariable.VersionNumber[ItemIndex]] = null;
                            }
                            else
                            {
                                for (int i = ItemIndex; ItemIndex < ItemCount; ItemIndex++)
                                {
                                    Settings[AppVariable.SkinName[ItemIndex]] = ItemIndex != ItemCount - 1 ? Settings[AppVariable.SkinName[ItemIndex + 1]] : null;
                                    Settings[AppVariable.cmbNameDataBaseSandogh[ItemIndex]] = ItemIndex != ItemCount - 1 ? ItemIndex.ToString() : null;
                                    Settings[AppVariable.cmbServerType[ItemIndex]] = ItemIndex != ItemCount - 1 ? Settings[AppVariable.cmbServerType[ItemIndex + 1]] : null;
                                    Settings[AppVariable.cmbServerName[ItemIndex]] = ItemIndex != ItemCount - 1 ? Settings[AppVariable.cmbServerName[ItemIndex + 1]] : null;
                                    Settings[AppVariable.cmbAuthentication[ItemIndex]] = ItemIndex != ItemCount - 1 ? Settings[AppVariable.cmbAuthentication[ItemIndex + 1]] : null;
                                    Settings[AppVariable.txtUserName2[ItemIndex]] = ItemIndex != ItemCount - 1 ? Settings[AppVariable.txtUserName2[ItemIndex + 1]] : null;
                                    Settings[AppVariable.txtPassword2[ItemIndex]] = ItemIndex != ItemCount - 1 ? Settings[AppVariable.txtPassword2[ItemIndex + 1]] : null;
                                    Settings[AppVariable.txtAttachDbFilePath[ItemIndex]] = ItemIndex != ItemCount - 1 ? Settings[AppVariable.txtAttachDbFilePath[ItemIndex + 1]] : null;
                                    Settings[AppVariable.txtDatabaseName[ItemIndex]] = ItemIndex != ItemCount - 1 ? Settings[AppVariable.txtDatabaseName[ItemIndex + 1]] : null;
                                    Settings[AppVariable.txtUserName[ItemIndex]] = ItemIndex != ItemCount - 1 ? Settings[AppVariable.txtUserName[ItemIndex + 1]] : null;
                                    Settings[AppVariable.txtPassword[ItemIndex]] = ItemIndex != ItemCount - 1 ? Settings[AppVariable.txtPassword[ItemIndex + 1]] : null;
                                    Settings[AppVariable.VersionNumber[ItemIndex]] = ItemIndex != ItemCount - 1 ? Settings[AppVariable.VersionNumber[ItemIndex + 1]] : null;

                                }
                            }
                            Settings[AppVariable.DefaltIndexCmbNameSandogh] = "-1";
                            Settings[AppVariable.IsChangeDbName] = "false";
                            FillCmbNameDatabase();
                            cmbNameDataBaseSandogh.SelectedIndex = -1;
                            cmbNameDataBaseSandogh_SelectedIndexChanged(null, null);
                            XtraMessageBox.Show("دیتابیس انتخابی حذف شد", "پیغام حذف", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("دیتابیس فعال قابل حذف نیست", "پیغام حذف", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
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
