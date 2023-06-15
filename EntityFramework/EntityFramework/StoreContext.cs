using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    internal class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<SalePromotion> SalePromotion { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StoreDB;Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Update table name
            //modelBuilder
            //    .Entity<Address>()
            //    .ToTable("New Name");
            
            modelBuilder
                .Entity<Address>()
                .Property<int>("ClientId");

            modelBuilder.Entity<Address>().HasKey("ClientId");
        }

    }
}