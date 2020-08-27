using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Scripts_Game.Managers;
using TMPro;
using UnityEngine;

public class SignPanel : UIWindowBase
{
    public CanvasGroup contentCanvasGroup;
    public GameObject beforeTitle, afterTitle;
    public Transform dayItemContent;
    public SignItem[] items;
    public GameObject DayItemPrefab;
    public GameObject continueBtn;
    public CanvasGroup coinGroup;
    
    private Action closeCallback;
    private int todayIndex;
    private bool isTodayCompleted;
    private bool toOpenGift = false;
    private string rewardId;
    private SignItem today, tomorrow;

    private void Start()
    {
        this.StartWaitForEndOfFrame(() =>
        {
            float deltaX = today.transform.localPosition.x - items[0].transform.localPosition.x;
            dayItemContent.localPosition -= new Vector3(deltaX, 0, 0);
        });
    }

    public override void OnOpen()
    {
        base.OnOpen();
        coinGroup.alpha = 0;
        todayIndex = AppEngine.SSystemManager.GetSystem<PlayerSignSystem>().TodaySignIndex;
        if (objs != null && objs.Length > 1)
        {
            beforeTitle.SetActive(true);
            afterTitle.SetActive(false);
            toOpenGift = (bool) objs[0];
            closeCallback = (Action) objs[1];
            isTodayCompleted = false;
            rewardId = AppEngine.SSystemManager.GetSystem<PlayerSignSystem>().GetTodaySignRewardId();
        }
        InitItems();
        if (toOpenGift)
        {
            continueBtn.SetActive(false);
        }
    }

    private void OnGiftClosed(UIWindowBase ui)
    {
        coinGroup.alpha = 1;
        TimersManager.SetTimer(3f, () => { coinGroup.alpha = 0; });
        beforeTitle.SetActive(false);
        afterTitle.SetActive(true);
        if (todayIndex == 6)//最后一天完成明天无奖励，修改提示文案
        {
            //afterTitle.GetComponent<TextMeshProUGUI>().text = "";
        }
        StartCoroutine(CompleteProcess());
    }

    private IEnumerator CompleteProcess()
    {
        yield return new WaitForSeconds(1.8f);
        today.PlayCompleteAni();
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_sign_paper);
        yield return new WaitForSeconds(1.9f);
        if (tomorrow != null)
        {
            tomorrow.PlayUnlockAni();
            yield return new WaitForSeconds(1f);
        }
        continueBtn.SetActive(true);
        yield break;
    }

    private void InitItems()
    {
        PlayerSignSystem ss = AppEngine.SSystemManager.GetSystem<PlayerSignSystem>();
        // for (int i = dayItemContent.childCount-1; i >= 0; i--)
        // {
        //     Destroy(dayItemContent.GetChild(i).gameObject);
        // }
        int dayIndex, round = ss.Round - 1;
        for (var i = 0; i < items.Length; i++)
        {
            //GameObject itemObj = Instantiate(DayItemPrefab, dayItemContent);
            //SignItem item = itemObj.GetComponent<SignItem>();
            SignItem item = items[i];
            dayIndex = i + 7 * round;
            int box = ss.GetSignGiftBox(dayIndex+1);
            if (dayIndex < todayIndex)
            {
                //items[i].InitPassed();
            }
            else if (dayIndex == todayIndex)
            {
                //items[i].InitToday(isTodayCompleted);
                today = item;
            }
            else if (dayIndex == (todayIndex + 1))
            {
                //items[i].InitTomorrow();
                tomorrow = item;
            }
            else
            {
                //items[i].InitNormal();
            }
            item.InitItem(dayIndex, todayIndex, box);
        }
    }

    public override IEnumerator EnterAnim(params object[] objs)
    {
        yield return base.EnterAnim(objs);
        yield return new WaitForSeconds(1.5f);
        //UIManager.OpenUIAsync(ViewConst.prefab_CommonGiftDialog, OpenType.Over, OnGiftClosed, null,null, rewardId);
        AppEngine.SSystemManager.GetSystem<PlayerSignSystem>().CompleteSign();
        
        CommonRewardData _commonRewardData = new CommonRewardData();
        _commonRewardData.rewardId = rewardId;
        _commonRewardData.boxType = today.BoxType == 1 ? RewardBoxType.SignBox2 : RewardBoxType.SignBox1;
        _commonRewardData.RewardSource = RewardSource.sign;
        UIManager.OpenUIAsync(ViewConst.prefab_CommonRewardDialog, OpenType.Over, OnGiftClosed, null, null, _commonRewardData);
    }

    public override void OnClose()
    {
        base.OnClose();
        closeCallback?.Invoke();
    }
}