using DG.Tweening;
using System.Collections;
using BetaFramework;
using Scripts_Game.Managers;
using UnityEngine;
using UnityEngine.UI;

public class FBLoginGiftDialog : UIWindowBase
{
    public GameObject rubyFly;
    public Text value;
    public Transform coinsStartTrans;

    private int rewardCoin;

    public override void OnOpen()
    {
        base.OnOpen();
        rewardCoin = Const.FacebookLoginCoin;
        if (rewardCoin <= 0) rewardCoin = 50;
    }

    public void Confirm()
    {
        if (!false)
        {
//            DataManager.PlayerData.FbLoginGiftClaimed = true;
            //DataManager.CurrencyData.CreditBalance (int.Parse(DataManager.SourceData.FileInit.FacebookLoginReward));
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
            //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_btn_normal);
            RewardMgr.RewardInventory(InventoryType.Coin, rewardCoin, RewardSource.fbLogin);
//            DataManager.PropStatisticsData.AddReward(PropStatisticsData.RewardLocation.fb_login, 0, 0, 0, rewardCoin);
//            ReportDataManager.FBFirstLoginCoin();
            CommandBinder.DispatchBinding(GameEvent.RubyFly, new RubyFlyCommand.RubyFlyData(RubyType.stack, coinsStartTrans.position,0));
            Close();
        }
        Timer.Schedule(this,10, () =>
        {
            Close();
        });
        
    }


}