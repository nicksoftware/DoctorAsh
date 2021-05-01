using System;
using System.Threading.Tasks;
using DoctorAsh.Appointments.Exceptions;
using Shouldly;
using Xunit;

namespace DoctorAsh.Appointments
{
    public class AppointmentTests : DoctorAshDomainTestBase
    {
        private Appointment appointment = new Appointment(Guid.NewGuid(), "Test Appointment", "Appointment description");

        public AppointmentTests()
        {
        }

        [Fact]
        public void SetStartDate_GivenoldDate_throw_InvalidStartDateException()
        {
            // Act
            var exception = Assert.Throws<InvalidStartDateException>(() =>
            {
                appointment.SetStartDate(DateTime.Now.AddYears(-4));

            });
            // Assert
            exception.ShouldBeOfType<InvalidStartDateException>();
            exception.Code.ShouldBe(DoctorAshDomainErrorCodes.InvalidStartDateException);
        }

        [Fact]
        public void SetStartDate_GivenDateGreaterThanDateToday_ShouldSetDate()
        {
            //Arrange
            var date = DateTime.Now.AddDays(2);

            //Act
            appointment.SetStartDate(date);

            //Assert
            appointment.StartDate.ShouldBe(date);
        }

        [Fact]
        public void SetEndDate_GivenDateOlderThanStartDate_throw_InvalidEndDateException()
        {
            var startDate = DateTime.Now.AddDays(5);
            var endDate = DateTime.Now;
            // Act
            var exception = Assert.Throws<InvalidEndDateException>(() =>
            {
                appointment.SetStartDate(startDate);

                appointment.SetEndDate(endDate);

            });
            // Assert
            exception.Code.ShouldBe(DoctorAshDomainErrorCodes.InvalidEndDateException);
        }

        [Fact]
        public void SetEndDate_GivenDateGreaterThanStartDate_ShouldSetDate()
        {
            //Arrange
            var date = DateTime.Now.AddDays(2);
            //Act
            appointment.SetStartDate(date);
            //Assert
            appointment.StartDate.ShouldBe(date);
        }
    }
}
