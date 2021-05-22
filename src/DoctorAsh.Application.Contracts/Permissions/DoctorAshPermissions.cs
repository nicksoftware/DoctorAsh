namespace DoctorAsh.Permissions
{
    public static class DoctorAshPermissions
    {
        public const string GroupName = "DoctorAsh";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";
        public class Appointment
        {
            public const string Default = GroupName + ".Appointment";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
            public const string ViewOthers = Default + ".ViewOthers";
            public const string Cancel = Default + ".Cancel";
            public const string Reschedule = Default + ".Reschedule";
        }

        public class Doctor
        {
            public const string Default = GroupName + ".Doctor";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Patient
        {
            public const string Default = GroupName + ".Patient";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
