using DoctorAsh.Appointments.Dtos;
using DoctorAsh.Web.Pages.Appointments.Appointment.ViewModels;
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
        }
    }
}
