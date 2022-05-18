using System;
using System.Threading.Tasks;
using DoctorAsh.Blazor.Pages.Patients.Patient.ViewModels;
using DoctorAsh.Patients;
using DoctorAsh.Patients.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAsh.Blazor.Pages.Patients.Patient
{
    public class EditModalModel : DoctorAshPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditPatientViewModel ViewModel { get; set; }

        private readonly IPatientAppService _service;

        public EditModalModel(IPatientAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<PatientDto, CreateEditPatientViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditPatientViewModel, CreateUpdatePatientDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}