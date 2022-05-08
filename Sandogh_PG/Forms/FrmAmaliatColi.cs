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
        public FrmAmaliatColi(FrmTarifAaza_1 fm)
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
                        var dt = new DataTable();

                        var keys = new DataColumn[1];
                        DataColumn column = new DataColumn();
                        column.DataType = Type.GetType("System.String");
                        column.ColumnName = "Id";
                        dt.Columns.Add(column);
                        keys[0] = column;
                        dt.PrimaryKey = keys;


                        for (int i = 0; i < Fm.gridView1.RowCount; i++)
                        {
                            DataRow dRow = dt.NewRow();
                            dRow["Id"] = Fm.gridView1.GetRowCellValue(i, "Id");
                            dt.Rows.Add(dRow);
                        }

                        var q2 = db.AazaSandoghs.ToList();
                        var q = db.AazaSandoghs.ToList();
                        for (int i = 0; i < q2.Count; i++)
                        {
                            if (!dt.Rows.Contains(q2[i].Id))
                                q.Remove(q2[i]);
                        }
                        //var q = db.AazaSandoghs.Where(s => s.IsActive == IsActiveList).ToList();

                        for (int i = 0; i < q.Count; i++)
                        {
                            q[i].HaghOzviat = Convert.ToDecimal(txtHaghOzviat.Text.Replace(",", ""));
                        }
                        db.SaveChanges();
                        XtraMessageBox.Show("مبلغ پس انداز " + q.Count + " عضو صندوق اصلاح گردید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!string.IsNullOrEmpty(txtHaghOzviat.Text))
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