package com.imop.lj.gameserver.goodactivity.activity.impl;

import com.imop.lj.gameserver.goodactivity.activity.AbstractGoodActivity;
import com.imop.lj.gameserver.goodactivity.persistance.GoodActivityPO;
import com.imop.lj.gameserver.goodactivity.target.impl.SevenDayLoginTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivitySevenDayLoginTargetTemplate;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityTargetTemplate;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.useractivity.impl.SevenDayLoginUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.impl.SevenDayLoginUserDataModel;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * 升级活动
 * @author yu.zhao
 *
 */
public class SevenDayLoginActivity extends AbstractGoodActivity {

	public SevenDayLoginActivity(GoodActivityPO goodActivityPO) {
		super(goodActivityPO);
	}
	
	@Override
	protected void buildTargetUnit(GoodActivityTargetTemplate targetTpl) {
		addTargetUnit(new SevenDayLoginTargetUnit(this, (GoodActivitySevenDayLoginTargetTemplate) targetTpl));
	}
	
	@Override
	public AbstractUserGoodActivity buildUserGoodActivity(long charId) {
		return new SevenDayLoginUserGoodActivity(charId, this);
	}
	
	@Override
	public EventType getBindEventType() {
		return SevenDayLoginUserDataModel.BIND_EVENT_TYPE;
	}
	
	/**
	 * 需要自动参加
	 */
	@Override
	public boolean needAutoJoin() {
		return true;
	}

}
