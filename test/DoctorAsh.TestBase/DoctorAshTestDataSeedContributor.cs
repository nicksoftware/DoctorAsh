using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoctorAsh.Appointments;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using DoctorAsh.Doctors;
using DoctorAsh.Patients;

namespace DoctorAsh
{
    public class DoctorAshTestDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepo;
        private readonly IAppointmentRepository _appointmentRepository;

        public DoctorAshTestDataSeedContributor(
            IPatientRepository patientRepository,
            IDoctorRepository doctorRepo,
            IAppointmentRepository appointmentRepository)
        {
            _patientRepository = patientRepository;
            _doctorRepo = doctorRepo;
            _appointmentRepository = appointmentRepository;

        }
        public async Task SeedAsync(DataSeedContext context)
        {
            /* Seed additional test data... */
            var dr = Doctor.Create(TestData.DoctorId, TestData.AdminId);
            dr.AddWorkingHour(new WorkingHour(dr.Id, DayOfWeek.Monday)
            {
                StartTime = DateTime.Parse("07:30 AM"),
                EndTime = DateTime.Parse("10:30 PM"),
            });
    
          await  _doctorRepo.InsertAsync(dr,true);

            var patient = new Patient(TestData.PatientId);
            patient.UserId = TestData.PatientId;
          await  _patientRepository.InsertAsync(patient,true);
            var appointmentId = Guid.NewGuid();

            var appointment = new AppointmentBuilder(appointmentId)
            .WithDoctor(TestData.DoctorId)
            .WithPatient(TestData.PatientId)
            .WithTitle("First Appointment")
            .WithDescription("appointmnet description goes here")
            .WithStartDate(DateTime.Now.AddDays(1))
            .WithEndDate(DateTime.Now.AddDays(1).AddHours(2))
            .WithRecurrence(RecurrenceType.Once)
            .Build();
            await _appointmentRepository.InsertAsync(appointment,true);

        }

        private Task SeedAppointmentsAsync(DataSeedContext context)
        {
            return Task.CompletedTask;
            // var appointments = new List<Appointment>();
            // var rollDice = new Random();
            // var userIds = new Guid[]{ TestData.User1Id, TestData.User2Id };

            // for (int i = 0; i < 10; i++)
            // {
            //     var id = Guid.NewGuid();
            //     var title = $"Appointment {i}";
            //     var description = $"Appointment {i} description";
            //     var start = new DateTime(2021, 05, 13).AddDays(i);
            //     var endDate = new DateTime(2021, 05, 13).AddDays(i+2);
            //     var recurrence = (RecurrenceType)rollDice.Next(0, 3);
            //     var appointment = new Appointment(id, Guid.NewGuid(), Guid.NewGuid());
            //     appointment.Title = title;
            //     appointment.Description = description;
            //     appointment.SetStartDate(start);
            //     appointment.SetEndDate(endDate);
            //     appointment.CreatorId = userIds[rollDice.Next(0, userIds.Length)];

            //     appointments.Add(appointment);
            // };

            // await _appointmentRepository.InsertManyAsync(appointments, true);
        }
    }
}