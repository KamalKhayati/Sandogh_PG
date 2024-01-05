namespace Sandogh_PG.Forms
{
    partial class FrmChangeSaghfeEtebar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChangeSaghfeEtebar));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.txtMazrabEtebar2 = new DevExpress.XtraEditors.TextEdit();
            this.txtXBrabarSarmaye2 = new DevExpress.XtraEditors.TextEdit();
            this.txtXBrabarSarmaye = new DevExpress.XtraEditors.TextEdit();
            this.txtMazrabEtebar = new DevExpress.XtraEditors.TextEdit();
            this.txtSaghfeEtebar = new DevExpress.XtraEditors.TextEdit();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSaveAndClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMazrabEtebar2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXBrabarSarmaye2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXBrabarSarmaye.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMazrabEtebar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaghfeEtebar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(725, 272);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.txtMazrabEtebar2);
            this.xtraTabPage1.Controls.Add(this.txtXBrabarSarmaye2);
            this.xtraTabPage1.Controls.Add(this.txtXBrabarSarmaye);
            this.xtraTabPage1.Controls.Add(this.txtMazrabEtebar);
            this.xtraTabPage1.Controls.Add(this.txtSaghfeEtebar);
            this.xtraTabPage1.Controls.Add(this.radioGroup1);
            this.xtraTabPage1.Controls.Add(this.panelControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(723, 231);
            this.xtraTabPage1.Text = "ویرایش مبلغ سقف اعتبار";
            // 
            // txtMazrabEtebar2
            // 
            this.txtMazrabEtebar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMazrabEtebar2.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtMazrabEtebar2.EnterMoveNextControl = true;
            this.txtMazrabEtebar2.Location = new System.Drawing.Point(72, 131);
            this.txtMazrabEtebar2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMazrabEtebar2.Name = "txtMazrabEtebar2";
            this.txtMazrabEtebar2.Properties.Appearance.Options.UseTextOptions = true;
            this.txtMazrabEtebar2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtMazrabEtebar2.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtMazrabEtebar2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMazrabEtebar2.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtMazrabEtebar2.Properties.MaskSettings.Set("mask", "n");
            this.txtMazrabEtebar2.Size = new System.Drawing.Size(166, 34);
            this.txtMazrabEtebar2.TabIndex = 53;
            // 
            // txtXBrabarSarmaye2
            // 
            this.txtXBrabarSarmaye2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXBrabarSarmaye2.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtXBrabarSarmaye2.EnterMoveNextControl = true;
            this.txtXBrabarSarmaye2.Location = new System.Drawing.Point(479, 131);
            this.txtXBrabarSarmaye2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtXBrabarSarmaye2.Name = "txtXBrabarSarmaye2";
            this.txtXBrabarSarmaye2.Properties.Appearance.Options.UseTextOptions = true;
            this.txtXBrabarSarmaye2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtXBrabarSarmaye2.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtXBrabarSarmaye2.Properties.DisplayFormat.FormatString = "0.00";
            this.txtXBrabarSarmaye2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtXBrabarSarmaye2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtXBrabarSarmaye2.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtXBrabarSarmaye2.Properties.MaskSettings.Set("mask", "###.##");
            this.txtXBrabarSarmaye2.Properties.MaskSettings.Set("valueType", typeof(double));
            this.txtXBrabarSarmaye2.Properties.MaskSettings.Set("autoHideDecimalSeparator", true);
            this.txtXBrabarSarmaye2.Properties.MaskSettings.Set("hideInsignificantZeros", true);
            this.txtXBrabarSarmaye2.Size = new System.Drawing.Size(61, 34);
            this.txtXBrabarSarmaye2.TabIndex = 52;
            this.txtXBrabarSarmaye2.EditValueChanged += new System.EventHandler(this.txtXBrabarSarmaye2_EditValueChanged);
            // 
            // txtXBrabarSarmaye
            // 
            this.txtXBrabarSarmaye.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXBrabarSarmaye.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtXBrabarSarmaye.EnterMoveNextControl = true;
            this.txtXBrabarSarmaye.Location = new System.Drawing.Point(479, 73);
            this.txtXBrabarSarmaye.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtXBrabarSarmaye.Name = "txtXBrabarSarmaye";
            this.txtXBrabarSarmaye.Properties.Appearance.Options.UseTextOptions = true;
            this.txtXBrabarSarmaye.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtXBrabarSarmaye.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtXBrabarSarmaye.Properties.DisplayFormat.FormatString = "0.00";
            this.txtXBrabarSarmaye.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtXBrabarSarmaye.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtXBrabarSarmaye.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtXBrabarSarmaye.Properties.MaskSettings.Set("mask", "###.##");
            this.txtXBrabarSarmaye.Properties.MaskSettings.Set("valueType", typeof(double));
            this.txtXBrabarSarmaye.Properties.MaskSettings.Set("autoHideDecimalSeparator", true);
            this.txtXBrabarSarmaye.Properties.MaskSettings.Set("hideInsignificantZeros", true);
            this.txtXBrabarSarmaye.Size = new System.Drawing.Size(61, 34);
            this.txtXBrabarSarmaye.TabIndex = 51;
            this.txtXBrabarSarmaye.EditValueChanged += new System.EventHandler(this.txtXBrabarSarmaye_EditValueChanged);
            // 
            // txtMazrabEtebar
            // 
            this.txtMazrabEtebar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMazrabEtebar.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtMazrabEtebar.EnterMoveNextControl = true;
            this.txtMazrabEtebar.Location = new System.Drawing.Point(82, 73);
            this.txtMazrabEtebar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMazrabEtebar.Name = "txtMazrabEtebar";
            this.txtMazrabEtebar.Properties.Appearance.Options.UseTextOptions = true;
            this.txtMazrabEtebar.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtMazrabEtebar.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtMazrabEtebar.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMazrabEtebar.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtMazrabEtebar.Properties.MaskSettings.Set("mask", "n");
            this.txtMazrabEtebar.Size = new System.Drawing.Size(166, 34);
            this.txtMazrabEtebar.TabIndex = 50;
            // 
            // txtSaghfeEtebar
            // 
            this.txtSaghfeEtebar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaghfeEtebar.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtSaghfeEtebar.EnterMoveNextControl = true;
            this.txtSaghfeEtebar.Location = new System.Drawing.Point(251, 17);
            this.txtSaghfeEtebar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSaghfeEtebar.Name = "txtSaghfeEtebar";
            this.txtSaghfeEtebar.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSaghfeEtebar.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtSaghfeEtebar.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtSaghfeEtebar.Properties.Mask.EditMask = "n";
            this.txtSaghfeEtebar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSaghfeEtebar.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtSaghfeEtebar.Size = new System.Drawing.Size(166, 34);
            this.txtSaghfeEtebar.TabIndex = 44;
            this.txtSaghfeEtebar.EditValueChanged += new System.EventHandler(this.txtSaghfeEtebar_EditValueChanged);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup1.Location = new System.Drawing.Point(0, 0);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "مبلغ سقف اعتبار جدید (بصورت یکسان)", true, null, ""),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "مبلغ سقف اعتبار جدید               برابر مبلغ کل سرمایه و مضربی از               " +
                    "                     باشد"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "مبلغ سقف اعتبار جدید               برابر مبلغ سرمایه اولیه و مضربی از            " +
                    "                        باشد")});
            this.radioGroup1.Size = new System.Drawing.Size(723, 184);
            this.radioGroup1.TabIndex = 48;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSaveAndClose);
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 184);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(723, 47);
            this.panelControl1.TabIndex = 49;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSaveAndClose.Enabled = false;
            this.btnSaveAndClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSaveAndClose.ImageOptions.SvgImage")));
            this.btnSaveAndClose.Location = new System.Drawing.Point(179, 2);
            this.btnSaveAndClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(152, 40);
            this.btnSaveAndClose.TabIndex = 46;
            this.btnSaveAndClose.Text = "ذخیره و بستن";
            this.btnSaveAndClose.ToolTip = "F4";
            this.btnSaveAndClose.ToolTipTitle = "ذخیره و بستن";
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(12, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(159, 40);
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "انصراف و بستن";
            this.btnClose.ToolTip = "Escape";
            this.btnClose.ToolTipTitle = "انصراف و بستن";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmChangeSaghfeEtebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 272);
            this.Controls.Add(this.xtraTabControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmChangeSaghfeEtebar.IconOptions.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(727, 312);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(683, 253);
            this.Name = "FrmChangeSaghfeEtebar";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تغییر سقف اعتبار";
            this.Load += new System.EventHandler(this.FrmChangeSaghfeEtebar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMazrabEtebar2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXBrabarSarmaye2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXBrabarSarmaye.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMazrabEtebar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaghfeEtebar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSaveAndClose;
        public DevExpress.XtraEditors.TextEdit txtSaghfeEtebar;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        public DevExpress.XtraEditors.TextEdit txtXBrabarSarmaye;
        public DevExpress.XtraEditors.TextEdit txtMazrabEtebar;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraEditors.TextEdit txtMazrabEtebar2;
        public DevExpress.XtraEditors.TextEdit txtXBrabarSarmaye2;
    }
}