package com.imop.lj.gameserver.goodactivity.activity.impl;

import com.imop.lj.gameserver.goodactivity.activity.AbstractGoodActivity;
import com.imop.lj.gameserver.goodactivity.persistance.GoodActivityPO;
import com.imop.lj.gameserver.goodactivity.target.impl.LevelUpTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityLevelUpTargetTemplate;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityTargetTemplate;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.useractivity.impl.LevelUpUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.impl.LevelUpUserDataModel;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * 升级活动
 * @author yu.zhao
 *
 */
public class LevelUpActivity extends AbstractGoodActivity {

	public LevelUpActivity(GoodActivityPO goodActivityPO) {
		super(goodActivityPO);
	}
	
	@Override
	protected void buildTargetUnit(GoodActivityTargetTemplate targetTpl) {
		addTargetUnit(new LevelUpTargetUnit(this, (GoodActivityLevelUpTargetTemplate) targetTpl));
	}
	
	@Override
	public AbstractUserGoodActivity buildUserGoodActivity(long charId) {
		return new LevelUpUserGoodActivity(charId, this);
	}
	
	@Override
	public EventType getBindEventType() {
		return LevelUpUserDataModel.BIND_EVENT_TYPE;
	}
	
	/**
	 * 需要自动参加
	 */
	@Override
	public boolean needAutoJoin() {
		return true;
	}

}
