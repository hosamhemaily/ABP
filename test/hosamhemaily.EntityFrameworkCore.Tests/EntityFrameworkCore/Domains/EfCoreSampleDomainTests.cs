using hosamhemaily.Samples;
using Xunit;

namespace hosamhemaily.EntityFrameworkCore.Domains;

[Collection(hosamhemailyTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<hosamhemailyEntityFrameworkCoreTestModule>
{

}
