using System;

namespace DoctorAsh.Appointments
{
    public enum StatusType
    {
        AwaitingApproval = 0,
        Approved = 1,
        Cancelled = 2,
        Ended = 3,
        Missed = 4,
        Declined = 5
    }
}