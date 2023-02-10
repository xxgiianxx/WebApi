using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApiPrueba.Controllers;
using WebApiPrueba.DataModel;

namespace WebApiPrueba.DataBaseContext
{
    public class MyDatabaseContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ProductDb");
        }

        public virtual DbSet<ProductoDataModel> Productos { get; set; }
        public virtual DbSet<CategoriaDataModel> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductoDataModel>()
           .HasOne<CategoriaDataModel>(s => s.categoria)
           .WithMany(g => g.Productos)
           .HasForeignKey(s => s.CategoriaId);
        }
    }
}