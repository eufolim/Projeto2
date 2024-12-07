using Microsoft.EntityFrameworkCore;
using taxa.Services;

namespace taxa
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Taxa> Taxas { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Taxa>().HasKey(p => p.Id);
            

            base.OnModelCreating(modelBuilder);
        }
    }
}