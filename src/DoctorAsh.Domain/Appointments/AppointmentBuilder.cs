using System;

namespace DoctorAsh.Appointments
{
    internal class AppointmentBuilder
    {
        private string _title = "";
        private Guid _id = Guid.Empty;
        private string _description = "";
        private DateTime _startDate = new DateTime(2021, 05, 13);
        private DateTime? _endDate = null;
        private RecurrenceType _recurrence = RecurrenceType.Once;
        private StatusType _status = StatusType.AwaitingApproval;

        internal AppointmentBuilder(Guid appointmentId)
        {
            _id = appointmentId;
        }
        internal Appointment Build()
        {
            var appointment = new Appointment(id: _id, _title, _description);
            appointment.SetStartDate(_startDate);
            appointment.SetEndDate((DateTime)_endDate);
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
