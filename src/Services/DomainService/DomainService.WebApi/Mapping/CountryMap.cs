using AutoMapper;
using DomainService.Core.Domain.Entities;
using DomainService.WebApi.Queries.Country.Responses;

namespace DomainService.WebApi.Mapping;
internal class CountryMap : Profile
{
    public CountryMap()
    {
        CreateMap<Country, CountryQueryResponse>()
            .ForMember(x => x.Name,
                y => y.MapFrom(e => e.Name))
            .ForMember(x => x.Id,
                y => y.MapFrom(e => e.Id));
    }
}
