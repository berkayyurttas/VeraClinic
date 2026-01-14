using Volo.Abp.Settings;

namespace VeraClinic.Settings;

public class VeraClinicSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(VeraClinicSettings.MySetting1));
    }
}
