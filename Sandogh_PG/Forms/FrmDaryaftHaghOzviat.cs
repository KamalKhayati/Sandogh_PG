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

namespace Sandogh_PG
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
                    var q1 = dataContext.AllHesabTafzilis.Where(f => f.GroupTafziliId == 3).OrderBy(s => s.Code).ToList();
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
        //public void FillcmbNameHesab()
        //{
        //    using (var dataContext = new MyContext())
        //    {
        //        try
        //        {
        //            if (En == EnumCED.Create)
        //            {
        //                var q1 = dataContext.AllHesabTafzilis.Where(s => s.GroupTafziliId == 1 || s.GroupTafziliId == 2 && s.IsActive == true).OrderBy(s => s.Code).ToList();
        //                if (q1.Count > 0)
        //                    allHesabTafzilisBindingSource1.DataSource = q1;
        //                else
        //                    allHesabTafzilisBindingSource1.DataSource = null;
        //            }
        //            else
        //            {
        //                var q1 = dataContext.AllHesabTafzilis.Where(s => s.GroupTafziliId == 1 || s.GroupTafziliId == 2).OrderBy(s => s.Code).ToList();
        //                if (q1.Count > 0)
        //                    allHesabTafzilisBindingSource1.DataSource = q1;
        //                else
        //                    allHesabTafzilisBindingSource1.DataSource = null;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
        //                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

        //}

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
                        txtSeryal.Text = "1";
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

        private void FrmDaryaftHaghOzviat_Load(object sender, EventArgs e)
        {
            FillcmbPardakhtKonande();
            FillcmbHesabMoin();
            HelpClass1.DateTimeMask(txtTarikh);

            using (var db = new MyContext())
            {
                try
                {
                    if (En == EnumCED.Create)
                    {
                        int _AazaId = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("Id"));
                        var qq = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 3 && f.Id2 == _AazaId);
                        if (qq != null)
                            cmbPardakhtKonande.EditValue = qq.Id;
                        NewSeryal();
                        txtTarikh.Text = DateTime.Now.ToString().Substring(0, 10);
                        SelectMonth();
                        txtSal.Text = txtTarikh.Text.Substring(0, 4);
                        var q = db.AazaSandoghs.FirstOrDefault(s => s.Id == _AazaId);
                        if (q != null)
                            txtMablagh.Text = q.HaghOzviat.ToString();

                        //var q2 = db.HesabBankis.FirstOrDefault(s => s.IsActive == true && s.IsDefault == true);
                        //if (q2 != null)
                        //{
                        //    var qq1 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2 && f.Id2 == q2.Id);
                        //    if (qq1 != null)
                        //    {
                        //        cmbMoin.EditValue = 1;
                        //        cmbNameHesab.EditValue = qq1.Id;

                        //    }
                        //}
                        // cmbMonth.ShowPopup();

                        int _SandoghId = Convert.ToInt32(Fm.Fm.IDSandogh.Caption);
                        var q2 = db.Tanzimats.FirstOrDefault(s => s.Id == _SandoghId);
                        if (q2 != null)
                        {
                            cmbMoin.EditValue = q2.MoinDefaultId;
                            cmbNameHesab.EditValue = q2.TafsiliDefaultId;
                        }

                        _NameAaza = cmbPardakhtKonande.Text;
                        if (cmbMonth.SelectedIndex != -1)
                            _Month = cmbMonth.Text;
                        _Sal = txtSal.Text;
                        txtSharh.Text = _Text1 + _NameAaza + _Babat + _Month + _Text2 + _Sal;
                    }
                    else if (En == EnumCED.Edit)
                    {
                        int _shSanad = Convert.ToInt32(Fm.gridView2.GetFocusedRowCellDisplayText("ShomareSanad"));
                        EditRowIndex = Fm.gridView2.FocusedRowHandle;
                        txtId.Text = Fm.gridView2.GetFocusedRowCellDisplayText("Id");
                        cmbPardakhtKonande.EditValue = Convert.ToInt32(Fm.gridView2.GetFocusedRowCellValue("AazaId"));
                        txtSeryal.Text = Fm.gridView2.GetFocusedRowCellDisplayText("Seryal");
                        txtTarikh.Text = Fm.gridView2.GetFocusedRowCellDisplayText("Tarikh").Substring(0, 10);
                        txtMablagh.Text = Fm.gridView2.GetFocusedRowCellDisplayText("Mablagh");
                        cmbMoin.EditValue = Convert.ToInt32(db.AsnadeHesabdariRows.FirstOrDefault(f => f.ShomareSanad == _shSanad).HesabMoinId);
                        cmbNameHesab.EditValue = Convert.ToInt32(Fm.gridView2.GetFocusedRowCellValue("NameHesabId"));
                        cmbMonth.SelectedIndex = Convert.ToInt32(Fm.gridView2.GetFocusedRowCellValue("IndexMonth"));
                        txtSal.Text = Fm.gridView2.GetFocusedRowCellDisplayText("Sal");
                        txtSharh.Text = Fm.gridView2.GetFocusedRowCellDisplayText("Sharh");
                        btnSaveNext.Visible = false;
                    }
                    txtTarikh.Focus();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            else if (Convert.ToInt32(txtMablagh.Text.Replace(",", "")) == 0)
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
                            var q1 = db.AsnadeHesabdariRows.Any() ? db.AsnadeHesabdariRows.Max(f => f.ShomareSanad) : 0;
                            HaghOzviat obj = new HaghOzviat();
                            obj.AazaId = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                            obj.NameAaza = cmbPardakhtKonande.Text;
                            obj.Seryal = Convert.ToInt32(txtSeryal.Text);
                            obj.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
                            obj.Mablagh = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                            obj.NameHesabId = Convert.ToInt32(cmbNameHesab.EditValue);
                            obj.NameHesab = cmbNameHesab.Text;
                            obj.IndexMonth = Convert.ToInt32(cmbMonth.SelectedIndex);
                            obj.Month = cmbMonth.Text;
                            obj.Sal = Convert.ToInt32(txtSal.Text);
                            obj.Sharh = txtSharh.Text;
                            obj.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                            obj.ShomareSanad = q1 + 1;
                            db.HaghOzviats.Add(obj);
                            //db.SaveChanges();
                            ////////////////////////////////////////////////////////////////////////
                            int _HesabMoinId1 = Convert.ToInt32(cmbMoin.EditValue);
                            var qq1 = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId1);
                            int _HesabTafId1 = Convert.ToInt32(cmbNameHesab.EditValue);
                            //var qq1 = db.CodeMoins.FirstOrDefault(f => f.Code == 1001);
                            var qq2 = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabTafId1);
                            AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
                            obj1.ShomareSanad = q1 + 1;
                            obj1.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
                            obj1.HesabMoinId = _HesabMoinId1;
                            obj1.HesabMoinCode = qq1.Code;
                            obj1.HesabMoinName = cmbMoin.Text;
                            obj1.HesabTafId = _HesabTafId1;
                            obj1.HesabTafCode = qq2.Code;
                            obj1.HesabTafName = cmbNameHesab.Text;
                            obj1.Bed = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                            obj1.Sharh = txtSharh.Text;
                            obj1.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                            db.AsnadeHesabdariRows.Add(obj1);
                            //db.SaveChanges();


                            int _HesabTafId2 = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                            var qq3 = db.CodeMoins.FirstOrDefault(f => f.Code == 7001);
                            var qq4 = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabTafId2);
                            AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
                            obj2.ShomareSanad = q1 + 1;
                            obj2.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
                            obj2.HesabMoinId = qq3.Id;
                            obj2.HesabMoinCode = 7001;
                            obj2.HesabMoinName = qq3.Name;
                            obj2.HesabTafId = _HesabTafId2;
                            obj2.HesabTafCode = qq4.Code;
                            obj2.HesabTafName = cmbPardakhtKonande.Text;
                            obj2.Bes = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                            obj2.Sharh = txtSharh.Text;
                            obj2.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                            db.AsnadeHesabdariRows.Add(obj2);
                            /////////////////////////////////////////////////////////////////////////////////
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
                                //q.AazaId = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                                //q.NameAaza = cmbPardakhtKonande.Text;
                                //q.Seryal = Convert.ToInt32(txtSeryal.Text);
                                q.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
                                q.Mablagh = !string.IsNullOrEmpty(txtMablagh.Text) ? Convert.ToDecimal(txtMablagh.Text) : 0;
                                q.NameHesabId = Convert.ToInt32(cmbNameHesab.EditValue);
                                q.NameHesab = cmbNameHesab.Text;
                                q.IndexMonth = Convert.ToInt32(cmbMonth.SelectedIndex);
                                q.Month = cmbMonth.Text;
                                q.Sal = Convert.ToInt32(txtSal.Text);
                                q.Sharh = txtSharh.Text;
                                ///////////////////////////////////////////////////////////////////////////////
                                var q1 = db.AsnadeHesabdariRows.Where(f => f.ShomareSanad == q.ShomareSanad);
                                if (q1.Count() > 0)
                                    db.AsnadeHesabdariRows.RemoveRange(q1);

                                ////////////////////////////////////////////////////////////////////////
                                int _HesabMoinId1 = Convert.ToInt32(cmbMoin.EditValue);
                                var qq1 = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId1);
                                int _HesabTafId1 = Convert.ToInt32(cmbNameHesab.EditValue);
                                //var qq1 = db.CodeMoins.FirstOrDefault(f => f.Code == 1001);
                                var qq2 = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabTafId1);
                                AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
                                obj1.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
                                obj1.ShomareSanad = q.ShomareSanad;
                                obj1.HesabMoinId = _HesabMoinId1;
                                obj1.HesabMoinCode = qq1.Code;
                                obj1.HesabMoinName = cmbMoin.Text;
                                obj1.HesabTafId = _HesabTafId1;
                                obj1.HesabTafCode = qq2.Code;
                                obj1.HesabTafName = cmbNameHesab.Text;
                                obj1.Bed = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                                obj1.Sharh = txtSharh.Text;
                                obj1.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                db.AsnadeHesabdariRows.Add(obj1);


                                int _HesabTafId2 = Convert.ToInt32(cmbPardakhtKonande.EditValue);
                                var qq3 = db.CodeMoins.FirstOrDefault(f => f.Code == 7001);
                                var qq4 = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabTafId2);
                                AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
                                obj2.ShomareSanad = q.ShomareSanad;
                                obj2.Tarikh = Convert.ToDateTime(txtTarikh.Text.Substring(0, 10));
                                obj2.HesabMoinId = qq3.Id;
                                obj2.HesabMoinCode = 7001;
                                obj2.HesabMoinName = qq3.Name;
                                obj2.HesabTafId = _HesabTafId2;
                                obj2.HesabTafCode = qq4.Code;
                                obj2.HesabTafName = cmbPardakhtKonande.Text;
                                obj2.Bes = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                                obj2.Sharh = txtSharh.Text;
                                obj2.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                db.AsnadeHesabdariRows.Add(obj2);
                                /////////////////////////////////////////////////////////////////////////////////
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
                _NameAaza = cmbPardakhtKonande.Text;
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
                form.ShowDialog(this);
            }
            else
            {
                Application.OpenForms[form.Name].Activate();
            }

        }

        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            btnSaveClose_Click(null, null);
            if (En == EnumCED.Cancel)
            {
                ActiveForm(this);
                this.Visible = false;
                Fm.btnCreate2_Click(null, null);
            }
        }

        private void cmbNameHesab_Enter(object sender, EventArgs e)
        {
            cmbNameHesab.ShowPopup();
        }

        private void cmbMonth_Enter(object sender, EventArgs e)
        {
            cmbMonth.ShowPopup();
        }

        private void txtMablagh_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelpClass1.AddZerooToTextBox(sender, e);

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
                                    //allHesabTafzilisBindingSource.DisplayMember = "NameHesab";
                                    //allHesabTafzilisBindingSource.ValueMember = "Id";
                                    //allHesabTafzilisBindingSource.Columns[1].FieldName = "NameHesab";
                                    if (En == EnumCED.Create)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2 && f.IsActive == true).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2).OrderBy(s => s.Code).ToList();
                                        if (q2.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q2;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    break;
                                }
                            case 2001:
                                {
                                    //allHesabTafzilisBindingSource.DisplayMember = "NameVFamil";
                                    //allHesabTafzilisBindingSource.ValueMember = "Id";
                                    //allHesabTafzilisBindingSource.Columns[1].FieldName = "NameVFamil";
                                    if (En == EnumCED.Create)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 3 && f.IsActive == true).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 3).OrderBy(s => s.Code).ToList();
                                        if (q2.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q2;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
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
                                    if (En == EnumCED.Create)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 6 && f.IsActive == true).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 6).OrderBy(s => s.Code).ToList();
                                        if (q2.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q2;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
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
                                    //allHesabTafzilisBindingSource.DisplayMember = "HesabName";
                                    //allHesabTafzilisBindingSource.ValueMember = "Id";
                                    //allHesabTafzilisBindingSource.Columns[1].FieldName = "HesabName";
                                    if (En == EnumCED.Create)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 4 && f.IsActive == true).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 4).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    break;
                                }
                            case 9001:
                                {
                                    //allHesabTafzilisBindingSource.DisplayMember = "HesabName";
                                    //allHesabTafzilisBindingSource.ValueMember = "Id";
                                    //allHesabTafzilisBindingSource.Columns[1].FieldName = "HesabName";
                                    if (En == EnumCED.Create)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 5 && f.IsActive == true).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 5).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
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

        private void cmbMoin_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbNameHesab();
        }

        private void cmbMoin_Enter(object sender, EventArgs e)
        {
            cmbMoin.ShowPopup();
        }

    }
}