using DomainService.WebApi.Queries.Province.Responses;
using MediatR;

namespace DomainService.WebApi.Queries.Province.Requests;

public sealed record GetProvinceByContryQueryRequest : IRequest<IEnumerable<GetProvinceByCountryQueryResponse>>
{
    public Guid CountryId { get; init; }
}
