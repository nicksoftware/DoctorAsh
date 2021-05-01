using DoctorAsh.Appointments;
using DoctorAsh.Appointments.Dtos;
using AutoMapper;

namespace DoctorAsh
{
    public class DoctorAshApplicationAutoMapperProfile : Profile
    {
        public DoctorAshApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Appointment, AppointmentDto>();
            CreateMap<CreateAppointmentDto, Appointment>(MemberList.Source);
        }
    }
}
