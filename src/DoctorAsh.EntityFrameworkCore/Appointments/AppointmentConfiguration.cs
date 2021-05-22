using System;
using DoctorAsh.Doctors;
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
            
            b.HasOne<Doctor>().WithMany().HasForeignKey(x => x.DoctorId).IsRequired();
        }
    }
}