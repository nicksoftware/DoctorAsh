using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DoctorAsh.Appointments;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace DoctorAsh.Doctors
{
    public class Doctor: FullAuditedAggregateRoot<Guid>
    {
        protected Doctor(){}
        private Doctor(Guid id,Guid userId):base(id)=> UserId = userId;

        public static Doctor Create(Guid id,Guid userId)
        {

            return new Doctor(id,userId);

        }
        public Guid UserId { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new Collection<Appointment>();
        public ICollection<WorkingHour> WorkingHours{get;set;} = new Collection<WorkingHour>();
        public AvailablityStatusType Status { get; set; }
        public double RatingScore { get; set; }

        public Doctor(
            Guid id,
            ICollection<WorkingHour> workingHours,
            AvailablityStatusType status,
            double ratingScore
        ) : base(id)
        {
            WorkingHours = workingHours;
            Status = status;
            RatingScore = ratingScore;
        }

        public void AddWorkingHour(WorkingHour workingHour)
        {

            var dayWorkingOurExists =
                WorkingHours
                .SingleOrDefault(d=>d.Day == workingHour.Day);   

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
