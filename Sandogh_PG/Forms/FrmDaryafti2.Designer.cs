namespace Sandogh_PG.Forms
{
    partial class FrmDaryafti2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDaryafti2));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSetInfoToExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnTestInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetInfoFromExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetInfoDataBase = new DevExpress.XtraEditors.SimpleButton();
            this.cmbMoinA1 = new DevExpress.XtraEditors.LookUpEdit();
            this.codeMoinsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbNameHesabA1 = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cmbMoinP1 = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbNameHesabP1 = new DevExpress.XtraEditors.LookUpEdit();
            this.txtTarikhSanad1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cmbMonth1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSal1 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMoinA1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeMoinsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNameHesabA1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMoinP1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNameHesabP1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarikhSanad1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMonth1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSal1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(0, 134);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1440, 562);
            this.gridControl1.TabIndex = 36;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn17});
            this.gridView1.DetailHeight = 378;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 38;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsFind.AllowFindPanel = false;
            this.gridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gridView1.OptionsFind.FindNullPrompt = "متنی برای جستجو تایپ کنید ...";
            this.gridView1.OptionsMenu.ShowFooterItem = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            this.gridView1.RowCountChanged += new System.EventHandler(this.gridView1_RowCountChanged);
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn15.Caption = "کد حساب";
            this.gridColumn15.FieldName = "CodeHesab";
            this.gridColumn15.MinWidth = 118;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 0;
            this.gridColumn15.Width = 118;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn16.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn16.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn16.Caption = "نام حساب";
            this.gridColumn16.FieldName = "NameAaza";
            this.gridColumn16.MinWidth = 22;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 1;
            this.gridColumn16.Width = 318;
            // 
            // gridColumn19
            // 
            this.gridColumn19.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn19.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn19.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn19.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn19.Caption = "مبلغ پس انداز";
            this.gridColumn19.DisplayFormat.FormatString = "{0:n}";
            this.gridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn19.FieldName = "MablaghPasandaz";
            this.gridColumn19.GroupFormat.FormatString = "{0:n}";
            this.gridColumn19.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn19.MinWidth = 22;
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MablaghPasandaz", "{0:n}")});
            this.gridColumn19.UnboundDataType = typeof(decimal);
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 2;
            this.gridColumn19.Width = 182;
            // 
            // gridColumn20
            // 
            this.gridColumn20.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn20.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn20.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn20.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn20.Caption = "مبلغ اقساط";
            this.gridColumn20.DisplayFormat.FormatString = "n";
            this.gridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn20.FieldName = "MablaghAghsat";
            this.gridColumn20.MinWidth = 22;
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MablaghAghsat", "{0:n}")});
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 3;
            this.gridColumn20.Width = 182;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn17.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn17.Caption = "کد وام";
            this.gridColumn17.FieldName = "CodeVam";
            this.gridColumn17.MinWidth = 100;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 4;
            this.gridColumn17.Width = 119;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSetInfoToExcel);
            this.panelControl1.Controls.Add(this.btnTestInfo);
            this.panelControl1.Controls.Add(this.btnGetInfoFromExcel);
            this.panelControl1.Controls.Add(this.btnGetInfoDataBase);
            this.panelControl1.Controls.Add(this.cmbMoinA1);
            this.panelControl1.Controls.Add(this.cmbNameHesabA1);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.cmbMoinP1);
            this.panelControl1.Controls.Add(this.cmbNameHesabP1);
            this.panelControl1.Controls.Add(this.txtTarikhSanad1);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.cmbMonth1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtSal1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1440, 134);
            this.panelControl1.TabIndex = 0;
            // 
            // btnSetInfoToExcel
            // 
            this.btnSetInfoToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetInfoToExcel.Enabled = false;
            this.btnSetInfoToExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSetInfoToExcel.ImageOptions.Image")));
            this.btnSetInfoToExcel.Location = new System.Drawing.Point(13, 48);
            this.btnSetInfoToExcel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSetInfoToExcel.Name = "btnSetInfoToExcel";
            this.btnSetInfoToExcel.Size = new System.Drawing.Size(244, 34);
            this.btnSetInfoToExcel.TabIndex = 40;
            this.btnSetInfoToExcel.Text = "خروجی گزارش به اکسل";
            this.btnSetInfoToExcel.Click += new System.EventHandler(this.btnExportInfoToExcel_Click);
            // 
            // btnTestInfo
            // 
            this.btnTestInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestInfo.Enabled = false;
            this.btnTestInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTestInfo.ImageOptions.Image")));
            this.btnTestInfo.Location = new System.Drawing.Point(265, 7);
            this.btnTestInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTestInfo.Name = "btnTestInfo";
            this.btnTestInfo.Size = new System.Drawing.Size(220, 34);
            this.btnTestInfo.TabIndex = 9;
            this.btnTestInfo.Text = "تست درستی اطلاعات";
            this.btnTestInfo.Click += new System.EventHandler(this.btnTestInfo_Click);
            // 
            // btnGetInfoFromExcel
            // 
            this.btnGetInfoFromExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetInfoFromExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGetInfoFromExcel.ImageOptions.Image")));
            this.btnGetInfoFromExcel.Location = new System.Drawing.Point(13, 89);
            this.btnGetInfoFromExcel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGetInfoFromExcel.Name = "btnGetInfoFromExcel";
            this.btnGetInfoFromExcel.Size = new System.Drawing.Size(244, 34);
            this.btnGetInfoFromExcel.TabIndex = 8;
            this.btnGetInfoFromExcel.Text = "دریافت اطلاعات از اکسل";
            this.btnGetInfoFromExcel.Click += new System.EventHandler(this.btnGetInfoFromExcel_Click);
            // 
            // btnGetInfoDataBase
            // 
            this.btnGetInfoDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetInfoDataBase.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGetInfoDataBase.ImageOptions.Image")));
            this.btnGetInfoDataBase.Location = new System.Drawing.Point(13, 7);
            this.btnGetInfoDataBase.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGetInfoDataBase.Name = "btnGetInfoDataBase";
            this.btnGetInfoDataBase.Size = new System.Drawing.Size(244, 34);
            this.btnGetInfoDataBase.TabIndex = 7;
            this.btnGetInfoDataBase.Text = "دریافت اطلاعات از دیتابیس";
            this.btnGetInfoDataBase.Click += new System.EventHandler(this.btnGetInfoDataBase_Click);
            // 
            // cmbMoinA1
            // 
            this.cmbMoinA1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMoinA1.EnterMoveNextControl = true;
            this.cmbMoinA1.Location = new System.Drawing.Point(814, 89);
            this.cmbMoinA1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbMoinA1.Name = "cmbMoinA1";
            this.cmbMoinA1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMoinA1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "نام حساب معین :", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmbMoinA1.Properties.DataSource = this.codeMoinsBindingSource;
            this.cmbMoinA1.Properties.DisplayMember = "Name";
            this.cmbMoinA1.Properties.ImmediatePopup = true;
            this.cmbMoinA1.Properties.MaxLength = 150;
            this.cmbMoinA1.Properties.NullText = "";
            this.cmbMoinA1.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cmbMoinA1.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.cmbMoinA1.Properties.ValueMember = "Id";
            this.cmbMoinA1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMoinA1.Size = new System.Drawing.Size(346, 34);
            this.cmbMoinA1.TabIndex = 5;
            this.cmbMoinA1.EditValueChanged += new System.EventHandler(this.cmbMoinA1_EditValueChanged);
            // 
            // codeMoinsBindingSource
            // 
            this.codeMoinsBindingSource.DataSource = typeof(Sandogh_PG.CodeMoin);
            // 
            // cmbNameHesabA1
            // 
            this.cmbNameHesabA1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbNameHesabA1.EnterMoveNextControl = true;
            this.cmbNameHesabA1.Location = new System.Drawing.Point(265, 89);
            this.cmbNameHesabA1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbNameHesabA1.Name = "cmbNameHesabA1";
            this.cmbNameHesabA1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNameHesabA1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "آیدی", 50, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "نام حساب تفضیل :", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmbNameHesabA1.Properties.DataSource = typeof(Sandogh_PG.AllHesabTafzili);
            this.cmbNameHesabA1.Properties.DisplayMember = "Name";
            this.cmbNameHesabA1.Properties.ImmediatePopup = true;
            this.cmbNameHesabA1.Properties.MaxLength = 150;
            this.cmbNameHesabA1.Properties.NullText = "";
            this.cmbNameHesabA1.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cmbNameHesabA1.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.cmbNameHesabA1.Properties.ValueMember = "Id";
            this.cmbNameHesabA1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbNameHesabA1.Size = new System.Drawing.Size(541, 34);
            this.cmbNameHesabA1.TabIndex = 6;
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(1177, 96);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(234, 27);
            this.labelControl6.TabIndex = 39;
            this.labelControl6.Text = "واریز وجه اقساط ماهیانه به حساب";
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(1177, 51);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(250, 27);
            this.labelControl5.TabIndex = 36;
            this.labelControl5.Text = "واریز وجه پس انداز ماهیانه به حساب";
            // 
            // cmbMoinP1
            // 
            this.cmbMoinP1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMoinP1.EnterMoveNextControl = true;
            this.cmbMoinP1.Location = new System.Drawing.Point(814, 48);
            this.cmbMoinP1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbMoinP1.Name = "cmbMoinP1";
            this.cmbMoinP1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMoinP1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "نام حساب معین :", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmbMoinP1.Properties.DataSource = this.codeMoinsBindingSource;
            this.cmbMoinP1.Properties.DisplayMember = "Name";
            this.cmbMoinP1.Properties.ImmediatePopup = true;
            this.cmbMoinP1.Properties.MaxLength = 150;
            this.cmbMoinP1.Properties.NullText = "";
            this.cmbMoinP1.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cmbMoinP1.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.cmbMoinP1.Properties.ValueMember = "Id";
            this.cmbMoinP1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMoinP1.Size = new System.Drawing.Size(346, 34);
            this.cmbMoinP1.TabIndex = 3;
            this.cmbMoinP1.EditValueChanged += new System.EventHandler(this.cmbMoinP1_EditValueChanged);
            // 
            // cmbNameHesabP1
            // 
            this.cmbNameHesabP1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbNameHesabP1.EnterMoveNextControl = true;
            this.cmbNameHesabP1.Location = new System.Drawing.Point(265, 48);
            this.cmbNameHesabP1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbNameHesabP1.Name = "cmbNameHesabP1";
            this.cmbNameHesabP1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNameHesabP1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "آیدی", 50, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "نام حساب تفضیل :", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmbNameHesabP1.Properties.DataSource = typeof(Sandogh_PG.AllHesabTafzili);
            this.cmbNameHesabP1.Properties.DisplayMember = "Name";
            this.cmbNameHesabP1.Properties.ImmediatePopup = true;
            this.cmbNameHesabP1.Properties.MaxLength = 150;
            this.cmbNameHesabP1.Properties.NullText = "";
            this.cmbNameHesabP1.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cmbNameHesabP1.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.cmbNameHesabP1.Properties.ValueMember = "Id";
            this.cmbNameHesabP1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbNameHesabP1.Size = new System.Drawing.Size(541, 34);
            this.cmbNameHesabP1.TabIndex = 4;
            // 
            // txtTarikhSanad1
            // 
            this.txtTarikhSanad1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTarikhSanad1.EnterMoveNextControl = true;
            this.txtTarikhSanad1.Location = new System.Drawing.Point(993, 7);
            this.txtTarikhSanad1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTarikhSanad1.Name = "txtTarikhSanad1";
            this.txtTarikhSanad1.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTarikhSanad1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtTarikhSanad1.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtTarikhSanad1.Properties.Mask.BeepOnError = true;
            this.txtTarikhSanad1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTarikhSanad1.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));
            this.txtTarikhSanad1.Properties.MaskSettings.Set("placeholder", '-');
            this.txtTarikhSanad1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTarikhSanad1.Size = new System.Drawing.Size(167, 34);
            this.txtTarikhSanad1.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.AutoEllipsis = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(1177, 9);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(76, 35);
            this.labelControl3.TabIndex = 32;
            this.labelControl3.Text = "تاریخ سند";
            // 
            // cmbMonth1
            // 
            this.cmbMonth1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMonth1.EnterMoveNextControl = true;
            this.cmbMonth1.Location = new System.Drawing.Point(636, 7);
            this.cmbMonth1.Name = "cmbMonth1";
            this.cmbMonth1.Properties.Appearance.Options.UseTextOptions = true;
            this.cmbMonth1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cmbMonth1.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.cmbMonth1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMonth1.Properties.Items.AddRange(new object[] {
            "فروردین",
            "اردیبهشت",
            "خرداد",
            "تیر ",
            "مرداد",
            "شهریور",
            "مهر",
            "آبان",
            "آذر",
            "دی ",
            "بهمن",
            "اسفند"});
            this.cmbMonth1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbMonth1.Size = new System.Drawing.Size(138, 34);
            this.cmbMonth1.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(942, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 27);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "سال";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(781, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(21, 27);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "ماه";
            // 
            // txtSal1
            // 
            this.txtSal1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSal1.EnterMoveNextControl = true;
            this.txtSal1.Location = new System.Drawing.Point(814, 7);
            this.txtSal1.Name = "txtSal1";
            this.txtSal1.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSal1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtSal1.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtSal1.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtSal1.Properties.MaskSettings.Set("mask", "f");
            this.txtSal1.Properties.MaxLength = 4;
            this.txtSal1.Size = new System.Drawing.Size(122, 34);
            this.txtSal1.TabIndex = 1;
            // 
            // FrmDaryafti2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 696);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.Image = global::Sandogh_PG.Properties.Resources.PG_Logo_1;
            this.MinimumSize = new System.Drawing.Size(1442, 736);
            this.Name = "FrmDaryafti2";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دریافت پس انداز ماهیانه و اقساط وام بصورت گروهی";
            this.Load += new System.EventHandler(this.FrmDaryafti2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMoinA1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeMoinsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNameHesabA1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMoinP1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNameHesabP1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarikhSanad1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMonth1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSal1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraEditors.ComboBoxEdit cmbMonth1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtSal1;
        public DevExpress.XtraEditors.TextEdit txtTarikhSanad1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.LookUpEdit cmbMoinP1;
        public DevExpress.XtraEditors.LookUpEdit cmbNameHesabP1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.LookUpEdit cmbMoinA1;
        public DevExpress.XtraEditors.LookUpEdit cmbNameHesabA1;
        private DevExpress.XtraEditors.SimpleButton btnTestInfo;
        private DevExpress.XtraEditors.SimpleButton btnGetInfoFromExcel;
        private DevExpress.XtraEditors.SimpleButton btnGetInfoDataBase;
        private System.Windows.Forms.BindingSource codeMoinsBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnSetInfoToExcel;
    }
}