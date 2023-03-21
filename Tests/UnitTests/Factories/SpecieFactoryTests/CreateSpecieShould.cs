using Greenmaster_ASP.Models.Extensions;
using Greenmaster_ASP.Models.Factories;
using Microsoft.Win32.SafeHandles;
using NSubstitute;
using Xunit;
using static Greenmaster_ASP.Tests.Helpers.AssertObjects;

namespace Greenmaster_ASP.Tests.UnitTests.Factories.SpecieFactoryTests;

public class CreateSpecieShould : SpecieFactoryTestBase
{
    
    
    [Fact]
    public void ThrowArgumentNullException_WhenPassedViewModelNull()
    {
        Assert.Throws<ArgumentNullException>(() => SpecieFactory.Create(null!));
    }
    
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenViewModelMaxHeightInvalid()
    {
        var invalidMaxHeightSpecieViewModel = SpecieFactory.ToViewModel(SpecieStrelitzia.Clone());
        invalidMaxHeightSpecieViewModel.MaxHeight = -15;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(invalidMaxHeightSpecieViewModel));
        invalidMaxHeightSpecieViewModel.MaxHeight = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(invalidMaxHeightSpecieViewModel));
        invalidMaxHeightSpecieViewModel.MaxHeight = 150.1;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(invalidMaxHeightSpecieViewModel));
    }
    
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenViewModelMaxWidthInvalid()
    {
        var invalidMaxWidthSpecieViewModel = SpecieFactory.ToViewModel(SpecieStrelitzia.Clone());
        invalidMaxWidthSpecieViewModel.MaxWidth = -15;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(invalidMaxWidthSpecieViewModel));
        invalidMaxWidthSpecieViewModel.MaxWidth = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(invalidMaxWidthSpecieViewModel));
        invalidMaxWidthSpecieViewModel.MaxWidth = 10.1;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(invalidMaxWidthSpecieViewModel));
    }

    [Fact]
    public void ReturnCorrectModelOfSpecie_WhenViewModelValid()
    {
        var resultSpecie = SpecieFactory.Create(SpecieViewModelStrelitzia);
        
        AssertSpecie(SpecieStrelitzia, resultSpecie);
    }

    [Fact]
    public void ThrowArgumentNullException_WhenImageNull()
    {
        var invalidSpecieViewModel = SpecieFactory.ToViewModel(SpecieStrelitzia.Clone());
        invalidSpecieViewModel.Image = null!;
        Assert.Throws<ArgumentNullException>(() => SpecieFactory.Create(invalidSpecieViewModel));
    }
    
    /*[Fact]
    public void ThrowInvalidOperationException_WhenParsingToImageObjectFails()
    {
        var invalidSpecieViewModel = SpecieViewModelStrelitzia.Clone();
        invalidSpecieViewModel.Image = Substitute.For<IFormFile>();
        invalidSpecieViewModel.Image.CopyTo(Arg.Any<Stream>()).th;
        Assert.Throws<InvalidOperationException>(() => SpecieFactory.Create(invalidSpecieViewModel));
    }*/
    
    //TODO: check if plantrequirements are created correctly
    //TODO: check if flowerData is created correctly
    //TODO: check if FertiliserData is created correctly
    
}