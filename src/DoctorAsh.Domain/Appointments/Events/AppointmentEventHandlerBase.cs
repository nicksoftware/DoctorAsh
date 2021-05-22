using System;
using System.Threading.Tasks;
using DoctorAsh.Doctors;
using DoctorAsh.Patients;
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

        public AppointmentEventHandler(
            IExternalUserLookupServiceProvider userLookupServiceProvider,
            IBackgroundJobManager  backgroundJobManager,
            IAppointmentRepository appointmentRepository,
            IDoctorRepository doctorRepository,
            IPatientRepository patientRepository)
        {
            UserLookupServiceProvider = userLookupServiceProvider;
            BackgroundJobManager = backgroundJobManager;
            AppointmentRepository = appointmentRepository;
            DoctorRepository = doctorRepository;
            PatientRepository = patientRepository;
        }
        protected abstract Task SendPatientEmailAsync();
        protected abstract Task SendDoctorEmailAsync();
        public virtual async Task HandleEventAsync(IAppointmentEventData eventData)
        {
            try
            {
                EventData = (IAppointmentEventData)(T) eventData;
                Appointment = await AppointmentRepository.FindAsync(eventData.AppointmentId);
                var doctor = await DoctorRepository.FindAsync(Appointment.DoctorId);
                var patient = await PatientRepository.FindAsync(Appointment.PatientId); 
                DoctorUser= await UserLookupServiceProvider.FindByIdAsync(doctor.UserId);
                PatientUser= await UserLookupServiceProvider.FindByIdAsync(patient.UserId);
                
                await SendDoctorEmailAsync();
                await SendPatientEmailAsync();  
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        protected virtual string GetDoctorFullNames()=> $"{DoctorUser.Name} {DoctorUser.Surname}";
        protected virtual string GetPatientFullNames()=> $"{PatientUser.Name} {PatientUser.Surname}";
    }
}