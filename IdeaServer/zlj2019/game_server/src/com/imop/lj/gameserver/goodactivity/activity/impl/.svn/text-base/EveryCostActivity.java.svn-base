package com.imop.lj.gameserver.goodactivity.activity.impl;

import com.imop.lj.gameserver.goodactivity.activity.AbstractGoodActivity;
import com.imop.lj.gameserver.goodactivity.persistance.GoodActivityPO;
import com.imop.lj.gameserver.goodactivity.target.impl.EveryCostTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityEveryCostTargetTemplate;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityTargetTemplate;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.useractivity.impl.EveryCostUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.impl.EveryCostUserDataModel;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * 每累计消耗活动
 * @author yu.zhao
 *
 */
public class EveryCostActivity extends AbstractGoodActivity {

	public EveryCostActivity(GoodActivityPO goodActivityPO) {
		super(goodActivityPO);
	}
	
	@Override
	protected void buildTargetUnit(GoodActivityTargetTemplate targetTpl) {
		addTargetUnit(new EveryCostTargetUnit(this, (GoodActivityEveryCostTargetTemplate) targetTpl));
	}
	
	@Override
	public AbstractUserGoodActivity buildUserGoodActivity(long charId) {
		return new EveryCostUserGoodActivity(charId, this);
	}
	
	@Override
	public EventType getBindEventType() {
		return EveryCostUserDataModel.BIND_EVENT_TYPE;
	}

}
