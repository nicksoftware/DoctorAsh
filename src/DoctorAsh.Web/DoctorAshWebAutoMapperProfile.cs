using DoctorAsh.Appointments.Dtos;
using DoctorAsh.Web.Pages.Appointments.Appointment.ViewModels;
using DoctorAsh.Doctors.Dtos;
using DoctorAsh.Web.Pages.Doctors.Doctor.ViewModels;
using DoctorAsh.Patients.Dtos;
using DoctorAsh.Web.Pages.Patients.Patient.ViewModels;
using AutoMapper;

namespace DoctorAsh.Web
{
    public class DoctorAshWebAutoMapperProfile : Profile
    {
        public DoctorAshWebAutoMapperProfile()
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
