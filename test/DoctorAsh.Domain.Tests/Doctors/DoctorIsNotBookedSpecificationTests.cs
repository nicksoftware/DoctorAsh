using System;
using System.Linq;
using System.Threading.Tasks;
using DoctorAsh.Appointments;
using Shouldly;
using Xunit;

namespace DoctorAsh.Doctors
{
    public class DoctorIsNotBookedSpecificationTests : DoctorAshDomainTestBase
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
            var startTime = DateTime.Now.AddDays(1);
            var endTime = DateTime.Now.AddDays(1).AddHours(2);

            var doctor = await _doctorRepository.FindAsync(TestData.DoctorId);
            var appointment = new Appointment(Guid.NewGuid(), TestData.DoctorId, TestData.PatientId);

            appointment.SetStartDate(startTime);
            appointment.SetEndDate(endTime);
            doctor.Appointments.Add(appointment);

            var spec = new DoctorIsNotBookedSpecification(startTime, endTime);
            var result = spec.IsSatisfiedBy(doctor);

            result.ShouldBe(false);
        }
    }
}
