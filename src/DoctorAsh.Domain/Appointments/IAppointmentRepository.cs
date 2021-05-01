using System;
using Volo.Abp.Domain.Repositories;

namespace DoctorAsh.Appointments
{
    public interface IAppointmentRepository : IRepository<Appointment, Guid>
    {
    }
}