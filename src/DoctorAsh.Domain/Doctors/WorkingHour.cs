using System;
using Volo.Abp.Domain.Entities;

namespace DoctorAsh.Doctors
{
    public class WorkingHour: Entity<int>
    {
        public Guid DoctorId { get; set; }
        public DayOfWeek Day {get;set;}
        public DateTime StartTime { get; set; }
        public DateTime EndTime {get;set;}
    }
}