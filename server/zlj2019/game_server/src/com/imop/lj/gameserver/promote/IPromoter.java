package com.imop.lj.gameserver.promote;

import com.imop.lj.gameserver.human.Human;

public interface IPromoter {

	/**
	 * 是否有可以提升
	 * @param human
	 * @return
	 */
	public boolean canPromote(Human human);
}
