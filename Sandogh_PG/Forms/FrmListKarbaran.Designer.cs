﻿namespace Sandogh_PG
{
    partial class FrmListKarbaran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListKarbaran));
            this.btnSaveNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.karbaransBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Line = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShenase = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassword = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblUserId = new DevExpress.XtraEditors.LabelControl();
            this.xtraScrollableControl2 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtShenase = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisplyActiveList = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreate = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.karbaransBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.xtraScrollableControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShenase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveNext
            // 
            this.btnSaveNext.Enabled = false;
            this.btnSaveNext.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSaveNext.ImageOptions.SvgImage")));
            this.btnSaveNext.Location = new System.Drawing.Point(614, 6);
            this.btnSaveNext.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSaveNext.Name = "btnSaveNext";
            this.btnSaveNext.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSaveNext.Size = new System.Drawing.Size(47, 40);
            this.btnSaveNext.TabIndex = 4;
            this.btnSaveNext.ToolTip = "F9";
            this.btnSaveNext.ToolTipTitle = "ذخیره و بعدی";
            this.btnSaveNext.Click += new System.EventHandler(this.btnSaveNext_Click);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(12, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnClose.Size = new System.Drawing.Size(47, 40);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "بستن ";
            this.btnClose.ToolTip = "Escape";
            this.btnClose.ToolTipTitle = "بستن ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.Location = new System.Drawing.Point(176, 6);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnPrint.Size = new System.Drawing.Size(47, 40);
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
            this.btnNext.Size = new System.Drawing.Size(47, 40);
            this.btnNext.TabIndex = 7;
            this.btnNext.ToolTip = "بعدی";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintPreview.ImageOptions.Image")));
            this.btnPrintPreview.Location = new System.Drawing.Point(225, 6);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnPrintPreview.Size = new System.Drawing.Size(47, 40);
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
            this.btnEdit.Size = new System.Drawing.Size(47, 40);
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
            this.btnDelete.Size = new System.Drawing.Size(47, 40);
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
            this.btnFirst.Size = new System.Drawing.Size(47, 40);
            this.btnFirst.TabIndex = 9;
            this.btnFirst.ToolTip = "اولین رکورد";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
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
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.gridControl1);
            this.panelControl4.Controls.Add(this.lblUserName);
            this.panelControl4.Controls.Add(this.lblUserId);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(865, 302);
            this.panelControl4.TabIndex = 33;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.karbaransBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(861, 298);
            this.gridControl1.TabIndex = 32;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // karbaransBindingSource
            // 
            this.karbaransBindingSource.DataSource = typeof(Sandogh_PG.Karbaran);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.Line,
            this.colName,
            this.colShenase,
            this.colPassword});
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
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            this.gridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridView1_KeyPress);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
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
            this.Line.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.Line.Visible = true;
            this.Line.VisibleIndex = 0;
            this.Line.Width = 66;
            // 
            // colName
            // 
            this.colName.AppearanceCell.Options.UseTextOptions = true;
            this.colName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colName.Caption = "نام کاربر";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 22;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 318;
            // 
            // colShenase
            // 
            this.colShenase.AppearanceCell.Options.UseTextOptions = true;
            this.colShenase.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShenase.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colShenase.AppearanceHeader.Options.UseTextOptions = true;
            this.colShenase.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShenase.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colShenase.Caption = "شناسه کاربری";
            this.colShenase.FieldName = "Shenase";
            this.colShenase.MinWidth = 22;
            this.colShenase.Name = "colShenase";
            this.colShenase.Visible = true;
            this.colShenase.VisibleIndex = 2;
            this.colShenase.Width = 218;
            // 
            // colPassword
            // 
            this.colPassword.AppearanceCell.Options.UseTextOptions = true;
            this.colPassword.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPassword.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPassword.AppearanceHeader.Options.UseTextOptions = true;
            this.colPassword.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPassword.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPassword.Caption = "رمز عبور";
            this.colPassword.FieldName = "Password";
            this.colPassword.MinWidth = 22;
            this.colPassword.Name = "colPassword";
            this.colPassword.Visible = true;
            this.colPassword.VisibleIndex = 3;
            this.colPassword.Width = 218;
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
            // xtraScrollableControl2
            // 
            this.xtraScrollableControl2.Controls.Add(this.txtName);
            this.xtraScrollableControl2.Controls.Add(this.txtId);
            this.xtraScrollableControl2.Controls.Add(this.txtPassword);
            this.xtraScrollableControl2.Controls.Add(this.txtShenase);
            this.xtraScrollableControl2.Controls.Add(this.labelControl3);
            this.xtraScrollableControl2.Controls.Add(this.labelControl2);
            this.xtraScrollableControl2.Controls.Add(this.labelControl5);
            this.xtraScrollableControl2.Controls.Add(this.panelControl2);
            this.xtraScrollableControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraScrollableControl2.Location = new System.Drawing.Point(0, 302);
            this.xtraScrollableControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.xtraScrollableControl2.Name = "xtraScrollableControl2";
            this.xtraScrollableControl2.Size = new System.Drawing.Size(865, 163);
            this.xtraScrollableControl2.TabIndex = 34;
            // 
            // txtName
            // 
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new System.Drawing.Point(360, 64);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtName.Name = "txtName";
            this.txtName.Properties.MaxLength = 50;
            this.txtName.Properties.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(431, 34);
            this.txtName.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.EditValue = "آیدی";
            this.txtId.Location = new System.Drawing.Point(360, 64);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtId.Name = "txtId";
            this.txtId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtId.Properties.Mask.EditMask = "f0";
            this.txtId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtId.Properties.NullText = "آیدی انبار";
            this.txtId.Properties.ReadOnly = true;
            this.txtId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtId.Size = new System.Drawing.Size(59, 34);
            this.txtId.TabIndex = 33;
            this.txtId.TabStop = false;
            this.txtId.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.EnterMoveNextControl = true;
            this.txtPassword.Location = new System.Drawing.Point(8, 106);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.MaxLength = 50;
            this.txtPassword.Properties.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(231, 34);
            this.txtPassword.TabIndex = 2;
            // 
            // txtShenase
            // 
            this.txtShenase.EnterMoveNextControl = true;
            this.txtShenase.Location = new System.Drawing.Point(8, 64);
            this.txtShenase.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtShenase.Name = "txtShenase";
            this.txtShenase.Properties.MaxLength = 50;
            this.txtShenase.Properties.ReadOnly = true;
            this.txtShenase.Size = new System.Drawing.Size(231, 34);
            this.txtShenase.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(245, 68);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(90, 27);
            this.labelControl3.TabIndex = 30;
            this.labelControl3.Text = "شناسه کاربری";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(245, 109);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 27);
            this.labelControl2.TabIndex = 31;
            this.labelControl2.Text = "رمز عبور";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(799, 67);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(53, 27);
            this.labelControl5.TabIndex = 32;
            this.labelControl5.Text = "نام کاربر";
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
            this.panelControl2.Size = new System.Drawing.Size(865, 49);
            this.panelControl2.TabIndex = 26;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Location = new System.Drawing.Point(662, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSave.Size = new System.Drawing.Size(47, 40);
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
            this.btnPreview.Size = new System.Drawing.Size(47, 40);
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
            this.btnLast.Size = new System.Drawing.Size(47, 40);
            this.btnLast.TabIndex = 6;
            this.btnLast.ToolTip = "آخرین رکورد";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnDisplyActiveList
            // 
            this.btnDisplyActiveList.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDisplyActiveList.ImageOptions.SvgImage")));
            this.btnDisplyActiveList.Location = new System.Drawing.Point(127, 6);
            this.btnDisplyActiveList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDisplyActiveList.Name = "btnDisplyActiveList";
            this.btnDisplyActiveList.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnDisplyActiveList.Size = new System.Drawing.Size(47, 40);
            this.btnDisplyActiveList.TabIndex = 10;
            this.btnDisplyActiveList.ToolTip = "F7";
            this.btnDisplyActiveList.ToolTipTitle = "لیست فعال";
            this.btnDisplyActiveList.Click += new System.EventHandler(this.btnDisplyList_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancel.ImageOptions.SvgImage")));
            this.btnCancel.Location = new System.Drawing.Point(565, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnCancel.Size = new System.Drawing.Size(47, 40);
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
            this.btnCreate.Size = new System.Drawing.Size(47, 40);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.ToolTip = "F2";
            this.btnCreate.ToolTipTitle = "ایجاد";
            this.btnCreate.Visible = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // FrmListKarbaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 465);
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.xtraScrollableControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmListKarbaran.IconOptions.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListKarbaran";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست کاربران";
            this.Load += new System.EventHandler(this.FrmListKarbaran_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmListKarbaran_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.karbaransBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.xtraScrollableControl2.ResumeLayout(false);
            this.xtraScrollableControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShenase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSaveNext;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnPrintPreview;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnFirst;
        public DevExpress.XtraEditors.LabelControl lblUserName;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn Line;
        public DevExpress.XtraEditors.LabelControl lblUserId;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl2;
        public DevExpress.XtraEditors.TextEdit txtPassword;
        public DevExpress.XtraEditors.TextEdit txtShenase;
        public DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraEditors.SimpleButton btnLast;
        private DevExpress.XtraEditors.SimpleButton btnDisplyActiveList;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnCreate;
        private System.Windows.Forms.BindingSource karbaransBindingSource;
        public DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colShenase;
        private DevExpress.XtraGrid.Columns.GridColumn colPassword;
    }
}