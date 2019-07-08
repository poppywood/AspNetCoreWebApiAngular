using AspNetCoreWebApiAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApiAngular.DataContext
{
    public class MonitorContext : DbContext 
    {
        public DbSet<Monitor> Monitors { get; set; }
        public MonitorContext(DbContextOptions<MonitorContext> options)
            : base(options)
        {
        }

    }
}
