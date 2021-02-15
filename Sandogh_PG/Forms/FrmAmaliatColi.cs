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
    public partial class FrmAmaliatColi : DevExpress.XtraEditors.XtraForm
    {
        public FrmAmaliatColi()
        {
            InitializeComponent();
        }

         FrmTarifAaza_1 Fm;
        public FrmAmaliatColi( FrmTarifAaza_1 fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        public bool IsActiveList;

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (XtraMessageBox.Show("آیا مطمئن هستید؟", "پیغام ذخیره", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        var q = db.AazaSandoghs.Where(s => s.IsActive == IsActiveList).ToList();
                        for (int i = 0; i < q.Count; i++)
                        {
                            q[i].HaghOzviat = Convert.ToDecimal(txtHaghOzviat.Text.Replace(",", ""));
                        }
                        db.SaveChanges();
                        XtraMessageBox.Show("مبلغ پس انداز " + q.Count + " عضو صندوق اصلاح گردید","پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        Fm.FillDataGridTarifAaza();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void txtHaghOzviat_EditValueChanged(object sender, EventArgs e)
        {
            if (txtHaghOzviat.Text!="0" && !string.IsNullOrEmpty(txtHaghOzviat.Text))
            {
                btnSaveAndClose.Enabled = true;
            }
            else
            {
                btnSaveAndClose.Enabled = false;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}