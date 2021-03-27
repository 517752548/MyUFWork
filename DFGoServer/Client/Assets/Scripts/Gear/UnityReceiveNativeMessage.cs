using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnityReceiveNativeMessage : AndroidJavaProxy
{
    private OnNativeBack deleteFun;
    public delegate void OnNativeBack(int id, int intvalue, string str);
    //"com.alipay.UnityListener"
    public UnityReceiveNativeMessage(string javaInterface) : base(javaInterface)
    {
    }

    public UnityReceiveNativeMessage(AndroidJavaClass javaInterface) : base(javaInterface)
    {
    }
    
    public void SetLuaListener(OnNativeBack _deleteFun)
    {
        this.deleteFun = _deleteFun;
    }
    
    public void Send(int id, int intvalue, string str)
    {
        if (deleteFun != null)
        {
            deleteFun.Invoke(id,intvalue,str);
        }
    }
}
