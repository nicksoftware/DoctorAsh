using System;
using System.Linq.Expressions;
using Volo.Abp.Specifications;
using Volo.Abp.Timing;

namespace DoctorAsh.Appointments
{
    public class AppointmentDateOverDueSpecification : Specification<Appointment>
    {
        private readonly IClock _clock;

        public AppointmentDateOverDueSpecification(IClock clock)
        {
            _clock = clock;
        }
        public override Expression<Func<Appointment, bool>> ToExpression()
        {
            return x=>!x.IsCancelled && x.Status != StatusType.Missed && _clock.Now > x.StartDate;
        }
    }
}