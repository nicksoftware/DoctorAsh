using System;
using DoctorAsh.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DoctorAsh.Patients
{
    public class PatientRepository : EfCoreRepository<DoctorAshDbContext, Patient, Guid>, IPatientRepository
    {
        public PatientRepository(IDbContextProvider<DoctorAshDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}