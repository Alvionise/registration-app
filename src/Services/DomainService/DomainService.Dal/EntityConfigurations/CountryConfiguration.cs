using DomainService.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainService.Dal.EntityConfigurations;
public class CountryConfiguration : BaseEntityConfiguration<Country, Guid>
{
    public override void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasMany(x => x.Provinces)
            .WithOne(x => x.Country);

        builder.Property(x => x.Name)
            .HasMaxLength(256)
            .IsRequired();

        builder.ToTable(nameof(Country));

        base.Configure(builder);
    }
}
