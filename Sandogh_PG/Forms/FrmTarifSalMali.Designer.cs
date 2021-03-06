﻿namespace Sandogh_PG.Forms
{
    partial class FrmTarifSalMali
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTarifSalMali));
            this.NameSandogh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Line = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SaleMali = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsDefault = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.salMalisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnSaveNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisplyActiveList = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreate = new DevExpress.XtraEditors.SimpleButton();
            this.chkIsDefault = new DevExpress.XtraEditors.CheckEdit();
            this.xtraScrollableControl2 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.txtEndDate = new DevExpress.XtraEditors.TextEdit();
            this.txtStartDate = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtSalMali = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbNameSandoogh = new DevExpress.XtraEditors.LookUpEdit();
            this.tarifSandoghsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.lblUserId = new DevExpress.XtraEditors.LabelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salMalisBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDefault.Properties)).BeginInit();
            this.xtraScrollableControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalMali.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNameSandoogh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarifSandoghsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameSandogh
            // 
            this.NameSandogh.AppearanceCell.Options.UseTextOptions = true;
            this.NameSandogh.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.NameSandogh.AppearanceHeader.Options.UseTextOptions = true;
            this.NameSandogh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameSandogh.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.NameSandogh.Caption = "نام صندوق";
            this.NameSandogh.FieldName = "NameSandogh";
            this.NameSandogh.MinWidth = 21;
            this.NameSandogh.Name = "NameSandogh";
            this.NameSandogh.Visible = true;
            this.NameSandogh.VisibleIndex = 1;
            this.NameSandogh.Width = 278;
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
            this.Line.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.Line.Visible = true;
            this.Line.VisibleIndex = 0;
            this.Line.Width = 66;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 21;
            this.colId.Name = "colId";
            this.colId.Width = 84;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.Line,
            this.NameSandogh,
            this.SaleMali,
            this.StartDate,
            this.EndDate,
            this.IsDefault});
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
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            this.gridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridView1_KeyPress);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // SaleMali
            // 
            this.SaleMali.AppearanceCell.Options.UseTextOptions = true;
            this.SaleMali.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SaleMali.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SaleMali.AppearanceHeader.Options.UseTextOptions = true;
            this.SaleMali.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SaleMali.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SaleMali.Caption = "سال مالی";
            this.SaleMali.FieldName = "SaleMali";
            this.SaleMali.MinWidth = 22;
            this.SaleMali.Name = "SaleMali";
            this.SaleMali.Visible = true;
            this.SaleMali.VisibleIndex = 2;
            this.SaleMali.Width = 100;
            // 
            // StartDate
            // 
            this.StartDate.AppearanceCell.Options.UseTextOptions = true;
            this.StartDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.StartDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.StartDate.AppearanceHeader.Options.UseTextOptions = true;
            this.StartDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.StartDate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.StartDate.Caption = "شروع دوره مالی";
            this.StartDate.FieldName = "StartDate";
            this.StartDate.MinWidth = 22;
            this.StartDate.Name = "StartDate";
            this.StartDate.Visible = true;
            this.StartDate.VisibleIndex = 3;
            this.StartDate.Width = 134;
            // 
            // EndDate
            // 
            this.EndDate.AppearanceCell.Options.UseTextOptions = true;
            this.EndDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EndDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.EndDate.AppearanceHeader.Options.UseTextOptions = true;
            this.EndDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EndDate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.EndDate.Caption = "پایان دوره مالی";
            this.EndDate.FieldName = "EndDate";
            this.EndDate.MinWidth = 22;
            this.EndDate.Name = "EndDate";
            this.EndDate.Visible = true;
            this.EndDate.VisibleIndex = 4;
            this.EndDate.Width = 134;
            // 
            // IsDefault
            // 
            this.IsDefault.AppearanceCell.Options.UseTextOptions = true;
            this.IsDefault.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.IsDefault.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.IsDefault.AppearanceHeader.Options.UseTextOptions = true;
            this.IsDefault.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.IsDefault.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.IsDefault.Caption = "پیش فرض";
            this.IsDefault.FieldName = "IsDefault";
            this.IsDefault.MinWidth = 22;
            this.IsDefault.Name = "IsDefault";
            this.IsDefault.Visible = true;
            this.IsDefault.VisibleIndex = 5;
            this.IsDefault.Width = 111;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.salMalisBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(856, 297);
            this.gridControl1.TabIndex = 32;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // salMalisBindingSource
            // 
            this.salMalisBindingSource.DataSource = typeof(Sandogh_PG.SalMali);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnSaveNext);
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Controls.Add(this.btnPrint);
            this.panelControl2.Controls.Add(this.btnNext);
            this.panelControl2.Controls.Add(this.btnPrintPreview);
            this.panelControl2.Controls.Add(this.btnEdit);
            this.panelControl2.Controls.Add(this.btnDelete);
            this.panelControl2.Controls.Add(this.btnFirst);
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.Controls.Add(this.btnPreview);
            this.panelControl2.Controls.Add(this.btnLast);
            this.panelControl2.Controls.Add(this.btnDisplyActiveList);
            this.panelControl2.Controls.Add(this.btnCancel);
            this.panelControl2.Controls.Add(this.btnCreate);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(860, 49);
            this.panelControl2.TabIndex = 26;
            // 
            // btnSaveNext
            // 
            this.btnSaveNext.Enabled = false;
            this.btnSaveNext.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSaveNext.ImageOptions.SvgImage")));
            this.btnSaveNext.Location = new System.Drawing.Point(614, 6);
            this.btnSaveNext.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSaveNext.Name = "btnSaveNext";
            this.btnSaveNext.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSaveNext.Size = new System.Drawing.Size(42, 36);
            this.btnSaveNext.TabIndex = 4;
            this.btnSaveNext.ToolTip = "F9";
            this.btnSaveNext.ToolTipTitle = "ذخیره و بعدی";
            this.btnSaveNext.Click += new System.EventHandler(this.btnSaveNext_Click);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(5, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnClose.Size = new System.Drawing.Size(96, 36);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "بستن ";
            this.btnClose.ToolTip = "Escape";
            this.btnClose.ToolTipTitle = "بستن ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.Location = new System.Drawing.Point(182, 6);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnPrint.Size = new System.Drawing.Size(42, 36);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.ToolTip = "F12";
            this.btnPrint.ToolTipTitle = "چاپ لیست";
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnNext
            // 
            this.btnNext.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.ImageOptions.Image")));
            this.btnNext.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNext.ImageOptions.SvgImage")));
            this.btnNext.Location = new System.Drawing.Point(432, 6);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnNext.Size = new System.Drawing.Size(42, 36);
            this.btnNext.TabIndex = 7;
            this.btnNext.ToolTip = "بعدی";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintPreview.ImageOptions.Image")));
            this.btnPrintPreview.Location = new System.Drawing.Point(231, 6);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnPrintPreview.Size = new System.Drawing.Size(42, 36);
            this.btnPrintPreview.TabIndex = 11;
            this.btnPrintPreview.ToolTip = "F11";
            this.btnPrintPreview.ToolTipTitle = "نمایش چاپ";
            this.btnPrintPreview.Visible = false;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEdit.ImageOptions.SvgImage")));
            this.btnEdit.Location = new System.Drawing.Point(711, 6);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnEdit.Size = new System.Drawing.Size(42, 36);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.ToolTip = "F4";
            this.btnEdit.ToolTipTitle = "ویرایش";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.Location = new System.Drawing.Point(760, 6);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnDelete.Size = new System.Drawing.Size(42, 36);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.ToolTip = "F3";
            this.btnDelete.ToolTipTitle = "حذف";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.ImageOptions.Image")));
            this.btnFirst.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFirst.ImageOptions.SvgImage")));
            this.btnFirst.Location = new System.Drawing.Point(335, 6);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnFirst.Size = new System.Drawing.Size(42, 36);
            this.btnFirst.TabIndex = 9;
            this.btnFirst.ToolTip = "اولین رکورد";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Location = new System.Drawing.Point(662, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSave.Size = new System.Drawing.Size(42, 36);
            this.btnSave.TabIndex = 0;
            this.btnSave.ToolTip = "F5";
            this.btnSave.ToolTipTitle = "ذخیره";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.ImageOptions.Image")));
            this.btnPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPreview.ImageOptions.SvgImage")));
            this.btnPreview.Location = new System.Drawing.Point(384, 6);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnPreview.Size = new System.Drawing.Size(42, 36);
            this.btnPreview.TabIndex = 8;
            this.btnPreview.ToolTip = "قبلی";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnLast
            // 
            this.btnLast.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLast.ImageOptions.SvgImage")));
            this.btnLast.Location = new System.Drawing.Point(481, 6);
            this.btnLast.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLast.Name = "btnLast";
            this.btnLast.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnLast.Size = new System.Drawing.Size(42, 36);
            this.btnLast.TabIndex = 6;
            this.btnLast.ToolTip = "آخرین رکورد";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnDisplyActiveList
            // 
            this.btnDisplyActiveList.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDisplyActiveList.ImageOptions.SvgImage")));
            this.btnDisplyActiveList.Location = new System.Drawing.Point(133, 6);
            this.btnDisplyActiveList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDisplyActiveList.Name = "btnDisplyActiveList";
            this.btnDisplyActiveList.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnDisplyActiveList.Size = new System.Drawing.Size(42, 36);
            this.btnDisplyActiveList.TabIndex = 10;
            this.btnDisplyActiveList.ToolTip = "F7";
            this.btnDisplyActiveList.ToolTipTitle = "لیست فعال";
            this.btnDisplyActiveList.Click += new System.EventHandler(this.btnDisplyActiveList_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancel.ImageOptions.SvgImage")));
            this.btnCancel.Location = new System.Drawing.Point(565, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnCancel.Size = new System.Drawing.Size(42, 36);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.ToolTip = "F6";
            this.btnCancel.ToolTipTitle = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCreate.ImageOptions.SvgImage")));
            this.btnCreate.Location = new System.Drawing.Point(809, 6);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnCreate.Size = new System.Drawing.Size(42, 36);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.ToolTip = "F2";
            this.btnCreate.ToolTipTitle = "ایجاد";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // chkIsDefault
            // 
            this.chkIsDefault.EditValue = true;
            this.chkIsDefault.EnterMoveNextControl = true;
            this.chkIsDefault.Location = new System.Drawing.Point(11, 136);
            this.chkIsDefault.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkIsDefault.Name = "chkIsDefault";
            this.chkIsDefault.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.chkIsDefault.Properties.Caption = "دوره مالی پیش فرض";
            this.chkIsDefault.Properties.ReadOnly = true;
            this.chkIsDefault.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsDefault.Size = new System.Drawing.Size(181, 31);
            this.chkIsDefault.TabIndex = 3;
            this.chkIsDefault.Visible = false;
            // 
            // xtraScrollableControl2
            // 
            this.xtraScrollableControl2.Controls.Add(this.chkIsDefault);
            this.xtraScrollableControl2.Controls.Add(this.panelControl2);
            this.xtraScrollableControl2.Controls.Add(this.txtEndDate);
            this.xtraScrollableControl2.Controls.Add(this.txtStartDate);
            this.xtraScrollableControl2.Controls.Add(this.labelControl2);
            this.xtraScrollableControl2.Controls.Add(this.labelControl7);
            this.xtraScrollableControl2.Controls.Add(this.txtSalMali);
            this.xtraScrollableControl2.Controls.Add(this.labelControl3);
            this.xtraScrollableControl2.Controls.Add(this.labelControl1);
            this.xtraScrollableControl2.Controls.Add(this.cmbNameSandoogh);
            this.xtraScrollableControl2.Controls.Add(this.txtId);
            this.xtraScrollableControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraScrollableControl2.Location = new System.Drawing.Point(0, 301);
            this.xtraScrollableControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.xtraScrollableControl2.Name = "xtraScrollableControl2";
            this.xtraScrollableControl2.Size = new System.Drawing.Size(860, 177);
            this.xtraScrollableControl2.TabIndex = 32;
            // 
            // txtEndDate
            // 
            this.txtEndDate.EnterMoveNextControl = true;
            this.txtEndDate.Location = new System.Drawing.Point(275, 134);
            this.txtEndDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Properties.Appearance.Options.UseTextOptions = true;
            this.txtEndDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtEndDate.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtEndDate.Properties.Mask.BeepOnError = true;
            this.txtEndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtEndDate.Properties.Mask.PlaceHolder = '-';
            this.txtEndDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtEndDate.Properties.ReadOnly = true;
            this.txtEndDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEndDate.Size = new System.Drawing.Size(165, 34);
            this.txtEndDate.TabIndex = 2;
            // 
            // txtStartDate
            // 
            this.txtStartDate.EnterMoveNextControl = true;
            this.txtStartDate.Location = new System.Drawing.Point(562, 134);
            this.txtStartDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Properties.Appearance.Options.UseTextOptions = true;
            this.txtStartDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtStartDate.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtStartDate.Properties.Mask.BeepOnError = true;
            this.txtStartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtStartDate.Properties.Mask.PlaceHolder = '-';
            this.txtStartDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtStartDate.Properties.ReadOnly = true;
            this.txtStartDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStartDate.Size = new System.Drawing.Size(165, 34);
            this.txtStartDate.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.AutoEllipsis = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(445, 133);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(109, 35);
            this.labelControl2.TabIndex = 30;
            this.labelControl2.Text = "پایان دوره مالی";
            // 
            // labelControl7
            // 
            this.labelControl7.AutoEllipsis = true;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.Location = new System.Drawing.Point(732, 133);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(115, 35);
            this.labelControl7.TabIndex = 30;
            this.labelControl7.Text = "شروع دوره مالی";
            // 
            // txtSalMali
            // 
            this.txtSalMali.EditValue = "";
            this.txtSalMali.EnterMoveNextControl = true;
            this.txtSalMali.Location = new System.Drawing.Point(621, 93);
            this.txtSalMali.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSalMali.Name = "txtSalMali";
            this.txtSalMali.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSalMali.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtSalMali.Properties.Mask.EditMask = "f0";
            this.txtSalMali.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSalMali.Properties.MaxLength = 4;
            this.txtSalMali.Properties.ReadOnly = true;
            this.txtSalMali.Size = new System.Drawing.Size(105, 34);
            this.txtSalMali.TabIndex = 0;
            this.txtSalMali.TabStop = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(734, 58);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(100, 27);
            this.labelControl3.TabIndex = 27;
            this.labelControl3.Text = "انتخاب صندوق";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(734, 96);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 27);
            this.labelControl1.TabIndex = 26;
            this.labelControl1.Text = "سال مالی";
            // 
            // cmbNameSandoogh
            // 
            this.cmbNameSandoogh.Location = new System.Drawing.Point(275, 55);
            this.cmbNameSandoogh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbNameSandoogh.Name = "cmbNameSandoogh";
            this.cmbNameSandoogh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNameSandoogh.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "آیدی", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameSandogh", "نام صندوق قرض الحسنه", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmbNameSandoogh.Properties.DataSource = this.tarifSandoghsBindingSource;
            this.cmbNameSandoogh.Properties.DisplayMember = "NameSandogh";
            this.cmbNameSandoogh.Properties.ImmediatePopup = true;
            this.cmbNameSandoogh.Properties.MaxLength = 150;
            this.cmbNameSandoogh.Properties.NullText = "";
            this.cmbNameSandoogh.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cmbNameSandoogh.Properties.ReadOnly = true;
            this.cmbNameSandoogh.Properties.ValueMember = "Id";
            this.cmbNameSandoogh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbNameSandoogh.Size = new System.Drawing.Size(452, 34);
            this.cmbNameSandoogh.TabIndex = 0;
            this.cmbNameSandoogh.TabStop = false;
            this.cmbNameSandoogh.Enter += new System.EventHandler(this.cmbNameSandoogh_Enter);
            // 
            // tarifSandoghsBindingSource
            // 
            this.tarifSandoghsBindingSource.DataSource = typeof(Sandogh_PG.TarifSandogh);
            // 
            // txtId
            // 
            this.txtId.EditValue = "آیدی";
            this.txtId.Location = new System.Drawing.Point(511, 55);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtId.Name = "txtId";
            this.txtId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtId.Properties.Mask.EditMask = "f0";
            this.txtId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtId.Properties.NullText = "آیدی انبار";
            this.txtId.Properties.ReadOnly = true;
            this.txtId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtId.Size = new System.Drawing.Size(140, 34);
            this.txtId.TabIndex = 28;
            this.txtId.TabStop = false;
            this.txtId.Visible = false;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(25, 86);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(53, 27);
            this.lblUserName.TabIndex = 31;
            this.lblUserName.Text = "نام کاربر";
            this.lblUserName.Visible = false;
            // 
            // lblUserId
            // 
            this.lblUserId.Location = new System.Drawing.Point(25, 51);
            this.lblUserId.Margin = new System.Windows.Forms.Padding(4);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(72, 27);
            this.lblUserId.TabIndex = 30;
            this.lblUserId.Text = "آیدی  کاربر";
            this.lblUserId.Visible = false;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.gridControl1);
            this.panelControl4.Controls.Add(this.lblUserName);
            this.panelControl4.Controls.Add(this.lblUserId);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(860, 301);
            this.panelControl4.TabIndex = 31;
            // 
            // FrmTarifSalMali
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 478);
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.xtraScrollableControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmTarifSalMali.IconOptions.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTarifSalMali";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعریف سال مالی";
            this.Load += new System.EventHandler(this.FrmTarifSalMali_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTarifSalMali_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salMalisBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDefault.Properties)).EndInit();
            this.xtraScrollableControl2.ResumeLayout(false);
            this.xtraScrollableControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalMali.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNameSandoogh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarifSandoghsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.Columns.GridColumn NameSandogh;
        private DevExpress.XtraGrid.Columns.GridColumn Line;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn SaleMali;
        private DevExpress.XtraGrid.Columns.GridColumn StartDate;
        private DevExpress.XtraGrid.Columns.GridColumn IsDefault;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnPrintPreview;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnFirst;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraEditors.SimpleButton btnLast;
        private DevExpress.XtraEditors.SimpleButton btnDisplyActiveList;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnCreate;
        public DevExpress.XtraEditors.CheckEdit chkIsDefault;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl2;
        private DevExpress.XtraEditors.TextEdit txtEndDate;
        private DevExpress.XtraEditors.TextEdit txtStartDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.TextEdit txtSalMali;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cmbNameSandoogh;
        private System.Windows.Forms.BindingSource tarifSandoghsBindingSource;
        public DevExpress.XtraEditors.TextEdit txtId;
        public DevExpress.XtraEditors.LabelControl lblUserName;
        public DevExpress.XtraEditors.LabelControl lblUserId;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private System.Windows.Forms.BindingSource salMalisBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn EndDate;
        private DevExpress.XtraEditors.SimpleButton btnSaveNext;
    }
}