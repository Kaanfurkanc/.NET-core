using Microsoft.EntityFrameworkCore;
using WebApiProject.Core;

namespace WebApiProject.Repository
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=MSSQLSERVER;database=ProductDatabase
                            ;integrated security=true;TrustServerCertificate=True;");
        }
        
        public DbSet<Product> products { get; set; } = null!;
    }
}
