using System;
using DoctorAsh.Permissions;
using DoctorAsh.Appointments.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace DoctorAsh.Appointments
{
    public class AppointmentAppService : CrudAppService<Appointment, AppointmentDto, Guid, PagedAndSortedResultRequestDto, CreateAppointmentDto, UpdateAppointmentDto>,
        IAppointmentAppService
    {
        protected override string GetPolicyName { get; set; } = DoctorAshPermissions.Appointment.Default;
        protected override string GetListPolicyName { get; set; } = DoctorAshPermissions.Appointment.Default;
        protected override string CreatePolicyName { get; set; } = DoctorAshPermissions.Appointment.Create;
        protected override string UpdatePolicyName { get; set; } = DoctorAshPermissions.Appointment.Update;
        protected override string DeletePolicyName { get; set; } = DoctorAshPermissions.Appointment.Delete;

        private readonly IAppointmentRepository _repository;
        private readonly IAppointmentManager _appointmentManager;

        public AppointmentAppService(IAppointmentRepository repository,
        IAppointmentManager appointmentManager) : base(repository)
        {
            _repository = repository;
            _appointmentManager = appointmentManager;
        }

        public override async Task<AppointmentDto> CreateAsync(CreateAppointmentDto input)
        {
            
            var createdAppointment = await _appointmentManager.CreateAsync(
                title: input.Title,
                description: input.Description,
                startDate: input.StartDate,
                endDate: (DateTime)input.EndDate,
                recurrence: input.Recurrence
            );
            return MapToGetOutputDto(createdAppointment);
        }

        public override Task<AppointmentDto> UpdateAsync(Guid id, UpdateAppointmentDto input)
        {
            return base.UpdateAsync(id, input);
        }

        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }
        public override Task<AppointmentDto> GetAsync(Guid id)
        {
            return base.GetAsync(id);
        }
        public override Task<PagedResultDto<AppointmentDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetListAsync(input);
        }
        public async Task<AppointmentDto> RescheduleAsync(Guid id, RescheduleAppointmentDto input)
        {
            var appointment = await Repository.FindAsync(id);
            if(appointment == null) throw new EntityNotFoundException(typeof(Appointment),id);

            var updatedAppointment =   await _appointmentManager.RescheduleAsync(appointment, input.NewDate, input.NewEndDate);

            return MapToGetOutputDto(updatedAppointment);
        }

        public async Task<AppointmentDto> CancelAsync(Guid id, CancelAppointmentDto input)
        {
            var appointment = await Repository.FindAsync(id);
            if (appointment == null) throw new EntityNotFoundException(typeof(Appointment), id);

            var cancelAppointment = await _appointmentManager.CancelAsync(appointment, input.Reason);
            
            return MapToGetOutputDto(cancelAppointment);
        }
    }
}
