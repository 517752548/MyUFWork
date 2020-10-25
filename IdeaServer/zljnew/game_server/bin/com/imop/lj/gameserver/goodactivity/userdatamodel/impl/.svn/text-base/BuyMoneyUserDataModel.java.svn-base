package com.imop.lj.gameserver.goodactivity.userdatamodel.impl;

import com.imop.lj.gameserver.goodactivity.useractivity.impl.BuyMoneyUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.AbstractGoodActivityUserDataModel;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * 招财进宝活动玩家数据对象类
 * @author yu.zhao
 *
 */
public class BuyMoneyUserDataModel extends AbstractGoodActivityUserDataModel {
	
	public BuyMoneyUserDataModel(BuyMoneyUserGoodActivity userActivity) {
		super(userActivity);
	}

	@Override
	public boolean onPlayerDoEvent(Event<?> e) {
		return false;
	}

	@Override
	public EventType getBindEventType() {
		return null;
	}
	
	@Override
	public boolean needHideOnNothingToDo() {
		return true;
	}
	
	@Override
	public boolean autoJoin(Human human) {
		return true;
	}
	
}
