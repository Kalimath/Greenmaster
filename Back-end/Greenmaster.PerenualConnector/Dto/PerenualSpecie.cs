using Newtonsoft.Json;
// ReSharper disable InconsistentNaming
#pragma warning disable CS8618

namespace Greenmaster.PerenualConnector.Dto;

public class PerenualSpecie
{
    public int id { get; set; }
    public string common_name { get; set; }
    public List<string> scientific_name { get; set; }
    public List<string> other_name { get; set; }
    public string cycle { get; set; }
    public string watering { get; set; }
    public List<string> sunlight { get; set; }
    public DefaultImage default_image { get; set; }
}

public class DefaultImage
{
    public int license { get; set; }
    public string license_name { get; set; }
    public string license_url { get; set; }
    public string original_url { get; set; }
    public string regular_url { get; set; }
    public string medium_url { get; set; }
    public string small_url { get; set; }
    public string thumbnail { get; set; }
}