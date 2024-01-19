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
using System.IO;
using Sandogh_PG;
using System.Data.Entity.Infrastructure;
using Sandogh_PG.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraGrid.Views.Grid;

namespace Sandogh_PG
{
    public partial class FrmTarifAaza_1 : DevExpress.XtraEditors.XtraForm
    {
        public FrmMain Fm;
        public FrmTarifAaza_1(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        FrmVamPardakhti Km;
        public FrmTarifAaza_1(FrmVamPardakhti km)
        {
            InitializeComponent();
            Km = km;
        }


        public EnumCED En = EnumCED.Cancel;
        public bool IsActiveList = true;

        public void FillDataGridTarifAaza()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    if (IsActiveList == true)
                    {
                        var q1 = dataContext.AazaSandoghs.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0)
                        {
                            gridControl1.DataSource = q1;
                            gridView1.MoveLast();
                        }
                        else
                            gridControl1.DataSource = null;
                    }
                    else
                    {
                        var q = dataContext.AazaSandoghs.Where(s => s.IsActive == false).OrderBy(s => s.Code);
                        if (q.Count() > 0)
                        {
                            gridControl1.DataSource = q.ToList();
                            gridView1.MoveLast();
                        }
                        else
                            gridControl1.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbMoaref()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    if (IsActiveList == true)
                    {
                        var q1 = dataContext.AazaSandoghs.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0)
                            aazaSandoghsBindingSource.DataSource = q1;
                        else
                            aazaSandoghsBindingSource.DataSource = null;
                    }
                    else
                    {
                        var q = dataContext.AazaSandoghs.OrderBy(s => s.Code);
                        if (q.Count() > 0)
                            aazaSandoghsBindingSource.DataSource = q.ToList();
                        else
                            aazaSandoghsBindingSource.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void NewCode(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.AazaSandoghs.Select(s => s);
                    if (q.Any())
                    {
                        var MaximumCod = q.Max(p => p.Code);
                        if (MaximumCod.ToString() != "9999999")
                        {
                            txtCode.Text = (MaximumCod + 1).ToString();
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                                XtraMessageBox.Show("اعمال محدودیت تعریف 2999999 حساب  ..." + "\n" +
                                    "توجه : نمیتوان بیشتر از این تعداد حساب تعریف کرد ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        txtCode.Text = "7000001";
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        bool IsActiveBeforeEdit = true;
        private void FrmTarifAaza_1_Load(object sender, EventArgs e)
        {
            _SandoghId = Convert.ToInt32(Fm.IDSandogh.Caption);
            FillDataGridTarifAaza();

            HelpClass1.DateTimeMask(txtTarikhTasviyeVam);
            HelpClass1.DateTimeMask(txtTarikhOzviat);
            HelpClass1.DateTimeMask(txtBirthDate);

            using (var db = new MyContext())
            {
                try
                {
                    var q = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SandoghId);
                    if (q != null)
                    {
                        if (q.checkEdit6)
                        {
                            if (q.NoeRezervIndex == 1)
                            {
                                btnNobatVam.Visible = txtNobatbandiVam.Visible = labelControl26.Visible = true;
                            }
                            else if (q.NoeRezervIndex == 2)
                            {
                                btnMohasebeTarikhMabnayeNobatVam.Visible = txtTarikhTasviyeVam.Visible = lblMohasebeTarikhMabnayeNobat.Visible = true;

                            }
                        }

                        if (q.radioGroup3 == 0)
                        {
                            txtMablaghPasandaz.Enabled = true;
                            //btnAmaliatColi.Visible = true;
                        }
                        else
                        {
                            txtDarsadPasandaz.Enabled = true;
                            //btnAmaliatColi.Visible = false;
                        }

                        btnChangeSaghfeEtebar.Visible =
                            labelControl30.Visible =
                            labelControl31.Visible =
                            labelControl32.Visible =
                            txtSaghfeEtebar.Visible =
                            txtEtebarBlookeShode.Visible =
                            txtMandeEtebar.Visible = q.checkEdit5 == false ? false : true;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool TextEditValidation()
        {
            ///////////////// اعتبار سنجی کد ////////////////////////////////////
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToInt32(txtCode.Text) <= 7000000 || Convert.ToInt32(txtCode.Text) >= 10000000)
            {
                XtraMessageBox.Show("کد وارده بایستی عددی بزرگتر از 7000000 و کمتر از 10000000 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtNameVFamil.Text))
            {
                XtraMessageBox.Show("لطفا نام , فامیل را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameVFamil.Focus();
                return false;
            }
            else if (new MyContext().Tanzimats.FirstOrDefault().checkEdit18 == true)
            {
                if (string.IsNullOrEmpty(txtCodeMeli.Text))
                {
                    XtraMessageBox.Show("لطفا کد ملی را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodeMeli.Focus();
                    return false;

                }
                else if (txtCodeMeli.Text.Length < 10)
                {
                    XtraMessageBox.Show("کد ملی باید 10 رقم باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodeMeli.Focus();
                    return false;
                }

            }



            if (string.IsNullOrEmpty(txtNobatbandiVam.Text) || txtNobatbandiVam.Text == "0")
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        var t = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SandoghId);
                        if (t != null && t.checkEdit6)
                        {
                            if (t.NoeRezervIndex == 1)
                            {
                                XtraMessageBox.Show("شماره نوبت وام را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtNobatbandiVam.Focus();
                                return false;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            if (string.IsNullOrEmpty(txtTarikhTasviyeVam.Text))
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        var t = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SandoghId);
                        if (t != null && t.checkEdit6)
                        {
                            if (t.NoeRezervIndex == 2)
                            {
                                XtraMessageBox.Show("تاریخ مبنای نوبت بندی وام را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtTarikhTasviyeVam.Focus();
                                return false;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            if (txtDarsadPasandaz.Enabled == true)
            {
                if (string.IsNullOrEmpty(txtDarsadPasandaz.Text))
                {
                    XtraMessageBox.Show("درصد مبلغ پس انداز ماهیانه را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;

                }
                else 
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            var q = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SandoghId);
                            if (q != null && q.checkEdit17)
                            {
                                if (q.radioGroup3 == 1)
                                {
                                    double DarsadPasandaz = string.IsNullOrEmpty(txtDarsadPasandaz.Text) ? 0 : Convert.ToDouble(txtDarsadPasandaz.Text);
                                    //double MaxDarsadPasandaz = Convert.ToDouble(txtMaxDarsadPasandaz.Text);
                                    if (DarsadPasandaz < q.MinDarsadPasandaz)
                                    {
                                        XtraMessageBox.Show(" درصد پس انداز ماهیانه از حداقل درصد تعیین شده در تنظیمات کمتر است \n حداقل درصد پیش فرض :" + " % " + q.MinDarsadPasandaz
                                            , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return false;

                                    }
                                    else if (DarsadPasandaz > q.MaxDarsadPasandaz)
                                    {
                                        XtraMessageBox.Show(" درصد پس انداز ماهیانه از حداکثر درصد تعیین شده در تنظیمات بیشتر است \n حداکثر درصد پیش فرض :" + " % " + q.MaxDarsadPasandaz
                                            , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                }
            }

            if (string.IsNullOrEmpty(txtTarikhOzviat.Text))
            {
                XtraMessageBox.Show("لطفا تاریخ عضویت را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTarikhOzviat.Focus();
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            if (db.AazaSandoghs.Any())
                            {
                                var q1 = db.AazaSandoghs.FirstOrDefault(p => p.NameVFamil == txtNameVFamil.Text);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.AazaSandoghs.FirstOrDefault(p => p.Id != RowId && p.NameVFamil == txtNameVFamil.Text);
                            if (q1 != null)
                            {
                                XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //txtName.Text = nameBeforeEdit;
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return true;
        }

        private void FrmTarifAaza_1_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.F7)
            {
                btnDisplyActiveList_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnDisplyNotActiveList_Click(sender, null);
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
            //else if (e.KeyCode == Keys.F12 && btnPrint.Enabled == true)
            //{
            //    btnPrint_Click(sender, null);
            //}
            else if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, null);
            }
            else if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.F12)
            {
                HelpClass1.ControlAltShift_KeyDown(sender, e, btnDesignReport);
            }
            else if (e.Alt && e.Control)
            {
                _ControlAlt = true ;
            }


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

        string FilePath1 = Application.StartupPath + @"\Report\Ghozareshat\";
        string FileName1 = "rptListAaza.repx";

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            //HelpClass1.PrintPreview(gridControl1, gridView1);
            if (System.IO.File.Exists(FilePath1 + FileName1))
            {
                if (gridView1.RowCount > 0)
                {
                    //byte[] byte1 = null;
                    //using (var db = new MyContext())
                    //{
                    //    try
                    //    {
                    //        var q1 = db.TarifSandoghs.FirstOrDefault(s => s.Id == 1);
                    //        if (q1 != null)
                    //        {
                    //            if (q1.Pictuer != null)
                    //            {
                    //                //MemoryStream ms = new MemoryStream(q1.Pictuer);
                    //                //img = Image.FromStream(ms);
                    //                byte1 = Convert.ToSByte(q1.Pictuer);
                    //            }
                    //            //else
                    //               // img = null;

                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                    //            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //}

                    //Image imge1 = null;
                    //MemoryStream ms = new MemoryStream();
                    //img = Image.FromFile("PG_07.jpg");
                    // imge1.Save(ms, Fm.pictureEdit1.Image.RawFormat);
                    // byte[] myarrey = ms.GetBuffer();
                    // gridView1.SetRowCellValue(0, colLogo, myarrey);
                    XtraReport XtraReport1 = new XtraReport();
                    XtraReport1.LoadLayoutFromXml(FilePath1 + FileName1);
                    XtraReport1.DataSource = gridView1.DataSource;

                    //XtraReport XtraReport2 = new XtraReport();
                    //XtraReport2.LoadLayoutFromXml(FilePath1 + FileName1);
                    //XtraReport2.DataSource = new MyContext().TarifSandoghs.FirstOrDefault();

                    //XtraReport XtraReport = new XtraReport();
                    //XtraReport.LoadLayoutFromXml(FilePath1 + FileName1);
                    //XtraReport = XtraReport1 + XtraReport2;

                    XtraReport1.Parameters["TarikhVSaat"].Value = DateTime.Now;
                    XtraReport1.Parameters["ReportName"].Value = "مشخصات اعضاء صندوق";
                    XtraReport1.Parameters["SandoghName"].Value = Fm.ribbonControl1.ApplicationDocumentCaption;
                    XtraReport1.Parameters["Logo_Co"].Value = Fm.pictureEdit1.Image;

                    FrmPrinPreview FPP = new FrmPrinPreview();
                    FPP.documentViewer1.DocumentSource = XtraReport1;
                    FPP.RepotPageWidth = 100;
                    FPP.ShowDialog();
                    //XtraReport1.Report..DataSource = new MyContext().TarifSandoghs.FirstOrDefault();
                    //FPP.ShowDialog();

                    // XtraReport1.DataSource = HelpClass1.ConvettDatagridviewToDataSet(gridView1);

                    //XtraReport1.Parameters["Az_Tarikh"].Value = ChkTarikh.Checked ? txtAzTarikh.Text : gridView2.GetRowCellDisplayText(0, "Tarikh").Substring(0, 10);
                    //XtraReport1.Parameters["Ta_Tarikh"].Value = ChkTarikh.Checked ? txtTaTarikh.Text : DateTime.Now.ToString().Substring(0, 10);
                    //XtraReport1.Parameters["HesabMoin"].Value = _HesabMoin;
                    //XtraReport1.Parameters["HesabTafzil"].Value = cmbHesabTafzili.Text;
                    //XtraReport1.Parameters["Logo"].Value = Fm.pictureEdit1;
                    ///////////////////////////////////
                    //XtraReport1.CalculatedFields[0].Assign(new MyContext().TarifSandoghs.FirstOrDefault(), "Pictuer");
                    //XtraReport1.CalculatedFields[0].;
                    //using (var db = new MyContext())
                    //{
                    //    try
                    //    {
                    //        var q1 = db.TarifSandoghs.FirstOrDefault(s => s.Id == 1);
                    //        if (q1 != null)
                    //        {
                    //            if (q1.Pictuer != null)
                    //            {
                    //                MemoryStream ms = new MemoryStream(q1.Pictuer);
                    //                img = Image.FromStream(ms);

                    //            }
                    //            else
                    //                img = null;

                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                    //            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //}
                    //// HelpClass1.LoadReportDesigner(FilePath1, FileName1 , img);

                    ////XtraReport XtraReport1 = new XtraReport();
                    ////XtraReport1.LoadLayoutFromXml(FilePath1 + FileName1);
                    //Parameter param1 = new Parameter();
                    //param1.Name = "Logo";
                    //param1.Type = typeof(System.Byte);
                    //param1.Value = img;

                    //XtraReport1.Parameters.Add(param1);

                    //////////////////////////////////
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

        public void btnDisplyActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = true;
            FillDataGridTarifAaza();
        }

        public void btnDisplyNotActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = false;
            FillDataGridTarifAaza();
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

            //GridView view = (GridView)sender;
            //if (view == null) return;
            //int rowHandle = view.GetRowHandle(e.ListSourceRowIndex);
            ////int visibleIndex = view.GetVisibleIndex(rowHandle);
            ////if (e.IsSetData) return;
            //if (e.Column.FieldName == "Pictuer")
            //    e.Value = Fm.pictureEdit1.Image;

        }

        private void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            gridView1.OptionsFind.AlwaysVisible = gridView1.OptionsFind.AlwaysVisible ? false : true;
        }

        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            //gridView1.Columns["SharhHesab"].Visible = gridView1.Columns["SharhHesab"].Visible == false ? true : false;
            btnSave_Click(null, null);
            if (En == EnumCED.Save)
                btnCreate_Click(null, null);
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
            txtId.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtCodePersoneli.Text = string.Empty;
            txtTarikhOzviat.Text = string.Empty;
            txtTarikhTasviyeVam.Text = string.Empty;
            txtNameVFamil.Text = string.Empty;
            txtNamePedar.Text = string.Empty;
            txtCodeMeli.Text = string.Empty;
            txtShShenasname.Text = string.Empty;
            txtTedadeFarzand.Text = string.Empty;
            txtBirthDate.Text = string.Empty;
            cmbJensiat.SelectedIndex = -1;
            cmbTaahol.SelectedIndex = -1;
            txtNameBank.Text = string.Empty;
            txtShomareHesab.Text = string.Empty;
            txtShomareKart.Text = string.Empty;
            txtShomareShaba.Text = string.Empty;
            txtAdress.Text = string.Empty;
            txtMohaleKar.Text = string.Empty;
            txtMobile1.Text = string.Empty;
            txtMobile2.Text = string.Empty;
            txtTell.Text = string.Empty;
            txtShoghl.Text = string.Empty;
            cmbMoaref.EditValue = 0;
            txtSaghfeEtebar.Text = string.Empty;
            txtEtebarBlookeShode.Text = string.Empty;
            txtMandeEtebar.Text = string.Empty;
            txtMablaghPasandaz.Text = string.Empty;
            txtBesAvali.Text = string.Empty;
            //txtBedAvali.Text = string.Empty;
            //txtHazineEftetah.Text = string.Empty;
            txtSharhHesab.Text = string.Empty;
            txtNobatbandiVam.Text = string.Empty;
            txtDarsadPasandaz.Text = string.Empty;
            txtDaramadeMahiane.Text = string.Empty;
            pictureEdit1.Image = null;
        }

        public void ActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                txtCodePersoneli.ReadOnly = false;
                txtTarikhOzviat.ReadOnly = false;
                txtTarikhTasviyeVam.ReadOnly = false;
                txtNameVFamil.ReadOnly = false;
                txtNamePedar.ReadOnly = false;
                txtCodeMeli.ReadOnly = false;
                txtShShenasname.ReadOnly = false;
                txtBirthDate.ReadOnly = false;
                cmbJensiat.ReadOnly = false;
                cmbTaahol.ReadOnly = false;
                txtTedadeFarzand.ReadOnly = false;
                txtNameBank.ReadOnly = false;
                txtShomareHesab.ReadOnly = false;
                txtShomareKart.ReadOnly = false;
                txtShomareShaba.ReadOnly = false;
                txtAdress.ReadOnly = false;
                txtMohaleKar.ReadOnly = false;
                txtMobile1.ReadOnly = false;
                txtMobile2.ReadOnly = false;
                txtTell.ReadOnly = false;
                txtShoghl.ReadOnly = false;
                cmbMoaref.ReadOnly = false;
                txtSaghfeEtebar.ReadOnly = false;
                txtEtebarBlookeShode.ReadOnly = false;
                txtMandeEtebar.ReadOnly = false;
                txtMablaghPasandaz.ReadOnly = false;
                txtBesAvali.ReadOnly = false;
                //txtBedAvali.ReadOnly = false;
                //txtHazineEftetah.ReadOnly = false;
                txtDaramadeMahiane.ReadOnly = false;
                txtSharhHesab.ReadOnly = false;
                txtNobatbandiVam.ReadOnly = false;
                chkIsActive.ReadOnly = false;
                chkIsOzveSandogh.ReadOnly = false;
                pictureEdit1.ReadOnly = false;
                btnBrowsPictuer.Enabled = true;
                btnDeletePictuer.Enabled = true;
                btnNobatVam.Enabled = true;
                btnMohasebeTarikhMabnayeNobatVam.Enabled = true;
                txtDarsadPasandaz.ReadOnly = false;

            }
        }

        public void InActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                txtCodePersoneli.ReadOnly = true;
                txtTarikhOzviat.ReadOnly = true;
                txtTarikhTasviyeVam.ReadOnly = true;
                txtNameVFamil.ReadOnly = true;
                txtNamePedar.ReadOnly = true;
                txtCodeMeli.ReadOnly = true;
                txtShShenasname.ReadOnly = true;
                txtBirthDate.ReadOnly = true;
                cmbJensiat.ReadOnly = true;
                cmbTaahol.ReadOnly = true;
                txtNameBank.ReadOnly = true;
                txtTedadeFarzand.ReadOnly = true;
                txtShomareHesab.ReadOnly = true;
                txtShomareKart.ReadOnly = true;
                txtShomareShaba.ReadOnly = true;
                txtAdress.ReadOnly = true;
                txtMohaleKar.ReadOnly = true;
                txtMobile1.ReadOnly = true;
                txtMobile2.ReadOnly = true;
                txtTell.ReadOnly = true;
                txtShoghl.ReadOnly = true;
                cmbMoaref.ReadOnly = true;
                txtMablaghPasandaz.ReadOnly = true;
                txtBesAvali.ReadOnly = true;
                //txtBedAvali.ReadOnly = true;
                //txtHazineEftetah.ReadOnly = true;
                txtDaramadeMahiane.ReadOnly = true;
                txtSharhHesab.ReadOnly = true;
                txtNobatbandiVam.ReadOnly = true;
                chkIsActive.ReadOnly = true;
                chkIsOzveSandogh.ReadOnly = true;
                pictureEdit1.ReadOnly = true;
                btnBrowsPictuer.Enabled = false;
                btnDeletePictuer.Enabled = false;
                btnNobatVam.Enabled = false;
                btnMohasebeTarikhMabnayeNobatVam.Enabled = false;
                txtSaghfeEtebar.ReadOnly = true;
                txtEtebarBlookeShode.ReadOnly = true;
                txtMandeEtebar.ReadOnly = true;
                txtDarsadPasandaz.ReadOnly = true;

            }
        }

        int _SandoghId = 0;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            _SandoghId = Convert.ToInt32(Fm.IDSandogh.Caption);
            En = EnumCED.Create;
            gridControl1.Enabled = false;
            InActiveButtons();
            ClearControls();
            ActiveControls();
            FillcmbMoaref();
            cmbMoaref.EditValue = 0;
            NewCode(null, null);
            txtTarikhOzviat.Text = DateTime.Now.ToString().Substring(0, 10);
            cmbJensiat.SelectedIndex = 0;
            cmbTaahol.SelectedIndex = 0;
            HelpClass1.DateTimeMask(txtBirthDate);
            HelpClass1.DateTimeMask(txtTarikhOzviat);
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SandoghId);
                    if (q != null)
                    {

                        if (q.radioGroup3 == 0)
                        {
                            //txtMinMablaghPasandaz.Enabled = txtMaxMablaghPasandaz.Enabled = true;
                            txtMablaghPasandaz.Text = q.MinMablaghPasandaz.ToString();
                        }
                        else
                        {
                            //txtMinDarsadPasandaz.Enabled = txtMaxDarsadPasandaz.Enabled = true;
                            txtDarsadPasandaz.Text = q.MinDarsadPasandaz.ToString();
                        }

                        if (q.checkEdit6)
                        {
                            if (q.NoeRezervIndex == 1)
                            {
                                btnNobatVam_Click(null, null);
                            }
                            else if (q.NoeRezervIndex == 2)
                            {
                                txtTarikhOzviat.Text = DateTime.Now.ToString().Substring(0, 10);
                                btnMohasebeTarikhMabnayeNobatVam_Click(null, null);
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



            txtNameVFamil.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (XtraMessageBox.Show("آیا عضو مورد نظر حذف شود؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    IsActiveBeforeEdit = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                    EditRowIndex = gridView1.FocusedRowHandle;
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                            var qq = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 3 && f.Id2 == RowId);
                            if (qq != null)
                            {
                                db.AllHesabTafzilis.Remove(qq);
                                var q = db.AazaSandoghs.FirstOrDefault(p => p.Id == RowId);
                                if (q != null)
                                    db.AazaSandoghs.Remove(q);
                                var qq1 = db.AsnadeHesabdariRows.Where(s => s.ShomareSanad == q.ShomareSanad);
                                if (qq1 != null)
                                    db.AsnadeHesabdariRows.RemoveRange(qq1);
                                /////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();

                                if (IsActiveBeforeEdit)
                                    btnDisplyActiveList_Click(null, null);
                                else
                                    btnDisplyNotActiveList_Click(null, null);
                                // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex - 1;
                            }
                            else
                                XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (DbUpdateException)
                        {
                            XtraMessageBox.Show("به دلیل اینکه از حساب فوق جهت صدور سند و یا عملیات مربوط \n به اسناد تضمینی استفاده شده است لذا قابل حذف نیست",
                                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }

        public int EditRowIndex = 0;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && btnEdit.Visible == true)
            {
                gridControl1.Enabled = false;
                EditRowIndex = gridView1.FocusedRowHandle;
                En = EnumCED.Edit;
                InActiveButtons();
                HelpClass1.DateTimeMask(txtBirthDate);
                HelpClass1.DateTimeMask(txtTarikhOzviat);
                FillcmbMoaref();
                txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString();
                txtCodePersoneli.Text = gridView1.GetFocusedRowCellValue("CodePersoneli").ToString();
                if (gridView1.GetFocusedRowCellDisplayText("TarikhOzviat").ToString() != null)
                    txtTarikhOzviat.Text = gridView1.GetFocusedRowCellValue("TarikhOzviat").ToString().Substring(0, 10);
                if (gridView1.GetFocusedRowCellDisplayText("TarikhTasviyeVam").ToString() != null)
                    txtTarikhTasviyeVam.Text = gridView1.GetFocusedRowCellValue("TarikhTasviyeVam").ToString().Substring(0, 10);
                txtNameVFamil.Text = gridView1.GetFocusedRowCellDisplayText("NameVFamil");
                txtNamePedar.Text = gridView1.GetFocusedRowCellDisplayText("NamePedar");
                txtCodeMeli.Text = gridView1.GetFocusedRowCellDisplayText("CodeMelli");
                txtShShenasname.Text = gridView1.GetFocusedRowCellDisplayText("ShShenasname");
                if (gridView1.GetFocusedRowCellValue("BirthDate") != null)
                    txtBirthDate.Text = gridView1.GetFocusedRowCellDisplayText("BirthDate").Substring(0, 10);
                else
                    txtBirthDate.Text = string.Empty;
                cmbJensiat.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexJensiat"));
                cmbTaahol.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexTaahol"));
                if (gridView1.GetFocusedRowCellValue("TedadeFarzand") != null)
                    txtTedadeFarzand.Text = gridView1.GetFocusedRowCellDisplayText("TedadeFarzand");
                else
                    txtTedadeFarzand.Text = string.Empty;
                txtNameBank.Text = gridView1.GetFocusedRowCellDisplayText("NameBank");
                txtShomareHesab.Text = gridView1.GetFocusedRowCellDisplayText("ShomareHesab");
                txtShomareKart.Text = gridView1.GetFocusedRowCellDisplayText("ShomareKart");
                txtShomareShaba.Text = gridView1.GetFocusedRowCellDisplayText("ShomareShaba");
                txtAdress.Text = gridView1.GetFocusedRowCellDisplayText("AdressManzel");
                txtMohaleKar.Text = gridView1.GetFocusedRowCellDisplayText("AdressMohalKar");
                txtMobile1.Text = gridView1.GetFocusedRowCellDisplayText("Mobile1");
                txtMobile2.Text = gridView1.GetFocusedRowCellDisplayText("Mobile2");
                txtTell.Text = gridView1.GetFocusedRowCellDisplayText("Tell");
                txtShoghl.Text = gridView1.GetFocusedRowCellDisplayText("Shoghl");
                if (gridView1.GetFocusedRowCellValue("MoarefId") != null)
                    cmbMoaref.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MoarefId"));
                else
                    cmbMoaref.EditValue = 0;
                txtBesAvali.Text = gridView1.GetFocusedRowCellDisplayText("BesAvali");
                txtSaghfeEtebar.Text = gridView1.GetFocusedRowCellDisplayText("SaghfeEtebar");
                txtEtebarBlookeShode.Text = gridView1.GetFocusedRowCellDisplayText("EtebarBlookeShode");
                txtMandeEtebar.Text = (Convert.ToDecimal(txtSaghfeEtebar.Text.Replace(",", "")) - Convert.ToDecimal(txtEtebarBlookeShode.Text.Replace(",", ""))).ToString();
                txtMablaghPasandaz.Text = gridView1.GetFocusedRowCellDisplayText("HaghOzviat") ?? "0";
                //txtHazineEftetah.Text = gridView1.GetFocusedRowCellDisplayText("HazineEftetah");
                txtDaramadeMahiane.Text = gridView1.GetFocusedRowCellDisplayText("DaramadeMahiane");
                txtSharhHesab.Text = gridView1.GetFocusedRowCellDisplayText("SharhHesab");
                txtNobatbandiVam.Text = gridView1.GetFocusedRowCellDisplayText("NobatbandiVam") ?? "0";
                txtDarsadPasandaz.Text = gridView1.GetFocusedRowCellDisplayText("DarsadPasandaz") ?? "0";
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                chkIsOzveSandogh.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsOzveSandogh"));

                using (var db = new MyContext())
                {
                    try
                    {
                        int RowId = Convert.ToInt32(txtId.Text);
                        var q1 = db.AazaSandoghs.FirstOrDefault(s => s.Id == RowId);
                        if (q1.Pictuer != null)
                        {
                            MemoryStream ms = new MemoryStream(q1.Pictuer);
                            pictureEdit1.Image = Image.FromStream(ms);
                            img = pictureEdit1.Image;
                        }
                        else
                            pictureEdit1.Image = null;
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                CodeBeforeEdit = txtCode.Text;
                NameBeforeEdit = txtNameVFamil.Text;
                IsActiveBeforeEdit = chkIsActive.Checked;
                ActiveControls();
                xtraTabControl1.SelectedTabPageIndex = 0;
                txtNameVFamil.Focus();
            }
        }

        // int _cmbNoeVamIndex = 0;
        //public void FrmTaeinNobatBandiVam()
        //{
        //    using (var db = new MyContext())
        //    {
        //        try
        //        {
        //            var t = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SandoghId);
        //            if (t.checkEdit6)
        //            {
        //                FrmTaeinNobatBandiVam fm = new FrmTaeinNobatBandiVam(this);
        //                fm._AllHesabTafziliId = _AllTafId;
        //                string _lblNahveyeNobatbandi = string.Empty;
        //                if (t.NoeRezervIndex == -1)
        //                {
        //                    _lblNahveyeNobatbandi = string.Empty;
        //                }
        //                else if (t.NoeRezervIndex == 0)
        //                {
        //                    _lblNahveyeNobatbandi = "نوبت بندی بر اساس تاریخ عضویت اعضاء در صندوق";
        //                }
        //                else if (t.NoeRezervIndex == 1)
        //                {
        //                    _lblNahveyeNobatbandi = "نوبت بندی بر اساس شماره قرعه کشی اعضاء در صندوق";
        //                }
        //                else if (t.NoeRezervIndex == 2)
        //                {
        //                    _lblNahveyeNobatbandi = "نویت بندی بر اساس تاریخ عضویت اعضاء جدید \nبا حداقل مدت انتظار یا تاریخ تسویه وام قبلی اعضاء";
        //                }
        //                fm.lblNahveyeNobatbandi.Text = _lblNahveyeNobatbandi;
        //                fm.cmbNoeVam.SelectedIndex = t.AnvaeVams.FirstOrDefault(s => s.DefaultNoeVam == true) != null ? t.AnvaeVams.FirstOrDefault(s => s.DefaultNoeVam == true).NoeVamIndex : -1;
        //                fm._TarikhOzviat = txtTarikhOzviat.Text;
        //                fm._SalMaliId =Convert.ToInt32( Fm.IDSalMali.ToString());
        //                fm.ShowDialog();
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
        //                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

        //}

        Image img;
        int _AllTafId = 0;
        //int _ShomareNobat = 0;
        //ateTime _TarikhTasviyeVam = DateTime.Now;
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
                            AazaSandogh obj = new AazaSandogh();
                            obj.Code = Convert.ToInt32(txtCode.Text);
                            obj.CodePersoneli = txtCodePersoneli.Text;
                            //if ()
                            obj.TarikhOzviat = !string.IsNullOrEmpty(txtTarikhOzviat.Text) ? Convert.ToDateTime(txtTarikhOzviat.Text) : DateTime.Now;

                            obj.TarikhTasviyeVam = !string.IsNullOrEmpty(txtTarikhTasviyeVam.Text) ? Convert.ToDateTime(txtTarikhTasviyeVam.Text) :
                                !string.IsNullOrEmpty(txtTarikhOzviat.Text) ? Convert.ToDateTime(txtTarikhOzviat.Text) : DateTime.Now;
                            obj.NameVFamil = txtNameVFamil.Text;
                            obj.NamePedar = txtNamePedar.Text;
                            obj.CodeMelli = txtCodeMeli.Text;
                            obj.ShShenasname = txtShShenasname.Text;
                            if (!string.IsNullOrEmpty(txtBirthDate.Text))
                                obj.BirthDate = Convert.ToDateTime(txtBirthDate.Text);
                            if (cmbJensiat.SelectedIndex != -1)
                            {
                                obj.Jensiat = cmbJensiat.Text;
                                obj.IndexJensiat = cmbJensiat.SelectedIndex;

                            }
                            if (cmbTaahol.SelectedIndex != -1)
                            {
                                obj.Taahol = cmbTaahol.Text;
                                obj.IndexTaahol = cmbTaahol.SelectedIndex;
                            }

                            obj.TedadeFarzand = !string.IsNullOrEmpty(txtTedadeFarzand.Text.Replace(",", "")) ? Convert.ToInt32(txtTedadeFarzand.Text.Replace(",", "")) : 0;
                            obj.NameBank = txtNameBank.Text;
                            obj.ShomareHesab = txtShomareHesab.Text;
                            obj.ShomareKart = txtShomareKart.Text;
                            obj.ShomareShaba = txtShomareShaba.Text;
                            obj.AdressManzel = txtAdress.Text;
                            obj.AdressMohalKar = txtMohaleKar.Text;
                            obj.Mobile1 = txtMobile1.Text;
                            obj.Mobile2 = txtMobile2.Text;
                            obj.Tell = txtTell.Text;
                            obj.Shoghl = txtShoghl.Text;
                            if (Convert.ToInt32(cmbMoaref.EditValue) != 0)
                            {
                                obj.Moaref = cmbMoaref.Text;
                                obj.MoarefId = Convert.ToInt32(cmbMoaref.EditValue);
                            }
                            //obj.HazineEftetah = !string.IsNullOrEmpty(txtHazineEftetah.Text.Replace(",", "")) ? Convert.ToDecimal(txtHazineEftetah.Text.Replace(",", "")) : 0;
                            obj.BesAvali = !string.IsNullOrEmpty(txtBesAvali.Text.Replace(",", "")) ? Convert.ToDecimal(txtBesAvali.Text.Replace(",", "")) : 0;
                            //obj.BedAvali = !string.IsNullOrEmpty(txtBedAvali.Text) ? Convert.ToDecimal(txtBedAvali.Text) : 0;
                            obj.HaghOzviat = !string.IsNullOrEmpty(txtMablaghPasandaz.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghPasandaz.Text.Replace(",", "")) : 0;
                            //obj.MaxHaghOzviat = !string.IsNullOrEmpty(txtMaxMablaghPasandaz.Text.Replace(",", "")) ? Convert.ToDecimal(txtMaxMablaghPasandaz.Text.Replace(",", "")) : 0;
                            obj.SaghfeEtebar = !string.IsNullOrEmpty(txtSaghfeEtebar.Text.Replace(",", "")) ? Convert.ToDecimal(txtSaghfeEtebar.Text.Replace(",", "")) : 0;
                            obj.EtebarBlookeShode = !string.IsNullOrEmpty(txtEtebarBlookeShode.Text.Replace(",", "")) ? Convert.ToDecimal(txtEtebarBlookeShode.Text.Replace(",", "")) : 0;
                            obj.DaramadeMahiane = !string.IsNullOrEmpty(txtDaramadeMahiane.Text.Replace(",", "")) ? Convert.ToDecimal(txtDaramadeMahiane.Text.Replace(",", "")) : 0;
                            obj.IsActive = chkIsActive.Checked;
                            obj.SharhHesab = txtSharhHesab.Text;
                            obj.TarifSandoghId = Convert.ToInt32(Fm.IDSandogh.Caption);
                            //obj.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                            obj.DarsadPasandaz = !string.IsNullOrEmpty(txtDarsadPasandaz.Text.Replace(",", "")) ? Convert.ToDouble(txtDarsadPasandaz.Text) : 0;
                            //obj.MaxDarsadPasandaz = !string.IsNullOrEmpty(txtMaxDarsadPasandaz.Text.Replace(",", "")) ? Convert.ToDouble(txtMaxDarsadPasandaz.Text) : 0;

                            if (pictureEdit1.Image != null)
                            {
                                MemoryStream ms = new MemoryStream();
                                img.Save(ms, pictureEdit1.Image.RawFormat);
                                byte[] myarrey = ms.GetBuffer();
                                obj.Pictuer = myarrey;
                            }
                            else
                                obj.Pictuer = null;
                            obj.IsOzveSandogh = chkIsOzveSandogh.Checked;
                            obj.GroupTafziliId = 3;
                            obj.ShomareSanad = 0;
                            obj.NobatbandiVam = Convert.ToInt32(txtNobatbandiVam.Text);
                            db.AazaSandoghs.Add(obj);
                            db.SaveChanges();
                            //////////////////////////////////////////
                            int _Code = Convert.ToInt32(txtCode.Text);
                            AllHesabTafzili obj1 = new AllHesabTafzili();
                            obj1.Id2 = db.AazaSandoghs.FirstOrDefault(f => f.Code == _Code).Id;
                            obj1.Code = _Code;
                            obj1.Name = txtNameVFamil.Text;
                            obj1.GroupTafziliId = 3;
                            obj1.IsActive = chkIsActive.Checked;
                            obj1.SandoghId = Convert.ToInt32(Fm.IDSandogh.Caption);
                            db.AllHesabTafzilis.Add(obj1);
                            db.SaveChanges();
                            ////////////////////////////////////////////////////////////////////////////////////
                            var qr1 = db.AllHesabTafzilis.FirstOrDefault(f => f.Code == _Code);
                            if (qr1 != null)
                            {
                                var qr2 = db.AazaSandoghs.FirstOrDefault(f => f.Code == _Code);
                                _AllTafId = qr1.Id;
                                qr2.AllTafId = _AllTafId;
                                db.SaveChanges();
                            }
                            /////////////////////////////////////////////////////////////////////////////////////
                            //int _ShomareSanad = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ShomareSanad"));
                            //if (_ShomareSanad != 0)
                            //{
                            //    var q = db.AsnadeHesabdariRows.Where(f => f.ShomareSanad == _ShomareSanad);
                            //    if (q.Count() > 0)
                            //    {
                            //        db.AsnadeHesabdariRows.RemoveRange(q);
                            //        db.SaveChanges();
                            //    }
                            //}

                            //var q1 = db.AsnadeHesabdariRows.Any() ? db.AsnadeHesabdariRows.Max(f => f.ShomareSanad) : 0;
                            //if (txtBesAvali.Text != "0")
                            //{
                            //    //int _HesabTafId1 = Convert.ToInt32(cmbNameHesab.EditValue);
                            //    var qq1 = db.CodeMoins.FirstOrDefault(f => f.Code == 1001);
                            //    var qq2 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2 && f.IsActive == true);
                            //    AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
                            //    obj2.ShomareSanad = q1 + 1;
                            //    obj2.Tarikh = Convert.ToDateTime(txtTarikhOzviat.Text.Substring(0, 10));
                            //    obj2.HesabMoinId = qq1.Id;
                            //    obj2.HesabMoinCode = 1001;
                            //    obj2.HesabMoinName = qq1.Name;
                            //    obj2.HesabTafId = qq2.Id;
                            //    obj2.HesabTafCode = qq2.Code;
                            //    obj2.HesabTafName = qq2.Name;
                            //    obj2.Bed = Convert.ToDecimal(txtBesAvali.Text.Replace(",", ""));
                            //    obj2.Sharh = "مانده از قبل " + txtNameVFamil.Text;
                            //    obj2.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                            //    db.AsnadeHesabdariRows.Add(obj2);


                            //    int _HesabTafCode2 = Convert.ToInt32(txtCode.Text);
                            //    var qq3 = db.CodeMoins.FirstOrDefault(f => f.Code == 7001);
                            //    var qq4 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 3 && f.Code == _HesabTafCode2);
                            //    AsnadeHesabdariRow obj3 = new AsnadeHesabdariRow();
                            //    obj3.ShomareSanad = q1 + 1;
                            //    obj3.Tarikh = Convert.ToDateTime(txtTarikhOzviat.Text.Substring(0, 10));
                            //    obj3.HesabMoinId = qq3.Id;
                            //    obj3.HesabMoinCode = 7001;
                            //    obj3.HesabMoinName = qq3.Name;
                            //    obj3.HesabTafId = qq4.Id;
                            //    obj3.HesabTafCode = _HesabTafCode2;
                            //    obj3.HesabTafName = txtNameVFamil.Text;
                            //    obj3.Bes = Convert.ToDecimal(txtBesAvali.Text.Replace(",", ""));
                            //    obj3.Sharh = "بستانکاری از قبل";
                            //    obj3.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                            //    db.AsnadeHesabdariRows.Add(obj3);

                            //    var s1 = db.AazaSandoghs.FirstOrDefault(f => f.Code == _Code);
                            //    s1.ShomareSanad = q1 + 1;
                            //    /////////////////////////////////////////////////////////////////////////////////

                            //}
                            //if (txtHazineEftetah.Text != "0")
                            //{
                            //    int _HesabTafCode2 = Convert.ToInt32(txtCode.Text);
                            //    var qq3 = db.CodeMoins.FirstOrDefault(f => f.Code == 7001);
                            //    var qq4 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 3 && f.Code == _HesabTafCode2);
                            //    AsnadeHesabdariRow obj3 = new AsnadeHesabdariRow();
                            //    obj3.ShomareSanad = q1 + 1;
                            //    obj3.Tarikh = Convert.ToDateTime(txtTarikhOzviat.Text.Substring(0, 10));
                            //    obj3.HesabMoinId = qq3.Id;
                            //    obj3.HesabMoinCode = 7001;
                            //    obj3.HesabMoinName = qq3.Name;
                            //    obj3.HesabTafId = qq4.Id;
                            //    obj3.HesabTafCode = _HesabTafCode2;
                            //    obj3.HesabTafName = txtNameVFamil.Text;
                            //    obj3.Bed = Convert.ToDecimal(txtHazineEftetah.Text.Replace(",", ""));
                            //    obj3.Sharh = "بابت هزینه افتتاح حساب";
                            //    obj3.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                            //    db.AsnadeHesabdariRows.Add(obj3);


                            //    //int _HesabTafId1 = Convert.ToInt32(cmbNameHesab.EditValue);
                            //    var qq1 = db.CodeMoins.FirstOrDefault(f => f.Code == 8001);
                            //    var qq2 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 4 && f.Code == 1000002);
                            //    AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
                            //    obj2.ShomareSanad = q1 + 1;
                            //    obj2.Tarikh = Convert.ToDateTime(txtTarikhOzviat.Text.Substring(0, 10));
                            //    obj2.HesabMoinId = qq1.Id;
                            //    obj2.HesabMoinCode = 8001;
                            //    obj2.HesabMoinName = qq1.Name;
                            //    obj2.HesabTafId = qq2.Id;
                            //    obj2.HesabTafCode = 1000002;
                            //    obj2.HesabTafName = qq2.Name;
                            //    obj2.Bes = Convert.ToDecimal(txtHazineEftetah.Text.Replace(",", ""));
                            //    obj2.Sharh = "بابت افتتاح حساب " + txtNameVFamil.Text;
                            //    obj2.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                            //    db.AsnadeHesabdariRows.Add(obj2);

                            //    var s1 = db.AazaSandoghs.FirstOrDefault(f => f.Code == _Code);
                            //    s1.ShomareSanad = q1 + 1;
                            //}
                            //db.SaveChanges();

                            ///////////////////////////////////////////////////////////////////////////////////////
                            if (chkIsActive.Checked)
                                btnDisplyActiveList_Click(null, null);
                            else
                                btnDisplyNotActiveList_Click(null, null);

                            gridControl1.Enabled = true;
                            gridView1.MoveLast();
                            ActiveButtons();
                            ClearControls();
                            InActiveControls();
                            En = EnumCED.Save;
                            //var t = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SandoghId).AnvaeVams.FirstOrDefault(s => s.DefaultNoeVam == true);
                            //_cmbNoeVamIndex = t != null ? t.NoeVamIndex : -1;

                            //FrmTaeinNobatBandiVam();
                            //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
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
                            int _Code = Convert.ToInt32(txtCode.Text);
                            string _Name = txtNameVFamil.Text;
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.AazaSandoghs.FirstOrDefault(p => p.Id == RowId);

                            if (q != null)
                            {
                                //_AllTafId = q.AllTafId;
                                q.Code = Convert.ToInt32(txtCode.Text);
                                q.CodePersoneli = txtCodePersoneli.Text;
                                //if (!string.IsNullOrEmpty(txtTarikhOzviat.Text))
                                //    q.TarikhOzviat = Convert.ToDateTime(txtTarikhOzviat.Text);
                                q.TarikhOzviat = !string.IsNullOrEmpty(txtTarikhOzviat.Text) ? Convert.ToDateTime(txtTarikhOzviat.Text) : DateTime.Now;
                                q.TarikhTasviyeVam = !string.IsNullOrEmpty(txtTarikhTasviyeVam.Text) ? Convert.ToDateTime(txtTarikhTasviyeVam.Text) :
                                    !string.IsNullOrEmpty(txtTarikhOzviat.Text) ? Convert.ToDateTime(txtTarikhOzviat.Text) : DateTime.Now;

                                q.NameVFamil = txtNameVFamil.Text;
                                q.NamePedar = txtNamePedar.Text;
                                q.CodeMelli = txtCodeMeli.Text;
                                q.ShShenasname = txtShShenasname.Text;
                                if (!string.IsNullOrEmpty(txtBirthDate.Text))
                                    q.BirthDate = Convert.ToDateTime(txtBirthDate.Text);
                                if (cmbJensiat.SelectedIndex != -1)
                                {
                                    q.Jensiat = cmbJensiat.Text;
                                    q.IndexJensiat = cmbJensiat.SelectedIndex;

                                }
                                if (cmbTaahol.SelectedIndex != -1)
                                {
                                    q.Taahol = cmbTaahol.Text;
                                    q.IndexTaahol = cmbTaahol.SelectedIndex;

                                }
                                q.TedadeFarzand = !string.IsNullOrEmpty(txtTedadeFarzand.Text.Replace(",", "")) ? Convert.ToInt32(txtTedadeFarzand.Text.Replace(",", "")) : 0;
                                q.NameBank = txtNameBank.Text;
                                q.ShomareHesab = txtShomareHesab.Text;
                                q.ShomareKart = txtShomareKart.Text;
                                q.ShomareShaba = txtShomareShaba.Text;
                                q.AdressManzel = txtAdress.Text;
                                q.AdressMohalKar = txtMohaleKar.Text;
                                q.Mobile1 = txtMobile1.Text;
                                q.Mobile2 = txtMobile2.Text;
                                q.Tell = txtTell.Text;
                                q.Shoghl = txtShoghl.Text;
                                if (Convert.ToInt32(cmbMoaref.EditValue) != 0)
                                {
                                    q.Moaref = cmbMoaref.Text;
                                    q.MoarefId = Convert.ToInt32(cmbMoaref.EditValue);

                                }
                                //q.HazineEftetah = !string.IsNullOrEmpty(txtHazineEftetah.Text.Replace(",", "")) ? Convert.ToDecimal(txtHazineEftetah.Text.Replace(",", "")) : 0;
                                q.BesAvali = !string.IsNullOrEmpty(txtBesAvali.Text.Replace(",", "")) ? Convert.ToDecimal(txtBesAvali.Text.Replace(",", "")) : 0;
                                //q.BedAvali = !string.IsNullOrEmpty(txtBedAvali.Text) ? Convert.ToDecimal(txtBedAvali.Text) : 0;
                                q.HaghOzviat = !string.IsNullOrEmpty(txtMablaghPasandaz.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghPasandaz.Text.Replace(",", "")) : 0;
                                //q.MaxHaghOzviat = !string.IsNullOrEmpty(txtMaxMablaghPasandaz.Text.Replace(",", "")) ? Convert.ToDecimal(txtMaxMablaghPasandaz.Text.Replace(",", "")) : 0;
                                q.SaghfeEtebar = !string.IsNullOrEmpty(txtSaghfeEtebar.Text.Replace(",", "")) ? Convert.ToDecimal(txtSaghfeEtebar.Text.Replace(",", "")) : 0;
                                q.EtebarBlookeShode = !string.IsNullOrEmpty(txtEtebarBlookeShode.Text.Replace(",", "")) ? Convert.ToDecimal(txtEtebarBlookeShode.Text.Replace(",", "")) : 0;
                                q.DaramadeMahiane = !string.IsNullOrEmpty(txtDaramadeMahiane.Text.Replace(",", "")) ? Convert.ToDecimal(txtDaramadeMahiane.Text.Replace(",", "")) : 0;
                                q.SharhHesab = txtSharhHesab.Text;
                                q.DarsadPasandaz = !string.IsNullOrEmpty(txtDarsadPasandaz.Text.Replace(",", "")) ? Convert.ToDouble(txtDarsadPasandaz.Text) : 0;
                                //q.MaxDarsadPasandaz = !string.IsNullOrEmpty(txtMaxDarsadPasandaz.Text.Replace(",", "")) ? Convert.ToDouble(txtMaxDarsadPasandaz.Text) : 0;

                                if (pictureEdit1.Image != null)
                                {
                                    MemoryStream ms = new MemoryStream();
                                    img.Save(ms, pictureEdit1.Image.RawFormat);
                                    byte[] myarrey = ms.GetBuffer();
                                    q.Pictuer = myarrey;
                                }
                                else
                                    q.Pictuer = null;
                                q.IsOzveSandogh = chkIsOzveSandogh.Checked;
                                q.IsActive = chkIsActive.Checked;
                                q.GroupTafziliId = 3;
                                q.NobatbandiVam = Convert.ToInt32(txtNobatbandiVam.Text);
                                //////////////////////////////////////////
                                //int _Code = Convert.ToInt32(txtCode.Text);
                                var qq01 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 3 && f.Id2 == RowId);
                                if (qq01 != null)
                                {
                                    qq01.Code = _Code;
                                    qq01.Name = txtNameVFamil.Text;
                                    qq01.GroupTafziliId = 3;
                                    qq01.IsActive = chkIsActive.Checked;
                                }
                                db.SaveChanges();
                                /////////////////////////////////////////////////////////////////////////////////////
                                int _ShomareSanad = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ShomareSanad"));
                                if (_ShomareSanad != 0)
                                {
                                    var q2 = db.AsnadeHesabdariRows.Where(f => f.ShomareSanad == _ShomareSanad);
                                    if (q2.Count() > 0)
                                    {
                                        db.AsnadeHesabdariRows.RemoveRange(q2);
                                        db.SaveChanges();
                                    }
                                }

                                //var q1 = db.AsnadeHesabdariRows.Any() ? db.AsnadeHesabdariRows.Max(f => f.ShomareSanad) : 0;
                                //if (txtBesAvali.Text != "0")
                                //{
                                //    //int _HesabTafId1 = Convert.ToInt32(cmbNameHesab.EditValue);
                                //    var qq1 = db.CodeMoins.FirstOrDefault(f => f.Code == 1001);
                                //    var qq2 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2 && f.IsActive == true);
                                //    AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
                                //    obj2.ShomareSanad = _ShomareSanad == 0 ? q1 + 1 : q.ShomareSanad;
                                //    obj2.Tarikh = Convert.ToDateTime(txtTarikhOzviat.Text.Substring(0, 10));
                                //    obj2.HesabMoinId = qq1.Id;
                                //    obj2.HesabMoinCode = 1001;
                                //    obj2.HesabMoinName = qq1.Name;
                                //    obj2.HesabTafId = qq2.Id;
                                //    obj2.HesabTafCode = qq2.Code;
                                //    obj2.HesabTafName = qq2.Name;
                                //    obj2.Bed = Convert.ToDecimal(txtBesAvali.Text.Replace(",", ""));
                                //    obj2.Sharh = "مانده از قبل " + txtNameVFamil.Text;
                                //    obj2.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                                //    db.AsnadeHesabdariRows.Add(obj2);


                                //    int _HesabTafCode2 = Convert.ToInt32(txtCode.Text);
                                //    var qq3 = db.CodeMoins.FirstOrDefault(f => f.Code == 7001);
                                //    var qq4 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 3 && f.Code == _HesabTafCode2);
                                //    AsnadeHesabdariRow obj3 = new AsnadeHesabdariRow();
                                //    obj3.ShomareSanad = _ShomareSanad == 0 ? q1 + 1 : q.ShomareSanad;
                                //    obj3.Tarikh = Convert.ToDateTime(txtTarikhOzviat.Text.Substring(0, 10));
                                //    obj3.HesabMoinId = qq3.Id;
                                //    obj3.HesabMoinCode = 7001;
                                //    obj3.HesabMoinName = qq3.Name;
                                //    obj3.HesabTafId = qq4.Id;
                                //    obj3.HesabTafCode = _HesabTafCode2;
                                //    obj3.HesabTafName = txtNameVFamil.Text;
                                //    obj3.Bes = Convert.ToDecimal(txtBesAvali.Text.Replace(",", ""));
                                //    obj3.Sharh = "بستانکاری از قبل";
                                //    obj3.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                                //    db.AsnadeHesabdariRows.Add(obj3);

                                //    var s1 = db.AazaSandoghs.FirstOrDefault(f => f.Code == _Code);
                                //    if (_ShomareSanad == 0)
                                //        s1.ShomareSanad = q1 + 1;

                                //    /////////////////////////////////////////////////////////////////////////////////

                                //}

                                //if (txtHazineEftetah.Text != "0")
                                //{
                                //    int _HesabTafCode2 = Convert.ToInt32(txtCode.Text);
                                //    var qq3 = db.CodeMoins.FirstOrDefault(f => f.Code == 7001);
                                //    var qq4 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 3 && f.Code == _HesabTafCode2);
                                //    AsnadeHesabdariRow obj3 = new AsnadeHesabdariRow();
                                //    obj3.ShomareSanad = _ShomareSanad == 0 ? q1 + 1 : q.ShomareSanad;
                                //    obj3.Tarikh = Convert.ToDateTime(txtTarikhOzviat.Text.Substring(0, 10));
                                //    obj3.HesabMoinId = qq3.Id;
                                //    obj3.HesabMoinCode = 7001;
                                //    obj3.HesabMoinName = qq3.Name;
                                //    obj3.HesabTafId = qq4.Id;
                                //    obj3.HesabTafCode = _HesabTafCode2;
                                //    obj3.HesabTafName = txtNameVFamil.Text;
                                //    obj3.Bed = Convert.ToDecimal(txtHazineEftetah.Text.Replace(",", ""));
                                //    obj3.Sharh = "بابت هزینه افتتاح حساب";
                                //    obj3.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                                //    db.AsnadeHesabdariRows.Add(obj3);


                                //    //int _HesabTafId1 = Convert.ToInt32(cmbNameHesab.EditValue);
                                //    var qq1 = db.CodeMoins.FirstOrDefault(f => f.Code == 8001);
                                //    var qq2 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 4 && f.Code == 1000002);
                                //    AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
                                //    obj2.ShomareSanad = _ShomareSanad == 0 ? q1 + 1 : q.ShomareSanad;
                                //    obj2.Tarikh = Convert.ToDateTime(txtTarikhOzviat.Text.Substring(0, 10));
                                //    obj2.HesabMoinId = qq1.Id;
                                //    obj2.HesabMoinCode = 8001;
                                //    obj2.HesabMoinName = qq1.Name;
                                //    obj2.HesabTafId = qq2.Id;
                                //    obj2.HesabTafCode = 1000002;
                                //    obj2.HesabTafName = qq2.Name;
                                //    obj2.Bes = Convert.ToDecimal(txtHazineEftetah.Text.Replace(",", ""));
                                //    obj2.Sharh = "بابت افتتاح حساب " + txtNameVFamil.Text;
                                //    obj2.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                                //    db.AsnadeHesabdariRows.Add(obj2);

                                //    var s1 = db.AazaSandoghs.FirstOrDefault(f => f.Code == _Code);
                                //    if (_ShomareSanad == 0)
                                //        s1.ShomareSanad = q1 + 1;
                                //}

                                //if (_ShomareSanad != 0)
                                //{
                                //    if (txtBesAvali.Text == "0" && txtHazineEftetah.Text == "0")
                                //    {
                                //        q.ShomareSanad = 0;
                                //    }

                                //}
                                //db.SaveChanges();
                                ////////////////////////////////////////////////////////////////////////////////////
                                if (IsActiveBeforeEdit)
                                    btnDisplyActiveList_Click(null, null);
                                else
                                    btnDisplyNotActiveList_Click(null, null);

                                //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex;
                                gridControl1.Enabled = true;
                                ActiveButtons();
                                ClearControls();
                                InActiveControls();
                                En = EnumCED.Save;

                                //var r = db.R_AnvaeVam_B_AllHesabTafzilis.FirstOrDefault(s => s.AllHesabTafziliId == _AllTafId && s.AnvaeVamId == _AnvaeVamId);
                                //FrmTaeinNobatBandiVam();

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

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            btnDelete.Enabled = btnEdit.Enabled = gridView1.RowCount > 0 ? true : false;
        }

        private void btnBrowsPictuer_Click(object sender, EventArgs e)
        {
            XtraOpenFileDialog XtraOpenFileDialog1 = new XtraOpenFileDialog();
            XtraOpenFileDialog1.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";

            if (XtraOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img = Image.FromFile(XtraOpenFileDialog1.FileName);
                this.pictureEdit1.Image = img;
                //this.pictureEdit1.Tag = openFileDialog1.FileName;
            }

        }

        private void btnDeletePictuer_Click(object sender, EventArgs e)
        {
            pictureEdit1.Image = null;
        }

        private void cmbJensiat_Enter(object sender, EventArgs e)
        {
            cmbJensiat.ShowPopup();
        }

        private void cmbTaahol_Enter(object sender, EventArgs e)
        {
            cmbTaahol.ShowPopup();
        }

        private void cmbMoaref_Enter(object sender, EventArgs e)
        {
            cmbMoaref.ShowPopup();
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (En == EnumCED.Edit && chkIsActive.Checked == false)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int RowId = Convert.ToInt32(txtId.Text);
                        string _NameAaza = txtNameVFamil.Text;
                        var AllTafId = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 3 && f.Id2 == RowId).Id;
                        var q1 = db.VamPardakhtis.FirstOrDefault(s => s.IsTasviye == false && s.AazaId == AllTafId);
                        var q2 = db.VamPardakhtis.Where(s => s.IsTasviye == false && s.ZameninName.Contains(_NameAaza));
                        var q3 = db.AsnadeHesabdariRows.Where(f => f.HesabTafId == AllTafId).ToList();
                        var q4 = db.CheckTazmins.FirstOrDefault(f => f.IsInSandogh == true && f.VamGerandeId == AllTafId);
                        if (q1 != null)
                        {
                            XtraMessageBox.Show("عضو مورد نظر وام تسویه نشده دارد لذا نمیتوان آنرا غیر فعال نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            chkIsActive.Checked = true;
                            return;
                        }
                        else if (q2.Count() > 0)
                        {
                            foreach (var item in q2)
                            {
                                XtraMessageBox.Show("عضو مورد نظر ضامن وام " + item.NameAaza + " است لذا نمیتوان آنرا غیر فعال نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            chkIsActive.Checked = true;
                            return;
                        }
                        else if (q3.Count > 0)
                        {
                            decimal SumBed = 0;
                            decimal SumBes = 0;
                            decimal MandeHesab = 0;
                            foreach (var item in q3)
                            {
                                if (item.Bed != null)
                                    SumBed += (decimal)item.Bed;
                                else
                                    SumBes += (decimal)item.Bes;
                            }
                            MandeHesab = SumBed - SumBes;
                            if (MandeHesab != 0)
                            {
                                XtraMessageBox.Show("عضو مورد نظر دارای مانده حساب است لذا نمیتوان آنرا غیرفعال نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                chkIsActive.Checked = true;
                                return;

                            }
                        }
                        else if (q4 != null)
                        {
                            XtraMessageBox.Show("عضو مورد نظر نزد صندوق سند تضمینی دارد لذا نمیتوان آنرا غیر فعال نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            chkIsActive.Checked = true;
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtBesAvali_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtHaghOzviat_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnNobatVam_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.AazaSandoghs.Max(s => s.NobatbandiVam);
                    if (q > 0)
                    {
                        txtNobatbandiVam.Text = (q + 1).ToString();
                    }
                    else
                        txtNobatbandiVam.Text = "1";
                    //txtNobatbandiVam.Focus();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    //gridControl1.Enabled = false;
                    //EditRowIndex = gridView1.FocusedRowHandle;
                    //En = EnumCED.Edit;
                    //InActiveButtons();
                    HelpClass1.DateTimeMask(txtBirthDate);
                    HelpClass1.DateTimeMask(txtTarikhOzviat);
                    FillcmbMoaref();

                    txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                    txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString();
                    txtCodePersoneli.Text = gridView1.GetFocusedRowCellValue("CodePersoneli").ToString();
                    if (gridView1.GetFocusedRowCellDisplayText("TarikhOzviat").ToString() != null)
                        txtTarikhOzviat.Text = gridView1.GetFocusedRowCellValue("TarikhOzviat").ToString().Substring(0, 10);
                    if (gridView1.GetFocusedRowCellDisplayText("TarikhTasviyeVam").ToString() != null)
                        txtTarikhTasviyeVam.Text = gridView1.GetFocusedRowCellValue("TarikhTasviyeVam").ToString().Substring(0, 10);
                    txtNameVFamil.Text = gridView1.GetFocusedRowCellDisplayText("NameVFamil");
                    txtNamePedar.Text = gridView1.GetFocusedRowCellDisplayText("NamePedar");
                    txtCodeMeli.Text = gridView1.GetFocusedRowCellDisplayText("CodeMelli");
                    txtShShenasname.Text = gridView1.GetFocusedRowCellDisplayText("ShShenasname");
                    if (gridView1.GetFocusedRowCellValue("BirthDate") != null)
                        txtBirthDate.Text = gridView1.GetFocusedRowCellDisplayText("BirthDate").Substring(0, 10);
                    else
                        txtBirthDate.Text = string.Empty;
                    cmbJensiat.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexJensiat"));
                    cmbTaahol.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexTaahol"));
                    if (gridView1.GetFocusedRowCellValue("TedadeFarzand") != null)
                        txtTedadeFarzand.Text = gridView1.GetFocusedRowCellDisplayText("TedadeFarzand");
                    else
                        txtTedadeFarzand.Text = string.Empty;

                    txtNameBank.Text = gridView1.GetFocusedRowCellDisplayText("NameBank");
                    txtShomareHesab.Text = gridView1.GetFocusedRowCellDisplayText("ShomareHesab");
                    txtShomareKart.Text = gridView1.GetFocusedRowCellDisplayText("ShomareKart");
                    txtShomareShaba.Text = gridView1.GetFocusedRowCellDisplayText("ShomareShaba");
                    txtAdress.Text = gridView1.GetFocusedRowCellDisplayText("AdressManzel");
                    txtMohaleKar.Text = gridView1.GetFocusedRowCellDisplayText("AdressMohalKar");
                    txtMobile1.Text = gridView1.GetFocusedRowCellDisplayText("Mobile1");
                    txtMobile2.Text = gridView1.GetFocusedRowCellDisplayText("Mobile2");
                    txtTell.Text = gridView1.GetFocusedRowCellDisplayText("Tell");
                    txtShoghl.Text = gridView1.GetFocusedRowCellDisplayText("Shoghl");
                    if (gridView1.GetFocusedRowCellValue("MoarefId") != null)
                        cmbMoaref.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MoarefId"));
                    else
                        cmbMoaref.EditValue = 0;
                    txtBesAvali.Text = gridView1.GetFocusedRowCellDisplayText("BesAvali");
                    txtSaghfeEtebar.Text = gridView1.GetFocusedRowCellDisplayText("SaghfeEtebar");
                    txtEtebarBlookeShode.Text = gridView1.GetFocusedRowCellDisplayText("EtebarBlookeShode");
                    txtMandeEtebar.Text = (Convert.ToDecimal(txtSaghfeEtebar.Text.Replace(",", "")) - Convert.ToDecimal(txtEtebarBlookeShode.Text.Replace(",", ""))).ToString();
                    txtMablaghPasandaz.Text = gridView1.GetFocusedRowCellDisplayText("HaghOzviat") ?? "0";
                    //txtHazineEftetah.Text = gridView1.GetFocusedRowCellDisplayText("HazineEftetah");
                    txtDaramadeMahiane.Text = gridView1.GetFocusedRowCellDisplayText("DaramadeMahiane");
                    txtSharhHesab.Text = gridView1.GetFocusedRowCellDisplayText("SharhHesab");
                    txtNobatbandiVam.Text = gridView1.GetFocusedRowCellDisplayText("NobatbandiVam") ?? "0";
                    txtDarsadPasandaz.Text = gridView1.GetFocusedRowCellDisplayText("DarsadPasandaz") ?? "0";
                    chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                    chkIsOzveSandogh.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsOzveSandogh"));
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.AazaSandoghs.FirstOrDefault(s => s.Id == RowId);
                            if (q1.Pictuer != null)
                            {
                                MemoryStream ms = new MemoryStream(q1.Pictuer);
                                pictureEdit1.Image = Image.FromStream(ms);
                                img = pictureEdit1.Image;
                            }
                            else
                                pictureEdit1.Image = null;
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //CodeBeforeEdit = txtCode.Text;
                    //NameBeforeEdit = txtNameVFamil.Text;
                    //IsActiveBeforeEdit = chkIsActive.Checked;
                    //ActiveControls();
                    //xtraTabControl1.SelectedTabPageIndex = 0;
                    //txtCodePersoneli.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                    "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            gridView1_RowCellClick(null, null);
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(this,gridView1, gridView1.RowCount);
            }

        }

        private void gridView1_KeyUp(object sender, KeyEventArgs e)
        {
            gridView1_RowCellClick(null, null);
        }

        private Keys m_keyCode;
        private void txtSharhHesab_Leave(object sender, EventArgs e)
        {
            if (m_keyCode == Keys.Enter)
            {
                xtraTabControl1.SelectedTabPageIndex = 1;
                txtAdress.Focus();
                m_keyCode = Keys.Clear;
            }
        }

        private void txtSharhHesab_KeyDown(object sender, KeyEventArgs e)
        {
            this.m_keyCode = e.KeyCode;

        }

        private void txtTell_KeyDown(object sender, KeyEventArgs e)
        {
            this.m_keyCode = e.KeyCode;

        }

        private void txtShomareShaba_KeyDown(object sender, KeyEventArgs e)
        {
            this.m_keyCode = e.KeyCode;

        }

        private void txtNobatbandiVam_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void txtTell_Leave(object sender, EventArgs e)
        {
            if (m_keyCode == Keys.Enter)
            {
                xtraTabControl1.SelectedTabPageIndex = 2;
                txtNameBank.Focus();
                m_keyCode = Keys.Clear;
            }

        }

        private void txtShomareShaba_Leave(object sender, EventArgs e)
        {
            if (m_keyCode == Keys.Enter)
            {
                xtraTabControl1.SelectedTabPageIndex = 3;
                txtMablaghPasandaz.Focus();
                m_keyCode = Keys.Clear;
            }

        }

        private void txtNobatbandiVam_Leave(object sender, EventArgs e)
        {


        }

        private void btnAmaliatColi_Click(object sender, EventArgs e)
        {
            FrmChangMablaghPasandaz fm = new FrmChangMablaghPasandaz(this);
            fm.IsActiveList = IsActiveList;
            fm.ShowDialog(this);
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                btnAmaliatColi.Enabled = true;
                btnChangeSaghfeEtebar.Enabled = true;
            }
            else
            {
                btnAmaliatColi.Enabled = false;
                btnChangeSaghfeEtebar.Enabled = false;

            }
        }

        private void btnDesignReport_Click(object sender, EventArgs e)
        {
            //using (var db = new MyContext())
            //{
            //    try
            //    {
            //        var q1 = db.TarifSandoghs.FirstOrDefault(s => s.Id == 1);
            //        if (q1 != null)
            //        {
            //            if (q1.Pictuer != null)
            //            {
            //                MemoryStream ms = new MemoryStream(q1.Pictuer);
            //                img = Image.FromStream(ms);

            //            }
            //            else
            //                img = null;

            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
            //            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            // HelpClass1.LoadReportDesigner(FilePath1, FileName1 , img);

            //XtraReport XtraReport1 = new XtraReport();
            //XtraReport1.LoadLayoutFromXml(FilePath1 + FileName1);
            //Parameter param1 = new Parameter();
            //param1.Name = "Logo";
            //param1.Type = typeof(System.Byte);
            ////param1.Value = img;

            //XtraReport1.Parameters.Add(param1);
            // frd.reportDesigner1.OpenReport(XtraReport1);
            //XtraReport1.Document.Parameters.Add(param1);


            //ساخت فرم طراحی گزارش و ارسال فرم طراحی شده قبلی به فرم طراحی جهت ویرایش
            //FrmReportDesigner frd = new FrmReportDesigner();
            //frd.reportDesigner1.OpenReport(FilePath + FileName);
            //frd.Show();
            HelpClass1.LoadReportDesigner(FilePath1, FileName1);

        }

        private void FrmTarifAaza_1_Shown(object sender, EventArgs e)
        {
            gridView1.MoveLast();
        }

        private void btnChangeSaghfeEtebar_Click(object sender, EventArgs e)
        {
            FrmChangeSaghfeEtebar fm = new FrmChangeSaghfeEtebar(this);
            fm.IsActiveList = IsActiveList;
            fm.ShowDialog(this);
        }

        public bool IsChangeSaghfeEtebar;
        private void FrmTarifAaza_1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Km != null && IsChangeSaghfeEtebar)
            {
                //Km.chkcmbEntekhabZamenin.EditValue = 0;
                //Km.chkcmbEntekhabZamenin.EditValue = null;
                //Km.chkcmbEntekhabZamenin.Text = "";
                Km.chkcmbAazaSandoogh_EditValueChanged(null, null);
            }
        }

        private void labelControl31_Click(object sender, EventArgs e)
        {
            if (_ControlAlt)
            {
                txtEtebarBlookeShode.Enabled = txtEtebarBlookeShode.Enabled == true ? false : true;
                //txtMandeEtebar.ReadOnly = txtMandeEtebar.ReadOnly == true ? false : true;
                _ControlAlt = false;
            }

        }

        private void txtSaghfeEtebar_EditValueChanged(object sender, EventArgs e)
        {
            decimal S1 = !string.IsNullOrEmpty(txtSaghfeEtebar.Text) ? Convert.ToDecimal(txtSaghfeEtebar.Text.Replace(",", "")) : 0;
            decimal S2 = !string.IsNullOrEmpty(txtEtebarBlookeShode.Text) ? Convert.ToDecimal(txtEtebarBlookeShode.Text.Replace(",", "")) : 0;
            decimal S3 = S1 > S2 ? S1 - S2 : 0;
            txtMandeEtebar.Text = S3.ToString();
        }

        private void txtEtebarBlookeShode_EditValueChanged(object sender, EventArgs e)
        {
            decimal S1 = !string.IsNullOrEmpty(txtSaghfeEtebar.Text) ? Convert.ToDecimal(txtSaghfeEtebar.Text.Replace(",", "")) : 0;
            decimal S2 = !string.IsNullOrEmpty(txtEtebarBlookeShode.Text) ? Convert.ToDecimal(txtEtebarBlookeShode.Text.Replace(",", "")) : 0;
            decimal S3 = S1 > S2 ? S1 - S2 : 0;
            txtMandeEtebar.Text = S3.ToString();
        }

        private void FrmTarifAaza_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelpClass1.AddZerooToTextBox(sender, e);
        }

        private void txtTarikhTasviyeVam_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtTarikhTasviyeVam_Leave(object sender, EventArgs e)
        {
        }
        //int _indexNoeVam = 0;
        public void btnMohasebeTarikhMabnayeNobatVam_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (En == EnumCED.Create)
                    {
                        //int yyyy1 = Convert.ToInt32(txtTarikhOzviat.Text.ToString().Substring(0, 4));
                        //int MM1 = Convert.ToInt32(txtTarikhOzviat.Text.ToString().Substring(5, 2));
                        //int dd1 = Convert.ToInt32(txtTarikhOzviat.Text.ToString().Substring(8, 2));
                        //Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                        //int _index = 0;
                        //int ModatEntezar = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SandoghId).AnvaeVams.FirstOrDefault(s => s.DefaultNoeVam==true).MinModatEntezar;
                        //txtTarikhTasviyeVam.Text = d1.AddMont(ModatEntezar).ToString();
                        txtTarikhTasviyeVam.Text = txtTarikhOzviat.Text;

                    }
                    else if (En == EnumCED.Edit)
                    {
                        //var q1 = db.AazaSandoghs.Where(s => s.IsActive == true).AsParallel();
                        var q2 = db.VamPardakhtis;

                        int _AazaId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("AllTafId"));
                        if (q2.FirstOrDefault(s => s.AazaId == _AazaId) == null)
                        {
                            //int yyyy1 = Convert.ToInt32(txtTarikhOzviat.Text.ToString().Substring(0, 4));
                            //int MM1 = Convert.ToInt32(txtTarikhOzviat.Text.ToString().Substring(5, 2));
                            //int dd1 = Convert.ToInt32(txtTarikhOzviat.Text.ToString().Substring(8, 2));
                            //Mydate d1 = new Mydate(yyyy1, MM1, dd1);

                            //int ModatEntezar = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SandoghId).AnvaeVams.FirstOrDefault(s => s.DefaultNoeVam == true).MinModatEntezar;
                            //txtTarikhTasviyeVam.Text = d1.AddMont(ModatEntezar).ToString();
                            txtTarikhTasviyeVam.Text = txtTarikhOzviat.Text;

                        }
                        else
                        {
                            if (q2.FirstOrDefault(s => s.AazaId == _AazaId && s.IsTasviye == true && (s.IndexNoeVam == 0 || s.IndexNoeVam == 1)) == null)
                            {
                                //int yyyy1 = Convert.ToInt32(txtTarikhOzviat.Text.ToString().Substring(0, 4));
                                //int MM1 = Convert.ToInt32(txtTarikhOzviat.Text.ToString().Substring(5, 2));
                                //int dd1 = Convert.ToInt32(txtTarikhOzviat.Text.ToString().Substring(8, 2));
                                //Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                                //int _index = 0;
                                //int ModatEntezar = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SandoghId).AnvaeVams.FirstOrDefault(s => s.DefaultNoeVam == true).MinModatEntezar;
                                //txtTarikhTasviyeVam.Text = d1.AddMont(ModatEntezar).ToString();
                                txtTarikhTasviyeVam.Text = txtTarikhOzviat.Text;

                            }
                            else
                            {
                                var q5 = db.RizeAghsatVams.Where(s => s.AazaId == _AazaId && s.VamPardakhti1.IsTasviye == true && (s.VamPardakhti1.IndexNoeVam == 0 || s.VamPardakhti1.IndexNoeVam == 1)).Max(s => s.TarikhDaryaft);
                                txtTarikhTasviyeVam.Text = q5.ToString();
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

        }

        private void txtMandeEtebar_Leave(object sender, EventArgs e)
        {
            if (m_keyCode == Keys.Enter)
            {
                //xtraTabControl1.SelectedTabPageIndex = 1;
                btnSave.Focus();
                m_keyCode = Keys.Clear;
            }

        }

        private void txtMandeEtebar_KeyDown(object sender, KeyEventArgs e)
        {
            this.m_keyCode = e.KeyCode;
        }

        bool _ControlAlt = false;
        private void labelControl19_Click(object sender, EventArgs e)
        {
            if(_ControlAlt)
            {
            txtBesAvali.Enabled = txtBesAvali.Enabled ? false : true;
                _ControlAlt = false;
            }
        }

        private void txtMablaghPasandaz_Leave(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SandoghId);
                    if (q != null && q.checkEdit17)
                    {
                        if (q.radioGroup3 == 0)
                        {
                            decimal MablaghPasandaz = Convert.ToDecimal(txtMablaghPasandaz.Text);
                            //decimal MaxMablaghPasandaz = Convert.ToDecimal(txtMaxMablaghPasandaz.Text);
                            if (MablaghPasandaz < q.MinMablaghPasandaz)
                            {
                                XtraMessageBox.Show(" مبلغ پس انداز ماهیانه از حداقل تعیین شده در تنظیمات کمتر است \n حداقل مبلغ پیش فرض :" + q.MinMablaghPasandaz.ToString("n0")
                                    , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtMablaghPasandaz.Focus();
                            }
                            else if (MablaghPasandaz > q.MaxMablaghPasandaz)
                            {
                                XtraMessageBox.Show(" مبلغ پس انداز ماهیانه از حداکثر تعیین شده در تنظیمات بیشتر است \n حداکثر مبلغ پیش فرض :" + q.MaxMablaghPasandaz.ToString("n0")
                                    , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtMablaghPasandaz.Focus();

                            }
                        }
                        //else
                        //{
                        //    double MinDarsadPasandaz = Convert.ToDouble(txtMinDarsadPasandaz.Text);
                        //    double MaxDarsadPasandaz = Convert.ToDouble(txtMaxDarsadPasandaz.Text);
                        //    if (MinDarsadPasandaz < q.MinDarsadPasandaz)
                        //    {
                        //        XtraMessageBox.Show("حداقل درصد پس انداز ماهیانه از حداقل درصد تعیین شده در تنظیمات کمتر است \n حداقل درصد پیش فرض :" + " % " + MinDarsadPasandaz
                        //            , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        txtMinDarsadPasandaz.Focus();

                        //    }
                        //    else if (MaxDarsadPasandaz > q.MaxDarsadPasandaz)
                        //    {
                        //        XtraMessageBox.Show("حداکثر درصد پس انداز ماهیانه از حداکثر درصد تعیین شده در تنظیمات بیشتر است \n حداکثر درصد پیش فرض :" + " % " + MaxDarsadPasandaz
                        //            , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        txtMaxDarsadPasandaz.Focus();

                        //    }

                        //}

                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void txtDarsadPasandaz_Leave(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SandoghId);
                    if (q != null && q.checkEdit17)
                    {
                        //if (q.radioGroup3 == 0)
                        //{
                        //    decimal MinMablaghPasandaz = Convert.ToDecimal(txtMinMablaghPasandaz.Text);
                        //    decimal MaxMablaghPasandaz = Convert.ToDecimal(txtMaxMablaghPasandaz.Text);
                        //    if (MinMablaghPasandaz < q.MinMablaghPasandaz)
                        //    {
                        //        XtraMessageBox.Show("حداقل مبلغ پس انداز ماهیانه از حداقل تعیین شده در تنظیمات کمتر است \n حداقل مبلغ پیش فرض :" + MinMablaghPasandaz.ToString("n0")
                        //            , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        txtMinMablaghPasandaz.Focus();
                        //    }
                        //    else if (MaxMablaghPasandaz > q.MaxMablaghPasandaz)
                        //    {
                        //        XtraMessageBox.Show("حداکثر مبلغ پس انداز ماهیانه از حداکثر تعیین شده در تنظیمات بیشتر است \n حداکثر مبلغ پیش فرض :" + MaxMablaghPasandaz.ToString("n0")
                        //            , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        txtMaxMablaghPasandaz.Focus();

                        //    }
                        //}
                        if (q.radioGroup3 == 1)
                        {
                            double DarsadPasandaz = string.IsNullOrEmpty(txtDarsadPasandaz.Text) ? 0 : Convert.ToDouble(txtDarsadPasandaz.Text);
                            //double MaxDarsadPasandaz = Convert.ToDouble(txtMaxDarsadPasandaz.Text);
                            if (DarsadPasandaz < q.MinDarsadPasandaz)
                            {
                                XtraMessageBox.Show(" درصد پس انداز ماهیانه از حداقل درصد تعیین شده در تنظیمات کمتر است \n حداقل درصد پیش فرض :" + " % " + q.MinDarsadPasandaz
                                    , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtDarsadPasandaz.Focus();

                            }
                            else if (DarsadPasandaz > q.MaxDarsadPasandaz)
                            {
                                XtraMessageBox.Show(" درصد پس انداز ماهیانه از حداکثر درصد تعیین شده در تنظیمات بیشتر است \n حداکثر درصد پیش فرض :" + " % " + q.MaxDarsadPasandaz
                                    , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtDarsadPasandaz.Focus();

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

        }

        private void txtTarikhOzviat_Leave(object sender, EventArgs e)
        {
            //btnMohasebeTarikhMabnayeNobatVam_Click(null, null);

            using (var db = new MyContext())
            {
                try
                {
                    var q = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SandoghId);
                    if (q != null)
                    {
                        if (q.checkEdit6)
                        {
                            if (q.NoeRezervIndex == 2 && txtTarikhOzviat.ReadOnly == false)
                            {
                                btnMohasebeTarikhMabnayeNobatVam_Click(null, null);
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

        }
    }
}