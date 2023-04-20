namespace Globus.Test.Application.DTOs;

public record ProductDTO
{
    public int Id { get; init; }
    public int Number { get; init; }
    public string Name { get; init; }
}