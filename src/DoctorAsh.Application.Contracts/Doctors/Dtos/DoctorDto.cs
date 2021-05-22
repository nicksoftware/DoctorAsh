using System;
using System.Collections.Generic;
using DoctorAsh.Appointments.Dtos;
using Volo.Abp.Application.Dtos;

namespace DoctorAsh.Doctors.Dtos
{
    [Serializable]
    public class DoctorDto : FullAuditedEntityDto<Guid>
    {
        public ICollection<AppointmentDto> Appointments { get; set; }

        public ICollection<WorkingHourDto> WorkingHours { get; set; }

        public AvailablityStatusType Status { get; set; }

        public double RatingScore { get; set; }
    }
}