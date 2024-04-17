using System;
using System.Collections.Generic;
using System.Text;
using hosamhemaily.Localization;
using Volo.Abp.Application.Services;

namespace hosamhemaily;

/* Inherit your application services from this class.
 */
public abstract class hosamhemailyAppService : ApplicationService
{
    protected hosamhemailyAppService()
    {
        LocalizationResource = typeof(hosamhemailyResource);
    }
}
