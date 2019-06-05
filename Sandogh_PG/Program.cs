using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Threading;
using DevExpress.XtraEditors;

namespace Sandogh_PG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //از Mutex برای این استفاده میکنیم که بخواهیم فقط یک نسخه از برنامه روی دسکتاپ اجرا شود
            //bool instance = false;
            //Mutex mtx = new Mutex(true, Application.ProductName, out instance);

            //if (instance)
            //{

            //فعال کردن زبان فارسی در برنامه 
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fa");
            //Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();

            HelpClass1.SwitchToPersianLanguage();
            Cultures.InitializePersianCulture();
            HelpClass1.SetRegionAndLanguage();

            // ساخت پوشه مسیر دایرکتوری فایل کانفیگ
            SkinManager.EnableFormSkins();
            //WindowsFormsSettings.AllowDefaultSvgImages = DevExpress.Utils.DefaultBoolean.False;
            if (!System.IO.Directory.Exists(AppVariable.fileName))
                System.IO.Directory.CreateDirectory(AppVariable.fileName);
            // ساخت پوشه دیتابیس
            if (!System.IO.Directory.Exists(Application.StartupPath + @"\DB"))
                System.IO.Directory.CreateDirectory(Application.StartupPath + @"\DB");
            Application.Run(new AppContext());
            //Application.Run(new FrmMain());


            //    mtx.ReleaseMutex();
            //}
            //else
            //{
            //    XtraMessageBox.Show("برنامه صندوق در حال اجرا است");
            //}

        }
        public class AppContext : ApplicationContext
        {
            public AppContext()
            {
                Application.Idle += new EventHandler(Application_Idle);
                //new FrmMain().Show();
                new FrmLogin().ShowDialog();
            }

            private void Application_Idle(object sender, EventArgs e)
            {
                if (Application.OpenForms.Count == 0)
                {
                    Application.Exit();
                }
            }
        }
    }
}
