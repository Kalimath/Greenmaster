using Greenmaster.Core.Models.Extensions;
using StaticData.Time.Durations;

namespace Greenmaster.Core.Tests.Extensions.IEnumerableTests;

public class ToCsvStringShould
{
    private readonly IEnumerable<Month> _someMonths;

    public ToCsvStringShould()
    {
        _someMonths = new List<Month>();
    }

    [Fact]
    public void returnEmptyString_WhenThisIsEmpty()
    {
        Assert.Equal("", _someMonths.ToCsvString());
    }
    
    [Fact]
    public void ReturnExpectedString()
    {
        //Arrange
        ((List<Month>)_someMonths).Add(Month.April);
        ((List<Month>)_someMonths).Add(Month.July);
        ((List<Month>)_someMonths).Add(Month.August);
        ((List<Month>)_someMonths).Add(Month.September);
        var expectedCsv = $"{Month.April},{Month.July},{Month.August},{Month.September}";
        
        //Act
        var receivedCsv = _someMonths.ToCsvString();
        
        //Assert
        Assert.Equal(_someMonths.Count(),receivedCsv.Split(',').Length);
        Assert.Equal(expectedCsv, receivedCsv);
    }
}