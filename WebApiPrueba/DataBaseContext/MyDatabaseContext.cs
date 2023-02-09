using Microsoft.EntityFrameworkCore;
using WebApiPrueba.DataModel;

namespace WebApiPrueba.DataBaseContext
{
    public class MyDatabaseContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ProductDb");
        }
        
        public DbSet<ProductDataModel> Products { get; set; }
    }
}
