using DomainService.WebApi.Mapping;

namespace DomainService.WebApi.Extensions;
internal static class AutomapperExtension
{
    public static IServiceCollection RegisterAutomapperProfiles(this IServiceCollection services)
    {
        Type[] profilesCollection =
        {
            typeof(CountryMap),
            typeof(UserMap),
            typeof(ProvinceMap),
        };

        services.AddAutoMapper(profilesCollection);

        return services;
    }
}
