using UnityEngine;
using System.Collections;
using BetaFramework;
using EventUtil;
using Scripts_Game.Managers;
using UnityEngine.UI;

public class VideoGiftDialog : UIWindowBase
{
    public Text txtCoin;
    private int rewardCoin;
    private string txtFormat = "Thank you for watching!\nYou got<color=\"#81191C\"> {0} FREE COINS</color>";
    public Transform coinContent;

    public override void OnOpen()
    {
        base.OnOpen();
        rewardCoin = (int) objs[0];
        txtCoin.text = string.Format(txtFormat, rewardCoin);
    }

    public void Claim()
    {
        EventDispatcher.TriggerEvent(GlobalEvents.SkipBalanceAni);
        RewardMgr.RewardInventory(InventoryType.Coin, rewardCoin, DataManager.ProcessData.advideosource);
        Vector3 pos = coinContent.position;
        TimersManager.SetTimer(0.2f,
            () =>
            {
                CommandBinder.DispatchBinding(GameEvent.RubyFly,
                    new RubyFlyCommand.RubyFlyData(RubyType.stack, pos, rewardCoin));
            });
        Close();
    }
}