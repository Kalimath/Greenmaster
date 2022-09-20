﻿namespace be.Greenmaster.Extensions.SubTypes;

public class DictionaryEnum<TEnum,TValue>:Dictionary<string, TValue> where TEnum : struct, IConvertible
{
    public DictionaryEnum():base()
    {
        this.InitiateEnumKeys();
    }

    public void InitiateEnumKeys(){
        if (!typeof(TEnum).IsEnum) 
        {
            throw new ArgumentException("TEnum must be an enumerated type");
        }
        else
        {
            var enumNames = Enum.GetNames(typeof(TEnum));
            foreach (var name in enumNames.AsQueryable())
            {
                this[name] = default(TValue)!;
            }
        }
            
    }
}