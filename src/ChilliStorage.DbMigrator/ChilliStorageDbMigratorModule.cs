using ChilliStorage.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ChilliStorage.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ChilliStorageEntityFrameworkCoreModule),
    typeof(ChilliStorageApplicationContractsModule)
)]
public class ChilliStorageDbMigratorModule : AbpModule
{
}
