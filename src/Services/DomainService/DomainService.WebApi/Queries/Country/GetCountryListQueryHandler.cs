using AutoMapper;
using DomainService.Dal.Abstractions;
using DomainService.WebApi.Queries.Country.Requests;
using DomainService.WebApi.Queries.Country.Responses;
using MediatR;

namespace DomainService.WebApi.Queries.Country;
internal class GetCountryListQueryHandler : IRequestHandler<GetCountryQueryRequest, IEnumerable<CountryQueryResponse>>
{
    private readonly IQueryRepository<Core.Domain.Entities.Country, Guid> _queryRepository;
    private readonly IMapper _mapper;

    public GetCountryListQueryHandler(IQueryRepository<Core.Domain.Entities.Country, Guid> queryRepository, IMapper mapper)
    {
        _queryRepository = queryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CountryQueryResponse>> Handle(GetCountryQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _queryRepository.FindAsync(x => x.Provinces.Any(), cancellationToken);
        return _mapper.Map<IEnumerable<CountryQueryResponse>>(result);
    }
}
