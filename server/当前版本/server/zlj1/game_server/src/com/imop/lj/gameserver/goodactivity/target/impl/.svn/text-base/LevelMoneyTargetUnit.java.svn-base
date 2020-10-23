package com.imop.lj.gameserver.goodactivity.target.impl;

import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.goodactivity.activity.impl.LevelMoneyActivity;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityLevelMoneyTargetTemplate;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.AbstractGoodActivityUserDataModel;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.vip.VipDef.VipFuncTypeEnum;

public class LevelMoneyTargetUnit extends AbstractGoodActivityTargetUnit {

	public LevelMoneyTargetUnit(LevelMoneyActivity activity, 
			GoodActivityLevelMoneyTargetTemplate targetTpl) {
		super(activity, targetTpl);
	}
	
	@Override
	public GoodActivityLevelMoneyTargetTemplate getTargetTpl() {
		return (GoodActivityLevelMoneyTargetTemplate) super.getTargetTpl();
	}
	
	@Override
	public int getShowGroupId() {
		return getTargetTpl().getGroupId();
	}
	
	@Override
	public int getCurNum(AbstractUserGoodActivity userActivity) {
		return getTargetTpl().getCostBond();
	}
	
	@Override
	public int getCurNumSecond(AbstractUserGoodActivity userActivity) {
		return getTargetTpl().getNeedLevel();
	}
	
	@Override
	public int getShowNeedNum() {
		return getTargetTpl().getVipLimitId();
	}
	
	@Override
	public int getShowNeedNumSecond() {
		return (int)getTimeLimit();
	}
	
	/**
	 * 获取目标需要的等级
	 * @return
	 */
	public int getNeedLevel() {
		return getTargetTpl().getNeedLevel();
	}
	
	@Override
	public int getPreTargetId() {
		return getTargetTpl().getPreTargetId();
	}
	
	@Override
	public VipFuncTypeEnum getVipLimit() {
		return getTargetTpl().getVipLimit();
	}
	
	@Override
	public boolean isNeedCost() {
		return getTargetTpl().getCostBond() > 0;
	}
	
	@Override
	public long getTimeLimit() {
		return getTargetTpl().getTimeLimitNum() * TimeUtils.HOUR;
	}
	
	@Override
	public boolean isTimeLimitOK() {
		long timeLimit = getTimeLimit();
		if (timeLimit == 0) {
			return true;
		}
		
		//目标的时间限制在有效期内
		if (getActivity().getStartTime() + timeLimit >= Globals.getTimeService().now()) {
			return true;
		}
		
		return false;
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
		boolean flag = human.costMoney(needBond, Currency.BOND, false, 0, MoneyLogReason.GA_LEVEL_MONEY_COST, 
				MoneyLogReason.GA_LEVEL_MONEY_COST.getReasonText(), 0);
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
		return true;
	}
}
