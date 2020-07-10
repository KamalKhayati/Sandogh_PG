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
    public partial class FrmShenaseVRamz : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmShenaseVRamz(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Fm.IsOkDelete = false;
            this.Close();
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
                            Fm.IsOkDelete = true;
                            this.Close();
                        }
                        else
                        {
                            XtraMessageBox.Show("شناسه یا رمز عبور اشتباه است",
                                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Fm.IsOkDelete = false;
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
    }
}