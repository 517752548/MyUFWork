using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class NativeLogger
{
#if !UNITY_EDITOR&&UNITY_IPHONE
    [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
    private static extern void printLog(string str);
    [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
    private static extern void printLogWarning(string str);
    [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
    private static extern void printLogError(string str);
#endif

    public static void Log(string str)
    {

#if UNITY_EDITOR||UNITY_ANDROID
        Debug.Log(str);
#endif
#if !UNITY_EDITOR&&UNITY_IPHONE
        printLog(str);
#endif
    }

    public static void LogWarning(string str)
    {
#if UNITY_EDITOR||UNITY_ANDROID
        Debug.LogWarning(str);
#endif
#if !UNITY_EDITOR&&UNITY_IPHONE
        printLogWarning(str);
#endif
    }

    public static void LogError(string str)
    {
#if UNITY_EDITOR||UNITY_ANDROID
        Debug.LogError(str);
#endif
#if !UNITY_EDITOR&&UNITY_IPHONE
        printLogError(str);
#endif
    }
}
