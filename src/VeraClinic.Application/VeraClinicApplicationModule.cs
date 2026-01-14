using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.TenantManagement;

namespace VeraClinic;

[DependsOn(
    typeof(VeraClinicDomainModule),
    typeof(VeraClinicApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class VeraClinicApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // Mapperly sınıfımızı Singleton olarak kaydediyoruz
        // Bu sayede AppService içinde constructor üzerinden çağırabileceğiz
        context.Services.AddSingleton<VeraClinicApplicationMappers>();
    }
}