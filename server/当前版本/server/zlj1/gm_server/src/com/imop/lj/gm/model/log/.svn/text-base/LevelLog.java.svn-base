package com.imop.lj.gm.model.log;

import java.util.List;

import com.imop.lj.gm.utils.DateUtil;

public class LevelLog extends BaseLog {
    private int buildingId;
    private String buildingName;
    private long upLevelTime;
    private long intervalTime;



	public int getBuildingId() {
		return buildingId;
	}



	public void setBuildingId(int buildingId) {
		this.buildingId = buildingId;
	}



	public String getBuildingName() {
		return buildingName;
	}



	public void setBuildingName(String buildingName) {
		this.buildingName = buildingName;
	}



	public long getUpLevelTime() {
		return upLevelTime;
	}



	public void setUpLevelTime(long upLevelTime) {
		this.upLevelTime = upLevelTime;
	}



	public long getIntervalTime() {
		return intervalTime;
	}



	public void setIntervalTime(long intervalTime) {
		this.intervalTime = intervalTime;
	}



	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(buildingId);
		list.add(buildingName);
		list.add(DateUtil.formateDateLong(upLevelTime));
		return list;
	}
}
