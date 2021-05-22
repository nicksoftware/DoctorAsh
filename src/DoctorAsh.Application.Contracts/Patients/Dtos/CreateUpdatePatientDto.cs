using System;
using System.Collections.Generic;
using System.ComponentModel;
using DoctorAsh.Appointments.Dtos;

namespace DoctorAsh.Patients.Dtos
{
    [Serializable]
    public class CreateUpdatePatientDto
    {
        public ICollection<AppointmentDto> Appointments { get; set; }
    }
}