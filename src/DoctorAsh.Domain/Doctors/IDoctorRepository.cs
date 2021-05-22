using System;
using Volo.Abp.Domain.Repositories;

namespace DoctorAsh.Doctors
{
    public interface IDoctorRepository : IRepository<Doctor, Guid>
    {
    }
}