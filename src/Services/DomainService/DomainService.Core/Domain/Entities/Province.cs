namespace DomainService.Core.Domain.Entities;

/// <summary>
/// User province
/// </summary>
public class Province : BaseEntity
{
    [Obsolete("For ORM only", true)]
    protected Province()
    {
    }

    /// <summary>
    /// ctor for <see cref="Province"/>
    /// </summary>
    /// <param name="name">Province name</param>
    public Province(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Province name
    /// </summary>
    public string Name { get; init; } = null!;

    /// <summary>
    /// Id country for seeding
    /// </summary>
    public Guid CountryId { get; init; }

    /// <summary>
    /// Province country
    /// </summary>
    public Country Country { get; init; } = null!;
}
