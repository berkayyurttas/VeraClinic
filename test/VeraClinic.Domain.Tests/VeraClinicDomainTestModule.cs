using Volo.Abp.Modularity;

namespace VeraClinic;

[DependsOn(
    typeof(VeraClinicDomainModule),
    typeof(VeraClinicTestBaseModule)
)]
public class VeraClinicDomainTestModule : AbpModule
{

}
