package com.imop.lj.gameserver.goodactivity.activity.impl;

import com.imop.lj.gameserver.goodactivity.activity.AbstractGoodActivity;
import com.imop.lj.gameserver.goodactivity.persistance.GoodActivityPO;
import com.imop.lj.gameserver.goodactivity.target.impl.TotalChargeBuyTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityTotalChargeBuyTargetTemplate;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityTargetTemplate;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.useractivity.impl.TotalChargeBuyUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.impl.TotalChargeBuyUserDataModel;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * 一元购类型充值活动
 * @author yu.zhao
 *
 */
public class TotalChargeBuyActivity extends AbstractGoodActivity {

	public TotalChargeBuyActivity(GoodActivityPO goodActivityPO) {
		super(goodActivityPO);
	}
	
	@Override
	protected void buildTargetUnit(GoodActivityTargetTemplate targetTpl) {
		addTargetUnit(new TotalChargeBuyTargetUnit(this, (GoodActivityTotalChargeBuyTargetTemplate) targetTpl));
	}
	
	@Override
	public AbstractUserGoodActivity buildUserGoodActivity(long charId) {
		return new TotalChargeBuyUserGoodActivity(charId, this);
	}
	
	@Override
	public EventType getBindEventType() {
		return TotalChargeBuyUserDataModel.BIND_EVENT_TYPE;
	}

}
