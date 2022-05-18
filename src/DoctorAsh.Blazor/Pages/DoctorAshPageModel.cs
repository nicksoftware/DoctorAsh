using DoctorAsh.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace DoctorAsh.Blazor.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class DoctorAshPageModel : AbpPageModel
    {
        protected DoctorAshPageModel()=> LocalizationResourceType = typeof(DoctorAshResource);
    }
}