using Microsoft.EntityFrameworkCore;
using test_mvc.Models.Entities;

namespace test_mvc.Config;

public class AppDbContext : DbContext
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}