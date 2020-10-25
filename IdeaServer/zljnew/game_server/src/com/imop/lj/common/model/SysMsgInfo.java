package com.imop.lj.common.model;

public class SysMsgInfo {
	private String content;
	private short showType;
	
	public SysMsgInfo() {
		
	}
	
	public SysMsgInfo(String content, short showType) {
		this.content = content;
		this.showType = showType;
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public short getShowType() {
		return showType;
	}

	public void setShowType(short showType) {
		this.showType = showType;
	}
	
	@Override
	public boolean equals(Object o) {
		return false;
	}

	@Override
	public String toString() {
		return "SysMsgInfo [content=" + content + ", showType=" + showType
				+ "]";
	}
	
}
