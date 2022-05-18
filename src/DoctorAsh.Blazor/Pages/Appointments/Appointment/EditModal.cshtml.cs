using System;
using System.Threading.Tasks;
using DoctorAsh.Appointments;
using DoctorAsh.Appointments.Dtos;
using DoctorAsh.Blazor.Pages.Appointments.Appointment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAsh.Blazor.Pages.Appointments.Appointment
{
    public class EditModalModel : DoctorAshPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditAppointmentViewModel ViewModel { get; set; }

        private readonly IAppointmentAppService _service;

        public EditModalModel(IAppointmentAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<AppointmentDto, CreateEditAppointmentViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditAppointmentViewModel, UpdateAppointmentDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}