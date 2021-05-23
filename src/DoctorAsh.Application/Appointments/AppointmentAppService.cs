using System;
using DoctorAsh.Permissions;
using DoctorAsh.Appointments.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using DoctorAsh.Doctors;
using DoctorAsh.Doctors.Exceptions;
using System.Linq;

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
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAppointmentManager _appointmentManager;

        public AppointmentAppService(
        IAppointmentRepository repository,
        IDoctorRepository doctorRepository,
        IAppointmentManager appointmentManager) : base(repository)
        {
            _repository = repository;
            _doctorRepository = doctorRepository;
            _appointmentManager = appointmentManager;
        }

        public override async Task<AppointmentDto> CreateAsync(CreateAppointmentDto input)
        {
            var doctor = await _doctorRepository
            .FindAsync(new DoctorIsAvailableSpecification(input.StartDate, (DateTime)input.EndDate).ToExpression());

            if (doctor == null || doctor.Id != input.DoctorId) throw new DoctorIsNotAvailableException(input.StartDate, (DateTime)input.EndDate);

            var createdAppointment = await _appointmentManager.CreateAsync(
                doctorId:  input.DoctorId,
                patientId: input.PatientId,
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
            Appointment appointment = await GetIfExists(id);
            var updatedAppointment = await _appointmentManager.RescheduleAsync(appointment, input.NewDate, input.NewEndDate);

            return MapToGetOutputDto(updatedAppointment);
        }

        public async Task<AppointmentDto> CancelAsync(Guid id, CancelAppointmentDto input)
        {
            Appointment appointment = await GetIfExists(id);
            var cancelAppointment = await _appointmentManager.CancelAsync(appointment, input.Reason);

            return MapToGetOutputDto(cancelAppointment);
        }
        public async Task ApproveAppointmentAsync(Guid id)
        {
            Appointment appointment = await GetIfExists(id);
            await _appointmentManager.AcceptAsync(appointment);
        }

        public async Task DeclineAppointmentAsync(Guid id)
        {
            Appointment appointment = await GetIfExists(id);
            await _appointmentManager.DeclineAsync(appointment);
        }

        private async Task<Appointment> GetIfExists(Guid id)
        {
            var appointment = await Repository.FindAsync(id);
            if (appointment == null) throw new EntityNotFoundException(typeof(Appointment), id);
            return appointment;
        }

    }
}
