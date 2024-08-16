using ChilliStorage.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ChilliStorage.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ChilliStorageController : AbpControllerBase
{
    protected ChilliStorageController()
    {
        LocalizationResource = typeof(ChilliStorageResource);
    }
}
