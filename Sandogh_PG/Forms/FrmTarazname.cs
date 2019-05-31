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
    public partial class FrmTarazname : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmTarazname(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        public void FillDataGridView1()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (ChkTarikh.Checked == false)
                    {
                        List<AsnadeHesabdariRow> List1 = new List<AsnadeHesabdariRow>();
                        var q1 = db.AsnadeHesabdariRows.ToList();
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
                                    obj1.Bed = db.AsnadeHesabdariRows.Where(f => f.HesabMoinId == item.HesabMoinId).Sum(f => f.Bed);
                                    obj1.Bes = db.AsnadeHesabdariRows.Where(f => f.HesabMoinId == item.HesabMoinId).Sum(f => f.Bes);
                                    List1.Add(obj1);
                                }
                            }
                            asnadeHesabdariRowsBindingSource.DataSource = List1.OrderBy(f => f.HesabMoinCode);
                        }
                        else
                            asnadeHesabdariRowsBindingSource.DataSource = null;

                    }
                    else
                    {
                        DateTime _Ta = Convert.ToDateTime(txtTaTarikh.Text);
                        List<AsnadeHesabdariRow> List1 = new List<AsnadeHesabdariRow>();
                        var q1 = db.AsnadeHesabdariRows.Where(f => f.Tarikh <= _Ta).ToList();
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
                                    obj1.Bed = db.AsnadeHesabdariRows.Where(f => f.HesabMoinId == item.HesabMoinId).Sum(f => f.Bed);
                                    obj1.Bes = db.AsnadeHesabdariRows.Where(f => f.HesabMoinId == item.HesabMoinId).Sum(f => f.Bes);
                                    List1.Add(obj1);
                                }
                            }
                            asnadeHesabdariRowsBindingSource.DataSource = List1.OrderBy(f => f.HesabMoinCode);
                        }
                        else
                            asnadeHesabdariRowsBindingSource.DataSource = null;
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void FrmTarazname_Load(object sender, EventArgs e)
        {
            txtTaTarikh.Text = DateTime.Now.ToString().Substring(0, 10);
            FillDataGridView1();
        }

        string FilePath = Application.StartupPath + @"\Report\Ghozareshat\";
        string FileName = "rptTarazname.repx";

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(FilePath + FileName))
            {
                if (gridView1.RowCount > 0)
                {
                    XtraReport XtraReport1 = new XtraReport();
                    XtraReport1.LoadLayoutFromXml(FilePath + FileName);

                    XtraReport1.DataSource = HelpClass1.ConvettDatagridviewToDataSet(gridView1);

                   // XtraReport1.Parameters["Az_Tarikh"].Value = ChkTarikh.Checked ? txtAzTarikh.Text : gridView2.GetRowCellDisplayText(0, "Tarikh").Substring(0, 10);
                    XtraReport1.Parameters["Ta_Tarikh"].Value = ChkTarikh.Checked ? txtTaTarikh.Text : DateTime.Now.ToString().Substring(0, 10);
                    XtraReport1.Parameters["TarikhVSaat"].Value = DateTime.Now;
                    //XtraReport1.Parameters["HesabMoin"].Value = _HesabMoin;
                    //XtraReport1.Parameters["HesabTafzil"].Value = cmbHesabTafzili.Text;
                    XtraReport1.Parameters["SandoghName"].Value = Fm.ribbonControl1.ApplicationDocumentCaption;
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

        private void FrmTarazname_KeyDown(object sender, KeyEventArgs e)
        {
            HelpClass1.ControlAltShift_KeyDown(sender, e, btnDesignReport);

        }

        private void btnDisplyList_Click(object sender, EventArgs e)
        {
            FillDataGridView1();
        }

        private void ChkTarikh_CheckedChanged(object sender, EventArgs e)
        {
            txtTaTarikh.Enabled = ChkTarikh.Checked ? true : false;
            FillDataGridView1();
            txtTaTarikh.Focus();

        }
    }
}