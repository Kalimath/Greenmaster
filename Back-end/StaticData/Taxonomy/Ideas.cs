namespace StaticData.Taxonomy;

public static class PlantFamilyProperties
{
    public static PlantFamilyInfo Acanthaceae { get; } = new(PlantFamily.Acanthaceae, PlantOrder.Lamiales);
    public static PlantFamilyInfo Rosaceae { get; } = new(PlantFamily.Rosaceae, PlantOrder.Rosales);
    public static PlantFamilyInfo Fabaceae { get; } = new(PlantFamily.Fabaceae, PlantOrder.Fabales);
    public static PlantFamilyInfo Solanaceae { get; } = new(PlantFamily.Solanaceae, PlantOrder.Solanales);
    public static PlantFamilyInfo Lamiaceae { get; } = new(PlantFamily.Lamiaceae, PlantOrder.Lamiales);
    public static PlantFamilyInfo Poaceae { get; } = new(PlantFamily.Poaceae, PlantOrder.Poales);
    public static PlantFamilyInfo Orchidaceae { get; } = new(PlantFamily.Orchidaceae, PlantOrder.Asparagales);
    // Add more families as needed...
}

public class PlantFamilyInfo
{
    public PlantFamily Family { get; }
    public PlantOrder Order { get; }

    public PlantFamilyInfo(PlantFamily family, PlantOrder order)
    {
        Family = family;
        Order = order;
    }
}