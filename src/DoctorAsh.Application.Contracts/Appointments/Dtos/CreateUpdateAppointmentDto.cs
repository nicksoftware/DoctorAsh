using System;
using System.ComponentModel;
namespace DoctorAsh.Appointments.Dtos
{
    [Serializable]
    public class CreateAppointmentDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public RecurrenceType Recurrence { get; set; }
    }

    public class UpdateAppointmentDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public RecurrenceType Recurrence { get; set; }

    }
}