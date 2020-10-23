package com.imop.lj.gameserver.goodactivity.userdatamodel.impl;

import com.imop.lj.gameserver.common.event.LoginDaysAddEvent;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.target.impl.SevenDayLoginTargetUnit;
import com.imop.lj.gameserver.goodactivity.useractivity.impl.SevenDayLoginUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.AbstractGoodActivityUserDataModel;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

import java.util.Collection;

/**
 * 升级活动玩家数据对象类
 * @author yu.zhao
 *
 */
public class SevenDayLoginUserDataModel extends AbstractGoodActivityUserDataModel {

	public static EventType BIND_EVENT_TYPE = EventType.LoginDaysAdd;

	public SevenDayLoginUserDataModel(SevenDayLoginUserGoodActivity userActivity) {
		super(userActivity);
	}
	
	@Override
	public EventType getBindEventType() {
		return BIND_EVENT_TYPE;
	}
	
	@Override
	public boolean onPlayerDoEvent(Event<?> e) {
		boolean updateFlag = false;
		if (!isCareEvent(e)) {
			return updateFlag;
		}

		LoginDaysAddEvent event = (LoginDaysAddEvent) e;

		updateFlag = checkOnLogin(event.getInfo());
		return updateFlag;
	}
	
	@Override
	public boolean autoJoin(Human human) {
//		int level = human.getLevel();
//		boolean updateFlag = checkOnLogin(level);
//		return updateFlag;
		return true;
	}
	
	/**
	 * 登陆的玩家
	 * @param human
	 * @return
	 */
	protected boolean checkOnLogin(Human human) {
		boolean updateFlag = false;
		Collection<AbstractGoodActivityTargetUnit> targetList = getUserActivity().getGoodActivity().getTargetList();
		int hadLoginDay = human.getTotalLoginDays();
		for (AbstractGoodActivityTargetUnit target : targetList) {
			SevenDayLoginTargetUnit curTarget = (SevenDayLoginTargetUnit) target;
			int targetId = curTarget.getTargetId();
			// 获取每个档位需要的充值数量 
			int needDay = curTarget.getNeedDay();
			if (hadLoginDay >= needDay) {
				// 等级满足对应的档位需求，则可领奖
				updateFlag |= setReachNumOne(targetId);
			} else {
				break;
			}
		}
		if (updateFlag) {
			// 存库
			save();
		}
		return updateFlag;
	}
	
}
