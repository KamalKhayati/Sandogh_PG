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
using System.Data.Entity;
using DevExpress.XtraGrid;
using DevExpress.Data;

namespace Sandogh_TG
{
    public partial class FrmSoratHesabTafzili : DevExpress.XtraEditors.XtraForm
    {

        public FrmSoratHesabTafzili()
        {
            InitializeComponent();
        }
        public void FillDataGridView1()
        {
            int TafziliId = Convert.ToInt32(cmbHesabTafzili.EditValue);
            using (var db = new MyContext())
            {
                try
                {
                    List<AsnadeHesabdariRow> List1 = new List<AsnadeHesabdariRow>();
                    var q1 = db.AsnadeHesabdariRows.Where(f => f.HesabTafId == TafziliId).ToList();
                    if (q1.Count > 0)
                    {
                        foreach (var item in q1)
                        {
                            AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
                            if (!List1.Any(f => f.HesabMoinId == item.HesabMoinId))
                            {
                                obj1.Id = item.Id;
                                obj1.HesabMoinId = item.HesabMoinId;
                                obj1.HesabMoinCode = item.HesabMoinCode;
                                obj1.HesabMoinName = item.HesabMoinName;
                                //obj1.HesabTafId = item.HesabTafId;
                                //obj1.HesabTafCode = item.HesabTafCode;
                                //obj1.HesabTafName = item.HesabTafName;
                                obj1.Bed = db.AsnadeHesabdariRows.Where(f => f.HesabTafId == TafziliId && f.HesabMoinId == item.HesabMoinId).Sum(f => f.Bed);
                                obj1.Bes = db.AsnadeHesabdariRows.Where(f => f.HesabTafId == TafziliId && f.HesabMoinId == item.HesabMoinId).Sum(f => f.Bes);
                                List1.Add(obj1);
                            }
                        }
                        asnadeHesabdariRowsBindingSource.DataSource = List1.OrderBy(f => f.HesabMoinCode);
                    }
                    else
                        asnadeHesabdariRowsBindingSource.DataSource = null;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        //long SumBed = 0;
        //long SumBes = 0;
        //long _Mande = 0;
        //GridColumnSummaryItem M1 = null;
        public void FillcmbHesabTafzili()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.AllHesabTafzilis.OrderBy(f => f.GroupTafziliId).ToList();
                    if (q.Count > 0)
                    {
                        allHesabTafzilisBindingSource.DataSource = q;
                    }
                    else
                        allHesabTafzilisBindingSource.DataSource = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillDataGridView2()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int TafziliId = Convert.ToInt32(cmbHesabTafzili.EditValue);
                    var q = db.AsnadeHesabdariRows.Where(f => f.HesabTafId == TafziliId).OrderBy(f => f.Tarikh).ThenBy(f => f.ShomareSanad).ToList();
                    if (q.Count > 0)
                    {
                        asnadeHesabdariRowsBindingSource1.DataSource = q;
                    }
                    else
                        asnadeHesabdariRowsBindingSource1.DataSource = null;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void cmbHesabTafzili_EditValueChanged(object sender, EventArgs e)
        {
            btnDisplyList_Click(null, null);
        }
        List<long> Result1;
        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            long bed = Convert.ToInt64(gridView1.GetListSourceRowCellValue(rowIndex, "Bed"));
            long bes = Convert.ToInt64(gridView1.GetListSourceRowCellValue(rowIndex, "Bes"));
            if (e.Column.FieldName != "Mande") return;
            if (e.IsGetData)
            {
                Result1.Add(bed - bes);
                e.Value = Result1[rowIndex];
            }
        }


        private void btnDisplyList_Click(object sender, EventArgs e)
        {
            Result1 = new List<long>();
           HelpClass1.Result2 = new List<long>();
            FillDataGridView1();
            FillDataGridView2();
        }

        private void cmbHesabTafzili_Enter(object sender, EventArgs e)
        {
            cmbHesabTafzili.ShowPopup();
        }

        private void gridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.gridView_CustomUnboundColumnData(sender, e, gridView2, "Bed", "Bes", "Mande1");
        }

        private void FrmSoratHesabTafzili_Load(object sender, EventArgs e)
        {
            FillcmbHesabTafzili();
            cmbHesabTafzili.Focus();
            //M1 = new GridColumnSummaryItem();
            //M1.SummaryType = SummaryItemType.Custom;
            //M1.FieldName = "Mande1";
            //M1.DisplayFormat = "{0:n}";
            //gridView2.Columns["Mande1"].Summary.Add(M1);

        }
        private void gridView2_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            HelpClass1.gridView_CustomSummaryCalculate(sender, e, gridView2, "Bed", "Bes", "Mande1");
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int TafziliId = Convert.ToInt32(cmbHesabTafzili.EditValue);
                        int MoinId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabMoinId"));
                        var q = db.AsnadeHesabdariRows.Where(f => f.HesabMoinId == MoinId && f.HesabTafId == TafziliId).OrderBy(f => f.Tarikh).ThenBy(f => f.ShomareSanad).ToList();
                        if (q.Count > 0)
                        {
                            HelpClass1.Result2 = new List<long>();
                            asnadeHesabdariRowsBindingSource1.DataSource = q;
                        }
                        else
                            asnadeHesabdariRowsBindingSource1.DataSource = null;


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