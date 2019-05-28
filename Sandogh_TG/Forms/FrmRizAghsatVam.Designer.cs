namespace Sandogh_TG
{
    partial class FrmRizAghsatVam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRizAghsatVam));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveClose = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cmbDaryaftKonande = new DevExpress.XtraEditors.LookUpEdit();
            this.allHesabTafzilisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.xtraScrollableControl2 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.txtShomareGhest = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtMablaghGest = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtSarresidGhest = new DevExpress.XtraEditors.TextEdit();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDaryaftKonande.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allHesabTafzilisBindingSource)).BeginInit();
            this.xtraScrollableControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShomareGhest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMablaghGest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSarresidGhest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Controls.Add(this.btnSaveNext);
            this.panelControl2.Controls.Add(this.btnSaveClose);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 249);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(491, 60);
            this.panelControl2.TabIndex = 26;
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(6, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 50);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "بستن ";
            this.btnClose.ToolTip = "Escape";
            this.btnClose.ToolTipTitle = "بستن ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveNext
            // 
            this.btnSaveNext.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSaveNext.ImageOptions.SvgImage")));
            this.btnSaveNext.Location = new System.Drawing.Point(312, 6);
            this.btnSaveNext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveNext.Name = "btnSaveNext";
            this.btnSaveNext.Size = new System.Drawing.Size(174, 50);
            this.btnSaveNext.TabIndex = 0;
            this.btnSaveNext.Text = "ذخیره و بعدی";
            this.btnSaveNext.ToolTip = "F9";
            this.btnSaveNext.ToolTipTitle = "ذخیره و بعدی";
            this.btnSaveNext.Click += new System.EventHandler(this.btnSaveNext_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveClose.ImageOptions.Image")));
            this.btnSaveClose.Location = new System.Drawing.Point(131, 6);
            this.btnSaveClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(174, 50);
            this.btnSaveClose.TabIndex = 1;
            this.btnSaveClose.Text = "ذخیره و بستن";
            this.btnSaveClose.ToolTip = "F5";
            this.btnSaveClose.ToolTipTitle = "ذخیره و بستن";
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.AutoEllipsis = true;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(373, 14);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(83, 40);
            this.labelControl5.TabIndex = 31;
            this.labelControl5.Text = "گیرنده وام";
            // 
            // cmbDaryaftKonande
            // 
            this.cmbDaryaftKonande.EnterMoveNextControl = true;
            this.cmbDaryaftKonande.Location = new System.Drawing.Point(15, 15);
            this.cmbDaryaftKonande.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbDaryaftKonande.Name = "cmbDaryaftKonande";
            this.cmbDaryaftKonande.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDaryaftKonande.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "نام و نام خانوادگی", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmbDaryaftKonande.Properties.DataSource = this.allHesabTafzilisBindingSource;
            this.cmbDaryaftKonande.Properties.DisplayMember = "Name";
            this.cmbDaryaftKonande.Properties.ImmediatePopup = true;
            this.cmbDaryaftKonande.Properties.MaxLength = 5;
            this.cmbDaryaftKonande.Properties.NullText = "";
            this.cmbDaryaftKonande.Properties.ReadOnly = true;
            this.cmbDaryaftKonande.Properties.ValueMember = "Id";
            this.cmbDaryaftKonande.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbDaryaftKonande.Size = new System.Drawing.Size(351, 38);
            this.cmbDaryaftKonande.TabIndex = 15;
            this.cmbDaryaftKonande.TabStop = false;
            // 
            // allHesabTafzilisBindingSource
            // 
            this.allHesabTafzilisBindingSource.DataSource = typeof(Sandogh_TG.AllHesabTafzili);
            // 
            // xtraScrollableControl2
            // 
            this.xtraScrollableControl2.Controls.Add(this.txtShomareGhest);
            this.xtraScrollableControl2.Controls.Add(this.labelControl4);
            this.xtraScrollableControl2.Controls.Add(this.txtMablaghGest);
            this.xtraScrollableControl2.Controls.Add(this.labelControl12);
            this.xtraScrollableControl2.Controls.Add(this.txtSarresidGhest);
            this.xtraScrollableControl2.Controls.Add(this.labelControl20);
            this.xtraScrollableControl2.Controls.Add(this.txtCode);
            this.xtraScrollableControl2.Controls.Add(this.labelControl7);
            this.xtraScrollableControl2.Controls.Add(this.panelControl2);
            this.xtraScrollableControl2.Controls.Add(this.labelControl5);
            this.xtraScrollableControl2.Controls.Add(this.cmbDaryaftKonande);
            this.xtraScrollableControl2.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xtraScrollableControl2.Name = "xtraScrollableControl2";
            this.xtraScrollableControl2.Size = new System.Drawing.Size(491, 309);
            this.xtraScrollableControl2.TabIndex = 36;
            // 
            // txtShomareGhest
            // 
            this.txtShomareGhest.EditValue = "";
            this.txtShomareGhest.EnterMoveNextControl = true;
            this.txtShomareGhest.Location = new System.Drawing.Point(249, 109);
            this.txtShomareGhest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtShomareGhest.Name = "txtShomareGhest";
            this.txtShomareGhest.Properties.Appearance.Options.UseTextOptions = true;
            this.txtShomareGhest.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtShomareGhest.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtShomareGhest.Properties.Mask.EditMask = "000000";
            this.txtShomareGhest.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtShomareGhest.Properties.MaxLength = 7;
            this.txtShomareGhest.Properties.ReadOnly = true;
            this.txtShomareGhest.Size = new System.Drawing.Size(116, 38);
            this.txtShomareGhest.TabIndex = 67;
            this.txtShomareGhest.TabStop = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(373, 113);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 31);
            this.labelControl4.TabIndex = 68;
            this.labelControl4.Text = "قسط";
            // 
            // txtMablaghGest
            // 
            this.txtMablaghGest.EditValue = "";
            this.txtMablaghGest.EnterMoveNextControl = true;
            this.txtMablaghGest.Location = new System.Drawing.Point(196, 202);
            this.txtMablaghGest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMablaghGest.Name = "txtMablaghGest";
            this.txtMablaghGest.Properties.Appearance.Options.UseTextOptions = true;
            this.txtMablaghGest.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtMablaghGest.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtMablaghGest.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMablaghGest.Properties.Mask.EditMask = "n";
            this.txtMablaghGest.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMablaghGest.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMablaghGest.Properties.MaxLength = 16;
            this.txtMablaghGest.Size = new System.Drawing.Size(170, 38);
            this.txtMablaghGest.TabIndex = 1;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl12.Appearance.Options.UseForeColor = true;
            this.labelControl12.Location = new System.Drawing.Point(373, 206);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(80, 31);
            this.labelControl12.TabIndex = 57;
            this.labelControl12.Text = "مبلغ قسط";
            // 
            // txtSarresidGhest
            // 
            this.txtSarresidGhest.EnterMoveNextControl = true;
            this.txtSarresidGhest.Location = new System.Drawing.Point(196, 156);
            this.txtSarresidGhest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSarresidGhest.Name = "txtSarresidGhest";
            this.txtSarresidGhest.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSarresidGhest.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtSarresidGhest.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtSarresidGhest.Properties.Mask.BeepOnError = true;
            this.txtSarresidGhest.Properties.Mask.EditMask = "([1-9][3-9][0-9][0-9])/(((0[1-6])/([012][1-9]|[123]0|31))|((0[7-9]|1[01])/([012][" +
    "1-9]|[123]0))|((1[2])/([012][1-9])))";
            this.txtSarresidGhest.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSarresidGhest.Properties.Mask.PlaceHolder = '-';
            this.txtSarresidGhest.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtSarresidGhest.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSarresidGhest.Size = new System.Drawing.Size(170, 38);
            this.txtSarresidGhest.TabIndex = 0;
            // 
            // labelControl20
            // 
            this.labelControl20.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl20.Appearance.Options.UseForeColor = true;
            this.labelControl20.Location = new System.Drawing.Point(373, 159);
            this.labelControl20.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(105, 31);
            this.labelControl20.TabIndex = 55;
            this.labelControl20.Text = "سررسید قسط";
            // 
            // txtCode
            // 
            this.txtCode.EditValue = "";
            this.txtCode.EnterMoveNextControl = true;
            this.txtCode.Location = new System.Drawing.Point(196, 62);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCode.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtCode.Properties.Mask.EditMask = "000000";
            this.txtCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCode.Properties.MaxLength = 7;
            this.txtCode.Properties.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(170, 38);
            this.txtCode.TabIndex = 44;
            this.txtCode.TabStop = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Location = new System.Drawing.Point(374, 66);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(51, 31);
            this.labelControl7.TabIndex = 45;
            this.labelControl7.Text = "کد وام";
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.xtraScrollableControl2);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(494, 311);
            this.panelControl4.TabIndex = 35;
            // 
            // FrmRizAghsatVam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 311);
            this.Controls.Add(this.panelControl4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRizAghsatVam";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اقساط وام";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRizAghsatVam_FormClosing);
            this.Load += new System.EventHandler(this.FrmRizAghsatVam_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRizAghsatVam_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbDaryaftKonande.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allHesabTafzilisBindingSource)).EndInit();
            this.xtraScrollableControl2.ResumeLayout(false);
            this.xtraScrollableControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShomareGhest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMablaghGest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSarresidGhest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSaveClose;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.LookUpEdit cmbDaryaftKonande;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl2;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        public DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.TextEdit txtSarresidGhest;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        public DevExpress.XtraEditors.TextEdit txtMablaghGest;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.SimpleButton btnSaveNext;
        public DevExpress.XtraEditors.TextEdit txtShomareGhest;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.BindingSource allHesabTafzilisBindingSource;
    }
}