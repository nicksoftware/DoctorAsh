using System;
using System.Threading.Tasks;
using DoctorAsh.Appointments.Exceptions;
using Shouldly;
using Xunit;

namespace DoctorAsh.Appointments
{
    public class AppointmentBuilderTests : DoctorAshDomainTestBase
    {
        [Fact]
        public void GivenRequiredInputs_BuildAndReturnAppointment()
        {
            var title = "Test builder";
            var description = "Test builder Appointment";
            var start = DateTime.Now.AddDays(2);
            var end = DateTime.Now.AddDays(4);

            var ab = new AppointmentBuilder(Guid.NewGuid());
            var appointment = ab
                .WithTitle(title)
                .WithDescription(description)
                .WithStartDate(start)
                .WithEndDate(end)
                .WithRecurrence(RecurrenceType.Once).Build();

            appointment.ShouldNotBeNull();
            appointment.Title.ShouldBe(title);
            appointment.Description.ShouldBe(description);
            appointment.StartDate.ShouldBe(start);
            appointment.EndDate.ShouldBe(end);
            appointment.Recurrence.ShouldBe(RecurrenceType.Once);

        }
    }
}