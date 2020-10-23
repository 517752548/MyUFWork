package com.imop.lj.gameserver.guide;

import com.imop.lj.gameserver.human.Human;

public interface IGuidePusher {
	
	/**
	 * 检查玩家是否满足显示新手引导的条件
	 * @param human
	 * @return
	 */
	boolean checkCond(Human human);
	
	/**
	 * 给玩家提示有新手引导了
	 */
	void sendHasGuide(Human human);
	
	/**
	 * 给玩家发新手引导信息
	 * @param human
	 */
	void sendGuideInfo(Human human);
	
}
