using iocs_analizer_api.Models;
using Microsoft.EntityFrameworkCore;

namespace iocs_analizer_api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }

        public DbSet<Ioc> Iocs { get; set; }
    }
}