using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_TG
{
   public class AppVariable
    {
        // مسیر دایکتوری ذخیره فایل کانفیگ 
        public static string fileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + @"\" + Assembly.GetExecutingAssembly().GetName().Name;

        //#region Setting Keys

        public static string SkinName = "Skin";
        //public static string ConnectionPath = "dbConnection";

    }
}
