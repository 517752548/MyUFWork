package com.imop.lj.gm.model.log;

import java.util.List;

public class ArenaLog extends BaseLog {

	private int cwinTime;
	private int totalTime;
	private int rank;
	private int countDelta;
	private int countResult;
	private long opponents;
	public int getCwinTime() {
		return cwinTime;
	}
	public void setCwinTime(int cwinTime) {
		this.cwinTime = cwinTime;
	}
	public int getTotalTime() {
		return totalTime;
	}
	public void setTotalTime(int totalTime) {
		this.totalTime = totalTime;
	}
	public int getRank() {
		return rank;
	}
	public void setRank(int rank) {
		this.rank = rank;
	}
	public int getCountDelta() {
		return countDelta;
	}
	public void setCountDelta(int countDelta) {
		this.countDelta = countDelta;
	}
	public int getCountResult() {
		return countResult;
	}
	public void setCountResult(int countResult) {
		this.countResult = countResult;
	}
	public long getOpponents() {
		return opponents;
	}
	public void setOpponents(long opponents) {
		this.opponents = opponents;
	}
	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(cwinTime);
		list.add(totalTime);
		list.add(rank);
		list.add(countDelta);
		list.add(countResult);
		list.add(opponents);
		return list;
	}
}
