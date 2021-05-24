using System;
using System.Linq;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace DoctorAsh.Doctors
{
    public class DoctorIsAtWorkSpecification : Specification<Doctor>
    {
        private readonly DateTime startDate;
        private readonly DateTime endDate;

        public DoctorIsAtWorkSpecification(DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public override Expression<Func<Doctor, bool>> ToExpression()
        {
            
            return d => d.WorkingHours.Where(x =>startDate.Hour > x.StartTime.Hour  && x.EndTime.Hour > endDate.Hour).Count() > 0;
        }
    }
}