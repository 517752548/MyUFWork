using System.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public partial class SROptions
{
    private bool m_IsInit = false;

    void Init()
    {

    }


    [Category("Key Map"), DisplayName(" ctrl + shift + F1 \t\t System Info \n ctrl + shift + F2 \t\t Console \n ctrl + shift + F3 \t\t GM \n ctrl + shift + F4 \t\t Profile \n ")]
    public void World()
    {
    }

    [Category("SDK Test"), DisplayName("抛出异常")]
    public void ThrowException()
    {
        throw new Exception("test Exception");
    }

    [Category("SDK Test"), DisplayName("展示插屏")]
    public void ShowInterstitial()
    {
        //AppEngine.SAdManager.ShowInterstitialNoCondition(AdManager.InterstitialCallPlace.none);
    }

    [Category("SDK Test"), DisplayName("显示插屏分组AB")]
    public void ShowInGroupAB()
    {
        //UIManager.ShowMessage(string.Format("插屏分组:{0}", AppEngine.SSystemManager.GetSystem<TestABSystem>().GetUserTestLib()));
    }

    [Category("SDK Test"), DisplayName("视频")]
    public void ShowReward()
    {
        //BetaFramework.AppEngine.SAdManager.ShowRewardVideo(AdManager.RewardVideoCallPlace.Shop);
    }
    [Category("SDK Test"), DisplayName("广告测试")]
    public void ShowTestReward()
    {
    }
    [Category("SDK Test"), DisplayName("闪退")]
    public void ForceExit()
    {
        GameObject go = null;
        Debug.Log(go.name);
    }

    [Category("SDK Test"), DisplayName("广告ID")]
    public int AdId { set; get; }
    
    [Category("关卡"), DisplayName("跳关卡"), Sort(1)]
    [Increment(1), NumberRange(0, 50000000)]
    public int ItemID { set; get; }

    [Category("关卡"), DisplayName("点击跳关"), Sort(1)]
    public void SkipLevel()
    {
        //AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value = ItemID;
        //UIManager.ShowMessage(string.Format("跳关成功:{0}", AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value));
    }


    [Category("数据"), DisplayName("清除本地加服务器存档"), Sort(-999)]
    public void ClearServerData()
    {

    }

    [Category("数据"), DisplayName("清除本地存档"), Sort(-998)]
    public void ClearCache()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    [Category("数据"), DisplayName("宠物ID"),Sort(-995)]
    [Increment(1), NumberRange(0, 50000000)]
    public int petID { set; get; }
    [Category("数据"), DisplayName("1000金币和小人"),Sort(-994)]
    public void SendMeEmail()
    {
        //AppEngine.SSystemManager.GetSystem<EmailSystem>().SendDailyEmail(1000, petID.ToString());
    }

    [Category("数据"), DisplayName("称号ID"),Sort(-993)]
    [Increment(1), NumberRange(0, 50000000)]
    public int titleID { set; get; }
    [Category("数据"), DisplayName("添加称号"),Sort(-992)]
    public void AddTitle()
    {

    }
    
    [Category("数据"), DisplayName("不显示log")]
    public void NoLog()
    {
        PlayerPrefs.SetInt("showlog", 1);
        Debug.unityLogger.logEnabled = false;
    }

    [Category("数据"), DisplayName("跳Loading")]
    public void ToLoading()
    {
        SceneManager.LoadScene(1);
    }

}
