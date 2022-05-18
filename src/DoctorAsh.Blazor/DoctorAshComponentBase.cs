using DoctorAsh.Localization;
using Volo.Abp.AspNetCore.Components;

namespace DoctorAsh.Blazor;

public abstract class DoctorAshComponentBase : AbpComponentBase
{
    protected DoctorAshComponentBase()
    {
        LocalizationResource = typeof(DoctorAshResource);
    }
}
