using Microsoft.EntityFrameworkCore;
using residencias.Services;

namespace residencias
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Residencia> Residencias { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Residencia>().HasKey(p => p.Id);
            

            base.OnModelCreating(modelBuilder);
        }
    }
}