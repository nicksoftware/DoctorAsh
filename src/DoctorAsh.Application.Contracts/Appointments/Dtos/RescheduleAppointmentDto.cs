using System;
using System.ComponentModel.DataAnnotations;

namespace DoctorAsh.Appointments.Dtos
{
    [Serializable]
    public class RescheduleAppointmentDto
    {
        public DateTime NewDate { get; set; }
        public DateTime NewEndDate { get; set; }
        [Required]
        public string Reason { get; set; }
    }
}