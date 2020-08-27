using BetaFramework;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.OneWord
{
    public class OneWordRewardVideo : GameEntity
    {
        private OneWordGameManager _GameManager { get { return m_baseGameManager as OneWordGameManager; } }

        public void Init()
        {
            gameObject.SetActive(false);
        }

        private bool IsRewardVideoReady()
        {
            return false;
        }
        
        public void CheckRefresh()
        {
            if (AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().CanRefreshExLevel)
            {
                gameObject.SetActive(true);
            }
        }

        public void OnClickWatch()
        {
            if (IsRewardVideoReady())
            {
            }
            else
            {
                UIManager.ShowMessage("No video, please try later!");
            }
        }

        private void OnRewarded(bool reward)
        {
            if (!reward)
                return;
            var level = _GameManager.GetLevel();
            AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().SetExLevelEnable(level.LevelID());
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
	}
}