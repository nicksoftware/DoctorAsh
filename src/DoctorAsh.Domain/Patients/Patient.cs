using System;
using System.Collections.Generic;
using DoctorAsh.Appointments;
using Volo.Abp.Domain.Entities.Auditing;

namespace DoctorAsh.Patients
{
    public class Patient: FullAuditedAggregateRoot<Guid>
    {
        public ICollection<Appointment> Appointments { get; set; }

        protected Patient()
        {
        }

        public Patient(
            Guid id,
            ICollection<Appointment> appointments
        ) : base(id)
        {
            Appointments = appointments;
        }
    }
}
