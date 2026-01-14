using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace VeraClinic.Data;

/* This is used if database provider does't define
 * IVeraClinicDbSchemaMigrator implementation.
 */
public class NullVeraClinicDbSchemaMigrator : IVeraClinicDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
