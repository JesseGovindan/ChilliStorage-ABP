using Volo.Abp.Settings;

namespace ChilliStorage.Settings;

public class ChilliStorageSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ChilliStorageSettings.MySetting1));
    }
}
