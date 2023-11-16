using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Otthonbazar.Data.EntityTypeConfigurations;
using otthanbazar.Data;

namespace otthanbazar.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<otthanbazar.Data.Advertisement>? Advertisements { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
             builder.Entity<City>().ToTable("City");
            builder.Entity<Advertisement>().ToTable("Advertisement");
            builder.ApplyConfiguration(new CitySeedConfig());
            builder.ApplyConfiguration(new AdvertisementSeedConfig());

        }





    }
}