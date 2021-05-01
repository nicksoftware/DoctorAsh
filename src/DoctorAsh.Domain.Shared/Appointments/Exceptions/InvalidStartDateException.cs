using System;
using Volo.Abp;

namespace DoctorAsh.Appointments.Exceptions
{
    public class InvalidEndDateException : BusinessException
    {
        public InvalidEndDateException(DateTime date)
        : base(DoctorAshDomainErrorCodes.InvalidEndDateException)
        {
            WithData("date", date.ToShortDateString());
        } 
    }
    public class InvalidStartDateException : BusinessException
    {
        public InvalidStartDateException(DateTime date)
        : base(DoctorAshDomainErrorCodes.InvalidStartDateException)
        {
            WithData("date", date.ToShortDateString());
        }
    }
}