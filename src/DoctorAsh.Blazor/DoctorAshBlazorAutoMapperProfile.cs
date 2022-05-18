using DoctorAsh.Appointments.Dtos;
using DoctorAsh.Doctors.Dtos;
using DoctorAsh.Patients.Dtos;
using AutoMapper;
using DoctorAsh.Blazor.Pages.Appointments.Appointment.ViewModels;
using DoctorAsh.Blazor.Pages.Doctors.Doctor.ViewModels;
using DoctorAsh.Blazor.Pages.Patients.Patient.ViewModels;

namespace DoctorAsh.Blazor
{
    public class DoctorAshBlazorAutoMapperProfile : Profile
    {
        public DoctorAshBlazorAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
            CreateMap<AppointmentDto, CreateEditAppointmentViewModel>();
            CreateMap<CreateEditAppointmentViewModel, CreateAppointmentDto>();
            CreateMap<CreateEditAppointmentViewModel, UpdateAppointmentDto>();
            CreateMap<DoctorDto, CreateEditDoctorViewModel>();
            CreateMap<CreateEditDoctorViewModel, CreateUpdateDoctorDto>();
            CreateMap<PatientDto, CreateEditPatientViewModel>();
            CreateMap<CreateEditPatientViewModel, CreateUpdatePatientDto>();
        }
    }
}
