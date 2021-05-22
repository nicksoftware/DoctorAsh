using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;

namespace DoctorAsh.Appointments.Events
{
    public class AppointmentUpdatedHandler :
    ILocalEventHandler<EntityUpdatedEventData<Appointment>>,
    ITransientDependency
    {
        public Task HandleEventAsync(EntityUpdatedEventData<Appointment> eventData) 
        {
            return Task.CompletedTask;
        }    
    }
}