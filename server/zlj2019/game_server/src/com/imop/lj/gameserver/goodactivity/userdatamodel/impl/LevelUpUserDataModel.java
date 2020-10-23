package com.imop.lj.gameserver.goodactivity.userdatamodel.impl;

import java.util.Collection;

import com.imop.lj.gameserver.common.event.LeaderLevelUpEvent;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.target.impl.LevelUpTargetUnit;
import com.imop.lj.gameserver.goodactivity.useractivity.impl.LevelUpUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.AbstractGoodActivityUserDataModel;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * 升级活动玩家数据对象类
 * @author yu.zhao
 *
 */
public class LevelUpUserDataModel extends AbstractGoodActivityUserDataModel {
	
	public static EventType BIND_EVENT_TYPE = EventType.LeaderLevelUp;
	
	public LevelUpUserDataModel(LevelUpUserGoodActivity userActivity) {
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
		
		LeaderLevelUpEvent event = (LeaderLevelUpEvent) e;
		int level = event.getLevel();
		
		updateFlag = checkOnLevelUp(level);
		return updateFlag;
	}
	
	@Override
	public boolean autoJoin(Human human) {
		int level = human.getLevel();
		boolean updateFlag = checkOnLevelUp(level);
		return updateFlag;
	}
	
	/**
	 * 升级时更新数据
	 * @param level
	 * @return
	 */
	protected boolean checkOnLevelUp(int level) {
		boolean updateFlag = false;
		Collection<AbstractGoodActivityTargetUnit> targetList = getUserActivity().getGoodActivity().getTargetList();
		for (AbstractGoodActivityTargetUnit target : targetList) {
			LevelUpTargetUnit curTarget = (LevelUpTargetUnit) target;
			int targetId = curTarget.getTargetId();
			// 获取每个档位需要的充值数量 
			int needLevel = curTarget.getNeedLevel();
			if (level >= needLevel) {
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
