namespace Sandogh_TG
{
    using Sandogh_TG.Migrations;
    using Sandogh_TG;
    using System;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;

    public class MyContext : DbContext
    {
        // Your context has been configured to use a 'MyContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Sandogh_TG.MyContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MyContext' 
        // connection string in the application configuration file.
        public MyContext()
            : base("name=MyContext")
        {
            #region
            //پیش فرض
            //Database.SetInitializer<MyContext>(new CreateDatabaseIfNotExists<MyContext>());
            //حذف دیتابیس قبلی بهمراه داده های داخلش و ایجاد دیتابیس جدید بدون داده در صورت تغییرویاعدم تغییر(در هرصورت) کلاس مدل
            //Database.SetInitializer<MyContext>(new DropCreateDatabaseAlways<MyContext>());
            // حذف دیتابیس قبلی بهمراه داده های داخلش و ایجاد دیتابیس جدید بدون داده در صورت تغییر کلاس مدل
            //Database.SetInitializer<MyContext>(new DropCreateDatabaseIfModelChanges<MyContext>());
            // غیرفعال کردن پیکربندی دیتابیس برای اینکه داده های فعلی موجود در دیتا بیس حذف نشود
            //Database.SetInitializer<MyContext>(null);
            //پیکربندی دیتابیس بصورت Coustom
            //Database.SetInitializer<MyContext>(new MyContextInitializer());
            #endregion
            //Migration SetInitializer
            Database.SetInitializer<MyContext>(new MigrateDatabaseToLatestVersion<MyContext, Configuration>(true));
            SqlConnection.ClearAllPools();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<TarifSandogh> TarifSandoghs { get; set; }
        public virtual DbSet<HesabBanki> HesabBankis { get; set; }
        public virtual DbSet<AazaSandogh> AazaSandoghs { get; set; }
        public virtual DbSet<HaghOzviat> HaghOzviats { get; set; }
        public virtual DbSet<VamPardakhti> VamPardakhtis { get; set; }
        public virtual DbSet<Tanzimat> Tanzimats { get; set; }
        public virtual DbSet<RizeAghsatVam> RizeAghsatVams { get; set; }
        public virtual DbSet<SalMali> SalMalis { get; set; }
        public virtual DbSet<CheckTazmin> CheckTazmins { get; set; }
        public virtual DbSet<DaryaftNaghdiVBanki> DaryaftNaghdiVBankis { get; set; }
        public virtual DbSet<PardakhtNaghdiVBanki> PardakhtNaghdiVBankis { get; set; }
        public virtual DbSet<CodingDaramadVHazine> CodingDaramadVHazines { get; set; }
        public virtual DbSet<SabDaramad> SabDaramads { get; set; }
        public virtual DbSet<SabtHazine> SabtHazines { get; set; }
        public virtual DbSet<EnteghalatHesabBanki> EnteghalatHesabBankis { get; set; }
        public virtual DbSet<EnteghalatHesabAaza> EnteghalatHesabAazas { get; set; }
        public virtual DbSet<EnteghalatBeDaramadVhazine> EnteghalatBeDaramadVhazines { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AazaSandogh>().HasMany(m => m.HaghOzviats).WithRequired(m => m.AazaSandogh1).HasForeignKey(m => m.AazaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<AazaSandogh>().HasMany(m => m.VamPardakhtis).WithRequired(m => m.AazaSandogh1).HasForeignKey(m => m.AazaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<AazaSandogh>().HasMany(m => m.CheckTazmins).WithRequired(m => m.AazaSandogh1).HasForeignKey(m => m.VamGerandeId).WillCascadeOnDelete(false);
            modelBuilder.Entity<AazaSandogh>().HasMany(m => m.DaryaftNaghdiVBankis).WithRequired(m => m.AazaSandogh1).HasForeignKey(m => m.PardakhtkonandeId).WillCascadeOnDelete(false);
            modelBuilder.Entity<AazaSandogh>().HasMany(m => m.PardakhtNaghdiVBankis).WithRequired(m => m.AazaSandogh1).HasForeignKey(m => m.DaryaftkonandeId).WillCascadeOnDelete(false);
            modelBuilder.Entity<HesabBanki>().HasMany(m => m.HaghOzviats).WithRequired(m => m.HesabBanki1).HasForeignKey(m => m.NameHesabId).WillCascadeOnDelete(false);
            modelBuilder.Entity<HesabBanki>().HasMany(m => m.VamPardakhtis).WithRequired(m => m.HesabBanki1).HasForeignKey(m => m.NameHesabId).WillCascadeOnDelete(false);
            modelBuilder.Entity<TarifSandogh>().HasOptional(m => m.Tanzimat1).WithRequired(m => m.TarifSandogh1).WillCascadeOnDelete(true);
            modelBuilder.Entity<TarifSandogh>().HasMany(m => m.CodingDaramadVHazines).WithRequired(m => m.TarifSandogh1).HasForeignKey(m => m.SandoghId).WillCascadeOnDelete(false);
            modelBuilder.Entity<TarifSandogh>().HasMany(m => m.SabDaramads).WithRequired(m => m.TarifSandogh1).HasForeignKey(m => m.SandoghId).WillCascadeOnDelete(false);
            modelBuilder.Entity<TarifSandogh>().HasMany(m => m.SabtHazines).WithRequired(m => m.TarifSandogh1).HasForeignKey(m => m.SandoghId).WillCascadeOnDelete(false);
            modelBuilder.Entity<VamPardakhti>().HasMany(m => m.RizeAghsatVams).WithRequired(m => m.VamPardakhti1).HasForeignKey(m => m.VamPardakhtiId).WillCascadeOnDelete(false);
            modelBuilder.Entity<TarifSandogh>().HasMany(m => m.SalMalis).WithRequired(m => m.TarifSandogh1).HasForeignKey(m => m.TarifSandoghId).WillCascadeOnDelete(false);
            modelBuilder.Entity<TarifSandogh>().HasMany(m => m.HesabBankis).WithRequired(m => m.TarifSandogh1).HasForeignKey(m => m.TarifSandoghId).WillCascadeOnDelete(false);
            modelBuilder.Entity<TarifSandogh>().HasMany(m => m.AazaSandoghs).WithRequired(m => m.TarifSandogh1).HasForeignKey(m => m.TarifSandoghId).WillCascadeOnDelete(false);
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}