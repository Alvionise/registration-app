namespace DomainService.WebApi.Queries.Country.Responses;
public record CountryQueryResponse
{
    /// <summary>
    /// Identifier
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Country name
    /// </summary>
    public string Name { get; init; } = null!;
}
