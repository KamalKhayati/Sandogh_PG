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
    public partial class FrmOdatCheckTazmin : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmOdatCheckTazmin(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        public EnumCED En;

        private void cmbNoeSanad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNoeSanad.SelectedIndex == 0 || cmbNoeSanad.SelectedIndex == -1)
            {
                labelControl4.Text = "شماره چک";
                labelControl14.Text = "تاریخ چک";
                labelControl19.Text = "مبلغ چک";
                labelControl8.Text = "صاحب چک";
                //txtShomareHesab.ReadOnly = false;
            }
            else
            {
                labelControl4.Text = "شماره سفته";
                labelControl14.Text = "تاریخ سفته";
                labelControl19.Text = "مبلغ سفته";
                labelControl8.Text = "ضامن سفته";
                //txtShomareHesab.ReadOnly = true;
            }
        }

        public void FillDataGridCheckTazmin()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.CheckTazmins.Where(s => s.IsInSandogh == false).OrderBy(s => s.SeryalDaryaft);
                    if (q.Count() > 0)
                        gridControl1.DataSource = q.ToList();
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

        public void FillcmbVamGerande()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 3).ToList();
                    if (q1.Count > 0)
                        allHesabTafzilisBindingSource.DataSource = q1;
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

        private void FrmOdatCheckTazmin_Load(object sender, EventArgs e)
        {
            FillDataGridCheckTazmin();
            HelpClass1.DateTimeMask(txtTarikhDaryaft);
            HelpClass1.DateTimeMask(txtTarikhCheck);
            HelpClass1.DateTimeMask(txtTarikhOdat);
            gridView1.MoveLast();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool TextEditValidation()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (string.IsNullOrEmpty(txtTarikhOdat.Text))
                    {
                        XtraMessageBox.Show("لطفاً تاریخ عودت چک را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSeryalDaryaft.Focus();
                        return false;
                    }
                    else 
                    {
                        int _AazaId = Convert.ToInt32(cmbVamGerande.EditValue);
                        var n1 = db.VamPardakhtis.FirstOrDefault(s => s.AazaId == _AazaId && s.IsTasviye==false);
                        if (n1!=null)
                        {
                            if (XtraMessageBox.Show("صاحب چک وام تسویه نشده دارد آیا با این حال باز هم چک عودت شود", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.Yes)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return true;


        }

        private void FrmOdatCheckTazmin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnCreate_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F3 && btnDelete.Enabled == true)
            {
                btnDelete_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F4 && btnEdit.Enabled == true)
            {
                btnEdit_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F5 && btnSave.Enabled == true)
            {
                btnSave_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F6 && btnCancel.Enabled == true)
            {
                btnCancel_Click(sender, null);
            }
            //else if (e.KeyCode == Keys.F7)
            //{
            //    btnDisplayCheckInSandogh_Click(sender, null);
            //}
            else if (e.KeyCode == Keys.F7)
            {
                btnDisplayCheckOdatShode_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnSaveNext_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F10)
            {
                btnAdvancedSearch_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F11)
            {
                btnPrintPreview_Click(sender, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, null);
            }

            HelpClass1.ControlAltShift_KeyDown(sender, e, btnDesignReport);

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            gridView1.MoveLast();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            gridView1.MoveNext();

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            gridView1.MovePrev();

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            gridView1.MoveFirst();
        }

        public void btnDisplayCheckOdatShode_Click(object sender, EventArgs e)
        {
            FillDataGridCheckTazmin();
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEdit_Click(null, null);
            }

        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);
        }

        private void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            gridView1.OptionsFind.AlwaysVisible = gridView1.OptionsFind.AlwaysVisible ? false : true;
        }

        public void InActiveButtons()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                foreach (SimpleButton item in panelControl2.Controls)
                {
                    item.Enabled = false;
                }
                btnSave.Enabled = true;
                btnSaveNext.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;
            }
        }

        public void ActiveButtons()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                foreach (SimpleButton item in panelControl2.Controls)
                {
                    item.Enabled = true;
                }
                btnSave.Enabled = false;
                btnSaveNext.Enabled = false;
                btnCancel.Enabled = false;
            }
        }

        public void ClearControls()
        {
            txtSeryalDaryaft.Text = string.Empty;
            txtTarikhDaryaft.Text = string.Empty;
            cmbVamGerande.Text = string.Empty;
            cmbNoeSanad.SelectedIndex = -1;
            txtShCheck.Text = string.Empty;
            txtTarikhCheck.Text = string.Empty;
            txtMamlaghCheck.Text = string.Empty;
            txtShomareHesab.Text = string.Empty;
            txtNameBankVShobe.Text = string.Empty;
            txtSahebCheck.Text = string.Empty;
            txtSharhSanad.Text = string.Empty;
            txtTarikhOdat.Text = string.Empty;
            txtSharhOdat.Text = string.Empty;

        }

        public void ActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                txtTarikhOdat.ReadOnly = false;
                txtSharhOdat.ReadOnly = false;
            }
            FillcmbVamGerande();

        }

        public void InActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                txtTarikhOdat.ReadOnly = true;
                txtSharhOdat.ReadOnly = true;
            }
        }

        public int EditRowIndex = 0;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            //gridControl1.Enabled = false;
            FrmListCheckTazminNazdeSandogh fm = new FrmListCheckTazminNazdeSandogh(this);
            fm.ShowDialog();
            txtTarikhOdat.Focus();
            txtSharhOdat.Text = "بابت عودت " + cmbNoeSanad.Text + " تضمین به شماره " + txtShCheck.Text;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (XtraMessageBox.Show("آیا عودت چک فوق ابطال گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    EditRowIndex = gridView1.FocusedRowHandle;
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                            var q = db.CheckTazmins.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                q.TarikhOdatCheck = null;
                                q.SharhOdatCheck = string.Empty;
                                q.VaziyatCheck = "نزد صندوق";
                                q.IsInSandogh = true;
                                /////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();

                                btnDisplayCheckOdatShode_Click(null, null);
                                // XtraMessageBox.Show("عملیات ابطال عودت با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex - 1;
                            }
                            else
                                XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //catch (DbUpdateException)
                        //{
                        //    XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این حساب مقدور نیست \n" +
                        //        " جهت حذف حساب مورد نظر در ابتدا بایستی زیر شاخه های این حساب یعنی پس انداز ماهیانه اعضاء،\n وامهای دریافتی اعضا،ریز اقساط وام، انتقالی بین حسابها، سند های درآمد و هزینه ، و سایر دریافتها و\n پرداختها مربوط به این حساب در صورت وجود حذف گردد" +
                        //        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && btnEdit.Visible == true)
            {
                gridControl1.Enabled = false;
                EditRowIndex = gridView1.FocusedRowHandle;
                En = EnumCED.Edit;
                InActiveButtons();
                ActiveControls();

                txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                txtSeryalDaryaft.Text = gridView1.GetFocusedRowCellValue("SeryalDaryaft").ToString();
                txtTarikhDaryaft.Text = gridView1.GetFocusedRowCellValue("TarikhDaryaft").ToString().Substring(0, 10); ;
                cmbVamGerande.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("VamGerandeId"));
                cmbNoeSanad.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("NoeSanadId"));
                txtShCheck.Text = gridView1.GetFocusedRowCellValue("ShCheck").ToString();
                if (gridView1.GetFocusedRowCellValue("TarikhCheck") != null)
                    txtTarikhCheck.Text = gridView1.GetFocusedRowCellValue("TarikhCheck").ToString().Substring(0, 10);
                txtMamlaghCheck.Text = gridView1.GetFocusedRowCellValue("Mablagh").ToString();
                txtShomareHesab.Text = gridView1.GetFocusedRowCellValue("ShomareHesab").ToString();
                txtNameBankVShobe.Text = gridView1.GetFocusedRowCellValue("NameBank").ToString();
                txtSahebCheck.Text = gridView1.GetFocusedRowCellValue("SahebCheck").ToString();
                txtSharhSanad.Text = gridView1.GetFocusedRowCellValue("SharhDaryaftCheck").ToString();
                if (gridView1.GetFocusedRowCellValue("TarikhOdatCheck") != null)
                    txtTarikhOdat.Text = gridView1.GetFocusedRowCellValue("TarikhOdatCheck").ToString().Substring(0, 10);
                txtSharhOdat.Text = gridView1.GetFocusedRowCellValue("SharhOdatCheck").ToString();

                txtTarikhOdat.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (TextEditValidation())
            {
                if (En == EnumCED.Create)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.CheckTazmins.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                if (!string.IsNullOrEmpty(txtTarikhOdat.Text))
                                    q.TarikhOdatCheck = Convert.ToDateTime(txtTarikhOdat.Text);
                                q.SharhOdatCheck = txtSharhOdat.Text;
                                q.VaziyatCheck = "عودت";
                                q.IsInSandogh = false;

                                db.SaveChanges();
                                btnDisplayCheckOdatShode_Click(null, null);

                                //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex;
                                gridControl1.Enabled = true;
                                ActiveButtons();
                                ClearControls();
                                InActiveControls();
                                En = EnumCED.Save;
                            }
                            else
                                XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.ToString(), "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (En == EnumCED.Edit)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.CheckTazmins.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                if (!string.IsNullOrEmpty(txtTarikhOdat.Text))
                                    q.TarikhOdatCheck = Convert.ToDateTime(txtTarikhOdat.Text);
                                q.SharhOdatCheck = txtSharhOdat.Text;
                                //q.VaziyatCheck = "عودت";
                                //q.IsInSandogh = false;

                                db.SaveChanges();
                                btnDisplayCheckOdatShode_Click(null, null);

                                //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex;
                                gridControl1.Enabled = true;
                                ActiveButtons();
                                ClearControls();
                                InActiveControls();
                                En = EnumCED.Save;
                            }
                            else
                                XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gridControl1.Enabled = true;
            ActiveButtons();
            ClearControls();
            InActiveControls();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //gridView1_RowCellClick(null, null);
            //btnDelete.Enabled = btnEdit.Enabled = gridView1.RowCount > 0 && gridView1.GetFocusedRowCellValue("TarikhOdatCheck") != null ? true : false;
            btnDelete.Enabled = btnEdit.Enabled = gridView1.RowCount > 0 ? true : false;

        }

        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
            if (En == EnumCED.Save)
                btnCreate_Click(null, null);
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //btnCreate.Enabled = gridView1.RowCount > 0 && gridView1.GetFocusedRowCellValue("TarikhOdatCheck") == null ? true : false;
        }

        string FilePath1 = Application.StartupPath + @"\Report\Ghozareshat\";
        string FileName1 = "rptDaryaftTazmin.repx";
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(FilePath1 + FileName1))
            {
                if (gridView1.RowCount > 0)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            var _TarikhDaryaft = Convert.ToDateTime(gridView1.GetFocusedRowCellValue("TarikhOdatCheck").ToString().Substring(0, 10));
                            int _VamGerandeId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("VamGerandeId"));
                            var q = db.CheckTazmins.Where(f => f.VamGerandeId == _VamGerandeId && f.TarikhOdatCheck == _TarikhDaryaft && f.IsInSandogh == false).ToList();
                            if (q.Count > 0)
                            {
                                XtraReport XtraReport1 = new XtraReport();
                                XtraReport1.LoadLayoutFromXml(FilePath1 + FileName1);
                                XtraReport1.Parameters["TarikhVSaat"].Value = DateTime.Now;
                                XtraReport1.Parameters["SandoghName"].Value = Fm.ribbonControl1.ApplicationDocumentCaption;
                                XtraReport1.DataSource = q;
                                FrmPrinPreview FPP = new FrmPrinPreview();
                                FPP.documentViewer1.DocumentSource = XtraReport1;
                                FPP.ShowDialog();
                            }
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //XtraReport1.DataSource = HelpClass1.ConvettDatagridviewToDataSet(gridView1);

                    //XtraReport1.Parameters["ShomareSanad"].Value = gridView3.GetFocusedRowCellDisplayText("ShomareSanad");
                    //XtraReport1.Parameters["NahveyePardakht"].Value = gridView3.GetFocusedRowCellDisplayText("NahveyePardakht");
                    //XtraReport1.Parameters["NoeVam"].Value = gridView3.GetFocusedRowCellDisplayText("NoeVam");
                    //XtraReport1.Parameters["DarsadeKarmozd"].Value = gridView3.GetFocusedRowCellDisplayText("DarsadeKarmozd");
                    //XtraReport1.Parameters["MablaghDirkard"].Value = gridView3.GetFocusedRowCellDisplayText("MablaghDirkard");
                    //XtraReport1.Parameters["TarikhDarkhast"].Value = gridView3.GetFocusedRowCellDisplayText("TarikhDarkhast");
                    //XtraReport1.Parameters["ShomareDarkhast"].Value = gridView3.GetFocusedRowCellDisplayText("ShomareDarkhast");
                    //XtraReport1.Parameters["Code"].Value = gridView3.GetFocusedRowCellDisplayText("Code");
                    //XtraReport1.Parameters["TarikhPardakht"].Value = gridView3.GetFocusedRowCellDisplayText("TarikhPardakht");
                    //XtraReport1.Parameters["MablaghAsli"].Value = gridView3.GetFocusedRowCellDisplayText("MablaghAsli");
                    //XtraReport1.Parameters["MablaghKarmozd"].Value = gridView3.GetFocusedRowCellDisplayText("MablaghKarmozd");
                    //XtraReport1.Parameters["FaseleAghsat"].Value = gridView3.GetFocusedRowCellDisplayText("FaseleAghsat");
                    //XtraReport1.Parameters["TedadAghsat"].Value = gridView3.GetFocusedRowCellDisplayText("TedadAghsat");
                    //XtraReport1.Parameters["MablaghAghsat"].Value = gridView3.GetFocusedRowCellDisplayText("MablaghAghsat");
                    //XtraReport1.Parameters["SarresidAvalinGhest"].Value = gridView3.GetFocusedRowCellDisplayText("SarresidAvalinGhest");
                    //XtraReport1.Parameters["ZameninName"].Value = gridView3.GetFocusedRowCellDisplayText("ZameninName");
                    //XtraReport1.Parameters["HaveCheckTazmin"].Value = gridView3.GetFocusedRowCellDisplayText("HaveCheckTazmin");


                    //XtraReport1.DataSource = gridView2.DataSource;
                    //XtraReport1.Parameters["Az_Tarikh"].Value = ChkTarikh.Checked ? txtAzTarikh.Text : gridView2.GetRowCellDisplayText(0, "Tarikh").Substring(0, 10);
                    //XtraReport1.Parameters["Ta_Tarikh"].Value = ChkTarikh.Checked ? txtTaTarikh.Text : DateTime.Now.ToString().Substring(0, 10);
                    //XtraReport1.Parameters["HesabMoin"].Value = _HesabMoin;

                    //List<decimal> ListMande1 = new List<decimal>();
                    //for (int i = 0; i < gridView1.RowCount; i++)
                    //{
                    //    ListMande1.Add(Convert.ToDecimal(gridView2.GetRowCellValue(i, "Mande1")));
                    //}
                    //XtraReport1.Parameters["Mande1"].Value = ListMande1;

                }
            }
            else
            {
                HelpClass1.NewReportDesigner(FilePath1, FileName1);
            }
        }

        private void btnDesignReport_Click(object sender, EventArgs e)
        {
            HelpClass1.LoadReportDesigner(FilePath1, FileName1);
        }


    }
}