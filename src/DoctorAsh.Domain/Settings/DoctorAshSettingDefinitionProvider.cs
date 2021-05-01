using Volo.Abp.Settings;

namespace DoctorAsh.Settings
{
    public class DoctorAshSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(DoctorAshSettings.MySetting1));
        }
    }
}
