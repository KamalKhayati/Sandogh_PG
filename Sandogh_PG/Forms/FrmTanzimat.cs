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

namespace Sandogh_PG
{
    public partial class FrmTanzimat : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmTanzimat(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
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
            using (var db = new MyContext())
            {
                try
                {
                    FillcmbHesabMoin();
                    int _SandoghId = Convert.ToInt32(Fm.IDSandogh.Caption);
                    var q1 = db.Tanzimats.FirstOrDefault(s => s.Id == _SandoghId);
                    if (q1 != null)
                    {
                        txtDarsadeKarmozd.Text = q1.DarsadeKarmozd.ToString();
                        txtMablaghDirkard.Text = q1.MablaghDirkard.ToString();
                        txtMaximumAghsatMahane.Text = q1.MaximumAghsatMahane.ToString();
                        txtMaximumAghsatSalane.Text = q1.MaximumAghsatSalane.ToString();
                        txtPath.Text = q1.Path;
                        checkEdit1.Checked = q1.checkEdit1;
                        checkEdit2.Checked = q1.checkEdit2;
                        checkEdit3.Checked = q1.checkEdit3;
                        cmbMoin.EditValue = q1.MoinDefaultId;
                        cmbNameHesab.EditValue = q1.TafsiliDefaultId;
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

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _SandoghId = Convert.ToInt32(Fm.IDSandogh.Caption);
                    var q1 = db.Tanzimats.FirstOrDefault(s => s.Id == _SandoghId);
                    if (q1 != null)
                    {
                        q1.DarsadeKarmozd = !string.IsNullOrEmpty(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) ? Convert.ToSingle(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) : 0;
                        q1.MablaghDirkard = !string.IsNullOrEmpty(txtMablaghDirkard.Text.Replace(",", "")) ? Convert.ToInt32(txtMablaghDirkard.Text.Replace(",", "")) : 0;
                        q1.MaximumAghsatMahane = !string.IsNullOrEmpty(txtMaximumAghsatMahane.Text.Replace(",", "")) ? Convert.ToInt32(txtMaximumAghsatMahane.Text.Replace(",", "")) : 0;
                        q1.MaximumAghsatSalane = !string.IsNullOrEmpty(txtMaximumAghsatSalane.Text.Replace(",", "")) ? Convert.ToInt32(txtMaximumAghsatSalane.Text.Replace(",", "")) : 0;
                        q1.Path = txtPath.Text;
                        q1.checkEdit1 = checkEdit1.Checked;
                        q1.checkEdit2 = checkEdit2.Checked;
                        q1.checkEdit3 = checkEdit3.Checked;
                        q1.MoinDefaultId = Convert.ToInt32(cmbMoin.EditValue);
                        q1.TafsiliDefaultId = Convert.ToInt32(cmbNameHesab.EditValue);
                    }
                    else
                    {

                        Tanzimat obj = new Tanzimat();
                        obj.DarsadeKarmozd = !string.IsNullOrEmpty(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) ? Convert.ToSingle(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) : 0;
                        obj.MablaghDirkard = !string.IsNullOrEmpty(txtMablaghDirkard.Text.Replace(",", "")) ? Convert.ToInt32(txtMablaghDirkard.Text.Replace(",", "")) : 0;
                        obj.MaximumAghsatMahane = !string.IsNullOrEmpty(txtMaximumAghsatMahane.Text.Replace(",", "")) ? Convert.ToInt32(txtMaximumAghsatMahane.Text.Replace(",", "")) : 0;
                        obj.MaximumAghsatSalane = !string.IsNullOrEmpty(txtMaximumAghsatSalane.Text.Replace(",", "")) ? Convert.ToInt32(txtMaximumAghsatSalane.Text.Replace(",", "")) : 0;
                        obj.Path = txtPath.Text;
                        obj.checkEdit1 = checkEdit1.Checked;
                        obj.checkEdit2 = checkEdit2.Checked;
                        obj.checkEdit3 = checkEdit3.Checked;
                        obj.Id = _SandoghId;
                        obj.MoinDefaultId = Convert.ToInt32(cmbMoin.EditValue);
                        obj.TafsiliDefaultId = Convert.ToInt32(cmbNameHesab.EditValue);
                        //obj.SalMaliId = Convert.ToInt32(Fm.IDSalMali.Caption);
                        db.Tanzimats.Add(obj);
                    }

                    db.SaveChanges();
                    XtraMessageBox.Show("اطلاعات با موفقیت ثبت گردید", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
    }
}