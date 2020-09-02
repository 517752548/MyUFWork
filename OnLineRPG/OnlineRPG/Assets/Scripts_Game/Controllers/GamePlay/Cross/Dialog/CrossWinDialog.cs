using BetaFramework;
using DG.Tweening;
using Scripts_Game.Controllers.Cup;
using Scripts_Game.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts_Game.Controllers.GamePlay.Cross.Dialog
{
    public class CrossWinDialog : UIWindowBase
    {
        public CupCollectProgressBar cupBar;
        public Button continueBtn;

        private int cellCount;
        private bool isReplay = false;
        public override void OnOpen()
        {
            base.OnOpen();

            SetContinueBtn(false);
            cellCount = (int)objs[0];
            isReplay = AppEngine.SSystemManager.GetSystem<EliteSystem>().IsReplayCurLevel();
            int star = AppEngine.SSystemManager.GetSystem<EliteSystem>().GetCurrentLevelStars();
            if (isReplay)
            {
                anim.SetTrigger("winagain");
            }
            else
            {
                RewardMgr.RewardInventory(InventoryType.Cup, cellCount, RewardSource.elite);
                switch (star)
                {
                    case 1:
                        anim.SetTrigger("winone");
                        break;
                    case 2:
                        anim.SetTrigger("wintwo");
                        break;
                    case 3:
                    default:
                        anim.SetTrigger("winthree");
                        break;
                }
                cupBar.Show();
                cupBar.startBar.Show(cellCount);
                AppEngine.SSystemManager.GetSystem<EliteSystem>().FinishCurrentLevel();
            }
            //cupBar.SetActive(false);
            //cupBar.startBar.SetActive(false);
        }

        private void SetContinueBtn(bool enable)
        {
            continueBtn.interactable = enable;
            var cg = continueBtn.transform.GetChild(0).GetComponent<CanvasGroup>();
            cg.interactable = enable;
            cg.blocksRaycasts = enable;
            //cg.alpha
            cg.DOFade(enable ? 1f : 0f, 0.2f);
        }

        public void OnFirstAniOver()
        {
            if (isReplay)
            {
                SetContinueBtn(true);
            }
            else
            {
                cupBar.Fly(() =>
                {
                    SetContinueBtn(true);
                });
            }
        }

        public void OnClickContinue()
        {
            UIManager.OpenUIAsync(ViewConst.prefab_GameLoadingWindow, (ui, para) =>
            {
                UIManager.CloseUIWindow(this);
                UIManager.OpenUIAsync(ViewConst.prefab_HappinessSelectLevelDialog);
                MainSceneDirector.Instance.SwitchUi(GameUI.Home, ok =>
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