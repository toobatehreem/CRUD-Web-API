using APIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace APIProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }

        public DbSet<Products> Products { get; set; }
        public DbSet<ProductType> ProductType { get; set; }

        public DbSet<Users> Users { get; set; }
    }
}
