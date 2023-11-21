using Microsoft.EntityFrameworkCore;
using Donations.Entities.Models;

namespace Donations.DAL.Data
{
    public class DonationDbContext : DbContext
    {
        public DonationDbContext(DbContextOptions<DonationDbContext> options) : base(options)
        {
        }

        public DbSet<Donation> Donations { get; set; }
        public DbSet<PoliticalEntity> Entities { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}
