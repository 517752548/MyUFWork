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
    ClassicGameSystem sys => AppEngine.SSystemManager.GetSystem<ClassicGameSystem>();
    SyncDataAccesser data => AppEngine.SyncManager.Data;

    //返回值是0代表正常完成，直接播放粉丝动画，如果为1代表解锁了新世界，需要展示解锁新世界的动画
    private Action<int> progressAnimCallback;
    //宝箱满了
    private bool Full
    {
        get => full;
        set
        {
            full = value;
            openObj.SetActive(full);
            nonOpenObj.SetActive(!full);
        }
    }
    private GameObject openObj;
    private GameObject nonOpenObj;

    // Use this for initialization
    private void Start()
    {
        openObj = transform.Find("Img_Bg/Open").gameObject;
        nonOpenObj = transform.Find("Img_Bg/Unlock").gameObject;
        ShowOldView();
    }

    public override void OnShow()
    {
        base.OnShow();
        ShowOldView();
    }

    private void ShowOldView()
    {
        int rewardLevel = data.RewardLevel.Value;
        int nextRewardLevel = sys.GetNextRewardLevel(rewardLevel);
        var completedLevelIndex = sys.currentLevel.LastValue;
        if (completedLevelIndex >= nextRewardLevel)
        {//满了
            Full = true;
        }
        else
        {
            Full = false;
            sys.GetSubWorldBoxProgress(completedLevelIndex, out var currentProgress, out var currentMax);
            progressText.text = string.Format("{0}/{1}", currentProgress, currentMax);
            progressImage.value = (float)currentProgress / currentMax;
        }
    }

    public void PlayProgressAni(Action overCallback)
    {
        LevelTaskAnimator.SetTrigger("hit");
        if (Full)
        {
            overCallback?.Invoke();
        }
        else
        {
            var completedLevelIndex = sys.currentLevel.LastValue;
            sys.GetSubWorldBoxProgress(completedLevelIndex, out var currentProgress, out var currentMax);
            currentProgress++;
            float imageProgress = (float)currentProgress / currentMax;
            progressImage.DOValue(imageProgress, 0.5f).OnComplete(() =>
            {
                progressText.text = string.Format("{0}/{1}", currentProgress, currentMax);

                if (currentProgress == currentMax)
                {
                    //如果达到最大值就发送这个subworld的奖励
                    LevelTaskAnimator.SetTrigger("full");
                    Full = true;
                }
                overCallback?.Invoke();
            });
        }
    }

    private void OpenBox()
    {
        int rewardLevel = data.RewardLevel.Value;
        int nextRewardLevel = sys.GetNextRewardLevel(rewardLevel);
        AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_subBoxOpen);
        var rewardId = sys.GetSubWorldRewardId(nextRewardLevel);
        var seq = DOTween.Sequence();
        seq.InsertCallback(1.2f, () =>
        {
            CommonRewardData _commonRewardData = new CommonRewardData();
            _commonRewardData.rewardId = rewardId;
            _commonRewardData.boxType = RewardBoxType.SubWorld;
            _commonRewardData.RewardSource = RewardSource.subWorld;
            _commonRewardData.callback = () =>
            {
                ShowOldView();
            };
            UIManager.OpenUIAsync(ViewConst.prefab_CommonRewardDialog, OpenType.Over, null, null, null, _commonRewardData);
        });
        // seq.InsertCallback(2.5f, () => LevelTaskAnimator.SetTrigger("idle"));
        data.RewardLevel.Value = nextRewardLevel;
    }

    private bool clickHome = false;
    private bool full;

    public void ClickBox()
    {
        if (clickHome)
        {
            return;
        }

        clickHome = true;
        TimersManager.SetTimer(0.5f, () => { clickHome = false; });
        if (Full)
        {//满了
            OpenBox();
        }
        else
        {
            UIManager.OpenUIAsync(ViewConst.prefab_LevelRewardDialog);
        }
    }
}