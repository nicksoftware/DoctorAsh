using System.Threading.Tasks;
using DoctorAsh.Blazor.Pages.Doctors.Doctor.ViewModels;
using DoctorAsh.Doctors;
using DoctorAsh.Doctors.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAsh.Blazor.Pages.Doctors.Doctor
{
    public class CreateModalModel : DoctorAshPageModel
    {
        [BindProperty]
        public CreateEditDoctorViewModel ViewModel { get; set; }

        private readonly IDoctorAppService _service;

        public CreateModalModel(IDoctorAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditDoctorViewModel, CreateUpdateDoctorDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}