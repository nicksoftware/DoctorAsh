using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace DoctorAsh.Appointments.Dtos
{
    [Serializable]
    public class AppointmentDto : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public RecurrenceType Recurrence { get; set; }

        public StatusType Status { get; set; }
    }
}