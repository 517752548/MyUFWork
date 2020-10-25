package com.imop.lj.gameserver.goodactivity.activity.impl;

import com.imop.lj.gameserver.goodactivity.activity.AbstractGoodActivity;
import com.imop.lj.gameserver.goodactivity.persistance.GoodActivityPO;
import com.imop.lj.gameserver.goodactivity.target.impl.NormalTotalChargeTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityNormalTotalChargeTargetTemplate;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityTargetTemplate;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.useractivity.impl.NormalTotalChargeUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.impl.NormalTotalChargeUserDataModel;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * 普通累计充值活动
 * @author yu.zhao
 *
 */
public class NormalTotalChargeActivity extends AbstractGoodActivity {

	public NormalTotalChargeActivity(GoodActivityPO goodActivityPO) {
		super(goodActivityPO);
	}
	
	@Override
	protected void buildTargetUnit(GoodActivityTargetTemplate targetTpl) {
		addTargetUnit(new NormalTotalChargeTargetUnit(this, (GoodActivityNormalTotalChargeTargetTemplate) targetTpl));
	}
	
	@Override
	public AbstractUserGoodActivity buildUserGoodActivity(long charId) {
		return new NormalTotalChargeUserGoodActivity(charId, this);
	}
	
	@Override
	public EventType getBindEventType() {
		return NormalTotalChargeUserDataModel.BIND_EVENT_TYPE;
	}

}
