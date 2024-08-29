using API.Models;
using System.Data.Entity;

namespace MyApiProject.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=MyDbContext")
        {
            // Deshabilitar el pluralizado de nombres de tablas
            this.Configuration.LazyLoadingEnabled = false;
        }

        // Mapeo explícito de la tabla
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product"); // Nombre exacto de la tabla
        }

        public DbSet<Product> Products { get; set; }
    }
}
