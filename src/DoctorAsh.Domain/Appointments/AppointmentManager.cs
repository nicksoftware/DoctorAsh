using System.Threading;
using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;
using Volo.Abp;
using DoctorAsh.Appointments.Exceptions;

namespace DoctorAsh.Appointments
{
    public interface IAppointmentManager
    {
        Task<Appointment> CreateAsync([NotNull] string title,
        [NotNull] string description,
        [NotNull] DateTime startDate,
        DateTime endDate,
        [NotNull] RecurrenceType recurrence);

        Task<Appointment> RescheduleAsync(
    [NotNull] Appointment appointment,
    [NotNull] DateTime startDate,
    [NotNull] DateTime endDate);
        Task<Appointment> CancelAsync(
            [NotNull] Appointment appointment,
            [NotNull] string reason
        );

    }
    public class AppointmentManager : DomainService, IAppointmentManager
    {
        private readonly IAppointmentRepository _appointmentRepo;

        public AppointmentManager(IAppointmentRepository appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }
        public async Task<Appointment> CreateAsync(
            [NotNull] string title,
            [NotNull] string description,
            [NotNull] DateTime startDate,
            DateTime endDate,
            [NotNull] RecurrenceType recurrence)
        {
            var ab = new AppointmentBuilder(GuidGenerator.Create());

            var appointment = ab
                .WithTitle(title)
                .WithDescription(description)
                .WithRecurrence(recurrence)
                .WithStartDate(startDate)
                .WithEndDate(endDate)
                .Build();

            return await _appointmentRepo.InsertAsync(appointment, autoSave: true);
        }

        public async Task<Appointment> UpdateDetailsAsync(
            [NotNull] Appointment appointment,
            [NotNull] string title,
            [NotNull] string descriptions)
        {
            appointment.Title = Check.NotNullOrWhiteSpace(title, nameof(title));
            appointment.Description = Check.NotNullOrWhiteSpace(title, nameof(descriptions));

            return await _appointmentRepo.UpdateAsync(appointment);
        }

        public async Task<Appointment> RescheduleAsync(
            [NotNull] Appointment appointment,
            [NotNull] DateTime startDate,
            [NotNull] DateTime endDate)
        {
            appointment.SetStartDate(startDate);
            appointment.SetEndDate(endDate);

            return await _appointmentRepo.UpdateAsync(appointment);
        }

        public async Task<Appointment> CancelAsync(
            [NotNull] Appointment appointment,
            [NotNull] string reason
        )
        {
            appointment.Cancel(reason);

            return await _appointmentRepo.UpdateAsync(appointment);
        }

    }
}