using System.Linq.Expressions;
using DomainService.Core.Domain.Contracts;
using DomainService.Dal.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DomainService.Dal.Repositories.Base;

/// <summary>
/// Base implementation for read and write repo
/// </summary>
/// <typeparam name="TEntity">Entity</typeparam>
/// <typeparam name="TContext">DbContext</typeparam>
/// <typeparam name="TKey">Primary key</typeparam>
public abstract class BaseCommandRepository<TEntity, TContext, TKey> : BaseQueryRepository<TEntity, TContext, TKey>, ICommandRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>, IAggregateRoot
    where TContext : DbContext
{
    protected BaseCommandRepository(TContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<TEntity> Query => DbSet;

    public override async Task<TEntity?> FirtOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => await Query.FirstOrDefaultAsync(predicate, cancellationToken);

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.CreatedOn = DateTime.UtcNow; // TODO need to replace for IDateTimeProvider
        entity.UpdatedOn = DateTime.UtcNow;

        var entry = await DbSet.AddAsync(entity, cancellationToken);
        return entry.Entity;
    }

    public virtual TEntity UpdateAsync(TEntity entity)
    {
        entity.UpdatedOn = DateTime.UtcNow; // TODO need to replace for IDateTimeProvider

        var entry = DbSet.Update(entity);
        return entry.Entity;
    }
}
