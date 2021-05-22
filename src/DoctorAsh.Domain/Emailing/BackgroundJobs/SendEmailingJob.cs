using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;

namespace DoctorAsh.Emailing
{
    [BackgroundJobName("emails")]
    public class  EmailSendingArgs
    {
        public string EmailAddress { get; init; }
        public string Subject { get; init; }
        public string Body { get; init; }
    }
    public class SendEmailJob : AsyncBackgroundJob<EmailSendingArgs>, ITransientDependency
    {
        private readonly EmailService _emailService;

        public SendEmailJob(EmailService emailService)
        {
            _emailService = emailService;
        }
        public override async Task ExecuteAsync(EmailSendingArgs args)
        {
            await _emailService.SendMessageAsync(
                args.EmailAddress,
                args.Subject,
                args.Body
            );
        }
    }
}