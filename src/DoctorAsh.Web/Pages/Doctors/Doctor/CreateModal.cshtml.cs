using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoctorAsh.Doctors;
using DoctorAsh.Doctors.Dtos;
using DoctorAsh.Web.Pages.Doctors.Doctor.ViewModels;

namespace DoctorAsh.Web.Pages.Doctors.Doctor
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