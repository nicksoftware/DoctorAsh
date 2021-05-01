using System.Threading;
using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace DoctorAsh.Appointments
{
    public interface IAppointmentManager 
    {
        Task<Appointment> CreateAsync([NotNull] string title,
        [NotNull] string description,
        [NotNull] DateTime startDate,
        DateTime endDate,
        [NotNull] RecurrenceType recurrence);

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

            var insertedAppointment = await _appointmentRepo.InsertAsync(appointment, autoSave: true);

            return insertedAppointment;
        }
    }
}