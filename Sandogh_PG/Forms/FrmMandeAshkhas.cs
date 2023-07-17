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
using DevExpress.XtraReports.UI;
using System.Data.Entity;

namespace Sandogh_PG
{
    public partial class FrmMandeAshkhas : DevExpress.XtraEditors.XtraForm
    {
        public FrmMandeAshkhas()
        {
            InitializeComponent();
        }

        FrmMain Fm;
        public FrmMandeAshkhas(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        int _SandoghId = 0;
        private void FrmMandeAshkhas_Load(object sender, EventArgs e)
        {
            txtTaTarikh.Text = DateTime.Now.ToString().Substring(0, 10);
            HelpClass1.DateTimeMask(txtTaTarikh);
            _SandoghId = Convert.ToInt32(Fm.IDSandogh.Caption);
            FillDataGridView1();
            //FillDataGridView2();

            txtTaTarikh.Focus();
        }

        public void FillDataGridView1()
        {
            using (var db = new MyContext())
            {
                try
                {
                    DateTime _Ta = Convert.ToDateTime(txtTaTarikh.Text);
                    List<AsnadeHesabdariRow> List1 = new List<AsnadeHesabdariRow>();
                    var q2 = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SandoghId).checkEdit4;
                    var q3 = db.AllHesabTafzilis.Where(s => s.IsActive == false).ToList();
                    var q1 = db.AsnadeHesabdariRows.Where(f => f.Tarikh <= _Ta && f.HesabTafCode >= 7000001 && f.HesabTafCode <= 7999999).ToList();
                    var q4 = q1.Select(s => s.HesabTafId).Distinct().ToList();

                    if (q4.Count > 0)
                    {
                        foreach (var item in q4)
                        {
                            var q5 = q1.FirstOrDefault(s => s.HesabTafId == item);
                            if (q2)
                            {
                                if (!q3.Any(s => s.Id == item))
                                {
                                    AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
                                    if (!List1.Any(f => f.HesabTafId == item))
                                    {
                                        //obj1.Id = item.Id;
                                        obj1.HesabMoinId = q5.HesabMoinId;
                                        obj1.HesabMoinCode = q5.HesabMoinCode;
                                        obj1.HesabMoinName = q5.HesabMoinName;
                                        obj1.HesabTafId = q5.HesabTafId;
                                        obj1.HesabTafCode = q5.HesabTafCode;
                                        obj1.HesabTafName = q5.HesabTafName;
                                        //obj1.HesabTafId = item.HesabTafId;
                                        //obj1.HesabTafCode = item.HesabTafCode;
                                        //obj1.HesabTafName = item.HesabTafName;
                                        obj1.Mande01 = q1.Where(f => f.HesabTafId == item).Sum(f => f.Bed) - q1.Where(f => f.HesabTafId == item).Sum(f => f.Bes);
                                        //obj1.Bes = q1.Where(f => f.HesabTafId == item.HesabTafId).Sum(f => f.Bes);
                                        List1.Add(obj1);
                                    }
                                }
                            }
                            else
                            {
                                AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
                                if (!List1.Any(f => f.HesabTafId == item))
                                {
                                    //obj1.Id = item.Id;
                                    obj1.HesabMoinId = q5.HesabMoinId;
                                    obj1.HesabMoinCode = q5.HesabMoinCode;
                                    obj1.HesabMoinName = q5.HesabMoinName;
                                    obj1.HesabTafId = q5.HesabTafId;
                                    obj1.HesabTafCode = q5.HesabTafCode;
                                    obj1.HesabTafName = q5.HesabTafName;
                                    //obj1.HesabTafId = item.HesabTafId;
                                    //obj1.HesabTafCode = item.HesabTafCode;
                                    //obj1.HesabTafName = item.HesabTafName;
                                    obj1.Mande01 = q1.Where(f => f.HesabTafId == item).Sum(f => f.Bed) - q1.Where(f => f.HesabTafId == item).Sum(f => f.Bes);
                                    //obj1.Bes = q1.Where(f => f.HesabTafId == item.HesabTafId).Sum(f => f.Bes);
                                    List1.Add(obj1);
                                }

                            }

                        }
                        asnadeHesabdariRowsBindingSource.DataSource = List1.OrderBy(f => f.HesabTafCode);
                    }
                    else
                        asnadeHesabdariRowsBindingSource.DataSource = null;

                }
                catch (Exception)
                {
                    //XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                    //    "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillDataGridView2()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (var db = new MyContext())
            {
                try
                {
                    dt.Columns.Add("Line");
                    dt.Columns.Add("HesabTafCode");
                    dt.Columns.Add("HesabTafName");
                    dt.Columns.Add("Mande01");
                    var q = db.CodeMoins.Select(f => f.Code).ToArray();
                    for (int ColumnCounter = 0; ColumnCounter < new MyContext().CodeMoins.Count(); ColumnCounter++)
                        dt.Columns.Add(q[ColumnCounter].ToString());


                    for (int RowCounter = 0; RowCounter < gridView1.RowCount; RowCounter++)
                    {
                        DataRow DataRow1 = dt.NewRow();
                        for (int j = 0; j < 4; j++)
                        {
                            //DataRow1[j] = gridView.Rows[RowCounter].Cells[j].Value.ToString();
                            string s2 = gridView1.GetRowCellDisplayText(RowCounter, gridView1.Columns[dt.Columns[j].ColumnName]);
                            DataRow1[j] = s2;
                        }

                        DateTime _Ta = Convert.ToDateTime(txtTaTarikh.Text);
                        var q1 = db.AsnadeHesabdariRows.Where(f => f.Tarikh <= _Ta && f.HesabTafCode >= 7000001 && f.HesabTafCode <= 7999999).ToList();
                        for (int j = 0; j < dt.Columns.Count - 4; j++)
                        {
                            //DataRow1[j] = gridView.Rows[RowCounter].Cells[j].Value.ToString
                            int _CodeMoin = Convert.ToInt32(dt.Columns[j + 4].ColumnName);
                            int _CodeTafzil = Convert.ToInt32(gridView1.GetRowCellDisplayText(RowCounter, gridView1.Columns[dt.Columns[1].ColumnName]));
                            var q2 = q1.Where(f => f.HesabMoinCode == _CodeMoin && f.HesabTafCode == _CodeTafzil);
                            decimal _SumBed = q2.Sum(f => f.Bed ?? 0);
                            decimal _SumBes = q2.Sum(f => f.Bes ?? 0);
                            decimal Mablagh = _SumBed - _SumBes;
                            DataRow1[j + 4] = Mablagh.ToString("N0");
                        }

                        dt.Rows.Add(DataRow1);
                    }
                    gridControl2.DataSource = dt;
                    //ds.Tables.Add(dt);

                }
                catch (Exception)
                {
                    //XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                    //    "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);
        }

        string FilePath = Application.StartupPath + @"\Report\Ghozareshat\";
        string FileName1 = "rptMandeTalfighiAshkhas.repx";
        string FileName2 = "rptMandeTafkikiAshkhas.repx";

        public string _SandoghName = string.Empty;

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                DataTable dt = new DataTable();
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    //if (gridView1.Columns[i].Visible)
                    dt.Columns.Add(gridView1.Columns[i].FieldName);
                }

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    DataRow dRow = dt.NewRow();
                    //dRow[cell.ColumnIndex] = cell.Value;
                    if (gridView1.Columns["Line"].Visible)
                        dRow["Line"] = gridView1.GetRowCellValue(i, "Line");
                    if (gridView1.Columns["HesabTafCode"].Visible)
                        dRow["HesabTafCode"] = gridView1.GetRowCellValue(i, "HesabTafCode");
                    if (gridView1.Columns["HesabTafName"].Visible)
                        dRow["HesabTafName"] = gridView1.GetRowCellDisplayText(i, "HesabTafName");
                    if (gridView1.Columns["Mande01"].Visible)
                        dRow["Mande01"] = gridView1.GetRowCellDisplayText(i, "Mande01");
                    dt.Rows.Add(dRow);
                }

                if (System.IO.File.Exists(FilePath + FileName1))
                {
                    if (gridView1.RowCount > 0)
                    {
                        XtraReport XtraReport1 = new XtraReport();
                        XtraReport1.LoadLayoutFromXml(FilePath + FileName1);

                        //XtraReport1.DataSource = gridView1.DataSource;
                        XtraReport1.DataSource = dt;

                        // XtraReport1.Parameters["Az_Tarikh"].Value = ChkTarikh.Checked ? txtAzTarikh.Text : new MyContext().AsnadeHesabdariRows.Min(f => f.Tarikh).ToString().Substring(0, 10);
                        XtraReport1.Parameters["Ta_Tarikh"].Value = ChkTarikh.Checked ? txtTaTarikh.Text : DateTime.Now.ToString().Substring(0, 10);
                        XtraReport1.Parameters["TarikhVSaat"].Value = DateTime.Now;
                        //XtraReport1.Parameters["HesabMoin"].Value = _HesabMoin;
                        //XtraReport1.Parameters["HesabTafzil"].Value = cmbHesabTafzili.Text;
                        XtraReport1.Parameters["SandoghName"].Value = _SandoghName;
                        XtraReport1.Parameters["Logo_Co"].Value = Fm.pictureEdit1.Image;

                        FrmPrinPreview FPP = new FrmPrinPreview();
                        FPP.documentViewer1.DocumentSource = XtraReport1;
                        FPP.ShowDialog();
                    }
                }
                else
                {
                    HelpClass1.NewReportDesigner(FilePath, FileName1);
                }
            }
            else
            {
                DataTable dt = new DataTable();
                for (int i = 0; i < gridView2.Columns.Count; i++)
                {
                    //if (gridView1.Columns[i].Visible)
                    dt.Columns.Add(gridView2.Columns[i].FieldName);
                }

                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    DataRow dRow = dt.NewRow();
                    //dRow[cell.ColumnIndex] = cell.Value;
                    if (gridView2.Columns["Line"].Visible)
                        dRow["Line"] = gridView2.GetRowCellValue(i, "Line");
                    if (gridView2.Columns["HesabTafCode"].Visible)
                        dRow["HesabTafCode"] = gridView2.GetRowCellValue(i, "HesabTafCode");
                    if (gridView2.Columns["HesabTafName"].Visible)
                        dRow["HesabTafName"] = gridView2.GetRowCellDisplayText(i, "HesabTafName");
                    if (gridView2.Columns["2001"].Visible)
                        dRow["2001"] = gridView2.GetRowCellDisplayText(i, "2001");
                    if (gridView2.Columns["2002"].Visible)
                        dRow["2002"] = gridView2.GetRowCellDisplayText(i, "2002");
                    if (gridView2.Columns["2003"].Visible)
                        dRow["2003"] = gridView2.GetRowCellDisplayText(i, "2003");
                    if (gridView2.Columns["3001"].Visible)
                        dRow["3001"] = gridView2.GetRowCellDisplayText(i, "3001");
                    if (gridView2.Columns["4001"].Visible)
                        dRow["4001"] = gridView2.GetRowCellDisplayText(i, "4001");
                    if (gridView2.Columns["6001"].Visible)
                        dRow["6001"] = gridView2.GetRowCellDisplayText(i, "6001");
                    if (gridView2.Columns["6002"].Visible)
                        dRow["6002"] = gridView2.GetRowCellDisplayText(i, "6002");
                    if (gridView2.Columns["6003"].Visible)
                        dRow["6003"] = gridView2.GetRowCellDisplayText(i, "6003");
                    if (gridView2.Columns["7001"].Visible)
                        dRow["7001"] = gridView2.GetRowCellDisplayText(i, "7001");
                    if (gridView2.Columns["Mande01"].Visible)
                        dRow["Mande01"] = gridView2.GetRowCellDisplayText(i, "Mande01");
                    dt.Rows.Add(dRow);
                }

                if (System.IO.File.Exists(FilePath + FileName2))
                {
                    if (gridView2.RowCount > 0)
                    {
                        XtraReport XtraReport1 = new XtraReport();
                        XtraReport1.LoadLayoutFromXml(FilePath + FileName2);

                        //XtraReport1.DataSource = gridControl2.DataSource;
                        XtraReport1.DataSource = dt;

                        // XtraReport1.Parameters["Az_Tarikh"].Value = ChkTarikh.Checked ? txtAzTarikh.Text : new MyContext().AsnadeHesabdariRows.Min(f => f.Tarikh).ToString().Substring(0, 10);
                        XtraReport1.Parameters["Ta_Tarikh"].Value = ChkTarikh.Checked ? txtTaTarikh.Text : DateTime.Now.ToString().Substring(0, 10);
                        XtraReport1.Parameters["TarikhVSaat"].Value = DateTime.Now;
                        //XtraReport1.Parameters["HesabMoin"].Value = _HesabMoin;
                        //XtraReport1.Parameters["HesabTafzil"].Value = cmbHesabTafzili.Text;
                        XtraReport1.Parameters["SandoghName"].Value = _SandoghName;
                        XtraReport1.Parameters["Logo_Co"].Value = Fm.pictureEdit1.Image;

                        XtraReport1.Parameters["Vam_Daryaftani_2001"].Value = gridView2.Columns["2001"].Caption;
                        XtraReport1.Parameters["Vam_Daryaftani_2002"].Value = gridView2.Columns["2002"].Caption;
                        XtraReport1.Parameters["Vam_Daryaftani_2003"].Value = gridView2.Columns["2003"].Caption;
                        XtraReport1.Parameters["Mosaede"].Value = gridView2.Columns["3001"].Caption;
                        XtraReport1.Parameters["Bedehkaran"].Value = gridView2.Columns["4001"].Caption;
                        XtraReport1.Parameters["Vam_Pardakhtani"].Value = gridView2.Columns["6001"].Caption;
                        XtraReport1.Parameters["Asnade_Pardakhtani"].Value = gridView2.Columns["6002"].Caption;
                        XtraReport1.Parameters["Bestankaran"].Value = gridView2.Columns["6003"].Caption;
                        XtraReport1.Parameters["Sarmaye"].Value = gridView2.Columns["7001"].Caption;
                        XtraReport1.Parameters["Mande"].Value = gridView2.Columns["Mande01"].Caption;
                        FrmPrinPreview FPP = new FrmPrinPreview();
                        FPP.documentViewer1.DocumentSource = XtraReport1;
                        FPP.RepotPageWidth = 133;
                        FPP.ShowDialog();
                    }
                }
                else
                {
                    HelpClass1.NewReportDesigner(FilePath, FileName2);
                }

            }
        }

        private void btnDesignReport_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                HelpClass1.LoadReportDesigner(FilePath, FileName1);

            }
            else
            {
                HelpClass1.LoadReportDesigner(FilePath, FileName2);

            }
        }

        private void FrmMandeAshkhas_KeyDown(object sender, KeyEventArgs e)
        {
            HelpClass1.ControlAltShift_KeyDown(sender, e, btnDesignReport);

        }

        private void btnDisplyList_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
                FillDataGridView1();
            else
                FillDataGridView2();
        }

        private void ChkTarikh_CheckedChanged(object sender, EventArgs e)
        {
            txtTaTarikh.Enabled = ChkTarikh.Checked ? true : false;
            txtTaTarikh.Focus();

        }

        private void txtTaTarikh_EditValueChanged(object sender, EventArgs e)
        {
            //btnDisplyList_Click(null, null);
        }

        private void txtTaTarikh_Enter(object sender, EventArgs e)
        {
            btnDisplyList_Click(null, null);

        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.CodeMoins.ToList();
                    if (xtraTabControl1.SelectedTabPageIndex == 1)
                    {
                        gridView2.Columns["2001"].Caption = q.FirstOrDefault(s => s.SandoghId == _SandoghId && s.Code == 2001).Name;
                        gridView2.Columns["2002"].Caption = q.FirstOrDefault(s => s.SandoghId == _SandoghId && s.Code == 2002).Name;
                        gridView2.Columns["2003"].Caption = q.FirstOrDefault(s => s.SandoghId == _SandoghId && s.Code == 2003).Name;
                        gridView2.Columns["3001"].Caption = q.FirstOrDefault(s => s.SandoghId == _SandoghId && s.Code == 3001).Name;
                        gridView2.Columns["4001"].Caption = q.FirstOrDefault(s => s.SandoghId == _SandoghId && s.Code == 4001).Name;
                        gridView2.Columns["6001"].Caption = q.FirstOrDefault(s => s.SandoghId == _SandoghId && s.Code == 6001).Name;
                        gridView2.Columns["6002"].Caption = q.FirstOrDefault(s => s.SandoghId == _SandoghId && s.Code == 6002).Name;
                        gridView2.Columns["6003"].Caption = q.FirstOrDefault(s => s.SandoghId == _SandoghId && s.Code == 6003).Name;
                        gridView2.Columns["7001"].Caption = q.FirstOrDefault(s => s.SandoghId == _SandoghId && s.Code == 7001).Name;

                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            btnDisplyList_Click(null, null);
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(gridView1, gridView1.RowCount);
            }

        }

        private void gridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(gridView2, gridView2.RowCount);
            }

        }
    }
}