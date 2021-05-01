namespace DoctorAsh
{
    public static class DoctorAshDomainErrorCodes
    {
        /* You can add your business exception error codes here, as constants */
        public const string InvalidStartDateException = "DoctorAsh:ErrorCode:0001";
        public const string InvalidEndDateException = "DoctorAsh:ErrorCode:0002";
        public const string AppointmentIsActiveException = "DoctorAsh:ErrorCode:0003";
        public const string AppointmentAlreadyCancelledException = "DoctorAsh:ErrorCode:0004";
    }
}
