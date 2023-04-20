using Globus.Test.Domain.Interfaces;
using Globus.Test.Domain.Models;
using Globus.Test.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Globus.Test.Infrastructure.Repositories;

internal class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _dbContext;
    private readonly IProductCache _productCache;

    public ProductRepository(ProductDbContext dbContext, IProductCache productCache)
    {
        _dbContext = dbContext;
        _productCache = productCache;
    }
    
    public async Task<Product> GetProductById(int id, CancellationToken cancellationToken = default)
    {
        if (_productCache.TryGetValue(id, out var product))
            return product;
        
        var dbProduct = await _dbContext.Products
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        return dbProduct;
    }

    public async Task<Product[]> GetProducts(CancellationToken cancellationToken = default)
    {
        if (_productCache.Count() != 0)
            return _productCache.GetAll();
        
        var products = await _dbContext.Products
            .AsNoTracking()
            .ToArrayAsync(cancellationToken);

        foreach (var product in products)
            _productCache.AddOrUpdate(product.Id, product);

        return products;
    }

    public async Task Delete(int id, CancellationToken cancellationToken = default)
    {
        _dbContext.Products.Remove(new Product{Id = id});
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        _productCache.Remove(id);
    }

    public async Task AddOrUpdate(Product product, CancellationToken cancellationToken = default)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        _productCache.AddOrUpdate(product.Id, product);
    }
}