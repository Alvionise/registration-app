using DomainService.Core.Domain.Contracts;
using DomainService.Dal.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DomainService.Dal.Repositories;
public class DefaultQueryRepository<TEntity, TContext, TKey> : BaseQueryRepository<TEntity, TContext, TKey>
    where TEntity : class, IEntity<TKey>
    where TContext : DbContext
{
    public DefaultQueryRepository(TContext dbContext) : base(dbContext)
    {
    }
}
