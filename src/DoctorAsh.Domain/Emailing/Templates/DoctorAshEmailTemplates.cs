using System;
using Volo.Abp.Emailing.Templates;

namespace DoctorAsh.Emailing.Templates
{
    public static class DoctorAshEmailTemplates
    {
        public const string Welcome = "Welcome";
        public const string Layout = StandardEmailTemplates.Layout;
        public const string Message = StandardEmailTemplates.Message;
    }
}