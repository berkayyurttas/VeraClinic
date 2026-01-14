using System.Threading.Tasks;

namespace VeraClinic.Data;

public interface IVeraClinicDbSchemaMigrator
{
    Task MigrateAsync();
}
