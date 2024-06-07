using App.Domain.Core.Adress.Entities;
using App.Domain.Core.CategoryService.Entities;
using App.Domain.Core.Member.Entities;
using App.Domain.Core.OrderAgg.Entities;
using App.Infra.DB.SqlServer.EF.EntitiesConfigoration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DB.SqlServer.EF.DB_Achare.Ef
{
    public class AchareDbContext : DbContext
    {
        public AchareDbContext(DbContextOptions<AchareDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new BidConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfigorarion());
            modelBuilder.ApplyConfiguration(new MainCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ExpertConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public Expert Experts { get; set; }
        public Customer Customers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
    }
}
