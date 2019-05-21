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
using Stimulsoft.Report;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.ReportGeneration;

namespace Sandogh_TG
{
    public partial class FrmDaftarRozname : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmDaftarRozname(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        public void FillDataGridDaftarRozname()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (ChkTarikh.Checked == false)
                    {
                        var q = db.AsnadeHesabdariRows.OrderBy(f => f.Tarikh).ThenBy(f => f.ShomareSanad).ToList();
                        if (q.Count > 0)
                            asnadeHesabdariRowsBindingSource.DataSource = q;
                        else
                            asnadeHesabdariRowsBindingSource.DataSource = null;
                    }
                    else
                    {
                        DateTime _Az = Convert.ToDateTime(txtAzTarikh.Text);
                        DateTime _Ta = Convert.ToDateTime(txtTaTarikh.Text);
                        var q = db.AsnadeHesabdariRows.Where(f => f.Tarikh >= _Az && f.Tarikh <= _Ta).OrderBy(f => f.Tarikh).ThenBy(f => f.ShomareSanad).ToList();
                        if (q.Count > 0)
                            asnadeHesabdariRowsBindingSource.DataSource = q;
                        else
                            asnadeHesabdariRowsBindingSource.DataSource = null;
                    }
                }
                catch //(Exception ex)
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

        private void ChkTarikh_CheckedChanged(object sender, EventArgs e)
        {
            txtAzTarikh.Enabled = txtTaTarikh.Enabled = ChkTarikh.Checked ? true : false;
            FillDataGridDaftarRozname();
            txtAzTarikh.Focus();
        }

        private void FrmDaftarRozname_Load(object sender, EventArgs e)
        {
            txtAzTarikh.Text = txtTaTarikh.Text = DateTime.Now.ToString().Substring(0, 10);
            FillDataGridDaftarRozname();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillDataGridDaftarRozname();
        }

        private void txtAzTarikh_EditValueChanged(object sender, EventArgs e)
        {
            FillDataGridDaftarRozname();
        }

        private void txtTaTarikh_EditValueChanged(object sender, EventArgs e)
        {
            FillDataGridDaftarRozname();

        }

        private void FrmDaftarRozname_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.F12)
            //{
            //    btnDesignReport.Visible = btnDesignReport.Visible == true ? false : true;
            //}
            HelpClass1.ControlAltShift_KeyDown(sender, e, btnDesignReport);
        }

        string FilePath = Application.StartupPath + @"\Report\Ghozareshat\";
        string FileName = "rptDaftarRozname.repx";
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(FilePath + FileName))
            {
                if (gridView1.RowCount > 0)
                {
                    XtraReport XtraReport1 = new XtraReport();
                    XtraReport1.LoadLayoutFromXml(FilePath + FileName);
                    XtraReport1.DataSource = gridView1.DataSource;
                    XtraReport1.Parameters["Az_Tarikh"].Value = ChkTarikh.Checked ? txtAzTarikh.Text : gridView1.GetRowCellDisplayText(0, "Tarikh").Substring(0, 10);
                    XtraReport1.Parameters["Ta_Tarikh"].Value = ChkTarikh.Checked ? txtTaTarikh.Text : DateTime.Now.ToString().Substring(0, 10);
                    XtraReport1.Parameters["TarikhVSaat"].Value = DateTime.Now;
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

    }
}