using DomainService.Core.Domain.Contracts;
using DomainService.ValueObjects.Email;
using DomainService.ValueObjects.Password;

namespace DomainService.Core.Domain.Entities;

/// <summary>
/// User model
/// </summary>
public class User : BaseEntity, IAggregateRoot
{
    [Obsolete("For ORM only", true)]
    protected User()
    {
    }

    /// <summary>
    /// ctor <see cref="User"/> for User creation
    /// </summary>
    /// <param name="email">User email (login)</param>
    /// <param name="password">User password</param>
    /// <param name="isAgreeWorkForFood">Whether the user agrees to work for food</param>
    public User(Email email, Password password, bool isAgreeWorkForFood)
    {
        Email = email;
        Password = password;
        IsAgreeWorkForFood = isAgreeWorkForFood;
    }

    /// <summary>
    /// Set user province.
    /// </summary>
    /// <param name="province"><see cref="Province"/>.</param>
    public void SetProvince(Province? province)
    {
        Province = province;
    }

    /// <summary>
    /// User email (login)
    /// </summary>
    public Email Email { get; init; } = null!;

    /// <summary>
    /// User password
    /// </summary>
    public Password Password { get; init; } = null!;

    /// <summary>
    /// User province
    /// </summary>
    public Province? Province { get; private set; }

    /// <summary>
    /// Whether the user agrees to work for food
    /// </summary>
    public bool IsAgreeWorkForFood { get; init; }
}
