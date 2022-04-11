using System.ComponentModel;
using System.Reflection;

namespace PokemonTCGApp.Model
{
    public static class EnumExtension
    {
        public static string GetDescription<T>(this T value, Type type = null)
        {
            if (type is null)
            {
                type = typeof(T);
            }
            if (!type.IsEnum || !Enum.TryParse(type, value.ToString(), out _))
            {
                return value.ToString();
            }
            var name = type.GetEnumName(value);
            if (name is null)
            {
                return value.ToString();
            }
            var field = type.GetField(name);
            var attr = field is null ? default(DescriptionAttribute) : (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
            return attr is null ? value.ToString() : attr.Description;
        }
    }
}
