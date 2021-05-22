using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace DoctorAsh.Doctors
{
    public class DoctorAppServiceTests : DoctorAshApplicationTestBase
    {
        private readonly IDoctorAppService _doctorAppService;

        public DoctorAppServiceTests()
        {
            _doctorAppService = GetRequiredService<IDoctorAppService>();
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
