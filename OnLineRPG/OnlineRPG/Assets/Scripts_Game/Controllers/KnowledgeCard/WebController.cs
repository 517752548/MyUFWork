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

    public override void OnShow()
    {
        base.OnShow();
        ShowFans();
    }

    public void KnowledgeCardEntranceButtonClick()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
        UIManager.OpenUIAsync(ViewConst.prefab_FansRewardDialog);
    }

    /// <summary>
    /// 展示现在的进度
    /// </summary>
    private void ShowFans()
    {
        int lastFans = AppEngine.SyncManager.Data.fansNumber.LastValue;
        int lastNestFans = AppEngine.SSystemManager.GetSystem<WebSystem>().GetNextTarget(lastFans);
        int lastRegion = AppEngine.SSystemManager.GetSystem<WebSystem>().GetCurrentTargetRegion(lastFans);
        int currentFans = AppEngine.SyncManager.Data.fansNumber.Value;
        int lastTarget = AppEngine.SSystemManager.GetSystem<WebSystem>().GetLastTarget(lastFans);
        if (lastNestFans > 0)
        {
            if (lastFans - lastTarget == lastRegion)
            {
                int lastRegionzero = AppEngine.SSystemManager.GetSystem<WebSystem>().GetCurrentTargetRegion(lastFans + 1);
                webSlidler.value = 0;
                SetWebText(0, lastRegionzero); 
            }
            else
            {
                float progress = (lastFans - lastTarget) / (float) lastRegion;
                webSlidler.value = progress;
                SetWebText(lastFans - lastTarget, lastRegion);
            }
            
        }
        else
        {
            SetWebText(lastFans - lastTarget, -1);
            webSlidler.value = 1;
        }
    }

    public void DoIncreaseAnimator(Action callback)
    {
        levelTaskBoxAnimator.SetTrigger("hit");
        
        int currentFans = AppEngine.SyncManager.Data.fansNumber.Value;
        int lastFans = AppEngine.SyncManager.Data.fansNumber.LastValue;
        int lastNextFans = AppEngine.SSystemManager.GetSystem<WebSystem>().GetNextTarget(lastFans);
        int currentNextFans = AppEngine.SSystemManager.GetSystem<WebSystem>().GetNextTarget(currentFans);
        int currentRegion = AppEngine.SSystemManager.GetSystem<WebSystem>().GetCurrentTargetRegion(currentFans);
        int lastRegion = AppEngine.SSystemManager.GetSystem<WebSystem>().GetCurrentTargetRegion(lastFans);
        if (lastNextFans == currentNextFans)
        {
            int lastTarget = AppEngine.SSystemManager.GetSystem<WebSystem>().GetLastTarget(currentFans);
            //没有达到奖励宝箱
            float progress = (currentFans - lastTarget) / (float) currentRegion;
            webSlidler.DOValue(progress, 0.5f).OnComplete(() =>
            {
                SetWebText(currentFans - lastTarget, currentRegion);
                callback?.Invoke();
            });
            SetWebTextAnim(lastFans - lastTarget, currentFans - lastTarget, currentRegion);
        }
        else
        {
            int lastTarget = AppEngine.SSystemManager.GetSystem<WebSystem>().GetLastTarget(currentFans);
            SetWebTextAnim(lastFans - lastTarget, lastRegion, lastRegion);
            webSlidler.DOValue(1, 0.2f).OnComplete(() =>
            {
                levelTaskBoxAnimator.SetTrigger("full");

                float progress = (currentFans - lastTarget) / (float) currentRegion;
                //SetWebTextAnim(0, currentFans - lastTarget, currentRegion);
                rewardNextProgress = progress;
                maxRegion = currentRegion;
                current = currentFans - lastTarget;
                SetWebText(currentRegion, currentRegion);
                string rewardid = AppEngine.SSystemManager.GetSystem<WebSystem>().GetLastTargetReward(currentFans);
                string currentID = AppEngine.SSystemManager.GetSystem<WebSystem>().GetLastTargetID(currentFans);
                AppEngine.SSystemManager.GetSystem<WebSystem>().GivePlayerReward(currentID);
                //Debug.LogError("达到领奖要求" + rewardid);
                //如果达到最大值就发送这个subworld的奖励
                AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_subBoxOpen);
                TimersManager.SetTimer(1.2f,
                    () =>
                    {
                        CommonRewardData _commonRewardData = new CommonRewardData();
                        _commonRewardData.rewardId = rewardid;
                        _commonRewardData.boxType = RewardBoxType.WebBox;
                        _commonRewardData.RewardSource = RewardSource.WebBox;
                        _commonRewardData.callback = UserGetSubworldReward;
                        UIManager.OpenUIAsync(ViewConst.prefab_CommonRewardDialog, OpenType.Over, ui =>
                        {
                            callback?.Invoke();
                        }, null, null, _commonRewardData);
                        TimersManager.SetTimer(1, () => { levelTaskBoxAnimator.SetTrigger("idle"); });
                    });
            });
        }

        AppEngine.SyncManager.Data.fansNumber.ResetLastValue();
    }

    /// <summary>
    /// 用户拿到奖励之后
    /// </summary>
    private void UserGetSubworldReward()
    {
        webSlidler.value = 0;
        webSlidler.DOValue(rewardNextProgress, 0.5f).OnComplete(() =>
        {
            SetWebTextAnim(0, current, maxRegion);
            rewardNextProgress = 0;
        });
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

    private void SetWebTextAnim(int old, int current, int max)
    {
        if (max == -1 || max == 0)
        {
            webText.text = string.Format("MAX", current, current);
        }
        else
        {
            int oldBalance = old;
            DOTween.To(() => oldBalance, x => oldBalance = x, current, 0.5f).OnUpdate(() =>
            {
                webText.text = string.Format("{0}/{1}", oldBalance, max);
            }).OnComplete(() => { webText.text = string.Format("{0}/{1}", XUtils.GetFormatFans(current), XUtils.GetFormatFans(max)); });
        }
    }

    public override void OnHidden()
    {
        base.OnHidden();
    }
}