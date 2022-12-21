namespace Sandogh_PG
{
    partial class FrmAppRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAppRegister));
            this.lblCode = new DevExpress.XtraEditors.LabelControl();
            this.lblSerial = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.txtSerial = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.comVersionType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblVersionType = new DevExpress.XtraEditors.LabelControl();
            this.lblVersionNumber = new DevExpress.XtraEditors.LabelControl();
            this.txtVersionNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtDeviceID = new DevExpress.XtraEditors.TextEdit();
            this.lblDeviceID = new DevExpress.XtraEditors.LabelControl();
            this.txtLNDeviceID = new DevExpress.XtraEditors.TextEdit();
            this.lblLNDeviceID = new DevExpress.XtraEditors.LabelControl();
            this.txtDataBase = new DevExpress.XtraEditors.TextEdit();
            this.lblDataBase = new DevExpress.XtraEditors.LabelControl();
            this.txtLNDataBase = new DevExpress.XtraEditors.TextEdit();
            this.lblLNDataBase = new DevExpress.XtraEditors.LabelControl();
            this.txtGarantiEndData = new DevExpress.XtraEditors.TextEdit();
            this.lblGarantiEndData = new DevExpress.XtraEditors.LabelControl();
            this.txtLNGarantiEndData = new DevExpress.XtraEditors.TextEdit();
            this.lblLNGarantiDate = new DevExpress.XtraEditors.LabelControl();
            this.lblIsGaranti = new DevExpress.XtraEditors.LabelControl();
            this.comIsGaranti = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbDeviceID = new DevExpress.XtraEditors.LookUpEdit();
            this.lblcmbDeviceID = new DevExpress.XtraEditors.LabelControl();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreate = new DevExpress.XtraEditors.SimpleButton();
            this.lblIsActive = new DevExpress.XtraEditors.LabelControl();
            this.comIsActive = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtLNVersionNumber = new DevExpress.XtraEditors.TextEdit();
            this.lblLNVersionNumber = new DevExpress.XtraEditors.LabelControl();
            this.txtRegisterDate = new DevExpress.XtraEditors.TextEdit();
            this.lblRegisterDate = new DevExpress.XtraEditors.LabelControl();
            this.txtLNVersionType = new DevExpress.XtraEditors.TextEdit();
            this.lblLNVersionType = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.allowedDevisesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comVersionType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVersionNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeviceID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLNDeviceID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLNDataBase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGarantiEndData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLNGarantiEndData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comIsGaranti.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDeviceID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLNVersionNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegisterDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLNVersionType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allowedDevisesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(467, 437);
            this.lblCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(40, 27);
            this.lblCode.TabIndex = 17;
            this.lblCode.Text = "Code";
            this.lblCode.Click += new System.EventHandler(this.lblCode_Click);
            // 
            // lblSerial
            // 
            this.lblSerial.Location = new System.Drawing.Point(84, 437);
            this.lblSerial.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(42, 27);
            this.lblSerial.TabIndex = 18;
            this.lblSerial.Text = "Serial";
            // 
            // txtCode
            // 
            this.txtCode.EnterMoveNextControl = true;
            this.txtCode.Location = new System.Drawing.Point(515, 434);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCode.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtCode.Properties.ReadOnly = true;
            this.txtCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCode.Size = new System.Drawing.Size(215, 34);
            this.txtCode.TabIndex = 14;
            // 
            // txtSerial
            // 
            this.txtSerial.EnterMoveNextControl = true;
            this.txtSerial.Location = new System.Drawing.Point(133, 434);
            this.txtSerial.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSerial.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtSerial.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtSerial.Properties.ReadOnly = true;
            this.txtSerial.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSerial.Size = new System.Drawing.Size(215, 34);
            this.txtSerial.TabIndex = 15;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(133, 472);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(215, 33);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "ثبت";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(515, 472);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(215, 33);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "خروج";
            this.btnClose.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // comVersionType
            // 
            this.comVersionType.EnterMoveNextControl = true;
            this.comVersionType.Location = new System.Drawing.Point(133, 106);
            this.comVersionType.Name = "comVersionType";
            this.comVersionType.Properties.Appearance.Options.UseTextOptions = true;
            this.comVersionType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.comVersionType.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.comVersionType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comVersionType.Properties.Items.AddRange(new object[] {
            "Orginal",
            "Demo",
            "Display"});
            this.comVersionType.Properties.ReadOnly = true;
            this.comVersionType.Size = new System.Drawing.Size(215, 34);
            this.comVersionType.TabIndex = 1;
            // 
            // lblVersionType
            // 
            this.lblVersionType.Location = new System.Drawing.Point(30, 109);
            this.lblVersionType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblVersionType.Name = "lblVersionType";
            this.lblVersionType.Size = new System.Drawing.Size(95, 27);
            this.lblVersionType.TabIndex = 33;
            this.lblVersionType.Text = "VersionType";
            this.lblVersionType.Click += new System.EventHandler(this.lblVersionType_Click);
            // 
            // lblVersionNumber
            // 
            this.lblVersionNumber.Location = new System.Drawing.Point(6, 147);
            this.lblVersionNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblVersionNumber.Name = "lblVersionNumber";
            this.lblVersionNumber.Size = new System.Drawing.Size(119, 27);
            this.lblVersionNumber.TabIndex = 34;
            this.lblVersionNumber.Text = "VersionNumber";
            this.lblVersionNumber.Click += new System.EventHandler(this.lblVersionNumber_Click);
            // 
            // txtVersionNumber
            // 
            this.txtVersionNumber.EnterMoveNextControl = true;
            this.txtVersionNumber.Location = new System.Drawing.Point(133, 146);
            this.txtVersionNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtVersionNumber.Name = "txtVersionNumber";
            this.txtVersionNumber.Properties.Appearance.Options.UseTextOptions = true;
            this.txtVersionNumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtVersionNumber.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtVersionNumber.Properties.ReadOnly = true;
            this.txtVersionNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtVersionNumber.Size = new System.Drawing.Size(215, 34);
            this.txtVersionNumber.TabIndex = 3;
            // 
            // txtDeviceID
            // 
            this.txtDeviceID.EnterMoveNextControl = true;
            this.txtDeviceID.Location = new System.Drawing.Point(133, 184);
            this.txtDeviceID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDeviceID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtDeviceID.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtDeviceID.Properties.ReadOnly = true;
            this.txtDeviceID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDeviceID.Size = new System.Drawing.Size(215, 34);
            this.txtDeviceID.TabIndex = 5;
            // 
            // lblDeviceID
            // 
            this.lblDeviceID.Location = new System.Drawing.Point(59, 187);
            this.lblDeviceID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblDeviceID.Name = "lblDeviceID";
            this.lblDeviceID.Size = new System.Drawing.Size(66, 27);
            this.lblDeviceID.TabIndex = 36;
            this.lblDeviceID.Text = "DeviceID";
            this.lblDeviceID.Click += new System.EventHandler(this.lblDeviceID_Click);
            // 
            // txtLNDeviceID
            // 
            this.txtLNDeviceID.EnterMoveNextControl = true;
            this.txtLNDeviceID.Location = new System.Drawing.Point(515, 184);
            this.txtLNDeviceID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLNDeviceID.Name = "txtLNDeviceID";
            this.txtLNDeviceID.Properties.Appearance.Options.UseTextOptions = true;
            this.txtLNDeviceID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtLNDeviceID.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtLNDeviceID.Properties.ReadOnly = true;
            this.txtLNDeviceID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLNDeviceID.Size = new System.Drawing.Size(215, 34);
            this.txtLNDeviceID.TabIndex = 6;
            // 
            // lblLNDeviceID
            // 
            this.lblLNDeviceID.Location = new System.Drawing.Point(420, 187);
            this.lblLNDeviceID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblLNDeviceID.Name = "lblLNDeviceID";
            this.lblLNDeviceID.Size = new System.Drawing.Size(87, 27);
            this.lblLNDeviceID.TabIndex = 38;
            this.lblLNDeviceID.Text = "LNDeviceID";
            this.lblLNDeviceID.Click += new System.EventHandler(this.lblLNDeviceID_Click);
            // 
            // txtDataBase
            // 
            this.txtDataBase.EnterMoveNextControl = true;
            this.txtDataBase.Location = new System.Drawing.Point(133, 222);
            this.txtDataBase.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDataBase.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtDataBase.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtDataBase.Properties.ReadOnly = true;
            this.txtDataBase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDataBase.Size = new System.Drawing.Size(215, 34);
            this.txtDataBase.TabIndex = 7;
            // 
            // lblDataBase
            // 
            this.lblDataBase.Location = new System.Drawing.Point(52, 225);
            this.lblDataBase.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(73, 27);
            this.lblDataBase.TabIndex = 40;
            this.lblDataBase.Text = "DataBase";
            this.lblDataBase.Click += new System.EventHandler(this.lblDataBase_Click);
            // 
            // txtLNDataBase
            // 
            this.txtLNDataBase.EnterMoveNextControl = true;
            this.txtLNDataBase.Location = new System.Drawing.Point(515, 222);
            this.txtLNDataBase.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLNDataBase.Name = "txtLNDataBase";
            this.txtLNDataBase.Properties.Appearance.Options.UseTextOptions = true;
            this.txtLNDataBase.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtLNDataBase.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtLNDataBase.Properties.ReadOnly = true;
            this.txtLNDataBase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLNDataBase.Size = new System.Drawing.Size(215, 34);
            this.txtLNDataBase.TabIndex = 8;
            // 
            // lblLNDataBase
            // 
            this.lblLNDataBase.Location = new System.Drawing.Point(413, 225);
            this.lblLNDataBase.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblLNDataBase.Name = "lblLNDataBase";
            this.lblLNDataBase.Size = new System.Drawing.Size(94, 27);
            this.lblLNDataBase.TabIndex = 42;
            this.lblLNDataBase.Text = "LNDataBase";
            this.lblLNDataBase.Click += new System.EventHandler(this.lblLNDataBase_Click);
            // 
            // txtGarantiEndData
            // 
            this.txtGarantiEndData.EditValue = "";
            this.txtGarantiEndData.EnterMoveNextControl = true;
            this.txtGarantiEndData.Location = new System.Drawing.Point(133, 260);
            this.txtGarantiEndData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtGarantiEndData.Name = "txtGarantiEndData";
            this.txtGarantiEndData.Properties.Appearance.Options.UseTextOptions = true;
            this.txtGarantiEndData.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtGarantiEndData.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtGarantiEndData.Properties.ReadOnly = true;
            this.txtGarantiEndData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGarantiEndData.Size = new System.Drawing.Size(215, 34);
            this.txtGarantiEndData.TabIndex = 9;
            // 
            // lblGarantiEndData
            // 
            this.lblGarantiEndData.Location = new System.Drawing.Point(6, 263);
            this.lblGarantiEndData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblGarantiEndData.Name = "lblGarantiEndData";
            this.lblGarantiEndData.Size = new System.Drawing.Size(119, 27);
            this.lblGarantiEndData.TabIndex = 44;
            this.lblGarantiEndData.Text = "GarantiEndData";
            this.lblGarantiEndData.Click += new System.EventHandler(this.lblGarantiEndData_Click);
            // 
            // txtLNGarantiEndData
            // 
            this.txtLNGarantiEndData.EnterMoveNextControl = true;
            this.txtLNGarantiEndData.Location = new System.Drawing.Point(515, 260);
            this.txtLNGarantiEndData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLNGarantiEndData.Name = "txtLNGarantiEndData";
            this.txtLNGarantiEndData.Properties.Appearance.Options.UseTextOptions = true;
            this.txtLNGarantiEndData.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtLNGarantiEndData.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtLNGarantiEndData.Properties.ReadOnly = true;
            this.txtLNGarantiEndData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLNGarantiEndData.Size = new System.Drawing.Size(215, 34);
            this.txtLNGarantiEndData.TabIndex = 10;
            // 
            // lblLNGarantiDate
            // 
            this.lblLNGarantiDate.Location = new System.Drawing.Point(396, 263);
            this.lblLNGarantiDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblLNGarantiDate.Name = "lblLNGarantiDate";
            this.lblLNGarantiDate.Size = new System.Drawing.Size(111, 27);
            this.lblLNGarantiDate.TabIndex = 46;
            this.lblLNGarantiDate.Text = "LNGarantiDate";
            this.lblLNGarantiDate.Click += new System.EventHandler(this.lblLNGarantiDate_Click);
            // 
            // lblIsGaranti
            // 
            this.lblIsGaranti.Location = new System.Drawing.Point(56, 301);
            this.lblIsGaranti.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblIsGaranti.Name = "lblIsGaranti";
            this.lblIsGaranti.Size = new System.Drawing.Size(69, 27);
            this.lblIsGaranti.TabIndex = 49;
            this.lblIsGaranti.Text = "IsGaranti";
            this.lblIsGaranti.Click += new System.EventHandler(this.lblIsGaranti_Click);
            // 
            // comIsGaranti
            // 
            this.comIsGaranti.EnterMoveNextControl = true;
            this.comIsGaranti.Location = new System.Drawing.Point(133, 298);
            this.comIsGaranti.Name = "comIsGaranti";
            this.comIsGaranti.Properties.Appearance.Options.UseTextOptions = true;
            this.comIsGaranti.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.comIsGaranti.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.comIsGaranti.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comIsGaranti.Properties.Items.AddRange(new object[] {
            "false",
            "true"});
            this.comIsGaranti.Properties.ReadOnly = true;
            this.comIsGaranti.Size = new System.Drawing.Size(215, 34);
            this.comIsGaranti.TabIndex = 11;
            // 
            // cmbDeviceID
            // 
            this.cmbDeviceID.EnterMoveNextControl = true;
            this.cmbDeviceID.Location = new System.Drawing.Point(13, 58);
            this.cmbDeviceID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbDeviceID.Name = "cmbDeviceID";
            this.cmbDeviceID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDeviceID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "آیدی", 50, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DeviceID", "Device ID ", 300, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DataBaseName", "DataBaseName", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VersionType", "VersionType", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmbDeviceID.Properties.DataSource = this.allowedDevisesBindingSource;
            this.cmbDeviceID.Properties.DisplayMember = "DeviceID";
            this.cmbDeviceID.Properties.ImmediatePopup = true;
            this.cmbDeviceID.Properties.MaxLength = 150;
            this.cmbDeviceID.Properties.NullText = "";
            this.cmbDeviceID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cmbDeviceID.Properties.ValueMember = "Id";
            this.cmbDeviceID.Size = new System.Drawing.Size(717, 34);
            this.cmbDeviceID.TabIndex = 0;
            this.cmbDeviceID.EditValueChanged += new System.EventHandler(this.cmbDeviceID_EditValueChanged);
            // 
            // lblcmbDeviceID
            // 
            this.lblcmbDeviceID.Location = new System.Drawing.Point(13, 25);
            this.lblcmbDeviceID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblcmbDeviceID.Name = "lblcmbDeviceID";
            this.lblcmbDeviceID.Size = new System.Drawing.Size(66, 27);
            this.lblcmbDeviceID.TabIndex = 51;
            this.lblcmbDeviceID.Text = "DeviceID";
            this.lblcmbDeviceID.Click += new System.EventHandler(this.lblcmbDeviceID_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEdit.ImageOptions.SvgImage")));
            this.btnEdit.Location = new System.Drawing.Point(573, 12);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnEdit.Size = new System.Drawing.Size(47, 40);
            this.btnEdit.TabIndex = 54;
            this.btnEdit.ToolTip = "ویرایش";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.Location = new System.Drawing.Point(628, 12);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnDelete.Size = new System.Drawing.Size(47, 40);
            this.btnDelete.TabIndex = 53;
            this.btnDelete.ToolTip = "حذف";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCreate.ImageOptions.SvgImage")));
            this.btnCreate.Location = new System.Drawing.Point(683, 12);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnCreate.Size = new System.Drawing.Size(47, 40);
            this.btnCreate.TabIndex = 52;
            this.btnCreate.ToolTip = "ایجاد";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblIsActive
            // 
            this.lblIsActive.Location = new System.Drawing.Point(56, 341);
            this.lblIsActive.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(61, 27);
            this.lblIsActive.TabIndex = 56;
            this.lblIsActive.Text = "IsActive";
            this.lblIsActive.Click += new System.EventHandler(this.lblIsActive_Click);
            // 
            // comIsActive
            // 
            this.comIsActive.EnterMoveNextControl = true;
            this.comIsActive.Location = new System.Drawing.Point(133, 338);
            this.comIsActive.Name = "comIsActive";
            this.comIsActive.Properties.Appearance.Options.UseTextOptions = true;
            this.comIsActive.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.comIsActive.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.comIsActive.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comIsActive.Properties.Items.AddRange(new object[] {
            "false",
            "true"});
            this.comIsActive.Properties.ReadOnly = true;
            this.comIsActive.Size = new System.Drawing.Size(215, 34);
            this.comIsActive.TabIndex = 12;
            // 
            // txtLNVersionNumber
            // 
            this.txtLNVersionNumber.EnterMoveNextControl = true;
            this.txtLNVersionNumber.Location = new System.Drawing.Point(515, 146);
            this.txtLNVersionNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLNVersionNumber.Name = "txtLNVersionNumber";
            this.txtLNVersionNumber.Properties.Appearance.Options.UseTextOptions = true;
            this.txtLNVersionNumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtLNVersionNumber.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtLNVersionNumber.Properties.ReadOnly = true;
            this.txtLNVersionNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLNVersionNumber.Size = new System.Drawing.Size(215, 34);
            this.txtLNVersionNumber.TabIndex = 4;
            // 
            // lblLNVersionNumber
            // 
            this.lblLNVersionNumber.Location = new System.Drawing.Point(367, 147);
            this.lblLNVersionNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblLNVersionNumber.Name = "lblLNVersionNumber";
            this.lblLNVersionNumber.Size = new System.Drawing.Size(140, 27);
            this.lblLNVersionNumber.TabIndex = 57;
            this.lblLNVersionNumber.Text = "LNVersionNumber";
            this.lblLNVersionNumber.Click += new System.EventHandler(this.lblLNVersionNumber_Click);
            // 
            // txtRegisterDate
            // 
            this.txtRegisterDate.EnterMoveNextControl = true;
            this.txtRegisterDate.Location = new System.Drawing.Point(133, 378);
            this.txtRegisterDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtRegisterDate.Name = "txtRegisterDate";
            this.txtRegisterDate.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRegisterDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtRegisterDate.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtRegisterDate.Properties.ReadOnly = true;
            this.txtRegisterDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRegisterDate.Size = new System.Drawing.Size(215, 34);
            this.txtRegisterDate.TabIndex = 13;
            // 
            // lblRegisterDate
            // 
            this.lblRegisterDate.Location = new System.Drawing.Point(27, 379);
            this.lblRegisterDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblRegisterDate.Name = "lblRegisterDate";
            this.lblRegisterDate.Size = new System.Drawing.Size(98, 27);
            this.lblRegisterDate.TabIndex = 60;
            this.lblRegisterDate.Text = "RegisterDate";
            this.lblRegisterDate.Click += new System.EventHandler(this.lblRegisterDate_Click);
            // 
            // txtLNVersionType
            // 
            this.txtLNVersionType.EnterMoveNextControl = true;
            this.txtLNVersionType.Location = new System.Drawing.Point(515, 108);
            this.txtLNVersionType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLNVersionType.Name = "txtLNVersionType";
            this.txtLNVersionType.Properties.Appearance.Options.UseTextOptions = true;
            this.txtLNVersionType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtLNVersionType.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtLNVersionType.Properties.ReadOnly = true;
            this.txtLNVersionType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLNVersionType.Size = new System.Drawing.Size(215, 34);
            this.txtLNVersionType.TabIndex = 2;
            // 
            // lblLNVersionType
            // 
            this.lblLNVersionType.Location = new System.Drawing.Point(391, 109);
            this.lblLNVersionType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblLNVersionType.Name = "lblLNVersionType";
            this.lblLNVersionType.Size = new System.Drawing.Size(116, 27);
            this.lblLNVersionType.TabIndex = 64;
            this.lblLNVersionType.Text = "LNVersionType";
            this.lblLNVersionType.Click += new System.EventHandler(this.lblLNVersionType_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(367, 305);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 27);
            this.labelControl1.TabIndex = 65;
            this.labelControl1.Text = "My Device ID :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(367, 343);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(160, 27);
            this.labelControl2.TabIndex = 66;
            this.labelControl2.Text = "My DataBace Name :";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(367, 381);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(145, 27);
            this.labelControl3.TabIndex = 67;
            this.labelControl3.Text = "My Version Name :";
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancel.ImageOptions.SvgImage")));
            this.btnCancel.Location = new System.Drawing.Point(518, 12);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnCancel.Size = new System.Drawing.Size(47, 40);
            this.btnCancel.TabIndex = 68;
            this.btnCancel.ToolTip = "F6";
            this.btnCancel.ToolTipTitle = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // allowedDevisesBindingSource
            // 
            this.allowedDevisesBindingSource.DataSource = typeof(Sandogh_PG.Models.AllowedDevise);
            // 
            // FrmAppRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 513);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtLNVersionType);
            this.Controls.Add(this.lblLNVersionType);
            this.Controls.Add(this.lblRegisterDate);
            this.Controls.Add(this.txtRegisterDate);
            this.Controls.Add(this.txtLNVersionNumber);
            this.Controls.Add(this.lblLNVersionNumber);
            this.Controls.Add(this.lblIsActive);
            this.Controls.Add(this.comIsActive);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblcmbDeviceID);
            this.Controls.Add(this.cmbDeviceID);
            this.Controls.Add(this.lblIsGaranti);
            this.Controls.Add(this.comIsGaranti);
            this.Controls.Add(this.txtLNGarantiEndData);
            this.Controls.Add(this.lblLNGarantiDate);
            this.Controls.Add(this.txtGarantiEndData);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblGarantiEndData);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.txtLNDataBase);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblLNDataBase);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtDataBase);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblDataBase);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.txtLNDeviceID);
            this.Controls.Add(this.lblLNDeviceID);
            this.Controls.Add(this.txtDeviceID);
            this.Controls.Add(this.lblDeviceID);
            this.Controls.Add(this.txtVersionNumber);
            this.Controls.Add(this.lblVersionNumber);
            this.Controls.Add(this.lblVersionType);
            this.Controls.Add(this.comVersionType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmAppRegister.IconOptions.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(740, 553);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(740, 553);
            this.Name = "FrmAppRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "عملیات لاینسس نرم افزار";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAppRegister_FormClosed);
            this.Load += new System.EventHandler(this.frmAppRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comVersionType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVersionNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeviceID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLNDeviceID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLNDataBase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGarantiEndData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLNGarantiEndData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comIsGaranti.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDeviceID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLNVersionNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegisterDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLNVersionType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allowedDevisesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblCode;
        private DevExpress.XtraEditors.LabelControl lblSerial;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.TextEdit txtSerial;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.TextEdit txtLNGarantiEndData;
        private DevExpress.XtraEditors.LabelControl lblLNGarantiDate;
        private DevExpress.XtraEditors.TextEdit txtGarantiEndData;
        private DevExpress.XtraEditors.LabelControl lblGarantiEndData;
        private DevExpress.XtraEditors.TextEdit txtLNDataBase;
        private DevExpress.XtraEditors.LabelControl lblLNDataBase;
        private DevExpress.XtraEditors.TextEdit txtDataBase;
        private DevExpress.XtraEditors.LabelControl lblDataBase;
        private DevExpress.XtraEditors.TextEdit txtLNDeviceID;
        private DevExpress.XtraEditors.LabelControl lblLNDeviceID;
        private DevExpress.XtraEditors.TextEdit txtDeviceID;
        private DevExpress.XtraEditors.LabelControl lblDeviceID;
        private DevExpress.XtraEditors.TextEdit txtVersionNumber;
        private DevExpress.XtraEditors.LabelControl lblVersionNumber;
        private DevExpress.XtraEditors.LabelControl lblVersionType;
        private DevExpress.XtraEditors.ComboBoxEdit comVersionType;
        private DevExpress.XtraEditors.LabelControl lblIsGaranti;
        private DevExpress.XtraEditors.ComboBoxEdit comIsGaranti;
        public DevExpress.XtraEditors.LookUpEdit cmbDeviceID;
        private DevExpress.XtraEditors.LabelControl lblcmbDeviceID;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnCreate;
        private DevExpress.XtraEditors.LabelControl lblIsActive;
        private DevExpress.XtraEditors.ComboBoxEdit comIsActive;
        private System.Windows.Forms.BindingSource allowedDevisesBindingSource;
        private DevExpress.XtraEditors.TextEdit txtLNVersionNumber;
        private DevExpress.XtraEditors.LabelControl lblLNVersionNumber;
        private DevExpress.XtraEditors.TextEdit txtRegisterDate;
        private DevExpress.XtraEditors.LabelControl lblRegisterDate;
        private DevExpress.XtraEditors.TextEdit txtLNVersionType;
        private DevExpress.XtraEditors.LabelControl lblLNVersionType;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}