package com.imop.lj.gameserver.goodactivity.userdatamodel.impl;

import java.util.Collection;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.target.impl.VipLevelTargetUnit;
import com.imop.lj.gameserver.goodactivity.useractivity.impl.VipLevelUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.AbstractGoodActivityUserDataModel;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * vip等级活动玩家数据对象类
 * @author yu.zhao
 *
 */
public class VipLevelUserDataModel extends AbstractGoodActivityUserDataModel {
	
	public static EventType BIND_EVENT_TYPE = EventType.VipStateChange;
	
	public VipLevelUserDataModel(VipLevelUserGoodActivity userActivity) {
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
		
		int vipLevel = Globals.getVipService().getCurVipLevel(getUserActivity().getCharId());
		updateFlag = checkOnVipStateChange(vipLevel);
		return updateFlag;
	}
	
	@Override
	public boolean autoJoin(Human human) {
		int vipLevel = Globals.getVipService().getCurVipLevel(human.getCharId());
		boolean updateFlag = checkOnVipStateChange(vipLevel);
		return updateFlag;
	}
	
	/**
	 * vip状态变化时，更新相关数据
	 * @param vipLevel
	 * @return
	 */
	protected boolean checkOnVipStateChange(int vipLevel) {
		boolean updateFlag = false;
		if (vipLevel <= 0) {
			return updateFlag;
		}
		Collection<AbstractGoodActivityTargetUnit> targetList = getUserActivity().getGoodActivity().getTargetList();
		for (AbstractGoodActivityTargetUnit target : targetList) {
			VipLevelTargetUnit curTarget = (VipLevelTargetUnit) target;
			int targetId = curTarget.getTargetId();
			// 获取每个档位需要的vip等级
			int needVipLevel = curTarget.getNeedVipLevel();
			if (vipLevel >= needVipLevel) {
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
