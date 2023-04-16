global using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPIDotNet7.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"server=LAPTOP-1N27P6TM\MSSQLSERVERNEW;database=SuperHeroDB
                            ;Trusted_Connection=true;integrated security=true;TrustServerCertificate=True;");
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }

    }
}
