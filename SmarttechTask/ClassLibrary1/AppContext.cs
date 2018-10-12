using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.DAL
{
    public class AppContext : DbContext
    {
        public AppContext()
          : base("AppContext")
        {
        }

        public static AppContext Create()
        {
            return new AppContext();
        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Faculty> Faculties { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}