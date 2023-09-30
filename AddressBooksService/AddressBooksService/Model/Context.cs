using Microsoft.EntityFrameworkCore;

namespace AddressBooksService.Model
{
    /// <summary>
    /// Rappresenta il contesto del database per l'applicazione.
    /// </summary>
    public class Context : DbContext
    {
        /// <summary>
        /// Ottiene o imposta l'insieme delle entità Paese nel database.
        /// </summary>
        public virtual DbSet<Country> Countries { get; set; }

        /// <summary>
        /// Ottiene o imposta l'insieme delle entità Indirizzo nel database.
        /// </summary>
        public virtual DbSet<AddressBook> AddressBooks { get; set; }

        /// <summary>
        /// Ottiene o imposta l'insieme delle entità Città nel database.
        /// </summary>
        public virtual DbSet<City> Cities { get; set; }

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="Context"/>.
        /// </summary>
        public Context()
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="Context"/> con le opzioni specificate.
        /// </summary>
        /// <param name="options">Opzioni per la configurazione del contesto del database.</param>
        public Context(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Configura il modello che è stato definito per il contesto del database.
        /// </summary>
        /// <param name="modelBuilder">Generatore di modelli usato per la costruzione del modello per il contesto del database.</param>
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
