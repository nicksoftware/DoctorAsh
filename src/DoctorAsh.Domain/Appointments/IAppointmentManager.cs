using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

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
        Task<Appointment> ReactivateAsync(Guid id, Appointment appointment);
        Task AcceptAsync(Appointment appointment);
        Task DeclineAsync(Appointment appointment);
    }
}