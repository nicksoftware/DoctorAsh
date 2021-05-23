using System;
using System.Threading.Tasks;
using DoctorAsh.Doctors;
using DoctorAsh.Emailing;
using DoctorAsh.Patients;
using Microsoft.Extensions.Logging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using Volo.Abp.Users;

namespace DoctorAsh.Appointments.Events
{
    public class AppointmentCreated : EntityChangedEventData<Appointment>, IAppointmentEventData
    {
        public AppointmentCreated(Appointment entity) : base(entity)
        {
        }

        public Guid AppointmentId { get ; init; }
    }
    public class AppointmentCreatedHandler : AppointmentEventHandler<AppointmentCreated>
    {

        private readonly IExternalUserLookupServiceProvider _userLookupServiceProvider;
        private readonly IBackgroundJobManager _backgroundJobManager;
        private readonly IAppointmentRepository _appointmentRepository;
        private Guid _appointmentId = Guid.Empty;

        public AppointmentCreatedHandler(IExternalUserLookupServiceProvider userLookupServiceProvider, IBackgroundJobManager backgroundJobManager, IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository, IPatientRepository patientRepository, ILogger<AppointmentEventHandler<AppointmentCreated>> logger) : base(userLookupServiceProvider, backgroundJobManager, appointmentRepository, doctorRepository, patientRepository, logger)
        {
        }

        protected override async Task SendDoctorEmailAsync()
        {
            var emailBody = $"<p>Doctor {GetDoctorFullNames()} Your Appointment with Patient {GetPatientFullNames()} ,has been Created</p>";

                await  BackgroundJobManager.EnqueueAsync(
                    new EmailSendingArgs
                    {
                        EmailAddress = DoctorUser.Email,
                        Subject = "Appointment Created",
                        Body = emailBody
                    }
                );
        }

        protected override async Task SendPatientEmailAsync()
        {
            var emailBody = $"<p>Your Appointment with Doctor {GetDoctorFullNames()} ,has been Created</p>";
            await  BackgroundJobManager.EnqueueAsync(
                new EmailSendingArgs
                {
                    EmailAddress = PatientUser.Email,
                    Subject = "Appointment Created",
                    Body = emailBody
                }
            );
        }
    }

}