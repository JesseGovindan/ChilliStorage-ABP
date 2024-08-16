using ChilliStorage.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace ChilliStorage.Permissions;

public class ChilliStoragePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ChilliStoragePermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(ChilliStoragePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ChilliStorageResource>(name);
    }
}
