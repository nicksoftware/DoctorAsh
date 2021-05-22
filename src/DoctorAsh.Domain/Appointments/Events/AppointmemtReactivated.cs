using System;
using System.Threading.Tasks;
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

        public class AppointmentReactivatedHandler : ILocalEventHandler<AppointmemtReactivated>
        {
            private readonly IExternalUserLookupServiceProvider _userLookupServiceProvider;
            private readonly IBackgroundJobManager _backgroundJobManager;

            public AppointmentReactivatedHandler(IExternalUserLookupServiceProvider userLookupServiceProvider,
            IBackgroundJobManager  backgroundJobManager)
            {
                _userLookupServiceProvider = userLookupServiceProvider;
                _backgroundJobManager = backgroundJobManager;
            }
            public Task HandleEventAsync(AppointmemtReactivated eventData)
            {
                //Notify Patient and Doctor

                throw new NotImplementedException();
            }
        }
    }
}