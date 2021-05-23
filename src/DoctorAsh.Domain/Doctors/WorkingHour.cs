using System;
using Volo.Abp.Domain.Entities;

namespace DoctorAsh.Doctors
{
    public class WorkingHour: Entity<int>
    {
        protected WorkingHour(){}
        public WorkingHour(Guid doctorId,DayOfWeek day)
        {
            DoctorId = doctorId;
            Day = day;
        }
        public Guid DoctorId { get; set; }
        public DayOfWeek Day {get;set;}
        public DateTime StartTime { get; set; }
        public DateTime EndTime {get;set;}
    }
}