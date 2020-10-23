package com.imop.lj.gameserver.goodactivity.target.impl;

import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.goodactivity.activity.impl.TotalChargeBuyActivity;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityTotalChargeBuyTargetTemplate;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.AbstractGoodActivityUserDataModel;
import com.imop.lj.gameserver.human.Human;

public class TotalChargeBuyTargetUnit extends AbstractGoodActivityTargetUnit {

	public TotalChargeBuyTargetUnit(TotalChargeBuyActivity activity, 
			GoodActivityTotalChargeBuyTargetTemplate targetTpl) {
		super(activity, targetTpl);
	}
	
	@Override
	public GoodActivityTotalChargeBuyTargetTemplate getTargetTpl() {
		return (GoodActivityTotalChargeBuyTargetTemplate) super.getTargetTpl();
	}
	
	/**
	 * 获取目标需要的充值数量
	 * @return
	 */
	public int getChargeNum() {
		return getTargetTpl().getChargeNum();
	}
	
	@Override
	public int getShowNeedNum() {
		return getChargeNum();
	}
	
	@Override
	public int getShowNeedNumSecond() {
		return getTargetTpl().getCostBond();
	}


	@Override
	public boolean isNeedCost() {
		return true;
	}
	
	@Override
	public boolean isCostEnough(Human human, boolean notice) {
		if (!isNeedCost()) {
			return true;
		}
		if (human == null) {
			return false;
		}
		
		int needBond = getTargetTpl().getCostBond();
		//元宝是否足够
		if (!human.hasEnoughMoney(needBond, Currency.BOND, false)) {
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
		if (human == null) {
			return false;
		}
		
		int needBond = getTargetTpl().getCostBond();
		//扣除消耗
		boolean flag = human.costMoney(needBond, Currency.BOND, true, 0, MoneyLogReason.GA_TOTOAL_CHARGE_BUY_COST, 
				MoneyLogReason.GA_TOTOAL_CHARGE_BUY_COST.getReasonText(), 0);
		if (!flag) {
			Loggers.goodActivityLogger.error("cost money failed!humanId=" + human.getUUID() + ";pid=" + human.getPassportId());
			return false;
		}
		
		return true;
	}
	
	@Override
	protected boolean condCheckImpl(AbstractUserGoodActivity userActivity, boolean notice, Human human) {
		AbstractGoodActivityUserDataModel userDataModel = userActivity.getUserDataModel();
		//如果该目标已经领取过奖励，就不能再领取了
		if (userDataModel != null && userDataModel.hasGiveReward(getTargetId())) {
			return false;
		}
		
		if (userActivity != null && userDataModel != null) {
			if (userDataModel.getCurNum(getTargetId()) >= getChargeNum()) {
				return true;
			}
		}
		if (notice && human != null) {
			human.sendErrorMessage(LangConstants.GOOD_ACTIVITY_TOTOAL_CHARGE_BUY_FAIL1);
		}
		return false;
	}
}
