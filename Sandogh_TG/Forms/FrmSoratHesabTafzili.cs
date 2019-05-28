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
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;

namespace Sandogh_TG
{
    public partial class FrmSoratHesabTafzili : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmSoratHesabTafzili(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
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
            _HesabMoin = string.Empty;
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
                        _HesabMoin = gridView1.GetFocusedRowCellDisplayText("HesabMoinName");

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        string FilePath = Application.StartupPath + @"\Report\Ghozareshat\";
        string FileName = "rptSoratHesabTafzili.repx";
        string _HesabMoin = string.Empty;

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(FilePath + FileName))
            {
                if (gridView2.RowCount > 0)
                {
                    XtraReport XtraReport1 = new XtraReport();
                    XtraReport1.LoadLayoutFromXml(FilePath + FileName);

                    XtraReport1.DataSource =HelpClass1.ConvettDatagridviewToDataSet(gridView2);

                    XtraReport1.Parameters["Az_Tarikh"].Value = ChkTarikh.Checked ? txtAzTarikh.Text : gridView2.GetRowCellDisplayText(0, "Tarikh").Substring(0, 10);
                    XtraReport1.Parameters["Ta_Tarikh"].Value = ChkTarikh.Checked ? txtTaTarikh.Text : DateTime.Now.ToString().Substring(0, 10);
                    XtraReport1.Parameters["TarikhVSaat"].Value = DateTime.Now;
                    XtraReport1.Parameters["HesabMoin"].Value = _HesabMoin;
                    XtraReport1.Parameters["HesabTafzil"].Value = cmbHesabTafzili.Text;
                    XtraReport1.Parameters["SandoghName"].Value = Fm.ribbonControl1.ApplicationDocumentCaption;
                    //List<decimal> ListMande1 = new List<decimal>();
                    //for (int i = 0; i < gridView1.RowCount; i++)
                    //{
                    //    ListMande1.Add(Convert.ToDecimal(gridView2.GetRowCellValue(i, "Mande1")));
                    //}
                    //XtraReport1.Parameters["Mande1"].Value = ListMande1;
                    FrmPrinPreview FPP = new FrmPrinPreview();
                    FPP.documentViewer1.DocumentSource = XtraReport1;
                    FPP.ShowDialog();

                }
            }
            else
            {
                HelpClass1.NewReportDesigner(FilePath, FileName);
            }
        }

        private void btnDesignReport_Click(object sender, EventArgs e)
        {
            HelpClass1.LoadReportDesigner(FilePath, FileName);
        }

        private void FrmSoratHesabTafzili_KeyDown(object sender, KeyEventArgs e)
        {
            HelpClass1.ControlAltShift_KeyDown(sender, e, btnDesignReport);

        }
    }

}