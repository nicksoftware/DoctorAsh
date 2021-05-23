using System;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;
using Shouldly;
using Volo.Abp.EventBus.Local;
using Volo.Abp.Timing;

namespace DoctorAsh.Appointments
{
    public sealed class AppointmentManagerTests : DoctorAshDomainTestBase
    {
        private readonly IAppointmentRepository _repository;
        private readonly IClock _clock;
        public AppointmentManagerTests()
        {
            _repository = GetService<IAppointmentRepository>();
            _clock = GetService<IClock>();
        }

        [Fact(Skip = "Test is buggy")]
        public async Task CreateAsync()
        {
            //Given
            const string title = "Test builder";
            const string description = "Test builder Appointment";
            var start = DateTime.Now.AddDays(2);
            var end = DateTime.Now.AddDays(4);
            var fakeEventBus = Substitute.For<ILocalEventBus>();

            //When
            var manager = new AppointmentManager(_repository,fakeEventBus,_clock);

            var result = await WithUnitOfWorkAsync<Appointment>(async () => 
                await manager.CreateAsync(title, description, start, end, RecurrenceType.Once));
            
            result.Title.ShouldBe(title);
            result.Description.ShouldBe(description);
            result.StartDate.ShouldBe(start);
            result.EndDate.ShouldBe(end);
        }
    }
}