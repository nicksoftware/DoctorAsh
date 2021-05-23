using System;
using System.Linq;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace DoctorAsh.Doctors
{

    public class DoctorIsNotBookedSpecification : Specification<Doctor>
    {
        private readonly DateTime startDate;
        private readonly DateTime endDate;
        public DoctorIsNotBookedSpecification(DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }
        public override Expression<Func<Doctor, bool>> ToExpression()
        {
            return d => d.Appointments.Where(x => x.StartDate >= startDate && x.EndDate <= endDate).Count() == 0;
        }
    }
}