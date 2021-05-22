using DoctorAsh.Appointments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DoctorAsh.Doctors
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> b)
        {
            b.ToTable(DoctorAshConsts.DbTablePrefix + "Doctors", DoctorAshConsts.DbSchema);
            b.ConfigureByConvention(); 
            b.HasMany<Appointment>(x=>x.Appointments);
        }
    }
}