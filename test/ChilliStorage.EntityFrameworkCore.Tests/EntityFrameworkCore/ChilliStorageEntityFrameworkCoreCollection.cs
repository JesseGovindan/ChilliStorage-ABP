using Xunit;

namespace ChilliStorage.EntityFrameworkCore;

[CollectionDefinition(ChilliStorageTestConsts.CollectionDefinitionName)]
public class ChilliStorageEntityFrameworkCoreCollection : ICollectionFixture<ChilliStorageEntityFrameworkCoreFixture>
{

}
