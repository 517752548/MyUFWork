package com.imop.lj.gameserver.charge;

import java.sql.Timestamp;
import java.text.MessageFormat;
import java.util.List;

import com.imop.lj.common.LogReasons;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.time.TimeService;
import com.imop.lj.core.util.Range;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.currency.CurrencyProcessor;
import com.imop.lj.gameserver.human.Human;

public class ChargeManager {

	/** 主人 */
	private Human owner;

	private ChargePrizeService prizeService;

	private TimeService timeService;


	public ChargeManager(Human owner,ChargePrizeService prizeService,TimeService timeService) {
		this.owner = owner;
		this.prizeService = prizeService;
		this.timeService = timeService;
	}


	public Human getOwner() {
		return owner;
	}

	public void checkAndResetTodayCharge(Timestamp lastChargeTime)
	{
		if(lastChargeTime == null) {
			this.getOwner().setTodayCharge(0);
			return;
		}

		if(!TimeUtils.isSameDay(timeService.now(), lastChargeTime.getTime()))
		{
			this.getOwner().setTodayCharge(0);
		}
	}

	/**
	 * 根据本次充值金额进行充值奖励给予
	 * @param chargeDiamond
	 */
	public void onPlusTodayCharge(int chargeDiamond)
	{
		int todayCharge = this.getOwner().getTodayCharge();

		//增加当日充值总金额
		this.getOwner().setTodayCharge(todayCharge + chargeDiamond);

		List<Range<Integer>> ranges = prizeService.getRangesByCharge(todayCharge,chargeDiamond);

		int chargePrize = 0;//充值奖励
		for(Range<Integer> range : ranges)
		{
			chargePrize += prizeService.getTransferExtraPrize(range);
		}

		if(chargePrize > 0 )
		{
			//系统赠送的元宝都是绑定元宝。
			CurrencyProcessor.instance.giveMoney(owner,chargePrize, Currency.SYS_BOND, true,
					LogReasons.MoneyLogReason.TODAY_CHARGE_PRIZE,
					MessageFormat.format(LogReasons.MoneyLogReason.TODAY_CHARGE_PRIZE.getReasonText(), todayCharge,chargeDiamond), true);
		}
	}

	public void refreshChargePanelInfo(int vipLevel,int vipNextLevel,int totalCharge,int nextVipDiffCharge,int nextVipTotalCharge)
	{

//		GCShowChargePanel gcShowChargePanel = new GCShowChargePanel();
//		gcShowChargePanel.setVipLevel(vipLevel);
//		gcShowChargePanel.setTotalCharge(totalCharge);
//		if(vipLevel == VipLevel.VIP10.getIndex())
//		{
//			gcShowChargePanel.setNextVipLevel(0);
//			gcShowChargePanel.setNextVipDesc(new String[0]);
//			gcShowChargePanel.setDiffCharge(0);
//			gcShowChargePanel.setNextVipTotalCharge(0);
//		}
//		else
//		{
//			List<VipFunctionInfo> descs = Globals.getVipService().getDesc(vipNextLevel);
//			List<String> descList = Lists.newArrayList();
//			for(VipFunctionInfo desc :descs)
//			{
//				if(!StringUtils.isEmpty(desc.getDesc()))
//				{
//					descList.add(desc.getDesc());
//				}
//			}
//			gcShowChargePanel.setNextVipLevel(vipNextLevel);
//			gcShowChargePanel.setNextVipDesc(descList.toArray(new String[0]));
//			gcShowChargePanel.setDiffCharge(nextVipDiffCharge);
//			gcShowChargePanel.setNextVipTotalCharge(nextVipTotalCharge);
//		}
//
//		gcShowChargePanel.setChargePrizeInfo(buildChargePrizeInfo());
//		this.owner.sendMessage(gcShowChargePanel);
	}

	/**
	 *
	 * 您还需要充值多少钱就可以获得当日充值奖励
	 *
	 * @return
	 */
	public String buildChargePrizeInfo()
	{
		String result = "";
		//当前充值距离下一级的差值
		int transferDiff = 0;
		//下一级充值奖励值
		int nextPrize = 0;

		Timestamp lastChargeTime = this.getOwner().getLastChargeTime();
		if(lastChargeTime != null)
		{
			//如果不是同一天,每日充值清零
			this.checkAndResetTodayCharge(lastChargeTime);
		}

		//取得当天的充值额度
		int todayTransfer = this.getOwner().getTodayCharge();
		Range<Integer> range = prizeService.getTransferRange(todayTransfer);
		if(range == null)
		{
			if(todayTransfer < prizeService.getMinTransferPrize()) //充值低于100
			{
				transferDiff = prizeService.getMinTransferPrize() - todayTransfer;
				Range<Integer> minPrizeRange = prizeService.getTransferRange(prizeService.getMinTransferPrize());
				nextPrize = prizeService.getTransferExtraPrize(minPrizeRange);
			}
		}
		else
		{
			Range<Integer> nextRange = prizeService.getNextTransferRange(range);
			if(nextRange != null)
			{
				transferDiff = nextRange.getMin() - todayTransfer;
				nextPrize = prizeService.getTransferExtraPrize(nextRange);
			}
		}
		if(transferDiff != 0 && nextPrize != 0)
		{
			result = Globals.getLangService().readSysLang(LangConstants.TODAY_TRANSFER_PRIZE_INFO,transferDiff,nextPrize);
		}
		return result;
	}

}
