using DomainService.WebApi.Queries.Country.Responses;
using MediatR;

namespace DomainService.WebApi.Queries.Country.Requests;
internal sealed record GetCountryQueryRequest : IRequest<IEnumerable<CountryQueryResponse>>
{
}
