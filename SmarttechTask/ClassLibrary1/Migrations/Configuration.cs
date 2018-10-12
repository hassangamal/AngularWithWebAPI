namespace ClassLibrary1.Migrations
{
    using Smart.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Smart.DAL.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Smart.DAL.AppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Faculties.AddOrUpdate(
                  p => p.Name,
                   new Faculty { Name = "Computer and information Science" },
                   new Faculty { Name = "Commerce" },
                   new Faculty { Name = "Engineering" }
                 );
        }
    }
}
