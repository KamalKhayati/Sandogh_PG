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
using System.Xml;
using System.Configuration;

namespace Sandogh_PG
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        //SettingsBag Settings { get; } = JsonSettings.Construct<SettingsBag>(AppVariable.fileName + @"\config.json").EnableAutosave().WithEncryption("asdjklasjdkajsd654654").LoadNow();
        SettingsBag Settings { get; } = JsonSettings.Construct<SettingsBag>(AppVariable.fileName + @"\config.json").EnableAutosave().WithEncryption("km113012").LoadNow();

        public FrmLogin()
        {
            InitializeComponent();

        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        string _Password = HelpClass1.EncryptText(txtPassword.Text);
                        string _Shenase = HelpClass1.EncryptText(txtShenase.Text);
                        var q = db.Karbarans.FirstOrDefault(f => f.Shenase == _Shenase && f.Password == _Password);
                        if (q != null)
                        {
                            this.Close();
                            //var q1 = db.RmsUserhaBmsAccessLevelMenuhas.Where(s => s.MsUserId == q.MsUserId).ToList();
                            //if (q1.Count==0)
                            //{
                            //    XtraMessageBox.Show("برای این کاربر هیچگونه سطح دسترسی تعیین نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                            //{
                            //    Application.OpenForms[i].Close();
                            //}
                            //return;
                            //}
                            var qq = db.TarifSandoghs.FirstOrDefault(s => s.Id == 1);
                            if (qq.AppActived == true)
                            {
                                if (qq.ShomareNoskheBarname == Application.ProductVersion)
                                {
                                    FrmMain fm = new FrmMain();
                                    fm.txtUserId.Caption = q.Id.ToString();
                                    fm.txtUserName.Caption = q.Name.ToString();
                                    fm.txtDateTimeNow.Caption = DateTime.Now.ToString().Substring(0, 10);
                                    fm.NameDataBase.Caption = db.Database.Connection.Database;
                                    fm.ShNoskheBarname.Caption = qq.ShomareNoskheBarname;
                                    //fm.IndexNameDataBase.Caption = cmbNameDataBaseSandogh.SelectedIndex.ToString();
                                    fm.Show();
                                }
                                else
                                {
                                    if (qq.IsGaranti == true)
                                    {
                                        qq.ShomareNoskheBarname = Application.ProductVersion;
                                        db.SaveChanges();
                                        FrmMain fm = new FrmMain();
                                        fm.txtUserId.Caption = q.Id.ToString();
                                        fm.txtUserName.Caption = q.Name.ToString();
                                        fm.txtDateTimeNow.Caption = DateTime.Now.ToString().Substring(0, 10);
                                        fm.NameDataBase.Caption = db.Database.Connection.Database;
                                        fm.ShNoskheBarname.Caption = qq.ShomareNoskheBarname;
                                        //fm.IndexNameDataBase.Caption = cmbNameDataBaseSandogh.SelectedIndex.ToString();
                                        fm.Show();
                                    }
                                    else
                                    {
                                        var rs = XtraMessageBox.Show("با  توجه به اینکه مدت گارانتی برنامه به اتمام رسیده است \n لذا مجاز به استفاده از ورژن جدید برنامه نمی باشید\n جهت تمدید گارانتی و استفاده از آپدیت جدید برنامه لطفاً با پشتیبانی به شماره \n 09148253244 تماس حاصل فرمایید درغیر اینصورت جهت استفاده از برنامه میتوانید \n ورژن قبلی برنامه را نصب کنید", "پیغام", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                        if (rs == DialogResult.OK)
                                        {
                                            FrmAppRegister frm = new FrmAppRegister();
                                            frm._Password = HelpClass1.EncryptText(txtPassword.Text);
                                            frm._Shenase = HelpClass1.EncryptText(txtShenase.Text);
                                            frm.Text = "تمدید گارانتی برنامه";
                                            frm.Show();
                                        }
                                        else
                                            this.Close();
                                    }
                                }
                            }
                            else
                            {
                                FrmAppRegister frm = new FrmAppRegister();
                                frm._Password = HelpClass1.EncryptText(txtPassword.Text);
                                frm._Shenase = HelpClass1.EncryptText(txtShenase.Text);
                                frm.Show();
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("رمز عبور اشتباه است",
                                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPassword.Text = "";
                            txtPassword.Focus();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lblSystemDate.Text = DateTime.Now.ToString().Substring(0, 10);
            FillCmbNameDatabase();
            lblVersion.Text = "نسخه برنامه : " + Application.ProductVersion;
            lblDataBace.Text = "بانک اطلاعاتی: " + new MyContext().Database.Connection.Database.ToString();

            if (cmbNameDataBaseSandogh.Properties.Items.Count > 1)
            {
                cmbNameDataBaseSandogh.Visible = true;
            }
            //else if (cmbNameDataBaseSandogh.Properties.Items.Count == 0)
            //{
            //    cmbNameDataBaseSandogh.Visible = true;
            //    chkConnectToServer.Visible = true;
            //    this.Height = 495;
            //    XtraMessageBox.Show("لطفاً یک بانک اطلاعاتی تعریف و یا انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        }

        public string SetAppConfing()
        {
            //D:\Kamal Projects\Sandogh\Sandogh_PG\Sandogh_PG\bin\Debug\DB
            //D:\Kamal Projects\Sandogh\Sandogh_PG\Sandogh_PG\bin\Debug\DB\Sandogh_PG.mdf
            //string DataPath = Application.StartupPath + @"\DB\";
            AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath + @"\DB\");
            //       < add name = "con" connectionString = "" providerName = "System.Data.sqlclient" />
            //< !--< add name = "MyContext" connectionString1 = "data source=(LocalDb)\MSSQLLocalDB;initial catalog=Sandogh_PG.MyContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName = "System.Data.SqlClient" /> -->
            //      < !--< add name = "MyContext" connectionString2 = "Data Source=KAMAL-PC\sql2008;AttachDbFilename=|DataDirectory|\Sandogh_PG.mdf; Database=Sandogh_PG;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName = "System.Data.SqlClient" /> -->
            //< add name = "MyContext" connectionString = "Data Source=KAMAL-PC\sql2008;AttachDbFilename=|DataDirectory|\Sandogh_PG.mdf; Database=Sandogh_PG;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName = "System.Data.SqlClient" />

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

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtShenase.Text))
            {
                cmbNameDataBaseSandogh.Enabled = false;
                // SetAppConfing();
                /////////////////////////////////////////////////////////
                //using (var db = new MyContext())
                //{
                //    try
                //    {
                //        db.Database.Initialize(true);
                //    }

                //    catch (Exception ex)
                //    {

                //        MessageBox.Show(ex.Message);
                //    }
                //}

                using (var db = new MyContext())
                {
                    try
                    {
                        db.Database.Initialize(true);
                        LblNameDatabase.Text = db.Database.Connection.Database;

                        string _Shenase = HelpClass1.EncryptText(txtShenase.Text);
                        var q = db.Karbarans.FirstOrDefault(f => f.Shenase == _Shenase);
                        if (q != null)
                        {
                            lblName.Visible = true;
                            lblName.Text = q.Name;
                        }
                        else
                        {
                            XtraMessageBox.Show("شناسه کاربری اشتباه است",
                                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtShenase.Text = "";
                            txtShenase.Focus();
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

        private void chkConnectToServer_CheckedChanged(object sender, EventArgs e)
        {
            this.Height = chkConnectToServer.Checked ? 485 : 292;
            //cmbServerType.SelectedIndex = 0;
            //cmbServerName.SelectedIndex = 0;
            //cmbAuthentication.SelectedIndex = 0;
        }

        private void cmbAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUserName2.Enabled = txtPassword2.Enabled = cmbAuthentication.SelectedIndex == 1 ? true : false;
        }

        public void FillInfoControls()
        {
            int _IndexcmbNameDatabase = cmbNameDataBaseSandogh.SelectedIndex;
            try
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
                    txtAttachDbFilePath.Text = Settings[AppVariable.txtAttachDbFilePath[_IndexcmbNameDatabase]].ToString();
                    txtDatabaseName.Text = Settings[AppVariable.txtDatabaseName[_IndexcmbNameDatabase]].ToString();
                }
            }
            catch (Exception e)
            {
            }
        }

        private void cmbNameDataBaseSandogh_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    string d1 = db.Database.Connection.ConnectionString;
                    FillInfoControls();
                    //if (db.Database.Connection.Database != cmbNameDataBaseSandogh.Text || db.Database.Connection.DataSource!=Settings[AppVariable.cmbServerName[cmbNameDataBaseSandogh.SelectedIndex]].ToString())
                    if (SetAppConfing() != d1)
                    {
                        updateConfigFile(SetAppConfing());
                        Settings[AppVariable.DefaltIndexCmbNameSandogh] = cmbNameDataBaseSandogh.SelectedIndex.ToString();
                        // Application.Restart();
                        Application.Exit();
                    }
                    else
                    {
                        //FillInfoControls();
                        if (!string.IsNullOrEmpty(LblNameDatabase.Text))
                        {
                            txtShenase.ReadOnly = txtPassword.ReadOnly = false;
                            btnEnter.Enabled = true;
                            string s1 = Application.StartupPath + @"\DB\" + cmbNameDataBaseSandogh.Text + ".mdf";
                            if (System.IO.File.Exists(s1))
                            {
                                string command1 = " ALTER DATABASE " + LblNameDatabase.Text + " SET ONLINE";
                                db.Database.CommandTimeout = 360;
                                db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, command1);
                            }
                            txtShenase.Focus();

                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                     "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Application.Exit();
                }
            }
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
            if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.F12)
            {
                FrmPassword frm = new FrmPassword(this);
                frm.txtPassword.Focus();
                frm.ShowDialog();
            }

        }

        private void txtDatabaseName_EditValueChanged(object sender, EventArgs e)
        {
            txtAttachDbFilePath.Text = Application.StartupPath + @"\DB\" + txtDatabaseName.Text + ".mdf";
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            txtShenase.Focus();

        }
    }
}