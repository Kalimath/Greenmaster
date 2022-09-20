using System.ComponentModel;
using Xunit.Sdk;

namespace be.Greenmaster.Extensions.SubTypes;

public class EnumVDictionary<TEnum, TValue> : Dictionary<string, TValue> where TEnum : struct, IConvertible
{
    public EnumVDictionary() : base()
    {
        this.InitiateEnumKeys();
    }

    public void InitiateEnumKeys()
    {
        if (typeof(TEnum).IsEnum)
        {
            var enumNames = Enum.GetNames(typeof(TEnum));
            foreach (var name in enumNames.AsQueryable())
            {
                this[name] = default(TValue)!;
            }
        }
        else
        {
            throw new InvalidEnumArgumentException("TEnum must be an enumerated type");
        }
    }

    public void Add(TEnum eKey, TValue value)
    {
        var stringifiedEnumKey = eKey.ToString();
        if (string.IsNullOrWhiteSpace(stringifiedEnumKey))
            throw new InvalidEnumArgumentException(
                $"Enum.ToString() resulted in an invalid value: {stringifiedEnumKey}");
        if (!this.ContainsKey(stringifiedEnumKey))
        {
            this.Add(stringifiedEnumKey, value);
        }
        else
        {
            this[stringifiedEnumKey] = value;
        }
    }

    public void Remove(TEnum eKey)
    {
        var key = eKey.ToString();
        if (!string.IsNullOrWhiteSpace(key))
        {
            this[key] = default!;
        }
    }
}