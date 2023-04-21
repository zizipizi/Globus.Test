using MediatR;

namespace Globus.Test.Application.Commands.DeleteProduct;

public record DeleteProductCommand : IRequest<int>
{
    public int Id { get; init; }
}