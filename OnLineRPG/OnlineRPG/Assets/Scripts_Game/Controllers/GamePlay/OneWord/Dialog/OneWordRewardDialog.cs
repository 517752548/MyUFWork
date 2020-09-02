using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using EventUtil;
using Scripts_Game.Controllers.Cup;
using Scripts_Game.Managers;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace Scripts_Game.Controllers.GamePlay.OneWord.Dialog
{
    public class OneWordRewardDialog : UIWindowBase
    {
        public Transform layout;
        public CupCollectProgressBar cupBar;
        public Button continueBtn;

        private int rewardCoin = 0;
        private int rewardCupCount;
        private List<RewardInventory> rewardList;
        private List<CommonRewardItem> _rewardItemsList = new List<CommonRewardItem>();

        public override void OnOpen()
        {
            base.OnOpen();
            string rewardId = (string) objs[0];
            rewardCupCount = (int) objs[1];

            rewardList = RewardMgr.GetRewards(rewardId);

            RewardMgr.RewardInventory(rewardList, RewardSource.OneWord);
            RewardMgr.RewardInventory(InventoryType.Cup, rewardCupCount, RewardSource.OneWord);

            ShowItem();
            cupBar.Show();
        }

        public void OnClickClaim()
        {
            if (rewardCoin > 0)
            {
                transform.GetChild(0).GetComponent<CanvasGroup>().DOFade(0, 0.3f);
                CommandBinder.DispatchBinding(GameEvent.RubyFly,
                    new RubyFlyCommand.RubyFlyData(RubyType.stack, layout.position, rewardCoin));
                DOTween.Sequence().InsertCallback(0.8f, () => { UIManager.CloseUIWindow(this, false); });
            }
            else
            {
                UIManager.CloseUIWindow(this);
            }
        }

        private async void ShowItem()
        {
            GameObject Item = await Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_CommonRewardItem).Task;

            int rewardCount = rewardList.Count;
            GameObject rewardItem = null;

            for (int i = 0; i < rewardCount; i++)
            {
                rewardItem = Instantiate(Item, layout, false);
                CommonRewardItem _commonRewardItem = rewardItem.GetComponent<CommonRewardItem>();
                _commonRewardItem.SetData(rewardList[i]);
                _rewardItemsList.Add(_commonRewardItem);

                if (rewardList[i].type == InventoryType.Coin)
                {
                    EventDispatcher.TriggerEvent(GlobalEvents.SkipBalanceAni);
                    rewardCoin = rewardList[i].count;
                }
            }

            AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_GiftDialog);
            StartCoroutine(DoAnimator());
        }

        private IEnumerator DoAnimator()
        {
            for (int i = 0; i < _rewardItemsList.Count; i++)
            {
                _rewardItemsList[i].DoPiaAnim();
                yield return new WaitForSeconds(0.5f);
            }

            cupBar.startBar.Show(rewardCupCount);
            cupBar.Fly(() => { SetContinueBtn(true);});
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
    }
}