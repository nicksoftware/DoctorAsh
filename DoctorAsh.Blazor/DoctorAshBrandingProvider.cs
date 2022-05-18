using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace DoctorAsh.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class DoctorAshBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "DoctorAsh";
    }
}
