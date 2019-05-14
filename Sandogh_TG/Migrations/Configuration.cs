namespace Sandogh_TG.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Configuration;
    using System.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<Sandogh_TG.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Sandogh_TG.MyContext";
            string DataPath = Application.StartupPath + @"\DB\";
            AppDomain.CurrentDomain.SetData("DataDirectory", DataPath);
        }

        protected override void Seed(Sandogh_TG.MyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Entry(new TarifSandogh() { Id = 1, NameSandogh = "صندوق قرض الحسنه", IsDefault = true }).State = context.TarifSandoghs.Any(s => s.Id == 1) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new SalMali() { Id = 1, TarifSandoghId = 1, NameSandogh = "صندوق قرض الحسنه", SaleMali = 1398, StartDate = Convert.ToDateTime("2019/03/21"), EndDate = Convert.ToDateTime("2020/03/19"), IsDefault = true }).State = context.SalMalis.Any(s => s.Id == 1) ? EntityState.Unchanged : EntityState.Added;
            //context.Entry(new HesabBanki() { Id = 1, TarifSandoghId = 1, GroupTafziliId = 2, NameHesab = "ملت مرکزی جاری 123456789", StartDate = Convert.ToDateTime("2019/03/21"), IsDefault = true, IsActive = true, Code = 3000001, GroupHesabIndex = 1, GroupHesab = "بانک", NameBank = "ملت", NoeHesab = "جاری", ShomareHesab = "123456789", NameShobe = "مرکزی" }).State = context.HesabBankis.Any(s => s.Code == 3000001) ? EntityState.Unchanged : EntityState.Added;
            //context.Entry(new HesabBanki() { Id = 2, TarifSandoghId = 1, GroupTafziliId = 2, NameHesab = "صادرات مرکزی جاری 456789000", StartDate = Convert.ToDateTime("2019/03/21"), IsDefault = false, IsActive = true, Code = 3000002, GroupHesabIndex = 1, GroupHesab = "بانک", NameBank = "صادرات", NoeHesab = "جاری", ShomareHesab = "456789000", NameShobe = "مرکزی" }).State = context.HesabBankis.Any(s => s.Code == 3000002) ? EntityState.Unchanged : EntityState.Added;
            //context.Entry(new AazaSandogh() { Id = 1, TarifSandoghId = 1, GroupTafziliId = 3, IsOzveSandogh = true, NameVFamil = "کمال خیاطی", TarikhOzviat = Convert.ToDateTime("2019/03/21"), IsActive = true, Code = 7000001, HaghOzviat = 500000, CodePersoneli = "1" }).State = context.AazaSandoghs.Any(s => s.Code == 7000001) ? EntityState.Unchanged : EntityState.Added;
            //context.Entry(new AazaSandogh() { Id = 2, TarifSandoghId = 1, GroupTafziliId = 3, IsOzveSandogh = true, NameVFamil = "جمال خیاطی", TarikhOzviat = Convert.ToDateTime("2019/03/21"), IsActive = true, Code = 7000002, HaghOzviat = 400000, CodePersoneli = "2" }).State = context.AazaSandoghs.Any(s => s.Code == 7000002) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new Tanzimat() { Id = 1, SandoghId = 1, checkEdit1 = true, checkEdit2 = true, checkEdit3 = true, DarsadeKarmozd = 0, MablaghDirkard = 0, MaximumAghsatMahane = 60, MaximumAghsatSalane = 5 }).State = context.Tanzimats.Any(s => s.Id == 1) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodingDaramadVHazine() { Id = 1, SandoghId = 1, GroupTafziliId = 4, IsActive = true, Code = 1000001, GroupIndex = 0, GroupName = "درآمد", HesabName = "درآمد کارمزد وام" }).State = context.CodingDaramadVHazines.Any(s => s.Code == 1000001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodingDaramadVHazine() { Id = 2, SandoghId = 1, GroupTafziliId = 4, IsActive = true, Code = 1000002, GroupIndex = 0, GroupName = "درآمد", HesabName = "درآمد افتتاح حساب" }).State = context.CodingDaramadVHazines.Any(s => s.Code == 1000002) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodingDaramadVHazine() { Id = 3, SandoghId = 1, GroupTafziliId = 5, IsActive = true, Code = 2000001, GroupIndex = 1, GroupName = "هزینه", HesabName = "هزینه کارمزد بانکی" }).State = context.CodingDaramadVHazines.Any(s => s.Code == 2000001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new Karbaran() { Id = 1, Name = "مدیر صندوق", Shenase = "1", Password = "1" }).State = context.Karbarans.Any(s => s.Id == 1) ? EntityState.Unchanged : EntityState.Added;

            context.Entry(new AllHesabTafzili() { Id = 1, Id2 = 1, Code = 1000001, Name = "درآمد کارمزد وام", SandoghId = 1, IsActive = true, GroupTafziliId = 4 }).State = context.AllHesabTafzilis.Any(s => s.Code == 1000001) ? EntityState.Unchanged : EntityState.Added;
            //context.Entry(new AllHesabTafzili() { Id = 2, Id2 = 1, Code = 3000001, Name = "ملت مرکزی جاری 123456789", SandoghId = 1, IsActive = true, GroupTafziliId = 2 }).State = context.AllHesabTafzilis.Any(s => s.Code == 3000001) ? EntityState.Unchanged : EntityState.Added;
            //context.Entry(new AllHesabTafzili() { Id = 3, Id2 = 2, Code = 3000002, Name = "صادرات مرکزی جاری 456789000", SandoghId = 1, IsActive = true, GroupTafziliId = 2 }).State = context.AllHesabTafzilis.Any(s => s.Code == 3000002) ? EntityState.Unchanged : EntityState.Added;
            //context.Entry(new AllHesabTafzili() { Id = 4, Id2 = 1, Code = 7000001, Name = "کمال خیاطی", SandoghId = 1, IsActive = true, GroupTafziliId = 3 }).State = context.AllHesabTafzilis.Any(s => s.Code == 7000001) ? EntityState.Unchanged : EntityState.Added;
            //context.Entry(new AllHesabTafzili() { Id = 5, Id2 = 2, Code = 7000002, Name = "جمال خیاطی", SandoghId = 1, IsActive = true, GroupTafziliId = 3 }).State = context.AllHesabTafzilis.Any(s => s.Code == 7000002) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new AllHesabTafzili() { Id = 6, Id2 = 2, Code = 1000002, Name = "درآمد افتتاح حساب", SandoghId = 1, IsActive = true, GroupTafziliId = 4 }).State = context.AllHesabTafzilis.Any(s => s.Code == 1000002) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new AllHesabTafzili() { Id = 7, Id2 = 3, Code = 2000001, Name = "هزینه کارمزد بانکی", SandoghId = 1, IsActive = true, GroupTafziliId = 5 }).State = context.AllHesabTafzilis.Any(s => s.Code == 2000001) ? EntityState.Unchanged : EntityState.Added;

            context.Entry(new CodeMoin() { Id = 1, Code = 1001, Name = "صندوق و بانک", SandoghId = 1 }).State = context.CodeMoins.Any(s => s.Code == 1001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 2, Code = 2001, Name = "وام اعضاء", SandoghId = 1 }).State = context.CodeMoins.Any(s => s.Code == 2001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 3, Code = 3001, Name = "مساعده", SandoghId = 1 }).State = context.CodeMoins.Any(s => s.Code == 3001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 4, Code = 4001, Name = "بدهکاران", SandoghId = 1 }).State = context.CodeMoins.Any(s => s.Code == 4001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 5, Code = 6001, Name = "وام پرداختنی", SandoghId = 1 }).State = context.CodeMoins.Any(s => s.Code == 6001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 6, Code = 6002, Name = "اسناد پرداختنی", SandoghId = 1 }).State = context.CodeMoins.Any(s => s.Code == 6002) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 7, Code = 6003, Name = "بستانکاران", SandoghId = 1 }).State = context.CodeMoins.Any(s => s.Code == 6003) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 8, Code = 7001, Name = "سرمایه", SandoghId = 1 }).State = context.CodeMoins.Any(s => s.Code == 7001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 9, Code = 8001, Name = "درآمد", SandoghId = 1 }).State = context.CodeMoins.Any(s => s.Code == 8001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 10, Code = 9001, Name = "هزینه", SandoghId = 1 }).State = context.CodeMoins.Any(s => s.Code == 9001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new GroupTafzili() { Id = 1, Code = 1, Name = "صندوق", SandoghId = 1 }).State = context.GroupTafzilis.Any(s => s.Code == 1) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new GroupTafzili() { Id = 2, Code = 2, Name = "بانک", SandoghId = 1 }).State = context.GroupTafzilis.Any(s => s.Code == 2) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new GroupTafzili() { Id = 3, Code = 3, Name = "اشخاص", SandoghId = 1 }).State = context.GroupTafzilis.Any(s => s.Code == 3) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new GroupTafzili() { Id = 4, Code = 4, Name = "درآمد", SandoghId = 1 }).State = context.GroupTafzilis.Any(s => s.Code == 4) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new GroupTafzili() { Id = 5, Code = 5, Name = "هزینه", SandoghId = 1 }).State = context.GroupTafzilis.Any(s => s.Code == 5) ? EntityState.Unchanged : EntityState.Added;

        }
    }
}
