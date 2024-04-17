using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace hosamhemaily;

[Dependency(ReplaceServices = true)]
public class hosamhemailyBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "hosamhemaily";
}
