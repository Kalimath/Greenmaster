using Newtonsoft.Json;

namespace Greenmaster.Repo.Database.JsonData;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class SpecieDto
{
    public SpecieDto(string pid, SpecieBasicInfo specieBasicInfo, string displayPid, SpecieMaintenanceInfo specieMaintenanceInfo, SpecieParameters specieParameters,
        string? image)
    {
        Pid = pid ?? throw new ArgumentNullException(nameof(pid));
        SpecieBasicInfo = specieBasicInfo ?? throw new ArgumentNullException(nameof(specieBasicInfo));
        DisplayPid = displayPid ?? throw new ArgumentNullException(nameof(displayPid));
        SpecieMaintenanceInfo = specieMaintenanceInfo ?? throw new ArgumentNullException(nameof(specieMaintenanceInfo));
        SpecieParameters = specieParameters ?? throw new ArgumentNullException(nameof(specieParameters));
        Image = image;
    }

    [JsonProperty("pid")] public string Pid { get; set; }

    [JsonProperty("basic")] public SpecieBasicInfo SpecieBasicInfo { get; set; }

    [JsonProperty("display_pid")] public string DisplayPid { get; set; }

    [JsonProperty("maintenance")] public SpecieMaintenanceInfo SpecieMaintenanceInfo { get; set; }

    [JsonProperty("parameter")] public SpecieParameters SpecieParameters { get; set; }

    [JsonProperty("image")] public string? Image { get; set; }
}