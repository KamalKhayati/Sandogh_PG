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
using Sandogh_TG.Models;
using System.IO;

namespace Sandogh_TG.Forms
{
    public partial class FrmTarifSandogh : DevExpress.XtraEditors.XtraForm
    {
        public FrmTarifSandogh()
        {
            InitializeComponent();
        }

        private void FrmTarifSandogh_Load(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q1 = db.TarifSandoghs.FirstOrDefault(s => s.Id == 1);
                    if (q1 != null)
                    {
                        txtNameSandogh.Text = q1.NameSandogh;
                        txtNameModir.Text = q1.NameModir;
                        txtKarmozdVam.Text = q1.Karmozd.ToString();
                        txtDirkard.Text = q1.Dirkard.ToString();
                        txtAdress.Text = q1.Adress;
                        txtTell.Text = q1.Tell;
                        txtMobile.Text = q1.Mobile;
                        txtTarikhEjad.Text = q1.TarikhEjad.ToString().Substring(0,10);
                        txtPath.Text = q1.Path;
                        if (q1.Pictuer != null)
                        {
                            MemoryStream ms = new MemoryStream(q1.Pictuer);
                            pictureEdit1.Image = Image.FromStream(ms);
                        }
                        else
                            pictureEdit1.Image = null;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void FrmTarifSandogh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnSaveClose_Click(sender, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, null);
            }

        }

        private void btnBrowsPictuer_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img = Image.FromFile(openFileDialog1.FileName);
                this.pictureEdit1.Image = img;
                //this.pictureEdit1.Tag = openFileDialog1.FileName;

            }
        }

        //string CopyPictuer(string sourcefile, string key)
        //{
        //    if (sourcefile == "")
        //        return null;
        //    string curentPath;
        //    string newPath;
        //    curentPath = Application.StartupPath + @"\image\";
        //    if (Directory.Exists(curentPath) == false)
        //    {
        //        Directory.CreateDirectory(curentPath);
        //    }

        //    newPath = curentPath + key + sourcefile.Substring(sourcefile.LastIndexOf("."));
        //    if (File.Exists(newPath))
        //    {
        //        File.Delete(newPath);
        //    }
        //    File.Copy(sourcefile, newPath);
        //    return newPath;
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pictureEdit1.Image = null;
        }

        Image img;
        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNameSandogh.Text))
            {
                XtraMessageBox.Show("لطفاً نام صندوق را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        var q1 = db.TarifSandoghs.FirstOrDefault(s => s.Id == 1);
                        if (q1 != null)
                        {
                            q1.NameSandogh = txtNameSandogh.Text;
                            q1.NameModir = txtNameModir.Text;
                            q1.Karmozd = Convert.ToSingle(txtKarmozdVam.Text);
                            q1.Dirkard = Convert.ToInt32(txtDirkard.Text);
                            q1.Adress = txtAdress.Text;
                            q1.Tell = txtTell.Text;
                            q1.Mobile = txtMobile.Text;
                            q1.TarikhEjad = Convert.ToDateTime(txtTarikhEjad.Text.Substring(0, 10));
                            q1.Path = txtPath.Text;
                            if (pictureEdit1.Image != null)
                            {
                                MemoryStream ms = new MemoryStream();
                                img.Save(ms, pictureEdit1.Image.RawFormat);
                                byte[] myarrey = ms.GetBuffer();
                                q1.Pictuer = myarrey;
                            }
                            else
                                q1.Pictuer = null;

                        }
                        else
                        {
                            TarifSandogh obj = new TarifSandogh();
                            obj.NameSandogh = txtNameSandogh.Text;
                            obj.NameModir = txtNameModir.Text;
                            obj.Karmozd =!string.IsNullOrEmpty(txtKarmozdVam.Text)? Convert.ToSingle(txtKarmozdVam.Text):0;
                            obj.Dirkard = !string.IsNullOrEmpty(txtDirkard.Text) ? Convert.ToInt32(txtDirkard.Text):0;
                            obj.Adress = txtAdress.Text;
                            obj.Tell = txtTell.Text;
                            obj.Mobile = txtMobile.Text;
                            if(!string.IsNullOrEmpty(txtTarikhEjad.Text))
                                obj.TarikhEjad =  Convert.ToDateTime(txtTarikhEjad.Text.Substring(0, 10));
                            obj.Path = txtPath.Text;
                            if (pictureEdit1.Image != null)
                            {
                                MemoryStream ms = new MemoryStream();
                                img.Save(ms, pictureEdit1.Image.RawFormat);
                                byte[] myarrey = ms.GetBuffer();
                                obj.Pictuer = myarrey;
                            }
                            else
                                obj.Pictuer = null;
                            db.TarifSandoghs.Add(obj);
                        }
                        
                        db.SaveChanges();
                        XtraMessageBox.Show("اطلاعات با موفقیت ثبت گردید" , "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        FolderBrowserDialog SPath = new FolderBrowserDialog();
        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            try
            {
                if (SPath.ShowDialog() == DialogResult.OK)
                {
                    if (SPath.SelectedPath.Length == 3)
                    {
                        txtPath.Text = SPath.SelectedPath + "BackupFile_Sandogh_TG";
                        //+"_Date_" + DateTime.Now.ToString().Replace("/", "").Substring(0, 8) + "_Time_" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(".", " ").Substring(8, 11) + ".BAK";
                        //txtSelectPath.Text = SPath.SelectedPath + "BackupFile_" +
                        //    DateTime.Now.Date.Year + DateTime.Now.Date.Month + DateTime.Now.Date.Day + "_" +
                        //    DateTime.Now.TimeOfDay.Hours + DateTime.Now.TimeOfDay.Minutes + DateTime.Now.TimeOfDay.Seconds + ".BAK";
                    }
                    else
                    {
                        txtPath.Text = SPath.SelectedPath + "\\BackupFile_Sandogh_TG";
                        //+"_Date_" + DateTime.Now.ToString().Replace("/", "").Substring(0, 8) + "_Time_" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(".", " ").Substring(8, 11) + ".BAK";
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
    }
}