namespace Sandogh_PG.Forms
{
    partial class RepairDataBase1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepairDataBase1));
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnOK88_2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.AutoEllipsis = true;
            this.labelControl4.Location = new System.Drawing.Point(109, 4);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(485, 27);
            this.labelControl4.TabIndex = 32;
            this.labelControl4.Text = "جهت اعمال تغییرات ورژن جدید در دیتابیس ، روی دکمه تأیید کلیک کنید";
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.groupControl1);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 35);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(699, 393);
            this.xtraScrollableControl1.TabIndex = 35;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnOK88_2);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(699, 89);
            this.groupControl1.TabIndex = 35;
            this.groupControl1.Text = "V 1.0.0.88";
            // 
            // btnOK88_2
            // 
            this.btnOK88_2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOK88_2.ImageOptions.Image")));
            this.btnOK88_2.Location = new System.Drawing.Point(6, 41);
            this.btnOK88_2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOK88_2.Name = "btnOK88_2";
            this.btnOK88_2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnOK88_2.Size = new System.Drawing.Size(105, 31);
            this.btnOK88_2.TabIndex = 36;
            this.btnOK88_2.Text = "تأیید";
            this.btnOK88_2.Click += new System.EventHandler(this.btnOK88_2_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.AutoEllipsis = true;
            this.labelControl2.Location = new System.Drawing.Point(373, 39);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(320, 27);
            this.labelControl2.TabIndex = 35;
            this.labelControl2.Text = "درج تاریخ سررسید پس انداز ماهیانه در دیتابیس";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(699, 35);
            this.panelControl1.TabIndex = 36;
            // 
            // RepairDataBase1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 428);
            this.Controls.Add(this.xtraScrollableControl1);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(701, 468);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(701, 468);
            this.Name = "RepairDataBase1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اعمال تغییرات در دیتابیس";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RepairDataBase1_FormClosed);
            this.Load += new System.EventHandler(this.RepairDataBase1_Load);
            this.xtraScrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraEditors.SimpleButton btnOK88_2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}