using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DoctorAsh.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DoctorAsh.Appointments
{
    public class AppointmentRepository : EfCoreRepository<DoctorAshDbContext, Appointment, Guid>, IAppointmentRepository
    {
        public AppointmentRepository(IDbContextProvider<DoctorAshDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task UpdateMissedAppointmentsAsync()
        {
            var dbSet = await GetDbSetAsync();

            var appointments = dbSet.Where(x=>!x.IsCancelled && x.Status != StatusType.Missed).ToList();

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