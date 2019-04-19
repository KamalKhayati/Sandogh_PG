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
            context.Entry(new TarifSandogh() { Id = 1, NameSandogh = "ÕäÏæÞ ÞÑÖ ÇáÍÓäå", IsDefault = true, }).State = context.TarifSandoghs.Any(s => s.Id == 1) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new SalMali() { Id = 1, TarifSandoghId = 1, NameSandogh = "ÕäÏæÞ ÞÑÖ ÇáÍÓäå", SaleMali = 1398, StartDate = Convert.ToDateTime("2019/03/21"), EndDate = Convert.ToDateTime("2020/03/19"), IsDefault = true }).State = context.SalMalis.Any(s => s.Id == 1) ? EntityState.Unchanged : EntityState.Added;
            context.Entry(new Tanzimat() { Id = 1, SandoghId = 1, checkEdit1 = true, checkEdit2 = true, checkEdit3 = true,SalMaliId=1 }).State = context.Tanzimats.Any(s => s.Id == 1) ? EntityState.Unchanged : EntityState.Added;

        }
    }
}
