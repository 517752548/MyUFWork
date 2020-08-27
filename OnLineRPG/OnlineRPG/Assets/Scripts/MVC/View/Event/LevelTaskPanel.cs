using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using BetaFramework;
using Scripts_Game.Managers;
using TMPro;

public class LevelTaskPanel : BaseHomeUI
{
    public TextMeshProUGUI progressText;
    public Slider progressImage;
    public Animator LevelTaskAnimator;


    //返回值是0代表正常完成，直接播放粉丝动画，如果为1代表解锁了新世界，需要展示解锁新世界的动画
    private Action<int> progressAnimCallback;

    // Use this for initialization
    private void Start()
    {
        ShowOldView();
    }

    public override void OnShow()
    {
        base.OnShow();
        ShowOldView();
    }

    private void ShowOldView()
    {
        var sys = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>();
        var completedLevelIndex = sys.currentLevel.LastValue - 1;
        sys.GetSubWorldBoxProgress(completedLevelIndex, out var currentProgress, out var currentMax);
       
        progressText.text = string.Format("{0}/{1}", currentProgress, currentMax);
        progressImage.value = (float) currentProgress / currentMax;
        
        if (!DataManager.PlayerData.claimPlayerGetSubWorldReward && !string.IsNullOrEmpty(DataManager.PlayerData.playerGetSubWorldReward.Value))
        {
            //如果强杀就补发奖励
            string rewardId = DataManager.PlayerData.playerGetSubWorldReward.Value;
            DataManager.PlayerData.playerGetSubWorldReward.Value = "";
            RewardMgr.RewardInventory(RewardMgr.GetRewards(rewardId), RewardSource.subWorld);
        }
    }

    public void PlayProgressAni(Action overCallback)
    {
        LevelTaskAnimator.SetTrigger("hit");
        var sys = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>();
        var completedLevelIndex = sys.currentLevel.LastValue - 1;
        sys.GetSubWorldBoxProgress(completedLevelIndex, out var currentProgress, out var currentMax);
        currentProgress++;
        float imageProgress = (float) currentProgress / currentMax;
        progressImage.DOValue(imageProgress, 0.5f).OnComplete(() =>
        {
            progressText.text = string.Format("{0}/{1}", currentProgress, currentMax);

            if (currentProgress == currentMax)
            {
                //如果达到最大值就发送这个subworld的奖励
                LevelTaskAnimator.SetTrigger("full");
                AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_subBoxOpen);
                var rewardId = sys.GetSubWorldRewardId(sys.currentLevel.LastValue);
                var seq = DOTween.Sequence();
                seq.InsertCallback(1.2f, () =>
                {
                    CommonRewardData _commonRewardData = new CommonRewardData();
                    _commonRewardData.rewardId = rewardId;
                    _commonRewardData.boxType = RewardBoxType.SubWorld;
                    _commonRewardData.RewardSource = RewardSource.subWorld;
                    _commonRewardData.callback = () =>
                    {
                        completedLevelIndex = sys.currentLevel.Value - 1;
                        sys.GetSubWorldBoxProgress(completedLevelIndex, out currentProgress, out currentMax);
                        progressText.text = string.Format("{0}/{1}", currentProgress, currentMax);
                        progressImage.value = 0;
                    };
                    UIManager.OpenUIAsync(ViewConst.prefab_CommonRewardDialog,  OpenType.Over, ui =>
                    {
                        overCallback?.Invoke();
                    },  null, null, _commonRewardData);
                });
                seq.InsertCallback(2.5f, () => LevelTaskAnimator.SetTrigger("idle"));
            }
            else
            {
                overCallback?.Invoke();
            }
        });
    }

    private bool clickHome = false;

    public void ClickBox()
    {
        if (clickHome)
        {
            return;
        }

        clickHome = true;
        TimersManager.SetTimer(0.5f, () => { clickHome = false; });
        UIManager.OpenUIAsync(ViewConst.prefab_LevelRewardDialog);
    }
}