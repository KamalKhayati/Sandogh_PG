﻿namespace Sandogh_PG
{
    partial class FrmDaryaftHaghOzviat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDaryaftHaghOzviat));
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.cmbPardakhtKonande = new DevExpress.XtraEditors.LookUpEdit();
            this.allHesabTafzilisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.txtSeryal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.txtSharh = new DevExpress.XtraEditors.TextEdit();
            this.txtTarikh = new DevExpress.XtraEditors.TextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnSaveNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveClose = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.txtMablagh = new DevExpress.XtraEditors.TextEdit();
            this.xtraScrollableControl2 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.cmbMoin = new DevExpress.XtraEditors.LookUpEdit();
            this.codeMoinsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtSal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.cmbNameHesab = new DevExpress.XtraEditors.LookUpEdit();
            this.allHesabTafzilisBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cmbMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPardakhtKonande.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allHesabTafzilisBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeryal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSharh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarikh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMablagh.Properties)).BeginInit();
            this.xtraScrollableControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMoin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeMoinsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNameHesab.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allHesabTafzilisBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMonth.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl4
            // 
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(663, 398);
            this.panelControl4.TabIndex = 33;
            // 
            // cmbPardakhtKonande
            // 
            this.cmbPardakhtKonande.EnterMoveNextControl = true;
            this.cmbPardakhtKonande.Location = new System.Drawing.Point(136, 6);
            this.cmbPardakhtKonande.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPardakhtKonande.Name = "cmbPardakhtKonande";
            this.cmbPardakhtKonande.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPardakhtKonande.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "آیدی", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "نام و نام خانوادگی", 500, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmbPardakhtKonande.Properties.DataSource = this.allHesabTafzilisBindingSource;
            this.cmbPardakhtKonande.Properties.DisplayMember = "Name";
            this.cmbPardakhtKonande.Properties.ImmediatePopup = true;
            this.cmbPardakhtKonande.Properties.MaxLength = 150;
            this.cmbPardakhtKonande.Properties.NullText = "";
            this.cmbPardakhtKonande.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cmbPardakhtKonande.Properties.PopupWidth = 500;
            this.cmbPardakhtKonande.Properties.ReadOnly = true;
            this.cmbPardakhtKonande.Properties.ValueMember = "Id";
            this.cmbPardakhtKonande.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbPardakhtKonande.Size = new System.Drawing.Size(398, 38);
            this.cmbPardakhtKonande.TabIndex = 15;
            this.cmbPardakhtKonande.TabStop = false;
            // 
            // allHesabTafzilisBindingSource
            // 
            this.allHesabTafzilisBindingSource.DataSource = typeof(Sandogh_PG.AllHesabTafzili);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(592, 59);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 31);
            this.labelControl1.TabIndex = 26;
            this.labelControl1.Text = "سریال";
            // 
            // txtId
            // 
            this.txtId.EditValue = "آیدی ";
            this.txtId.Location = new System.Drawing.Point(397, 55);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtId.Properties.Mask.EditMask = "f0";
            this.txtId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtId.Properties.NullText = "آیدی انبار";
            this.txtId.Properties.ReadOnly = true;
            this.txtId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtId.Size = new System.Drawing.Size(65, 38);
            this.txtId.TabIndex = 28;
            this.txtId.TabStop = false;
            this.txtId.Visible = false;
            // 
            // txtSeryal
            // 
            this.txtSeryal.EditValue = "";
            this.txtSeryal.EnterMoveNextControl = true;
            this.txtSeryal.Location = new System.Drawing.Point(469, 55);
            this.txtSeryal.Margin = new System.Windows.Forms.Padding(4);
            this.txtSeryal.Name = "txtSeryal";
            this.txtSeryal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSeryal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtSeryal.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtSeryal.Properties.Mask.EditMask = "000000";
            this.txtSeryal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSeryal.Properties.MaxLength = 7;
            this.txtSeryal.Properties.ReadOnly = true;
            this.txtSeryal.Size = new System.Drawing.Size(116, 38);
            this.txtSeryal.TabIndex = 20;
            this.txtSeryal.TabStop = false;
            // 
            // labelControl5
            // 
            this.labelControl5.AutoEllipsis = true;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(541, 4);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(115, 40);
            this.labelControl5.TabIndex = 31;
            this.labelControl5.Text = "پرداخت کننده";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.AutoEllipsis = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(592, 101);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 40);
            this.labelControl2.TabIndex = 30;
            this.labelControl2.Text = "تاریخ";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.AutoEllipsis = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(592, 193);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 40);
            this.labelControl3.TabIndex = 31;
            this.labelControl3.Text = "واریز به ";
            // 
            // labelControl14
            // 
            this.labelControl14.AutoEllipsis = true;
            this.labelControl14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl14.Location = new System.Drawing.Point(592, 286);
            this.labelControl14.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(44, 40);
            this.labelControl14.TabIndex = 31;
            this.labelControl14.Text = "شرح ";
            // 
            // txtSharh
            // 
            this.txtSharh.EnterMoveNextControl = true;
            this.txtSharh.Location = new System.Drawing.Point(4, 288);
            this.txtSharh.Margin = new System.Windows.Forms.Padding(4);
            this.txtSharh.Name = "txtSharh";
            this.txtSharh.Properties.MaxLength = 400;
            this.txtSharh.Size = new System.Drawing.Size(581, 38);
            this.txtSharh.TabIndex = 6;
            // 
            // txtTarikh
            // 
            this.txtTarikh.EnterMoveNextControl = true;
            this.txtTarikh.Location = new System.Drawing.Point(397, 102);
            this.txtTarikh.Margin = new System.Windows.Forms.Padding(4);
            this.txtTarikh.Name = "txtTarikh";
            this.txtTarikh.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTarikh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtTarikh.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtTarikh.Properties.Mask.BeepOnError = true;
            this.txtTarikh.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtTarikh.Properties.Mask.PlaceHolder = '-';
            this.txtTarikh.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTarikh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTarikh.Size = new System.Drawing.Size(188, 38);
            this.txtTarikh.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnSaveNext);
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Controls.Add(this.btnSaveClose);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 334);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(663, 60);
            this.panelControl2.TabIndex = 35;
            // 
            // btnSaveNext
            // 
            this.btnSaveNext.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSaveNext.ImageOptions.SvgImage")));
            this.btnSaveNext.Location = new System.Drawing.Point(476, 6);
            this.btnSaveNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveNext.Name = "btnSaveNext";
            this.btnSaveNext.Size = new System.Drawing.Size(174, 50);
            this.btnSaveNext.TabIndex = 1;
            this.btnSaveNext.Text = "ذخیره و بعدی";
            this.btnSaveNext.ToolTip = "F9";
            this.btnSaveNext.ToolTipTitle = "ذخیره و بعدی";
            this.btnSaveNext.Click += new System.EventHandler(this.btnSaveNext_Click);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(13, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 50);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "بستن ";
            this.btnClose.ToolTip = "Escape";
            this.btnClose.ToolTipTitle = "بستن ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveClose.ImageOptions.Image")));
            this.btnSaveClose.Location = new System.Drawing.Point(143, 6);
            this.btnSaveClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(174, 50);
            this.btnSaveClose.TabIndex = 0;
            this.btnSaveClose.Text = "ذخیره و بستن";
            this.btnSaveClose.ToolTip = "F5";
            this.btnSaveClose.ToolTipTitle = "ذخیره و بستن";
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl19.Appearance.Options.UseForeColor = true;
            this.labelControl19.AutoEllipsis = true;
            this.labelControl19.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl19.Location = new System.Drawing.Point(592, 148);
            this.labelControl19.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(39, 40);
            this.labelControl19.TabIndex = 43;
            this.labelControl19.Text = "مبلغ";
            // 
            // txtMablagh
            // 
            this.txtMablagh.EnterMoveNextControl = true;
            this.txtMablagh.Location = new System.Drawing.Point(397, 149);
            this.txtMablagh.Margin = new System.Windows.Forms.Padding(4);
            this.txtMablagh.Name = "txtMablagh";
            this.txtMablagh.Properties.Appearance.Options.UseTextOptions = true;
            this.txtMablagh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtMablagh.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtMablagh.Properties.Mask.EditMask = "n";
            this.txtMablagh.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMablagh.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMablagh.Size = new System.Drawing.Size(188, 38);
            this.txtMablagh.TabIndex = 1;
            this.txtMablagh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMablagh_KeyPress);
            // 
            // xtraScrollableControl2
            // 
            this.xtraScrollableControl2.Controls.Add(this.cmbMoin);
            this.xtraScrollableControl2.Controls.Add(this.txtSal);
            this.xtraScrollableControl2.Controls.Add(this.txtMablagh);
            this.xtraScrollableControl2.Controls.Add(this.labelControl19);
            this.xtraScrollableControl2.Controls.Add(this.panelControl2);
            this.xtraScrollableControl2.Controls.Add(this.txtTarikh);
            this.xtraScrollableControl2.Controls.Add(this.txtSharh);
            this.xtraScrollableControl2.Controls.Add(this.labelControl14);
            this.xtraScrollableControl2.Controls.Add(this.labelControl4);
            this.xtraScrollableControl2.Controls.Add(this.labelControl6);
            this.xtraScrollableControl2.Controls.Add(this.labelControl3);
            this.xtraScrollableControl2.Controls.Add(this.labelControl2);
            this.xtraScrollableControl2.Controls.Add(this.labelControl5);
            this.xtraScrollableControl2.Controls.Add(this.textEdit1);
            this.xtraScrollableControl2.Controls.Add(this.txtSeryal);
            this.xtraScrollableControl2.Controls.Add(this.txtId);
            this.xtraScrollableControl2.Controls.Add(this.labelControl1);
            this.xtraScrollableControl2.Controls.Add(this.cmbNameHesab);
            this.xtraScrollableControl2.Controls.Add(this.cmbPardakhtKonande);
            this.xtraScrollableControl2.Controls.Add(this.cmbMonth);
            this.xtraScrollableControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraScrollableControl2.Location = new System.Drawing.Point(0, 4);
            this.xtraScrollableControl2.Margin = new System.Windows.Forms.Padding(4);
            this.xtraScrollableControl2.Name = "xtraScrollableControl2";
            this.xtraScrollableControl2.Size = new System.Drawing.Size(663, 394);
            this.xtraScrollableControl2.TabIndex = 34;
            this.xtraScrollableControl2.TabStop = false;
            // 
            // cmbMoin
            // 
            this.cmbMoin.EnterMoveNextControl = true;
            this.cmbMoin.Location = new System.Drawing.Point(397, 195);
            this.cmbMoin.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMoin.Name = "cmbMoin";
            this.cmbMoin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMoin.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "نام حساب معین :", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmbMoin.Properties.DataSource = this.codeMoinsBindingSource;
            this.cmbMoin.Properties.DisplayMember = "Name";
            this.cmbMoin.Properties.ImmediatePopup = true;
            this.cmbMoin.Properties.MaxLength = 150;
            this.cmbMoin.Properties.NullText = "";
            this.cmbMoin.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cmbMoin.Properties.ValueMember = "Id";
            this.cmbMoin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMoin.Size = new System.Drawing.Size(188, 38);
            this.cmbMoin.TabIndex = 2;
            this.cmbMoin.EditValueChanged += new System.EventHandler(this.cmbMoin_EditValueChanged);
            this.cmbMoin.Enter += new System.EventHandler(this.cmbMoin_Enter);
            // 
            // codeMoinsBindingSource
            // 
            this.codeMoinsBindingSource.DataSource = typeof(Sandogh_PG.CodeMoin);
            // 
            // txtSal
            // 
            this.txtSal.EnterMoveNextControl = true;
            this.txtSal.Location = new System.Drawing.Point(237, 242);
            this.txtSal.Margin = new System.Windows.Forms.Padding(4);
            this.txtSal.Name = "txtSal";
            this.txtSal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtSal.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtSal.Properties.Mask.EditMask = "f";
            this.txtSal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtSal.Size = new System.Drawing.Size(94, 38);
            this.txtSal.TabIndex = 5;
            this.txtSal.EditValueChanged += new System.EventHandler(this.txtSal_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.AutoEllipsis = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(338, 241);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(42, 40);
            this.labelControl4.TabIndex = 31;
            this.labelControl4.Text = "سال";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.AutoEllipsis = true;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(593, 240);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(27, 40);
            this.labelControl6.TabIndex = 31;
            this.labelControl6.Text = "ماه";
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "سرمایه";
            this.textEdit1.EnterMoveNextControl = true;
            this.textEdit1.Location = new System.Drawing.Point(4, 6);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.textEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit1.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.textEdit1.Properties.Mask.EditMask = "000000";
            this.textEdit1.Properties.MaxLength = 7;
            this.textEdit1.Size = new System.Drawing.Size(122, 38);
            this.textEdit1.TabIndex = 20;
            this.textEdit1.TabStop = false;
            // 
            // cmbNameHesab
            // 
            this.cmbNameHesab.EnterMoveNextControl = true;
            this.cmbNameHesab.Location = new System.Drawing.Point(4, 195);
            this.cmbNameHesab.Margin = new System.Windows.Forms.Padding(4);
            this.cmbNameHesab.Name = "cmbNameHesab";
            this.cmbNameHesab.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNameHesab.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "آیدی", 50, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "نام حساب تفضیل :", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmbNameHesab.Properties.DataSource = this.allHesabTafzilisBindingSource1;
            this.cmbNameHesab.Properties.DisplayMember = "Name";
            this.cmbNameHesab.Properties.ImmediatePopup = true;
            this.cmbNameHesab.Properties.MaxLength = 150;
            this.cmbNameHesab.Properties.NullText = "";
            this.cmbNameHesab.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cmbNameHesab.Properties.ValueMember = "Id";
            this.cmbNameHesab.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbNameHesab.Size = new System.Drawing.Size(385, 38);
            this.cmbNameHesab.TabIndex = 3;
            this.cmbNameHesab.Enter += new System.EventHandler(this.cmbNameHesab_Enter);
            // 
            // allHesabTafzilisBindingSource1
            // 
            this.allHesabTafzilisBindingSource1.DataSource = typeof(Sandogh_PG.AllHesabTafzili);
            // 
            // cmbMonth
            // 
            this.cmbMonth.EnterMoveNextControl = true;
            this.cmbMonth.Location = new System.Drawing.Point(397, 241);
            this.cmbMonth.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMonth.Properties.ImmediatePopup = true;
            this.cmbMonth.Properties.Items.AddRange(new object[] {
            "فروردین",
            "اردیبهشت",
            "خرداد",
            "تیر",
            "مرداد",
            "شهریور",
            "مهر",
            "آبان",
            "آذر",
            "دی ",
            "بهمن",
            "اسفند"});
            this.cmbMonth.Properties.MaxLength = 5;
            this.cmbMonth.Properties.PopupSizeable = true;
            this.cmbMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbMonth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMonth.Size = new System.Drawing.Size(188, 38);
            this.cmbMonth.TabIndex = 4;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            this.cmbMonth.Enter += new System.EventHandler(this.cmbMonth_Enter);
            // 
            // FrmDaryaftHaghOzviat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 398);
            this.Controls.Add(this.xtraScrollableControl2);
            this.Controls.Add(this.panelControl4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDaryaftHaghOzviat";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دریافت پس انداز ماهیانه";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDaryaftHaghOzviat_FormClosing);
            this.Load += new System.EventHandler(this.FrmDaryaftHaghOzviat_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDaryaftHaghOzviat_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPardakhtKonande.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allHesabTafzilisBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeryal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSharh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarikh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMablagh.Properties)).EndInit();
            this.xtraScrollableControl2.ResumeLayout(false);
            this.xtraScrollableControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMoin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeMoinsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNameHesab.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allHesabTafzilisBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMonth.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit txtId;
        public DevExpress.XtraEditors.TextEdit txtSeryal;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        public DevExpress.XtraEditors.TextEdit txtSharh;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSaveClose;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        public DevExpress.XtraEditors.TextEdit txtMablagh;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.LookUpEdit cmbPardakhtKonande;
        public DevExpress.XtraEditors.TextEdit txtTarikh;
        public DevExpress.XtraEditors.LookUpEdit cmbNameHesab;
        public DevExpress.XtraEditors.ComboBoxEdit cmbMonth;
        public DevExpress.XtraEditors.TextEdit txtSal;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnSaveNext;
        public DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.BindingSource allHesabTafzilisBindingSource;
        private System.Windows.Forms.BindingSource allHesabTafzilisBindingSource1;
        public DevExpress.XtraEditors.LookUpEdit cmbMoin;
        private System.Windows.Forms.BindingSource codeMoinsBindingSource;
    }
}