using Microsoft.Extensions.Localization;
using VeraClinic.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace VeraClinic;

[Dependency(ReplaceServices = true)]
public class VeraClinicBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<VeraClinicResource> _localizer;

    public VeraClinicBrandingProvider(IStringLocalizer<VeraClinicResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
