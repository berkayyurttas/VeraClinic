using Volo.Abp.Modularity;

namespace VeraClinic;

[DependsOn(
    typeof(VeraClinicApplicationModule),
    typeof(VeraClinicDomainTestModule)
)]
public class VeraClinicApplicationTestModule : AbpModule
{

}
