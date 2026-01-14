using VeraClinic.Samples;
using Xunit;

namespace VeraClinic.EntityFrameworkCore.Applications;

[Collection(VeraClinicTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<VeraClinicEntityFrameworkCoreTestModule>
{

}
