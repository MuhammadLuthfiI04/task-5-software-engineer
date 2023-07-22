using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
        public DbSet<Customer> Customers { get; set; }
    }
}
