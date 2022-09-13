using Newtonsoft.Json;

namespace Greenmaster.Repo.Database.JsonData;

public class SpecieBasicInfo
{
    [JsonProperty("floral_language")] public string FloralLanguage { get; set; }

    [JsonProperty("origin")] public string Origin { get; set; }

    [JsonProperty("production")] public string Production { get; set; }

    [JsonProperty("category")] public string Category { get; set; }

    [JsonProperty("blooming")] public string Blooming { get; set; }

    [JsonProperty("color")] public string Color { get; set; }
}