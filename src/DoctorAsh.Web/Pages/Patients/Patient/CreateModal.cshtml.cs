using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoctorAsh.Patients;
using DoctorAsh.Patients.Dtos;
using DoctorAsh.Web.Pages.Patients.Patient.ViewModels;

namespace DoctorAsh.Web.Pages.Patients.Patient
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