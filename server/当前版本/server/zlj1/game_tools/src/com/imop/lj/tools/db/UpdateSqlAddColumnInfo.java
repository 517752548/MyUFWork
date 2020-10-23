package com.imop.lj.tools.db;

public class UpdateSqlAddColumnInfo {
	
	private String tableName;
	private String columnName;
	
	private String columnType;
	private int columnLen;
	private String columnDefault;
	
	private boolean notNull;
	
	public String getTableName() {
		return tableName;
	}
	public void setTableName(String tableName) {
		this.tableName = tableName;
	}
	public String getColumnName() {
		return columnName;
	}
	public void setColumnName(String columnName) {
		this.columnName = columnName;
	}
	public String getColumnType() {
		return columnType;
	}
	public void setColumnType(String columnType) {
		this.columnType = columnType;
	}
	
	public int getColumnLen() {
		return columnLen;
	}
	public void setColumnLen(int columnLen) {
		this.columnLen = columnLen;
	}
	public String getColumnDefault() {
		return columnDefault;
	}
	public void setColumnDefault(String columnDefault) {
		this.columnDefault = columnDefault;
	}
	public boolean isNotNull() {
		return notNull;
	}
	public void setNotNull(boolean notNull) {
		this.notNull = notNull;
	}
	@Override
	public String toString() {
		return "UpdateSqlAddColumnInfo [tableName=" + tableName
				+ ", columnName=" + columnName + ", columnType=" + columnType
				+ ", columnLen=" + columnLen + ", columnDefault="
				+ columnDefault + ", notNull=" + notNull + "]";
	}
	
}
