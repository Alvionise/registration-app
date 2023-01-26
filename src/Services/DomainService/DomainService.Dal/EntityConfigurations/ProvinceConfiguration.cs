using DomainService.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainService.Dal.EntityConfigurations;
public class ProvinceConfiguration : BaseEntityConfiguration<Province, Guid>
{
    public override void Configure(EntityTypeBuilder<Province> builder)
    {
        builder.HasOne(x => x.Country)
            .WithMany(x => x.Provinces);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(256);

        builder.ToTable(nameof(Province));

        base.Configure(builder);
    }
}
