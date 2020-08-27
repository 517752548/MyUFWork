using System;
using System.Collections.Generic;
using System.ComponentModel;
using BetaFramework;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;
using PathC;
using UnityEngine.AddressableAssets;
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
	[Category("SDK Test"), DisplayName("闪退")]
    public void ForceExit()
    {
        GameObject go = null;
        Debug.Log(go.name);
    }

    
    [Category("SDK Test"), DisplayName("广告ID")]
    public int AdId { set; get; }
    
    
    
    [Category("数据"), DisplayName("清除存档")]
    public void ClearCache()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
    [Category("数据"), DisplayName("无限金币")]
    public void AddCoin()
    {
	    AppEngine.SyncManager.Data.Coin.Value = 999999;
    }
    [Category("数据"), DisplayName("自动填词")]
    public void AutoInputLevel()
    {
	    Const.UseInput = true;
    }
    
    [Category("数据"), DisplayName("自动跑关")]
    public void AutoLevel()
    {
	    Const.AutoPlay = true;
	    Time.timeScale = seppd;
    }

    [Category("数据"), DisplayName("不显示log")]
    public void NoLog()
    {
	    Debug.unityLogger.logEnabled = false;
    }
    [Category("数据"), DisplayName("跳Loading")]
    public void ToLoading()
    {
	    SceneManager.LoadScene(1);
    }
    [Category("数据"), DisplayName("不打FB点")]
    public void NoFB()
    {
	    Const.reportFB = false;
    }
    private int seppd = 3;
    [Category("倍速"), DisplayName("倍速")]
    [Increment(1), NumberRange(1, 7)]
    public int TimeSpeed
    {
	    set { seppd = value;}
	    get
	    {
		    return seppd;
	    }
    }
    
    //DebugInReleaseServer
    [Category("数据"), DisplayName("测试Version")]
    public void Version()
    {
	    //AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().LoadVersion();
    }
    [Category("数据"), DisplayName("测试服资源完整性")]
    public void DebugResources()
    {
	    Addressables.DownloadDependenciesAsync("OnlineBG");
	    Addressables.DownloadDependenciesAsync("OnLineLevel").Completed += op =>
	    {
		    Debug.LogError("下载成功");
	    };
	    //AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().LoadVersion();
    }
    [Category("数据"), DisplayName("正式服资源完整性")]
    public void ReleaseResources()
    {
	    //AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().LoadVersion();
    }
    
    
    [Category("数据"), DisplayName("显示答案")]
    public void ShowAnswer()
    {
        AppEngine.SGameSettingManager.ShowAnswer.Value = !AppEngine.SGameSettingManager.ShowAnswer.Value;
        UIManager.ShowMessage(string.Format("显示答案:{0}",AppEngine.SGameSettingManager.ShowAnswer.Value));
    }
    [Category("数据"), DisplayName("去除广告")]
    public void RemoveAD()
    {
	    AppEngine.SyncManager.Data.IsRemoveAd.Value = true;
    }
    
    [Category("数据"), DisplayName("显示广告AB")]
    public void ShowLevelAB()
    {
        UIManager.ShowMessage(string.Format("广告分组:{0}",AppEngine.SSystemManager.GetSystem<TestABSystem>().GetUserTestLib()));
    }
    [Category("数据"), DisplayName("切换广告A")]
    public void SetADAB()
    {
	    AppEngine.SSystemManager.GetSystem<TestABSystem>().ADAB.Value = "A";
	    UIManager.ShowMessage(string.Format("广告分组:{0}",AppEngine.SSystemManager.GetSystem<TestABSystem>().GetUserTestLib()));
    }
    [Category("数据"), DisplayName("切换广告B")]
    public void SetADB()
    {
	    AppEngine.SSystemManager.GetSystem<TestABSystem>().ADAB.Value = "B";
	    UIManager.ShowMessage(string.Format("广告分组:{0}",AppEngine.SSystemManager.GetSystem<TestABSystem>().GetUserTestLib()));
    }
    [Category("数据"), DisplayName("显示注册信息")]
    public void ShowAccountInfo()
    {
	    UIManager.ShowMessage(string.Format("设备注册:{0}fb注册{1}ID{2}",AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().PlayerLogin,AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().fbOnline.Value,AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().playerCrazeID.Value),5f);
    }
    [Category("数据"), DisplayName("切换词库A")]
    public void ChangeLevelA()
    {
	    AppEngine.SSystemManager.GetSystem<TestABWordLibSystem>().WordAB.Value =("A");
	    UIManager.ShowMessage(string.Format("切换成功，请重启"));
    }
    [Category("数据"), DisplayName("切换词库B")]
    public void ChangeLevelB()
    {
	    AppEngine.SSystemManager.GetSystem<TestABWordLibSystem>().WordAB.Value =("B");
	    UIManager.ShowMessage(string.Format("切换成功，请重启"));
    }
    [Category("数据"), DisplayName("显示奖励AB")]
    public void ShowRewardAB()
    {
	    UIManager.ShowMessage(string.Format("奖励AB->" + AppEngine.SSystemManager.GetSystem<RewardABSystem>().RewardAB.Value));
    }
    [Category("数据"), DisplayName("切换奖励A")]
    public void ChangeRewardA()
    {
	    AppEngine.SSystemManager.GetSystem<RewardABSystem>().RewardAB.Value =("A");
	    UIManager.ShowMessage(string.Format("切换成功，请重启"));
    }
    [Category("数据"), DisplayName("切换奖励B")]
    public void ChangeRewardB()
    {
	    AppEngine.SSystemManager.GetSystem<RewardABSystem>().RewardAB.Value =("B");
	    UIManager.ShowMessage(string.Format("切换成功，请重启"));
    }
    [Category("数据"), DisplayName("显示提示AB")]
    public void ShowTIPAB()
    {
	    UIManager.ShowMessage(string.Format("提示AB->" + AppEngine.SSystemManager.GetSystem<CellTipABSystem>().GetUserRewardLib()));
    }
    [Category("数据"), DisplayName("切换提示A")]
    public void ChangeTIPA()
    {
	    AppEngine.SSystemManager.GetSystem<CellTipABSystem>().DebugSetRewardAB("A");
	    UIManager.ShowMessage(string.Format("提示AB->" + AppEngine.SSystemManager.GetSystem<CellTipABSystem>().GetUserRewardLib()));
    }
    [Category("数据"), DisplayName("切换提示B")]
    public void ChangeTIPB()
    {
	    AppEngine.SSystemManager.GetSystem<CellTipABSystem>().DebugSetRewardAB("B");
	    UIManager.ShowMessage(string.Format("提示AB->" + AppEngine.SSystemManager.GetSystem<CellTipABSystem>().GetUserRewardLib()));
    }
    [Category("数据"), DisplayName("跳关卡")]
    [Increment(1), NumberRange(0, 50000000)]
    public int ItemID { set; get; }
    
    [Category("数据"), DisplayName("点击跳关")]
    public void SkipLevel()
    {
        AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value = ItemID;
        UIManager.ShowMessage(string.Format("跳关成功:{0}",AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value));
    }

    
    
    [Category("数据"), DisplayName("Count")]
    [Increment(1), NumberRange(0, 50)]
    public int ItemCount { set; get; }
    
    [Category("数据"), DisplayName("增加蜜蜂")]
    public void AddBee()
    {
	    AppEngine.SyncManager.Data.Bee.Value += 10;
    }

    [Category("每日挑战"), DisplayName("每日挑战")]
    [Increment(1), NumberRange(0, 50)]
    public int DailyTemp
    {
        set;
        get;
    }

    [Category("每日挑战"), DisplayName("每日挑战")]
    public void LogDropRate()
    {
        AppEngine.SSystemManager.GetSystem<DailySystem>().TempDaily = DailyTemp;
        AppEngine.SSystemManager.GetSystem<DailySystem>().NewDaily();
    }
  
    [Category("7日签到"), DisplayName("再次签到")]
    public void EnableTodaySign()
    {
	    AppEngine.SSystemManager.GetSystem<PlayerSignSystem>().ResetLastSignDateForTest();
    }
    [Category("7日签到"), DisplayName("签到天数")]
    [Increment(1), NumberRange(0, 7)]
    public int SignDays
    {
	    set { AppEngine.SSystemManager.GetSystem<PlayerSignSystem>().SetSignTimesForTest(value);}
	    get
	    {
		    return AppEngine.SSystemManager.GetSystem<PlayerSignSystem>().TodaySignIndex;
	    }
    }
}