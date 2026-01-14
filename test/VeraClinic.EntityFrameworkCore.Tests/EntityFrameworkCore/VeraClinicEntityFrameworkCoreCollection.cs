using Xunit;

namespace VeraClinic.EntityFrameworkCore;

[CollectionDefinition(VeraClinicTestConsts.CollectionDefinitionName)]
public class VeraClinicEntityFrameworkCoreCollection : ICollectionFixture<VeraClinicEntityFrameworkCoreFixture>
{

}
