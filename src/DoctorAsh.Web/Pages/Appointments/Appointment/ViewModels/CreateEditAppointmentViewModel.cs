using System;

using System.ComponentModel.DataAnnotations;
using DoctorAsh.Appointments;

namespace DoctorAsh.Web.Pages.Appointments.Appointment.ViewModels
{
    public class CreateEditAppointmentViewModel
    {
        [Display(Name = "AppointmentTitle")]
        public string Title { get; set; }

        [Display(Name = "AppointmentDescription")]
        public string Description { get; set; }

        [Display(Name = "AppointmentStartDate")]
        public DateTime StartDate { get; set; }

        [Display(Name = "AppointmentEndDate")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "AppointmentRecurrence")]
        public RecurrenceType Recurrence { get; set; }

        [Display(Name = "AppointmentStatus")]
        public StatusType Status { get; set; }
    }
}