using DomainService.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainService.Dal.EntityConfigurations;

/// <summary>
/// EF config for User entity
/// </summary>
public class UserConfiguration : BaseEntityConfiguration<User, Guid>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(x => x.IsAgreeWorkForFood)
            .IsRequired();

        builder.OwnsOne(x => x.Email, n =>
        {
            n.Property(_ => _.Value).HasMaxLength(256).IsRequired();
        })
            .Navigation(x => x.Email)
            .IsRequired();

        builder.OwnsOne(x => x.Password, n =>
            {
                n.Property(_ => _.Value).HasMaxLength(256).IsRequired();
            })
            .Navigation(x => x.Password)
            .IsRequired();

        builder.HasOne(x => x.Province);
        builder.Navigation(x => x.Province).IsRequired(false);

        builder.ToTable(nameof(User));

        base.Configure(builder);
    }
}
