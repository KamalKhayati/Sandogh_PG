namespace Sandogh_TG
{
    partial class XtraForm1
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
            this.txtSubject = new DevExpress.XtraEditors.TextEdit();
            this.txName = new DevExpress.XtraEditors.TextEdit();
            this.dtpDate = new DevExpress.XtraEditors.TextEdit();
            this.btnlettergen = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSubject
            // 
            this.txtSubject.EditValue = "تست ورد";
            this.txtSubject.Location = new System.Drawing.Point(324, 65);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(230, 32);
            this.txtSubject.TabIndex = 0;
            // 
            // txName
            // 
            this.txName.EditValue = "کمال خیاطی";
            this.txName.Location = new System.Drawing.Point(325, 112);
            this.txName.Name = "txName";
            this.txName.Size = new System.Drawing.Size(228, 32);
            this.txName.TabIndex = 1;
            // 
            // dtpDate
            // 
            this.dtpDate.EditValue = "1398/02/15";
            this.dtpDate.Location = new System.Drawing.Point(325, 163);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(228, 32);
            this.dtpDate.TabIndex = 1;
            // 
            // btnlettergen
            // 
            this.btnlettergen.Location = new System.Drawing.Point(330, 219);
            this.btnlettergen.Name = "btnlettergen";
            this.btnlettergen.Size = new System.Drawing.Size(223, 51);
            this.btnlettergen.TabIndex = 2;
            this.btnlettergen.Text = "simpleButton1";
            this.btnlettergen.Click += new System.EventHandler(this.btnlettergen_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(329, 283);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(224, 47);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 571);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnlettergen);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txName);
            this.Controls.Add(this.txtSubject);
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.XtraForm1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtSubject;
        private DevExpress.XtraEditors.TextEdit txName;
        private DevExpress.XtraEditors.TextEdit dtpDate;
        private DevExpress.XtraEditors.SimpleButton btnlettergen;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}