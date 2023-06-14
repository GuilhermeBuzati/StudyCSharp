using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    internal class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StoreDB;Trusted_Connection=true;");
        }

    }
}