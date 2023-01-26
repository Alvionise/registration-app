namespace DomainService.Core.Domain.Contracts;

/// <summary> Interface exposes base contract for Entity in solution.
/// </summary>
/// <typeparam name="TPrimaryKey">Type of the primary key.</typeparam>
public interface IEntity<out TPrimaryKey> : IAuditable
{
    /// <summary>
    /// Entity identifier.
    /// </summary>
    TPrimaryKey Id { get; }
}
