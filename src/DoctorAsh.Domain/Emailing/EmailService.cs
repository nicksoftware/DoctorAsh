using System;
using System.Threading.Tasks;
using DoctorAsh.Emailing.Templates;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
using Volo.Abp.TextTemplating;

namespace DoctorAsh.Emailing
{
    public interface IEmailService : ITransientDependency
    {
        Task SendWelcomeMessageAsync(string to);
        Task SendMessageAsync(string to, string subject, string message);
    }

    public class EmailService : IEmailService
    {
        private readonly IEmailSender _emailSender;
        private readonly ITemplateRenderer _templateRenderer;

        public EmailService(
            IEmailSender emailSender,
            ITemplateRenderer templateRenderer)
        {
            _emailSender = emailSender;
            _templateRenderer = templateRenderer;
        }

        public async Task SendMessageAsync(string to, string subject, string message)
        {
            var body = await _templateRenderer.RenderAsync(DoctorAshEmailTemplates.Message,
            new
            {
                Message = message
            });

            await _emailSender.SendAsync(to, subject, body);
        }

        public async Task SendWelcomeMessageAsync(string to)
        {
            var body = await _templateRenderer.RenderAsync(
                DoctorAshEmailTemplates.Welcome,
            new
            {
                Message = "Welcome to Doctor Ash ,Start looking for the nearest Doctor close to you."
            });

            await _emailSender.SendAsync(to, "Welcome to Doctor Ash", body);
        }
    }
}