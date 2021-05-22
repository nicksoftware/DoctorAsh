using System;
using DoctorAsh.Doctors;
using DoctorAsh.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DoctorAsh.Appointments
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable(DoctorAshConsts.DbTablePrefix + "Appointments", DoctorAshConsts.DbSchema);

            builder.ConfigureByConvention();

            builder.Property(x => x.Title).IsRequired().HasMaxLength(AppointmentConsts.TitleMaxLength);

            builder.Property(x => x.Description).IsRequired().HasMaxLength(AppointmentConsts.DescriptionMaxLength);
            
            builder.HasOne<Doctor>().WithMany(x=>x.Appointments).HasForeignKey(x => x.DoctorId).IsRequired();
            
            builder.HasOne<Patient>().WithMany(x=>x.Appointments).HasForeignKey(x=>x.PatientId).IsRequired();
        }
    }
}