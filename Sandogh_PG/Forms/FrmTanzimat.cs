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
using DevExpress.XtraGrid;

namespace Sandogh_PG
{
    public partial class FrmTanzimat : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        MyContext db1;
        public FrmTanzimat(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
            db1 = new MyContext();
        }

        public void FillcmbHesabMoin()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q1 = db.CodeMoins.Select(s => s).ToList();
                    if (q1.Count > 0)
                        codeMoinsBindingSource.DataSource = q1;
                    else
                        codeMoinsBindingSource.DataSource = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        public void FillcmbNameHesab()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _HesabMoinId = Convert.ToInt32(cmbMoin.EditValue);
                    var q = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId);
                    if (q != null)
                    {
                        switch (q.Code)
                        {
                            case 1001:
                                {
                                    var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2 && f.IsActive == true).OrderBy(s => s.Code).ToList();
                                    if (q1.Count > 0)
                                        allHesabTafzilisBindingSource.DataSource = q1;
                                    else
                                        allHesabTafzilisBindingSource.DataSource = null;
                                    break;
                                }
                            case 2001:
                                {
                                    var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 3 && f.IsActive == true).OrderBy(s => s.Code).ToList();
                                    if (q1.Count > 0)
                                        allHesabTafzilisBindingSource.DataSource = q1;
                                    else
                                        allHesabTafzilisBindingSource.DataSource = null;
                                    break;
                                }
                            case 3001:
                                {
                                    goto case 2001;
                                }
                            case 4001:
                                {
                                    goto case 2001;
                                }
                            case 5001:
                                {
                                    var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 6 && f.IsActive == true).OrderBy(s => s.Code).ToList();
                                    if (q1.Count > 0)
                                        allHesabTafzilisBindingSource.DataSource = q1;
                                    else
                                        allHesabTafzilisBindingSource.DataSource = null;
                                    break;
                                }
                            case 6001:
                                {
                                    goto case 2001;
                                }
                            case 6002:
                                {
                                    goto case 2001;
                                }
                            case 6003:
                                {
                                    goto case 2001;
                                }
                            case 7001:
                                {
                                    goto case 2001;
                                }
                            case 8001:
                                {
                                    var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 4 && f.IsActive == true).OrderBy(s => s.Code).ToList();
                                    if (q1.Count > 0)
                                        allHesabTafzilisBindingSource.DataSource = q1;
                                    else
                                        allHesabTafzilisBindingSource.DataSource = null;
                                    break;
                                }
                            case 9001:
                                {
                                    var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 5 && f.IsActive == true).OrderBy(s => s.Code).ToList();
                                    if (q1.Count > 0)
                                        allHesabTafzilisBindingSource.DataSource = q1;
                                    else
                                        allHesabTafzilisBindingSource.DataSource = null;
                                    break;
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


        private void FrmTanzimat_Load(object sender, EventArgs e)
        {
            //using (var db1 = new MyContext())
            {
                try
                {
                    //gridView1.SetRowCellValue(0, NoeVam, "وام قرض الحسنه");
                    //gridView1.SetRowCellValue(1, NoeVam, "وام عادی");
                    //gridView1.SetRowCellValue(2, NoeVam, "وام ضروری");
                    //gridView1.SetRowCellValue(3, NoeVam, "وام ازدواج");

                    var q5 = db1.AnvaeVams.ToList();
                    gridControl1.DataSource = q5;

                    FillcmbHesabMoin();
                    int _SandoghId = Convert.ToInt32(Fm.IDSandogh.Caption);
                    var q1 = db1.Tanzimats.FirstOrDefault(s => s.SandoghId == _SandoghId);
                    if (q1 != null)
                    {
                        //txtDarsadeKarmozd.Text = q1.DarsadeKarmozd.ToString();
                        //txtMablaghDirkard.Text = q1.MablaghDirkard.ToString();
                        //txtMaximumAghsatMahane.Text = q1.MaximumAghsatMahane.ToString();
                        //txtMaximumAghsatSalane.Text = q1.MaximumAghsatSalane.ToString();
                        //txtModatEntezar.Text = q1.ModatEntezar.ToString();
                        //txtXBrabarSarmaye.Text = q1.XBrabarSarmaye.ToString();
                        //txtMazrabEtebar.Text = q1.MazrabEtebar.ToString();
                        txtPath.Text = q1.Path;
                        checkEdit1.Checked = q1.checkEdit1;
                        checkEdit2.Checked = q1.checkEdit2;
                        checkEdit3.Checked = q1.checkEdit3;
                        checkEdit4.Checked = q1.checkEdit4;
                        checkEdit5.Checked = q1.checkEdit5;
                        checkEdit6.Checked = q1.checkEdit6;
                        checkEdit18.Checked = q1.checkEdit18;
                        checkEdit10.Checked = q1.checkEdit10;
                        checkEdit11.Checked = q1.checkEdit11;
                        checkEdit12.Checked = q1.checkEdit12;
                        checkEdit13.Checked = q1.checkEdit13;
                        checkEdit14.Checked = q1.checkEdit14;
                        //checkEdit15.Checked = q1.checkEdit15;
                        checkEdit16.Checked = q1.checkEdit16;
                        checkEdit17.Checked = q1.checkEdit17;
                        radioGroup1.SelectedIndex = q1.radioGroup1;
                        radioGroup2.SelectedIndex = q1.radioGroup2;
                        radioGroup3.SelectedIndex = q1.radioGroup3;
                        radioGroup4.SelectedIndex = q1.radioGroup4;
                        cmbMoin.EditValue = q1.MoinDefaultId;
                        cmbNameHesab.EditValue = q1.TafsiliDefaultId;

                        txtXMah.Text = q1.XMah.ToString();

                        txtMinMablaghSarmayeAvalye.Text = q1.MinMablaghSarmayeAvalye.ToString();
                        txtMaxMablaghSarmayeAvalye.Text = q1.MaxMablaghSarmayeAvalye.ToString();

                        txtMablaghHarSahm.Text = q1.MablaghHarSahm.ToString();
                        txtMinTedadSahm.Text = q1.MinTedadSahm.ToString();
                        txtMaxTedadSahm.Text = q1.MaxTedadSahm.ToString();

                        txtMinMablaghPasandaz.Text = q1.MinMablaghPasandaz.ToString();
                        txtMaxMablaghPasandaz.Text = q1.MaxMablaghPasandaz.ToString();

                        txtMinDarsadPasandaz.Text = q1.MinDarsadPasandaz.ToString();
                        txtMaxDarsadPasandaz.Text = q1.MaxDarsadPasandaz.ToString();

                        cmbNoeRezerv.SelectedIndex = checkEdit6.Checked ? q1.NoeRezervIndex : -1;

                        radioGroup2_SelectedIndexChanged(null, null);
                        radioGroup3_SelectedIndexChanged(null, null);
                        //txtMablaghHarSahm.ReadOnly = radioGroup2.SelectedIndex == 0 ? false : true;
                        ////txtTozihatMablaghSarmayeAvalye.ReadOnly = txtMinMablaghSarmayeAvalye.ReadOnly = txtMaxMablaghSarmayeAvalye.ReadOnly = radioGroup2.SelectedIndex == 1 ? false : true;
                        //txtMinMablaghPasandaz.ReadOnly = radioGroup3.SelectedIndex == 0 ? false : true;
                        ////txtTozihatMablaghPasandaz.ReadOnly = txtMinDarsadPasandaz.ReadOnly = txtMaxDarsadPasandaz.ReadOnly = radioGroup3.SelectedIndex == 1 ? false : true;


                        //gridControl2.DataSource= HelpClass1.ConvettDatagridviewToDataTable(gridView2, gridView2.RowCount);
                        //DataTable dt = HelpClass1.ConvettDatagridviewToDataTable(gridView2, gridView2.RowCount);
                        //dt.Columns[0].DataType= typeof(Int32);

                        //DataTable dt = new DataTable();
                        //dt.Columns.Add("Mablagh");
                        //dt.Columns.Add("TedadZamen");
                        //dt.Columns["Mablagh"].DataType = typeof(Decimal);
                        //dt.Columns["TedadZamen"].DataType = typeof(Int32);

                        //gridControl2.DataSource = dt;
                        gridView1_FocusedRowChanged(null, null);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmTanzimat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnSaveClose_Click(sender, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, null);
            }

        }

        public bool Validition()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (checkEdit6.Checked && cmbNoeRezerv.SelectedIndex == -1)
                    {
                        XtraMessageBox.Show("لطفاً نوع حالت رزرو نوبت بندی وام را مشخص کنید", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(0, "NoeVamName"))||
                        string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(1, "NoeVamName")) ||
                        string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(2, "NoeVamName")) ||
                        string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(3, "NoeVamName")) )
                    {
                        XtraMessageBox.Show("مشخصه نوع وام در برگه 3 نباید خالی باشد", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;

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
        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (Validition())
                    {
                        int _SandoghId = Convert.ToInt32(Fm.IDSandogh.Caption);
                        var q1 = db.Tanzimats.FirstOrDefault(s => s.SandoghId == _SandoghId);
                        if (q1 != null)
                        {
                            //q1.DarsadeKarmozd = !string.IsNullOrEmpty(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) ? Convert.ToSingle(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) : 0;
                            //q1.MablaghDirkard = !string.IsNullOrEmpty(txtMablaghDirkard.Text.Replace(",", "")) ? Convert.ToInt32(txtMablaghDirkard.Text.Replace(",", "")) : 0;
                            //q1.MaximumAghsatMahane = !string.IsNullOrEmpty(txtMaximumAghsatMahane.Text.Replace(",", "")) ? Convert.ToInt32(txtMaximumAghsatMahane.Text.Replace(",", "")) : 0;
                            //q1.MaximumAghsatSalane = !string.IsNullOrEmpty(txtMaximumAghsatSalane.Text.Replace(",", "")) ? Convert.ToInt32(txtMaximumAghsatSalane.Text.Replace(",", "")) : 0;
                            //q1.ModatEntezar = !string.IsNullOrEmpty(txtModatEntezar.Text.Replace(",", "")) ? Convert.ToInt32(txtModatEntezar.Text.Replace(",", "")) : 0;

                            for (int i = 0; i < 4; i++)
                            {

                                q1.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == i).NoeVamName = !string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(i, "NoeVamName")) ? gridView1.GetRowCellValue(i, "NoeVamName").ToString() : "نوع "+i+1;
                                q1.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == i).DarsadeKarmozd = !string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(i, "DarsadeKarmozd")) ? Convert.ToDouble(gridView1.GetRowCellValue(i, "DarsadeKarmozd")) : 0;
                                q1.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == i).MablaghDirkard = !string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(i, "MablaghDirkard")) ? Convert.ToDecimal(gridView1.GetRowCellValue(i, "MablaghDirkard")) : 0;
                                q1.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == i).MaxAghsatMahane = !string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(i, "MaxAghsatMahane")) ? Convert.ToInt32(gridView1.GetRowCellValue(i, "MaxAghsatMahane")) : 0;
                                q1.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == i).MaxAghsatSalane = !string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(i, "MaxAghsatSalane")) ? Convert.ToInt32(gridView1.GetRowCellValue(i, "MaxAghsatSalane")) : 0;
                                q1.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == i).MinModatEntezar = !string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(i, "MinModatEntezar")) ? Convert.ToInt32(gridView1.GetRowCellValue(i, "MinModatEntezar")) : 0;
                                q1.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == i).MaxPardakht = !string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(i, "MaxPardakht")) ? Convert.ToDecimal(gridView1.GetRowCellValue(i, "MaxPardakht")) : 0;
                                q1.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == i).DefaultNoeVam = Convert.ToBoolean(gridView1.GetRowCellValue(i, "DefaultNoeVam"));
                                q1.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == i).AdamEtayeVamJadid = Convert.ToBoolean(gridView1.GetRowCellValue(i, "AdamEtayeVamJadid"));
                                q1.AnvaeVams.FirstOrDefault(s => s.NoeVamIndex == i).MablaghVamChandBrabarSarmaye = !string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(i, "MablaghVamChandBrabarSarmaye")) ? Convert.ToDouble(gridView1.GetRowCellValue(i, "MablaghVamChandBrabarSarmaye")) : 0;

                            }

                            //q1.XBrabarSarmaye = !string.IsNullOrEmpty(txtXBrabarSarmaye.Text.Replace(",", "")) ? Convert.ToInt32(txtXBrabarSarmaye.Text.Replace(",", "")) : 0;
                            //q1.MazrabEtebar = !string.IsNullOrEmpty(txtMazrabEtebar.Text.Replace(",", "")) ? Convert.ToInt32(txtMazrabEtebar.Text.Replace(",", "")) : 0;
                            q1.Path = txtPath.Text;
                            q1.checkEdit1 = checkEdit1.Checked;
                            q1.checkEdit2 = checkEdit2.Checked;
                            q1.checkEdit3 = checkEdit3.Checked;
                            q1.checkEdit4 = checkEdit4.Checked;
                            q1.checkEdit5 = checkEdit5.Checked;
                            q1.checkEdit6 = checkEdit6.Checked;
                            q1.checkEdit18 = checkEdit18.Checked;
                            q1.checkEdit10 = checkEdit10.Checked;
                            q1.checkEdit11 = checkEdit11.Checked;
                            q1.checkEdit12 = checkEdit12.Checked;
                            q1.checkEdit13 = checkEdit13.Checked;
                            q1.checkEdit14 = checkEdit14.Checked;
                            //q1.checkEdit15 = checkEdit15.Checked;
                            q1.checkEdit16 = checkEdit16.Checked;
                            q1.checkEdit17 = checkEdit17.Checked;
                            q1.XMah = !string.IsNullOrEmpty(txtXMah.Text.Replace(",", "")) ? Convert.ToInt32(txtXMah.Text.Replace(",", "")) : 0;

                            q1.radioGroup1 = radioGroup1.SelectedIndex;
                            q1.radioGroup2 = radioGroup2.SelectedIndex;
                            q1.radioGroup3 = radioGroup3.SelectedIndex;
                            q1.radioGroup4 = radioGroup4.SelectedIndex;

                            q1.MinMablaghSarmayeAvalye = !string.IsNullOrEmpty(txtMinMablaghSarmayeAvalye.Text.Replace(",", "")) ? Convert.ToDecimal(txtMinMablaghSarmayeAvalye.Text.Replace(",", "")) : 0;
                            q1.MaxMablaghSarmayeAvalye = !string.IsNullOrEmpty(txtMaxMablaghSarmayeAvalye.Text.Replace(",", "")) ? Convert.ToDecimal(txtMaxMablaghSarmayeAvalye.Text.Replace(",", "")) : 0;
                            q1.MablaghHarSahm = !string.IsNullOrEmpty(txtMablaghHarSahm.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghHarSahm.Text.Replace(",", "")) : 0;
                            q1.MinTedadSahm = !string.IsNullOrEmpty(txtMinTedadSahm.Text.Replace(",", "")) ? Convert.ToDouble(txtMinTedadSahm.Text.Replace(",", "")) : 0;
                            q1.MaxTedadSahm = !string.IsNullOrEmpty(txtMaxTedadSahm.Text.Replace(",", "")) ? Convert.ToDouble(txtMaxTedadSahm.Text.Replace(",", "")) : 0;

                            q1.MinMablaghPasandaz = !string.IsNullOrEmpty(txtMinMablaghPasandaz.Text.Replace(",", "")) ? Convert.ToDecimal(txtMinMablaghPasandaz.Text.Replace(",", "")) : 0;
                            q1.MaxMablaghPasandaz = !string.IsNullOrEmpty(txtMaxMablaghPasandaz.Text.Replace(",", "")) ? Convert.ToDecimal(txtMaxMablaghPasandaz.Text.Replace(",", "")) : 0;
                            //q1.TozihatMablaghPasandaz = !string.IsNullOrEmpty(txtTozihatMablaghPasandaz.Text.Replace(",", "")) ? Convert.ToString(txtTozihatMablaghPasandaz.Text.Replace(",", "")) : string.Empty;
                            q1.MinDarsadPasandaz = !string.IsNullOrEmpty(txtMinDarsadPasandaz.Text.Replace(",", "")) ? Convert.ToDouble(txtMinDarsadPasandaz.Text.Replace(",", "")) : 0;
                            q1.MaxDarsadPasandaz = !string.IsNullOrEmpty(txtMaxDarsadPasandaz.Text.Replace(",", "")) ? Convert.ToDouble(txtMaxDarsadPasandaz.Text.Replace(",", "")) : 0;

                            q1.NoeRezervIndex = Convert.ToInt32(cmbNoeRezerv.SelectedIndex);
                            q1.MoinDefaultId = Convert.ToInt32(cmbMoin.EditValue);
                            q1.TafsiliDefaultId = Convert.ToInt32(cmbNameHesab.EditValue);
                        }
                        //else
                        //{

                        //    Tanzimat obj = new Tanzimat();
                        //    obj.DarsadeKarmozd = !string.IsNullOrEmpty(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) ? Convert.ToSingle(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) : 0;
                        //    obj.MablaghDirkard = !string.IsNullOrEmpty(txtMablaghDirkard.Text.Replace(",", "")) ? Convert.ToInt32(txtMablaghDirkard.Text.Replace(",", "")) : 0;
                        //    obj.MaximumAghsatMahane = !string.IsNullOrEmpty(txtMaximumAghsatMahane.Text.Replace(",", "")) ? Convert.ToInt32(txtMaximumAghsatMahane.Text.Replace(",", "")) : 0;
                        //    obj.MaximumAghsatSalane = !string.IsNullOrEmpty(txtMaximumAghsatSalane.Text.Replace(",", "")) ? Convert.ToInt32(txtMaximumAghsatSalane.Text.Replace(",", "")) : 0;
                        //    obj.ModatEntezar = !string.IsNullOrEmpty(txtModatEntezar.Text.Replace(",", "")) ? Convert.ToInt32(txtModatEntezar.Text.Replace(",", "")) : 0;
                        //    obj.XBrabarSarmaye = !string.IsNullOrEmpty(txtXBrabarSarmaye.Text.Replace(",", "")) ? Convert.ToInt32(txtXBrabarSarmaye.Text.Replace(",", "")) : 0;
                        //    obj.MazrabEtebar = !string.IsNullOrEmpty(txtMazrabEtebar.Text.Replace(",", "")) ? Convert.ToInt32(txtMazrabEtebar.Text.Replace(",", "")) : 0;
                        //    obj.Path = txtPath.Text;
                        //    obj.checkEdit1 = checkEdit1.Checked;
                        //    obj.checkEdit2 = checkEdit2.Checked;
                        //    obj.checkEdit3 = checkEdit3.Checked;
                        //    obj.checkEdit4 = checkEdit4.Checked;
                        //    obj.checkEdit5 = checkEdit5.Checked;
                        //    obj.checkEdit6 = checkEdit6.Checked;
                        //    obj.checkEdit18 = checkEdit18.Checked;
                        //    obj.checkEdit8 = checkEdit8.Checked;
                        //    obj.radioGroup1 = radioGroup1.SelectedIndex;
                        //    obj.Id = _SandoghId;
                        //    obj.MoinDefaultId = Convert.ToInt32(cmbMoin.EditValue);
                        //    obj.TafsiliDefaultId = Convert.ToInt32(cmbNameHesab.EditValue);
                        //    //obj.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                        //    db.Tanzimats.Add(obj);
                        //}

                        db.SaveChanges();
                        XtraMessageBox.Show("اطلاعات با موفقیت ثبت گردید", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //FolderBrowserDialog SPath = new FolderBrowserDialog();
        XtraFolderBrowserDialog SPath = new XtraFolderBrowserDialog();
        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            try
            {
                if (SPath.ShowDialog() == DialogResult.OK)
                {
                    if (SPath.SelectedPath.Length == 3)
                    {
                        txtPath.Text = SPath.SelectedPath;// + "BackupFile_Sandogh_PG";
                                                          //+"_Date_" + DateTime.Now.ToString().Replace("/", "").Substring(0, 8) + "_Time_" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(".", " ").Substring(8, 11) + ".BAK";
                                                          //txtSelectPath.Text = SPath.SelectedPath + "BackupFile_" +
                                                          //    DateTime.Now.Date.Year + DateTime.Now.Date.Month + DateTime.Now.Date.Day + "_" +
                                                          //    DateTime.Now.TimeOfDay.Hours + DateTime.Now.TimeOfDay.Minutes + DateTime.Now.TimeOfDay.Seconds + ".BAK";
                    }
                    else
                    {
                        txtPath.Text = SPath.SelectedPath; //+ "\\BackupFile_Sandogh_PG";
                                                           //+"_Date_" + DateTime.Now.ToString().Replace("/", "").Substring(0, 8) + "_Time_" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(".", " ").Substring(8, 11) + ".BAK";
                                                           //txtSelectPath.Text = SPath.SelectedPath + "\\BackupFile_" +
                                                           //    DateTime.Now.Date.Year + DateTime.Now.Date.Month + DateTime.Now.Date.Day + "_" +
                                                           //    DateTime.Now.TimeOfDay.Hours + DateTime.Now.TimeOfDay.Minutes + DateTime.Now.TimeOfDay.Seconds + ".BAK";
                    }
                }
            }
            catch (PathTooLongException)
            {

                MessageBox.Show("مسیر فایل طولانی است");
            }
        }

        private void cmbMoin_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbNameHesab();
        }

        private void checkEdit5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit5.Checked == true )
            {
                checkEdit1.Checked = true;
                checkEdit11.Checked = false;

            }
            //checkEdit6.Visible = checkEdit5.Checked ? true : false;
            //checkEdit6.Checked = checkEdit5.Checked ? true : false;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == false )
            {
                checkEdit5.Checked = false;
                checkEdit11.Checked = false;
            }
        }

        private void checkEdit9_CheckedChanged(object sender, EventArgs e)
        {
            txtXMah.ReadOnly = checkEdit10.Checked ? false : true;
        }

        private void checkEdit6_CheckedChanged(object sender, EventArgs e)
        {
            cmbNoeRezerv.ReadOnly = checkEdit6.Checked ? false : true;
            if (checkEdit6.Checked == false)
                cmbNoeRezerv.SelectedIndex = -1;
        }

        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMinMablaghSarmayeAvalye.ReadOnly = txtMaxMablaghSarmayeAvalye.ReadOnly = radioGroup2.SelectedIndex == 0 ? false : true;
            txtMablaghHarSahm.ReadOnly = txtMinTedadSahm.ReadOnly = txtMaxTedadSahm.ReadOnly = radioGroup2.SelectedIndex == 1 ? false : true;

            //txtTozihatMablaghSarmayeAvalye.ReadOnly = txtMinMablaghSarmayeAvalye.ReadOnly = txtMaxMablaghSarmayeAvalye.ReadOnly = radioGroup2.SelectedIndex == 1 ? false : true;
            //txtStaticMablaghPasandaz.ReadOnly = radioGroup3.SelectedIndex == 0 ? false : true;
            //txtTozihatMablaghPasandaz.ReadOnly = txtMinPasandazMahane.ReadOnly = txtMaxPasandazMahane.ReadOnly = radioGroup3.SelectedIndex == 1 ? false : true;
        }

        private void radioGroup3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMinMablaghPasandaz.ReadOnly = txtMaxMablaghPasandaz.ReadOnly = radioGroup3.SelectedIndex == 0 ? false : true;
            txtMinDarsadPasandaz.ReadOnly = txtMaxDarsadPasandaz.ReadOnly = radioGroup3.SelectedIndex == 1 ? false : true;

            //txtStaticMablaghSarmayeAvalye.ReadOnly = radioGroup2.SelectedIndex == 0 ? false : true;
            //txtTozihatMablaghSarmayeAvalye.ReadOnly = txtMinMablaghSarmayeAvalye.ReadOnly = txtMaxMablaghSarmayeAvalye.ReadOnly = radioGroup2.SelectedIndex == 1 ? false : true;
            //txtTozihatMablaghPasandaz.ReadOnly = txtMinDarsadPasandaz.ReadOnly = txtMaxDarsadPasandaz.ReadOnly = radioGroup3.SelectedIndex == 1 ? false : true;

        }

        private void checkEdit16_CheckedChanged(object sender, EventArgs e)
        {
            panelControl16.Enabled = checkEdit16.Checked ? true : false;
        }

        private void checkEdit17_CheckedChanged(object sender, EventArgs e)
        {
            panelControl17.Enabled = checkEdit17.Checked ? true : false;
        }

        private void checkEdit11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit11.Checked == true)
            {
                checkEdit1.Checked = true;
                checkEdit5.Checked = false;
            }

            gridControl2.Enabled = checkEdit11.Checked ? true : false;
        }

        int RowId = 0;
        int BeforeRowId = 0;
        //GridControl gridControl02 = null;
        //GridControl BeforegridControl02 = null;

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //using (var db = new MyContext())
            {
                //try
                //{
                //    if (checkEdit11.Checked)
                //    {
                //        RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                //        gridControl02 = new GridControl();
                //        gridControl02.DataSource = gridControl2.DataSource;

                //        if (BeforegridControl02 != null && gridControl02 != BeforegridControl02 && BeforeRowId != 0 && BeforeRowId != RowId)
                //        {
                //            DataTable dt = HelpClass1.ConvettDatagridviewToDataTable(gridView2, gridView2.RowCount - 1);
                //            if (dt.Rows.Count > 0)
                //            {
                //                var tz = db.TedadZamenins.Where(s => s.AnvaeVamId == BeforeRowId);
                //                db.TedadZamenins.RemoveRange(tz);
                //            }
                //            List<TedadZamenin> List = new List<TedadZamenin>();
                //            for (int i = 0; i < dt.Rows.Count - 1; i++)
                //            {
                //                TedadZamenin obj = new TedadZamenin()
                //                {
                //                    Mablagh = string.IsNullOrEmpty(dt.Rows[i][0].ToString()) ? 0 : Convert.ToDecimal(dt.Rows[i][0].ToString()),
                //                    TedadZamen = string.IsNullOrEmpty(dt.Rows[i][0].ToString()) ? 0 : Convert.ToInt32(dt.Rows[i][0].ToString()),
                //                };
                //                List.Add(obj);
                //            }
                //            db.AnvaeVams.FirstOrDefault(s => s.Id == BeforeRowId).TedadZamenins = List;
                //            db.SaveChanges();
                //        }
                //        BeforeRowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                //        BeforegridControl02.DataSource = gridControl2.DataSource;

                //        gridControl2.DataSource = db.TedadZamenins.Where(s => s.AnvaeVamId == RowId);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                //        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridView1_FocusedRowChanged(null, null);
            //using (var db = new MyContext())
            {
                //try
                //{
                //    if (checkEdit11.Checked)
                //    {
                //        RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                //        gridControl02 = new GridControl();
                //        gridControl02.DataSource = gridControl2.DataSource;

                //        if (BeforegridControl02 != null && gridControl02 != BeforegridControl02 && BeforeRowId != 0 && BeforeRowId != RowId)
                //        {
                //            DataTable dt = HelpClass1.ConvettDatagridviewToDataTable(gridView2, gridView2.RowCount - 1);
                //            if (dt.Rows.Count > 0)
                //            {
                //                var tz = db.TedadZamenins.Where(s => s.AnvaeVamId == BeforeRowId);
                //                if (tz.Count() > 0)
                //                    db.TedadZamenins.RemoveRange(tz);
                //            }
                //            List<TedadZamenin> List = new List<TedadZamenin>();
                //            for (int i = 0; i < dt.Rows.Count; i++)
                //            {
                //                TedadZamenin obj = new TedadZamenin();
                //                obj.Mablagh = string.IsNullOrEmpty(dt.Rows[i][0].ToString()) ? 0 : Convert.ToDecimal(dt.Rows[i][0].ToString());
                //                obj.TedadZamen = string.IsNullOrEmpty(dt.Rows[i][1].ToString()) ? 0 : Convert.ToInt32(dt.Rows[i][1].ToString());
                //                List.Add(obj);
                //            }
                //            if (List.Count() > 0)
                //                db.AnvaeVams.FirstOrDefault(s => s.Id == BeforeRowId).TedadZamenins = List;
                //            db.SaveChanges();
                //        }
                //        BeforeRowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                //        //if (gridView2.RowCount-1 > 0)
                //        BeforegridControl02 = new GridControl();
                //        BeforegridControl02.DataSource = gridControl2.DataSource;

                //        DataTable dt2 = new DataTable();
                //        dt2.Columns.Add("Mablagh");
                //        dt2.Columns.Add("TedadZamen");
                //        dt2.Columns["Mablagh"].DataType = typeof(Decimal);
                //        dt2.Columns["TedadZamen"].DataType = typeof(Int32);

                //        var t = db.TedadZamenins.Where(s => s.AnvaeVamId == RowId).ToList();
                //        if (t.Count() > 0)
                //        {
                //            for (int i = 0; i < t.Count(); i++)
                //            {
                //                DataRow DataRow1 = dt2.NewRow();
                //                DataRow1["Mablagh"] = t[i].Mablagh;
                //                DataRow1["TedadZamen"] = t[i].TedadZamen;
                //                dt2.Rows.Add(DataRow1);
                //            }

                //        }
                //        gridControl2.DataSource = dt2;

                //    }
                //}
                //catch (Exception ex)
                //{
                //    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                //        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (checkEdit11.Checked)
                    {
                        RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                        var tz = db.TedadZamenins.Where(s => s.AnvaeVamId == RowId);
                        if (tz.Count() > 0)
                            db.TedadZamenins.RemoveRange(tz);

                        DataTable dt = HelpClass1.ConvettDatagridviewToDataTable(gridView2, gridView2.RowCount - 1);
                        if (dt.Rows.Count > 0)
                        {
                            List<TedadZamenin> List = new List<TedadZamenin>();
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                TedadZamenin obj = new TedadZamenin();
                                obj.Mablagh = string.IsNullOrEmpty(dt.Rows[i][0].ToString()) ? 0 : Convert.ToDecimal(dt.Rows[i][0].ToString());
                                obj.TedadZamen = string.IsNullOrEmpty(dt.Rows[i][1].ToString()) ? 0 : Convert.ToInt32(dt.Rows[i][1].ToString());
                                List.Add(obj);
                            }
                            if (List.Count() > 0)
                                db.AnvaeVams.FirstOrDefault(s => s.Id == RowId).TedadZamenins = List;
                           
                        }
                        db.SaveChanges();

                        DataTable dt2 = new DataTable();
                        dt2.Columns.Add("Mablagh");
                        dt2.Columns.Add("TedadZamen");
                        dt2.Columns["Mablagh"].DataType = typeof(Decimal);
                        dt2.Columns["TedadZamen"].DataType = typeof(Int32);

                        var t = db.TedadZamenins.Where(s => s.AnvaeVamId == RowId).ToList();
                        if (t.Count() > 0)
                        {
                            for (int i = 0; i < t.Count(); i++)
                            {
                                DataRow DataRow1 = dt2.NewRow();
                                DataRow1["Mablagh"] = t[i].Mablagh;
                                DataRow1["TedadZamen"] = t[i].TedadZamen;
                                dt2.Rows.Add(DataRow1);
                            }

                        }
                        gridControl2.DataSource = dt2;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        //GridControl gridControl02;
        //GridControl BeforgridControl02;
        //DataTable dt3;
        //DataTable dt4;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (checkEdit11.Checked)
                    {
                        RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                        DataTable dt2 = new DataTable();
                        dt2.Columns.Add("Mablagh");
                        dt2.Columns.Add("TedadZamen");
                        dt2.Columns["Mablagh"].DataType = typeof(Decimal);
                        dt2.Columns["TedadZamen"].DataType = typeof(Int32);

                        var t = db.TedadZamenins.Where(s => s.AnvaeVamId == RowId).ToList();
                        if (t.Count() > 0)
                        {
                            for (int i = 0; i < t.Count(); i++)
                            {
                                DataRow DataRow1 = dt2.NewRow();
                                DataRow1["Mablagh"] = t[i].Mablagh;
                                DataRow1["TedadZamen"] = t[i].TedadZamen;
                                dt2.Rows.Add(DataRow1);
                            }

                        }
                        gridControl2.DataSource = dt2;


                         //dt3 = new DataTable();
                       // dt3 = HelpClass1.ConvettDatagridviewToDataTable(gridView2, gridView2.RowCount - 1);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void FrmTanzimat_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (db1 != null)
                db1.Dispose();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(this, gridView1, gridView1.RowCount);
            }

        }

        private void gridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(this, gridView2, gridView2.RowCount);
            }

        }

        private void checkEdit15_CheckedChanged(object sender, EventArgs e)
        {
            gridView1.Columns["MablaghVamChandBrabarSarmaye"].Caption = radioGroup4.SelectedIndex==0 ? "مبلغ وام حداکثر چند برابر جمع کل سرمایه" : "مبلغ وام حداکثر چند برابر سرمایه اولیه";
        }


        private void gridControl2_Leave(object sender, EventArgs e)
        {
            //dt4 = new DataTable();
            //dt4 = HelpClass1.ConvettDatagridviewToDataTable(gridView2, gridView2.RowCount - 1);
            //if (dt3.CreateDataReader() != dt4.CreateDataReader())
            //{
            //    btnSave_Click(null, null);
            //}

        }

        private void gridControl2_Move(object sender, EventArgs e)
        {
            //dt4 = new DataTable();
            //dt4 = HelpClass1.ConvettDatagridviewToDataTable(gridView2, gridView2.RowCount - 1);
            //if (dt3 != dt4)
            //{
            //    btnSave_Click(null, null);
            //}

        }
    }
}