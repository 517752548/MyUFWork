package com.imop.lj.gameserver.mall.msg;

import java.util.LinkedList;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;

/**
 * 更新商城限时队列
 * 
 * @author xiaowei.liu
 * 
 */
public class ChangeMallTimeLimitQueuMessage extends SysInternalMessage {
	private long startTime;
	private String timeLimitQueueStr;
	private LinkedList<Integer> timeLimitQueue;
	
	public ChangeMallTimeLimitQueuMessage(long startTime, String timeLimitQueueStr, LinkedList<Integer> timeLimitQueue){
		this.startTime = startTime;
		this.timeLimitQueueStr = timeLimitQueueStr;
		this.timeLimitQueue = timeLimitQueue;
	}
	
	@Override
	public void execute() {
		Globals.getMallService().changeStartTimeAndQueue(startTime, timeLimitQueueStr, timeLimitQueue);
	}

}
