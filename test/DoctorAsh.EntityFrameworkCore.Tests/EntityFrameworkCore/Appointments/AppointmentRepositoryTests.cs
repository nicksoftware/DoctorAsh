using System;
using System.Threading.Tasks;
using DoctorAsh.Appointments;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace DoctorAsh.EntityFrameworkCore.Appointments
{
    public class AppointmentRepositoryTests : DoctorAshEntityFrameworkCoreTestBase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentRepositoryTests()
        {
            _appointmentRepository = GetRequiredService<IAppointmentRepository>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
        */
    }
}
