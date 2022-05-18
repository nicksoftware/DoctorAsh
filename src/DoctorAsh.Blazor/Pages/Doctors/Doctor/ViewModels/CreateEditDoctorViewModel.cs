using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DoctorAsh.Appointments.Dtos;
using DoctorAsh.Doctors;
using DoctorAsh.Doctors.Dtos;

namespace DoctorAsh.Blazor.Pages.Doctors.Doctor.ViewModels
{
    public class CreateEditDoctorViewModel
    {
        [Display(Name = "DoctorAppointments")]
        public ICollection<AppointmentDto> Appointments { get; set; }

        [Display(Name = "DoctorWorkingHours")]
        public ICollection<WorkingHourDto> WorkingHours { get; set; }

        [Display(Name = "DoctorStatus")]
        public AvailablityStatusType Status { get; set; }

        [Display(Name = "DoctorRatingScore")]
        public double RatingScore { get; set; }
    }
}