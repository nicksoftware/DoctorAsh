using DoctorAsh.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DoctorAsh.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class DoctorAshController : AbpController
    {
        protected DoctorAshController()
        {
            LocalizationResource = typeof(DoctorAshResource);
        }
    }
}