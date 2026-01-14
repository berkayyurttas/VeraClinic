using VeraClinic.Samples;
using Xunit;

namespace VeraClinic.EntityFrameworkCore.Domains;

[Collection(VeraClinicTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<VeraClinicEntityFrameworkCoreTestModule>
{

}
