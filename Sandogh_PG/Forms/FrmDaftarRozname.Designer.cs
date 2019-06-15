namespace Sandogh_PG
{
    partial class FrmDaftarRozname
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDaftarRozname));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnDesignReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintPreview = new DevExpress.XtraEditors.SimpleButton();
            this.ChkTarikh = new DevExpress.XtraEditors.CheckEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtTaTarikh = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtAzTarikh = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
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
            this.colSharh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChkTarikh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaTarikh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAzTarikh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asnadeHesabdariRowsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnDesignReport);
            this.panelControl1.Controls.Add(this.btnPrintPreview);
            this.panelControl1.Controls.Add(this.ChkTarikh);
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Controls.Add(this.txtTaTarikh);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtAzTarikh);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1525, 59);
            this.panelControl1.TabIndex = 0;
            // 
            // btnDesignReport
            // 
            this.btnDesignReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesignReport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDesignReport.ImageOptions.SvgImage")));
            this.btnDesignReport.Location = new System.Drawing.Point(854, 9);
            this.btnDesignReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnDesignReport.Name = "btnDesignReport";
            this.btnDesignReport.Size = new System.Drawing.Size(46, 41);
            this.btnDesignReport.TabIndex = 37;
            this.btnDesignReport.ToolTip = "چاپ لیست";
            this.btnDesignReport.Visible = false;
            this.btnDesignReport.Click += new System.EventHandler(this.btnDesignReport_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrintPreview.ImageOptions.SvgImage")));
            this.btnPrintPreview.Location = new System.Drawing.Point(908, 9);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(46, 41);
            this.btnPrintPreview.TabIndex = 3;
            this.btnPrintPreview.ToolTip = "نمایش چاپ";
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // ChkTarikh
            // 
            this.ChkTarikh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChkTarikh.Location = new System.Drawing.Point(1499, 11);
            this.ChkTarikh.Margin = new System.Windows.Forms.Padding(4);
            this.ChkTarikh.Name = "ChkTarikh";
            this.ChkTarikh.Properties.Caption = "checkEdit1";
            this.ChkTarikh.Size = new System.Drawing.Size(20, 35);
            this.ChkTarikh.TabIndex = 0;
            this.ChkTarikh.TabStop = false;
            this.ChkTarikh.Visible = false;
            this.ChkTarikh.CheckedChanged += new System.EventHandler(this.ChkTarikh_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSearch.ImageOptions.SvgImage")));
            this.btnSearch.Location = new System.Drawing.Point(962, 9);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 41);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.ToolTip = "F7";
            this.btnSearch.ToolTipTitle = "لیست فعال";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtTaTarikh
            // 
            this.txtTaTarikh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaTarikh.EnterMoveNextControl = true;
            this.txtTaTarikh.Location = new System.Drawing.Point(1016, 10);
            this.txtTaTarikh.Margin = new System.Windows.Forms.Padding(4);
            this.txtTaTarikh.Name = "txtTaTarikh";
            this.txtTaTarikh.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTaTarikh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtTaTarikh.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtTaTarikh.Properties.Mask.BeepOnError = true;
            this.txtTaTarikh.Properties.Mask.EditMask = "([1-9][3-9][0-9][0-9])/(((0[1-6])/([012][1-9]|[123]0|31))|((0[7-9]|1[01])/([012][" +
    "1-9]|[123]0))|((1[2])/([012][1-9])))";
            this.txtTaTarikh.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtTaTarikh.Properties.Mask.PlaceHolder = '-';
            this.txtTaTarikh.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTaTarikh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTaTarikh.Size = new System.Drawing.Size(159, 38);
            this.txtTaTarikh.TabIndex = 1;
            this.txtTaTarikh.EditValueChanged += new System.EventHandler(this.txtTaTarikh_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.AutoEllipsis = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(1182, 10);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 40);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "تا تاریخ";
            // 
            // txtAzTarikh
            // 
            this.txtAzTarikh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAzTarikh.EnterMoveNextControl = true;
            this.txtAzTarikh.Location = new System.Drawing.Point(1257, 9);
            this.txtAzTarikh.Margin = new System.Windows.Forms.Padding(4);
            this.txtAzTarikh.Name = "txtAzTarikh";
            this.txtAzTarikh.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAzTarikh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtAzTarikh.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtAzTarikh.Properties.Mask.BeepOnError = true;
            this.txtAzTarikh.Properties.Mask.EditMask = "([1-9][3-9][0-9][0-9])/(((0[1-6])/([012][1-9]|[123]0|31))|((0[7-9]|1[01])/([012][" +
    "1-9]|[123]0))|((1[2])/([012][1-9])))";
            this.txtAzTarikh.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtAzTarikh.Properties.Mask.PlaceHolder = '-';
            this.txtAzTarikh.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtAzTarikh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAzTarikh.Size = new System.Drawing.Size(159, 38);
            this.txtAzTarikh.TabIndex = 0;
            this.txtAzTarikh.EditValueChanged += new System.EventHandler(this.txtAzTarikh_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.AutoEllipsis = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(1423, 9);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 40);
            this.labelControl2.TabIndex = 32;
            this.labelControl2.Text = "از تاریخ";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.asnadeHesabdariRowsBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1521, 608);
            this.gridControl1.TabIndex = 33;
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
            this.colBes,
            this.colSharh});
            this.gridView1.DetailHeight = 434;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 31;
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
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 23;
            this.colId.Name = "colId";
            this.colId.Width = 92;
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
            this.Line.MinWidth = 23;
            this.Line.Name = "Line";
            this.Line.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Line", "{0}")});
            this.Line.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.Line.Visible = true;
            this.Line.VisibleIndex = 0;
            this.Line.Width = 86;
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
            this.colShomareSanad.MinWidth = 24;
            this.colShomareSanad.Name = "colShomareSanad";
            this.colShomareSanad.Visible = true;
            this.colShomareSanad.VisibleIndex = 1;
            this.colShomareSanad.Width = 110;
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
            this.colTarikh.MinWidth = 24;
            this.colTarikh.Name = "colTarikh";
            this.colTarikh.Visible = true;
            this.colTarikh.VisibleIndex = 2;
            this.colTarikh.Width = 134;
            // 
            // colCodeMoin
            // 
            this.colCodeMoin.FieldName = "HesabMoinCode";
            this.colCodeMoin.MinWidth = 24;
            this.colCodeMoin.Name = "colCodeMoin";
            this.colCodeMoin.Width = 92;
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
            this.colMoinName.MinWidth = 24;
            this.colMoinName.Name = "colMoinName";
            this.colMoinName.Visible = true;
            this.colMoinName.VisibleIndex = 3;
            this.colMoinName.Width = 159;
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
            this.colHesabTafCode.MinWidth = 24;
            this.colHesabTafCode.Name = "colHesabTafCode";
            this.colHesabTafCode.Visible = true;
            this.colHesabTafCode.VisibleIndex = 4;
            this.colHesabTafCode.Width = 122;
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
            this.colHesabTafName.MinWidth = 24;
            this.colHesabTafName.Name = "colHesabTafName";
            this.colHesabTafName.Visible = true;
            this.colHesabTafName.VisibleIndex = 5;
            this.colHesabTafName.Width = 367;
            // 
            // colBed
            // 
            this.colBed.AppearanceCell.Options.UseTextOptions = true;
            this.colBed.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBed.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colBed.AppearanceHeader.Options.UseTextOptions = true;
            this.colBed.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBed.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colBed.Caption = "مبلغ بدهکار";
            this.colBed.DisplayFormat.FormatString = "n";
            this.colBed.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBed.FieldName = "Bed";
            this.colBed.MinWidth = 24;
            this.colBed.Name = "colBed";
            this.colBed.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Bed", "{0:n}")});
            this.colBed.Visible = true;
            this.colBed.VisibleIndex = 6;
            this.colBed.Width = 171;
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
            this.colBes.MinWidth = 24;
            this.colBes.Name = "colBes";
            this.colBes.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Bes", "{0:n}")});
            this.colBes.Visible = true;
            this.colBes.VisibleIndex = 7;
            this.colBes.Width = 171;
            // 
            // colSharh
            // 
            this.colSharh.AppearanceCell.Options.UseTextOptions = true;
            this.colSharh.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSharh.AppearanceHeader.Options.UseTextOptions = true;
            this.colSharh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSharh.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSharh.Caption = "شرح سند";
            this.colSharh.FieldName = "Sharh";
            this.colSharh.MinWidth = 24;
            this.colSharh.Name = "colSharh";
            this.colSharh.Visible = true;
            this.colSharh.VisibleIndex = 8;
            this.colSharh.Width = 489;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 59);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1525, 612);
            this.panelControl2.TabIndex = 34;
            // 
            // FrmDaftarRozname
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1525, 671);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmDaftarRozname";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دفتر روزنامه";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDaftarRozname_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDaftarRozname_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChkTarikh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaTarikh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAzTarikh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asnadeHesabdariRowsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn Line;
        private DevExpress.XtraGrid.Columns.GridColumn colShomareSanad;
        private DevExpress.XtraGrid.Columns.GridColumn colTarikh;
        private DevExpress.XtraGrid.Columns.GridColumn colHesabTafName;
        private DevExpress.XtraGrid.Columns.GridColumn colBed;
        private DevExpress.XtraGrid.Columns.GridColumn colSharh;
        private System.Windows.Forms.BindingSource asnadeHesabdariRowsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colHesabTafCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBes;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeMoin;
        private DevExpress.XtraGrid.Columns.GridColumn colMoinName;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtTaTarikh;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtAzTarikh;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.CheckEdit ChkTarikh;
        private DevExpress.XtraEditors.SimpleButton btnPrintPreview;
        private DevExpress.XtraEditors.SimpleButton btnDesignReport;
    }
}