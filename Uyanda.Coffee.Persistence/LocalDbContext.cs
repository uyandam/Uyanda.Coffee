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

        public DbSet<TransactionEntity> Transaction { get; set; }

        public DbSet<InvoiceEntity> Invoice { get; set; }

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

        }
    }
}
