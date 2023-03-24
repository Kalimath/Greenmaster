using Greenmaster_ASP.Controllers;
using Xunit;

namespace Greenmaster_ASP.Tests.UnitTests.Controllers.Specie;

public class CtorShould
{
    [Fact]
    public void ThrowArgumentNullException_WhenPassedRenderingServiceNull()
    {
        Assert.Throws<ArgumentNullException>(() => _ = new SpecieController(null!));
    }
}