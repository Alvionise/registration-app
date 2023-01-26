using DomainService.WebApi.Commands.User.Request;
using FluentValidation;

namespace DomainService.WebApi.Commands.User;
internal class UpdateUserProvinceValidator : AbstractValidator<UpdateUserProvinceRequest>
{
    public UpdateUserProvinceValidator()
    {
        RuleFor(x => x.ProvinceId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.UserId)
            .NotNull()
            .NotEmpty();
    }
}
