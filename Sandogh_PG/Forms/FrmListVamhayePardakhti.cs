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
using System.Data.Entity.Infrastructure;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Diagnostics;
using DevExpress.XtraReports.UI;

namespace Sandogh_PG
{
    public partial class FrmListVamhayePardakhti : DevExpress.XtraEditors.XtraForm
    {
        public FrmMain Fm;
        public FrmListVamhayePardakhti(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        public bool ListTasviyeNashode = true;
        public int _VamPardakhtiId = 0;
        public void FillDataGridVamhayePardakhti()
        {
            using (var db = new MyContext())
            {
                try
                {
                    rizeAghsatVamsBindingSource.DataSource = null;
                    if (ListTasviyeNashode == true)
                    {
                        var q1 = db.VamPardakhtis.Where(s => s.IsTasviye == false).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0)
                            vamPardakhtisBindingSource.DataSource = q1;
                        else
                            vamPardakhtisBindingSource.DataSource = null;
                    }
                    else
                    {
                        var q = db.VamPardakhtis.Where(s => s.IsTasviye == true).OrderBy(s => s.Code);
                        if (q.Count() > 0)
                            vamPardakhtisBindingSource.DataSource = q.ToList();
                        else
                            vamPardakhtisBindingSource.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillDataGridRizeAghsatVam()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _VamPardakhtiId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                    var q1 = db.RizeAghsatVams.Where(s => s.VamPardakhtiId == _VamPardakhtiId).OrderBy(s => s.TarikhSarresid).ToList();
                    if (q1.Count > 0)
                        rizeAghsatVamsBindingSource.DataSource = q1;
                    else
                        rizeAghsatVamsBindingSource.DataSource = null;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnCreate1_Click(object sender, EventArgs e)
        {
            FrmVamPardakhti fm = new FrmVamPardakhti(this);
            fm.En = EnumCED.Create;
            fm.ShowDialog();
        }

        private void btnEdit1_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                EditRowIndex = gridView1.FocusedRowHandle;
                using (var db = new MyContext())
                {
                    try
                    {
                        if (ListTasviyeNashode)
                        {
                            int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                            var q = db.RizeAghsatVams.FirstOrDefault(p => p.VamPardakhtiId == RowId && p.MablaghDaryafti > 0);
                            if (q != null)
                            {
                                XtraMessageBox.Show("به دلیل اقساط دریافتی ، بعضی از اطلاعات قابل ویرایش نیست \nجهت ویرایش کلیه اطلاعات ، بایستی در ابتدا اقساط دریافت شده از طریق منوی (دریافت پس انداز ماهیانه و اقساط وام) حذف شود \nضمناً در صورت نداشتن اقساط دریافتی ، جهت حذف و یا ویرایش اطلاعات مربوط به تاریخ سررسید اقساط و مبلغ اقساط میتوانید\n از طریق منوی سمت چپ اقدام نمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                FrmVamPardakhti fm = new FrmVamPardakhti(this);
                                fm.En = EnumCED.Edit;
                                fm.IsEditRizAghsat = false;
                                fm.panelControl1.Enabled = false;
                                fm.panelControl3.Enabled = false;
                                fm.panelControl5.Enabled = false;
                                fm.panelControl6.Enabled = false;
                                fm.panelControl7.Enabled = false;
                                fm.ShowDialog();
                            }
                            else
                            {
                                FrmVamPardakhti fm = new FrmVamPardakhti(this);
                                fm.En = EnumCED.Edit;
                                fm.IsEditRizAghsat = true;
                                fm.ShowDialog();
                            }

                        }
                        else
                        {
                            FrmVamPardakhti fm = new FrmVamPardakhti(this);
                            fm.En = EnumCED.Edit;
                            //fm.IsEditRizAghsat = true;
                            fm.panelControl1.Enabled = fm.panelControl3.Enabled = fm.panelControl4.Enabled = fm.panelControl5.Enabled = fm.panelControl6.Enabled = fm.panelControl7.Enabled = false;
                            fm.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FrmListVamhayePardakhti_Load(object sender, EventArgs e)
        {
            FillDataGridVamhayePardakhti();
            btnCreate1.Focus();
        }

        public void btnDisplyActiveList1_Click(object sender, EventArgs e)
        {
            ListTasviyeNashode = true;
            FillDataGridVamhayePardakhti();
            gridView1_FocusedRowChanged(null, null);
            groupBox4.Text = "لیست وامهای پرداختی (تسویه نشده)";
            groupBox4.ForeColor = Color.Blue;
        }

        public void btnDisplyNotActiveList1_Click(object sender, EventArgs e)
        {
            ListTasviyeNashode = false;
            FillDataGridVamhayePardakhti();
            gridView1_FocusedRowChanged(null, null);
            groupBox4.Text = "لیست وامهای پرداختی (تسویه شده)";
            groupBox4.ForeColor = Color.Red;
        }

        private void btnLast1_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveLast(gridView1);
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveNext(gridView1);

        }

        private void btnPreview1_Click(object sender, EventArgs e)
        {
            HelpClass1.MovePrev(gridView1);

        }

        private void btnFirst1_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveFirst(gridView1);

        }
        int EditRowIndex = 0;
        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (XtraMessageBox.Show("آیا وام مورد نظر حذف شود؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    EditRowIndex = gridView1.FocusedRowHandle;
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                            var qq1 = db.RizeAghsatVams.FirstOrDefault(p => p.VamPardakhtiId == RowId && p.MablaghDaryafti > 0);
                            if (qq1 != null)
                            {
                                XtraMessageBox.Show("به دلیل اقساط دریافتی ، وام فوق قابل حذف نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                var q = db.VamPardakhtis.FirstOrDefault(p => p.Id == RowId);
                                if (q != null)
                                {
                                    db.VamPardakhtis.Remove(q);
                                    var q1 = db.AsnadeHesabdariRows.Where(f => f.ShomareSanad == q.ShomareSanad);
                                    if (q1.Count() > 0)
                                        db.AsnadeHesabdariRows.RemoveRange(q1);
                                    /////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();

                                    if (ListTasviyeNashode)
                                        btnDisplyActiveList1_Click(null, null);
                                    else
                                        btnDisplyNotActiveList1_Click(null, null);
                                    //XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridView1.RowCount > 0)
                                        gridView1.FocusedRowHandle = EditRowIndex - 1;
                                }
                                else
                                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }





                        }
                        //catch (DbUpdateException)
                        //{
                        //    XtraMessageBox.Show("حذف این وام مقدور نیست \n" +
                        //        "جهت حذف وام مورد نظر ، در ابتدا بایستی ریز اقساط وام حذف گردد"
                        //        , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridView1_RowCellClick(null, null);
            //total = new List<long>();
            //FillDataGridRizeAghsatVam();
            chkSelectAll.Checked = false;
            if (ListTasviyeNashode == true)
            {
                if (gridView1.RowCount > 0)
                {
                    btnCreate2.Visible = true;
                    btnDelete2.Visible = true;
                    btnEdit2.Visible = true;
                    chkSelectAll.Visible = true;
                }
            }
            else
            {
                btnCreate2.Visible = false;
                btnDelete2.Visible = false;
                btnEdit2.Visible = false;
                chkSelectAll.Visible = false;
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            _VamPardakhtiId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
            total = new List<long>();
            FillDataGridRizeAghsatVam();

        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);

        }
        List<long> total = new List<long>();
        private void gridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);

            int rowIndex = e.ListSourceRowIndex;
            long MablaghAghsat = Convert.ToInt64(gridView2.GetListSourceRowCellValue(rowIndex, "MablaghAghsat"));
            long MablaghDaryafti = Convert.ToInt64(gridView2.GetListSourceRowCellValue(rowIndex, "MablaghDaryafti"));
            if (e.Column.FieldName != "Mande") return;
            if (e.IsGetData)
            {
                if (rowIndex == 0)
                {
                    total.Add(MablaghAghsat - MablaghDaryafti);
                    e.Value = total[rowIndex];

                }
                else
                {
                    total.Add(total[rowIndex - 1] + MablaghAghsat - MablaghDaryafti);
                    e.Value = total[rowIndex];
                }

            }

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit1_Click(null, null);
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEdit1_Click(null, null);
            }

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            btnEdit2_Click(null, null);
        }

        private void btnEdit2_Click(object sender, EventArgs e)
        {
            if (gridView2.SelectedRowsCount > 0)
            {
                int ColumnMablaghDaryafti = Convert.ToInt32(gridView2.GetFocusedRowCellValue("MablaghDaryafti"));
                if (ColumnMablaghDaryafti > 0)
                {
                    XtraMessageBox.Show("مبلغ قسط مورد نظر قبلاً دریافت شده است لذا قابل ویرایش نیست \nجهت ویرایش بایستی در ابتدا مبلغ قسط دریافت شده از طریق منوی (دریافت پس انداز ماهیانه و اقساط وام) حذف شود ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    return;
                }
                else
                {
                    FrmRizAghsatVam fm = new FrmRizAghsatVam(this);
                    fm.En = EnumCED.Edit;
                    fm.EditRowIndex = gridView2.FocusedRowHandle;
                    //fm.IDSandogh.Text = IDSandogh.Text;
                    fm.ShowDialog();
                }
            }
        }

        private void gridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEdit2_Click(null, null);
            }
        }

        private void btnLast2_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveLast(gridView2);

        }

        private void btnNext2_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveNext(gridView2);

        }

        private void btnPreview2_Click(object sender, EventArgs e)
        {
            HelpClass1.MovePrev(gridView2);

        }

        private void btnFirst2_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveFirst(gridView2);

        }

        public void btnDisplyActiveList2_Click(object sender, EventArgs e)
        {
            FillDataGridRizeAghsatVam();
        }

        public void btnCreate2_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                FrmRizAghsatVam fm = new FrmRizAghsatVam(this);
                fm.En = EnumCED.Create;
                //fm.IDSandogh.Text = IDSandogh.Text;
                fm.ShowDialog();
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gridView2.SelectedRowsCount > 0)
            {
                int ColumnSum = 0;
                if (chkSelectAll.Checked)
                {
                    if (XtraMessageBox.Show("آیا همه اقساط وام جاری شوند؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ColumnSum = Convert.ToInt32(gridView2.Columns["MablaghDaryafti"].SummaryItem.SummaryValue);
                        if (ColumnSum != 0)
                        {
                            XtraMessageBox.Show("تعدادی از اقساط قبلاً دریافت شده اند لذا قابل حذف نیستند \nجهت حذف اقساط بایستی در ابتدا مبلغ اقساط دریافت شده از طریق منوی (دریافت پس انداز ماهیانه و اقساط وام) حذف شوند ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                            return;
                        }
                        else
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int VamId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.RizeAghsatVams.Where(p => p.VamPardakhtiId == VamId).ToList();
                                    if (q.Count() > 0)
                                    {
                                        db.RizeAghsatVams.RemoveRange(q);
                                        db.SaveChanges();
                                        btnDisplyActiveList2_Click(null, null);
                                        //XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (XtraMessageBox.Show("آیا قسط مورد نظر حذف شود؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (Convert.ToInt32(gridView2.GetFocusedRowCellValue("MablaghDaryafti")) > 0)
                        {
                            XtraMessageBox.Show("قسط مورد نظر قبلاً دریافت شده است لذا قابل حذف نیست \nجهت حذف بایستی در ابتدا مبلغ قسط دریافت شده از طریق منوی (دریافت پس انداز ماهیانه و اقساط وام) حذف شود ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                            return;
                        }
                        else
                        {
                            EditRowIndex = gridView2.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridView2.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.RizeAghsatVams.FirstOrDefault(p => p.Id == RowId);
                                    if (q != null)
                                    {
                                        db.RizeAghsatVams.Remove(q);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();

                                        btnDisplyActiveList2_Click(null, null);
                                        //XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView2.RowCount > 0)
                                            gridView2.FocusedRowHandle = EditRowIndex - 1;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //catch (DbUpdateException)
                                //{
                                //    XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این وام مقدور نیست \n" +
                                //        "جهت حذف وام مورد نظر در ابتدا بایستی ریز اقساط وام مذکور حذف گردد"
                                //        , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //}
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                gridView2.OptionsSelection.MultiSelect = true;
                gridView2.SelectAll();
            }
            else
            {
                gridView2.OptionsSelection.MultiSelect = false;
                //gridView2.UnSelectCells(0, ColLine, gridView2.TopRowIndex, colMablaghAghsat);
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (ListTasviyeNashode == false)
            //{
            //    btnCreate2.Visible = false;
            //    btnDelete2.Visible = false;
            //    btnEdit2.Visible = false;
            //    chkSelectAll.Visible = false;
            //}
        }

        private void gridView2_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            HelpClass1.gridView_CustomSummaryCalculate(sender, e, gridView2, "MablaghAghsat", "MablaghDaryafti", "Mande");

        }


        /// <summary>
        /// ////////////////////////چاپ قرارداد وام///////////////////////
        /// </summary>
        string FilePath = string.Empty;
        string DatePardakht = string.Empty;
        string NameSandogh = string.Empty;
        string ModirSandogh = string.Empty;
        string AdressSandogh = string.Empty;
        string ShTell = string.Empty;
        string NameVFamil = string.Empty;
        string NamePedar = string.Empty;
        string CodeMelli = string.Empty;
        string AdressShakhs = string.Empty;
        string ShMobile = string.Empty;
        string MablaghVam = string.Empty;
        string Date1 = string.Empty;
        string Date2 = string.Empty;
        string MablaghKarmozd = string.Empty;
        string DarsadKarmozd = string.Empty;
        string FasleAghsat = string.Empty;
        string TedadeAghsat = string.Empty;
        string MablaghGhestAval = string.Empty;
        string MablaghDirkard = string.Empty;
        string Zamenin = string.Empty;
        string NoeSanad1 = "..........";
        string Shcheak1 = ".................";
        string MablaghTazmin1 = ".................";
        string NoeSanad2 = "..........";
        string Shcheak2 = ".................";
        string MablaghTazmin2 = ".................";
        string NoeSanad3 = "..........";
        string Shcheak3 = ".................";
        string MablaghTazmin3 = ".................";
        string NoeSanad4 = "..........";
        string Shcheak4 = ".................";
        string MablaghTazmin4 = ".................";
        string NoeSanad5 = "..........";
        string Shcheak5 = ".................";
        string MablaghTazmin5 = ".................";
        string NoeSanad6 = "..........";
        string Shcheak6 = ".................";
        string MablaghTazmin6 = ".................";
        string NoeSanad7 = "..........";
        string Shcheak7 = ".................";
        string MablaghTazmin7 = ".................";
        string NoeSanad8 = "..........";
        string Shcheak8 = ".................";
        string MablaghTazmin8 = ".................";
        string NoeSanad9 = "..........";
        string Shcheak9 = ".................";
        string MablaghTazmin9 = ".................";
        string NoeSanad10 = "..........";
        string Shcheak10 = ".................";
        string MablaghTazmin10 = ".................";
        string NahveyeDaryaftKarmozd = string.Empty;

        //تابع یه ورودی از جنس رشته داره
        public string Reverse(string input)
        {
            ////رشته را با متد زیر به آرایه ایی از کاراکتر ها تبدیل میکنه
            //char[] chars = input.ToCharArray();
            ////آرایه را معکوس میکنه
            //Array.Reverse(chars);
            ////آرایه معکوس شده را به رشته تبدیل میکنه
            //return new String(chars);
            string s = input.Substring(0, 4);
            string m = input.Substring(5, 2);
            string d = input.Substring(8, 2);
            string smd = d + "/" + m + "/" + s;
            return smd;
        }
        public void GetInfoForWord()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int IdSandogh = Convert.ToInt32(Fm.IDSandogh.Caption);
                    int IdShakhs = Convert.ToInt32(gridView1.GetFocusedRowCellValue("AazaId"));
                    int IdVam = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                    var q1 = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == IdShakhs).Id2;
                    var q2 = db.AazaSandoghs.FirstOrDefault(f => f.Id == q1);
                    var q3 = db.RizeAghsatVams.Where(f => f.VamPardakhtiId == IdVam).Max(f => f.TarikhSarresid);
                    var q4 = db.TarifSandoghs.FirstOrDefault(f => f.Id == IdSandogh);
                    DatePardakht = !string.IsNullOrEmpty(gridView1.GetFocusedRowCellDisplayText("TarikhPardakht")) ? Reverse(gridView1.GetFocusedRowCellDisplayText("TarikhPardakht")) : "....................";
                    NameVFamil = !string.IsNullOrEmpty(gridView1.GetFocusedRowCellDisplayText("NameAaza")) ? gridView1.GetFocusedRowCellDisplayText("NameAaza") : "....................";
                    NamePedar = q2 != null && !string.IsNullOrEmpty(q2.NamePedar) ? q2.NamePedar : "...............";
                    CodeMelli = q2 != null && !string.IsNullOrEmpty(q2.CodeMelli) ? q2.CodeMelli : ".........................";
                    AdressShakhs = q2 != null ? !string.IsNullOrEmpty(q2.AdressManzel) ? q2.AdressManzel : !string.IsNullOrEmpty(q2.AdressMohalKar) ? q2.AdressMohalKar : "......................................................" : "......................................................";
                    ShMobile = q2 != null ? !string.IsNullOrEmpty(q2.Mobile1) ? q2.Mobile1 : !string.IsNullOrEmpty(q2.Mobile2) ? q2.Mobile2 : "........................." : ".........................";
                    Date1 = !string.IsNullOrEmpty(gridView1.GetFocusedRowCellDisplayText("SarresidAvalinGhest")) ? Reverse(gridView1.GetFocusedRowCellDisplayText("SarresidAvalinGhest")) : "....................";
                    Date2 = q3 != null ? Reverse(q3.ToString().Substring(0, 10)) : "....................";
                    MablaghVam = !string.IsNullOrEmpty(gridView1.GetFocusedRowCellDisplayText("MablaghAsli")) ? gridView1.GetFocusedRowCellDisplayText("MablaghAsli") : "....................";
                    MablaghKarmozd = !string.IsNullOrEmpty(gridView1.GetFocusedRowCellDisplayText("MablaghKarmozd")) ? gridView1.GetFocusedRowCellDisplayText("MablaghKarmozd") : "....................";
                    DarsadKarmozd = MablaghVam != "0" && MablaghKarmozd != "0" ? (Convert.ToInt32(MablaghVam.Replace(",", "")) / Convert.ToInt32(MablaghKarmozd.Replace(",", ""))).ToString() : "...........";
                    FasleAghsat = !string.IsNullOrEmpty(gridView1.GetFocusedRowCellDisplayText("FaseleAghsat")) ? gridView1.GetFocusedRowCellDisplayText("FaseleAghsat") : "....................";
                    TedadeAghsat = !string.IsNullOrEmpty(gridView1.GetFocusedRowCellDisplayText("TedadAghsat")) ? gridView1.GetFocusedRowCellDisplayText("TedadAghsat") : "..........";
                    MablaghGhestAval = !string.IsNullOrEmpty(gridView1.GetFocusedRowCellDisplayText("MablaghAghsat")) ? gridView1.GetFocusedRowCellDisplayText("MablaghAghsat") : "....................";
                    MablaghDirkard = !string.IsNullOrEmpty(gridView1.GetFocusedRowCellDisplayText("MablaghDirkard")) ? gridView1.GetFocusedRowCellDisplayText("MablaghDirkard") : ".............";
                    Zamenin = !string.IsNullOrEmpty(gridView1.GetFocusedRowCellDisplayText("ZameninName")) ? gridView1.GetFocusedRowCellDisplayText("ZameninName") : ".........................";
                    var q6 = db.VamPardakhtis.Any(f => f.checkEdit1 == true && f.Id == IdVam);
                    if (q6)
                        NahveyeDaryaftKarmozd = "که این مبلغ بصورت یکجا و قبل از پرداخت وام به وام گیرنده از محل اصل وام کسر و فقط اصل مبلغ وام قسط بندی گردیده است";
                    else
                        NahveyeDaryaftKarmozd = "که این مبلغ به همراه اصل مبلغ وام قسط بندی و پرداخت خواهد گردید";


                    NameSandogh = q4 != null && !string.IsNullOrEmpty(q4.NameSandogh) ? q4.NameSandogh : "..............................";
                    ModirSandogh = q4 != null && !string.IsNullOrEmpty(q4.NameModir) ? q4.NameModir : "..............................";
                    AdressSandogh = q4 != null && !string.IsNullOrEmpty(q4.Adress) ? q4.Adress : "..................................................";
                    ShTell = q4 != null ? !string.IsNullOrEmpty(q4.Tell) ? q4.Tell : !string.IsNullOrEmpty(q4.Mobile) ? q4.Mobile : "........................" : "........................";

                    NoeSanad1 = "..........";
                    Shcheak1 = ".................";
                    MablaghTazmin1 = ".................";
                    NoeSanad2 = "..........";
                    Shcheak2 = ".................";
                    MablaghTazmin2 = ".................";
                    NoeSanad3 = "..........";
                    Shcheak3 = ".................";
                    MablaghTazmin3 = ".................";
                    NoeSanad4 = "..........";
                    Shcheak4 = ".................";
                    MablaghTazmin4 = ".................";
                    NoeSanad5 = "..........";
                    Shcheak5 = ".................";
                    MablaghTazmin5 = ".................";
                    NoeSanad6 = "..........";
                    Shcheak6 = ".................";
                    MablaghTazmin6 = ".................";
                    NoeSanad7 = "..........";
                    Shcheak7 = ".................";
                    MablaghTazmin7 = ".................";
                    NoeSanad8 = "..........";
                    Shcheak8 = ".................";
                    MablaghTazmin8 = ".................";
                    NoeSanad9 = "..........";
                    Shcheak9 = ".................";
                    MablaghTazmin9 = ".................";
                    NoeSanad10 = "..........";
                    Shcheak10 = ".................";
                    MablaghTazmin10 = ".................";

                    var q5 = db.CheckTazmins.Where(f => f.VamGerandeId == IdShakhs && f.IsInSandogh == true).ToList();
                    if (q5.Count > 0)
                        switch (q5.Count)
                        {
                            case 1:
                                {
                                    for (int i = 1; i < q5.Count + 1; i++)
                                    {
                                        if (i == 1)
                                        {
                                            NoeSanad1 = q5[i - 1].NoeSanad;
                                            Shcheak1 = q5[i - 1].ShCheck;
                                            MablaghTazmin1 = q5[i - 1].Mablagh.ToString("n0");
                                        }
                                        else if (i == 2)
                                        {
                                            NoeSanad2 = q5[i - 1].NoeSanad;
                                            Shcheak2 = q5[i - 1].ShCheck;
                                            MablaghTazmin2 = q5[i - 1].Mablagh.ToString("n0");
                                        }
                                        else if (i == 3)
                                        {
                                            NoeSanad3 = q5[i - 1].NoeSanad;
                                            Shcheak3 = q5[i - 1].ShCheck;
                                            MablaghTazmin3 = q5[i - 1].Mablagh.ToString("n0");
                                        }
                                        else if (i == 4)
                                        {
                                            NoeSanad4 = q5[i - 1].NoeSanad;
                                            Shcheak4 = q5[i - 1].ShCheck;
                                            MablaghTazmin4 = q5[i - 1].Mablagh.ToString("n0");
                                        }
                                        else if (i == 5)
                                        {
                                            NoeSanad5 = q5[i - 1].NoeSanad;
                                            Shcheak5 = q5[i - 1].ShCheck;
                                            MablaghTazmin5 = q5[i - 1].Mablagh.ToString("n0");
                                        }
                                        else if (i == 6)
                                        {
                                            NoeSanad6 = q5[i - 1].NoeSanad;
                                            Shcheak6 = q5[i - 1].ShCheck;
                                            MablaghTazmin6 = q5[i - 1].Mablagh.ToString("n0");
                                        }
                                        else if (i == 7)
                                        {
                                            NoeSanad7 = q5[i - 1].NoeSanad;
                                            Shcheak7 = q5[i - 1].ShCheck;
                                            MablaghTazmin7 = q5[i - 1].Mablagh.ToString("n0");
                                        }
                                        else if (i == 8)
                                        {
                                            NoeSanad8 = q5[i - 1].NoeSanad;
                                            Shcheak8 = q5[i - 1].ShCheck;
                                            MablaghTazmin8 = q5[i - 1].Mablagh.ToString("n0");
                                        }
                                        else if (i == 9)
                                        {
                                            NoeSanad9 = q5[i - 1].NoeSanad;
                                            Shcheak9 = q5[i - 1].ShCheck;
                                            MablaghTazmin9 = q5[i - 1].Mablagh.ToString("n0");
                                        }
                                        else if (i == 10)
                                        {
                                            NoeSanad10 = q5[i - 1].NoeSanad;
                                            Shcheak10 = q5[i - 1].ShCheck;
                                            MablaghTazmin10 = q5[i - 1].Mablagh.ToString("n0");
                                        }
                                        else
                                            return;
                                    }
                                    break;
                                }
                            case 2:
                                goto case 1;
                            case 3:
                                goto case 1;
                            case 4:
                                goto case 1;
                            case 5:
                                goto case 1;
                            case 6:
                                goto case 1;
                            case 7:
                                goto case 1;
                            case 8:
                                goto case 1;
                            case 9:
                                goto case 1;
                            case 10:
                                goto case 1;

                            default:
                                {
                                    XtraMessageBox.Show("تعداد اسناد تضمینی شخص مورد نظر بیشتر از 10 فقره می باشد\n لذا فقط میتوان مشخصات 10 فقره آنرا در متن قرارداد ذکر نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    goto case 1;
                                }

                        }
                    //else
                    //{
                    //    NoeSanad1 = "..........";
                    //    Shcheak1 = ".................";
                    //    MablaghTazmin1 = ".................";
                    //    NoeSanad2 = "..........";
                    //    Shcheak2 = ".................";
                    //    MablaghTazmin2 = ".................";
                    //    NoeSanad3 = "..........";
                    //    Shcheak3 = ".................";
                    //    MablaghTazmin3 = ".................";
                    //    NoeSanad4 = "..........";
                    //    Shcheak4 = ".................";
                    //    MablaghTazmin4 = ".................";
                    //    NoeSanad5 = "..........";
                    //    Shcheak5 = ".................";
                    //    MablaghTazmin5 = ".................";
                    //    NoeSanad6 = "..........";
                    //    Shcheak6 = ".................";
                    //    MablaghTazmin6 = ".................";
                    //    NoeSanad7 = "..........";
                    //    Shcheak7 = ".................";
                    //    MablaghTazmin7 = ".................";
                    //    NoeSanad8 = "..........";
                    //    Shcheak8 = ".................";
                    //    MablaghTazmin8 = ".................";
                    //    NoeSanad9 = "..........";
                    //    Shcheak9 = ".................";
                    //    MablaghTazmin9 = ".................";
                    //    NoeSanad10 = "..........";
                    //    Shcheak10 = ".................";
                    //    MablaghTazmin10 = ".................";

                    //}
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void btnGharardad_Click(object sender, EventArgs e)
        {
            btnGharardad.Enabled = false;
            GetInfoForWord();
            //  create offer letter
            try
            {
                FilePath = Application.StartupPath + @"\Report\Gharardad";
                //  Just to kill WINWORD.EXE if it is running
                KillProcess("winword");
                //  copy letter format to temp.doc
                File.Copy(FilePath + @"\Gharardade_Org.doc", FilePath + @"\Gharardade_Temp.doc", true);
                //File.Copy(@"D:\Kamal Projects\Sandogh\Sandogh TG N1\Sandogh_PG\Sandogh_PG\bin\Debug\Report\Gharardade.docx", "c:\\temp.docx", true);
                //File.Copy("D:\\Gharardade.docx", "D:\\temp.doc", true);
                //  create missing object
                object missing = Missing.Value;
                //  create Word application object
                Word.Application wordApp = new Word.Application();
                //  create Word document object
                Word.Document aDoc = null;
                //  create & define filename object with temp.doc
                object filename = FilePath + @"\Gharardade_Temp.doc";
                //  if temp.doc available
                if (File.Exists((string)filename))
                {
                    object readOnly = false;
                    object isVisible = false;
                    //  make visible Word application
                    wordApp.Visible = false;
                    //  open Word document named temp.doc
                    aDoc = wordApp.Documents.Open(ref filename, ref missing,
                                                  ref readOnly, ref missing, ref missing, ref missing,
                                                  ref missing, ref missing, ref missing, ref missing,
                                                  ref missing, ref isVisible, ref missing, ref missing,
                                                  ref missing, ref missing);
                    aDoc.Activate();
                    //  Call FindAndReplace()function for each change
                    this.FindAndReplace(wordApp, "<DatePardakht>", DatePardakht.Trim());
                    this.FindAndReplace(wordApp, "<NameVFamil>", NameVFamil.Trim());
                    this.FindAndReplace(wordApp, "<NamePedar>", NamePedar.Trim());
                    this.FindAndReplace(wordApp, "<CodeMelli>", CodeMelli.Trim());
                    this.FindAndReplace(wordApp, "<AdressShakhs>", AdressShakhs.Trim());
                    this.FindAndReplace(wordApp, "<ShMobile>", ShMobile.Trim());
                    this.FindAndReplace(wordApp, "<Date1>", Date1.Trim());
                    this.FindAndReplace(wordApp, "<Date2>", Date2.Trim());
                    this.FindAndReplace(wordApp, "<MablaghVam>", MablaghVam.Trim());
                    this.FindAndReplace(wordApp, "<MablaghKarmozd>", MablaghKarmozd.Trim());
                    this.FindAndReplace(wordApp, "<DarsadKarmozd>", DarsadKarmozd.Trim());
                    this.FindAndReplace(wordApp, "<FasleAghsat>", FasleAghsat.Trim());
                    this.FindAndReplace(wordApp, "<TedadeAghsat>", TedadeAghsat.Trim());
                    this.FindAndReplace(wordApp, "<MablaghGhestAval>", MablaghGhestAval.Trim());
                    this.FindAndReplace(wordApp, "<MablaghDirkard>", MablaghDirkard.Trim());
                    this.FindAndReplace(wordApp, "<Zamenin>", Zamenin.Trim());
                    this.FindAndReplace(wordApp, "<NameSandogh>", NameSandogh.Trim());
                    this.FindAndReplace(wordApp, "<ModirSandogh>", ModirSandogh.Trim());
                    this.FindAndReplace(wordApp, "<AdressSandogh>", AdressSandogh.Trim());
                    this.FindAndReplace(wordApp, "<ShTell>", ShTell.Trim());
                    this.FindAndReplace(wordApp, "<NoeSanad1>", NoeSanad1.Trim());
                    this.FindAndReplace(wordApp, "<Shcheak1>", Shcheak1.Trim());
                    this.FindAndReplace(wordApp, "<MablaghTazmin1>", MablaghTazmin1.Trim());
                    this.FindAndReplace(wordApp, "<NoeSanad2>", NoeSanad2.Trim());
                    this.FindAndReplace(wordApp, "<Shcheak2>", Shcheak2.Trim());
                    this.FindAndReplace(wordApp, "<MablaghTazmin2>", MablaghTazmin2.Trim());
                    this.FindAndReplace(wordApp, "<NoeSanad3>", NoeSanad3.Trim());
                    this.FindAndReplace(wordApp, "<Shcheak3>", Shcheak3.Trim());
                    this.FindAndReplace(wordApp, "<MablaghTazmin3>", MablaghTazmin3.Trim());
                    this.FindAndReplace(wordApp, "<NoeSanad4>", NoeSanad4.Trim());
                    this.FindAndReplace(wordApp, "<Shcheak4>", Shcheak4.Trim());
                    this.FindAndReplace(wordApp, "<MablaghTazmin4>", MablaghTazmin4.Trim());
                    this.FindAndReplace(wordApp, "<NoeSanad5>", NoeSanad5.Trim());
                    this.FindAndReplace(wordApp, "<Shcheak5>", Shcheak5.Trim());
                    this.FindAndReplace(wordApp, "<MablaghTazmin5>", MablaghTazmin5.Trim());
                    this.FindAndReplace(wordApp, "<NoeSanad6>", NoeSanad6.Trim());
                    this.FindAndReplace(wordApp, "<Shcheak6>", Shcheak6.Trim());
                    this.FindAndReplace(wordApp, "<MablaghTazmin6>", MablaghTazmin6.Trim());
                    this.FindAndReplace(wordApp, "<NoeSanad7>", NoeSanad7.Trim());
                    this.FindAndReplace(wordApp, "<Shcheak7>", Shcheak7.Trim());
                    this.FindAndReplace(wordApp, "<MablaghTazmin7>", MablaghTazmin7.Trim());
                    this.FindAndReplace(wordApp, "<NoeSanad8>", NoeSanad8.Trim());
                    this.FindAndReplace(wordApp, "<Shcheak8>", Shcheak8.Trim());
                    this.FindAndReplace(wordApp, "<MablaghTazmin8>", MablaghTazmin8.Trim());
                    this.FindAndReplace(wordApp, "<NoeSanad9>", NoeSanad9.Trim());
                    this.FindAndReplace(wordApp, "<Shcheak9>", Shcheak9.Trim());
                    this.FindAndReplace(wordApp, "<MablaghTazmin9>", MablaghTazmin9.Trim());
                    this.FindAndReplace(wordApp, "<NoeSanad10>", NoeSanad10.Trim());
                    this.FindAndReplace(wordApp, "<Shcheak10>", Shcheak10.Trim());
                    this.FindAndReplace(wordApp, "<MablaghTazmin10>", MablaghTazmin10.Trim());
                    this.FindAndReplace(wordApp, "<NahveyeDaryaftKarmozd>", NahveyeDaryaftKarmozd.Trim());
                    //  save temp.doc after modified
                    aDoc.Save();
                    KillProcess("winword");

                }
                else
                    XtraMessageBox.Show("فایل  موقت Gharardade_Temp یافت نشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                //XtraMessageBox.Show("عملیات با خطا مواجه شد", "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnGharardad.Enabled = true;
            OpenFilWord();
        }

        private void FindAndReplace(Word.Application wordApp, object findText, object replaceText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            wordApp.Selection.Find.Execute(ref findText, ref matchCase,
                ref matchWholeWord, ref matchWildCards, ref matchSoundsLike,
                ref matchAllWordForms, ref forward, ref wrap, ref format,
                ref replaceText, ref replace, ref matchKashida,
                        ref matchDiacritics,
                ref matchAlefHamza, ref matchControl);
        }

        public static void KillProcess(string name)
        {
            Process[] pr = Process.GetProcessesByName(name);

            foreach (Process prs in pr)
            {
                if (prs.ProcessName.ToLower() == name)
                {
                    prs.Kill();
                }
            }
        }

        private void OpenFilWord()
        {
            //Document doc = new Document();
            //doc.LoadFromFile(FilePath + @"\Gharardade_Org.doc",FileFormat.Doc);
            try
            {
                Word.Application ap = new Word.Application();
                ap.Visible = true;
                object miss = Missing.Value;
                object path = FilePath + @"\Gharardade_Temp.doc";
                object readOnly = false;
                object isVisible = true;
                Word.Document doc = new Word.Document();
                doc = ap.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref isVisible, ref miss, ref miss, ref miss, ref miss);
                doc.Activate();
                //Word.Application ap = new Word.Application();
                //Word.Document document = ap.Documents.Open(FilePath + @"\Gharardade_Temp.doc",);

            }
            catch //(Exception)
            {
                //doc.Application.Quit(ref missing, ref missing, ref missing);
                //throw;
            }
        }

        private void FrmListVamhayePardakhti_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                foreach (var file in Directory.GetFiles(FilePath, "*.tmp", SearchOption.AllDirectories))
                {
                    File.Delete(file);
                }
            }
        }

        string FilePath1 = Application.StartupPath + @"\Report\Ghozareshat\";
        string FileName1 = "rptListVamha.repx";
        string FileName2 = "rptRizVamha.repx";

        private void btnPrintPreview1_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(FilePath1 + FileName1))
            {
                if (gridView1.RowCount > 0)
                {
                    XtraReport XtraReport1 = new XtraReport();
                    XtraReport1.LoadLayoutFromXml(FilePath1 + FileName1);

                    // XtraReport1.DataSource = HelpClass1.ConvettDatagridviewToDataSet(gridView1);
                    XtraReport1.DataSource = gridView1.DataSource;

                    //XtraReport1.Parameters["Az_Tarikh"].Value = ChkTarikh.Checked ? txtAzTarikh.Text : gridView2.GetRowCellDisplayText(0, "Tarikh").Substring(0, 10);
                    //XtraReport1.Parameters["Ta_Tarikh"].Value = ChkTarikh.Checked ? txtTaTarikh.Text : DateTime.Now.ToString().Substring(0, 10);
                    XtraReport1.Parameters["TarikhVSaat"].Value = DateTime.Now;
                    //XtraReport1.Parameters["HesabMoin"].Value = _HesabMoin;
                    //XtraReport1.Parameters["HesabTafzil"].Value = cmbHesabTafzili.Text;
                    XtraReport1.Parameters["ReportName"].Value = groupBox4.Text;
                    XtraReport1.Parameters["SandoghName"].Value = Fm.ribbonControl1.ApplicationDocumentCaption;

                    //List<decimal> ListMande1 = new List<decimal>();
                    //for (int i = 0; i < gridView1.RowCount; i++)
                    //{
                    //    ListMande1.Add(Convert.ToDecimal(gridView2.GetRowCellValue(i, "Mande1")));
                    //}
                    //XtraReport1.Parameters["Mande1"].Value = ListMande1;
                    FrmPrinPreview FPP = new FrmPrinPreview();
                    FPP.documentViewer1.DocumentSource = XtraReport1;
                    FPP.RepotPageWidth = 130;
                    FPP.ShowDialog();

                }
            }
            else
            {
                HelpClass1.NewReportDesigner(FilePath1, FileName1);
            }
        }

        private void btnDesignReport1_Click(object sender, EventArgs e)
        {
            HelpClass1.LoadReportDesigner(FilePath1, FileName1);
        }

        private void btnPrintPreview2_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(FilePath1 + FileName2))
            {
                if (gridView2.RowCount > 0)
                {
                    XtraReport XtraReport1 = new XtraReport();
                    XtraReport1.LoadLayoutFromXml(FilePath1 + FileName2);

                    XtraReport1.DataSource = HelpClass1.ConvettDatagridviewToDataSet(gridView2);
                    XtraReport1.Parameters["TarikhVSaat"].Value = DateTime.Now;
                    XtraReport1.Parameters["SandoghName"].Value = Fm.ribbonControl1.ApplicationDocumentCaption;
                    XtraReport1.Parameters["NameAaza"].Value = gridView1.GetFocusedRowCellDisplayText("NameAaza");
                    XtraReport1.Parameters["ShomareSanad"].Value = gridView1.GetFocusedRowCellDisplayText("ShomareSanad");
                    XtraReport1.Parameters["NahveyePardakht"].Value = gridView1.GetFocusedRowCellDisplayText("NahveyePardakht");
                    XtraReport1.Parameters["NoeVam"].Value = gridView1.GetFocusedRowCellDisplayText("NoeVam");
                    XtraReport1.Parameters["DarsadeKarmozd"].Value = gridView1.GetFocusedRowCellDisplayText("DarsadeKarmozd");
                    XtraReport1.Parameters["MablaghDirkard"].Value = gridView1.GetFocusedRowCellDisplayText("MablaghDirkard");
                    XtraReport1.Parameters["TarikhDarkhast"].Value = gridView1.GetFocusedRowCellDisplayText("TarikhDarkhast");
                    XtraReport1.Parameters["ShomareDarkhast"].Value = gridView1.GetFocusedRowCellDisplayText("ShomareDarkhast");
                    XtraReport1.Parameters["Code"].Value = gridView1.GetFocusedRowCellDisplayText("Code");
                    XtraReport1.Parameters["TarikhPardakht"].Value = gridView1.GetFocusedRowCellDisplayText("TarikhPardakht");
                    XtraReport1.Parameters["MablaghAsli"].Value = gridView1.GetFocusedRowCellDisplayText("MablaghAsli");
                    XtraReport1.Parameters["MablaghKarmozd"].Value = gridView1.GetFocusedRowCellDisplayText("MablaghKarmozd");
                    XtraReport1.Parameters["FaseleAghsat"].Value = gridView1.GetFocusedRowCellDisplayText("FaseleAghsat");
                    XtraReport1.Parameters["TedadAghsat"].Value = gridView1.GetFocusedRowCellDisplayText("TedadAghsat");
                    XtraReport1.Parameters["MablaghAghsat"].Value = gridView1.GetFocusedRowCellDisplayText("MablaghAghsat");
                    XtraReport1.Parameters["SarresidAvalinGhest"].Value = gridView1.GetFocusedRowCellDisplayText("SarresidAvalinGhest");
                    XtraReport1.Parameters["ZameninName"].Value = gridView1.GetFocusedRowCellDisplayText("ZameninName");
                    XtraReport1.Parameters["HaveCheckTazmin"].Value = gridView1.GetFocusedRowCellDisplayText("HaveCheckTazmin");

                    
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
                    FrmPrinPreview FPP = new FrmPrinPreview();
                    FPP.documentViewer1.DocumentSource = XtraReport1;
                    FPP.ShowDialog();

                }
            }
            else
            {
                HelpClass1.NewReportDesigner(FilePath1, FileName2);
            }
        }

        private void btnDesignReport2_Click(object sender, EventArgs e)
        {
            HelpClass1.LoadReportDesigner(FilePath1, FileName2);
        }

        private void FrmListVamhayePardakhti_KeyDown(object sender, KeyEventArgs e)
        {
            HelpClass1.ControlAltShift_KeyDown(sender, e, btnDesignReport1);
            HelpClass1.ControlAltShift_KeyDown(sender, e, btnDesignReport2);
        }

        private void gridView2_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.RowCount > 0)
            {
                // bool IsActive = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "IsActive"));
                int ShomareSanad = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "ShomareSanad"));
                int Mande = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "Mande"));

                if (ShomareSanad == 0 || (ShomareSanad > 0 && Mande == 0))
                {
                    return;
                    //Color foreColor = Color.Black;
                    //e.Appearance.ForeColor = foreColor;
                }
                else if (ShomareSanad > 0 && Mande > 0)
                {
                    Color foreColor = Color.Red;
                    e.Appearance.ForeColor = foreColor;
                    e.Appearance.BackColor = Color.Yellow;
                }

            }

        }
    }
}