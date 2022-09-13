using Newtonsoft.Json;

namespace Greenmaster.Repo.Database.JsonData;

public class SpecieParameters
{
    [JsonProperty("max_light_mmol")] public int MaxLightMmol { get; set; }

    [JsonProperty("min_light_mmol")] public int MinLightMmol { get; set; }

    [JsonProperty("max_light_lux")] public int MaxLightLux { get; set; }

    [JsonProperty("min_light_lux")] public int MinLightLux { get; set; }

    [JsonProperty("max_temp")] public int MaxTemp { get; set; }

    [JsonProperty("min_temp")] public int MinTemp { get; set; }

    [JsonProperty("max_env_humid")] public int MaxEnvHumid { get; set; }

    [JsonProperty("min_env_humid")] public int MinEnvHumid { get; set; }

    [JsonProperty("max_soil_moist")] public int MaxSoilMoist { get; set; }

    [JsonProperty("min_soil_moist")] public int MinSoilMoist { get; set; }

    [JsonProperty("max_soil_ec")] public int MaxSoilEc { get; set; }

    [JsonProperty("min_soil_ec")] public int MinSoilEc { get; set; }
}