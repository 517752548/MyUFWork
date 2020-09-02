using BetaFramework;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleData
{
    
    //当前称号ID
    public static int currentTitleId = 0;
    //获得的新称号
    public static int obtainId;
    //限时
    public static int showTime;
    //是否浏览中
    public static bool isBrowsing = false;
    //称号配置
    public static List<TitleReceiveData> configList = new List<TitleReceiveData>();

    //从服务器拉取到已拥有称号数据
    public static Dictionary<int, TitleReceiveData> titleDic = new Dictionary<int, TitleReceiveData>();

    //已拥有的称号 和对应的时间戳
    public static Dictionary<int, string> title_time = new Dictionary<int, string>();


    /// <summary>
    /// 根据id返回对应的 称号数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static TitleReceiveData GetReceiveData(int id)
    {
        foreach (var item in configList)
        {
            if (item.id == id)
            {
                return item;
            }
        }
        return null;
    }

    /// <summary>
    /// 提交数据,更换称号或者添加新称号
    /// </summary>
    /// <param name="callback"></param>
    public static void UploadConfig(UploadTitleType type ,Action<bool> callback)
    {
        UploadTitleData uploadData = null;
        if (type == UploadTitleType.Refresh)
        {
            uploadData = new UploadTitleData((int)ServerCode.UploadTitleData, currentTitleId,
                0, showTime);
        }
        else if (type == UploadTitleType.add)
        {
            uploadData = new UploadTitleData((int)ServerCode.UploadTitleData, currentTitleId,
                obtainId, showTime);
        }
        
        
        WebRequestPostUtility.Instance.PostJson(Const.Elite_ServerUrl, (aobj) =>
        {
            if (aobj.isHttpError || aobj.isNetworkError)
            {
                Debug.LogError("upload config error");
                callback?.Invoke(false);
            }
            else
            {
                var data = JsonConvert.DeserializeObject<TitleBackData>(aobj.downloadHandler.text);
                //Debug.LogError("Title配置" + aobj.downloadHandler.text);
                if (data.code == 200)
                {                  
                    callback?.Invoke(true);
                }
                else
                {
                    callback?.Invoke(false);
                }
            }
        }, JsonConvert.SerializeObject(uploadData),
            AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().GetHeaders());
    }
    /// <summary>
    /// 获取到已拥有的称号
    /// </summary>
    public static void GetWebTitle()
    {
        configList = WebConfigMgr.Get<TitleConfig>().data;

        ReqTagData repTagData = new ReqTagData
        {
            mId = (int)ServerCode.GetOwendTitle,
        };

        WebRequestPostUtility.Instance.PostJson(Const.Elite_ServerUrl, (aobj) =>
        {
            if (aobj.isHttpError || aobj.isNetworkError)
            {
                Debug.LogError("upload config error");
                
            }
            else 
            {
                var data = JsonConvert.DeserializeObject<GetTitle>(aobj.downloadHandler.text);
                
                if (data.code == 200)
                {
                    for (int i = 0; i < data.data.dataList. Count; i++)
                    {
                        foreach (var item in configList)
                        {
                            if (item.id == data.data.dataList[i].id)
                            {
                                titleDic.Add(data.data.dataList[i].id, item);
                                title_time.Add(item.id , data.data.dataList[i].time);
                            }
                        }
                        
                    }
                }
            }
        }, JsonConvert.SerializeObject(repTagData),
            AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().GetHeaders());
    }
    /// <summary>
    /// 删除过时称号
    /// </summary>
    public static void DeleteTitle(int deleteId , Action<bool> callback)
    {
        DeleteTitleData deleteTitleData = new DeleteTitleData
        {
            mId = (int)ServerCode.DeleteTitle,
            delete_id = deleteId
        };

        WebRequestPostUtility.Instance.PostJson(Const.Elite_ServerUrl, (aobj) =>
        {
            if (aobj.isHttpError || aobj.isNetworkError)
            {
                Debug.LogError("upload config error");
                
            }
            else 
            {
                Debug.LogError("Title配置" + aobj.downloadHandler.text);
                var data = JsonConvert.DeserializeObject<TitleBackData>(aobj.downloadHandler.text);
                
                if (data.code == 200)
                {
                    callback?.Invoke(true);
                }
                else
                {
                    callback?.Invoke(false);
                }
            }
        }, JsonConvert.SerializeObject(deleteTitleData),
            AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().GetHeaders());
    }
}
public enum UploadTitleType{
    Refresh,
    add
}

