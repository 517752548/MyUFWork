package com.imop.lj.gameserver.goodactivity.activity.impl;

import com.imop.lj.gameserver.goodactivity.activity.AbstractGoodActivity;
import com.imop.lj.gameserver.goodactivity.persistance.GoodActivityPO;
import com.imop.lj.gameserver.goodactivity.target.impl.DayTotalChargeTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityDayTotalChargeTargetTemplate;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityTargetTemplate;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.useractivity.impl.DayTotalChargeUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.impl.DayTotalChargeUserDataModel;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * 每日累计充值活动
 * @author yu.zhao
 *
 */
public class DayTotalChargeActivity extends AbstractGoodActivity {

	public DayTotalChargeActivity(GoodActivityPO goodActivityPO) {
		super(goodActivityPO);
	}
	
	@Override
	protected void buildTargetUnit(GoodActivityTargetTemplate targetTpl) {
		addTargetUnit(new DayTotalChargeTargetUnit(this, (GoodActivityDayTotalChargeTargetTemplate) targetTpl));
	}
	
	@Override
	public AbstractUserGoodActivity buildUserGoodActivity(long charId) {
		return new DayTotalChargeUserGoodActivity(charId, this);
	}
	
	@Override
	public EventType getBindEventType() {
		return DayTotalChargeUserDataModel.BIND_EVENT_TYPE;
	}

}
