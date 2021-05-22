using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Threading;

namespace DoctorAsh.Appointments
{
    public class MissedApointmentChecerkWorker : AsyncPeriodicBackgroundWorkerBase
    {
        public MissedApointmentChecerkWorker(AbpAsyncTimer timer, IServiceScopeFactory serviceScopeFactory)
        : base(timer, serviceScopeFactory)
        {
            Timer.Period = 600000; //10 minutes
        }
        protected override async Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
        {

            var appointmentRepository = workerContext.ServiceProvider
                .GetRequiredService<IAppointmentRepository>();

            await appointmentRepository.UpdateMissedAppointmentsAsync();
            
        }
    }
}