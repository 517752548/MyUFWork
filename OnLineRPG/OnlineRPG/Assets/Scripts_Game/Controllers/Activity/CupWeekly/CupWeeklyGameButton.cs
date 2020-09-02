using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using EventUtil;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CupWeeklyGameButton : BaseEntranceBtn
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI rankText;
    public Animator weekEntranceAnim;

    private string PlayerUpAnimTrigerUp = "up";
    private string PlayerUpAnimTrigerOpen = "open";
    private bool canclick = true;
    private int oldRank = -1;
    private bool checkGift = true;
    private int looptime = 0;

    // Use this for initialization
    void Start()
    {
        rankText.text = "";
        AppEngine.SSystemManager.GetSystem<CupWeeklyPlaySystem>().SetHomeButton(this);
        //EventDispatcher.AddEventListener(GlobalEvents.NewRoomEnter, CheckBegion);
        AppEngine.SSystemManager.GetSystem<CupWeeklyPlaySystem>().TimeAction += ShowTime;
    }

    public void Refresh()
    {
        //OnShow();
        UpdateInParent();
    }

    public override void OnShow()
    {
        if (AppEngine.SSystemManager.GetSystem<CupWeeklyPlaySystem>().ActivityImg())
        {
            gameObject.SetActive(true);
        }

        if (gameObject.activeSelf)
        {
            Weight = DataManager.FastRaceData.RepFastRaceConfigPacketData.order;
        }

        base.OnShow();
        ShowMyRank();
    }

    private void ShowMyRank()
    {
        //rankText.text = "";
        if (DataManager.FastRaceData.ConfigInit && DataManager.FastRaceData.Score > 0)
        {
            AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().GetPlayerRankIndex((op) =>
            {
                if (oldRank == -1)
                {
                    oldRank = AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().playerRank;
                    if (oldRank == -1)
                    {
                        rankText.text = "";
                    }
                    else
                    {
                        rankText.text = oldRank.ToString();
                    }
                    
                }
                else if (oldRank > AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().playerRank)
                {
                    TimersManager.SetTimer(0.5f, () => { ShowUpAnim(); });
                }
                else
                {
                    if (AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().playerRank == -1)
                    {
                        rankText.text = "";
                    }
                    else
                    {
                        rankText.text = AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().playerRank
                            .ToString();
                    }
                }
            }, (getreward) =>
            {
                if (getreward)
                {
                    weekEntranceAnim.SetTrigger(PlayerUpAnimTrigerOpen);
                }
            });
        }
    }


    private void ShowUpAnim()
    {
        weekEntranceAnim.SetTrigger(PlayerUpAnimTrigerUp);
        rankText.text = oldRank.ToString();
        TimersManager.SetTimer(0.5f,
            () =>
            {
                if (AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().playerRank == -1)
                {
                    rankText.text = "";
                }
                else
                {
                    int currentRank = oldRank;
                    rankText.text = oldRank.ToString();
                    DOTween
                        .To(() => currentRank, x => currentRank = x,
                            AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().playerRank, 0.5f)
                        .OnComplete(() =>
                        {
                            rankText.text = AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>()
                                .playerRank.ToString();
                        }).OnUpdate(() => { rankText.text = currentRank.ToString(); });
                }
            });
    }

    private void ShowTime(string time)
    {
        timeText.text = time;
        if (checkGift && time == "Finished")
        {
            checkGift = false;
            TimersManager.SetTimer(10, () => { checkGift = true; });
            if (looptime < 20)
            {
                AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().GetPlayerRankIndex(null, null);
            }

            looptime++;
        }
    }

    /// <summary>
    /// 刷新按钮
    /// </summary>
    public void RefreshButton()
    {
        if (AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().playerRank == -1)
        {
            rankText.text = "";
        }
        else
        {
            rankText.text = AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().playerRank.ToString();
        }
    }

    public void ShowStarEffect()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_home_frstareffect);
        weekEntranceAnim.SetTrigger(PlayerUpAnimTrigerOpen);
    }

    public void ClickButton()
    {
        if (canclick == false)
        {
            return;
        }

        canclick = false;
        TimersManager.SetTimer(0.5f, () => { canclick = true; });
        if (AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value <
            DataManager.FastRaceData.RepFastRaceConfigPacketData.level)
        {
            UIManager.OpenUIAsync(ViewConst.prefab_CommonNotice_Level, null,
                string.Format("Level {0}",
                    DataManager.FastRaceData.RepFastRaceConfigPacketData.level));
            return;
        }

        if (Application.internetReachability == NetworkReachability.NotReachable) //没网的情况直接不显示广告
        {
            UIManager.OpenUIAsync(ViewConst.prefab_NetConnectFailDialog, null, null);
            BetaFramework.LoggerHelper.Log("reward video invalid - no net");
            return;
        }

        if (DataManager.FastRaceData.Score > 0)
        {
            UIManager.OpenUIAsync(ViewConst.prefab_WeekRankListDialog);
            return;
        }

        UIManager.OpenUIAsync(ViewConst.prefab_WeekendPropagandaDialog);
    }

    private void OnDestroy()
    {
        AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().TimeAction = ShowTime;
        //EventDispatcher.RemoveEventListener(GlobalEvents.NewRoomEnter, CheckBegion);
    }
}