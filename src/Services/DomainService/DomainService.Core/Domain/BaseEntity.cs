using DomainService.Core.Domain.Contracts;

namespace DomainService.Core.Domain;

/// <summary>
/// Base implementation for entities.
/// </summary>
public class BaseEntity : IEntity<Guid>
{
    /// <inheritdoc/>
    public Guid Id { get; set; }
    /// <inheritdoc/>
    public DateTime CreatedOn { get; set; }
    /// <inheritdoc/>
    public DateTime UpdatedOn { get; set; }
}
