using System;

namespace DoctorAsh.Appointments
{
    internal class AppointmentBuilder
    {
        private string _title = string.Empty;
        private Guid _id = Guid.Empty;
        private string _description = string.Empty;
        private DateTime _startDate = new DateTime(2021, 05, 13);
        private DateTime? _endDate = null;
        private RecurrenceType _recurrence = RecurrenceType.Once;
        private StatusType _status = StatusType.AwaitingApproval;
        private Guid _patientId = Guid.Empty;
        private Guid _doctorId = Guid.Empty;

        internal AppointmentBuilder(Guid appointmentId)
        {
            _id = appointmentId;
        }
        internal Appointment Build()
        {
            var appointment = new Appointment(id: _id, _doctorId,_patientId);
            appointment.Title = _title;
            appointment.Description = _description;
            appointment.SetStartDate(_startDate);

            if (_endDate != null)
            {
                appointment.SetEndDate((DateTime)_endDate);
            }

            appointment.Recurrence = _recurrence;
            appointment.Status = _status;
            return appointment;
        }
        internal AppointmentBuilder WithTitle(string value)
        {
            _title = value;
            return this;
        }

        internal AppointmentBuilder WithDescription(string value)
        {
            _description = value;
            return this;
        }

        internal AppointmentBuilder WithStartDate(DateTime value)
        {
            _startDate = value;
            return this;
        }

        internal AppointmentBuilder WithPatient(Guid patientId)
        {
            _patientId = patientId;
            return this;
        }

        internal AppointmentBuilder WithDoctor(Guid doctorId)
        {
            _doctorId = doctorId;
            return this;
        }

        internal AppointmentBuilder WithEndDate(DateTime? value)
        {
            _endDate = value;
            return this;
        }

        internal AppointmentBuilder WithRecurrence(RecurrenceType value)
        {
            _recurrence = value;
            return this;
        }

        internal AppointmentBuilder WithStatus(StatusType value)
        {
            _status = value;
            return this;
        }
    }
}
