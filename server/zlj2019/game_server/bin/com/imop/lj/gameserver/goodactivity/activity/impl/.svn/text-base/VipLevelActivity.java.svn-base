package com.imop.lj.gameserver.goodactivity.activity.impl;

import com.imop.lj.gameserver.goodactivity.activity.AbstractGoodActivity;
import com.imop.lj.gameserver.goodactivity.persistance.GoodActivityPO;
import com.imop.lj.gameserver.goodactivity.target.impl.VipLevelTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityVipLevelTargetTemplate;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityTargetTemplate;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.useractivity.impl.VipLevelUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.impl.VipLevelUserDataModel;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * vip等级活动
 * @author yu.zhao
 *
 */
public class VipLevelActivity extends AbstractGoodActivity {

	public VipLevelActivity(GoodActivityPO goodActivityPO) {
		super(goodActivityPO);
	}
	
	@Override
	protected void buildTargetUnit(GoodActivityTargetTemplate targetTpl) {
		addTargetUnit(new VipLevelTargetUnit(this, (GoodActivityVipLevelTargetTemplate) targetTpl));
	}
	
	@Override
	public AbstractUserGoodActivity buildUserGoodActivity(long charId) {
		return new VipLevelUserGoodActivity(charId, this);
	}
	
	@Override
	public EventType getBindEventType() {
		return VipLevelUserDataModel.BIND_EVENT_TYPE;
	}
	
	/**
	 * 需要自动参加
	 */
	@Override
	public boolean needAutoJoin() {
		return true;
	}

}
