using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;


namespace Sandogh_PG
{
    public partial class FrmBackupRestore : Form
    {
        FrmMain Fm;
        public FrmBackupRestore(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        FolderBrowserDialog SPath = new FolderBrowserDialog();
        private void btnBrowserBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (SPath.ShowDialog() == DialogResult.OK)
                {
                    string _NameDataBase = Fm.NameDataBase.Caption;
                    if (SPath.SelectedPath.Length == 3)
                    {
                        txtSelectPath.Text = SPath.SelectedPath + "Backup_" + _NameDataBase + "_V" + Application.ProductVersion + "_Date_" +
                            DateTime.Now.ToString().Replace("/", "").Substring(0, 8) + "_Time_" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(".", " ").Replace("ب ظ", "PM").Replace("ق ظ", "AM").Substring(8, 10) + ".BAK";
                        //txtSelectPath.Text = SPath.SelectedPath + "BackupFile_" +
                        //    DateTime.Now.Date.Year + DateTime.Now.Date.Month + DateTime.Now.Date.Day + "_" +
                        //    DateTime.Now.TimeOfDay.Hours + DateTime.Now.TimeOfDay.Minutes + DateTime.Now.TimeOfDay.Seconds + ".BAK";
                    }
                    else
                    {
                        txtSelectPath.Text = SPath.SelectedPath + "\\Backup_" + _NameDataBase + "_V" + Application.ProductVersion + "_Date_" +
                            DateTime.Now.ToString().Replace("/", "").Substring(0, 8) + "_Time_" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(".", " ").Replace("ب ظ", "PM").Replace("ق ظ", "AM").Substring(8, 10) + ".BAK";
                        //txtSelectPath.Text = SPath.SelectedPath + "\\BackupFile_" +
                        //    DateTime.Now.Date.Year + DateTime.Now.Date.Month + DateTime.Now.Date.Day + "_" +
                        //    DateTime.Now.TimeOfDay.Hours + DateTime.Now.TimeOfDay.Minutes + DateTime.Now.TimeOfDay.Seconds + ".BAK";
                    }
                }
            }
            catch (PathTooLongException)
            {

                MessageBox.Show("مسیر فایل طولانی است");
            }
        }

        private void rbtnBackup_CheckedChanged(object sender, EventArgs e)
        {
            gbxBackup.Enabled = true;
            gbxRestore.Enabled = false;
        }

        private void rbtnRestore_CheckedChanged(object sender, EventArgs e)
        {
            gbxBackup.Enabled = false;
            gbxRestore.Enabled = true;

        }
        bool isBackupRestore = false;
        private void FrmBackupRestore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rbtnBackup.Checked)
            {
                if (isBackupRestore)
                {
                    e.Cancel = true;
                    MessageBox.Show("نرم افزار درحال پشتیبان گیری است");
                }
            }
            else
            {
                if (isBackupRestore)
                {
                    e.Cancel = true;
                    MessageBox.Show("نرم افزار درحال بازیابی اطلاعات است");
                }

            }
        }

        private void btnStartBackup_Click(object sender, EventArgs e)
        {
            //isBackupRestore = true;
            if (string.IsNullOrEmpty(txtSelectPath.Text))
            {
                MessageBox.Show("مسیر فایل پشتیبان تعیین نشده است");
            }
            else
            {
               // if (!System.IO.Directory.Exists(new MyContext().Tanzimats.FirstOrDefault().Path))
                if (!System.IO.Directory.Exists(SPath.SelectedPath))
                {
                    MessageBox.Show("این مسیر در سیستم وجود ندارد لطفاً یک مسیر صحیح انتخاب نمایید");
                    txtSelectPath.Text = string.Empty;
                    btnBrowserBackup_Click(null, null);
                }
                else
                {
                    Application.OpenForms["FrmBackupRestore"].Enabled = false;
                    if (!backgroundWorkerBackup.IsBusy)
                    {
                        backgroundWorkerBackup.RunWorkerAsync();
                    }
                }
            }

        }
        private void backgroundWorkerBackup_DoWork(object sender, DoWorkEventArgs e)
        {
            string _NameDataBase = Fm.NameDataBase.Caption;

            using (var context = new MyContext())
            {
                //string command = @"BACKUP DATABASE " + _NameDataBase + " TO DISK='" + txtSelectPath.Text + "' WITH INIT";
                string command = @"BACKUP DATABASE " + _NameDataBase + " TO DISK='" + txtSelectPath.Text + "' WITH COMPRESSION";
                context.Database.CommandTimeout = 360;
                context.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, command);
            }
            //string strSQL = @"BACKUP DATABASE  Sandogh_PG  TO DISK='" + txtSelectPath.Text + "'";
            //SqlConnection con = new SqlConnection();
            //SqlCommand com = new SqlCommand();
            //con.ConnectionString = @"Data Source=KAMAL-PC\SQL2008;Initial Catalog=Sandogh_PG;
            //                             Integrated Security=True;Connect Timeout=30;Encrypt=False;
            //                              TrustServerCertificate=False;ApplicationIntent=ReadWrite;
            //                               MultiSubnetFailover=False";
            //com.CommandText = strSQL;
            //com.Connection = con;
            //con.Open();
            //com.ExecuteNonQuery();
            //con.Close();
        }

        private void backgroundWorkerBackup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MessageBox.Show("فایل پشتیبان با موفقیت انجام شد");
                Process.Start("explorer.exe", SPath.SelectedPath);
            }
            else
                MessageBox.Show("مشکل در انجام فایل پشتیبان");


            Application.OpenForms["FrmBackupRestore"].Enabled = true;
            //txtSelectPath.Text = string.Empty;

        }

        OpenFileDialog ofd = new OpenFileDialog();
        private void btnBrowserRestore_Click(object sender, EventArgs e)
        {
            ofd.Filter = "BackupFile (*.BAK)|*.Bak|All Files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtSelectFile.Text = ofd.FileName;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSelectFile.Text))
            {
                MessageBox.Show("مسیر فایل پشتیبان انتخاب نشده است");
            }
            else
            {
                Application.OpenForms["FrmBackupRestore"].Enabled = false;
                if (!backgroundWorkerRestore.IsBusy)
                {
                    backgroundWorkerRestore.RunWorkerAsync();
                }

            }
        }
        string DataPath1 = Application.StartupPath + @"\DB\";

        private void backgroundWorkerRestore_DoWork(object sender, DoWorkEventArgs e)
        {
            string _NameDataBase = Fm.NameDataBase.Caption;
            using (var context = new MyContext())
            {
                //string command = @"BACKUP DATABASE " + _NameDataBase + " TO DISK='" + txtSelectFile.Text + "_KmOld" + "' WITH INIT";
                string command = @"BACKUP DATABASE " + _NameDataBase + " TO DISK='" + txtSelectFile.Text + "_KmOld" + "' WITH COMPRESSION";
                context.Database.CommandTimeout = 360;
                context.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, command);
            }

            using (var context = new MyContext())
            {
                string command1 = "DECLARE @Table TABLE (LogicalName varchar(128),[PhysicalName] varchar(128), [Type] varchar, [FileGroupName] varchar(128), [Size] varchar(128)," +
                                  "[MaxSize] varchar(128), [FileId] varchar(128), [CreateLSN] varchar(128), [DropLSN] varchar(128), [UniqueId] varchar(128), [ReadOnlyLSN] varchar(128), [ReadWriteLSN] varchar(128)," +
                                  "[BackupSizeInBytes] varchar(128), [SourceBlockSize] varchar(128), [FileGroupId] varchar(128), [LogGroupGUID] varchar(128), [DifferentialBaseLSN] varchar(128), [DifferentialBaseGUID] varchar(128), [IsReadOnly] varchar(128), [IsPresent] varchar(128), [TDEThumbprint] varchar(128))" +
                                  "DECLARE @Path varchar(1000)='" + txtSelectFile.Text + "'" +
                                  "DECLARE @LogicalNameData varchar(128),@LogicalNameLog varchar(128)" +
                                  "INSERT INTO @table EXEC('RESTORE FILELISTONLY FROM DISK = ''' +@Path+ '''')" +
                                     "SET @LogicalNameData = (SELECT LogicalName FROM @Table WHERE Type = 'D')" +
                                     "SET @LogicalNameLog = (SELECT LogicalName FROM @Table WHERE Type = 'L')" +
                                  "SELECT @LogicalNameData";
                context.Database.CommandTimeout = 360;
                string LogicalNameData  = context.Database.SqlQuery<string>(command1).FirstOrDefault();

                string command2 = "DECLARE @Table TABLE (LogicalName varchar(128),[PhysicalName] varchar(128), [Type] varchar, [FileGroupName] varchar(128), [Size] varchar(128)," +
                                  "[MaxSize] varchar(128), [FileId] varchar(128), [CreateLSN] varchar(128), [DropLSN] varchar(128), [UniqueId] varchar(128), [ReadOnlyLSN] varchar(128), [ReadWriteLSN] varchar(128)," +
                                  "[BackupSizeInBytes] varchar(128), [SourceBlockSize] varchar(128), [FileGroupId] varchar(128), [LogGroupGUID] varchar(128), [DifferentialBaseLSN] varchar(128), [DifferentialBaseGUID] varchar(128), [IsReadOnly] varchar(128), [IsPresent] varchar(128), [TDEThumbprint] varchar(128))" +
                                  "DECLARE @Path varchar(1000)='" + txtSelectFile.Text + "'" +
                                  "DECLARE @LogicalNameData varchar(128),@LogicalNameLog varchar(128)" +
                                  "INSERT INTO @table EXEC('RESTORE FILELISTONLY FROM DISK = ''' +@Path+ '''')" +
                                     "SET @LogicalNameData = (SELECT LogicalName FROM @Table WHERE Type = 'D')" +
                                     "SET @LogicalNameLog = (SELECT LogicalName FROM @Table WHERE Type = 'L')" +
                                  "SELECT @LogicalNameLog";
                context.Database.CommandTimeout = 360;
                string LogicalNameLog = context.Database.SqlQuery<string>(command2).FirstOrDefault();



                string command3 = string.Empty;
                if (LogicalNameData != _NameDataBase + ".mdf")
                {
                    command3 = "ALTER DATABASE " + _NameDataBase + " SET OFFLINE WITH ROLLBACK IMMEDIATE" +
                            " RESTORE DATABASE " + _NameDataBase + " FROM DISK = '" + txtSelectFile.Text + "' WITH REPLACE, RECOVERY," +
                            " MOVE '" + LogicalNameData + "' TO '" + DataPath1 + _NameDataBase + ".mdf'," +
                            " MOVE '" + LogicalNameLog + "' TO '" + DataPath1 + _NameDataBase + "_log.ldf'" +
                            " ALTER DATABASE " + _NameDataBase + " MODIFY FILE(NAME = '" + LogicalNameData + "', NEWNAME = '" + _NameDataBase + ".mdf')" +
                            " ALTER DATABASE " + _NameDataBase + " MODIFY FILE(NAME = '" + LogicalNameLog + "', NEWNAME = '" + _NameDataBase + "_log.ldf')" +
                            " ALTER DATABASE " + _NameDataBase + " SET ONLINE";
                }
                else
                {
                    command3 = "ALTER DATABASE " + _NameDataBase + " SET OFFLINE WITH ROLLBACK IMMEDIATE" +
                            " RESTORE DATABASE " + _NameDataBase + " FROM DISK = '" + txtSelectFile.Text + "' WITH REPLACE, RECOVERY," +
                            " MOVE '" + LogicalNameData + "' TO '" + DataPath1 + _NameDataBase + ".mdf'," +
                            " MOVE '" + LogicalNameLog + "' TO '" + DataPath1 + _NameDataBase + "_log.ldf'" +
                            " ALTER DATABASE " + _NameDataBase + " SET ONLINE";
                }
                context.Database.CommandTimeout = 360;
                context.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, command3);

                //string command4 = "ALTER DATABASE " + _NameDataBase + " MODIFY FILE(NAME = '" + LogicalNameData + "', NEWNAME = '" + _NameDataBase + ".mdf')";
                //string command5 = "ALTER DATABASE " + _NameDataBase + " MODIFY FILE(NAME = '" + LogicalNameLog + "', NEWNAME = '" + _NameDataBase + "_log.ldf')";
                //context.Database.CommandTimeout = 360;
                //context.Database.ExecuteSqlCommand(command4,command5);
                //context.Database.ExecuteSqlCommand(command5);

            }
        }

        private void backgroundWorkerRestore_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                try
                {
                   // MessageBox.Show(" عملیات بازیابی اطلاعات با موفقیت انجام شد و برنامه مجدداً راه اندازی میشود");
                    MessageBox.Show("عملیات بازیابی اطلاعات با موفقیت انجام شد لطفاً برنامه را مجدداً اجرا کنید");
                    Application.OpenForms["FrmBackupRestore"].Enabled = true;
                    Application.Exit();
                   // Application.Restart();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    // Application.Exit();
                }
            }
            else
            {
                //MessageBox.Show("عملیات بازیابی با خطا مواجه شد");
                //Application.OpenForms["FrmBackupRestore"].Enabled = true;
                //txtSelectFile.Text = "";
                /////////////////////////////////////////////////////////////////////////
                try
                {
                   // MessageBox.Show(" عملیات بازیابی اطلاعات با موفقیت انجام شد و برنامه مجدداً راه اندازی میشود");
                    MessageBox.Show("عملیات بازیابی اطلاعات با موفقیت انجام شد لطفاً برنامه را مجدداً اجرا کنید");
                    Application.OpenForms["FrmBackupRestore"].Enabled = true;
                    Application.Exit();
                   // Application.Restart();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    // Application.Exit();
                }

            }
        }

        private void FrmBackupRestore_Load(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    string _NameDataBase = Fm.NameDataBase.Caption;
                    int _SId = Convert.ToInt32(Fm.IDSandogh.Caption);
                    string sText = "\\Backup_" + _NameDataBase + "_V"+ Application.ProductVersion +"_Date_" +
                            DateTime.Now.ToString().Replace("/", "").Substring(0, 8) + "_Time_" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(".", " ").Replace("ب ظ", "PM").Replace("ق ظ", "AM").Substring(8, 10) + ".BAK";
                    var q2 = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SId);
                    if (!string.IsNullOrEmpty(q2.Path))
                    {
                        txtSelectPath.Text = q2.Path + sText;
                        SPath.SelectedPath = q2.Path;
                    }
                    //else
                    //    txtSelectPath.Text = string.Empty;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

    }
}
