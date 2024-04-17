using hosamhemaily.Samples;
using Xunit;

namespace hosamhemaily.EntityFrameworkCore.Applications;

[Collection(hosamhemailyTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<hosamhemailyEntityFrameworkCoreTestModule>
{

}
