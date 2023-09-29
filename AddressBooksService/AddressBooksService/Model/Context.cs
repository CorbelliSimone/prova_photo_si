using Microsoft.EntityFrameworkCore;

namespace AddressBooksService.Model
{
    public class Context : DbContext
    {
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<AddressBook> AddressBooks { get; set; }
        public virtual DbSet<City> Cities { get; set; }

        public Context()
        {
        }

        public Context(DbContextOptions options) : base(options)
        {
        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasOne(x => x.Country)
                .WithMany(x => x.Cities)
                .HasForeignKey(x => x.CountryId)
                ;

            modelBuilder.Entity<AddressBook>()
                .HasOne(x => x.City)
                .WithMany(x => x.AddressBooks)
                .HasForeignKey(x => x.CityId)
                ;
        }
    }
}
