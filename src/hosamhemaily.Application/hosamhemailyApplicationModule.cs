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

namespace hosamhemaily;

[DependsOn(
    typeof(hosamhemailyDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(hosamhemailyApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class hosamhemailyApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<hosamhemailyApplicationModule>();
        });

        //Configure<AbpAuditingOptions>(options =>
        //{
        //    options.IsEnabled = true; //Disables the auditing system
        //});

        // context.Services.AddScoped<IRepository<TodoItem, Guid>, RepositoryBase<TodoItem, Guid>>();


    }
}
