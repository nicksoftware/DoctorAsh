using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoctorAsh.Doctors;
using DoctorAsh.Doctors.Dtos;
using DoctorAsh.Web.Pages.Doctors.Doctor.ViewModels;

namespace DoctorAsh.Web.Pages.Doctors.Doctor
{
    public class EditModalModel : DoctorAshPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditDoctorViewModel ViewModel { get; set; }

        private readonly IDoctorAppService _service;

        public EditModalModel(IDoctorAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<DoctorDto, CreateEditDoctorViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditDoctorViewModel, CreateUpdateDoctorDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}