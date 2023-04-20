using Globus.Test.Application.DTOs;
using Globus.Test.Domain.Interfaces;
using MediatR;

namespace Globus.Test.Application.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ProductDTO[]>
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDTO[]> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetProducts(cancellationToken);
        return products.Select(p => new ProductDTO
        {
            Id = p.Id,
            Number = p.Number,
            Name = p.Name
        }).ToArray();
    }
}