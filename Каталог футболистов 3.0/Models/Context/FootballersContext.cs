using Microsoft.EntityFrameworkCore;

namespace Каталог_футболистов_3._0.Models.Context
{
    public class FootballersContext : DbContext
    {
        public DbSet<Footballers> Footballers { get; set; }

        public FootballersContext(DbContextOptions<FootballersContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
