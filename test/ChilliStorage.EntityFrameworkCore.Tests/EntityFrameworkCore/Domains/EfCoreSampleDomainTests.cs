using ChilliStorage.Samples;
using Xunit;

namespace ChilliStorage.EntityFrameworkCore.Domains;

[Collection(ChilliStorageTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ChilliStorageEntityFrameworkCoreTestModule>
{

}
