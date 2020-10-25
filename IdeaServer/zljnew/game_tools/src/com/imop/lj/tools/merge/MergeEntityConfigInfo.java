package com.imop.lj.tools.merge;

public class MergeEntityConfigInfo {
	private boolean globals;

	private boolean empty;

	private boolean deleted;
	
	private boolean bindCharId;
	
	private boolean bindCharName;

	private String className;

	private String fullClassName;

	private String mergeModelName;

	private String tableName;

	private String idClassName;

	public boolean isGlobals() {
		return globals;
	}

	public void setGlobals(boolean globals) {
		this.globals = globals;
	}

	public boolean isEmpty() {
		return empty;
	}

	public void setEmpty(boolean empty) {
		this.empty = empty;
	}

	public String getClassName() {
		return className;
	}

	public void setClassName(String className) {
		this.className = className;
	}

	public String getMergeModelName() {
		return mergeModelName;
	}

	public void setMergeModelName(String mergeModelName) {
		this.mergeModelName = mergeModelName;
	}

	public String getTableName() {
		return tableName;
	}

	public void setTableName(String tableName) {
		this.tableName = tableName;
	}


	public String getIdClassName() {
		return idClassName;
	}

	public void setIdClassName(String idClassName) {
		this.idClassName = idClassName;
	}

	public String getFullClassName() {
		return fullClassName;
	}

	public void setFullClassName(String fullClassName) {
		this.fullClassName = fullClassName;
	}

	public boolean isDeleted() {
		return deleted;
	}

	public void setDeleted(boolean deleted) {
		this.deleted = deleted;
	}

	public boolean isBindCharId() {
		return bindCharId;
	}

	public void setBindCharId(boolean bindCharId) {
		this.bindCharId = bindCharId;
	}

	public boolean isBindCharName() {
		return bindCharName;
	}

	public void setBindCharName(boolean bindCharName) {
		this.bindCharName = bindCharName;
	}

	@Override
	public String toString() {
		return "MergeEntityConfigInfo [globals=" + globals + ", empty=" + empty
				+ ", deleted=" + deleted + ", bindCharId=" + bindCharId
				+ ", bindCharName=" + bindCharName + ", className=" + className
				+ ", fullClassName=" + fullClassName + ", mergeModelName="
				+ mergeModelName + ", tableName=" + tableName
				+ ", idClassName=" + idClassName + "]";
	}
}
