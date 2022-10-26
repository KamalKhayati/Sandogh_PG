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

namespace Sandogh_PG
{
    public partial class FrmPassword : DevExpress.XtraEditors.XtraForm
    {
        FrmLogin Fm;
        public FrmPassword(FrmLogin fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        private void FrmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            string _DefaultPassword = "@Km1373971983113012";
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                if (_DefaultPassword == txtPassword.Text)
                {
                    Fm.chkConnectToServer.Visible = Fm.chkConnectToServer.Visible == true ? false : true;
                    Fm.cmbNameDataBaseSandogh.Visible = true;
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("رمز وارده اشتباه است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Text = string.Empty;
                    txtPassword.Focus();
                    return;
                }
            }

        }
    }
}