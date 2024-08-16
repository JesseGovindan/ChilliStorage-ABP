using Volo.Abp.Modularity;

namespace ChilliStorage;

public abstract class ChilliStorageApplicationTestBase<TStartupModule> : ChilliStorageTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
