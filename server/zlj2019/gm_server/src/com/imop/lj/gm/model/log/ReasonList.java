/**
 *
 */
package com.imop.lj.gm.model.log;

import java.sql.Timestamp;

/**
 * @author linfan
 *
 */
public class ReasonList {
	/** 主键 */
	private int logUid;

	/** 日志类型 */
	private int logType;

	/** 日志时间 */
	private Timestamp logTime;

	/** 日志表 */
	private String logTable;

	/** 日志Field */
	private String logField;

	/** 原因 */
	private int reason;

	/** 原因名称 */
	private String reasonName;

	public int getLogUid() {
		return logUid;
	}

	public void setLogUid(int logUid) {
		this.logUid = logUid;
	}

	public int getLogType() {
		return logType;
	}

	public void setLogType(int logType) {
		this.logType = logType;
	}

	public Timestamp getLogTime() {
		return logTime;
	}

	public void setLogTime(Timestamp logTime) {
		this.logTime = logTime;
	}

	public String getLogTable() {
		return logTable;
	}

	public void setLogTable(String logTable) {
		this.logTable = logTable;
	}

	public String getLogField() {
		return logField;
	}

	public void setLogField(String logField) {
		this.logField = logField;
	}

	public int getReason() {
		return reason;
	}

	public void setReason(int reason) {
		this.reason = reason;
	}

	public String getReasonName() {
		return reasonName;
	}

	public void setReasonName(String reasonName) {
		this.reasonName = reasonName;
	}

}
