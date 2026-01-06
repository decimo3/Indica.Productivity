using System.Globalization;

namespace Indica.Productivity.Shared
{
    public static class Converter
    {
        private static readonly Dictionary<string, bool> booleanStrings = new()
        {
            {"Normal", true},
            {"não", false }, {"sim", true },
            {"true", true}, {"false", false},
            {"Done", true }, {"Notdone", false},
            {"found", true}, {"not_found", false},
            {"1 - Sim", true}, {"2 - Não", false},
            {"VERDADEIRO", true}, {"FALSO", false}
        };
        private static string ExtractDigits(string input) =>
            new(input.Where(char.IsDigit).ToArray());
        private static string ExtractDigitsAndDot(string input) =>
            new(input.Where(c => char.IsDigit(c) || c == '.' || c == '-').ToArray());
        public static string GetString(object value)
        {
            return value?.ToString() ?? string.Empty;
        }
        public static int GetInt32(object value)
        {
            if (value is int i) return i;
            if (value is long l) return (int)l;
            if (value is double d) return (int)d;
            if (value is string s)
                return int.TryParse(ExtractDigits(s), out int result) ? result : 0;
            return 0;
        }
        public static long GetInt64(object value)
        {
            if (value is long l) return l;
            if (value is int i) return i;
            if (value is double d) return (long)d;
            if (value is string s)
                return long.TryParse(ExtractDigits(s), out long result) ? result : 0;
            return 0;
        }
        public static float GetFloat(object value)
        {
            if (value is float f) return f;
            if (value is double d) return (float)d;
            if (value is string s)
                return float.TryParse(ExtractDigitsAndDot(s), CultureInfo.InvariantCulture, out float result) ? result : 0;
            return 0;
        }
        public static double GetDouble(object value)
        {
            if (value is double d) return d;
            if (value is float f) return f;
            if (value is string s)
                return double.TryParse(ExtractDigitsAndDot(s), CultureInfo.InvariantCulture, out double result) ? result : 0;
            return 0;
        }
        public static decimal GetDecimal(object value)
        {
            if (value is decimal d) return d;
            if (value is double m) return (decimal)m;
            if (value is float f) return (decimal)f;
            if (value is string s)
                return decimal.TryParse(ExtractDigitsAndDot(s), CultureInfo.InvariantCulture, out decimal result) ? result : 0;
            return 0;
        }
        public static DateTime GetDateTime(object value)
        {
            if (value is DateTime dt) return dt;
            if (value is double d) return DateTime.FromOADate(d);
            if (value is string s && DateTime.TryParse(s, out DateTime result))
                return result;
            return DateTime.MinValue;
        }
        public static DateOnly GetDateOnly(object value)
        {
            if (value is DateTime dt) return DateOnly.FromDateTime(dt);
            if (value is string s && DateOnly.TryParse(s, out DateOnly result))
                return result;
            return DateOnly.MinValue;
        }
        public static TimeOnly GetTimeOnly(object value)
        {
            if (value is DateTime dt) return TimeOnly.FromDateTime(dt);
            if (value is string s && TimeOnly.TryParse(s, out TimeOnly result))
                return result;
            return TimeOnly.MinValue;
        }
        public static TimeSpan GetTimeSpan(object value)
        {
            if (value is TimeSpan ts) return ts;
            if (value is DateTime dt) return dt.TimeOfDay;
            if (value is int minutes) return TimeSpan.FromMinutes(minutes);
            if (value is double min) return TimeSpan.FromMinutes(min);
            if (value is string s)
            {
                if (int.TryParse(s, out int num))
                    return TimeSpan.FromMinutes(num);
                if (TimeSpan.TryParse(s, out TimeSpan result))
                    return result;
                if (TimeSpan.TryParseExact(s, @"hh\:mm", null, out result))
                    return result;
            }
            return TimeSpan.Zero;
        }
        public static bool? GetBoolean(object value)
        {
            if (value is bool b) return b;
            if (value is string s && booleanStrings.TryGetValue(s, out bool result))
                return result;
            return null;
        }
        public static object? GetDesiredType(Type targetType, object value)
        {
            if (value == null) return null;
            try
            {
                if (targetType == typeof(string))
                    return value?.ToString() ?? string.Empty;

                if (targetType == typeof(int))
                    return GetInt32(value);

                if (targetType == typeof(long))
                    return GetInt64(value);

                if (targetType == typeof(float))
                    return GetFloat(value);

                if (targetType == typeof(double))
                    return GetDouble(value);

                if (targetType == typeof(DateTime))
                    return GetDateTime(value);

                if (targetType == typeof(DateOnly))
                    return GetDateOnly(value);

                if (targetType == typeof(TimeOnly))
                    return GetTimeOnly(value);

                if (targetType == typeof(TimeSpan))
                    return GetTimeSpan(value);

                if (targetType == typeof(bool))
                    return GetBoolean(value);

                if (targetType == typeof(decimal))
                    return GetDecimal(value);

                return null;
            }
            catch
            {
                // Optionally log or handle conversion error
                return null;
            }
        }
    }
}
