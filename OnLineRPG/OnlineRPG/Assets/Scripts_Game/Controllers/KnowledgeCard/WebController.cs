using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using Scripts_Game.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WebController : BaseHomeUI
{
    public Slider webSlidler;
    public TextMeshProUGUI webText;
    public Animator levelTaskBoxAnimator;
    private float rewardNextProgress = 0;
    private int maxRegion;
    private int current;
    private GameObject NonOpenObj;//非open状态使用
    private GameObject OpenObj;//open状态下使用
    private SyncDataAccesser data => AppEngine.SyncManager.Data;

    void Awake()
    {
        NonOpenObj = transform.Find("Img_Bg/Unlock").gameObject;
        OpenObj = transform.Find("Img_Bg/Open").gameObject;
        transform.GetComponentInChildren<Button>().onClick.AddListener(ButtonClick);
    }

    public override void OnShow()
    {
        base.OnShow();
        ShowCup();
    }

    public void ButtonClick()
    {
        Debug.LogError("ButtonClick");
        if (NonOpenObj.activeSelf)
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
            UIManager.OpenUIAsync(ViewConst.prefab_CupRewardDialog);
        }
        else
        {
            int currentReward = AppEngine.SyncManager.Data.RewardCup.Value;
            string rewardid = AppEngine.SSystemManager.GetSystem<CupSystem>().GetCurTargetReward(currentReward);
            Debug.LogError("达到领奖要求" + rewardid);
            //如果达到最大值就发送这个subworld的奖励
            AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_subBoxOpen); //不再自动发奖
            TimersManager.SetTimer(1.2f,
                () =>
                {
                    CommonRewardData _commonRewardData = new CommonRewardData();
                    _commonRewardData.rewardId = rewardid;
                    _commonRewardData.boxType = RewardBoxType.CupBox;
                    _commonRewardData.RewardSource = RewardSource.CupBox;
                    _commonRewardData.callback = UserGetSubworldReward;
                    UIManager.OpenUIAsync(ViewConst.prefab_CommonRewardDialog, OpenType.Over, ui =>
                    {
                        
                    }, null, null, _commonRewardData);
                    data.RewardCup.Value = AppEngine.SSystemManager.GetSystem<CupSystem>().GetCurTarget(data.RewardCup.Value);
                });
        }
    }

    /// <summary>
    /// 展示现在的进度
    /// </summary>
    private void ShowCup()
    {
        NonOpenObj.SetActive(false);
        OpenObj.SetActive(false);
        int rewardTarget = data.RewardCup.Value;//已经领奖
        int currentCup = data.Cup.Value;
        int nextRewardTarget = AppEngine.SSystemManager.GetSystem<CupSystem>().GetCurTarget(rewardTarget);//下一个该领奖的目标值
        if (currentCup < nextRewardTarget) {//不满
            NonOpenObj.SetActive(true);
            webSlidler.value = (currentCup-rewardTarget)/(float)(nextRewardTarget-rewardTarget);
            SetWebText(currentCup-rewardTarget, nextRewardTarget-rewardTarget);
        } else {//满了
            OpenObj.SetActive(true);
        }

        // int lastCup = AppEngine.SyncManager.Data.Cup.LastValue;
        // int lastNextCup = AppEngine.SSystemManager.GetSystem<WebSystem>().GetNextTarget(lastCup);
        // int lastRegion = AppEngine.SSystemManager.GetSystem<WebSystem>().GetCurrentTargetRegion(lastCup);
        // int currentFans = AppEngine.SyncManager.Data.Cup.Value;
        // int lastTarget = AppEngine.SSystemManager.GetSystem<WebSystem>().GetLastTarget(lastCup);
        
        // if (lastNextCup > 0)
        // {
        //     if (lastCup - lastTarget == lastRegion)
        //     {
        //         int lastRegionzero = AppEngine.SSystemManager.GetSystem<WebSystem>().GetCurrentTargetRegion(lastCup + 1);
        //         webSlidler.value = 0;
        //         SetWebText(0, lastRegionzero);
        //     }
        //     else
        //     {
        //         // Debug.LogError($"{lastCup} -- {lastTarget} -- {lastRegion}");
        //         float progress = (lastCup - lastTarget) / (float)lastRegion;
        //         webSlidler.value = progress;
        //         SetWebText(lastCup - lastTarget, lastRegion);
        //     }
        //     NonOpenObj.SetActive(true);
        // }
        // else
        // {
        //     SetWebText(lastCup - lastTarget, -1);
        //     webSlidler.value = 1;
        //     OpenObj.SetActive(true);
        // }
    }

    /// <summary>
    /// 用户拿到奖励之后
    /// </summary>
    private void UserGetSubworldReward()
    {
        ShowCup();
        // NonOpenObj.SetActive(true);
        // OpenObj.SetActive(false);
        // webSlidler.value = 0;
        // webSlidler.DOValue(rewardNextProgress, 0.5f).OnComplete(() =>
        // {
        //     SetWebText(0, current, maxRegion);
        //     rewardNextProgress = 0;
        // });
    }

    private void SetWebText(int current, int max)
    {
        if (max == -1 || max == 0)
        {
            webText.text = string.Format("MAX", current, current);
        }
        else
        {
            webText.text = string.Format("{0}/{1}", XUtils.GetFormatFans(current), XUtils.GetFormatFans(max));
        }
    }

    private void SetWebText(int old, int current, int max)
    {
        if (max == -1 || max == 0)
        {
            webText.text = string.Format("MAX", current, current);
        }
        else
        {
            webText.text = string.Format("{0}/{1}", XUtils.GetFormatFans(current), XUtils.GetFormatFans(max));
            // int oldBalance = old;
            // DOTween.To(() => oldBalance, x => oldBalance = x, current, 0.5f).OnUpdate(() =>
            // {
            //     webText.text = string.Format("{0}/{1}", oldBalance, max);
            // }).OnComplete(() => { });
        }
    }

    public override void OnHidden()
    {
        base.OnHidden();
    }
}