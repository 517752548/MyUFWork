using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidCall
{
    
    AndroidJavaObject jo_MathClass;

    public void SetClassName(string className)
    {
        jo_MathClass = new AndroidJavaObject(className);
        Debug.Log(className);
    }

    public void SetActivity()
    {
        AndroidJavaClass act = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        var actObj = act.GetStatic<AndroidJavaObject>("currentActivity");
        jo_MathClass.Call("SetActivity",actObj);
    }
    
    public void CallStaticMethod(string methodName)
    {
        jo_MathClass.CallStatic(methodName);
    }
    
    public void CallStaticMethod_S(string methodName,string para)
    {
        jo_MathClass.CallStatic(methodName,para);
    }
    
    public void CallStaticMethod_s_s(string methodName,string para,string para2)
    {
        jo_MathClass.CallStatic(methodName,para,para2);
    }
    
    public void CallMethod(string methodName)
    {
        jo_MathClass.Call(methodName);
    }
    
    public void CallMethod_Para(string methodName,params object[] args)
    {
        jo_MathClass.Call(methodName,args);
    }
    
    public void CallMethod_S(string methodName,string para)
    {
        jo_MathClass.Call(methodName,para);
    }
    
    public void CallMethod_s_s(string methodName,string para,string para2)
    {
        jo_MathClass.Call(methodName,para,para2);
    }
}
