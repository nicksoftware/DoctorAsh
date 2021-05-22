using System;
using System.Threading.Tasks;
using DoctorAsh.Doctors;
using DoctorAsh.Emailing;
using DoctorAsh.Patients;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.EventBus;
using Volo.Abp.Users;

namespace DoctorAsh.Appointments.Events
{
    public class AppointmentCancelled:IAppointmentEventData
    {
        public AppointmentCancelled(Guid id, string reason,DateTime cancellationDate)
        {
            AppointmentId = id;
            Reason = reason;
            CancellationDate = cancellationDate;
        }
        public Guid AppointmentId { get; init; }
        public string Reason { get; init; }
        public DateTime CancellationDate { get; init; }
    }

    public class AppointmentCancelledHandler : AppointmentEventHandler<AppointmentCancelled>
    {

            public AppointmentCancelledHandler(
                IExternalUserLookupServiceProvider userLookupServiceProvider, 
                IBackgroundJobManager backgroundJobManager,
                IAppointmentRepository appointmentRepository,
                IDoctorRepository doctorRepository, 
                IPatientRepository patientRepository)
                : base(
                    userLookupServiceProvider,
                    backgroundJobManager,
                    appointmentRepository,
                    doctorRepository,
                    patientRepository)
            {
            }
        protected override async Task SendPatientEmailAsync()
            {
                var data =(AppointmentCancelled) EventData;
                var cancellationDate = data.CancellationDate.ToString("dddd , dd MMMM yyyy");
                var cancellationTime = data.CancellationDate.ToString("hh:mm tt");
                
                var emailBody = $"<p>Your Appointment with Doctor {GetDoctorFullNames()} ,has been Cancelled</p>"+
                $"Reason for cancellation {data.Reason},  date of cancellation {cancellationDate},time of cancellation {cancellationTime} ";
                
                await  BackgroundJobManager.EnqueueAsync(
                    new EmailSendingArgs
                    {
                        EmailAddress = PatientUser.Email,
                        Subject = "Appointment Cancelled",
                        Body = emailBody
                    }
                );
            }
            
            protected override async Task SendDoctorEmailAsync()
            {
                var emailBody = $"<p>Doctor {GetDoctorFullNames()} Your Appointment with Patient {GetPatientFullNames()} ,has been Cancelled</p>";

                await  BackgroundJobManager.EnqueueAsync(
                    new EmailSendingArgs
                    {
                        EmailAddress = DoctorUser.Email,
                        Subject = "Appointment Cancelled",
                        Body = emailBody
                    }
                );
            }
    }
}