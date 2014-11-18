namespace System
{
    using System.Collections.Generic;

    public static class EnumExtensions
    {
        public static string AsString<TEnum>(this TEnum enumValue) where TEnum : struct, IConvertible
        {
            return EnumCache<TEnum>.Get(enumValue);
        }

        public static TEnum AsEnum<TEnum>(this string enumName) where TEnum : struct, IConvertible
        {
            return EnumCache<TEnum>.Get(enumName);
        }

        private static class EnumCache<TEnum>
        {
            private static Dictionary<TEnum, string> EnumToStringValues = new Dictionary<TEnum, string>();
            private static Dictionary<string, TEnum> StringToEnumValues = new Dictionary<string, TEnum>();

            static EnumCache()
            {
                var t = typeof(TEnum);
                var values = (TEnum[])Enum.GetValues(t);
                var names = Enum.GetNames(t);

                for (var i = 0; i < values.Length; ++i)
                {
                    EnumToStringValues.Add(values[i], names[i]);
                    StringToEnumValues.Add(names[i], values[i]);

                    var lowerCaseFallback = names[i].ToLowerInvariant();
                    if (lowerCaseFallback != names[i])
                        StringToEnumValues.Add(lowerCaseFallback, values[i]);
                }
            }

            internal static string Get(TEnum enumValue)
            {
                return EnumToStringValues[enumValue];
            }

            internal static TEnum Get(string enumName)
            {
                TEnum value;
                var success = StringToEnumValues.TryGetValue(enumName, out value);
                if (!success)
                {
                    // Try get lower case version
                    success = StringToEnumValues.TryGetValue(enumName.ToLowerInvariant(), out value);
                    if (!success)
                    {
                        throw new ArgumentOutOfRangeException("enumName not found: " + enumName);
                    }
                }

                return value;
            }
        }
    }
}