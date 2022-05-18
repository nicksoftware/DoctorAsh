using System.Threading.Tasks;

namespace DoctorAsh.Blazor.Pages.Patients.Patient
{
    public class IndexModel : DoctorAshPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
