using DomainService.WebApi.Queries.Province.Requests;
using FluentValidation;

namespace DomainService.WebApi.Queries.Province;
internal class GetProvinceByCountryValidator : AbstractValidator<GetProvinceByContryQueryRequest>
{
    public GetProvinceByCountryValidator()
    {
        RuleFor(x => x.CountryId)
            .NotEmpty()
            .NotNull();
    }
}
