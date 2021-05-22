using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace DoctorAsh.Patients
{
    public class Condition: FullAuditedEntity<Guid>
    {
        public Guid MedicalHistoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Treatment { get; set; }
        public Guid? DiagnosedBy { get; set; }
        public bool IsActive { get; set; }
    }
}