namespace Sandogh_TG
{
    partial class FrmCodingDaramadVHazine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCodingDaramadVHazine));
            this.Line = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHesabName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.codingDaramadVHazinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnSaveNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdvancedSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisplayList = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreate = new DevExpress.XtraEditors.SimpleButton();
            this.txtNameHesab = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cmbGroupHesab = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codingDaramadVHazinesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameHesab.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGroupHesab.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.Line.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.Line.Visible = true;
            this.Line.VisibleIndex = 0;
            this.Line.Width = 70;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 19;
            this.colId.Name = "colId";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.Line,
            this.colGroupName,
            this.colCode,
            this.colHesabName});
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
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            this.gridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridView1_KeyPress);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colGroupName
            // 
            this.colGroupName.AppearanceCell.Options.UseTextOptions = true;
            this.colGroupName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colGroupName.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroupName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colGroupName.Caption = "گروه حساب";
            this.colGroupName.FieldName = "GroupName";
            this.colGroupName.Name = "colGroupName";
            this.colGroupName.Visible = true;
            this.colGroupName.VisibleIndex = 1;
            this.colGroupName.Width = 110;
            // 
            // colCode
            // 
            this.colCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCode.Caption = "کد";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 2;
            this.colCode.Width = 120;
            // 
            // colHesabName
            // 
            this.colHesabName.AppearanceCell.Options.UseTextOptions = true;
            this.colHesabName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colHesabName.AppearanceHeader.Options.UseTextOptions = true;
            this.colHesabName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHesabName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colHesabName.Caption = "نام حساب";
            this.colHesabName.FieldName = "HesabName";
            this.colHesabName.Name = "colHesabName";
            this.colHesabName.Visible = true;
            this.colHesabName.VisibleIndex = 3;
            this.colHesabName.Width = 420;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.codingDaramadVHazinesBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(753, 313);
            this.gridControl1.TabIndex = 32;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // codingDaramadVHazinesBindingSource
            // 
            this.codingDaramadVHazinesBindingSource.DataSource = typeof(Sandogh_TG.CodingDaramadVHazine);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(582, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(38, 33);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "simpleButton1";
            this.btnSave.ToolTip = "F5";
            this.btnSave.ToolTipTitle = "ذخیره";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.gridControl1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(757, 317);
            this.panelControl4.TabIndex = 40;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(494, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(38, 33);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "simpleButton1";
            this.btnCancel.ToolTip = "F6";
            this.btnCancel.ToolTipTitle = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.btnSaveNext);
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Controls.Add(this.btnPrint);
            this.panelControl2.Controls.Add(this.btnNext);
            this.panelControl2.Controls.Add(this.btnPrintPreview);
            this.panelControl2.Controls.Add(this.btnEdit);
            this.panelControl2.Controls.Add(this.btnAdvancedSearch);
            this.panelControl2.Controls.Add(this.btnDelete);
            this.panelControl2.Controls.Add(this.btnFirst);
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.Controls.Add(this.btnPreview);
            this.panelControl2.Controls.Add(this.btnLast);
            this.panelControl2.Controls.Add(this.btnDisplayList);
            this.panelControl2.Controls.Add(this.btnCancel);
            this.panelControl2.Controls.Add(this.btnCreate);
            this.panelControl2.Location = new System.Drawing.Point(0, 323);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(757, 44);
            this.panelControl2.TabIndex = 39;
            // 
            // btnSaveNext
            // 
            this.btnSaveNext.Enabled = false;
            this.btnSaveNext.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveNext.ImageOptions.Image")));
            this.btnSaveNext.Location = new System.Drawing.Point(538, 5);
            this.btnSaveNext.Name = "btnSaveNext";
            this.btnSaveNext.Size = new System.Drawing.Size(38, 33);
            this.btnSaveNext.TabIndex = 4;
            this.btnSaveNext.Text = "simpleButton1";
            this.btnSaveNext.ToolTip = "F9";
            this.btnSaveNext.ToolTipTitle = "ذخیره و بعدی";
            this.btnSaveNext.Click += new System.EventHandler(this.btnSaveNext_Click);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(5, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 33);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "بستن ";
            this.btnClose.ToolTip = "Escape";
            this.btnClose.ToolTipTitle = "بستن ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.Location = new System.Drawing.Point(98, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(38, 33);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "simpleButton1";
            this.btnPrint.ToolTip = "F12";
            this.btnPrint.ToolTipTitle = "چاپ لیست";
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnNext
            // 
            this.btnNext.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.ImageOptions.Image")));
            this.btnNext.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNext.ImageOptions.SvgImage")));
            this.btnNext.Location = new System.Drawing.Point(383, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(38, 33);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "simpleButton1";
            this.btnNext.ToolTip = "بعدی";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintPreview.ImageOptions.Image")));
            this.btnPrintPreview.Location = new System.Drawing.Point(142, 5);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(38, 33);
            this.btnPrintPreview.TabIndex = 13;
            this.btnPrintPreview.Text = "simpleButton1";
            this.btnPrintPreview.ToolTip = "F11";
            this.btnPrintPreview.ToolTipTitle = "نمایش چاپ";
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEdit.ImageOptions.SvgImage")));
            this.btnEdit.Location = new System.Drawing.Point(626, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(38, 33);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "simpleButton1";
            this.btnEdit.ToolTip = "F4";
            this.btnEdit.ToolTipTitle = "ویرایش";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdvancedSearch
            // 
            this.btnAdvancedSearch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAdvancedSearch.ImageOptions.SvgImage")));
            this.btnAdvancedSearch.Location = new System.Drawing.Point(186, 5);
            this.btnAdvancedSearch.Name = "btnAdvancedSearch";
            this.btnAdvancedSearch.Size = new System.Drawing.Size(38, 33);
            this.btnAdvancedSearch.TabIndex = 12;
            this.btnAdvancedSearch.Text = "simpleButton1";
            this.btnAdvancedSearch.ToolTip = "F10";
            this.btnAdvancedSearch.ToolTipTitle = "جستجوی پیشرفته";
            this.btnAdvancedSearch.Click += new System.EventHandler(this.btnAdvancedSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.Location = new System.Drawing.Point(670, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(38, 33);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "simpleButton1";
            this.btnDelete.ToolTip = "F3";
            this.btnDelete.ToolTipTitle = "حذف";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.ImageOptions.Image")));
            this.btnFirst.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFirst.ImageOptions.SvgImage")));
            this.btnFirst.Location = new System.Drawing.Point(295, 5);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(38, 33);
            this.btnFirst.TabIndex = 9;
            this.btnFirst.Text = "simpleButton1";
            this.btnFirst.ToolTip = "اولین رکورد";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.ImageOptions.Image")));
            this.btnPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPreview.ImageOptions.SvgImage")));
            this.btnPreview.Location = new System.Drawing.Point(339, 5);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(38, 33);
            this.btnPreview.TabIndex = 8;
            this.btnPreview.Text = "simpleButton1";
            this.btnPreview.ToolTip = "قبلی";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnLast
            // 
            this.btnLast.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLast.ImageOptions.SvgImage")));
            this.btnLast.Location = new System.Drawing.Point(427, 5);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(38, 33);
            this.btnLast.TabIndex = 6;
            this.btnLast.Text = "simpleButton1";
            this.btnLast.ToolTip = "آخرین رکورد";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnDisplayList
            // 
            this.btnDisplayList.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDisplayList.ImageOptions.SvgImage")));
            this.btnDisplayList.Location = new System.Drawing.Point(230, 5);
            this.btnDisplayList.Name = "btnDisplayList";
            this.btnDisplayList.Size = new System.Drawing.Size(38, 33);
            this.btnDisplayList.TabIndex = 10;
            this.btnDisplayList.Text = "simpleButton1";
            this.btnDisplayList.ToolTip = "F7";
            this.btnDisplayList.ToolTipTitle = "لیست چکهای تضمینی نزد صندوق";
            this.btnDisplayList.Click += new System.EventHandler(this.btnDisplyList_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCreate.ImageOptions.SvgImage")));
            this.btnCreate.Location = new System.Drawing.Point(714, 5);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(38, 33);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "simpleButton1";
            this.btnCreate.ToolTip = "F2";
            this.btnCreate.ToolTipTitle = "ایجاد";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtNameHesab
            // 
            this.txtNameHesab.EnterMoveNextControl = true;
            this.txtNameHesab.Location = new System.Drawing.Point(5, 6);
            this.txtNameHesab.Name = "txtNameHesab";
            this.txtNameHesab.Properties.MaxLength = 100;
            this.txtNameHesab.Properties.ReadOnly = true;
            this.txtNameHesab.Size = new System.Drawing.Size(352, 32);
            this.txtNameHesab.TabIndex = 1;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl13.Appearance.Options.UseForeColor = true;
            this.labelControl13.AutoEllipsis = true;
            this.labelControl13.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl13.Location = new System.Drawing.Point(363, 5);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(69, 32);
            this.labelControl13.TabIndex = 63;
            this.labelControl13.Text = "نام حساب";
            // 
            // panelControl3
            // 
            this.panelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl3.Controls.Add(this.labelControl6);
            this.panelControl3.Controls.Add(this.cmbGroupHesab);
            this.panelControl3.Controls.Add(this.txtNameHesab);
            this.panelControl3.Controls.Add(this.labelControl13);
            this.panelControl3.Controls.Add(this.txtCode);
            this.panelControl3.Controls.Add(this.txtId);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Location = new System.Drawing.Point(0, 373);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(757, 45);
            this.panelControl3.TabIndex = 41;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(677, 9);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(75, 25);
            this.labelControl6.TabIndex = 65;
            this.labelControl6.Text = "گروه حساب";
            // 
            // cmbGroupHesab
            // 
            this.cmbGroupHesab.EnterMoveNextControl = true;
            this.cmbGroupHesab.Location = new System.Drawing.Point(576, 6);
            this.cmbGroupHesab.Name = "cmbGroupHesab";
            this.cmbGroupHesab.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbGroupHesab.Properties.ImmediatePopup = true;
            this.cmbGroupHesab.Properties.Items.AddRange(new object[] {
            "درآمد",
            "هزینه"});
            this.cmbGroupHesab.Properties.MaxLength = 5;
            this.cmbGroupHesab.Properties.PopupSizeable = true;
            this.cmbGroupHesab.Properties.ReadOnly = true;
            this.cmbGroupHesab.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbGroupHesab.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbGroupHesab.Size = new System.Drawing.Size(95, 32);
            this.cmbGroupHesab.TabIndex = 0;
            this.cmbGroupHesab.SelectedIndexChanged += new System.EventHandler(this.cmbGroupHesab_SelectedIndexChanged);
            this.cmbGroupHesab.Enter += new System.EventHandler(this.cmbGroupHesab_Enter);
            // 
            // txtCode
            // 
            this.txtCode.EditValue = "";
            this.txtCode.EnterMoveNextControl = true;
            this.txtCode.Location = new System.Drawing.Point(438, 6);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtCode.Properties.Appearance.Options.UseBackColor = true;
            this.txtCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCode.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtCode.Properties.Mask.EditMask = "00000";
            this.txtCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCode.Properties.MaxLength = 7;
            this.txtCode.Properties.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(106, 32);
            this.txtCode.TabIndex = 55;
            this.txtCode.TabStop = false;
            // 
            // txtId
            // 
            this.txtId.EditValue = "آیدی";
            this.txtId.Location = new System.Drawing.Point(438, 6);
            this.txtId.Name = "txtId";
            this.txtId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtId.Properties.Mask.EditMask = "f0";
            this.txtId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtId.Properties.NullText = "آیدی انبار";
            this.txtId.Properties.ReadOnly = true;
            this.txtId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtId.Size = new System.Drawing.Size(73, 32);
            this.txtId.TabIndex = 59;
            this.txtId.TabStop = false;
            this.txtId.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(550, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(16, 25);
            this.labelControl1.TabIndex = 56;
            this.labelControl1.Text = "کد";
            // 
            // FrmCodingDaramadVHazine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 419);
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCodingDaramadVHazine";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "کدینگ درآمد و هزینه";
            this.Load += new System.EventHandler(this.FrmCodingDaramadVHazine_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCodingDaramadVHazine_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codingDaramadVHazinesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNameHesab.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGroupHesab.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.Columns.GridColumn Line;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colHesabName;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSaveNext;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnPrintPreview;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnAdvancedSearch;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnFirst;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraEditors.SimpleButton btnLast;
        private DevExpress.XtraEditors.SimpleButton btnDisplayList;
        private DevExpress.XtraEditors.SimpleButton btnCreate;
        public DevExpress.XtraEditors.TextEdit txtNameHesab;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        public DevExpress.XtraEditors.TextEdit txtCode;
        public DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit cmbGroupHesab;
        private System.Windows.Forms.BindingSource codingDaramadVHazinesBindingSource;
    }
}