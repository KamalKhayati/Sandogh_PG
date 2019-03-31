namespace Sandogh_TG
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnTarifSandogh = new DevExpress.XtraBars.BarButtonItem();
            this.btnTarifHesabBanki = new DevExpress.XtraBars.BarButtonItem();
            this.btnTarifAaza = new DevExpress.XtraBars.BarButtonItem();
            this.btnDaryaftAzAaza = new DevExpress.XtraBars.BarButtonItem();
            this.btnSabtDaramad = new DevExpress.XtraBars.BarButtonItem();
            this.btnPardakhtBeAaza = new DevExpress.XtraBars.BarButtonItem();
            this.btnSabtHazine = new DevExpress.XtraBars.BarButtonItem();
            this.infoBase = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgInfoBase = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.Daryaft = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgDaryaft = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.Pardakht = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgPardakht = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.Reports = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.Abzar = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.Other = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnTarifSandogh,
            this.btnTarifHesabBanki,
            this.btnTarifAaza,
            this.btnDaryaftAzAaza,
            this.btnSabtDaramad,
            this.btnPardakhtBeAaza,
            this.btnSabtHazine});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ribbonControl1.MaxItemId = 8;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.infoBase,
            this.Daryaft,
            this.Pardakht,
            this.Reports,
            this.Abzar,
            this.Other});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowCategoryInCaption = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1301, 206);
            // 
            // btnTarifSandogh
            // 
            this.btnTarifSandogh.Caption = "تنظیمات و معرفی صندوق";
            this.btnTarifSandogh.Id = 1;
            this.btnTarifSandogh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTarifSandogh.ImageOptions.Image")));
            this.btnTarifSandogh.Name = "btnTarifSandogh";
            this.btnTarifSandogh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTarifSandogh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTarifSandogh_ItemClick);
            // 
            // btnTarifHesabBanki
            // 
            this.btnTarifHesabBanki.Caption = "تعریف حسابهای بانکی و صندوق";
            this.btnTarifHesabBanki.Id = 2;
            this.btnTarifHesabBanki.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTarifHesabBanki.ImageOptions.Image")));
            this.btnTarifHesabBanki.Name = "btnTarifHesabBanki";
            this.btnTarifHesabBanki.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTarifHesabBanki.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTarifHesabBanki_ItemClick);
            // 
            // btnTarifAaza
            // 
            this.btnTarifAaza.Caption = "تعریف اعضا";
            this.btnTarifAaza.Id = 3;
            this.btnTarifAaza.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTarifAaza.ImageOptions.Image")));
            this.btnTarifAaza.Name = "btnTarifAaza";
            this.btnTarifAaza.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTarifAaza.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTarifAaza_ItemClick);
            // 
            // btnDaryaftAzAaza
            // 
            this.btnDaryaftAzAaza.Caption = "دریافتی از اعضاء";
            this.btnDaryaftAzAaza.Id = 4;
            this.btnDaryaftAzAaza.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDaryaftAzAaza.ImageOptions.SvgImage")));
            this.btnDaryaftAzAaza.Name = "btnDaryaftAzAaza";
            this.btnDaryaftAzAaza.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnSabtDaramad
            // 
            this.btnSabtDaramad.Caption = "ثبت درآمد";
            this.btnSabtDaramad.Id = 5;
            this.btnSabtDaramad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSabtDaramad.ImageOptions.SvgImage")));
            this.btnSabtDaramad.Name = "btnSabtDaramad";
            this.btnSabtDaramad.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnPardakhtBeAaza
            // 
            this.btnPardakhtBeAaza.Caption = "پرداختی به اعضاء";
            this.btnPardakhtBeAaza.Id = 6;
            this.btnPardakhtBeAaza.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPardakhtBeAaza.ImageOptions.Image")));
            this.btnPardakhtBeAaza.Name = "btnPardakhtBeAaza";
            this.btnPardakhtBeAaza.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnSabtHazine
            // 
            this.btnSabtHazine.Caption = "ثبت هزینه";
            this.btnSabtHazine.Id = 7;
            this.btnSabtHazine.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSabtHazine.ImageOptions.Image")));
            this.btnSabtHazine.Name = "btnSabtHazine";
            this.btnSabtHazine.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // infoBase
            // 
            this.infoBase.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgInfoBase});
            this.infoBase.Name = "infoBase";
            this.infoBase.Text = "اطلاعات پایه";
            // 
            // rpgInfoBase
            // 
            this.rpgInfoBase.ItemLinks.Add(this.btnTarifSandogh, true);
            this.rpgInfoBase.ItemLinks.Add(this.btnTarifHesabBanki, true);
            this.rpgInfoBase.ItemLinks.Add(this.btnTarifAaza, true);
            this.rpgInfoBase.Name = "rpgInfoBase";
            this.rpgInfoBase.Text = "اطلاعات پایه ";
            // 
            // Daryaft
            // 
            this.Daryaft.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgDaryaft});
            this.Daryaft.Name = "Daryaft";
            this.Daryaft.Text = "دریافت";
            // 
            // rpgDaryaft
            // 
            this.rpgDaryaft.ItemLinks.Add(this.btnDaryaftAzAaza, true);
            this.rpgDaryaft.ItemLinks.Add(this.btnSabtDaramad, true);
            this.rpgDaryaft.Name = "rpgDaryaft";
            this.rpgDaryaft.Text = "دریافتها";
            // 
            // Pardakht
            // 
            this.Pardakht.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgPardakht});
            this.Pardakht.Name = "Pardakht";
            this.Pardakht.Text = "پرداخت";
            // 
            // rpgPardakht
            // 
            this.rpgPardakht.ItemLinks.Add(this.btnPardakhtBeAaza, true);
            this.rpgPardakht.ItemLinks.Add(this.btnSabtHazine, true);
            this.rpgPardakht.Name = "rpgPardakht";
            this.rpgPardakht.Text = "پرداختها";
            // 
            // Reports
            // 
            this.Reports.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.Reports.Name = "Reports";
            this.Reports.Text = "گزارشات";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "ribbonPageGroup4";
            // 
            // Abzar
            // 
            this.Abzar.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.Abzar.Name = "Abzar";
            this.Abzar.Text = "ابزار";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "ribbonPageGroup5";
            // 
            // Other
            // 
            this.Other.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6});
            this.Other.Name = "Other";
            this.Other.Text = "سایر";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "ribbonPageGroup6";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 516);
            this.Controls.Add(this.ribbonControl1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "FrmMain";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صندوق قرض الحسنه تلاشگران";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage infoBase;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgInfoBase;
        private DevExpress.XtraBars.Ribbon.RibbonPage Daryaft;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgDaryaft;
        private DevExpress.XtraBars.Ribbon.RibbonPage Pardakht;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgPardakht;
        private DevExpress.XtraBars.Ribbon.RibbonPage Reports;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage Abzar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPage Other;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnTarifSandogh;
        private DevExpress.XtraBars.BarButtonItem btnTarifHesabBanki;
        private DevExpress.XtraBars.BarButtonItem btnTarifAaza;
        private DevExpress.XtraBars.BarButtonItem btnDaryaftAzAaza;
        private DevExpress.XtraBars.BarButtonItem btnSabtDaramad;
        private DevExpress.XtraBars.BarButtonItem btnPardakhtBeAaza;
        private DevExpress.XtraBars.BarButtonItem btnSabtHazine;
    }
}

