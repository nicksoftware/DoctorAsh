using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DoctorAsh.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Timing;

namespace DoctorAsh.Appointments
{
    public class AppointmentRepository : EfCoreRepository<DoctorAshDbContext, Appointment, Guid>, IAppointmentRepository
    {
        private readonly IClock _clock;

        public AppointmentRepository(IDbContextProvider<DoctorAshDbContext> dbContextProvider,IClock clock) : base(dbContextProvider)
        {
            _clock = clock;
        }

        public async Task UpdateMissedAppointmentsAsync()
        {
            var dbSet = await GetDbSetAsync();
            

            var appointments = dbSet
            .Where(new AppointmentDateOverDueSpecification(_clock)).ToList();

            appointments.ForEach(appointment => appointment.SetToMissed());
            
            await UpdateManyAsync(appointments,true);
        }

        // public  async Task<IEnumerable<Appointment>> GetUserCurrentAppointmentsAsync(
        //     int skipCount,
        //     int maxResultCount,
        //     string sorting,
        //     bool includeDetails = false,
        //     CancellationToken cancellationToken = default)
        // {
        //     var dbSet = await GetDbSetAsync();
        //     return dbSet.Where(x=>x.CreatorId == )
        //     throw new NotImplementedException();
        // }
    }
}