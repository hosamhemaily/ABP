using hosamhemaily.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace hosamhemaily.Permissions;

public class hosamhemailyPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(hosamhemailyPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(hosamhemailyPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<hosamhemailyResource>(name);
    }
}
