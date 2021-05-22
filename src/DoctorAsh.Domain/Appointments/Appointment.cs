using System;
using Volo.Abp.Domain.Entities.Auditing;
using DoctorAsh.Appointments.Exceptions;
using JetBrains.Annotations;
using DoctorAsh.Appointments.Events;

namespace DoctorAsh.Appointments
{
    public class Appointment : FullAuditedAggregateRoot<Guid>
    {
        public Guid DoctorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public RecurrenceType Recurrence { get; set; }
        public StatusType Status { get; set; }
        public bool IsCancelled { get; set; }
        public string cancellationReason { get; set; }

        protected Appointment() { }

        internal Appointment(
            [NotNull] Guid id,
            [NotNull] string title,
            [NotNull] string description
            ) : base(id)
        {
            Title = title;
            Description = description;
        }

        internal void SetStartDate(DateTime startDate)
        {

            if (startDate < DateTime.Now) throw new InvalidStartDateException(startDate);
            StartDate = startDate;
        }

        internal void SetEndDate(DateTime endDate)
        {
            if (endDate <= StartDate) throw new InvalidEndDateException(endDate);

            EndDate = endDate;
        }

        internal void Cancel(string reason)
        {
            if (IsCancelled) throw new AppointmentAlreadyCancelledException(Id);

            IsCancelled = true;
            Status = StatusType.Cancelled;
            cancellationReason = reason;

            AddLocalEvent(new AppointmentCancelled(Id, reason));
        }

        public void SetToMissed()
        {
            if (Status == StatusType.Missed) return;
            
            Status = StatusType.Missed;

            AddLocalEvent(new AppointmentMissed(Id));
        }
        public void ReActivate()
        {
            if (!IsCancelled) throw new AppointmentIsActiveException(Id);

            IsCancelled = false;
            Status = StatusType.Cancelled;
            cancellationReason = string.Empty;

            AddLocalEvent(new AppointmemtReactivated(Id));
        }
    }
}
