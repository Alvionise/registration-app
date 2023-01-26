using Microsoft.EntityFrameworkCore;

namespace DomainService.WebApi.Extensions;
internal static class DatabaseServiceExtension<TContext>
    where TContext : DbContext
{
    public static void PrepareDbAndSeed(IServiceProvider provider)
    {
        using var scope = provider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<TContext>();
        db.Database.Migrate();
    }
}
