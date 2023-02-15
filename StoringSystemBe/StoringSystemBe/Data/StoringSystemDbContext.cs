using Microsoft.EntityFrameworkCore;
using StoringSystemBe.Model;

namespace StoringSystemBe.Data;

public class StoringSystemDbContext : DbContext
{
    public DbSet<ProductType> ProductTypes { get; set; } = null!;
    public DbSet<Product> Product { get; set; } = null!;
    public StoringSystemDbContext(DbContextOptions options) : base(options){}
}