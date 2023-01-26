using DomainService.Core.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainService.Dal.EntityConfigurations;

/// <summary>
/// EF configuration for base entities
/// </summary>
/// <typeparam name="TEntity">Base entity</typeparam>
/// <typeparam name="TKey">Primary key</typeparam>
public abstract class BaseEntityConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
    where TEntity : class, IEntity<TKey>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);

        if (typeof(TEntity).IsAssignableTo(typeof(IAuditable)))
        {
            builder.Property(nameof(IAuditable.CreatedOn))
                .IsRequired();

            builder.Property(nameof(IAuditable.UpdatedOn))
                .IsRequired();
        }
    }
}
