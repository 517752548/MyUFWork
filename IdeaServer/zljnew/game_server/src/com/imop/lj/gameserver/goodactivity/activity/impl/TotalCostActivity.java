package com.imop.lj.gameserver.goodactivity.activity.impl;

import com.imop.lj.gameserver.goodactivity.activity.AbstractGoodActivity;
import com.imop.lj.gameserver.goodactivity.persistance.GoodActivityPO;
import com.imop.lj.gameserver.goodactivity.target.impl.TotalCostTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityTargetTemplate;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityTotalCostTargetTemplate;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.useractivity.impl.TotalCostUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.impl.TotalCostUserDataModel;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * 累计消耗活动
 * @author yu.zhao
 *
 */
public class TotalCostActivity extends AbstractGoodActivity {

	public TotalCostActivity(GoodActivityPO goodActivityPO) {
		super(goodActivityPO);
	}
	
	@Override
	protected void buildTargetUnit(GoodActivityTargetTemplate targetTpl) {
		addTargetUnit(new TotalCostTargetUnit(this, (GoodActivityTotalCostTargetTemplate) targetTpl));
	}
	
	@Override
	public AbstractUserGoodActivity buildUserGoodActivity(long charId) {
		return new TotalCostUserGoodActivity(charId, this);
	}
	
	@Override
	public EventType getBindEventType() {
		return TotalCostUserDataModel.BIND_EVENT_TYPE;
	}

//	/**
//	 * 需要周期性结算奖励
//	 */
//	@Override
//	public boolean needGiveUnGotRewardPeriod() {
//		return getTpl().getUpdateDay() > 0;
//	}
//	
//	@Override
//	public boolean isReachGiveRewardPeriodTime() {
//		// 检查是否到了结算周期
//		return Globals.getTimeService().now() >= getNextRefreshTime();
//	}
}
