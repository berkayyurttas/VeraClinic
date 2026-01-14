using Volo.Abp.Modularity;

namespace VeraClinic;

/* Inherit from this class for your domain layer tests. */
public abstract class VeraClinicDomainTestBase<TStartupModule> : VeraClinicTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
