using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DoctorAsh.Appointments
{
    public static class AppointmentEfCoreQueryableExtensions
    {
        public static IQueryable<Appointment> IncludeDetails(this IQueryable<Appointment> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                // .Include(x => x.xxx) // TODO: AbpHelper generated
                ;
        }
    }
}