using Globus.Test.Application.DTOs;
using MediatR;

namespace Globus.Test.Application.Queries.GetProducts;

public record GetProductsQuery : IRequest<ProductDTO[]>
{
}