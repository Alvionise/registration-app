using AutoMapper;
using DomainService.Dal.Abstractions;
using DomainService.WebApi.Queries.Province.Requests;
using DomainService.WebApi.Queries.Province.Responses;
using MediatR;

namespace DomainService.WebApi.Queries.Province;
internal class GetProvincesByCountryHandler : IRequestHandler<GetProvinceByContryQueryRequest, IEnumerable<GetProvinceByCountryQueryResponse>>
{
    private readonly IQueryRepository<Core.Domain.Entities.Province, Guid> _queryRepository;
    private readonly IMapper _mapper;

    public GetProvincesByCountryHandler(IQueryRepository<Core.Domain.Entities.Province, Guid> queryRepository, IMapper mapper)
    {
        _queryRepository = queryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetProvinceByCountryQueryResponse>> Handle(GetProvinceByContryQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _queryRepository.FindAsync(x => x.CountryId == request.CountryId, cancellationToken);
        return _mapper.Map<IEnumerable<GetProvinceByCountryQueryResponse>>(result);
    }
}
