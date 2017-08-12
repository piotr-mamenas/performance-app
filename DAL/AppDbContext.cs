using System.Data.Entity;
using Core.Domain.Identity;
using Core.Domain.Organization;
using Core.Domain.Partner;

namespace DAL
{
    public class AppDbContext : ApplicationDbContext
    {
        public DbSet<Bank> Organizations { get; set; }
        public DbSet<AssetManager> AssetManagers { get; set; }
    }
}
