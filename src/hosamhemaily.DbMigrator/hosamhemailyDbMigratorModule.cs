using hosamhemaily.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace hosamhemaily.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(hosamhemailyEntityFrameworkCoreModule),
    typeof(hosamhemailyApplicationContractsModule)
    )]
public class hosamhemailyDbMigratorModule : AbpModule
{
}
