using Volo.Abp.Modularity;

namespace hosamhemaily;

public abstract class hosamhemailyApplicationTestBase<TStartupModule> : hosamhemailyTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
