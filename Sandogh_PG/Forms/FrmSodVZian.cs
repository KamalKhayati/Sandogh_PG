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

namespace Sandogh_PG
{
    public partial class FrmSodVZian : DevExpress.XtraEditors.XtraForm
    {
       public FrmMain Fm;
        public FrmSodVZian(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        decimal SodVZian = 0;
        public void FillDataGridView1()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var p1 = db.CodeMoins.ToList();
                    DateTime _Az = Convert.ToDateTime(txtAzTarikh.Text);
                    DateTime _Ta = Convert.ToDateTime(txtTaTarikh.Text);
                    List<AsnadeHesabdariRow> List1 = new List<AsnadeHesabdariRow>();
                    var q1 = db.AsnadeHesabdariRows.Where(f => f.Tarikh >= _Az && f.Tarikh <= _Ta && f.HesabMoinCode >= 8001 && f.HesabMoinCode <= 9999).ToList();
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
                                obj1.HesabMoinName = p1.FirstOrDefault(s=>s.SandoghId==_SandoghId&& s.Id==item.HesabMoinId).Name ;
                                //obj1.HesabTafId = item.HesabTafId;
                                //obj1.HesabTafCode = item.HesabTafCode;
                                //obj1.HesabTafName = item.HesabTafName;
                                obj1.Bed = q1.Where(f => f.HesabMoinId == item.HesabMoinId).Sum(f => f.Bed);
                                obj1.Bes = q1.Where(f => f.HesabMoinId == item.HesabMoinId).Sum(f => f.Bes);
                                List1.Add(obj1);
                            }
                        }
                        SodVZian = Convert.ToDecimal(List1.Sum(f => f.Bes) - List1.Sum(f => f.Bed));
                        asnadeHesabdariRowsBindingSource.DataSource = List1.OrderBy(f => f.HesabMoinCode);
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

        int _SandoghId = 0;
        private void FrmSodVZian_Load(object sender, EventArgs e)
        {
            _SandoghId = Convert.ToInt32(Fm.IDSandogh.Caption);
            txtAzTarikh.Text = new MyContext().AsnadeHesabdariRows.Any() ? new MyContext().AsnadeHesabdariRows.Min(f => f.Tarikh).ToString().Substring(0, 10) : "1398/01/01";
            txtTaTarikh.Text = DateTime.Now.ToString().Substring(0, 10);
            HelpClass1.DateTimeMask(txtAzTarikh);
            HelpClass1.DateTimeMask(txtTaTarikh);
            FillDataGridView1();

            txtAzTarikh.Focus();
        }

        string FilePath = Application.StartupPath + @"\Report\Ghozareshat\";
        string FileName = "rptSodVZian.repx";

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
                    XtraReport1.Parameters["Az_Tarikh"].Value = ChkTarikh.Checked ? txtAzTarikh.Text : new MyContext().AsnadeHesabdariRows.Min(f => f.Tarikh).ToString().Substring(0, 10);
                    XtraReport1.Parameters["Ta_Tarikh"].Value = ChkTarikh.Checked ? txtTaTarikh.Text : DateTime.Now.ToString().Substring(0, 10);
                    XtraReport1.Parameters["TarikhVSaat"].Value = DateTime.Now;
                    XtraReport1.Parameters["SodVZian"].Value = SodVZian;
                    //XtraReport1.Parameters["HesabMoin"].Value = _HesabMoin;
                    //XtraReport1.Parameters["HesabTafzil"].Value = cmbHesabTafzili.Text;
                    XtraReport1.Parameters["SandoghName"].Value = Fm.ribbonControl1.ApplicationDocumentCaption;
                    XtraReport1.Parameters["Logo_Co"].Value = Fm.pictureEdit1.Image;

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

        private void FrmSodVZian_KeyDown(object sender, KeyEventArgs e)
        {
            HelpClass1.ControlAltShift_KeyDown(sender, e, btnDesignReport);

        }

        private void btnDisplyList_Click(object sender, EventArgs e)
        {
            FillDataGridView1();
        }

        private void ChkTarikh_CheckedChanged(object sender, EventArgs e)
        {
            txtAzTarikh.Enabled = txtTaTarikh.Enabled = ChkTarikh.Checked ? true : false;
            if (ChkTarikh.Checked == false)
                FillDataGridView1();
            txtAzTarikh.Focus();

        }

        private void btnRizMoin_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                FrmRizMoin frm = new FrmRizMoin(this);
                string RowMoinName = gridView1.GetFocusedRowCellDisplayText("HesabMoinName");
                frm.Text = "ریز حساب معین : " + RowMoinName;
                frm.RowMoinId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabMoinId"));
                frm._Az_Tarikh =  txtAzTarikh.Text ;
                frm._Ta_Tarikh =  txtTaTarikh.Text ;
                frm._SandoghName = Fm.ribbonControl1.ApplicationDocumentCaption; ;
                frm.ShowDialog();
            }

        }

        private void txtAzTarikh_EditValueChanged(object sender, EventArgs e)
        {
            FillDataGridView1();

        }

        private void txtTaTarikh_EditValueChanged(object sender, EventArgs e)
        {
            FillDataGridView1();

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(this,gridView1, gridView1.RowCount);
            }

        }
    }
}