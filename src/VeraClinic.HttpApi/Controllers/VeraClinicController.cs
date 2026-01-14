using VeraClinic.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace VeraClinic.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class VeraClinicController : AbpControllerBase
{
    protected VeraClinicController()
    {
        LocalizationResource = typeof(VeraClinicResource);
    }
}
