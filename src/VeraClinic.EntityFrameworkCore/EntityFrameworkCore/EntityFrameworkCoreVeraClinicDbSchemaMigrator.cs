using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VeraClinic.Data;
using Volo.Abp.DependencyInjection;

namespace VeraClinic.EntityFrameworkCore;

public class EntityFrameworkCoreVeraClinicDbSchemaMigrator
    : IVeraClinicDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreVeraClinicDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the VeraClinicDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<VeraClinicDbContext>()
            .Database
            .MigrateAsync();
    }
}
