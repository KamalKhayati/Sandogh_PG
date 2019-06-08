namespace Sandogh_PG
{
    partial class FrmBackupRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBackupRestore));
            this.btnStartBackup = new System.Windows.Forms.Button();
            this.txtSelectPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxBackup = new System.Windows.Forms.GroupBox();
            this.btnBrowserBackup = new System.Windows.Forms.Button();
            this.gbxRestore = new System.Windows.Forms.GroupBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBrowserRestore = new System.Windows.Forms.Button();
            this.txtSelectFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorkerBackup = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerRestore = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnRestore = new System.Windows.Forms.RadioButton();
            this.rbtnBackup = new System.Windows.Forms.RadioButton();
            this.gbxBackup.SuspendLayout();
            this.gbxRestore.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartBackup
            // 
            this.btnStartBackup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStartBackup.Location = new System.Drawing.Point(23, 82);
            this.btnStartBackup.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnStartBackup.Name = "btnStartBackup";
            this.btnStartBackup.Size = new System.Drawing.Size(165, 43);
            this.btnStartBackup.TabIndex = 4;
            this.btnStartBackup.Text = "پشتیبان گیری";
            this.btnStartBackup.UseVisualStyleBackColor = true;
            this.btnStartBackup.Click += new System.EventHandler(this.btnStartBackup_Click);
            // 
            // txtSelectPath
            // 
            this.txtSelectPath.Location = new System.Drawing.Point(123, 37);
            this.txtSelectPath.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtSelectPath.Name = "txtSelectPath";
            this.txtSelectPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSelectPath.Size = new System.Drawing.Size(461, 39);
            this.txtSelectPath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(591, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "انتخاب مسیر :";
            // 
            // gbxBackup
            // 
            this.gbxBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxBackup.Controls.Add(this.btnStartBackup);
            this.gbxBackup.Controls.Add(this.btnBrowserBackup);
            this.gbxBackup.Controls.Add(this.txtSelectPath);
            this.gbxBackup.Controls.Add(this.label1);
            this.gbxBackup.Location = new System.Drawing.Point(0, 94);
            this.gbxBackup.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.gbxBackup.Name = "gbxBackup";
            this.gbxBackup.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.gbxBackup.Size = new System.Drawing.Size(814, 162);
            this.gbxBackup.TabIndex = 8;
            this.gbxBackup.TabStop = false;
            this.gbxBackup.Text = "پشتیبان گیری از اطلاعات";
            // 
            // btnBrowserBackup
            // 
            this.btnBrowserBackup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBrowserBackup.Location = new System.Drawing.Point(23, 37);
            this.btnBrowserBackup.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnBrowserBackup.Name = "btnBrowserBackup";
            this.btnBrowserBackup.Size = new System.Drawing.Size(90, 33);
            this.btnBrowserBackup.TabIndex = 5;
            this.btnBrowserBackup.Text = ".....";
            this.btnBrowserBackup.UseVisualStyleBackColor = true;
            this.btnBrowserBackup.Click += new System.EventHandler(this.btnBrowserBackup_Click);
            // 
            // gbxRestore
            // 
            this.gbxRestore.Controls.Add(this.btnRestore);
            this.gbxRestore.Controls.Add(this.btnBrowserRestore);
            this.gbxRestore.Controls.Add(this.txtSelectFile);
            this.gbxRestore.Controls.Add(this.label2);
            this.gbxRestore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbxRestore.Enabled = false;
            this.gbxRestore.Location = new System.Drawing.Point(0, 266);
            this.gbxRestore.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.gbxRestore.Name = "gbxRestore";
            this.gbxRestore.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.gbxRestore.Size = new System.Drawing.Size(814, 174);
            this.gbxRestore.TabIndex = 9;
            this.gbxRestore.TabStop = false;
            this.gbxRestore.Text = "بازیابی اطلاعات";
            // 
            // btnRestore
            // 
            this.btnRestore.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRestore.Location = new System.Drawing.Point(23, 121);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(165, 43);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "بازیابی";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBrowserRestore
            // 
            this.btnBrowserRestore.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBrowserRestore.Location = new System.Drawing.Point(23, 75);
            this.btnBrowserRestore.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnBrowserRestore.Name = "btnBrowserRestore";
            this.btnBrowserRestore.Size = new System.Drawing.Size(90, 33);
            this.btnBrowserRestore.TabIndex = 5;
            this.btnBrowserRestore.Text = ".....";
            this.btnBrowserRestore.UseVisualStyleBackColor = true;
            this.btnBrowserRestore.Click += new System.EventHandler(this.btnBrowserRestore_Click);
            // 
            // txtSelectFile
            // 
            this.txtSelectFile.Location = new System.Drawing.Point(123, 76);
            this.txtSelectFile.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtSelectFile.Name = "txtSelectFile";
            this.txtSelectFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSelectFile.Size = new System.Drawing.Size(461, 39);
            this.txtSelectFile.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(591, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "انتخاب فایل پشتیبان :";
            // 
            // backgroundWorkerBackup
            // 
            this.backgroundWorkerBackup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBackup_DoWork);
            this.backgroundWorkerBackup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerBackup_RunWorkerCompleted);
            // 
            // backgroundWorkerRestore
            // 
            this.backgroundWorkerRestore.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRestore_DoWork);
            this.backgroundWorkerRestore.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerRestore_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnRestore);
            this.groupBox1.Controls.Add(this.rbtnBackup);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 85);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "انتخاب حالت";
            // 
            // rbtnRestore
            // 
            this.rbtnRestore.AutoSize = true;
            this.rbtnRestore.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnRestore.Location = new System.Drawing.Point(227, 32);
            this.rbtnRestore.Name = "rbtnRestore";
            this.rbtnRestore.Size = new System.Drawing.Size(93, 35);
            this.rbtnRestore.TabIndex = 3;
            this.rbtnRestore.Text = "بازیابی";
            this.rbtnRestore.UseVisualStyleBackColor = true;
            this.rbtnRestore.CheckedChanged += new System.EventHandler(this.rbtnRestore_CheckedChanged);
            // 
            // rbtnBackup
            // 
            this.rbtnBackup.AutoSize = true;
            this.rbtnBackup.Checked = true;
            this.rbtnBackup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnBackup.Location = new System.Drawing.Point(20, 32);
            this.rbtnBackup.Name = "rbtnBackup";
            this.rbtnBackup.Size = new System.Drawing.Size(154, 35);
            this.rbtnBackup.TabIndex = 3;
            this.rbtnBackup.TabStop = true;
            this.rbtnBackup.Text = "پشتیبان گیری";
            this.rbtnBackup.UseVisualStyleBackColor = true;
            this.rbtnBackup.CheckedChanged += new System.EventHandler(this.rbtnBackup_CheckedChanged);
            // 
            // FrmBackupRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 440);
            this.Controls.Add(this.gbxBackup);
            this.Controls.Add(this.gbxRestore);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("IRANSans(FaNum) Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBackupRestore";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "پشتیبان گیری و بازیابی اطلاعات";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBackupRestore_FormClosing);
            this.Load += new System.EventHandler(this.FrmBackupRestore_Load);
            this.gbxBackup.ResumeLayout(false);
            this.gbxBackup.PerformLayout();
            this.gbxRestore.ResumeLayout(false);
            this.gbxRestore.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartBackup;
        private System.Windows.Forms.TextBox txtSelectPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxBackup;
        private System.Windows.Forms.Button btnBrowserBackup;
        private System.Windows.Forms.GroupBox gbxRestore;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBrowserRestore;
        private System.Windows.Forms.TextBox txtSelectFile;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorkerBackup;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRestore;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnRestore;
        private System.Windows.Forms.RadioButton rbtnBackup;
    }
}