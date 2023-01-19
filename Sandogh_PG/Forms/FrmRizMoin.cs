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
using DevExpress.XtraReports.UI;

namespace Sandogh_PG
{
    public partial class FrmRizMoin : DevExpress.XtraEditors.XtraForm
    {
        //public FrmRizMoin()
        //{
        //    InitializeComponent();
        //}

        public FrmSodVZian Fm;
        public FrmRizMoin(FrmSodVZian fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        public FrmTarazname Pm;
        public FrmRizMoin(FrmTarazname pm)
        {
            InitializeComponent();
            Pm = pm;
        }

        private void FrmRizMoin_Load(object sender, EventArgs e)
        {
            FillDataGridView1();
        }

        public int RowMoinId = 0;
        public void FillDataGridView1()
        {
            using (var db = new MyContext())
            {
                try
                {
                    DateTime _AZ = Convert.ToDateTime(_Az_Tarikh);
                    DateTime _Ta = Convert.ToDateTime(_Ta_Tarikh);
                    List<AsnadeHesabdariRow> List1 = new List<AsnadeHesabdariRow>();
                    var q1 = db.AsnadeHesabdariRows.Where(f => f.Tarikh >= _AZ && f.Tarikh <= _Ta && f.HesabMoinId == RowMoinId).ToList();
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
                                obj1.Bed = q1.Where(f => f.HesabTafId == item.HesabTafId).Sum(f => f.Bed) - q1.Where(f => f.HesabTafId == item.HesabTafId).Sum(f => f.Bes);
                                //obj1.Bes = q1.Where(f => f.HesabTafId == item.HesabTafId).Sum(f => f.Bes);
                                List1.Add(obj1);
                            }
                        }
                        asnadeHesabdariRowsBindingSource.DataSource = List1.OrderBy(f => f.HesabTafCode);
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

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);
        }

        string FilePath = Application.StartupPath + @"\Report\Ghozareshat\";
        string FileName = "rptRizHesabMoin.repx";

        public string _Az_Tarikh = string.Empty;
        public string _Ta_Tarikh = string.Empty;
        public string _SandoghName = string.Empty;

        private void btnPrintPreview_Click(object sender, EventArgs e)
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
                //if (gridView1.Columns["Line"].Visible)
                //dRow["Line"] = gridView1.GetRowCellValue(i, "Line");
                if (gridView1.Columns["HesabTafCode"].Visible)
                    dRow["HesabTafCode"] = gridView1.GetRowCellDisplayText(i, "HesabTafCode");
                if (gridView1.Columns["HesabTafName"].Visible)
                    dRow["HesabTafName"] = gridView1.GetRowCellDisplayText(i, "HesabTafName");
                //if (gridView1.Columns["Sal"].Visible)
                //dRow["Sal"] = _txtSal.Text;
                //if (gridView1.Columns["Month"].Visible)
                //dRow["Month"] = _cmbMonth.Text;
                if (gridView1.Columns["Bed"].Visible)
                    dRow["Bed"] = gridView1.GetRowCellDisplayText(i, "Bed");
                //if (gridView1.Columns["MablaghAghsat"].Visible)
                //    dRow["MablaghAghsat"] = gridView1.GetRowCellDisplayText(i, "MablaghAghsat");
                //if (gridView1.Columns["Sum"].Visible)
                //    dRow["Sum"] = gridView1.Columns["MablaghPasandaz"].Visible && gridView1.Columns["MablaghAghsat"].Visible ? gridView1.GetRowCellDisplayText(i, "Sum") :
                //        gridView1.Columns["MablaghPasandaz"].Visible && !gridView1.Columns["MablaghAghsat"].Visible ? gridView1.GetRowCellDisplayText(i, "MablaghPasandaz") :
                //        !gridView1.Columns["MablaghPasandaz"].Visible && gridView1.Columns["MablaghAghsat"].Visible ? gridView1.GetRowCellDisplayText(i, "MablaghAghsat") : "";
                //else
                //    dRow["Sum"] = string.Empty;
                //if (gridView1.Columns["Tozihat"].Visible && gridView1.Columns["MablaghPasandaz"].Visible && gridView1.Columns["MablaghAghsat"].Visible)
                //    dRow["Tozihat"] = gridView1.GetRowCellDisplayText(i, "Tozihat");
                dt.Rows.Add(dRow);
            }


            if (System.IO.File.Exists(FilePath + FileName))
            {
                if (gridView1.RowCount > 0)
                {
                    XtraReport XtraReport1 = new XtraReport();
                    XtraReport1.LoadLayoutFromXml(FilePath + FileName);

                    XtraReport1.DataSource = dt;
                    //XtraReport1.DataSource = gridView1.DataSource;

                    XtraReport1.Parameters["Az_Tarikh"].Value = _Az_Tarikh;
                    XtraReport1.Parameters["Ta_Tarikh"].Value = _Ta_Tarikh;
                    XtraReport1.Parameters["TarikhVSaat"].Value = DateTime.Now;
                    //XtraReport1.Parameters["HesabMoin"].Value = _HesabMoin;
                    //XtraReport1.Parameters["HesabTafzil"].Value = cmbHesabTafzili.Text;
                    XtraReport1.Parameters["SandoghName"].Value = _SandoghName;
                    if (Fm != null)
                    {
                        XtraReport1.Parameters["Logo_Co"].Value = Fm.Fm.pictureEdit1.Image;
                    }
                    else
                    {
                        XtraReport1.Parameters["Logo_Co"].Value = Pm.Fm.pictureEdit1.Image;
                    }

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

        private void FrmRizMoin_KeyDown(object sender, KeyEventArgs e)
        {
            HelpClass1.ControlAltShift_KeyDown(sender, e, btnDesignReport);

        }
    }
}