using System;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.OneWord
{
    public class OneWordWinState : BaseWinState
    {
        public override bool CheckCondition()
        {
            return GameManager.GetEntity<OneWordCellManager>().IsCompleted;
        }

        public override void Enter()
        {
            base.Enter();
            GameManager.GetEntity<OneWordCellManager>().ShowComplete();
            //UIManager.OpenUIAsync(ViewConst.prefab_WellDownDialog, null, (Action)OnCloseDlg);
        }

        private void OnCloseDlg()
        {
            UIManager.OpenUIAsync(ViewConst.prefab_GameLoadingWindow, (ui, para) =>
            {
                //(m_baseGameManager as OneWordGameManager).SaveLocal();
                MainSceneDirector.Instance.SwitchUi(GameUI.Home, ok =>
                {
                    Timer.Schedule(AppThreadController.instance, 0.2f, () =>
                    {
                        UIManager.CloseUIWindow(
                            UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow)); 
                    });
                });

            });
            OnCompleted();
        }
    }
}