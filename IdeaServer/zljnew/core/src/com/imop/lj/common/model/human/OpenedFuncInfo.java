package com.imop.lj.common.model.human;

public class OpenedFuncInfo {

	/** 功能Id */
	private int id;
	/** 是否开启 */
	private int opened;
	/** 序号 */
	private int num;
	/** 图标 */
	private String icon;
	/** 说明 */
	private String desc;

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public int getOpened() {
		return opened;
	}

	public void setOpened(int opened) {
		this.opened = opened;
	}

	public int getNum() {
		return num;
	}

	public void setNum(int num) {
		this.num = num;
	}

	public String getIcon() {
		return icon;
	}

	public void setIcon(String icon) {
		this.icon = icon;
	}

	public String getDesc() {
		return desc;
	}

	public void setDesc(String desc) {
		this.desc = desc;
	}

}
