using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ChilliStorage.Data;
using Volo.Abp.DependencyInjection;

namespace ChilliStorage.EntityFrameworkCore;

public class EntityFrameworkCoreChilliStorageDbSchemaMigrator
    : IChilliStorageDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreChilliStorageDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ChilliStorageDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ChilliStorageDbContext>()
            .Database
            .MigrateAsync();
    }
}
