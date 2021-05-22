using System;

using System.ComponentModel.DataAnnotations;
using DoctorAsh.Appointments;

namespace DoctorAsh.Web.Pages.Appointments.Appointment.ViewModels
{
    public class CreateEditAppointmentViewModel
    {
        [Required]
        [Display(Name = "AppointmentTitle")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "AppointmentDescription")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "AppointmentStartDate")]
        public DateTime StartDate { get; set; }
        
        [Required]
        [Display(Name = "AppointmentEndDate")]
        public DateTime? EndDate { get; set; }
        
        [Required]
        [Display(Name = "AppointmentRecurrence")]
        public RecurrenceType Recurrence { get; set; }
        
        [Display(Name = "AppointmentStatus")]
        public StatusType Status { get; set; }
    }
}