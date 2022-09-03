using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using template.Data.Models;
using WorldCities.Data.Models;

namespace WorldCities.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        public DbSet<LogModel> LogModels { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        

        // public DbSet<City> Cities { get; set; }
        // public DbSet<Country> Countries { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Adding the code below tells DB "NumericId is an AlternateKey and don't update".
            modelBuilder.Entity<MedicalRecord>().Property(e => e.CreatedDate)
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);



        }
    }
}
