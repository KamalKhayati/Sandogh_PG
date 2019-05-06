namespace Sandogh_TG
{
    partial class FrmYadavari
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.haghOzviatsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameAaza1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarikh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMablagh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.rizeAghsatVamsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Line = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameAaza = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVamPardakhtiCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShomareGhest = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarikhSarresid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMablaghAghsat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.haghOzviatsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rizeAghsatVamsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(830, 652);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelControl6);
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(826, 648);
            this.panelControl2.TabIndex = 3;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.gridControl2);
            this.panelControl6.Controls.Add(this.panelControl5);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl6.Location = new System.Drawing.Point(2, 336);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(822, 336);
            this.panelControl6.TabIndex = 35;
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.haghOzviatsBindingSource;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl2.Location = new System.Drawing.Point(2, 37);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(818, 297);
            this.gridControl2.TabIndex = 33;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // haghOzviatsBindingSource
            // 
            this.haghOzviatsBindingSource.DataSource = typeof(Sandogh_TG.HaghOzviat);
            // 
            // gridView2
            // 
            this.gridView2.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView2.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.Appearance.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.colNameAaza1,
            this.colTarikh,
            this.colMablagh});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.IndicatorWidth = 25;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsFind.AllowFindPanel = false;
            this.gridView2.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gridView2.OptionsFind.FindNullPrompt = "متنی برای جستجو تایپ کنید ...";
            this.gridView2.OptionsMenu.ShowFooterItem = true;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.RowAutoHeight = true;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView2_CustomUnboundColumnData);
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.MinWidth = 19;
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "ردیف";
            this.gridColumn2.FieldName = "Line";
            this.gridColumn2.MinWidth = 19;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Line", "{0}")});
            this.gridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 70;
            // 
            // colNameAaza1
            // 
            this.colNameAaza1.AppearanceCell.Options.UseTextOptions = true;
            this.colNameAaza1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNameAaza1.AppearanceHeader.Options.UseTextOptions = true;
            this.colNameAaza1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNameAaza1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNameAaza1.Caption = "نام اعضاء";
            this.colNameAaza1.FieldName = "NameAaza";
            this.colNameAaza1.Name = "colNameAaza1";
            this.colNameAaza1.Visible = true;
            this.colNameAaza1.VisibleIndex = 1;
            this.colNameAaza1.Width = 250;
            // 
            // colTarikh
            // 
            this.colTarikh.AppearanceCell.Options.UseTextOptions = true;
            this.colTarikh.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarikh.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTarikh.AppearanceHeader.Options.UseTextOptions = true;
            this.colTarikh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarikh.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTarikh.Caption = "تاریخ آخرین دریافت";
            this.colTarikh.DisplayFormat.FormatString = "d";
            this.colTarikh.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTarikh.FieldName = "Tarikh";
            this.colTarikh.Name = "colTarikh";
            this.colTarikh.Visible = true;
            this.colTarikh.VisibleIndex = 2;
            this.colTarikh.Width = 150;
            // 
            // colMablagh
            // 
            this.colMablagh.AppearanceCell.Options.UseTextOptions = true;
            this.colMablagh.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMablagh.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMablagh.AppearanceHeader.Options.UseTextOptions = true;
            this.colMablagh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMablagh.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMablagh.Caption = "مبلغ آخرین دریافت";
            this.colMablagh.DisplayFormat.FormatString = "n";
            this.colMablagh.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMablagh.FieldName = "Mablagh";
            this.colMablagh.Name = "colMablagh";
            this.colMablagh.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Mablagh", "{0:n}")});
            this.colMablagh.Width = 150;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.labelControl2);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl5.Location = new System.Drawing.Point(2, 2);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(818, 35);
            this.panelControl5.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(168, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(485, 25);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "لیست اعضایی که از آخرین دریافت پس انداز ماهیانه آنها یکماه گذشته است";
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.gridControl1);
            this.panelControl4.Controls.Add(this.panelControl3);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(2, 2);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(822, 334);
            this.panelControl4.TabIndex = 34;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.rizeAghsatVamsBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(2, 37);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(818, 295);
            this.gridControl1.TabIndex = 33;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // rizeAghsatVamsBindingSource
            // 
            this.rizeAghsatVamsBindingSource.DataSource = typeof(Sandogh_TG.RizeAghsatVam);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.Line,
            this.colNameAaza,
            this.colVamPardakhtiCode,
            this.colShomareGhest,
            this.colTarikhSarresid,
            this.colMablaghAghsat});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 25;
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
            this.colId.MinWidth = 19;
            this.colId.Name = "colId";
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
            this.Line.MinWidth = 19;
            this.Line.Name = "Line";
            this.Line.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Line", "{0}")});
            this.Line.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.Line.Visible = true;
            this.Line.VisibleIndex = 0;
            this.Line.Width = 70;
            // 
            // colNameAaza
            // 
            this.colNameAaza.AppearanceCell.Options.UseTextOptions = true;
            this.colNameAaza.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNameAaza.AppearanceHeader.Options.UseTextOptions = true;
            this.colNameAaza.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNameAaza.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNameAaza.Caption = "وام گیرنده";
            this.colNameAaza.FieldName = "NameAaza";
            this.colNameAaza.Name = "colNameAaza";
            this.colNameAaza.Visible = true;
            this.colNameAaza.VisibleIndex = 1;
            this.colNameAaza.Width = 250;
            // 
            // colVamPardakhtiCode
            // 
            this.colVamPardakhtiCode.AppearanceCell.Options.UseTextOptions = true;
            this.colVamPardakhtiCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVamPardakhtiCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colVamPardakhtiCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colVamPardakhtiCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVamPardakhtiCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colVamPardakhtiCode.Caption = "کد وام";
            this.colVamPardakhtiCode.FieldName = "VamPardakhtiCode";
            this.colVamPardakhtiCode.Name = "colVamPardakhtiCode";
            this.colVamPardakhtiCode.Visible = true;
            this.colVamPardakhtiCode.VisibleIndex = 2;
            this.colVamPardakhtiCode.Width = 100;
            // 
            // colShomareGhest
            // 
            this.colShomareGhest.AppearanceCell.Options.UseTextOptions = true;
            this.colShomareGhest.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShomareGhest.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colShomareGhest.AppearanceHeader.Options.UseTextOptions = true;
            this.colShomareGhest.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShomareGhest.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colShomareGhest.Caption = "شماره قسط";
            this.colShomareGhest.FieldName = "ShomareGhest";
            this.colShomareGhest.Name = "colShomareGhest";
            this.colShomareGhest.Visible = true;
            this.colShomareGhest.VisibleIndex = 3;
            this.colShomareGhest.Width = 100;
            // 
            // colTarikhSarresid
            // 
            this.colTarikhSarresid.AppearanceCell.Options.UseTextOptions = true;
            this.colTarikhSarresid.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarikhSarresid.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTarikhSarresid.AppearanceHeader.Options.UseTextOptions = true;
            this.colTarikhSarresid.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarikhSarresid.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTarikhSarresid.Caption = "تاریخ سررسید";
            this.colTarikhSarresid.DisplayFormat.FormatString = "d";
            this.colTarikhSarresid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTarikhSarresid.FieldName = "TarikhSarresid";
            this.colTarikhSarresid.Name = "colTarikhSarresid";
            this.colTarikhSarresid.Visible = true;
            this.colTarikhSarresid.VisibleIndex = 4;
            this.colTarikhSarresid.Width = 120;
            // 
            // colMablaghAghsat
            // 
            this.colMablaghAghsat.AppearanceCell.Options.UseTextOptions = true;
            this.colMablaghAghsat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMablaghAghsat.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMablaghAghsat.AppearanceHeader.Options.UseTextOptions = true;
            this.colMablaghAghsat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMablaghAghsat.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMablaghAghsat.Caption = "مبلغ قسط";
            this.colMablaghAghsat.DisplayFormat.FormatString = "n";
            this.colMablaghAghsat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMablaghAghsat.FieldName = "MablaghAghsat";
            this.colMablaghAghsat.Name = "colMablaghAghsat";
            this.colMablaghAghsat.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MablaghAghsat", "{0:n}")});
            this.colMablaghAghsat.Visible = true;
            this.colMablaghAghsat.VisibleIndex = 5;
            this.colMablaghAghsat.Width = 150;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(818, 35);
            this.panelControl3.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(228, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(321, 25);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "لیست اعضایی که اقساط وام سررسید گذشته دارند";
            // 
            // FrmYadavari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 652);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmYadavari";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم یادآوری روزانه";
            this.Load += new System.EventHandler(this.FrmYadavari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.haghOzviatsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rizeAghsatVamsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        public DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource rizeAghsatVamsBindingSource;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn Line;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colNameAaza;
        private DevExpress.XtraGrid.Columns.GridColumn colVamPardakhtiCode;
        private DevExpress.XtraGrid.Columns.GridColumn colShomareGhest;
        private DevExpress.XtraGrid.Columns.GridColumn colTarikhSarresid;
        private DevExpress.XtraGrid.Columns.GridColumn colMablaghAghsat;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        public DevExpress.XtraGrid.GridControl gridControl2;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private System.Windows.Forms.BindingSource haghOzviatsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTarikh;
        private DevExpress.XtraGrid.Columns.GridColumn colMablagh;
        private DevExpress.XtraGrid.Columns.GridColumn colNameAaza1;
    }
}