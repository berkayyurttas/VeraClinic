using VeraClinic.Localization;
using Volo.Abp.Application.Services;

namespace VeraClinic;

/* Inherit your application services from this class.
 */
public abstract class VeraClinicAppService : ApplicationService
{
    protected VeraClinicAppService()
    {
        LocalizationResource = typeof(VeraClinicResource);
    }
}
