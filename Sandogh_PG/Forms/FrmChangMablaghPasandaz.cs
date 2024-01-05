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
using DevExpress.XtraEditors.Mask;

namespace Sandogh_PG.Forms
{
    public partial class FrmChangMablaghPasandaz : DevExpress.XtraEditors.XtraForm
    {
        public FrmChangMablaghPasandaz()
        {
            InitializeComponent();
        }

        FrmTarifAaza_1 Fm;
        public FrmChangMablaghPasandaz(FrmTarifAaza_1 fm)
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

                        var q = db.Tanzimats.FirstOrDefault();
                        if (q != null)
                        {
                            var q2 = db.AazaSandoghs.ToList();
                            decimal _HaghOzviat = Convert.ToDecimal(txtHaghOzviat.Text.Replace(",", ""));

                            if (q.checkEdit17 == false)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    //q2[i].HaghOzviat = Convert.ToDecimal(txtHaghOzviat.Text.Replace(",", ""));
                                    int _id = Convert.ToInt32(dt.Rows[i][0].ToString());
                                    q2.FirstOrDefault(s => s.Id == _id).HaghOzviat = _HaghOzviat;
                                }

                            }
                            else if (q.checkEdit17)
                            {
                                if (q.radioGroup3 == 0)
                                {
                                    if (_HaghOzviat<q.MinMablaghPasandaz|| _HaghOzviat > q.MaxMablaghPasandaz)
                                    {
                                        XtraMessageBox.Show("مبلغ پس انداز جدید خارج از محدوده تعیین شده می باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    else
                                    {
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            //q2[i].HaghOzviat = Convert.ToDecimal(txtHaghOzviat.Text.Replace(",", ""));
                                            int _id = Convert.ToInt32(dt.Rows[i][0].ToString());
                                            q2.FirstOrDefault(s => s.Id == _id).HaghOzviat = _HaghOzviat;
                                        }

                                    }
                                }
                                else if (q.radioGroup3 == 1)
                                {
                                    if ((double)_HaghOzviat < q.MinDarsadPasandaz || (double)_HaghOzviat > q.MaxDarsadPasandaz)
                                    {
                                        XtraMessageBox.Show("درصد پس انداز جدید خارج از محدوده تعیین شده می باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    else
                                    {
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            //q2[i].HaghOzviat = Convert.ToDecimal(txtHaghOzviat.Text.Replace(",", ""));
                                            int _id = Convert.ToInt32(dt.Rows[i][0].ToString());
                                            q2.FirstOrDefault(s => s.Id == _id).DarsadPasandaz = (double)_HaghOzviat;
                                        }

                                    }

                                }
                            }
                        }



                        //var q = db.AazaSandoghs.ToList();
                        //for (int i = 0; i < q2.Count; i++)
                        //{
                        //    if (!dt.Rows.Contains(q2[i].Id))
                        //        q.Remove(q2[i]);
                        //}
                        ////var q = db.AazaSandoghs.Where(s => s.IsActive == IsActiveList).ToList();

                        //for (int i = 0; i < q.Count; i++)
                        //{
                        //    q[i].HaghOzviat = Convert.ToDecimal(txtHaghOzviat.Text.Replace(",", ""));
                        //}
                        //db.AazaSandoghs.Remove(q2[0]);
                        db.SaveChanges();
                        XtraMessageBox.Show("مبلغ پس انداز " + dt.Rows.Count + " عضو صندوق اصلاح گردید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //if (!string.IsNullOrEmpty(txtHaghOzviat.Text))
            //{
            //    btnSaveAndClose.Enabled = true;
            //}
            //else
            //{
            //    btnSaveAndClose.Enabled = false;

            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmChangMablaghPasandaz_Load(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.Tanzimats.FirstOrDefault();
                    if (q != null)
                    {
                        if (q.checkEdit17)
                        {
                            if (q.radioGroup3 == 1)
                            {
                                this.Text = "تغییر درصد پس انداز ماهیانه";
                                labelControl1.Text = "% پس انداز ماهیانه";
                                labelControl2.Text = "% سرمایه اولیه";
                                xtraTabControl1.TabPages[0].Text = "تغییر درصد پس انداز ماهیانه";

                                var settings = txtHaghOzviat.Properties.MaskSettings.Configure<MaskSettings.Numeric>();
                                settings.MaskExpression = "##.#0";
                                //txtHaghOzviat.Properties.MaskSetting = Numeric;
                            }
                        }
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