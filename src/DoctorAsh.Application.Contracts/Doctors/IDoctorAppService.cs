using System;
using DoctorAsh.Doctors.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DoctorAsh.Doctors
{
    public interface IDoctorAppService :
        ICrudAppService< 
            DoctorDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateDoctorDto,
            CreateUpdateDoctorDto>
    {

    }
}