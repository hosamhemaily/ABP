using hosamhemaily.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace hosamhemaily.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class hosamhemailyController : AbpControllerBase
{
    protected hosamhemailyController()
    {
        LocalizationResource = typeof(hosamhemailyResource);
    }
}
