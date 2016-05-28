using Avant.Domain;
using Avant.Domain.Utils;
using Microsoft.Data.Entity;

namespace Avant.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Avant;Integrated Security=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Property(p => p.CategoryId).IsRequired(false);
        }

        public void Migrate()
        {
            Database.Migrate();
        }
    }
}
