using Globus.Test.Application.DTOs;
using Globus.Test.Domain.Interfaces;
using MediatR;

namespace Globus.Test.Application.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductById(request.Id, cancellationToken);
        if (product is not null)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Number = product.Number
            };
        }

        return null;
    }
}