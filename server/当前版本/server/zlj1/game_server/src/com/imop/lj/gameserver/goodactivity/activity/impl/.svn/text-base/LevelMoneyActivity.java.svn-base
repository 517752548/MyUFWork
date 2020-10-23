package com.imop.lj.gameserver.goodactivity.activity.impl;

import com.imop.lj.gameserver.goodactivity.activity.AbstractGoodActivity;
import com.imop.lj.gameserver.goodactivity.persistance.GoodActivityPO;
import com.imop.lj.gameserver.goodactivity.target.impl.LevelMoneyTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityLevelMoneyTargetTemplate;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityTargetTemplate;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.useractivity.impl.LevelMoneyUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.impl.LevelMoneyUserDataModel;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * 开服基金活动
 * @author yu.zhao
 *
 */
public class LevelMoneyActivity extends AbstractGoodActivity {

	public LevelMoneyActivity(GoodActivityPO goodActivityPO) {
		super(goodActivityPO);
	}
	
	@Override
	protected void buildTargetUnit(GoodActivityTargetTemplate targetTpl) {
		addTargetUnit(new LevelMoneyTargetUnit(this, (GoodActivityLevelMoneyTargetTemplate) targetTpl));
	}
	
	@Override
	public AbstractUserGoodActivity buildUserGoodActivity(long charId) {
		return new LevelMoneyUserGoodActivity(charId, this);
	}
	
	@Override
	public EventType getBindEventType() {
		return LevelMoneyUserDataModel.BIND_EVENT_TYPE;
	}
	
	@Override
	public boolean needAutoJoin() {
		return true;
	}
}
