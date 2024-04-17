using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using hosamhemaily.Data;
using Volo.Abp.DependencyInjection;

namespace hosamhemaily.EntityFrameworkCore;

public class EntityFrameworkCorehosamhemailyDbSchemaMigrator
    : IhosamhemailyDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCorehosamhemailyDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the hosamhemailyDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<hosamhemailyDbContext>()
            .Database
            .MigrateAsync();
    }
}
