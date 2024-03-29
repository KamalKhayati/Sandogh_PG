﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sandogh_PG
{
    public class Cultures
    {
        public static void InitializePersianCulture()
        {
            try
            {
                InitializeCulture("fa-ir", new[] { "ی", "د", "س", "چ", "پ", "ج", "ش" },
                          new[] { "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" },
                          new[]
                              {
                                      "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی",
                                      "بهمن", "اسفند", ""
                              },
                          new[]
                              {
                                      "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی",
                                      "بهمن", "اسفند", ""
                              }, "ق.ظ. ", "ب.ظ. ", "yyyy/MM/dd", new PersianCalendar());

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> InitializePersianCulture()" + "\n" + ex.Message,
                    "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void InitializeCulture(string culture, string[] abbreviatedDayNames, string[] dayNames,
                                             string[] abbreviatedMonthNames, string[] monthNames, string amDesignator,
                                             string pmDesignator, string shortDatePattern, Calendar calendar)
        {
            try
            {
                var calture = new CultureInfo(culture);
                var info = calture.DateTimeFormat;
                info.AbbreviatedDayNames = abbreviatedDayNames;
                info.DayNames = dayNames;
                info.AbbreviatedMonthNames = abbreviatedMonthNames;
                info.MonthNames = monthNames;
                info.AMDesignator = amDesignator;
                info.PMDesignator = pmDesignator;
                info.ShortDatePattern = shortDatePattern;
                info.FirstDayOfWeek = DayOfWeek.Saturday;
                var cal = calendar;
                var type = typeof(DateTimeFormatInfo);
                var fieldInfo = type.GetField("calendar", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
                if (fieldInfo != null)
                    fieldInfo.SetValue(info, cal);
                var field = typeof(CultureInfo).GetField("calendar", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
                if (field != null)
                    field.SetValue(calture, cal);
                Thread.CurrentThread.CurrentCulture = calture;
                Thread.CurrentThread.CurrentUICulture = calture;
                CultureInfo.CurrentCulture.DateTimeFormat = info;
                CultureInfo.CurrentUICulture.DateTimeFormat = info;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> InitializeCulture()" + "\n" + ex.Message,
                    "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
