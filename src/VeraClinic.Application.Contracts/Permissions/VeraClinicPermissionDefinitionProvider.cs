using VeraClinic.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace VeraClinic.Permissions;

public class VeraClinicPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(VeraClinicPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(VeraClinicPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<VeraClinicResource>(name);
    }
}
