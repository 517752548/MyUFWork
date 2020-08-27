using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClassicTittleBar : BaseTittleBar
{
    public TextMeshProUGUI LevelTittle;
    private ClassicGameManager _GameManager { get { return m_baseGameManager as ClassicGameManager; } }
    public void ClickBack()
    {
        UIManager.OpenUIAsync(ViewConst.prefab_GameLoadingWindow, (ui, para) =>
        {
            (m_baseGameManager as ClassicGameManager).SaveLocal();
            MainSceneDirector.Instance.SwitchUi(GameUI.Home, ok =>
            {
                Timer.Schedule(AppThreadController.instance, 0.2f, () =>
                {
                    UIManager.CloseUIWindow(
                        UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow)); 
                    TimersManager.SetTimer(0.5f, () =>
                    {
                        GC.Collect();
                        Resources.UnloadUnusedAssets();
                    });
                });
            });

        });
        _GameManager.GameTempData.ReportOutLevel();
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
    }

    public void Init()
    {
        ClassicWorldEntity world =  AppEngine.SSystemManager.GetSystem<ClassicGameSystem>()
            .GetClassicWorld(AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value);
        LevelTittle.text = world.Name;
    }
}
