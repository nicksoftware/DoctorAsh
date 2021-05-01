using System;
using Volo.Abp;

namespace DoctorAsh.Appointments.Exceptions
{
    public class AppointmentAlreadyCancelledException: BusinessException
    {
        public AppointmentAlreadyCancelledException(Guid appointmentId)
        : base(DoctorAshDomainErrorCodes.AppointmentAlreadyCancelledException)
        {
            WithData("id", appointmentId);
        }
    }

    
}