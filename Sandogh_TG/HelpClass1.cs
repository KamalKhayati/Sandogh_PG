using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sandogh_TG
{
    public class HelpClass1
    {
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

        public static void SetNumberRowsColumnUnboundGirdView(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
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

    }

    public enum EnumCED
    {
        Create,
        Edit,
        Delete,
        Save,
        Cancel,
    }

}
