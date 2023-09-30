using Microsoft.EntityFrameworkCore;

namespace OrdersService.Model
{
    /// <summary>
    /// Contesto del database per gli ordini.
    /// </summary>
    public class Context : DbContext
    {
        /// <summary>
        /// Insieme degli ordini e prodotti correlati.
        /// </summary>
        public virtual DbSet<OrderProducts> OrderProducts { get; set; }

        /// <summary>
        /// Insieme degli ordini.
        /// </summary>
        public virtual DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Crea un'istanza di Context.
        /// </summary>
        public Context()
        {
        }

        /// <summary>
        /// Crea un'istanza di Context con le opzioni specificate.
        /// </summary>
        /// <param name="options">Opzioni del contesto del database.</param>
        public Context(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Configura il modello del database tramite Fluent API.
        /// </summary>
        /// <param name="modelBuilder">Generatore di modelli.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProducts>()
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderProducts)
                .HasForeignKey(x => x.OrderId)
                ;

            modelBuilder.Entity<Order>()
                .HasIndex(x => x.OrderNumber)
                .IsUnique()
                ;
        }
    }
}
