using Newtonsoft.Json;

namespace Greenmaster.Core.Extensions;

public static class SystemExtension
{
    // ReSharper disable once MethodNameNotMeaningful
    public static T Clone<T>(this T source)
    {
        var serialized = JsonConvert.SerializeObject(source);
        return JsonConvert.DeserializeObject<T>(serialized) ?? throw new InvalidOperationException();
    }
}