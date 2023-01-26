using System.Linq.Expressions;
using DomainService.Core.Domain.Contracts;

namespace DomainService.Dal.Abstractions;

/// <summary>
/// Command repository contract
/// </summary>
/// <typeparam name="TEntity">Entity</typeparam>
/// <typeparam name="TKey">Entity primary key</typeparam>
public interface ICommandRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
{
    Task<TEntity?> FirtOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    TEntity UpdateAsync(TEntity entity);
}
