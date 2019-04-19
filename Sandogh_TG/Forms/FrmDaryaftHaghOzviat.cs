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

namespace Sandogh_TG
{
    public partial class FrmDaryaftHaghOzviat : DevExpress.XtraEditors.XtraForm
    {
        FrmDaryafti Fm;
        public FrmDaryaftHaghOzviat(FrmDaryafti fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        public EnumCED En;
        public int EditRowIndex = 0;
        string _Text1 = "دریافت از ";
        string _NameAaza = string.Empty;
        string _Babat = " بابت پس انداز ";
        string _Month = string.Empty;
        string _Text2 = " ماه ";
        string _Sal = string.Empty;
        int Month = 0;
        public void FillcmbPardakhtKonande()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    var q1 = dataContext.AazaSandoghs.OrderBy(s => s.Code).ToList();
                    if (q1.Count > 0)
                        aazaSandoghsBindingSource.DataSource = q1;
                    else
                        aazaSandoghsBindingSource.DataSource = null;
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
            using (var dataContext = new MyContext())
            {
                try
                {
                    var q1 = dataContext.HesabBankis.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList();
                    if (q1.Count > 0)
                        hesabBankisBindingSource.DataSource = q1;
                    else
                        hesabBankisBindingSource.DataSource = null;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void NewSeryal()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.HaghOzviats.Select(s => s);
                    if (q.Any())
                    {
                        var MaximumSeryal = q.Max(p => p.Seryal);
                        if (MaximumSeryal.ToString() != "9999999")
                        {
                            txtSeryal.Text = (MaximumSeryal + 1).ToString();
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                                XtraMessageBox.Show("اعمال محدودیت 9999999 سریال دریافت  ..." + "\n" +
                                    "توجه : نمیتوان بیشتر از این تعداد دریافتی پس انداز ماهیانه داشت ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        txtSeryal.Text = "0000001";
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void SelectMonth()
        {
            Month = Convert.ToInt32(txtTarikh.Text.Substring(5, 2));
            switch (Month)
            {
                case 1:
                    cmbMonth.SelectedIndex = 0;
                    break;
                case 2:
                    cmbMonth.SelectedIndex = 1;
                    break;
                case 3:
                    cmbMonth.SelectedIndex = 2;
                    break;
                case 4:
                    cmbMonth.SelectedIndex = 3;
                    break;
                case 5:
                    cmbMonth.SelectedIndex = 4;
                    break;
                case 6:
                    cmbMonth.SelectedIndex = 5;
                    break;
                case 7:
                    cmbMonth.SelectedIndex = 6;
                    break;
                case 8:
                    cmbMonth.SelectedIndex = 7;
                    break;
                case 9:
                    cmbMonth.SelectedIndex = 8;
                    break;
                case 10:
                    cmbMonth.SelectedIndex = 9;
                    break;
                case 11:
                    cmbMonth.SelectedIndex = 10;
                    break;
                case 12:
                    cmbMonth.SelectedIndex = 11;
                    break;
            }
        }

        private void FrmDaryaftHaghOzviat_Load(object sender, EventArgs e)
        {
            FillcmbPardakhtKonande();
            FillcmbNameHesab();
            if (En == EnumCED.Create)
            {
                int _AazaId = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("Id"));
                cmbPardakhtKonande.EditValue =_AazaId ;
                NewSeryal();
                txtTarikh.Text = DateTime.Now.ToString().Substring(0, 10);
                SelectMonth();
                txtSal.Text = txtTarikh.Text.Substring(0, 4);
                using (var db = new MyContext())
                {
                    try
                    {
                        var q = db.AazaSandoghs.FirstOrDefault(s => s.Id == _AazaId);
                        if (q != null)
                            txtMablagh.Text = q.HaghOzviat.ToString();

                        var q2 = db.HesabBankis.FirstOrDefault(s => s.IsDefault == true);
                        if (q2 != null)
                            cmbNameHesab.EditValue = q2.Id;

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


                _NameAaza = cmbPardakhtKonande.Text;
                if (cmbMonth.SelectedIndex != -1)
                    _Month = cmbMonth.Text;
                _Sal = txtSal.Text;
                txtSharh.Text = _Text1 + _NameAaza + _Babat + _Month + _Text2 + _Sal;
            }
            else if (En == EnumCED.Edit)
            {
                EditRowIndex = Fm.gridView2.FocusedRowHandle;
                txtId.Text = Fm.gridView2.GetFocusedRowCellDisplayText("Id");
                cmbPardakhtKonande.EditValue = Convert.ToInt32(Fm.gridView2.GetFocusedRowCellValue("AazaId"));
                txtSeryal.Text = Fm.gridView2.GetFocusedRowCellDisplayText("Seryal");
                txtTarikh.Text = Fm.gridView2.GetFocusedRowCellDisplayText("Tarikh").Substring(0, 10);
                txtMablagh.Text = Fm.gridView2.GetFocusedRowCellDisplayText("Mablagh");
                cmbNameHesab.EditValue = Convert.ToInt32(Fm.gridView2.GetFocusedRowCellValue("NameHesabId"));
                cmbMonth.SelectedIndex = Convert.ToInt32(Fm.gridView2.GetFocusedRowCellValue("IndexMonth"));
                txtSal.Text = Fm.gridView2.GetFocusedRowCellDisplayText("Sal");
                txtSharh.Text = Fm.gridView2.GetFocusedRowCellDisplayText("Sharh");
                btnSaveNext.Visible = false;
            }

        }

        private void FrmDaryaftHaghOzviat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnSaveClose_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F9 && btnSaveNext.Visible == true)
            {
                btnSaveNext_Click(sender, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, null);
            }

        }

        public void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbPardakhtKonande.Text) || string.IsNullOrEmpty(txtSeryal.Text))
            {
                XtraMessageBox.Show("فیلد نام پرداخت کننده یا سریال نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(txtTarikh.Text))
            {
                XtraMessageBox.Show("لطفاً تاریخ را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(txtMablagh.Text))
            {
                XtraMessageBox.Show("لطفاً مبلغ را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(cmbNameHesab.Text))
            {
                XtraMessageBox.Show("لطفاً حساب بانک یا صندوق را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(cmbMonth.Text))
            {
                XtraMessageBox.Show("لطفاً ماه را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            HaghOzviat obj = new HaghOzviat();
                            obj.AazaId = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                            obj.Seryal = Convert.ToInt32(txtSeryal.Text);
                            obj.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
                            obj.Mablagh = !string.IsNullOrEmpty(txtMablagh.Text) ? Convert.ToDecimal(txtMablagh.Text) : 0;
                            obj.NameHesabId = Convert.ToInt32(cmbNameHesab.EditValue);
                            obj.NameHesab = cmbNameHesab.Text;
                            obj.IndexMonth = Convert.ToInt32(cmbMonth.SelectedIndex);
                            obj.Month = cmbMonth.Text;
                            obj.Sal = Convert.ToInt32(txtSal.Text) ;
                            obj.Sharh = txtSharh.Text;
                            obj.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                            db.HaghOzviats.Add(obj);
                            db.SaveChanges();
                            //XtraMessageBox.Show("اطلاعات با موفقیت ثبت شد", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            En = EnumCED.Save;
                            Fm.btnDisplyList2_Click(null, null);
                            Fm.gridView2.MoveLast();
                            this.Close();
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.HaghOzviats.FirstOrDefault(s => s.Id == RowId);
                            if (q != null)
                            {
                                q.AazaId = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                                q.Seryal = Convert.ToInt32(txtSeryal.Text);
                                q.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
                                q.Mablagh = !string.IsNullOrEmpty(txtMablagh.Text) ? Convert.ToDecimal(txtMablagh.Text) : 0;
                                q.NameHesabId = Convert.ToInt32(cmbNameHesab.EditValue);
                                q.NameHesab = cmbNameHesab.Text;
                                q.IndexMonth = Convert.ToInt32(cmbMonth.SelectedIndex);
                                q.Month = cmbMonth.Text;
                                q.Sal = Convert.ToInt32(txtSal.Text);
                                q.Sharh = txtSharh.Text;
                                db.SaveChanges();
                                //XtraMessageBox.Show("اطلاعات با موفقیت ویرایش شد", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                En = EnumCED.Save;
                                Fm.btnDisplyList2_Click(null, null);
                                if (Fm.gridView2.RowCount > 0)
                                    Fm.gridView2.FocusedRowHandle = EditRowIndex;
                                this.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            En = EnumCED.Cancel;
            this.Close();
        }

        private void FrmDaryaftHaghOzviat_FormClosing(object sender, FormClosingEventArgs e)
        {
            En = EnumCED.Cancel;
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonth.SelectedIndex != -1)
            {
                _Month = cmbMonth.Text;
                txtSharh.Text = _Text1 + _NameAaza + _Babat + _Month + _Text2 + _Sal;
            }

        }

        private void txtSal_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSal.Text))
            {
                _Sal = txtSal.Text;
                txtSharh.Text = _Text1 + _NameAaza + _Babat + _Month + _Text2 + _Sal;
            }

        }

        public new void ActiveForm(XtraForm form)
        {
            if (Application.OpenForms[form.Name] == null)
            {
                form.Show(this);
            }
            else
            {
                Application.OpenForms[form.Name].Activate();
            }

        }

        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            btnSaveClose_Click(null, null);
            if (En == EnumCED.Save)
            {
                ActiveForm(this);
                this.Visible = false;
                Fm.btnCreate2_Click(null, null);
            }
        }
    }
}