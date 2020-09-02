using System;
using BetaFramework;
using TMPro;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.Cross.Dialog
{
    public class CrossUnlockDialog : UIWindowBase
    {
        public Action<bool> callback;
        private const int needCoin = 200;
        public TextMeshProUGUI level;
        public TextMeshProUGUI[] coinNum;
        public override void OnOpen()
        {
            base.OnOpen();
            callback = objs[0] as Action<bool>;
            level.text = string.Format("Unlock Elite Level:{0}",
                AppEngine.SSystemManager.GetSystem<EliteSystem>().currentLevelID);
            for (int i = 0; i < coinNum.Length; i++)
            {
                coinNum[i].text = string.Format("x{0}", needCoin);
            }
            
        }

        public void ClickClose()
        {
            Close();
            callback?.Invoke(false);
        }
        public void OnClickCoin()
        {
            //AppEngine.SyncManager.Data.Coin.Value -= configData.Coast;
            if (AppEngine.SyncManager.Data.Coin.Value >= needCoin)
            {
                AppEngine.SyncManager.Data.Coin.Value -= needCoin;
            AppEngine.SyncManager.Data.Elitedata.Value.GetElitePref(AppEngine.SSystemManager.GetSystem<EliteSystem>().currentWordID).SetLevelUnlock(AppEngine.SSystemManager.GetSystem<EliteSystem>().currentLevelID - 1);
            Close();
            callback?.Invoke(true);
            }
            else
            {
                UIManager.ShowMessage("Coin Not Enough!");
            }
        }

        public void OnClickTick()
        {
            if (AppEngine.SyncManager.Data.EliteTicket.Value >= 1)
            {
                AppEngine.SyncManager.Data.EliteTicket.Value -= 1;
            AppEngine.SyncManager.Data.Elitedata.Value.GetElitePref(AppEngine.SSystemManager.GetSystem<EliteSystem>().currentWordID).SetLevelUnlock(AppEngine.SSystemManager.GetSystem<EliteSystem>().currentLevelID - 1);
            Close();
            callback?.Invoke(true);
            }else
            {
                UIManager.ShowMessage("Ticket Not Enough!");
            }
        }
    }
}