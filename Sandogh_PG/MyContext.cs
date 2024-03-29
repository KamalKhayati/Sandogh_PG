﻿namespace Sandogh_PG
{
    using Sandogh_PG.Migrations;
    using Sandogh_PG;
    using System;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using DevExpress.XtraEditors;
    using System.Windows.Forms;

    public class MyContext : DbContext
    {
        // Your context has been configured to use a 'MyContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Sandogh_PG.MyContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MyContext' 
        // connection string in the application configuration file.
        public SetInitialize SetIni = SetInitialize.MigrateDatabaseToLatestVersion;

        public MyContext()
            : base("name=MyContext")
        {
            try
            {
                #region
                //پیش فرض
                //Database.SetInitializer<MyContext>(new CreateDatabaseIfNotExists<MyContext>());
                //    if (SetIni == SetInitialize.DropCreateDatabaseAlways)

                //حذف دیتابیس قبلی بهمراه داده های داخلش و ایجاد دیتابیس جدید بدون داده در صورت تغییرویاعدم تغییر(در هرصورت) کلاس مدل
                ////     Database.SetInitializer<MyContext>(new DropCreateDatabaseAlways<MyContext>());
                ///
                // حذف دیتابیس قبلی بهمراه داده های داخلش و ایجاد دیتابیس جدید بدون داده در صورت تغییر کلاس مدل
                //Database.SetInitializer<MyContext>(new DropCreateDatabaseIfModelChanges<MyContext>());

                // غیرفعال کردن پیکربندی دیتابیس برای اینکه داده های فعلی موجود در دیتا بیس حذف نشود
                //Database.SetInitializer<MyContext>(null);

                //پیکربندی دیتابیس بصورت Coustom
                //Database.SetInitializer<MyContext>(new MyContextInitializer());

                #endregion
                //Migration SetInitializer
                if (Database.Connection.ConnectionString != "")
                {
                    //Database.Initialize(true);
                    Database.SetInitializer<MyContext>(new MigrateDatabaseToLatestVersion<MyContext, Configuration>(true));
                    //Database.SetInitializer<MyContext>(new MigrateDatabaseToLatestVersion<MyContext, Configuration>(false));
                   // Database.Initialize(true);
                    SqlConnection.ClearAllPools();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> MyContext()" + "\n" + ex.Message,
                    "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public MyContext(SetInitialize SetIni)
            : base("name=MyContext")
        {
            try
            {
                if (SetIni == SetInitialize.DropCreateDatabaseAlways)
                    //حذف دیتابیس قبلی بهمراه داده های داخلش و ایجاد دیتابیس جدید بدون داده در صورت تغییرویاعدم تغییر(در هرصورت) کلاس مدل
                    Database.SetInitializer<MyContext>(new DropCreateDatabaseAlways<MyContext>());
                SqlConnection.ClearAllPools();
                #region
                //پیش فرض
                //Database.SetInitializer<MyContext>(new CreateDatabaseIfNotExists<MyContext>());
                // حذف دیتابیس قبلی بهمراه داده های داخلش و ایجاد دیتابیس جدید بدون داده در صورت تغییر کلاس مدل
                //Database.SetInitializer<MyContext>(new DropCreateDatabaseIfModelChanges<MyContext>());
                // غیرفعال کردن پیکربندی دیتابیس برای اینکه داده های فعلی موجود در دیتا بیس حذف نشود
                //Database.SetInitializer<MyContext>(null);
                //پیکربندی دیتابیس بصورت Coustom
                //Database.SetInitializer<MyContext>(new MyContextInitializer());
                //    if (SetIni == SetInitialize.MigrateDatabaseToLatestVersion)
                //Migration SetInitializer
                //        Database.SetInitializer<MyContext>(new MigrateDatabaseToLatestVersion<MyContext, Configuration>(true));
                #endregion

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> MyContext()" + "\n" + ex.Message,
                    "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<CodeMoin> CodeMoins { get; set; }
        public virtual DbSet<GroupTafzili> GroupTafzilis { get; set; }
        public virtual DbSet<TarifSandogh> TarifSandoghs { get; set; }
        public virtual DbSet<MasolinSandogh> MasolinSandoghs { get; set; }
        public virtual DbSet<SalMali> SalMalis { get; set; }
        public virtual DbSet<HesabBanki> HesabBankis { get; set; }
        public virtual DbSet<AazaSandogh> AazaSandoghs { get; set; }
        public virtual DbSet<CodingDaramadVHazine> CodingDaramadVHazines { get; set; }
        public virtual DbSet<AllHesabTafzili> AllHesabTafzilis { get; set; }
        public virtual DbSet<Tanzimat> Tanzimats { get; set; }
        public virtual DbSet<AnvaeVam> AnvaeVams { get; set; }
        public virtual DbSet<R_AnvaeVam_B_AllHesabTafzili> R_AnvaeVam_B_AllHesabTafzilis { get; set; }
        public virtual DbSet<TedadZamenin> TedadZamenins { get; set; }
        public virtual DbSet<HaghOzviat> HaghOzviats { get; set; }
        public virtual DbSet<RizeAghsatVam> RizeAghsatVams { get; set; }
        public virtual DbSet<VamPardakhti> VamPardakhtis { get; set; }
        public virtual DbSet<R_VamPardakhti_B_Zamenin> R_VamPardakhti_B_Zamenins { get; set; }
        public virtual DbSet<R_VamPardakhti_B_CheckTazmin> R_VamPardakhti_B_CheckTazmins { get; set; }
        public virtual DbSet<DaryaftPardakhtBinHesabha> DaryaftPardakhtBinHesabhas { get; set; }
        public virtual DbSet<CheckTazmin> CheckTazmins { get; set; }
        public virtual DbSet<AsnadeHesabdariRow> AsnadeHesabdariRows { get; set; }
        public virtual DbSet<Karbaran> Karbarans { get; set; }
        public virtual DbSet<CodingAmval> CodingAmvals { get; set; }
        public virtual DbSet<AllowedDevise> AllowedDevises { get; set; }

        //public virtual DbSet<PardakhtNaghdiVBanki> PardakhtNaghdiVBankis { get; set; }
        //public virtual DbSet<SabDaramad> SabDaramads { get; set; }
        //public virtual DbSet<SabtHazine> SabtHazines { get; set; }
        //public virtual DbSet<EnteghalatHesabBanki> EnteghalatHesabBankis { get; set; }
        //public virtual DbSet<EnteghalatHesabAaza> EnteghalatHesabAazas { get; set; }
        //public virtual DbSet<EnteghalatBeDaramadVhazine> EnteghalatBeDaramadVhazines { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                //modelBuilder.Entity<AazaSandogh>().HasMany(m => m.HaghOzviats).WithRequired(m => m.AazaSandogh1).HasForeignKey(m => m.AazaId).WillCascadeOnDelete(false);
                //modelBuilder.Entity<AazaSandogh>().HasMany(m => m.VamPardakhtis).WithRequired(m => m.AazaSandogh1).HasForeignKey(m => m.AazaId).WillCascadeOnDelete(false);
                //modelBuilder.Entity<AazaSandogh>().HasMany(m => m.CheckTazmins).WithRequired(m => m.AazaSandogh1).HasForeignKey(m => m.VamGerandeId).WillCascadeOnDelete(false);

                //modelBuilder.Entity<AazaSandogh>().HasMany(m => m.DaryaftNaghdiVBankis).WithRequired(m => m.AazaSandogh1).HasForeignKey(m => m.PardakhtkonandeId).WillCascadeOnDelete(false);
                //modelBuilder.Entity<AazaSandogh>().HasMany(m => m.PardakhtNaghdiVBankis).WithRequired(m => m.AazaSandogh1).HasForeignKey(m => m.DaryaftkonandeId).WillCascadeOnDelete(false);
                //modelBuilder.Entity<HesabBanki>().HasMany(m => m.HaghOzviats).WithRequired(m => m.HesabBanki1).HasForeignKey(m => m.NameHesabId).WillCascadeOnDelete(false);
                //modelBuilder.Entity<HesabBanki>().HasMany(m => m.VamPardakhtis).WithRequired(m => m.HesabBanki1).HasForeignKey(m => m.HesabTafziliId).WillCascadeOnDelete(false);

                modelBuilder.Entity<TarifSandogh>().HasOptional(m => m.Tanzimat1).WithRequired(m => m.TarifSandogh1).WillCascadeOnDelete(true);
                modelBuilder.Entity<TarifSandogh>().HasMany(m => m.SalMalis).WithRequired(m => m.TarifSandogh1).HasForeignKey(m => m.TarifSandoghId).WillCascadeOnDelete(false);
                modelBuilder.Entity<TarifSandogh>().HasMany(m => m.CodeMoins).WithRequired(m => m.TarifSandogh1).HasForeignKey(m => m.SandoghId).WillCascadeOnDelete(false);
                modelBuilder.Entity<TarifSandogh>().HasMany(m => m.GroupTafzilis).WithRequired(m => m.TarifSandogh1).HasForeignKey(m => m.SandoghId).WillCascadeOnDelete(false);
                modelBuilder.Entity<TarifSandogh>().HasMany(m => m.MasolinSandoghs).WithRequired(m => m.TarifSandogh1).HasForeignKey(m => m.SandoghId).WillCascadeOnDelete(true);
                //modelBuilder.Entity<TarifSandogh>().HasMany(m => m.HesabBankis).WithRequired(m => m.TarifSandogh1).HasForeignKey(m => m.TarifSandoghId).WillCascadeOnDelete(false);
                //modelBuilder.Entity<TarifSandogh>().HasMany(m => m.AazaSandoghs).WithRequired(m => m.TarifSandogh1).HasForeignKey(m => m.TarifSandoghId).WillCascadeOnDelete(false);
                //modelBuilder.Entity<TarifSandogh>().HasMany(m => m.CodingDaramadVHazines).WithRequired(m => m.TarifSandogh1).HasForeignKey(m => m.SandoghId).WillCascadeOnDelete(false);
                modelBuilder.Entity<TarifSandogh>().HasMany(m => m.AllHesabTafzilis).WithRequired(m => m.TarifSandogh1).HasForeignKey(m => m.SandoghId).WillCascadeOnDelete(false);

                //modelBuilder.Entity<GroupTafzili>().HasMany(m => m.HesabBankis).WithRequired(m => m.GroupTafzili1).HasForeignKey(m => m.GroupTafziliId).WillCascadeOnDelete(false);
                //modelBuilder.Entity<GroupTafzili>().HasMany(m => m.AazaSandoghs).WithRequired(m => m.GroupTafzili1).HasForeignKey(m => m.GroupTafziliId).WillCascadeOnDelete(false);
                //modelBuilder.Entity<GroupTafzili>().HasMany(m => m.CodingDaramadVHazines).WithRequired(m => m.GroupTafzili1).HasForeignKey(m => m.GroupTafziliId).WillCascadeOnDelete(false);
                modelBuilder.Entity<GroupTafzili>().HasMany(m => m.AllHesabTafzilis).WithRequired(m => m.GroupTafzili1).HasForeignKey(m => m.GroupTafziliId).WillCascadeOnDelete(false);
                modelBuilder.Entity<VamPardakhti>().HasMany(m => m.RizeAghsatVams).WithRequired(m => m.VamPardakhti1).HasForeignKey(m => m.VamPardakhtiId).WillCascadeOnDelete(true);

                modelBuilder.Entity<CheckTazmin>().HasMany(m => m.R_VamPardakhti_B_CheckTazmins).WithRequired(m => m.CheckTazmin1).HasForeignKey(m => m.CheckTazminId).WillCascadeOnDelete(false);
                modelBuilder.Entity<VamPardakhti>().HasMany(m => m.R_VamPardakhti_B_CheckTazmins).WithRequired(m => m.VamPardakhtin1).HasForeignKey(m => m.VamPardakhtiId).WillCascadeOnDelete(true);

                modelBuilder.Entity<AllHesabTafzili>().HasMany(m => m.R_VamPardakhti_B_Zamenins).WithRequired(m => m.AllHesabTafzili1).HasForeignKey(m => m.AllTafId).WillCascadeOnDelete(false);
                modelBuilder.Entity<VamPardakhti>().HasMany(m => m.R_VamPardakhti_B_Zamenins).WithRequired(m => m.VamPardakhtin1).HasForeignKey(m => m.VamPardakhtiId).WillCascadeOnDelete(true);

                modelBuilder.Entity<AllHesabTafzili>().HasMany(m => m.R_AnvaeVam_B_AllHesabTafzilis).WithRequired(m => m.AllHesabTafzili1).HasForeignKey(m => m.AllHesabTafziliId).WillCascadeOnDelete(true);
                modelBuilder.Entity<AnvaeVam>().HasMany(m => m.R_AnvaeVam_B_AllHesabTafzilis).WithRequired(m => m.AnvaeVam1).HasForeignKey(m => m.AnvaeVamId).WillCascadeOnDelete(false);

                //modelBuilder.Entity<AllHesabTafzili>().HasMany(m => m.VamPardakhtis).WithRequired(m => m.AllHesabTafzili1).HasForeignKey(m => m.AazaId).WillCascadeOnDelete(false);
                //modelBuilder.Entity<AllHesabTafzili>().HasMany(m => m.VamPardakhtis).WithRequired(m => m.AllHesabTafzili1).HasForeignKey(m => m.HesabTafziliId).WillCascadeOnDelete(false);
                //modelBuilder.Entity<HesabBanki>().HasMany(m => m.AsnadeHesabdariRows).WithRequired(m => m.HesabBanki1).HasForeignKey(m => m.HesabTafId).WillCascadeOnDelete(false);
                //modelBuilder.Entity<AazaSandogh>().HasMany(m => m.AsnadeHesabdariRows).WithRequired(m => m.AazaSandogh1).HasForeignKey(m => m.HesabTafId).WillCascadeOnDelete(false);
                //modelBuilder.Entity<CodingDaramadVHazine>().HasMany(m => m.AsnadeHesabdariRows).WithRequired(m => m.CodingDaramadVHazine1).HasForeignKey(m => m.HesabTafId).WillCascadeOnDelete(false);
                modelBuilder.Entity<AllHesabTafzili>().HasMany(m => m.AsnadeHesabdariRows).WithRequired(m => m.AllHesabTafzili1).HasForeignKey(m => m.HesabTafId).WillCascadeOnDelete(false);
                modelBuilder.Entity<AllHesabTafzili>().HasMany(m => m.CheckTazmins).WithRequired(m => m.AllHesabTafzili1).HasForeignKey(m => m.VamGerandeId).WillCascadeOnDelete(false);
                //modelBuilder.Entity<AllHesabTafzili>().HasMany(m => m.VamPardakhtis).WithRequired(m => m.AllHesabTafzili1).HasForeignKey(m => m.AazaId).WillCascadeOnDelete(false);

                modelBuilder.Entity<SalMali>().HasMany(m => m.AsnadeHesabdariRows).WithRequired(m => m.SalMali1).HasForeignKey(m => m.SalMaliId).WillCascadeOnDelete(false);
                modelBuilder.Entity<SalMali>().HasMany(m => m.CheckTazmins).WithRequired(m => m.SalMali1).HasForeignKey(m => m.SalMaliId).WillCascadeOnDelete(false);

                modelBuilder.Entity<CodeMoin>().HasMany(m => m.AsnadeHesabdariRows).WithRequired(m => m.CodeMoin1).HasForeignKey(m => m.HesabMoinId).WillCascadeOnDelete(false);
                modelBuilder.Entity<Tanzimat>().HasMany(m => m.AnvaeVams).WithRequired(m => m.Tanzimat1).HasForeignKey(m => m.TanzimatId).WillCascadeOnDelete(false);
                modelBuilder.Entity<AnvaeVam>().HasMany(m => m.TedadZamenins).WithRequired(m => m.AnvaeVam1).HasForeignKey(m => m.AnvaeVamId).WillCascadeOnDelete(false);

                modelBuilder.Entity<AnvaeVam>().Property(p => p.MaxPardakht).HasPrecision(18, 0);
                modelBuilder.Entity<AnvaeVam>().Property(p => p.MablaghDirkard).HasPrecision(18, 0);
                //modelBuilder.Entity<AnvaeVam>().Property(p => p.DarsadeKarmozd).HasColumnType("");

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات ذیل با خطا مواجه شد" + "\n" + "==> OnModelCreating()" + "\n" + ex.Message,
                    "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //finally
            //{
            //}
        }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}