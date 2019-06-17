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
    public partial class FrmMabaleghGhabelDaryaft : DevExpress.XtraEditors.XtraForm
    {
        public FrmMabaleghGhabelDaryaft()
        {
            InitializeComponent();
        }

        public void FillDataGridView1()
        {
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (var db = new MyContext())
            {
                try
                {
                    int _Sal = Convert.ToInt32(txtSal.Text);
                    int _IndexMonth = cmbMonth.SelectedIndex;
                    // dt.Columns.Add("AazaId");
                    // dt.Columns.Add("Line");
                    dt.Columns.Add("NameAaza");
                    dt.Columns.Add("Sal");
                    dt.Columns.Add("Month");
                    dt.Columns.Add("MablaghPasandaz");
                    dt.Columns.Add("MablaghAghsat");
                    dt.Columns.Add("CodePersoneli");
                    dt.Columns.Add("Tozihat");
                    var q = db.AazaSandoghs.Where(f => f.IsActive == true && f.IsOzveSandogh == chkIsOzveSandogh.Checked).ToList();
                    if (q.Count > 0)
                    {
                        for (int RowCounter = 0; RowCounter < q.Count(); RowCounter++)
                        {
                            string _Tozihat = string.Empty;
                            DataRow DataRow1 = dt.NewRow();
                            DataRow1[0] = q[RowCounter].NameVFamil;
                            DataRow1[1] = txtSal.Text;
                            DataRow1[2] = cmbMonth.Text;

                            int _AllTafId = q[RowCounter].AllTafId;
                            var qq1 = db.HaghOzviats.Where(f => f.AazaId == _AllTafId && f.Sal == _Sal).ToList();
                            if (qq1.Count==0)
                            {
                                DataRow1[3] = q[RowCounter].HaghOzviat != null ? q[RowCounter].HaghOzviat.Value.ToString("n0") : "0";
                                _Tozihat += "پس انداز " + (qq1.Count +1) + " ماه";
                            }
                            else
                            {
                                int qq2 = qq1.Max(f => f.IndexMonth);
                                DataRow1[3] = q[RowCounter].HaghOzviat != null ? ((q[RowCounter].HaghOzviat.Value) * (cmbMonth.SelectedIndex-qq2)).ToString("n0") : "0";
                                if (cmbMonth.SelectedIndex - qq2>0)
                                    _Tozihat += "پس انداز " + (cmbMonth.SelectedIndex - qq2) + " ماه";
                            }

                            int _Id = q[RowCounter].Id;
                            var q1 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 3 && f.Id2 == _Id);
                            if (q1 != null)
                            {
                                DateTime _Tarikh = Convert.ToDateTime("1398/01/01");
                                switch (cmbMonth.SelectedIndex)
                                {
                                    case 0:
                                        {
                                            _Tarikh = Convert.ToDateTime(txtSal.Text + "/01/31");
                                            break;
                                        }
                                    case 1:
                                        {
                                            _Tarikh = Convert.ToDateTime(txtSal.Text + "/02/31");
                                            break;
                                        }
                                    case 2:
                                        {
                                            _Tarikh = Convert.ToDateTime(txtSal.Text + "/03/31");
                                            break;
                                        }
                                    case 3:
                                        {
                                            _Tarikh = Convert.ToDateTime(txtSal.Text + "/04/31");
                                            break;
                                        }
                                    case 4:
                                        {
                                            _Tarikh = Convert.ToDateTime(txtSal.Text + "/05/31");
                                            break;
                                        }
                                    case 5:
                                        {
                                            _Tarikh = Convert.ToDateTime(txtSal.Text + "/06/31");
                                            break;
                                        }
                                    case 6:
                                        {
                                            _Tarikh = Convert.ToDateTime(txtSal.Text + "/07/30");
                                            break;
                                        }
                                    case 7:
                                        {
                                            _Tarikh = Convert.ToDateTime(txtSal.Text + "/08/30");
                                            break;
                                        }
                                    case 8:
                                        {
                                            _Tarikh = Convert.ToDateTime(txtSal.Text + "/09/30");
                                            break;
                                        }
                                    case 9:
                                        {
                                            _Tarikh = Convert.ToDateTime(txtSal.Text + "/10/30");
                                            break;
                                        }
                                    case 10:
                                        {
                                            _Tarikh = Convert.ToDateTime(txtSal.Text + "/11/30");
                                            break;
                                        }
                                    case 11:
                                        {
                                            _Tarikh = Convert.ToDateTime(txtSal.Text + "/12/29");
                                            break;
                                        }
                                }
                                var q2 = db.RizeAghsatVams.Where(f => f.AazaId == q1.Id && f.TarikhSarresid <= _Tarikh && f.ShomareSanad == 0).ToList();
                                if (q2.Count > 0)
                                {
                                    decimal _MablaghAghsat = 0;
                                    foreach (var item in q2)
                                    {
                                        _MablaghAghsat += item.MablaghAghsat;
                                        //_Tozihat += "قسط " + item.ShomareGhest + " وام ش " + item.VamPardakhtiCode + " + ";
                                    }
                                    _Tozihat += !string.IsNullOrEmpty(_Tozihat)? " + " + q2.Count+ " قسط وام ": q2.Count + " قسط وام ";

                                    DataRow1[4] = _MablaghAghsat.ToString("n0");
                                }
                            }
                            DataRow1[5] = q[RowCounter].CodePersoneli;
                            DataRow1[6] = _Tozihat;

                            dt.Rows.Add(DataRow1);
                        }
                        gridControl1.DataSource = dt;
                        //ds.Tables.Add(dt);
                    }
                    else
                        gridControl1.DataSource = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                       "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void btnDisplyList_Click(object sender, EventArgs e)
        {
            FillDataGridView1();
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);
        }

        private void FrmMabaleghGhabelDaryaft_Load(object sender, EventArgs e)
        {
            var Date = DateTime.Now;
            txtSal.Text = Date.ToString().Substring(0, 4);
            switch (Date.ToString().Substring(5, 2))
            {
                case "01":
                    cmbMonth.SelectedIndex = 0;
                    break;
                case "02":
                    cmbMonth.SelectedIndex = 1;
                    break;
                case "03":
                    cmbMonth.SelectedIndex = 2;
                    break;
                case "04":
                    cmbMonth.SelectedIndex = 3;
                    break;
                case "05":
                    cmbMonth.SelectedIndex = 4;
                    break;
                case "06":
                    cmbMonth.SelectedIndex = 5;
                    break;
                case "07":
                    cmbMonth.SelectedIndex = 6;
                    break;
                case "08":
                    cmbMonth.SelectedIndex = 7;
                    break;
                case "09":
                    cmbMonth.SelectedIndex = 8;
                    break;
                case "10":
                    cmbMonth.SelectedIndex = 9;
                    break;
                case "11":
                    cmbMonth.SelectedIndex = 10;
                    break;
                case "12":
                    cmbMonth.SelectedIndex = 11;
                    break;
            }
            FillDataGridView1();
        }

       // int RowIndex = 0;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           // RowIndex = gridView1.GetRowHandle(e.FocusedRowHandle);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }

        string FilePath = Application.StartupPath + @"\Report\Ghozareshat\";
        string FileName1 = "rptMabaleghGhabelDaryaft.repx";

        public string _SandoghName = string.Empty;

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(FilePath + FileName1))
            {
                if (gridView1.RowCount > 0)
                {
                    XtraReport XtraReport1 = new XtraReport();
                    XtraReport1.LoadLayoutFromXml(FilePath + FileName1);

                    XtraReport1.DataSource = gridView1.DataSource;

                    // XtraReport1.Parameters["Az_Tarikh"].Value = ChkTarikh.Checked ? txtAzTarikh.Text : new MyContext().AsnadeHesabdariRows.Min(f => f.Tarikh).ToString().Substring(0, 10);
                    //XtraReport1.Parameters["Ta_Tarikh"].Value = ChkTarikh.Checked ? txtTaTarikh.Text : DateTime.Now.ToString().Substring(0, 10);
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

        private void btnDesignReport_Click(object sender, EventArgs e)
        {
            HelpClass1.LoadReportDesigner(FilePath, FileName1);

        }

        private void FrmMabaleghGhabelDaryaft_KeyDown(object sender, KeyEventArgs e)
        {
            HelpClass1.ControlAltShift_KeyDown(sender, e, btnDesignReport);

        }

    }
}