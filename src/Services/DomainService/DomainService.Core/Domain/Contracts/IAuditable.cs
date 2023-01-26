namespace DomainService.Core.Domain.Contracts;

/// <summary>
/// Interface exposes contract for Entity which support audit of changes - date of create and last change.
/// </summary>
public interface IAuditable
{
    /// <summary>
    /// Entity creation date.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Entity update date.
    /// </summary>
    public DateTime UpdatedOn { get; set; }
}
