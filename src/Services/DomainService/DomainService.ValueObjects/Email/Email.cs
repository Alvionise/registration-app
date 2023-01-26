namespace DomainService.ValueObjects.Email;

/// <summary>
/// Email value object
/// </summary>
public record Email
{
    /// <summary>
    /// Email address value
    /// </summary>
    public string Value { get; init; }

    /// <summary>
    /// ctor <see cref="Email"/>
    /// </summary>
    /// <param name="value">Value of email</param>
    public Email(string value)
    {
        Value = value;
    }
}
