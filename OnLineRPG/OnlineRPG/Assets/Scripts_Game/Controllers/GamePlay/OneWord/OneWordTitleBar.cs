using BetaFramework;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.OneWord
{
    public class OneWordTitleBar : GameEntity
    {
        public void OnClickBack()
        {
            UIManager.OpenUIAsync(ViewConst.prefab_GameLoadingWindow, (ui, para) =>
            {
                (m_baseGameManager as OneWordGameManager).SaveLocal();
                MainSceneDirector.Instance.SwitchUi(GameUI.Home, ok =>
                {
                    Timer.Schedule(AppThreadController.instance, 0.2f, () =>
                    {
                        UIManager.CloseUIWindow(
                            UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow)); 
                    });
                });
                
            });
            m_baseGameManager.GameTempData.ReportOutLevel();
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
        }

        public void OnClickHelp()
        {
            UIManager.OpenUIAsync(ViewConst.prefab_QuestionRestDialog);
        }
    }
}