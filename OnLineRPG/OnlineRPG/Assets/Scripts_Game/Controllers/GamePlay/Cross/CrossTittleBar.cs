using System;
using BetaFramework;
using TMPro;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.Cross
{
    public class CrossTittleBar : BaseTittleBar
    {
        public TextMeshProUGUI LevelTittle;
        
        private CrossGameManager _GameManager { get { return m_baseGameManager as CrossGameManager; } }
        public void ClickBack()
        {
            UIManager.OpenUIAsync(ViewConst.prefab_GameLoadingWindow, (ui, para) =>
            {
                _GameManager.SaveLocal();
                UIManager.OpenUIAsync(ViewConst.prefab_HappinessSelectLevelDialog);
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
            //_GameManager.GameTempData.ReportOutLevel();
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
        }

        public void Init()
        {
            LevelTittle.text = "";
        }
    }
}