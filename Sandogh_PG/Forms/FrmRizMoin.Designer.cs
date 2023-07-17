namespace Sandogh_PG
{
    partial class FrmRizMoin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRizMoin));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.asnadeHesabdariRowsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Line = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShomareSanad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarikh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeMoin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoinName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHesabTafCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHesabTafName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnDesignReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintPreview = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asnadeHesabdariRowsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.asnadeHesabdariRowsBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(0, 47);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(850, 544);
            this.gridControl1.TabIndex = 36;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // asnadeHesabdariRowsBindingSource
            // 
            this.asnadeHesabdariRowsBindingSource.DataSource = typeof(Sandogh_PG.AsnadeHesabdariRow);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.Line,
            this.colShomareSanad,
            this.colTarikh,
            this.colCodeMoin,
            this.colMoinName,
            this.colHesabTafCode,
            this.colHesabTafName,
            this.colBed,
            this.colBes});
            this.gridView1.DetailHeight = 378;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 28;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AllowFindPanel = false;
            this.gridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gridView1.OptionsFind.FindNullPrompt = "متنی برای جستجو تایپ کنید ...";
            this.gridView1.OptionsMenu.ShowFooterItem = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 21;
            this.colId.Name = "colId";
            this.colId.Width = 84;
            // 
            // Line
            // 
            this.Line.AppearanceCell.Options.UseTextOptions = true;
            this.Line.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Line.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Line.AppearanceHeader.Options.UseTextOptions = true;
            this.Line.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Line.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Line.Caption = "ردیف";
            this.Line.FieldName = "Line";
            this.Line.MinWidth = 21;
            this.Line.Name = "Line";
            this.Line.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Line", "{0}")});
            this.Line.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.Line.Visible = true;
            this.Line.VisibleIndex = 0;
            this.Line.Width = 78;
            // 
            // colShomareSanad
            // 
            this.colShomareSanad.AppearanceCell.Options.UseTextOptions = true;
            this.colShomareSanad.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShomareSanad.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colShomareSanad.AppearanceHeader.Options.UseTextOptions = true;
            this.colShomareSanad.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShomareSanad.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colShomareSanad.Caption = "شماره سند";
            this.colShomareSanad.FieldName = "ShomareSanad";
            this.colShomareSanad.MinWidth = 22;
            this.colShomareSanad.Name = "colShomareSanad";
            this.colShomareSanad.Width = 100;
            // 
            // colTarikh
            // 
            this.colTarikh.AppearanceCell.Options.UseTextOptions = true;
            this.colTarikh.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarikh.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTarikh.AppearanceHeader.Options.UseTextOptions = true;
            this.colTarikh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarikh.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTarikh.Caption = "تاریخ";
            this.colTarikh.FieldName = "Tarikh";
            this.colTarikh.MinWidth = 22;
            this.colTarikh.Name = "colTarikh";
            this.colTarikh.Width = 122;
            // 
            // colCodeMoin
            // 
            this.colCodeMoin.AppearanceCell.Options.UseTextOptions = true;
            this.colCodeMoin.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeMoin.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCodeMoin.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeMoin.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeMoin.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCodeMoin.Caption = "کد معین";
            this.colCodeMoin.FieldName = "HesabMoinCode";
            this.colCodeMoin.MinWidth = 22;
            this.colCodeMoin.Name = "colCodeMoin";
            this.colCodeMoin.Width = 136;
            // 
            // colMoinName
            // 
            this.colMoinName.AppearanceCell.Options.UseTextOptions = true;
            this.colMoinName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMoinName.AppearanceHeader.Options.UseTextOptions = true;
            this.colMoinName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMoinName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMoinName.Caption = "شرح معین";
            this.colMoinName.FieldName = "HesabMoinName";
            this.colMoinName.MinWidth = 22;
            this.colMoinName.Name = "colMoinName";
            this.colMoinName.Width = 273;
            // 
            // colHesabTafCode
            // 
            this.colHesabTafCode.AppearanceCell.Options.UseTextOptions = true;
            this.colHesabTafCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHesabTafCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colHesabTafCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colHesabTafCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHesabTafCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colHesabTafCode.Caption = "کد تفضیلی";
            this.colHesabTafCode.FieldName = "HesabTafCode";
            this.colHesabTafCode.MinWidth = 22;
            this.colHesabTafCode.Name = "colHesabTafCode";
            this.colHesabTafCode.Visible = true;
            this.colHesabTafCode.VisibleIndex = 1;
            this.colHesabTafCode.Width = 111;
            // 
            // colHesabTafName
            // 
            this.colHesabTafName.AppearanceCell.Options.UseTextOptions = true;
            this.colHesabTafName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colHesabTafName.AppearanceHeader.Options.UseTextOptions = true;
            this.colHesabTafName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHesabTafName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colHesabTafName.Caption = "نام حساب";
            this.colHesabTafName.FieldName = "HesabTafName";
            this.colHesabTafName.MinWidth = 22;
            this.colHesabTafName.Name = "colHesabTafName";
            this.colHesabTafName.Visible = true;
            this.colHesabTafName.VisibleIndex = 2;
            this.colHesabTafName.Width = 409;
            // 
            // colBed
            // 
            this.colBed.AppearanceCell.Options.UseTextOptions = true;
            this.colBed.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBed.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colBed.AppearanceHeader.Options.UseTextOptions = true;
            this.colBed.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBed.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colBed.Caption = "مانده حساب";
            this.colBed.DisplayFormat.FormatString = "n";
            this.colBed.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBed.FieldName = "Bed";
            this.colBed.MinWidth = 22;
            this.colBed.Name = "colBed";
            this.colBed.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Bed", "{0:n}")});
            this.colBed.Visible = true;
            this.colBed.VisibleIndex = 3;
            this.colBed.Width = 191;
            // 
            // colBes
            // 
            this.colBes.AppearanceCell.Options.UseTextOptions = true;
            this.colBes.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBes.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colBes.AppearanceHeader.Options.UseTextOptions = true;
            this.colBes.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBes.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colBes.Caption = "مبلغ بستانکار";
            this.colBes.DisplayFormat.FormatString = "n";
            this.colBes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBes.FieldName = "Bes";
            this.colBes.MinWidth = 22;
            this.colBes.Name = "colBes";
            this.colBes.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Bes", "{0:n}")});
            this.colBes.Width = 155;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnDesignReport);
            this.panelControl1.Controls.Add(this.btnPrintPreview);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(850, 47);
            this.panelControl1.TabIndex = 37;
            // 
            // btnDesignReport
            // 
            this.btnDesignReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesignReport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDesignReport.ImageOptions.SvgImage")));
            this.btnDesignReport.Location = new System.Drawing.Point(748, 5);
            this.btnDesignReport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDesignReport.Name = "btnDesignReport";
            this.btnDesignReport.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnDesignReport.Size = new System.Drawing.Size(47, 40);
            this.btnDesignReport.TabIndex = 43;
            this.btnDesignReport.ToolTip = "طراحی فرم چاپ";
            this.btnDesignReport.Visible = false;
            this.btnDesignReport.Click += new System.EventHandler(this.btnDesignReport_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrintPreview.ImageOptions.SvgImage")));
            this.btnPrintPreview.Location = new System.Drawing.Point(797, 5);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnPrintPreview.Size = new System.Drawing.Size(47, 40);
            this.btnPrintPreview.TabIndex = 0;
            this.btnPrintPreview.ToolTip = "نمایش چاپ";
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // FrmRizMoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 591);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmRizMoin.IconOptions.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmRizMoin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ریز تفضیلی معین";
            this.Load += new System.EventHandler(this.FrmRizMoin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRizMoin_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asnadeHesabdariRowsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn Line;
        private DevExpress.XtraGrid.Columns.GridColumn colShomareSanad;
        private DevExpress.XtraGrid.Columns.GridColumn colTarikh;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeMoin;
        private DevExpress.XtraGrid.Columns.GridColumn colMoinName;
        private DevExpress.XtraGrid.Columns.GridColumn colHesabTafCode;
        private DevExpress.XtraGrid.Columns.GridColumn colHesabTafName;
        private DevExpress.XtraGrid.Columns.GridColumn colBed;
        private DevExpress.XtraGrid.Columns.GridColumn colBes;
        private System.Windows.Forms.BindingSource asnadeHesabdariRowsBindingSource;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnDesignReport;
        private DevExpress.XtraEditors.SimpleButton btnPrintPreview;
    }
}