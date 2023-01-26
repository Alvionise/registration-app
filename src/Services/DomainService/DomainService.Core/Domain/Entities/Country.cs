namespace DomainService.Core.Domain.Entities;

/// <summary>
/// Country
/// </summary>
public class Country : BaseEntity
{
    [Obsolete("For ORM only", true)]
    protected Country()
    {
    }

    /// <summary>
    /// ctor <see cref="Country"/>
    /// </summary>
    /// <param name="name">Country name</param>
    /// <param name="provinces">Country provinces</param>
    public Country(string name, IEnumerable<Province> provinces)
    {
        Name = name;
        Provinces = provinces;
    }

    /// <summary>
    /// Country name
    /// </summary>
    public string Name { get; init; } = null!;

    /// <summary>
    /// Country provinces
    /// </summary>
    public IEnumerable<Province> Provinces { get; init; } = null!;
}
