using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace DoctorAsh.Web
{
    [Dependency(ReplaceServices = true)]
    public class DoctorAshBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "DoctorAsh";
    }
}
