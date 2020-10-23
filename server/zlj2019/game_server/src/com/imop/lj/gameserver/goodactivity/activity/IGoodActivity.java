package com.imop.lj.gameserver.goodactivity.activity;

import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.GoodActivityType;
import com.imop.lj.gameserver.human.Human;

public interface IGoodActivity {
	
	long getId();
	
	GoodActivityType getGoodActivityType();
	
	String getName();
	
	String getDesc();
	
	int getIcon();
	
	int getNameIcon();
	
	int getTitleIcon();
	
	long getStartTime();
	
	long getEndTime();
	
	boolean isOpening();
	
	void onActivityStart();
	
	void onActivityEnd();
	
	long getCountDownTime();
	
	String getCountDownTimeDesc();
	
	String getSelfInfo(Human human);
	
	int getShowTargetType();
	
	/**
	 * 获取活动目标信息，json格式
	 * @param charId
	 * @return
	 */
	String getTargetJsonStr(long charId);
	
	/**
	 * 是否有可领取的奖励
	 * @param charId
	 * @return
	 */
	boolean hasBonus(long charId);
	
	/**
	 * 玩家能否参加/看到该活动
	 * @param charId
	 * @return
	 */
	boolean canUserJoin(long charId);
	
}
