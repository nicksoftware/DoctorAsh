using System;
using Shouldly;
using Xunit;

namespace DoctorAsh.Doctors
{
    public class DoctoIsAtWorkSpecificationTests
    {
        public DoctoIsAtWorkSpecificationTests() { }

        [Fact]
        public void IsSetisfiedBy_GivenInvalidTime_returnFalse()
        {
            //Given
            var dr = Doctor.Create(TestData.DoctorId, TestData.AdminId);
            dr.AddWorkingHour(new WorkingHour(dr.Id, DayOfWeek.Monday)
            {
                StartTime = DateTime.Parse("07:30 AM"),
                EndTime = DateTime.Parse("10:30 PM"),
            });
            //When
            var spec = new DoctorIsAtWorkSpecification(DateTime.Parse("02:30 AM"), DateTime.Parse("05:30 AM"));
            //Then
            var result = spec.IsSatisfiedBy(dr);
            result.ShouldBe(false);
        }

        [Fact]
        public void IsSetisfiedBy_AvailableTime_returnTrue()
        {
            var date = DateTime.Now;

            var dr = Doctor.Create(TestData.DoctorId, TestData.AdminId);
            dr.AddWorkingHour(new WorkingHour(dr.Id, DayOfWeek.Monday)
            {
                StartTime = date,
                EndTime = date.AddHours(15),
            });
            var spec = new DoctorIsAtWorkSpecification(date.AddHours(1), date.AddHours(5));

            var result = spec.IsSatisfiedBy(dr);

            result.ShouldBe(true);
        }

        [Fact]
        public void IsSatisfiedBy_WhenStartTimeIsEqualTodoctorEndTime_ReturnFalse()
        {
            var date = DateTime.Now;
            var endDate = DateTime.Now.AddHours(15);
            var dr = Doctor.Create(TestData.DoctorId, TestData.AdminId);
            dr.AddWorkingHour(new WorkingHour(dr.Id, DayOfWeek.Monday)
            {
                StartTime = date,
                EndTime = endDate
            });
            //When
            var spec = new DoctorIsAtWorkSpecification(DateTime.Now.AddHours(15), DateTime.Now.AddHours(17));
            var result = spec.IsSatisfiedBy(dr);
            result.ShouldBe(false);
        }
    }
}