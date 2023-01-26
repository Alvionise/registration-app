using Microsoft.EntityFrameworkCore;

namespace DomainService.Dal.Abstractions;

/// <summary>
/// Unit of work contract
/// </summary>
/// <typeparam name="TContext">DbContext</typeparam>
public interface IUnitOfWork<TContext> where TContext : DbContext
{
    /// <summary>
    /// Save changes to DB and do some actions (publish integration events for example)
    /// </summary>
    /// <param name="cancellationToken"><see cref="T:System.Threading.CancellationToken" /></param>
    /// <returns><see cref="T:System.Threading.Tasks.Task" /></returns>
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
