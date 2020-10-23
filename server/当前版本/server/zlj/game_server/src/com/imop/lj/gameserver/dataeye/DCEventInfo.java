package com.imop.lj.gameserver.dataeye;

import java.util.Map;

public class DCEventInfo {
	private String eventId;
	private Map<String, String> labelMap;
	private int duration;
	
	public String getEventId() {
		return eventId;
	}
	public void setEventId(String eventId) {
		this.eventId = eventId;
	}
	public Map<String, String> getLabelMap() {
		return labelMap;
	}
	public void setLabelMap(Map<String, String> labelMap) {
		this.labelMap = labelMap;
	}
	public int getDuration() {
		return duration;
	}
	public void setDuration(int duration) {
		this.duration = duration;
	}
	
}
