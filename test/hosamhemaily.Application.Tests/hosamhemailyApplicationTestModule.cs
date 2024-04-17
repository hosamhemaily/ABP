using Volo.Abp.Modularity;

namespace hosamhemaily;

[DependsOn(
    typeof(hosamhemailyApplicationModule),
    typeof(hosamhemailyDomainTestModule)
)]
public class hosamhemailyApplicationTestModule : AbpModule
{

}
