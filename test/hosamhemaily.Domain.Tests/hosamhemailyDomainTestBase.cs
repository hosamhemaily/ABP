using Volo.Abp.Modularity;

namespace hosamhemaily;

/* Inherit from this class for your domain layer tests. */
public abstract class hosamhemailyDomainTestBase<TStartupModule> : hosamhemailyTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
