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
using Sandogh_PG;
using System.IO;
using System.Management;

namespace Sandogh_PG
{
    public partial class FrmTarifSandogh : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmTarifSandogh(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        private void FrmTarifSandogh_Load(object sender, EventArgs e)
        {
            txtTarikhEjad.Text = DateTime.Now.ToString().Substring(0, 10);
            HelpClass1.DateTimeMask(txtTarikhEjad);

            using (var db = new MyContext())
            {
                try
                {
                    var q1 = db.TarifSandoghs.FirstOrDefault(s => s.Id == 1);
                    if (q1 != null)
                    {
                        txtNameSandogh.Text = q1.NameSandogh;
                        txtNameModir.Text = q1.NameModir;
                        txtAdress.Text = q1.Adress;
                        txtTell.Text = q1.Tell;
                        txtMobile.Text = q1.Mobile;
                        if (q1.TarikhEjad != null)
                            txtTarikhEjad.Text = q1.TarikhEjad.ToString().Substring(0, 10);
                        chkIsDefault.Checked = q1.IsDefault;
                        if (q1.Pictuer != null)
                        {
                            MemoryStream ms = new MemoryStream(q1.Pictuer);
                            pictureEdit1.Image = Image.FromStream(ms);
                            img = pictureEdit1.Image;

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
            if (e.KeyCode == Keys.F5)
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
            XtraOpenFileDialog XtraOpenFileDialog1 = new XtraOpenFileDialog();
            XtraOpenFileDialog1.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";

            if (XtraOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img = Image.FromFile(XtraOpenFileDialog1.FileName);
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
                            q1.Adress = txtAdress.Text;
                            q1.Tell = txtTell.Text;
                            q1.Mobile = txtMobile.Text;
                            q1.IsDefault = chkIsDefault.Checked;
                            //q1.IsDefault = chkIsDefault.Checked;
                            if (!string.IsNullOrEmpty(txtTarikhEjad.Text))
                            {
                                q1.TarikhEjad = Convert.ToDateTime(txtTarikhEjad.Text.Substring(0, 10));

                            }
                            else
                                q1.TarikhEjad =Convert.ToDateTime(DateTime.Now.ToString().Substring(0, 10));

                            if (pictureEdit1.Image != null)
                            {
                                MemoryStream ms = new MemoryStream();
                                img.Save(ms, pictureEdit1.Image.RawFormat);
                                byte[] myarrey = ms.GetBuffer();
                                q1.Pictuer = myarrey;
                            }
                            else
                                q1.Pictuer = null;
                            /////////////////////////////////////////////////////////////////////
                            string MadarBoardCode = string.Empty;
                            ManagementObjectSearcher sercher2 = new ManagementObjectSearcher("select * from Win32_BaseBoard");
                            foreach (ManagementObject wmi_Board in sercher2.Get())
                            {
                                if (wmi_Board["SerialNumber"] != null)
                                    MadarBoardCode = wmi_Board["SerialNumber"].ToString().Trim();
                            }
                            if (q1.MadarBoardCode != MadarBoardCode.Substring(0, 10))
                            {
                                q1.MadarBoardCode = MadarBoardCode.Substring(0, 10);
                                db.SaveChanges();
                            }

                        }
                        //else
                        //{
                        //    TarifSandogh obj = new TarifSandogh();
                        //    obj.NameSandogh = txtNameSandogh.Text;
                        //    obj.NameModir = txtNameModir.Text;
                        //    obj.Adress = txtAdress.Text;
                        //    obj.Tell = txtTell.Text;
                        //    obj.Mobile = txtMobile.Text;
                        //    obj.IsDefault = chkIsDefault.Checked;
                        //    if (!string.IsNullOrEmpty(txtTarikhEjad.Text))
                        //        obj.TarikhEjad = Convert.ToDateTime(txtTarikhEjad.Text.Substring(0, 10));
                        //    else
                        //        q1.TarikhEjad = Convert.ToDateTime(DateTime.Now.ToString().Substring(0, 10));
                        //    if (pictureEdit1.Image != null)
                        //    {
                        //        MemoryStream ms = new MemoryStream();
                        //        img.Save(ms, pictureEdit1.Image.RawFormat);
                        //        byte[] myarrey = ms.GetBuffer();
                        //        obj.Pictuer = myarrey;
                        //    }
                        //    else
                        //        obj.Pictuer = null;
                        //    obj.PicBackground = null;
                        //    db.TarifSandoghs.Add(obj);
                        //}


                        db.SaveChanges();
                        XtraMessageBox.Show("اطلاعات با موفقیت ثبت گردید", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Fm.FrmMain_Load(null, null);
                        Fm.pictureEdit1.Image = pictureEdit1.Image;
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

    }
}