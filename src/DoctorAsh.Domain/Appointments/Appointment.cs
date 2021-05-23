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
        public Guid PatientId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public RecurrenceType Recurrence { get; set; }
        public StatusType Status { get; internal set; }
        public bool IsCancelled { get; set; }
        public string cancellationReason { get; set; }

        protected Appointment() { }

        internal Appointment(
            [NotNull] Guid id,
            [NotNull] Guid doctorId,
            [NotNull] Guid patientId
            ) : base(id)
        {
            DoctorId = doctorId;
            PatientId = patientId;
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

        internal void Cancel(string reason, DateTime cancellationDate)
        {
            CheckIfNotCancelled();

            IsCancelled = true;
            Status = StatusType.Cancelled;
            cancellationReason = reason;

            AddLocalEvent(new AppointmentCancelled(Id, reason, cancellationDate));
        }

        public void SetToMissed()
        {
            if (Status == StatusType.Missed) return;

            Status = StatusType.Missed;

            AddLocalEvent(new AppointmentMissed(Id));
        }
        internal void ReActivate()
        {
            if (!IsCancelled) throw new AppointmentIsActiveException(Id);

            IsCancelled = false;
            Status = StatusType.Cancelled;
            cancellationReason = string.Empty;

            AddLocalEvent(new AppointmemtReactivated(Id));
        }
        internal void Accept()
        {
            CheckIfNotCancelled();

            if (Status == StatusType.Approved) return;

            Status = StatusType.Approved;
        }

        internal void Decline()
        {
            CheckIfNotCancelled();

            if (Status == StatusType.Declined) return;

            Status = StatusType.Declined;
        }

        private void CheckIfNotCancelled()
        {
            if (IsCancelled) throw new AppointmentAlreadyCancelledException(Id);
        }

    }
}
