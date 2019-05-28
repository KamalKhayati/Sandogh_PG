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

namespace Sandogh_TG
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        //SettingsBag Settings { get; } = JsonSettings.Construct<SettingsBag>(AppVariable.fileName + @"\config.json").EnableAutosave().WithEncryption("asdjklasjdkajsd654654").LoadNow();
        SettingsBag Settings { get; } = JsonSettings.Construct<SettingsBag>(AppVariable.fileName + @"\config.json").EnableAutosave().LoadNow();

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
                            FrmMain fm = new FrmMain();
                            fm.txtUserId.Caption = q.Id.ToString();
                            fm.txtUserName.Caption = q.Name.ToString();
                            fm.txtDateTimeNow.Caption = DateTime.Now.ToString().Substring(0, 10);
                            fm.NameDataBase.Caption = db.Database.Connection.Database;
                            //fm.IndexNameDataBase.Caption = cmbNameDataBaseSandogh.SelectedIndex.ToString();
                            fm.Show();

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
            //cmbNameDataBaseSandogh.SelectedIndex = 0;
            using (var db = new MyContext())
            {
                try
                {
                    LblNameDatabase.Text = db.Database.Connection.Database;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            using (var db = new MyContext())
            {
                // فراخوانی پوسته برنامه از مسیر دایرکتوری %appdata%
                try
                {
                    //int i = 0;
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(Settings[AppVariable.SkinName[0]].ToString() ?? "DevExpress Style");

                    string command = " ALTER DATABASE " + LblNameDatabase.Text + " SET ONLINE";
                    db.Database.CommandTimeout = 360;
                    db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, command);
                }
                catch (Exception)
                {

                }
            }


        }
        public void SetAppConfing()
        {
            //D:\Kamal Projects\Sandogh\Sandogh_TG\Sandogh_TG\bin\Debug\DB
            //D:\Kamal Projects\Sandogh\Sandogh_TG\Sandogh_TG\bin\Debug\DB\Sandogh_TG.mdf
            //string DataPath = Application.StartupPath + @"\DB\";
            AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath + @"\DB\");
            //       < add name = "con" connectionString = "" providerName = "System.Data.sqlclient" />
            //< !--< add name = "MyContext" connectionString1 = "data source=(LocalDb)\MSSQLLocalDB;initial catalog=Sandogh_TG.MyContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName = "System.Data.SqlClient" /> -->
            //      < !--< add name = "MyContext" connectionString2 = "Data Source=KAMAL-PC\sql2008;AttachDbFilename=|DataDirectory|\Sandogh_TG.mdf; Database=Sandogh_TG;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName = "System.Data.SqlClient" /> -->
            //< add name = "MyContext" connectionString = "Data Source=KAMAL-PC\sql2008;AttachDbFilename=|DataDirectory|\Sandogh_TG.mdf; Database=Sandogh_TG;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName = "System.Data.SqlClient" />

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
                updateConfigFile(strCon);
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
                using (var db = new MyContext())
                {
                    LblNameDatabase.Text = db.Database.Connection.Database;
                    try
                    {
                        string _Shenase =HelpClass1.EncryptText(txtShenase.Text);
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
            this.Height = chkConnectToServer.Checked ? 562 : 319;
            cmbServerType.SelectedIndex = 0;
            cmbServerName.SelectedIndex = 0;
            cmbAuthentication.SelectedIndex = 0;
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
                string a = Settings[AppVariable.cmbNameDataBaseSandogh[_IndexcmbNameDatabase]].ToString();
                if (a == _IndexcmbNameDatabase.ToString())
                {
                    cmbServerType.SelectedIndex = Convert.ToInt32(Settings[AppVariable.cmbServerType[_IndexcmbNameDatabase]].ToString());
                    cmbServerName.Text = Settings[AppVariable.cmbServerName[_IndexcmbNameDatabase]].ToString();
                    cmbAuthentication.SelectedIndex = Convert.ToInt32(Settings[AppVariable.cmbAuthentication[_IndexcmbNameDatabase]].ToString());
                    txtUserName2.Text = Settings[AppVariable.txtUserName2[_IndexcmbNameDatabase]].ToString();
                    txtPassword2.Text = Settings[AppVariable.txtPassword2[_IndexcmbNameDatabase]].ToString();
                    txtAttachDbFilePath.Text = Settings[AppVariable.txtAttachDbFilePath[_IndexcmbNameDatabase]].ToString();
                    txtDatabaseName.Text = Settings[AppVariable.txtDatabaseName[_IndexcmbNameDatabase]].ToString();
                }
                //else
                //{
                //    cmbServerType.SelectedIndex = 0;
                //    cmbServerName.SelectedIndex = 0;
                //    cmbAuthentication.SelectedIndex = 0;
                //    txtAttachDbFilePath.Text = Application.StartupPath + @"\DB\" + cmbNameDataBaseSandogh.Text + ".mdf";
                //    txtDatabaseName.Text = cmbNameDataBaseSandogh.Text;
                //}
            }
            catch (Exception e)
            {

                //cmbServerType.SelectedIndex = 0;
                //cmbServerName.SelectedIndex = 0;
                //cmbAuthentication.SelectedIndex = 0;
                //txtAttachDbFilePath.Text = Application.StartupPath + @"\DB\" + cmbNameDataBaseSandogh.Text + ".mdf";
                //txtDatabaseName.Text = cmbNameDataBaseSandogh.Text;

            }
        }
        private void cmbNameDataBaseSandogh_SelectedIndexChanged(object sender, EventArgs e)
        {

            //txtAttachDbFilePath.Text = Application.StartupPath + @"\DB\" + cmbNameDataBaseSandogh.Text + ".mdf";
            //txtDatabaseName.Text = cmbNameDataBaseSandogh.Text;
            FillInfoControls();
            SetAppConfing();
            Application.Restart();
            //using (var db = new MyContext())
            //{
            //    try
            //    {
            //        if (!db.Database.Exists())
            //            db.Database.Initialize(true);
            //        //string command = "ALTER DATABASE Sandogh_TG SET OFFLINE WITH ROLLBACK IMMEDIATE " +
            //        //                   " RESTORE DATABASE Sandogh_TG FROM DISK='" + txtSelectFile.Text + "' WITH REPLACE " +
            //        //                    "ALTER DATABASE Sandogh_TG SET ONLINE";
            //        //string command = "ALTER DATABASE " + cmbNameDataBaseSandogh.Text + " SET OFFLINE WITH ROLLBACK IMMEDIATE " +
            //        //                 "ALTER DATABASE " + cmbNameDataBaseSandogh.Text + " SET ONLINE";
            //        string command = " ALTER DATABASE " + LblNameDatabase.Text + " SET ONLINE";
            //        //string command = "DECLARE	@Spid INT DECLARE @ExecSQL VARCHAR(255) DECLARE KillCursor CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY "+
            //        //                 "FOR SELECT DISTINCT SPID FROM    MASTER..SysProcesses WHERE DBID = DB_ID('" + cmbNameDataBaseSandogh.Text + "') OPEN KillCursor " +
            //        //                 "--Grab the first SPID FETCH   NEXT FROM    KillCursor INTO    @Spid WHILE	@@FETCH_STATUS = 0 BEGIN "+
            //        //                 "SET     @ExecSQL = 'KILL ' + CAST(@Spid AS VARCHAR(50)) EXEC(@ExecSQL) -- Pull the next SPID FETCH NEXT FROM KillCursor INTO @Spid END "+
            //        //                 "CLOSE   KillCursor DEALLOCATE  KillCursor "+ 
            //        //                 "ALTER DATABASE " + cmbNameDataBaseSandogh.Text + " SET ONLINE";
            //        db.Database.CommandTimeout = 360;
            //        db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, command);

            //    }
            //    catch (Exception)
            //    {

            //        return;
            //    }
            //}

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < cmbNameDataBaseSandogh.Properties.Items.Count; i++)
            //{
            //    if (i == cmbNameDataBaseSandogh.SelectedIndex)
            //    {
            //        Settings[AppVariable.cmbNameDataBaseSandogh[i]] = cmbNameDataBaseSandogh.SelectedIndex.ToString();
            //        Settings[AppVariable.cmbServerType[i]] = cmbServerType.SelectedIndex.ToString();
            //        Settings[AppVariable.cmbServerName[i]] = cmbServerName.Text;
            //        Settings[AppVariable.cmbAuthentication[i]] = cmbAuthentication.SelectedIndex.ToString();
            //        Settings[AppVariable.txtUserName2[i]] = txtUserName2.Text;
            //        Settings[AppVariable.txtPassword2[i]] = txtPassword2.Text;
            //        Settings[AppVariable.txtAttachDbFilePath[i]] = txtAttachDbFilePath.Text;
            //        Settings[AppVariable.txtDatabaseName[i]] = txtDatabaseName.Text;
            //    }
            //}
            if (!string.IsNullOrEmpty(txtDatabaseName.Text))
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

                int _Index = cmbNameDataBaseSandogh.Properties.Items.Count;
                Settings[AppVariable.txtDatabaseName[_Index]] = txtDatabaseName.Text;
                Settings[AppVariable.cmbNameDataBaseSandogh[_Index]] = _Index;
                Settings[AppVariable.cmbServerType[_Index]] = cmbServerType.SelectedIndex.ToString();
                Settings[AppVariable.cmbServerName[_Index]] = cmbServerName.Text;
                Settings[AppVariable.cmbAuthentication[_Index]] = cmbAuthentication.SelectedIndex.ToString();
                Settings[AppVariable.txtUserName2[_Index]] = txtUserName2.Text;
                Settings[AppVariable.txtPassword2[_Index]] = txtPassword2.Text;
                Settings[AppVariable.txtAttachDbFilePath[_Index]] = txtAttachDbFilePath.Text;
                SetAppConfing();
                FillCmbNameDatabase();

                using (var db = new MyContext())
                {
                    try
                    {
                        string St1 = Application.StartupPath + @"\DB\";
                        //string command = " ALTER DATABASE " + txtDatabaseName.Text + " SET ONLINE";
                        string command = " CREATE DATABASE " + txtDatabaseName.Text +
                                         " ON" +
                                         " (NAME =" + txtDatabaseName.Text + ",FILENAME = '" + St1 + txtDatabaseName.Text + ".mdf')" +
                                             " LOG ON" +
                                             " (NAME = '" + txtDatabaseName.Text + "_log',FILENAME = '" + St1 + txtDatabaseName.Text + ".ldf')";
                        db.Database.CommandTimeout = 360;
                        db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, command);

                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
        }

        public void FillCmbNameDatabase()
        {
            try
            {
                cmbNameDataBaseSandogh.Properties.Items.Clear();
                int i = 0;
                // int a = Convert.ToInt32(Settings[AppVariable.cmbNameDataBaseSandogh[i]]);
                while (Convert.ToInt32(Settings[AppVariable.cmbNameDataBaseSandogh[i]]) == i)
                {
                    cmbNameDataBaseSandogh.Properties.Items.Add(Settings[AppVariable.txtDatabaseName[i]].ToString());
                    i++;
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
                chkConnectToServer.Visible = chkConnectToServer.Visible == true ? false : true;
                cmbNameDataBaseSandogh.Visible = cmbNameDataBaseSandogh.Visible == true ? false : true;
            }

        }

        private void txtDatabaseName_EditValueChanged(object sender, EventArgs e)
        {
            txtAttachDbFilePath.Text = Application.StartupPath + @"\DB\" + txtDatabaseName.Text + ".mdf";
        }
    }
}