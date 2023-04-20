using MediatR;

namespace Globus.Test.Application.Commands.DeleteProduct;

public record DeleteProductCommand : IRequest
{
    public int Id { get; init; }
}