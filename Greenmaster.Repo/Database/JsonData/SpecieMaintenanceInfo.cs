using Newtonsoft.Json;

namespace Greenmaster.Repo.Database.JsonData;

public class SpecieMaintenanceInfo
{
    [JsonProperty("size")] public string Size { get; set; }

    [JsonProperty("soil")] public string Soil { get; set; }

    [JsonProperty("sunlight")] public string Sunlight { get; set; }

    [JsonProperty("watering")] public string Watering { get; set; }

    [JsonProperty("fertilization")] public string Fertilization { get; set; }

    [JsonProperty("pruning")] public string Pruning { get; set; }
}