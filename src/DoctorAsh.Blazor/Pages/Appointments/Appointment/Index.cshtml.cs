using System.Threading.Tasks;

namespace DoctorAsh.Blazor.Pages.Appointments.Appointment
{
    public class IndexModel : DoctorAshPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
