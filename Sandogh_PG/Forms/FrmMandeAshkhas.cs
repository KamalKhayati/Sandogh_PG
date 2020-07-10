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

        private void FrmMandeAshkhas_Load(object sender, EventArgs e)
        {
            txtTaTarikh.Text = DateTime.Now.ToString().Substring(0, 10);
            HelpClass1.DateTimeMask(txtTaTarikh);
            FillDataGridView1();
            FillDataGridView2();

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
                    var q1 = db.AsnadeHesabdariRows.Where(f => f.Tarikh <= _Ta && f.HesabTafCode >= 7000001 && f.HesabTafCode <= 7999999).ToList();
                    if (q1.Count > 0)
                    {
                        foreach (var item in q1)
                        {
                            AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
                            if (!List1.Any(f => f.HesabTafId == item.HesabTafId))
                            {
                                //obj1.Id = item.Id;
                                obj1.HesabMoinId = item.HesabMoinId;
                                obj1.HesabMoinCode = item.HesabMoinCode;
                                obj1.HesabMoinName = item.HesabMoinName;
                                obj1.HesabTafId = item.HesabTafId;
                                obj1.HesabTafCode = item.HesabTafCode;
                                obj1.HesabTafName = item.HesabTafName;
                                //obj1.HesabTafId = item.HesabTafId;
                                //obj1.HesabTafCode = item.HesabTafCode;
                                //obj1.HesabTafName = item.HesabTafName;
                                obj1.Mande01 = q1.Where(f => f.HesabTafId == item.HesabTafId).Sum(f => f.Bed) - q1.Where(f => f.HesabTafId == item.HesabTafId).Sum(f => f.Bes);
                                //obj1.Bes = q1.Where(f => f.HesabTafId == item.HesabTafId).Sum(f => f.Bes);
                                List1.Add(obj1);
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
                if (System.IO.File.Exists(FilePath + FileName1))
                {
                    if (gridView1.RowCount > 0)
                    {
                        XtraReport XtraReport1 = new XtraReport();
                        XtraReport1.LoadLayoutFromXml(FilePath + FileName1);

                        XtraReport1.DataSource = gridView1.DataSource;

                        // XtraReport1.Parameters["Az_Tarikh"].Value = ChkTarikh.Checked ? txtAzTarikh.Text : new MyContext().AsnadeHesabdariRows.Min(f => f.Tarikh).ToString().Substring(0, 10);
                        XtraReport1.Parameters["Ta_Tarikh"].Value = ChkTarikh.Checked ? txtTaTarikh.Text : DateTime.Now.ToString().Substring(0, 10);
                        XtraReport1.Parameters["TarikhVSaat"].Value = DateTime.Now;
                        //XtraReport1.Parameters["HesabMoin"].Value = _HesabMoin;
                        //XtraReport1.Parameters["HesabTafzil"].Value = cmbHesabTafzili.Text;
                        XtraReport1.Parameters["SandoghName"].Value = _SandoghName;
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
                if (System.IO.File.Exists(FilePath + FileName2))
                {
                    if (gridView2.RowCount > 0)
                    {
                        XtraReport XtraReport1 = new XtraReport();
                        XtraReport1.LoadLayoutFromXml(FilePath + FileName2);

                        XtraReport1.DataSource = gridControl2.DataSource;

                        // XtraReport1.Parameters["Az_Tarikh"].Value = ChkTarikh.Checked ? txtAzTarikh.Text : new MyContext().AsnadeHesabdariRows.Min(f => f.Tarikh).ToString().Substring(0, 10);
                        XtraReport1.Parameters["Ta_Tarikh"].Value = ChkTarikh.Checked ? txtTaTarikh.Text : DateTime.Now.ToString().Substring(0, 10);
                        XtraReport1.Parameters["TarikhVSaat"].Value = DateTime.Now;
                        //XtraReport1.Parameters["HesabMoin"].Value = _HesabMoin;
                        //XtraReport1.Parameters["HesabTafzil"].Value = cmbHesabTafzili.Text;
                        XtraReport1.Parameters["SandoghName"].Value = _SandoghName;
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
            if (xtraTabControl1.SelectedTabPageIndex==0)
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
            FillDataGridView1();
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
    }
}