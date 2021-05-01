using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;

namespace DoctorAsh.Appointments
{
    public interface IAppointmentRepository : IRepository<Appointment, Guid>
    {

    }
}