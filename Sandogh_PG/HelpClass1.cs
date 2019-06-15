using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Data.SqlClient;

namespace Sandogh_PG
{
    public class HelpClass1
    {
        //تنظیم EditMask تکس باکس تاریخ
        //RightToLeft=No
        //RegEx
        //([1-9][3-9][0-9][0-9])/(((0[1-6])/([012][1-9]|[123]0|31))|((0[7-9]|1[01])/([012][1-9]|[123]0))|((1[2])/([012][1-9])))
        //Show Placeholdes=true


        public static void AddZerooToTextBox(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+')
            {
                TextEdit TextEdit1 = (TextEdit)sender;
                if (TextEdit1 == null) return;
                TextEdit1.Text = TextEdit1.Text + "000";
            }
            //else if (e.KeyChar == '-')
            //{
            //    TextEdit TextEdit1 = (TextEdit)sender;
            //    if (TextEdit1 == null) return;
            //    string Text1 = TextEdit1.Text.Replace("-", "+");
            //    string Text2 = Text1 + "00";
            //    TextEdit1.Text = Text2.Replace("-", "+");
            //}
        }
        public static void SwitchToPersianLanguage()
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.CreateSpecificCulture("fa-IR"));
        }
        public static void SetRegionAndLanguage()
        {
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);

            ///Set Values
            regkey.SetValue("iCalendarType", "1");
            regkey.SetValue("iCountry", "981");
            regkey.SetValue("iCurrDigits", "0");
            regkey.SetValue("iCurrency", "2");
            regkey.SetValue("iDate", "2");
            regkey.SetValue("iDigits", "0");
            regkey.SetValue("iFirstDayOfWeek", "5");
            regkey.SetValue("iFirstWeekOfYear", "0");
            regkey.SetValue("iLocale", "00000429");
            regkey.SetValue("iLocaleName", "fa-IR");
            regkey.SetValue("iLZero", "1");
            regkey.SetValue("iMeasure", "0");
            regkey.SetValue("iNegCurr", "3");
            regkey.SetValue("iNegNumber", "3");
            regkey.SetValue("iNumShape", "0");
            regkey.SetValue("iPaperSize", "9");
            regkey.SetValue("iTime", "0");
            regkey.SetValue("iTimePrefix", "0");
            regkey.SetValue("iTLZero", "1");
            regkey.SetValue("Locale", "00000429");
            regkey.SetValue("LocaleName", "fa-IR");
            regkey.SetValue("iNumShape", "0");
            regkey.SetValue("s1159", "ق.ظ");
            regkey.SetValue("s2359", "ب.ظ");
            regkey.SetValue("sCountry", "Iran");
            regkey.SetValue("sCurrency", " ");
            regkey.SetValue("sDate", "/");
            regkey.SetValue("sDecimal", ".");
            regkey.SetValue("sGrouping", "3;0");
            regkey.SetValue("sLanguage", "FAR");
            regkey.SetValue("sList", ";");
            regkey.SetValue("sLongDate", "yyyy/MM/dd");
            regkey.SetValue("sMonDecimalSep", "/");
            regkey.SetValue("sMonGrouping", "3;0");
            regkey.SetValue("sMonThousandSep", ",");
            regkey.SetValue("sNativeDigits", "۰۱۲۳۴۵۶۷۸۹");
            regkey.SetValue("sNegativeSign", "-");
            regkey.SetValue("sPositiveSign", "");
            regkey.SetValue("sShortDate", "yyyy/MM/dd");
            regkey.SetValue("sShortTime", "hh:mm tt");
            regkey.SetValue("sThousand", ",");
            regkey.SetValue("sTime", ":");
            regkey.SetValue("sTimeFormat", "hh:mm:ss tt");
            regkey.SetValue("sYearMonth", "MMMM,yyyy");

            //Close the Registry
            regkey.Close();

            /////////////////////////////////////////////////////////////////
            //Get Data From Text Boxes

            //string DateFormat = txtDateFormat.Text.Trim();

            //string TimeFormat = txtTimeFormat.Text.Trim();

            //string Currency = txtCurrency.Text.Trim();



            //Registry Logic

            //Open Sub key

            //RegistryKey rkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);



            ///Set Values

            //rkey.SetValue("sTimeFormat", TimeFormat);

            //rkey.SetValue("sShortDate", DateFormat);

            //rkey.SetValue("sCurrency", Currency);



            //Close the Registry

            //rkey.Close();
            /////////////////////////////////////////////////////////////
        }
        public static void StartCalculater()
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }
        public static void StartWordPad()
        {
            System.Diagnostics.Process.Start("WordPad.exe");
        }
        public static void StartNotePad()
        {
            System.Diagnostics.Process.Start("NotePad.exe");
        }
        public static void MoveLast(GridView gridView)
        {
            gridView.MoveLast();
        }
        public static void MoveNext(GridView gridView)
        {
            gridView.MoveNext();
        }
        public static void MovePrev(GridView gridView)
        {
            gridView.MovePrev();
        }
        public static void MoveFirst(GridView gridView)
        {
            gridView.MoveFirst();
        }

        #region عملیات مربوط به PictuerBox
        //private void btnBrowse_Click(object sender, EventArgs e)
        //{
        //    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
        //        return;
        //    pictureBox1.ImageLocation = openFileDialog1.FileName;
        //}

        //string copyPictuer(string sourcefile, string key)
        //{
        //    if (sourcefile == "")
        //        return null;
        //    string curentPath;
        //    string newPath;
        //    curentPath = Application.StartupPath + @"\image\";
        //    if (Directory.Exists(curentPath) == false)
        //    {
        //        Directory.CreateDirectory(curentPath);
        //    }

        //    newPath = curentPath + key + sourcefile.Substring(sourcefile.LastIndexOf("."));
        //    if (File.Exists(newPath))
        //    {
        //        File.Delete(newPath);
        //    }
        //    File.Copy(sourcefile, newPath);
        //    return newPath;
        //}

        //private Region r = new Region();
        //private void pictureBox1_Click(object sender, EventArgs e)
        //{
        //    if (pictureBox1.SizeMode == PictureBoxSizeMode.StretchImage)
        //    {
        //        r = pictureBox1.Region;
        //        pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        //    }
        //    else
        //    {
        //        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        //        pictureBox1.Region = r;
        //    }
        //}

        //private void pictureBox1_MouseLeave(object sender, EventArgs e)
        //{
        //    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        //    pictureBox1.Region = r;

        //}

        //private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    r = pictureBox1.Region;
        //    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

        //}
        #endregion

        public static void PrintPreview(GridControl gridControl1, GridView gridView1)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                // Check whether the GridControl can be previewed.
                if (!gridControl1.IsPrintingAvailable)
                {
                    XtraMessageBox.Show("کتابخانه XtraPrinting پیدا نشد", "خطا");
                    return;
                }
                // Open the Preview window.
                gridView1.ShowPrintPreview();
            }
        }

        public static void SetNumberRowsColumnUnboundGirdView(object sender, CustomColumnDataEventArgs e)
        {
            GridView view = (GridView)sender;
            if (view == null) return;
            int rowHandle = view.GetRowHandle(e.ListSourceRowIndex);
            //int visibleIndex = view.GetVisibleIndex(rowHandle);
            //if (e.IsSetData) return;
            if (e.Column.FieldName == "Line")
                e.Value = rowHandle + 1;
            //if (e.Column.FieldName == "gridColumnVisibleIndex")
            //    e.Value = visibleIndex;
            //if (e.Column.FieldName == "gridColumnListSourceIndex")
            //    e.Value = e.ListSourceRowIndex;

        }

        public static void gridView_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e, GridView gridView1, string Bed = "Bed", string Bes = "Bes", string Mande = "Mande")
        {
            if (gridView1.RowCount == 0)
                return;

            decimal SumBed = Convert.ToDecimal(gridView1.Columns[Bed].SummaryItem.SummaryValue);
            decimal SumBes = Convert.ToDecimal(gridView1.Columns[Bes].SummaryItem.SummaryValue);
            decimal _Mande = SumBed - SumBes;

            var item = e.Item as GridColumnSummaryItem;

            if (item == null || item.FieldName != Mande)
                return;

            if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                e.TotalValue = _Mande;
        }

        public static List<decimal> Result2;
        public static int IndexAkharinDaruaft = -1;
        public static void gridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e, GridView gridView1, string Bed = "Bed", string Bes = "Bes", string Mande = "Mande")
        {
            if (gridView1.RowCount == 0)
                return;

            SetNumberRowsColumnUnboundGirdView(sender, e);
            int rowIndex = e.ListSourceRowIndex;
            decimal bed = Convert.ToDecimal(gridView1.GetListSourceRowCellValue(rowIndex, Bed));
            decimal bes = Convert.ToDecimal(gridView1.GetListSourceRowCellValue(rowIndex, Bes));
            if (e.Column.FieldName != Mande) return;
            if (e.IsGetData)
            {
                if (rowIndex == 0)
                {
                    Result2.Add(bed - bes);
                    e.Value = Result2[rowIndex];
                    if (Convert.ToDecimal(e.Value) == 0)
                    {
                        IndexAkharinDaruaft = rowIndex;
                    }
                }
                else
                {
                    Result2.Add(Result2[rowIndex - 1] + bed - bes);
                    e.Value = Result2[rowIndex];
                    if (Convert.ToDecimal(e.Value) == 0)
                    {
                        IndexAkharinDaruaft = rowIndex;
                    }
                }
            }

        }

        public static void ControlAltShift_KeyDown(object sender, KeyEventArgs e, params Control[] btn)
        {
            if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.F12)
            {
                for (int i = 0; i < btn.Length; i++)
                {
                    btn[i].Visible = btn[i].Visible == true ? false : true;
                }
            }
        }

        public static void LoadReportDesigner(string FilePath, string FileName)
        {
            if (System.IO.File.Exists(FilePath + FileName))
            {
                //ساخت فرم طراحی گزارش و ارسال فرم طراحی شده قبلی به فرم طراحی جهت ویرایش
                FrmReportDesigner frd = new FrmReportDesigner();
                frd.reportDesigner1.OpenReport(FilePath + FileName);
                frd.Show();

            }
            else
            {
                NewReportDesigner(FilePath, FileName);
            }
        }

        public static void NewReportDesigner(string FilePath, string FileName)
        {
            XtraMessageBox.Show("چاپ فوق قبلاً طراحی نشده است لذا در صورت طراحی چاپ ، فایل مربوطه را با نام " + FileName + " در مسیر \n" + FilePath + " ذخیره فرمایید.", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            //ساخت فرم طراحی گزارش و ارسال فرم طراحی شده قبلی به فرم طراحی جهت ویرایش
            XtraReport XtraReport1 = new XtraReport();
            XtraReport1.DisplayName = FileName;
            XtraReport1.PaperName = FileName;
            XtraReport1.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            XtraReport1.Name = FileName;
            //XtraReport1.PrinterName = FileName;
            XtraReport1.Margins = new System.Drawing.Printing.Margins(25, 25, 25, 25);
            FrmReportDesigner frd = new FrmReportDesigner();
            frd.reportDesigner1.OpenReport(XtraReport1);
            frd.Show();


        }

        public static DataSet ConvettDatagridviewToDataSet(GridView gridView)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            for (int ColumnCounter = 0; ColumnCounter < gridView.Columns.Count; ColumnCounter++)
                dt.Columns.Add(gridView.Columns[ColumnCounter].FieldName);

            for (int RowCounter = 0; RowCounter < gridView.RowCount; RowCounter++)
            {
                DataRow DataRow1 = dt.NewRow();
                for (int j = 0; j < gridView.Columns.Count; j++)
                {
                    //DataRow1[j] = gridView.Rows[RowCounter].Cells[j].Value.ToString();
                    DataRow1[j] = gridView.GetRowCellDisplayText(RowCounter, gridView.Columns[j]);
                }
                dt.Rows.Add(DataRow1);
            }
            ds.Tables.Add(dt);
            return ds;
        }

        /////Encryption یا رمزنگاری
        public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        /////Decryption یا رمزگشایی
        public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;


            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        /////خب حالا باید دو تا void درست کنیم تا Encrypt و Decrypt را ساده تر برامون انجام دهند.
        ///ابتدا void مربوط به Encrypt
        public static string EncryptText(string input, string password = "km113012")
        {
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }

        ///////سپس void دوم یا Decrypt همانند زیر می شود.
        ///نحوه استفاده از آن هم بسیار ساده است متد ها هرکدام دو مقدار ورودی دارد که اولی استرینگ است که می خواهید کد شود و دومی کلید شما است.
        public static string DecryptText(string input, string password = "km113012")
        {
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            string result = Encoding.UTF8.GetString(bytesDecrypted);

            return result;
        }

        ////////////////////////////جلوگیری از خارج شدن برنامه //////////////////////////////////////
        public static void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("آیا میخواهید از برنامه خارج شود ؟", "پیغام ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
                return;
                // Application.OpenForms["FrmMain"].Activate();
            }
            else
            {
                SqlConnection.ClearAllPools();
                Application.ExitThread();
                Application.Exit();
            }
        }


        //public static void LoadReportDesigner1(string FilePath, string FileName)
        //{
        //    if (System.IO.File.Exists(FilePath + FileName))
        //    {
        //        StiReport str = new StiReport();
        //        str.Load(FilePath + FileName);
        //        StiDesigner stiDesigner = new StiDesigner();
        //        stiDesigner.Report = str;
        //        stiDesigner.ShowDialogDesigner();


        //        ////ساخت فرم طراحی گزارش و ارسال فرم طراحی شده قبلی به فرم طراحی جهت ویرایش
        //        //FrmReportDesigner frd = new FrmReportDesigner();
        //        //frd.reportDesigner1.OpenReport(FilePath + FileName);
        //        //frd.Show();

        //        //StiReport str = new StiReport();
        //        //str.Load(FilePath + FileName);
        //        //str.RegBusinessObject("rptRizDaryafti", gridView2.SourceView);
        //        //str.Dictionary.Variables["Az_Tarikh"].Value = ChkTarikh.Checked ? txtAzTarikh.Text : gridView1.GetRowCellDisplayText(0, "Tarikh").Substring(0, 10);
        //        //str.Dictionary.Variables["Ta_Tarikh"].Value = ChkTarikh.Checked ? txtTaTarikh.Text : gridView1.GetRowCellDisplayText(gridView1.RowCount - 1, "Tarikh").Substring(0, 10);
        //        //str.Dictionary.Variables["TarikhVSaat"].ValueObject = DateTime.Now;
        //        //str.Compile();
        //        //str.ShowWithRibbonGUI();

        //    }
        //    else
        //    {
        //        NewReportDesigner1(FilePath, FileName);
        //    }
        //}

        //public static void NewReportDesigner1(string FilePath, string FileName)
        //{
        //    ////ساخت فرم طراحی گزارش و ارسال فرم طراحی شده قبلی به فرم طراحی جهت ویرایش
        //    //XtraReport XtraReport1 = new XtraReport();
        //    //XtraReport1.DisplayName = FileName;
        //    //FrmReportDesigner frd = new FrmReportDesigner();
        //    //frd.reportDesigner1.OpenReport(XtraReport1);
        //    //frd.Show();

        //    XtraMessageBox.Show("چاپ فوق قبلاً طراحی نشده است لذا در صورت طراحی چاپ ، فایل مربوطه را با نام " + FileName + " در مسیر \n" + FilePath + " ذخیره فرمایید.", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
        //    StiReport str = new StiReport();
        //    StiDesigner stiDesigner = new StiDesigner();
        //    stiDesigner.Report = str;
        //    stiDesigner.ShowDialogDesigner();
        //}


    }


    ///////////////////////// طراحی - پیش نمایش و چاپ گزارشات ////////////////////////////////
    //ساخت فرم طراحی گزارش و ارسال فرم طراحی شده قبلی به فرم طراحی جهت ویرایش
    //FrmReportDesigner frd = new FrmReportDesigner();
    // frd.reportDesigner1.OpenReport(new XtraReport1());
    // frd.ShowDialog();

    //ارسال فرم طراحی شده جهت پیش نماش و چاپ
    //ReportPrintTool rt = new ReportPrintTool(new XtraReport1());
    //rt.ShowRibbonPreviewDialog();

    //// ساخت یک فرم پرینت پرویو و ارسال فرم طراحی شده به فرم پرینت پرویو برای نمایش و چاپ
    //XtraReport1 x1 = new XtraReport1();
    //FrmPrintPreview frd = new FrmPrintPreview();
    //frd.documentViewer1.DocumentSource = x1;
    //frd.ShowDialog();

    //////////////////////////// چاپ گزارش در محیط استیمول سافت////////////////////////////
    //StiReport str = new StiReport();
    //str.Load(Application.StartupPath + @"\Report\Ghozareshat\Daftar_Rozname.mrt");
    //str.RegBusinessObject("Daftar_Rozname", gridView1.SourceView);
    //str.Dictionary.Variables["Az_Tarikh"].Value = ChkTarikh.Checked ? txtAzTarikh.Text : gridView1.GetRowCellDisplayText(0, "Tarikh").Substring(0, 10);
    //str.Dictionary.Variables["Ta_Tarikh"].Value = ChkTarikh.Checked ? txtTaTarikh.Text : gridView1.GetRowCellDisplayText(gridView1.RowCount - 1, "Tarikh").Substring(0, 10);
    //str.Dictionary.Variables["TarikhVSaat"].ValueObject = DateTime.Now;
    //str.Compile();
    //str.ShowWithRibbonGUI();

}

public enum EnumCED
{
    Create,
    Edit,
    Delete,
    Save,
    Cancel,
}
public enum SetInitialize
{
    MigrateDatabaseToLatestVersion,
    DropCreateDatabaseAlways,
}

