using DoctorAsh.Appointments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DoctorAsh.Doctors
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable(DoctorAshConsts.DbTablePrefix + "Doctors", DoctorAshConsts.DbSchema);
            builder.ConfigureByConvention(); 
            builder.HasMany<Appointment>(x=>x.Appointments);
        }
    }
}