using System;
using Volo.Abp.Domain.Repositories;

namespace DoctorAsh.Patients
{
    public interface IPatientRepository : IRepository<Patient, Guid>
    {
    }
}