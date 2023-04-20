using Globus.Test.Domain.Models;

namespace Globus.Test.Infrastructure.Services;

internal interface IProductCache
{
    bool TryGetValue(int id, out Product product);
    Product[] GetAll();
    void Remove(int id);
    void AddOrUpdate(int id, Product product);
    int Count();
}