using System;
using Volo.Abp.TextTemplating;

namespace DoctorAsh.Emailing
{
    public class DoctorAshTemplateDefinitionProvider : TemplateDefinitionProvider
    {
        public override void Define(ITemplateDefinitionContext context)
        {
            context.Add(
                new TemplateDefinition("Welcome") //template name: "Hello"
                    .WithVirtualFilePath(
                        "/Emailing/Templates/Welcome.tpl", //template content path
                        isInlineLocalized: true
                    )
            );

            context.Add(
                new TemplateDefinition("Appointment") //template name: "Hello"
                    .WithVirtualFilePath(
                        "/Emailing/Templates/Appointment.tpl", //template content path
                        isInlineLocalized: true
                    )
            );
        }
    }
}