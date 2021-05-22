using DoctorAsh.Localization;
using Volo.Abp.Application.Services;

namespace DoctorAsh
{

    public abstract class DoctorAshAppService : ApplicationService
    {
        protected DoctorAshAppService()
        {
            LocalizationResource = typeof(DoctorAshResource);
        }
    }
}
