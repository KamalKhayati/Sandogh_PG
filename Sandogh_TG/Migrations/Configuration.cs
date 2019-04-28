namespace Sandogh_TG.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Windows.Forms;

    internal sealed class Configuration : DbMigrationsConfiguration<Sandogh_TG.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Sandogh_TG.MyContext";
            string DataPath = Application.StartupPath + @"\DB";
            AppDomain.CurrentDomain.SetData("DataDirectory", DataPath);
        }

        protected override void Seed(Sandogh_TG.MyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Entry(new TarifSandogh() { Id = 1, NameSandogh = "صندوق قرض الحسنه", IsDefault = true, }).State = context.TarifSandoghs.Any(s => s.Id == 1) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new SalMali() { Id = 1, TarifSandoghId = 1, NameSandogh = "صندوق قرض الحسنه", SaleMali = 1398, StartDate = Convert.ToDateTime("2019/03/21"), EndDate = Convert.ToDateTime("2020/03/19"), IsDefault = true }).State = context.SalMalis.Any(s => s.Id == 1) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new HesabBanki() { Id = 1, TarifSandoghId = 1, NameHesab = "ملت مرکزی جاری 123456789", SalMaliId = 1, StartDate = Convert.ToDateTime("2019/03/21"), IsDefault = true ,IsActive=true,Code=3000001,GroupHesabIndex=1,GroupHesab="بانک",NameBank="ملت",NoeHesab="جاری",ShomareHesab="123456789",NameShobe="مرکزی"}).State = context.HesabBankis.Any(s => s.Code == 3000001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new HesabBanki() { Id = 2, TarifSandoghId = 1, NameHesab = "صادرات مرکزی جاری 456789000", SalMaliId = 1, StartDate = Convert.ToDateTime("2019/03/21"), IsDefault = false ,IsActive=true,Code=3000002,GroupHesabIndex=1,GroupHesab="بانک",NameBank="صادرات",NoeHesab="جاری",ShomareHesab= "456789000", NameShobe="مرکزی"}).State = context.HesabBankis.Any(s => s.Code == 3000002) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new AazaSandogh() { Id = 1, TarifSandoghId = 1, NameVFamil = "کمال خیاطی", SalMaliId = 1, TarikhOzviat = Convert.ToDateTime("2019/03/21"), IsActive=true,Code=7000001,HaghOzviat=500000,CodePersoneli="1"}).State = context.AazaSandoghs.Any(s => s.Code == 7000001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new AazaSandogh() { Id = 2, TarifSandoghId = 1, NameVFamil = "جمال خیاطی", SalMaliId = 1, TarikhOzviat = Convert.ToDateTime("2019/03/21"), IsActive=true,Code=7000002,HaghOzviat=400000,CodePersoneli="2"}).State = context.AazaSandoghs.Any(s => s.Code == 7000002) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new Tanzimat() { Id = 1, SandoghId = 1, checkEdit1 = true, checkEdit2 = true, checkEdit3 = true,SalMaliId=1 }).State = context.Tanzimats.Any(s => s.Id == 1) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodingDaramadVHazine() { Id = 1, SandoghId=1, Code = 1000001,GroupIndex=0 ,GroupName="درآمد",HesabName="درآمد کارمزد وام",SalMaliId=1 }).State = context.CodingDaramadVHazines.Any(s => s.Code == 1000001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 1, Code = 1001, Name="صندوق و بانک",SalMaliId=1 }).State = context.CodeMoins.Any(s => s.Code == 1001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 2, Code = 2001, Name="وام اعضاء",SalMaliId=1 }).State = context.CodeMoins.Any(s => s.Code == 2001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 3, Code = 3001, Name="مساعده",SalMaliId=1 }).State = context.CodeMoins.Any(s => s.Code == 3001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 4, Code = 4001, Name="بدهکاران سایر",SalMaliId=1 }).State = context.CodeMoins.Any(s => s.Code == 4001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 5, Code = 6001, Name="وام پرداختنی",SalMaliId=1 }).State = context.CodeMoins.Any(s => s.Code == 6001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 6, Code = 6002, Name="اسناد پرداختنی",SalMaliId=1 }).State = context.CodeMoins.Any(s => s.Code == 6002) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 7, Code = 6003, Name="بستانکاران سایر",SalMaliId=1 }).State = context.CodeMoins.Any(s => s.Code == 6003) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 8, Code = 7001, Name="سرمایه",SalMaliId=1 }).State = context.CodeMoins.Any(s => s.Code == 7001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 9, Code = 8001, Name="درآمد",SalMaliId=1 }).State = context.CodeMoins.Any(s => s.Code == 8001) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new CodeMoin() { Id = 10, Code = 9001, Name="هزینه",SalMaliId=1 }).State = context.CodeMoins.Any(s => s.Code == 9001) ? EntityState.Unchanged : EntityState.Added;

        }
    }
}
