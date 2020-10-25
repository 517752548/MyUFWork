package com.imop.lj.gameserver.goodactivity.userdatamodel.impl;

import java.util.Collection;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.LeaderLevelUpEvent;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.target.impl.LevelMoneyTargetUnit;
import com.imop.lj.gameserver.goodactivity.useractivity.impl.LevelMoneyUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.AbstractGoodActivityUserDataModel;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * 开服基金活动玩家数据对象类
 * @author yu.zhao
 *
 */
public class LevelMoneyUserDataModel extends AbstractGoodActivityUserDataModel {
	
	public static EventType BIND_EVENT_TYPE = EventType.LeaderLevelUp;
	
	public LevelMoneyUserDataModel(LevelMoneyUserGoodActivity userActivity) {
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
		return true;
	}
	
	@Override
	public boolean checkOnFinishTarget(long goodActivityId, int finishTargetId) {
		Human human = Globals.getHumanCacheService().getHumanOnlineOrCache(getUserActivity().getCharId());
		if (human != null) {
			return checkOnLevelUp(human.getLevel());
		}
		return false;
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
			LevelMoneyTargetUnit curTarget = (LevelMoneyTargetUnit) target;
			int targetId = curTarget.getTargetId();
			//前置目标是否完成的标识位
			boolean preTargetFlag = target.isPreTargetFinished(getUserActivity());
			// 获取每个档位需要的充值数量 
			int needLevel = curTarget.getNeedLevel();
			if (!curTarget.isNeedCost() && preTargetFlag && level >= needLevel) {
				// 等级满足对应的档位需求，则可领奖
				updateFlag |= setReachNumOne(targetId);
			}
		}
		if (updateFlag) {
			// 存库
			save();
		}
		return updateFlag;
	}
	
	@Override
	public boolean needHideOnNothingToDo() {
		return true;
	}
	
	@Override
	public boolean hasNothingToDo() {
		//全都领取了，隐藏
		if (super.hasNothingToDo()) {
			return true;
		}
		
		Collection<AbstractGoodActivityTargetUnit> targetList = getUserActivity().getGoodActivity().getTargetList();
		for (AbstractGoodActivityTargetUnit targetUnit : targetList) {
			//没有前置的目标，任意一个没有到时间，则返回false
			if (targetUnit.getTimeLimit() > 0 &&
					targetUnit.isTimeLimitOK()) {
				return false;
			}
			
			//参加的目标组中，如果有没领取的，则返回false
			if (targetUnit.hasPreTarget()
					&& hasGiveReward(targetUnit.getPreTargetId())
					&& !hasGiveReward(targetUnit.getTargetId())) {
				return false;
			}
		}
		
		//其他情况返回true
		return true;
	}
}
