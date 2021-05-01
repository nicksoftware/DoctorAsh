using System;
using System.Collections.Generic;
using System.Text;
using DoctorAsh.Localization;
using Volo.Abp.Application.Services;

namespace DoctorAsh
{
    /* Inherit your application services from this class.
     */
    public abstract class DoctorAshAppService : ApplicationService
    {
        protected DoctorAshAppService()
        {
            LocalizationResource = typeof(DoctorAshResource);
        }
    }
}
