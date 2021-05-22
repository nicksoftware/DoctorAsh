using System.Threading.Tasks;

namespace DoctorAsh.Web.Pages.Patients.Patient
{
    public class IndexModel : DoctorAshPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
