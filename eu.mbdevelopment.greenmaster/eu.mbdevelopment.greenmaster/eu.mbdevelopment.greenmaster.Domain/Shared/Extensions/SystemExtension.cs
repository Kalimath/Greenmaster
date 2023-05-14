using Newtonsoft.Json;

namespace eu.mbdevelopment.greenmaster.Domain.Shared.Extensions;

public static class SystemExtension
{
    public static T Clone<T>(this T source)
    {
        var serialized = JsonConvert.SerializeObject(source);
        return JsonConvert.DeserializeObject<T>(serialized)!;
    }
}