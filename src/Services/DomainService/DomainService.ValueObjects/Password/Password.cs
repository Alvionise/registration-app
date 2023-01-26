namespace DomainService.ValueObjects.Password;

/// <summary>
/// User password value object
/// </summary>
public record Password
{
    /// <summary>
    /// Value of password
    /// </summary>
    public string Value { get; init; }

    /// <summary>
    /// ctor <see cref="Password"/>
    /// </summary>
    /// <param name="value">Value of password</param>
    public Password(string value)
    {
        Value = value;
    }
}
