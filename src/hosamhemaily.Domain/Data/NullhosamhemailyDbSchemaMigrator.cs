using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace hosamhemaily.Data;

/* This is used if database provider does't define
 * IhosamhemailyDbSchemaMigrator implementation.
 */
public class NullhosamhemailyDbSchemaMigrator : IhosamhemailyDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
