using System;

namespace DoctorAsh.Doctors.Dtos
{
    public class WorkingHourDto
    {
        public Guid DoctorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime {get;set;}
    }
}