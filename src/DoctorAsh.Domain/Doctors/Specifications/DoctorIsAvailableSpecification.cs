using System;
using Volo.Abp.Specifications;

namespace DoctorAsh.Doctors
{
    public class DoctorIsAvailableSpecification : AndSpecification<Doctor>
    {
        public DoctorIsAvailableSpecification(DateTime startDate,DateTime endDate) 
        : base(new DoctorIsAtWorkSpecification(startDate,endDate),new DoctorIsNotBookedSpecification(startDate,endDate) )
        {
        }
    }
}