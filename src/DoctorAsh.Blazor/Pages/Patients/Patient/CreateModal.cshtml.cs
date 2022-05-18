using System.Threading.Tasks;
using DoctorAsh.Blazor.Pages.Patients.Patient.ViewModels;
using DoctorAsh.Patients;
using DoctorAsh.Patients.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAsh.Blazor.Pages.Patients.Patient
{
    public class CreateModalModel : DoctorAshPageModel
    {
        [BindProperty]
        public CreateEditPatientViewModel ViewModel { get; set; }

        private readonly IPatientAppService _service;

        public CreateModalModel(IPatientAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditPatientViewModel, CreateUpdatePatientDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}