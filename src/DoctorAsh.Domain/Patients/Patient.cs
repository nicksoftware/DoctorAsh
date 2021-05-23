using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DoctorAsh.Appointments;
using Volo.Abp.Domain.Entities.Auditing;

namespace DoctorAsh.Patients
{
    public class Patient: FullAuditedAggregateRoot<Guid>
    {
        public Guid UserId {get;set;}
        public ICollection<Appointment> Appointments { get; set; } = new Collection<Appointment>();

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
