using System;
using DoctorAsh.Permissions;
using DoctorAsh.Patients.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DoctorAsh.Patients
{
    public class PatientAppService : CrudAppService<Patient, PatientDto, Guid, PagedAndSortedResultRequestDto, CreateUpdatePatientDto, CreateUpdatePatientDto>,
        IPatientAppService
    {
        protected override string GetPolicyName { get; set; } = DoctorAshPermissions.Patient.Default;
        protected override string GetListPolicyName { get; set; } = DoctorAshPermissions.Patient.Default;
        protected override string CreatePolicyName { get; set; } = DoctorAshPermissions.Patient.Create;
        protected override string UpdatePolicyName { get; set; } = DoctorAshPermissions.Patient.Update;
        protected override string DeletePolicyName { get; set; } = DoctorAshPermissions.Patient.Delete;

        private readonly IPatientRepository _repository;
        
        public PatientAppService(IPatientRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
