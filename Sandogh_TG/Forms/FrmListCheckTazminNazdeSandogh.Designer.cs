namespace Sandogh_TG
{
    partial class FrmListCheckTazminNazdeSandogh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListCheckTazminNazdeSandogh));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.checkTazminsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Line = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeryalDaryaft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarikhDaryaft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVaziyatCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVamGerandeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoeSanad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarikhCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMablagh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShomareHesab = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameBank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSahebCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSharhDaryaftCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarikhOdatCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSharhOdatCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTazminsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1077, 51);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(131, 12);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(753, 31);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "جهت انتخاب سند تضمینی مورد نظر روی ردیف مربوطه یک بار اینتر و یا دوبار با ماوس کل" +
    "یک کنید";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 51);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1077, 508);
            this.panelControl2.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.checkTazminsBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1073, 504);
            this.gridControl1.TabIndex = 33;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // checkTazminsBindingSource
            // 
            this.checkTazminsBindingSource.DataSource = typeof(Sandogh_TG.CheckTazmin);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.Line,
            this.colSeryalDaryaft,
            this.colTarikhDaryaft,
            this.colVaziyatCheck,
            this.colVamGerandeName,
            this.colNoeSanad,
            this.colShCheck,
            this.colTarikhCheck,
            this.colMablagh,
            this.colShomareHesab,
            this.colNameBank,
            this.colSahebCheck,
            this.colSharhDaryaftCheck,
            this.colTarikhOdatCheck,
            this.colSharhOdatCheck});
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
            this.gridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridView1_KeyPress);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
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
            // colSeryalDaryaft
            // 
            this.colSeryalDaryaft.AppearanceCell.Options.UseTextOptions = true;
            this.colSeryalDaryaft.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSeryalDaryaft.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSeryalDaryaft.AppearanceHeader.Options.UseTextOptions = true;
            this.colSeryalDaryaft.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSeryalDaryaft.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSeryalDaryaft.Caption = "سریال";
            this.colSeryalDaryaft.FieldName = "SeryalDaryaft";
            this.colSeryalDaryaft.MinWidth = 24;
            this.colSeryalDaryaft.Name = "colSeryalDaryaft";
            this.colSeryalDaryaft.Visible = true;
            this.colSeryalDaryaft.VisibleIndex = 1;
            this.colSeryalDaryaft.Width = 104;
            // 
            // colTarikhDaryaft
            // 
            this.colTarikhDaryaft.AppearanceCell.Options.UseTextOptions = true;
            this.colTarikhDaryaft.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarikhDaryaft.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTarikhDaryaft.AppearanceHeader.Options.UseTextOptions = true;
            this.colTarikhDaryaft.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarikhDaryaft.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTarikhDaryaft.Caption = "تاریخ";
            this.colTarikhDaryaft.FieldName = "TarikhDaryaft";
            this.colTarikhDaryaft.MinWidth = 24;
            this.colTarikhDaryaft.Name = "colTarikhDaryaft";
            this.colTarikhDaryaft.Visible = true;
            this.colTarikhDaryaft.VisibleIndex = 2;
            this.colTarikhDaryaft.Width = 134;
            // 
            // colVaziyatCheck
            // 
            this.colVaziyatCheck.AppearanceCell.Options.UseTextOptions = true;
            this.colVaziyatCheck.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVaziyatCheck.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colVaziyatCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.colVaziyatCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVaziyatCheck.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colVaziyatCheck.Caption = "وضعیت سند";
            this.colVaziyatCheck.FieldName = "VaziyatCheck";
            this.colVaziyatCheck.MinWidth = 24;
            this.colVaziyatCheck.Name = "colVaziyatCheck";
            this.colVaziyatCheck.Visible = true;
            this.colVaziyatCheck.VisibleIndex = 3;
            this.colVaziyatCheck.Width = 147;
            // 
            // colVamGerandeName
            // 
            this.colVamGerandeName.AppearanceCell.Options.UseTextOptions = true;
            this.colVamGerandeName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colVamGerandeName.AppearanceHeader.Options.UseTextOptions = true;
            this.colVamGerandeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVamGerandeName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colVamGerandeName.Caption = "نام وام گیرنده";
            this.colVamGerandeName.FieldName = "VamGerandeName";
            this.colVamGerandeName.MinWidth = 24;
            this.colVamGerandeName.Name = "colVamGerandeName";
            this.colVamGerandeName.Visible = true;
            this.colVamGerandeName.VisibleIndex = 4;
            this.colVamGerandeName.Width = 306;
            // 
            // colNoeSanad
            // 
            this.colNoeSanad.AppearanceCell.Options.UseTextOptions = true;
            this.colNoeSanad.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNoeSanad.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNoeSanad.AppearanceHeader.Options.UseTextOptions = true;
            this.colNoeSanad.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNoeSanad.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNoeSanad.Caption = "نوع سند";
            this.colNoeSanad.FieldName = "NoeSanad";
            this.colNoeSanad.MinWidth = 24;
            this.colNoeSanad.Name = "colNoeSanad";
            this.colNoeSanad.Visible = true;
            this.colNoeSanad.VisibleIndex = 5;
            this.colNoeSanad.Width = 122;
            // 
            // colShCheck
            // 
            this.colShCheck.AppearanceCell.Options.UseTextOptions = true;
            this.colShCheck.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShCheck.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colShCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.colShCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShCheck.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colShCheck.Caption = "شماره سند";
            this.colShCheck.FieldName = "ShCheck";
            this.colShCheck.MinWidth = 24;
            this.colShCheck.Name = "colShCheck";
            this.colShCheck.Visible = true;
            this.colShCheck.VisibleIndex = 6;
            this.colShCheck.Width = 134;
            // 
            // colTarikhCheck
            // 
            this.colTarikhCheck.AppearanceCell.Options.UseTextOptions = true;
            this.colTarikhCheck.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarikhCheck.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTarikhCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.colTarikhCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarikhCheck.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTarikhCheck.Caption = "تاریخ سند";
            this.colTarikhCheck.FieldName = "TarikhCheck";
            this.colTarikhCheck.MinWidth = 24;
            this.colTarikhCheck.Name = "colTarikhCheck";
            this.colTarikhCheck.Visible = true;
            this.colTarikhCheck.VisibleIndex = 7;
            this.colTarikhCheck.Width = 134;
            // 
            // colMablagh
            // 
            this.colMablagh.AppearanceCell.Options.UseTextOptions = true;
            this.colMablagh.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMablagh.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMablagh.AppearanceHeader.Options.UseTextOptions = true;
            this.colMablagh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMablagh.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMablagh.Caption = "مبلغ";
            this.colMablagh.DisplayFormat.FormatString = "n";
            this.colMablagh.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMablagh.FieldName = "Mablagh";
            this.colMablagh.MinWidth = 24;
            this.colMablagh.Name = "colMablagh";
            this.colMablagh.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Mablagh", "{0:n}")});
            this.colMablagh.Visible = true;
            this.colMablagh.VisibleIndex = 8;
            this.colMablagh.Width = 183;
            // 
            // colShomareHesab
            // 
            this.colShomareHesab.AppearanceCell.Options.UseTextOptions = true;
            this.colShomareHesab.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShomareHesab.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colShomareHesab.AppearanceHeader.Options.UseTextOptions = true;
            this.colShomareHesab.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShomareHesab.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colShomareHesab.Caption = "شماره حساب";
            this.colShomareHesab.FieldName = "ShomareHesab";
            this.colShomareHesab.MinWidth = 24;
            this.colShomareHesab.Name = "colShomareHesab";
            this.colShomareHesab.Visible = true;
            this.colShomareHesab.VisibleIndex = 9;
            this.colShomareHesab.Width = 183;
            // 
            // colNameBank
            // 
            this.colNameBank.AppearanceCell.Options.UseTextOptions = true;
            this.colNameBank.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNameBank.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNameBank.AppearanceHeader.Options.UseTextOptions = true;
            this.colNameBank.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNameBank.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNameBank.Caption = "نام بانک وشعبه";
            this.colNameBank.FieldName = "NameBank";
            this.colNameBank.MinWidth = 24;
            this.colNameBank.Name = "colNameBank";
            this.colNameBank.Visible = true;
            this.colNameBank.VisibleIndex = 10;
            this.colNameBank.Width = 208;
            // 
            // colSahebCheck
            // 
            this.colSahebCheck.AppearanceCell.Options.UseTextOptions = true;
            this.colSahebCheck.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSahebCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.colSahebCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSahebCheck.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSahebCheck.Caption = "صاحب/ضامن سند";
            this.colSahebCheck.FieldName = "SahebCheck";
            this.colSahebCheck.MinWidth = 24;
            this.colSahebCheck.Name = "colSahebCheck";
            this.colSahebCheck.Visible = true;
            this.colSahebCheck.VisibleIndex = 11;
            this.colSahebCheck.Width = 208;
            // 
            // colSharhDaryaftCheck
            // 
            this.colSharhDaryaftCheck.AppearanceCell.Options.UseTextOptions = true;
            this.colSharhDaryaftCheck.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSharhDaryaftCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.colSharhDaryaftCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSharhDaryaftCheck.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSharhDaryaftCheck.Caption = "شرح دریافت سند";
            this.colSharhDaryaftCheck.FieldName = "SharhDaryaftCheck";
            this.colSharhDaryaftCheck.MinWidth = 24;
            this.colSharhDaryaftCheck.Name = "colSharhDaryaftCheck";
            this.colSharhDaryaftCheck.Visible = true;
            this.colSharhDaryaftCheck.VisibleIndex = 12;
            this.colSharhDaryaftCheck.Width = 489;
            // 
            // colTarikhOdatCheck
            // 
            this.colTarikhOdatCheck.AppearanceCell.Options.UseTextOptions = true;
            this.colTarikhOdatCheck.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarikhOdatCheck.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTarikhOdatCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.colTarikhOdatCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarikhOdatCheck.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTarikhOdatCheck.Caption = "تاریخ عودت";
            this.colTarikhOdatCheck.FieldName = "TarikhOdatCheck";
            this.colTarikhOdatCheck.MinWidth = 24;
            this.colTarikhOdatCheck.Name = "colTarikhOdatCheck";
            this.colTarikhOdatCheck.Width = 92;
            // 
            // colSharhOdatCheck
            // 
            this.colSharhOdatCheck.AppearanceCell.Options.UseTextOptions = true;
            this.colSharhOdatCheck.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSharhOdatCheck.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSharhOdatCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.colSharhOdatCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSharhOdatCheck.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSharhOdatCheck.Caption = "شرح عودت";
            this.colSharhOdatCheck.FieldName = "SharhOdatCheck";
            this.colSharhOdatCheck.MinWidth = 24;
            this.colSharhOdatCheck.Name = "colSharhOdatCheck";
            this.colSharhOdatCheck.Width = 92;
            // 
            // FrmListCheckTazminNazdeSandogh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 559);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListCheckTazminNazdeSandogh";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست اسناد تضمینی نزد صندوق";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmListCheckTazminNazdeSandogh_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTazminsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn Line;
        private DevExpress.XtraGrid.Columns.GridColumn colSeryalDaryaft;
        private DevExpress.XtraGrid.Columns.GridColumn colTarikhDaryaft;
        private DevExpress.XtraGrid.Columns.GridColumn colVaziyatCheck;
        private DevExpress.XtraGrid.Columns.GridColumn colVamGerandeName;
        private DevExpress.XtraGrid.Columns.GridColumn colNoeSanad;
        private DevExpress.XtraGrid.Columns.GridColumn colShCheck;
        private DevExpress.XtraGrid.Columns.GridColumn colTarikhCheck;
        private DevExpress.XtraGrid.Columns.GridColumn colMablagh;
        private DevExpress.XtraGrid.Columns.GridColumn colShomareHesab;
        private DevExpress.XtraGrid.Columns.GridColumn colNameBank;
        private DevExpress.XtraGrid.Columns.GridColumn colSahebCheck;
        private DevExpress.XtraGrid.Columns.GridColumn colSharhDaryaftCheck;
        private DevExpress.XtraGrid.Columns.GridColumn colTarikhOdatCheck;
        private DevExpress.XtraGrid.Columns.GridColumn colSharhOdatCheck;
        public DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource checkTazminsBindingSource;
    }
}