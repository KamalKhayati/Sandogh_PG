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


namespace Sandogh_TG
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
                    if (SPath.SelectedPath.Length == 3)
                    {
                        txtSelectPath.Text = SPath.SelectedPath + "BackupFile_Sandoogh_Date_" +
                            DateTime.Now.ToString().Replace("/", "").Substring(0, 8) + "_Time_" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(".", " ").Substring(8, 11) + ".BAK";
                        //txtSelectPath.Text = SPath.SelectedPath + "BackupFile_" +
                        //    DateTime.Now.Date.Year + DateTime.Now.Date.Month + DateTime.Now.Date.Day + "_" +
                        //    DateTime.Now.TimeOfDay.Hours + DateTime.Now.TimeOfDay.Minutes + DateTime.Now.TimeOfDay.Seconds + ".BAK";
                    }
                    else
                    {
                        txtSelectPath.Text = SPath.SelectedPath + "\\BackupFile_Sandoogh_Date_" +
                            DateTime.Now.ToString().Replace("/", "").Substring(0, 8) + "_Time_" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(".", " ").Substring(8, 11) + ".BAK";
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
                Application.OpenForms["FrmBackupRestore"].Enabled = false;
                if (!backgroundWorkerBackup.IsBusy)
                {
                    backgroundWorkerBackup.RunWorkerAsync();
                }
            }

        }

        private void backgroundWorkerBackup_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var context = new MyContext())
            {
                string command = @"BACKUP DATABASE Sandogh_TG_N1_V1 TO DISK='" + txtSelectPath.Text + "' WITH INIT";
                context.Database.CommandTimeout = 360;
                context.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, command);
            }
            //string strSQL = @"BACKUP DATABASE  Sandogh_TG_N1_V1  TO DISK='" + txtSelectPath.Text + "'";
            //SqlConnection con = new SqlConnection();
            //SqlCommand com = new SqlCommand();
            //con.ConnectionString = @"Data Source=KAMAL-PC\SQL2008;Initial Catalog=Sandogh_TG_N1_V1;
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

        private void backgroundWorkerRestore_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var context = new MyContext())
            {
                string command = @"BACKUP DATABASE Sandogh_TG_N1_V1 TO DISK='" + txtSelectFile.Text + "_KmOld" + "' WITH INIT";
                context.Database.CommandTimeout = 360;
                context.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, command);
            }

            using (var context = new MyContext())
            {
                string command = "ALTER DATABASE Sandogh_TG_N1_V1 SET OFFLINE WITH ROLLBACK IMMEDIATE " +
                                   " RESTORE DATABASE Sandogh_TG_N1_V1 FROM DISK='" + txtSelectFile.Text + "'WITH REPLACE " +
                                    "ALTER DATABASE Sandogh_TG_N1_V1 SET ONLINE";
                context.Database.CommandTimeout = 360;
                context.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, command);
            }
        }

        private void backgroundWorkerRestore_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                //MessageBox.Show(" عملیات بازیابی اطلاعات با موفقیت انجام شد و برنامه مجدداً راه اندازی میشود");
                MessageBox.Show("عملیات بازیابی اطلاعات با موفقیت انجام شد");
                Application.OpenForms["FrmBackupRestore"].Enabled = true;
                //Application.Exit();
                //Application.Restart();
            }
            else
            {
                MessageBox.Show("عملیات بازیابی با خطا مواجه شد");
                Application.OpenForms["FrmBackupRestore"].Enabled = true;
                txtSelectFile.Text = "";
            }
        }

        private void FrmBackupRestore_Load(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _SId = Convert.ToInt32(Fm.IDSandogh.Caption);
                    string sText = "\\BackupFile_Sandoogh_Date_" +
                            DateTime.Now.ToString().Replace("/", "").Substring(0, 8) + "_Time_" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(".", " ").Substring(8, 11) + ".BAK";
                    var q2 = db.Tanzimats.FirstOrDefault(s => s.Id == _SId);
                    if (!string.IsNullOrEmpty(q2.Path))
                    {
                        txtSelectPath.Text = q2.Path +sText ;
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
