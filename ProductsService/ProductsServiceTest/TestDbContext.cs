using Microsoft.EntityFrameworkCore;
using ProductsService.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsServiceTest
{
    public class TestDbContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your model here if needed
        }
    }
}
