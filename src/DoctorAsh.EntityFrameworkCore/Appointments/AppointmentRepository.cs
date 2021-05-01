using System;
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
    }
}