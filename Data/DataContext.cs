using AssignmentHelpers.Models;
using Microsoft.EntityFrameworkCore;
namespace AssignmentHelpers.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options):base (options)
        {

        }
        public DbSet<client> clients { get; set; }
        public DbSet<assignment> assignments { get; set; }
        public DbSet<testimony> testimonies { get; set; }
        public DbSet<banner> banners { get; set; }
        public DbSet<feed> feeds { get; set; }
         
    }
}
