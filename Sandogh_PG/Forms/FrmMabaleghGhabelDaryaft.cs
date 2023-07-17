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
using DevExpress.XtraPrintingLinks;
using DevExpress.DataAccess.EntityFramework;
using DevExpress.XtraGrid.Views.Grid;

namespace Sandogh_PG
{
    public partial class FrmMabaleghGhabelDaryaft : DevExpress.XtraEditors.XtraForm
    {
        //public FrmMabaleghGhabelDaryaft()
        //{
        //    InitializeComponent();
        //}

        public FrmMain Fm;
        public FrmMabaleghGhabelDaryaft(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        TextEdit _txtSal;
        ComboBoxEdit _cmbMonth;
        string IndexMah = string.Empty;
        public void FillDataGridView()
        {
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (var db = new MyContext())
            {
                try
                {
                    int _Sal = Convert.ToInt32(_txtSal.Text);
                    int _IndexMonth = _cmbMonth.SelectedIndex;
                    // dt.Columns.Add("AazaId");
                    dt.Columns.Add("NameAaza");
                    dt.Columns.Add("Sal");
                    dt.Columns.Add("Month");
                    dt.Columns.Add("MablaghPasandaz");
                    dt.Columns.Add("MablaghAghsat");
                    dt.Columns.Add("CodePersoneli");
                    dt.Columns.Add("Tozihat");


                    dt.Columns["MablaghPasandaz"].DataType = typeof(Decimal);
                    dt.Columns["MablaghAghsat"].DataType = typeof(Decimal);
                    //var q = db.AazaSandoghs.Where(f => f.IsActive == true && f.IsOzveSandogh == chkIsOzveSandogh.Checked).ToList();


                    DateTime? StartMonth = null;
                    DateTime? EndMonth = null;

                    switch (_cmbMonth.SelectedIndex)
                    {
                        case 0:
                            {
                                StartMonth = Convert.ToDateTime(_txtSal.Text + "/01/01");
                                EndMonth = Convert.ToDateTime(_txtSal.Text + "/01/31");
                                IndexMah = "01";
                                break;
                            }
                        case 1:
                            {
                                StartMonth = Convert.ToDateTime(_txtSal.Text + "/02/01");
                                EndMonth = Convert.ToDateTime(_txtSal.Text + "/02/31");
                                IndexMah = "02";
                                break;
                            }
                        case 2:
                            {
                                StartMonth = Convert.ToDateTime(_txtSal.Text + "/03/01");
                                EndMonth = Convert.ToDateTime(_txtSal.Text + "/03/31");
                                IndexMah = "03";
                                break;
                            }
                        case 3:
                            {
                                StartMonth = Convert.ToDateTime(_txtSal.Text + "/04/01");
                                EndMonth = Convert.ToDateTime(_txtSal.Text + "/04/31");
                                IndexMah = "04";
                                break;
                            }
                        case 4:
                            {
                                StartMonth = Convert.ToDateTime(_txtSal.Text + "/05/01");
                                EndMonth = Convert.ToDateTime(_txtSal.Text + "/05/31");
                                IndexMah = "05";
                                break;
                            }
                        case 5:
                            {
                                StartMonth = Convert.ToDateTime(_txtSal.Text + "/06/01");
                                EndMonth = Convert.ToDateTime(_txtSal.Text + "/06/31");
                                IndexMah = "06";
                                break;
                            }
                        case 6:
                            {
                                StartMonth = Convert.ToDateTime(_txtSal.Text + "/07/01");
                                EndMonth = Convert.ToDateTime(_txtSal.Text + "/07/30");
                                IndexMah = "07";
                                break;
                            }
                        case 7:
                            {
                                StartMonth = Convert.ToDateTime(_txtSal.Text + "/08/01");
                                EndMonth = Convert.ToDateTime(_txtSal.Text + "/08/30");
                                IndexMah = "08";
                                break;
                            }
                        case 8:
                            {
                                StartMonth = Convert.ToDateTime(_txtSal.Text + "/09/01");
                                EndMonth = Convert.ToDateTime(_txtSal.Text + "/09/30");
                                IndexMah = "09";
                                break;
                            }
                        case 9:
                            {
                                StartMonth = Convert.ToDateTime(_txtSal.Text + "/10/01");
                                EndMonth = Convert.ToDateTime(_txtSal.Text + "/10/30");
                                IndexMah = "10";
                                break;
                            }
                        case 10:
                            {
                                StartMonth = Convert.ToDateTime(_txtSal.Text + "/11/01");
                                EndMonth = Convert.ToDateTime(_txtSal.Text + "/11/30");
                                IndexMah = "11";
                                break;
                            }
                        case 11:
                            {
                                StartMonth = Convert.ToDateTime(_txtSal.Text + "/12/01");
                                EndMonth = Convert.ToDateTime(_txtSal.Text + "/12/29");
                                IndexMah = "12";
                                break;
                            }
                    }


                    var q = db.AazaSandoghs.Where(f => f.IsActive == true).ToList();
                    if (q.Count > 0)
                    {
                        for (int RowCounter = 0; RowCounter < q.Count(); RowCounter++)
                        {
                            string _Tozihat = string.Empty;
                            DataRow DataRow1 = dt.NewRow();
                            DataRow1[0] = q[RowCounter].NameVFamil;
                            DataRow1[1] = _txtSal.Text;
                            DataRow1[2] = _cmbMonth.Text;
                            DataRow1[3] = 0;
                            DataRow1[4] = 0;
                            DataRow1[5] = q[RowCounter].CodePersoneli;

                            int _AllTafId = q[RowCounter].AllTafId;
                            var qq1 = db.HaghOzviats.Where(f => f.AazaId == _AllTafId && f.Sal == _Sal).ToList();

                            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
                            {
                                DataRow1[3] = q[RowCounter].HaghOzviat != null ? q[RowCounter].HaghOzviat.Value.ToString("n0") : "0";
                                dt.Rows.Add(DataRow1);
                                gridControl1.DataSource = dt;
                            }
                            else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
                            {
                                int _Id = q[RowCounter].Id;
                                var q1 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 3 && f.Id2 == _Id);
                                if (q1 != null)
                                {
                                    decimal _MablaghAghsat = 0;
                                    //var q2 = db.RizeAghsatVams.Where(f => f.AazaId == q1.Id && f.TarikhSarresid <= EndMonth && f.MablaghDaryafti == 0 && f.VamPardakhti1.IsTasviye == false).ToList();
                                    var q5 = db.VamPardakhtis.Where(s => s.AazaId == q1.Id && s.IsTasviye == false).Select(s => s.Id).ToList();

                                    for (int i = 0; i < q5.Count; i++)
                                    {
                                        int VamId = q5[i];
                                        var q2 = db.RizeAghsatVams.Where(f => f.AazaId == q1.Id && f.MablaghDaryafti == 0 && f.MablaghAghsat > 0 && f.VamPardakhti1.IsTasviye == false && f.VamPardakhtiId == VamId).ToList();
                                        if (q2.Count > 0)
                                        {
                                            if (i > 0)
                                            {
                                                //string _Tozihat = string.Empty;
                                                DataRow1 = dt.NewRow();
                                                DataRow1[0] = q[RowCounter].NameVFamil;
                                                DataRow1[1] = _txtSal.Text;
                                                DataRow1[2] = _cmbMonth.Text;
                                                DataRow1[3] = 0;
                                                DataRow1[4] = 0;
                                                DataRow1[5] = q[RowCounter].CodePersoneli;
                                            }
                                            var q3 = q2.Min(s => s.TarikhSarresid);
                                            _MablaghAghsat = q2.FirstOrDefault(s => s.TarikhSarresid == q3).MablaghAghsat;
                                            DataRow1[4] = _MablaghAghsat.ToString("n0");
                                            DataRow1[6] = q3.ToString().Substring(0, 10);

                                            dt.Rows.Add(DataRow1);
                                        }

                                    }
                                }
                                //gridView1.Columns["Tozihat"].Caption = "سررسید قسط";
                                gridControl2.DataSource = dt;

                            }
                            else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
                            {
                                if (checkEdit1.Checked)
                                {
                                    if (qq1.Count == 0)
                                    {
                                        DataRow1[3] = q[RowCounter].HaghOzviat != null ? ((q[RowCounter].HaghOzviat.Value) * (_cmbMonth.SelectedIndex + 1)).ToString("n0") : "0";
                                        if (q[RowCounter].HaghOzviat.Value > 0)
                                            _Tozihat += "پس انداز " + (_cmbMonth.SelectedIndex + 1) + " ماه";
                                    }
                                    else
                                    {
                                        int qq2 = qq1.Max(f => f.IndexMonth);
                                        DataRow1[3] = q[RowCounter].HaghOzviat != null ? ((q[RowCounter].HaghOzviat.Value) * (_cmbMonth.SelectedIndex - qq2)).ToString("n0") : "0";
                                        if (_cmbMonth.SelectedIndex - qq2 > 0 && q[RowCounter].HaghOzviat.Value > 0)
                                            _Tozihat += "پس انداز " + (_cmbMonth.SelectedIndex - qq2) + " ماه";
                                    }

                                }
                                else
                                {
                                    var qq3 = qq1.FirstOrDefault(f => f.IndexMonth == _IndexMonth);
                                    if (qq3 == null)
                                    {
                                        DataRow1[3] = q[RowCounter].HaghOzviat != null ? q[RowCounter].HaghOzviat.Value.ToString("n0") : "0";
                                        if (q[RowCounter].HaghOzviat.Value > 0)
                                            _Tozihat += "پس انداز " + 1 + " ماه";
                                    }

                                }

                                int _Id = q[RowCounter].Id;
                                var q1 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 3 && f.Id2 == _Id);
                                if (q1 != null)
                                {

                                    if (checkEdit1.Checked)
                                    {
                                        var q2 = db.RizeAghsatVams.Where(f => f.AazaId == q1.Id && f.TarikhSarresid <= EndMonth && f.MablaghDaryafti == 0 && f.VamPardakhti1.IsTasviye == false).ToList();
                                        var q3 = db.RizeAghsatVams.Where(f => f.AazaId == q1.Id && f.TarikhSarresid <= EndMonth && f.MablaghDaryafti != 0 && f.MablaghDaryafti < f.MablaghAghsat && f.VamPardakhti1.IsTasviye == false).ToList();

                                        List<RizeAghsatVam> List1 = new List<RizeAghsatVam>();
                                        List1.AddRange(q2);
                                        List1.AddRange(q3);

                                        if (List1.Count > 0)
                                        {
                                            decimal _MablaghAghsat = 0;
                                            foreach (var item in List1)
                                            {
                                                _MablaghAghsat += item.MablaghAghsat - item.MablaghDaryafti;
                                                //_Tozihat += "قسط " + item.ShomareGhest + " وام ش " + item.VamPardakhtiCode + " + ";
                                            }
                                            string s0 = string.Empty;
                                            string s1 = string.Empty;

                                            s0 = q2.Count() > 0 ? " + " + q2.Count + " قسط وام " : "";
                                            s1 = q3.Count() > 0 ? " + " + q3.Count + " مورد کسری دریافتی اقساط" : "";
                                            _Tozihat += !string.IsNullOrEmpty(_Tozihat) ? s0 + s1 :
                                                s0 != "" ? q2.Count + " قسط وام " + s1 :
                                                s1 != "" ? q3.Count + " مورد کسری دریافتی اقساط" : "";

                                            DataRow1[4] = _MablaghAghsat.ToString("n0");
                                        }
                                    }
                                    else
                                    {
                                        var q2 = db.RizeAghsatVams.Where(f => f.AazaId == q1.Id && f.TarikhSarresid >= StartMonth && f.TarikhSarresid <= EndMonth && f.MablaghDaryafti == 0 && f.VamPardakhti1.IsTasviye == false).ToList();
                                        var q3 = db.RizeAghsatVams.Where(f => f.AazaId == q1.Id && f.TarikhSarresid >= StartMonth && f.TarikhSarresid <= EndMonth && f.MablaghDaryafti != 0 && f.MablaghDaryafti < f.MablaghAghsat && f.VamPardakhti1.IsTasviye == false).ToList();

                                        //var q2 = db.RizeAghsatVams.Where(f => f.AazaId == q1.Id && f.TarikhSarresid <= _Tarikh && f.MablaghDaryafti == 0).ToList();
                                        //var q3 = db.RizeAghsatVams.Where(f => f.AazaId == q1.Id && f.TarikhSarresid <= _Tarikh && f.MablaghDaryafti != 0 && f.MablaghDaryafti < f.MablaghAghsat).ToList();

                                        List<RizeAghsatVam> List1 = new List<RizeAghsatVam>();
                                        List1.AddRange(q2);
                                        List1.AddRange(q3);

                                        if (List1.Count > 0)
                                        {
                                            decimal _MablaghAghsat = 0;
                                            foreach (var item in List1)
                                            {
                                                _MablaghAghsat += item.MablaghAghsat - item.MablaghDaryafti;
                                                //_Tozihat += "قسط " + item.ShomareGhest + " وام ش " + item.VamPardakhtiCode + " + ";
                                            }
                                            string s0 = string.Empty;
                                            string s1 = string.Empty;
                                            s0 = q2.Count() > 0 ? " + " + q2.Count + " قسط وام " : "";
                                            s1 = q3.Count() > 0 ? " + " + q3.Count + " مورد کسری دریافتی اقساط" : "";
                                            _Tozihat += !string.IsNullOrEmpty(_Tozihat) ? s0 + s1 : s0 != "" ? q2.Count + " قسط وام " + s1 : s1 != "" ? q3.Count + " مورد کسری دریافتی اقساط" : "";

                                            DataRow1[4] = _MablaghAghsat.ToString("n0");
                                        }

                                    }

                                }

                                DataRow1[6] = _Tozihat;
                                decimal DataRow3 = DataRow1[3] != null ? Convert.ToDecimal(DataRow1[3]) : 0;
                                decimal DataRow4 = DataRow1[4].ToString() != "" ? Convert.ToDecimal(DataRow1[4]) : 0;

                                if (DataRow3 > 0 || DataRow4 > 0)
                                    dt.Rows.Add(DataRow1);

                                gridControl3.DataSource = dt;
                            }
                        }

                        //ds.Tables.Add(dt);
                    }
                    else
                        gridControl1.DataSource = gridControl2.DataSource = gridControl3.DataSource = null;
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
            FillDataGridView();
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            //HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);
        }

        private void FrmMabaleghGhabelDaryaft_Load(object sender, EventArgs e)
        {
            var Date = DateTime.Now;
            _txtSal = txtSal1;
            _cmbMonth = cmbMonth1;
            gridView = gridView1;
            FileName1 = "rptPasAndazeDaryaftani.repx";

            txtSal1.Text = txtSal2.Text = txtSal3.Text = Date.ToString().Substring(0, 4);
            switch (Date.ToString().Substring(5, 2))
            {
                case "01":
                    {
                        cmbMonth1.SelectedIndex = cmbMonth2.SelectedIndex = cmbMonth3.SelectedIndex = 0;
                        break;
                    }
                case "02":
                    {
                        cmbMonth1.SelectedIndex = cmbMonth2.SelectedIndex = cmbMonth3.SelectedIndex = 1;
                        break;
                    }
                case "03":
                    {
                        cmbMonth1.SelectedIndex = cmbMonth2.SelectedIndex = cmbMonth3.SelectedIndex = 2;
                        break;
                    }
                case "04":
                    {
                        cmbMonth1.SelectedIndex = cmbMonth2.SelectedIndex = cmbMonth3.SelectedIndex = 3;
                        break;
                    }
                case "05":
                    {
                        cmbMonth1.SelectedIndex = cmbMonth2.SelectedIndex = cmbMonth3.SelectedIndex = 4;
                        break;
                    }
                case "06":
                    {
                        cmbMonth1.SelectedIndex = cmbMonth2.SelectedIndex = cmbMonth3.SelectedIndex = 5;
                        break;
                    }
                case "07":
                    {
                        cmbMonth1.SelectedIndex = cmbMonth2.SelectedIndex = cmbMonth3.SelectedIndex = 6;
                        break;
                    }
                case "08":
                    {
                        cmbMonth1.SelectedIndex = cmbMonth2.SelectedIndex = cmbMonth3.SelectedIndex = 7;
                        break;
                    }
                case "09":
                    {
                        cmbMonth1.SelectedIndex = cmbMonth2.SelectedIndex = cmbMonth3.SelectedIndex = 8;
                        break;
                    }
                case "10":
                    {
                        cmbMonth1.SelectedIndex = cmbMonth2.SelectedIndex = cmbMonth3.SelectedIndex = 9;
                        break;
                    }
                case "11":
                    {
                        cmbMonth1.SelectedIndex = cmbMonth2.SelectedIndex = cmbMonth3.SelectedIndex = 10;
                        break;
                    }
                case "12":
                    {
                        cmbMonth1.SelectedIndex = cmbMonth2.SelectedIndex = cmbMonth3.SelectedIndex = 11;
                        break;
                    }
            }
            xtraTabControl1_SelectedPageChanged(null, null);
            //FillDataGridView1();
        }

        // int RowIndex = 0;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // RowIndex = gridView1.GetRowHandle(e.FocusedRowHandle);

        }

        GridView gridView;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            gridView.DeleteSelectedRows();
        }

        string FilePath = Application.StartupPath + @"\Report\Ghozareshat\";
        string FileName1 = string.Empty;

        public string _SandoghName = string.Empty;

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            #region MyRegion
            //if (System.IO.File.Exists(FilePath + FileName1))
            //{
            //    if (gridView.RowCount > 0)
            //    {
            //        XtraReport XtraReport1 = new XtraReport();
            //        XtraReport1.LoadLayoutFromXml(FilePath + FileName1);

            //        XtraReport1.DataSource = gridView.DataSource;

            //        // XtraReport1.Parameters["Az_Tarikh"].Value = ChkTarikh.Checked ? txtAzTarikh.Text : new MyContext().AsnadeHesabdariRows.Min(f => f.Tarikh).ToString().Substring(0, 10);
            //        //XtraReport1.Parameters["Ta_Tarikh"].Value = ChkTarikh.Checked ? txtTaTarikh.Text : DateTime.Now.ToString().Substring(0, 10);
            //        XtraReport1.Parameters["TarikhVSaat"].Value = DateTime.Now;
            //        //XtraReport1.Parameters["HesabMoin"].Value = _HesabMoin;
            //        //XtraReport1.Parameters["HesabTafzil"].Value = cmbHesabTafzili.Text;
            //        XtraReport1.Parameters["SandoghName"].Value = _SandoghName;
            //        FrmPrinPreview FPP = new FrmPrinPreview();
            //        FPP.documentViewer1.DocumentSource = XtraReport1;
            //        FPP.ShowDialog();
            //    }
            //}
            //else
            //{
            //    HelpClass1.NewReportDesigner(FilePath, FileName1);
            //}

            #endregion

            //foreach (DataGridViewColumn column in gridView.Columns)
            //{
            //    if (column.Visible)
            //        dt.Columns.Add(column.Name);
            //}

            //foreach (DataGridViewRow row in gridView.Rows)
            //{
            //    DataRow dRow = dt.NewRow();
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        dRow[cell.ColumnIndex] = cell.Value;
            //    }
            //    dt.Rows.Add(dRow);
            //}

            DataTable dt = new DataTable();
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                //if (gridView.Columns[i].Visible)
                dt.Columns.Add(gridView.Columns[i].FieldName);
            }

            for (int i = 0; i < gridView.RowCount; i++)
            {
                DataRow dRow = dt.NewRow();
                //dRow[cell.ColumnIndex] = cell.Value;
                //if (gridView.Columns["Line"].Visible)
                //dRow["Line"] = gridView.GetRowCellValue(i, "Line");
                if (gridView.Columns["CodePersoneli"].Visible)
                    dRow["CodePersoneli"] = gridView.GetRowCellDisplayText(i, "CodePersoneli");
                if (gridView.Columns["NameAaza"].Visible)
                    dRow["NameAaza"] = gridView.GetRowCellDisplayText(i, "NameAaza");
                //if (gridView.Columns["Sal"].Visible)
                //dRow["Sal"] = _txtSal.Text;
                //if (gridView.Columns["Month"].Visible)
                //dRow["Month"] = _cmbMonth.Text;
                if (gridView.Columns["MablaghPasandaz"].Visible)
                    dRow["MablaghPasandaz"] = gridView.GetRowCellDisplayText(i, "MablaghPasandaz");
                if (gridView.Columns["MablaghAghsat"].Visible)
                    dRow["MablaghAghsat"] = gridView.GetRowCellDisplayText(i, "MablaghAghsat");
                if (gridView.Columns["Sum"].Visible)
                    dRow["Sum"] = gridView.Columns["MablaghPasandaz"].Visible && gridView.Columns["MablaghAghsat"].Visible ? gridView.GetRowCellDisplayText(i, "Sum") :
                        gridView.Columns["MablaghPasandaz"].Visible && !gridView.Columns["MablaghAghsat"].Visible ? gridView.GetRowCellDisplayText(i, "MablaghPasandaz") :
                        !gridView.Columns["MablaghPasandaz"].Visible && gridView.Columns["MablaghAghsat"].Visible ? gridView.GetRowCellDisplayText(i, "MablaghAghsat") : "";
                else
                    dRow["Sum"] = string.Empty;
                if (gridView.Columns["Tozihat"].Visible && gridView.Columns["MablaghPasandaz"].Visible && gridView.Columns["MablaghAghsat"].Visible)
                    dRow["Tozihat"] = gridView.GetRowCellDisplayText(i, "Tozihat");
                dt.Rows.Add(dRow);
            }

            if (System.IO.File.Exists(FilePath + FileName1))
            {
                if (gridView.RowCount > 0)
                {
                    XtraReport XtraReport1 = new XtraReport();
                    XtraReport1.LoadLayoutFromXml(FilePath + FileName1);


                    XtraReport1.DataSource = dt;

                    // XtraReport1.Parameters["Az_Tarikh"].Value = ChkTarikh.Checked ? txtAzTarikh.Text : new MyContext().AsnadeHesabdariRows.Min(f => f.Tarikh).ToString().Substring(0, 10);
                    //XtraReport1.Parameters["Ta_Tarikh"].Value = ChkTarikh.Checked ? txtTaTarikh.Text : DateTime.Now.ToString().Substring(0, 10);
                    XtraReport1.Parameters["Sal"].Value = _txtSal.Text;
                    XtraReport1.Parameters["Month"].Value = _cmbMonth.Text;
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

        private void btnDesignReport_Click(object sender, EventArgs e)
        {
            HelpClass1.LoadReportDesigner(FilePath, FileName1);

        }


        private void FrmMabaleghGhabelDaryaft_KeyDown(object sender, KeyEventArgs e)
        {

            HelpClass1.ControlAltShift_KeyDown(sender, e, button);

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            checkEdit2.Checked = checkEdit1.Checked ? false : true;
            labelControl1.Text = checkEdit1.Checked ? "تا سال" : "سال";
            labelControl2.Text = checkEdit1.Checked ? "تا ماه" : "ماه";
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            checkEdit1.Checked = checkEdit2.Checked ? false : true;
            labelControl1.Text = checkEdit2.Checked ? "سال" : "تا سال";
            labelControl2.Text = checkEdit2.Checked ? "ماه" : "تا ماه";

        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            HelpClass1.CustomDrawRowIndicator(sender, e, view);
        }

        SimpleButton button;
        //string xtraTabPage = "";
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //xtraTabPage = xtraTabControl1.SelectedTabPage.Text;
            //xtraTabControl1.SelectedTabPage.Controls.Add(gridControl1);
            button = new SimpleButton();
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                //panelControl3.SendToBack();
                //gridView1.Columns["MablaghPasandaz"].Visible = true;
                //gridView1.Columns["MablaghAghsat"].Visible = false;
                //gridView1.Columns["Sum"].Visible = false;
                //gridView1.Columns["Tozihat"].Visible = false;
                _txtSal = txtSal1;
                _cmbMonth = cmbMonth1;
                gridView = gridView1;
                button = simpleButton2;
                FileName1 = "rptPasAndazeDaryaftani.repx";

            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
            {
                //panelControl4.SendToBack();
                //gridView1.Columns["MablaghPasandaz"].Visible = false;
                //gridView1.Columns["MablaghAghsat"].Visible = true;
                //gridView1.Columns["Sum"].Visible = false;
                //gridView1.Columns["Tozihat"].Visible = false;
                _txtSal = txtSal2;
                _cmbMonth = cmbMonth2;
                gridView = gridView2;
                button = simpleButton6;
                FileName1 = "rptAghsateDaryaftani.repx";

            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
            {
                //panelControl1.SendToBack();
                //gridView1.Columns["MablaghPasandaz"].Visible = true;
                //gridView1.Columns["MablaghAghsat"].Visible = true;
                //gridView1.Columns["Sum"].Visible = true;
                //gridView1.Columns["Tozihat"].Visible = true;

                ////gridView.Columns["DateTimeInsert"].VisibleIndex = 19;
                //gridView1.Columns["MablaghPasandaz"].VisibleIndex = 4;
                //gridView1.Columns["MablaghAghsat"].VisibleIndex = 5;
                //gridView1.Columns["Sum"].VisibleIndex = 6;
                //gridView1.Columns["Tozihat"].VisibleIndex = 7;
                _txtSal = txtSal3;
                _cmbMonth = cmbMonth3;
                gridView = gridView3;
                button = btnDesignReport;
                FileName1 = "rptMabaleghGhabelDaryaft.repx";

            }

        }

        private void gridView2_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            DateTime DateNow = DateTime.Now;
            GridView view = sender as GridView;
            int SalSarresid = 0;
            string MonthSarresid = string.Empty;
            if (view.RowCount > 0)
            {
                // bool IsActive = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "IsActive"));
                //int ShomareSanad = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "ShomareSanad"));
                //decimal MablaghAghsat = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, "MablaghAghsat"));
                //decimal MablaghDaryafti = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, "MablaghDaryafti"));
                //DateTime Date1 = Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, "Tozihat"));
                if (view.GetRowCellDisplayText(e.RowHandle, "Tozihat") != null)
                {
                    SalSarresid = Convert.ToInt32(view.GetRowCellDisplayText(e.RowHandle, "Tozihat").ToString().Substring(0, 4));
                    MonthSarresid = view.GetRowCellDisplayText(e.RowHandle, "Tozihat").ToString().Substring(5, 2);
                }

                if (SalSarresid < Convert.ToInt32(_txtSal.Text))
                {
                    Color foreColor = Color.Red;
                    e.Appearance.ForeColor = foreColor;
                }
                else if (SalSarresid == Convert.ToInt32(_txtSal.Text))
                {
                    if (MonthSarresid == IndexMah)
                    {
                        return;
                    }
                    else if (Convert.ToInt16(MonthSarresid) < Convert.ToInt16(IndexMah))
                    {
                        Color foreColor = Color.Red;
                        e.Appearance.ForeColor = foreColor;
                        //e.Appearance.BackColor = Color.LightYellow;

                    }
                    else if (Convert.ToInt16(MonthSarresid) > Convert.ToInt16(IndexMah))
                    {
                        Color foreColor = Color.Blue;
                        e.Appearance.ForeColor = foreColor;
                        //e.Appearance.BackColor = Color.LightBlue;
                    }

                }
                else if (SalSarresid > Convert.ToInt32(_txtSal.Text))
                {
                    Color foreColor = Color.Blue;
                    e.Appearance.ForeColor = foreColor;
                }

            }

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

        private void gridView3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(gridView3, gridView3.RowCount);
            }

        }
    }
}