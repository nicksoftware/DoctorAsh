using System;
using System.Threading.Tasks;
using DoctorAsh.Emailing;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.EventBus;
using Volo.Abp.Users;

namespace DoctorAsh.Appointments.Events
{
    public class AppointmentCancelled
    {
        public AppointmentCancelled(Guid id, string reason)
        {
            AppointmentId = id;
            Reason = reason;
        }
        public Guid AppointmentId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientdId { get; set; }
        public string Reason { get; set; }
    }

    public class AppointmentCancelledHandler : ILocalEventHandler<AppointmentCancelled>
    {
        private readonly IExternalUserLookupServiceProvider _userLookupServiceProvider;
        private readonly IBackgroundJobManager _backgroundJobManager;
        private readonly IAppointmentRepository _appointmentRepository;
            private Guid _appointmentId = Guid.Empty;

        public AppointmentCancelledHandler( 
            IExternalUserLookupServiceProvider userLookupServiceProvider,
            IBackgroundJobManager  backgroundJobManager,
            IAppointmentRepository appointmentRepository)
        {
            _userLookupServiceProvider = userLookupServiceProvider;
            _backgroundJobManager = backgroundJobManager;
            _appointmentRepository = appointmentRepository;
        }
        public async Task HandleEventAsync(AppointmentCancelled eventData)
        {
            try
            {
                _appointmentId = eventData.AppointmentId;
                //Notify Patient and Doctor
                await SendDoctorEmailAsync(eventData.DoctorId);
                await SendPatientEmailAsync(eventData.PatientdId);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        private async Task SendPatientEmailAsync(Guid patientId)
            {
                
                // var patient =await _patientService.FindAsync(eventData.PatientId);
                //var patientUser = _userLookupServiceProvider.FindByIdAsync(patient.UserId);
                var emailBody = "<p>Your Appointment with Doctor **** ,has been ReActivated</p>";
                var patientEmail = string.Empty;

                await  _backgroundJobManager.EnqueueAsync(
                    new EmailSendingArgs
                    {
                        EmailAddress = patientEmail,
                        Subject = "Appointment Reactivated",
                        Body = emailBody
                    }
                );
            }
            private async Task SendDoctorEmailAsync(Guid doctorId)
            {
                // var doctor =await _doctorService.FindAsync(eventData.DoctorId);
                // var doctorUser = _userLookupServiceProvider.FindByIdAsync(doctor.UserId);
                var emailBody = "<p>Doctor *** Your Appointment with Patient **** ,has been ReActivated</p>";
                var patientEmail = string.Empty;

                await  _backgroundJobManager.EnqueueAsync(
                    new EmailSendingArgs
                    {
                        EmailAddress = patientEmail,
                        Subject = "Appointment Reactivated",
                        Body = emailBody
                    }
                );
            }
    }
}