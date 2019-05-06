using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;

namespace Sandogh_TG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var db = new MyContext())
            {
                try
                {
                    db.Database.Initialize(true);
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            HelpClass1.SwitchToPersianLanguage();
            Cultures.InitializePersianCulture();
            HelpClass1.SetRegionAndLanguage();

            BonusSkins.Register();
            Application.Run(new AppContext());
        }
        public class AppContext : ApplicationContext
        {
            public AppContext()
            {
                Application.Idle += new EventHandler(Application_Idle);
                //new FrmMain().Show();
                new FrmLogin().Show();
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
