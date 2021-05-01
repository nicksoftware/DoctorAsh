using System;

namespace DoctorAsh.Appointments.Dtos
{
    [Serializable]
    public class CancelAppointmentDto
    {
        public string Reason { get; set; }
    }
}