using DomainService.Core.Domain.Contracts;
using DomainService.Dal.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DomainService.Dal.Repositories;

/// <summary>
/// Default query repository with base actions and read uncommited
/// </summary>
/// <typeparam name="TEntity">Entity</typeparam>
/// <typeparam name="TContext">DbContext</typeparam>
/// <typeparam name="TKey">Primary key</typeparam>
public class DefaultQueryRepository<TEntity, TContext, TKey> : BaseQueryRepository<TEntity, TContext, TKey>
    where TEntity : class, IEntity<TKey>
    where TContext : DbContext
{
    public DefaultQueryRepository(TContext dbContext) : base(dbContext)
    {
    }
}
