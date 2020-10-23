using System.Collections;

public class JsonHelper
{
    public JsonHelper()
    {
    }

    public static IList GetListData(string key, IDictionary data)
    {
        if (data != null && data.Contains(key))
        {
            try
            {
                return (IList)(data[key]);
            }
            catch
            {
                return null;
            }
        }
        return null;
    }

    public static IDictionary GetDictData(string key, IDictionary data)
    {
        if (data != null && data.Contains(key))
        {
            try
            {
                return (IDictionary)(data[key]);
            }
            catch
            {
                return null;
            }
        }
        return null;
    }

    public static int GetIntData(string key, IDictionary data, int defaultValue = 0)
    {
        if (data != null && data.Contains(key))
        {
            try
            {
                return int.Parse(data[key].ToString());
            }
            catch
            {
                return defaultValue;
            }
        }
        return defaultValue;
    }
    
    public static long GetLongData(string key, IDictionary data, long defaultValue = 0)
    {
        if (data != null && data.Contains(key))
        {
            try
            {
                return long.Parse(data[key].ToString());
            }
            catch
            {
                return defaultValue;
            }
        }
        return defaultValue;
    }

    public static string GetStringData(string key, IDictionary data, string defaultValue = "")
    {
        if (data != null && data.Contains(key))
        {
            try
            {
                return data[key].ToString();
            }
            catch
            {
                return defaultValue;
            }
        }
        return defaultValue;
    }

    public static bool GetBoolData(string key, IDictionary data, bool defaultValue = false)
    {
        if (data != null && data.Contains(key))
        {
            try
            {
                return bool.Parse(data[key].ToString());
            }
            catch
            {
                return defaultValue;
            }
        }
        return defaultValue;
    }
}