package com.imop.lj.gm.model.log;

import java.util.List;

public class UserActionLog extends BaseLog {
//	message_type
//	message_param
//	exectime
//	error
	private int message_type;
	private int message_param;
	private int exectime;
	private String error;
	public int getMessage_type() {
		return message_type;
	}
	public void setMessage_type(int message_type) {
		this.message_type = message_type;
	}
	public int getMessage_param() {
		return message_param;
	}
	public void setMessage_param(int message_param) {
		this.message_param = message_param;
	}
	public int getExectime() {
		return exectime;
	}
	public void setExectime(int exectime) {
		this.exectime = exectime;
	}
	public String getError() {
		return error;
	}
	public void setError(String error) {
		this.error = error;
	}
	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(this.message_type);
		list.add(this.message_param);
		list.add(this.exectime);
		return list;
	}
}
