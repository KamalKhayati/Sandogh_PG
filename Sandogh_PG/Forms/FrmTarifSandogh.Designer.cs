namespace Sandogh_PG
{
    partial class FrmTarifSandogh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTarifSandogh));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MasolinName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SematName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MobilNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tozihat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.txtNameSandogh = new DevExpress.XtraEditors.TextEdit();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnBrowsPictuer = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMobile = new DevExpress.XtraEditors.TextEdit();
            this.txtNameModir = new DevExpress.XtraEditors.TextEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.txtTarikhEjad = new DevExpress.XtraEditors.TextEdit();
            this.txtAdress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.txtTell = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.chkIsDefault = new DevExpress.XtraEditors.CheckEdit();
            this.btnSaveClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameSandogh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameModir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarikhEjad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTell.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDefault.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(716, 592);
            this.panelControl1.TabIndex = 23;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(2, 268);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(712, 322);
            this.gridControl1.TabIndex = 50;
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
            this.MasolinName,
            this.SematName,
            this.MobilNumber,
            this.StartDate,
            this.EndDate,
            this.Tozihat});
            this.gridView1.DetailHeight = 378;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 36;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsFind.AllowFindPanel = false;
            this.gridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gridView1.OptionsFind.FindNullPrompt = "متنی برای جستجو تایپ کنید ...";
            this.gridView1.OptionsMenu.ShowFooterItem = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsScrollAnnotations.ShowFocusedRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            // 
            // MasolinName
            // 
            this.MasolinName.AppearanceCell.Options.UseTextOptions = true;
            this.MasolinName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.MasolinName.AppearanceHeader.Options.UseTextOptions = true;
            this.MasolinName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MasolinName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.MasolinName.Caption = "نام مسئولین/مدیران صندوق";
            this.MasolinName.FieldName = "MasolinName";
            this.MasolinName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.MasolinName.MinWidth = 22;
            this.MasolinName.Name = "MasolinName";
            this.MasolinName.Visible = true;
            this.MasolinName.VisibleIndex = 0;
            this.MasolinName.Width = 219;
            // 
            // SematName
            // 
            this.SematName.AppearanceCell.Options.UseTextOptions = true;
            this.SematName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SematName.AppearanceHeader.Options.UseTextOptions = true;
            this.SematName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SematName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SematName.Caption = "عنوان سمت";
            this.SematName.FieldName = "SematName";
            this.SematName.MinWidth = 118;
            this.SematName.Name = "SematName";
            this.SematName.Visible = true;
            this.SematName.VisibleIndex = 1;
            this.SematName.Width = 268;
            // 
            // MobilNumber
            // 
            this.MobilNumber.AppearanceCell.Options.UseTextOptions = true;
            this.MobilNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MobilNumber.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.MobilNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.MobilNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MobilNumber.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.MobilNumber.Caption = "شماره موبایل";
            this.MobilNumber.FieldName = "MobilNumber";
            this.MobilNumber.MinWidth = 22;
            this.MobilNumber.Name = "MobilNumber";
            this.MobilNumber.Visible = true;
            this.MobilNumber.VisibleIndex = 2;
            this.MobilNumber.Width = 182;
            // 
            // StartDate
            // 
            this.StartDate.AppearanceCell.Options.UseTextOptions = true;
            this.StartDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.StartDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.StartDate.AppearanceHeader.Options.UseTextOptions = true;
            this.StartDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.StartDate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.StartDate.Caption = "تاریخ شروع مسئولیت";
            this.StartDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.StartDate.FieldName = "StartDate";
            this.StartDate.MinWidth = 22;
            this.StartDate.Name = "StartDate";
            this.StartDate.Visible = true;
            this.StartDate.VisibleIndex = 3;
            this.StartDate.Width = 173;
            // 
            // EndDate
            // 
            this.EndDate.AppearanceCell.Options.UseTextOptions = true;
            this.EndDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EndDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.EndDate.AppearanceHeader.Options.UseTextOptions = true;
            this.EndDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EndDate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.EndDate.Caption = "تاریخ پایان مسئولیت";
            this.EndDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.EndDate.FieldName = "EndDate";
            this.EndDate.MinWidth = 22;
            this.EndDate.Name = "EndDate";
            this.EndDate.Visible = true;
            this.EndDate.VisibleIndex = 4;
            this.EndDate.Width = 172;
            // 
            // Tozihat
            // 
            this.Tozihat.AppearanceCell.Options.UseTextOptions = true;
            this.Tozihat.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Tozihat.AppearanceHeader.Options.UseTextOptions = true;
            this.Tozihat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Tozihat.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Tozihat.Caption = "توضیحات";
            this.Tozihat.FieldName = "Tozihat";
            this.Tozihat.MinWidth = 22;
            this.Tozihat.Name = "Tozihat";
            this.Tozihat.Visible = true;
            this.Tozihat.VisibleIndex = 5;
            this.Tozihat.Width = 403;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.txtNameSandogh);
            this.panelControl3.Controls.Add(this.btnDelete);
            this.panelControl3.Controls.Add(this.btnBrowsPictuer);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Controls.Add(this.pictureEdit1);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Controls.Add(this.txtMobile);
            this.panelControl3.Controls.Add(this.txtNameModir);
            this.panelControl3.Controls.Add(this.labelControl18);
            this.panelControl3.Controls.Add(this.labelControl16);
            this.panelControl3.Controls.Add(this.txtTarikhEjad);
            this.panelControl3.Controls.Add(this.txtAdress);
            this.panelControl3.Controls.Add(this.labelControl4);
            this.panelControl3.Controls.Add(this.labelControl17);
            this.panelControl3.Controls.Add(this.txtTell);
            this.panelControl3.Controls.Add(this.pictureEdit2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(712, 266);
            this.panelControl3.TabIndex = 47;
            // 
            // txtNameSandogh
            // 
            this.txtNameSandogh.EnterMoveNextControl = true;
            this.txtNameSandogh.Location = new System.Drawing.Point(243, 14);
            this.txtNameSandogh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNameSandogh.Name = "txtNameSandogh";
            this.txtNameSandogh.Properties.MaxLength = 150;
            this.txtNameSandogh.Size = new System.Drawing.Size(318, 34);
            this.txtNameSandogh.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.Location = new System.Drawing.Point(197, 133);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnDelete.Size = new System.Drawing.Size(46, 55);
            this.btnDelete.TabIndex = 45;
            this.btnDelete.TabStop = false;
            this.btnDelete.ToolTip = "F6";
            this.btnDelete.ToolTipTitle = "انصراف";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnBrowsPictuer
            // 
            this.btnBrowsPictuer.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBrowsPictuer.ImageOptions.SvgImage")));
            this.btnBrowsPictuer.Location = new System.Drawing.Point(197, 82);
            this.btnBrowsPictuer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBrowsPictuer.Name = "btnBrowsPictuer";
            this.btnBrowsPictuer.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnBrowsPictuer.Size = new System.Drawing.Size(46, 55);
            this.btnBrowsPictuer.TabIndex = 44;
            this.btnBrowsPictuer.TabStop = false;
            this.btnBrowsPictuer.ToolTip = "F2";
            this.btnBrowsPictuer.ToolTipTitle = "ایجاد";
            this.btnBrowsPictuer.Click += new System.EventHandler(this.btnBrowsPictuer_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.AutoEllipsis = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(567, 13);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 35);
            this.labelControl2.TabIndex = 41;
            this.labelControl2.Text = "نام صندوق";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Location = new System.Drawing.Point(38, 30);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(151, 158);
            this.pictureEdit1.TabIndex = 43;
            // 
            // labelControl1
            // 
            this.labelControl1.AutoEllipsis = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(567, 54);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 35);
            this.labelControl1.TabIndex = 41;
            this.labelControl1.Text = "مسئول صندوق";
            // 
            // txtMobile
            // 
            this.txtMobile.EnterMoveNextControl = true;
            this.txtMobile.Location = new System.Drawing.Point(343, 138);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Properties.MaxLength = 23;
            this.txtMobile.Size = new System.Drawing.Size(218, 34);
            this.txtMobile.TabIndex = 3;
            // 
            // txtNameModir
            // 
            this.txtNameModir.EnterMoveNextControl = true;
            this.txtNameModir.Location = new System.Drawing.Point(243, 55);
            this.txtNameModir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNameModir.Name = "txtNameModir";
            this.txtNameModir.Properties.MaxLength = 150;
            this.txtNameModir.Size = new System.Drawing.Size(318, 34);
            this.txtNameModir.TabIndex = 1;
            // 
            // labelControl18
            // 
            this.labelControl18.AutoEllipsis = true;
            this.labelControl18.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl18.Location = new System.Drawing.Point(567, 136);
            this.labelControl18.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(48, 35);
            this.labelControl18.TabIndex = 41;
            this.labelControl18.Text = "موبایل";
            // 
            // labelControl16
            // 
            this.labelControl16.AutoEllipsis = true;
            this.labelControl16.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl16.Location = new System.Drawing.Point(570, 219);
            this.labelControl16.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(45, 35);
            this.labelControl16.TabIndex = 41;
            this.labelControl16.Text = "آدرس";
            // 
            // txtTarikhEjad
            // 
            this.txtTarikhEjad.EnterMoveNextControl = true;
            this.txtTarikhEjad.Location = new System.Drawing.Point(343, 179);
            this.txtTarikhEjad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTarikhEjad.Name = "txtTarikhEjad";
            this.txtTarikhEjad.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTarikhEjad.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTarikhEjad.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtTarikhEjad.Properties.Mask.BeepOnError = true;
            this.txtTarikhEjad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtTarikhEjad.Properties.Mask.PlaceHolder = '-';
            this.txtTarikhEjad.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTarikhEjad.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTarikhEjad.Size = new System.Drawing.Size(218, 34);
            this.txtTarikhEjad.TabIndex = 4;
            // 
            // txtAdress
            // 
            this.txtAdress.EnterMoveNextControl = true;
            this.txtAdress.Location = new System.Drawing.Point(7, 220);
            this.txtAdress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Properties.MaxLength = 400;
            this.txtAdress.Size = new System.Drawing.Size(554, 34);
            this.txtAdress.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(569, 181);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(129, 27);
            this.labelControl4.TabIndex = 22;
            this.labelControl4.Text = "تاریخ ایجاد صندوق";
            // 
            // labelControl17
            // 
            this.labelControl17.AutoEllipsis = true;
            this.labelControl17.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl17.Location = new System.Drawing.Point(567, 95);
            this.labelControl17.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(36, 35);
            this.labelControl17.TabIndex = 41;
            this.labelControl17.Text = "تلفن";
            // 
            // txtTell
            // 
            this.txtTell.EnterMoveNextControl = true;
            this.txtTell.Location = new System.Drawing.Point(343, 96);
            this.txtTell.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTell.Name = "txtTell";
            this.txtTell.Properties.MaxLength = 23;
            this.txtTell.Size = new System.Drawing.Size(218, 34);
            this.txtTell.TabIndex = 2;
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.EditValue = global::Sandogh_PG.Properties.Resources.PG_Logo_2;
            this.pictureEdit2.Location = new System.Drawing.Point(70, 54);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Size = new System.Drawing.Size(100, 96);
            this.pictureEdit2.TabIndex = 46;
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(5, 5);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 50);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "بستن ";
            this.btnClose.ToolTip = "Escape";
            this.btnClose.ToolTipTitle = "بستن ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.chkIsDefault);
            this.panelControl2.Controls.Add(this.btnSaveClose);
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 592);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(716, 60);
            this.panelControl2.TabIndex = 24;
            // 
            // chkIsDefault
            // 
            this.chkIsDefault.EditValue = true;
            this.chkIsDefault.EnterMoveNextControl = true;
            this.chkIsDefault.Location = new System.Drawing.Point(542, 17);
            this.chkIsDefault.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkIsDefault.Name = "chkIsDefault";
            this.chkIsDefault.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.chkIsDefault.Properties.Caption = "صندوق پیش فرض";
            this.chkIsDefault.Properties.ReadOnly = true;
            this.chkIsDefault.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsDefault.Size = new System.Drawing.Size(161, 31);
            this.chkIsDefault.TabIndex = 13;
            this.chkIsDefault.Visible = false;
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveClose.ImageOptions.Image")));
            this.btnSaveClose.Location = new System.Drawing.Point(168, 5);
            this.btnSaveClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(185, 50);
            this.btnSaveClose.TabIndex = 0;
            this.btnSaveClose.Text = "ذخیره و بستن";
            this.btnSaveClose.ToolTip = "F2";
            this.btnSaveClose.ToolTipTitle = "ذخیره و بستن";
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // FrmTarifSandogh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 652);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmTarifSandogh.IconOptions.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTarifSandogh";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات و معرفی صندوق";
            this.Load += new System.EventHandler(this.FrmTarifSandogh_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTarifSandogh_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameSandogh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameModir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarikhEjad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTell.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDefault.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraEditors.SimpleButton btnSaveClose;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        public DevExpress.XtraEditors.TextEdit txtMobile;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.TextEdit txtTarikhEjad;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.TextEdit txtTell;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        public DevExpress.XtraEditors.TextEdit txtAdress;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        public DevExpress.XtraEditors.TextEdit txtNameModir;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit txtNameSandogh;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnBrowsPictuer;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        public DevExpress.XtraEditors.CheckEdit chkIsDefault;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn MasolinName;
        private DevExpress.XtraGrid.Columns.GridColumn SematName;
        private DevExpress.XtraGrid.Columns.GridColumn MobilNumber;
        private DevExpress.XtraGrid.Columns.GridColumn StartDate;
        private DevExpress.XtraGrid.Columns.GridColumn EndDate;
        private DevExpress.XtraGrid.Columns.GridColumn Tozihat;
    }
}