using System.Threading.Tasks;

namespace DoctorAsh.Web.Pages.Doctors.Doctor
{
    public class IndexModel : DoctorAshPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
