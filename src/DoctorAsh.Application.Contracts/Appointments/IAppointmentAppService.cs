using System;
using System.Threading.Tasks;
using DoctorAsh.Appointments.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DoctorAsh.Appointments
{
    public interface IAppointmentAppService :
        ICrudAppService<
            AppointmentDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateAppointmentDto,
            UpdateAppointmentDto>
    {
        Task<AppointmentDto> RescheduleAsync(Guid id, RescheduleAppointmentDto input);
        Task<AppointmentDto> CancelAsync(Guid id, CancelAppointmentDto input);
        Task ApproveAppointmentAsync(Guid id);
        Task DeclineAppointmentAsync(Guid id);
    }
}