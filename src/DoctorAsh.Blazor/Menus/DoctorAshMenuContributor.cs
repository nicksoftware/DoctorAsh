using System.Threading.Tasks;
using DoctorAsh.Localization;
using DoctorAsh.MultiTenancy;
using DoctorAsh.Permissions;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace DoctorAsh.Blazor.Menus;

public class DoctorAshMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<DoctorAshResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                DoctorAshMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);
        if (await context.IsGrantedAsync(DoctorAshPermissions.Appointment.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(DoctorAshMenus.Appointment, l["Menu:Appointment"], "/Appointments/Appointment")
            );
        }
        if (await context.IsGrantedAsync(DoctorAshPermissions.Doctor.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(DoctorAshMenus.Doctor, l["Menu:Doctor"], "/Doctors/Doctor")
            );
        }
        if (await context.IsGrantedAsync(DoctorAshPermissions.Patient.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(DoctorAshMenus.Patient, l["Menu:Patient"], "/Patients/Patient")
            );
        }
    }
}
