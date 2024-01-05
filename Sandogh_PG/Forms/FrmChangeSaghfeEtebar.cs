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
    public partial class FrmChangeSaghfeEtebar : DevExpress.XtraEditors.XtraForm
    {
        public FrmChangeSaghfeEtebar()
        {
            InitializeComponent();
        }

        FrmTarifAaza_1 Fm;
        public FrmChangeSaghfeEtebar(FrmTarifAaza_1 fm)
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
                        //var q3 = db.Tanzimats.FirstOrDefault();
                        for (int i = 0; i < q2.Count; i++)
                        {
                            if (!dt.Rows.Contains(q2[i].Id))
                                q.Remove(q2[i]);
                        }

                        //var q = db.AazaSandoghs.Where(s => s.IsActive == IsActiveList).ToList();

                        for (int i = 0; i < q.Count; i++)
                        {
                            if (radioGroup1.SelectedIndex == 0)
                            {
                                q[i].SaghfeEtebar = Convert.ToDecimal(txtSaghfeEtebar.Text.Replace(",", ""));
                            }
                            else if (radioGroup1.SelectedIndex == 1)
                            {
                                var q4 = db.AsnadeHesabdariRows.Where(s => s.HesabMoinCode == 7001).ToList();
                                decimal _XBrabarSarmaye = !string.IsNullOrEmpty(txtXBrabarSarmaye.Text.Replace(",", "")) ? Convert.ToDecimal(txtXBrabarSarmaye.Text.Replace(",", "")) : 0;
                                decimal _MazrabEtebar = !string.IsNullOrEmpty(txtMazrabEtebar.Text.Replace(",", "")) ? Convert.ToDecimal(txtMazrabEtebar.Text.Replace(",", "")) : 0;

                                var q5 = q4.Where(s => s.HesabTafId == q[i].AllTafId).ToList();
                                decimal sumbed = q5.Sum(s => s.Bed) ?? 0;
                                decimal sumbes = q5.Sum(s => s.Bes) ?? 0;
                                decimal _SaghfeEtebar = (sumbes - sumbed) >= 0 ? _XBrabarSarmaye * (sumbes - sumbed) : 0;
                                //decimal _SaghfeEtebar =  0;
                                //if (q3.checkEdit8 == false)
                                //{
                                //    q[i].SaghfeEtebar = _SaghfeEtebar;
                                //}
                                //else
                                //{
                                //decimal _MablaghMazrab = q3.MazrabEtebar;
                                if (_MazrabEtebar != 0)
                                {

                                    float Sm = Convert.ToSingle(_SaghfeEtebar / _MazrabEtebar);
                                    int rounded = (int)Math.Round(Sm);
                                    q[i].SaghfeEtebar = rounded * _MazrabEtebar;
                                }
                                else
                                {
                                    XtraMessageBox.Show("مضرب اعتبار باید عددی بزرگتر از صفر باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                //}
                            }
                            else if (radioGroup1.SelectedIndex == 2)
                            {
                                //var q4 = q.Where(s => s.HesabMoinCode == 7001).ToList();
                                decimal _XBrabarSarmaye2 = !string.IsNullOrEmpty(txtXBrabarSarmaye2.Text.Replace(",", "")) ? Convert.ToDecimal(txtXBrabarSarmaye2.Text.Replace(",", "")) : 0;
                                decimal _MazrabEtebar2 = !string.IsNullOrEmpty(txtMazrabEtebar2.Text.Replace(",", "")) ? Convert.ToDecimal(txtMazrabEtebar2.Text.Replace(",", "")) : 0;


                                var q5 = q.FirstOrDefault(s => s.AllTafId == q[i].AllTafId);
                                //decimal sumbed = q5.Sum(s => s.Bed) ?? 0;
                                //decimal sumbes = q5.Sum(s => s.Bes) ?? 0;
                                decimal _SaghfeEtebar = q5 != null && q5.BesAvali != null ? _XBrabarSarmaye2 * q5.BesAvali ?? 0 : 0;
                                //decimal _SaghfeEtebar =  0;
                                //if (q3.checkEdit8 == false)
                                //{
                                //    q[i].SaghfeEtebar = _SaghfeEtebar;
                                //}
                                //else
                                //{
                                //decimal _MablaghMazrab = q3.MazrabEtebar;
                                if (_MazrabEtebar2 != 0)
                                {

                                    float Sm = Convert.ToSingle(_SaghfeEtebar / _MazrabEtebar2);
                                    int rounded = (int)Math.Round(Sm);
                                    q[i].SaghfeEtebar = rounded * _MazrabEtebar2;
                                }
                                else
                                {
                                    XtraMessageBox.Show("مضرب اعتبار باید عددی بزرگتر از صفر باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                //}
                            }
                        }
                        db.SaveChanges();
                        Fm.IsChangeSaghfeEtebar = true;
                        XtraMessageBox.Show("سقف اعتبار " + q.Count + " عضو صندوق اصلاح گردید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtSaghfeEtebar_EditValueChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtSaghfeEtebar.Text))
            //{
            //    btnSaveAndClose.Enabled = true;
            //}
            //else
            //{
            //    btnSaveAndClose.Enabled = false;

            //}

            //if (radioGroup1.SelectedIndex == 0)
            //{
            //    if (!string.IsNullOrEmpty(txtSaghfeEtebar.Text))
            //        btnSaveAndClose.Enabled = true;
            //    else
            //        btnSaveAndClose.Enabled = false;
            //}
            //else if (radioGroup1.SelectedIndex == 1)
            //{

            //}
            //else if (radioGroup1.SelectedIndex == 2)
            //{

            //}
            btnSaveAndClose.Enabled = radioGroup1.SelectedIndex == 0 && !string.IsNullOrEmpty(txtSaghfeEtebar.Text) ? true : false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSaghfeEtebar.ReadOnly = radioGroup1.SelectedIndex == 0 ? false : true;
            txtXBrabarSarmaye.ReadOnly = txtMazrabEtebar.ReadOnly = radioGroup1.SelectedIndex == 1 ? false : true;
            txtXBrabarSarmaye2.ReadOnly = txtMazrabEtebar2.ReadOnly = radioGroup1.SelectedIndex == 2 ? false : true;
            txtSaghfeEtebar.Text = txtXBrabarSarmaye.Text = txtXBrabarSarmaye2.Text = txtMazrabEtebar.Text = txtMazrabEtebar2.Text = string.Empty;
        }

        private void FrmChangeSaghfeEtebar_Load(object sender, EventArgs e)
        {
            radioGroup1.SelectedIndex = 0;
            //using (var db = new MyContext())
            //{
            //    try
            //    {
            //        var q = db.Tanzimats.FirstOrDefault();
            //        if (q != null)
            //        {
            //            //radioGroup1.Properties.Items[0].Description = "مبلغ سقف اعتبار جدید (بصورت یکسان)";
            //            if (q.checkEdit7)
            //            {
            //                radioGroup1.Properties.Items[1].Description = "مبلغ سقف اعتبار جدید " + q.XBrabarSarmaye.ToString() + " برابر مبلغ سرمایه";
            //                radioGroup1.SelectedIndex = 1;
            //                radioGroup1.Properties.Items[1].Enabled = true;
            //                if (q.checkEdit8)
            //                    radioGroup1.Properties.Items[1].Description = "مبلغ سقف اعتبار جدید " + q.XBrabarSarmaye.ToString() + " برابر مبلغ سرمایه" + " (مضرب اعتبار: " + q.MazrabEtebar.ToString("n0") + ")";
            //            }
            //            else
            //            {
            //                radioGroup1.SelectedIndex = 0;
            //                radioGroup1.Properties.Items[1].Enabled = false;
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
            //            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

        }

        private void txtXBrabarSarmaye_EditValueChanged(object sender, EventArgs e)
        {
            btnSaveAndClose.Enabled = radioGroup1.SelectedIndex == 1 && !string.IsNullOrEmpty(txtXBrabarSarmaye.Text) ? true : false;

        }

        private void txtXBrabarSarmaye2_EditValueChanged(object sender, EventArgs e)
        {
            btnSaveAndClose.Enabled = radioGroup1.SelectedIndex == 2 && !string.IsNullOrEmpty(txtXBrabarSarmaye2.Text) ? true : false;

        }
    }
}