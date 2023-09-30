using Microsoft.EntityFrameworkCore;

namespace ProductsService.Model
{
    /// <summary>
    /// Rappresenta il contesto del database per l'applicazione.
    /// </summary>
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Collezione dei prodotti nel database.
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }

        /// <summary>
        /// Collezione delle categorie nel database.
        /// </summary>
        public virtual DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Configura le relazioni e le proprietà delle entità nel modello.
        /// </summary>
        /// <param name="modelBuilder">Il generatore di modelli EF.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
