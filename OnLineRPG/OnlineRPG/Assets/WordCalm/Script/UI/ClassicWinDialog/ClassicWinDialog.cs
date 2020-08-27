using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using Scripts_Game.Controllers.GamePlay.Classic.Win;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ClassicWinDialog : UIWindowBase
{
    public Text userNameText;
    public Image UserPhoto;
    public Transform cardContent;
    public TextMeshProUGUI cardThemeText;
    public Text fansText;
    public Text FanPlus;
    public Animator winAnimator;
    public Animator fansAnimator;
    public GameObject tip;
    public Text tipText;

    private ClassicLevelEntity currentLevelEntity;
    private ClassicPackage currentLevelPackage;
    private int oldFans;
    private int newFans;
    private int fansUpdaterate = 3;
    private int currentFansupdate = 0;
    private int pieceOrder;
    private CardPieceCtrl _cardPieceCtrl;

    public override void OnOpen()
    {
        base.OnOpen();
        AppEngine.SSoundManager.BgmPause();
        TimersManager.SetTimer(7, () => { AppEngine.SSoundManager.BgmUnPause(); });


        //userNameText.text = AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBName.Value;
        currentLevelEntity = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetCurClassicLevel();
        currentLevelPackage = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetCurClassicPackage();
        pieceOrder = currentLevelPackage.GetLevelSerialNum(AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value);
        AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value++;
        if (currentLevelEntity.ID == currentLevelPackage.CardLevelID)
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_welldone_h);
            winAnimator.SetTrigger("IsStart");
        }
        else
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_welldone_normal);
            winAnimator.SetTrigger("IsStartOnlyCard");
        }

        RewardFans();
        SetKnowledgeCard();
        RewardSubworldTag();
        if (Const.AutoPlay)
        {
            TimersManager.SetTimer(6f, () => { ClickContinue(); });
        }
    }

    //标记是否需要发奖，如果强杀用来补发奖励
    private void RewardSubworldTag()
    {
        int oldLevel = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.LastValue;
        var rewardData = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetSubWorldRewardData(oldLevel);
        if (rewardData != null)
        {
            DataManager.PlayerData.playerGetSubWorldReward.Value = rewardData.RewardId;
            DataManager.PlayerData.claimPlayerGetSubWorldReward = true;
        }
    }

    private void SetKnowledgeCard()
    {
        _cardPieceCtrl = CardPieceCtrl.Make(currentLevelPackage._CardEntity,
            (CardPieceMode) currentLevelPackage.CardPieceMode, cardContent);
        _cardPieceCtrl.SetProgress(pieceOrder - 1);
        //KnowledgeCardImage.sprite = currentLevelPackage._CardEntity.Image;
        cardThemeText.text = currentLevelPackage._CardEntity.CardTheme.ToUpper();
    }

    private void RewardFans()
    {
        int fans = AppEngine.SyncManager.Data.fansNumber.Value;
        oldFans = fans;

        fansText.text = String.Format("{0}", fans);

        int addFans = 0;
        for (int i = 0; i < currentLevelEntity.Questions.Count; i++)
        {
            addFans += currentLevelEntity.Questions[i].Answer.Length;
        }

        FanPlus.text = string.Format("+{0}", addFans);
        fans += addFans;
        newFans = fans;
        AppEngine.SyncManager.Data.fansNumber.Value = newFans;
    }

    public void RewardCardKnowlegde()
    {
        _cardPieceCtrl.PlayGotAni(pieceOrder, () =>
        {
            if (currentLevelPackage.CardLevelID == currentLevelEntity.ID)
            {
                _cardPieceCtrl.PlayFinishAni(PlayFansAni);
            }
            else
            {
                PlayFansAni();
            }
        });
    }

    private void PlayFansAni()
    {
        int fans = AppEngine.SyncManager.Data.fansNumber.Value;
        int min = (int) (fans * 0.7f);
        int max = (int) (fans * 1.3f);
        float myInt = 0;
        fansAnimator.SetTrigger("up");
        DOTween.To(x => myInt = x, oldFans, newFans, 1.2f).OnUpdate(() =>
        {
            currentFansupdate++;
            if (currentFansupdate >= fansUpdaterate)
            {
                currentFansupdate = 0;
                fansText.text = String.Format("{0}", (int) myInt);
            }
        }).OnComplete(() =>
        {
            fansText.text = String.Format("{0}", newFans);
            if (currentLevelPackage.CardLevelID == currentLevelEntity.ID)
            {
                StartCoroutine(ShowTip(currentLevelPackage._CardEntity.Description, 10f));
            }
        });
        winAnimator.SetTrigger("StartNext");
        if (currentLevelPackage.CardLevelID == currentLevelEntity.ID)
        {
            DataManager.PlayerData.KnowledgeCards.Value.AddKnowledgeCard(
                AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.LastValue,
                currentLevelPackage.CardID, Random.Range(min, max));
        }
    }

    public void ClickContinue()
    {
        AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().LoadClassicLevel(
            AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value,
            (ok) => { LoggerHelper.Log("load new level ok"); });
        AppEngine.SyncManager.DoSync(null);

    }

    public void ClickWord()
    {
        if (currentLevelPackage.CardLevelID == currentLevelEntity.ID)
        {
            StartCoroutine(ShowTip(currentLevelPackage._CardEntity.Description, 10f));
        }
        else
        {
            StartCoroutine(ShowTip($"The picture will be revealed at Level {currentLevelPackage.EndLevelIndex}!", 10f));
        }

        //ShowKnowledgeWord();
    }

    private Sequence tipAutoHideSeq = null;

    private IEnumerator ShowTip(string text, float delayAutoHide = -1)
    {
        yield return new WaitForSeconds(1);

        var tipAni = tip.GetComponent<Animator>();

        tipText.text = text;

        if (!tip.activeSelf)
        {
            tip.SetActive(true);
            tipAni.SetTrigger("out");
            if (delayAutoHide > 0)
            {
                tipAutoHideSeq = DOTween.Sequence().InsertCallback(delayAutoHide, HideTip);
            }
        }
        else
        {
            HideTip();
        }
    }

    public void HideTip()
    {
        var tipAni = tip.GetComponent<Animator>();
        if (tip.activeSelf)
        {
            if (tipAutoHideSeq != null)
            {
                tipAutoHideSeq.Kill();
                tipAutoHideSeq = null;
            }

            tipAni.SetTrigger("in");
            DOTween.Sequence().InsertCallback(0.2f, () => { tip.SetActive(false); });
        }
    }
}