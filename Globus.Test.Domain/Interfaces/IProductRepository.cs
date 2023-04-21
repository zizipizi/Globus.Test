using Globus.Test.Domain.Models;

namespace Globus.Test.Domain.Interfaces;

public interface IProductRepository
{
    Task<Product> GetProductById(int id, CancellationToken cancellationToken = default);
    Task<Product[]> GetProducts(CancellationToken cancellationToken = default);
    
    Task Delete(int id, CancellationToken cancellationToken = default);

    Task Update(Product product);

    Task Create(Product product, CancellationToken cancellationToken = default);
}