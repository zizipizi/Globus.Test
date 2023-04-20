using Globus.Test.Domain.Models;
using Globus.Test.Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Globus.Test.Infrastructure;

public class ProductDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    

    public ProductDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
    }
}

//dotnet ef migrations add initial_create --project Globus.Test.Infrastructure --startup-project Globus.Test.Api
//dotnet ef database update --project Globus.Test.Infrastructure --startup-project Globus.Test.Api