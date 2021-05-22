using System;
using Volo.Abp;

namespace DoctorAsh.Doctors
{
    public class WorkingHourForDayGivenAlreadySetException: BusinessException
    {
        public WorkingHourForDayGivenAlreadySetException(DayOfWeek day)
        :base(DoctorAshDomainErrorCodes.WorkingHourForDayGivenAlreadySetException)
        {
            WithData("day",Enum.GetName(typeof(DayOfWeek), day));
        }
    }
}