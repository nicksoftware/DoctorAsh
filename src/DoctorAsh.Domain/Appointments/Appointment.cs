using System.Reflection;
using System;
using Volo.Abp.Domain.Entities.Auditing;
using DoctorAsh.Appointments.Exceptions;
using JetBrains.Annotations;

namespace DoctorAsh.Appointments
{
    public class Appointment : FullAuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public RecurrenceType Recurrence { get; set; }
        public StatusType Status { get; set; }

        protected Appointment()
        {
        }

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

            if (startDate < DateTime.Now)
                throw new InvalidStartDateException(startDate);

            StartDate = startDate;
        }

        internal void SetEndDate(DateTime endDate)
        {
            if (endDate <= StartDate)
                throw new InvalidEndDateException(endDate);

            EndDate = endDate;
        }
    }
}
