using Localization.Resources.AbpUi;
using hosamhemaily.Localization;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace hosamhemaily;

[DependsOn(
    typeof(hosamhemailyApplicationContractsModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    //typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule)
    )]
public class hosamhemailyHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    //public override void PreConfigureServices(ServiceConfigurationContext context)
    //{
    //    var configuration = context.Services.GetConfiguration();

    //    context.Services.AddAuthentication("Bearer")
    //        .AddJwtBearer("Bearer", options =>
    //        {
    //            options.Authority = configuration["AuthServer:Authority"];
    //            options.RequireHttpsMetadata = false; // For development only
    //            options.TokenValidationParameters = new TokenValidationParameters
    //            {
    //                ValidateAudience = false
    //            };
    //        });
    //}

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<hosamhemailyResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
