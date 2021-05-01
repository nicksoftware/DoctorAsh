using System;
using Volo.Abp;

namespace DoctorAsh.Appointments.Exceptions
{
    public class AppointmentIsActiveException: BusinessException

    {
        public AppointmentIsActiveException(Guid id)
        : base(DoctorAshDomainErrorCodes.AppointmentIsActiveException)
        {
            WithData("id", id.ToString());
        }
    }
}