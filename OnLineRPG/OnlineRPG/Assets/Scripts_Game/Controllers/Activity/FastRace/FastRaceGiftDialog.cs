using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Scripts_Game.Managers;
using UnityEngine;
using UnityEngine.UI;

public class FastRaceGiftDialog : UIWindowBase
{

	public Text reward;
	public Transform coinTran;
	public GameObject btn;
	public override void OnOpen()
	{
		base.OnOpen();
		reward.text = "x " +  DataManager.FastRaceData.rewardNum.ToString();
	}

	public void OK()
	{
		//CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_btn_normal);
		btn.SetActive(false);
		StartCoroutine(ClaimCoroutine());
		Timer.Schedule(this,10, () =>
		{
			Close();
		});
	}
	
	private IEnumerator ClaimCoroutine()
	{
		RewardMgr.RewardInventory((InventoryType)DataManager.FastRaceData.rewardID,DataManager.FastRaceData.rewardNum,RewardSource.FastRace);
		//CommandBinder.DispatchBinding(GameEvent.RubyFly, new RubyFlyCommand.RubyFlyData(RubyType.stack, coinTran));
		//yield return SingCoin.f.FlyGolds(coinsStartTrans.position, false);
		//AppEngine.SSystemManager.GetSystem<BagSystem>().RewardItem(10,AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().coinNumber,"FastRace");
		//DataManager.currdata.CreditBalance(AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().coinNumber,RubyAniType.MoreCoin,1.2f);
		yield return new WaitForSeconds(1f);
		Close();
	}
}
