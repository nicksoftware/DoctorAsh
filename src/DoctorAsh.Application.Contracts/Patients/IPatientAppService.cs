using System;
using DoctorAsh.Patients.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DoctorAsh.Patients
{
    public interface IPatientAppService :
        ICrudAppService< 
            PatientDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdatePatientDto,
            CreateUpdatePatientDto>
    {

    }
}