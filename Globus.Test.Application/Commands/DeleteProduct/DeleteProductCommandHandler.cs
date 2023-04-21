using Globus.Test.Domain.Interfaces;
using MediatR;

namespace Globus.Test.Application.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductById(request.Id, cancellationToken);
        if (product is null)
            return int.MinValue;
            
        await _productRepository.Delete(request.Id, cancellationToken);
        return request.Id;
    }
}