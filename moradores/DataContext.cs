using Microsoft.EntityFrameworkCore;

namespace moradores
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}