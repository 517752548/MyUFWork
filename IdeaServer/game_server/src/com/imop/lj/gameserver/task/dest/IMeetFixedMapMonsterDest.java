package com.imop.lj.gameserver.task.dest;

/**
 * 指定遇怪方案的任务目标，类似的完成条件都需要实现该接口
 * @author yu.zhao
 *
 */
public interface IMeetFixedMapMonsterDest {

	int getMapId();
	
	int getMeetMonsterPlanId();
	
}
