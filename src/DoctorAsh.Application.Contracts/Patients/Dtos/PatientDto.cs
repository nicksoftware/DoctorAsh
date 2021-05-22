using System;
using System.Collections.Generic;
using DoctorAsh.Appointments.Dtos;
using Volo.Abp.Application.Dtos;

namespace DoctorAsh.Patients.Dtos
{
    [Serializable]
    public class PatientDto : FullAuditedEntityDto<Guid>
    {
        public ICollection<AppointmentDto> Appointments { get; set; }
    }
}