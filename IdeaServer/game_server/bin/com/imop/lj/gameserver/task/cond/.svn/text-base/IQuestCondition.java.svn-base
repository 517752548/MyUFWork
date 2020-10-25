package com.imop.lj.gameserver.task.cond;

import com.imop.lj.gameserver.human.Human;

/**
 *
 * 检查玩家是否满足该任务的一些条件
 *
 *
 */
public interface IQuestCondition {

	/**
	 * 用于检查该任务是否对玩家可见
	 *
	 * @param human
	 * @return
	 */
	boolean canSee(Human human);

	/**
	 * 检查玩家是否可以接该任务
	 *
	 * @param human
	 * @return
	 */
	boolean canAccept(Human human);

	/**
	 * 在接任务时做一些处理，比如物品的扣减，钱的扣减
	 *
	 * @param human
	 * @return
	 */
	boolean onAccept(Human human);

	/**
	 * 接任务条件不满足时的提示
	 *
	 * @return
	 */
	String getErrorDesc(Human human);

}
