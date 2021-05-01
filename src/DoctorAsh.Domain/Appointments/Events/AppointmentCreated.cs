using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;

namespace DoctorAsh.Appointments.Events
{
    public class AppointmentCreatedHandler :
        ILocalEventHandler<EntityCreatedEventData<Appointment>>,
        ITransientDependency
    {
        public Task HandleEventAsync(EntityCreatedEventData<Appointment> eventData)
        {
            return Task.CompletedTask;
        }
    }

}