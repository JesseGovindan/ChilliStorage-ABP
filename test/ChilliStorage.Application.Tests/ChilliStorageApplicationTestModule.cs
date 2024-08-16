using Volo.Abp.Modularity;

namespace ChilliStorage;

[DependsOn(
    typeof(ChilliStorageApplicationModule),
    typeof(ChilliStorageDomainTestModule)
)]
public class ChilliStorageApplicationTestModule : AbpModule
{

}
