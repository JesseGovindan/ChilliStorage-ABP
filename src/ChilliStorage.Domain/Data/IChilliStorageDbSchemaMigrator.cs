using System.Threading.Tasks;

namespace ChilliStorage.Data;

public interface IChilliStorageDbSchemaMigrator
{
    Task MigrateAsync();
}
