using Xunit;

namespace hosamhemaily.EntityFrameworkCore;

[CollectionDefinition(hosamhemailyTestConsts.CollectionDefinitionName)]
public class hosamhemailyEntityFrameworkCoreCollection : ICollectionFixture<hosamhemailyEntityFrameworkCoreFixture>
{

}
