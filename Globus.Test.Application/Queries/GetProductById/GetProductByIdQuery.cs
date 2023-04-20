using Globus.Test.Application.DTOs;
using MediatR;

namespace Globus.Test.Application.Queries.GetProductById;

public record GetProductByIdQuery : IRequest<ProductDTO>
{
    public int Id { get; init; }
}