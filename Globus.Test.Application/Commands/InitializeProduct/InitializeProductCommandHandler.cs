using Globus.Test.Application.DTOs;
using Globus.Test.Domain.Interfaces;
using MediatR;

namespace Globus.Test.Application.Commands.InitializeProduct;

public class InitializeProductCommandHandler : IRequestHandler<InitializeProductCommand>
{
    private readonly IProductRepository _productRepository;

    public InitializeProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(InitializeProductCommand request, CancellationToken cancellationToken)
    {
        await _productRepository.GetProducts(cancellationToken);
    }
}