﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;

namespace Sandogh_PG
{
    public partial class FrmListCheckTazminNazdeSandogh : DevExpress.XtraEditors.XtraForm
    {
        FrmOdatCheckTazmin Fm;
        public FrmListCheckTazminNazdeSandogh(FrmOdatCheckTazmin fm)
        {
            InitializeComponent();
            Fm = fm;
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
            Sandogh_PG.MyContext dbContext = new Sandogh_PG.MyContext();
            // Call the Load method to get the data for the given DbSet from the database.
            dbContext.CheckTazmins.Where(f=>f.IsInSandogh==true).Load();
            // This line of code is generated by Data Source Configuration Wizard
            checkTazminsBindingSource.DataSource = dbContext.CheckTazmins.Local.ToBindingList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                Fm.gridControl1.Enabled = false;
                //EditRowIndex = gridView1.FocusedRowHandle;
                Fm.En = EnumCED.Create;
                Fm.InActiveButtons();
                Fm.ActiveControls();
                Fm.FillcmbVamGerande();
                Fm.txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                Fm.txtSeryalDaryaft.Text = gridView1.GetFocusedRowCellValue("SeryalDaryaft").ToString();
                Fm.txtTarikhDaryaft.Text = gridView1.GetFocusedRowCellValue("TarikhDaryaft").ToString().Substring(0, 10); ;
                Fm.cmbVamGerande.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("VamGerandeId"));
                Fm.cmbNoeSanad.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("NoeSanadId"));
                Fm.txtShCheck.Text = gridView1.GetFocusedRowCellValue("ShCheck").ToString();
                if (gridView1.GetFocusedRowCellValue("TarikhCheck") != null)
                    Fm.txtTarikhCheck.Text = gridView1.GetFocusedRowCellValue("TarikhCheck").ToString().Substring(0, 10);
                Fm.txtMamlaghCheck.Text = gridView1.GetFocusedRowCellValue("Mablagh").ToString();
                Fm.txtShomareHesab.Text = gridView1.GetFocusedRowCellValue("ShomareHesab").ToString();
                Fm.txtNameBankVShobe.Text = gridView1.GetFocusedRowCellValue("NameBank").ToString();
                Fm.txtSahebCheck.Text = gridView1.GetFocusedRowCellValue("SahebCheck").ToString();
                Fm.txtSharhSanad.Text = gridView1.GetFocusedRowCellValue("SharhDaryaftCheck").ToString();
                Fm.txtTarikhOdat.Text = DateTime.Now.ToString().Substring(0, 10);
                Fm.txtTarikhOdat.Focus();
                this.Close();
            }

        }

        private void FrmListCheckTazminNazdeSandogh_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Fm.txtSeryalDaryaft.Text==string.Empty)
            {
                Fm.gridControl1.Enabled = true;
            }
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                gridView1_DoubleClick(null, null);
            }

        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                HelpClass1.ExportDataGridViewToExcel(this,gridView1, gridView1.RowCount);
            }

        }
    }
}