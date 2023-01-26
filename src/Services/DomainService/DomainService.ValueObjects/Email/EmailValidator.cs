using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace DomainService.ValueObjects.Email;

/// <summary>
/// Validator for <see cref="Email"/>
/// </summary>
public class EmailValidator : AbstractValidator<Email>
{
    /// <summary>
    /// ctor <see cref="EmailValidator"/>
    /// </summary>
    public EmailValidator()
    {
        RuleFor(x => x.Value)
            .NotEmpty()
            .WithName(nameof(Email));

        RuleFor(x => x.Value)
            .Must(x => new EmailAddressAttribute().IsValid(x))
            .When(x => !string.IsNullOrWhiteSpace(x.Value))
            .WithMessage("Incorrect Email value");
    }
}
