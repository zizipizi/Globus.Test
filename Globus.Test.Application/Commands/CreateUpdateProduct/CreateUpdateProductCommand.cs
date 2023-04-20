using MediatR;

namespace Globus.Test.Application.Commands.CreateUpdateProduct;

public record CreateUpdateProductCommand : IRequest
{
    public int Id { get; init; }
    public int Number { get; init; }
    public string Name { get; init; }
}