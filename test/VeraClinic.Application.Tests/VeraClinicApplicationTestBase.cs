using Volo.Abp.Modularity;

namespace VeraClinic;

public abstract class VeraClinicApplicationTestBase<TStartupModule> : VeraClinicTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
