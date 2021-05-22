using System;
using System.Threading.Tasks;
using Volo.Abp.EventBus;

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
        public Task HandleEventAsync(AppointmentCancelled eventData) =>
            throw new NotImplementedException();
    }
}