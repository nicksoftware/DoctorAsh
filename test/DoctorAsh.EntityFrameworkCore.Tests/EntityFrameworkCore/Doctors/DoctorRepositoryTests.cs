using System;
using System.Threading.Tasks;
using DoctorAsh.Doctors;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace DoctorAsh.EntityFrameworkCore.Doctors
{
    public class DoctorRepositoryTests : DoctorAshEntityFrameworkCoreTestBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorRepositoryTests()
        {
            _doctorRepository = GetRequiredService<IDoctorRepository>();
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
