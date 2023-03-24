namespace Greenmaster_ASP.Models.Examples;

public interface IExamplesService
{
    List<Specie> GetAllSpecies();
    List<Rendering> GetAllRenderings();
}

public class ExamplesService : IExamplesService
{
    public List<Specie> GetAllSpecies()
    {
        return SpecieExamples.GetAll();
    }

    public List<Rendering> GetAllRenderings()
    {
        return RenderingExamples.GetAll();
    }
}