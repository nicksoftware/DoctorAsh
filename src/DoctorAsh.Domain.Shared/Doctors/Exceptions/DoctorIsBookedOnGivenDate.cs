using System;
using Volo.Abp;

namespace DoctorAsh.Doctors.Exceptions
{
    public class DoctorIsNotAvailableException: BusinessException
    {
        public DoctorIsNotAvailableException(DateTime startDate,DateTime endDate)
        :base(DoctorAshDomainErrorCodes.DoctorIsNotAvailableException)
        {
            WithData("startDate",startDate);
            WithData("endDate",endDate);
        }
    }
}