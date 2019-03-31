using Sandogh_TG.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sandogh_TG
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnTarifSandogh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTarifSandogh fm = new FrmTarifSandogh();
            fm.ShowDialog();
        }

        private void btnTarifHesabBanki_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTarifHesabBanki fm = new FrmTarifHesabBanki();
            fm.ShowDialog();

        }

        private void btnTarifAaza_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTarifAaza fm = new FrmTarifAaza();
            fm.ShowDialog();

        }
    }
}
