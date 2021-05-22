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
        public void Configure(EntityTypeBuilder<Appointment> b)
        {
            b.ToTable(DoctorAshConsts.DbTablePrefix + "Appointments", DoctorAshConsts.DbSchema);

            b.ConfigureByConvention();

            b.Property(x => x.Title).IsRequired().HasMaxLength(AppointmentConsts.TitleMaxLength);

            b.Property(x => x.Description).IsRequired().HasMaxLength(AppointmentConsts.DescriptionMaxLength);
            
            b.HasOne<Doctor>().WithMany(x=>x.Appointments).HasForeignKey(x => x.DoctorId).IsRequired();
            
            b.HasOne<Patient>().WithMany(x=>x.Appointments).HasForeignKey(x=>x.PatientId).IsRequired();
        }
    }
}