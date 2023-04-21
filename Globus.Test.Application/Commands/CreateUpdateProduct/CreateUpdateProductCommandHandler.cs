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
        var product = await _productRepository.GetProductById(request.Id, cancellationToken);

        if (product is null)
        {
            await _productRepository.Create(new Product
            {
                Name = request.Name,
                Number = request.Number
            }, cancellationToken);
        }
        else
        {
            await _productRepository.Update(new Product
            {
                Id = request.Id,
                Name = request.Name,
                Number = request.Number
            });
        }
    }
}