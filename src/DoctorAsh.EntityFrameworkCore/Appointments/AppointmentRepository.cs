using System;
using System.Collections.Generic;
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

        // public override Task<List<Appointment>> GetUserAppointmentsAsync(
        //     int skipCount,
        //     int maxResultCount,
        //     string sorting,
        //     bool includeDetails = false,
        //     CancellationToken cancellationToken = default)
        // {
        // }
    }
}