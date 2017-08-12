using System.Data.Entity;
using Core.Domain.Contact;
using Core.Domain.Organization;
using Core.Domain.Partner;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=DefaultConnection")
        {
            
        }

        public DbSet<BasePartner> Partners { get; set; }
        public DbSet<BaseOrganization> Organizations { get; set; }
        public DbSet<BaseContact> Contacts { get; set; }
    }
}
