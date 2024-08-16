using Volo.Abp.Modularity;

namespace ChilliStorage;

/* Inherit from this class for your domain layer tests. */
public abstract class ChilliStorageDomainTestBase<TStartupModule> : ChilliStorageTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
