using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace DoctorAsh.Patients
{
    public class PatientAppServiceTests : DoctorAshApplicationTestBase
    {
        private readonly IPatientAppService _patientAppService;

        public PatientAppServiceTests()
        {
            _patientAppService = GetRequiredService<IPatientAppService>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
        */
    }
}
