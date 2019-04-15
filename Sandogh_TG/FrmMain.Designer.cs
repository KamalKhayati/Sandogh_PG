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
            this.btnDaryaft1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnSabtDaramad = new DevExpress.XtraBars.BarButtonItem();
            this.btnDaryaft2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnSabtHazine = new DevExpress.XtraBars.BarButtonItem();
            this.btnEetayVam = new DevExpress.XtraBars.BarButtonItem();
            this.btnPardakht2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnEnteghali = new DevExpress.XtraBars.BarButtonItem();
            this.btnTanzimat = new DevExpress.XtraBars.BarButtonItem();
            this.IDSandogh = new DevExpress.XtraBars.BarStaticItem();
            this.btnTarifSalMali = new DevExpress.XtraBars.BarButtonItem();
            this.IDSalMali = new DevExpress.XtraBars.BarStaticItem();
            this.infoBase = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgInfoBase = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.DaryaftVPardakht = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgDaryaft = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgPardakhtha = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgEnteghali = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.SabteDaramadVHazine = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgSabteDaramadVHazine = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.Reports = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.Abzar = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgTanzimat = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.Other = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
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
            this.btnDaryaft1,
            this.btnSabtDaramad,
            this.btnDaryaft2,
            this.btnSabtHazine,
            this.btnEetayVam,
            this.btnPardakht2,
            this.btnEnteghali,
            this.btnTanzimat,
            this.IDSandogh,
            this.btnTarifSalMali,
            this.IDSalMali});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ribbonControl1.MaxItemId = 15;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.infoBase,
            this.DaryaftVPardakht,
            this.SabteDaramadVHazine,
            this.Reports,
            this.Abzar,
            this.Other});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowCategoryInCaption = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1301, 206);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnTarifSandogh
            // 
            this.btnTarifSandogh.Caption = "معرفی صندوق قرض الحسنه";
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
            this.btnTarifAaza.Caption = "تعریف اعضاء صندوق";
            this.btnTarifAaza.Id = 3;
            this.btnTarifAaza.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTarifAaza.ImageOptions.Image")));
            this.btnTarifAaza.Name = "btnTarifAaza";
            this.btnTarifAaza.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTarifAaza.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTarifAaza_ItemClick);
            // 
            // btnDaryaft1
            // 
            this.btnDaryaft1.Caption = "دریافت پس انداز ماهیانه و اقساط وام";
            this.btnDaryaft1.Id = 4;
            this.btnDaryaft1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDaryaft1.ImageOptions.SvgImage")));
            this.btnDaryaft1.Name = "btnDaryaft1";
            this.btnDaryaft1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDaryaft1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDaryaft1_ItemClick);
            // 
            // btnSabtDaramad
            // 
            this.btnSabtDaramad.Caption = "ثبت درآمد";
            this.btnSabtDaramad.Id = 5;
            this.btnSabtDaramad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSabtDaramad.ImageOptions.SvgImage")));
            this.btnSabtDaramad.Name = "btnSabtDaramad";
            this.btnSabtDaramad.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnDaryaft2
            // 
            this.btnDaryaft2.Caption = "سایر دریافتها";
            this.btnDaryaft2.Id = 6;
            this.btnDaryaft2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDaryaft2.ImageOptions.Image")));
            this.btnDaryaft2.Name = "btnDaryaft2";
            this.btnDaryaft2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnSabtHazine
            // 
            this.btnSabtHazine.Caption = "ثبت هزینه";
            this.btnSabtHazine.Id = 7;
            this.btnSabtHazine.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSabtHazine.ImageOptions.Image")));
            this.btnSabtHazine.Name = "btnSabtHazine";
            this.btnSabtHazine.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnEetayVam
            // 
            this.btnEetayVam.Caption = "اعطای وام به اعضاء";
            this.btnEetayVam.Id = 8;
            this.btnEetayVam.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEetayVam.ImageOptions.SvgImage")));
            this.btnEetayVam.Name = "btnEetayVam";
            this.btnEetayVam.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnEetayVam.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEetayVam_ItemClick);
            // 
            // btnPardakht2
            // 
            this.btnPardakht2.Caption = "سایر پرداختها";
            this.btnPardakht2.Id = 9;
            this.btnPardakht2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPardakht2.ImageOptions.SvgImage")));
            this.btnPardakht2.Name = "btnPardakht2";
            this.btnPardakht2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnEnteghali
            // 
            this.btnEnteghali.Caption = "انتقالی بین بانکها و صندوقها";
            this.btnEnteghali.Id = 10;
            this.btnEnteghali.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEnteghali.ImageOptions.SvgImage")));
            this.btnEnteghali.Name = "btnEnteghali";
            this.btnEnteghali.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnTanzimat
            // 
            this.btnTanzimat.Caption = "تنظیمات";
            this.btnTanzimat.Id = 11;
            this.btnTanzimat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTanzimat.ImageOptions.Image")));
            this.btnTanzimat.Name = "btnTanzimat";
            this.btnTanzimat.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTanzimat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTanzimat_ItemClick);
            // 
            // IDSandogh
            // 
            this.IDSandogh.Caption = "IDSandogh";
            this.IDSandogh.Id = 12;
            this.IDSandogh.Name = "IDSandogh";
            // 
            // btnTarifSalMali
            // 
            this.btnTarifSalMali.Caption = "تعریف سال مالی";
            this.btnTarifSalMali.Id = 13;
            this.btnTarifSalMali.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTarifSalMali.ImageOptions.Image")));
            this.btnTarifSalMali.Name = "btnTarifSalMali";
            this.btnTarifSalMali.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTarifSalMali.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTarifSalMali_ItemClick);
            // 
            // IDSalMali
            // 
            this.IDSalMali.Caption = "IDSalMali";
            this.IDSalMali.Id = 14;
            this.IDSalMali.Name = "IDSalMali";
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
            this.rpgInfoBase.ItemLinks.Add(this.btnTarifSalMali, true);
            this.rpgInfoBase.ItemLinks.Add(this.btnTarifHesabBanki, true);
            this.rpgInfoBase.ItemLinks.Add(this.btnTarifAaza, true);
            this.rpgInfoBase.Name = "rpgInfoBase";
            this.rpgInfoBase.Text = "اطلاعات پایه ";
            // 
            // DaryaftVPardakht
            // 
            this.DaryaftVPardakht.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgDaryaft,
            this.rpgPardakhtha,
            this.rpgEnteghali});
            this.DaryaftVPardakht.Name = "DaryaftVPardakht";
            this.DaryaftVPardakht.Text = "دریافت و پرداخت";
            // 
            // rpgDaryaft
            // 
            this.rpgDaryaft.ItemLinks.Add(this.btnDaryaft1);
            this.rpgDaryaft.ItemLinks.Add(this.btnDaryaft2, true);
            this.rpgDaryaft.Name = "rpgDaryaft";
            this.rpgDaryaft.Text = "دریافتها";
            // 
            // rpgPardakhtha
            // 
            this.rpgPardakhtha.ItemLinks.Add(this.btnEetayVam);
            this.rpgPardakhtha.ItemLinks.Add(this.btnPardakht2, true);
            this.rpgPardakhtha.Name = "rpgPardakhtha";
            this.rpgPardakhtha.Text = "پرداختها";
            // 
            // rpgEnteghali
            // 
            this.rpgEnteghali.ItemLinks.Add(this.btnEnteghali);
            this.rpgEnteghali.Name = "rpgEnteghali";
            this.rpgEnteghali.Text = "انتقالی به حسابها";
            // 
            // SabteDaramadVHazine
            // 
            this.SabteDaramadVHazine.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgSabteDaramadVHazine});
            this.SabteDaramadVHazine.Name = "SabteDaramadVHazine";
            this.SabteDaramadVHazine.Text = "درآمد و هزینه";
            // 
            // rpgSabteDaramadVHazine
            // 
            this.rpgSabteDaramadVHazine.ItemLinks.Add(this.btnSabtDaramad);
            this.rpgSabteDaramadVHazine.ItemLinks.Add(this.btnSabtHazine, true);
            this.rpgSabteDaramadVHazine.Name = "rpgSabteDaramadVHazine";
            this.rpgSabteDaramadVHazine.Text = "ثبت درآمد و هزینه";
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
            this.rpgTanzimat});
            this.Abzar.Name = "Abzar";
            this.Abzar.Text = "ابزار";
            // 
            // rpgTanzimat
            // 
            this.rpgTanzimat.ItemLinks.Add(this.btnTanzimat, true);
            this.rpgTanzimat.Name = "rpgTanzimat";
            this.rpgTanzimat.Text = "تنظیمات";
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
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.IDSandogh);
            this.ribbonStatusBar1.ItemLinks.Add(this.IDSalMali);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 475);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1301, 41);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 516);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "FrmMain";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "صندوق قرض الحسنه ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage infoBase;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgInfoBase;
        private DevExpress.XtraBars.Ribbon.RibbonPage DaryaftVPardakht;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgDaryaft;
        private DevExpress.XtraBars.Ribbon.RibbonPage SabteDaramadVHazine;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSabteDaramadVHazine;
        private DevExpress.XtraBars.Ribbon.RibbonPage Reports;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage Abzar;
        private DevExpress.XtraBars.Ribbon.RibbonPage Other;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnTarifSandogh;
        private DevExpress.XtraBars.BarButtonItem btnTarifHesabBanki;
        private DevExpress.XtraBars.BarButtonItem btnTarifAaza;
        private DevExpress.XtraBars.BarButtonItem btnDaryaft1;
        private DevExpress.XtraBars.BarButtonItem btnSabtDaramad;
        private DevExpress.XtraBars.BarButtonItem btnDaryaft2;
        private DevExpress.XtraBars.BarButtonItem btnSabtHazine;
        private DevExpress.XtraBars.BarButtonItem btnEetayVam;
        private DevExpress.XtraBars.BarButtonItem btnPardakht2;
        private DevExpress.XtraBars.BarButtonItem btnEnteghali;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgPardakhtha;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgEnteghali;
        private DevExpress.XtraBars.BarButtonItem btnTanzimat;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTanzimat;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem btnTarifSalMali;
        public DevExpress.XtraBars.BarStaticItem IDSandogh;
        public DevExpress.XtraBars.BarStaticItem IDSalMali;
    }
}

