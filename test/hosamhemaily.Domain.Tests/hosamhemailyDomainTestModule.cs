using Volo.Abp.Modularity;

namespace hosamhemaily;

[DependsOn(
    typeof(hosamhemailyDomainModule),
    typeof(hosamhemailyTestBaseModule)
)]
public class hosamhemailyDomainTestModule : AbpModule
{

}
