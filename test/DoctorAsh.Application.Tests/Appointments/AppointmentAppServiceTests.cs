using System.Linq;
using System;
using Shouldly;
using System.Threading.Tasks;
using Xunit;
using DoctorAsh.Appointments.Dtos;
using DoctorAsh.Appointments.Exceptions;
using Volo.Abp.Application.Dtos;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace DoctorAsh.Appointments
{
    public class AppointmentAppServiceTests : DoctorAshApplicationTestBase
    {
        private readonly IAppointmentAppService _appointmentAppService;

        public AppointmentAppServiceTests()
        {
            _appointmentAppService = GetRequiredService<IAppointmentAppService>();
        }
        [Fact]
        public async Task CreateAsync_Should_ThrowException_If_Given_past_StartDate()
        {
            //Given
            var date = DateTime.Now.AddDays(-5);
            var input = new CreateAppointmentDto
            {
                Title = "Test Appointment",
                Description = "Testing appointmnent",
                StartDate = date,
                EndDate = date.AddDays(10),
                Recurrence = RecurrenceType.Annually,
            };
            //When
            var exception = await Assert.ThrowsAsync<InvalidStartDateException>(async () =>
            {
                // statement that throws exception comes here
                await _appointmentAppService.CreateAsync(input);
            });

            // exception.Code.ShouldBe("YourExceptionCode");
            exception.Code.ShouldBe(DoctorAshDomainErrorCodes.InvalidStartDateException);
            //Then
        }

        [Fact]
        public async Task CreateAsync_Should_ThrowException_If_Given_EndDate_LessThan_StartDate()
        {
            //Given
            var date = DateTime.Now.AddDays(5);
            var input = new CreateAppointmentDto
            {
                Title = "Test Appointment",
                Description = "Testing appointmnent",
                StartDate = date,
                EndDate = date,
                Recurrence = RecurrenceType.Annually,
            };
            //When
            var exception = await Assert.ThrowsAsync<InvalidEndDateException>(async () =>
            {
                // statement that throws exception comes here
                await _appointmentAppService.CreateAsync(input);
            });

            // exception.Code.ShouldBe("YourExceptionCode");
            exception.Code.ShouldBe(DoctorAshDomainErrorCodes.InvalidEndDateException);
            //Then
        }
        [Fact]
        public async Task CreateAsync_GivenFutureStartDate_ReturnNewAppointment()
        {
            //Given
            var date = DateTime.Now.AddDays(5);
            var input = new CreateAppointmentDto
            {
                Title = "Test Appointment",
                Description = "Testing appointmnent",
                StartDate = date,
                EndDate = date.AddDays(10),
                Recurrence = RecurrenceType.Annually,
            };

            //When
            var result = await _appointmentAppService.CreateAsync(input);
            //Then

            result.ShouldNotBeNull();
            result.Title.ShouldBe(input.Title);
            result.Description.ShouldBe(input.Description);
            result.StartDate.ShouldBe(input.StartDate);
            result.EndDate.ShouldBe(input.EndDate);
            result.Status.ShouldBe(StatusType.AwaitingApproval);
            result.Recurrence.ShouldBe(RecurrenceType.Annually);
        }

        [Fact]
        public async Task GetListAsync_Should_Return_ListOfAppointments()
        {
            var result = await _appointmentAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            result.TotalCount.ShouldBeGreaterThan(0);
        }
        [Fact]
        public async Task GetAsync_GivenValidAppointmentId_Should_ReturnAppointment()
        {
            //Given
            var appointments = await _appointmentAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            var appointmentId = appointments.Items.First().Id;
            //When
            var result = await _appointmentAppService.GetAsync(appointmentId);
            //Then
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task GetAsync_GivenInvalidId_ThrowEntityNotFoundException()
        {
            var invalidId = Guid.NewGuid();
            await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
            {
                await _appointmentAppService.GetAsync(invalidId);
            });
        }

        [Fact]
        public async Task RescheduleAsync_ShouldReschedule_ReturnAppointmentWithNewDate()
        {
            //Given
            var date = DateTime.Now.AddDays(5);

            var input = new CreateAppointmentDto
            {
                Title = "Test Appointment",
                Description = "Testing appointmnent",
                StartDate = date,
                EndDate = date.AddDays(10),
                Recurrence = RecurrenceType.Annually,
            };

            var appointment = await _appointmentAppService.CreateAsync(input);

            var rescheduleInput = new RescheduleAppointmentDto
            {
                NewDate = date.AddMonths(1),
                NewEndDate = date.AddMonths(2),
                Reason = "I am away I wont make it on this day"
            };
            //When
            var result = await _appointmentAppService.RescheduleAsync(appointment.Id, rescheduleInput);
            //Then
            result.StartDate.ShouldBe(rescheduleInput.NewDate);
            result.EndDate.ShouldBe(rescheduleInput.NewEndDate);
            result.Status.ShouldBe(StatusType.AwaitingApproval);
        }

        [Fact]
        public async Task RescheduleAsync_GivenInvalidDate_ThrowException()
        {
            //Given
            var date = DateTime.Now.AddDays(5);

            var input = new CreateAppointmentDto
            {
                Title = "Test Appointment",
                Description = "Testing appointmnent",
                StartDate = date,
                EndDate = date.AddDays(10),
                Recurrence = RecurrenceType.Annually,
            };

            var appointment = await _appointmentAppService.CreateAsync(input);

            var rescheduleInput = new RescheduleAppointmentDto
            {
                NewDate = date.AddMonths(-1),
                NewEndDate = date,
                Reason = "I am away I wont make it on this day"
            };
            //When
            var exception = await Assert.ThrowsAnyAsync<BusinessException>(async () =>
            {
                // statement that throws exception comes here
                var result = await _appointmentAppService.RescheduleAsync(appointment.Id, rescheduleInput);
            });

            exception.ShouldNotBeOfType<BusinessException>();
        }
        [Fact]
        public async Task CancelAppointment_GivenActiveAppointment_Should_Cancel_Appointment()
        {
            //Given
            var input = new PagedAndSortedResultRequestDto();
            var appointments = await _appointmentAppService.GetListAsync(input);
            //When
            var cancelInput = new CancelAppointmentDto
            {
                Reason = "Stuck in Traffic"
            };

            var result = await _appointmentAppService.CancelAsync(appointments.Items.First().Id, cancelInput);

            //Then
            result.ShouldNotBeNull();
            result.Status.ShouldBe(StatusType.Cancelled);

        }
    }
}
