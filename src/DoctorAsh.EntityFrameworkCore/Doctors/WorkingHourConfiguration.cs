using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DoctorAsh.Doctors
{
    public class WorkingHourConfiguration : IEntityTypeConfiguration<WorkingHour>
    {
        public void Configure(EntityTypeBuilder<WorkingHour> b)
        {
            b.ToTable(DoctorAshConsts.DbTablePrefix + "WorkingHours", DoctorAshConsts.DbSchema);
            b.ConfigureByConvention();
            
            b.HasOne<Doctor>().WithMany(x=>x.WorkingHours).HasForeignKey(x=>x.DoctorId).IsRequired();
        }
    }
}