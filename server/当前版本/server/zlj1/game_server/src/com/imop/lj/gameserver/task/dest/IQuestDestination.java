package com.imop.lj.gameserver.task.dest;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.DestType;

/**
 * 
 * 任务完成条件，表示一件完成任务必须做的事或者一件做了会导致任务失败的事
 * 
 * 
 *
 */
public interface IQuestDestination {
	
	/**
	 * 在接任务前，检查该任务目标是否要接
	 * 
	 * @param human
	 * @return
	 */
	boolean canAccept(Human human);
	
	/**
	 * 触发此任务目标蕴含的接任务后的事件，例如护送npc开始行走，给玩家发一些任务物品
	 * 
	 * @param human
	 */
	void onAccept(Human human);
	
	/**
	 * 是否处于可以完成此目标的状态，用于一些特殊的任务，在任务目标完成计数加一时需要满足特定的状态，比如身上有某个物品等
	 * 
	 * @param human
	 * @return
	 */
	boolean isInFinishStatus(Human human);
	
	/**
	 * 触发此任务目标完成时的事件
	 * 
	 * @param human
	 */
	boolean onDestFinish(Human human);
	
	/**
	 * 触发的交任务的事件
	 * 
	 * @param human
	 * @return
	 */
	boolean onQuestFinish(Human human);
	
	/**
	 * 触发放弃任务时的事件
	 * 
	 * @param human
	 * @return
	 */
	boolean onQuestGiveUp(Human human);
	
	/**
	 * 此任务目标加载后调用，用于在系统中部署与任务相关的其他系统的功能，例如npc的对话功能等
	 */
	void onLoad();

	/**
	 * @return 目标类型
	 * @see IQuestDestination.Type
	 */
	DestType getDestType();
	
	/**
	 * 任务目标的要求计数，例如要求杀死多少个怪等
	 * 
	 * @return
	 */
	int getRequiredNum();
	
	/**
	 * 返回此目标实例的一个唯一的key，此key能唯一标示完成该任务目标需要做的事，一般以该目标的主参数构建，例如杀怪目标可以用怪物Id，
	 * 与npc对话的目标可以用npcId，给npc送物品可可以用npcId物品Id等参数拼接在一起的字符串。
	 * 
	 * 注意： 1.这些key的实现类必须具有正确hashCode()与equals()定义的。
	 * 2.填表示一定要注意对于同一个任务不能有两个此值相同的任务目标，这样会造成错误。例如一个任务有两个任务目标，目标一杀10只狼，目标2杀20只狼。
	 * 如果真有类似需求，可以考虑将更多信息并入instKey中，来使一个任务的目标中都有不同的instKey
	 * 
	 * @return
	 */
	Object getInstKey();
	
	
	/**
	 * 判断任务是否满足条件
	 * 
	 * @param human
	 * @return
	 */
	@SuppressWarnings("rawtypes")
	boolean evaluate(AbstractTask task);
	
	@SuppressWarnings("rawtypes")
	boolean init(AbstractTask task);
	
	@SuppressWarnings("rawtypes")
	boolean onFinishTask(AbstractTask task);
	
	/**
	 * 任务状态是否可回退，即是否状态类任务，如拥有A道具B个，当道具消耗掉时会回退
	 * @return
	 */
	boolean canStatusBack();
	
	/**
	 * 获取任务计数的分子，可回退类型任务使用
	 * @param task
	 * @return
	 */
	@SuppressWarnings("rawtypes")
	int getGotNum(AbstractTask task);
}
