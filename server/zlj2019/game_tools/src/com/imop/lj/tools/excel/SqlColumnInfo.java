package com.imop.lj.tools.excel;

public class SqlColumnInfo {
	public String name;
	public String type;
	public Class<?> typeClz;
	
	public SqlColumnInfo() {
		
	}
	
	public String getDbType() {
		String dbType = "";
		switch (type) {
		case "int":
		case "integer":
		case "long":
		case "short":
		case "byte":
			dbType = "INTEGER NOT NULL DEFAULT 0";
			break;
		case "float":
			dbType = "FLOAT NOT NULL DEFAULT 0";
			break;
		case "bool":
		case "boolean":
			dbType = "BOOL NOT NULL DEFAULT 0";
			break;
		case "string":
		default:
			dbType = "VARCHAR NOT NULL DEFAULT ''";
			break;
		}
		return dbType;
	}

	@Override
	public String toString() {
		return "SqlColumnInfo [name=" + name + ", type=" + type + ", clz=" + typeClz + "]";
	}
	
}
