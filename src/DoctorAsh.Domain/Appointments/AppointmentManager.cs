using System.Runtime.Serialization;
using System.Threading;
using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;
using Volo.Abp;
using DoctorAsh.Appointments.Exceptions;
using Volo.Abp.EventBus.Local;
using DoctorAsh.Appointments.Events;
using Volo.Abp.Timing;

namespace DoctorAsh.Appointments
{
    public class AppointmentManager : DomainService, IAppointmentManager
    {
        private readonly IAppointmentRepository _appointmentRepo;
        private readonly ILocalEventBus _localEventBus;
        private readonly IClock _clock;

        public AppointmentManager(
            IAppointmentRepository appointmentRepo,
            ILocalEventBus localEventBus,
            IClock clock)
        {
            _appointmentRepo = appointmentRepo;
            _localEventBus = localEventBus;
            _clock = clock;
        }
        public async Task<Appointment> CreateAsync(
            [NotNull] Guid doctorId,
            [NotNull] Guid patientId,
            [NotNull] string title,
            [NotNull] string description,
            [NotNull] DateTime startDate,
            DateTime endDate,
            [NotNull] RecurrenceType recurrence)
        {
            var ab = new AppointmentBuilder(GuidGenerator.Create());

            var appointment = ab
                .WithDoctor(doctorId)
                .WithPatient(patientId)
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

            return await _appointmentRepo.UpdateAsync(appointment, true).ConfigureAwait(false);
        }

        public async Task<Appointment> RescheduleAsync(
            [NotNull] Appointment appointment,
            [NotNull] DateTime startDate,
            [NotNull] DateTime endDate)
        {
            appointment.SetStartDate(startDate);
            appointment.SetEndDate(endDate);
            appointment.Status = StatusType.AwaitingApproval;
            return await _appointmentRepo.UpdateAsync(appointment, true).ConfigureAwait(false);
        }

        public async Task<Appointment> CancelAsync(
            [NotNull] Appointment appointment,
            [NotNull] string reason
        )
        {
            appointment.Cancel(reason, _clock.Now);
            var cancelledAppointment = await _appointmentRepo.UpdateAsync(appointment, true);
            return cancelledAppointment;
        }

        public async Task<Appointment> ReactivateAsync(
            Guid id,
            Appointment appointment)
        {
            appointment.ReActivate();

            var activatedAppointment = await _appointmentRepo.UpdateAsync(appointment, true);
            return appointment;
        }

        public Task AcceptAsync(Appointment appointment)
        {
            appointment.Accept();
            return Task.CompletedTask;
        }

        public Task DeclineAsync(Appointment appointment)
        {
            appointment.Decline();
            return Task.CompletedTask;
        }
    }
}