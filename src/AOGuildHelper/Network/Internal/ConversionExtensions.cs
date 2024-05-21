using System.Collections;
using System.Globalization;
using System.Numerics;

namespace AOGuildHelper.Network.Internal;

public static class ConversionExtensions
{
    public static bool TryGetGuid(this IDictionary<byte, object> parameters, byte key, out Guid value)
    {
        if (!parameters.TryGetValue(key, out var obj))
        {
            value = new Guid();
            return false;
        }

        return obj.TryConvertToGuid(out value);
    }
    public static bool TryConvertToGuid(this object obj, out Guid value)
    {
        switch (obj)
        {
            case Guid guidValue:
                value = guidValue;
                break;

            case byte[] byteArrayValue:
                value = new Guid(byteArrayValue);
                break;

            case IEnumerable<byte> byteEnumerableValue:
                value = new Guid(byteEnumerableValue.ToArray());
                break;

            default:
                value = Guid.Empty;
                return false;
        }

        return true;
    }
    public static Guid ConvertToGuid(this object obj)
    {
        if (!TryConvertToGuid(obj, out var value))
            throw new InvalidOperationException($"Conversion of {obj} to Guid failed");

        return value;
    }

    public static bool TryGetInt32(this IDictionary<byte, object> parameters, byte key, out int value)
    {
        if (!parameters.TryGetValue(key, out var obj))
        {
            value = 0;
            return false;
        }

        return obj.TryConvertToInt32(out value);
    }
    public static bool TryConvertToInt32(this object obj, out int value)
    {
        switch (obj)
        {
            case byte byteValue:
                value = byteValue;
                break;

            case short shortValue:
                value = shortValue;
                break;

            case int intValue:
                value = intValue;
                break;

            default:
                value = 0;
                return false;
        }

        return true;
    }
    public static int ConvertToInt32(this object obj)
    {
        if (!TryConvertToInt32(obj, out var value))
            throw new InvalidOperationException($"Conversion of {obj} to Int32 failed");

        return value;
    }

    public static bool TryGetInt64(this IDictionary<byte, object> parameters, byte key, out long value)
    {
        if (!parameters.TryGetValue(key, out var obj))
        {
            value = 0;
            return false;
        }

        return obj.TryConvertToInt64(out value);
    }
    public static bool TryConvertToInt64(this object obj, out long value)
    {
        switch (obj)
        {
            case byte byteValue:
                value = byteValue;
                break;

            case short shortValue:
                value = shortValue;
                break;

            case int intValue:
                value = intValue;
                break;

            case long longValue:
                value = longValue;
                break;

            default:
                value = 0;
                return false;
        }

        return true;
    }
    public static long ConvertToInt64(this object obj)
    {
        if (!TryConvertToInt64(obj, out var value))
            throw new InvalidOperationException($"Conversion of {obj} to Int64 failed");

        return value;
    }

    public static bool TryGetInt16(this IDictionary<byte, object> parameters, byte key, out short value)
    {
        if (!parameters.TryGetValue(key, out var obj))
        {
            value = 0;
            return false;
        }

        switch (obj)
        {
            case byte byteValue:
                value = byteValue;
                break;

            case short shortValue:
                value = shortValue;
                break;

            default:
                value = 0;
                return false;
        }

        return true;
    }

    public static bool TryGetByte(this IDictionary<byte, object> parameters, byte key, out byte value)
    {
        if (!parameters.TryGetValue(key, out var obj))
        {
            value = 0;
            return false;
        }

        return obj.TryConvertToByte(out value);
    }
    public static bool TryConvertToByte(this object obj, out byte value)
    {
        switch (obj)
        {
            case byte byteValue:
                value = byteValue;
                break;

            default:
                value = 0;
                return false;
        }

        return true;
    }

    public static bool TryGetDouble(this IDictionary<byte, object> parameters, byte key, out double value)
    {
        if (!parameters.TryGetValue(key, out var obj))
        {
            value = 0;
            return false;
        }

        switch (obj)
        {
            case float floatValue:
                value = (double)new decimal(floatValue);
                break;

            case double doubleValue:
                value = doubleValue;
                break;

            default:
                value = 0;
                return false;
        }

        return true;
    }

    public static bool TryGetBoolean(this IDictionary<byte, object> parameters, byte key, out bool value)
    {
        if (!parameters.TryGetValue(key, out var obj))
        {
            value = false;
            return false;
        }

        return TryConvertToBoolean(obj, out value);
    }
    public static bool TryConvertToBoolean(this object obj, out bool value)
    {
        switch (obj)
        {
            case bool boolValue:
                value = boolValue;
                break;

            default:
                value = false;
                return false;
        }

        return true;
    }
    public static bool ConvertToBoolean(this object obj)
    {
        if (!TryConvertToBoolean(obj, out var value))
            throw new InvalidOperationException($"Conversion of {obj} to boolean failed");

        return value;
    }

    public static bool TryGetString(this IDictionary<byte, object> parameters, byte key, out string value)
    {
        if (!parameters.TryGetValue(key, out var obj))
        {
            value = "";
            return false;
        }

        return obj.TryConvertToString(out value);
    }
    public static bool TryConvertToString(this object obj, out string value)
    {
        switch (obj)
        {
            case string stringValue:
                value = stringValue;
                break;

            default:
                value = "";
                return false;
        }

        return true;
    }
    public static string ConvertToString(this object obj)
    {
        if (!TryConvertToString(obj, out var value))
            throw new InvalidOperationException($"Conversion of {obj} to string failed");

        return value;
    }

    public static bool TryGetVector2(this IDictionary<byte, object> parameters, byte key, out Vector2 value)
    {
        if (!parameters.TryGetValue(key, out var obj))
        {
            value = Vector2.Zero;
            return false;
        }

        switch (obj)
        {
            case float[] { Length: 2 } floatArrayValue:
                value = new Vector2(floatArrayValue[0], floatArrayValue[1]);
                break;

            default:
                value = Vector2.Zero;
                return false;
        }

        return true;
    }

    public static bool TryGetTimeSpanFromSeconds(this IDictionary<byte, object> parameters, byte key, out TimeSpan value)
    {
        if (!parameters.TryGetValue(key, out var obj))
        {
            value = TimeSpan.Zero;
            return false;
        }

        switch (obj)
        {
            case byte byteValue:
                value = TimeSpan.FromSeconds(byteValue);
                break;

            case short shortValue:
                value = TimeSpan.FromSeconds(shortValue);
                break;

            case int intValue:
                value = TimeSpan.FromSeconds(intValue);
                break;

            case long longValue:
                value = TimeSpan.FromSeconds(longValue);
                break;

            default:
                value = TimeSpan.Zero;
                return false;
        }

        return true;
    }

    public static bool TryGetArray<T>(this IDictionary<byte, object> parameters, byte key, out T[] value, TryConvertDelegate<T> tryConvert)
    {
        if (!parameters.TryGetValue(key, out var obj))
        {
            value = Array.Empty<T>();
            return false;
        }

        if (obj is not IEnumerable enumerable)
        {
            value = Array.Empty<T>();
            return false;
        }

        value = enumerable.Cast<object>()
            .Select(
                x =>
                {
                    if (!tryConvert(x, out var val))
                    {
                        throw new InvalidOperationException($"Conversion of {x} to {typeof(T)} failed");
                    }
                    return val;
                }
            ).ToArray();
        return true;
    }

    public static int? TryParseInt32(this string? str)
    {
        if (str is not { Length: > 0 })
        {
            return null;
        }

        return int.Parse(str, CultureInfo.InvariantCulture);
    }

    public static double? TryParseDouble(this string? str)
    {
        if (str is not { Length: > 0 })
        {
            return null;
        }

        return double.Parse(str, CultureInfo.InvariantCulture);
    }
}

public delegate bool TryConvertDelegate<T>(object obj, out T value);
