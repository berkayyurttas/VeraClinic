using VeraClinic.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace VeraClinic.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(VeraClinicEntityFrameworkCoreModule),
    typeof(VeraClinicApplicationContractsModule)
)]
public class VeraClinicDbMigratorModule : AbpModule
{
}
