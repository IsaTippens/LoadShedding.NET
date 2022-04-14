using System.Reflection;
using System;
using System.ComponentModel;
namespace LoadShedding.NET
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum e)
        {
            Type type = e.GetType();
            string? name = type.GetEnumName(e);
            if (name != null)
            {
                FieldInfo? fieldInfo = type.GetField(name);
                if (fieldInfo != null) 
                {
                    DescriptionAttribute? descAttr = Attribute.GetCustomAttribute(
                        fieldInfo,
                        typeof(DescriptionAttribute)
                        ) as DescriptionAttribute;
                    if (descAttr != null)
                    {
                        return descAttr.Description;
                    }

                }
            }
            return e.ToString();
        }
    }
}