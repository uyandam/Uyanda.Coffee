using Microsoft.EntityFrameworkCore;
using Uyanda.Coffee.Persistence.Entities;

namespace Uyanda.Coffee.Persistence
{
    public class LocalDbContext : DbContext, IUnitOfWork
    {
        private readonly string connectionString = "Data Source = (LocalDB)\\mssqllocaldb;Integrated Security = True; Initial Catalog = D_CoffeeShop;";

        public LocalDbContext()
        {
            
        }
        public LocalDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<BeverageEntity> Beverages { get; set; }

        public DbSet<BeverageSizeCostEntity> BeverageCost { get; set; }

        public DbSet<LineItemEntity> LineItem { get; set; }

        public DbSet<InvoiceEntity> Invoice { get; set; }

        public DbSet<BeverageSizeEntity> BeverageSizes { get; set; }

        public DbSet<CustomerEntity> Customer { get; set; }

        public DbSet<PaymentEntity> Pay { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Constants.DataSchema);

            modelBuilder.Entity<BeverageEntity>(entity =>
            {
                entity.Property(p => p.Name).HasColumnType("varchar(128)");

                entity.ToTable("Beverage");
            });


            modelBuilder.Entity<BeverageSizeCostEntity>()
                .HasIndex(c => new { c.BeverageId, c.BeverageSizeId })
                .IsUnique();

            modelBuilder.Entity<CustomerEntity>()
                .HasIndex(c => new { c.PhoneNumber })
                .IsUnique();

            modelBuilder.Entity<PaymentEntity>()
                .HasIndex(c => new { c.InvoiceId })
                .IsUnique();

            modelBuilder.Entity<CustomerEntity>().HasData(
                new CustomerEntity { Id = 1, PhoneNumber = "0" , Points = 0}
                );


            modelBuilder.Entity<BeverageTypeEntity>().HasData(
                new BeverageTypeEntity { Id = 1, Name = "Hot"},
                new BeverageTypeEntity { Id = 2, Name = "Cold"}
                );

            modelBuilder.Entity<BeverageSizeEntity>().HasData(
                new BeverageSizeEntity { Id = 1, Name = "Small"},
                new BeverageSizeEntity { Id = 2, Name = "Medium"},
                new BeverageSizeEntity { Id = 3, Name = "Large"}
                );

            modelBuilder.Entity<BeverageEntity>().HasData(
                new BeverageEntity { Id = 1, BeverageTypeId = 1, IsActive = true, Name = "Coffee" },
                new BeverageEntity { Id = 2, BeverageTypeId = 1, IsActive = true, Name = "Five Roses"},
                new BeverageEntity { Id = 3, BeverageTypeId = 2, IsActive = true, Name = "Milkshake"}
                );

            modelBuilder.Entity<BeverageSizeCostEntity>().HasData(
                new BeverageSizeCostEntity { Id = 1, BeverageId = 1, BeverageSizeId = 1, Cost = 15},
                new BeverageSizeCostEntity { Id = 2, BeverageId = 2, BeverageSizeId = 1, Cost = 25},
                new BeverageSizeCostEntity { Id = 3, BeverageId = 3, BeverageSizeId = 1, Cost = 30},
                new BeverageSizeCostEntity { Id = 4, BeverageId = 1, BeverageSizeId = 2, Cost = 10},
                new BeverageSizeCostEntity { Id = 5, BeverageId = 2, BeverageSizeId = 2, Cost = 15},
                new BeverageSizeCostEntity { Id = 6, BeverageId = 3, BeverageSizeId = 2, Cost = 20},
                new BeverageSizeCostEntity { Id = 7, BeverageId = 1, BeverageSizeId = 3, Cost = 20},
                new BeverageSizeCostEntity { Id = 8, BeverageId = 2, BeverageSizeId = 3, Cost = 30},
                new BeverageSizeCostEntity { Id = 9, BeverageId = 3, BeverageSizeId = 3, Cost = 40}
                );

        }
    }
}
