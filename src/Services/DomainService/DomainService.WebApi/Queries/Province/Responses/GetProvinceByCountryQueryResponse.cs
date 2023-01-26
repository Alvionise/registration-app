namespace DomainService.WebApi.Queries.Province.Responses;
public record GetProvinceByCountryQueryResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
}
