package com.imop.lj.tools.excel;

import java.util.List;

/**
 * 字段对象
 *
 *
 */
public class ExcelFieldObject {

	/** 类型 */
	private String fieldType;
	/** 名字 */
	private String fieldName;
	/** 第一个字母大写的名字 */
	private String bigName;
	/** 注解 */
	private List<String> anotations;
	/** 注释 */
	private String comment;
	/** 是否为X坐标 */
	private boolean xpoint;
	/** 是否为Y坐标 */
	private boolean ypoint;
	/** 最大值 */
	private int maxValue;
	/** 最小值 */
	private int minValue;
	/** 是否允许为空 */
	private boolean notNull;
	/** 起始行数 */
	private int startLine;
	/** 最大长度 */
	private int maxLen;
	/** 最小长度 */
	private int minLen;
	
	/** 客户端不需要 标识位 */
	private boolean notClient;
	/** 客户端类型，普通类型==服务器类型，自定义类型==去掉包名后的名字 */
	private String clientType;
	/** 客户端用的，自定义类型的字段数量 */
	private int unitFieldNum;
	/** 客户端用的，list的长度 */
	private int unitNum;
	/** 客户端用的，List<Long>中的类型，即Long */
	private String clientSubType;

	/**
	 * @param fieldType
	 * @param fieldName
	 * @param anotations
	 * @param comment
	 * @param xpoint
	 * @param ypoint
	 */
	public ExcelFieldObject(String fieldType, String fieldName,
			List<String> anotations, String comment, boolean xpoint,
			boolean ypoint, int maxValue, int minValue, boolean notNull,
			int startLine, int maxLen, int minLen, 
			boolean notClient, String clientType, int unitFieldNum, int unitNum) {
		super();
		this.fieldType = fieldType;
		this.fieldName = fieldName;
		this.anotations = anotations;
		this.comment = comment;
		this.xpoint = xpoint;
		this.ypoint = ypoint;
		this.maxValue = maxValue;
		this.minValue = minValue;
		this.notNull = notNull;
		this.startLine = startLine;
		this.maxLen = maxLen;
		this.minLen = minLen;
		this.notClient = notClient;
		this.clientType = clientType;
		this.unitFieldNum = unitFieldNum;
		this.unitNum = unitNum;
		
		// 首字母大写
		this.bigName = fieldName.substring(0, 1).toUpperCase()
				+ fieldName.substring(1);
		if (xpoint || ypoint) {
			if (minValue == -1) {
				this.minValue = 0;
			}
			if (maxValue == -1) {
				this.maxValue = 1000;
			}
		}
		
		this.clientSubType = clientType;
		if (clientSubType.contains("<")) {
			clientSubType = clientSubType.substring(clientSubType.indexOf("<") + 1, clientSubType.indexOf(">"));
		}
		
//		System.out.println("isUserDef() = " + isUserDef() + ";isList()=" + isList());
//		System.out.println("unitFieldNum=" + unitFieldNum + ";unitNum=" + unitNum + ";isUserDef=" + isUserDef());
	}

	public String getFieldType() {
		return fieldType;
	}

	public String getFieldName() {
		return fieldName;
	}

	public List<String> getAnotations() {
		return anotations;
	}

	public String getComment() {
		return comment;
	}

	public String getBigName() {
		return bigName;
	}

	public boolean isXpoint() {
		return xpoint;
	}

	public boolean isYpoint() {
		return ypoint;
	}

	public int getMaxValue() {
		return maxValue;
	}

	public int getMinValue() {
		return minValue;
	}

	public boolean isNotNull() {
		return notNull;
	}

	public int getStartLine() {
		return startLine;
	}

	public int getMaxLen() {
		return maxLen;
	}

	public int getMinLen() {
		return minLen;
	}

	public boolean isNotClient() {
		return notClient;
	}

	public String getClientType() {
		return clientType;
	}

	public int getUnitFieldNum() {
		return unitFieldNum;
	}

	public int getUnitNum() {
		return unitNum;
	}

	/**
	 * 是否用户自定义类型，即自定义的类
	 * @return
	 */
	public boolean isUserDef() {
		return !clientType.equalsIgnoreCase(fieldType);
	}

	public boolean isList() {
		return unitNum > 0;
	}

	public boolean isBaseType() {
		return unitFieldNum == 0 && unitNum == 0;
	}

	public String getClientSubType() {
		return clientSubType;
	}
	
}
