using System;
using System.Threading.Tasks;
using DoctorAsh.Doctors;
using DoctorAsh.Emailing;
using DoctorAsh.Patients;
using Microsoft.Extensions.Logging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.Users;

namespace DoctorAsh.Appointments.Events
{
    public class AppointmentRescheduled : IAppointmentEventData
    {
        public AppointmentRescheduled(Guid appointmentId)
        {
            AppointmentId = appointmentId;
        }
        public Guid AppointmentId { get; init; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public string Reason { get; set; }
        public DateTime OldDate { get; set; }
        public DateTime NewDate { get; set; }

    }

    public class AppointmentRescheduledHandler :
        AppointmentEventHandler<AppointmentRescheduled>
    {
        public AppointmentRescheduledHandler(IExternalUserLookupServiceProvider userLookupServiceProvider, IBackgroundJobManager backgroundJobManager, IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository, IPatientRepository patientRepository, ILogger<AppointmentEventHandler<AppointmentRescheduled>> logger) : base(userLookupServiceProvider, backgroundJobManager, appointmentRepository, doctorRepository, patientRepository, logger)
        {
        }

        public override Task HandleEventAsync(IAppointmentEventData eventData)
        {
            Appointment.Status = StatusType.AwaitingApproval;
            AppointmentRepository.UpdateAsync(Appointment, true);
            return base.HandleEventAsync(eventData);
        }
        protected override async Task SendDoctorEmailAsync()
        {
            var emailBody = $"<p>Doctor {GetDoctorFullNames()} Your Appointment with Patient {GetPatientFullNames()} ,has been Rescheduled Please Approve the new Set Date</p>";

            await BackgroundJobManager.EnqueueAsync(
                new EmailSendingArgs
                {
                    EmailAddress = DoctorUser.Email,
                    Subject = "Appointment Rescheduled",
                    Body = emailBody
                }
            );
        }

        protected override async Task SendPatientEmailAsync()
        {
            var emailBody = $"<p>Your Appointment with Doctor {GetDoctorFullNames()} ,has been Rescheduled and is awaitng for approval by Doctor</p>";

            await BackgroundJobManager.EnqueueAsync(
                new EmailSendingArgs
                {
                    EmailAddress = PatientUser.Email,
                    Subject = "Appointment Rescheduled",
                    Body = emailBody
                }
            );
        }
    }
}