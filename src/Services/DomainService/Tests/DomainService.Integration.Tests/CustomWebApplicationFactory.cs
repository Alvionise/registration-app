using System.Data.Common;
using DomainService.Dal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DomainService.Integration.Tests;
public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<AppDbContext>));

            var dbConnectionDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbConnection));

            if (dbContextDescriptor != null && dbConnectionDescriptor != null)
            {
                services.Remove(dbContextDescriptor);
                services.Remove(dbConnectionDescriptor);
            }

            services.AddDbContext<AppDbContext>((x, o) =>
            {
                o.UseInMemoryDatabase(databaseName: "InMemoryDb");
            });
        });

        builder.UseEnvironment("Development");
    }
}
