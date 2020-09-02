using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using EventUtil;
using Newtonsoft.Json;
using Scripts.Utility;
using UnityEngine;

public class CupLifePlaySystem : ISystem
{
    public CupLifePlaySystemNet net;

    private CupLifeGameButton _fastRaceGameButton;
    

    public RecordExtra.StringPrefData todayShowPanel;
    public Action<string> TimeAction;
    public bool btnAdd = false;
    private bool inMainHome = false;
    public int playerRank { get; set; }
    private Coroutine timeLoop;
    

    public bool activityEnable
    {
        get { return _activityenable; }
        set
        {
            _activityenable = value;
            //Debug.LogError("活动状态:" + value);
        }
    }

    public override void OnEnterUI(GameUI UiToSwitch)
    {
        
        if (UiToSwitch == GameUI.Home)
        {
            inMainHome = true;
            RefreshStatus();
        }
        else
        {
            inMainHome = false;
        }

    }

    private void RefreshFRBtn()
    {
        if (!ActivityImg())
        {
            return;
        }

        Debug.Log("FR活动进行中");
        // if (!btnAdd)
        // {
        //     btnAdd = true;
        //     ((HomeRoot) MainSceneDirector.Instance.GetUIRoot(GameUI.Home)).GetHomeUi<FastRaceGameButton>().Refresh();
        //     if (timeLoop == null)
        //         timeLoop = AppThreadController.instance.StartCoroutine(LoopTime());
        // }
    }

    public void RefreshEnterButton()
    {
        FastRaceGameButton button =  ((HomeRoot) MainSceneDirector.Instance.GetUIRoot(GameUI.Home)).GetHomeUi<FastRaceGameButton>();
        if (button)
        {
            button.RefreshButton();
        }
    }

    /// <summary>
    /// 需要主动弹出锦标赛的欢迎界面吗
    /// </summary>
    /// <returns></returns>
    public bool ShowFRWelcomePanel()
    {
        if (!ActivityImg())
        {
            return false;
        }

        if (DataManager.FastRaceData.RepFastRaceConfigPacketData.showPanel == 1 &&
            todayShowPanel.Value != DateTime.Today.ToString())
        {
            todayShowPanel.Value = DateTime.Today.ToString();
            return true;
        }

        return false;
    }

    public bool GameActivityIng()
    {
        if (!DataManager.FastRaceData.ConfigInit)
        {
            return false;
        }

        if (notReachLevel)
        {
            return false;
        }

        if (DataManager.FastRaceData.RepFastRaceConfigPacketData.status == 3 || DataManager.FastRaceData.RepFastRaceConfigPacketData.status == 2)
        {
            return false;
        }

        return true;
    }
    /// <summary>
    /// 判断活动的状态
    /// </summary>
    /// <returns></returns>
    public bool ActivityImg()
    {
        if (!DataManager.FastRaceData.ConfigInit)
        {
            return false;
        }

        if (notReachLevel)
        {
            return false;
        }

        if (DataManager.FastRaceData.RepFastRaceConfigPacketData.status == 3)
        {
            return false;
        }

        return true;
    }

    public void AddScore(int number = 1)
    {
        DataManager.FastRaceData.Score++;
        UpScore();
    }

    public int rewardType;
    //奖励的金币数
    public int rewardNumber = 0;

    public bool notReachLevel
    {
        get { return _notReachLevel; }
        set
        {
            _notReachLevel = value;
            //Debug.LogError("活动关卡状态:" + value);
        }
    }


    private bool _activityenable = false;
    private bool _notReachLevel = false;
    private GameObject gameButton;
    private GameObject winButton;

    public override void InitSystem()
    {
        base.InitSystem();
        todayShowPanel = new RecordExtra.StringPrefData("todayShowPanel", "");
        net = new CupLifePlaySystemNet(this);
        EventUtil.EventDispatcher.AddEventListener(GlobalEvents.FRConfigInited, OnConfigLoad);
        net.GetConfig();
    }

    public void SetHomeButton(CupLifeGameButton _fastRaceGameButton)
    {
        this._fastRaceGameButton = _fastRaceGameButton;
    }

    /// <summary>
    /// 新的活动id，新活动
    /// </summary>
    public void NewActivityStart()
    {
        DataManager.FastRaceData.NewActivityStart();
    }


    /// <summary>
    /// 新一轮活动开始，先获取房间号
    /// </summary>
    public void NewTurnStart()
    {
        if (notReachLevel)
        {
            return;
        }

        playerRank = -1;
        Debug.Log("新一轮活动开始，先获取房间号");
        net.CreateRoom((roominfo) =>
        {
            if (roominfo != null)
            {
                if (DataManager.FastRaceData.RoomId != 0)
                {
                    notReachLevel = false;
                    Debug.Log("活动开启");
                    activityEnable = true;
                    EventDispatcher.TriggerEvent(GlobalEvents.NewRoomEnter);
                }
                else
                {
                    notReachLevel = true;
                }
            }
        });
    }


    public void UpScore(bool getreward = false, Action<UploadScoreRepData> back = null)
    {
        if (notReachLevel)
        {
            return;
        }

        if (DataManager.FastRaceData.RoomId == 0)
        {
            NewTurnStart();
            return;
        }

        //Debug.LogError("活动继续，上传一下分数" + getreward);
        net.UploadScore(DataManager.FastRaceData.Score,
            AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().GetPlayerHeadUrl(), (scoreback) =>
            {
                //Debug.LogError("分数" + JsonConvert.SerializeObject(scoreback));
                if (scoreback == null)
                {
                    //上传失败在这里可以不处理
                    if (back != null)
                    {
                        back.Invoke(null);
                    }
                }
                else
                {
                    if (scoreback.status != 1)
                    {
                        Debug.LogError("活动结束，关闭活动");
                        //当前活动进入展示期
                        DataManager.FastRaceData.RepFastRaceConfigPacketData.status = 2;
                        //活动已经结束
                        activityEnable = false;
                    }
                    else
                    {
                        //活动未结束
                        activityEnable = true;
                    }
                    
                    if (back != null)
                    {
                        back.Invoke(scoreback);
                    }
                }
            });
    }

    /// <summary>
    /// 获取自己的排名
    /// </summary>
    /// <param name="actionback"></param>
    public void GetPlayerRankIndex(Action<MyRankInfo> actionback,Action<bool> getReward)
    {
        if (!DataManager.FastRaceData.ConfigInit)
        {
            return;
        }
        net.GetPlayerRank(rankinfo =>
        {
            if (rankinfo == null)
            {
                playerRank = -1;
                actionback?.Invoke(null);
            }
            else
            {
                if (rankinfo.code != 200)
                {
                    playerRank = -1;
                    actionback?.Invoke(null);
                }
                else
                {
                    playerRank = rankinfo.data.rink;
                    if (rankinfo.data.status == 3 && rankinfo.data.rewardId > 0 && rankinfo.data.type == 0 && rankinfo.data.rewardNum > 0)
                    {
                        getReward?.Invoke(true);
                        //当前活动进入展示期
                        DataManager.FastRaceData.RepFastRaceConfigPacketData.status = 2;
                        DataManager.FastRaceData.CanGetReward = true;
                        DataManager.FastRaceData.rewardID = rankinfo.data.rewardId;
                        DataManager.FastRaceData.rewardNum = rankinfo.data.rewardNum;
                        TimersManager.SetTimer(0.8f, () =>
                        {
                            if (inMainHome)
                            {
                                //((HomeRoot) MainSceneDirector.Instance.GetUIRoot(GameUI.Home)).HomeFsmManager.TriggerEvent(HomeFsmManager
                                //    .Event_CheckRefresh);
                            }
                        });
                    }
                    else
                    {
                        DataManager.FastRaceData.CanGetReward = false;
                    }
                    actionback?.Invoke(rankinfo.data);
                }
            }
        });
    }

    /// <summary>
    /// 获取排行榜
    /// </summary>
    /// <param name="actionback"></param>
    public void GetRankList(Action<RanListInfo> actionback)
    {
        net.GetRankList(rankinfo =>
        {
            if (rankinfo == null)
            {
                actionback.Invoke(null);
            }
            else
            {
                actionback.Invoke(rankinfo);
            }
        });
    }

    /// <summary>
    /// 领取奖励
    /// </summary>
    public void GetReward(Action<bool> callback = null)
    {
        net.Reward((ok) =>
        {
            if (ok)
            {
                activityEnable = false;
                Debug.LogError("领取奖励，关闭活动");
                if (callback != null)
                {
                    callback.Invoke(true);
                }
            }
            else
            {
                //继续等待发奖
                if (callback != null)
                {
                    callback.Invoke(false);
                }
            }
        });
    }

    /// <summary>
    /// 成功拿到配置文件
    /// </summary>
    private void OnConfigLoad()
    {
        //Debug.LogError("接收FastRace新活动配置" + DataManager.FastRaceData.RepFastRaceConfigPacketData.level);
        if (DataManager.FastRaceData.ConfigInit)
        {
            if (DataManager.FastRaceData.RepFastRaceConfigPacketData.countdown > 0)
            {
                if (DataManager.FastRaceData.RepFastRaceConfigPacketData.level <
                    AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value)
                {
                    notReachLevel = false;
                }
                else
                {
                    //关卡不满足条件
                    notReachLevel = true;
                }

                //Debug.LogError("活动有效" + DataManager.FastRaceData.RoomId);
                //活动在有效期
                if (DataManager.FastRaceData.RoomId == 0)
                {
                    NewTurnStart();
                    if (inMainHome)
                        RefreshEnterButton();
                }
                else
                {
                    UpScore();
                }
            }
            else
            {
                activityEnable = false;
            }
        }
        else
        {
            activityEnable = false;
        }

        if (inMainHome)
            RefreshFRBtn();
    }

    private void RefreshStatus()
    {
        if (DataManager.FastRaceData.ConfigInit)
        {
            if (DataManager.FastRaceData.RepFastRaceConfigPacketData.countdown > 0)
            {
                if (DataManager.FastRaceData.RepFastRaceConfigPacketData.level <
                    AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value)
                {
                    notReachLevel = false;
                    activityEnable = true;
                }
                else
                {
                    //关卡不满足条件
                    notReachLevel = true;
                    activityEnable = false;
                }

                //Debug.LogError("活动有效" + DataManager.FastRaceData.RoomId);

            }
            else
            {
                activityEnable = false;
            }
        }
        else
        {
            activityEnable = false;
        }

        if (inMainHome)
            RefreshFRBtn();
    }

    private IEnumerator LoopTime()
    {
        var time = new WaitForSeconds(1);
        while (true)
        {
            if (GameActivityIng())
            {
                if (DataManager.FastRaceData.RepFastRaceConfigPacketData.countdown > 0)
                {
                    var times = new CountDownTime(DataManager.FastRaceData.RepFastRaceConfigPacketData.countdown);
                    TimeAction?.Invoke(
                        DataManager.FastRaceData.RepFastRaceConfigPacketData.countdown > CountDownTime.HourSeconds
                            ? $"{times.TotalHour:D2}h:{times.Minute:D2}m"
                            : $"{times.Minute:D2}m:{times.Second:D2}s");
                }
                else
                {
                    TimeAction?.Invoke("Finished");
                }

                DataManager.FastRaceData.RepFastRaceConfigPacketData.countdown--;
            }
            else
            {
                TimeAction?.Invoke("Finished");
            }

            yield return time;
        }
    }

    public override void LeaveOneHours()
    {
        base.LeaveOneHours();
        net.GetConfig(); 
    }
    
}