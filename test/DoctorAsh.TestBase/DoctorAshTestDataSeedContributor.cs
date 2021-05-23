using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoctorAsh.Appointments;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace DoctorAsh
{
    public class DoctorAshTestDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public DoctorAshTestDataSeedContributor(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            /* Seed additional test data... */

            await SeedAppointmentsAsync(context);

        }

        private  Task SeedAppointmentsAsync(DataSeedContext context)
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