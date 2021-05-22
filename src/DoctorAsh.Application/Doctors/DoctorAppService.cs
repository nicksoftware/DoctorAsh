using System;
using DoctorAsh.Permissions;
using DoctorAsh.Doctors.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DoctorAsh.Doctors
{
    public class DoctorAppService : CrudAppService<Doctor, DoctorDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateDoctorDto, CreateUpdateDoctorDto>,
        IDoctorAppService
    {
        protected override string GetPolicyName { get; set; } = DoctorAshPermissions.Doctor.Default;
        protected override string GetListPolicyName { get; set; } = DoctorAshPermissions.Doctor.Default;
        protected override string CreatePolicyName { get; set; } = DoctorAshPermissions.Doctor.Create;
        protected override string UpdatePolicyName { get; set; } = DoctorAshPermissions.Doctor.Update;
        protected override string DeletePolicyName { get; set; } = DoctorAshPermissions.Doctor.Delete;

        private readonly IDoctorRepository _repository;
        
        public DoctorAppService(IDoctorRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
