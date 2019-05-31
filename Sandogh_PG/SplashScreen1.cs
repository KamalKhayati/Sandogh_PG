using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using nucs.JsonSettings;
using nucs.JsonSettings.Fluent;

namespace Sandogh_PG
{
    public partial class SplashScreen1 : SplashScreen
    {

        public SplashScreen1()
        {
            InitializeComponent();
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            //txtbox1.Text = p.GetYear(DateTime.Now).ToString() + "/" + p.GetMonth(DateTime.Now).ToString("0#")
            //        + "/" + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            this.labelControl1.Text = "Copyright © 1397-" + p.GetYear(DateTime.Now).ToString();
            //this.labelControl1.Text = "Copyright © 1397-" + DateTime.Now.Year.ToString() ;

        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
    }
}