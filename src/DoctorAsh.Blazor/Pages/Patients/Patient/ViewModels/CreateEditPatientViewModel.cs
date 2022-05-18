using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DoctorAsh.Appointments.Dtos;

namespace DoctorAsh.Blazor.Pages.Patients.Patient.ViewModels
{
    public class CreateEditPatientViewModel
    {
        [Display(Name = "PatientAppointments")]
        public ICollection<AppointmentDto> Appointments { get; set; }
    }
}