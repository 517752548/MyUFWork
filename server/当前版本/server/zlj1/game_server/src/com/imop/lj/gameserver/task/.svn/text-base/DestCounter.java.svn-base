package com.imop.lj.gameserver.task;

import com.imop.lj.gameserver.task.dest.IQuestDestination;

public class DestCounter {
	/** 要求的数量 */
	private final int reqNum;
	/** 已经搞定的数量 */
	private int gotNum;
	/** 目标 */
	private IQuestDestination dest;

	public DestCounter(IQuestDestination dest, int reqNum) {
		this.dest = dest;
		this.reqNum = reqNum;
		this.gotNum = 0;
	}

	public int getGotNum() {
		return gotNum;
	}

	public void setGotNum(int gotNum) {
		this.gotNum = gotNum;
	}

	public IQuestDestination getDest() {
		return dest;
	}

	public void setDest(IQuestDestination dest) {
		this.dest = dest;
	}

	public int getReqNum() {
		return reqNum;
	}
	
	public boolean canStatusBack() {
		return dest.canStatusBack();
	}
	
	@SuppressWarnings("rawtypes")
	public int getDestGotNum(AbstractTask task) {
		return dest.getGotNum(task);
	}
}
