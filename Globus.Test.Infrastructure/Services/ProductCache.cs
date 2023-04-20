using System.Collections.Concurrent;
using Globus.Test.Domain.Models;

namespace Globus.Test.Infrastructure.Services;

internal class ProductCache : IProductCache
{
    private readonly ConcurrentDictionary<int, Product> _products;

    public ProductCache()
    {
        _products = new ConcurrentDictionary<int, Product>();
    }

    public bool TryGetValue(int id, out Product product) => _products.TryGetValue(id, out product);

    public Product[] GetAll() => _products.Values.ToArray();

    public void Remove(int id) => _products.Remove(id, out _);

    public void AddOrUpdate(int id, Product product) => _products.AddOrUpdate(id, product, (_, existingProduct) =>
    {
        existingProduct.Name = product.Name;
        existingProduct.Number = product.Number;

        return existingProduct;
    });

    public int Count() => _products.Count;
}