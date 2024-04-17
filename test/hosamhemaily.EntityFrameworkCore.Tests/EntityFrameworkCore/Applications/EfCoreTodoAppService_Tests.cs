using hosamhemaily.Samples;
using hosamhemaily.TodoItems;
using Xunit;

namespace hosamhemaily.EntityFrameworkCore.Applications;

[Collection(hosamhemailyTestConsts.CollectionDefinitionName)]
public class EfCoreTodoAppService_Tests : TodoAppService_Tests<hosamhemailyEntityFrameworkCoreTestModule>
{

}
