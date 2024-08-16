using Volo.Abp.Modularity;

namespace ChilliStorage;

[DependsOn(
    typeof(ChilliStorageDomainModule),
    typeof(ChilliStorageTestBaseModule)
)]
public class ChilliStorageDomainTestModule : AbpModule
{

}
