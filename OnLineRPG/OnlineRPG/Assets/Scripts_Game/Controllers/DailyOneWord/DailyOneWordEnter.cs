using System;
using BetaFramework;
using Scripts.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyOneWordEnter : BaseEntranceBtn
{
    public Animator ani;
    public TextMeshProUGUI timeText;
    public GameObject VideoFlag;
    public GameObject lockObj;
    public GameObject TimeObj;
    
    private bool isCompleted;
    
    public void OnClick()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
        if (!AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsUnlocked())
        {
            UIManager.OpenUIAsync(ViewConst.prefab_CommonNotice_Level, OpenType.Replace,null,
                string.Format("Level {0}",
                    AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().GetUnlockLevel()));
            return;
        }
        if (!AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsReady())
        {
            UIManager.OpenUIAsync(ViewConst.prefab_NetConnectFailDialog,null, null);
            AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().Load();
            return;
        }
        // if (AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsCompleted)
        // {
        //     UIManager.OpenUIAsync(ViewConst.prefab_WellDownDialog);
        //     return;
        // }
        //DataManager.ProcessData._GameMode = GameMode.OneWord;
        //MainSceneDirector.Instance.SwitchUi(GameUI.Game);
        UIManager.OpenUIAsync(ViewConst.prefab_GameLoadingWindow,OpenType.Replace, (ui, para) =>
        {
            DataManager.ProcessData._GameMode = GameMode.OneWord;
            MainSceneDirector.Instance.SwitchUi(GameUI.Game, ok =>
            {
                Timer.Schedule(AppThreadController.instance, 0.2f, () =>
                {
                    UIManager.CloseUIWindow(
                        UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow)); 
                });
            });

        });
    }

    public override void OnShow()
    {
        base.OnShow();
        AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().OnTimeUpdate += OnTimeUpdate;
        if (!AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsEnable())
        {
            lockObj.SetActive(true);
            TimeObj.SetActive(false);
        }
        else
        {
            lockObj.SetActive(false);
            isCompleted = !AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsAllCompleted;
            AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().UpdateTime();
        }
    }

    public override void OnHidden()
    {
        base.OnHidden();
        AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().OnTimeUpdate -= OnTimeUpdate;
    }
    

    private void OnTimeUpdate(int sec)
    {
        if (AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsEnable())
        {
            if (lockObj.activeSelf)
            {
                isCompleted = !AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsAllCompleted;
                lockObj.SetActive(false);
            }
            var time = new CountDownTime(sec);
            timeText.text = sec > CountDownTime.HourSeconds ? $"{time.TotalHour:D2}h:{time.Minute:D2}m" : $"{time.Minute:D2}m:{time.Second:D2}s";
            if (AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsAllCompleted != isCompleted)
            {
                isCompleted = !isCompleted;            
                if (isCompleted)
                {
                    ani.SetTrigger("wait");
                    TimeObj.SetActive(true);
                }
                else
                {
                    ani.SetTrigger("now");
                    TimeObj.SetActive(false);
                }
            }

            VideoFlag.SetActive(AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().CanRefreshExLevel);
        }
        else
        {
            ani.SetTrigger("wait");
            lockObj.SetActive(true);
            TimeObj.SetActive(false);
        }
    }
}