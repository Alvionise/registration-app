using System.Transactions;
using DomainService.Dal.Abstractions;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DomainService.Dal;

/// <summary>
/// Implementation for UnitOfWork for example
/// </summary>
public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
{
    private readonly TContext _dbContext;
    private readonly ILogger _logger = Log.ForContext<UnitOfWork<TContext>>();

    public UnitOfWork(TContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }, TransactionScopeAsyncFlowOption.Enabled);

            // do some actions, send events etc.

            await _dbContext.SaveChangesAsync(cancellationToken);

            scope.Complete();
        }
        catch (Exception e)
        {
            _logger.Error(e, $"Save changes error");
            throw;
        }
    }
}
