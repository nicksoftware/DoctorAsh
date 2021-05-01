using System.Threading.Tasks;

namespace DoctorAsh.Web.Pages.Appointments.Appointment
{
    public class IndexModel : DoctorAshPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
