using System;
using System.Collections.Generic;
using System.Linq;
using DoctorAsh.Appointments;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace DoctorAsh.Doctors
{
    public class Doctor: FullAuditedAggregateRoot<Guid>
    {
        protected Doctor(){}
        internal Doctor(Guid id):base(id){}
        public Guid UserId { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<WorkingHour> WorkingHours{get;set;}
        public AvailablityStatusType Status { get; set; }
        public double RatingScore { get; set; }

        public Doctor(
            Guid id,
            ICollection<Appointment> appointments,
            ICollection<WorkingHour> workingHours,
            AvailablityStatusType status,
            double ratingScore
        ) : base(id)
        {
            Appointments = appointments;
            WorkingHours = workingHours;
            Status = status;
            RatingScore = ratingScore;
        }

        public void AddWorkingHour(WorkingHour workingHour)
        {
            var dayWorkingOurExists =  WorkingHours.SingleOrDefault(d=>d.Day == workingHour.Day);

            if(dayWorkingOurExists != null) 
                throw new WorkingHourForDayGivenAlreadySetException(workingHour.Day);

            WorkingHours.Add(workingHour);
        }

        public void RemoveWorkingHour(WorkingHour workingHour)
        {
            var workingOurExists =  WorkingHours.SingleOrDefault(d=>d.Id == workingHour.Id);

            if(workingOurExists == null) 
            throw new UserFriendlyException("Working hour doesnt exist");

            WorkingHours.Remove(workingHour);
        }

        public void ChangeWorkingHour(WorkingHour workingHour)
        {
            var workingOurExists =  WorkingHours.SingleOrDefault(d=>d.Id == workingHour.Id);

            if(workingOurExists == null) 
            throw new UserFriendlyException("Working hour doesnt exist");

            WorkingHours.Remove(workingOurExists);
            WorkingHours.Add(workingHour);
        }
    }
}
