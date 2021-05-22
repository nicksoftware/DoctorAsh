using System;
using System.Threading.Tasks;
using DoctorAsh.Patients;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace DoctorAsh.EntityFrameworkCore.Patients
{
    public class PatientRepositoryTests : DoctorAshEntityFrameworkCoreTestBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientRepositoryTests()
        {
            _patientRepository = GetRequiredService<IPatientRepository>();
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
