using System.Threading.Tasks;

namespace hosamhemaily.Data;

public interface IhosamhemailyDbSchemaMigrator
{
    Task MigrateAsync();
}
