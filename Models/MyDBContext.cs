using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABP_Test.Models
{
    public class MyDBContext : DbContext
    {
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Complectation> Complectations { get; set; }
        public DbSet<GroupParts> GroupParts { get; set; }
        public DbSet<SubGroup> SubGroups { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }

        public MyDBContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MACHINE-1O01OGG;Database=ABPTest;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true");
            //optionsBuilder.UseLazyLoadingProxies();
        }

        //protected override void OnConfiguring(
        //    DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite(
        //        "Data Source=products.db");
        //    optionsBuilder.UseLazyLoadingProxies();
        //}

    }
}
