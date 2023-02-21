using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Threading;
using DevExpress.XtraEditors;
using Sandogh_PG.Forms;

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
            try
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

                // ساخت پوشه مسیر دایرکتوری فایل کانفیگ
                SkinManager.EnableFormSkins();
                //WindowsFormsSettings.AllowDefaultSvgImages = DevExpress.Utils.DefaultBoolean.False;
                if (!System.IO.Directory.Exists(AppVariable.fileName))
                    System.IO.Directory.CreateDirectory(AppVariable.fileName);
                // ساخت پوشه دیتابیس
                if (!System.IO.Directory.Exists(Application.StartupPath + @"\DB"))
                    System.IO.Directory.CreateDirectory(Application.StartupPath + @"\DB");


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                BonusSkins.Register();
                //new FrmLogin().Show();
                if (HelpClass1.IsSetGregorianCalendar())
                {
                    Cultures.InitializePersianCulture();
                    Application.Run(new AppContext());
                }
                else
                    Application.Exit();

                //BonusSkins.Register();

                //HelpClass1.SwitchToPersianLanguage();
                //Cultures.InitializePersianCulture();
                //HelpClass1.SetRegionAndLanguage();

                //Application.Run(new AppContext());
                //Application.Run(new FrmMain());


                //    mtx.ReleaseMutex();
                //}
                //else
                //{
                //    XtraMessageBox.Show("برنامه صندوق در حال اجرا است");
                //}


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> Main()" + "\n" + ex.Message,
                    "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public class AppContext : ApplicationContext
        {
            public AppContext()
            {
                try
                {
                    Application.Idle += new EventHandler(Application_Idle);
                    //new FrmMain().Show();
                    new FrmLogin1().ShowDialog();

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> AppContext()" + "\n" + ex.Message,
                        "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void Application_Idle(object sender, EventArgs e)
            {
                try
                {
                    if (Application.OpenForms.Count == 0)
                    {
                        Application.Exit();
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> Application_Idle()" + "\n" + ex.Message,
                         "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
