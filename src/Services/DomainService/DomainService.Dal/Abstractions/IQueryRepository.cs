using System.Linq.Expressions;
using DomainService.Core.Domain.Contracts;

namespace DomainService.Dal.Abstractions;

/// <summary>
/// Query repository contract
/// </summary>
/// <typeparam name="TEntity">Entity</typeparam>
/// <typeparam name="TKey">Entity primary key</typeparam>
public interface IQueryRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
{
    Task<TEntity?> FirtOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}
