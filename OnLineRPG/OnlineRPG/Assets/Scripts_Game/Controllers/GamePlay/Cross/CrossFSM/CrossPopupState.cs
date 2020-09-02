using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.Cross
{
    public class CrossPopupState : BasePopupState
    {
        enum GameMsg
        {
            none,
            BusGiftPanel
        }

        private GameMsg msg = GameMsg.none;

        public override bool CheckCondition()
        {
            if (Const.AutoPlay)
            {
                return false;
            }

            if (DataManager.businessGiftData.LevelStart())
            {
                msg = GameMsg.BusGiftPanel;
                return true;
            }

            return base.CheckCondition();
        }

        public override void Enter()
        {
            base.Enter();
            ShowMessage();

        }

        private void ShowMessage()
        {
            switch (msg)
            {
                case GameMsg.BusGiftPanel:
                    UICallBack closeback = OnUiClose;
                    if (DataManager.businessGiftData.shopItem.Length == 1)
                    {
                        UIManager.OpenUIAsync(ViewConst.prefab_ShopLimitBagOneDialog, closeback);
                    }
                    else
                    {
                        UIManager.OpenUIAsync(ViewConst.prefab_ShopLimitBagTwoDialog, closeback);
                    }

                    break;
            }
        }

        private void OnUiClose(UIWindowBase UI, params object[] objs)
        {
            Complete();
        }

        public override void Leave()
        {
            base.Leave();
        }
    }
}