using BetaFramework;
using Data.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class WebConfigMgr
{
    static Dictionary<Type, WebConfig> configDic = new Dictionary<Type, WebConfig>();

    static WebConfigMgr()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();
        var baseType = typeof(WebConfig);
        foreach (var type in types)
        {
            if (type.IsSubclassOf(baseType) && !type.IsAbstract)
            {
                var config = Activator.CreateInstance(type) as WebConfig;
                configDic.Add(type, config);
            }
        }
    }
    public static void Init()
    {
        LoadLocalRes();
        RefreshAll();
    }

    static void LoadLocalRes()
    {
        foreach (var item in configDic)
        {
            item.Value.LoadLocalData();
        }
    }

    static void RefreshAll()
    {
        foreach (var item in configDic)
        {
            Request(item.Key);
        }
    }

    public static T Get<T>() where T : WebConfig
    {
        return configDic[typeof(T)] as T;
    }

    public static void Refresh<T>(Action<bool, T> callback) where T : WebConfig
    {
        var type = typeof(T);
        Request(type, (succ, config) =>
       {
           callback(succ, config as T);
       });
    }

    static void Request(Type type, Action<bool, WebConfig> callback = null)
    {
        string json = JsonConvert.SerializeObject(configDic[type].GetRequest);
        WebRequestPostUtility.Instance.PostJson(Const.Elite_ServerUrl, (back) =>
        {
            if (back.isNetworkError || back.isHttpError)
            {
                callback?.Invoke(false, null);
            }
            else
            {
                var res = JsonConvert.DeserializeObject<BaseResponse>(back.downloadHandler.text);
                try
                {
                    if (res.code == 200)
                    {
                        var config = configDic[type].DeserializeResponse(back.downloadHandler.text);
                        callback?.Invoke(true, config);
                    }
                    else
                    {
                        Debug.LogErrorFormat("ReqWebRes error! mid=={0}, code=={1}", res.mId, res.code);
                        callback?.Invoke(false, null);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogErrorFormat("ReqWebRes error! mid=={0}, msg=={1}", res.mId, e.Message);
                    callback?.Invoke(false, null);
                }
            }
        }, json, AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().GetHeaders());
    }
}
