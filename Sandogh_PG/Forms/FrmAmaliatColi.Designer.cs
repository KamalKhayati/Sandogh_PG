namespace Sandogh_PG.Forms
{
    partial class FrmAmaliatColi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAmaliatColi));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.txtHaghOzviat = new DevExpress.XtraEditors.TextEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.btnSaveAndClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHaghOzviat.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(341, 152);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btnClose);
            this.xtraTabPage1.Controls.Add(this.btnSaveAndClose);
            this.xtraTabPage1.Controls.Add(this.txtHaghOzviat);
            this.xtraTabPage1.Controls.Add(this.labelControl18);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(339, 111);
            this.xtraTabPage1.Text = "ویرایش کلی مبلغ پس انداز ماهیانه اعضاء";
            // 
            // txtHaghOzviat
            // 
            this.txtHaghOzviat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHaghOzviat.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtHaghOzviat.EnterMoveNextControl = true;
            this.txtHaghOzviat.Location = new System.Drawing.Point(8, 12);
            this.txtHaghOzviat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtHaghOzviat.Name = "txtHaghOzviat";
            this.txtHaghOzviat.Properties.Appearance.Options.UseTextOptions = true;
            this.txtHaghOzviat.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtHaghOzviat.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtHaghOzviat.Properties.Mask.EditMask = "n";
            this.txtHaghOzviat.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtHaghOzviat.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtHaghOzviat.Size = new System.Drawing.Size(177, 34);
            this.txtHaghOzviat.TabIndex = 44;
            this.txtHaghOzviat.EditValueChanged += new System.EventHandler(this.txtHaghOzviat_EditValueChanged);
            // 
            // labelControl18
            // 
            this.labelControl18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl18.AutoEllipsis = true;
            this.labelControl18.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelControl18.Location = new System.Drawing.Point(193, 15);
            this.labelControl18.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(134, 27);
            this.labelControl18.TabIndex = 45;
            this.labelControl18.Text = "مبلغ پس انداز جدید";
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSaveAndClose.Enabled = false;
            this.btnSaveAndClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEdit.ImageOptions.SvgImage")));
            this.btnSaveAndClose.Location = new System.Drawing.Point(175, 60);
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
            this.btnClose.Location = new System.Drawing.Point(8, 60);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(159, 40);
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "انصراف و بستن";
            this.btnClose.ToolTip = "Escape";
            this.btnClose.ToolTipTitle = "انصراف و بستن";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmAmaliatColi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 152);
            this.Controls.Add(this.xtraTabControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmAmaliatColi.IconOptions.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAmaliatColi";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "انجام عملیات کلی";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHaghOzviat.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        public DevExpress.XtraEditors.TextEdit txtHaghOzviat;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.SimpleButton btnSaveAndClose;
        public DevExpress.XtraEditors.SimpleButton btnClose;
    }
}