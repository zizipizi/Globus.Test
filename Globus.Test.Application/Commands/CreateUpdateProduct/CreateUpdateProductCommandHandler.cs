using Globus.Test.Domain.Interfaces;
using Globus.Test.Domain.Models;
using MediatR;

namespace Globus.Test.Application.Commands.CreateUpdateProduct;

public class CreateUpdateProductCommandHandler : IRequestHandler<CreateUpdateProductCommand>
{
    private readonly IProductRepository _productRepository;

    public CreateUpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(CreateUpdateProductCommand request, CancellationToken cancellationToken)
    {
        await _productRepository.AddOrUpdate(new Product
        {
            Id = request.Id,
            Name = request.Name,
            Number = request.Number
        }, cancellationToken);
    }
}