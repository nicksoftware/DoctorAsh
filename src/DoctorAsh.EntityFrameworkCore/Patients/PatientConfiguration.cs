using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DoctorAsh.Patients
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
                builder.ToTable(DoctorAshConsts.DbTablePrefix + "Patients", DoctorAshConsts.DbSchema);
                builder.ConfigureByConvention(); 
                builder.HasMany(x=>x.Appointments);
        }
    }
}