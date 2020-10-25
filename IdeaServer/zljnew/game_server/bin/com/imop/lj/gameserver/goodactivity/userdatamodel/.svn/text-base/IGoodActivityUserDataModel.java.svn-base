package com.imop.lj.gameserver.goodactivity.userdatamodel;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;


public interface IGoodActivityUserDataModel {
	
	/**
	 * 玩家数据更新
	 * @param e
	 */
	boolean onPlayerDoEvent(Event<?> e);
	
	/**
	 * 完成目标后，检查是否满足领取条件
	 * @param goodActivityId
	 * @param finishTargetId
	 * @return
	 */
	boolean checkOnFinishTarget(long goodActivityId, int finishTargetId);
	
	EventType getBindEventType();
	
	boolean isCareEvent(Event<?> e);
	
	boolean hasUnGiveBonus(int targetId);
	
	boolean hasGiveReward(int targetId);
	
	boolean onGiveBonus(int targetId, int giveBonusNum);
	
	/**
	 * 玩家数据解析
	 * @return
	 */
	String userDataToJson();
	
	void userDataFromJson(String jsonStr);
	
	/**
	 * 自动参加活动时更新数据，一些特殊的活动如等级排名、vip等级等需要
	 * @param human
	 */
	boolean autoJoin(Human human);
	
	/**
	 * 玩家该活动是否有可领取的奖励
	 * @return
	 */
	boolean hasBonus();

}
