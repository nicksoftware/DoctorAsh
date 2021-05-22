using System;

namespace DoctorAsh.Appointments.Events
{
    public interface IAppointmentEventData
    {
        Guid AppointmentId { get; init; }
    }
}