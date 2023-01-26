using AutoMapper;
using DomainService.Core.Domain.Entities;
using DomainService.WebApi.Queries.Province.Responses;

namespace DomainService.WebApi.Mapping;
internal class ProvinceMap : Profile
{
    public ProvinceMap()
    {
        CreateMap<Province, GetProvinceByCountryQueryResponse>()
            .ForMember(x => x.Id, m => m.MapFrom(y => y.Id))
            .ForMember(x => x.Name, m => m.MapFrom(y => y.Name));
    }
}
