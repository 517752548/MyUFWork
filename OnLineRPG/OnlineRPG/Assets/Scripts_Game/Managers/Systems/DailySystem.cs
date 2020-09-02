using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Newtonsoft.Json;
using UnityEngine;

public class DailySystem : ISystem
{
    public RecordExtra.IntPrefData Year;
    public RecordExtra.IntPrefData Mon;

    public int TempDaily = 0;
    private DailyRewardAB _rewardAb;

    /// <summary>
    /// 今天的
    /// </summary>
    private RecordExtra.ObjectPrefData<List<int>> todayCategorys;

    private RecordExtra.ObjectPrefData<List<DailyQuestionEntity>> todayLevels;

    private bool CheckedTodayState = false;
    /// <summary>
    /// 1 language  2 lifestyle  3 history   4 geography   5 entertainment   6 science
    /// </summary>
    public override void InitSystem()
    {
        Year = new RecordExtra.IntPrefData(PrefKeys.DailyYear,2020);
        Mon = new RecordExtra.IntPrefData(PrefKeys.DailyMonth,8);
        todayCategorys = new RecordExtra.ObjectPrefData<List<int>>(PrefKeys.TodayCategory, new List<int>());
        todayLevels =
            new RecordExtra.ObjectPrefData<List<DailyQuestionEntity>>(PrefKeys.TodayLevelEntitys,
                new List<DailyQuestionEntity>());
        AppEngine.STimeHeart.OnTimeUpdate += CheckDailyInfo;
        ResourceManager.LoadAsync<DailyRewardAB>(
#if UNITY_IOS
            string.Format("DailyRewardAB_Ios_ItemReward_{0}.asset", AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetUserRewardLib()), 
#else
            string.Format("DailyRewardAB_Android_ItemReward_{0}.asset", AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetUserRewardLib()), 
#endif
            ok =>
            {
                _rewardAb = ok;
                base.InitSystem();
            });
        
    }

    public DailyRewardAB GetDailyRewardConfig()
    {
        return _rewardAb;
    }



    
    public void TodayWin()
    {
        AppEngine.SyncManager.Data.Stars.Value++;
        todayLevels.Value = new List<DailyQuestionEntity>();
        todayCategorys.Value = new List<int>();
        AppEngine.SyncManager.Data.ToadyFinished.Value = true;
    }

    #region Daily 存档逻辑

    /// <summary>
    /// 校验每日挑战日期
    /// </summary>
    private void CheckDailyInfo()
    {
        if (CheckedTodayState)
        {
            CheckedTodayState = true;
            return;
        }

        if (PlatformUtil.GetAppIsRelease())
        {
            //if (MonKey.Value != DateTime.Now.ToString("yy-MM"))
            if (AppEngine.SyncManager.Data.MonKey.Value != AppEngine.STimeHeart.ServerTime.ToString("yy-MM"))
            {
                NewMon();
            }
        }
        else
        {
            //if (MonKey.Value != DateTime.Now.ToString("yy-MM"))
            if (AppEngine.SyncManager.Data.MonKey.Value != DateTime.Now.ToString("yy-MM"))
            {
                NewMon();
            }
        }
        

        //if (TodayKey.Value != DateTime.Now.ToString("yyyy-MM-dd"))
        if (AppEngine.SyncManager.Data.TodayKey.Value != AppEngine.STimeHeart.ServerTime.ToString("yyyy-MM-dd"))
        {
            NewDaily();
        }
    }

    /// <summary>
    /// 新的一个月
    /// </summary>
    private void NewMon()
    {
        if (PlatformUtil.GetAppIsRelease())
        {
            //MonKey.Value = DateTime.Now.ToString("yy-MM");
            AppEngine.SyncManager.Data.MonKey.Value = AppEngine.STimeHeart.ServerTime.ToString("yy-MM");
            Year.Value = AppEngine.STimeHeart.ServerTime.Year;
            Mon.Value = AppEngine.STimeHeart.ServerTime.Month;
            AppEngine.SyncManager.Data.Stars.Value = 0;
            //清楚每日挑战的存档
            ResetToday();
        }
        else
        {
            //MonKey.Value = DateTime.Now.ToString("yy-MM");
            AppEngine.SyncManager.Data.MonKey.Value = DateTime.Now.ToString("yy-MM");
            Year.Value = DateTime.Now.Year;
            Mon.Value = DateTime.Now.Month;
            AppEngine.SyncManager.Data.Stars.Value = 0;
            //清楚每日挑战的存档
            ResetToday();
        }
        
    }

    /// <summary>
    /// 新的一天
    /// </summary>
    public void NewDaily()
    {
        //TodayKey.Value = DateTime.Now.ToString("yyyy-MM-dd");
        AppEngine.SyncManager.Data.TodayKey.Value = AppEngine.STimeHeart.ServerTime.ToString("yyyy-MM-dd");
        ResetToday();
    }

    /// <summary>
    /// 重置当天数据
    /// </summary>
    private void ResetToday()
    {
        Record.DeleteKey(PrefKeys.DailyLevelProgress);
        AppEngine.SyncManager.Data.ToadyFinished.Value = false;
        AppEngine.SyncManager.Data.ToadyFinished.ResetLastValue();
        todayCategorys.Value = new List<int>();
        todayLevels.Value = new List<DailyQuestionEntity>();
    }

    #endregion


    public List<int> GetTodayLevelCategory()
    {
        return todayCategorys.Value;
    }

    /// <summary>
    /// 生成今天的关卡问题内容
    /// </summary>
    /// <returns></returns>
    public void CreateTodayLevelCategory(Action<bool> callback)
    {
        DailyRequestWord request = new DailyRequestWord(ServerCode.DailyLib, TempDaily);
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
                DailyWordList dailylist = JsonConvert.DeserializeObject<DailyWordList>(back.downloadHandler.text);
                if (dailylist.code != 200)
                {
                    callback.Invoke(false);
                }
                else
                {
                    List<int> categorys = new List<int>();
                    for (int i = 0; i < dailylist.data.dailyInit.Count; i++)
                    {
                        if (!categorys.Contains(dailylist.data.dailyInit[i].CategoryID))
                        {
                            categorys.Add(dailylist.data.dailyInit[i].CategoryID);
                        }
                    }
                    
                    todayCategorys.Value = categorys;
                    todayLevels.Value = dailylist.data.dailyInit;
                    callback.Invoke(true);
                }
            }
        }, json);
    }

    /// <summary>
    /// 获取今日关卡信息
    /// </summary>
    /// <returns></returns>
    public List<DailyQuestionEntity> GetDailyLevel()
    {
        return todayLevels.Value;
    }

    public void PlayDailyGame()
    {
        UIManager.OpenUIAsync(ViewConst.prefab_GameLoadingWindow, (ui, para) =>
        {
            TimersManager.SetTimer(0.3f, () =>
            {
                if (todayLevels.Value.Count > 0)
                {
                    DataManager.ProcessData._GameMode = GameMode.Daily;
                    MainSceneDirector.Instance.SwitchUi(GameUI.Game, ok =>
                    {
                        TimersManager.SetTimer(0.2f,
                            () =>
                            {
                                UIManager.CloseUIWindow(
                                    UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow));
                            });
                    });

                }
                else
                {
                    //进入失败就返回
                    DataManager.ProcessData._GameMode = GameMode.Classic;
                    MainSceneDirector.Instance.SwitchUi(GameUI.Home, ok =>
                    {
                        UIManager.CloseUIWindow(UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow));
                    });
                    
                }
            });
        });
    }
}