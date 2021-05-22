using DoctorAsh.Patients;
using DoctorAsh.Doctors;
using System.Reflection;
using DoctorAsh.Appointments;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DoctorAsh.EntityFrameworkCore
{
    public static class DoctorAshDbContextModelCreatingExtensions
    {
        public static void ConfigureDoctorAsh(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
