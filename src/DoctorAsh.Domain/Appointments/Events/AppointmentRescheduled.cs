using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;

namespace DoctorAsh.Appointments.Events
{
    public class AppointmentRescheduled
    {
        public Guid AppointmentId { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public string Reason { get; set; }
        public DateTime OldDate { get; set; }
        public DateTime NewDate { get; set; }

    }

    public class AppointmentRescheduledHandler :
        ILocalEventHandler<AppointmentRescheduled>,
        ITransientDependency
    {
        public Task HandleEventAsync(AppointmentRescheduled eventData)
        {   
            try
            {
                //Notify  Patient of changes 
                //Change appointment status to waitingForApproval
                // Ask Doctor to Approve Rescheduling   
            }
            catch (System.Exception)
            {
                throw;
            }


            return Task.CompletedTask;
        }
    }
}