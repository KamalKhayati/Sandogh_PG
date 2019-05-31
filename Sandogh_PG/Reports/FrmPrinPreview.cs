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

namespace Sandogh_PG
{
    public partial class FrmPrinPreview : DevExpress.XtraEditors.XtraForm
    {
        public FrmPrinPreview()
        {
            InitializeComponent();
        }

       public int RepotPageWidth = 180;
        private void FrmPrinPreview_Load(object sender, EventArgs e)
        {
            bbiZoom.EditValue = RepotPageWidth;
        }
    }
}