using System;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp;
using Xunit;

namespace DoctorAsh.Doctors
{
    public class DoctorTests : DoctorAshDomainTestBase
    {

        private Guid _doctorId = Guid.Empty;
        private Doctor _doctor;
        public DoctorTests()
        {
            _doctor = Doctor.Create(_doctorId, TestData.User1Id);
        }

        [Fact]
        public void AddWorkingHour_Given_UniqueDay_AddToWorkingHours()
        {
            //Given
            var workingHour = new WorkingHour(_doctorId, DayOfWeek.Monday)
            {
                StartTime = DateTime.Parse("7:00 AM"),
                EndTime = DateTime.Parse("10:30 AM")
            };
            //When
            _doctor.AddWorkingHour(workingHour);
            //Then
            _doctor.WorkingHours.ShouldContain(workingHour);
        }

        [Fact]
        public void AddWorkingHour_GivenDayOfExistingWorkingHour_ThrowException()
        {
            var doctorId = Guid.NewGuid();
            var doctor = Doctor.Create(doctorId, TestData.User1Id);
            //Given
            var workingHour = new WorkingHour(doctorId, DayOfWeek.Monday)
            {
                StartTime = DateTime.Parse("7:00 AM"),
                EndTime = DateTime.Parse("10:30 AM")
            };

            //When
            var exception = Assert.Throws<WorkingHourForDayGivenAlreadySetException>(() =>
                {
                    var newWorkingHour = new WorkingHour(doctorId, DayOfWeek.Monday)
                    {
                        StartTime = DateTime.Parse("8:00 AM"),
                        EndTime = DateTime.Parse("10:30 AM")
                    };
                    doctor.AddWorkingHour(workingHour);
                }
            );
            //Then
            exception.Code.ShouldBe(DoctorAshDomainErrorCodes.WorkingHourForDayGivenAlreadySetException);
        }

        [Fact]
        public void ChangeWorkingHour_ShouldChangeWorkingHour()
        {
            //Given
            //Given
            var workingHour = new WorkingHour(_doctorId, DayOfWeek.Monday)
            {
                StartTime = DateTime.Parse("7:00 AM"),
                EndTime = DateTime.Parse("10:30 AM")
            };

            //When
            var existingWorkingHour = _doctor.WorkingHours.FirstOrDefault(x => x.Day == DayOfWeek.Monday);
            var newStartTime = DateTime.Parse("10:00 AM");
            var newEndTime = DateTime.Parse("12:30 AM");
            existingWorkingHour.StartTime = newStartTime;
            existingWorkingHour.EndTime = newEndTime;
            _doctor.ChangeWorkingHour(existingWorkingHour);

            //Assert
            var result = _doctor.WorkingHours.First(d => d.Day == DayOfWeek.Monday);
            result.StartTime.ShouldBe(newStartTime);
            result.EndTime.ShouldBe(newEndTime);

        }

        [Fact]
        public void RemoveWorkingHour_ShouldChangeWorkingHour()
        {
            //Given
            //Given
            var workingHour = new WorkingHour(_doctorId, DayOfWeek.Monday)
            {
                StartTime = DateTime.Parse("7:00 AM"),
                EndTime = DateTime.Parse("10:30 AM")
            };

            _doctor.AddWorkingHour(workingHour);
            //When
            _doctor.RemoveWorkingHour(workingHour);
            var result = _doctor.WorkingHours.FirstOrDefault(x => x.Day == DayOfWeek.Monday);
            //Assert
            result.ShouldBeNull();
        }
    }
}
