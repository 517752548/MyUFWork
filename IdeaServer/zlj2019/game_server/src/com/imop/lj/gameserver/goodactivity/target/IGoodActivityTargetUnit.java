package com.imop.lj.gameserver.goodactivity.target;

import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;

public interface IGoodActivityTargetUnit {
	
	/**
	 * 目标信息json串
	 * @return
	 */
	String toJson(AbstractUserGoodActivity userActivity);
	
}
