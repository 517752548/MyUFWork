package com.imop.lj.gameserver.pubtask;

import net.sf.json.JSONArray;

import com.imop.lj.gameserver.task.TaskDef.TaskStatus;

public class BackupPubTask {
	private int questId;
	private int star;
	private TaskStatus status = TaskStatus.INIT;
	
	public BackupPubTask() {
		
	}
	
	public BackupPubTask(int questId, int star, TaskStatus status) {
		this.questId = questId;
		this.star = star;
		this.status = status;
	}

	public int getQuestId() {
		return questId;
	}

	public void setQuestId(int questId) {
		this.questId = questId;
	}

	public TaskStatus getStatus() {
		return status;
	}

	public void setStatus(TaskStatus status) {
		this.status = status;
	}
	
	public int getStar() {
		return star;
	}

	public void setStar(int star) {
		this.star = star;
	}

	public String toJson() {
		JSONArray json = new JSONArray();
		json.add(questId);
		json.add(star);
		json.add(status.getIndex());
		return json.toString();
	}
	
	public void fromJsonStr(String str) {
		if (str == null || str.isEmpty()) {
			return;
		}
		JSONArray json = JSONArray.fromObject(str);
		if (json == null || json.isEmpty()) {
			return;
		}
		
		questId = json.getInt(0);
		star = json.getInt(1);
		status = TaskStatus.indexOf(json.getInt(2));
	}

	@Override
	public String toString() {
		return "BackupPubTask [questId=" + questId + ", star=" + star
				+ ", status=" + status + "]";
	}
	
}
