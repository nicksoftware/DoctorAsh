using DoctorAsh.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace DoctorAsh.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class DoctorAshPageModel : AbpPageModel
    {
        protected DoctorAshPageModel()
        {
            LocalizationResourceType = typeof(DoctorAshResource);
        }
    }
}