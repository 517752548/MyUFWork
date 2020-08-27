using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class DailyTittleBar : GameEntity
{
    private bool canClick = true;
    public void Init()
    {
        
    }
    public void ClickSetting()
    {
        if(!canClick)
            return;
        TimersManager.SetTimer(0.5f, () =>
        {
            canClick = true;
        });
        UIManager.OpenUIAsync(ViewConst.prefab_ClassicSettingDialog);
    }
    public void ClickBack()
    {

        UIManager.OpenUIAsync(ViewConst.prefab_GameLoadingWindow, (ui, para) =>
        {
            (m_baseGameManager as DailyGameManager).SaveLocal();
            MainSceneDirector.Instance.SwitchUi(GameUI.Home, ok =>
            {
                Timer.Schedule(AppThreadController.instance, 0.2f, () =>
                {
                    UIManager.CloseUIWindow(
                        UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow)); 
                    TimersManager.SetTimer(0.5f, () =>
                    {
                        UIManager.OpenUIAsync(ViewConst.prefab_DailyChallengeEventDialog);
                    });
                });
            });

        });
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
    }
}
