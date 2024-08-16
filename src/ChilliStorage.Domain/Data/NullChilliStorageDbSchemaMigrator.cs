using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ChilliStorage.Data;

/* This is used if database provider does't define
 * IChilliStorageDbSchemaMigrator implementation.
 */
public class NullChilliStorageDbSchemaMigrator : IChilliStorageDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
