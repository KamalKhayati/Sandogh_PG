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
            this.txtSaghfeEtebar = new DevExpress.XtraEditors.TextEdit();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveAndClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaghfeEtebar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(555, 213);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.txtSaghfeEtebar);
            this.xtraTabPage1.Controls.Add(this.radioGroup1);
            this.xtraTabPage1.Controls.Add(this.btnClose);
            this.xtraTabPage1.Controls.Add(this.btnSaveAndClose);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(553, 172);
            this.xtraTabPage1.Text = "ویرایش مبلغ سقف اعتبار";
            // 
            // txtSaghfeEtebar
            // 
            this.txtSaghfeEtebar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaghfeEtebar.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtSaghfeEtebar.EnterMoveNextControl = true;
            this.txtSaghfeEtebar.Location = new System.Drawing.Point(64, 17);
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
            this.radioGroup1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioGroup1.Location = new System.Drawing.Point(3, 3);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "مبلغ سقف اعتبار جدید (بصورت یکسان)", true, null, ""),
            new DevExpress.XtraEditors.Controls.RadioGroupItem()});
            this.radioGroup1.Size = new System.Drawing.Size(545, 116);
            this.radioGroup1.TabIndex = 48;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(5, 125);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(159, 40);
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "انصراف و بستن";
            this.btnClose.ToolTip = "Escape";
            this.btnClose.ToolTipTitle = "انصراف و بستن";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSaveAndClose.Enabled = false;
            this.btnSaveAndClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSaveAndClose.ImageOptions.SvgImage")));
            this.btnSaveAndClose.Location = new System.Drawing.Point(172, 125);
            this.btnSaveAndClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(152, 40);
            this.btnSaveAndClose.TabIndex = 46;
            this.btnSaveAndClose.Text = "ذخیره و بستن";
            this.btnSaveAndClose.ToolTip = "F4";
            this.btnSaveAndClose.ToolTipTitle = "ذخیره و بستن";
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // FrmChangeSaghfeEtebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 213);
            this.Controls.Add(this.xtraTabControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmChangeSaghfeEtebar.IconOptions.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChangeSaghfeEtebar";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تغییر سقف اعتبار";
            this.Load += new System.EventHandler(this.FrmChangeSaghfeEtebar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSaghfeEtebar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSaveAndClose;
        public DevExpress.XtraEditors.TextEdit txtSaghfeEtebar;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
    }
}