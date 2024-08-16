using ChilliStorage.Localization;
using Volo.Abp.Application.Services;

namespace ChilliStorage;

/* Inherit your application services from this class.
 */
public abstract class ChilliStorageAppService : ApplicationService
{
    protected ChilliStorageAppService()
    {
        LocalizationResource = typeof(ChilliStorageResource);
    }
}
