package com.imop.lj.gm.model.log;

import java.util.List;

/**
 * 战争日志
 *
 * @author fanghua.cui
 */
public class WarLog extends BaseLog{
	private int warType;

	public WarLog() {
	}

	public int getWarType() {
		return warType;
	}

	public void setWarType(int warType) {
		this.warType = warType;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(warType);
		return list;
	}
}