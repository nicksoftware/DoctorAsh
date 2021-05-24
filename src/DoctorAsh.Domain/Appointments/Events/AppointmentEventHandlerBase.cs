using System;
using System.Threading.Tasks;
using DoctorAsh.Doctors;
using DoctorAsh.Patients;
using Microsoft.Extensions.Logging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.Users;

namespace DoctorAsh.Appointments.Events
{
    public abstract class AppointmentEventHandler<T>: ILocalEventHandler<IAppointmentEventData>,ITransientDependency
    {
        protected IBackgroundJobManager BackgroundJobManager {get;set;}
        protected IAppointmentRepository AppointmentRepository {get;set;}
        protected IDoctorRepository DoctorRepository {get;set;}
        protected IPatientRepository PatientRepository {get;set;}
        protected IExternalUserLookupServiceProvider UserLookupServiceProvider{get;set;}
        protected Appointment Appointment = null;
        protected IUserData DoctorUser =null;
        protected IUserData PatientUser = null;
        protected IAppointmentEventData EventData = null;
        protected readonly ILogger<AppointmentEventHandler<T>> Logger;

        public AppointmentEventHandler(
            IExternalUserLookupServiceProvider userLookupServiceProvider,
            IBackgroundJobManager  backgroundJobManager,
            IAppointmentRepository appointmentRepository,
            IDoctorRepository doctorRepository,
            IPatientRepository patientRepository,ILogger<AppointmentEventHandler<T>> logger)
        {
            UserLookupServiceProvider = userLookupServiceProvider;
            BackgroundJobManager = backgroundJobManager;
            AppointmentRepository = appointmentRepository;
            DoctorRepository = doctorRepository;
            PatientRepository = patientRepository;
            Logger = logger;
        }
        public virtual async Task HandleEventAsync(IAppointmentEventData eventData)
        {
            try
            {
                await InitialProperties(eventData);
                await TrySendDoctorEmailAsync();
                await TrySendPatientEmailAsync();
            }
            catch (System.Exception ex)
            {
                Logger.LogException(ex,LogLevel.Error);
                throw;
            }
        }

        protected virtual async Task InitialProperties(IAppointmentEventData eventData)
        {
            EventData = eventData;
            Appointment = await AppointmentRepository.FindAsync(eventData.AppointmentId);
            var doctor = await DoctorRepository.FindAsync(Appointment.DoctorId);
            var patient = await PatientRepository.FindAsync(Appointment.PatientId);
            DoctorUser = await UserLookupServiceProvider.FindByIdAsync(doctor.UserId);
            PatientUser = await UserLookupServiceProvider.FindByIdAsync(patient.UserId);
        }

        protected virtual async Task TrySendPatientEmailAsync()
        {
            if (PatientUser.EmailConfirmed)
            {
                Logger.LogInformation($" Send Email Job : To Patient {GetPatientFullNames()} ,Email  {PatientUser.Email}");
                await SendPatientEmailAsync();
            }
            else
                Logger.LogWarning($"Failed to send Email : User {PatientUser.Id} has not Confirmed Email");
        }

        protected virtual async Task TrySendDoctorEmailAsync()
        {
            if (DoctorUser.EmailConfirmed)
            {
                Logger.LogInformation($" Send Email Job : To Dr {GetDoctorFullNames()} , email - {DoctorUser.Email}");
                await SendDoctorEmailAsync();
            }
            else
                Logger.LogWarning($"Failed to send Email : User {DoctorUser.Id} has not Confirmed Email");
        }

        protected abstract Task SendPatientEmailAsync();
        protected abstract Task SendDoctorEmailAsync();
        protected virtual string GetDoctorFullNames()=> $"{DoctorUser.Name} {DoctorUser.Surname}";
        protected virtual string GetPatientFullNames()=> $"{PatientUser.Name} {PatientUser.Surname}";
    }
}