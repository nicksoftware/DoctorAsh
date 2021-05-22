using System;
using System.Collections.Generic;
using System.ComponentModel;
using DoctorAsh.Appointments.Dtos;

namespace DoctorAsh.Doctors.Dtos
{
    [Serializable]
    public class CreateUpdateDoctorDto
    {
        public ICollection<AppointmentDto> Appointments { get; set; }

        public ICollection<WorkingHourDto> WorkingHours { get; set; }

        public AvailablityStatusType Status { get; set; }

        public double RatingScore { get; set; }
    }
}