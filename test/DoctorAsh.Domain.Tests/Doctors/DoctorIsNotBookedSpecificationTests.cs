using System;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace DoctorAsh.Doctors
{
    public class DoctorIsNotBookedSpecificationTests:DoctorAshDomainTestBase
    {
private readonly IDoctorRepository _doctorRepository;
        public DoctorIsNotBookedSpecificationTests()
        {
            _doctorRepository = GetRequiredService<IDoctorRepository>();
        }
        [Fact]
        public async Task IsSatisfiedBy_GivenAlreadyBookedSession_returnFalse()
        {
        //Given
            var doctor = await _doctorRepository.FindAsync(TestData.DoctorId);

            var spec = new DoctorIsNotBookedSpecification(DateTime.Now.AddDays(1),DateTime.Now.AddDays(1).AddHours(2));
            var result = spec.IsSatisfiedBy(doctor);
            result.ShouldBe(false);
        }
    }
}