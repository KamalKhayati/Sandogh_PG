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

namespace Sandogh_PG
{
    public partial class FrmSoratHesabTafzili : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmSoratHesabTafzili(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        int _SandoghId = 0;
        public void FillDataGridView1()
        {
            int TafziliId = Convert.ToInt32(cmbHesabTafzili.EditValue);
            var StartData = Convert.ToDateTime(txtAzTarikh.Text);
            var EndData = Convert.ToDateTime(txtTaTarikh.Text);
            using (var db = new MyContext())
            {
                try
                {
                    List<AsnadeHesabdariRow> List1 = new List<AsnadeHesabdariRow>();
                    var q1 = db.AsnadeHesabdariRows.Where(f => f.HesabTafId == TafziliId && f.Tarikh <= EndData).AsParallel();
                    //var p1 = db.CodeMoins.ToList();
                    if (q1.Count() > 0)
                    {
                        var q2 = q1.Select(s => s.HesabMoinId).Distinct().AsParallel();
                        foreach (var item in q2)
                        {
                            //var q3 = q1.Where(s => s.HesabMoinId == item).ToList();
                            AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
                            if (!List1.Any(f => f.HesabMoinId == item))
                            {
                                //obj1.Id = q1.FirstOrDefault(s => s.HesabMoinId == item).Id;
                                obj1.HesabMoinId = item;
                                obj1.HesabMoinCode = q1.FirstOrDefault(s => s.HesabMoinId == item).CodeMoin1.Code;
                                //obj1.HesabMoinName = q3.FirstOrDefault().HesabMoinName;
                                obj1.HesabMoinName = q1.FirstOrDefault(s => s.HesabMoinId == item).CodeMoin1.Name;
                                //obj1.HesabMoinName = p1.FirstOrDefault(s=>s.SandoghId==_SandoghId && s.Id==item).Name;
                                //obj1.HesabTafId = item.HesabTafId;
                                //obj1.HesabTafCode = item.HesabTafCode;
                                //obj1.HesabTafName = item.HesabTafName;
                                obj1.Bed = q1.Where(s => s.HesabMoinId == item).Sum(f => f.Bed);
                                obj1.Bes = q1.Where(s => s.HesabMoinId == item).Sum(f => f.Bes);
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
                    var q1 = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SandoghId).checkEdit4;

                    if (q1)
                    {
                        var q = db.AllHesabTafzilis.Where(f => f.IsActive == q1).OrderBy(f => f.GroupTafziliId).AsParallel();
                        if (q.Count() > 0)
                        {
                            allHesabTafzilisBindingSource.DataSource = q;
                        }
                        else
                            allHesabTafzilisBindingSource.DataSource = null;
                    }
                    else
                    {
                        var q = db.AllHesabTafzilis.OrderBy(f => f.GroupTafziliId).AsParallel();
                        if (q.Count() > 0)
                        {
                            allHesabTafzilisBindingSource.DataSource = q;
                        }
                        else
                            allHesabTafzilisBindingSource.DataSource = null;
                    }
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
                    asnadeHesabdariRowsBindingSource1.Clear();
                    asnadeHesabdariRowsBindingSource1.DataSource = null;
                    //HelpClass1.rowHandel = 0;
                    int TafziliId = Convert.ToInt32(cmbHesabTafzili.EditValue);
                    var StartData = Convert.ToDateTime(txtAzTarikh.Text);
                    var EndData = Convert.ToDateTime(txtTaTarikh.Text);
                    int yyyy1 = Convert.ToInt32(txtAzTarikh.Text.Substring(0, 4));
                    int MM1 = Convert.ToInt32(txtAzTarikh.Text.Substring(5, 2));
                    int dd1 = Convert.ToInt32(txtAzTarikh.Text.Substring(8, 2));
                    Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                    d1.DecrementDay();
                    var q2 = db.AsnadeHesabdariRows.Where(f => f.HesabTafId == TafziliId && f.Tarikh <= EndData).OrderBy(f => f.Tarikh).AsParallel();
                    var q = q2.ToList();
                    var p1 = q.Where(s => s.Tarikh < StartData).OrderBy(f => f.Tarikh).AsParallel();
                    var q1 = p1.ToList();

                    if (q.Count > 0)
                    {
                        if (q1.Count > 0)
                        {
                            q.RemoveRange(0, q1.Count);
                            AsnadeHesabdariRow obj = new AsnadeHesabdariRow();
                            //obj.ShomareSanad = 0;
                            obj.Tarikh = Convert.ToDateTime(d1);
                            obj.Sharh = "جمع مانده حساب از قبل";
                            obj.Bed = q1.Sum(s => s.Bed);
                            obj.Bes = q1.Sum(s => s.Bes);
                            q.Add(obj);
                        }
                        asnadeHesabdariRowsBindingSource1.DataSource = q.OrderBy(f => f.Tarikh).ThenBy(f => f.ShomareSanad);
                        HelpClass1.MoveLast(gridView2);
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
            if (Convert.ToInt32(cmbHesabTafzili.EditValue) != 0)
            {
                btnDisplyList_Click(null, null);
                //cmbHesabTafzili.ShowPopup(); 
            }
        }
        List<decimal> Result1;
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
            Result1 = new List<decimal>();
            HelpClass1.Result2 = new List<decimal>();
            FillDataGridView1();
            FillDataGridView2();
        }

        private void cmbHesabTafzili_Enter(object sender, EventArgs e)
        {
            //btnDisplyList_Click(null, null);
            cmbHesabTafzili.ShowPopup();
        }

        private void gridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.gridView_CustomUnboundColumnData(sender, e, gridView2, "Bed", "Bes", "Mande1");

        }


        private void FrmSoratHesabTafzili_Load(object sender, EventArgs e)
        {
            txtAzTarikh.Text = new MyContext().AsnadeHesabdariRows.Any() ? new MyContext().AsnadeHesabdariRows.Min(f => f.Tarikh).ToString().Substring(0, 10) : "1398/01/01";
            txtTaTarikh.Text = DateTime.Now.ToString().Substring(0, 10);
            HelpClass1.DateTimeMask(txtAzTarikh);
            HelpClass1.DateTimeMask(txtTaTarikh);
            _SandoghId = Convert.ToInt32(Fm.IDSandogh.Caption);
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
                        var StartData = Convert.ToDateTime(txtAzTarikh.Text);
                        var EndData = Convert.ToDateTime(txtTaTarikh.Text);
                        int yyyy1 = Convert.ToInt32(txtAzTarikh.Text.Substring(0, 4));
                        int MM1 = Convert.ToInt32(txtAzTarikh.Text.Substring(5, 2));
                        int dd1 = Convert.ToInt32(txtAzTarikh.Text.Substring(8, 2));
                        Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                        d1.DecrementDay();
                        var p = db.AsnadeHesabdariRows.Where(f => f.HesabTafId == TafziliId && f.HesabMoinId == MoinId && f.Tarikh <= EndData).OrderBy(f => f.Tarikh).AsParallel();
                        var q = p.ToList();
                        var p1 = p.Where(s => s.Tarikh < StartData).OrderBy(f => f.Tarikh).AsParallel();
                        var q1 = p1.ToList();

                        if (q.Count > 0)
                        {
                            if (q1.Count > 0)
                            {
                                q.RemoveRange(0, q1.Count);
                                AsnadeHesabdariRow obj = new AsnadeHesabdariRow();
                                //obj.ShomareSanad = 0;
                                obj.Tarikh = Convert.ToDateTime(d1);
                                obj.Sharh = "جمع مانده حساب از قبل";
                                obj.Bed = q1.Sum(s => s.Bed);
                                obj.Bes = q1.Sum(s => s.Bes);
                                q.Add(obj);
                            }
                            HelpClass1.Result2 = new List<decimal>();
                            asnadeHesabdariRowsBindingSource1.DataSource = null;
                            asnadeHesabdariRowsBindingSource1.DataSource = q.OrderBy(f => f.Tarikh).ThenBy(f => f.ShomareSanad);
                            HelpClass1.MoveLast(gridView2);
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

                //using (var db = new MyContext())
                //{
                //    try
                //    {
                //        int TafziliId = Convert.ToInt32(cmbHesabTafzili.EditValue);
                //        int MoinId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabMoinId"));
                //        var q = db.AsnadeHesabdariRows.Where(f => f.HesabMoinId == MoinId && f.HesabTafId == TafziliId).OrderBy(f => f.Tarikh).ThenBy(f => f.ShomareSanad).ToList();
                //        if (q.Count > 0)
                //        {
                //            HelpClass1.Result2 = new List<decimal>();
                //            asnadeHesabdariRowsBindingSource1.DataSource = q;
                //        }
                //        else
                //            asnadeHesabdariRowsBindingSource1.DataSource = null;
                //        _HesabMoin = gridView1.GetFocusedRowCellDisplayText("HesabMoinName");

                //    }
                //    catch (Exception ex)
                //    {
                //        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                //            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}

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

                    XtraReport1.DataSource = HelpClass1.ConvettDatagridviewToDataSet(gridView2);

                    XtraReport1.Parameters["Az_Tarikh"].Value = txtAzTarikh.Text;
                    XtraReport1.Parameters["Ta_Tarikh"].Value = txtTaTarikh.Text;
                    XtraReport1.Parameters["TarikhVSaat"].Value = DateTime.Now;
                    XtraReport1.Parameters["HesabMoin"].Value = _HesabMoin;
                    XtraReport1.Parameters["HesabTafzil"].Value = cmbHesabTafzili.Text;
                    XtraReport1.Parameters["SandoghName"].Value = Fm.ribbonControl1.ApplicationDocumentCaption;
                    XtraReport1.Parameters["Logo_Co"].Value = Fm.pictureEdit1.Image;

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