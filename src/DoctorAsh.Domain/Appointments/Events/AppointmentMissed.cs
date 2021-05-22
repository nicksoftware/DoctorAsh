using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;

namespace DoctorAsh.Appointments.Events
{
    public class AppointmentMissed
    {
        public AppointmentMissed(Guid appointmentId)
        {
            AppointmentId = appointmentId;
        }
        public Guid AppointmentId { get;}
        public class AppointmentMissedEventHandler : ILocalEventHandler<AppointmentMissed>, ITransientDependency
        {
            public Task HandleEventAsync(AppointmentMissed eventData)
            {
                //Notify Users That Apppointment has been Missed
                throw new System.NotImplementedException();
            }
        }
    }
}