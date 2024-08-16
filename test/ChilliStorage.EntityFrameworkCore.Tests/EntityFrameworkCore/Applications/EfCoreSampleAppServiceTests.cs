using ChilliStorage.Samples;
using Xunit;

namespace ChilliStorage.EntityFrameworkCore.Applications;

[Collection(ChilliStorageTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ChilliStorageEntityFrameworkCoreTestModule>
{

}
