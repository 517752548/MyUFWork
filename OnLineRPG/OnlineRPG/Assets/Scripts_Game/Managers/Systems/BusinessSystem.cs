using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using EventUtil;
using Newtonsoft.Json;
using UnityEngine;

public class BusinessSystem : ISystem
{
    public Action<string,int> timeLoop;
    private BusinessSystemNet net;
    private bool timeLooped = false;
    public bool timeOut = true;
    private GameUI UiToSwitch;

    public override void InitSystem()
    {
        net = new BusinessSystemNet();
        base.InitSystem();
        GetBusinessConfig();
    }

    public override void OnEnterUI(GameUI UiToSwitch)
    {
        base.OnEnterUI(UiToSwitch);
        UiToSwitch = this.UiToSwitch;
    }

    private void GetBusinessConfig()
    {
        net.GetConfig((ok) =>
        {
            if (ok)
            {
                if (DataManager.businessGiftData.inited && !timeLooped)
                {
                    timeLooped = true;
                    TimersManager.SetLoopableTimer(1, LoopTime);
                }
            }

            if (UiToSwitch != null && UiToSwitch == GameUI.Home)
            {
                if (DataManager.businessGiftData.inited && DataManager.businessGiftData.needshowpanel == 1 && !DataManager.businessGiftData.AllGiftBuyed() && DataManager.businessGiftData.LevelEnough() && !AppEngine.SSystemManager.GetSystem<BusinessSystem>().timeOut)
                {
                    HomeRootFsmManager.CheckRefresh();
                }
                
            }
        });
    }

    private void LoopTime()
    {

        TimeSpan span = DataManager.businessGiftData.cutdownTime.Subtract(AppEngine.STimeHeart.RealTime);
        if (span.TotalSeconds > 0)
        {
            timeOut = false;
            timeLoop?.Invoke($"{span.Hours:00}:{span.Minutes:00}:{span.Seconds:00}",(int)span.TotalSeconds);
        }
        else
        {
            timeOut = true;
            timeLoop?.Invoke("00:00:00",0);
        }
        
    }

    public void PlayerBuyItem(IapProductConfig_Data iapdata)
    {
        net.PlayerBuy(iapdata);
    }
    public override void LeaveOneHours()
    {
        base.LeaveOneHours();
        GetBusinessConfig();
    }
}

class BusinessSystemNet
{
    public void GetConfig(Action<bool> callback)
    {
        int channel = Record.GetInt("AFBack",0);
        if (channel != 1)
        {
            channel = 2;
        }
        ReqData requestConig = new ReqData
        {
            mId = (int) ServerCode.BusinessGift,
            abGroup = AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetUserRewardLib(),
            channel = channel,
#if UNITY_IOS
            platform = "ios"
#else
            platform = "android"
#endif
            
        };
        //Debug.LogError(JsonConvert.SerializeObject(requestConig));
        WebRequestPostUtility.Instance.PostJson(Const.ServerUrl, (aobj) =>
            {
                if (aobj.isHttpError || aobj.isNetworkError)
                {
                    Debug.LogError("Business config error");
                    callback?.Invoke(false);
                }
                else
                {
                    var data = JsonConvert.DeserializeObject<RepData>(aobj.downloadHandler.text);
                    //Debug.LogError("Business配置" + aobj.downloadHandler.text);
                    if (data.code == (int) RepCodes.SUCCESSED)
                    {
                        DataManager.businessGiftData.SetServerData(data);
                        callback?.Invoke(true);
                    }
                }
            }, JsonConvert.SerializeObject(requestConig),
            AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().GetHeaders());
    }

    /// <summary>
    /// 获取用户的分层
    /// </summary>
    public void GetPlayerLayer()
    {
        ReqTagData requestConig = new ReqTagData
        {
            mId = (int) ServerCode.PlayerLayer,
        };
        Debug.LogError(JsonConvert.SerializeObject(requestConig));
        WebRequestPostUtility.Instance.PostJson(Const.ServerUrl, (aobj) =>
            {
                if (aobj.isHttpError || aobj.isNetworkError)
                {
                    Debug.LogError("Business config error");
                }
                else
                {
                    var data = JsonConvert.DeserializeObject<RepTagData>(aobj.downloadHandler.text);
                    Debug.LogError("Business配置" + aobj.downloadHandler.text);
                    if (data.code == (int) RepCodes.SUCCESSED)
                    {
                        
                    }
                }
            }, JsonConvert.SerializeObject(requestConig),
            AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().GetHeaders());
    }
    public void PlayerBuy(IapProductConfig_Data iapdata)
    {
        int activityId = 0;
        if (DataManager.businessGiftData.inited)
        {
            for (int i = 0; i < DataManager.businessGiftData.shopItem.Length; i++)
            {
                if (DataManager.businessGiftData.shopItem[i].giftId == iapdata.ItemID)
                {
                    activityId = DataManager.businessGiftData.id.Value;
                }
            }
        }

        float price = 0;
        bool ok = float.TryParse(iapdata.ProductDollarPrice, out price);
        if (!ok)
        {
            BetaFramework.LoggerHelper.Error("GetPrice IapItems productPrice Not Right");
        }
        ReqBuyData requestConig = new ReqBuyData
        {
            mId = (int) ServerCode.PlayerBuy,
            id = activityId,
            giftId = iapdata.ItemID,
            cost = price
        };
        Debug.Log(JsonConvert.SerializeObject(requestConig));
        WebRequestPostUtility.Instance.PostJson(Const.ServerUrl, (aobj) =>
            {
                if (aobj.isHttpError || aobj.isNetworkError)
                {
                    Debug.LogError("Business config error");
                }
                else
                {
                    var data = JsonConvert.DeserializeObject<RepBuyData>(aobj.downloadHandler.text);
                    Debug.Log("Business配置" + aobj.downloadHandler.text);
                    if (data.code == (int) RepCodes.SUCCESSED)
                    {
                        
                    }
                }
            }, JsonConvert.SerializeObject(requestConig),
            AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().GetHeaders());
    }
    
}

class ReqTagData
{
    public int mId;
}

class RepTagData
{
    public int mId;
    public int code;
    public TagData data;
}

class TagData
{
    public int layered;
}
class ReqBuyData
{
    public int mId;
    public int id;
    public int giftId;
    public float cost;
}

class RepBuyData
{
    public int mId;
    public int code;
    public string data;
}

class ReqData
{
    public int mId;
    public string abGroup;
    public string platform;
    public int channel;
}

public class RepData
{
    public int mId;
    public int code;
    public BusData data;
}

public class BusData
{
    public int id;
    public int level;
    public int flashing;
    public int countdown;
    public int panel;
    public int panelShop;
    public string panelWord;
    public string panelFre;
    public BusShopItem[] giftList;
}

public class BusShopItem
{
    public int giftId;
    public string buyId;
}