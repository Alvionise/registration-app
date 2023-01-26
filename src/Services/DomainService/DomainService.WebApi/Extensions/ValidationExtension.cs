using DomainService.ValueObjects.Email;
using DomainService.ValueObjects.Password;
using DomainService.WebApi.Commands.User;
using DomainService.WebApi.Commands.User.Request;
using DomainService.WebApi.Queries.Province;
using DomainService.WebApi.Queries.Province.Requests;
using FluentValidation;

namespace DomainService.WebApi.Extensions;

/// <summary>
/// Extension for validators registration
/// </summary>
internal static class ValidationExtension
{
    public static IServiceCollection RegisterValidation(this IServiceCollection services)
    {
        services.AddScoped<IValidator<Email>, EmailValidator>();
        services.AddScoped<IValidator<Password>, PasswordValidator>();
        services.AddScoped<IValidator<CreateUserRequest>, CreateUserRequestValidator>();
        services.AddScoped<IValidator<UpdateUserProvinceRequest>, UpdateUserProvinceValidator>();
        services.AddScoped<IValidator<GetProvinceByContryQueryRequest>, GetProvinceByCountryValidator>();

        return services;
    }
}
