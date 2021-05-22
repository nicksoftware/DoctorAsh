using System;
using DoctorAsh.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DoctorAsh.Doctors
{
    public class DoctorRepository : EfCoreRepository<DoctorAshDbContext, Doctor, Guid>, IDoctorRepository
    {
        public DoctorRepository(IDbContextProvider<DoctorAshDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}