using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoctorAsh.Appointments;
using DoctorAsh.Appointments.Dtos;
using DoctorAsh.Web.Pages.Appointments.Appointment.ViewModels;

namespace DoctorAsh.Web.Pages.Appointments.Appointment
{
    public class CreateModalModel : DoctorAshPageModel
    {
        [BindProperty]
        public CreateEditAppointmentViewModel ViewModel { get; set; }

        private readonly IAppointmentAppService _service;

        public CreateModalModel(IAppointmentAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditAppointmentViewModel, CreateAppointmentDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}