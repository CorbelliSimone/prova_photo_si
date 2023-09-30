using Microsoft.EntityFrameworkCore;

namespace UsersService.Model
{
    /// <summary>
    /// Il contesto del database per gli utenti.
    /// </summary>
    public class Context : DbContext
    {
        /// <summary>
        /// Inizializza una nuova istanza di <see cref="Context"/>.
        /// </summary>
        public Context()
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="Context"/> con le opzioni specificate.
        /// </summary>
        /// <param name="options">Le opzioni per il contesto del database.</param>
        public Context(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Ottiene o imposta l'insieme degli utenti nel database.
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Configura il modello del database durante il processo di creazione.
        /// </summary>
        /// <param name="modelBuilder">Il generatore di modelli utilizzato per costruire il modello del database.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
              .HasIndex(u => u.Username)
              .IsUnique();
        }
    }
}
