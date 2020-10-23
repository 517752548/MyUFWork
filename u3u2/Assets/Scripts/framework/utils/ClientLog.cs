using UnityEngine;

public class ClientLog
{
    //0:Log+LogWarining+LogError 1:LogWarning+LogError 2:LogError 3:none
    private static int level = 2;

    /*
    public static bool CanOutPutError()
    {
        return CommonDefines.isDeversion();
    }

    public static bool CanOutPutWarning()
    {
        return CommonDefines.isDeversion();

    }

    public static bool CanOutputLog()
    {
        return CommonDefines.isDeversion();
    }
    */


    /**
 * LogError
 * */

    public static void LogError(object message)
    {
        if (level > 2)
        {
            return;
        }

        if (null == message)
        {
            return;
        }
        //Debug.LogError(message);
        NativeLogger.LogError((string)message);
        Logger.Ins.Log("Error: " + message.ToString());
    }

    public static void LogError(object message, Object context)
    {
        if (level > 2)
        {
            return;
        }

        if (null == message || null == context)
        {
            return;
        }
        Debug.LogError(message, context);
    }

    /**
 * LogWarning
 * */
    public static void LogWarning(object message)
    {
        if (level > 1)
        {
            return;
        }
        if (null == message)
        {
            return;
        }
        Debug.LogWarning(message);
        Logger.Ins.Log("Warning: " + message.ToString());
    }

    public static void LogWarning(object message, Object context)
    {
        if (level > 1)
        {
            return;
        }
        if (null == message || null == context)
        {
            return;
        }
        Debug.LogWarning(message, context);
    }

    /**
 * Log
 * */

    public static void Log(object message)
    {
        if (level > 0)
        {
            return;
        }
        if (null == message)
        {
            return;
        }
        Debug.Log(message);
    }

    public static void Log(object message, Object context)
    {
        if (level > 0)
        {
            return;
        }
        if (null == message || null == context)
        {
            return;
        }
        Debug.Log(message, context);
    }

    public static void LogErrorEx(object message)
    {
        if (level > 2)
        {
            return;
        }
        /*
        if (!CanOutPutError())
        {
            return;
        }
        */
        if (null == message)
        {
            return;
        }
        Debug.LogError(message);
    }

    public static void LogErrorEx(object message, Object context)
    {
        if (level > 2)
        {
            return;
        }
        /*
        if (!CanOutPutError())
        {
            return;
        }
        */
        if (null == message || null == context)
        {
            return;
        }
        Debug.LogError(message, context);
    }

    public static void LogWarningEx(object message)
    {
        if (level > 1)
        {
            return;
        }
        /*
        if (!CanOutPutWarning())
        {
            return;
        }
        */
        if (null == message)
        {
            return;
        }
        Debug.LogWarning(message);
    }

    public static void LogWarningEx(object message, Object context)
    {
        if (level > 1)
        {
            return;
        }
        /*
        if (!CanOutPutWarning())
        {
            return;
        }
        */
        if (null == message || null == context)
        {
            return;
        }
        Debug.LogWarning(message, context);
    }

    public static void LogEx(object message)
    {
        if (level > 0)
        {
            return;
        }
        /*
        if (!CanOutputLog())
        {
            return;
        }
        */
        if (null == message)
        {
            return;
        }
        Debug.Log(message);
    }

    public static void LogEx(object message, Object context)
    {
        if (level > 0)
        {
            return;
        }
        /*
        if (!CanOutputLog())
        {
            return;
        }
        */
        if (null == message || null == context)
        {
            return;
        }
        Debug.Log(message, context);
    }
}