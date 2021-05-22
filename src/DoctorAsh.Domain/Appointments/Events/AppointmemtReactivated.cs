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
    public class AppointmemtReactivated
    {

        public AppointmemtReactivated(Guid id) => AppointmentId = id;
        public Guid AppointmentId { get; init; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }


        public class AppointmentReactivatedHandler : AppointmentEventHandler<AppointmemtReactivated>
        {
            public AppointmentReactivatedHandler(
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
                var emailBody =
                    $"<p>Your Appointment with Dr {DoctorUser.Name} {DoctorUser.Surname} ,"+
                    $"has been ReActivated,and it is set for {Appointment.StartDate.ToString("dddd, dd MMMM yyyy")} at {Appointment.StartDate.ToString("hh:mm tt")} </p>";

                await  BackgroundJobManager.EnqueueAsync(
                    new EmailSendingArgs
                    {
                        EmailAddress = PatientUser.Email,
                        Subject = "Appointment Reactivated",
                        Body = emailBody
                    }
                );
            }

            protected override async Task SendDoctorEmailAsync()
            {
                var emailBody =
                $"<p>Doctor *** Your Appointment with Patient {PatientUser.Name} {PatientUser.Surname} ,has been ReActivated</p>"+
                $"<p>and it is set for {Appointment.StartDate.ToString("dddd, dd MMMM yyyy")} at {Appointment.StartDate.ToString("hh:mm tt")} </p>";

                await  BackgroundJobManager.EnqueueAsync(
                    new EmailSendingArgs
                    {
                        EmailAddress = DoctorUser.Email,
                        Subject = "Appointment Reactivated",
                        Body = emailBody
                    }
                );
            }
        }
    }
}