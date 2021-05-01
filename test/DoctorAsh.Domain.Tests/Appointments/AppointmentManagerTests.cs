using System;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace DoctorAsh.Appointments
{
    public class AppointmentManagerTests : DoctorAshDomainTestBase
    {
        private IAppointmentRepository repository;
        public AppointmentManagerTests()
        {
            repository = GetService<IAppointmentRepository>();
        }

        [Fact(Skip = "Test is buggy")]
        public async Task CreateAsync()
        {
            //Given
            var title = "Test builder";
            var description = "Test builder Appointment";
            var start = DateTime.Now.AddDays(2);
            var end = DateTime.Now.AddDays(4);

            //When
            var manager = new AppointmentManager(repository);

            var result = await WithUnitOfWorkAsync<Appointment>(async () =>
            {
                return await manager.CreateAsync(title, description, start, end, RecurrenceType.Once);
            });
            result.Title.ShouldBe(title);
            result.Description.ShouldBe(description);
            result.StartDate.ShouldBe(start);
            result.EndDate.ShouldBe(end);
        }
    }
}