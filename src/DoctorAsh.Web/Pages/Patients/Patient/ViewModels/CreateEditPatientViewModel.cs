using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DoctorAsh.Appointments.Dtos;

namespace DoctorAsh.Web.Pages.Patients.Patient.ViewModels
{
    public class CreateEditPatientViewModel
    {
        [Display(Name = "PatientAppointments")]
        public ICollection<AppointmentDto> Appointments { get; set; }
    }
}