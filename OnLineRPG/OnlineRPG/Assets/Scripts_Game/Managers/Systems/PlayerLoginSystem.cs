using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Data.Request;
using EventUtil;
using Newtonsoft.Json;
using UnityEngine;

public class PlayerLoginSystem : ISystem
{
    //程江分配的唯一id
    public RecordExtra.StringPrefData playerCrazeID;
    public RecordExtra.StringPrefData deviceID;
    public RecordExtra.StringPrefData token;
    /// <summary>
    /// fb有没有登录，不是sdk的登录是自己服务器的登录
    /// </summary>
    public RecordExtra.BoolPrefData fbOnline;
    private bool finish = false;

    public override void InitSystem()
    {
        playerCrazeID = new RecordExtra.StringPrefData(PrefKeys.playerCrazeId, "");
        deviceID = new RecordExtra.StringPrefData(PrefKeys.deviceId, "");
        token = new RecordExtra.StringPrefData(PrefKeys.tokenID, "");
        fbOnline = new RecordExtra.BoolPrefData(PrefKeys.fbOnline,false);
        FTDSdk.getInstance().getDeviceInfo(DeviceInfoBack);
#if UNITY_EDITOR
        DeviceInfoBack("{\"userid\":\"editor1234567890sx12314\"}");
#endif
        TimersManager.SetTimer(2, () =>
        {
            if (!finish)
            {
                finish = true;
                base.InitSystem(); 
            }
        });
    }

    private void DeviceInfoBack(string deviceInfo)
    {
        BIDeviceData data = JsonConvert.DeserializeObject<BIDeviceData>(deviceInfo);
        Debug.Log(data.userid);
        if (!string.IsNullOrEmpty(data.userid))
        {
            if (string.IsNullOrEmpty(deviceID.Value))
            {
                deviceID.Value = data.userid;
            }
            else
            {
                if (!deviceID.Value.Equals(data.userid))
                {
                    //userid发生了变化，看是否需要处理
                }
            }

            if (string.IsNullOrEmpty(playerCrazeID.Value))
            {
                CreatAccount((OK) =>
                {
                    if (OK)
                    {
                        AppEngine.SyncManager.DoSync((ok1, ok2) =>
                        {
                            LoadFinish();
                            //创建成功
                            Debug.Log("账户注册成功");
                            FireLoginState();
                        },true,true);
                    }
                    else
                    {
                        LoadFinish();
                    }
                    
                });
            }
            else
            {
                Debug.Log("不需要注册账户");
                CheckFBLogin();
                LoadFinish();
            }
        }
    }

    private void LoadFinish()
    {
        if (!finish)
        {
            finish = true;
            base.InitSystem(); 
        }
    }
    
    public void CheckFBLogin()
    {
        if (!string.IsNullOrEmpty(AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBID.Value) && !fbOnline.Value)
        {
            PlayerLoginFB((ok, firstBind) =>
            {
                if (ok)
                {
                    LoggerHelper.Log("fb online 登录成功");
                    if (firstBind)
                        UIManager.OpenUIAsync(ViewConst.prefab_FBLoginGiftDialog);
                }
                else
                {
                    LoggerHelper.Log("fb online 登录失败");
                }

                FireLoginState();
            });
        }
        else
        {
            FireLoginState();
        }
    }

    /// <summary>
    /// 用户有没有登录
    /// </summary>
    public bool PlayerLogin
    {
        get
        {
            if (string.IsNullOrEmpty(playerCrazeID.Value))
            {
                return false;
            }

            return true;
        }
    }


    private void CreatAccount(Action<bool> callback)
    {
        Debug.Log("创建账户");
        if (string.IsNullOrEmpty(deviceID.Value))
        {
            callback.Invoke(false);
            return;
        }
        LoginDataRequest request = new LoginDataRequest(ServerCode.CreatAccount, AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBName.Value,deviceID.Value);
        string json = JsonConvert.SerializeObject(request);
        WebRequestPostUtility.Instance.PostJson(Const.ServerUrl, (back) =>
        {
            if (back.isNetworkError || back.isHttpError)
            {
                Debug.LogError("creat account error");
                callback.Invoke(false);
            }
            else
            {
                LoggerHelper.Log(back.downloadHandler.text);
                LoginDataBack backdata = JsonConvert.DeserializeObject<LoginDataBack>(back.downloadHandler.text);
                playerCrazeID.Value = backdata.data.passportId;
                token.Value = backdata.data.token;
                callback.Invoke(true);
            }
        }, json,GetHeaders());
    }


    /// <summary>
    /// 登录fb的接口
    /// </summary>
    /// <param name="callback"></param>
    public void PlayerLoginFB(Action<bool, bool> callback)
    {
        LoginFBRequest request = new LoginFBRequest(ServerCode.CreatFBAccount, AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBID.Value,AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBName.Value,deviceID.Value);
        request.url = AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBImageUrl.Value;
        string json = JsonConvert.SerializeObject(request);
        WebRequestPostUtility.Instance.PostJson(Const.ServerUrl, (back) =>
        {
            if (back.isNetworkError || back.isHttpError)
            {
                LoggerHelper.Log("creat account error");
                callback.Invoke(false, false);
            }
            else
            {
                LoggerHelper.Log(back.downloadHandler.text);
                LoginFBDataBack backdata = JsonConvert.DeserializeObject<LoginFBDataBack>(back.downloadHandler.text);
                if (backdata.code != 200)
                {
                    callback.Invoke(false, false);
                }
                else
                {
                    if (backdata.data.binding)
                    {
                        callback.Invoke(true, true); 
                    }
                    else
                    {
                        playerCrazeID.Value = backdata.data.playerInfo.passportId;
                        token.Value = backdata.data.playerInfo.token;
                        AppEngine.SyncManager.OnUserChanged();
                        callback.Invoke(true, false); 
                        
                    }

                    fbOnline.Value = true;
                }
                
            }
        }, json,GetHeaders());
    }

    /// <summary>
    /// 登出fb
    /// </summary>
    /// <param name="callback"></param>
    public void LoginOutFB(Action<bool> callback)
    {
        LoginFBOutRequest request = new LoginFBOutRequest(ServerCode.FBLoginOut, AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBID.Value,AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBName.Value,deviceID.Value);
        string json = JsonConvert.SerializeObject(request);
        WebRequestPostUtility.Instance.PostJson(Const.ServerUrl, (back) =>
        {
            if (back.isNetworkError || back.isHttpError)
            {
                callback.Invoke(false);
            }
            else
            {
                LoggerHelper.Log(back.downloadHandler.text);
                LoginFBOutDataBack backdata = JsonConvert.DeserializeObject<LoginFBOutDataBack>(back.downloadHandler.text);
                if (backdata.code != 200)
                {
                    callback.Invoke(false);
                }
                else
                {
                    playerCrazeID.Value = backdata.data.playerInfo.passportId;
                    token.Value = backdata.data.playerInfo.token;
                    AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().LoginOutFB();
                    callback.Invoke(true);
                    fbOnline.Value = false;
                    AppEngine.SyncManager.OnUserChanged();
                    //EventDispatcher.TriggerEvent(GlobalEvents.FBLoginOut);
                }
                
            }
        }, json,GetHeaders());
    }


    /// <summary>
    /// 获取用户的线上基本信息，这个接口目前应该用不到
    /// </summary>
    /// <param name="callback"></param>
    public void GetPlayerOnLineInfo(Action<bool> callback)
    {
        LoginFBOutRequest request = new LoginFBOutRequest(ServerCode.GetPlayerOnlineData, AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBID.Value,AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBName.Value,deviceID.Value);
        string json = JsonConvert.SerializeObject(request);
        WebRequestPostUtility.Instance.PostJson(Const.ServerUrl, (back) =>
        {
            if (back.isNetworkError || back.isHttpError)
            {
                callback.Invoke(false);
            }
            else
            {
                LoggerHelper.Log(back.downloadHandler.text);
                LoginFBOutDataBack backdata = JsonConvert.DeserializeObject<LoginFBOutDataBack>(back.downloadHandler.text);
                if (backdata.code != 200)
                {
                    callback.Invoke(false);
                }
                else
                {
                    //playerCrazeID.Value = backdata.data.playerInfo.passportId;
                    //token.Value = backdata.data.playerInfo.token;
                    callback.Invoke(true); 
                }
                
            }
        }, json,GetHeaders());
    }

    /// <summary>
    /// 修改用户注册信息
    /// </summary>
    /// <param name="callback"></param>
    public void ChangePlayerInfo(Action<bool> callback)
    {
        ChangeInfoData request = new ChangeInfoData(ServerCode.ChangePlayerInfo,AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBName.Value,"1");
        string json = JsonConvert.SerializeObject(request);
        WebRequestPostUtility.Instance.PostJson(Const.ServerUrl, (back) =>
        {
            if (back.isNetworkError || back.isHttpError)
            {
                callback.Invoke(false);
            }
            else
            {
                LoggerHelper.Log(back.downloadHandler.text);
                ChangeInfoBack backdata = JsonConvert.DeserializeObject<ChangeInfoBack>(back.downloadHandler.text);
                if (backdata.code != 200)
                {
                    callback.Invoke(false);
                }
                else
                {
                    //playerCrazeID.Value = backdata.data.playerInfo.passportId;
                    //token.Value = backdata.data.playerInfo.token;
                    callback.Invoke(true); 
                }
                
            }
        }, json,GetHeaders());
    }
    /// <summary>
    /// 获取headers
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, string> GetHeaders()
    {
        Dictionary<string,string> headers = new Dictionary<string, string>();
        headers.Add("PassportId",playerCrazeID.Value);
        headers.Add("Token",token.Value);
        return headers;
    }
    
    public Dictionary<string, string> GetFastRaceHeaders()
    {
        Dictionary<string,string> headers = new Dictionary<string, string>();
        headers.Add("PassportId",deviceID.Value);
        headers.Add("Token",token.Value);
        return headers;
    }

    /// <summary>
    /// 广播登陆状态
    /// </summary>
    private void FireLoginState()
    {
        EventDispatcher.TriggerEvent(GlobalEvents.LoginStatusRefresh);
    }
}

public class LoginDataRequest : BaseRequestParam
{
    public string userName;
    public string platform;
    public int handIndex;
    public string deviceId;
    public LoginDataRequest(ServerCode mid,string userName,string deviceid)
    {
        this.mId = (int)mid;
        this.userName = userName;
        this.deviceId = deviceid;
#if UNITY_ANDROID
        platform = "android";
#else
        platform = "ios";
        #endif
    }
}

public class LoginFBRequest : BaseRequestParam
{
    public string userName;
    public string url;
    public string fbId;
    public string deviceId;
    public LoginFBRequest(ServerCode mid,string fbid,string userName,string deviceid)
    {
        this.mId = (int)mid;
        this.fbId = fbid;
        this.userName = userName;
        this.deviceId = deviceid;
    }
}
public class LoginFBOutRequest : BaseRequestParam
{
    public string fbId;
    public string platform;
    public string deviceId;
    public LoginFBOutRequest(ServerCode mid,string fbid,string userName,string deviceid)
    {
        this.mId = (int)mid;
        this.fbId = fbid;
        this.deviceId = deviceid;
#if UNITY_ANDROID
        platform = "android";
#else
        platform = "ios";
#endif
    }
}
public class LoginDataBack : BaseResponseData<LoginBack>
{
}
public class LoginFBDataBack : BaseResponseData<LoginFBBack>
{
}
public class LoginFBOutDataBack : BaseResponseData<LoginFBOutBack>
{
}
public class ChangeInfoBack : BaseResponseData<string>
{
}
public class ChangeInfoData:BaseRequestParam
{
    public string userName;
    public string handIndex;
    public ChangeInfoData(ServerCode mid,string userName,string handIndex)
    {
        this.mId = (int)mid;
        this.userName = userName;
        this.handIndex = handIndex;
    }
}
public class LoginBack
{
    public string passportId;
    public string token;
}

public class LoginFBBack
{
    public bool binding;
    public LoginFBBackInfo playerInfo;

}
public class LoginFBOutBack
{
    public LoginFBBackInfo playerInfo;
}
public class LoginFBBackInfo
{
    public string token;
    public string passportId;
    public string abGroup;
    public string handIndex;
    public string handUrl;
    public string userName;
}