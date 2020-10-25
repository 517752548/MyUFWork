package com.imop.lj.gameserver.goodactivity.target.impl;

import java.text.MessageFormat;

import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.MathUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.goodactivity.activity.impl.BuyMoneyActivity;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityBuyMoneyTargetTemplate;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.AbstractGoodActivityUserDataModel;
import com.imop.lj.gameserver.human.Human;

public class BuyMoneyTargetUnit extends AbstractGoodActivityTargetUnit {

	public BuyMoneyTargetUnit(BuyMoneyActivity activity, 
			GoodActivityBuyMoneyTargetTemplate targetTpl) {
		super(activity, targetTpl);
	}
	
	@Override
	public GoodActivityBuyMoneyTargetTemplate getTargetTpl() {
		return (GoodActivityBuyMoneyTargetTemplate) super.getTargetTpl();
	}
	
	@Override
	public int getPreTargetId() {
		return getTargetTpl().getPreTargetId();
	}
	
	@Override
	public boolean isNeedCost() {
		return true;
	}
	
	@Override
	public int getCurNum(AbstractUserGoodActivity userActivity) {
		return getTargetTpl().getCostMoneyNum();
	}
	
	@Override
	public int getCurNumSecond(AbstractUserGoodActivity userActivity) {
		return getTargetTpl().getCostMoneyType();
	}
	
	@Override
	public int getShowNeedNum() {
		return getTargetTpl().getGiveMoneyMax();
	}
	
	@Override
	public int getShowNeedNumSecond() {
		return getTargetTpl().getGiveMoneyType();
	}
	
	
	@Override
	public boolean isCostEnough(Human human, boolean notice) {
		if (!isNeedCost()) {
			return true;
		}
		if (human == null) {
			return false;
		}
		
		Currency currency = getTargetTpl().getCostCurrency();
		int needNum = getTargetTpl().getCostMoneyNum();
		
		//货币是否足够
		if (!human.hasEnoughMoney(needNum, currency, false)) {
			if (notice) {
				human.sendErrorMessage(LangConstants.GOOD_ACTIVITY_LEVEL_MONEY_FAIL1);
			}
			return false;
		}
		
		return true;
	}
	
	@Override
	public boolean costOnGiveBonus(Human human) {
		if(!isCostEnough(human, false)) {
			return false;
		}
		
		Currency currency = getTargetTpl().getCostCurrency();
		int needNum = getTargetTpl().getCostMoneyNum();
		//扣除消耗
		boolean flag = human.costMoney(needNum, currency, true, 0, MoneyLogReason.GA_BUY_MONEY_COST, 
				MoneyLogReason.GA_BUY_MONEY_COST.getReasonText(), 0);
		if (!flag) {
			Loggers.goodActivityLogger.error("cost money failed!humanId=" + human.getUUID() + ";pid=" + human.getPassportId());
			return false;
		}
		
		return true;
	}
	
	@Override
	public boolean giveSpecialReward(Human human, int giveBonusNum) {
		if (human == null || giveBonusNum <= 0) {
			return false;
		}
		
		Currency currency = getTargetTpl().getGiveCurrency();
		int min = getTargetTpl().getGiveMoneyMin();
		int max = getTargetTpl().getGiveMoneyMax();
		boolean flag = true;
		for (int i = 0; i < giveBonusNum; i++) {
			int giveNum = MathUtils.random(min, max);
			boolean tf = human.giveMoney(giveNum, currency, false, MoneyLogReason.GA_BUY_MONEY_REWARD, 
					MoneyLogReason.GA_BUY_MONEY_REWARD.getReasonText());
			flag &= tf;
			if (tf) {
				//增加活动日志，显示用
				String logContent = MessageFormat.format(getTargetTpl().getLogContent(), human.getName(), giveNum, 
						Globals.getLangService().readSysLang(currency.getNameKey()));
				getActivity().addLog(logContent);
			}
		}
		
		return flag;
	}
	
	@Override
	protected boolean condCheckImpl(AbstractUserGoodActivity userActivity, boolean notice, Human human) {
		AbstractGoodActivityUserDataModel userDataModel = userActivity.getUserDataModel();
		//如果该目标已经领取过奖励，就不能再领取了
		if (userDataModel != null && userDataModel.hasGiveReward(getTargetId())) {
			return false;
		}
		return true;
	}
}
