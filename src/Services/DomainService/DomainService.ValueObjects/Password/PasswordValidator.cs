using FluentValidation;

namespace DomainService.ValueObjects.Password;

/// <summary>
/// Validator for <see cref="Password"/>
/// </summary>
public class PasswordValidator : AbstractValidator<Password>
{
    /// <summary>
    /// ctor <see cref="PasswordValidator"/>
    /// </summary>
    public PasswordValidator()
    {
        RuleFor(x => x.Value)
            .NotEmpty()
            .WithName(nameof(Password));

        RuleFor(x => x.Value)
            .Matches("[0-9]").WithMessage($"'{nameof(Password)}' must contain minimum one digit.")
            .Matches("[a-zA-Z]").WithMessage($"'{nameof(Password)}' must contain minimum one letter.");
    }
}
