using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Account;
using Volo.Abp.Auditing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
//using Volo.Abp;
//using Volo.Abp.AspNetCore.Authentication.JwtBearer;

namespace hosamhemaily;

[DependsOn(
    typeof(hosamhemailyDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(hosamhemailyApplicationContractsModule),
    //typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    //,
    //typeof(AbpAspNetCoreAuthenticationJwtBearerModule)
    )]
public class hosamhemailyApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<hosamhemailyApplicationModule>();
        });
        //var configuration = context.Services.GetConfiguration();
        //context.Services.AddAuthentication("Bearer")
        //    .AddJwtBearer("Bearer", options =>
        //    {
        //        options.Authority = configuration["AuthServer:Authority"];
        //        options.RequireHttpsMetadata = false; // For development only
        //        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        //        {
        //            ValidateAudience = false
        //        };
        //    });

        //Configure<AbpAuditingOptions>(options =>
        //{
        //    options.IsEnabled = true; //Disables the auditing system
        //});x`

        // context.Services.AddScoped<IRepository<TodoItem, Guid>, RepositoryBase<TodoItem, Guid>>();


    }
}
