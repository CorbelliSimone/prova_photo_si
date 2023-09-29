using Microsoft.EntityFrameworkCore;

namespace OrdersService.Model
{
    public class Context : DbContext
    {
        public virtual DbSet<OrderProducts> OrderProducts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public Context()
        {
        }

        public Context(DbContextOptions options) : base(options)
        {
        }

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
