using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ChilliStorage;

[Dependency(ReplaceServices = true)]
public class ChilliStorageBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ChilliStorage";
}
