using System.ComponentModel.DataAnnotations;
using DomainService.WebApi.Commands.User.Request;
using FluentValidation;

namespace DomainService.WebApi.Commands.User;
internal class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.IsAgreeWorkForFood)
            .Must(x => x.Equals(true))
            .WithMessage("You must agree to the condition of working for food");

        RuleFor(x => x)
            .Must(IsValidPassword)
            .WithMessage("Password and confirmation must be equal");

        RuleFor(x => x.Password.Value)
            .NotEmpty()
            .WithName(nameof(CreateUserRequest.Password));

        RuleFor(x => x.Password.Value)
            .Matches("[0-9]").WithMessage($"'{nameof(CreateUserRequest.Password)}' must contain minimum one digit.")
            .Matches("[a-zA-Z]").WithMessage($"'{nameof(CreateUserRequest.Password)}' must contain minimum one letter.");

        RuleFor(x => x.Login.Value)
            .NotEmpty()
            .WithName(nameof(CreateUserRequest.Login));

        RuleFor(x => x.Login.Value)
            .Must(x => new EmailAddressAttribute().IsValid(x))
            .When(x => !string.IsNullOrWhiteSpace(x.Login.Value))
            .WithMessage("Incorrect Email value");
    }

    private bool IsValidPassword(CreateUserRequest request)
        => request.Password.Value.Equals(request.ConfirmPassword.Value);
}
